using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class Adventure : ConfigData<AdventureItem, short>
{
	public static class DefKey
	{
		public const short ReturnBambooHouse = 0;

		public const short DownRiver = 1;

		public const short RockBamboo = 2;

		public const short MonkeyHero = 3;

		public const short VilliageChange = 4;

		public const short AbandonedPost = 5;

		public const short UnderhillRiver = 6;

		public const short ValleyExit = 7;

		public const short TombImmortal = 8;

		public const short WulinConference = 9;

		public const short BlackBambooAppear = 10;

		public const short LandOfTrance = 11;

		public const short SectMainStoryKongsang_1 = 12;

		public const short SectMainStoryFulong_3 = 13;

		public const short SectMainStoryXuehou_2 = 14;

		public const short SectMainStoryEmei_2 = 15;

		public const short SectMainStoryFulong_1 = 16;

		public const short SectMainStoryRanshan_2 = 17;

		public const short SectMainStoryRemakeYuanshan_1 = 18;

		public const short SectMainStoryYuanshan_2 = 19;

		public const short SectMainStoryRanshan_1 = 20;

		public const short SectMainStoryShixiang_1 = 21;

		public const short SectMainStoryZhujian_2 = 22;

		public const short SectMainStoryZhujian_1 = 23;

		public const short SectMainStoryWuxian_1 = 24;

		public const short SectMainStoryWuxian_4 = 25;

		public const short SectMainStoryBaihua_4 = 26;

		public const short SectMainStoryBaihua_3 = 27;

		public const short SectMainStoryFulong_2 = 28;

		public const short SectMainStoryXuannv_3 = 29;

		public const short SectMainStoryXuannv_4 = 30;

		public const short SectMainStoryXuannv_2 = 31;

		public const short SectMainStoryXuehou_5 = 32;

		public const short SectMainStoryXuehou_1 = 33;

		public const short SectMainStoryJingang_1 = 34;

		public const short SectMainStoryXuehou_3 = 35;

		public const short SectMainStoryWuxian_3 = 36;

		public const short SectMainStoryWuxian_2 = 37;

		public const short SectMainStoryXuehou_4 = 38;

		public const short SectMainStoryXuannv_1 = 39;

		public const short SectMainStoryEmei_1 = 40;

		public const short SectMainStoryBaihua_1 = 41;

		public const short SectMainStoryYuanshan_1 = 42;

		public const short SectMainStoryBaihua_2 = 43;

		public const short SectMainStoryBaihua_6 = 44;

		public const short SectMainStoryBaihua_5 = 45;

		public const short SectMainStoryYuanshan_3 = 46;

		public const short SectMainStoryBaihua_7 = 47;

		public const short SectMainStoryBaihua_8 = 48;

		public const short TownMarket = 49;

		public const short TeaParty_1 = 50;

		public const short WineParty_1 = 51;

		public const short WineParty_2 = 52;

		public const short MarryAdventure = 53;

		public const short TeaParty_2 = 54;

		public const short TeaParty_3 = 55;

		public const short WineParty_3 = 56;

		public const short ElopeWithLove = 57;

		public const short EnemyNest_ViciousBeggarsNest = 58;

		public const short EnemyNest_ThievesCamp = 59;

		public const short EnemyNest_BanditsStronghold = 60;

		public const short EnemyNest_TraitorsGang = 61;

		public const short EnemyNest_VillainsValley = 62;

		public const short EnemyNest_Mixiangzhen = 63;

		public const short EnemyNest_MassGrave = 64;

		public const short EnemyNest_HereticHome = 65;

		public const short EnemyNest_EvilGround = 66;

		public const short EnemyNest_Xiuluochang = 67;

		public const short EnemyNest_FlurryofDemons = 68;

		public const short EnemyNest_DeadEnd = 69;

		public const short RighteousLow = 70;

		public const short RighteousMiddle = 71;

		public const short RighteousHigh = 72;

		public const short SummerCombatMatch2 = 73;

		public const short SummerCombatMatch3 = 74;

		public const short SectCombatMatch = 75;

		public const short SummerCombatMatch1 = 76;

		public const short SpringMarket = 77;

		public const short SummerCombatMatch8 = 78;

		public const short SummerCombatMatch11 = 79;

		public const short SummerCombatMatch4 = 80;

		public const short SummerCombatMatch6 = 81;

		public const short SummerCombatMatch10 = 82;

		public const short SummerCombatMatch9 = 83;

		public const short SummerCombatMatch5 = 84;

		public const short SummerCombatMatch7 = 85;

		public const short WinterLifeSkillMatch4 = 86;

		public const short WinterLifeSkillMatch6 = 87;

		public const short WinterLifeSkillMatch = 88;

		public const short WinterLifeSkillMatch2 = 89;

		public const short WinterLifeSkillMatch5 = 90;

		public const short WinterLifeSkillMatch3 = 91;

		public const short WinterLifeSkillMatch1 = 92;

		public const short CricketCompetition = 93;

		public const short FemaleMarriageChengDu = 109;

		public const short FemaleMarriageDaLi = 110;

		public const short FemaleMarriageFuZhou = 111;

		public const short FemaleMarriageGuangZhou = 112;

		public const short FemaleMarriageGuiZhou = 113;

		public const short FemaleMarriageHangZhou = 114;

		public const short FemaleMarriageJiangLing = 115;

		public const short marryJingCheng = 116;

		public const short FemaleMarriageLiaoYan = 117;

		public const short FemaleMarriageQinZhou = 118;

		public const short FemaleMarriageQingZhou = 119;

		public const short FemaleMarriageShouChun = 120;

		public const short FemaleMarriageTaiYuan = 121;

		public const short FemaleMarriageXiangYang = 122;

		public const short MarryYangzhou = 123;

		public const short MedicineOther = 136;

		public const short MedicineHitDefuse = 137;

		public const short MedicineHeal = 138;

		public const short MedicineAttackProtect = 139;

		public const short MedicineDetoxify = 140;

		public const short SwordGrave_DaXuanN = 147;

		public const short SwordGrave_FenShen = 148;

		public const short SwordGrave_FengHuang = 149;

		public const short SwordGrave_FuXieTie = 150;

		public const short SwordGrave_GuiShenX = 151;

		public const short SwordGrave_JieLongP = 152;

		public const short SwordGrave_MoNvYi = 153;

		public const short SwordGrave_QiuMoMu = 154;

		public const short SwordGrave_Rongchen = 155;

		public const short Mie_DaXuanN = 156;

		public const short Mie_FenShen = 157;

		public const short Mie_FengHuang = 158;

		public const short Mie_FuXieTie = 159;

		public const short Mie_GuiShenX = 160;

		public const short Mie_JieLongP = 161;

		public const short Mie_MoNvYi = 162;

		public const short Mie_QiuMoMu = 163;

		public const short Mie_Rongchen = 164;

		public const short Yuan_DaXuanN = 165;

		public const short Yuan_FenShen = 166;

		public const short Yuan_FengHuang = 167;

		public const short Yuan_FuXieTie = 168;

		public const short Yuan_GuiShenX = 169;

		public const short Yuan_JieLongP = 170;

		public const short Yuan_MoNvYi = 171;

		public const short Yuan_QiuMoMu = 172;

		public const short Yuan_Rongchen = 173;

		public const short SealEvil_DaXuanN = 174;

		public const short SealEvil_FenShen = 175;

		public const short SealEvil_FengHuang = 176;

		public const short SealEvil_FuXieTie = 177;

		public const short SealEvil_GuiShenX = 178;

		public const short SealEvil_JieLongP = 179;

		public const short SealEvil_MoNvYi = 180;

		public const short SealEvil_QiuMoMu = 181;

		public const short SealEvil_Rongchen = 182;

		public const short Queerbook6 = 183;

		public const short Queerbook2 = 184;

		public const short Queerbook3 = 185;

		public const short Queerbook7 = 186;

		public const short Queerbook1 = 187;

		public const short Queerbook12 = 188;

		public const short Queerbook14 = 189;

		public const short Queerbook9 = 190;

		public const short Queerbook13 = 191;

		public const short Queerbook8 = 192;

		public const short Queerbook11 = 193;

		public const short Queerbook4 = 194;

		public const short Queerbook5 = 195;

		public const short Queerbook10 = 196;
	}

	public static class DefValue
	{
		public static AdventureItem ReturnBambooHouse => Instance[(short)0];

		public static AdventureItem DownRiver => Instance[(short)1];

		public static AdventureItem RockBamboo => Instance[(short)2];

		public static AdventureItem MonkeyHero => Instance[(short)3];

		public static AdventureItem VilliageChange => Instance[(short)4];

		public static AdventureItem AbandonedPost => Instance[(short)5];

		public static AdventureItem UnderhillRiver => Instance[(short)6];

		public static AdventureItem ValleyExit => Instance[(short)7];

		public static AdventureItem TombImmortal => Instance[(short)8];

		public static AdventureItem WulinConference => Instance[(short)9];

		public static AdventureItem BlackBambooAppear => Instance[(short)10];

		public static AdventureItem LandOfTrance => Instance[(short)11];

		public static AdventureItem SectMainStoryKongsang_1 => Instance[(short)12];

		public static AdventureItem SectMainStoryFulong_3 => Instance[(short)13];

		public static AdventureItem SectMainStoryXuehou_2 => Instance[(short)14];

		public static AdventureItem SectMainStoryEmei_2 => Instance[(short)15];

		public static AdventureItem SectMainStoryFulong_1 => Instance[(short)16];

		public static AdventureItem SectMainStoryRanshan_2 => Instance[(short)17];

		public static AdventureItem SectMainStoryRemakeYuanshan_1 => Instance[(short)18];

		public static AdventureItem SectMainStoryYuanshan_2 => Instance[(short)19];

		public static AdventureItem SectMainStoryRanshan_1 => Instance[(short)20];

		public static AdventureItem SectMainStoryShixiang_1 => Instance[(short)21];

		public static AdventureItem SectMainStoryZhujian_2 => Instance[(short)22];

		public static AdventureItem SectMainStoryZhujian_1 => Instance[(short)23];

		public static AdventureItem SectMainStoryWuxian_1 => Instance[(short)24];

		public static AdventureItem SectMainStoryWuxian_4 => Instance[(short)25];

		public static AdventureItem SectMainStoryBaihua_4 => Instance[(short)26];

		public static AdventureItem SectMainStoryBaihua_3 => Instance[(short)27];

		public static AdventureItem SectMainStoryFulong_2 => Instance[(short)28];

		public static AdventureItem SectMainStoryXuannv_3 => Instance[(short)29];

		public static AdventureItem SectMainStoryXuannv_4 => Instance[(short)30];

		public static AdventureItem SectMainStoryXuannv_2 => Instance[(short)31];

		public static AdventureItem SectMainStoryXuehou_5 => Instance[(short)32];

		public static AdventureItem SectMainStoryXuehou_1 => Instance[(short)33];

		public static AdventureItem SectMainStoryJingang_1 => Instance[(short)34];

		public static AdventureItem SectMainStoryXuehou_3 => Instance[(short)35];

		public static AdventureItem SectMainStoryWuxian_3 => Instance[(short)36];

		public static AdventureItem SectMainStoryWuxian_2 => Instance[(short)37];

		public static AdventureItem SectMainStoryXuehou_4 => Instance[(short)38];

		public static AdventureItem SectMainStoryXuannv_1 => Instance[(short)39];

		public static AdventureItem SectMainStoryEmei_1 => Instance[(short)40];

		public static AdventureItem SectMainStoryBaihua_1 => Instance[(short)41];

		public static AdventureItem SectMainStoryYuanshan_1 => Instance[(short)42];

		public static AdventureItem SectMainStoryBaihua_2 => Instance[(short)43];

		public static AdventureItem SectMainStoryBaihua_6 => Instance[(short)44];

		public static AdventureItem SectMainStoryBaihua_5 => Instance[(short)45];

		public static AdventureItem SectMainStoryYuanshan_3 => Instance[(short)46];

		public static AdventureItem SectMainStoryBaihua_7 => Instance[(short)47];

		public static AdventureItem SectMainStoryBaihua_8 => Instance[(short)48];

		public static AdventureItem TownMarket => Instance[(short)49];

		public static AdventureItem TeaParty_1 => Instance[(short)50];

		public static AdventureItem WineParty_1 => Instance[(short)51];

		public static AdventureItem WineParty_2 => Instance[(short)52];

		public static AdventureItem MarryAdventure => Instance[(short)53];

		public static AdventureItem TeaParty_2 => Instance[(short)54];

		public static AdventureItem TeaParty_3 => Instance[(short)55];

		public static AdventureItem WineParty_3 => Instance[(short)56];

		public static AdventureItem ElopeWithLove => Instance[(short)57];

		public static AdventureItem EnemyNest_ViciousBeggarsNest => Instance[(short)58];

		public static AdventureItem EnemyNest_ThievesCamp => Instance[(short)59];

		public static AdventureItem EnemyNest_BanditsStronghold => Instance[(short)60];

		public static AdventureItem EnemyNest_TraitorsGang => Instance[(short)61];

		public static AdventureItem EnemyNest_VillainsValley => Instance[(short)62];

		public static AdventureItem EnemyNest_Mixiangzhen => Instance[(short)63];

		public static AdventureItem EnemyNest_MassGrave => Instance[(short)64];

		public static AdventureItem EnemyNest_HereticHome => Instance[(short)65];

		public static AdventureItem EnemyNest_EvilGround => Instance[(short)66];

		public static AdventureItem EnemyNest_Xiuluochang => Instance[(short)67];

		public static AdventureItem EnemyNest_FlurryofDemons => Instance[(short)68];

		public static AdventureItem EnemyNest_DeadEnd => Instance[(short)69];

		public static AdventureItem RighteousLow => Instance[(short)70];

		public static AdventureItem RighteousMiddle => Instance[(short)71];

		public static AdventureItem RighteousHigh => Instance[(short)72];

		public static AdventureItem SummerCombatMatch2 => Instance[(short)73];

		public static AdventureItem SummerCombatMatch3 => Instance[(short)74];

		public static AdventureItem SectCombatMatch => Instance[(short)75];

		public static AdventureItem SummerCombatMatch1 => Instance[(short)76];

		public static AdventureItem SpringMarket => Instance[(short)77];

		public static AdventureItem SummerCombatMatch8 => Instance[(short)78];

		public static AdventureItem SummerCombatMatch11 => Instance[(short)79];

		public static AdventureItem SummerCombatMatch4 => Instance[(short)80];

		public static AdventureItem SummerCombatMatch6 => Instance[(short)81];

		public static AdventureItem SummerCombatMatch10 => Instance[(short)82];

		public static AdventureItem SummerCombatMatch9 => Instance[(short)83];

		public static AdventureItem SummerCombatMatch5 => Instance[(short)84];

		public static AdventureItem SummerCombatMatch7 => Instance[(short)85];

		public static AdventureItem WinterLifeSkillMatch4 => Instance[(short)86];

		public static AdventureItem WinterLifeSkillMatch6 => Instance[(short)87];

		public static AdventureItem WinterLifeSkillMatch => Instance[(short)88];

		public static AdventureItem WinterLifeSkillMatch2 => Instance[(short)89];

		public static AdventureItem WinterLifeSkillMatch5 => Instance[(short)90];

		public static AdventureItem WinterLifeSkillMatch3 => Instance[(short)91];

		public static AdventureItem WinterLifeSkillMatch1 => Instance[(short)92];

		public static AdventureItem CricketCompetition => Instance[(short)93];

		public static AdventureItem FemaleMarriageChengDu => Instance[(short)109];

		public static AdventureItem FemaleMarriageDaLi => Instance[(short)110];

		public static AdventureItem FemaleMarriageFuZhou => Instance[(short)111];

		public static AdventureItem FemaleMarriageGuangZhou => Instance[(short)112];

		public static AdventureItem FemaleMarriageGuiZhou => Instance[(short)113];

		public static AdventureItem FemaleMarriageHangZhou => Instance[(short)114];

		public static AdventureItem FemaleMarriageJiangLing => Instance[(short)115];

		public static AdventureItem marryJingCheng => Instance[(short)116];

		public static AdventureItem FemaleMarriageLiaoYan => Instance[(short)117];

		public static AdventureItem FemaleMarriageQinZhou => Instance[(short)118];

		public static AdventureItem FemaleMarriageQingZhou => Instance[(short)119];

		public static AdventureItem FemaleMarriageShouChun => Instance[(short)120];

		public static AdventureItem FemaleMarriageTaiYuan => Instance[(short)121];

		public static AdventureItem FemaleMarriageXiangYang => Instance[(short)122];

		public static AdventureItem MarryYangzhou => Instance[(short)123];

		public static AdventureItem MedicineOther => Instance[(short)136];

		public static AdventureItem MedicineHitDefuse => Instance[(short)137];

		public static AdventureItem MedicineHeal => Instance[(short)138];

		public static AdventureItem MedicineAttackProtect => Instance[(short)139];

		public static AdventureItem MedicineDetoxify => Instance[(short)140];

		public static AdventureItem SwordGrave_DaXuanN => Instance[(short)147];

		public static AdventureItem SwordGrave_FenShen => Instance[(short)148];

		public static AdventureItem SwordGrave_FengHuang => Instance[(short)149];

		public static AdventureItem SwordGrave_FuXieTie => Instance[(short)150];

		public static AdventureItem SwordGrave_GuiShenX => Instance[(short)151];

		public static AdventureItem SwordGrave_JieLongP => Instance[(short)152];

		public static AdventureItem SwordGrave_MoNvYi => Instance[(short)153];

		public static AdventureItem SwordGrave_QiuMoMu => Instance[(short)154];

		public static AdventureItem SwordGrave_Rongchen => Instance[(short)155];

		public static AdventureItem Mie_DaXuanN => Instance[(short)156];

		public static AdventureItem Mie_FenShen => Instance[(short)157];

		public static AdventureItem Mie_FengHuang => Instance[(short)158];

		public static AdventureItem Mie_FuXieTie => Instance[(short)159];

		public static AdventureItem Mie_GuiShenX => Instance[(short)160];

		public static AdventureItem Mie_JieLongP => Instance[(short)161];

		public static AdventureItem Mie_MoNvYi => Instance[(short)162];

		public static AdventureItem Mie_QiuMoMu => Instance[(short)163];

		public static AdventureItem Mie_Rongchen => Instance[(short)164];

		public static AdventureItem Yuan_DaXuanN => Instance[(short)165];

		public static AdventureItem Yuan_FenShen => Instance[(short)166];

		public static AdventureItem Yuan_FengHuang => Instance[(short)167];

		public static AdventureItem Yuan_FuXieTie => Instance[(short)168];

		public static AdventureItem Yuan_GuiShenX => Instance[(short)169];

		public static AdventureItem Yuan_JieLongP => Instance[(short)170];

		public static AdventureItem Yuan_MoNvYi => Instance[(short)171];

		public static AdventureItem Yuan_QiuMoMu => Instance[(short)172];

		public static AdventureItem Yuan_Rongchen => Instance[(short)173];

		public static AdventureItem SealEvil_DaXuanN => Instance[(short)174];

		public static AdventureItem SealEvil_FenShen => Instance[(short)175];

		public static AdventureItem SealEvil_FengHuang => Instance[(short)176];

		public static AdventureItem SealEvil_FuXieTie => Instance[(short)177];

		public static AdventureItem SealEvil_GuiShenX => Instance[(short)178];

		public static AdventureItem SealEvil_JieLongP => Instance[(short)179];

		public static AdventureItem SealEvil_MoNvYi => Instance[(short)180];

		public static AdventureItem SealEvil_QiuMoMu => Instance[(short)181];

		public static AdventureItem SealEvil_Rongchen => Instance[(short)182];

		public static AdventureItem Queerbook6 => Instance[(short)183];

		public static AdventureItem Queerbook2 => Instance[(short)184];

		public static AdventureItem Queerbook3 => Instance[(short)185];

		public static AdventureItem Queerbook7 => Instance[(short)186];

		public static AdventureItem Queerbook1 => Instance[(short)187];

		public static AdventureItem Queerbook12 => Instance[(short)188];

		public static AdventureItem Queerbook14 => Instance[(short)189];

		public static AdventureItem Queerbook9 => Instance[(short)190];

		public static AdventureItem Queerbook13 => Instance[(short)191];

		public static AdventureItem Queerbook8 => Instance[(short)192];

		public static AdventureItem Queerbook11 => Instance[(short)193];

		public static AdventureItem Queerbook4 => Instance[(short)194];

		public static AdventureItem Queerbook5 => Instance[(short)195];

		public static AdventureItem Queerbook10 => Instance[(short)196];
	}

	public static Adventure Instance = new Adventure();

	private readonly HashSet<string> RequiredFields = new HashSet<string>
	{
		"Name", "Desc", "Type", "TemplateId", "CombatDifficulty", "LifeSkillDifficulty", "Interruptible", "TimeCost", "KeepTime", "ResCost",
		"ItemCost", "RestrictedByWorldPopulation", "Malice", "AdventureParams", "EnterEvent", "StartNodes", "TransferNodes", "EndNodes", "BaseBranches", "AdvancedBranches",
		"DifficultyAddXiangshuLevel"
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
		List<AdventureItem> dataArray = _dataArray;
		string config = LocalStringManager.GetConfig("Adventure_language", "Name_0");
		string config2 = LocalStringManager.GetConfig("Adventure_language", "Desc_0");
		int[] resCost = new int[9];
		List<int[]> list = new List<int[]>();
		List<int[]> itemCost = list;
		short[] malice = new short[3];
		List<(string, string, string, string)> list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams = list2;
		List<AdventureStartNode> startNodes = new List<AdventureStartNode>
		{
			new AdventureStartNode("eb58b685-2397-4d98-b455-c8355c33ae9a", "A", "LK_Adventure_NodeTitle_0", 2)
		};
		List<AdventureTransferNode> list3 = new List<AdventureTransferNode>();
		List<AdventureTransferNode> transferNodes = list3;
		List<AdventureEndNode> endNodes = new List<AdventureEndNode>
		{
			new AdventureEndNode("0d42c020-5e19-4246-9e97-abc8b5741cfd", "B", "LK_Adventure_NodeTitle_1", 7)
		};
		List<AdventureBaseBranch> baseBranches = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 5, "", new int[2] { 15, 1 }, new int[7] { 2, 2, 11, 4, 2, 7, 1 }, new int[5] { 25, 5, 5, 10, 10 }, new string[5] { "0", "0", "0", "0", "0" }, new int[77]
			{
				15, 0, 10, 5, 1, 10, 5, 2, 10, 5,
				3, 10, 5, 4, 10, 5, 0, 20, 3, 1,
				20, 3, 2, 20, 3, 3, 20, 3, 4, 20,
				3, 0, 30, 2, 1, 30, 2, 2, 30, 2,
				3, 30, 2, 4, 30, 2, 3, 8, 25, 5,
				8, 50, 3, 8, 75, 2, 0, 3, 7, 5,
				5, 7, 10, 3, 7, 15, 2, 3, 5, 10,
				5, 5, 20, 3, 5, 30, 2
			}, new int[33]
			{
				0, 0, 5, 5, -501, 1, 2, 5, -502, 1,
				2, 5, -503, 1, 2, 5, -504, 1, 2, 5,
				-505, 1, 2, 0, 2, 5, -506, 1, 5, 5,
				-507, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" })
		};
		List<AdventureAdvancedBranch> advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray.Add(new AdventureItem(0, config, config2, 1, 1, 1, 0, 1, -1, resCost, itemCost, restrictedByWorldPopulation: false, malice, adventureParams, "41fdff85-6a15-42c4-a31d-191c1537f207", startNodes, transferNodes, endNodes, baseBranches, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray2 = _dataArray;
		string config3 = LocalStringManager.GetConfig("Adventure_language", "Name_1");
		string config4 = LocalStringManager.GetConfig("Adventure_language", "Desc_1");
		int[] resCost2 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost2 = list;
		short[] malice2 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams2 = list2;
		List<AdventureStartNode> startNodes2 = new List<AdventureStartNode>
		{
			new AdventureStartNode("fe397e1e-a820-463c-a4ea-6ff3eb7c2f06", "A", "", 4)
		};
		list3 = new List<AdventureTransferNode>();
		List<AdventureTransferNode> transferNodes2 = list3;
		List<AdventureEndNode> endNodes2 = new List<AdventureEndNode>
		{
			new AdventureEndNode("35be0310-7654-4c15-be37-586f1e137aa2", "B", "LK_Adventure_NodeTitle_2", 4)
		};
		List<AdventureBaseBranch> baseBranches2 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 5, "", new int[2], new int[4] { 1, 2, 0, 0 }, new int[5] { 100, 100, 100, 100, 100 }, new string[5] { "0", "0", "0", "0", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray2.Add(new AdventureItem(1, config3, config4, 1, 1, 1, 0, 0, -1, resCost2, itemCost2, restrictedByWorldPopulation: false, malice2, adventureParams2, null, startNodes2, transferNodes2, endNodes2, baseBranches2, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray3 = _dataArray;
		string config5 = LocalStringManager.GetConfig("Adventure_language", "Name_2");
		string config6 = LocalStringManager.GetConfig("Adventure_language", "Desc_2");
		int[] resCost3 = new int[9];
		List<int[]> itemCost3 = new List<int[]>
		{
			new int[2] { 12, 210 },
			new int[20]
			{
				12, 200, 12, 201, 12, 202, 12, 203, 12, 204,
				12, 205, 12, 206, 12, 207, 12, 208, 12, 209
			}
		};
		short[] malice3 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams3 = list2;
		List<AdventureStartNode> startNodes3 = new List<AdventureStartNode>
		{
			new AdventureStartNode("56d400cb-e4f9-407e-94b0-e720035b3272", "A", "LK_Adventure_NodeTitle_3", 6),
			new AdventureStartNode("3faffe87-075e-4a24-ad93-8d0252e247c9", "B", "LK_Adventure_NodeTitle_3", 1),
			new AdventureStartNode("3e9f5eab-29bf-4fab-a685-c0ca85ec37f5", "C", "LK_Adventure_NodeTitle_3", 5),
			new AdventureStartNode("e2c1bc38-7c44-42f5-bf57-b158ed8cb2bd", "D", "LK_Adventure_NodeTitle_3", 19),
			new AdventureStartNode("c20df188-e738-464d-b26a-91aec234fd37", "E", "LK_Adventure_NodeTitle_3", 10),
			new AdventureStartNode("7ad3ba6e-a92e-45d2-9aa2-761b9b7e7e89", "F", "LK_Adventure_NodeTitle_3", 22),
			new AdventureStartNode("04f773d2-8efb-4375-860e-ba570a9100ce", "G", "LK_Adventure_NodeTitle_3", 3),
			new AdventureStartNode("71f33c48-1a18-489b-be23-fd30ea00a42e", "H", "LK_Adventure_NodeTitle_3", 11),
			new AdventureStartNode("184edd04-f79f-4e9f-8da3-f64d4d7610b3", "I", "LK_Adventure_NodeTitle_3", 18),
			new AdventureStartNode("8356b4a4-a250-463a-8b0c-06bbce0f2119", "J", "LK_Adventure_NodeTitle_3", 17)
		};
		list3 = new List<AdventureTransferNode>();
		List<AdventureTransferNode> transferNodes3 = list3;
		List<AdventureEndNode> endNodes3 = new List<AdventureEndNode>
		{
			new AdventureEndNode("35107020-3550-4a94-9cd2-eae1561da442", "AE", "LK_Adventure_NodeTitle_4", 16),
			new AdventureEndNode("cdb1e03c-a4b1-4af6-b547-2657604019e7", "BE", "LK_Adventure_NodeTitle_4", 16),
			new AdventureEndNode("0435d089-4a9b-443a-b512-98829fb9ae07", "CE", "LK_Adventure_NodeTitle_4", 16),
			new AdventureEndNode("8f2892bb-5b47-42eb-9c69-24af5d8af861", "DE", "LK_Adventure_NodeTitle_4", 16),
			new AdventureEndNode("cde0fefd-bd3a-4d1c-a535-689054ac39f1", "EE", "LK_Adventure_NodeTitle_4", 16),
			new AdventureEndNode("bdd574a1-e1c0-46c9-b98c-1a0b56cea2c1", "FE", "LK_Adventure_NodeTitle_4", 16),
			new AdventureEndNode("531feb09-bc04-4227-9f08-4d7279f67734", "GE", "LK_Adventure_NodeTitle_4", 16),
			new AdventureEndNode("658de5e9-18fc-43c7-85dd-b070a1d6205e", "HE", "LK_Adventure_NodeTitle_4", 16),
			new AdventureEndNode("833e7dd8-f366-45d6-9336-cf2967268ace", "IE", "LK_Adventure_NodeTitle_4", 16),
			new AdventureEndNode("64fb3d0f-04c0-4b59-b0e2-d3db91d96fa0", "JE", "LK_Adventure_NodeTitle_4", 16)
		};
		List<AdventureBaseBranch> baseBranches3 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 10, "1", 1, 10, "", new int[4] { 8, 1, 9, 1 }, new int[7] { 2, 2, 17, 1, 2, 18, 1 }, new int[5] { 25, 5, 5, 10, 10 }, new string[7] { "0", "0", "0", "1", "4249e10e-f8f7-4701-a183-70fe89af5364", "40", "0" }, new int[77]
			{
				15, 0, 10, 5, 1, 10, 5, 2, 10, 5,
				3, 10, 5, 4, 10, 5, 0, 20, 3, 1,
				20, 3, 2, 20, 3, 3, 20, 3, 4, 20,
				3, 0, 30, 2, 1, 30, 2, 2, 30, 2,
				3, 30, 2, 4, 30, 2, 3, 8, 25, 5,
				8, 50, 3, 8, 75, 2, 0, 3, 7, 5,
				5, 7, 10, 3, 7, 15, 2, 3, 5, 10,
				5, 5, 20, 3, 5, 30, 2
			}, new int[33]
			{
				0, 0, 5, 5, -501, 1, 2, 5, -502, 1,
				2, 5, -503, 1, 2, 5, -504, 1, 2, 5,
				-505, 1, 2, 0, 2, 5, -506, 1, 5, 5,
				-507, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 11, "1", 1, 10, "", new int[2] { 6, 1 }, new int[7] { 2, 2, 17, 1, 2, 18, 1 }, new int[5] { 25, 5, 5, 10, 10 }, new string[7] { "0", "0", "0", "1", "4249e10e-f8f7-4701-a183-70fe89af5364", "40", "0" }, new int[77]
			{
				15, 0, 10, 5, 1, 10, 5, 2, 10, 5,
				3, 10, 5, 4, 10, 5, 0, 20, 3, 1,
				20, 3, 2, 20, 3, 3, 20, 3, 4, 20,
				3, 0, 30, 2, 1, 30, 2, 2, 30, 2,
				3, 30, 2, 4, 30, 2, 3, 8, 25, 5,
				8, 50, 3, 8, 75, 2, 0, 3, 7, 5,
				5, 7, 10, 3, 7, 15, 2, 3, 5, 10,
				5, 5, 20, 3, 5, 30, 2
			}, new int[33]
			{
				0, 0, 5, 5, -501, 1, 2, 5, -502, 1,
				2, 5, -503, 1, 2, 5, -504, 1, 2, 5,
				-505, 1, 2, 0, 2, 5, -506, 1, 5, 5,
				-507, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 12, "1", 1, 10, "", new int[2] { 15, 1 }, new int[7] { 2, 2, 17, 1, 2, 18, 1 }, new int[5] { 25, 5, 5, 10, 10 }, new string[7] { "0", "0", "0", "1", "4249e10e-f8f7-4701-a183-70fe89af5364", "40", "0" }, new int[77]
			{
				15, 0, 10, 5, 1, 10, 5, 2, 10, 5,
				3, 10, 5, 4, 10, 5, 0, 20, 3, 1,
				20, 3, 2, 20, 3, 3, 20, 3, 4, 20,
				3, 0, 30, 2, 1, 30, 2, 2, 30, 2,
				3, 30, 2, 4, 30, 2, 3, 8, 25, 5,
				8, 50, 3, 8, 75, 2, 0, 3, 7, 5,
				5, 7, 10, 3, 7, 15, 2, 3, 5, 10,
				5, 5, 20, 3, 5, 30, 2
			}, new int[33]
			{
				0, 0, 5, 5, -501, 1, 2, 5, -502, 1,
				2, 5, -503, 1, 2, 5, -504, 1, 2, 5,
				-505, 1, 2, 0, 2, 5, -506, 1, 5, 5,
				-507, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 13, "1", 1, 10, "", new int[2] { 5, 1 }, new int[7] { 2, 2, 17, 1, 2, 18, 1 }, new int[5] { 25, 5, 5, 10, 10 }, new string[7] { "0", "0", "0", "1", "4249e10e-f8f7-4701-a183-70fe89af5364", "40", "0" }, new int[77]
			{
				15, 0, 10, 5, 1, 10, 5, 2, 10, 5,
				3, 10, 5, 4, 10, 5, 0, 20, 3, 1,
				20, 3, 2, 20, 3, 3, 20, 3, 4, 20,
				3, 0, 30, 2, 1, 30, 2, 2, 30, 2,
				3, 30, 2, 4, 30, 2, 3, 8, 25, 5,
				8, 50, 3, 8, 75, 2, 0, 3, 7, 5,
				5, 7, 10, 3, 7, 15, 2, 3, 5, 10,
				5, 5, 20, 3, 5, 30, 2
			}, new int[33]
			{
				0, 0, 5, 5, -501, 1, 2, 5, -502, 1,
				2, 5, -503, 1, 2, 5, -504, 1, 2, 5,
				-505, 1, 2, 0, 2, 5, -506, 1, 5, 5,
				-507, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(4, 14, "1", 1, 10, "", new int[2] { 10, 1 }, new int[7] { 2, 2, 17, 1, 2, 18, 1 }, new int[5] { 25, 5, 5, 10, 10 }, new string[7] { "0", "0", "0", "1", "4249e10e-f8f7-4701-a183-70fe89af5364", "40", "0" }, new int[77]
			{
				15, 0, 10, 5, 1, 10, 5, 2, 10, 5,
				3, 10, 5, 4, 10, 5, 0, 20, 3, 1,
				20, 3, 2, 20, 3, 3, 20, 3, 4, 20,
				3, 0, 30, 2, 1, 30, 2, 2, 30, 2,
				3, 30, 2, 4, 30, 2, 3, 8, 25, 5,
				8, 50, 3, 8, 75, 2, 0, 3, 7, 5,
				5, 7, 10, 3, 7, 15, 2, 3, 5, 10,
				5, 5, 20, 3, 5, 30, 2
			}, new int[33]
			{
				0, 0, 5, 5, -501, 1, 2, 5, -502, 1,
				2, 5, -503, 1, 2, 5, -504, 1, 2, 5,
				-505, 1, 2, 0, 2, 5, -506, 1, 5, 5,
				-507, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(5, 15, "1", 1, 10, "", new int[2] { 14, 1 }, new int[7] { 2, 2, 17, 1, 2, 18, 1 }, new int[5] { 25, 5, 5, 10, 10 }, new string[7] { "0", "0", "0", "1", "4249e10e-f8f7-4701-a183-70fe89af5364", "40", "0" }, new int[77]
			{
				15, 0, 10, 5, 1, 10, 5, 2, 10, 5,
				3, 10, 5, 4, 10, 5, 0, 20, 3, 1,
				20, 3, 2, 20, 3, 3, 20, 3, 4, 20,
				3, 0, 30, 2, 1, 30, 2, 2, 30, 2,
				3, 30, 2, 4, 30, 2, 3, 8, 25, 5,
				8, 50, 3, 8, 75, 2, 0, 3, 7, 5,
				5, 7, 10, 3, 7, 15, 2, 3, 5, 10,
				5, 5, 20, 3, 5, 30, 2
			}, new int[33]
			{
				0, 0, 5, 5, -501, 1, 2, 5, -502, 1,
				2, 5, -503, 1, 2, 5, -504, 1, 2, 5,
				-505, 1, 2, 0, 2, 5, -506, 1, 5, 5,
				-507, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(6, 16, "1", 1, 10, "", new int[2] { 11, 1 }, new int[7] { 2, 2, 17, 1, 2, 18, 1 }, new int[5] { 25, 5, 5, 10, 10 }, new string[7] { "0", "0", "0", "1", "4249e10e-f8f7-4701-a183-70fe89af5364", "40", "0" }, new int[77]
			{
				15, 0, 10, 5, 1, 10, 5, 2, 10, 5,
				3, 10, 5, 4, 10, 5, 0, 20, 3, 1,
				20, 3, 2, 20, 3, 3, 20, 3, 4, 20,
				3, 0, 30, 2, 1, 30, 2, 2, 30, 2,
				3, 30, 2, 4, 30, 2, 3, 8, 25, 5,
				8, 50, 3, 8, 75, 2, 0, 3, 7, 5,
				5, 7, 10, 3, 7, 15, 2, 3, 5, 10,
				5, 5, 20, 3, 5, 30, 2
			}, new int[33]
			{
				0, 0, 5, 5, -501, 1, 2, 5, -502, 1,
				2, 5, -503, 1, 2, 5, -504, 1, 2, 5,
				-505, 1, 2, 0, 2, 5, -506, 1, 5, 5,
				-507, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(7, 17, "1", 1, 10, "", new int[2] { 7, 1 }, new int[7] { 2, 2, 17, 1, 2, 18, 1 }, new int[5] { 25, 5, 5, 10, 10 }, new string[7] { "0", "0", "0", "1", "4249e10e-f8f7-4701-a183-70fe89af5364", "40", "0" }, new int[77]
			{
				15, 0, 10, 5, 1, 10, 5, 2, 10, 5,
				3, 10, 5, 4, 10, 5, 0, 20, 3, 1,
				20, 3, 2, 20, 3, 3, 20, 3, 4, 20,
				3, 0, 30, 2, 1, 30, 2, 2, 30, 2,
				3, 30, 2, 4, 30, 2, 3, 8, 25, 5,
				8, 50, 3, 8, 75, 2, 0, 3, 7, 5,
				5, 7, 10, 3, 7, 15, 2, 3, 5, 10,
				5, 5, 20, 3, 5, 30, 2
			}, new int[33]
			{
				0, 0, 5, 5, -501, 1, 2, 5, -502, 1,
				2, 5, -503, 1, 2, 5, -504, 1, 2, 5,
				-505, 1, 2, 0, 2, 5, -506, 1, 5, 5,
				-507, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(8, 18, "1", 1, 10, "", new int[2] { 4, 1 }, new int[7] { 2, 2, 17, 1, 2, 18, 1 }, new int[5] { 25, 5, 5, 10, 10 }, new string[7] { "0", "0", "0", "1", "4249e10e-f8f7-4701-a183-70fe89af5364", "40", "0" }, new int[77]
			{
				15, 0, 10, 5, 1, 10, 5, 2, 10, 5,
				3, 10, 5, 4, 10, 5, 0, 20, 3, 1,
				20, 3, 2, 20, 3, 3, 20, 3, 4, 20,
				3, 0, 30, 2, 1, 30, 2, 2, 30, 2,
				3, 30, 2, 4, 30, 2, 3, 8, 25, 5,
				8, 50, 3, 8, 75, 2, 0, 3, 7, 5,
				5, 7, 10, 3, 7, 15, 2, 3, 5, 10,
				5, 5, 20, 3, 5, 30, 2
			}, new int[33]
			{
				0, 0, 5, 5, -501, 1, 2, 5, -502, 1,
				2, 5, -503, 1, 2, 5, -504, 1, 2, 5,
				-505, 1, 2, 0, 2, 5, -506, 1, 5, 5,
				-507, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(9, 19, "1", 1, 10, "", new int[4] { 13, 1, 12, 1 }, new int[7] { 2, 2, 17, 1, 2, 18, 1 }, new int[5] { 25, 5, 5, 10, 10 }, new string[7] { "0", "0", "0", "1", "4249e10e-f8f7-4701-a183-70fe89af5364", "40", "0" }, new int[77]
			{
				15, 0, 10, 5, 1, 10, 5, 2, 10, 5,
				3, 10, 5, 4, 10, 5, 0, 20, 3, 1,
				20, 3, 2, 20, 3, 3, 20, 3, 4, 20,
				3, 0, 30, 2, 1, 30, 2, 2, 30, 2,
				3, 30, 2, 4, 30, 2, 3, 8, 25, 5,
				8, 50, 3, 8, 75, 2, 0, 3, 7, 5,
				5, 7, 10, 3, 7, 15, 2, 3, 5, 10,
				5, 5, 20, 3, 5, 30, 2
			}, new int[33]
			{
				0, 0, 5, 5, -501, 1, 2, 5, -502, 1,
				2, 5, -503, 1, 2, 5, -504, 1, 2, 5,
				-505, 1, 2, 0, 2, 5, -506, 1, 5, 5,
				-507, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray3.Add(new AdventureItem(2, config5, config6, 1, 1, 1, 2, 10, 6, resCost3, itemCost3, restrictedByWorldPopulation: false, malice3, adventureParams3, "51ee8f4a-1d18-4e55-9e4c-c32936ea1e16", startNodes3, transferNodes3, endNodes3, baseBranches3, advancedBranches, difficultyAddXiangshuLevel: true));
		List<AdventureItem> dataArray4 = _dataArray;
		string config7 = LocalStringManager.GetConfig("Adventure_language", "Name_3");
		string config8 = LocalStringManager.GetConfig("Adventure_language", "Desc_3");
		int[] resCost4 = new int[9] { 50, 0, 0, 0, 0, 0, 0, 0, 0 };
		List<int[]> itemCost4 = new List<int[]> { new int[2] { 7, 0 } };
		short[] malice4 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams4 = list2;
		List<AdventureStartNode> startNodes4 = new List<AdventureStartNode>
		{
			new AdventureStartNode("42704c20-2261-4d3c-9ecf-ad606540fba2", "A", "LK_Adventure_NodeTitle_5", 12)
		};
		list3 = new List<AdventureTransferNode>();
		List<AdventureTransferNode> transferNodes4 = list3;
		List<AdventureEndNode> endNodes4 = new List<AdventureEndNode>
		{
			new AdventureEndNode("4d682f5c-0fbd-4a0f-9b7f-9cd951b2e0ad", "B", "LK_Adventure_NodeTitle_6", 3)
		};
		List<AdventureBaseBranch> baseBranches4 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 10, "", new int[2] { 15, 1 }, new int[16]
			{
				5, 2, 1, 5, 2, 2, 4, 2, 3, 3,
				2, 11, 2, 2, 12, 1
			}, new int[5] { 25, 5, 5, 10, 10 }, new string[7] { "0", "0", "0", "1", "306f8454-526e-48a8-b17a-3a23fc2d6b38", "60", "0" }, new int[77]
			{
				15, 0, 10, 5, 1, 10, 5, 2, 10, 5,
				3, 10, 5, 4, 10, 5, 0, 20, 3, 1,
				20, 3, 2, 20, 3, 3, 20, 3, 4, 20,
				3, 0, 30, 2, 1, 30, 2, 2, 30, 2,
				3, 30, 2, 4, 30, 2, 3, 8, 25, 5,
				8, 50, 3, 8, 75, 2, 0, 3, 7, 5,
				5, 7, 10, 3, 7, 15, 2, 3, 5, 10,
				5, 5, 20, 3, 5, 30, 2
			}, new int[33]
			{
				0, 0, 5, 5, -501, 1, 2, 5, -502, 1,
				2, 5, -503, 1, 2, 5, -504, 1, 2, 5,
				-505, 1, 2, 0, 2, 5, -506, 1, 5, 5,
				-507, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray4.Add(new AdventureItem(3, config7, config8, 1, 1, 1, 0, 5, 6, resCost4, itemCost4, restrictedByWorldPopulation: false, malice4, adventureParams4, "f16eaecc-52b7-4dae-b28b-f9004d872fdb", startNodes4, transferNodes4, endNodes4, baseBranches4, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray5 = _dataArray;
		string config9 = LocalStringManager.GetConfig("Adventure_language", "Name_4");
		string config10 = LocalStringManager.GetConfig("Adventure_language", "Desc_4");
		int[] resCost5 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost5 = list;
		short[] malice5 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams5 = list2;
		List<AdventureStartNode> startNodes5 = new List<AdventureStartNode>
		{
			new AdventureStartNode("b58fa2bd-f1e4-4718-93fc-69b849be01e6", "A", "LK_Adventure_NodeTitle_7", 8)
		};
		List<AdventureTransferNode> transferNodes5 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("e6b83eae-d591-40ef-8b23-42254464a071", "B", "LK_Adventure_NodeTitle_8", 8),
			new AdventureTransferNode("39e08df7-ed7b-4088-a002-8f66c2c317fe", "C", "LK_Adventure_NodeTitle_8", 8)
		};
		List<AdventureEndNode> endNodes5 = new List<AdventureEndNode>
		{
			new AdventureEndNode("7d428f94-32f9-48bc-a92f-1dd94d9cbaf2", "D", "LK_Adventure_NodeTitle_9", 4)
		};
		List<AdventureBaseBranch> baseBranches5 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 3, "", new int[32]
			{
				0, 1, 1, 1, 2, 1, 3, 1, 4, 1,
				5, 1, 6, 1, 7, 1, 8, 1, 9, 1,
				10, 1, 11, 1, 12, 1, 13, 1, 14, 1,
				15, 1
			}, new int[10] { 3, 2, 7, 1, 2, 8, 3, 2, 18, 2 }, new int[5] { 25, 5, 5, 10, 10 }, new string[7] { "0", "0", "0", "1", "6b49169d-8c7c-447f-81be-49250f883f32", "40", "0" }, new int[77]
			{
				15, 0, 20, 5, 1, 20, 5, 2, 20, 5,
				3, 20, 5, 4, 20, 5, 0, 40, 3, 1,
				40, 3, 2, 40, 3, 3, 40, 3, 4, 40,
				3, 0, 60, 2, 1, 60, 2, 2, 60, 2,
				3, 60, 2, 4, 60, 2, 3, 8, 50, 5,
				8, 100, 3, 8, 150, 2, 0, 3, 7, 10,
				5, 7, 20, 3, 7, 30, 2, 3, 5, 20,
				5, 5, 40, 3, 5, 60, 2
			}, new int[33]
			{
				0, 0, 5, 5, -501, 1, 2, 5, -502, 1,
				2, 5, -503, 1, 2, 5, -504, 1, 2, 5,
				-505, 1, 2, 0, 2, 5, -506, 1, 5, 5,
				-507, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 1, 5, "", new int[32]
			{
				0, 1, 1, 1, 2, 1, 3, 1, 4, 1,
				5, 1, 6, 1, 7, 1, 8, 1, 9, 1,
				10, 1, 11, 1, 12, 1, 13, 1, 14, 1,
				15, 1
			}, new int[10] { 3, 2, 7, 1, 2, 8, 3, 2, 18, 2 }, new int[5] { 25, 5, 5, 10, 10 }, new string[7] { "0", "0", "0", "1", "6b49169d-8c7c-447f-81be-49250f883f32", "40", "0" }, new int[77]
			{
				15, 0, 20, 5, 1, 20, 5, 2, 20, 5,
				3, 20, 5, 4, 20, 5, 0, 40, 3, 1,
				40, 3, 2, 40, 3, 3, 40, 3, 4, 40,
				3, 0, 60, 2, 1, 60, 2, 2, 60, 2,
				3, 60, 2, 4, 60, 2, 3, 8, 50, 5,
				8, 100, 3, 8, 150, 2, 0, 3, 7, 10,
				5, 7, 20, 3, 7, 30, 2, 3, 5, 20,
				5, 5, 40, 3, 5, 60, 2
			}, new int[33]
			{
				0, 0, 5, 5, -501, 1, 2, 5, -502, 1,
				2, 5, -503, 1, 2, 5, -504, 1, 2, 5,
				-505, 1, 2, 0, 2, 5, -506, 1, 5, 5,
				-507, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 3, "3", 1, 5, "", new int[32]
			{
				0, 1, 1, 1, 2, 1, 3, 1, 4, 1,
				5, 1, 6, 1, 7, 1, 8, 1, 9, 1,
				10, 1, 11, 1, 12, 1, 13, 1, 14, 1,
				15, 1
			}, new int[10] { 3, 2, 7, 1, 2, 8, 3, 2, 18, 2 }, new int[5] { 25, 5, 5, 10, 10 }, new string[7] { "0", "0", "0", "1", "6b49169d-8c7c-447f-81be-49250f883f32", "40", "0" }, new int[77]
			{
				15, 0, 20, 5, 1, 20, 5, 2, 20, 5,
				3, 20, 5, 4, 20, 5, 0, 40, 3, 1,
				40, 3, 2, 40, 3, 3, 40, 3, 4, 40,
				3, 0, 60, 2, 1, 60, 2, 2, 60, 2,
				3, 60, 2, 4, 60, 2, 3, 8, 50, 5,
				8, 100, 3, 8, 150, 2, 0, 3, 7, 10,
				5, 7, 20, 3, 7, 30, 2, 3, 5, 20,
				5, 5, 40, 3, 5, 60, 2
			}, new int[33]
			{
				0, 0, 5, 5, -501, 1, 2, 5, -502, 1,
				2, 5, -503, 1, 2, 5, -504, 1, 2, 5,
				-505, 1, 2, 0, 2, 5, -506, 1, 5, 5,
				-507, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray5.Add(new AdventureItem(4, config9, config10, 1, 2, 2, 0, 0, 3, resCost5, itemCost5, restrictedByWorldPopulation: false, malice5, adventureParams5, "f8845027-267f-4631-8452-4a7ea71815e9", startNodes5, transferNodes5, endNodes5, baseBranches5, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray6 = _dataArray;
		string config11 = LocalStringManager.GetConfig("Adventure_language", "Name_5");
		string config12 = LocalStringManager.GetConfig("Adventure_language", "Desc_5");
		int[] resCost6 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost6 = list;
		short[] malice6 = new short[3];
		list2 = new List<(string, string, string, string)>();
		dataArray6.Add(new AdventureItem(5, config11, config12, 1, 2, 2, 2, 10, -1, resCost6, itemCost6, restrictedByWorldPopulation: false, malice6, list2, "9d74053a-df65-439a-8732-d1585500677e", new List<AdventureStartNode>
		{
			new AdventureStartNode("f714bfba-a911-499a-aae5-ace6e58af368", "A", "LK_Adventure_NodeTitle_10", 8)
		}, new List<AdventureTransferNode>
		{
			new AdventureTransferNode("adcbc60b-c2db-4f56-89be-31277436b537", "B", "LK_Adventure_NodeTitle_11", 13)
		}, new List<AdventureEndNode>
		{
			new AdventureEndNode("3f050af1-083a-432d-9cce-5567f97682dc", "C", "LK_Adventure_NodeTitle_12", 13)
		}, new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 5, "", new int[2] { 15, 1 }, new int[10] { 3, 2, 7, 1, 2, 8, 2, 2, 18, 3 }, new int[5] { 25, 5, 5, 10, 10 }, new string[7] { "0", "0", "0", "1", "99227b61-afeb-459b-9618-7f620dd285fe", "40", "0" }, new int[77]
			{
				15, 0, 20, 5, 1, 20, 5, 2, 20, 5,
				3, 20, 5, 4, 20, 5, 0, 40, 3, 1,
				40, 3, 2, 40, 3, 3, 40, 3, 4, 40,
				3, 0, 60, 2, 1, 60, 2, 2, 60, 2,
				3, 60, 2, 4, 60, 2, 3, 8, 50, 5,
				8, 100, 3, 8, 150, 2, 0, 3, 7, 10,
				5, 7, 20, 3, 7, 30, 2, 3, 5, 20,
				5, 5, 40, 3, 5, 60, 2
			}, new int[33]
			{
				0, 0, 5, 5, -501, 1, 2, 5, -502, 1,
				2, 5, -503, 1, 2, 5, -504, 1, 2, 5,
				-505, 1, 2, 0, 2, 5, -506, 1, 5, 5,
				-507, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 1, 5, "", new int[2] { 15, 1 }, new int[10] { 3, 2, 7, 1, 2, 8, 2, 2, 18, 3 }, new int[5] { 25, 5, 5, 10, 10 }, new string[5] { "0", "0", "0", "0", "0" }, new int[77]
			{
				15, 0, 20, 5, 1, 20, 5, 2, 20, 5,
				3, 20, 5, 4, 20, 5, 0, 40, 3, 1,
				40, 3, 2, 40, 3, 3, 40, 3, 4, 40,
				3, 0, 60, 2, 1, 60, 2, 2, 60, 2,
				3, 60, 2, 4, 60, 2, 3, 8, 50, 5,
				8, 100, 3, 8, 150, 2, 0, 3, 7, 10,
				5, 7, 20, 3, 7, 30, 2, 3, 5, 20,
				5, 5, 40, 3, 5, 60, 2
			}, new int[33]
			{
				0, 0, 5, 5, -501, 1, 2, 5, -502, 1,
				2, 5, -503, 1, 2, 5, -504, 1, 2, 5,
				-505, 1, 2, 0, 2, 5, -506, 1, 5, 5,
				-507, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" })
		}, new List<AdventureAdvancedBranch>
		{
			new AdventureAdvancedBranch(3, "", 1, 15, 60, new int[2] { 15, 1 }, new int[4] { 1, 2, 3, 1 }, new int[5] { 5, 5, 5, 5, 5 }, new string[5] { "0", "0", "0", "0", "0" }, new int[50]
			{
				3, 6, 200, 5, 6, 400, 3, 6, 600, 2,
				3, 6, 200, 5, 6, 400, 3, 6, 600, 2,
				3, 6, 200, 5, 6, 400, 3, 6, 600, 2,
				3, 6, 200, 5, 6, 400, 3, 6, 600, 2,
				3, 6, 200, 5, 6, 400, 3, 6, 600, 2
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray7 = _dataArray;
		string config13 = LocalStringManager.GetConfig("Adventure_language", "Name_6");
		string config14 = LocalStringManager.GetConfig("Adventure_language", "Desc_6");
		int[] resCost7 = new int[9];
		List<int[]> itemCost7 = new List<int[]> { new int[2] { 12, 229 } };
		short[] malice7 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams6 = list2;
		List<AdventureStartNode> startNodes6 = new List<AdventureStartNode>
		{
			new AdventureStartNode("fe397e1e-a820-463c-a4ea-6ff3eb7c2f06", "A", "LK_Adventure_NodeTitle_13", 1),
			new AdventureStartNode("80a194d2-1a48-41d8-b577-2043820d441c", "B", "LK_Adventure_NodeTitle_2", 1)
		};
		list3 = new List<AdventureTransferNode>();
		dataArray7.Add(new AdventureItem(6, config13, config14, 1, 4, 2, 0, 1, -1, resCost7, itemCost7, restrictedByWorldPopulation: false, malice7, adventureParams6, "be986c64-0ae7-4503-a269-46f094d1e293", startNodes6, list3, new List<AdventureEndNode>
		{
			new AdventureEndNode("35be0310-7654-4c15-be37-586f1e137aa2", "C", "LK_Adventure_NodeTitle_14", 4)
		}, new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 2, "1", 1, 5, "", new int[2] { 15, 1 }, new int[7] { 2, 2, 3, 1, 2, 4, 1 }, new int[5] { 25, 5, 5, 10, 10 }, new string[5] { "0", "0", "0", "0", "0" }, new int[77]
			{
				15, 0, 20, 5, 1, 20, 5, 2, 20, 5,
				3, 20, 5, 4, 20, 5, 0, 40, 3, 1,
				40, 3, 2, 40, 3, 3, 40, 3, 4, 40,
				3, 0, 60, 2, 1, 60, 2, 2, 60, 2,
				3, 60, 2, 4, 60, 2, 3, 8, 50, 5,
				8, 100, 3, 8, 150, 2, 0, 3, 7, 10,
				5, 7, 20, 3, 7, 30, 2, 3, 5, 20,
				5, 5, 40, 3, 5, 60, 2
			}, new int[33]
			{
				0, 0, 5, 5, -501, 1, 2, 5, -502, 1,
				2, 5, -503, 1, 2, 5, -504, 1, 2, 5,
				-505, 1, 2, 0, 2, 5, -506, 1, 5, 5,
				-507, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 1, 5, "", new int[2] { 15, 1 }, new int[7] { 2, 2, 3, 1, 2, 4, 1 }, new int[5] { 25, 5, 5, 10, 10 }, new string[5] { "0", "0", "0", "0", "0" }, new int[77]
			{
				15, 0, 20, 5, 1, 20, 5, 2, 20, 5,
				3, 20, 5, 4, 20, 5, 0, 40, 3, 1,
				40, 3, 2, 40, 3, 3, 40, 3, 4, 40,
				3, 0, 60, 2, 1, 60, 2, 2, 60, 2,
				3, 60, 2, 4, 60, 2, 3, 8, 50, 5,
				8, 100, 3, 8, 150, 2, 0, 3, 7, 10,
				5, 7, 20, 3, 7, 30, 2, 3, 5, 20,
				5, 5, 40, 3, 5, 60, 2
			}, new int[33]
			{
				0, 0, 5, 5, -501, 1, 2, 5, -502, 1,
				2, 5, -503, 1, 2, 5, -504, 1, 2, 5,
				-505, 1, 2, 0, 2, 5, -506, 1, 5, 5,
				-507, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" })
		}, new List<AdventureAdvancedBranch>
		{
			new AdventureAdvancedBranch(1, "", 0, 15, 10, new int[4] { 12, 1, 13, 1 }, new int[9] { 1, 7, 6, 1, 0, 0, 0, 100, 0 }, new int[5] { 100, 100, 100, 0, 100 }, new string[7] { "0", "0", "0", "1", "cf59007f-1d80-4cd9-8eda-766da08faf16", "100", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureAdvancedBranch(1, "", 1, 15, 10, new int[4] { 12, 1, 13, 1 }, new int[9] { 1, 7, 6, 1, 0, 0, 0, 100, 0 }, new int[5] { 100, 100, 100, 0, 100 }, new string[7] { "0", "0", "0", "1", "cf59007f-1d80-4cd9-8eda-766da08faf16", "100", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray8 = _dataArray;
		string config15 = LocalStringManager.GetConfig("Adventure_language", "Name_7");
		string config16 = LocalStringManager.GetConfig("Adventure_language", "Desc_7");
		int[] resCost8 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost8 = list;
		short[] malice8 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams7 = list2;
		List<AdventureStartNode> startNodes7 = new List<AdventureStartNode>
		{
			new AdventureStartNode("52deeba4-3689-4fca-a36b-6e652e878fa3", "A", "LK_Adventure_NodeTitle_15", 2)
		};
		List<AdventureTransferNode> transferNodes6 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("5dd8d5b7-a0c0-445d-89f2-469ed8abb406", "B", "LK_Adventure_NodeTitle_16", 2),
			new AdventureTransferNode("d4b58f9c-9152-4cc7-b2ff-1fedc2a6cde2", "C", "LK_Adventure_NodeTitle_17", 2)
		};
		List<AdventureEndNode> endNodes6 = new List<AdventureEndNode>
		{
			new AdventureEndNode("6bb11e81-baf1-480b-b3a3-ab1dc3739f3b", "D", "LK_Adventure_NodeTitle_18", 2)
		};
		List<AdventureBaseBranch> baseBranches6 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 5, "", new int[32]
			{
				0, 1, 1, 1, 2, 1, 3, 1, 4, 1,
				5, 1, 6, 1, 7, 1, 8, 1, 9, 1,
				10, 1, 11, 1, 12, 1, 13, 1, 14, 1,
				15, 1
			}, new int[16]
			{
				5, 2, 1, 4, 2, 2, 5, 2, 3, 2,
				2, 11, 3, 2, 12, 1
			}, new int[5] { 25, 5, 5, 10, 10 }, new string[5] { "0", "0", "0", "0", "0" }, new int[77]
			{
				15, 0, 20, 5, 1, 20, 5, 2, 20, 5,
				3, 20, 5, 4, 20, 5, 0, 40, 3, 1,
				40, 3, 2, 40, 3, 3, 40, 3, 4, 40,
				3, 0, 60, 2, 1, 60, 2, 2, 60, 2,
				3, 60, 2, 4, 60, 2, 3, 8, 50, 5,
				8, 100, 3, 8, 150, 2, 0, 3, 7, 10,
				5, 7, 20, 3, 7, 30, 2, 3, 5, 20,
				5, 5, 40, 3, 5, 60, 2
			}, new int[33]
			{
				0, 0, 5, 5, -501, 1, 2, 5, -502, 1,
				2, 5, -503, 1, 2, 5, -504, 1, 2, 5,
				-505, 1, 2, 0, 2, 5, -506, 1, 5, 5,
				-507, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 1, 5, "", new int[32]
			{
				0, 1, 1, 1, 2, 1, 3, 1, 4, 1,
				5, 1, 6, 1, 7, 1, 8, 1, 9, 1,
				10, 1, 11, 1, 12, 1, 13, 1, 14, 1,
				15, 1
			}, new int[16]
			{
				5, 2, 1, 4, 2, 2, 5, 2, 3, 2,
				2, 11, 3, 2, 12, 1
			}, new int[5] { 25, 5, 5, 10, 10 }, new string[5] { "0", "0", "0", "0", "0" }, new int[77]
			{
				15, 0, 20, 5, 1, 20, 5, 2, 20, 5,
				3, 20, 5, 4, 20, 5, 0, 40, 3, 1,
				40, 3, 2, 40, 3, 3, 40, 3, 4, 40,
				3, 0, 60, 2, 1, 60, 2, 2, 60, 2,
				3, 60, 2, 4, 60, 2, 3, 8, 50, 5,
				8, 100, 3, 8, 150, 2, 0, 3, 7, 10,
				5, 7, 20, 3, 7, 30, 2, 3, 5, 20,
				5, 5, 40, 3, 5, 60, 2
			}, new int[33]
			{
				0, 0, 5, 5, -501, 1, 2, 5, -502, 1,
				2, 5, -503, 1, 2, 5, -504, 1, 2, 5,
				-505, 1, 2, 0, 2, 5, -506, 1, 5, 5,
				-507, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 3, "3", 1, 3, "", new int[32]
			{
				0, 1, 1, 1, 2, 1, 3, 1, 4, 1,
				5, 1, 6, 1, 7, 1, 8, 1, 9, 1,
				10, 1, 11, 1, 12, 1, 13, 1, 14, 1,
				15, 1
			}, new int[16]
			{
				5, 2, 1, 4, 2, 2, 5, 2, 3, 2,
				2, 11, 3, 2, 12, 1
			}, new int[5] { 25, 5, 5, 10, 10 }, new string[5] { "0", "0", "0", "0", "0" }, new int[77]
			{
				15, 0, 20, 5, 1, 20, 5, 2, 20, 5,
				3, 20, 5, 4, 20, 5, 0, 40, 3, 1,
				40, 3, 2, 40, 3, 3, 40, 3, 4, 40,
				3, 0, 60, 2, 1, 60, 2, 2, 60, 2,
				3, 60, 2, 4, 60, 2, 3, 8, 50, 5,
				8, 100, 3, 8, 150, 2, 0, 3, 7, 10,
				5, 7, 20, 3, 7, 30, 2, 3, 5, 20,
				5, 5, 40, 3, 5, 60, 2
			}, new int[33]
			{
				0, 0, 5, 5, -501, 1, 2, 5, -502, 1,
				2, 5, -503, 1, 2, 5, -504, 1, 2, 5,
				-505, 1, 2, 0, 2, 5, -506, 1, 5, 5,
				-507, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray8.Add(new AdventureItem(7, config15, config16, 1, 1, 2, 0, 1, -1, resCost8, itemCost8, restrictedByWorldPopulation: false, malice8, adventureParams7, "c0ed52cf-7c3d-4997-8573-79a2583a4abb", startNodes7, transferNodes6, endNodes6, baseBranches6, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray9 = _dataArray;
		string config17 = LocalStringManager.GetConfig("Adventure_language", "Name_8");
		string config18 = LocalStringManager.GetConfig("Adventure_language", "Desc_8");
		int[] resCost9 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost9 = list;
		short[] malice9 = new short[3];
		list2 = new List<(string, string, string, string)>();
		dataArray9.Add(new AdventureItem(8, config17, config18, 1, 1, 3, 0, 1, -1, resCost9, itemCost9, restrictedByWorldPopulation: false, malice9, list2, "1f452302-d9f5-40be-b74d-ab543c2be16e", new List<AdventureStartNode>
		{
			new AdventureStartNode("7cfb90f0-f8d0-49c1-878b-18edda314d06", "A", "LK_Adventure_NodeTitle_19", 20)
		}, new List<AdventureTransferNode>
		{
			new AdventureTransferNode("3a8e2cb7-1453-4a94-94ae-3110c1119734", "B", "LK_Adventure_NodeTitle_20", 20)
		}, new List<AdventureEndNode>
		{
			new AdventureEndNode("90dea193-5a77-4db7-8763-c5f24907beae", "C", "LK_Adventure_NodeTitle_21", 20)
		}, new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 5, "", new int[2] { 4, 1 }, new int[4] { 1, 2, 20, 1 }, new int[5] { 25, 5, 5, 10, 10 }, new string[5] { "0", "0", "0", "0", "0" }, new int[77]
			{
				15, 0, 40, 5, 1, 40, 5, 2, 40, 5,
				3, 40, 5, 4, 40, 5, 0, 60, 3, 1,
				60, 3, 2, 60, 3, 3, 60, 3, 4, 60,
				3, 0, 80, 2, 1, 80, 2, 2, 80, 2,
				3, 80, 2, 4, 80, 2, 3, 8, 100, 5,
				8, 150, 3, 8, 200, 2, 0, 3, 7, 20,
				5, 7, 30, 3, 7, 40, 2, 3, 5, 40,
				5, 5, 60, 3, 5, 80, 2
			}, new int[33]
			{
				0, 0, 5, 5, -501, 1, 2, 5, -502, 1,
				2, 5, -503, 1, 2, 5, -504, 1, 2, 5,
				-505, 1, 2, 0, 2, 5, -506, 1, 5, 5,
				-507, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 1, 5, "", new int[2] { 4, 1 }, new int[4] { 1, 2, 20, 1 }, new int[5] { 25, 5, 5, 10, 10 }, new string[5] { "0", "0", "0", "0", "0" }, new int[77]
			{
				15, 0, 40, 5, 1, 40, 5, 2, 40, 5,
				3, 40, 5, 4, 40, 5, 0, 60, 3, 1,
				60, 3, 2, 60, 3, 3, 60, 3, 4, 60,
				3, 0, 80, 2, 1, 80, 2, 2, 80, 2,
				3, 80, 2, 4, 80, 2, 3, 8, 100, 5,
				8, 150, 3, 8, 200, 2, 0, 3, 7, 20,
				5, 7, 30, 3, 7, 40, 2, 3, 5, 40,
				5, 5, 60, 3, 5, 80, 2
			}, new int[33]
			{
				0, 0, 5, 5, -501, 1, 2, 5, -502, 1,
				2, 5, -503, 1, 2, 5, -504, 1, 2, 5,
				-505, 1, 2, 0, 2, 5, -506, 1, 5, 5,
				-507, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" })
		}, new List<AdventureAdvancedBranch>
		{
			new AdventureAdvancedBranch(3, "", 1, 4, 60, new int[4] { 12, 1, 13, 1 }, new int[9] { 1, 7, 20, 1, 0, 0, 0, 0, 1 }, new int[5] { 1, 1, 1, 1, 10 }, new string[5] { "0", "0", "0", "0", "0" }, new int[5], new int[17]
			{
				0, 0, 0, 0, 3, 12, 0, 3, 5, 12,
				1, 2, 3, 12, 2, 1, 2
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureAdvancedBranch(3, "", 0, 4, 60, new int[4] { 13, 1, 12, 1 }, new int[9] { 1, 7, 20, 1, 0, 0, 0, 0, 1 }, new int[5] { 1, 1, 1, 1, 10 }, new string[5] { "0", "0", "0", "0", "0" }, new int[5], new int[17]
			{
				0, 0, 0, 0, 3, 12, 0, 3, 5, 12,
				1, 2, 3, 12, 2, 1, 2
			}, new string[5] { "0", "0", "0", "0", "0" })
		}, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray10 = _dataArray;
		string config19 = LocalStringManager.GetConfig("Adventure_language", "Name_9");
		string config20 = LocalStringManager.GetConfig("Adventure_language", "Desc_9");
		int[] resCost10 = new int[9];
		list = new List<int[]>();
		dataArray10.Add(new AdventureItem(9, config19, config20, 1, 7, 7, 0, 10, 6, resCost10, list, restrictedByWorldPopulation: false, new short[3], new List<(string, string, string, string)> { ("SectsPraise", "LK_Adventure_9_ParamName_0", "adventure_icon_chenggonglv", "") }, "2066e387-75a8-4ea8-afed-d0cab3a3ab10", new List<AdventureStartNode>
		{
			new AdventureStartNode("1245cde7-a454-401c-9f2f-fa761ad92a10", "A0", "LK_Adventure_NodeTitle_23", 1)
		}, new List<AdventureTransferNode>
		{
			new AdventureTransferNode("070cfc1f-5deb-4643-99d5-c27d0518dc0c", "A1", "LK_Adventure_NodeTitle_24", 1),
			new AdventureTransferNode("0c041256-3bf2-409d-b047-8dbe6aeb685e", "A2", "LK_Adventure_NodeTitle_25", 1),
			new AdventureTransferNode("88e76e8b-1a07-413f-8d04-831d5230c841", "A3", "LK_Adventure_NodeTitle_26", 1),
			new AdventureTransferNode("561e3574-0d0e-4111-9a3b-0aaf9e7d5958", "A4", "LK_Adventure_NodeTitle_27", 1),
			new AdventureTransferNode("5f46b7ec-ac1f-4f12-854b-88fea93cc832", "A5", "LK_Adventure_NodeTitle_28", 1),
			new AdventureTransferNode("ad4b177c-fcd2-4ad2-a2d0-a4f7b869b243", "A6", "LK_Adventure_NodeTitle_28", 1)
		}, new List<AdventureEndNode>
		{
			new AdventureEndNode("29f45cd7-2841-4374-a01e-d3e53029ce18", "B", "LK_Adventure_NodeTitle_29", 1)
		}, new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 10, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[4] { 1, 2, 1, 100 }, new int[5] { 100, 100, 100, 100, 100 }, new string[5] { "0", "0", "0", "0", "0" }, new int[14]
			{
				0, 3, 8, 800, 50, 8, 1200, 30, 8, 1600,
				20, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 1, 10, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[4] { 1, 2, 1, 100 }, new int[5] { 100, 100, 100, 100, 100 }, new string[5] { "0", "0", "0", "0", "0" }, new int[14]
			{
				0, 3, 8, 800, 50, 8, 1200, 30, 8, 1600,
				20, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 3, "3", 1, 5, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[4] { 1, 2, 1, 100 }, new int[5] { 100, 200, 100, 100, 100 }, new string[15]
			{
				"1", "01cf52be-43f9-4511-9012-595172530955", "100", "1", "01cf52be-43f9-4511-9012-595172530955", "100", "1", "01cf52be-43f9-4511-9012-595172530955", "100", "1",
				"01cf52be-43f9-4511-9012-595172530955", "100", "1", "01cf52be-43f9-4511-9012-595172530955", "100"
			}, new int[14]
			{
				0, 3, 8, 800, 50, 8, 1200, 30, 8, 1600,
				20, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 4, "4", 1, 5, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[4] { 1, 2, 1, 100 }, new int[5] { 200, 200, 200, 200, 200 }, new string[15]
			{
				"1", "f85e6861-3e83-42f6-8001-2f262d525121", "100", "1", "f85e6861-3e83-42f6-8001-2f262d525121", "100", "1", "f85e6861-3e83-42f6-8001-2f262d525121", "100", "1",
				"f85e6861-3e83-42f6-8001-2f262d525121", "100", "1", "f85e6861-3e83-42f6-8001-2f262d525121", "100"
			}, new int[50]
			{
				3, 8, 80, 75, 8, 160, 20, 8, 320, 5,
				3, 8, 80, 75, 8, 160, 20, 8, 320, 5,
				3, 8, 80, 75, 8, 160, 20, 8, 320, 5,
				3, 8, 80, 75, 8, 160, 20, 8, 320, 5,
				3, 8, 80, 75, 8, 160, 20, 8, 320, 5
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(4, 5, "5", 1, 5, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[4] { 1, 2, 1, 100 }, new int[5] { 100, 200, 100, 100, 100 }, new string[15]
			{
				"1", "b96d9ca7-bf14-4ea7-86a2-9d5a049752fc", "100", "1", "b96d9ca7-bf14-4ea7-86a2-9d5a049752fc", "100", "1", "b96d9ca7-bf14-4ea7-86a2-9d5a049752fc", "100", "1",
				"b96d9ca7-bf14-4ea7-86a2-9d5a049752fc", "100", "1", "b96d9ca7-bf14-4ea7-86a2-9d5a049752fc", "100"
			}, new int[14]
			{
				0, 3, 8, 800, 50, 8, 1200, 30, 8, 1600,
				20, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(5, 6, "6", 1, 5, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[4] { 1, 2, 1, 100 }, new int[5] { 100, 200, 100, 100, 100 }, new string[15]
			{
				"1", "901f7264-ec98-4e29-922b-8f4fa5f156c6", "100", "1", "901f7264-ec98-4e29-922b-8f4fa5f156c6", "100", "1", "901f7264-ec98-4e29-922b-8f4fa5f156c6", "100", "1",
				"901f7264-ec98-4e29-922b-8f4fa5f156c6", "100", "1", "901f7264-ec98-4e29-922b-8f4fa5f156c6", "100"
			}, new int[14]
			{
				0, 3, 8, 800, 50, 8, 1200, 30, 8, 1600,
				20, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(6, 7, "7", 1, 5, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[4] { 1, 2, 1, 100 }, new int[5] { 100, 200, 100, 100, 100 }, new string[15]
			{
				"1", "762eba12-d02c-4a14-8938-20339a66460a", "100", "1", "762eba12-d02c-4a14-8938-20339a66460a", "100", "1", "762eba12-d02c-4a14-8938-20339a66460a", "100", "1",
				"762eba12-d02c-4a14-8938-20339a66460a", "100", "1", "762eba12-d02c-4a14-8938-20339a66460a", "100"
			}, new int[14]
			{
				0, 3, 8, 800, 50, 8, 1200, 30, 8, 1600,
				20, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, new List<AdventureAdvancedBranch>
		{
			new AdventureAdvancedBranch(1, "", 2, 15, 180, new int[2] { 15, 100 }, new int[9] { 1, 7, 1, 100, 0, 0, 0, 100, 0 }, new int[5] { 10, 10, 10, 0, 10 }, new string[7] { "0", "0", "0", "1", "9e7faa36-bf31-4ad1-9397-23430dbaf5dc", "100", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureAdvancedBranch(1, "", 3, 15, 180, new int[2] { 15, 100 }, new int[9] { 1, 7, 1, 100, 0, 0, 0, 100, 0 }, new int[5] { 10, 10, 10, 0, 10 }, new string[7] { "0", "0", "0", "1", "9e7faa36-bf31-4ad1-9397-23430dbaf5dc", "100", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureAdvancedBranch(1, "", 1, 15, 180, new int[2] { 15, 100 }, new int[9] { 1, 7, 1, 100, 0, 0, 0, 100, 0 }, new int[5] { 10, 10, 10, 0, 10 }, new string[7] { "0", "0", "0", "1", "9e7faa36-bf31-4ad1-9397-23430dbaf5dc", "100", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray11 = _dataArray;
		string config21 = LocalStringManager.GetConfig("Adventure_language", "Name_10");
		string config22 = LocalStringManager.GetConfig("Adventure_language", "Desc_10");
		int[] resCost11 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost10 = list;
		short[] malice10 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams8 = list2;
		List<AdventureStartNode> startNodes8 = new List<AdventureStartNode>
		{
			new AdventureStartNode("40ed6909-7323-4a92-8ce8-f3ddc7710651", "A", "LK_Adventure_NodeTitle_30", 18)
		};
		list3 = new List<AdventureTransferNode>();
		List<AdventureTransferNode> transferNodes7 = list3;
		List<AdventureEndNode> endNodes7 = new List<AdventureEndNode>
		{
			new AdventureEndNode("47661c8e-d0a5-4270-84af-45158becb071", "B", "LK_Adventure_NodeTitle_31", 22)
		};
		List<AdventureBaseBranch> baseBranches7 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 10, "", new int[4] { 12, 1, 13, 1 }, new int[10] { 3, 2, 16, 3, 2, 18, 2, 2, 22, 1 }, new int[5] { 25, 5, 5, 10, 10 }, new string[7] { "0", "0", "0", "1", "4249e10e-f8f7-4701-a183-70fe89af5364", "40", "0" }, new int[77]
			{
				15, 0, 320, 5, 1, 320, 5, 2, 320, 5,
				3, 320, 5, 4, 320, 5, 0, 480, 3, 1,
				480, 3, 2, 480, 3, 3, 480, 3, 4, 480,
				3, 0, 640, 2, 1, 640, 2, 2, 640, 2,
				3, 640, 2, 4, 640, 2, 3, 8, 800, 5,
				8, 1200, 3, 8, 1600, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 320,
				5, 5, 480, 3, 5, 640, 2
			}, new int[33]
			{
				0, 0, 5, 5, -501, 1, 2, 5, -502, 1,
				2, 5, -503, 1, 2, 5, -504, 1, 2, 5,
				-505, 1, 2, 0, 2, 5, -506, 1, 5, 5,
				-507, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray11.Add(new AdventureItem(10, config21, config22, 1, 7, 7, 0, 5, -1, resCost11, itemCost10, restrictedByWorldPopulation: false, malice10, adventureParams8, "8455e12f-1107-41f9-849e-59f90b9ee284", startNodes8, transferNodes7, endNodes7, baseBranches7, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray12 = _dataArray;
		string config23 = LocalStringManager.GetConfig("Adventure_language", "Name_11");
		string config24 = LocalStringManager.GetConfig("Adventure_language", "Desc_11");
		int[] resCost12 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost11 = list;
		short[] malice11 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams9 = list2;
		List<AdventureStartNode> startNodes9 = new List<AdventureStartNode>
		{
			new AdventureStartNode("1dcee8aa-6b28-4602-815b-deb541b20b59", "A", "LK_Adventure_NodeTitle_32", 17)
		};
		List<AdventureTransferNode> transferNodes8 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("46e6894e-5c91-4d0c-9c77-1aedae62751e", "B", "LK_Adventure_NodeTitle_33", 22),
			new AdventureTransferNode("f6d1c43e-bff6-4fce-b1ce-8d02bcea8d6b", "C", "LK_Adventure_NodeTitle_34", 22)
		};
		List<AdventureEndNode> endNodes8 = new List<AdventureEndNode>
		{
			new AdventureEndNode("c58fe925-15a3-4d76-adba-442c6f4b0efc", "D", "LK_Adventure_NodeTitle_35", 22)
		};
		List<AdventureBaseBranch> baseBranches8 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 5, "", new int[2] { 4, 1 }, new int[9] { 1, 7, 22, 1, 5, 5, 5, 80, 5 }, new int[5] { 20, 20, 20, 100, 20 }, new string[7] { "0", "0", "0", "1", "6dfc944f-1da0-4e1f-9913-54cd391c6673", "100", "0" }, new int[41]
			{
				3, 8, 2100, 5, 8, 3150, 3, 8, 4200, 2,
				3, 8, 2100, 5, 8, 3150, 3, 8, 4200, 2,
				3, 8, 2100, 5, 8, 3150, 3, 8, 4200, 2,
				0, 3, 8, 2100, 5, 8, 3150, 3, 8, 4200,
				2
			}, new int[53]
			{
				3, 12, 5, 1, 5, 12, 6, 1, 3, 12,
				7, 1, 2, 3, 12, 5, 1, 5, 12, 6,
				1, 3, 12, 7, 1, 2, 3, 12, 5, 1,
				5, 12, 6, 1, 3, 12, 7, 1, 2, 0,
				3, 12, 5, 1, 5, 12, 6, 1, 3, 12,
				7, 1, 2
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "1", 1, 10, "", new int[2] { 4, 1 }, new int[9] { 1, 7, 22, 1, 5, 5, 5, 80, 5 }, new int[5] { 20, 20, 20, 100, 20 }, new string[7] { "0", "0", "0", "1", "6dfc944f-1da0-4e1f-9913-54cd391c6673", "100", "0" }, new int[41]
			{
				3, 8, 2100, 5, 8, 3150, 3, 8, 4200, 2,
				3, 8, 2100, 5, 8, 3150, 3, 8, 4200, 2,
				3, 8, 2100, 5, 8, 3150, 3, 8, 4200, 2,
				0, 3, 8, 2100, 5, 8, 3150, 3, 8, 4200,
				2
			}, new int[53]
			{
				3, 12, 5, 1, 5, 12, 6, 1, 3, 12,
				7, 1, 2, 3, 12, 5, 1, 5, 12, 6,
				1, 3, 12, 7, 1, 2, 3, 12, 5, 1,
				5, 12, 6, 1, 3, 12, 7, 1, 2, 0,
				3, 12, 5, 1, 5, 12, 6, 1, 3, 12,
				7, 1, 2
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 3, "1", 1, 3, "", new int[2] { 4, 1 }, new int[9] { 1, 7, 22, 1, 5, 5, 5, 80, 5 }, new int[5] { 20, 20, 20, 100, 20 }, new string[7] { "0", "0", "0", "1", "6dfc944f-1da0-4e1f-9913-54cd391c6673", "100", "0" }, new int[41]
			{
				3, 8, 2100, 5, 8, 3150, 3, 8, 4200, 2,
				3, 8, 2100, 5, 8, 3150, 3, 8, 4200, 2,
				3, 8, 2100, 5, 8, 3150, 3, 8, 4200, 2,
				0, 3, 8, 2100, 5, 8, 3150, 3, 8, 4200,
				2
			}, new int[53]
			{
				3, 12, 5, 1, 5, 12, 6, 1, 3, 12,
				7, 1, 2, 3, 12, 5, 1, 5, 12, 6,
				1, 3, 12, 7, 1, 2, 3, 12, 5, 1,
				5, 12, 6, 1, 3, 12, 7, 1, 2, 0,
				3, 12, 5, 1, 5, 12, 6, 1, 3, 12,
				7, 1, 2
			}, new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray12.Add(new AdventureItem(11, config23, config24, 1, 9, 9, 0, 10, 1, resCost12, itemCost11, restrictedByWorldPopulation: false, malice11, adventureParams9, "ae36b75a-e924-47a9-ab75-c51f374843f0", startNodes9, transferNodes8, endNodes8, baseBranches8, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray13 = _dataArray;
		string config25 = LocalStringManager.GetConfig("Adventure_language", "Name_12");
		string config26 = LocalStringManager.GetConfig("Adventure_language", "Desc_12");
		int[] resCost13 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost12 = list;
		short[] malice12 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams10 = list2;
		List<AdventureStartNode> startNodes10 = new List<AdventureStartNode>
		{
			new AdventureStartNode("336e4547-e9d9-4f98-b6bc-028c80a0b571", "A", "LK_Adventure_NodeTitle_36", 1)
		};
		list3 = new List<AdventureTransferNode>();
		List<AdventureTransferNode> transferNodes9 = list3;
		List<AdventureEndNode> endNodes9 = new List<AdventureEndNode>
		{
			new AdventureEndNode("d57b18e9-1bce-4f0e-a76b-7cbf41a268c0", "C", "LK_Adventure_NodeTitle_37", 1)
		};
		List<AdventureBaseBranch> baseBranches9 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 10, "", new int[2] { 9, 100 }, new int[9] { 1, 7, 1, 100, 10, 10, 10, 10, 60 }, new int[5] { 100, 100, 100, 100, 50 }, new string[5] { "0", "0", "0", "0", "0" }, new int[5], new int[9] { 0, 0, 0, 0, 1, 5, -506, 1, 50 }, new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray13.Add(new AdventureItem(12, config25, config26, 2, 1, 1, 0, 10, -1, resCost13, itemCost12, restrictedByWorldPopulation: false, malice12, adventureParams10, "3bb05013-d7fb-4420-a99d-49433d0413ce", startNodes10, transferNodes9, endNodes9, baseBranches9, advancedBranches, difficultyAddXiangshuLevel: true));
		List<AdventureItem> dataArray14 = _dataArray;
		string config27 = LocalStringManager.GetConfig("Adventure_language", "Name_13");
		string config28 = LocalStringManager.GetConfig("Adventure_language", "Desc_13");
		int[] resCost14 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost13 = list;
		short[] malice13 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams11 = list2;
		List<AdventureStartNode> startNodes11 = new List<AdventureStartNode>
		{
			new AdventureStartNode("941badc6-fd68-4736-883a-ede0bf03c729", "A", "LK_Adventure_NodeTitle_38", 0)
		};
		List<AdventureTransferNode> transferNodes10 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("5e5388f5-636f-4bdf-9b25-4abad586fa31", "B", "LK_Adventure_NodeTitle_39", 0)
		};
		List<AdventureEndNode> endNodes10 = new List<AdventureEndNode>
		{
			new AdventureEndNode("073eecfa-6bb3-422b-92ee-a812acd94cf2", "C", "LK_Adventure_NodeTitle_40", 0)
		};
		List<AdventureBaseBranch> baseBranches10 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 3, "", new int[2] { 14, 100 }, new int[4] { 1, 2, 5, 100 }, new int[5] { 100, 0, 100, 100, 100 }, new string[5] { "0", "0", "0", "0", "0" }, new int[14]
			{
				0, 3, 8, 300, 5, 8, 450, 3, 8, 600,
				2, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 1, 8, "", new int[2] { 14, 100 }, new int[9] { 1, 7, 5, 100, 30, 30, 5, 30, 5 }, new int[5] { 10, 0, 100, 10, 100 }, new string[9] { "1", "5d9f1588-0ce1-4347-baf3-b856a8a08b92", "10", "0", "0", "1", "45abdf3d-6cd2-4a94-a639-f46e0c5b80a6", "10", "0" }, new int[14]
			{
				0, 3, 8, 300, 5, 8, 450, 3, 8, 600,
				2, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray14.Add(new AdventureItem(13, config27, config28, 2, 1, 1, 0, 3, 3, resCost14, itemCost13, restrictedByWorldPopulation: false, malice13, adventureParams11, "13f24664-7834-47ea-b838-b95a37838f49", startNodes11, transferNodes10, endNodes10, baseBranches10, advancedBranches, difficultyAddXiangshuLevel: true));
		List<AdventureItem> dataArray15 = _dataArray;
		string config29 = LocalStringManager.GetConfig("Adventure_language", "Name_14");
		string config30 = LocalStringManager.GetConfig("Adventure_language", "Desc_14");
		int[] resCost15 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost14 = list;
		short[] malice14 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams12 = list2;
		List<AdventureStartNode> startNodes12 = new List<AdventureStartNode>
		{
			new AdventureStartNode("9a548256-778e-437b-9aa8-3594c69e9559", "A", "LK_Adventure_NodeTitle_41", 8)
		};
		List<AdventureTransferNode> transferNodes11 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("6ea8a8cf-3864-41ff-95f0-64df1380b7f7", "B", "LK_Adventure_NodeTitle_42", 8),
			new AdventureTransferNode("838664ff-9e09-41c9-9ebf-944c942b343f", "C", "LK_Adventure_NodeTitle_42", 8),
			new AdventureTransferNode("b3d75505-2ceb-40c0-a9dd-1accbba76d4d", "D", "LK_Adventure_NodeTitle_42", 8),
			new AdventureTransferNode("2ceabc86-7623-4f13-98b1-d8ed2d01167b", "E", "LK_Adventure_NodeTitle_42", 8),
			new AdventureTransferNode("6609ba01-45cd-4078-9ef8-63e9b16bca1f", "F", "LK_Adventure_NodeTitle_42", 8),
			new AdventureTransferNode("84424b09-5a9f-44d8-b546-0ecb5bde7d9f", "G", "LK_Adventure_NodeTitle_42", 8),
			new AdventureTransferNode("e05f1887-1c08-4bc4-bf8d-9506f3671df5", "H", "LK_Adventure_NodeTitle_42", 8),
			new AdventureTransferNode("00db26b4-4007-4787-973a-b8960c36ea13", "I", "LK_Adventure_NodeTitle_42", 8),
			new AdventureTransferNode("7cf1de5c-9d11-4a40-a2ed-cd3faf39c772", "J", "LK_Adventure_NodeTitle_42", 8)
		};
		List<AdventureEndNode> endNodes11 = new List<AdventureEndNode>
		{
			new AdventureEndNode("f7f35263-1d65-4a2d-90e9-1ea212fff8cc", "K", "LK_Adventure_NodeTitle_43", 8),
			new AdventureEndNode("fd4dce68-2ab8-4480-ad11-738b2b4a9579", "L", "LK_Adventure_NodeTitle_44", 8),
			new AdventureEndNode("47cdd663-c3b1-47eb-8096-853e20273a54", "M", "LK_Adventure_NodeTitle_43", 8)
		};
		List<AdventureBaseBranch> baseBranches11 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 3, "", new int[2] { 15, 100 }, new int[4] { 1, 2, 8, 100 }, new int[5] { 25, 5, 100, 5, 2 }, new string[5] { "0", "0", "0", "0", "0" }, new int[59]
			{
				15, 0, 10, 5, 0, 20, 3, 0, 30, 2,
				1, 10, 5, 1, 20, 3, 1, 30, 2, 2,
				10, 5, 2, 20, 3, 2, 30, 2, 3, 10,
				5, 3, 20, 3, 3, 30, 2, 4, 10, 5,
				4, 20, 3, 4, 30, 2, 3, 8, 25, 5,
				8, 50, 3, 8, 75, 2, 0, 0, 0
			}, new int[33]
			{
				0, 0, 0, 5, 5, -501, 1, 2, 5, -502,
				1, 2, 5, -503, 1, 2, 5, -504, 1, 2,
				5, -505, 1, 2, 2, 5, -506, 1, 2, 5,
				-507, 1, 2
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 1, 3, "", new int[2] { 15, 100 }, new int[4] { 1, 2, 8, 100 }, new int[5] { 25, 5, 100, 5, 2 }, new string[5] { "0", "0", "0", "0", "0" }, new int[59]
			{
				15, 0, 10, 5, 0, 20, 3, 0, 30, 2,
				1, 10, 5, 1, 20, 3, 1, 30, 2, 2,
				10, 5, 2, 20, 3, 2, 30, 2, 3, 10,
				5, 3, 20, 3, 3, 30, 2, 4, 10, 5,
				4, 20, 3, 4, 30, 2, 3, 8, 25, 5,
				8, 50, 3, 8, 75, 2, 0, 0, 0
			}, new int[33]
			{
				0, 0, 0, 5, 5, -501, 1, 2, 5, -502,
				1, 2, 5, -503, 1, 2, 5, -504, 1, 2,
				5, -505, 1, 2, 2, 5, -506, 1, 2, 5,
				-507, 1, 2
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 3, "3", 1, 3, "", new int[2] { 15, 100 }, new int[4] { 1, 2, 8, 100 }, new int[5] { 25, 5, 100, 5, 2 }, new string[5] { "0", "0", "0", "0", "0" }, new int[59]
			{
				15, 0, 10, 5, 0, 20, 3, 0, 30, 2,
				1, 10, 5, 1, 20, 3, 1, 30, 2, 2,
				10, 5, 2, 20, 3, 2, 30, 2, 3, 10,
				5, 3, 20, 3, 3, 30, 2, 4, 10, 5,
				4, 20, 3, 4, 30, 2, 3, 8, 25, 5,
				8, 50, 3, 8, 75, 2, 0, 0, 0
			}, new int[33]
			{
				0, 0, 0, 5, 5, -501, 1, 2, 5, -502,
				1, 2, 5, -503, 1, 2, 5, -504, 1, 2,
				5, -505, 1, 2, 2, 5, -506, 1, 2, 5,
				-507, 1, 2
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 4, "4", 1, 3, "", new int[2] { 15, 100 }, new int[4] { 1, 2, 8, 100 }, new int[5] { 25, 5, 100, 5, 2 }, new string[5] { "0", "0", "0", "0", "0" }, new int[59]
			{
				15, 0, 10, 5, 0, 20, 3, 0, 30, 2,
				1, 10, 5, 1, 20, 3, 1, 30, 2, 2,
				10, 5, 2, 20, 3, 2, 30, 2, 3, 10,
				5, 3, 20, 3, 3, 30, 2, 4, 10, 5,
				4, 20, 3, 4, 30, 2, 3, 8, 25, 5,
				8, 50, 3, 8, 75, 2, 0, 0, 0
			}, new int[33]
			{
				0, 0, 0, 5, 5, -501, 1, 2, 5, -502,
				1, 2, 5, -503, 1, 2, 5, -504, 1, 2,
				5, -505, 1, 2, 2, 5, -506, 1, 2, 5,
				-507, 1, 2
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 5, "5", 1, 3, "", new int[2] { 15, 100 }, new int[4] { 1, 2, 8, 100 }, new int[5] { 25, 5, 100, 5, 2 }, new string[5] { "0", "0", "0", "0", "0" }, new int[59]
			{
				15, 0, 10, 5, 0, 20, 3, 0, 30, 2,
				1, 10, 5, 1, 20, 3, 1, 30, 2, 2,
				10, 5, 2, 20, 3, 2, 30, 2, 3, 10,
				5, 3, 20, 3, 3, 30, 2, 4, 10, 5,
				4, 20, 3, 4, 30, 2, 3, 8, 25, 5,
				8, 50, 3, 8, 75, 2, 0, 0, 0
			}, new int[33]
			{
				0, 0, 0, 5, 5, -501, 1, 2, 5, -502,
				1, 2, 5, -503, 1, 2, 5, -504, 1, 2,
				5, -505, 1, 2, 2, 5, -506, 1, 2, 5,
				-507, 1, 2
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 6, "6", 1, 3, "", new int[2] { 15, 100 }, new int[4] { 1, 2, 8, 100 }, new int[5] { 25, 5, 100, 5, 2 }, new string[5] { "0", "0", "0", "0", "0" }, new int[59]
			{
				15, 0, 10, 5, 0, 20, 3, 0, 30, 2,
				1, 10, 5, 1, 20, 3, 1, 30, 2, 2,
				10, 5, 2, 20, 3, 2, 30, 2, 3, 10,
				5, 3, 20, 3, 3, 30, 2, 4, 10, 5,
				4, 20, 3, 4, 30, 2, 3, 8, 25, 5,
				8, 50, 3, 8, 75, 2, 0, 0, 0
			}, new int[33]
			{
				0, 0, 0, 5, 5, -501, 1, 2, 5, -502,
				1, 2, 5, -503, 1, 2, 5, -504, 1, 2,
				5, -505, 1, 2, 2, 5, -506, 1, 2, 5,
				-507, 1, 2
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 7, "7", 1, 3, "", new int[2] { 15, 100 }, new int[4] { 1, 2, 8, 100 }, new int[5] { 25, 5, 100, 5, 2 }, new string[5] { "0", "0", "0", "0", "0" }, new int[59]
			{
				15, 0, 10, 5, 0, 20, 3, 0, 30, 2,
				1, 10, 5, 1, 20, 3, 1, 30, 2, 2,
				10, 5, 2, 20, 3, 2, 30, 2, 3, 10,
				5, 3, 20, 3, 3, 30, 2, 4, 10, 5,
				4, 20, 3, 4, 30, 2, 3, 8, 25, 5,
				8, 50, 3, 8, 75, 2, 0, 0, 0
			}, new int[33]
			{
				0, 0, 0, 5, 5, -501, 1, 2, 5, -502,
				1, 2, 5, -503, 1, 2, 5, -504, 1, 2,
				5, -505, 1, 2, 2, 5, -506, 1, 2, 5,
				-507, 1, 2
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 8, "8", 1, 3, "", new int[2] { 15, 100 }, new int[4] { 1, 2, 8, 100 }, new int[5] { 25, 5, 100, 5, 2 }, new string[5] { "0", "0", "0", "0", "0" }, new int[59]
			{
				15, 0, 10, 5, 0, 20, 3, 0, 30, 2,
				1, 10, 5, 1, 20, 3, 1, 30, 2, 2,
				10, 5, 2, 20, 3, 2, 30, 2, 3, 10,
				5, 3, 20, 3, 3, 30, 2, 4, 10, 5,
				4, 20, 3, 4, 30, 2, 3, 8, 25, 5,
				8, 50, 3, 8, 75, 2, 0, 0, 0
			}, new int[33]
			{
				0, 0, 0, 5, 5, -501, 1, 2, 5, -502,
				1, 2, 5, -503, 1, 2, 5, -504, 1, 2,
				5, -505, 1, 2, 2, 5, -506, 1, 2, 5,
				-507, 1, 2
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 9, "9", 1, 3, "", new int[2] { 15, 100 }, new int[4] { 1, 2, 8, 100 }, new int[5] { 25, 5, 100, 5, 2 }, new string[5] { "0", "0", "0", "0", "0" }, new int[59]
			{
				15, 0, 10, 5, 0, 20, 3, 0, 30, 2,
				1, 10, 5, 1, 20, 3, 1, 30, 2, 2,
				10, 5, 2, 20, 3, 2, 30, 2, 3, 10,
				5, 3, 20, 3, 3, 30, 2, 4, 10, 5,
				4, 20, 3, 4, 30, 2, 3, 8, 25, 5,
				8, 50, 3, 8, 75, 2, 0, 0, 0
			}, new int[33]
			{
				0, 0, 0, 5, 5, -501, 1, 2, 5, -502,
				1, 2, 5, -503, 1, 2, 5, -504, 1, 2,
				5, -505, 1, 2, 2, 5, -506, 1, 2, 5,
				-507, 1, 2
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(4, 10, "10", 1, 3, "", new int[2] { 15, 100 }, new int[4] { 1, 2, 8, 100 }, new int[5] { 25, 5, 100, 5, 2 }, new string[5] { "0", "0", "0", "0", "0" }, new int[59]
			{
				15, 0, 10, 5, 0, 20, 3, 0, 30, 2,
				1, 10, 5, 1, 20, 3, 1, 30, 2, 2,
				10, 5, 2, 20, 3, 2, 30, 2, 3, 10,
				5, 3, 20, 3, 3, 30, 2, 4, 10, 5,
				4, 20, 3, 4, 30, 2, 3, 8, 25, 5,
				8, 50, 3, 8, 75, 2, 0, 0, 0
			}, new int[33]
			{
				0, 0, 0, 5, 5, -501, 1, 2, 5, -502,
				1, 2, 5, -503, 1, 2, 5, -504, 1, 2,
				5, -505, 1, 2, 2, 5, -506, 1, 2, 5,
				-507, 1, 2
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(5, 10, "11", 1, 3, "", new int[2] { 15, 100 }, new int[4] { 1, 2, 8, 100 }, new int[5] { 25, 5, 100, 5, 2 }, new string[5] { "0", "0", "0", "0", "0" }, new int[59]
			{
				15, 0, 10, 5, 0, 20, 3, 0, 30, 2,
				1, 10, 5, 1, 20, 3, 1, 30, 2, 2,
				10, 5, 2, 20, 3, 2, 30, 2, 3, 10,
				5, 3, 20, 3, 3, 30, 2, 4, 10, 5,
				4, 20, 3, 4, 30, 2, 3, 8, 25, 5,
				8, 50, 3, 8, 75, 2, 0, 0, 0
			}, new int[33]
			{
				0, 0, 0, 5, 5, -501, 1, 2, 5, -502,
				1, 2, 5, -503, 1, 2, 5, -504, 1, 2,
				5, -505, 1, 2, 2, 5, -506, 1, 2, 5,
				-507, 1, 2
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(6, 11, "12", 1, 3, "", new int[2] { 15, 100 }, new int[4] { 1, 2, 8, 100 }, new int[5] { 25, 5, 100, 5, 2 }, new string[5] { "0", "0", "0", "0", "0" }, new int[59]
			{
				15, 0, 10, 5, 0, 20, 3, 0, 30, 2,
				1, 10, 5, 1, 20, 3, 1, 30, 2, 2,
				10, 5, 2, 20, 3, 2, 30, 2, 3, 10,
				5, 3, 20, 3, 3, 30, 2, 4, 10, 5,
				4, 20, 3, 4, 30, 2, 3, 8, 25, 5,
				8, 50, 3, 8, 75, 2, 0, 0, 0
			}, new int[33]
			{
				0, 0, 0, 5, 5, -501, 1, 2, 5, -502,
				1, 2, 5, -503, 1, 2, 5, -504, 1, 2,
				5, -505, 1, 2, 2, 5, -506, 1, 2, 5,
				-507, 1, 2
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(9, 12, "15", 1, 3, "", new int[2] { 15, 100 }, new int[4] { 1, 2, 8, 100 }, new int[5] { 25, 5, 100, 5, 2 }, new string[5] { "0", "0", "0", "0", "0" }, new int[59]
			{
				15, 0, 10, 5, 0, 20, 3, 0, 30, 2,
				1, 10, 5, 1, 20, 3, 1, 30, 2, 2,
				10, 5, 2, 20, 3, 2, 30, 2, 3, 10,
				5, 3, 20, 3, 3, 30, 2, 4, 10, 5,
				4, 20, 3, 4, 30, 2, 3, 8, 25, 5,
				8, 50, 3, 8, 75, 2, 0, 0, 0
			}, new int[33]
			{
				0, 0, 0, 5, 5, -501, 1, 2, 5, -502,
				1, 2, 5, -503, 1, 2, 5, -504, 1, 2,
				5, -505, 1, 2, 2, 5, -506, 1, 2, 5,
				-507, 1, 2
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(7, 11, "13", 1, 3, "", new int[2] { 15, 100 }, new int[4] { 1, 2, 8, 100 }, new int[5] { 25, 5, 100, 5, 2 }, new string[5] { "0", "0", "0", "0", "0" }, new int[59]
			{
				15, 0, 10, 5, 0, 20, 3, 0, 30, 2,
				1, 10, 5, 1, 20, 3, 1, 30, 2, 2,
				10, 5, 2, 20, 3, 2, 30, 2, 3, 10,
				5, 3, 20, 3, 3, 30, 2, 4, 10, 5,
				4, 20, 3, 4, 30, 2, 3, 8, 25, 5,
				8, 50, 3, 8, 75, 2, 0, 0, 0
			}, new int[33]
			{
				0, 0, 0, 5, 5, -501, 1, 2, 5, -502,
				1, 2, 5, -503, 1, 2, 5, -504, 1, 2,
				5, -505, 1, 2, 2, 5, -506, 1, 2, 5,
				-507, 1, 2
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(8, 12, "14", 1, 3, "", new int[2] { 15, 100 }, new int[4] { 1, 2, 8, 100 }, new int[5] { 25, 5, 100, 5, 2 }, new string[5] { "0", "0", "0", "0", "0" }, new int[59]
			{
				15, 0, 10, 5, 0, 20, 3, 0, 30, 2,
				1, 10, 5, 1, 20, 3, 1, 30, 2, 2,
				10, 5, 2, 20, 3, 2, 30, 2, 3, 10,
				5, 3, 20, 3, 3, 30, 2, 4, 10, 5,
				4, 20, 3, 4, 30, 2, 3, 8, 25, 5,
				8, 50, 3, 8, 75, 2, 0, 0, 0
			}, new int[33]
			{
				0, 0, 0, 5, 5, -501, 1, 2, 5, -502,
				1, 2, 5, -503, 1, 2, 5, -504, 1, 2,
				5, -505, 1, 2, 2, 5, -506, 1, 2, 5,
				-507, 1, 2
			}, new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray15.Add(new AdventureItem(14, config29, config30, 2, 1, 1, 0, 6, 9, resCost15, itemCost14, restrictedByWorldPopulation: false, malice14, adventureParams12, "ad5c5e8d-347f-454f-af63-1f31fb702735", startNodes12, transferNodes11, endNodes11, baseBranches11, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray16 = _dataArray;
		string config31 = LocalStringManager.GetConfig("Adventure_language", "Name_15");
		string config32 = LocalStringManager.GetConfig("Adventure_language", "Desc_15");
		int[] resCost16 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost15 = list;
		short[] malice15 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams13 = list2;
		List<AdventureStartNode> startNodes13 = new List<AdventureStartNode>
		{
			new AdventureStartNode("ba053bcd-aed8-4a90-990e-dae88d723947", "A", "LK_Adventure_NodeTitle_45", 1)
		};
		List<AdventureTransferNode> transferNodes12 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("fbd3c969-2a72-44ed-9b60-38300bb80916", "B", "LK_Adventure_NodeTitle_46", 1),
			new AdventureTransferNode("a683c2d3-1ac3-4882-b9d8-f98267d0355a", "C", "LK_Adventure_NodeTitle_47", 1),
			new AdventureTransferNode("615d3659-eee1-446d-baeb-506d496e6e54", "D", "LK_Adventure_NodeTitle_48", 1)
		};
		List<AdventureEndNode> endNodes12 = new List<AdventureEndNode>
		{
			new AdventureEndNode("b2d9971c-fca7-4bfc-9283-77b5129db22d", "E", "LK_Adventure_NodeTitle_49", 1)
		};
		List<AdventureBaseBranch> baseBranches12 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 5, "", new int[4] { 12, 50, 13, 50 }, new int[4] { 1, 2, 1, 100 }, new int[5] { 25, 5, 100, 30, 30 }, new string[9] { "0", "0", "0", "1", "a218833b-d7c5-498e-a0f7-48afbd6c9e0a", "10", "1", "14c0e0be-8406-487e-b55b-12ac30d09aff", "10" }, new int[77]
			{
				15, 0, 40, 5, 0, 60, 3, 0, 80, 2,
				1, 40, 5, 1, 60, 3, 1, 80, 2, 2,
				40, 5, 2, 60, 3, 2, 80, 2, 3, 40,
				5, 3, 60, 3, 3, 80, 2, 4, 40, 5,
				4, 60, 3, 4, 80, 2, 3, 8, 100, 5,
				8, 150, 3, 8, 200, 2, 0, 3, 7, 20,
				5, 7, 30, 3, 7, 40, 2, 3, 5, 40,
				5, 5, 60, 3, 5, 80, 2
			}, new int[25]
			{
				5, 5, -501, 1, 1, 5, -502, 1, 1, 5,
				-503, 1, 1, 5, -504, 1, 1, 5, -505, 1,
				1, 0, 0, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 1, 5, "", new int[4] { 12, 50, 13, 50 }, new int[4] { 1, 2, 1, 100 }, new int[5] { 25, 5, 100, 30, 30 }, new string[9] { "0", "0", "0", "1", "a218833b-d7c5-498e-a0f7-48afbd6c9e0a", "10", "1", "14c0e0be-8406-487e-b55b-12ac30d09aff", "10" }, new int[77]
			{
				15, 0, 80, 5, 0, 120, 3, 0, 160, 2,
				1, 80, 5, 1, 120, 3, 1, 160, 2, 2,
				80, 5, 2, 120, 3, 2, 160, 2, 3, 80,
				5, 3, 120, 3, 3, 160, 2, 4, 80, 5,
				4, 120, 3, 4, 160, 2, 3, 8, 200, 5,
				8, 300, 3, 8, 400, 2, 0, 3, 7, 40,
				5, 7, 60, 3, 7, 80, 2, 3, 5, 80,
				5, 5, 120, 3, 5, 160, 2
			}, new int[25]
			{
				5, 5, -501, 1, 1, 5, -502, 1, 1, 5,
				-503, 1, 1, 5, -504, 1, 1, 5, -505, 1,
				1, 0, 0, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 3, "3", 1, 5, "", new int[4] { 12, 50, 13, 50 }, new int[4] { 1, 2, 1, 100 }, new int[5] { 25, 5, 100, 30, 30 }, new string[9] { "0", "0", "0", "1", "a218833b-d7c5-498e-a0f7-48afbd6c9e0a", "10", "1", "14c0e0be-8406-487e-b55b-12ac30d09aff", "10" }, new int[77]
			{
				15, 0, 120, 5, 0, 180, 3, 0, 240, 2,
				1, 120, 5, 1, 180, 3, 1, 240, 2, 2,
				120, 5, 2, 180, 3, 2, 240, 2, 3, 120,
				5, 3, 180, 3, 3, 240, 2, 4, 120, 5,
				4, 180, 3, 4, 240, 2, 3, 8, 300, 5,
				8, 450, 3, 8, 600, 2, 0, 3, 7, 60,
				5, 7, 90, 3, 7, 120, 2, 3, 5, 120,
				5, 5, 180, 3, 5, 240, 2
			}, new int[25]
			{
				5, 5, -501, 1, 1, 5, -502, 1, 1, 5,
				-503, 1, 1, 5, -504, 1, 1, 5, -505, 1,
				1, 0, 0, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 4, "4", 1, 5, "", new int[4] { 12, 50, 13, 50 }, new int[4] { 1, 2, 1, 100 }, new int[5] { 25, 5, 100, 30, 30 }, new string[9] { "0", "0", "0", "1", "a218833b-d7c5-498e-a0f7-48afbd6c9e0a", "10", "1", "14c0e0be-8406-487e-b55b-12ac30d09aff", "10" }, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 100,
				5, 7, 150, 3, 7, 200, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[25]
			{
				5, 5, -501, 1, 1, 5, -502, 1, 1, 5,
				-503, 1, 1, 5, -504, 1, 1, 5, -505, 1,
				1, 0, 0, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray16.Add(new AdventureItem(15, config31, config32, 2, 1, 1, 0, 3, 6, resCost16, itemCost15, restrictedByWorldPopulation: false, malice15, adventureParams13, "619c6a9a-7b69-4df7-a517-0d08828414ce", startNodes13, transferNodes12, endNodes12, baseBranches12, advancedBranches, difficultyAddXiangshuLevel: true));
		List<AdventureItem> dataArray17 = _dataArray;
		string config33 = LocalStringManager.GetConfig("Adventure_language", "Name_16");
		string config34 = LocalStringManager.GetConfig("Adventure_language", "Desc_16");
		int[] resCost17 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost16 = list;
		short[] malice16 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams14 = list2;
		List<AdventureStartNode> startNodes14 = new List<AdventureStartNode>
		{
			new AdventureStartNode("aec5e2af-5742-469a-9d3b-9cf78a957903", "A", "LK_Adventure_NodeTitle_50", 0)
		};
		List<AdventureTransferNode> transferNodes13 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("978f5ecd-dc66-4515-8151-12b9265b1117", "B", "LK_Adventure_NodeTitle_51", 0),
			new AdventureTransferNode("ff6cc7de-e81f-4c77-b674-1f9f07203fd9", "C", "LK_Adventure_NodeTitle_52", 0),
			new AdventureTransferNode("8fb114d6-92b3-4699-9a72-e55714608901", "D", "LK_Adventure_NodeTitle_53", 0)
		};
		List<AdventureEndNode> endNodes13 = new List<AdventureEndNode>
		{
			new AdventureEndNode("b0e39b4f-7676-4616-a940-98b387ae77fd", "E", "LK_Adventure_NodeTitle_54", 0)
		};
		List<AdventureBaseBranch> baseBranches13 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 6, "", new int[2] { 14, 100 }, new int[9] { 1, 7, 21, 100, 10, 35, 35, 10, 10 }, new int[5] { 100, 5, 10, 100, 100 }, new string[7] { "0", "0", "1", "731fa228-ed0d-45ae-a18d-d58ecbf203f4", "10", "0", "0" }, new int[14]
			{
				0, 3, 8, 25, 5, 8, 50, 3, 8, 75,
				2, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 1, 6, "", new int[2] { 14, 100 }, new int[9] { 1, 7, 21, 100, 10, 35, 35, 10, 10 }, new int[5] { 100, 5, 10, 100, 100 }, new string[7] { "0", "0", "1", "8157aa1d-bacd-4edc-85be-ebde3d0c0d9e", "10", "0", "0" }, new int[14]
			{
				0, 3, 8, 25, 5, 8, 50, 3, 8, 75,
				2, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 3, "3", 1, 6, "", new int[2] { 14, 100 }, new int[9] { 1, 7, 21, 100, 10, 35, 35, 10, 10 }, new int[5] { 100, 5, 10, 100, 100 }, new string[7] { "0", "0", "1", "7805b7c5-69dd-4b8b-9d96-7dbc49877b5e", "10", "0", "0" }, new int[14]
			{
				0, 3, 8, 25, 5, 8, 50, 3, 8, 75,
				2, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 4, "4", 1, 6, "", new int[2] { 14, 100 }, new int[9] { 1, 7, 21, 100, 10, 35, 10, 10, 35 }, new int[5] { 100, 5, 100, 100, 10 }, new string[5] { "0", "0", "0", "0", "0" }, new int[14]
			{
				0, 3, 8, 25, 5, 8, 50, 3, 8, 75,
				2, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray17.Add(new AdventureItem(16, config33, config34, 2, 1, 1, 0, 3, 6, resCost17, itemCost16, restrictedByWorldPopulation: false, malice16, adventureParams14, "2e3dbcfa-da7d-4039-b592-19cb82d0f2a3", startNodes14, transferNodes13, endNodes13, baseBranches13, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray18 = _dataArray;
		string config35 = LocalStringManager.GetConfig("Adventure_language", "Name_17");
		string config36 = LocalStringManager.GetConfig("Adventure_language", "Desc_17");
		int[] resCost18 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost17 = list;
		short[] malice17 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams15 = list2;
		List<AdventureStartNode> startNodes15 = new List<AdventureStartNode>
		{
			new AdventureStartNode("187679c7-9740-4d74-ba00-0d144eb436cf", "A", "LK_Adventure_NodeTitle_55", 15)
		};
		list3 = new List<AdventureTransferNode>();
		List<AdventureTransferNode> transferNodes14 = list3;
		List<AdventureEndNode> endNodes14 = new List<AdventureEndNode>
		{
			new AdventureEndNode("26168bcf-dd62-457a-87db-2764449aae43", "C", "LK_Adventure_NodeTitle_56", 15)
		};
		List<AdventureBaseBranch> baseBranches14 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 5, "", new int[6] { 4, 30, 15, 30, 12, 30 }, new int[4] { 1, 2, 15, 100 }, new int[5] { 40, 40, 40, 40, 40 }, new string[15]
			{
				"1", "ad4139e5-4cf5-4734-b2d7-bf5f85983908", "30", "1", "ad4139e5-4cf5-4734-b2d7-bf5f85983908", "30", "1", "ad4139e5-4cf5-4734-b2d7-bf5f85983908", "30", "1",
				"ad4139e5-4cf5-4734-b2d7-bf5f85983908", "30", "1", "ad4139e5-4cf5-4734-b2d7-bf5f85983908", "30"
			}, new int[50]
			{
				3, 8, 200, 15, 8, 300, 9, 8, 400, 6,
				3, 8, 200, 15, 8, 300, 9, 8, 400, 6,
				3, 8, 200, 15, 8, 300, 9, 8, 400, 6,
				3, 8, 200, 15, 8, 300, 9, 8, 400, 6,
				3, 8, 200, 15, 8, 300, 9, 8, 400, 6
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray18.Add(new AdventureItem(17, config35, config36, 2, 1, 1, 2, 3, -1, resCost18, itemCost17, restrictedByWorldPopulation: false, malice17, adventureParams15, "86886176-d87e-48dd-bf9b-0d63f049fec1", startNodes15, transferNodes14, endNodes14, baseBranches14, advancedBranches, difficultyAddXiangshuLevel: true));
		List<AdventureItem> dataArray19 = _dataArray;
		string config37 = LocalStringManager.GetConfig("Adventure_language", "Name_18");
		string config38 = LocalStringManager.GetConfig("Adventure_language", "Desc_18");
		int[] resCost19 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost18 = list;
		short[] malice18 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams16 = list2;
		List<AdventureStartNode> startNodes16 = new List<AdventureStartNode>
		{
			new AdventureStartNode("2560d993-0570-4ce4-9dff-41a89a77172a", "A", "LK_Adventure_NodeTitle_57", 0)
		};
		List<AdventureTransferNode> transferNodes15 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("1bac8f06-2e56-4e1e-bde9-56e3c61dd215", "B", "LK_Adventure_NodeTitle_58", 0),
			new AdventureTransferNode("ee8c94d3-d589-437b-8552-258e5e721246", "C", "LK_Adventure_NodeTitle_59", 0),
			new AdventureTransferNode("cfc97164-8a5b-44eb-aac8-9ee883c1c956", "D", "LK_Adventure_NodeTitle_60", 0)
		};
		List<AdventureEndNode> endNodes15 = new List<AdventureEndNode>
		{
			new AdventureEndNode("1fd6285d-d13b-429e-a148-8d0c5dc26e3e", "E", "LK_Adventure_NodeTitle_61", 0)
		};
		List<AdventureBaseBranch> baseBranches15 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 6, "736a5233-6d04-4a45-b7ea-5ba2093880cc", new int[6] { 13, 30, 12, 30, 2, 30 }, new int[13]
			{
				4, 2, 3, 25, 2, 16, 25, 2, 22, 25,
				2, 21, 25
			}, new int[5] { 10, 10, 10, 10, 10 }, new string[5] { "0", "0", "0", "0", "0" }, new int[23]
			{
				0, 3, 8, 200, 5, 8, 300, 3, 8, 400,
				2, 0, 3, 7, 40, 5, 7, 60, 3, 7,
				80, 2, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 1, 6, "9e945a78-abb9-46e3-afe6-e8d1fae7a0f4", new int[6] { 13, 30, 12, 30, 2, 30 }, new int[13]
			{
				4, 2, 3, 25, 2, 16, 25, 2, 22, 25,
				2, 21, 25
			}, new int[5] { 10, 10, 10, 10, 10 }, new string[5] { "0", "0", "0", "0", "0" }, new int[23]
			{
				0, 3, 8, 300, 5, 8, 450, 3, 8, 600,
				2, 0, 3, 7, 60, 5, 7, 90, 3, 7,
				120, 2, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 3, "3", 1, 4, "", new int[6] { 13, 30, 12, 30, 2, 30 }, new int[13]
			{
				4, 2, 3, 25, 2, 16, 25, 2, 22, 25,
				2, 21, 25
			}, new int[5] { 10, 10, 10, 10, 10 }, new string[15]
			{
				"1", "5c675877-f2ae-4f35-8adf-8b5f9a2166d7", "5", "1", "5c675877-f2ae-4f35-8adf-8b5f9a2166d7", "5", "1", "5c675877-f2ae-4f35-8adf-8b5f9a2166d7", "5", "1",
				"5c675877-f2ae-4f35-8adf-8b5f9a2166d7", "5", "1", "5c675877-f2ae-4f35-8adf-8b5f9a2166d7", "5"
			}, new int[23]
			{
				0, 3, 8, 500, 5, 8, 700, 3, 8, 1000,
				2, 0, 3, 7, 100, 5, 7, 150, 3, 7,
				200, 2, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 4, "4", 1, 4, "", new int[6] { 13, 30, 12, 30, 2, 30 }, new int[13]
			{
				4, 2, 3, 25, 2, 16, 25, 2, 22, 25,
				2, 21, 25
			}, new int[5] { 10, 10, 10, 10, 10 }, new string[15]
			{
				"1", "5af7152d-98e4-4ba4-ad7c-86330bf025f1", "10", "1", "5af7152d-98e4-4ba4-ad7c-86330bf025f1", "10", "1", "5af7152d-98e4-4ba4-ad7c-86330bf025f1", "10", "1",
				"5af7152d-98e4-4ba4-ad7c-86330bf025f1", "10", "1", "5af7152d-98e4-4ba4-ad7c-86330bf025f1", "10"
			}, new int[23]
			{
				0, 3, 8, 800, 5, 8, 1200, 3, 8, 1600,
				2, 0, 3, 7, 160, 5, 7, 240, 3, 7,
				320, 2, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray19.Add(new AdventureItem(18, config37, config38, 2, 1, 1, 0, 6, 12, resCost19, itemCost18, restrictedByWorldPopulation: false, malice18, adventureParams16, "66e1d5dd-818a-464c-b415-a4ab34f53191", startNodes16, transferNodes15, endNodes15, baseBranches15, advancedBranches, difficultyAddXiangshuLevel: true));
		List<AdventureItem> dataArray20 = _dataArray;
		string config39 = LocalStringManager.GetConfig("Adventure_language", "Name_19");
		string config40 = LocalStringManager.GetConfig("Adventure_language", "Desc_19");
		int[] resCost20 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost19 = list;
		short[] malice19 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams17 = list2;
		List<AdventureStartNode> startNodes17 = new List<AdventureStartNode>
		{
			new AdventureStartNode("892f9c63-b7d1-47c5-b15a-bb9dd73aa92c", "A", "LK_Adventure_NodeTitle_62", 16)
		};
		List<AdventureTransferNode> transferNodes16 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("9e919d3c-88c7-42ed-aa23-303071c15b05", "B", "LK_Adventure_NodeTitle_63", 22)
		};
		List<AdventureEndNode> endNodes16 = new List<AdventureEndNode>
		{
			new AdventureEndNode("b99c9296-7f51-4529-b645-9979afb2d364", "C", "LK_Adventure_NodeTitle_64", 3)
		};
		List<AdventureBaseBranch> baseBranches16 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 5, "", new int[4] { 12, 50, 13, 50 }, new int[13]
			{
				4, 2, 16, 25, 2, 20, 25, 2, 3, 25,
				2, 21, 25
			}, new int[5] { 100, 5, 100, 3, 4 }, new string[7] { "0", "0", "0", "1", "a434df8c-8a6c-4a0a-84df-ed0e6c854c6a", "5", "0" }, new int[14]
			{
				0, 3, 8, 200, 5, 8, 300, 3, 8, 400,
				2, 0, 0, 0
			}, new int[21]
			{
				0, 0, 0, 0, 4, 1, -101, 1, 2, 1,
				-102, 1, 2, 1, -103, 1, 2, 1, -104, 1,
				2
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 1, 10, "", new int[4] { 12, 50, 13, 50 }, new int[13]
			{
				4, 2, 3, 50, 2, 18, 10, 2, 21, 20,
				2, 22, 20
			}, new int[5] { 100, 5, 100, 3, 4 }, new string[7] { "0", "0", "0", "1", "a434df8c-8a6c-4a0a-84df-ed0e6c854c6a", "5", "0" }, new int[14]
			{
				0, 3, 8, 200, 5, 8, 300, 3, 8, 400,
				2, 0, 0, 0
			}, new int[21]
			{
				0, 0, 0, 0, 4, 1, -101, 1, 2, 1,
				-102, 1, 2, 1, -103, 1, 2, 1, -104, 1,
				2
			}, new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray20.Add(new AdventureItem(19, config39, config40, 2, 1, 1, 2, 10, -1, resCost20, itemCost19, restrictedByWorldPopulation: false, malice19, adventureParams17, "50ce38af-1aa6-4a51-a85b-87ff0ecd28cd", startNodes17, transferNodes16, endNodes16, baseBranches16, advancedBranches, difficultyAddXiangshuLevel: true));
		List<AdventureItem> dataArray21 = _dataArray;
		string config41 = LocalStringManager.GetConfig("Adventure_language", "Name_20");
		string config42 = LocalStringManager.GetConfig("Adventure_language", "Desc_20");
		int[] resCost21 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost20 = list;
		short[] malice20 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams18 = list2;
		List<AdventureStartNode> startNodes18 = new List<AdventureStartNode>
		{
			new AdventureStartNode("08a63ce7-7b75-44fb-8e0f-80f9f4281aa3", "A", "LK_Adventure_NodeTitle_65", 15)
		};
		List<AdventureTransferNode> transferNodes17 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("ee0e6219-ab3c-4a67-8148-7413f7820c04", "B", "LK_Adventure_NodeTitle_66", 1),
			new AdventureTransferNode("8a1ef3d9-78b2-4976-8481-8d68a5be07e4", "C", "LK_Adventure_NodeTitle_67", 19)
		};
		List<AdventureEndNode> endNodes17 = new List<AdventureEndNode>
		{
			new AdventureEndNode("06524a9c-6a52-41ad-af96-ceb85ca98dbe", "D", "LK_Adventure_NodeTitle_68", 19)
		};
		List<AdventureBaseBranch> baseBranches17 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 8, "", new int[6] { 4, 25, 12, 25, 15, 25 }, new int[4] { 1, 2, 15, 100 }, new int[5] { 60, 60, 60, 60, 60 }, new string[45]
			{
				"4", "5c6874c4-d8bf-4335-a24f-66dcca59cbe1", "5", "d9897297-c162-4d42-860d-2b23dc7f7d35", "5", "7b00a67f-6223-4623-89be-b71bfdb291d4", "5", "aecaa8e4-6d2a-4971-a1f2-fe1853df0de8", "5", "4",
				"5c6874c4-d8bf-4335-a24f-66dcca59cbe1", "5", "d9897297-c162-4d42-860d-2b23dc7f7d35", "5", "7b00a67f-6223-4623-89be-b71bfdb291d4", "5", "aecaa8e4-6d2a-4971-a1f2-fe1853df0de8", "5", "4", "5c6874c4-d8bf-4335-a24f-66dcca59cbe1",
				"5", "d9897297-c162-4d42-860d-2b23dc7f7d35", "5", "7b00a67f-6223-4623-89be-b71bfdb291d4", "5", "aecaa8e4-6d2a-4971-a1f2-fe1853df0de8", "5", "4", "5c6874c4-d8bf-4335-a24f-66dcca59cbe1", "5",
				"d9897297-c162-4d42-860d-2b23dc7f7d35", "5", "7b00a67f-6223-4623-89be-b71bfdb291d4", "5", "aecaa8e4-6d2a-4971-a1f2-fe1853df0de8", "5", "4", "5c6874c4-d8bf-4335-a24f-66dcca59cbe1", "5", "d9897297-c162-4d42-860d-2b23dc7f7d35",
				"5", "7b00a67f-6223-4623-89be-b71bfdb291d4", "5", "aecaa8e4-6d2a-4971-a1f2-fe1853df0de8", "5"
			}, new int[41]
			{
				3, 8, 200, 10, 0, 300, 6, 0, 400, 4,
				0, 3, 8, 200, 10, 8, 300, 6, 8, 400,
				4, 3, 8, 200, 10, 8, 300, 6, 8, 400,
				4, 3, 7, 40, 10, 7, 60, 6, 7, 80,
				4
			}, new int[9] { 0, 1, 9, -901, 1, 20, 0, 0, 0 }, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 1, 5, "", new int[6] { 4, 25, 12, 25, 15, 25 }, new int[4] { 1, 2, 1, 100 }, new int[5] { 40, 60, 40, 40, 40 }, new string[35]
			{
				"3", "b1914d01-2e69-456b-9df2-99899db0a83e", "10", "ded80f17-85cc-4fe9-b62e-075424b1a998", "10", "8645a858-bea3-4e77-8873-3cb297c33831", "10", "3", "b1914d01-2e69-456b-9df2-99899db0a83e", "10",
				"ded80f17-85cc-4fe9-b62e-075424b1a998", "10", "8645a858-bea3-4e77-8873-3cb297c33831", "10", "3", "b1914d01-2e69-456b-9df2-99899db0a83e", "10", "ded80f17-85cc-4fe9-b62e-075424b1a998", "10", "8645a858-bea3-4e77-8873-3cb297c33831",
				"10", "3", "b1914d01-2e69-456b-9df2-99899db0a83e", "10", "ded80f17-85cc-4fe9-b62e-075424b1a998", "10", "8645a858-bea3-4e77-8873-3cb297c33831", "10", "3", "b1914d01-2e69-456b-9df2-99899db0a83e",
				"10", "ded80f17-85cc-4fe9-b62e-075424b1a998", "10", "8645a858-bea3-4e77-8873-3cb297c33831", "10"
			}, new int[41]
			{
				3, 8, 300, 15, 8, 450, 9, 8, 600, 6,
				0, 3, 8, 300, 15, 0, 450, 9, 0, 600,
				6, 3, 8, 300, 15, 8, 450, 9, 8, 300,
				6, 3, 7, 60, 15, 7, 90, 9, 7, 120,
				6
			}, new int[9] { 0, 1, 9, -901, 1, 10, 0, 0, 0 }, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 3, "3", 1, 5, "", new int[6] { 4, 25, 12, 25, 15, 25 }, new int[4] { 1, 2, 19, 100 }, new int[5] { 40, 40, 40, 40, 40 }, new string[35]
			{
				"3", "455b0bb2-779a-482b-a3ff-1839c26533be", "10", "7b1a7141-737c-4e45-a82a-3c99168478e7", "10", "03a4e970-416b-4f46-91ef-5990eed40eb6", "10", "3", "455b0bb2-779a-482b-a3ff-1839c26533be", "10",
				"7b1a7141-737c-4e45-a82a-3c99168478e7", "10", "03a4e970-416b-4f46-91ef-5990eed40eb6", "10", "3", "455b0bb2-779a-482b-a3ff-1839c26533be", "10", "7b1a7141-737c-4e45-a82a-3c99168478e7", "10", "03a4e970-416b-4f46-91ef-5990eed40eb6",
				"10", "3", "455b0bb2-779a-482b-a3ff-1839c26533be", "10", "7b1a7141-737c-4e45-a82a-3c99168478e7", "10", "03a4e970-416b-4f46-91ef-5990eed40eb6", "10", "3", "455b0bb2-779a-482b-a3ff-1839c26533be",
				"10", "7b1a7141-737c-4e45-a82a-3c99168478e7", "10", "03a4e970-416b-4f46-91ef-5990eed40eb6", "10"
			}, new int[41]
			{
				3, 8, 500, 15, 8, 750, 9, 8, 1000, 6,
				0, 3, 8, 500, 15, 8, 750, 9, 8, 1000,
				6, 3, 8, 500, 15, 8, 750, 9, 8, 1000,
				6, 3, 7, 100, 15, 7, 150, 9, 7, 200,
				6
			}, new int[9] { 0, 1, 9, -901, 1, 30, 0, 0, 0 }, new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray21.Add(new AdventureItem(20, config41, config42, 2, 1, 1, 0, 10, 12, resCost21, itemCost20, restrictedByWorldPopulation: false, malice20, adventureParams18, "6bc86278-a379-4514-b48f-aa76d9912e10", startNodes18, transferNodes17, endNodes17, baseBranches17, advancedBranches, difficultyAddXiangshuLevel: true));
		List<AdventureItem> dataArray22 = _dataArray;
		string config43 = LocalStringManager.GetConfig("Adventure_language", "Name_21");
		string config44 = LocalStringManager.GetConfig("Adventure_language", "Desc_21");
		int[] resCost22 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost21 = list;
		short[] malice21 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams19 = list2;
		List<AdventureStartNode> startNodes19 = new List<AdventureStartNode>
		{
			new AdventureStartNode("f54016da-6211-45fb-8ed8-44c4eff43253", "A", "LK_Adventure_NodeTitle_69", 0)
		};
		list3 = new List<AdventureTransferNode>();
		dataArray22.Add(new AdventureItem(21, config43, config44, 2, 1, 1, 2, 3, 6, resCost22, itemCost21, restrictedByWorldPopulation: false, malice21, adventureParams19, "a7cc54da-bb05-4d3e-b5fa-abfc2163f727", startNodes19, list3, new List<AdventureEndNode>
		{
			new AdventureEndNode("d19979f7-b462-4505-8626-08a0a3522bce", "D", "LK_Adventure_NodeTitle_70", 0)
		}, new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 10, "", new int[8] { 0, 25, 1, 25, 2, 25, 3, 25 }, new int[17]
			{
				2, 7, 1, 50, 15, 15, 10, 50, 10, 7,
				2, 50, 15, 15, 10, 50, 10
			}, new int[5] { 25, 5, 100, 15, 100 }, new string[7] { "0", "0", "0", "1", "da609e55-ee5b-40a7-a0cb-9967879daa69", "20", "0" }, new int[68]
			{
				15, 0, 80, 5, 0, 120, 3, 0, 160, 2,
				1, 80, 5, 1, 120, 3, 1, 160, 2, 2,
				80, 5, 2, 120, 3, 2, 160, 2, 3, 80,
				5, 3, 120, 3, 3, 160, 2, 4, 80, 5,
				4, 120, 3, 4, 160, 2, 3, 8, 300, 5,
				8, 450, 3, 8, 600, 2, 0, 3, 7, 60,
				5, 7, 90, 3, 7, 120, 2, 0
			}, new int[9] { 0, 0, 0, 1, 10, -1001, 1, 2, 0 }, new string[5] { "0", "0", "0", "0", "0" })
		}, new List<AdventureAdvancedBranch>
		{
			new AdventureAdvancedBranch(3, "", 0, 2, 100, new int[8] { 0, 25, 1, 25, 2, 25, 3, 25 }, new int[4] { 1, 2, 5, 100 }, new int[5] { 100, 50, 100, 100, 100 }, new string[5] { "0", "0", "0", "0", "0" }, new int[5], new int[9] { 0, 1, 10, -1001, 1, 50, 0, 0, 0 }, new string[5] { "0", "0", "0", "0", "0" })
		}, difficultyAddXiangshuLevel: true));
		List<AdventureItem> dataArray23 = _dataArray;
		string config45 = LocalStringManager.GetConfig("Adventure_language", "Name_22");
		string config46 = LocalStringManager.GetConfig("Adventure_language", "Desc_22");
		int[] resCost23 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost22 = list;
		short[] malice22 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams20 = list2;
		List<AdventureStartNode> startNodes20 = new List<AdventureStartNode>
		{
			new AdventureStartNode("028b815f-a0c9-454e-a444-fa60b34c27f5", "A", "LK_Adventure_NodeTitle_71", 1)
		};
		List<AdventureTransferNode> transferNodes18 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("f5ac3255-8a1d-4d69-8a94-291929dd6cf1", "B", "LK_Adventure_NodeTitle_72", 1),
			new AdventureTransferNode("38e0e61c-d1d6-413a-b3b2-88e5f6a95673", "C", "LK_Adventure_NodeTitle_73", 1)
		};
		List<AdventureEndNode> endNodes18 = new List<AdventureEndNode>
		{
			new AdventureEndNode("6ddd4a9e-ff82-4a51-b15d-e136c0a85d18", "D", "LK_Adventure_NodeTitle_74", 1)
		};
		List<AdventureBaseBranch> baseBranches18 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 6, "63fdabc1-c2e4-4cf5-aa2d-d9634c53a8dc", new int[6] { 6, 25, 7, 25, 10, 25 }, new int[4] { 1, 2, 1, 100 }, new int[5] { 60, 60, 60, 60, 60 }, new string[5] { "0", "0", "0", "0", "0" }, new int[23]
			{
				0, 0, 3, 8, 200, 20, 8, 300, 12, 8,
				400, 8, 3, 8, 200, 20, 8, 300, 12, 8,
				400, 8, 0
			}, new int[17]
			{
				1, 5, -503, 1, 40, 1, 5, -504, 1, 40,
				0, 0, 1, 5, -505, 1, 40
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 1, 6, "bdd92391-75a8-44a2-9643-a2e0b99f7e52", new int[6] { 6, 25, 7, 25, 10, 25 }, new int[4] { 1, 2, 1, 100 }, new int[5] { 60, 60, 60, 60, 60 }, new string[5] { "0", "0", "0", "0", "0" }, new int[23]
			{
				0, 0, 3, 8, 200, 20, 8, 300, 12, 8,
				400, 8, 3, 8, 200, 20, 8, 300, 12, 8,
				400, 8, 0
			}, new int[17]
			{
				1, 5, -503, 1, 40, 1, 5, -504, 1, 40,
				0, 0, 1, 5, -505, 1, 40
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 3, "3", 1, 6, "0cf38cdf-1a90-4217-81d2-456ec642af2d", new int[6] { 6, 25, 7, 25, 10, 25 }, new int[4] { 1, 2, 1, 100 }, new int[5] { 60, 60, 60, 60, 60 }, new string[5] { "0", "0", "0", "0", "0" }, new int[23]
			{
				0, 0, 3, 8, 200, 20, 8, 300, 12, 8,
				400, 8, 3, 8, 200, 20, 8, 300, 12, 8,
				400, 8, 0
			}, new int[17]
			{
				1, 5, -503, 1, 40, 1, 5, -504, 1, 40,
				0, 0, 1, 5, -505, 1, 40
			}, new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray23.Add(new AdventureItem(22, config45, config46, 2, 1, 1, 0, 15, 9, resCost23, itemCost22, restrictedByWorldPopulation: false, malice22, adventureParams20, "e81e38ea-47e5-490b-895c-8ef6690225a3", startNodes20, transferNodes18, endNodes18, baseBranches18, advancedBranches, difficultyAddXiangshuLevel: true));
		List<AdventureItem> dataArray24 = _dataArray;
		string config47 = LocalStringManager.GetConfig("Adventure_language", "Name_23");
		string config48 = LocalStringManager.GetConfig("Adventure_language", "Desc_23");
		int[] resCost24 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost23 = list;
		short[] malice23 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams21 = list2;
		List<AdventureStartNode> startNodes21 = new List<AdventureStartNode>
		{
			new AdventureStartNode("2f2f90d8-b0e2-4531-a9c0-140185bd9c9b", "A", "LK_Adventure_NodeTitle_75", 9)
		};
		List<AdventureTransferNode> transferNodes19 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("40237f93-f119-445e-a959-e7604ccdb346", "B", "LK_Adventure_NodeTitle_76", 9)
		};
		List<AdventureEndNode> endNodes19 = new List<AdventureEndNode>
		{
			new AdventureEndNode("0abc4738-d772-4892-b227-dc760d025f2d", "C", "LK_Adventure_NodeTitle_77", 9)
		};
		List<AdventureBaseBranch> baseBranches19 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 0, 6, "79973089-03d1-40e1-92bf-392611c27789", new int[6] { 6, 25, 7, 25, 10, 25 }, new int[4] { 1, 2, 9, 100 }, new int[5] { 60, 60, 60, 60, 60 }, new string[5] { "0", "0", "0", "0", "0" }, new int[23]
			{
				0, 0, 3, 8, 200, 20, 8, 300, 12, 8,
				400, 8, 3, 8, 200, 20, 8, 300, 12, 8,
				400, 8, 0
			}, new int[17]
			{
				1, 5, -503, 1, 40, 1, 5, -504, 1, 40,
				0, 0, 1, 5, -505, 1, 40
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 1, 6, "310a4c91-25ad-4b33-aba3-6fbf2aebc774", new int[6] { 6, 25, 7, 25, 0, 25 }, new int[4] { 1, 2, 9, 100 }, new int[5] { 60, 60, 60, 60, 60 }, new string[5] { "0", "0", "0", "0", "0" }, new int[23]
			{
				0, 0, 3, 8, 200, 20, 8, 300, 12, 8,
				400, 8, 3, 8, 200, 20, 8, 300, 12, 8,
				400, 8, 0
			}, new int[17]
			{
				1, 5, -503, 1, 40, 1, 5, -504, 1, 40,
				0, 0, 1, 5, -505, 1, 40
			}, new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray24.Add(new AdventureItem(23, config47, config48, 2, 1, 1, 0, 3, -1, resCost24, itemCost23, restrictedByWorldPopulation: false, malice23, adventureParams21, "7e432304-2526-4ac9-b0f8-59bc67daba2a", startNodes21, transferNodes19, endNodes19, baseBranches19, advancedBranches, difficultyAddXiangshuLevel: true));
		List<AdventureItem> dataArray25 = _dataArray;
		string config49 = LocalStringManager.GetConfig("Adventure_language", "Name_24");
		string config50 = LocalStringManager.GetConfig("Adventure_language", "Desc_24");
		int[] resCost25 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost24 = list;
		short[] malice24 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams22 = list2;
		List<AdventureStartNode> startNodes22 = new List<AdventureStartNode>
		{
			new AdventureStartNode("0d9a549b-972e-4137-8edf-b266fe016cf6", "A", "LK_Adventure_NodeTitle_78", 0)
		};
		List<AdventureTransferNode> transferNodes20 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("31beef7e-8913-4f6d-a069-f730d28170a6", "B", "LK_Adventure_NodeTitle_79", 0)
		};
		List<AdventureEndNode> endNodes20 = new List<AdventureEndNode>
		{
			new AdventureEndNode("d5f6bbc8-1969-4293-8437-f60aa30b7a48", "C", "LK_Adventure_NodeTitle_80", 0)
		};
		List<AdventureBaseBranch> baseBranches20 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 10, "", new int[2] { 9, 100 }, new int[19]
			{
				6, 2, 1, 10, 2, 2, 10, 2, 3, 10,
				2, 5, 10, 2, 6, 10, 2, 10, 50
			}, new int[5] { 100, 5, 100, 100, 6 }, new string[5] { "0", "0", "0", "0", "0" }, new int[23]
			{
				0, 3, 8, 300, 5, 8, 450, 3, 8, 600,
				2, 0, 0, 3, 5, 120, 5, 5, 180, 3,
				5, 240, 2
			}, new int[9] { 0, 0, 0, 0, 1, 5, -506, 1, 2 }, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 1, 10, "", new int[2] { 9, 100 }, new int[19]
			{
				6, 2, 1, 10, 2, 2, 10, 2, 3, 10,
				2, 5, 10, 2, 6, 10, 2, 10, 50
			}, new int[5] { 100, 5, 100, 100, 6 }, new string[5] { "0", "0", "0", "0", "0" }, new int[23]
			{
				0, 3, 8, 300, 5, 8, 450, 3, 8, 600,
				2, 0, 0, 3, 5, 120, 5, 5, 180, 3,
				5, 240, 2
			}, new int[9] { 0, 0, 0, 0, 1, 5, -506, 1, 2 }, new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray25.Add(new AdventureItem(24, config49, config50, 2, 1, 1, 0, 3, 6, resCost25, itemCost24, restrictedByWorldPopulation: false, malice24, adventureParams22, "a125389a-6a9d-4fde-8822-86e8cd8470d7", startNodes22, transferNodes20, endNodes20, baseBranches20, advancedBranches, difficultyAddXiangshuLevel: true));
		List<AdventureItem> dataArray26 = _dataArray;
		string config51 = LocalStringManager.GetConfig("Adventure_language", "Name_25");
		string config52 = LocalStringManager.GetConfig("Adventure_language", "Desc_25");
		int[] resCost26 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost25 = list;
		short[] malice25 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams23 = list2;
		List<AdventureStartNode> startNodes23 = new List<AdventureStartNode>
		{
			new AdventureStartNode("05d61020-8fa0-484e-b745-154c77d0379e", "A", "LK_Adventure_NodeTitle_79", 0)
		};
		list3 = new List<AdventureTransferNode>();
		List<AdventureTransferNode> transferNodes21 = list3;
		List<AdventureEndNode> endNodes21 = new List<AdventureEndNode>
		{
			new AdventureEndNode("b5d3b75e-b97a-4110-8edc-fe4276e5c9b9", "C", "LK_Adventure_NodeTitle_80", 0)
		};
		List<AdventureBaseBranch> baseBranches21 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 10, "", new int[2] { 9, 100 }, new int[19]
			{
				6, 2, 1, 10, 2, 2, 10, 2, 3, 10,
				2, 5, 10, 2, 6, 10, 2, 10, 50
			}, new int[5] { 30, 10, 10, 10, 10 }, new string[13]
			{
				"3", "f1c481f8-a1e7-42c0-ba65-435dcebca503", "5", "4bbf992a-ddd2-4a31-ae90-bcbe0a302348", "5", "e74a50e4-d48c-4dbd-b677-538f86c10ab4", "5", "0", "0", "1",
				"eb40637a-535e-438f-b968-dc3f08c3b0d7", "10", "0"
			}, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray26.Add(new AdventureItem(25, config51, config52, 2, 1, 1, 0, 3, 12, resCost26, itemCost25, restrictedByWorldPopulation: false, malice25, adventureParams23, "5a67eea1-313b-437a-937f-42aa3b92a02e", startNodes23, transferNodes21, endNodes21, baseBranches21, advancedBranches, difficultyAddXiangshuLevel: true));
		List<AdventureItem> dataArray27 = _dataArray;
		string config53 = LocalStringManager.GetConfig("Adventure_language", "Name_26");
		string config54 = LocalStringManager.GetConfig("Adventure_language", "Desc_26");
		int[] resCost27 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost26 = list;
		short[] malice26 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams24 = list2;
		List<AdventureStartNode> startNodes24 = new List<AdventureStartNode>
		{
			new AdventureStartNode("16f05968-051f-4559-a1db-3c4f57c4eba6", "A", "LK_Adventure_NodeTitle_81", 8)
		};
		List<AdventureTransferNode> transferNodes22 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("48b36238-dbb7-4100-9903-86ee624e98d6", "B", "LK_Adventure_NodeTitle_82", 0)
		};
		List<AdventureEndNode> endNodes22 = new List<AdventureEndNode>
		{
			new AdventureEndNode("4046542a-74ad-41cd-a9bc-746b10d00e0a", "C", "LK_Adventure_NodeTitle_83", 0)
		};
		List<AdventureBaseBranch> baseBranches22 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 2, "", new int[2] { 8, 100 }, new int[4] { 1, 2, 8, 100 }, new int[5] { 25, 25, 10, 15, 20 }, new string[5] { "0", "0", "0", "0", "0" }, new int[8] { 0, 0, 0, 0, 1, 5, 320, 5 }, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 1, 2, "", new int[2] { 8, 100 }, new int[4] { 1, 2, 8, 100 }, new int[5] { 25, 25, 10, 15, 20 }, new string[5] { "0", "0", "0", "0", "0" }, new int[8] { 0, 0, 0, 0, 1, 5, 320, 5 }, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray27.Add(new AdventureItem(26, config53, config54, 2, 1, 1, 0, 10, -1, resCost27, itemCost26, restrictedByWorldPopulation: false, malice26, adventureParams24, "b4a82479-3587-49eb-ab2b-52a035a8bcbb", startNodes24, transferNodes22, endNodes22, baseBranches22, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray28 = _dataArray;
		string config55 = LocalStringManager.GetConfig("Adventure_language", "Name_27");
		string config56 = LocalStringManager.GetConfig("Adventure_language", "Desc_27");
		int[] resCost28 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost27 = list;
		short[] malice27 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams25 = list2;
		List<AdventureStartNode> startNodes25 = new List<AdventureStartNode>
		{
			new AdventureStartNode("", "A", "", 17)
		};
		List<AdventureTransferNode> transferNodes23 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("", "B", "", 17),
			new AdventureTransferNode("", "C", "", 17),
			new AdventureTransferNode("", "D", "", 17),
			new AdventureTransferNode("", "E", "", 17),
			new AdventureTransferNode("", "F", "", 17)
		};
		List<AdventureEndNode> endNodes23 = new List<AdventureEndNode>
		{
			new AdventureEndNode("", "G", "", 17)
		};
		List<AdventureBaseBranch> baseBranches23 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 2, 3, "", new int[2] { 8, 100 }, new int[4] { 1, 2, 17, 100 }, new int[5] { 10, 5, 10, 10, 15 }, new string[5] { "0", "0", "0", "0", "0" }, new int[23]
			{
				0, 3, 8, 50, 5, 8, 100, 3, 8, 150,
				2, 0, 0, 3, 5, 20, 5, 5, 40, 3,
				5, 60, 2
			}, new int[13]
			{
				0, 0, 0, 0, 2, 8, -801, 1, 10, 5,
				-506, 1, 10
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 2, 3, "", new int[2] { 8, 100 }, new int[4] { 1, 2, 17, 100 }, new int[5] { 10, 5, 10, 10, 15 }, new string[5] { "0", "0", "0", "0", "0" }, new int[23]
			{
				0, 3, 8, 100, 5, 8, 150, 3, 8, 200,
				2, 0, 0, 3, 5, 40, 5, 5, 60, 3,
				5, 80, 2
			}, new int[13]
			{
				0, 0, 0, 0, 2, 8, -801, 1, 10, 5,
				-506, 1, 10
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 3, "3", 2, 3, "", new int[2] { 8, 100 }, new int[4] { 1, 2, 17, 100 }, new int[5] { 10, 5, 10, 10, 15 }, new string[5] { "0", "0", "0", "0", "0" }, new int[23]
			{
				0, 3, 8, 200, 5, 8, 300, 3, 8, 400,
				2, 0, 0, 3, 5, 80, 5, 5, 120, 3,
				5, 160, 2
			}, new int[13]
			{
				0, 0, 0, 0, 2, 8, -801, 1, 10, 5,
				-506, 1, 10
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 4, "4", 2, 3, "", new int[2] { 8, 100 }, new int[4] { 1, 2, 17, 100 }, new int[5] { 10, 5, 10, 10, 15 }, new string[5] { "0", "0", "0", "0", "0" }, new int[23]
			{
				0, 3, 8, 300, 5, 8, 450, 3, 8, 600,
				2, 0, 0, 3, 5, 120, 5, 5, 180, 3,
				5, 240, 2
			}, new int[13]
			{
				0, 0, 0, 0, 2, 8, -801, 1, 10, 5,
				-506, 1, 10
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(4, 5, "5", 2, 3, "", new int[2] { 8, 100 }, new int[4] { 1, 2, 17, 100 }, new int[5] { 10, 5, 10, 10, 15 }, new string[5] { "0", "0", "0", "0", "0" }, new int[23]
			{
				0, 3, 8, 500, 5, 8, 750, 3, 8, 1000,
				2, 0, 0, 3, 5, 200, 5, 5, 300, 3,
				5, 400, 2
			}, new int[13]
			{
				0, 0, 0, 0, 2, 8, -801, 1, 10, 5,
				-506, 1, 10
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(5, 6, "6", 2, 3, "", new int[2] { 8, 100 }, new int[4] { 1, 2, 17, 100 }, new int[5] { 10, 5, 10, 10, 15 }, new string[5] { "0", "0", "0", "0", "0" }, new int[23]
			{
				0, 3, 8, 800, 5, 8, 1200, 3, 8, 1600,
				2, 0, 0, 3, 5, 320, 5, 5, 480, 3,
				5, 640, 2
			}, new int[13]
			{
				0, 0, 0, 0, 2, 8, -801, 1, 10, 5,
				-506, 1, 10
			}, new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray28.Add(new AdventureItem(27, config55, config56, 2, 1, 1, 0, 6, 9, resCost28, itemCost27, restrictedByWorldPopulation: false, malice27, adventureParams25, null, startNodes25, transferNodes23, endNodes23, baseBranches23, advancedBranches, difficultyAddXiangshuLevel: true));
		List<AdventureItem> dataArray29 = _dataArray;
		string config57 = LocalStringManager.GetConfig("Adventure_language", "Name_28");
		string config58 = LocalStringManager.GetConfig("Adventure_language", "Desc_28");
		int[] resCost29 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost28 = list;
		short[] malice28 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams26 = list2;
		List<AdventureStartNode> startNodes26 = new List<AdventureStartNode>
		{
			new AdventureStartNode("9d0f61e0-14cd-4916-a4f2-c27a76df23b0", "A", "LK_Adventure_NodeTitle_84", 0)
		};
		list3 = new List<AdventureTransferNode>();
		List<AdventureTransferNode> transferNodes24 = list3;
		List<AdventureEndNode> endNodes24 = new List<AdventureEndNode>
		{
			new AdventureEndNode("e1b92d31-f2c8-4862-ae09-ccd0129bc270", "B", "LK_Adventure_NodeTitle_85", 0)
		};
		List<AdventureBaseBranch> baseBranches24 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 5, "", new int[2] { 14, 100 }, new int[33]
			{
				4, 7, 1, 25, 35, 10, 10, 10, 35, 7,
				5, 25, 35, 10, 10, 10, 35, 7, 10, 25,
				35, 10, 10, 10, 35, 7, 12, 25, 35, 10,
				10, 10, 35
			}, new int[5] { 10, 100, 100, 100, 10 }, new string[7] { "0", "0", "0", "0", "1", "b87cdc21-e28a-485d-b411-d1bba19c41e0", "15" }, new int[23]
			{
				6, 0, 10, 5, 0, 20, 3, 0, 30, 2,
				2, 10, 5, 2, 20, 3, 2, 30, 2, 0,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray29.Add(new AdventureItem(28, config57, config58, 2, 1, 1, 0, 3, -1, resCost29, itemCost28, restrictedByWorldPopulation: false, malice28, adventureParams26, "3fbc181d-08a0-43da-bd10-6b4a08c5a947", startNodes26, transferNodes24, endNodes24, baseBranches24, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray30 = _dataArray;
		string config59 = LocalStringManager.GetConfig("Adventure_language", "Name_29");
		string config60 = LocalStringManager.GetConfig("Adventure_language", "Desc_29");
		int[] resCost30 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost29 = list;
		short[] malice29 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams27 = list2;
		List<AdventureStartNode> startNodes27 = new List<AdventureStartNode>
		{
			new AdventureStartNode("a4f121fe-ebbf-4b1b-ab62-f2251b430269", "A", "LK_Adventure_NodeTitle_86", 0)
		};
		List<AdventureTransferNode> transferNodes25 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("f8baad9b-4e0a-4275-91ad-9c66db38ed92", "B", "LK_Adventure_NodeTitle_87", 0),
			new AdventureTransferNode("bfd734a0-911f-4992-a48c-aed41fe90cf5", "C", "LK_Adventure_NodeTitle_87", 0),
			new AdventureTransferNode("f8136617-2762-4ccf-a90e-a9a12aa470df", "D", "LK_Adventure_NodeTitle_87", 0)
		};
		List<AdventureEndNode> endNodes25 = new List<AdventureEndNode>
		{
			new AdventureEndNode("e1c04c56-33d3-4ff3-aea2-6da271895aef", "E", "LK_Adventure_NodeTitle_88", 0)
		};
		List<AdventureBaseBranch> baseBranches25 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 5, "", new int[2] { 0, 100 }, new int[13]
			{
				4, 2, 5, 25, 2, 10, 25, 2, 1, 25,
				2, 21, 25
			}, new int[5] { 5, 5, 100, 100, 100 }, new string[5] { "0", "0", "0", "0", "0" }, new int[14]
			{
				0, 3, 8, 100, 5, 8, 150, 3, 8, 200,
				2, 0, 0, 0
			}, new int[9] { 1, 2, -201, 1, 10, 0, 0, 0, 0 }, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 1, 5, "", new int[2] { 0, 100 }, new int[13]
			{
				4, 2, 5, 25, 2, 10, 25, 2, 1, 25,
				2, 21, 25
			}, new int[5] { 5, 5, 100, 100, 100 }, new string[5] { "0", "0", "0", "0", "0" }, new int[14]
			{
				0, 3, 8, 200, 5, 8, 300, 3, 8, 400,
				2, 0, 0, 0
			}, new int[9] { 1, 2, -201, 1, 10, 0, 0, 0, 0 }, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 3, "3", 1, 5, "", new int[2] { 0, 100 }, new int[13]
			{
				4, 2, 5, 25, 2, 10, 25, 2, 1, 25,
				2, 21, 25
			}, new int[5] { 5, 5, 100, 100, 100 }, new string[5] { "0", "0", "0", "0", "0" }, new int[14]
			{
				0, 3, 8, 300, 5, 8, 450, 3, 8, 600,
				2, 0, 0, 0
			}, new int[9] { 1, 2, -201, 1, 10, 0, 0, 0, 0 }, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 4, "4", 1, 5, "", new int[2] { 0, 100 }, new int[13]
			{
				4, 2, 5, 25, 2, 10, 25, 2, 1, 25,
				2, 21, 25
			}, new int[5] { 5, 5, 100, 100, 100 }, new string[5] { "0", "0", "0", "0", "0" }, new int[14]
			{
				0, 3, 8, 500, 5, 8, 750, 3, 8, 1000,
				2, 0, 0, 0
			}, new int[9] { 1, 2, -201, 1, 10, 0, 0, 0, 0 }, new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray30.Add(new AdventureItem(29, config59, config60, 2, 1, 1, 0, 10, -1, resCost30, itemCost29, restrictedByWorldPopulation: false, malice29, adventureParams27, "506c72e8-cbfc-400c-b0b2-dadc6272f746", startNodes27, transferNodes25, endNodes25, baseBranches25, advancedBranches, difficultyAddXiangshuLevel: true));
		List<AdventureItem> dataArray31 = _dataArray;
		string config61 = LocalStringManager.GetConfig("Adventure_language", "Name_30");
		string config62 = LocalStringManager.GetConfig("Adventure_language", "Desc_30");
		int[] resCost31 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost30 = list;
		short[] malice30 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams28 = list2;
		List<AdventureStartNode> startNodes28 = new List<AdventureStartNode>
		{
			new AdventureStartNode("b3c059b7-2aa1-48d9-8784-fb35ec65066b", "A", "LK_Adventure_NodeTitle_86", 0)
		};
		List<AdventureTransferNode> transferNodes26 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("e937c7a4-0b80-40d2-94dd-9311af386e30", "B", "LK_Adventure_NodeTitle_87", 0),
			new AdventureTransferNode("2f434185-8f0b-4878-bbb3-c1a6878e6a18", "C", "LK_Adventure_NodeTitle_87", 0),
			new AdventureTransferNode("59cfcd5f-0a7e-4902-a12d-45ebaea9a99e", "D", "LK_Adventure_NodeTitle_87", 0)
		};
		List<AdventureEndNode> endNodes26 = new List<AdventureEndNode>
		{
			new AdventureEndNode("86f0eb3e-0dfd-4c7f-a271-2c234e20131d", "E", "LK_Adventure_NodeTitle_88", 0)
		};
		List<AdventureBaseBranch> baseBranches26 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 5, "", new int[2] { 0, 100 }, new int[13]
			{
				4, 2, 5, 25, 2, 10, 25, 2, 1, 25,
				2, 21, 25
			}, new int[5] { 5, 5, 100, 100, 100 }, new string[5] { "0", "0", "0", "0", "0" }, new int[14]
			{
				0, 3, 8, 100, 5, 8, 150, 3, 8, 200,
				2, 0, 0, 0
			}, new int[9] { 1, 2, -201, 1, 10, 0, 0, 0, 0 }, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 1, 5, "", new int[2] { 0, 100 }, new int[13]
			{
				4, 2, 5, 25, 2, 10, 25, 2, 1, 25,
				2, 21, 25
			}, new int[5] { 5, 5, 100, 100, 100 }, new string[5] { "0", "0", "0", "0", "0" }, new int[14]
			{
				0, 3, 8, 200, 5, 8, 300, 3, 8, 400,
				2, 0, 0, 0
			}, new int[9] { 1, 2, -201, 1, 10, 0, 0, 0, 0 }, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 3, "3", 1, 5, "", new int[2] { 0, 100 }, new int[13]
			{
				4, 2, 5, 25, 2, 10, 25, 2, 1, 25,
				2, 21, 25
			}, new int[5] { 5, 5, 100, 100, 100 }, new string[5] { "0", "0", "0", "0", "0" }, new int[14]
			{
				0, 3, 8, 300, 5, 8, 450, 3, 8, 600,
				2, 0, 0, 0
			}, new int[9] { 1, 2, -201, 1, 10, 0, 0, 0, 0 }, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 4, "4", 1, 5, "", new int[2] { 0, 100 }, new int[13]
			{
				4, 2, 5, 25, 2, 10, 25, 2, 1, 25,
				2, 21, 25
			}, new int[5] { 5, 5, 100, 100, 100 }, new string[5] { "0", "0", "0", "0", "0" }, new int[14]
			{
				0, 3, 8, 500, 5, 8, 750, 3, 8, 1000,
				2, 0, 0, 0
			}, new int[9] { 1, 2, -201, 1, 10, 0, 0, 0, 0 }, new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray31.Add(new AdventureItem(30, config61, config62, 2, 1, 1, 0, 10, -1, resCost31, itemCost30, restrictedByWorldPopulation: false, malice30, adventureParams28, "321f1885-dbd8-4bfb-adc8-c0e487c3d214", startNodes28, transferNodes26, endNodes26, baseBranches26, advancedBranches, difficultyAddXiangshuLevel: true));
		List<AdventureItem> dataArray32 = _dataArray;
		string config63 = LocalStringManager.GetConfig("Adventure_language", "Name_31");
		string config64 = LocalStringManager.GetConfig("Adventure_language", "Desc_31");
		int[] resCost32 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost31 = list;
		short[] malice31 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams29 = list2;
		List<AdventureStartNode> startNodes29 = new List<AdventureStartNode>
		{
			new AdventureStartNode("45889980-c31e-4b80-a1dd-2a4be42feaae", "A", "LK_Adventure_NodeTitle_86", 0)
		};
		List<AdventureTransferNode> transferNodes27 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("4079319f-38e8-45c3-a5e6-825426e3e574", "B", "LK_Adventure_NodeTitle_87", 0),
			new AdventureTransferNode("e41fd2e9-139c-4d1f-9199-0d50143bc60a", "C", "LK_Adventure_NodeTitle_87", 0),
			new AdventureTransferNode("f81afbe9-a5bd-4f79-9893-34c1cfbed1f4", "D", "LK_Adventure_NodeTitle_87", 0)
		};
		List<AdventureEndNode> endNodes27 = new List<AdventureEndNode>
		{
			new AdventureEndNode("92d727e2-3d19-456a-a94b-6738c2794207", "E", "LK_Adventure_NodeTitle_88", 0)
		};
		List<AdventureBaseBranch> baseBranches27 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 5, "", new int[2] { 0, 100 }, new int[13]
			{
				4, 2, 5, 25, 2, 10, 25, 2, 1, 25,
				2, 21, 25
			}, new int[5] { 5, 5, 100, 100, 100 }, new string[5] { "0", "0", "0", "0", "0" }, new int[14]
			{
				0, 3, 8, 100, 5, 8, 150, 3, 8, 200,
				2, 0, 0, 0
			}, new int[9] { 1, 2, -201, 1, 10, 0, 0, 0, 0 }, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 1, 5, "", new int[2] { 0, 100 }, new int[13]
			{
				4, 2, 5, 25, 2, 10, 25, 2, 1, 25,
				2, 21, 25
			}, new int[5] { 5, 5, 100, 100, 100 }, new string[5] { "0", "0", "0", "0", "0" }, new int[14]
			{
				0, 3, 8, 200, 5, 8, 300, 3, 8, 400,
				2, 0, 0, 0
			}, new int[9] { 1, 2, -201, 1, 10, 0, 0, 0, 0 }, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 3, "3", 1, 5, "", new int[2] { 0, 100 }, new int[13]
			{
				4, 2, 5, 25, 2, 10, 25, 2, 1, 25,
				2, 21, 25
			}, new int[5] { 5, 5, 100, 100, 100 }, new string[5] { "0", "0", "0", "0", "0" }, new int[14]
			{
				0, 3, 8, 300, 5, 8, 450, 3, 8, 600,
				2, 0, 0, 0
			}, new int[9] { 1, 2, -201, 1, 10, 0, 0, 0, 0 }, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 4, "4", 1, 5, "", new int[2] { 0, 100 }, new int[13]
			{
				4, 2, 5, 25, 2, 10, 25, 2, 1, 25,
				2, 21, 25
			}, new int[5] { 5, 5, 100, 100, 100 }, new string[5] { "0", "0", "0", "0", "0" }, new int[14]
			{
				0, 3, 8, 500, 5, 8, 750, 3, 8, 1000,
				2, 0, 0, 0
			}, new int[9] { 1, 2, -201, 1, 10, 0, 0, 0, 0 }, new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray32.Add(new AdventureItem(31, config63, config64, 2, 1, 1, 0, 10, -1, resCost32, itemCost31, restrictedByWorldPopulation: false, malice31, adventureParams29, "810dc2e8-04f4-4bed-96ce-73e7c1843054", startNodes29, transferNodes27, endNodes27, baseBranches27, advancedBranches, difficultyAddXiangshuLevel: true));
		List<AdventureItem> dataArray33 = _dataArray;
		string config65 = LocalStringManager.GetConfig("Adventure_language", "Name_32");
		string config66 = LocalStringManager.GetConfig("Adventure_language", "Desc_32");
		int[] resCost33 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost32 = list;
		short[] malice32 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams30 = list2;
		List<AdventureStartNode> startNodes30 = new List<AdventureStartNode>
		{
			new AdventureStartNode("a8edb085-4d74-4ca6-983b-463bc0afaeb2", "A", "LK_Adventure_NodeTitle_89", 8),
			new AdventureStartNode("da4dfa1a-a4ac-470b-95e5-7bf9ef273cf3", "B", "LK_Adventure_NodeTitle_89", 8),
			new AdventureStartNode("33a43279-4662-471a-91bb-f8cbd7365f92", "C", "LK_Adventure_NodeTitle_89", 8)
		};
		list3 = new List<AdventureTransferNode>();
		List<AdventureTransferNode> transferNodes28 = list3;
		List<AdventureEndNode> endNodes28 = new List<AdventureEndNode>
		{
			new AdventureEndNode("0f7851ed-d010-4c54-868d-839bc47042b5", "D", "LK_Adventure_NodeTitle_90", 8),
			new AdventureEndNode("f8caf1bf-ef47-4dd3-9bb3-fc47276e33b4", "E", "LK_Adventure_NodeTitle_90", 8),
			new AdventureEndNode("b2bea182-9757-44b8-b514-1c92dbada95a", "F", "LK_Adventure_NodeTitle_90", 8)
		};
		List<AdventureBaseBranch> baseBranches28 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 3, "1", 1, 5, "", new int[2] { 15, 100 }, new int[7] { 2, 2, 8, 50, 2, 10, 50 }, new int[5] { 100, 100, 100, 100, 100 }, new string[5] { "0", "0", "0", "0", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 4, "2", 1, 5, "", new int[2] { 15, 100 }, new int[7] { 2, 2, 8, 50, 2, 10, 50 }, new int[5] { 100, 100, 100, 100, 100 }, new string[5] { "0", "0", "0", "0", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 5, "3", 1, 5, "", new int[2] { 15, 100 }, new int[7] { 2, 2, 8, 50, 2, 10, 50 }, new int[5] { 100, 100, 100, 100, 100 }, new string[5] { "0", "0", "0", "0", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray33.Add(new AdventureItem(32, config65, config66, 2, 1, 1, 0, 3, 6, resCost33, itemCost32, restrictedByWorldPopulation: false, malice32, adventureParams30, "dbd82305-8021-4a73-916b-e1e19b92e08a", startNodes30, transferNodes28, endNodes28, baseBranches28, advancedBranches, difficultyAddXiangshuLevel: true));
		List<AdventureItem> dataArray34 = _dataArray;
		string config67 = LocalStringManager.GetConfig("Adventure_language", "Name_33");
		string config68 = LocalStringManager.GetConfig("Adventure_language", "Desc_33");
		int[] resCost34 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost33 = list;
		short[] malice33 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams31 = list2;
		List<AdventureStartNode> startNodes31 = new List<AdventureStartNode>
		{
			new AdventureStartNode("c6ff00dc-b757-4ace-a293-d01f7baa163b", "A", "LK_Adventure_NodeTitle_91", 0)
		};
		List<AdventureTransferNode> transferNodes29 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("414e9a77-bd9c-4623-b9ea-ef864613472a", "B", "LK_Adventure_NodeTitle_92", 0),
			new AdventureTransferNode("02397d44-5e21-4f47-a608-67dcfeabb54f", "C", "LK_Adventure_NodeTitle_93", 0),
			new AdventureTransferNode("725fe02d-5ac7-42f1-a491-022f14033236", "D", "LK_Adventure_NodeTitle_93", 0),
			new AdventureTransferNode("db1e2d0c-30f2-41f5-9fda-6b650dd13e57", "E", "LK_Adventure_NodeTitle_93", 0),
			new AdventureTransferNode("aedc9270-7bdd-48ff-8158-3bfd4c031d16", "F", "LK_Adventure_NodeTitle_94", 0)
		};
		List<AdventureEndNode> endNodes29 = new List<AdventureEndNode>
		{
			new AdventureEndNode("5ff87ca6-5bc0-4000-ac00-0b786a490828", "G", "LK_Adventure_NodeTitle_95", 0)
		};
		List<AdventureBaseBranch> baseBranches29 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 3, "", new int[10] { 5, 20, 8, 20, 9, 20, 13, 20, 15, 20 }, new int[4] { 1, 2, 20, 100 }, new int[5] { 100, 5, 5, 3, 100 }, new string[5] { "0", "0", "0", "0", "0" }, new int[23]
			{
				0, 3, 8, 25, 5, 8, 50, 3, 8, 75,
				2, 3, 6, 50, 5, 6, 100, 3, 6, 150,
				2, 0, 0
			}, new int[9] { 0, 0, 0, 1, 2, -201, 1, 5, 0 }, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 1, 3, "", new int[10] { 5, 20, 8, 20, 9, 20, 13, 20, 15, 20 }, new int[4] { 1, 2, 20, 100 }, new int[5] { 100, 5, 5, 3, 100 }, new string[5] { "0", "0", "0", "0", "0" }, new int[23]
			{
				0, 3, 8, 25, 5, 8, 50, 3, 8, 75,
				2, 3, 6, 50, 5, 6, 100, 3, 6, 150,
				2, 0, 0
			}, new int[9] { 0, 0, 0, 1, 2, -201, 1, 5, 0 }, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 3, "3", 1, 3, "", new int[10] { 5, 20, 8, 20, 9, 20, 13, 20, 15, 20 }, new int[4] { 1, 2, 20, 100 }, new int[5] { 100, 5, 5, 3, 100 }, new string[5] { "0", "0", "0", "0", "0" }, new int[23]
			{
				0, 3, 8, 25, 5, 8, 50, 3, 8, 75,
				2, 3, 6, 50, 5, 6, 100, 3, 6, 150,
				2, 0, 0
			}, new int[9] { 0, 0, 0, 1, 2, -201, 1, 5, 0 }, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 4, "4", 1, 3, "", new int[10] { 5, 20, 8, 20, 9, 20, 13, 20, 15, 20 }, new int[4] { 1, 2, 20, 100 }, new int[5] { 100, 5, 5, 3, 100 }, new string[5] { "0", "0", "0", "0", "0" }, new int[23]
			{
				0, 3, 8, 25, 5, 8, 50, 3, 8, 75,
				2, 3, 6, 50, 5, 6, 100, 3, 6, 150,
				2, 0, 0
			}, new int[9] { 0, 0, 0, 1, 2, -201, 1, 5, 0 }, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(4, 5, "5", 1, 3, "", new int[10] { 5, 20, 8, 20, 9, 20, 13, 20, 15, 20 }, new int[4] { 1, 2, 20, 100 }, new int[5] { 100, 5, 5, 3, 100 }, new string[5] { "0", "0", "0", "0", "0" }, new int[23]
			{
				0, 3, 8, 25, 5, 8, 50, 3, 8, 75,
				2, 3, 6, 50, 5, 6, 100, 3, 6, 150,
				2, 0, 0
			}, new int[9] { 0, 0, 0, 1, 2, -201, 1, 5, 0 }, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(5, 6, "6", 1, 3, "", new int[10] { 5, 20, 8, 20, 9, 20, 13, 20, 15, 20 }, new int[4] { 1, 2, 20, 100 }, new int[5] { 100, 5, 5, 3, 100 }, new string[5] { "0", "0", "0", "0", "0" }, new int[23]
			{
				0, 3, 8, 25, 5, 8, 50, 3, 8, 75,
				2, 3, 6, 50, 5, 6, 100, 3, 6, 150,
				2, 0, 0
			}, new int[9] { 0, 0, 0, 1, 2, -201, 1, 5, 0 }, new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray34.Add(new AdventureItem(33, config67, config68, 2, 1, 1, 0, 10, -1, resCost34, itemCost33, restrictedByWorldPopulation: false, malice33, adventureParams31, "14a6767f-7cce-41ee-b1b4-d173e7dbba66", startNodes31, transferNodes29, endNodes29, baseBranches29, advancedBranches, difficultyAddXiangshuLevel: true));
		List<AdventureItem> dataArray35 = _dataArray;
		string config69 = LocalStringManager.GetConfig("Adventure_language", "Name_34");
		string config70 = LocalStringManager.GetConfig("Adventure_language", "Desc_34");
		int[] resCost35 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost34 = list;
		short[] malice34 = new short[3];
		list2 = new List<(string, string, string, string)>();
		dataArray35.Add(new AdventureItem(34, config69, config70, 2, 2, 2, 0, 5, -1, resCost35, itemCost34, restrictedByWorldPopulation: false, malice34, list2, "a10f750b-8dcc-4777-b223-e258fd65b2d8", new List<AdventureStartNode>
		{
			new AdventureStartNode("41f1ed3d-8194-40f2-bcca-75cd650dad5e", "A", "LK_Adventure_NodeTitle_96", 16)
		}, new List<AdventureTransferNode>
		{
			new AdventureTransferNode("1198ad70-0f02-4845-9b06-ec1fffe1b678", "B", "LK_Adventure_NodeTitle_97", 16)
		}, new List<AdventureEndNode>
		{
			new AdventureEndNode("935b8aaf-4314-4082-86bf-a3685d3d246e", "C", "LK_Adventure_NodeTitle_98", 14)
		}, new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 5, "", new int[2] { 13, 100 }, new int[17]
			{
				2, 7, 16, 50, 25, 25, 5, 40, 5, 7,
				14, 50, 25, 25, 5, 40, 5
			}, new int[5] { 100, 40, 100, 5, 100 }, new string[13]
			{
				"0", "2", "967e94a4-b8c3-4701-bfb5-5601ab0ec276", "15", "94e78eb2-04ea-4d64-b1f5-da8c811c955f", "5", "0", "2", "94e78eb2-04ea-4d64-b1f5-da8c811c955f", "5",
				"967e94a4-b8c3-4701-bfb5-5601ab0ec276", "5", "0"
			}, new int[14]
			{
				0, 3, 8, 50, 5, 8, 100, 3, 8, 150,
				2, 0, 0, 0
			}, new int[9] { 0, 1, 2, -201, 1, 5, 0, 0, 0 }, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 1, 5, "", new int[2] { 13, 100 }, new int[17]
			{
				2, 7, 16, 50, 5, 25, 5, 60, 5, 7,
				14, 50, 5, 25, 5, 60, 5
			}, new int[5] { 100, 40, 100, 5, 100 }, new string[9] { "0", "1", "967e94a4-b8c3-4701-bfb5-5601ab0ec276", "5", "0", "1", "94e78eb2-04ea-4d64-b1f5-da8c811c955f", "10", "0" }, new int[14]
			{
				0, 3, 8, 50, 5, 8, 100, 3, 8, 150,
				2, 0, 0, 0
			}, new int[9] { 0, 1, 2, -201, 1, 5, 0, 0, 0 }, new string[5] { "0", "0", "0", "0", "0" })
		}, new List<AdventureAdvancedBranch>
		{
			new AdventureAdvancedBranch(3, "", 1, 13, 100, new int[2] { 13, 100 }, new int[9] { 1, 7, 3, 100, 5, 80, 5, 5, 5 }, new int[5] { 100, 0, 100, 100, 100 }, new string[5] { "0", "0", "0", "0", "0" }, new int[5], new int[9] { 0, 1, 2, -201, 1, 100, 0, 0, 0 }, new string[5] { "0", "0", "0", "0", "0" })
		}, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray36 = _dataArray;
		string config71 = LocalStringManager.GetConfig("Adventure_language", "Name_35");
		string config72 = LocalStringManager.GetConfig("Adventure_language", "Desc_35");
		int[] resCost36 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost35 = list;
		short[] malice35 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams32 = list2;
		List<AdventureStartNode> startNodes32 = new List<AdventureStartNode>
		{
			new AdventureStartNode("1a98ae6a-a634-47a4-8877-bb14df01ac20", "A", "LK_Adventure_NodeTitle_41", 8)
		};
		List<AdventureTransferNode> transferNodes30 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("f0a37d4f-e5dd-496b-a75c-01ca21b4db5a", "B", "LK_Adventure_NodeTitle_42", 8),
			new AdventureTransferNode("3992e058-d7c2-4113-b9f0-9212e2fa88d9", "C", "LK_Adventure_NodeTitle_42", 8),
			new AdventureTransferNode("6dc532e9-6701-4ef4-af4e-3d33dc95b1e6", "D", "LK_Adventure_NodeTitle_42", 8),
			new AdventureTransferNode("732fba85-edaf-48d7-8e46-00e1eb2da881", "E", "LK_Adventure_NodeTitle_42", 8),
			new AdventureTransferNode("6e1bd1b7-444b-4e75-9a58-235ab44d4023", "F", "LK_Adventure_NodeTitle_42", 8),
			new AdventureTransferNode("ee220cc0-fc60-484d-8d9a-5b95b381a6cc", "G", "LK_Adventure_NodeTitle_42", 8),
			new AdventureTransferNode("f929b562-af7a-4d74-a46d-c2ea59138fc2", "H", "LK_Adventure_NodeTitle_42", 8),
			new AdventureTransferNode("6c943993-b663-484b-8486-5223f8f22e8c", "I", "LK_Adventure_NodeTitle_42", 8),
			new AdventureTransferNode("f88c61fd-2280-48c7-8809-5429f64f33a9", "J", "LK_Adventure_NodeTitle_42", 8)
		};
		List<AdventureEndNode> endNodes30 = new List<AdventureEndNode>
		{
			new AdventureEndNode("4f5a7253-d0a5-40cd-84ab-040fba25cf71", "K", "LK_Adventure_NodeTitle_43", 8),
			new AdventureEndNode("0eba3600-cbc5-40c6-bfe1-d17512d2d841", "L", "LK_Adventure_NodeTitle_44", 8),
			new AdventureEndNode("36fd5072-204c-4db5-ac9c-1ffb4766fa6e", "M", "LK_Adventure_NodeTitle_43", 8)
		};
		List<AdventureBaseBranch> baseBranches30 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 3, "", new int[2] { 15, 100 }, new int[4] { 1, 2, 8, 100 }, new int[5] { 25, 5, 100, 5, 2 }, new string[5] { "0", "0", "0", "0", "0" }, new int[59]
			{
				15, 0, 10, 5, 0, 20, 3, 0, 30, 2,
				1, 10, 5, 1, 20, 3, 1, 30, 2, 2,
				10, 5, 2, 20, 3, 2, 30, 2, 3, 10,
				5, 3, 20, 3, 3, 30, 2, 4, 10, 5,
				4, 20, 3, 4, 30, 2, 3, 8, 25, 5,
				8, 50, 3, 8, 75, 2, 0, 0, 0
			}, new int[33]
			{
				0, 0, 0, 5, 5, -501, 1, 2, 5, -502,
				1, 2, 5, -503, 1, 2, 5, -504, 1, 2,
				5, -505, 1, 2, 2, 5, -506, 1, 2, 5,
				-507, 1, 2
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 1, 3, "", new int[2] { 15, 100 }, new int[4] { 1, 2, 8, 100 }, new int[5] { 25, 5, 100, 5, 2 }, new string[5] { "0", "0", "0", "0", "0" }, new int[59]
			{
				15, 0, 10, 5, 0, 20, 3, 0, 30, 2,
				1, 10, 5, 1, 20, 3, 1, 30, 2, 2,
				10, 5, 2, 20, 3, 2, 30, 2, 3, 10,
				5, 3, 20, 3, 3, 30, 2, 4, 10, 5,
				4, 20, 3, 4, 30, 2, 3, 8, 25, 5,
				8, 50, 3, 8, 75, 2, 0, 0, 0
			}, new int[33]
			{
				0, 0, 0, 5, 5, -501, 1, 2, 5, -502,
				1, 2, 5, -503, 1, 2, 5, -504, 1, 2,
				5, -505, 1, 2, 2, 5, -506, 1, 2, 5,
				-507, 1, 2
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 3, "3", 1, 3, "", new int[2] { 15, 100 }, new int[4] { 1, 2, 8, 100 }, new int[5] { 25, 5, 100, 5, 2 }, new string[5] { "0", "0", "0", "0", "0" }, new int[59]
			{
				15, 0, 10, 5, 0, 20, 3, 0, 30, 2,
				1, 10, 5, 1, 20, 3, 1, 30, 2, 2,
				10, 5, 2, 20, 3, 2, 30, 2, 3, 10,
				5, 3, 20, 3, 3, 30, 2, 4, 10, 5,
				4, 20, 3, 4, 30, 2, 3, 8, 25, 5,
				8, 50, 3, 8, 75, 2, 0, 0, 0
			}, new int[33]
			{
				0, 0, 0, 5, 5, -501, 1, 2, 5, -502,
				1, 2, 5, -503, 1, 2, 5, -504, 1, 2,
				5, -505, 1, 2, 2, 5, -506, 1, 2, 5,
				-507, 1, 2
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 4, "4", 1, 3, "", new int[2] { 15, 100 }, new int[4] { 1, 2, 8, 100 }, new int[5] { 25, 5, 100, 5, 2 }, new string[5] { "0", "0", "0", "0", "0" }, new int[59]
			{
				15, 0, 10, 5, 0, 20, 3, 0, 30, 2,
				1, 10, 5, 1, 20, 3, 1, 30, 2, 2,
				10, 5, 2, 20, 3, 2, 30, 2, 3, 10,
				5, 3, 20, 3, 3, 30, 2, 4, 10, 5,
				4, 20, 3, 4, 30, 2, 3, 8, 25, 5,
				8, 50, 3, 8, 75, 2, 0, 0, 0
			}, new int[33]
			{
				0, 0, 0, 5, 5, -501, 1, 2, 5, -502,
				1, 2, 5, -503, 1, 2, 5, -504, 1, 2,
				5, -505, 1, 2, 2, 5, -506, 1, 2, 5,
				-507, 1, 2
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 5, "5", 1, 3, "", new int[2] { 15, 100 }, new int[4] { 1, 2, 8, 100 }, new int[5] { 25, 5, 100, 5, 2 }, new string[5] { "0", "0", "0", "0", "0" }, new int[59]
			{
				15, 0, 10, 5, 0, 20, 3, 0, 30, 2,
				1, 10, 5, 1, 20, 3, 1, 30, 2, 2,
				10, 5, 2, 20, 3, 2, 30, 2, 3, 10,
				5, 3, 20, 3, 3, 30, 2, 4, 10, 5,
				4, 20, 3, 4, 30, 2, 3, 8, 25, 5,
				8, 50, 3, 8, 75, 2, 0, 0, 0
			}, new int[33]
			{
				0, 0, 0, 5, 5, -501, 1, 2, 5, -502,
				1, 2, 5, -503, 1, 2, 5, -504, 1, 2,
				5, -505, 1, 2, 2, 5, -506, 1, 2, 5,
				-507, 1, 2
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 6, "6", 1, 3, "", new int[2] { 15, 100 }, new int[4] { 1, 2, 8, 100 }, new int[5] { 25, 5, 100, 5, 2 }, new string[5] { "0", "0", "0", "0", "0" }, new int[59]
			{
				15, 0, 10, 5, 0, 20, 3, 0, 30, 2,
				1, 10, 5, 1, 20, 3, 1, 30, 2, 2,
				10, 5, 2, 20, 3, 2, 30, 2, 3, 10,
				5, 3, 20, 3, 3, 30, 2, 4, 10, 5,
				4, 20, 3, 4, 30, 2, 3, 8, 25, 5,
				8, 50, 3, 8, 75, 2, 0, 0, 0
			}, new int[33]
			{
				0, 0, 0, 5, 5, -501, 1, 2, 5, -502,
				1, 2, 5, -503, 1, 2, 5, -504, 1, 2,
				5, -505, 1, 2, 2, 5, -506, 1, 2, 5,
				-507, 1, 2
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 7, "7", 1, 3, "", new int[2] { 15, 100 }, new int[4] { 1, 2, 8, 100 }, new int[5] { 25, 5, 100, 5, 2 }, new string[5] { "0", "0", "0", "0", "0" }, new int[59]
			{
				15, 0, 10, 5, 0, 20, 3, 0, 30, 2,
				1, 10, 5, 1, 20, 3, 1, 30, 2, 2,
				10, 5, 2, 20, 3, 2, 30, 2, 3, 10,
				5, 3, 20, 3, 3, 30, 2, 4, 10, 5,
				4, 20, 3, 4, 30, 2, 3, 8, 25, 5,
				8, 50, 3, 8, 75, 2, 0, 0, 0
			}, new int[33]
			{
				0, 0, 0, 5, 5, -501, 1, 2, 5, -502,
				1, 2, 5, -503, 1, 2, 5, -504, 1, 2,
				5, -505, 1, 2, 2, 5, -506, 1, 2, 5,
				-507, 1, 2
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 8, "8", 1, 3, "", new int[2] { 15, 100 }, new int[4] { 1, 2, 8, 100 }, new int[5] { 25, 5, 100, 5, 2 }, new string[5] { "0", "0", "0", "0", "0" }, new int[59]
			{
				15, 0, 10, 5, 0, 20, 3, 0, 30, 2,
				1, 10, 5, 1, 20, 3, 1, 30, 2, 2,
				10, 5, 2, 20, 3, 2, 30, 2, 3, 10,
				5, 3, 20, 3, 3, 30, 2, 4, 10, 5,
				4, 20, 3, 4, 30, 2, 3, 8, 25, 5,
				8, 50, 3, 8, 75, 2, 0, 0, 0
			}, new int[33]
			{
				0, 0, 0, 5, 5, -501, 1, 2, 5, -502,
				1, 2, 5, -503, 1, 2, 5, -504, 1, 2,
				5, -505, 1, 2, 2, 5, -506, 1, 2, 5,
				-507, 1, 2
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 9, "9", 1, 3, "", new int[2] { 15, 100 }, new int[4] { 1, 2, 8, 100 }, new int[5] { 25, 5, 100, 5, 2 }, new string[5] { "0", "0", "0", "0", "0" }, new int[59]
			{
				15, 0, 10, 5, 0, 20, 3, 0, 30, 2,
				1, 10, 5, 1, 20, 3, 1, 30, 2, 2,
				10, 5, 2, 20, 3, 2, 30, 2, 3, 10,
				5, 3, 20, 3, 3, 30, 2, 4, 10, 5,
				4, 20, 3, 4, 30, 2, 3, 8, 25, 5,
				8, 50, 3, 8, 75, 2, 0, 0, 0
			}, new int[33]
			{
				0, 0, 0, 5, 5, -501, 1, 2, 5, -502,
				1, 2, 5, -503, 1, 2, 5, -504, 1, 2,
				5, -505, 1, 2, 2, 5, -506, 1, 2, 5,
				-507, 1, 2
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(4, 10, "10", 1, 3, "", new int[2] { 15, 100 }, new int[4] { 1, 2, 8, 100 }, new int[5] { 25, 5, 100, 5, 2 }, new string[5] { "0", "0", "0", "0", "0" }, new int[59]
			{
				15, 0, 10, 5, 0, 20, 3, 0, 30, 2,
				1, 10, 5, 1, 20, 3, 1, 30, 2, 2,
				10, 5, 2, 20, 3, 2, 30, 2, 3, 10,
				5, 3, 20, 3, 3, 30, 2, 4, 10, 5,
				4, 20, 3, 4, 30, 2, 3, 8, 25, 5,
				8, 50, 3, 8, 75, 2, 0, 0, 0
			}, new int[33]
			{
				0, 0, 0, 5, 5, -501, 1, 2, 5, -502,
				1, 2, 5, -503, 1, 2, 5, -504, 1, 2,
				5, -505, 1, 2, 2, 5, -506, 1, 2, 5,
				-507, 1, 2
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(5, 10, "11", 1, 3, "", new int[2] { 15, 100 }, new int[4] { 1, 2, 8, 100 }, new int[5] { 25, 5, 100, 5, 2 }, new string[5] { "0", "0", "0", "0", "0" }, new int[59]
			{
				15, 0, 10, 5, 0, 20, 3, 0, 30, 2,
				1, 10, 5, 1, 20, 3, 1, 30, 2, 2,
				10, 5, 2, 20, 3, 2, 30, 2, 3, 10,
				5, 3, 20, 3, 3, 30, 2, 4, 10, 5,
				4, 20, 3, 4, 30, 2, 3, 8, 25, 5,
				8, 50, 3, 8, 75, 2, 0, 0, 0
			}, new int[33]
			{
				0, 0, 0, 5, 5, -501, 1, 2, 5, -502,
				1, 2, 5, -503, 1, 2, 5, -504, 1, 2,
				5, -505, 1, 2, 2, 5, -506, 1, 2, 5,
				-507, 1, 2
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(6, 11, "12", 1, 3, "", new int[2] { 15, 100 }, new int[4] { 1, 2, 8, 100 }, new int[5] { 25, 5, 100, 5, 2 }, new string[5] { "0", "0", "0", "0", "0" }, new int[59]
			{
				15, 0, 10, 5, 0, 20, 3, 0, 30, 2,
				1, 10, 5, 1, 20, 3, 1, 30, 2, 2,
				10, 5, 2, 20, 3, 2, 30, 2, 3, 10,
				5, 3, 20, 3, 3, 30, 2, 4, 10, 5,
				4, 20, 3, 4, 30, 2, 3, 8, 25, 5,
				8, 50, 3, 8, 75, 2, 0, 0, 0
			}, new int[33]
			{
				0, 0, 0, 5, 5, -501, 1, 2, 5, -502,
				1, 2, 5, -503, 1, 2, 5, -504, 1, 2,
				5, -505, 1, 2, 2, 5, -506, 1, 2, 5,
				-507, 1, 2
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(7, 11, "13", 1, 3, "", new int[2] { 15, 100 }, new int[4] { 1, 2, 8, 100 }, new int[5] { 25, 5, 100, 5, 2 }, new string[5] { "0", "0", "0", "0", "0" }, new int[59]
			{
				15, 0, 10, 5, 0, 20, 3, 0, 30, 2,
				1, 10, 5, 1, 20, 3, 1, 30, 2, 2,
				10, 5, 2, 20, 3, 2, 30, 2, 3, 10,
				5, 3, 20, 3, 3, 30, 2, 4, 10, 5,
				4, 20, 3, 4, 30, 2, 3, 8, 25, 5,
				8, 50, 3, 8, 75, 2, 0, 0, 0
			}, new int[33]
			{
				0, 0, 0, 5, 5, -501, 1, 2, 5, -502,
				1, 2, 5, -503, 1, 2, 5, -504, 1, 2,
				5, -505, 1, 2, 2, 5, -506, 1, 2, 5,
				-507, 1, 2
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(8, 12, "14", 1, 3, "", new int[2] { 15, 100 }, new int[4] { 1, 2, 8, 100 }, new int[5] { 25, 5, 100, 5, 2 }, new string[5] { "0", "0", "0", "0", "0" }, new int[59]
			{
				15, 0, 10, 5, 0, 20, 3, 0, 30, 2,
				1, 10, 5, 1, 20, 3, 1, 30, 2, 2,
				10, 5, 2, 20, 3, 2, 30, 2, 3, 10,
				5, 3, 20, 3, 3, 30, 2, 4, 10, 5,
				4, 20, 3, 4, 30, 2, 3, 8, 25, 5,
				8, 50, 3, 8, 75, 2, 0, 0, 0
			}, new int[33]
			{
				0, 0, 0, 5, 5, -501, 1, 2, 5, -502,
				1, 2, 5, -503, 1, 2, 5, -504, 1, 2,
				5, -505, 1, 2, 2, 5, -506, 1, 2, 5,
				-507, 1, 2
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(9, 12, "15", 1, 3, "", new int[2] { 15, 100 }, new int[4] { 1, 2, 8, 100 }, new int[5] { 25, 5, 100, 5, 2 }, new string[5] { "0", "0", "0", "0", "0" }, new int[59]
			{
				15, 0, 10, 5, 0, 20, 3, 0, 30, 2,
				1, 10, 5, 1, 20, 3, 1, 30, 2, 2,
				10, 5, 2, 20, 3, 2, 30, 2, 3, 10,
				5, 3, 20, 3, 3, 30, 2, 4, 10, 5,
				4, 20, 3, 4, 30, 2, 3, 8, 25, 5,
				8, 50, 3, 8, 75, 2, 0, 0, 0
			}, new int[33]
			{
				0, 0, 0, 5, 5, -501, 1, 2, 5, -502,
				1, 2, 5, -503, 1, 2, 5, -504, 1, 2,
				5, -505, 1, 2, 2, 5, -506, 1, 2, 5,
				-507, 1, 2
			}, new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray36.Add(new AdventureItem(35, config71, config72, 2, 2, 2, 0, 6, 9, resCost36, itemCost35, restrictedByWorldPopulation: false, malice35, adventureParams32, "a493f032-c6e5-4209-b87e-ca7230f45f9d", startNodes32, transferNodes30, endNodes30, baseBranches30, advancedBranches, difficultyAddXiangshuLevel: true));
		List<AdventureItem> dataArray37 = _dataArray;
		string config73 = LocalStringManager.GetConfig("Adventure_language", "Name_36");
		string config74 = LocalStringManager.GetConfig("Adventure_language", "Desc_36");
		int[] resCost37 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost36 = list;
		short[] malice36 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams33 = list2;
		List<AdventureStartNode> startNodes33 = new List<AdventureStartNode>
		{
			new AdventureStartNode("f4b4d3b5-8814-46af-aff0-4bc8ce9d00e9", "A", "LK_Adventure_NodeTitle_99", 1)
		};
		List<AdventureTransferNode> transferNodes31 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("5fda168d-9ee3-4e1b-9ec7-4b508655a462", "B", "LK_Adventure_NodeTitle_100", 1)
		};
		List<AdventureEndNode> endNodes31 = new List<AdventureEndNode>
		{
			new AdventureEndNode("715d8fbd-4d0a-4b3e-9371-78888b45298a", "C", "LK_Adventure_NodeTitle_101", 1)
		};
		List<AdventureBaseBranch> baseBranches31 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 2, "", new int[2] { 15, 100 }, new int[33]
			{
				4, 7, 1, 25, 25, 15, 25, 10, 25, 7,
				11, 25, 25, 15, 25, 10, 25, 7, 5, 25,
				25, 15, 25, 10, 25, 7, 8, 25, 25, 15,
				25, 10, 25
			}, new int[5] { 50, 10, 20, 20, 10 }, new string[5] { "0", "0", "0", "0", "0" }, new int[68]
			{
				15, 0, 20, 5, 0, 40, 3, 0, 60, 2,
				1, 20, 5, 1, 40, 3, 1, 60, 2, 2,
				20, 5, 2, 40, 3, 2, 60, 2, 3, 20,
				5, 3, 40, 3, 3, 60, 2, 4, 20, 5,
				4, 40, 3, 4, 60, 2, 3, 8, 50, 5,
				8, 100, 3, 8, 150, 2, 0, 0, 3, 5,
				20, 5, 5, 40, 3, 5, 60, 2
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 1, 8, "", new int[2] { 15, 100 }, new int[33]
			{
				4, 7, 1, 25, 25, 15, 25, 10, 25, 7,
				10, 25, 25, 15, 25, 10, 25, 7, 5, 25,
				25, 15, 25, 10, 25, 7, 8, 25, 25, 15,
				25, 10, 25
			}, new int[5] { 100, 10, 10, 20, 20 }, new string[11]
			{
				"1", "76e131c5-c7cd-4d17-ba61-30413b495580", "50", "0", "1", "1643e425-665b-497d-9119-bcec345fcfd0", "20", "0", "1", "82c1ea7f-387e-4ef9-8141-3a3ae7d1a7c8",
				"10"
			}, new int[68]
			{
				15, 0, 20, 5, 0, 40, 3, 0, 60, 2,
				1, 20, 5, 1, 40, 3, 1, 60, 2, 2,
				20, 5, 2, 40, 3, 2, 60, 2, 3, 20,
				5, 3, 40, 3, 3, 60, 2, 4, 20, 5,
				4, 40, 3, 4, 60, 2, 3, 8, 50, 5,
				8, 100, 3, 8, 150, 2, 0, 0, 3, 5,
				20, 5, 5, 40, 3, 5, 60, 2
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray37.Add(new AdventureItem(36, config73, config74, 2, 2, 2, 0, 10, -1, resCost37, itemCost36, restrictedByWorldPopulation: false, malice36, adventureParams33, "f34d0bc5-72b5-4955-bb61-9a5c8c64df61", startNodes33, transferNodes31, endNodes31, baseBranches31, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray38 = _dataArray;
		string config75 = LocalStringManager.GetConfig("Adventure_language", "Name_37");
		string config76 = LocalStringManager.GetConfig("Adventure_language", "Desc_37");
		int[] resCost38 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost37 = list;
		short[] malice37 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams34 = list2;
		List<AdventureStartNode> startNodes34 = new List<AdventureStartNode>
		{
			new AdventureStartNode("2d7506d3-d1b4-4c40-a4d0-d7bd90ddf647", "A", "LK_Adventure_NodeTitle_102", 1)
		};
		List<AdventureTransferNode> transferNodes32 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("88e16658-794d-4e63-9988-e50a75d4c2aa", "B", "LK_Adventure_NodeTitle_103", 1)
		};
		List<AdventureEndNode> endNodes32 = new List<AdventureEndNode>
		{
			new AdventureEndNode("b7bccda0-e5c0-43dc-a1dd-7eb27d600e1c", "C", "LK_Adventure_NodeTitle_104", 1)
		};
		List<AdventureBaseBranch> baseBranches32 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 2, "", new int[2] { 15, 100 }, new int[33]
			{
				4, 7, 1, 25, 25, 15, 25, 25, 10, 7,
				10, 25, 25, 15, 25, 25, 10, 7, 5, 25,
				25, 15, 25, 25, 10, 7, 8, 25, 25, 15,
				25, 25, 10
			}, new int[5] { 50, 10, 20, 20, 10 }, new string[5] { "0", "0", "0", "0", "0" }, new int[68]
			{
				15, 0, 20, 5, 0, 40, 3, 0, 60, 2,
				1, 20, 5, 1, 40, 3, 1, 60, 2, 2,
				20, 5, 2, 40, 3, 2, 60, 2, 3, 20,
				5, 3, 40, 3, 3, 60, 2, 4, 20, 5,
				4, 40, 3, 4, 60, 2, 3, 8, 50, 5,
				8, 100, 3, 8, 150, 2, 0, 0, 3, 5,
				20, 5, 5, 40, 3, 5, 60, 2
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 1, 8, "", new int[2] { 15, 100 }, new int[33]
			{
				4, 7, 1, 25, 25, 15, 25, 25, 10, 7,
				10, 25, 25, 15, 25, 25, 10, 7, 5, 25,
				25, 15, 25, 25, 10, 7, 8, 25, 25, 15,
				25, 25, 10
			}, new int[5] { 100, 10, 20, 20, 0 }, new string[11]
			{
				"1", "2c723c4c-c99d-4133-8233-f186634521ea", "50", "0", "1", "1e928845-5f9f-404c-aea9-7cd12b0feb75", "20", "1", "7ad773b3-0c60-4547-938e-37901772f626", "20",
				"0"
			}, new int[68]
			{
				15, 0, 20, 5, 0, 40, 3, 0, 60, 2,
				1, 20, 5, 1, 40, 3, 1, 60, 2, 2,
				20, 5, 2, 40, 3, 2, 60, 2, 3, 20,
				5, 3, 40, 3, 3, 60, 2, 4, 20, 5,
				4, 40, 3, 4, 60, 2, 3, 8, 50, 5,
				8, 100, 3, 8, 150, 2, 0, 0, 3, 5,
				20, 5, 5, 40, 3, 5, 60, 2
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray38.Add(new AdventureItem(37, config75, config76, 2, 2, 2, 0, 10, -1, resCost38, itemCost37, restrictedByWorldPopulation: false, malice37, adventureParams34, "e78bb104-b3f4-480b-a043-00b6d90c3862", startNodes34, transferNodes32, endNodes32, baseBranches32, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray39 = _dataArray;
		string config77 = LocalStringManager.GetConfig("Adventure_language", "Name_38");
		string config78 = LocalStringManager.GetConfig("Adventure_language", "Desc_38");
		int[] resCost39 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost38 = list;
		short[] malice38 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams35 = list2;
		List<AdventureStartNode> startNodes35 = new List<AdventureStartNode>
		{
			new AdventureStartNode("2e2d30f8-d374-47a0-8c36-7f9b2af4d1a5", "A", "LK_Adventure_NodeTitle_41", 8)
		};
		List<AdventureTransferNode> transferNodes33 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("56df73e7-7eac-4e85-aa60-a35bf35a9115", "B", "LK_Adventure_NodeTitle_42", 8),
			new AdventureTransferNode("e49bb8f8-aa6d-4ae5-98f5-49e808377640", "C", "LK_Adventure_NodeTitle_42", 8),
			new AdventureTransferNode("ab7bec7b-35f8-49be-9a05-8758df21b830", "D", "LK_Adventure_NodeTitle_42", 8),
			new AdventureTransferNode("869c959d-104c-43b3-abf5-ab56421372a3", "E", "LK_Adventure_NodeTitle_42", 8),
			new AdventureTransferNode("4604563d-213a-4c76-add8-21d385369da3", "F", "LK_Adventure_NodeTitle_42", 8),
			new AdventureTransferNode("fcf78752-0a8f-41d0-b05e-d1906dbe6de3", "G", "LK_Adventure_NodeTitle_42", 8),
			new AdventureTransferNode("71de75aa-a4ca-4fc5-8ed4-f495be89b0a5", "H", "LK_Adventure_NodeTitle_42", 8),
			new AdventureTransferNode("f153fd09-93e0-44d8-b9d4-b6777fd4b405", "I", "LK_Adventure_NodeTitle_42", 8),
			new AdventureTransferNode("dc5a02c4-82bb-4c9d-9a93-5775eb89991f", "J", "LK_Adventure_NodeTitle_42", 8)
		};
		List<AdventureEndNode> endNodes33 = new List<AdventureEndNode>
		{
			new AdventureEndNode("906dd0f2-7bf1-4622-971c-d006bf71093b", "K", "LK_Adventure_NodeTitle_43", 8),
			new AdventureEndNode("ed1bb017-c804-47fe-9c32-533c942864b0", "L", "LK_Adventure_NodeTitle_44", 8),
			new AdventureEndNode("124a428a-8a4d-45cf-8936-a3690be20259", "M", "LK_Adventure_NodeTitle_43", 8)
		};
		List<AdventureBaseBranch> baseBranches33 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 3, "", new int[2] { 15, 100 }, new int[4] { 1, 2, 8, 100 }, new int[5] { 25, 5, 100, 5, 2 }, new string[5] { "0", "0", "0", "0", "0" }, new int[59]
			{
				15, 0, 10, 5, 0, 20, 3, 0, 30, 2,
				1, 10, 5, 1, 20, 3, 1, 30, 2, 2,
				10, 5, 2, 20, 3, 2, 30, 2, 3, 10,
				5, 3, 20, 3, 3, 30, 2, 4, 10, 5,
				4, 20, 3, 4, 30, 2, 3, 8, 25, 5,
				8, 50, 3, 8, 75, 2, 0, 0, 0
			}, new int[33]
			{
				0, 0, 0, 5, 5, -501, 1, 2, 5, -502,
				1, 2, 5, -503, 1, 2, 5, -504, 1, 2,
				5, -505, 1, 2, 2, 5, -506, 1, 2, 5,
				-507, 1, 2
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 1, 3, "", new int[2] { 15, 100 }, new int[4] { 1, 2, 8, 100 }, new int[5] { 25, 5, 100, 5, 2 }, new string[5] { "0", "0", "0", "0", "0" }, new int[59]
			{
				15, 0, 10, 5, 0, 20, 3, 0, 30, 2,
				1, 10, 5, 1, 20, 3, 1, 30, 2, 2,
				10, 5, 2, 20, 3, 2, 30, 2, 3, 10,
				5, 3, 20, 3, 3, 30, 2, 4, 10, 5,
				4, 20, 3, 4, 30, 2, 3, 8, 25, 5,
				8, 50, 3, 8, 75, 2, 0, 0, 0
			}, new int[33]
			{
				0, 0, 0, 5, 5, -501, 1, 2, 5, -502,
				1, 2, 5, -503, 1, 2, 5, -504, 1, 2,
				5, -505, 1, 2, 2, 5, -506, 1, 2, 5,
				-507, 1, 2
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 3, "3", 1, 3, "", new int[2] { 15, 100 }, new int[4] { 1, 2, 8, 100 }, new int[5] { 25, 5, 100, 5, 2 }, new string[5] { "0", "0", "0", "0", "0" }, new int[59]
			{
				15, 0, 10, 5, 0, 20, 3, 0, 30, 2,
				1, 10, 5, 1, 20, 3, 1, 30, 2, 2,
				10, 5, 2, 20, 3, 2, 30, 2, 3, 10,
				5, 3, 20, 3, 3, 30, 2, 4, 10, 5,
				4, 20, 3, 4, 30, 2, 3, 8, 25, 5,
				8, 50, 3, 8, 75, 2, 0, 0, 0
			}, new int[33]
			{
				0, 0, 0, 5, 5, -501, 1, 2, 5, -502,
				1, 2, 5, -503, 1, 2, 5, -504, 1, 2,
				5, -505, 1, 2, 2, 5, -506, 1, 2, 5,
				-507, 1, 2
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 7, "7", 1, 3, "", new int[2] { 15, 100 }, new int[4] { 1, 2, 8, 100 }, new int[5] { 25, 5, 100, 5, 2 }, new string[5] { "0", "0", "0", "0", "0" }, new int[59]
			{
				15, 0, 10, 5, 0, 20, 3, 0, 30, 2,
				1, 10, 5, 1, 20, 3, 1, 30, 2, 2,
				10, 5, 2, 20, 3, 2, 30, 2, 3, 10,
				5, 3, 20, 3, 3, 30, 2, 4, 10, 5,
				4, 20, 3, 4, 30, 2, 3, 8, 25, 5,
				8, 50, 3, 8, 75, 2, 0, 0, 0
			}, new int[33]
			{
				0, 0, 0, 5, 5, -501, 1, 2, 5, -502,
				1, 2, 5, -503, 1, 2, 5, -504, 1, 2,
				5, -505, 1, 2, 2, 5, -506, 1, 2, 5,
				-507, 1, 2
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 8, "8", 1, 3, "", new int[2] { 15, 100 }, new int[4] { 1, 2, 8, 100 }, new int[5] { 25, 5, 100, 5, 2 }, new string[5] { "0", "0", "0", "0", "0" }, new int[59]
			{
				15, 0, 10, 5, 0, 20, 3, 0, 30, 2,
				1, 10, 5, 1, 20, 3, 1, 30, 2, 2,
				10, 5, 2, 20, 3, 2, 30, 2, 3, 10,
				5, 3, 20, 3, 3, 30, 2, 4, 10, 5,
				4, 20, 3, 4, 30, 2, 3, 8, 25, 5,
				8, 50, 3, 8, 75, 2, 0, 0, 0
			}, new int[33]
			{
				0, 0, 0, 5, 5, -501, 1, 2, 5, -502,
				1, 2, 5, -503, 1, 2, 5, -504, 1, 2,
				5, -505, 1, 2, 2, 5, -506, 1, 2, 5,
				-507, 1, 2
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 9, "9", 1, 3, "", new int[2] { 15, 100 }, new int[4] { 1, 2, 8, 100 }, new int[5] { 25, 5, 100, 5, 2 }, new string[5] { "0", "0", "0", "0", "0" }, new int[59]
			{
				15, 0, 10, 5, 0, 20, 3, 0, 30, 2,
				1, 10, 5, 1, 20, 3, 1, 30, 2, 2,
				10, 5, 2, 20, 3, 2, 30, 2, 3, 10,
				5, 3, 20, 3, 3, 30, 2, 4, 10, 5,
				4, 20, 3, 4, 30, 2, 3, 8, 25, 5,
				8, 50, 3, 8, 75, 2, 0, 0, 0
			}, new int[33]
			{
				0, 0, 0, 5, 5, -501, 1, 2, 5, -502,
				1, 2, 5, -503, 1, 2, 5, -504, 1, 2,
				5, -505, 1, 2, 2, 5, -506, 1, 2, 5,
				-507, 1, 2
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 4, "4", 1, 3, "", new int[2] { 15, 100 }, new int[4] { 1, 2, 8, 100 }, new int[5] { 25, 5, 100, 5, 2 }, new string[5] { "0", "0", "0", "0", "0" }, new int[59]
			{
				15, 0, 10, 5, 0, 20, 3, 0, 30, 2,
				1, 10, 5, 1, 20, 3, 1, 30, 2, 2,
				10, 5, 2, 20, 3, 2, 30, 2, 3, 10,
				5, 3, 20, 3, 3, 30, 2, 4, 10, 5,
				4, 20, 3, 4, 30, 2, 3, 8, 25, 5,
				8, 50, 3, 8, 75, 2, 0, 0, 0
			}, new int[33]
			{
				0, 0, 0, 5, 5, -501, 1, 2, 5, -502,
				1, 2, 5, -503, 1, 2, 5, -504, 1, 2,
				5, -505, 1, 2, 2, 5, -506, 1, 2, 5,
				-507, 1, 2
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 5, "5", 1, 3, "", new int[2] { 15, 100 }, new int[4] { 1, 2, 8, 100 }, new int[5] { 25, 5, 100, 5, 2 }, new string[5] { "0", "0", "0", "0", "0" }, new int[59]
			{
				15, 0, 10, 5, 0, 20, 3, 0, 30, 2,
				1, 10, 5, 1, 20, 3, 1, 30, 2, 2,
				10, 5, 2, 20, 3, 2, 30, 2, 3, 10,
				5, 3, 20, 3, 3, 30, 2, 4, 10, 5,
				4, 20, 3, 4, 30, 2, 3, 8, 25, 5,
				8, 50, 3, 8, 75, 2, 0, 0, 0
			}, new int[33]
			{
				0, 0, 0, 5, 5, -501, 1, 2, 5, -502,
				1, 2, 5, -503, 1, 2, 5, -504, 1, 2,
				5, -505, 1, 2, 2, 5, -506, 1, 2, 5,
				-507, 1, 2
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 6, "6", 1, 3, "", new int[2] { 15, 100 }, new int[4] { 1, 2, 8, 100 }, new int[5] { 25, 5, 100, 5, 2 }, new string[5] { "0", "0", "0", "0", "0" }, new int[59]
			{
				15, 0, 10, 5, 0, 20, 3, 0, 30, 2,
				1, 10, 5, 1, 20, 3, 1, 30, 2, 2,
				10, 5, 2, 20, 3, 2, 30, 2, 3, 10,
				5, 3, 20, 3, 3, 30, 2, 4, 10, 5,
				4, 20, 3, 4, 30, 2, 3, 8, 25, 5,
				8, 50, 3, 8, 75, 2, 0, 0, 0
			}, new int[33]
			{
				0, 0, 0, 5, 5, -501, 1, 2, 5, -502,
				1, 2, 5, -503, 1, 2, 5, -504, 1, 2,
				5, -505, 1, 2, 2, 5, -506, 1, 2, 5,
				-507, 1, 2
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(4, 10, "10", 1, 3, "", new int[2] { 15, 100 }, new int[4] { 1, 2, 8, 100 }, new int[5] { 25, 5, 100, 5, 2 }, new string[5] { "0", "0", "0", "0", "0" }, new int[59]
			{
				15, 0, 10, 5, 0, 20, 3, 0, 30, 2,
				1, 10, 5, 1, 20, 3, 1, 30, 2, 2,
				10, 5, 2, 20, 3, 2, 30, 2, 3, 10,
				5, 3, 20, 3, 3, 30, 2, 4, 10, 5,
				4, 20, 3, 4, 30, 2, 3, 8, 25, 5,
				8, 50, 3, 8, 75, 2, 0, 0, 0
			}, new int[33]
			{
				0, 0, 0, 5, 5, -501, 1, 2, 5, -502,
				1, 2, 5, -503, 1, 2, 5, -504, 1, 2,
				5, -505, 1, 2, 2, 5, -506, 1, 2, 5,
				-507, 1, 2
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(5, 10, "11", 1, 3, "", new int[2] { 15, 100 }, new int[4] { 1, 2, 8, 100 }, new int[5] { 25, 5, 100, 5, 2 }, new string[5] { "0", "0", "0", "0", "0" }, new int[59]
			{
				15, 0, 10, 5, 0, 20, 3, 0, 30, 2,
				1, 10, 5, 1, 20, 3, 1, 30, 2, 2,
				10, 5, 2, 20, 3, 2, 30, 2, 3, 10,
				5, 3, 20, 3, 3, 30, 2, 4, 10, 5,
				4, 20, 3, 4, 30, 2, 3, 8, 25, 5,
				8, 50, 3, 8, 75, 2, 0, 0, 0
			}, new int[33]
			{
				0, 0, 0, 5, 5, -501, 1, 2, 5, -502,
				1, 2, 5, -503, 1, 2, 5, -504, 1, 2,
				5, -505, 1, 2, 2, 5, -506, 1, 2, 5,
				-507, 1, 2
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(6, 11, "12", 1, 3, "", new int[2] { 15, 100 }, new int[4] { 1, 2, 8, 100 }, new int[5] { 25, 5, 100, 5, 2 }, new string[5] { "0", "0", "0", "0", "0" }, new int[59]
			{
				15, 0, 10, 5, 0, 20, 3, 0, 30, 2,
				1, 10, 5, 1, 20, 3, 1, 30, 2, 2,
				10, 5, 2, 20, 3, 2, 30, 2, 3, 10,
				5, 3, 20, 3, 3, 30, 2, 4, 10, 5,
				4, 20, 3, 4, 30, 2, 3, 8, 25, 5,
				8, 50, 3, 8, 75, 2, 0, 0, 0
			}, new int[33]
			{
				0, 0, 0, 5, 5, -501, 1, 2, 5, -502,
				1, 2, 5, -503, 1, 2, 5, -504, 1, 2,
				5, -505, 1, 2, 2, 5, -506, 1, 2, 5,
				-507, 1, 2
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(7, 11, "13", 1, 3, "", new int[2] { 15, 100 }, new int[4] { 1, 2, 8, 100 }, new int[5] { 25, 5, 100, 5, 2 }, new string[5] { "0", "0", "0", "0", "0" }, new int[59]
			{
				15, 0, 10, 5, 0, 20, 3, 0, 30, 2,
				1, 10, 5, 1, 20, 3, 1, 30, 2, 2,
				10, 5, 2, 20, 3, 2, 30, 2, 3, 10,
				5, 3, 20, 3, 3, 30, 2, 4, 10, 5,
				4, 20, 3, 4, 30, 2, 3, 8, 25, 5,
				8, 50, 3, 8, 75, 2, 0, 0, 0
			}, new int[33]
			{
				0, 0, 0, 5, 5, -501, 1, 2, 5, -502,
				1, 2, 5, -503, 1, 2, 5, -504, 1, 2,
				5, -505, 1, 2, 2, 5, -506, 1, 2, 5,
				-507, 1, 2
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(8, 12, "14", 1, 3, "", new int[2] { 15, 100 }, new int[4] { 1, 2, 8, 100 }, new int[5] { 25, 5, 100, 5, 2 }, new string[5] { "0", "0", "0", "0", "0" }, new int[59]
			{
				15, 0, 10, 5, 0, 20, 3, 0, 30, 2,
				1, 10, 5, 1, 20, 3, 1, 30, 2, 2,
				10, 5, 2, 20, 3, 2, 30, 2, 3, 10,
				5, 3, 20, 3, 3, 30, 2, 4, 10, 5,
				4, 20, 3, 4, 30, 2, 3, 8, 25, 5,
				8, 50, 3, 8, 75, 2, 0, 0, 0
			}, new int[33]
			{
				0, 0, 0, 5, 5, -501, 1, 2, 5, -502,
				1, 2, 5, -503, 1, 2, 5, -504, 1, 2,
				5, -505, 1, 2, 2, 5, -506, 1, 2, 5,
				-507, 1, 2
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(9, 12, "15", 1, 3, "", new int[2] { 15, 100 }, new int[4] { 1, 2, 8, 100 }, new int[5] { 25, 5, 100, 5, 2 }, new string[5] { "0", "0", "0", "0", "0" }, new int[59]
			{
				15, 0, 10, 5, 0, 20, 3, 0, 30, 2,
				1, 10, 5, 1, 20, 3, 1, 30, 2, 2,
				10, 5, 2, 20, 3, 2, 30, 2, 3, 10,
				5, 3, 20, 3, 3, 30, 2, 4, 10, 5,
				4, 20, 3, 4, 30, 2, 3, 8, 25, 5,
				8, 50, 3, 8, 75, 2, 0, 0, 0
			}, new int[33]
			{
				0, 0, 0, 5, 5, -501, 1, 2, 5, -502,
				1, 2, 5, -503, 1, 2, 5, -504, 1, 2,
				5, -505, 1, 2, 2, 5, -506, 1, 2, 5,
				-507, 1, 2
			}, new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray39.Add(new AdventureItem(38, config77, config78, 2, 3, 3, 0, 6, 9, resCost39, itemCost38, restrictedByWorldPopulation: false, malice38, adventureParams35, "6f597837-f46c-469e-a2c2-890eed2eb1e1", startNodes35, transferNodes33, endNodes33, baseBranches33, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray40 = _dataArray;
		string config79 = LocalStringManager.GetConfig("Adventure_language", "Name_39");
		string config80 = LocalStringManager.GetConfig("Adventure_language", "Desc_39");
		int[] resCost40 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost39 = list;
		short[] malice39 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams36 = list2;
		List<AdventureStartNode> startNodes36 = new List<AdventureStartNode>
		{
			new AdventureStartNode("82c32917-70bd-4c5c-ab5e-51d6d5cbccbe", "A", "LK_Adventure_NodeTitle_105", 21)
		};
		List<AdventureTransferNode> transferNodes34 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("8a97170f-4eed-481f-883a-a6b797fba873", "B", "LK_Adventure_NodeTitle_106", 21)
		};
		List<AdventureEndNode> endNodes34 = new List<AdventureEndNode>
		{
			new AdventureEndNode("5e4f032f-31e6-45ab-964b-48f6a9744683", "C", "LK_Adventure_NodeTitle_107", 21)
		};
		List<AdventureBaseBranch> baseBranches34 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 3, "", new int[2] { 0, 100 }, new int[10] { 3, 2, 21, 50, 2, 16, 25, 2, 3, 25 }, new int[5] { 100, 6, 100, 100, 100 }, new string[5] { "0", "0", "0", "0", "0" }, new int[14]
			{
				0, 3, 8, 100, 5, 8, 150, 3, 8, 200,
				2, 0, 0, 0
			}, new int[9] { 0, 1, 2, -201, 1, 2, 0, 0, 0 }, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 1, 5, "", new int[2] { 0, 100 }, new int[10] { 3, 2, 21, 50, 2, 16, 25, 2, 3, 25 }, new int[5] { 100, 6, 100, 100, 100 }, new string[5] { "0", "0", "0", "0", "0" }, new int[14]
			{
				0, 3, 8, 100, 5, 8, 150, 3, 8, 200,
				2, 0, 0, 0
			}, new int[9] { 0, 1, 2, -201, 1, 2, 0, 0, 0 }, new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray40.Add(new AdventureItem(39, config79, config80, 2, 3, 3, 0, 10, -1, resCost40, itemCost39, restrictedByWorldPopulation: false, malice39, adventureParams36, "fef3cf3f-9f0d-4c70-b90f-4afb7953d735", startNodes36, transferNodes34, endNodes34, baseBranches34, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray41 = _dataArray;
		string config81 = LocalStringManager.GetConfig("Adventure_language", "Name_40");
		string config82 = LocalStringManager.GetConfig("Adventure_language", "Desc_40");
		int[] resCost41 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost40 = list;
		short[] malice40 = new short[3];
		list2 = new List<(string, string, string, string)>();
		dataArray41.Add(new AdventureItem(40, config81, config82, 2, 3, 3, 0, 0, -1, resCost41, itemCost40, restrictedByWorldPopulation: false, malice40, list2, "e984d570-dc39-46ae-8561-9e7352e3a15e", new List<AdventureStartNode>
		{
			new AdventureStartNode("52e95d54-31ab-4107-9a1f-ed33a9720eae", "A", "LK_Adventure_NodeTitle_108", 0)
		}, new List<AdventureTransferNode>
		{
			new AdventureTransferNode("ac5e622a-378a-4304-8287-921f1b4bc25f", "B", "LK_Adventure_NodeTitle_109", 0),
			new AdventureTransferNode("061b18c1-b401-4739-b0dd-8e6847d1460a", "C", "LK_Adventure_NodeTitle_110", 0),
			new AdventureTransferNode("febc912e-bb11-4741-b8c9-d64d56508777", "D", "LK_Adventure_NodeTitle_111", 0),
			new AdventureTransferNode("0bf54c0c-3a5a-4c04-af81-837234414d6c", "E", "LK_Adventure_NodeTitle_112", 0),
			new AdventureTransferNode("44475bf0-dac6-4893-ab70-9f2b251a768f", "F", "LK_Adventure_NodeTitle_113", 0),
			new AdventureTransferNode("07167d84-0d34-4624-bc82-96cfc18703ae", "G", "LK_Adventure_NodeTitle_114", 0)
		}, new List<AdventureEndNode>
		{
			new AdventureEndNode("be3a79db-c4bb-49a5-a3ef-333c3c109d39", "H", "LK_Adventure_NodeTitle_115", 0)
		}, new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 5, "", new int[32]
			{
				0, 1, 1, 1, 2, 1, 3, 1, 4, 1,
				5, 1, 6, 1, 7, 1, 8, 1, 9, 1,
				10, 1, 11, 1, 12, 1, 13, 1, 14, 1,
				15, 1
			}, new int[4] { 1, 2, 1, 100 }, new int[5] { 25, 5, 5, 100, 5 }, new string[5] { "0", "0", "0", "0", "0" }, new int[77]
			{
				15, 0, 40, 5, 0, 60, 3, 0, 80, 2,
				1, 40, 5, 1, 60, 3, 1, 80, 2, 2,
				40, 5, 2, 60, 3, 2, 80, 2, 3, 40,
				5, 3, 60, 3, 3, 80, 2, 4, 40, 5,
				4, 60, 3, 4, 80, 2, 3, 8, 100, 5,
				8, 150, 3, 8, 200, 2, 3, 6, 200, 5,
				6, 300, 3, 6, 400, 2, 0, 3, 5, 40,
				5, 5, 60, 3, 5, 80, 2
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 1, 5, "", new int[32]
			{
				0, 1, 1, 1, 2, 1, 3, 1, 4, 1,
				5, 1, 6, 1, 7, 1, 8, 1, 9, 1,
				10, 1, 11, 1, 12, 1, 13, 1, 14, 1,
				15, 1
			}, new int[4] { 1, 2, 3, 100 }, new int[5] { 25, 5, 5, 100, 5 }, new string[5] { "0", "0", "0", "0", "0" }, new int[77]
			{
				15, 0, 40, 5, 0, 60, 3, 0, 80, 2,
				1, 40, 5, 1, 60, 3, 1, 80, 2, 2,
				40, 5, 2, 60, 3, 2, 80, 2, 3, 40,
				5, 3, 60, 3, 3, 80, 2, 4, 40, 5,
				4, 60, 3, 4, 80, 2, 3, 8, 100, 5,
				8, 150, 3, 8, 200, 2, 3, 6, 200, 5,
				6, 300, 3, 6, 400, 2, 0, 3, 5, 40,
				5, 5, 60, 3, 5, 80, 2
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 3, "3", 1, 5, "", new int[32]
			{
				0, 1, 1, 1, 2, 1, 3, 1, 4, 1,
				5, 1, 6, 1, 7, 1, 8, 1, 9, 1,
				10, 1, 11, 1, 12, 1, 13, 1, 14, 1,
				15, 1
			}, new int[4] { 1, 2, 10, 100 }, new int[5] { 25, 5, 5, 100, 5 }, new string[5] { "0", "0", "0", "0", "0" }, new int[77]
			{
				15, 0, 40, 5, 0, 60, 3, 0, 80, 2,
				1, 40, 5, 1, 60, 3, 1, 80, 2, 2,
				40, 5, 2, 60, 3, 2, 80, 2, 3, 40,
				5, 3, 60, 3, 3, 80, 2, 4, 40, 5,
				4, 60, 3, 4, 80, 2, 3, 8, 100, 5,
				8, 150, 3, 8, 200, 2, 3, 6, 200, 5,
				6, 300, 3, 6, 400, 2, 0, 3, 5, 40,
				5, 5, 60, 3, 5, 80, 2
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 4, "4", 1, 5, "", new int[32]
			{
				0, 1, 1, 1, 2, 1, 3, 1, 4, 1,
				5, 1, 6, 1, 7, 1, 8, 1, 9, 1,
				10, 1, 11, 1, 12, 1, 13, 1, 14, 1,
				15, 1
			}, new int[4] { 1, 2, 22, 100 }, new int[5] { 25, 5, 5, 100, 5 }, new string[5] { "0", "0", "0", "0", "0" }, new int[77]
			{
				15, 0, 40, 5, 0, 60, 3, 0, 80, 2,
				1, 40, 5, 1, 60, 3, 1, 80, 2, 2,
				40, 5, 2, 60, 3, 2, 80, 2, 3, 40,
				5, 3, 60, 3, 3, 80, 2, 4, 40, 5,
				4, 60, 3, 4, 80, 2, 3, 8, 100, 5,
				8, 150, 3, 8, 200, 2, 3, 6, 200, 5,
				6, 300, 3, 6, 400, 2, 0, 3, 5, 40,
				5, 5, 60, 3, 5, 80, 2
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(4, 5, "5", 1, 5, "", new int[32]
			{
				0, 1, 1, 1, 2, 1, 3, 1, 4, 1,
				5, 1, 6, 1, 7, 1, 8, 1, 9, 1,
				10, 1, 11, 1, 12, 1, 13, 1, 14, 1,
				15, 1
			}, new int[4] { 1, 2, 10, 100 }, new int[5] { 25, 5, 5, 100, 5 }, new string[5] { "0", "0", "0", "0", "0" }, new int[77]
			{
				15, 0, 40, 5, 0, 60, 3, 0, 80, 2,
				1, 40, 5, 1, 60, 3, 1, 80, 2, 2,
				40, 5, 2, 60, 3, 2, 80, 2, 3, 40,
				5, 3, 60, 3, 3, 80, 2, 4, 40, 5,
				4, 60, 3, 4, 80, 2, 3, 8, 100, 5,
				8, 150, 3, 8, 200, 2, 3, 6, 200, 5,
				6, 300, 3, 6, 400, 2, 0, 3, 5, 40,
				5, 5, 60, 3, 5, 80, 2
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(5, 6, "6", 1, 5, "", new int[32]
			{
				0, 1, 1, 1, 2, 1, 3, 1, 4, 1,
				5, 1, 6, 1, 7, 1, 8, 1, 9, 1,
				10, 1, 11, 1, 12, 1, 13, 1, 14, 1,
				15, 1
			}, new int[4] { 1, 2, 10, 100 }, new int[5] { 25, 5, 5, 100, 5 }, new string[5] { "0", "0", "0", "0", "0" }, new int[77]
			{
				15, 0, 40, 5, 0, 60, 3, 0, 80, 2,
				1, 40, 5, 1, 60, 3, 1, 80, 2, 2,
				40, 5, 2, 60, 3, 2, 80, 2, 3, 40,
				5, 3, 60, 3, 3, 80, 2, 4, 40, 5,
				4, 60, 3, 4, 80, 2, 3, 8, 100, 5,
				8, 150, 3, 8, 200, 2, 3, 6, 200, 5,
				6, 300, 3, 6, 400, 2, 0, 3, 5, 40,
				5, 5, 60, 3, 5, 80, 2
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(6, 7, "7", 1, 5, "", new int[32]
			{
				0, 1, 1, 1, 2, 1, 3, 1, 4, 1,
				5, 1, 6, 1, 7, 1, 8, 1, 9, 1,
				10, 1, 11, 1, 12, 1, 13, 1, 14, 1,
				15, 1
			}, new int[4] { 1, 2, 10, 100 }, new int[5] { 25, 5, 5, 100, 5 }, new string[5] { "0", "0", "0", "0", "0" }, new int[77]
			{
				15, 0, 40, 5, 0, 60, 3, 0, 80, 2,
				1, 40, 5, 1, 60, 3, 1, 80, 2, 2,
				40, 5, 2, 60, 3, 2, 80, 2, 3, 40,
				5, 3, 60, 3, 3, 80, 2, 4, 40, 5,
				4, 60, 3, 4, 80, 2, 3, 8, 100, 5,
				8, 150, 3, 8, 200, 2, 3, 6, 200, 5,
				6, 300, 3, 6, 400, 2, 0, 3, 5, 40,
				5, 5, 60, 3, 5, 80, 2
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, new List<AdventureAdvancedBranch>
		{
			new AdventureAdvancedBranch(2, "", 0, 15, 100, new int[32]
			{
				0, 1, 1, 1, 2, 1, 3, 1, 4, 1,
				5, 1, 6, 1, 7, 1, 8, 1, 9, 1,
				10, 1, 11, 1, 12, 1, 13, 1, 14, 1,
				15, 1
			}, new int[4] { 1, 2, 1, 100 }, new int[5], new string[5] { "0", "0", "0", "0", "0" }, new int[5], new int[125]
			{
				5, 5, -501, 1, 20, 5, -502, 1, 20, 5,
				-503, 1, 20, 5, -504, 1, 20, 5, -505, 1,
				20, 2, 10, -1002, 1, 50, 10, -1001, 1, 50,
				1, 2, -201, 1, 100, 16, 0, -1, 1, 5,
				0, -2, 1, 5, 0, -3, 1, 5, 0, -4,
				1, 5, 0, -5, 1, 5, 0, -6, 1, 5,
				0, -7, 1, 5, 0, -8, 1, 5, 0, -9,
				1, 5, 0, -10, 1, 5, 0, -11, 1, 5,
				0, -12, 1, 5, 0, -13, 1, 5, 0, -14,
				1, 5, 0, -15, 1, 5, 0, -16, 1, 5,
				6, 5, -507, 1, 15, 5, -506, 1, 15, 1,
				-101, 1, 15, 1, -102, 1, 15, 1, -103, 1,
				15, 1, -104, 1, 15
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureAdvancedBranch(2, "", 1, 15, 100, new int[32]
			{
				0, 1, 1, 1, 2, 1, 3, 1, 4, 1,
				5, 1, 6, 1, 7, 1, 8, 1, 9, 1,
				10, 1, 11, 1, 12, 1, 13, 1, 14, 1,
				15, 1
			}, new int[4] { 1, 2, 3, 100 }, new int[5], new string[5] { "0", "0", "0", "0", "0" }, new int[5], new int[125]
			{
				5, 5, -501, 1, 20, 5, -502, 1, 20, 5,
				-503, 1, 20, 5, -504, 1, 20, 5, -505, 1,
				20, 2, 10, -1001, 1, 50, 10, -1002, 1, 50,
				1, 2, -201, 1, 100, 16, 0, -1, 1, 5,
				0, -2, 1, 5, 0, -3, 1, 5, 0, -4,
				1, 5, 0, -5, 1, 5, 0, -6, 1, 5,
				0, -7, 1, 5, 0, -8, 1, 5, 0, -9,
				1, 5, 0, -10, 1, 5, 0, -11, 1, 5,
				0, -12, 1, 5, 0, -13, 1, 5, 0, -14,
				1, 5, 0, -15, 1, 5, 0, -16, 1, 5,
				6, 5, -506, 1, 15, 5, -507, 1, 15, 1,
				-101, 1, 15, 1, -102, 1, 15, 1, -103, 1,
				15, 1, -104, 1, 15
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureAdvancedBranch(2, "", 2, 15, 100, new int[32]
			{
				0, 1, 1, 1, 2, 1, 3, 1, 4, 1,
				5, 1, 6, 1, 7, 1, 8, 1, 9, 1,
				10, 1, 11, 1, 12, 1, 13, 1, 14, 1,
				15, 1
			}, new int[4] { 1, 2, 10, 100 }, new int[5], new string[5] { "0", "0", "0", "0", "0" }, new int[5], new int[125]
			{
				5, 5, -501, 1, 20, 5, -502, 1, 20, 5,
				-503, 1, 20, 5, -504, 1, 20, 5, -505, 1,
				20, 2, 10, -1001, 1, 50, 10, -1002, 1, 50,
				1, 2, -201, 1, 100, 16, 0, -1, 1, 5,
				0, -2, 1, 5, 0, -3, 1, 5, 0, -4,
				1, 5, 0, -5, 1, 5, 0, -6, 1, 5,
				0, -7, 1, 5, 0, -8, 1, 5, 0, -9,
				1, 5, 0, -10, 1, 5, 0, -11, 1, 5,
				0, -12, 1, 5, 0, -13, 1, 5, 0, -14,
				1, 5, 0, -15, 1, 5, 0, -16, 1, 5,
				6, 5, -506, 1, 15, 5, -507, 1, 15, 1,
				-101, 1, 15, 1, -102, 1, 15, 1, -103, 1,
				15, 1, -104, 1, 15
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureAdvancedBranch(2, "", 3, 15, 100, new int[32]
			{
				0, 1, 1, 1, 2, 1, 3, 1, 4, 1,
				5, 1, 6, 1, 7, 1, 8, 1, 9, 1,
				10, 1, 11, 1, 12, 1, 13, 1, 14, 1,
				15, 1
			}, new int[4] { 1, 2, 22, 100 }, new int[5], new string[5] { "0", "0", "0", "0", "0" }, new int[5], new int[125]
			{
				5, 5, -501, 1, 20, 5, -502, 1, 20, 5,
				-503, 1, 20, 5, -504, 1, 20, 5, -505, 1,
				20, 2, 10, -1001, 1, 50, 10, -1002, 1, 50,
				1, 2, -201, 1, 100, 16, 0, -1, 1, 5,
				0, -2, 1, 5, 0, -3, 1, 5, 0, -4,
				1, 5, 0, -5, 1, 5, 0, -6, 1, 5,
				0, -7, 1, 5, 0, -8, 1, 5, 0, -9,
				1, 5, 0, -10, 1, 5, 0, -11, 1, 5,
				0, -12, 1, 5, 0, -13, 1, 5, 0, -14,
				1, 5, 0, -15, 1, 5, 0, -16, 1, 5,
				6, 5, -506, 1, 15, 5, -507, 1, 15, 1,
				-101, 1, 15, 1, -102, 1, 15, 1, -103, 1,
				15, 1, -104, 1, 15
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureAdvancedBranch(2, "", -1, 15, 100, new int[32]
			{
				0, 1, 1, 1, 2, 1, 3, 1, 4, 1,
				5, 1, 6, 1, 7, 1, 8, 1, 9, 1,
				10, 1, 11, 1, 12, 1, 13, 1, 14, 1,
				15, 1
			}, new int[4] { 1, 2, 5, 100 }, new int[5], new string[5] { "0", "0", "0", "0", "0" }, new int[5], new int[125]
			{
				5, 5, -501, 1, 20, 5, -502, 1, 20, 5,
				-503, 1, 20, 5, -504, 1, 20, 5, -505, 1,
				20, 2, 10, -1001, 1, 50, 10, -1002, 1, 50,
				1, 2, -201, 1, 100, 16, 0, -1, 1, 5,
				0, -2, 1, 5, 0, -3, 1, 5, 0, -4,
				1, 5, 0, -5, 1, 5, 0, -6, 1, 5,
				0, -7, 1, 5, 0, -8, 1, 5, 0, -9,
				1, 5, 0, -10, 1, 5, 0, -11, 1, 5,
				0, -12, 1, 5, 0, -13, 1, 5, 0, -14,
				1, 5, 0, -15, 1, 5, 0, -16, 1, 5,
				6, 5, -506, 1, 15, 5, -507, 1, 15, 1,
				-101, 1, 15, 1, -102, 1, 15, 1, -103, 1,
				15, 1, -104, 1, 15
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureAdvancedBranch(2, "", 4, 15, 100, new int[32]
			{
				0, 1, 1, 1, 2, 1, 3, 1, 4, 1,
				5, 1, 6, 1, 7, 1, 8, 1, 9, 1,
				10, 1, 11, 1, 12, 1, 13, 1, 14, 1,
				15, 1
			}, new int[4] { 1, 2, 1, 100 }, new int[5], new string[5] { "0", "0", "0", "0", "0" }, new int[5], new int[125]
			{
				5, 5, -501, 1, 20, 5, -502, 1, 20, 5,
				-503, 1, 20, 5, -504, 1, 20, 5, -505, 1,
				20, 2, 10, -1001, 1, 50, 10, -1002, 1, 50,
				1, 2, -201, 1, 100, 16, 0, -1, 1, 5,
				0, -2, 1, 5, 0, -3, 1, 5, 0, -4,
				1, 5, 0, -5, 1, 5, 0, -6, 1, 5,
				0, -7, 1, 5, 0, -8, 1, 5, 0, -9,
				1, 5, 0, -10, 1, 5, 0, -11, 1, 5,
				0, -12, 1, 5, 0, -13, 1, 5, 0, -14,
				1, 5, 0, -15, 1, 5, 0, -16, 1, 5,
				6, 5, -506, 1, 15, 5, -507, 1, 15, 1,
				-101, 1, 15, 1, -102, 1, 15, 1, -103, 1,
				15, 1, -104, 1, 15
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureAdvancedBranch(2, "", 5, 15, 100, new int[32]
			{
				0, 1, 1, 1, 2, 1, 3, 1, 4, 1,
				5, 1, 6, 1, 7, 1, 8, 1, 9, 1,
				10, 1, 11, 1, 12, 1, 13, 1, 14, 1,
				15, 1
			}, new int[4] { 1, 2, 1, 100 }, new int[5], new string[5] { "0", "0", "0", "0", "0" }, new int[5], new int[125]
			{
				5, 5, -501, 1, 20, 5, -502, 1, 20, 5,
				-503, 1, 20, 5, -504, 1, 20, 5, -505, 1,
				20, 2, 10, -1001, 1, 50, 10, -1002, 1, 50,
				1, 2, -201, 1, 100, 16, 0, -1, 1, 5,
				0, -2, 1, 5, 0, -3, 1, 5, 0, -4,
				1, 5, 0, -5, 1, 5, 0, -6, 1, 5,
				0, -7, 1, 5, 0, -8, 1, 5, 0, -9,
				1, 5, 0, -10, 1, 5, 0, -11, 1, 5,
				0, -12, 1, 5, 0, -13, 1, 5, 0, -14,
				1, 5, 0, -15, 1, 5, 0, -16, 1, 5,
				6, 1, -101, 1, 15, 1, -102, 1, 15, 1,
				-103, 1, 15, 1, -104, 1, 15, 5, -506, 1,
				15, 5, -507, 1, 15
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureAdvancedBranch(2, "", 6, 15, 100, new int[34]
			{
				0, 1, 1, 1, 2, 1, 3, 1, 4, 1,
				5, 1, 0, 1, 6, 1, 7, 1, 8, 1,
				9, 1, 10, 1, 11, 1, 12, 1, 13, 1,
				14, 1, 15, 1
			}, new int[4] { 1, 2, 1, 100 }, new int[5], new string[5] { "0", "0", "0", "0", "0" }, new int[5], new int[125]
			{
				5, 5, -501, 1, 20, 5, -502, 1, 20, 5,
				-503, 1, 20, 5, -504, 1, 20, 5, -505, 1,
				20, 2, 10, -1001, 1, 50, 10, -1002, 1, 50,
				1, 2, -201, 1, 100, 16, 0, -1, 1, 5,
				0, -2, 1, 5, 0, -3, 1, 5, 0, -4,
				1, 5, 0, -5, 1, 5, 0, -6, 1, 5,
				0, -7, 1, 5, 0, -8, 1, 5, 0, -9,
				1, 5, 0, -10, 1, 5, 0, -11, 1, 5,
				0, -12, 1, 5, 0, -13, 1, 5, 0, -14,
				1, 5, 0, -15, 1, 5, 0, -16, 1, 5,
				6, 1, -101, 1, 15, 1, -102, 1, 15, 1,
				-103, 1, 15, 1, -104, 1, 15, 5, -506, 1,
				15, 5, -507, 1, 15
			}, new string[5] { "0", "0", "0", "0", "0" })
		}, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray42 = _dataArray;
		string config83 = LocalStringManager.GetConfig("Adventure_language", "Name_41");
		string config84 = LocalStringManager.GetConfig("Adventure_language", "Desc_41");
		int[] resCost42 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost41 = list;
		short[] malice41 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams37 = list2;
		List<AdventureStartNode> startNodes37 = new List<AdventureStartNode>
		{
			new AdventureStartNode("", "A", "", 2)
		};
		List<AdventureTransferNode> transferNodes35 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("", "B", "", 0),
			new AdventureTransferNode("", "C", "", 0)
		};
		List<AdventureEndNode> endNodes35 = new List<AdventureEndNode>
		{
			new AdventureEndNode("", "D", "", 0)
		};
		List<AdventureBaseBranch> baseBranches35 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 2, 5, "", new int[2] { 8, 100 }, new int[16]
			{
				5, 2, 2, 30, 2, 2, 10, 2, 7, 30,
				2, 11, 20, 2, 17, 10
			}, new int[5] { 10, 5, 15, 10, 15 }, new string[5] { "0", "0", "0", "0", "0" }, new int[23]
			{
				0, 3, 8, 200, 5, 8, 300, 3, 8, 400,
				2, 0, 0, 3, 5, 80, 5, 5, 120, 3,
				5, 160, 2
			}, new int[13]
			{
				0, 0, 0, 0, 2, 8, -801, 1, 10, 5,
				-506, 1, 10
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 2, 5, "", new int[2] { 8, 100 }, new int[16]
			{
				5, 2, 2, 30, 2, 2, 10, 2, 7, 30,
				2, 11, 20, 2, 17, 10
			}, new int[5] { 10, 5, 15, 10, 15 }, new string[5] { "0", "0", "0", "0", "0" }, new int[23]
			{
				0, 3, 8, 200, 5, 8, 300, 3, 8, 400,
				2, 0, 0, 3, 5, 80, 5, 5, 120, 3,
				5, 160, 2
			}, new int[13]
			{
				0, 0, 0, 0, 2, 8, -801, 1, 10, 5,
				-506, 1, 10
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 3, "3", 2, 5, "", new int[2] { 8, 100 }, new int[16]
			{
				5, 2, 2, 30, 2, 2, 10, 2, 7, 30,
				2, 11, 20, 2, 17, 10
			}, new int[5] { 10, 5, 15, 10, 15 }, new string[5] { "0", "0", "0", "0", "0" }, new int[23]
			{
				0, 3, 8, 200, 5, 8, 300, 3, 8, 400,
				2, 0, 0, 3, 5, 80, 5, 5, 120, 3,
				5, 160, 2
			}, new int[13]
			{
				0, 0, 0, 0, 2, 8, -801, 1, 10, 5,
				-506, 1, 10
			}, new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray42.Add(new AdventureItem(41, config83, config84, 2, 4, 4, 0, 6, 9, resCost42, itemCost41, restrictedByWorldPopulation: false, malice41, adventureParams37, null, startNodes37, transferNodes35, endNodes35, baseBranches35, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray43 = _dataArray;
		string config85 = LocalStringManager.GetConfig("Adventure_language", "Name_42");
		string config86 = LocalStringManager.GetConfig("Adventure_language", "Desc_42");
		int[] resCost43 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost42 = list;
		short[] malice42 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams38 = list2;
		List<AdventureStartNode> startNodes38 = new List<AdventureStartNode>
		{
			new AdventureStartNode("b207cb09-cb8a-4945-9b01-cb7b05933ebf", "A", "LK_Adventure_NodeTitle_116", 16)
		};
		List<AdventureTransferNode> transferNodes36 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("32ce8fe1-906d-47e9-829e-f9be779a8051", "B", "LK_Adventure_NodeTitle_117", 20),
			new AdventureTransferNode("74821354-a3ad-43ea-a63a-8280f51083dc", "C", "LK_Adventure_NodeTitle_118", 3),
			new AdventureTransferNode("69f15dea-3ef5-454f-88bb-d970526b403e", "D", "LK_Adventure_NodeTitle_119", 22),
			new AdventureTransferNode("2dc91406-84f1-4c95-a306-87160f66dd7e", "E", "LK_Adventure_NodeTitle_120", 3),
			new AdventureTransferNode("16722b0b-882b-4151-b83e-61df4cc60b6d", "F", "LK_Adventure_NodeTitle_121", 3)
		};
		List<AdventureEndNode> endNodes36 = new List<AdventureEndNode>
		{
			new AdventureEndNode("797fe3c4-7dd8-4d9a-9794-2d961f66ab4d", "G", "LK_Adventure_NodeTitle_122", 3)
		};
		List<AdventureBaseBranch> baseBranches36 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 2, "", new int[4] { 12, 50, 13, 50 }, new int[7] { 2, 2, 16, 50, 2, 20, 50 }, new int[5] { 100, 5, 100, 10, 4 }, new string[5] { "0", "0", "0", "0", "0" }, new int[23]
			{
				0, 3, 8, 200, 5, 8, 300, 3, 8, 400,
				2, 0, 3, 7, 40, 5, 7, 60, 3, 7,
				80, 2, 0
			}, new int[21]
			{
				0, 0, 0, 0, 4, 1, -101, 1, 2, 1,
				-102, 1, 2, 1, -103, 1, 2, 1, -104, 1,
				2
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 1, 2, "", new int[4] { 12, 50, 13, 50 }, new int[7] { 2, 2, 16, 50, 2, 20, 50 }, new int[5] { 100, 5, 100, 10, 4 }, new string[5] { "0", "0", "0", "0", "0" }, new int[23]
			{
				0, 3, 8, 200, 5, 8, 300, 3, 8, 400,
				2, 0, 3, 7, 40, 5, 7, 60, 3, 7,
				80, 2, 0
			}, new int[21]
			{
				0, 0, 0, 0, 4, 1, -101, 1, 2, 1,
				-102, 1, 2, 1, -103, 1, 2, 1, -104, 1,
				2
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 3, "3", 1, 3, "", new int[4] { 12, 50, 13, 50 }, new int[10] { 3, 2, 3, 40, 2, 16, 30, 2, 20, 30 }, new int[5] { 100, 5, 100, 10, 4 }, new string[5] { "0", "0", "0", "0", "0" }, new int[23]
			{
				0, 3, 8, 200, 5, 8, 300, 3, 8, 400,
				2, 0, 3, 7, 40, 5, 7, 60, 3, 7,
				80, 2, 0
			}, new int[21]
			{
				0, 0, 0, 0, 4, 1, -101, 1, 2, 1,
				-102, 1, 2, 1, -103, 1, 2, 1, -104, 1,
				2
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 4, "4", 1, 5, "", new int[4] { 12, 50, 13, 50 }, new int[13]
			{
				4, 2, 3, 20, 2, 18, 20, 2, 21, 30,
				2, 22, 30
			}, new int[5] { 100, 5, 100, 10, 4 }, new string[5] { "0", "0", "0", "0", "0" }, new int[23]
			{
				0, 3, 8, 200, 5, 8, 300, 3, 8, 400,
				2, 0, 3, 7, 40, 5, 7, 60, 3, 7,
				80, 2, 0
			}, new int[21]
			{
				0, 0, 0, 0, 4, 1, -101, 1, 2, 1,
				-102, 1, 2, 1, -103, 1, 2, 1, -104, 1,
				2
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(4, 5, "5", 1, 5, "", new int[4] { 12, 50, 13, 50 }, new int[10] { 3, 2, 3, 60, 2, 21, 20, 2, 22, 20 }, new int[5] { 100, 5, 100, 10, 4 }, new string[5] { "0", "0", "0", "0", "0" }, new int[23]
			{
				0, 3, 8, 200, 5, 8, 300, 3, 8, 400,
				2, 0, 3, 7, 40, 5, 7, 60, 3, 7,
				80, 2, 0
			}, new int[21]
			{
				0, 0, 0, 0, 4, 1, -101, 1, 2, 1,
				-102, 1, 2, 1, -103, 1, 2, 1, -104, 1,
				2
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(5, 6, "6", 1, 3, "", new int[4] { 12, 50, 13, 50 }, new int[7] { 2, 2, 3, 70, 2, 16, 30 }, new int[5] { 100, 5, 100, 10, 4 }, new string[5] { "0", "0", "0", "0", "0" }, new int[23]
			{
				0, 3, 8, 200, 5, 8, 300, 3, 8, 400,
				2, 0, 3, 7, 40, 5, 7, 60, 3, 7,
				80, 2, 0
			}, new int[21]
			{
				0, 0, 0, 0, 4, 1, -101, 1, 2, 1,
				-102, 1, 2, 1, -103, 1, 2, 1, -104, 1,
				2
			}, new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray43.Add(new AdventureItem(42, config85, config86, 2, 1, 4, 0, 10, -1, resCost43, itemCost42, restrictedByWorldPopulation: false, malice42, adventureParams38, "2c4d1d97-51be-4972-a7a0-1dc09f1c81a0", startNodes38, transferNodes36, endNodes36, baseBranches36, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray44 = _dataArray;
		string config87 = LocalStringManager.GetConfig("Adventure_language", "Name_43");
		string config88 = LocalStringManager.GetConfig("Adventure_language", "Desc_43");
		int[] resCost44 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost43 = list;
		short[] malice43 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams39 = list2;
		List<AdventureStartNode> startNodes39 = new List<AdventureStartNode>
		{
			new AdventureStartNode("", "A", "", 17)
		};
		list3 = new List<AdventureTransferNode>();
		List<AdventureTransferNode> transferNodes37 = list3;
		List<AdventureEndNode> endNodes37 = new List<AdventureEndNode>
		{
			new AdventureEndNode("", "B", "", 17)
		};
		List<AdventureBaseBranch> baseBranches37 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 10, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[2] { 8, 100 }, new int[13]
			{
				4, 2, 17, 40, 2, 18, 30, 2, 11, 20,
				2, 4, 10
			}, new int[5] { 10, 5, 10, 20, 15 }, new string[7] { "0", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "30", "0" }, new int[23]
			{
				0, 3, 0, 300, 5, 0, 450, 3, 0, 600,
				2, 0, 0, 3, 5, 120, 5, 5, 180, 3,
				5, 240, 2
			}, new int[13]
			{
				0, 0, 0, 0, 2, 8, -801, 1, 10, 5,
				-506, 1, 10
			}, new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray44.Add(new AdventureItem(43, config87, config88, 2, 5, 5, 0, 6, 9, resCost44, itemCost43, restrictedByWorldPopulation: false, malice43, adventureParams39, null, startNodes39, transferNodes37, endNodes37, baseBranches37, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray45 = _dataArray;
		string config89 = LocalStringManager.GetConfig("Adventure_language", "Name_44");
		string config90 = LocalStringManager.GetConfig("Adventure_language", "Desc_44");
		int[] resCost45 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost44 = list;
		short[] malice44 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams40 = list2;
		List<AdventureStartNode> startNodes40 = new List<AdventureStartNode>
		{
			new AdventureStartNode("482f832c-03d8-4c97-8f2f-a711f2592c28", "A", "LK_Adventure_NodeTitle_123", 2)
		};
		List<AdventureTransferNode> transferNodes38 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("3de3c766-0900-4238-b98c-399567ed9df9", "D", "LK_Adventure_NodeTitle_124", 2),
			new AdventureTransferNode("91718141-a22e-4a56-bc6e-c96773d942c5", "C", "LK_Adventure_NodeTitle_125", 2),
			new AdventureTransferNode("7f9ee9af-d0b5-48d1-b998-983948a45d14", "B", "LK_Adventure_NodeTitle_126", 2),
			new AdventureTransferNode("c22a50c2-7c5b-4014-bca2-c7db90de1e4a", "G", "LK_Adventure_NodeTitle_124", 2),
			new AdventureTransferNode("61b17d06-0863-4b71-b3a6-6d03d0d9d0f7", "H", "LK_Adventure_NodeTitle_125", 2)
		};
		List<AdventureEndNode> endNodes38 = new List<AdventureEndNode>
		{
			new AdventureEndNode("be11f97f-4475-4afe-8244-6cd27536fdbe", "E", "LK_Adventure_NodeTitle_127", 3),
			new AdventureEndNode("be11f97f-4475-4afe-8244-6cd27536fdbe", "F", "LK_Adventure_NodeTitle_127", 3)
		};
		List<AdventureBaseBranch> baseBranches38 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(2, 4, "4", 1, 5, "", new int[2] { 8, 100 }, new int[4] { 1, 2, 8, 100 }, new int[5] { 25, 25, 10, 10, 25 }, new string[7] { "0", "0", "0", "1", "701f94db-5a97-4770-bed4-7ec030b2ae93", "5", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 5, "6", 1, 5, "", new int[2] { 8, 100 }, new int[4] { 1, 2, 8, 100 }, new int[5] { 25, 25, 10, 10, 25 }, new string[7] { "0", "0", "0", "1", "701f94db-5a97-4770-bed4-7ec030b2ae93", "5", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(0, 3, "1", 1, 5, "", new int[2] { 8, 100 }, new int[4] { 1, 2, 8, 100 }, new int[5] { 25, 25, 10, 10, 25 }, new string[7] { "0", "0", "0", "1", "701f94db-5a97-4770-bed4-7ec030b2ae93", "5", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 2, "2", 1, 5, "", new int[2] { 8, 100 }, new int[4] { 1, 2, 8, 100 }, new int[5] { 25, 25, 10, 10, 25 }, new string[7] { "0", "0", "0", "1", "701f94db-5a97-4770-bed4-7ec030b2ae93", "5", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 1, "3", 1, 5, "", new int[2] { 8, 100 }, new int[4] { 1, 2, 8, 100 }, new int[5] { 25, 25, 10, 10, 25 }, new string[7] { "0", "0", "0", "1", "701f94db-5a97-4770-bed4-7ec030b2ae93", "5", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(4, 6, "5", 1, 5, "", new int[2] { 8, 100 }, new int[4] { 1, 2, 8, 100 }, new int[5] { 25, 25, 10, 10, 25 }, new string[7] { "0", "0", "0", "1", "701f94db-5a97-4770-bed4-7ec030b2ae93", "5", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(5, 7, "7", 1, 5, "", new int[2] { 8, 100 }, new int[4] { 1, 2, 8, 100 }, new int[5] { 25, 25, 10, 10, 25 }, new string[7] { "0", "0", "0", "1", "701f94db-5a97-4770-bed4-7ec030b2ae93", "5", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray45.Add(new AdventureItem(44, config89, config90, 2, 7, 7, 0, 10, -1, resCost45, itemCost44, restrictedByWorldPopulation: false, malice44, adventureParams40, "9cfe7eab-0832-4eb0-90f8-58ba6af28b30", startNodes40, transferNodes38, endNodes38, baseBranches38, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray46 = _dataArray;
		string config91 = LocalStringManager.GetConfig("Adventure_language", "Name_45");
		string config92 = LocalStringManager.GetConfig("Adventure_language", "Desc_45");
		int[] resCost46 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost45 = list;
		short[] malice45 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams41 = list2;
		List<AdventureStartNode> startNodes41 = new List<AdventureStartNode>
		{
			new AdventureStartNode("75713e23-f3f1-44cc-bd5d-20615c8cca75", "A", "LK_Adventure_NodeTitle_128", 1)
		};
		List<AdventureTransferNode> transferNodes39 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("ebaec7b5-c44c-4338-aea7-3eb5365b8011", "B", "LK_Adventure_NodeTitle_129", 12)
		};
		List<AdventureEndNode> endNodes39 = new List<AdventureEndNode>
		{
			new AdventureEndNode("ff41a6c5-dbbb-47af-b528-6e821950ad1f", "C", "LK_Adventure_NodeTitle_130", 1)
		};
		List<AdventureBaseBranch> baseBranches39 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 5, "", new int[2] { 8, 100 }, new int[7] { 2, 2, 1, 50, 2, 12, 50 }, new int[5] { 25, 20, 10, 15, 20 }, new string[5] { "0", "0", "0", "0", "0" }, new int[11]
			{
				0, 1, 8, 800, 5, 0, 0, 1, 5, 720,
				5
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 1, 5, "", new int[2] { 8, 100 }, new int[7] { 2, 2, 1, 50, 2, 12, 50 }, new int[5] { 25, 20, 10, 15, 0 }, new string[5] { "0", "0", "0", "0", "0" }, new int[11]
			{
				0, 1, 8, 800, 5, 0, 0, 1, 5, 720,
				5
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray46.Add(new AdventureItem(45, config91, config92, 2, 7, 7, 0, 5, 6, resCost46, itemCost45, restrictedByWorldPopulation: false, malice45, adventureParams41, "9755f235-3540-4cf7-a8bc-9ff6a940aff1", startNodes41, transferNodes39, endNodes39, baseBranches39, advancedBranches, difficultyAddXiangshuLevel: true));
		List<AdventureItem> dataArray47 = _dataArray;
		string config93 = LocalStringManager.GetConfig("Adventure_language", "Name_46");
		string config94 = LocalStringManager.GetConfig("Adventure_language", "Desc_46");
		int[] resCost47 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost46 = list;
		short[] malice46 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams42 = list2;
		List<AdventureStartNode> startNodes42 = new List<AdventureStartNode>
		{
			new AdventureStartNode("0ce2cbcf-e7d3-491e-88a1-c1a6365aed86", "A", "LK_Adventure_NodeTitle_62", 21)
		};
		List<AdventureTransferNode> transferNodes40 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("bbfe0c42-df28-4c49-9004-5f62bb500523", "B", "LK_Adventure_NodeTitle_63", 21)
		};
		List<AdventureEndNode> endNodes40 = new List<AdventureEndNode>
		{
			new AdventureEndNode("48e13a77-a549-484a-8c86-06acf0b289cf", "C", "LK_Adventure_NodeTitle_64", 0)
		};
		List<AdventureBaseBranch> baseBranches40 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 5, "", new int[4] { 13, 50, 12, 50 }, new int[25]
			{
				3, 7, 21, 25, 5, 15, 5, 60, 15, 7,
				22, 25, 5, 15, 5, 60, 15, 7, 3, 50,
				5, 15, 5, 60, 15
			}, new int[5] { 100, 5, 100, 8, 4 }, new string[7] { "0", "0", "0", "1", "6aeadce8-8292-4997-8657-797b7eb6de9f", "5", "0" }, new int[23]
			{
				0, 3, 8, 800, 5, 8, 1200, 3, 8, 1600,
				2, 0, 3, 7, 160, 5, 7, 240, 3, 7,
				320, 2, 0
			}, new int[21]
			{
				0, 0, 0, 0, 4, 1, -101, 1, 2, 1,
				-102, 1, 2, 1, -103, 1, 2, 1, -104, 1,
				2
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 1, 10, "", new int[4] { 13, 50, 12, 50 }, new int[25]
			{
				3, 7, 21, 25, 5, 15, 5, 60, 15, 7,
				22, 25, 5, 15, 5, 60, 15, 7, 3, 50,
				5, 15, 5, 60, 15
			}, new int[5] { 100, 5, 100, 8, 4 }, new string[7] { "0", "0", "0", "1", "6aeadce8-8292-4997-8657-797b7eb6de9f", "5", "0" }, new int[23]
			{
				0, 3, 8, 800, 5, 8, 1200, 3, 8, 1600,
				2, 0, 3, 7, 160, 5, 7, 240, 3, 7,
				320, 2, 0
			}, new int[21]
			{
				0, 0, 0, 0, 4, 1, -101, 1, 2, 1,
				-102, 1, 2, 1, -103, 1, 2, 1, -104, 1,
				2
			}, new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray47.Add(new AdventureItem(46, config93, config94, 2, 7, 7, 2, 10, -1, resCost47, itemCost46, restrictedByWorldPopulation: false, malice46, adventureParams42, "ed09c138-95b3-402f-88f6-a289afcb197c", startNodes42, transferNodes40, endNodes40, baseBranches40, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray48 = _dataArray;
		string config95 = LocalStringManager.GetConfig("Adventure_language", "Name_47");
		string config96 = LocalStringManager.GetConfig("Adventure_language", "Desc_47");
		int[] resCost48 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost47 = list;
		short[] malice47 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams43 = list2;
		List<AdventureStartNode> startNodes43 = new List<AdventureStartNode>
		{
			new AdventureStartNode("90a96c62-ed73-4e80-a9b5-59020d6d7b5a", "A", "LK_Adventure_NodeTitle_131", 8)
		};
		List<AdventureTransferNode> transferNodes41 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("2dd43d9c-bc94-4372-8f8d-4104064c5230", "B", "LK_Adventure_NodeTitle_132", 8),
			new AdventureTransferNode("8ebfd48e-02f6-484b-a26b-7ef6ec56418b", "C", "LK_Adventure_NodeTitle_133", 8),
			new AdventureTransferNode("fe5a0396-9de9-4dda-813a-180578eadd5f", "D", "LK_Adventure_NodeTitle_134", 8)
		};
		List<AdventureEndNode> endNodes41 = new List<AdventureEndNode>
		{
			new AdventureEndNode("f191ea7f-83d0-42c6-8bf0-7fe04d3ca7d7", "E", "LK_Adventure_NodeTitle_135", 8)
		};
		List<AdventureBaseBranch> baseBranches41 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 5, "", new int[2] { 8, 100 }, new int[4] { 1, 2, 8, 100 }, new int[5] { 25, 25, 10, 10, 25 }, new string[7] { "0", "0", "0", "1", "4acbfe17-fd95-4821-94b4-8d23de2111fc", "5", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 1, 5, "", new int[2] { 8, 100 }, new int[4] { 1, 2, 8, 100 }, new int[5] { 25, 25, 10, 10, 25 }, new string[7] { "0", "0", "0", "1", "4acbfe17-fd95-4821-94b4-8d23de2111fc", "5", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 3, "3", 1, 5, "", new int[2] { 8, 100 }, new int[4] { 1, 2, 8, 100 }, new int[5] { 25, 25, 10, 10, 25 }, new string[7] { "0", "0", "0", "1", "4acbfe17-fd95-4821-94b4-8d23de2111fc", "5", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 4, "4", 1, 5, "", new int[2] { 8, 100 }, new int[4] { 1, 2, 8, 100 }, new int[5] { 25, 25, 10, 10, 25 }, new string[7] { "0", "0", "0", "1", "4acbfe17-fd95-4821-94b4-8d23de2111fc", "5", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 4, "5", 1, 5, "", new int[2] { 8, 100 }, new int[4] { 1, 2, 8, 100 }, new int[5] { 25, 25, 10, 10, 25 }, new string[7] { "0", "0", "0", "1", "4acbfe17-fd95-4821-94b4-8d23de2111fc", "5", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray48.Add(new AdventureItem(47, config95, config96, 2, 8, 8, 0, 5, 12, resCost48, itemCost47, restrictedByWorldPopulation: false, malice47, adventureParams43, "3e21f453-4d04-41df-a3b3-d1cc6f477afe", startNodes43, transferNodes41, endNodes41, baseBranches41, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray49 = _dataArray;
		string config97 = LocalStringManager.GetConfig("Adventure_language", "Name_48");
		string config98 = LocalStringManager.GetConfig("Adventure_language", "Desc_48");
		int[] resCost49 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost48 = list;
		short[] malice48 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams44 = list2;
		List<AdventureStartNode> startNodes44 = new List<AdventureStartNode>
		{
			new AdventureStartNode("bbedef6a-db43-4e9d-a3b1-31b92d12e400", "A", "LK_Adventure_NodeTitle_136", 8)
		};
		List<AdventureTransferNode> transferNodes42 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("a2b3cf2c-14ef-4f0d-be03-c059d3a3eac9", "C", "LK_Adventure_NodeTitle_137", 8),
			new AdventureTransferNode("68174317-d2ad-4822-b3f7-7840b6b057a3", "D", "LK_Adventure_NodeTitle_138", 8),
			new AdventureTransferNode("68b46f86-c1d3-42fd-8374-c2952409b05c", "B", "LK_Adventure_NodeTitle_139", 8)
		};
		List<AdventureEndNode> endNodes42 = new List<AdventureEndNode>
		{
			new AdventureEndNode("c4ed40a3-9d33-4024-aca4-d524e40bcf0b", "E", "LK_Adventure_NodeTitle_140", 8)
		};
		List<AdventureBaseBranch> baseBranches42 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 3, "1", 1, 2, "", new int[4] { 13, 50, 12, 50 }, new int[9] { 1, 7, 8, 100, 20, 20, 20, 20, 20 }, new int[5] { 10, 10, 10, 30, 10 }, new string[5] { "0", "0", "0", "0", "0" }, new int[5], new int[17]
			{
				0, 0, 0, 3, 12, 3, 1, 5, 12, 4,
				1, 5, 12, 5, 1, 5, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "3", 1, 5, "", new int[4] { 13, 50, 12, 50 }, new int[9] { 1, 7, 8, 100, 0, 0, 0, 100, 0 }, new int[5] { 10, 10, 10, 30, 10 }, new string[5] { "0", "0", "0", "0", "0" }, new int[5], new int[17]
			{
				0, 0, 0, 3, 12, 3, 1, 5, 12, 4,
				1, 5, 12, 5, 1, 5, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 4, "4", 1, 5, "", new int[4] { 13, 50, 12, 50 }, new int[9] { 1, 7, 8, 100, 0, 0, 0, 100, 0 }, new int[5] { 10, 10, 10, 30, 10 }, new string[5] { "0", "0", "0", "0", "0" }, new int[5], new int[17]
			{
				0, 0, 0, 3, 12, 3, 1, 5, 12, 4,
				1, 5, 12, 5, 1, 5, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 1, "2", 1, 5, "", new int[4] { 13, 50, 12, 50 }, new int[9] { 1, 7, 8, 100, 0, 0, 0, 100, 0 }, new int[5] { 10, 10, 10, 30, 10 }, new string[5] { "0", "0", "0", "0", "0" }, new int[5], new int[17]
			{
				0, 0, 0, 3, 12, 3, 1, 5, 12, 4,
				1, 5, 12, 5, 1, 5, 0
			}, new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray49.Add(new AdventureItem(48, config97, config98, 2, 9, 9, 0, 10, -1, resCost49, itemCost48, restrictedByWorldPopulation: false, malice48, adventureParams44, "93a9659a-ac77-41af-85a6-3d7deafebccb", startNodes44, transferNodes42, endNodes42, baseBranches42, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray50 = _dataArray;
		string config99 = LocalStringManager.GetConfig("Adventure_language", "Name_49");
		string config100 = LocalStringManager.GetConfig("Adventure_language", "Desc_49");
		int[] resCost50 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost49 = list;
		short[] malice49 = new short[3];
		List<(string, string, string, string)> adventureParams45 = new List<(string, string, string, string)>
		{
			("BookToalMone", "LK_Adventure_49_ParamName_0", "adventure_icon_fenxiang(Clone)", ""),
			("WeaponToalMoney", "LK_Adventure_49_ParamName_1", "adventure_icon_fenxiang(Clone)", ""),
			("AccessoryToalMoney", "LK_Adventure_49_ParamName_2", "adventure_icon_fenxiang(Clone)", ""),
			("ConstructionToalMoney", "LK_Adventure_49_ParamName_3", "adventure_icon_fenxiang(Clone)", ""),
			("MaterialToalMoney", "LK_Adventure_49_ParamName_4", "adventure_icon_fenxiang(Clone)", ""),
			("FoodToalMoney", "LK_Adventure_49_ParamName_5", "adventure_icon_fenxiang(Clone)", "")
		};
		List<AdventureStartNode> startNodes45 = new List<AdventureStartNode>
		{
			new AdventureStartNode("63c9a854-16d7-4846-bb3b-310ff7a84755", "A", "LK_Adventure_NodeTitle_147", 9)
		};
		List<AdventureTransferNode> transferNodes43 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("3f80a451-f3d9-4cae-96f7-3f4b06d8de77", "B", "LK_Adventure_NodeTitle_148", 9),
			new AdventureTransferNode("05217e74-2d83-40ae-aa49-9b30c321ab09", "C", "LK_Adventure_NodeTitle_149", 9)
		};
		List<AdventureEndNode> endNodes43 = new List<AdventureEndNode>
		{
			new AdventureEndNode("311e0cc9-183e-432c-b31b-e0103b95eddd", "D", "LK_Adventure_NodeTitle_150", 9)
		};
		List<AdventureBaseBranch> baseBranches43 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 3, "", new int[32]
			{
				0, 1, 1, 1, 2, 1, 3, 1, 4, 1,
				5, 1, 6, 1, 7, 1, 8, 1, 9, 1,
				10, 1, 11, 1, 12, 1, 13, 1, 14, 1,
				15, 1
			}, new int[16]
			{
				5, 2, 9, 50, 2, 8, 10, 2, 7, 5,
				2, 10, 5, 2, 5, 5
			}, new int[5] { 100, 100, 100, 100, 100 }, new string[15]
			{
				"1", "416a2a37-1fc4-4280-86ec-810127075825", "100", "1", "416a2a37-1fc4-4280-86ec-810127075825", "100", "1", "416a2a37-1fc4-4280-86ec-810127075825", "100", "1",
				"416a2a37-1fc4-4280-86ec-810127075825", "100", "1", "416a2a37-1fc4-4280-86ec-810127075825", "100"
			}, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 1, 5, "", new int[32]
			{
				0, 1, 1, 1, 2, 1, 3, 1, 4, 1,
				5, 1, 6, 1, 7, 1, 8, 1, 9, 1,
				10, 1, 11, 1, 12, 1, 13, 1, 14, 1,
				15, 1
			}, new int[16]
			{
				5, 2, 9, 50, 2, 8, 10, 2, 7, 5,
				2, 10, 5, 2, 5, 5
			}, new int[5] { 100, 100, 100, 100, 100 }, new string[15]
			{
				"1", "cf3175ba-b33e-4302-b675-04ea6a31b8fd", "100", "1", "cf3175ba-b33e-4302-b675-04ea6a31b8fd", "100", "1", "cf3175ba-b33e-4302-b675-04ea6a31b8fd", "100", "1",
				"cf3175ba-b33e-4302-b675-04ea6a31b8fd", "100", "1", "cf3175ba-b33e-4302-b675-04ea6a31b8fd", "100"
			}, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 3, "3", 1, 3, "", new int[32]
			{
				0, 1, 1, 1, 2, 1, 3, 1, 4, 1,
				5, 1, 6, 1, 7, 1, 8, 1, 9, 1,
				10, 1, 11, 1, 12, 1, 13, 1, 14, 1,
				15, 1
			}, new int[16]
			{
				5, 2, 9, 50, 2, 8, 10, 2, 7, 5,
				2, 10, 5, 2, 5, 5
			}, new int[5] { 100, 100, 100, 100, 100 }, new string[15]
			{
				"1", "f4124e3b-4c27-4308-a177-998107b76da7", "100", "1", "f4124e3b-4c27-4308-a177-998107b76da7", "100", "1", "f4124e3b-4c27-4308-a177-998107b76da7", "100", "1",
				"f4124e3b-4c27-4308-a177-998107b76da7", "100", "1", "f4124e3b-4c27-4308-a177-998107b76da7", "100"
			}, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray50.Add(new AdventureItem(49, config99, config100, 3, 1, 1, 1, 10, 3, resCost50, itemCost49, restrictedByWorldPopulation: false, malice49, adventureParams45, "5a1babe9-7ae8-43d1-8626-e2ccf180374a", startNodes45, transferNodes43, endNodes43, baseBranches43, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray51 = _dataArray;
		string config101 = LocalStringManager.GetConfig("Adventure_language", "Name_50");
		string config102 = LocalStringManager.GetConfig("Adventure_language", "Desc_50");
		int[] resCost51 = new int[9] { 500, 0, 0, 0, 0, 0, 1000, 0, 0 };
		list = new List<int[]>();
		List<int[]> itemCost50 = list;
		short[] malice50 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams46 = list2;
		List<AdventureStartNode> startNodes46 = new List<AdventureStartNode>
		{
			new AdventureStartNode("0f8cb5e7-ff42-4963-bc85-6428b5f0dd41", "A", "LK_Adventure_NodeTitle_151", 9)
		};
		list3 = new List<AdventureTransferNode>();
		List<AdventureTransferNode> transferNodes44 = list3;
		List<AdventureEndNode> endNodes44 = new List<AdventureEndNode>
		{
			new AdventureEndNode("c44a15ca-cd6b-4fba-b030-fcc91181e40f", "B", "LK_Adventure_NodeTitle_152", 9)
		};
		List<AdventureBaseBranch> baseBranches44 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 5, "", new int[2] { 5, 100 }, new int[17]
			{
				2, 7, 9, 90, 5, 5, 80, 5, 5, 7,
				10, 10, 0, 0, 100, 0, 0
			}, new int[5] { 100, 100, 35, 100, 100 }, new string[7] { "0", "0", "1", "43dc9fac-bd1a-4708-941d-214d46f78c4c", "100", "0", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray51.Add(new AdventureItem(50, config101, config102, 3, 1, 1, 1, 10, 3, resCost51, itemCost50, restrictedByWorldPopulation: false, malice50, adventureParams46, "0a275245-f965-4759-b939-c10387671165", startNodes46, transferNodes44, endNodes44, baseBranches44, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray52 = _dataArray;
		string config103 = LocalStringManager.GetConfig("Adventure_language", "Name_51");
		string config104 = LocalStringManager.GetConfig("Adventure_language", "Desc_51");
		int[] resCost52 = new int[9] { 500, 0, 0, 0, 0, 0, 1000, 0, 0 };
		list = new List<int[]>();
		List<int[]> itemCost51 = list;
		short[] malice51 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams47 = list2;
		List<AdventureStartNode> startNodes47 = new List<AdventureStartNode>
		{
			new AdventureStartNode("ee130061-ac72-4063-9a28-e82794d422da", "A", "LK_Adventure_NodeTitle_153", 9)
		};
		list3 = new List<AdventureTransferNode>();
		List<AdventureTransferNode> transferNodes45 = list3;
		List<AdventureEndNode> endNodes45 = new List<AdventureEndNode>
		{
			new AdventureEndNode("9c6d403f-202b-403d-b36b-611b25fb0b9b", "B", "LK_Adventure_NodeTitle_154", 9)
		};
		List<AdventureBaseBranch> baseBranches45 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 5, "", new int[2] { 5, 100 }, new int[17]
			{
				2, 7, 9, 90, 5, 5, 80, 5, 5, 7,
				10, 10, 0, 0, 100, 0, 0
			}, new int[5] { 100, 100, 35, 100, 100 }, new string[7] { "0", "0", "1", "bd4814fc-f49b-4563-9e77-1a227afd9777", "100", "0", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray52.Add(new AdventureItem(51, config103, config104, 3, 1, 1, 0, 10, 3, resCost52, itemCost51, restrictedByWorldPopulation: false, malice51, adventureParams47, "fdb280d5-f1b7-4a86-b747-5c0c247f71e1", startNodes47, transferNodes45, endNodes45, baseBranches45, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray53 = _dataArray;
		string config105 = LocalStringManager.GetConfig("Adventure_language", "Name_52");
		string config106 = LocalStringManager.GetConfig("Adventure_language", "Desc_52");
		int[] resCost53 = new int[9] { 1000, 0, 0, 0, 0, 0, 2000, 0, 0 };
		list = new List<int[]>();
		List<int[]> itemCost52 = list;
		short[] malice52 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams48 = list2;
		List<AdventureStartNode> startNodes48 = new List<AdventureStartNode>
		{
			new AdventureStartNode("ee130061-ac72-4063-9a28-e82794d422da", "A", "LK_Adventure_NodeTitle_153", 9)
		};
		list3 = new List<AdventureTransferNode>();
		List<AdventureTransferNode> transferNodes46 = list3;
		List<AdventureEndNode> endNodes46 = new List<AdventureEndNode>
		{
			new AdventureEndNode("9c6d403f-202b-403d-b36b-611b25fb0b9b", "B", "LK_Adventure_NodeTitle_154", 9)
		};
		List<AdventureBaseBranch> baseBranches46 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 10, "", new int[2] { 5, 100 }, new int[17]
			{
				2, 7, 9, 90, 5, 5, 80, 5, 5, 7,
				10, 10, 0, 0, 100, 0, 0
			}, new int[5] { 100, 100, 40, 100, 100 }, new string[7] { "0", "0", "1", "bd4814fc-f49b-4563-9e77-1a227afd9777", "100", "0", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray53.Add(new AdventureItem(52, config105, config106, 3, 1, 3, 1, 10, 3, resCost53, itemCost52, restrictedByWorldPopulation: false, malice52, adventureParams48, "fdb280d5-f1b7-4a86-b747-5c0c247f71e1", startNodes48, transferNodes46, endNodes46, baseBranches46, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray54 = _dataArray;
		string config107 = LocalStringManager.GetConfig("Adventure_language", "Name_53");
		string config108 = LocalStringManager.GetConfig("Adventure_language", "Desc_53");
		int[] resCost54 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost53 = list;
		short[] malice53 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams49 = list2;
		List<AdventureStartNode> startNodes49 = new List<AdventureStartNode>
		{
			new AdventureStartNode("936f2fff-71ba-4899-8b42-a85d7cee5ca5", "A", "LK_Adventure_NodeTitle_155", 10),
			new AdventureStartNode("15e5eb0f-72b0-4ba6-8e3d-f70466787822", "E", "LK_Adventure_NodeTitle_155", 1)
		};
		List<AdventureTransferNode> transferNodes47 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("7a3fd5ba-8e45-49c4-95d6-bfa4ef11e78f", "B", "LK_Adventure_NodeTitle_156", 3),
			new AdventureTransferNode("5d5abf74-725b-45a7-bddd-f90c64e1c6c2", "C", "LK_Adventure_NodeTitle_157", 3),
			new AdventureTransferNode("20f4dc9f-1009-41ba-b2a3-9477ee2f707a", "F", "LK_Adventure_NodeTitle_156", 6),
			new AdventureTransferNode("098c87df-d231-4302-8f8a-58de9789766e", "G", "LK_Adventure_NodeTitle_157", 7)
		};
		List<AdventureEndNode> endNodes47 = new List<AdventureEndNode>
		{
			new AdventureEndNode("4cfd31ba-2296-4237-a7dc-01db81893aa5", "D", "LK_Adventure_NodeTitle_158", 6),
			new AdventureEndNode("21c45534-ade4-43c0-9a3d-a007c4de302a", "H", "LK_Adventure_NodeTitle_158", 8)
		};
		List<AdventureBaseBranch> baseBranches47 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 2, "1", 1, 3, "", new int[2] { 15, 100 }, new int[17]
			{
				2, 7, 9, 50, 10, 10, 50, 10, 10, 7,
				10, 50, 10, 10, 50, 10, 10
			}, new int[5] { 5, 5, 40, 5, 10 }, new string[7] { "0", "0", "1", "f2636e59-79cb-452a-b056-4b1fd7eb577e", "60", "0", "0" }, new int[32]
			{
				3, 0, 40, 5, 0, 60, 3, 0, 80, 2,
				3, 8, 200, 5, 8, 300, 3, 8, 400, 2,
				0, 3, 7, 20, 5, 7, 30, 3, 7, 40,
				2, 0
			}, new int[13]
			{
				0, 0, 0, 0, 2, 7, -702, 1, 10, 7,
				-701, 1, 10
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 3, "2", 1, 3, "", new int[2] { 15, 100 }, new int[17]
			{
				2, 7, 9, 50, 10, 10, 50, 10, 10, 7,
				10, 50, 0, 10, 50, 10, 10
			}, new int[5] { 5, 5, 40, 5, 10 }, new string[7] { "0", "0", "1", "02ebff00-510b-470e-b285-ef653a995146", "60", "0", "0" }, new int[32]
			{
				3, 0, 40, 5, 0, 60, 3, 0, 80, 2,
				3, 8, 200, 5, 8, 300, 3, 8, 400, 2,
				0, 3, 7, 20, 5, 7, 30, 3, 7, 40,
				2, 0
			}, new int[13]
			{
				0, 0, 0, 0, 2, 7, -702, 1, 10, 7,
				-701, 1, 10
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 6, "3", 1, 10, "", new int[2] { 15, 100 }, new int[17]
			{
				2, 7, 9, 50, 10, 10, 50, 10, 10, 7,
				10, 50, 10, 10, 50, 10, 10
			}, new int[5] { 5, 5, 20, 5, 10 }, new string[7] { "0", "0", "1", "8b48a7fd-f4f3-4dcd-8fb4-6c15545aaa70", "80", "0", "0" }, new int[32]
			{
				3, 0, 40, 5, 0, 60, 3, 0, 80, 2,
				3, 8, 200, 5, 8, 300, 3, 8, 400, 2,
				0, 3, 7, 20, 5, 7, 30, 3, 7, 40,
				2, 0
			}, new int[13]
			{
				0, 0, 0, 0, 2, 7, -702, 1, 10, 7,
				-701, 1, 10
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 4, "4", 1, 3, "", new int[2] { 15, 100 }, new int[17]
			{
				2, 7, 9, 50, 10, 10, 50, 10, 10, 7,
				10, 50, 10, 10, 50, 10, 10
			}, new int[5] { 5, 5, 40, 5, 10 }, new string[7] { "0", "0", "1", "4fdf9457-63b2-44d6-9a6c-e013ecc098bb", "60", "0", "0" }, new int[32]
			{
				3, 0, 40, 5, 0, 60, 3, 0, 80, 2,
				3, 8, 200, 5, 8, 300, 3, 8, 400, 2,
				0, 3, 7, 20, 5, 7, 30, 3, 7, 40,
				2, 0
			}, new int[13]
			{
				0, 0, 0, 0, 2, 7, -702, 1, 10, 7,
				-701, 1, 10
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(4, 5, "5", 1, 3, "", new int[2] { 15, 100 }, new int[17]
			{
				2, 7, 9, 50, 10, 10, 50, 10, 10, 7,
				10, 50, 0, 10, 50, 10, 10
			}, new int[5] { 5, 5, 40, 5, 10 }, new string[7] { "0", "0", "1", "02ebff00-510b-470e-b285-ef653a995146", "60", "0", "0" }, new int[32]
			{
				3, 0, 40, 5, 0, 60, 3, 0, 80, 2,
				3, 8, 200, 5, 8, 300, 3, 8, 400, 2,
				0, 3, 7, 20, 5, 7, 30, 3, 7, 40,
				2, 0
			}, new int[13]
			{
				0, 0, 0, 0, 2, 7, -702, 1, 10, 7,
				-701, 1, 10
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(5, 7, "6", 1, 5, "", new int[2] { 15, 100 }, new int[9] { 1, 7, 1, 100, 10, 10, 50, 10, 10 }, new int[5] { 5, 5, 20, 5, 10 }, new string[7] { "0", "0", "1", "8b48a7fd-f4f3-4dcd-8fb4-6c15545aaa70", "80", "0", "0" }, new int[32]
			{
				3, 0, 40, 5, 0, 60, 3, 0, 80, 2,
				3, 8, 200, 5, 8, 300, 3, 8, 400, 2,
				0, 3, 7, 20, 5, 7, 30, 3, 7, 40,
				2, 0
			}, new int[13]
			{
				0, 0, 0, 0, 2, 7, -702, 1, 10, 7,
				-701, 1, 10
			}, new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray54.Add(new AdventureItem(53, config107, config108, 3, 1, 3, 0, 10, 3, resCost54, itemCost53, restrictedByWorldPopulation: false, malice53, adventureParams49, "94389b5c-b9f3-4fb1-9f26-8743ef3d1201", startNodes49, transferNodes47, endNodes47, baseBranches47, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray55 = _dataArray;
		string config109 = LocalStringManager.GetConfig("Adventure_language", "Name_54");
		string config110 = LocalStringManager.GetConfig("Adventure_language", "Desc_54");
		int[] resCost55 = new int[9] { 1000, 0, 0, 0, 0, 0, 2000, 0, 0 };
		list = new List<int[]>();
		List<int[]> itemCost54 = list;
		short[] malice54 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams50 = list2;
		List<AdventureStartNode> startNodes50 = new List<AdventureStartNode>
		{
			new AdventureStartNode("0f8cb5e7-ff42-4963-bc85-6428b5f0dd41", "A", "LK_Adventure_NodeTitle_151", 9)
		};
		list3 = new List<AdventureTransferNode>();
		List<AdventureTransferNode> transferNodes48 = list3;
		List<AdventureEndNode> endNodes48 = new List<AdventureEndNode>
		{
			new AdventureEndNode("c44a15ca-cd6b-4fba-b030-fcc91181e40f", "B", "LK_Adventure_NodeTitle_152", 9)
		};
		List<AdventureBaseBranch> baseBranches48 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 10, "", new int[2] { 5, 100 }, new int[17]
			{
				2, 7, 9, 90, 5, 5, 80, 5, 5, 7,
				10, 10, 5, 5, 80, 5, 5
			}, new int[5] { 100, 100, 40, 100, 100 }, new string[7] { "0", "0", "1", "43dc9fac-bd1a-4708-941d-214d46f78c4c", "100", "0", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray55.Add(new AdventureItem(54, config109, config110, 3, 1, 3, 1, 10, 3, resCost55, itemCost54, restrictedByWorldPopulation: false, malice54, adventureParams50, "0a275245-f965-4759-b939-c10387671165", startNodes50, transferNodes48, endNodes48, baseBranches48, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray56 = _dataArray;
		string config111 = LocalStringManager.GetConfig("Adventure_language", "Name_55");
		string config112 = LocalStringManager.GetConfig("Adventure_language", "Desc_55");
		int[] resCost56 = new int[9] { 1500, 0, 0, 0, 0, 0, 3000, 0, 0 };
		list = new List<int[]>();
		List<int[]> itemCost55 = list;
		short[] malice55 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams51 = list2;
		List<AdventureStartNode> startNodes51 = new List<AdventureStartNode>
		{
			new AdventureStartNode("0f8cb5e7-ff42-4963-bc85-6428b5f0dd41", "A", "LK_Adventure_NodeTitle_151", 9)
		};
		list3 = new List<AdventureTransferNode>();
		List<AdventureTransferNode> transferNodes49 = list3;
		List<AdventureEndNode> endNodes49 = new List<AdventureEndNode>
		{
			new AdventureEndNode("c44a15ca-cd6b-4fba-b030-fcc91181e40f", "B", "LK_Adventure_NodeTitle_152", 9)
		};
		List<AdventureBaseBranch> baseBranches49 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 15, "", new int[2] { 5, 100 }, new int[17]
			{
				2, 7, 9, 90, 5, 5, 80, 5, 5, 7,
				10, 10, 0, 0, 100, 0, 0
			}, new int[5] { 100, 100, 45, 100, 100 }, new string[7] { "0", "0", "1", "43dc9fac-bd1a-4708-941d-214d46f78c4c", "100", "0", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray56.Add(new AdventureItem(55, config111, config112, 3, 1, 5, 0, 10, 3, resCost56, itemCost55, restrictedByWorldPopulation: false, malice55, adventureParams51, "0a275245-f965-4759-b939-c10387671165", startNodes51, transferNodes49, endNodes49, baseBranches49, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray57 = _dataArray;
		string config113 = LocalStringManager.GetConfig("Adventure_language", "Name_56");
		string config114 = LocalStringManager.GetConfig("Adventure_language", "Desc_56");
		int[] resCost57 = new int[9] { 1500, 0, 0, 0, 0, 0, 3000, 0, 0 };
		list = new List<int[]>();
		List<int[]> itemCost56 = list;
		short[] malice56 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams52 = list2;
		List<AdventureStartNode> startNodes52 = new List<AdventureStartNode>
		{
			new AdventureStartNode("ee130061-ac72-4063-9a28-e82794d422da", "A", "LK_Adventure_NodeTitle_153", 9)
		};
		list3 = new List<AdventureTransferNode>();
		List<AdventureTransferNode> transferNodes50 = list3;
		List<AdventureEndNode> endNodes50 = new List<AdventureEndNode>
		{
			new AdventureEndNode("9c6d403f-202b-403d-b36b-611b25fb0b9b", "B", "LK_Adventure_NodeTitle_154", 9)
		};
		List<AdventureBaseBranch> baseBranches50 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 15, "", new int[2] { 5, 100 }, new int[17]
			{
				2, 7, 9, 90, 5, 5, 80, 5, 5, 7,
				10, 10, 0, 0, 100, 0, 0
			}, new int[5] { 100, 100, 45, 100, 100 }, new string[7] { "0", "0", "1", "bd4814fc-f49b-4563-9e77-1a227afd9777", "100", "0", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray57.Add(new AdventureItem(56, config113, config114, 3, 1, 5, 1, 10, 3, resCost57, itemCost56, restrictedByWorldPopulation: false, malice56, adventureParams52, "fdb280d5-f1b7-4a86-b747-5c0c247f71e1", startNodes52, transferNodes50, endNodes50, baseBranches50, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray58 = _dataArray;
		string config115 = LocalStringManager.GetConfig("Adventure_language", "Name_57");
		string config116 = LocalStringManager.GetConfig("Adventure_language", "Desc_57");
		int[] resCost58 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost57 = list;
		short[] malice57 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams53 = list2;
		List<AdventureStartNode> startNodes53 = new List<AdventureStartNode>
		{
			new AdventureStartNode("0017a7bb-0448-4b51-89f0-333bd8e6d6fe", "A", "LK_Adventure_NodeTitle_159", 1)
		};
		list3 = new List<AdventureTransferNode>();
		List<AdventureTransferNode> transferNodes51 = list3;
		List<AdventureEndNode> endNodes51 = new List<AdventureEndNode>
		{
			new AdventureEndNode("498d6a28-3a7b-4bb3-a991-ddc09ca2b9d7", "B", "LK_Adventure_NodeTitle_160", 1)
		};
		List<AdventureBaseBranch> baseBranches51 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 10, "", new int[2] { 15, 100 }, new int[41]
			{
				5, 7, 3, 5, 15, 5, 15, 50, 15, 7,
				1, 50, 15, 5, 15, 50, 15, 7, 6, 20,
				15, 5, 15, 50, 15, 7, 5, 20, 15, 5,
				15, 50, 15, 7, 16, 5, 15, 5, 15, 50,
				15
			}, new int[5] { 100, 100, 100, 0, 100 }, new string[7] { "0", "0", "0", "1", "d3b109ba-24b4-48d9-8b14-b43cda4b1b84", "100", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray58.Add(new AdventureItem(57, config115, config116, 3, 7, 7, 0, 3, 3, resCost58, itemCost57, restrictedByWorldPopulation: false, malice57, adventureParams53, "d86d0d04-27e0-4b9c-918b-959ad9c03d95", startNodes53, transferNodes51, endNodes51, baseBranches51, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray59 = _dataArray;
		string config117 = LocalStringManager.GetConfig("Adventure_language", "Name_58");
		string config118 = LocalStringManager.GetConfig("Adventure_language", "Desc_58");
		int[] resCost59 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost58 = list;
		short[] malice58 = new short[3];
		list2 = new List<(string, string, string, string)>();
		dataArray59.Add(new AdventureItem(58, config117, config118, 4, 1, 1, 2, 10, -1, resCost59, itemCost58, restrictedByWorldPopulation: false, malice58, list2, "fd3a0a5f-18ab-473e-b6ca-7f77ea6dbaba", new List<AdventureStartNode>
		{
			new AdventureStartNode("2dbe8480-562b-461c-8da1-63b0084d9078", "0", "LK_Adventure_NodeTitle_161", 18)
		}, new List<AdventureTransferNode>
		{
			new AdventureTransferNode("ea6eec62-be89-46c8-b9d6-838845379ea8", "C", "LK_Adventure_NodeTitle_162", 14)
		}, new List<AdventureEndNode>
		{
			new AdventureEndNode("0d6e1cab-e124-4965-9119-241e8cf3e4bc", "A", "LK_Adventure_NodeTitle_163", 14),
			new AdventureEndNode("5b5bf247-f732-430e-966a-97f4bbd5d28c", "B", "LK_Adventure_NodeTitle_164", 14)
		}, new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(1, 3, "B", 2, 5, "", new int[4] { 8, 50, 9, 50 }, new int[33]
			{
				4, 7, 18, 50, 10, 20, 0, 60, 10, 7,
				17, 40, 10, 20, 10, 60, 0, 7, 6, 7,
				10, 20, 0, 60, 10, 7, 7, 3, 0, 20,
				10, 60, 10
			}, new int[5] { 10, 5, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "038f42b2-2739-43da-a283-ed7ef1d3f2d0", "30", "0" }, new int[32]
			{
				6, 1, 10, 5, 1, 20, 3, 1, 30, 2,
				4, 10, 5, 4, 20, 3, 4, 30, 2, 3,
				8, 25, 5, 8, 50, 3, 8, 75, 2, 0,
				0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "A", 1, 5, "", new int[4] { 8, 50, 9, 50 }, new int[33]
			{
				4, 7, 18, 50, 50, 20, 10, 10, 10, 7,
				17, 40, 50, 20, 10, 10, 10, 7, 6, 7,
				50, 20, 10, 10, 10, 7, 7, 3, 50, 20,
				10, 10, 10
			}, new int[5] { 30, 5, 10, 10, 10 }, new string[9] { "2", "5ec50422-fd0c-466d-bf4b-42710b92c7c1", "15", "40f80f98-1609-46ae-bb33-1b83a5afee82", "15", "0", "0", "0", "0" }, new int[41]
			{
				9, 1, 10, 5, 1, 20, 3, 1, 30, 2,
				4, 10, 5, 4, 20, 3, 4, 30, 2, 0,
				10, 5, 0, 20, 3, 0, 30, 2, 3, 8,
				25, 5, 8, 50, 3, 8, 75, 2, 0, 0,
				0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(0, 1, "0", 1, 3, "", new int[4] { 8, 50, 9, 50 }, new int[17]
			{
				2, 7, 18, 50, 10, 10, 60, 10, 10, 7,
				17, 50, 10, 10, 60, 10, 10
			}, new int[5] { 100, 10, 10, 10, 10 }, new string[7] { "0", "0", "1", "b0668734-f34f-43cc-9cd5-dad5efb96197", "30", "0", "0" }, new int[23]
			{
				6, 1, 10, 50, 1, 20, 30, 1, 30, 20,
				4, 25, 50, 4, 50, 30, 4, 75, 20, 0,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, new List<AdventureAdvancedBranch>
		{
			new AdventureAdvancedBranch(3, "", 1, 8, 50, new int[2] { 8, 50 }, new int[9] { 1, 7, 7, 10, 100, 0, 0, 0, 0 }, new int[5] { 0, 10, 10, 10, 10 }, new string[5] { "0", "0", "0", "0", "0" }, new int[32]
			{
				9, 0, 25, 8, 0, 100, 10, 0, 225, 2,
				1, 25, 4, 1, 100, 5, 1, 225, 1, 4,
				25, 4, 4, 100, 5, 4, 225, 1, 0, 0,
				0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray60 = _dataArray;
		string config119 = LocalStringManager.GetConfig("Adventure_language", "Name_59");
		string config120 = LocalStringManager.GetConfig("Adventure_language", "Desc_59");
		int[] resCost60 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost59 = list;
		short[] malice59 = new short[3];
		list2 = new List<(string, string, string, string)>();
		dataArray60.Add(new AdventureItem(59, config119, config120, 4, 1, 1, 2, 10, -1, resCost60, itemCost59, restrictedByWorldPopulation: false, malice59, list2, "09531ca9-d493-4a05-8604-5d8d4cc412a9", new List<AdventureStartNode>
		{
			new AdventureStartNode("4ad91b10-b0a6-46c5-9cdd-49b4ae898051", "A", "LK_Adventure_NodeTitle_165", 12)
		}, new List<AdventureTransferNode>
		{
			new AdventureTransferNode("ae22f9a9-1760-4f30-87be-0abcef58b029", "B", "LK_Adventure_NodeTitle_166", 13)
		}, new List<AdventureEndNode>
		{
			new AdventureEndNode("bc965608-3048-4ec7-8a03-cd45fa2d576f", "C", "LK_Adventure_NodeTitle_167", 13),
			new AdventureEndNode("3ade3295-fc78-47fc-bccb-8410cb334b53", "D", "LK_Adventure_NodeTitle_168", 13)
		}, new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 10, "", new int[8] { 6, 25, 7, 25, 10, 25, 11, 25 }, new int[17]
			{
				2, 7, 11, 50, 50, 20, 10, 10, 10, 7,
				12, 50, 50, 20, 10, 10, 10
			}, new int[5] { 25, 50, 100, 50, 100 }, new string[11]
			{
				"3", "3778a612-3c09-48f0-9e06-8406e48347b9", "10", "bfdf43bb-7fe3-4747-ac82-97a5f71df0d6", "10", "2ece16e6-6bb5-4e74-9342-a0db104c9384", "100", "0", "0", "0",
				"0"
			}, new int[32]
			{
				6, 2, 20, 5, 2, 40, 3, 2, 60, 2,
				3, 20, 5, 3, 40, 3, 3, 60, 2, 3,
				8, 50, 50, 8, 100, 30, 0, 150, 20, 0,
				0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "1", 1, 5, "", new int[8] { 6, 25, 7, 25, 10, 25, 11, 25 }, new int[33]
			{
				4, 7, 13, 50, 60, 10, 10, 10, 10, 7,
				7, 10, 60, 10, 10, 10, 10, 7, 17, 20,
				60, 10, 10, 10, 10, 7, 12, 20, 60, 10,
				10, 10, 10
			}, new int[5] { 50, 60, 50, 60, 60 }, new string[13]
			{
				"4", "1129b22b-0f75-4bfd-aa04-aa9410eca9c0", "10", "40e748dd-9dd3-46a5-8fe4-8b378c1f9ac6", "10", "4d5b6890-0e8c-4beb-a4cf-e27e01889341", "10", "593e9fe3-1358-4341-8108-c4d464af7f63", "10", "0",
				"0", "0", "0"
			}, new int[32]
			{
				6, 2, 20, 5, 2, 40, 3, 2, 60, 2,
				3, 20, 5, 3, 40, 3, 3, 60, 2, 0,
				3, 6, 100, 50, 6, 200, 30, 6, 300, 20,
				0, 0
			}, new int[9] { 0, 0, 1, 2, -201, 1, 50, 0, 0 }, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 3, "2", 1, 5, "", new int[8] { 6, 25, 7, 25, 10, 25, 11, 25 }, new int[33]
			{
				4, 7, 13, 50, 10, 10, 10, 50, 20, 7,
				7, 10, 10, 10, 10, 50, 20, 7, 17, 20,
				10, 10, 10, 50, 20, 7, 12, 20, 10, 10,
				10, 50, 20
			}, new int[5] { 100, 50, 100, 20, 20 }, new string[13]
			{
				"0", "0", "0", "1", "8ffbfe76-5c1e-45c6-9b2b-9ba44f83ffaf", "30", "3", "ecf6073d-2842-433a-964f-47d80e9694ce", "10", "48f6eb2b-093b-4fd4-9e46-197e3b4c9e71",
				"10", "a2851004-fcf4-4d31-9acc-3e8ea60ddfb5", "10"
			}, new int[32]
			{
				6, 2, 20, 50, 2, 40, 30, 2, 60, 20,
				3, 20, 50, 3, 40, 30, 3, 60, 20, 3,
				8, 50, 50, 8, 100, 30, 0, 150, 20, 0,
				0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, new List<AdventureAdvancedBranch>
		{
			new AdventureAdvancedBranch(3, "", 1, 6, 50, new int[8] { 6, 25, 7, 25, 11, 25, 10, 25 }, new int[9] { 1, 7, 13, 100, 100, 0, 0, 0, 0 }, new int[5] { 0, 10, 10, 10, 10 }, new string[5] { "0", "0", "0", "0", "0" }, new int[23]
			{
				6, 6, 250, 45, 6, 500, 5, 2, 100, 45,
				2, 225, 5, 3, 100, 45, 3, 225, 5, 0,
				0, 0, 0
			}, new int[9] { 1, 2, -201, 1, 50, 0, 0, 0, 0 }, new string[5] { "0", "0", "0", "0", "0" })
		}, difficultyAddXiangshuLevel: false));
	}

	private void CreateItems1()
	{
		List<AdventureItem> dataArray = _dataArray;
		string config = LocalStringManager.GetConfig("Adventure_language", "Name_60");
		string config2 = LocalStringManager.GetConfig("Adventure_language", "Desc_60");
		int[] resCost = new int[9];
		List<int[]> list = new List<int[]>();
		List<int[]> itemCost = list;
		short[] malice = new short[3];
		List<(string, string, string, string)> adventureParams = new List<(string, string, string, string)>();
		dataArray.Add(new AdventureItem(60, config, config2, 4, 2, 2, 2, 10, -1, resCost, itemCost, restrictedByWorldPopulation: false, malice, adventureParams, "3f979bfd-131d-4815-95f5-c786943123e5", new List<AdventureStartNode>
		{
			new AdventureStartNode("248b4d58-4acf-414f-87a9-8c7662ec196d", "A", "LK_Adventure_NodeTitle_169", 1)
		}, new List<AdventureTransferNode>
		{
			new AdventureTransferNode("5879f0f0-9de6-42e5-b20f-fc62ab2329b8", "C", "LK_Adventure_NodeTitle_170", 13),
			new AdventureTransferNode("c88d71d4-e717-4930-98af-292fe5a85e38", "B", "LK_Adventure_NodeTitle_171", 13)
		}, new List<AdventureEndNode>
		{
			new AdventureEndNode("51d7f7b2-dc12-4a7f-bba0-ab3f673c939d", "D", "LK_Adventure_NodeTitle_172", 13),
			new AdventureEndNode("dddefe3c-1017-4f82-924e-6db1ba922f4d", "G", "LK_Adventure_NodeTitle_173", 13),
			new AdventureEndNode("dddefe3c-1017-4f82-924e-6db1ba922f4d", "F", "LK_Adventure_NodeTitle_173", 13)
		}, new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 2, "1", 1, 2, "", new int[4] { 15, 50, 8, 50 }, new int[25]
			{
				3, 7, 1, 40, 5, 20, 20, 50, 5, 7,
				13, 40, 5, 20, 20, 50, 5, 7, 3, 20,
				5, 20, 20, 50, 5
			}, new int[5] { 10, 50, 20, 10, 10 }, new string[7] { "0", "0", "0", "1", "834abf94-d2f2-416d-8d35-b25b011b56e4", "30", "0" }, new int[14]
			{
				0, 3, 8, 50, 50, 8, 100, 30, 8, 150,
				20, 0, 0, 0
			}, new int[85]
			{
				0, 0, 20, 0, -1, 1, 2, 0, -2, 1,
				2, 0, -3, 1, 2, 0, -4, 1, 2, 0,
				-5, 1, 2, 0, -6, 1, 2, 0, -7, 1,
				2, 0, -8, 1, 2, 0, -9, 1, 2, 0,
				-10, 1, 2, 0, -11, 1, 2, 0, -12, 1,
				2, 0, -13, 1, 2, 0, -14, 1, 2, 0,
				-15, 1, 2, 0, -16, 1, 2, 1, -101, 1,
				2, 1, -102, 1, 2, 1, -103, 1, 2, 1,
				-104, 1, 2, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 1, "2", 1, 5, "", new int[4] { 15, 50, 8, 50 }, new int[25]
			{
				3, 7, 1, 40, 10, 15, 15, 50, 10, 7,
				13, 40, 10, 15, 15, 50, 10, 7, 3, 20,
				10, 15, 15, 50, 10
			}, new int[5] { 10, 50, 20, 20, 10 }, new string[7] { "0", "0", "0", "1", "834abf94-d2f2-416d-8d35-b25b011b56e4", "30", "0" }, new int[14]
			{
				0, 3, 8, 50, 50, 8, 100, 30, 8, 150,
				20, 0, 0, 0
			}, new int[85]
			{
				0, 0, 20, 0, -1, 1, 2, 0, -2, 1,
				2, 0, -3, 1, 2, 0, -4, 1, 2, 0,
				-5, 1, 2, 0, -6, 1, 2, 0, -7, 1,
				2, 0, -8, 1, 2, 0, -9, 1, 2, 0,
				-10, 1, 2, 0, -11, 1, 2, 0, -12, 1,
				2, 0, -13, 1, 2, 0, -14, 1, 2, 0,
				-15, 1, 2, 0, -16, 1, 2, 1, -101, 1,
				2, 1, -102, 1, 2, 1, -103, 1, 2, 1,
				-104, 1, 2, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 4, "3", 1, 10, "", new int[4] { 15, 50, 8, 50 }, new int[33]
			{
				4, 7, 1, 50, 5, 15, 15, 60, 5, 7,
				13, 50, 5, 15, 15, 60, 5, 7, 3, 10,
				5, 15, 15, 60, 5, 7, 17, 10, 5, 15,
				15, 60, 5
			}, new int[5] { 10, 50, 20, 20, 10 }, new string[7] { "0", "0", "0", "1", "d0a2105d-12b6-4b8f-908e-fe6c15fd79bf", "30", "0" }, new int[14]
			{
				0, 3, 8, 20, 50, 8, 40, 30, 8, 60,
				20, 0, 0, 0
			}, new int[85]
			{
				0, 0, 20, 0, -1, 1, 2, 0, -2, 1,
				2, 0, -3, 1, 2, 0, -4, 1, 2, 0,
				-5, 1, 2, 0, -6, 1, 2, 0, -7, 1,
				2, 0, -8, 1, 2, 0, -9, 1, 2, 0,
				-10, 1, 2, 0, -11, 1, 2, 0, -12, 1,
				2, 0, -13, 1, 2, 0, -14, 1, 2, 0,
				-15, 1, 2, 0, -16, 1, 2, 1, -101, 1,
				2, 1, -102, 1, 2, 1, -103, 1, 2, 1,
				-104, 1, 2, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 3, "4", 1, 5, "", new int[4] { 15, 50, 8, 50 }, new int[25]
			{
				3, 7, 1, 40, 10, 15, 15, 50, 10, 7,
				13, 40, 10, 15, 15, 50, 10, 7, 3, 20,
				10, 15, 15, 50, 10
			}, new int[5] { 10, 50, 20, 20, 10 }, new string[7] { "0", "0", "0", "1", "834abf94-d2f2-416d-8d35-b25b011b56e4", "30", "0" }, new int[14]
			{
				0, 3, 8, 50, 50, 8, 100, 30, 8, 150,
				20, 0, 0, 0
			}, new int[85]
			{
				0, 0, 20, 0, -1, 1, 2, 0, -2, 1,
				2, 0, -3, 1, 2, 0, -4, 1, 2, 0,
				-5, 1, 2, 0, -6, 1, 2, 0, -7, 1,
				2, 0, -8, 1, 2, 0, -9, 1, 2, 0,
				-10, 1, 2, 0, -11, 1, 2, 0, -12, 1,
				2, 0, -13, 1, 2, 0, -14, 1, 2, 0,
				-15, 1, 2, 0, -16, 1, 2, 1, -101, 1,
				2, 1, -102, 1, 2, 1, -103, 1, 2, 1,
				-104, 1, 2, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 5, "5", 1, 5, "", new int[4] { 15, 50, 8, 50 }, new int[33]
			{
				4, 7, 1, 50, 5, 15, 15, 60, 5, 7,
				13, 50, 5, 15, 15, 60, 5, 7, 3, 10,
				5, 15, 15, 60, 5, 7, 17, 10, 5, 15,
				15, 60, 5
			}, new int[5] { 10, 50, 20, 20, 10 }, new string[7] { "0", "0", "0", "1", "d0a2105d-12b6-4b8f-908e-fe6c15fd79bf", "30", "0" }, new int[14]
			{
				0, 3, 8, 20, 50, 8, 40, 30, 8, 60,
				20, 0, 0, 0
			}, new int[85]
			{
				0, 0, 20, 0, -1, 1, 2, 0, -2, 1,
				2, 0, -3, 1, 2, 0, -4, 1, 2, 0,
				-5, 1, 2, 0, -6, 1, 2, 0, -7, 1,
				2, 0, -8, 1, 2, 0, -9, 1, 2, 0,
				-10, 1, 2, 0, -11, 1, 2, 0, -12, 1,
				2, 0, -13, 1, 2, 0, -14, 1, 2, 0,
				-15, 1, 2, 0, -16, 1, 2, 1, -101, 1,
				2, 1, -102, 1, 2, 1, -103, 1, 2, 1,
				-104, 1, 2, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" })
		}, new List<AdventureAdvancedBranch>
		{
			new AdventureAdvancedBranch(2, "", 1, 8, 100, new int[2] { 8, 100 }, new int[9] { 1, 7, 3, 100, 0, 0, 0, 100, 0 }, new int[5] { 10, 10, 10, 0, 10 }, new string[5] { "0", "0", "0", "0", "0" }, new int[5], new int[81]
			{
				0, 0, 0, 19, 0, -1, 1, 3, 0, -2,
				1, 3, 0, -3, 1, 3, 0, -4, 1, 3,
				0, -5, 1, 6, 0, -6, 1, 3, 0, -7,
				1, 2, 0, -8, 1, 2, 0, -9, 1, 5,
				0, -10, 1, 5, 0, -11, 1, 5, 0, -12,
				1, 3, 0, -13, 1, 1, 0, -14, 1, 1,
				0, -15, 1, 1, 1, -101, 1, 3, 1, -102,
				1, 4, 1, -103, 1, 4, 1, -104, 1, 3,
				0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureAdvancedBranch(2, "", 3, 8, 100, new int[2] { 8, 100 }, new int[9] { 1, 7, 3, 100, 0, 0, 0, 100, 0 }, new int[5] { 10, 10, 10, 0, 10 }, new string[5] { "0", "0", "0", "0", "0" }, new int[5], new int[81]
			{
				0, 0, 0, 19, 0, -1, 1, 3, 0, -2,
				1, 3, 0, -3, 1, 3, 0, -4, 1, 3,
				0, -5, 1, 6, 0, -6, 1, 3, 0, -7,
				1, 2, 0, -8, 1, 2, 0, -9, 1, 5,
				0, -10, 1, 5, 0, -11, 1, 5, 0, -12,
				1, 3, 0, -13, 1, 1, 0, -14, 1, 1,
				0, -15, 1, 1, 1, -101, 1, 3, 1, -102,
				1, 4, 1, -103, 1, 4, 1, -104, 1, 3,
				0
			}, new string[5] { "0", "0", "0", "0", "0" })
		}, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray2 = _dataArray;
		string config3 = LocalStringManager.GetConfig("Adventure_language", "Name_61");
		string config4 = LocalStringManager.GetConfig("Adventure_language", "Desc_61");
		int[] resCost2 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost2 = list;
		short[] malice2 = new short[3];
		List<(string, string, string, string)> adventureParams2 = new List<(string, string, string, string)>
		{
			("dies", "LK_Adventure_61_ParamName_0", "", ""),
			("surrender", "LK_Adventure_61_ParamName_1", "", ""),
			("slip", "LK_Adventure_61_ParamName_2", "", "")
		};
		List<AdventureStartNode> startNodes = new List<AdventureStartNode>
		{
			new AdventureStartNode("55659cd5-0bc8-4af1-baae-bb70c18f5bbe", "A", "LK_Adventure_NodeTitle_177", 2)
		};
		List<AdventureTransferNode> transferNodes = new List<AdventureTransferNode>();
		dataArray2.Add(new AdventureItem(61, config3, config4, 4, 3, 3, 2, 10, -1, resCost2, itemCost2, restrictedByWorldPopulation: false, malice2, adventureParams2, "e70c6ae8-b8ab-45d5-a4fd-35f2668b52ca", startNodes, transferNodes, new List<AdventureEndNode>
		{
			new AdventureEndNode("2aed95dd-beb8-439b-82fb-a7e6bf7a2ae2", "B", "LK_Adventure_NodeTitle_178", 2)
		}, new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 5, 10, "", new int[6] { 15, 50, 1, 25, 2, 25 }, new int[41]
			{
				5, 7, 1, 30, 5, 10, 10, 70, 5, 7,
				2, 30, 5, 10, 10, 70, 5, 7, 3, 20,
				5, 10, 10, 70, 5, 7, 5, 10, 5, 10,
				10, 70, 5, 7, 7, 10, 0, 10, 10, 70,
				5
			}, new int[5] { 10, 50, 25, 15, 10 }, new string[7] { "0", "0", "0", "1", "140971f1-b9bd-4227-b2dc-3d3c0fc661e8", "30", "0" }, new int[14]
			{
				0, 3, 8, 100, 50, 8, 150, 30, 8, 200,
				20, 0, 0, 0
			}, new int[9] { 0, 0, 1, 10, -1002, 1, 50, 0, 0 }, new string[5] { "0", "0", "0", "0", "0" })
		}, new List<AdventureAdvancedBranch>
		{
			new AdventureAdvancedBranch(5, "", 0, 15, 150, new int[2] { 15, 100 }, new int[9] { 1, 7, 7, 100, 0, 100, 0, 0, 0 }, new int[5] { 10, 0, 10, 10, 10 }, new string[5] { "0", "0", "0", "0", "0" }, new int[5], new int[9] { 0, 1, 10, -1002, 1, 100, 0, 0, 0 }, new string[5] { "0", "0", "0", "0", "0" })
		}, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray3 = _dataArray;
		string config5 = LocalStringManager.GetConfig("Adventure_language", "Name_62");
		string config6 = LocalStringManager.GetConfig("Adventure_language", "Desc_62");
		int[] resCost3 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost3 = list;
		short[] malice3 = new short[3];
		adventureParams = new List<(string, string, string, string)>();
		dataArray3.Add(new AdventureItem(62, config5, config6, 4, 4, 4, 2, 10, -1, resCost3, itemCost3, restrictedByWorldPopulation: false, malice3, adventureParams, "93532864-ab12-46e2-916c-0ff603c1f6bd", new List<AdventureStartNode>
		{
			new AdventureStartNode("f00ab12c-1dfc-4eb0-864e-12672161622d", "A", "LK_Adventure_NodeTitle_179", 2)
		}, new List<AdventureTransferNode>
		{
			new AdventureTransferNode("af43cf88-c9b1-4e56-aebb-ddb2575a1493", "B", "LK_Adventure_NodeTitle_180", 8),
			new AdventureTransferNode("fdef6811-7924-4050-bf87-5367abb54cd9", "C", "LK_Adventure_NodeTitle_181", 16)
		}, new List<AdventureEndNode>
		{
			new AdventureEndNode("0fc135c1-1f05-4e5f-97a8-2f93a69296d0", "D", "LK_Adventure_NodeTitle_182", 7)
		}, new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 2, 5, "", new int[6] { 14, 50, 12, 25, 13, 25 }, new int[41]
			{
				5, 7, 2, 30, 5, 65, 10, 15, 5, 7,
				2, 10, 5, 65, 10, 15, 5, 7, 7, 30,
				5, 65, 10, 15, 5, 7, 11, 20, 5, 65,
				10, 15, 5, 7, 17, 10, 5, 65, 10, 15,
				5
			}, new int[5] { 10, 20, 25, 10, 10 }, new string[9] { "0", "1", "b16093c4-1e5d-49d4-8c2e-97edc38f58e3", "30", "0", "1", "8bc7ff3e-7ee0-4d26-93fb-0db7c74aec30", "10", "0" }, new int[14]
			{
				0, 3, 8, 200, 5, 8, 300, 3, 8, 400,
				2, 0, 0, 0
			}, new int[13]
			{
				0, 0, 2, 8, -801, 1, 25, 8, -802, 1,
				25, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 2, 5, "", new int[6] { 14, 50, 12, 25, 13, 25 }, new int[41]
			{
				5, 7, 2, 30, 5, 65, 10, 15, 5, 7,
				2, 10, 5, 65, 10, 15, 5, 7, 7, 30,
				5, 65, 10, 15, 5, 7, 11, 20, 5, 65,
				10, 15, 5, 7, 17, 10, 5, 65, 10, 15,
				5
			}, new int[5] { 10, 0, 25, 10, 10 }, new string[9] { "0", "1", "41561cbd-9f76-43fd-bc77-814d9b804db8", "30", "0", "1", "8bc7ff3e-7ee0-4d26-93fb-0db7c74aec30", "10", "0" }, new int[14]
			{
				0, 3, 8, 200, 5, 8, 300, 3, 8, 400,
				2, 0, 0, 0
			}, new int[13]
			{
				0, 0, 2, 8, -801, 1, 25, 8, -802, 1,
				25, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 3, "3", 2, 5, "", new int[6] { 14, 50, 12, 25, 13, 25 }, new int[41]
			{
				5, 7, 2, 30, 5, 65, 10, 15, 5, 7,
				2, 10, 5, 65, 10, 15, 5, 7, 7, 30,
				5, 65, 10, 15, 5, 7, 11, 20, 5, 65,
				10, 15, 5, 7, 17, 10, 5, 65, 10, 15,
				5
			}, new int[5] { 10, 20, 10, 10, 10 }, new string[9] { "0", "1", "8f99be97-f495-4d6e-9555-0c4eecfde6e5", "30", "0", "1", "8bc7ff3e-7ee0-4d26-93fb-0db7c74aec30", "10", "0" }, new int[14]
			{
				0, 3, 8, 200, 5, 8, 300, 3, 8, 400,
				2, 0, 0, 0
			}, new int[13]
			{
				0, 0, 2, 8, -801, 1, 25, 8, -802, 1,
				25, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" })
		}, new List<AdventureAdvancedBranch>
		{
			new AdventureAdvancedBranch(2, "", 2, 14, 200, new int[2] { 14, 100 }, new int[9] { 1, 7, 7, 100, 100, 0, 0, 0, 0 }, new int[5] { 0, 10, 10, 10, 10 }, new string[5] { "0", "0", "0", "0", "0" }, new int[5], new int[13]
			{
				2, 8, -801, 1, 50, 8, -802, 1, 50, 0,
				0, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" })
		}, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray4 = _dataArray;
		string config7 = LocalStringManager.GetConfig("Adventure_language", "Name_63");
		string config8 = LocalStringManager.GetConfig("Adventure_language", "Desc_63");
		int[] resCost4 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost4 = list;
		short[] malice4 = new short[3];
		adventureParams = new List<(string, string, string, string)>();
		dataArray4.Add(new AdventureItem(63, config7, config8, 4, 4, 4, 2, 10, -1, resCost4, itemCost4, restrictedByWorldPopulation: false, malice4, adventureParams, "5a0bf59b-c72d-4332-8be6-722c1fa57d5c", new List<AdventureStartNode>
		{
			new AdventureStartNode("9781f81e-de43-484c-b19d-6fe93667b4dd", "A", "LK_Adventure_NodeTitle_183", 10)
		}, new List<AdventureTransferNode>
		{
			new AdventureTransferNode("096d8c6e-adb7-4269-951f-765d2e5f3b3b", "B", "LK_Adventure_NodeTitle_184", 4),
			new AdventureTransferNode("6ca9a8ad-8832-44db-ac74-3377ae1d5ff8", "D", "LK_Adventure_NodeTitle_185", 9),
			new AdventureTransferNode("4b2185aa-d029-4b1d-94c9-928595de093c", "C", "LK_Adventure_NodeTitle_186", 9),
			new AdventureTransferNode("a07fd455-2c5b-496d-b448-169e477a0351", "E", "LK_Adventure_NodeTitle_187", 9),
			new AdventureTransferNode("bbcce351-7a08-4c88-a92c-cb7826bcf19b", "F", "LK_Adventure_NodeTitle_188", 9)
		}, new List<AdventureEndNode>
		{
			new AdventureEndNode("d1fb9cbe-3000-4b43-a886-748fa5a9ef40", "G", "LK_Adventure_NodeTitle_189", 20),
			new AdventureEndNode("a949c400-9828-47ae-b117-2d3dd3af7e14", "K", "LK_Adventure_NodeTitle_189", 20),
			new AdventureEndNode("a949c400-9828-47ae-b117-2d3dd3af7e14", "H", "LK_Adventure_NodeTitle_189", 20),
			new AdventureEndNode("a949c400-9828-47ae-b117-2d3dd3af7e14", "I", "LK_Adventure_NodeTitle_189", 20),
			new AdventureEndNode("a949c400-9828-47ae-b117-2d3dd3af7e14", "J", "LK_Adventure_NodeTitle_189", 20),
			new AdventureEndNode("a949c400-9828-47ae-b117-2d3dd3af7e14", "L", "LK_Adventure_NodeTitle_189", 20)
		}, new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 2, "", new int[6] { 5, 50, 0, 25, 3, 25 }, new int[10] { 3, 2, 10, 50, 2, 3, 25, 2, 11, 25 }, new int[5] { 10, 10, 10, 10, 10 }, new string[5] { "0", "0", "0", "0", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 3, "2", 1, 3, "", new int[6] { 5, 50, 0, 25, 3, 25 }, new int[25]
			{
				3, 7, 10, 30, 5, 25, 60, 5, 5, 7,
				9, 50, 5, 25, 60, 5, 5, 7, 7, 20,
				5, 25, 60, 5, 5
			}, new int[5] { 10, 0, 10, 10, 10 }, new string[7] { "0", "0", "1", "8bd56234-d571-4462-ba15-38bc1469ec2c", "30", "0", "0" }, new int[14]
			{
				0, 3, 8, 200, 50, 8, 300, 30, 8, 400,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 2, 9, -901, 1, 2, 9, -902, 1,
				2, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 2, "3", 1, 5, "", new int[6] { 5, 50, 0, 25, 3, 25 }, new int[25]
			{
				3, 7, 9, 50, 5, 25, 60, 5, 5, 7,
				10, 30, 5, 25, 60, 5, 5, 7, 7, 20,
				5, 25, 60, 5, 5
			}, new int[5] { 10, 0, 15, 10, 10 }, new string[7] { "0", "0", "1", "b4ee02b7-82e6-4d95-985a-4191353fffad", "30", "0", "0" }, new int[14]
			{
				0, 3, 8, 200, 50, 8, 300, 30, 8, 400,
				20, 0, 0, 0
			}, new int[21]
			{
				0, 0, 4, 9, -901, 1, 2, 9, -902, 1,
				2, 7, -701, 1, 2, 7, -702, 1, 2, 0,
				0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 4, "4", 1, 5, "", new int[6] { 5, 50, 0, 25, 3, 25 }, new int[25]
			{
				3, 7, 10, 30, 5, 25, 50, 5, 5, 7,
				9, 50, 5, 25, 50, 5, 5, 7, 7, 20,
				5, 25, 50, 5, 5
			}, new int[5] { 10, 0, 15, 10, 10 }, new string[7] { "0", "0", "1", "cfb11701-e7c7-4b83-ab52-239943772956", "30", "0", "0" }, new int[14]
			{
				0, 3, 8, 200, 50, 8, 300, 30, 8, 400,
				20, 0, 0, 0
			}, new int[21]
			{
				0, 0, 4, 7, -701, 1, 2, 7, -702, 1,
				2, 9, -901, 1, 2, 9, -902, 1, 2, 0,
				0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(4, 5, "5", 1, 5, "", new int[6] { 5, 50, 0, 25, 3, 25 }, new int[25]
			{
				3, 7, 10, 30, 5, 25, 50, 5, 5, 7,
				9, 50, 5, 25, 50, 5, 5, 7, 7, 20,
				5, 25, 50, 5, 5
			}, new int[5] { 10, 0, 15, 10, 10 }, new string[7] { "0", "0", "1", "3fe82642-c3a4-4f3b-a1e9-c3372ec8f76d", "30", "0", "0" }, new int[14]
			{
				0, 3, 8, 200, 50, 8, 300, 30, 8, 400,
				20, 0, 0, 0
			}, new int[21]
			{
				0, 0, 4, 9, -901, 1, 2, 9, -902, 1,
				2, 7, -701, 1, 2, 7, -702, 1, 2, 0,
				0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(5, 6, "6", 1, 3, "", new int[6] { 5, 50, 0, 25, 3, 25 }, new int[33]
			{
				4, 7, 3, 10, 10, 10, 10, 60, 10, 7,
				10, 50, 10, 10, 10, 60, 10, 7, 11, 30,
				10, 10, 10, 60, 10, 7, 20, 10, 10, 10,
				10, 60, 10
			}, new int[5] { 10, 10, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "77c071ba-ddb0-4b21-8cc1-79af1c4780b5", "30", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 7, "10", 1, 10, "", new int[6] { 5, 50, 0, 25, 3, 25 }, new int[33]
			{
				4, 7, 10, 50, 5, 10, 10, 70, 5, 7,
				3, 10, 5, 10, 10, 70, 5, 7, 11, 30,
				5, 10, 10, 70, 5, 7, 20, 10, 5, 10,
				10, 70, 5
			}, new int[5] { 10, 0, 4, 15, 10 }, new string[7] { "0", "0", "0", "1", "77c071ba-ddb0-4b21-8cc1-79af1c4780b5", "30", "0" }, new int[14]
			{
				0, 3, 8, 200, 50, 8, 300, 30, 8, 400,
				20, 0, 0, 0
			}, new int[21]
			{
				0, 0, 4, 9, -901, 1, 2, 9, -902, 1,
				2, 7, -701, 1, 2, 7, -702, 1, 2, 0,
				0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 8, "7", 1, 10, "", new int[6] { 5, 50, 0, 25, 3, 25 }, new int[33]
			{
				4, 7, 10, 50, 5, 10, 10, 70, 5, 7,
				3, 10, 5, 10, 10, 70, 5, 7, 11, 30,
				5, 10, 10, 70, 5, 7, 20, 10, 5, 10,
				10, 70, 5
			}, new int[5] { 10, 0, 4, 15, 10 }, new string[7] { "0", "0", "0", "1", "77c071ba-ddb0-4b21-8cc1-79af1c4780b5", "30", "0" }, new int[14]
			{
				0, 3, 8, 200, 50, 8, 300, 30, 8, 400,
				20, 0, 0, 0
			}, new int[21]
			{
				0, 0, 4, 9, -901, 1, 2, 9, -902, 1,
				2, 7, -701, 1, 2, 7, -702, 1, 2, 0,
				0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(4, 9, "8", 1, 10, "", new int[6] { 5, 50, 0, 25, 3, 25 }, new int[33]
			{
				4, 7, 10, 50, 5, 10, 10, 70, 5, 7,
				3, 10, 5, 10, 10, 70, 5, 7, 11, 30,
				5, 10, 10, 70, 5, 7, 20, 10, 5, 10,
				10, 70, 5
			}, new int[5] { 10, 0, 4, 15, 10 }, new string[7] { "0", "0", "0", "1", "77c071ba-ddb0-4b21-8cc1-79af1c4780b5", "30", "0" }, new int[14]
			{
				0, 3, 8, 200, 50, 8, 300, 30, 8, 400,
				20, 0, 0, 0
			}, new int[21]
			{
				0, 0, 4, 9, -901, 1, 2, 9, -902, 1,
				2, 7, -701, 1, 2, 7, -702, 1, 2, 0,
				0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(5, 10, "9", 1, 10, "", new int[6] { 5, 50, 0, 25, 3, 25 }, new int[33]
			{
				4, 7, 10, 50, 5, 10, 10, 70, 5, 7,
				3, 10, 5, 10, 10, 70, 5, 7, 11, 30,
				5, 10, 10, 70, 5, 7, 20, 10, 5, 10,
				10, 70, 5
			}, new int[5] { 10, 0, 4, 15, 10 }, new string[7] { "0", "0", "0", "1", "77c071ba-ddb0-4b21-8cc1-79af1c4780b5", "30", "0" }, new int[14]
			{
				0, 3, 8, 200, 50, 8, 300, 30, 8, 400,
				20, 0, 0, 0
			}, new int[21]
			{
				0, 0, 4, 9, -901, 1, 2, 9, -902, 1,
				2, 7, -701, 1, 2, 7, -702, 1, 2, 0,
				0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 11, "11", 1, 10, "", new int[6] { 5, 50, 0, 25, 3, 25 }, new int[33]
			{
				4, 7, 10, 50, 5, 10, 10, 70, 5, 7,
				3, 10, 5, 10, 10, 70, 5, 7, 11, 30,
				5, 10, 10, 70, 5, 7, 20, 10, 5, 10,
				10, 70, 5
			}, new int[5] { 10, 0, 4, 15, 10 }, new string[7] { "0", "0", "0", "1", "77c071ba-ddb0-4b21-8cc1-79af1c4780b5", "30", "0" }, new int[14]
			{
				0, 3, 8, 200, 50, 8, 300, 30, 8, 400,
				20, 0, 0, 0
			}, new int[21]
			{
				0, 0, 4, 9, -901, 1, 2, 9, -902, 1,
				2, 7, -701, 1, 2, 7, -702, 1, 2, 0,
				0
			}, new string[5] { "0", "0", "0", "0", "0" })
		}, new List<AdventureAdvancedBranch>
		{
			new AdventureAdvancedBranch(2, "", 3, 5, 200, new int[2] { 5, 50 }, new int[9] { 1, 7, 10, 100, 0, 0, 100, 0, 0 }, new int[5] { 10, 10, 0, 10, 10 }, new string[7] { "0", "0", "1", "29e13d0c-8d2a-4eee-b7d7-ed2a29c4a488", "100", "0", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureAdvancedBranch(2, "", 4, 15, 200, new int[2] { 15, 100 }, new int[9] { 1, 7, 10, 100, 0, 0, 100, 0, 0 }, new int[5] { 10, 10, 0, 10, 10 }, new string[7] { "0", "0", "1", "29e13d0c-8d2a-4eee-b7d7-ed2a29c4a488", "100", "0", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray5 = _dataArray;
		string config9 = LocalStringManager.GetConfig("Adventure_language", "Name_64");
		string config10 = LocalStringManager.GetConfig("Adventure_language", "Desc_64");
		int[] resCost5 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost5 = list;
		short[] malice5 = new short[3];
		adventureParams = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams3 = adventureParams;
		List<AdventureStartNode> startNodes2 = new List<AdventureStartNode>
		{
			new AdventureStartNode("100c2db7-cfc0-4670-a85b-4e7ebb7abdba", "0", "LK_Adventure_NodeTitle_190", 18)
		};
		List<AdventureTransferNode> transferNodes2 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("0f54a6de-d79d-46a3-a22d-459d8788e935", "ZhenZhong", "LK_Adventure_NodeTitle_191", 11),
			new AdventureTransferNode("c3408ea6-f474-40a5-9916-39dc29f80dca", "ShuiKou1a", "LK_Adventure_NodeTitle_192", 4),
			new AdventureTransferNode("f4e8f859-b6d7-4be9-a6f9-a791e6ca11ad", "QiMai1c", "LK_Adventure_NodeTitle_192", 11),
			new AdventureTransferNode("65b5651f-06dc-4fc6-b03e-339a4d8a64f6", "MingTang1b", "LK_Adventure_NodeTitle_192", 18),
			new AdventureTransferNode("65b5651f-06dc-4fc6-b03e-339a4d8a64f6", "MingTang2a", "LK_Adventure_NodeTitle_192", 18),
			new AdventureTransferNode("f4e8f859-b6d7-4be9-a6f9-a791e6ca11ad", "QiMai2a", "LK_Adventure_NodeTitle_192", 11),
			new AdventureTransferNode("c3408ea6-f474-40a5-9916-39dc29f80dca", "ShuiKou2c", "LK_Adventure_NodeTitle_192", 4),
			new AdventureTransferNode("722e5a99-7c87-4c38-8ea2-0fffb5166f4b", "LieDu2b", "LK_Adventure_NodeTitle_193", 4),
			new AdventureTransferNode("722e5a99-7c87-4c38-8ea2-0fffb5166f4b", "LieDu2c", "LK_Adventure_NodeTitle_193", 4),
			new AdventureTransferNode("722e5a99-7c87-4c38-8ea2-0fffb5166f4b", "LieDu1a", "LK_Adventure_NodeTitle_193", 4),
			new AdventureTransferNode("722e5a99-7c87-4c38-8ea2-0fffb5166f4b", "YuDu1a", "LK_Adventure_NodeTitle_193", 4),
			new AdventureTransferNode("4df6ea32-e96b-4e0b-964e-4615bb2bf350", "FuDu1c", "LK_Adventure_NodeTitle_194", 11),
			new AdventureTransferNode("4df6ea32-e96b-4e0b-964e-4615bb2bf350", "HuanDu1c", "LK_Adventure_NodeTitle_194", 11),
			new AdventureTransferNode("37deacdf-3d35-46f3-9322-9eab54b47c22", "ChiDu1b", "LK_Adventure_NodeTitle_195", 18),
			new AdventureTransferNode("37deacdf-3d35-46f3-9322-9eab54b47c22", "HanDu1b", "LK_Adventure_NodeTitle_195", 18),
			new AdventureTransferNode("722e5a99-7c87-4c38-8ea2-0fffb5166f4b", "YuDu2c", "LK_Adventure_NodeTitle_193", 4),
			new AdventureTransferNode("65b5651f-06dc-4fc6-b03e-339a4d8a64f6", "MingTang3c", "LK_Adventure_NodeTitle_192", 18),
			new AdventureTransferNode("f4e8f859-b6d7-4be9-a6f9-a791e6ca11ad", "QiMai3b", "LK_Adventure_NodeTitle_192", 11),
			new AdventureTransferNode("37deacdf-3d35-46f3-9322-9eab54b47c22", "HanDu3c", "LK_Adventure_NodeTitle_195", 18),
			new AdventureTransferNode("37deacdf-3d35-46f3-9322-9eab54b47c22", "ChiDu3c", "LK_Adventure_NodeTitle_195", 18),
			new AdventureTransferNode("4df6ea32-e96b-4e0b-964e-4615bb2bf350", "FuDu3b", "LK_Adventure_NodeTitle_194", 11),
			new AdventureTransferNode("4df6ea32-e96b-4e0b-964e-4615bb2bf350", "HuanDu3b", "LK_Adventure_NodeTitle_194", 11),
			new AdventureTransferNode("722e5a99-7c87-4c38-8ea2-0fffb5166f4b", "LieDu3c", "LK_Adventure_NodeTitle_193", 4),
			new AdventureTransferNode("722e5a99-7c87-4c38-8ea2-0fffb5166f4b", "YuDu3c", "LK_Adventure_NodeTitle_193", 4),
			new AdventureTransferNode("37deacdf-3d35-46f3-9322-9eab54b47c22", "HanDu2a", "LK_Adventure_NodeTitle_195", 18),
			new AdventureTransferNode("37deacdf-3d35-46f3-9322-9eab54b47c22", "ChiDu2a", "LK_Adventure_NodeTitle_195", 18),
			new AdventureTransferNode("f4e8f859-b6d7-4be9-a6f9-a791e6ca11ad", "QiMai3a", "LK_Adventure_NodeTitle_192", 11),
			new AdventureTransferNode("4df6ea32-e96b-4e0b-964e-4615bb2bf350", "FuDu3a", "LK_Adventure_NodeTitle_194", 11),
			new AdventureTransferNode("4df6ea32-e96b-4e0b-964e-4615bb2bf350", "HuanDu3a", "LK_Adventure_NodeTitle_194", 11),
			new AdventureTransferNode("4df6ea32-e96b-4e0b-964e-4615bb2bf350", "FuDu2a", "LK_Adventure_NodeTitle_194", 11),
			new AdventureTransferNode("4df6ea32-e96b-4e0b-964e-4615bb2bf350", "HuanDu2a", "LK_Adventure_NodeTitle_194", 11),
			new AdventureTransferNode("65b5651f-06dc-4fc6-b03e-339a4d8a64f6", "MingTang3a", "LK_Adventure_NodeTitle_192", 18),
			new AdventureTransferNode("37deacdf-3d35-46f3-9322-9eab54b47c22", "HanDu3a", "LK_Adventure_NodeTitle_195", 18),
			new AdventureTransferNode("37deacdf-3d35-46f3-9322-9eab54b47c22", "ChiDu3a", "LK_Adventure_NodeTitle_195", 18),
			new AdventureTransferNode("722e5a99-7c87-4c38-8ea2-0fffb5166f4b", "YuDu2b", "LK_Adventure_NodeTitle_193", 4),
			new AdventureTransferNode("c3408ea6-f474-40a5-9916-39dc29f80dca", "ShuiKou2b", "LK_Adventure_NodeTitle_192", 4),
			new AdventureTransferNode("f4e8f859-b6d7-4be9-a6f9-a791e6ca11ad", "QiMai2b", "LK_Adventure_NodeTitle_192", 11),
			new AdventureTransferNode("4df6ea32-e96b-4e0b-964e-4615bb2bf350", "FuDu2b", "LK_Adventure_NodeTitle_194", 11),
			new AdventureTransferNode("4df6ea32-e96b-4e0b-964e-4615bb2bf350", "HuanDu2b", "LK_Adventure_NodeTitle_194", 11),
			new AdventureTransferNode("c3408ea6-f474-40a5-9916-39dc29f80dca", "ShuiKou3b", "LK_Adventure_NodeTitle_192", 4),
			new AdventureTransferNode("722e5a99-7c87-4c38-8ea2-0fffb5166f4b", "LieDu3b", "LK_Adventure_NodeTitle_193", 4),
			new AdventureTransferNode("722e5a99-7c87-4c38-8ea2-0fffb5166f4b", "YuDu3b", "LK_Adventure_NodeTitle_193", 4),
			new AdventureTransferNode("65b5651f-06dc-4fc6-b03e-339a4d8a64f6", "MingTang2c", "LK_Adventure_NodeTitle_192", 18),
			new AdventureTransferNode("37deacdf-3d35-46f3-9322-9eab54b47c22", "HanDu2c", "LK_Adventure_NodeTitle_195", 18),
			new AdventureTransferNode("37deacdf-3d35-46f3-9322-9eab54b47c22", "ChiDu2c", "LK_Adventure_NodeTitle_195", 18),
			new AdventureTransferNode("c3408ea6-f474-40a5-9916-39dc29f80dca", "ShuiKou3c", "LK_Adventure_NodeTitle_192", 4)
		};
		List<AdventureEndNode> endNodes = new List<AdventureEndNode>
		{
			new AdventureEndNode("75759577-87ee-4cb8-8af2-b019ccf9442d", "1", "LK_Adventure_NodeTitle_196", 20)
		};
		List<AdventureBaseBranch> baseBranches = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(10, 6, "ToQiMai", 1, 3, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 1, 30, 40, 10, 5, 40, 5, 7,
				11, 30, 40, 10, 5, 40, 5, 7, 17, 10,
				40, 10, 5, 40, 5, 7, 18, 10, 40, 10,
				5, 40, 5, 7, 4, 20, 40, 10, 5, 40,
				5
			}, new int[5] { 10, 0, 10, 10, 10 }, new string[9] { "1", "71653d8a-6f89-4cbd-ac49-d281c12478ba", "30", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "20", "0" }, new int[17]
			{
				0, 4, 8, 250, 35, 8, 500, 30, 8, 1000,
				25, 8, 1500, 10, 0, 0, 0
			}, new int[13]
			{
				0, 0, 0, 2, 5, -506, 1, 5, 5, -507,
				1, 5, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(11, 5, "ToMingTang", 1, 3, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 17, 20, 40, 10, 5, 30, 10, 7,
				18, 50, 40, 10, 5, 30, 10, 7, 4, 10,
				40, 10, 5, 30, 10, 7, 6, 5, 40, 10,
				5, 30, 10, 7, 11, 15, 40, 10, 5, 30,
				10
			}, new int[5] { 10, 0, 10, 10, 0 }, new string[9] { "1", "6f2e5851-2092-4293-a4fb-3f0a8b6fa4cb", "30", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 0, 0, 2, 5, -506, 1, 25, 5,
				-507, 1, 25
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(10, 5, "ToMingTang", 1, 3, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 17, 20, 40, 10, 5, 30, 10, 7,
				18, 50, 40, 10, 5, 30, 10, 7, 4, 10,
				40, 10, 5, 30, 10, 7, 6, 5, 40, 10,
				5, 30, 10, 7, 11, 15, 40, 10, 5, 30,
				10
			}, new int[5] { 10, 0, 10, 10, 0 }, new string[9] { "1", "6f2e5851-2092-4293-a4fb-3f0a8b6fa4cb", "30", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 0, 0, 2, 5, -506, 1, 25, 5,
				-507, 1, 25
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(11, 6, "ToQiMai", 1, 3, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 1, 30, 40, 10, 5, 40, 5, 7,
				11, 30, 40, 10, 5, 40, 5, 7, 17, 10,
				40, 10, 5, 40, 5, 7, 18, 10, 40, 10,
				5, 40, 5, 7, 4, 20, 40, 10, 5, 40,
				5
			}, new int[5] { 10, 0, 10, 10, 10 }, new string[9] { "1", "71653d8a-6f89-4cbd-ac49-d281c12478ba", "30", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "20", "0" }, new int[17]
			{
				0, 4, 8, 250, 35, 8, 500, 30, 8, 1000,
				25, 8, 1500, 10, 0, 0, 0
			}, new int[13]
			{
				0, 0, 0, 2, 5, -506, 1, 5, 5, -507,
				1, 5, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 10, "LieDu", 1, 3, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 17, 15, 40, 10, 5, 30, 10, 7,
				18, 20, 40, 10, 5, 30, 10, 7, 4, 40,
				40, 10, 5, 30, 10, 7, 6, 5, 40, 10,
				5, 30, 10, 7, 11, 20, 40, 10, 5, 30,
				10
			}, new int[5] { 10, 0, 10, 10, 0 }, new string[9] { "1", "f07cfe8d-ba2c-442a-872f-e8f9d05e582f", "30", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 0, 0, 2, 5, -506, 1, 25, 5,
				-507, 1, 25
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 11, "YuDu", 1, 3, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 17, 15, 40, 10, 5, 30, 10, 7,
				18, 20, 40, 10, 5, 30, 10, 7, 4, 40,
				40, 10, 5, 30, 10, 7, 6, 5, 40, 10,
				5, 30, 10, 7, 11, 20, 40, 10, 5, 30,
				10
			}, new int[5] { 10, 0, 10, 10, 0 }, new string[9] { "1", "f07cfe8d-ba2c-442a-872f-e8f9d05e582f", "30", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 0, 0, 2, 5, -506, 1, 25, 5,
				-507, 1, 25
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(7, 16, "YuDu", 1, 3, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 17, 15, 40, 10, 5, 30, 10, 7,
				18, 20, 40, 10, 5, 30, 10, 7, 4, 40,
				40, 10, 5, 30, 10, 7, 6, 5, 40, 10,
				5, 30, 10, 7, 11, 20, 40, 10, 5, 30,
				10
			}, new int[5] { 10, 0, 10, 10, 0 }, new string[9] { "1", "f07cfe8d-ba2c-442a-872f-e8f9d05e582f", "30", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 0, 0, 2, 5, -506, 1, 25, 5,
				-507, 1, 25
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(8, 18, "ToQiMai", 1, 3, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 1, 30, 40, 10, 5, 40, 5, 7,
				11, 30, 40, 10, 5, 40, 5, 7, 17, 10,
				40, 10, 5, 40, 5, 7, 18, 10, 40, 10,
				5, 40, 5, 7, 4, 20, 40, 10, 5, 40,
				5
			}, new int[5] { 10, 0, 10, 10, 10 }, new string[9] { "1", "71653d8a-6f89-4cbd-ac49-d281c12478ba", "30", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "20", "0" }, new int[17]
			{
				0, 4, 8, 250, 35, 8, 500, 30, 8, 1000,
				25, 8, 1500, 10, 0, 0, 0
			}, new int[13]
			{
				0, 0, 0, 2, 5, -506, 1, 5, 5, -507,
				1, 5, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(18, 21, "FuDu", 1, 3, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 1, 30, 40, 10, 5, 40, 5, 7,
				11, 30, 40, 10, 5, 40, 5, 7, 17, 10,
				40, 10, 5, 40, 5, 7, 18, 10, 40, 10,
				5, 40, 5, 7, 4, 20, 40, 10, 5, 40,
				5
			}, new int[5] { 10, 0, 10, 10, 10 }, new string[9] { "1", "71653d8a-6f89-4cbd-ac49-d281c12478ba", "30", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "20", "0" }, new int[17]
			{
				0, 4, 8, 250, 35, 8, 500, 30, 8, 1000,
				25, 8, 1500, 10, 0, 0, 0
			}, new int[13]
			{
				0, 0, 0, 2, 5, -506, 1, 5, 5, -507,
				1, 5, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(18, 22, "HuanDu", 1, 3, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 1, 30, 40, 10, 5, 40, 5, 7,
				11, 30, 40, 10, 5, 40, 5, 7, 17, 10,
				40, 10, 5, 40, 5, 7, 18, 10, 40, 10,
				5, 40, 5, 7, 4, 20, 40, 10, 5, 40,
				5
			}, new int[5] { 10, 0, 10, 10, 10 }, new string[9] { "1", "71653d8a-6f89-4cbd-ac49-d281c12478ba", "30", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "20", "0" }, new int[17]
			{
				0, 4, 8, 250, 35, 8, 500, 30, 8, 1000,
				25, 8, 1500, 10, 0, 0, 0
			}, new int[13]
			{
				0, 0, 0, 2, 5, -506, 1, 5, 5, -507,
				1, 5, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(17, 19, "HanDu", 1, 3, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 17, 20, 40, 10, 5, 30, 10, 7,
				18, 50, 40, 10, 5, 30, 10, 7, 4, 10,
				40, 10, 5, 30, 10, 7, 6, 5, 40, 10,
				5, 30, 10, 7, 11, 15, 40, 10, 5, 30,
				10
			}, new int[5] { 10, 0, 10, 10, 0 }, new string[9] { "1", "6f2e5851-2092-4293-a4fb-3f0a8b6fa4cb", "30", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 0, 0, 2, 5, -506, 1, 25, 5,
				-507, 1, 25
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(17, 20, "ChiDu", 1, 3, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 17, 20, 40, 10, 5, 30, 10, 7,
				18, 50, 40, 10, 5, 30, 10, 7, 4, 10,
				40, 10, 5, 30, 10, 7, 6, 5, 40, 10,
				5, 30, 10, 7, 11, 15, 40, 10, 5, 30,
				10
			}, new int[5] { 10, 0, 10, 10, 0 }, new string[9] { "1", "6f2e5851-2092-4293-a4fb-3f0a8b6fa4cb", "30", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 0, 0, 2, 5, -506, 1, 25, 5,
				-507, 1, 25
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(19, 47, "ToEnd", 1, 2, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 17, 30, 10, 10, 10, 60, 10, 7,
				18, 30, 10, 10, 10, 60, 10, 7, 1, 15,
				10, 10, 10, 60, 10, 7, 11, 15, 10, 10,
				10, 60, 10, 7, 4, 10, 10, 10, 10, 60,
				10
			}, new int[5] { 10, 0, 0, 20, 10 }, new string[7] { "0", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 2, 5, -506, 1, 25, 5, -507, 1,
				25, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(22, 47, "ToEnd", 1, 2, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 17, 30, 10, 10, 10, 60, 10, 7,
				18, 30, 10, 10, 10, 60, 10, 7, 1, 15,
				10, 10, 10, 60, 10, 7, 11, 15, 10, 10,
				10, 60, 10, 7, 4, 10, 10, 10, 10, 60,
				10
			}, new int[5] { 10, 0, 0, 20, 10 }, new string[7] { "0", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 2, 5, -506, 1, 25, 5, -507, 1,
				25, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(21, 47, "ToEnd", 1, 2, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 17, 30, 10, 10, 10, 60, 10, 7,
				18, 30, 10, 10, 10, 60, 10, 7, 1, 15,
				10, 10, 10, 60, 10, 7, 11, 15, 10, 10,
				10, 60, 10, 7, 4, 10, 10, 10, 10, 60,
				10
			}, new int[5] { 10, 0, 0, 20, 10 }, new string[7] { "0", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 2, 5, -506, 1, 25, 5, -507, 1,
				25, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(20, 47, "ToEnd", 1, 2, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 17, 30, 10, 10, 10, 60, 10, 7,
				18, 30, 10, 10, 10, 60, 10, 7, 1, 15,
				10, 10, 10, 60, 10, 7, 11, 15, 10, 10,
				10, 60, 10, 7, 4, 10, 10, 10, 10, 60,
				10
			}, new int[5] { 10, 0, 0, 20, 10 }, new string[7] { "0", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 2, 5, -506, 1, 25, 5, -507, 1,
				25, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(0, 1, "0", 1, 2, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[33]
			{
				4, 7, 17, 40, 10, 10, 10, 50, 20, 7,
				18, 30, 10, 10, 10, 50, 20, 7, 11, 20,
				10, 10, 10, 50, 20, 7, 4, 10, 10, 20,
				10, 50, 20
			}, new int[5] { 10, 10, 10, 20, 0 }, new string[7] { "0", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "30", "0" }, new int[5], new int[13]
			{
				0, 0, 0, 0, 2, 5, -506, 1, 25, 5,
				-507, 1, 25
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "ToShuiKou", 1, 3, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 17, 15, 40, 10, 5, 30, 10, 7,
				18, 20, 40, 10, 5, 30, 10, 7, 4, 40,
				40, 10, 5, 30, 10, 7, 6, 5, 40, 10,
				5, 30, 10, 7, 11, 20, 40, 10, 5, 30,
				10
			}, new int[5] { 10, 0, 10, 10, 0 }, new string[9] { "1", "f07cfe8d-ba2c-442a-872f-e8f9d05e582f", "30", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 0, 0, 2, 5, -506, 1, 25, 5,
				-507, 1, 25
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 4, "ToMingTang", 1, 3, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 17, 20, 40, 10, 5, 30, 10, 7,
				18, 50, 40, 10, 5, 30, 10, 7, 4, 10,
				40, 10, 5, 30, 10, 7, 6, 5, 40, 10,
				5, 30, 10, 7, 11, 15, 40, 10, 5, 30,
				10
			}, new int[5] { 10, 0, 10, 10, 0 }, new string[9] { "1", "6f2e5851-2092-4293-a4fb-3f0a8b6fa4cb", "30", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 0, 0, 2, 5, -506, 1, 25, 5,
				-507, 1, 25
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(4, 15, "HanDu", 1, 3, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 17, 20, 40, 10, 5, 30, 10, 7,
				18, 50, 40, 10, 5, 30, 10, 7, 4, 10,
				40, 10, 5, 30, 10, 7, 6, 5, 40, 10,
				5, 30, 10, 7, 11, 15, 40, 10, 5, 30,
				10
			}, new int[5] { 10, 0, 10, 10, 0 }, new string[9] { "1", "6f2e5851-2092-4293-a4fb-3f0a8b6fa4cb", "30", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 0, 0, 2, 5, -506, 1, 25, 5,
				-507, 1, 25
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(4, 14, "ChiDu", 1, 3, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 17, 20, 40, 10, 5, 30, 10, 7,
				18, 50, 40, 10, 5, 30, 10, 7, 4, 10,
				40, 10, 5, 30, 10, 7, 6, 5, 40, 10,
				5, 30, 10, 7, 11, 15, 40, 10, 5, 30,
				10
			}, new int[5] { 10, 0, 10, 10, 0 }, new string[9] { "1", "6f2e5851-2092-4293-a4fb-3f0a8b6fa4cb", "30", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 0, 0, 2, 5, -506, 1, 25, 5,
				-507, 1, 25
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 3, "ToQiMai", 1, 3, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 1, 30, 40, 10, 5, 40, 5, 7,
				11, 30, 40, 10, 5, 40, 5, 7, 17, 10,
				40, 10, 5, 40, 5, 7, 18, 10, 40, 10,
				5, 40, 5, 7, 4, 20, 40, 10, 5, 40,
				5
			}, new int[5] { 10, 0, 10, 10, 10 }, new string[9] { "1", "71653d8a-6f89-4cbd-ac49-d281c12478ba", "30", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "20", "0" }, new int[17]
			{
				0, 4, 8, 250, 35, 8, 500, 30, 8, 1000,
				25, 8, 1500, 10, 0, 0, 0
			}, new int[13]
			{
				0, 0, 0, 2, 5, -506, 1, 5, 5, -507,
				1, 5, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(13, 43, "ToMingTang", 1, 3, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 17, 20, 40, 10, 5, 30, 10, 7,
				18, 50, 40, 10, 5, 30, 10, 7, 4, 10,
				40, 10, 5, 30, 10, 7, 6, 5, 40, 10,
				5, 30, 10, 7, 11, 15, 40, 10, 5, 30,
				10
			}, new int[5] { 10, 0, 10, 10, 0 }, new string[9] { "1", "6f2e5851-2092-4293-a4fb-3f0a8b6fa4cb", "30", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 0, 0, 2, 5, -506, 1, 25, 5,
				-507, 1, 25
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(12, 7, "ToShuiKou", 1, 3, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 17, 15, 40, 10, 5, 30, 10, 7,
				18, 20, 40, 10, 5, 30, 10, 7, 4, 40,
				40, 10, 5, 30, 10, 7, 6, 5, 40, 10,
				5, 30, 10, 7, 11, 20, 40, 10, 5, 30,
				10
			}, new int[5] { 10, 0, 10, 10, 0 }, new string[9] { "1", "f07cfe8d-ba2c-442a-872f-e8f9d05e582f", "30", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 0, 0, 2, 5, -506, 1, 25, 5,
				-507, 1, 25
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(23, 47, "ToEnd", 1, 2, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 17, 30, 10, 10, 10, 60, 10, 7,
				18, 30, 10, 10, 10, 60, 10, 7, 1, 15,
				10, 10, 10, 60, 10, 7, 11, 15, 10, 10,
				10, 60, 10, 7, 4, 10, 10, 10, 10, 60,
				10
			}, new int[5] { 10, 0, 0, 20, 10 }, new string[7] { "0", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 2, 5, -506, 1, 25, 5, -507, 1,
				25, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(24, 47, "ToEnd", 1, 2, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 17, 30, 10, 10, 10, 60, 10, 7,
				18, 30, 10, 10, 10, 60, 10, 7, 1, 15,
				10, 10, 10, 60, 10, 7, 11, 15, 10, 10,
				10, 60, 10, 7, 4, 10, 10, 10, 10, 60,
				10
			}, new int[5] { 10, 0, 0, 20, 10 }, new string[7] { "0", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 2, 5, -506, 1, 25, 5, -507, 1,
				25, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 13, "HuanDu", 1, 3, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 1, 30, 40, 10, 5, 40, 5, 7,
				11, 30, 40, 10, 5, 40, 5, 7, 17, 10,
				40, 10, 5, 40, 5, 7, 18, 10, 40, 10,
				5, 40, 5, 7, 4, 20, 40, 10, 5, 40,
				5
			}, new int[5] { 10, 0, 10, 10, 10 }, new string[9] { "1", "71653d8a-6f89-4cbd-ac49-d281c12478ba", "30", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "20", "0" }, new int[17]
			{
				0, 4, 8, 250, 35, 8, 500, 30, 8, 1000,
				25, 8, 1500, 10, 0, 0, 0
			}, new int[13]
			{
				0, 0, 0, 2, 5, -506, 1, 5, 5, -507,
				1, 5, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 12, "FuDu", 1, 3, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 1, 30, 40, 10, 5, 40, 5, 7,
				11, 30, 40, 10, 5, 40, 5, 7, 17, 10,
				40, 10, 5, 40, 5, 7, 18, 10, 40, 10,
				5, 40, 5, 7, 4, 20, 40, 10, 5, 40,
				5
			}, new int[5] { 10, 0, 10, 10, 10 }, new string[9] { "1", "71653d8a-6f89-4cbd-ac49-d281c12478ba", "30", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "20", "0" }, new int[17]
			{
				0, 4, 8, 250, 35, 8, 500, 30, 8, 1000,
				25, 8, 1500, 10, 0, 0, 0
			}, new int[13]
			{
				0, 0, 0, 2, 5, -506, 1, 5, 5, -507,
				1, 5, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(5, 25, "HanDu", 1, 3, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 17, 20, 40, 10, 5, 30, 10, 7,
				18, 50, 40, 10, 5, 30, 10, 7, 4, 10,
				40, 10, 5, 30, 10, 7, 6, 5, 40, 10,
				5, 30, 10, 7, 11, 15, 40, 10, 5, 30,
				10
			}, new int[5] { 10, 0, 10, 10, 0 }, new string[9] { "1", "6f2e5851-2092-4293-a4fb-3f0a8b6fa4cb", "30", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 0, 0, 2, 5, -506, 1, 25, 5,
				-507, 1, 25
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(5, 26, "ChiDu", 1, 3, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 17, 20, 40, 10, 5, 30, 10, 7,
				18, 50, 40, 10, 5, 30, 10, 7, 4, 10,
				40, 10, 5, 30, 10, 7, 6, 5, 40, 10,
				5, 30, 10, 7, 11, 15, 40, 10, 5, 30,
				10
			}, new int[5] { 10, 0, 10, 10, 0 }, new string[9] { "1", "6f2e5851-2092-4293-a4fb-3f0a8b6fa4cb", "30", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 0, 0, 2, 5, -506, 1, 25, 5,
				-507, 1, 25
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(25, 27, "ToQiMai", 1, 3, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 1, 30, 40, 10, 5, 40, 5, 7,
				11, 30, 40, 10, 5, 40, 5, 7, 17, 10,
				40, 10, 5, 40, 5, 7, 18, 10, 40, 10,
				5, 40, 5, 7, 4, 20, 40, 10, 5, 40,
				5
			}, new int[5] { 10, 0, 10, 10, 10 }, new string[9] { "1", "71653d8a-6f89-4cbd-ac49-d281c12478ba", "30", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "20", "0" }, new int[17]
			{
				0, 4, 8, 250, 35, 8, 500, 30, 8, 1000,
				25, 8, 1500, 10, 0, 0, 0
			}, new int[13]
			{
				0, 0, 0, 2, 5, -506, 1, 5, 5, -507,
				1, 5, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(26, 27, "ToQiMai", 1, 3, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 1, 30, 40, 10, 5, 40, 5, 7,
				11, 30, 40, 10, 5, 40, 5, 7, 17, 10,
				40, 10, 5, 40, 5, 7, 18, 10, 40, 10,
				5, 40, 5, 7, 4, 20, 40, 10, 5, 40,
				5
			}, new int[5] { 10, 0, 10, 10, 10 }, new string[9] { "1", "71653d8a-6f89-4cbd-ac49-d281c12478ba", "30", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "20", "0" }, new int[17]
			{
				0, 4, 8, 250, 35, 8, 500, 30, 8, 1000,
				25, 8, 1500, 10, 0, 0, 0
			}, new int[13]
			{
				0, 0, 0, 2, 5, -506, 1, 5, 5, -507,
				1, 5, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(27, 28, "FuDu", 1, 3, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 1, 30, 40, 10, 5, 40, 5, 7,
				11, 30, 40, 10, 5, 40, 5, 7, 17, 10,
				40, 10, 5, 40, 5, 7, 18, 10, 40, 10,
				5, 40, 5, 7, 4, 20, 40, 10, 5, 40,
				5
			}, new int[5] { 10, 0, 10, 10, 10 }, new string[9] { "1", "71653d8a-6f89-4cbd-ac49-d281c12478ba", "30", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "20", "0" }, new int[17]
			{
				0, 4, 8, 250, 35, 8, 500, 30, 8, 1000,
				25, 8, 1500, 10, 0, 0, 0
			}, new int[13]
			{
				0, 0, 0, 2, 5, -506, 1, 5, 5, -507,
				1, 5, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(27, 29, "HuanDu", 1, 3, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 1, 30, 40, 10, 5, 40, 5, 7,
				11, 30, 40, 10, 5, 40, 5, 7, 17, 10,
				40, 10, 5, 40, 5, 7, 18, 10, 40, 10,
				5, 40, 5, 7, 4, 20, 40, 10, 5, 40,
				5
			}, new int[5] { 10, 0, 10, 10, 10 }, new string[9] { "1", "71653d8a-6f89-4cbd-ac49-d281c12478ba", "30", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "20", "0" }, new int[17]
			{
				0, 4, 8, 250, 35, 8, 500, 30, 8, 1000,
				25, 8, 1500, 10, 0, 0, 0
			}, new int[13]
			{
				0, 0, 0, 2, 5, -506, 1, 5, 5, -507,
				1, 5, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(28, 47, "ToEnd", 1, 2, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 17, 30, 10, 10, 10, 60, 10, 7,
				18, 30, 10, 10, 10, 60, 10, 7, 1, 15,
				10, 10, 10, 60, 10, 7, 11, 15, 10, 10,
				10, 60, 10, 7, 4, 10, 10, 10, 10, 60,
				10
			}, new int[5] { 10, 0, 0, 20, 10 }, new string[7] { "0", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 2, 5, -506, 1, 25, 5, -507, 1,
				25, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(29, 47, "ToEnd", 1, 2, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 17, 30, 10, 10, 10, 60, 10, 7,
				18, 30, 10, 10, 10, 60, 10, 7, 1, 15,
				10, 10, 10, 60, 10, 7, 11, 15, 10, 10,
				10, 60, 10, 7, 4, 10, 10, 10, 10, 60,
				10
			}, new int[5] { 10, 0, 0, 20, 10 }, new string[7] { "0", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 2, 5, -506, 1, 25, 5, -507, 1,
				25, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(6, 30, "FuDu", 1, 3, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 1, 30, 40, 10, 5, 40, 5, 7,
				11, 30, 40, 10, 5, 40, 5, 7, 17, 10,
				40, 10, 5, 40, 5, 7, 18, 10, 40, 10,
				5, 40, 5, 7, 4, 20, 40, 10, 5, 40,
				5
			}, new int[5] { 10, 0, 10, 10, 10 }, new string[9] { "1", "71653d8a-6f89-4cbd-ac49-d281c12478ba", "30", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "20", "0" }, new int[17]
			{
				0, 4, 8, 250, 35, 8, 500, 30, 8, 1000,
				25, 8, 1500, 10, 0, 0, 0
			}, new int[13]
			{
				0, 0, 0, 2, 5, -506, 1, 5, 5, -507,
				1, 5, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(6, 31, "HuanDu", 1, 3, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 1, 30, 40, 10, 5, 40, 5, 7,
				11, 30, 40, 10, 5, 40, 5, 7, 17, 10,
				40, 10, 5, 40, 5, 7, 18, 10, 40, 10,
				5, 40, 5, 7, 4, 20, 40, 10, 5, 40,
				5
			}, new int[5] { 10, 0, 10, 10, 10 }, new string[9] { "1", "71653d8a-6f89-4cbd-ac49-d281c12478ba", "30", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "20", "0" }, new int[17]
			{
				0, 4, 8, 250, 35, 8, 500, 30, 8, 1000,
				25, 8, 1500, 10, 0, 0, 0
			}, new int[13]
			{
				0, 0, 0, 2, 5, -506, 1, 5, 5, -507,
				1, 5, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(30, 32, "ToMingTang", 1, 3, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 17, 20, 40, 10, 5, 30, 10, 7,
				18, 50, 40, 10, 5, 30, 10, 7, 4, 10,
				40, 10, 5, 30, 10, 7, 6, 5, 40, 10,
				5, 30, 10, 7, 11, 15, 40, 10, 5, 30,
				10
			}, new int[5] { 10, 0, 10, 10, 0 }, new string[9] { "1", "6f2e5851-2092-4293-a4fb-3f0a8b6fa4cb", "30", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 0, 0, 2, 5, -506, 1, 25, 5,
				-507, 1, 25
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(31, 32, "ToMingTang", 1, 3, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 17, 20, 40, 10, 5, 30, 10, 7,
				18, 50, 40, 10, 5, 30, 10, 7, 4, 10,
				40, 10, 5, 30, 10, 7, 6, 5, 40, 10,
				5, 30, 10, 7, 11, 15, 40, 10, 5, 30,
				10
			}, new int[5] { 10, 0, 10, 10, 0 }, new string[9] { "1", "6f2e5851-2092-4293-a4fb-3f0a8b6fa4cb", "30", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 0, 0, 2, 5, -506, 1, 25, 5,
				-507, 1, 25
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(32, 33, "HanDu", 1, 3, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 17, 20, 40, 10, 5, 30, 10, 7,
				18, 50, 40, 10, 5, 30, 10, 7, 4, 10,
				40, 10, 5, 30, 10, 7, 6, 5, 40, 10,
				5, 30, 10, 7, 11, 15, 40, 10, 5, 30,
				10
			}, new int[5] { 10, 0, 10, 10, 0 }, new string[9] { "1", "6f2e5851-2092-4293-a4fb-3f0a8b6fa4cb", "30", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 0, 0, 2, 5, -506, 1, 25, 5,
				-507, 1, 25
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(32, 34, "ChiDu", 1, 3, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 17, 20, 40, 10, 5, 30, 10, 7,
				18, 50, 40, 10, 5, 30, 10, 7, 4, 10,
				40, 10, 5, 30, 10, 7, 6, 5, 40, 10,
				5, 30, 10, 7, 11, 15, 40, 10, 5, 30,
				10
			}, new int[5] { 10, 0, 10, 10, 0 }, new string[9] { "1", "6f2e5851-2092-4293-a4fb-3f0a8b6fa4cb", "30", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 0, 0, 2, 5, -506, 1, 25, 5,
				-507, 1, 25
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(33, 47, "ToEnd", 1, 2, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 17, 30, 10, 10, 10, 60, 10, 7,
				18, 30, 10, 10, 10, 60, 10, 7, 1, 15,
				10, 10, 10, 60, 10, 7, 11, 15, 10, 10,
				10, 60, 10, 7, 4, 10, 10, 10, 10, 60,
				10
			}, new int[5] { 10, 0, 0, 20, 10 }, new string[7] { "0", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 2, 5, -506, 1, 25, 5, -507, 1,
				25, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(34, 47, "ToEnd", 1, 2, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 17, 30, 10, 10, 10, 60, 10, 7,
				18, 30, 10, 10, 10, 60, 10, 7, 1, 15,
				10, 10, 10, 60, 10, 7, 11, 15, 10, 10,
				10, 60, 10, 7, 4, 10, 10, 10, 10, 60,
				10
			}, new int[5] { 10, 0, 0, 20, 10 }, new string[7] { "0", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 2, 5, -506, 1, 25, 5, -507, 1,
				25, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(15, 36, "ToShuiKou", 1, 3, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 17, 15, 40, 10, 5, 30, 10, 7,
				18, 20, 40, 10, 5, 30, 10, 7, 4, 40,
				40, 10, 5, 30, 10, 7, 6, 5, 40, 10,
				5, 30, 10, 7, 11, 20, 40, 10, 5, 30,
				10
			}, new int[5] { 10, 0, 10, 10, 0 }, new string[9] { "1", "f07cfe8d-ba2c-442a-872f-e8f9d05e582f", "30", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 0, 0, 2, 5, -506, 1, 25, 5,
				-507, 1, 25
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(36, 35, "YuDu", 1, 3, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 17, 15, 40, 10, 5, 30, 10, 7,
				18, 20, 40, 10, 5, 30, 10, 7, 4, 40,
				40, 10, 5, 30, 10, 7, 6, 5, 40, 10,
				5, 30, 10, 7, 11, 20, 40, 10, 5, 30,
				10
			}, new int[5] { 10, 0, 10, 10, 0 }, new string[9] { "1", "f07cfe8d-ba2c-442a-872f-e8f9d05e582f", "30", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 0, 0, 2, 5, -506, 1, 25, 5,
				-507, 1, 25
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(35, 18, "ToQiMai", 1, 3, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 1, 30, 40, 10, 5, 40, 5, 7,
				11, 30, 40, 10, 5, 40, 5, 7, 17, 10,
				40, 10, 5, 40, 5, 7, 18, 10, 40, 10,
				5, 40, 5, 7, 4, 20, 40, 10, 5, 40,
				5
			}, new int[5] { 10, 0, 10, 10, 10 }, new string[9] { "1", "71653d8a-6f89-4cbd-ac49-d281c12478ba", "30", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "20", "0" }, new int[17]
			{
				0, 4, 8, 250, 35, 8, 500, 30, 8, 1000,
				25, 8, 1500, 10, 0, 0, 0
			}, new int[13]
			{
				0, 0, 0, 2, 5, -506, 1, 5, 5, -507,
				1, 5, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(36, 8, "LieDu", 1, 3, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 17, 15, 40, 10, 5, 30, 10, 7,
				18, 20, 40, 10, 5, 30, 10, 7, 4, 40,
				40, 10, 5, 30, 10, 7, 6, 5, 40, 10,
				5, 30, 10, 7, 11, 20, 40, 10, 5, 30,
				10
			}, new int[5] { 10, 0, 10, 10, 0 }, new string[9] { "1", "f07cfe8d-ba2c-442a-872f-e8f9d05e582f", "30", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 0, 0, 2, 5, -506, 1, 25, 5,
				-507, 1, 25
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(14, 36, "ToShuiKou", 1, 3, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 17, 15, 40, 10, 5, 30, 10, 7,
				18, 20, 40, 10, 5, 30, 10, 7, 4, 40,
				40, 10, 5, 30, 10, 7, 6, 5, 40, 10,
				5, 30, 10, 7, 11, 20, 40, 10, 5, 30,
				10
			}, new int[5] { 10, 0, 10, 10, 0 }, new string[9] { "1", "f07cfe8d-ba2c-442a-872f-e8f9d05e582f", "30", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 0, 0, 2, 5, -506, 1, 25, 5,
				-507, 1, 25
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(15, 37, "ToQiMai", 1, 3, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 1, 30, 40, 10, 5, 40, 5, 7,
				11, 30, 40, 10, 5, 40, 5, 7, 17, 10,
				40, 10, 5, 40, 5, 7, 18, 10, 40, 10,
				5, 40, 5, 7, 4, 20, 40, 10, 5, 40,
				5
			}, new int[5] { 10, 0, 10, 10, 10 }, new string[9] { "1", "71653d8a-6f89-4cbd-ac49-d281c12478ba", "30", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "20", "0" }, new int[17]
			{
				0, 4, 8, 250, 35, 8, 500, 30, 8, 1000,
				25, 8, 1500, 10, 0, 0, 0
			}, new int[13]
			{
				0, 0, 0, 2, 5, -506, 1, 5, 5, -507,
				1, 5, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(14, 37, "ToQiMai", 1, 3, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 1, 30, 40, 10, 5, 40, 5, 7,
				11, 30, 40, 10, 5, 40, 5, 7, 17, 10,
				40, 10, 5, 40, 5, 7, 18, 10, 40, 10,
				5, 40, 5, 7, 4, 20, 40, 10, 5, 40,
				5
			}, new int[5] { 10, 0, 10, 10, 10 }, new string[9] { "1", "71653d8a-6f89-4cbd-ac49-d281c12478ba", "30", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "20", "0" }, new int[17]
			{
				0, 4, 8, 250, 35, 8, 500, 30, 8, 1000,
				25, 8, 1500, 10, 0, 0, 0
			}, new int[13]
			{
				0, 0, 0, 2, 5, -506, 1, 5, 5, -507,
				1, 5, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(40, 41, "LieDu", 1, 3, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 17, 15, 40, 10, 5, 30, 10, 7,
				18, 20, 40, 10, 5, 30, 10, 7, 4, 40,
				40, 10, 5, 30, 10, 7, 6, 5, 40, 10,
				5, 30, 10, 7, 11, 20, 40, 10, 5, 30,
				10
			}, new int[5] { 10, 0, 10, 10, 0 }, new string[9] { "1", "f07cfe8d-ba2c-442a-872f-e8f9d05e582f", "30", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 0, 0, 2, 5, -506, 1, 25, 5,
				-507, 1, 25
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(37, 38, "FuDu", 1, 3, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 1, 30, 40, 10, 5, 40, 5, 7,
				11, 30, 40, 10, 5, 40, 5, 7, 17, 10,
				40, 10, 5, 40, 5, 7, 18, 10, 40, 10,
				5, 40, 5, 7, 4, 20, 40, 10, 5, 40,
				5
			}, new int[5] { 10, 0, 10, 10, 10 }, new string[9] { "1", "71653d8a-6f89-4cbd-ac49-d281c12478ba", "30", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "20", "0" }, new int[17]
			{
				0, 4, 8, 250, 35, 8, 500, 30, 8, 1000,
				25, 8, 1500, 10, 0, 0, 0
			}, new int[13]
			{
				0, 0, 0, 2, 5, -506, 1, 5, 5, -507,
				1, 5, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(37, 39, "HuanDu", 1, 3, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 1, 30, 40, 10, 5, 40, 5, 7,
				11, 30, 40, 10, 5, 40, 5, 7, 17, 10,
				40, 10, 5, 40, 5, 7, 18, 10, 40, 10,
				5, 40, 5, 7, 4, 20, 40, 10, 5, 40,
				5
			}, new int[5] { 10, 0, 10, 10, 10 }, new string[9] { "1", "71653d8a-6f89-4cbd-ac49-d281c12478ba", "30", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "20", "0" }, new int[17]
			{
				0, 4, 8, 250, 35, 8, 500, 30, 8, 1000,
				25, 8, 1500, 10, 0, 0, 0
			}, new int[13]
			{
				0, 0, 0, 2, 5, -506, 1, 5, 5, -507,
				1, 5, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(38, 40, "ToShuiKou", 1, 3, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 17, 15, 40, 10, 5, 30, 10, 7,
				18, 20, 40, 10, 5, 30, 10, 7, 4, 40,
				40, 10, 5, 30, 10, 7, 6, 5, 40, 10,
				5, 30, 10, 7, 11, 20, 40, 10, 5, 30,
				10
			}, new int[5] { 10, 0, 10, 10, 0 }, new string[9] { "1", "f07cfe8d-ba2c-442a-872f-e8f9d05e582f", "30", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 0, 0, 2, 5, -506, 1, 25, 5,
				-507, 1, 25
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(39, 40, "ToShuiKou", 1, 3, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 17, 15, 40, 10, 5, 30, 10, 7,
				18, 20, 40, 10, 5, 30, 10, 7, 4, 40,
				40, 10, 5, 30, 10, 7, 6, 5, 40, 10,
				5, 30, 10, 7, 11, 20, 40, 10, 5, 30,
				10
			}, new int[5] { 10, 0, 10, 10, 0 }, new string[9] { "1", "f07cfe8d-ba2c-442a-872f-e8f9d05e582f", "30", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 0, 0, 2, 5, -506, 1, 25, 5,
				-507, 1, 25
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(40, 42, "YuDu", 1, 3, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 17, 15, 40, 10, 5, 30, 10, 7,
				18, 20, 40, 10, 5, 30, 10, 7, 4, 40,
				40, 10, 5, 30, 10, 7, 6, 5, 40, 10,
				5, 30, 10, 7, 11, 20, 40, 10, 5, 30,
				10
			}, new int[5] { 10, 0, 10, 10, 0 }, new string[9] { "1", "f07cfe8d-ba2c-442a-872f-e8f9d05e582f", "30", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 0, 0, 2, 5, -506, 1, 25, 5,
				-507, 1, 25
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(41, 47, "ToEnd", 1, 2, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 17, 30, 10, 10, 10, 60, 10, 7,
				18, 30, 10, 10, 10, 60, 10, 7, 1, 15,
				10, 10, 10, 60, 10, 7, 11, 15, 10, 10,
				10, 60, 10, 7, 4, 10, 10, 10, 10, 60,
				10
			}, new int[5] { 10, 0, 0, 20, 10 }, new string[7] { "0", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 2, 5, -506, 1, 25, 5, -507, 1,
				25, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(42, 47, "ToEnd", 1, 2, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 17, 30, 10, 10, 10, 60, 10, 7,
				18, 30, 10, 10, 10, 60, 10, 7, 1, 15,
				10, 10, 10, 60, 10, 7, 11, 15, 10, 10,
				10, 60, 10, 7, 4, 10, 10, 10, 10, 60,
				10
			}, new int[5] { 10, 0, 0, 20, 10 }, new string[7] { "0", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 2, 5, -506, 1, 25, 5, -507, 1,
				25, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(43, 44, "HanDu", 1, 3, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 17, 20, 40, 10, 5, 30, 10, 7,
				18, 50, 40, 10, 5, 30, 10, 7, 4, 10,
				40, 10, 5, 30, 10, 7, 6, 5, 40, 10,
				5, 30, 10, 7, 11, 15, 40, 10, 5, 30,
				10
			}, new int[5] { 10, 0, 10, 10, 0 }, new string[9] { "1", "6f2e5851-2092-4293-a4fb-3f0a8b6fa4cb", "30", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 0, 0, 2, 5, -506, 1, 25, 5,
				-507, 1, 25
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(43, 45, "ChiDu", 1, 3, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 17, 20, 40, 10, 5, 30, 10, 7,
				18, 50, 40, 10, 5, 30, 10, 7, 4, 10,
				40, 10, 5, 30, 10, 7, 6, 5, 40, 10,
				5, 30, 10, 7, 11, 15, 40, 10, 5, 30,
				10
			}, new int[5] { 10, 0, 10, 10, 0 }, new string[9] { "1", "6f2e5851-2092-4293-a4fb-3f0a8b6fa4cb", "30", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 0, 0, 2, 5, -506, 1, 25, 5,
				-507, 1, 25
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(7, 9, "LieDu", 1, 3, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 17, 15, 40, 10, 5, 30, 10, 7,
				18, 20, 40, 10, 5, 30, 10, 7, 4, 40,
				40, 10, 5, 30, 10, 7, 6, 5, 40, 10,
				5, 30, 10, 7, 11, 20, 40, 10, 5, 30,
				10
			}, new int[5] { 10, 0, 10, 10, 0 }, new string[9] { "1", "f07cfe8d-ba2c-442a-872f-e8f9d05e582f", "30", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 0, 0, 2, 5, -506, 1, 25, 5,
				-507, 1, 25
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(13, 7, "ToShuiKou", 1, 3, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 17, 15, 40, 10, 5, 30, 10, 7,
				18, 20, 40, 10, 5, 30, 10, 7, 4, 40,
				40, 10, 5, 30, 10, 7, 6, 5, 40, 10,
				5, 30, 10, 7, 11, 20, 40, 10, 5, 30,
				10
			}, new int[5] { 10, 0, 10, 10, 0 }, new string[9] { "1", "f07cfe8d-ba2c-442a-872f-e8f9d05e582f", "30", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 0, 0, 2, 5, -506, 1, 25, 5,
				-507, 1, 25
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(12, 43, "ToMingTang", 1, 3, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 17, 20, 40, 10, 5, 30, 10, 7,
				18, 50, 40, 10, 5, 30, 10, 7, 4, 10,
				40, 10, 5, 30, 10, 7, 6, 5, 40, 10,
				5, 30, 10, 7, 11, 15, 40, 10, 5, 30,
				10
			}, new int[5] { 10, 0, 10, 10, 0 }, new string[9] { "1", "6f2e5851-2092-4293-a4fb-3f0a8b6fa4cb", "30", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 0, 0, 2, 5, -506, 1, 25, 5,
				-507, 1, 25
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(9, 17, "ToMingTang", 1, 3, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 17, 20, 40, 10, 5, 30, 10, 7,
				18, 50, 40, 10, 5, 30, 10, 7, 4, 10,
				40, 10, 5, 30, 10, 7, 6, 5, 40, 10,
				5, 30, 10, 7, 11, 15, 40, 10, 5, 30,
				10
			}, new int[5] { 10, 0, 10, 10, 0 }, new string[9] { "1", "6f2e5851-2092-4293-a4fb-3f0a8b6fa4cb", "30", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 0, 0, 2, 5, -506, 1, 25, 5,
				-507, 1, 25
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(16, 17, "ToMingTang", 1, 3, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 17, 20, 40, 10, 5, 30, 10, 7,
				18, 50, 40, 10, 5, 30, 10, 7, 4, 10,
				40, 10, 5, 30, 10, 7, 6, 5, 40, 10,
				5, 30, 10, 7, 11, 15, 40, 10, 5, 30,
				10
			}, new int[5] { 10, 0, 10, 10, 0 }, new string[9] { "1", "6f2e5851-2092-4293-a4fb-3f0a8b6fa4cb", "30", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 0, 0, 2, 5, -506, 1, 25, 5,
				-507, 1, 25
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(44, 46, "ToShuiKou", 1, 3, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 17, 15, 40, 10, 5, 30, 10, 7,
				18, 20, 40, 10, 5, 30, 10, 7, 4, 40,
				40, 10, 5, 30, 10, 7, 6, 5, 40, 10,
				5, 30, 10, 7, 11, 20, 40, 10, 5, 30,
				10
			}, new int[5] { 10, 0, 10, 10, 0 }, new string[9] { "1", "f07cfe8d-ba2c-442a-872f-e8f9d05e582f", "30", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 0, 0, 2, 5, -506, 1, 25, 5,
				-507, 1, 25
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(45, 46, "ToShuiKou", 1, 3, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 17, 15, 40, 10, 5, 30, 10, 7,
				18, 20, 40, 10, 5, 30, 10, 7, 4, 40,
				40, 10, 5, 30, 10, 7, 6, 5, 40, 10,
				5, 30, 10, 7, 11, 20, 40, 10, 5, 30,
				10
			}, new int[5] { 10, 0, 10, 10, 0 }, new string[9] { "1", "f07cfe8d-ba2c-442a-872f-e8f9d05e582f", "30", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 0, 0, 2, 5, -506, 1, 25, 5,
				-507, 1, 25
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(46, 23, "LieDu", 1, 3, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 17, 15, 40, 10, 5, 30, 10, 7,
				18, 20, 40, 10, 5, 30, 10, 7, 4, 40,
				40, 10, 5, 30, 10, 7, 6, 5, 40, 10,
				5, 30, 10, 7, 11, 20, 40, 10, 5, 30,
				10
			}, new int[5] { 10, 0, 10, 10, 0 }, new string[9] { "1", "f07cfe8d-ba2c-442a-872f-e8f9d05e582f", "30", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 0, 0, 2, 5, -506, 1, 25, 5,
				-507, 1, 25
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(46, 24, "YuDu", 1, 3, "c9760b91-5c6e-4794-a700-7194b0ede30d", new int[4] { 4, 50, 9, 50 }, new int[41]
			{
				5, 7, 17, 15, 40, 10, 5, 30, 10, 7,
				18, 20, 40, 10, 5, 30, 10, 7, 4, 40,
				40, 10, 5, 30, 10, 7, 6, 5, 40, 10,
				5, 30, 10, 7, 11, 20, 40, 10, 5, 30,
				10
			}, new int[5] { 10, 0, 10, 10, 0 }, new string[9] { "1", "f07cfe8d-ba2c-442a-872f-e8f9d05e582f", "30", "0", "0", "1", "ece208c1-a23d-4525-963c-999b8477f23d", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 0, 0, 2, 5, -506, 1, 25, 5,
				-507, 1, 25
			}, new string[5] { "0", "0", "0", "0", "0" })
		};
		List<AdventureAdvancedBranch> advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray5.Add(new AdventureItem(64, config9, config10, 4, 5, 5, 2, 10, -1, resCost5, itemCost5, restrictedByWorldPopulation: false, malice5, adventureParams3, "2139a9fb-ef9b-4470-a937-850fd8994082", startNodes2, transferNodes2, endNodes, baseBranches, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray6 = _dataArray;
		string config11 = LocalStringManager.GetConfig("Adventure_language", "Name_65");
		string config12 = LocalStringManager.GetConfig("Adventure_language", "Desc_65");
		int[] resCost6 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost6 = list;
		short[] malice6 = new short[3];
		adventureParams = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams4 = adventureParams;
		List<AdventureStartNode> startNodes3 = new List<AdventureStartNode>
		{
			new AdventureStartNode("046a914d-1aec-4371-86b9-caba59161e71", "0", "LK_Adventure_NodeTitle_197", 8)
		};
		List<AdventureTransferNode> transferNodes3 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("dfd34638-7508-4037-901f-2857c40d8e10", "C", "LK_Adventure_NodeTitle_198", 5),
			new AdventureTransferNode("433a5dc1-c5e0-44bd-ab85-c41d811fdbfa", "1", "LK_Adventure_NodeTitle_199", 10)
		};
		List<AdventureEndNode> endNodes2 = new List<AdventureEndNode>
		{
			new AdventureEndNode("b9eb9e32-eed0-46e0-b5dc-87f7f392fba9", "B", "LK_Adventure_NodeTitle_200", 7),
			new AdventureEndNode("f394d70b-38f5-4c7a-b3ca-752f2bf41f0a", "A", "LK_Adventure_NodeTitle_201", 11)
		};
		List<AdventureBaseBranch> baseBranches2 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(1, 4, "C", 1, 10, "", new int[8] { 0, 25, 1, 25, 2, 25, 3, 25 }, new int[57]
			{
				7, 7, 10, 30, 5, 60, 15, 5, 5, 7,
				12, 15, 5, 60, 15, 5, 5, 7, 8, 10,
				5, 60, 15, 5, 5, 7, 16, 10, 5, 60,
				15, 5, 5, 7, 5, 20, 5, 60, 15, 5,
				5, 7, 11, 10, 5, 60, 15, 5, 5, 7,
				9, 5, 5, 60, 15, 5, 5
			}, new int[5] { 10, 50, 0, 10, 10 }, new string[7] { "0", "1", "c52b387c-681f-410e-bd8c-95155be65624", "30", "0", "0", "0" }, new int[14]
			{
				0, 3, 8, 500, 5, 8, 750, 3, 8, 1000,
				2, 0, 0, 0
			}, new int[9] { 0, 0, 1, 10, -1001, 1, 20, 0, 0 }, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 3, "B", 1, 15, "", new int[4] { 8, 50, 9, 50 }, new int[57]
			{
				7, 7, 10, 30, 0, 20, 10, 70, 0, 7,
				12, 15, 10, 20, 0, 70, 0, 7, 8, 10,
				0, 20, 10, 70, 0, 7, 16, 10, 0, 20,
				0, 70, 10, 7, 5, 20, 0, 20, 0, 70,
				10, 7, 11, 10, 10, 20, 0, 70, 0, 7,
				9, 5, 0, 20, 0, 70, 10
			}, new int[5] { 10, 0, 10, 50, 10 }, new string[7] { "0", "0", "0", "1", "44515918-a44d-4b4d-a7f1-a228dad4ad05", "30", "0" }, new int[14]
			{
				0, 3, 8, 500, 50, 8, 750, 30, 8, 1000,
				20, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(0, 2, "0", 1, 2, "", new int[8] { 0, 25, 1, 25, 2, 25, 3, 25 }, new int[49]
			{
				6, 7, 12, 25, 10, 10, 60, 10, 10, 7,
				8, 15, 10, 10, 60, 10, 10, 7, 16, 15,
				10, 10, 60, 10, 10, 7, 5, 20, 10, 10,
				60, 10, 10, 7, 11, 15, 10, 10, 60, 10,
				10, 7, 9, 10, 10, 10, 60, 10, 10
			}, new int[5] { 100, 100, 100, 10, 100 }, new string[5] { "0", "0", "0", "0", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 1, "A", 1, 10, "", new int[8] { 0, 25, 1, 25, 2, 25, 3, 25 }, new int[57]
			{
				7, 7, 10, 30, 5, 60, 15, 5, 5, 7,
				12, 15, 5, 60, 15, 5, 5, 7, 8, 10,
				5, 60, 15, 5, 5, 7, 16, 10, 5, 60,
				15, 5, 5, 7, 5, 20, 5, 60, 15, 5,
				5, 7, 11, 10, 5, 60, 15, 5, 5, 7,
				9, 5, 5, 60, 15, 5, 5
			}, new int[5] { 10, 50, 0, 10, 10 }, new string[7] { "0", "1", "c52b387c-681f-410e-bd8c-95155be65624", "30", "0", "0", "0" }, new int[14]
			{
				0, 3, 8, 500, 5, 8, 750, 3, 8, 1000,
				2, 0, 0, 0
			}, new int[9] { 0, 0, 1, 10, -1001, 1, 20, 0, 0 }, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 3, "B", 1, 20, "", new int[4] { 8, 50, 9, 50 }, new int[57]
			{
				7, 7, 10, 30, 0, 20, 10, 70, 0, 7,
				12, 15, 10, 20, 0, 70, 0, 7, 8, 10,
				0, 20, 10, 70, 0, 7, 16, 10, 0, 20,
				0, 70, 10, 7, 5, 20, 0, 20, 0, 70,
				10, 7, 11, 10, 10, 20, 0, 70, 0, 7,
				9, 5, 0, 20, 0, 70, 10
			}, new int[5] { 10, 0, 10, 50, 10 }, new string[7] { "0", "0", "0", "1", "44515918-a44d-4b4d-a7f1-a228dad4ad05", "30", "0" }, new int[14]
			{
				0, 3, 8, 500, 50, 8, 750, 30, 8, 1000,
				20, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray6.Add(new AdventureItem(65, config11, config12, 4, 6, 6, 2, 10, -1, resCost6, itemCost6, restrictedByWorldPopulation: false, malice6, adventureParams4, "cedfb7fd-92b2-4e63-97db-af02f813d0a5", startNodes3, transferNodes3, endNodes2, baseBranches2, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray7 = _dataArray;
		string config13 = LocalStringManager.GetConfig("Adventure_language", "Name_66");
		string config14 = LocalStringManager.GetConfig("Adventure_language", "Desc_66");
		int[] resCost7 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost7 = list;
		short[] malice7 = new short[3];
		adventureParams = new List<(string, string, string, string)>();
		dataArray7.Add(new AdventureItem(66, config13, config14, 4, 7, 7, 2, 10, -1, resCost7, itemCost7, restrictedByWorldPopulation: false, malice7, adventureParams, "cda696cc-f562-4a68-bd7b-c4a25c571294", new List<AdventureStartNode>
		{
			new AdventureStartNode("886a5dac-4377-4023-bbae-efba99af8723", "0", "LK_Adventure_NodeTitle_202", 11)
		}, new List<AdventureTransferNode>
		{
			new AdventureTransferNode("7e1648ba-3584-47d4-955e-363939977304", "1", "LK_Adventure_NodeTitle_203", 13),
			new AdventureTransferNode("2cff3e6e-da38-4dd9-b416-c80e7e6f8cce", "3", "LK_Adventure_NodeTitle_204", 11),
			new AdventureTransferNode("e4c26c50-2ef6-42a5-88a4-839a1f85c41b", "2", "LK_Adventure_NodeTitle_205", 11)
		}, new List<AdventureEndNode>
		{
			new AdventureEndNode("f978153d-59c0-443b-ae7a-3f9dad690743", "B", "LK_Adventure_NodeTitle_206", 11),
			new AdventureEndNode("41222079-3048-4006-98c4-f9f8cf7000e5", "A", "LK_Adventure_NodeTitle_207", 11)
		}, new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "0", 1, 5, "", new int[2] { 12, 50 }, new int[41]
			{
				5, 7, 16, 30, 30, 10, 10, 40, 10, 7,
				11, 40, 30, 10, 10, 40, 10, 7, 21, 10,
				30, 10, 10, 40, 10, 7, 13, 15, 30, 10,
				10, 40, 10, 7, 6, 5, 30, 10, 10, 40,
				10
			}, new int[5] { 30, 10, 20, 15, 20 }, new string[9] { "1", "05dee543-7ba6-4422-8dab-56ccd3e36e6d", "30", "0", "0", "1", "dae323ba-0463-4b7a-af7d-2b823de390b4", "30", "0" }, new int[32]
			{
				9, 0, 320, 5, 0, 480, 3, 0, 640, 2,
				2, 320, 5, 2, 480, 3, 2, 640, 2, 3,
				320, 5, 3, 480, 3, 3, 640, 2, 0, 0,
				0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 3, "B", 1, 10, "", new int[2] { 12, 50 }, new int[41]
			{
				5, 7, 16, 40, 10, 20, 10, 50, 10, 7,
				11, 30, 10, 20, 10, 50, 10, 7, 21, 10,
				10, 20, 10, 50, 10, 7, 13, 15, 10, 20,
				10, 50, 10, 7, 6, 5, 10, 20, 10, 50,
				10
			}, new int[5] { 20, 0, 20, 20, 20 }, new string[7] { "0", "0", "0", "1", "dae323ba-0463-4b7a-af7d-2b823de390b4", "30", "0" }, new int[14]
			{
				0, 3, 8, 800, 50, 8, 1200, 30, 8, 1600,
				20, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 2, "B1", 1, 5, "", new int[2] { 12, 50 }, new int[49]
			{
				6, 7, 16, 25, 10, 20, 10, 50, 10, 7,
				11, 35, 10, 20, 10, 50, 10, 7, 21, 10,
				10, 20, 10, 50, 10, 7, 13, 15, 10, 20,
				10, 50, 10, 7, 6, 10, 10, 20, 10, 50,
				10, 7, 5, 5, 10, 20, 10, 50, 10
			}, new int[5] { 20, 0, 20, 20, 20 }, new string[7] { "0", "0", "0", "1", "dae323ba-0463-4b7a-af7d-2b823de390b4", "30", "0" }, new int[14]
			{
				0, 3, 8, 800, 50, 8, 1200, 30, 8, 1600,
				20, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 4, "B2", 1, 5, "", new int[2] { 12, 50 }, new int[49]
			{
				6, 7, 16, 25, 10, 20, 10, 50, 10, 7,
				11, 35, 10, 20, 10, 50, 10, 7, 21, 10,
				10, 20, 10, 50, 10, 7, 13, 15, 10, 20,
				10, 50, 10, 7, 6, 10, 10, 20, 10, 50,
				10, 7, 5, 5, 10, 20, 10, 50, 10
			}, new int[5] { 20, 0, 20, 20, 20 }, new string[7] { "0", "0", "0", "1", "dae323ba-0463-4b7a-af7d-2b823de390b4", "30", "0" }, new int[14]
			{
				0, 3, 8, 800, 50, 8, 1200, 30, 8, 1600,
				20, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 5, "A", 1, 15, "", new int[2] { 12, 50 }, new int[41]
			{
				5, 7, 16, 40, 15, 15, 10, 50, 10, 7,
				11, 30, 15, 15, 10, 50, 10, 7, 21, 10,
				15, 15, 10, 50, 10, 7, 13, 15, 15, 15,
				10, 50, 10, 7, 6, 5, 15, 15, 10, 50,
				10
			}, new int[5] { 0, 0, 20, 20, 20 }, new string[7] { "0", "0", "0", "1", "dae323ba-0463-4b7a-af7d-2b823de390b4", "30", "0" }, new int[41]
			{
				9, 0, 320, 5, 0, 480, 3, 0, 640, 2,
				2, 320, 5, 2, 480, 3, 2, 640, 2, 3,
				320, 5, 3, 480, 3, 3, 640, 2, 3, 8,
				800, 50, 8, 1200, 30, 8, 1600, 20, 0, 0,
				0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, new List<AdventureAdvancedBranch>
		{
			new AdventureAdvancedBranch(5, "", 4, 12, 300, new int[2] { 12, 50 }, new int[41]
			{
				5, 7, 16, 40, 0, 0, 0, 100, 0, 7,
				11, 30, 0, 0, 0, 100, 0, 7, 21, 10,
				0, 0, 0, 100, 0, 7, 13, 15, 0, 0,
				0, 100, 0, 7, 6, 5, 0, 0, 0, 100,
				0
			}, new int[5] { 10, 10, 10, 0, 10 }, new string[5] { "0", "0", "0", "0", "0" }, new int[29]
			{
				0, 0, 0, 8, 2, 225, 6, 2, 400, 12,
				2, 625, 9, 2, 900, 3, 3, 225, 6, 3,
				400, 12, 3, 625, 9, 3, 900, 3, 0
			}, new int[77]
			{
				0, 0, 0, 18, 12, 33, 1, 2, 12, 34,
				1, 2, 12, 38, 1, 2, 12, 39, 1, 2,
				12, 43, 1, 2, 12, 44, 1, 2, 12, 48,
				1, 2, 12, 49, 1, 2, 12, 53, 1, 2,
				12, 54, 1, 2, 12, 58, 1, 2, 12, 59,
				1, 2, 12, 63, 1, 2, 12, 64, 1, 2,
				12, 68, 1, 2, 12, 69, 1, 2, 12, 73,
				1, 2, 12, 74, 1, 2, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureAdvancedBranch(3, "", 1, 12, 300, new int[2] { 12, 50 }, new int[41]
			{
				5, 7, 16, 40, 0, 0, 0, 0, 100, 7,
				11, 30, 0, 0, 0, 0, 100, 7, 21, 10,
				0, 0, 0, 0, 100, 7, 13, 15, 0, 0,
				0, 0, 100, 7, 6, 5, 0, 0, 0, 0,
				100
			}, new int[5] { 10, 10, 10, 10, 0 }, new string[7] { "0", "0", "0", "0", "1", "b616da5c-dbca-4a88-9756-bf29042a2682", "100" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureAdvancedBranch(2, "", 2, 12, 300, new int[2] { 12, 50 }, new int[17]
			{
				2, 7, 16, 50, 0, 0, 0, 0, 100, 7,
				21, 50, 0, 0, 0, 0, 100
			}, new int[5] { 10, 10, 10, 10, 0 }, new string[7] { "0", "0", "0", "0", "1", "b616da5c-dbca-4a88-9756-bf29042a2682", "100" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureAdvancedBranch(1, "", 3, 12, 300, new int[2] { 12, 50 }, new int[9] { 1, 7, 16, 100, 0, 0, 0, 0, 100 }, new int[5] { 10, 10, 10, 10, 0 }, new string[7] { "0", "0", "0", "0", "1", "b616da5c-dbca-4a88-9756-bf29042a2682", "100" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray8 = _dataArray;
		string config15 = LocalStringManager.GetConfig("Adventure_language", "Name_67");
		string config16 = LocalStringManager.GetConfig("Adventure_language", "Desc_67");
		int[] resCost8 = new int[9];
		list = new List<int[]>();
		dataArray8.Add(new AdventureItem(67, config15, config16, 4, 7, 7, 0, 10, -1, resCost8, list, restrictedByWorldPopulation: false, new short[3], new List<(string, string, string, string)> { ("kill", "LK_Adventure_67_ParamName_0", "", "") }, "a99bbdd4-5a77-44bd-a690-1b56278e69b0", new List<AdventureStartNode>
		{
			new AdventureStartNode("01fc2d05-6ea3-4cec-84f1-a597e073b3e6", "A", "LK_Adventure_NodeTitle_209", 11)
		}, new List<AdventureTransferNode>
		{
			new AdventureTransferNode("f14f18c2-503a-4ba5-9ede-d036b2a7c6eb", "B", "LK_Adventure_NodeTitle_210", 11),
			new AdventureTransferNode("33efb4b3-49e5-49c2-8a6b-99dd838cefb0", "C", "LK_Adventure_NodeTitle_211", 11),
			new AdventureTransferNode("27eab6cb-1fc1-40ab-a2c1-72aa560aedde", "E", "LK_Adventure_NodeTitle_212", 22),
			new AdventureTransferNode("7ddec90e-678b-4f40-9ac6-eadf9c6e02b5", "D", "LK_Adventure_NodeTitle_213", 11),
			new AdventureTransferNode("c6e6a9d8-259d-4403-8127-1d43fadd9d74", "F", "LK_Adventure_NodeTitle_214", 22),
			new AdventureTransferNode("c6e6a9d8-259d-4403-8127-1d43fadd9d74", "G", "LK_Adventure_NodeTitle_214", 22),
			new AdventureTransferNode("c6e6a9d8-259d-4403-8127-1d43fadd9d74", "H", "LK_Adventure_NodeTitle_214", 22)
		}, new List<AdventureEndNode>
		{
			new AdventureEndNode("5ee4d83d-def6-42c6-a76a-48627fbe5a30", "J", "LK_Adventure_NodeTitle_215", 11),
			new AdventureEndNode("3579868e-8e06-49ea-bd07-9d74717e755e", "K", "LK_Adventure_NodeTitle_216", 11)
		}, new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 5, "", new int[4] { 12, 50, 13, 50 }, new int[41]
			{
				5, 7, 1, 30, 35, 15, 5, 35, 5, 7,
				11, 30, 35, 15, 5, 35, 5, 7, 12, 20,
				35, 15, 5, 35, 5, 7, 6, 10, 35, 15,
				5, 35, 5, 7, 17, 10, 35, 15, 5, 35,
				5
			}, new int[5] { 15, 0, 100, 20, 100 }, new string[9] { "1", "bd9d10dc-e186-4fc3-a4ab-3e6efd3be785", "30", "0", "0", "1", "74db9aad-92ad-493e-bf7e-600ada0b27e2", "30", "0" }, new int[32]
			{
				6, 1, 320, 5, 1, 480, 3, 1, 640, 2,
				4, 320, 5, 4, 480, 3, 4, 640, 2, 3,
				8, 800, 50, 8, 1200, 30, 8, 1600, 20, 0,
				0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "1", 1, 10, "", new int[4] { 12, 50, 13, 50 }, new int[49]
			{
				6, 7, 1, 25, 0, 0, 10, 60, 30, 7,
				11, 30, 30, 0, 0, 60, 10, 7, 12, 20,
				10, 0, 30, 60, 0, 7, 6, 10, 0, 40,
				0, 60, 0, 7, 17, 10, 0, 40, 0, 60,
				0, 7, 16, 5, 0, 40, 0, 60, 0
			}, new int[5] { 100, 0, 100, 20, 100 }, new string[7] { "0", "0", "0", "1", "157658af-c58f-4262-ba5a-90acdca1ea64", "30", "0" }, new int[32]
			{
				6, 1, 320, 50, 1, 480, 30, 1, 640, 20,
				4, 320, 50, 4, 480, 30, 4, 640, 20, 3,
				8, 800, 50, 8, 1200, 30, 8, 1600, 20, 0,
				0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 3, "2", 0, 2, "", new int[4] { 12, 50, 13, 50 }, new int[4] { 1, 2, 22, 100 }, new int[5] { 100, 100, 100, 100, 100 }, new string[5] { "0", "0", "0", "0", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 4, "1", 1, 5, "", new int[4] { 12, 50, 13, 50 }, new int[49]
			{
				6, 7, 1, 25, 0, 0, 10, 60, 30, 7,
				11, 30, 30, 0, 0, 60, 10, 7, 12, 20,
				10, 0, 30, 60, 0, 7, 6, 10, 0, 40,
				0, 60, 0, 7, 17, 10, 0, 40, 0, 60,
				0, 7, 16, 5, 0, 40, 0, 60, 0
			}, new int[5] { 100, 0, 100, 20, 100 }, new string[7] { "0", "0", "0", "1", "157658af-c58f-4262-ba5a-90acdca1ea64", "30", "0" }, new int[32]
			{
				6, 1, 320, 50, 1, 480, 30, 1, 640, 20,
				4, 320, 50, 4, 480, 30, 4, 640, 20, 3,
				8, 800, 50, 8, 1200, 30, 8, 1600, 20, 0,
				0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(4, 8, "1", 1, 5, "", new int[4] { 12, 50, 13, 50 }, new int[49]
			{
				6, 7, 1, 25, 0, 0, 10, 60, 30, 7,
				11, 30, 30, 0, 0, 60, 10, 7, 12, 20,
				10, 0, 30, 60, 0, 7, 6, 10, 0, 40,
				0, 60, 0, 7, 17, 10, 0, 40, 0, 60,
				0, 7, 16, 5, 0, 40, 0, 60, 0
			}, new int[5] { 100, 0, 100, 20, 100 }, new string[7] { "0", "0", "0", "1", "157658af-c58f-4262-ba5a-90acdca1ea64", "30", "0" }, new int[32]
			{
				6, 1, 320, 50, 1, 480, 30, 1, 640, 20,
				4, 320, 50, 4, 480, 30, 4, 640, 20, 3,
				8, 800, 50, 8, 1200, 30, 8, 1600, 20, 0,
				0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 5, "1", 1, 10, "4318c19c-c3a9-4fa9-b0c3-f40b25e42324", new int[4] { 12, 50, 13, 50 }, new int[17]
			{
				2, 7, 22, 60, 15, 20, 15, 50, 0, 7,
				18, 40, 10, 20, 0, 50, 20
			}, new int[5] { 100, 0, 100, 20, 100 }, new string[7] { "0", "0", "0", "1", "99f2df56-75c7-4bdc-b40b-6e8b50364584", "30", "0" }, new int[14]
			{
				0, 3, 8, 800, 50, 8, 1200, 30, 8, 1600,
				20, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 6, "2", 1, 10, "4318c19c-c3a9-4fa9-b0c3-f40b25e42324", new int[4] { 12, 50, 13, 50 }, new int[17]
			{
				2, 7, 22, 60, 15, 20, 15, 50, 0, 7,
				18, 40, 10, 20, 0, 50, 20
			}, new int[5] { 100, 0, 100, 20, 100 }, new string[7] { "0", "0", "0", "1", "99f2df56-75c7-4bdc-b40b-6e8b50364584", "30", "0" }, new int[14]
			{
				0, 3, 8, 800, 50, 8, 1200, 30, 8, 1600,
				20, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 7, "3", 1, 10, "4318c19c-c3a9-4fa9-b0c3-f40b25e42324", new int[4] { 12, 50, 13, 50 }, new int[17]
			{
				2, 7, 22, 60, 15, 20, 15, 50, 0, 7,
				18, 40, 10, 20, 0, 50, 20
			}, new int[5] { 100, 0, 100, 20, 100 }, new string[7] { "0", "0", "0", "1", "99f2df56-75c7-4bdc-b40b-6e8b50364584", "30", "0" }, new int[14]
			{
				0, 3, 8, 800, 50, 8, 1200, 30, 8, 1600,
				20, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(5, 9, "1", 1, 10, "4318c19c-c3a9-4fa9-b0c3-f40b25e42324", new int[4] { 12, 50, 13, 50 }, new int[17]
			{
				2, 7, 22, 60, 0, 20, 10, 60, 20, 7,
				18, 40, 30, 20, 5, 60, 5
			}, new int[5] { 100, 0, 100, 30, 100 }, new string[17]
			{
				"0", "0", "0", "6", "db9b70e1-46b4-4d86-8f7b-7b82c34310ff", "10", "df319a31-636a-4cb5-943a-0cde2fc741ea", "10", "ad7db1d1-b5b4-46f2-a794-9a4c6e371457", "10",
				"c1ad8dd6-8426-4488-9dcb-9038506fa14f", "10", "fdaa1e52-2f9e-4292-a586-619e8ef875c3", "10", "29f043eb-43be-4a58-8e2b-482be496d9ad", "10", "0"
			}, new int[17]
			{
				0, 4, 8, 500, 20, 8, 1000, 30, 8, 1500,
				40, 8, 2250, 10, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(6, 9, "1", 1, 10, "4318c19c-c3a9-4fa9-b0c3-f40b25e42324", new int[4] { 12, 50, 13, 50 }, new int[17]
			{
				2, 7, 22, 60, 0, 20, 10, 60, 20, 7,
				18, 40, 30, 20, 5, 60, 5
			}, new int[5] { 100, 0, 100, 30, 100 }, new string[17]
			{
				"0", "0", "0", "6", "db9b70e1-46b4-4d86-8f7b-7b82c34310ff", "10", "df319a31-636a-4cb5-943a-0cde2fc741ea", "10", "ad7db1d1-b5b4-46f2-a794-9a4c6e371457", "10",
				"c1ad8dd6-8426-4488-9dcb-9038506fa14f", "10", "fdaa1e52-2f9e-4292-a586-619e8ef875c3", "10", "29f043eb-43be-4a58-8e2b-482be496d9ad", "10", "0"
			}, new int[17]
			{
				0, 4, 8, 500, 20, 8, 1000, 30, 8, 1500,
				40, 8, 2250, 10, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(7, 9, "1", 1, 10, "4318c19c-c3a9-4fa9-b0c3-f40b25e42324", new int[4] { 12, 50, 13, 50 }, new int[17]
			{
				2, 7, 22, 60, 0, 20, 10, 60, 20, 7,
				18, 40, 30, 20, 5, 60, 5
			}, new int[5] { 100, 0, 100, 30, 100 }, new string[17]
			{
				"0", "0", "0", "6", "db9b70e1-46b4-4d86-8f7b-7b82c34310ff", "10", "df319a31-636a-4cb5-943a-0cde2fc741ea", "10", "ad7db1d1-b5b4-46f2-a794-9a4c6e371457", "10",
				"c1ad8dd6-8426-4488-9dcb-9038506fa14f", "10", "fdaa1e52-2f9e-4292-a586-619e8ef875c3", "10", "29f043eb-43be-4a58-8e2b-482be496d9ad", "10", "0"
			}, new int[17]
			{
				0, 4, 8, 500, 20, 8, 1000, 30, 8, 1500,
				40, 8, 2250, 10, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, new List<AdventureAdvancedBranch>
		{
			new AdventureAdvancedBranch(4, "", 3, 13, 350, new int[2] { 13, 100 }, new int[9] { 1, 7, 16, 100, 0, 0, 0, 0, 100 }, new int[5] { 10, 10, 10, 10, 0 }, new string[5] { "0", "0", "0", "0", "0" }, new int[5], new int[21]
			{
				0, 0, 0, 0, 4, 12, 2, 1, 20, 12,
				3, 1, 40, 12, 4, 1, 30, 12, 5, 1,
				10
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureAdvancedBranch(4, "", 4, 12, 350, new int[2] { 12, 100 }, new int[9] { 1, 7, 16, 100, 0, 0, 0, 0, 100 }, new int[5] { 10, 10, 100, 100, 0 }, new string[5] { "0", "0", "0", "0", "0" }, new int[5], new int[21]
			{
				0, 0, 0, 0, 4, 12, 2, 1, 20, 12,
				3, 1, 40, 12, 4, 1, 30, 12, 5, 1,
				10
			}, new string[5] { "0", "0", "0", "0", "0" })
		}, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray9 = _dataArray;
		string config17 = LocalStringManager.GetConfig("Adventure_language", "Name_68");
		string config18 = LocalStringManager.GetConfig("Adventure_language", "Desc_68");
		int[] resCost9 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost8 = list;
		short[] malice8 = new short[3];
		adventureParams = new List<(string, string, string, string)>();
		dataArray9.Add(new AdventureItem(68, config17, config18, 4, 8, 8, 0, 10, -1, resCost9, itemCost8, restrictedByWorldPopulation: false, malice8, adventureParams, "c75157b0-dd03-40dd-a905-d3770118c824", new List<AdventureStartNode>
		{
			new AdventureStartNode("cd16df2b-f2b6-4b08-901f-e96b1a2e87ba", "A", "LK_Adventure_NodeTitle_217", 18)
		}, new List<AdventureTransferNode>
		{
			new AdventureTransferNode("3747c24a-ac8b-4fab-ad22-073192e85d61", "B", "LK_Adventure_NodeTitle_218", 16),
			new AdventureTransferNode("52291cc1-9ba7-407c-be4a-bac89a3b470b", "C", "LK_Adventure_NodeTitle_219", 16),
			new AdventureTransferNode("80d2bdc2-e134-43c5-ae2d-e0f4fc67da72", "D", "LK_Adventure_NodeTitle_220", 17)
		}, new List<AdventureEndNode>
		{
			new AdventureEndNode("27ff6659-cfe1-47b5-9ae7-0eb4ac4ffcc9", "E", "LK_Adventure_NodeTitle_221", 22),
			new AdventureEndNode("971b3d7d-fe5e-41a0-961f-fde5d95291c8", "F", "LK_Adventure_NodeTitle_221", 22),
			new AdventureEndNode("e4b71db2-1f7e-4e62-8e23-1ceafb35476f", "G", "LK_Adventure_NodeTitle_222", 18)
		}, new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 5, "", new int[2] { 13, 100 }, new int[41]
			{
				5, 7, 18, 60, 15, 10, 5, 10, 60, 7,
				16, 10, 10, 10, 10, 10, 60, 7, 17, 10,
				0, 10, 20, 10, 60, 7, 19, 10, 10, 10,
				0, 20, 60, 7, 21, 10, 0, 10, 10, 20,
				60
			}, new int[5] { 100, 10, 10, 10, 30 }, new string[17]
			{
				"0", "0", "0", "0", "6", "de0d569d-fe12-479f-ad27-627efbbbf1f9", "10", "0e6cfcd8-d07a-402d-95e3-cf3982aa7cc5", "10", "5fa128a5-a478-47e0-9092-9b2590f488e1",
				"10", "99d92340-7356-49b2-8ec2-244046df516e", "10", "2befa9df-7551-431c-9d1e-abf2b5bd49ae", "10", "f1115a09-5dfd-451a-9207-7fa16ded9f22", "10"
			}, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "1", 1, 10, "", new int[2] { 13, 100 }, new int[41]
			{
				5, 7, 18, 40, 10, 20, 0, 60, 10, 7,
				16, 30, 10, 20, 10, 60, 0, 7, 17, 5,
				0, 20, 20, 60, 0, 7, 19, 5, 0, 10,
				20, 60, 10, 7, 21, 20, 10, 10, 10, 60,
				10
			}, new int[5] { 100, 0, 100, 20, 100 }, new string[7] { "0", "0", "0", "1", "8560cadf-d2e2-44e8-9bb8-289fcc248037", "30", "0" }, new int[23]
			{
				0, 3, 8, 1300, 50, 8, 1950, 30, 8, 2600,
				20, 0, 3, 7, 260, 5, 7, 390, 3, 7,
				520, 2, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 3, "2", 1, 10, "", new int[2] { 13, 100 }, new int[41]
			{
				5, 7, 18, 40, 10, 20, 0, 60, 10, 7,
				16, 30, 10, 20, 10, 60, 0, 7, 17, 5,
				0, 20, 20, 60, 0, 7, 19, 5, 0, 10,
				20, 60, 10, 7, 21, 20, 10, 10, 10, 60,
				10
			}, new int[5] { 100, 0, 100, 20, 100 }, new string[7] { "0", "0", "0", "1", "8560cadf-d2e2-44e8-9bb8-289fcc248037", "30", "0" }, new int[23]
			{
				0, 3, 8, 1300, 50, 8, 1950, 30, 8, 2600,
				20, 0, 3, 7, 260, 5, 7, 390, 3, 7,
				520, 2, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 4, "1", 1, 10, "", new int[2] { 13, 100 }, new int[41]
			{
				5, 7, 18, 30, 10, 10, 10, 50, 20, 7,
				16, 10, 10, 10, 10, 50, 20, 7, 22, 20,
				10, 10, 10, 50, 20, 7, 20, 20, 10, 10,
				10, 50, 20, 7, 19, 20, 10, 10, 10, 50,
				20
			}, new int[5] { 100, 0, 100, 20, 10 }, new string[13]
			{
				"0", "0", "0", "2", "7348baa0-a70e-42de-80b4-feb64bb759e0", "15", "1327fae0-f1d1-4145-ab43-798353d631c5", "15", "2", "d8e3fc18-2239-4bd5-9d5c-d31942020b66",
				"10", "62847b89-5e6b-4ebb-ad97-cd4d01bea638", "10"
			}, new int[23]
			{
				0, 3, 8, 1300, 50, 8, 1950, 30, 8, 2600,
				20, 0, 3, 7, 260, 5, 7, 390, 3, 7,
				520, 2, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 5, "2", 1, 10, "", new int[2] { 13, 100 }, new int[41]
			{
				5, 7, 18, 30, 10, 10, 10, 50, 20, 7,
				16, 10, 10, 10, 10, 50, 20, 7, 22, 20,
				10, 10, 10, 50, 20, 7, 20, 20, 10, 10,
				10, 50, 20, 7, 6, 20, 10, 10, 10, 50,
				20
			}, new int[5] { 100, 0, 100, 20, 10 }, new string[13]
			{
				"0", "0", "0", "2", "6c6c8649-6d41-4fe9-acae-a5a2a57c3d63", "15", "3d0e7523-bd04-4950-87d1-d22815a5df21", "15", "2", "4b67d4d4-d9c6-48fa-bd69-95560ce8545d",
				"10", "d7eb90f0-7948-410f-bec1-917d4ad1bf88", "10"
			}, new int[23]
			{
				0, 3, 8, 1300, 50, 8, 1950, 30, 8, 2600,
				20, 0, 3, 7, 260, 5, 7, 390, 3, 7,
				520, 2, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 6, "1", 1, 10, "", new int[2] { 13, 100 }, new int[25]
			{
				3, 7, 18, 60, 5, 15, 5, 70, 5, 7,
				17, 20, 5, 15, 5, 70, 5, 7, 22, 20,
				5, 15, 5, 70, 5
			}, new int[5] { 100, 0, 100, 20, 100 }, new string[7] { "0", "0", "0", "1", "8560cadf-d2e2-44e8-9bb8-289fcc248037", "30", "0" }, new int[23]
			{
				0, 3, 8, 1300, 50, 8, 1950, 30, 8, 2600,
				20, 0, 3, 7, 260, 5, 7, 390, 3, 7,
				520, 2, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, new List<AdventureAdvancedBranch>
		{
			new AdventureAdvancedBranch(4, "", 1, 13, 400, new int[2] { 13, 100 }, new int[25]
			{
				3, 7, 1, 20, 100, 0, 0, 0, 0, 7,
				11, 40, 100, 0, 0, 0, 0, 7, 12, 40,
				100, 0, 0, 0, 0
			}, new int[5] { 10, 10, 10, 10, 10 }, new string[5] { "0", "0", "0", "0", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureAdvancedBranch(5, "", 3, 13, 400, new int[2] { 13, 100 }, new int[25]
			{
				3, 7, 1, 20, 100, 0, 0, 0, 0, 7,
				11, 40, 100, 0, 0, 0, 0, 7, 12, 40,
				100, 0, 0, 0, 0
			}, new int[5] { 10, 10, 10, 10, 10 }, new string[5] { "0", "0", "0", "0", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureAdvancedBranch(5, "", 4, 13, 400, new int[2] { 13, 100 }, new int[25]
			{
				3, 7, 1, 20, 100, 0, 0, 0, 0, 7,
				11, 40, 100, 0, 0, 0, 0, 7, 12, 40,
				100, 0, 0, 0, 0
			}, new int[5] { 10, 10, 10, 10, 10 }, new string[5] { "0", "0", "0", "0", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureAdvancedBranch(5, "", 5, 13, 400, new int[2] { 13, 100 }, new int[25]
			{
				3, 7, 18, 60, 100, 0, 0, 0, 0, 7,
				17, 20, 100, 0, 0, 0, 0, 7, 22, 20,
				100, 0, 0, 0, 0
			}, new int[5] { 10, 10, 10, 10, 10 }, new string[5] { "0", "0", "0", "0", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray10 = _dataArray;
		string config19 = LocalStringManager.GetConfig("Adventure_language", "Name_69");
		string config20 = LocalStringManager.GetConfig("Adventure_language", "Desc_69");
		int[] resCost10 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost9 = list;
		short[] malice9 = new short[3];
		adventureParams = new List<(string, string, string, string)>();
		dataArray10.Add(new AdventureItem(69, config19, config20, 4, 9, 9, 0, 10, -1, resCost10, itemCost9, restrictedByWorldPopulation: false, malice9, adventureParams, "f7fd890d-2e40-4a48-a763-52e4d9f551b4", new List<AdventureStartNode>
		{
			new AdventureStartNode("6d6e0e91-8297-45ac-847e-99545eef5a2d", "A", "LK_Adventure_NodeTitle_223", 17)
		}, new List<AdventureTransferNode>
		{
			new AdventureTransferNode("325ec9af-0a99-498a-b771-d47ac69f4e9a", "B", "LK_Adventure_NodeTitle_224", 18),
			new AdventureTransferNode("1f66d49c-297b-49f5-a48d-60d565788e10", "C", "LK_Adventure_NodeTitle_225", 21)
		}, new List<AdventureEndNode>
		{
			new AdventureEndNode("1a8a1c26-6ffe-4df5-9422-79c43fb66cb5", "D", "LK_Adventure_NodeTitle_226", 20)
		}, new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 2, 5, "", new int[4] { 4, 50, 5, 50 }, new int[33]
			{
				4, 7, 17, 40, 10, 20, 5, 60, 5, 7,
				18, 30, 5, 20, 10, 60, 5, 7, 16, 10,
				5, 20, 5, 60, 10, 7, 7, 20, 5, 20,
				5, 60, 10
			}, new int[5] { 100, 0, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "c47fc517-275f-4c5f-8e4c-f34b7e341258", "30", "0" }, new int[14]
			{
				0, 3, 8, 2100, 50, 8, 3150, 30, 8, 4200,
				20, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "1", 2, 10, "", new int[4] { 4, 50, 5, 50 }, new int[49]
			{
				6, 7, 17, 10, 10, 20, 15, 50, 5, 7,
				18, 20, 5, 20, 10, 50, 15, 7, 16, 10,
				15, 20, 5, 50, 10, 7, 7, 20, 10, 20,
				15, 50, 5, 7, 21, 20, 5, 20, 10, 50,
				15, 7, 5, 20, 5, 20, 15, 50, 10
			}, new int[5] { 100, 0, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "c47fc517-275f-4c5f-8e4c-f34b7e341258", "30", "0" }, new int[14]
			{
				0, 3, 8, 2100, 50, 8, 3150, 30, 8, 4200,
				20, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 3, "1", 2, 10, "", new int[4] { 4, 50, 5, 50 }, new int[41]
			{
				5, 7, 17, 30, 10, 30, 15, 40, 5, 7,
				18, 20, 15, 30, 10, 40, 5, 7, 16, 20,
				15, 30, 5, 40, 10, 7, 20, 20, 15, 30,
				10, 40, 5, 7, 18, 10, 5, 30, 5, 40,
				20
			}, new int[5] { 100, 0, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "c47fc517-275f-4c5f-8e4c-f34b7e341258", "30", "0" }, new int[14]
			{
				0, 3, 8, 2100, 50, 8, 3150, 30, 8, 4200,
				20, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, new List<AdventureAdvancedBranch>
		{
			new AdventureAdvancedBranch(4, "", 1, 5, 450, new int[2] { 5, 100 }, new int[9] { 1, 7, 7, 100, 0, 0, 0, 0, 100 }, new int[5] { 10, 10, 10, 10, 0 }, new string[7] { "0", "0", "0", "0", "1", "bc151e17-994f-4efd-a912-43ab6c2ecd6b", "100" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureAdvancedBranch(4, "", 2, 4, 450, new int[2] { 4, 100 }, new int[4] { 1, 2, 20, 100 }, new int[5] { 10, 10, 10, 10, 10 }, new string[5] { "0", "0", "0", "0", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray11 = _dataArray;
		string config21 = LocalStringManager.GetConfig("Adventure_language", "Name_70");
		string config22 = LocalStringManager.GetConfig("Adventure_language", "Desc_70");
		int[] resCost11 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost10 = list;
		short[] malice10 = new short[3];
		adventureParams = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams5 = adventureParams;
		List<AdventureStartNode> startNodes4 = new List<AdventureStartNode>
		{
			new AdventureStartNode("5fc4b28f-a4ac-48d3-8fbb-49e83cda98bd", "A", "LK_Adventure_NodeTitle_227", 11),
			new AdventureStartNode("39086398-2733-42db-9397-2f6b0cd683b3", "B", "LK_Adventure_NodeTitle_227", 11)
		};
		List<AdventureTransferNode> transferNodes4 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("aac8214f-9d34-4690-b15b-c1b4693b181c", "A1", "LK_Adventure_NodeTitle_228", 1),
			new AdventureTransferNode("aac8214f-9d34-4690-b15b-c1b4693b181c", "B01", "LK_Adventure_NodeTitle_228", 1)
		};
		List<AdventureEndNode> endNodes3 = new List<AdventureEndNode>
		{
			new AdventureEndNode("967b23de-4be2-49de-ad11-c529ac15ac7f", "A2", "LK_Adventure_NodeTitle_229", 1),
			new AdventureEndNode("04385dd3-0386-4080-83d0-def6a103ff2c", "B2", "LK_Adventure_NodeTitle_230", 1),
			new AdventureEndNode("04385dd3-0386-4080-83d0-def6a103ff2c", "C", "LK_Adventure_NodeTitle_230", 1),
			new AdventureEndNode("fe9119fc-d56f-4788-bdfd-d311dd2e83b9", "D", "LK_Adventure_NodeTitle_231", 1)
		};
		List<AdventureBaseBranch> baseBranches3 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 2, "1", 1, 2, "", new int[2] { 15, 100 }, new int[25]
			{
				3, 7, 1, 40, 20, 20, 20, 20, 20, 7,
				6, 20, 20, 20, 20, 20, 20, 7, 11, 40,
				20, 20, 20, 20, 20
			}, new int[5] { 10, 0, 0, 10, 10 }, new string[5] { "0", "0", "0", "0", "0" }, new int[14]
			{
				0, 3, 8, 50, 50, 8, 100, 30, 8, 150,
				20, 0, 0, 0
			}, new int[85]
			{
				0, 0, 20, 0, -1, 1, 2, 0, -2, 1,
				2, 0, -3, 1, 2, 0, -4, 1, 2, 0,
				-5, 1, 2, 0, -6, 1, 2, 0, -7, 1,
				2, 0, -8, 1, 2, 0, -9, 1, 2, 0,
				-10, 1, 2, 0, -11, 1, 2, 0, -12, 1,
				2, 0, -13, 1, 2, 0, -14, 1, 2, 0,
				-15, 1, 2, 0, -16, 1, 2, 1, -101, 1,
				2, 1, -102, 1, 2, 1, -103, 1, 2, 1,
				-104, 1, 2, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 4, "2", 1, 8, "", new int[2] { 15, 100 }, new int[17]
			{
				2, 7, 1, 50, 5, 10, 20, 60, 5, 7,
				11, 50, 5, 10, 20, 60, 5
			}, new int[5] { 10, 0, 0, 20, 10 }, new string[9] { "0", "0", "0", "2", "e213b931-4bd6-4821-9fdb-9de620923757", "15", "183b4885-1d63-4981-adef-1392456be039", "15", "0" }, new int[14]
			{
				0, 3, 8, 50, 50, 8, 100, 30, 8, 150,
				20, 0, 0, 0
			}, new int[85]
			{
				0, 0, 20, 0, -1, 1, 2, 0, -2, 1,
				2, 0, -3, 1, 2, 0, -4, 1, 2, 0,
				-5, 1, 2, 0, -6, 1, 2, 0, -7, 1,
				2, 0, -8, 1, 2, 0, -9, 1, 2, 0,
				-10, 1, 2, 0, -11, 1, 2, 0, -12, 1,
				2, 0, -13, 1, 2, 0, -14, 1, 2, 0,
				-15, 1, 2, 0, -16, 1, 2, 1, -101, 1,
				2, 1, -102, 1, 2, 1, -103, 1, 2, 1,
				-104, 1, 2, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 6, "4", 1, 8, "", new int[2] { 15, 100 }, new int[17]
			{
				2, 7, 1, 50, 5, 10, 20, 60, 5, 7,
				11, 50, 5, 10, 20, 60, 5
			}, new int[5] { 10, 0, 20, 10, 10 }, new string[13]
			{
				"0", "0", "0", "4", "67cf5b3c-8866-4487-98cc-b545b87ee01a", "5", "c3cf7a10-af02-4603-8018-55a5515c0be2", "5", "7163f4b7-1b44-468a-b565-0ed3a021d5b9", "5",
				"bdf3ef17-6e53-45cb-a608-e799576d57f1", "5", "0"
			}, new int[14]
			{
				0, 3, 8, 50, 50, 8, 100, 30, 8, 150,
				20, 0, 0, 0
			}, new int[85]
			{
				0, 0, 20, 0, -1, 1, 2, 0, -2, 1,
				2, 0, -3, 1, 2, 0, -4, 1, 2, 0,
				-5, 1, 2, 0, -6, 1, 2, 0, -7, 1,
				2, 0, -8, 1, 2, 0, -9, 1, 2, 0,
				-10, 1, 2, 0, -11, 1, 2, 0, -12, 1,
				2, 0, -13, 1, 2, 0, -14, 1, 2, 0,
				-15, 1, 2, 0, -16, 1, 2, 1, -101, 1,
				2, 1, -102, 1, 2, 1, -103, 1, 2, 1,
				-104, 1, 2, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 3, "2", 1, 2, "", new int[2] { 15, 100 }, new int[25]
			{
				3, 7, 1, 40, 20, 20, 20, 20, 20, 7,
				6, 20, 20, 20, 20, 20, 20, 7, 11, 40,
				20, 20, 20, 20, 20
			}, new int[5] { 10, 0, 0, 10, 10 }, new string[5] { "0", "0", "0", "0", "0" }, new int[14]
			{
				0, 3, 8, 50, 50, 8, 100, 30, 8, 150,
				20, 0, 0, 0
			}, new int[85]
			{
				0, 0, 20, 0, -1, 1, 2, 0, -2, 1,
				2, 0, -3, 1, 2, 0, -4, 1, 2, 0,
				-5, 1, 2, 0, -6, 1, 2, 0, -7, 1,
				2, 0, -8, 1, 2, 0, -9, 1, 2, 0,
				-10, 1, 2, 0, -11, 1, 2, 0, -12, 1,
				2, 0, -13, 1, 2, 0, -14, 1, 2, 0,
				-15, 1, 2, 0, -16, 1, 2, 1, -101, 1,
				2, 1, -102, 1, 2, 1, -103, 1, 2, 1,
				-104, 1, 2, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 5, "3", 1, 8, "", new int[2] { 15, 100 }, new int[17]
			{
				2, 7, 1, 50, 5, 10, 20, 60, 5, 7,
				11, 50, 5, 10, 20, 60, 5
			}, new int[5] { 10, 0, 20, 10, 10 }, new string[13]
			{
				"0", "0", "0", "4", "81674039-c596-4328-b00f-94e6e2bc5329", "5", "ed047e49-444c-489e-8498-45a70b09ad19", "5", "0ff04b74-6cc3-4a57-a7eb-e3453c70c758", "5",
				"3fbde7c9-86d3-434f-9048-53be57c57e86", "5", "0"
			}, new int[14]
			{
				0, 3, 8, 50, 50, 8, 100, 30, 8, 150,
				20, 0, 0, 0
			}, new int[85]
			{
				0, 0, 20, 0, -1, 1, 2, 0, -2, 1,
				2, 0, -3, 1, 2, 0, -4, 1, 2, 0,
				-5, 1, 2, 0, -6, 1, 2, 0, -7, 1,
				2, 0, -8, 1, 2, 0, -9, 1, 2, 0,
				-10, 1, 2, 0, -11, 1, 2, 0, -12, 1,
				2, 0, -13, 1, 2, 0, -14, 1, 2, 0,
				-15, 1, 2, 0, -16, 1, 2, 1, -101, 1,
				2, 1, -102, 1, 2, 1, -103, 1, 2, 1,
				-104, 1, 2, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 7, "5", 1, 8, "", new int[2] { 15, 100 }, new int[17]
			{
				2, 7, 1, 50, 5, 10, 20, 60, 5, 7,
				11, 50, 5, 10, 20, 60, 5
			}, new int[5] { 10, 0, 20, 20, 10 }, new string[9] { "0", "0", "0", "2", "3100fc7b-1cfd-47c9-89d7-c7cce9ddabe0", "15", "3277151d-b747-4ed6-bf62-f97553a2f2df", "15", "0" }, new int[14]
			{
				0, 3, 8, 50, 50, 8, 100, 30, 8, 150,
				20, 0, 0, 0
			}, new int[85]
			{
				0, 0, 20, 0, -1, 1, 2, 0, -2, 1,
				2, 0, -3, 1, 2, 0, -4, 1, 2, 0,
				-5, 1, 2, 0, -6, 1, 2, 0, -7, 1,
				2, 0, -8, 1, 2, 0, -9, 1, 2, 0,
				-10, 1, 2, 0, -11, 1, 2, 0, -12, 1,
				2, 0, -13, 1, 2, 0, -14, 1, 2, 0,
				-15, 1, 2, 0, -16, 1, 2, 1, -101, 1,
				2, 1, -102, 1, 2, 1, -103, 1, 2, 1,
				-104, 1, 2, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray11.Add(new AdventureItem(70, config21, config22, 5, 2, 2, 2, 10, -1, resCost11, itemCost10, restrictedByWorldPopulation: false, malice10, adventureParams5, "690cafb1-e540-494c-b2f5-5e47bc6e1120", startNodes4, transferNodes4, endNodes3, baseBranches3, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray12 = _dataArray;
		string config23 = LocalStringManager.GetConfig("Adventure_language", "Name_71");
		string config24 = LocalStringManager.GetConfig("Adventure_language", "Desc_71");
		int[] resCost12 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost11 = list;
		short[] malice11 = new short[3];
		adventureParams = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams6 = adventureParams;
		List<AdventureStartNode> startNodes5 = new List<AdventureStartNode>
		{
			new AdventureStartNode("190df73f-7b7f-4678-8c7f-222ba2c1c132", "A", "LK_Adventure_NodeTitle_232", 17)
		};
		List<AdventureTransferNode> transferNodes5 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("c06529c1-6555-400e-ac22-8ba95d915395", "A01", "LK_Adventure_NodeTitle_233", 3),
			new AdventureTransferNode("6aecc30e-3329-4394-986e-ef32811c6a43", "B", "LK_Adventure_NodeTitle_234", 1)
		};
		List<AdventureEndNode> endNodes4 = new List<AdventureEndNode>
		{
			new AdventureEndNode("e6e2906b-956a-4cff-b949-256de16d2bf1", "B01", "LK_Adventure_NodeTitle_235", 1),
			new AdventureEndNode("72728521-89b9-49a2-af54-4b8805928128", "A02", "LK_Adventure_NodeTitle_236", 11)
		};
		List<AdventureBaseBranch> baseBranches4 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 2, "", new int[4] { 15, 50, 1, 50 }, new int[17]
			{
				2, 7, 1, 50, 20, 20, 20, 20, 20, 7,
				11, 50, 20, 20, 20, 20, 20
			}, new int[5] { 10, 0, 10, 10, 10 }, new string[5] { "0", "0", "0", "0", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[9] { 0, 0, 1, 10, -1002, 1, 10, 0, 0 }, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 1, 10, "", new int[2] { 4, 1 }, new int[17]
			{
				2, 7, 1, 50, 5, 15, 15, 60, 5, 7,
				11, 50, 5, 15, 15, 60, 5
			}, new int[5] { 10, 0, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "701d933d-40ef-4818-b3aa-182e9e0165be", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[9] { 0, 0, 1, 10, -1002, 1, 10, 0, 0 }, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 3, "3", 1, 15, "", new int[4] { 15, 50, 1, 50 }, new int[17]
			{
				2, 7, 1, 50, 5, 15, 15, 60, 5, 7,
				11, 50, 5, 15, 15, 60, 5
			}, new int[5] { 10, 0, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "f991864c-1dc0-43f2-95f4-7d831f7aa1ef", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[9] { 0, 0, 1, 10, -1002, 1, 10, 0, 0 }, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 4, "4", 1, 10, "", new int[2] { 4, 1 }, new int[17]
			{
				2, 7, 1, 50, 5, 15, 15, 60, 5, 7,
				11, 50, 5, 15, 15, 60, 5
			}, new int[5] { 10, 0, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "9ab5d633-4743-4f0d-a4e9-b15dbf01aeec", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[9] { 0, 0, 1, 10, -1002, 1, 10, 0, 0 }, new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray12.Add(new AdventureItem(71, config23, config24, 5, 5, 5, 2, 10, -1, resCost12, itemCost11, restrictedByWorldPopulation: false, malice11, adventureParams6, "5fd77391-e094-47d7-87a2-71000d480a4b", startNodes5, transferNodes5, endNodes4, baseBranches4, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray13 = _dataArray;
		string config25 = LocalStringManager.GetConfig("Adventure_language", "Name_72");
		string config26 = LocalStringManager.GetConfig("Adventure_language", "Desc_72");
		int[] resCost13 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost12 = list;
		short[] malice12 = new short[3];
		adventureParams = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams7 = adventureParams;
		List<AdventureStartNode> startNodes6 = new List<AdventureStartNode>
		{
			new AdventureStartNode("5f6257bf-3a9b-4b5d-95f0-7c016448bef8", "A", "LK_Adventure_NodeTitle_237", 3)
		};
		List<AdventureTransferNode> transferNodes6 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("75fecc75-cbf4-421e-aae3-ae059a0a8b79", "A01", "LK_Adventure_NodeTitle_238", 3),
			new AdventureTransferNode("1e0e1593-2e94-4612-942d-cee63f50716f", "B01", "LK_Adventure_NodeTitle_239", 3),
			new AdventureTransferNode("17967357-c439-4d6f-892c-c3eae4d51e09", "A03", "LK_Adventure_NodeTitle_240", 3)
		};
		List<AdventureEndNode> endNodes5 = new List<AdventureEndNode>
		{
			new AdventureEndNode("8e141c51-74c9-4f14-bbd9-5c670a3b770e", "A02", "LK_Adventure_NodeTitle_241", 3),
			new AdventureEndNode("4188891d-bc1b-4a0a-b792-d80260937c35", "B", "LK_Adventure_NodeTitle_242", 3)
		};
		List<AdventureBaseBranch> baseBranches5 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 3, "2", 1, 3, "", new int[2] { 8, 100 }, new int[25]
			{
				3, 7, 3, 50, 10, 35, 10, 35, 10, 7,
				1, 20, 10, 35, 10, 35, 10, 7, 17, 30,
				10, 35, 10, 35, 10
			}, new int[5] { 10, 0, 10, 0, 10 }, new string[5] { "0", "0", "0", "0", "0" }, new int[23]
			{
				0, 3, 8, 1300, 50, 8, 1950, 30, 8, 2600,
				20, 0, 3, 7, 260, 50, 7, 390, 30, 7,
				520, 20, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 1, "1", 1, 8, "", new int[2] { 8, 100 }, new int[25]
			{
				3, 7, 3, 50, 10, 15, 10, 55, 10, 7,
				1, 20, 10, 15, 10, 55, 10, 7, 17, 30,
				10, 15, 10, 55, 10
			}, new int[5] { 10, 0, 10, 20, 10 }, new string[11]
			{
				"0", "0", "0", "3", "218a76ba-89a7-4010-9d08-bdf16b6a668b", "10", "66b22438-b077-4ced-81cc-12a8881360fa", "10", "86dba6a2-4a92-4396-83ac-e922cd5fed31", "10",
				"0"
			}, new int[23]
			{
				0, 3, 8, 1300, 50, 8, 1950, 30, 8, 2600,
				20, 0, 3, 7, 260, 5, 7, 390, 3, 7,
				520, 2, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 5, "2", 1, 20, "", new int[2] { 8, 100 }, new int[25]
			{
				3, 7, 3, 50, 10, 20, 20, 55, 10, 7,
				1, 20, 10, 20, 20, 55, 10, 7, 17, 30,
				10, 20, 20, 55, 10
			}, new int[5] { 10, 0, 10, 20, 10 }, new string[11]
			{
				"0", "0", "0", "3", "b7b70956-114e-418a-9c7d-8473e9ae91f0", "10", "160eb8b2-2035-4385-a8ec-bd92edb50a5a", "10", "86af2709-a660-4d8f-b7be-b99f4e39ac46", "10",
				"0"
			}, new int[23]
			{
				0, 3, 8, 1300, 50, 8, 1950, 30, 8, 2600,
				20, 0, 3, 7, 260, 5, 7, 390, 3, 7,
				520, 2, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "3", 1, 8, "", new int[2] { 8, 100 }, new int[25]
			{
				3, 7, 3, 50, 10, 15, 10, 55, 10, 7,
				1, 20, 10, 15, 10, 55, 10, 7, 17, 30,
				10, 15, 10, 55, 10
			}, new int[5] { 10, 0, 10, 20, 10 }, new string[11]
			{
				"0", "0", "0", "3", "218a76ba-89a7-4010-9d08-bdf16b6a668b", "10", "66b22438-b077-4ced-81cc-12a8881360fa", "10", "86dba6a2-4a92-4396-83ac-e922cd5fed31", "10",
				"0"
			}, new int[23]
			{
				0, 3, 8, 1300, 50, 8, 1950, 30, 8, 2600,
				20, 0, 3, 7, 260, 5, 7, 390, 3, 7,
				520, 2, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 4, "4", 1, 8, "", new int[2] { 8, 100 }, new int[25]
			{
				3, 7, 3, 50, 10, 15, 10, 55, 10, 7,
				1, 20, 10, 15, 10, 55, 10, 7, 17, 30,
				10, 15, 10, 55, 10
			}, new int[5] { 10, 0, 10, 20, 10 }, new string[11]
			{
				"0", "0", "0", "3", "218a76ba-89a7-4010-9d08-bdf16b6a668b", "10", "66b22438-b077-4ced-81cc-12a8881360fa", "10", "86dba6a2-4a92-4396-83ac-e922cd5fed31", "10",
				"0"
			}, new int[23]
			{
				0, 3, 8, 1300, 50, 8, 1950, 30, 8, 2600,
				20, 0, 3, 7, 260, 5, 7, 390, 3, 7,
				520, 2, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray13.Add(new AdventureItem(72, config25, config26, 5, 8, 8, 2, 10, -1, resCost13, itemCost12, restrictedByWorldPopulation: false, malice12, adventureParams7, "77353137-8ce7-48f7-abfe-b7c878767f6b", startNodes6, transferNodes6, endNodes5, baseBranches5, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray14 = _dataArray;
		string config27 = LocalStringManager.GetConfig("Adventure_language", "Name_73");
		string config28 = LocalStringManager.GetConfig("Adventure_language", "Desc_73");
		int[] resCost14 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost13 = list;
		short[] malice13 = new short[3];
		adventureParams = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams8 = adventureParams;
		List<AdventureStartNode> startNodes7 = new List<AdventureStartNode>
		{
			new AdventureStartNode("e151d279-8703-471d-a2dd-faac28aa3d7d", "A", "LK_Adventure_NodeTitle_243", 9)
		};
		List<AdventureTransferNode> transferNodes7 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("b89eb865-5246-40ad-a59f-f289a5c8831a", "B", "LK_Adventure_NodeTitle_244", 9),
			new AdventureTransferNode("f557b815-3f3b-4c64-80cb-4aa47b7411ae", "C", "LK_Adventure_NodeTitle_244", 9),
			new AdventureTransferNode("7100938d-a0ad-4f76-8870-717d688634b8", "D", "LK_Adventure_NodeTitle_244", 9)
		};
		List<AdventureEndNode> endNodes6 = new List<AdventureEndNode>
		{
			new AdventureEndNode("102fc53f-2d52-46dd-86b9-9c97c21edc30", "E", "LK_Adventure_NodeTitle_245", 9)
		};
		List<AdventureBaseBranch> baseBranches6 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 4, "", new int[6] { 6, 20, 7, 20, 11, 20 }, new int[9] { 1, 7, 9, 50, 10, 10, 10, 60, 10 }, new int[5] { 50, 50, 50, 0, 50 }, new string[7] { "0", "0", "0", "1", "d9cf0899-1916-4eef-ba94-32c5098424b2", "30", "0" }, new int[14]
			{
				0, 0, 0, 3, 8, 200, 5, 8, 300, 3,
				8, 400, 2, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 1, 4, "", new int[2] { 0, 100 }, new int[9] { 1, 7, 9, 50, 10, 10, 10, 60, 10 }, new int[5] { 50, 50, 50, 0, 50 }, new string[7] { "0", "0", "0", "1", "d9cf0899-1916-4eef-ba94-32c5098424b2", "30", "0" }, new int[14]
			{
				0, 0, 0, 3, 8, 300, 5, 8, 450, 3,
				8, 600, 2, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 3, "3", 1, 4, "", new int[2] { 0, 100 }, new int[9] { 1, 7, 9, 50, 10, 10, 10, 60, 10 }, new int[5] { 50, 50, 50, 0, 50 }, new string[7] { "0", "0", "0", "1", "d9cf0899-1916-4eef-ba94-32c5098424b2", "30", "0" }, new int[14]
			{
				0, 0, 0, 3, 8, 500, 5, 8, 750, 3,
				8, 1000, 2, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 4, "4", 1, 4, "", new int[6] { 6, 20, 7, 20, 11, 20 }, new int[9] { 1, 7, 9, 50, 10, 10, 10, 60, 10 }, new int[5] { 50, 50, 50, 0, 50 }, new string[7] { "0", "0", "0", "1", "d9cf0899-1916-4eef-ba94-32c5098424b2", "30", "0" }, new int[14]
			{
				0, 0, 0, 3, 8, 800, 5, 8, 1200, 3,
				8, 1600, 2, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray14.Add(new AdventureItem(73, config27, config28, 6, 6, 1, 1, 10, 3, resCost14, itemCost13, restrictedByWorldPopulation: false, malice13, adventureParams8, "25a42d7a-6aa9-4e64-b8e4-3b8ccbb21dd5", startNodes7, transferNodes7, endNodes6, baseBranches6, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray15 = _dataArray;
		string config29 = LocalStringManager.GetConfig("Adventure_language", "Name_74");
		string config30 = LocalStringManager.GetConfig("Adventure_language", "Desc_74");
		int[] resCost15 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost14 = list;
		short[] malice14 = new short[3];
		adventureParams = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams9 = adventureParams;
		List<AdventureStartNode> startNodes8 = new List<AdventureStartNode>
		{
			new AdventureStartNode("676523e1-4467-4a36-b8fb-2b043bea70fa", "A", "LK_Adventure_NodeTitle_243", 9)
		};
		List<AdventureTransferNode> transferNodes8 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("b89eb865-5246-40ad-a59f-f289a5c8831a", "B", "LK_Adventure_NodeTitle_244", 9),
			new AdventureTransferNode("f557b815-3f3b-4c64-80cb-4aa47b7411ae", "C", "LK_Adventure_NodeTitle_244", 10),
			new AdventureTransferNode("7100938d-a0ad-4f76-8870-717d688634b8", "D", "LK_Adventure_NodeTitle_244", 9)
		};
		List<AdventureEndNode> endNodes7 = new List<AdventureEndNode>
		{
			new AdventureEndNode("102fc53f-2d52-46dd-86b9-9c97c21edc30", "E", "LK_Adventure_NodeTitle_245", 9)
		};
		List<AdventureBaseBranch> baseBranches7 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 4, "", new int[2] { 0, 100 }, new int[9] { 1, 7, 9, 50, 10, 10, 10, 60, 10 }, new int[5] { 50, 50, 50, 0, 50 }, new string[7] { "0", "0", "0", "1", "d9cf0899-1916-4eef-ba94-32c5098424b2", "30", "0" }, new int[14]
			{
				0, 0, 0, 3, 8, 200, 5, 8, 300, 3,
				8, 400, 2, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 1, 4, "", new int[2] { 0, 100 }, new int[9] { 1, 7, 9, 50, 10, 10, 10, 60, 10 }, new int[5] { 50, 50, 50, 0, 50 }, new string[7] { "0", "0", "0", "1", "d9cf0899-1916-4eef-ba94-32c5098424b2", "30", "0" }, new int[14]
			{
				0, 0, 0, 3, 8, 300, 5, 8, 450, 3,
				8, 600, 2, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 3, "3", 1, 4, "", new int[2] { 0, 100 }, new int[9] { 1, 7, 9, 50, 10, 10, 10, 60, 10 }, new int[5] { 50, 50, 50, 0, 50 }, new string[7] { "0", "0", "0", "1", "d9cf0899-1916-4eef-ba94-32c5098424b2", "30", "0" }, new int[14]
			{
				0, 0, 0, 3, 8, 500, 5, 8, 750, 3,
				8, 1000, 2, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 4, "4", 1, 4, "", new int[2] { 0, 100 }, new int[9] { 1, 7, 9, 50, 10, 10, 10, 60, 10 }, new int[5] { 50, 50, 50, 0, 50 }, new string[7] { "0", "0", "0", "1", "d9cf0899-1916-4eef-ba94-32c5098424b2", "30", "0" }, new int[14]
			{
				0, 0, 0, 3, 8, 800, 5, 8, 1200, 3,
				8, 1600, 2, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray15.Add(new AdventureItem(74, config29, config30, 6, 6, 1, 1, 10, 3, resCost15, itemCost14, restrictedByWorldPopulation: false, malice14, adventureParams9, "25a42d7a-6aa9-4e64-b8e4-3b8ccbb21dd5", startNodes8, transferNodes8, endNodes7, baseBranches7, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray16 = _dataArray;
		string config31 = LocalStringManager.GetConfig("Adventure_language", "Name_75");
		string config32 = LocalStringManager.GetConfig("Adventure_language", "Desc_75");
		int[] resCost16 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost15 = list;
		short[] malice15 = new short[3];
		List<(string, string, string, string)> adventureParams10 = new List<(string, string, string, string)> { ("sustainDegree", "LK_Adventure_75_ParamName_0", "", "") };
		List<AdventureStartNode> startNodes9 = new List<AdventureStartNode>
		{
			new AdventureStartNode("21263743-f84c-4019-882b-124340a8d139", "A0", "LK_Adventure_NodeTitle_247", 1),
			new AdventureStartNode("21263743-f84c-4019-882b-124340a8d139", "A1", "LK_Adventure_NodeTitle_248", 1),
			new AdventureStartNode("21263743-f84c-4019-882b-124340a8d139", "A2", "LK_Adventure_NodeTitle_249", 2),
			new AdventureStartNode("21263743-f84c-4019-882b-124340a8d139", "A5", "LK_Adventure_NodeTitle_250", 1),
			new AdventureStartNode("21263743-f84c-4019-882b-124340a8d139", "A3", "LK_Adventure_NodeTitle_251", 1),
			new AdventureStartNode("21263743-f84c-4019-882b-124340a8d139", "A4", "LK_Adventure_NodeTitle_252", 1),
			new AdventureStartNode("21263743-f84c-4019-882b-124340a8d139", "A6", "LK_Adventure_NodeTitle_253", 1),
			new AdventureStartNode("21263743-f84c-4019-882b-124340a8d139", "A7", "LK_Adventure_NodeTitle_254", 1),
			new AdventureStartNode("21263743-f84c-4019-882b-124340a8d139", "A8", "LK_Adventure_NodeTitle_255", 1),
			new AdventureStartNode("21263743-f84c-4019-882b-124340a8d139", "A9", "LK_Adventure_NodeTitle_256", 1),
			new AdventureStartNode("21263743-f84c-4019-882b-124340a8d139", "A10", "LK_Adventure_NodeTitle_257", 1),
			new AdventureStartNode("21263743-f84c-4019-882b-124340a8d139", "A11", "LK_Adventure_NodeTitle_258", 4),
			new AdventureStartNode("21263743-f84c-4019-882b-124340a8d139", "A12", "LK_Adventure_NodeTitle_259", 22),
			new AdventureStartNode("21263743-f84c-4019-882b-124340a8d139", "A13", "LK_Adventure_NodeTitle_260", 5),
			new AdventureStartNode("21263743-f84c-4019-882b-124340a8d139", "A14", "LK_Adventure_NodeTitle_261", 2)
		};
		List<AdventureTransferNode> transferNodes9 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("12c48a31-eecf-49fa-9796-fb52d7b7adc5", "B0", "LK_Adventure_NodeTitle_262", 1),
			new AdventureTransferNode("12c48a31-eecf-49fa-9796-fb52d7b7adc5", "B1", "LK_Adventure_NodeTitle_263", 1),
			new AdventureTransferNode("12c48a31-eecf-49fa-9796-fb52d7b7adc5", "B2", "LK_Adventure_NodeTitle_264", 2),
			new AdventureTransferNode("12c48a31-eecf-49fa-9796-fb52d7b7adc5", "B3", "LK_Adventure_NodeTitle_265", 1),
			new AdventureTransferNode("12c48a31-eecf-49fa-9796-fb52d7b7adc5", "B4", "LK_Adventure_NodeTitle_266", 1),
			new AdventureTransferNode("12c48a31-eecf-49fa-9796-fb52d7b7adc5", "B5", "LK_Adventure_NodeTitle_267", 1),
			new AdventureTransferNode("12c48a31-eecf-49fa-9796-fb52d7b7adc5", "B6", "LK_Adventure_NodeTitle_268", 1),
			new AdventureTransferNode("12c48a31-eecf-49fa-9796-fb52d7b7adc5", "B7", "LK_Adventure_NodeTitle_269", 1),
			new AdventureTransferNode("12c48a31-eecf-49fa-9796-fb52d7b7adc5", "B8", "LK_Adventure_NodeTitle_270", 1),
			new AdventureTransferNode("12c48a31-eecf-49fa-9796-fb52d7b7adc5", "B9", "LK_Adventure_NodeTitle_271", 1),
			new AdventureTransferNode("12c48a31-eecf-49fa-9796-fb52d7b7adc5", "B10", "LK_Adventure_NodeTitle_272", 1),
			new AdventureTransferNode("12c48a31-eecf-49fa-9796-fb52d7b7adc5", "B11", "LK_Adventure_NodeTitle_273", 0),
			new AdventureTransferNode("12c48a31-eecf-49fa-9796-fb52d7b7adc5", "B12", "LK_Adventure_NodeTitle_274", 22),
			new AdventureTransferNode("12c48a31-eecf-49fa-9796-fb52d7b7adc5", "B13", "LK_Adventure_NodeTitle_275", 5),
			new AdventureTransferNode("12c48a31-eecf-49fa-9796-fb52d7b7adc5", "B14", "LK_Adventure_NodeTitle_276", 2)
		};
		List<AdventureEndNode> endNodes8 = new List<AdventureEndNode>
		{
			new AdventureEndNode("917a58a0-63a1-4856-a456-5e44a745cd1b", "C0", "LK_Adventure_NodeTitle_277", 1),
			new AdventureEndNode("917a58a0-63a1-4856-a456-5e44a745cd1b", "C1", "LK_Adventure_NodeTitle_277", 1),
			new AdventureEndNode("917a58a0-63a1-4856-a456-5e44a745cd1b", "C2", "LK_Adventure_NodeTitle_277", 2),
			new AdventureEndNode("917a58a0-63a1-4856-a456-5e44a745cd1b", "C3", "LK_Adventure_NodeTitle_277", 1),
			new AdventureEndNode("917a58a0-63a1-4856-a456-5e44a745cd1b", "C4", "LK_Adventure_NodeTitle_277", 1),
			new AdventureEndNode("917a58a0-63a1-4856-a456-5e44a745cd1b", "C5", "LK_Adventure_NodeTitle_277", 1),
			new AdventureEndNode("917a58a0-63a1-4856-a456-5e44a745cd1b", "C6", "LK_Adventure_NodeTitle_277", 1),
			new AdventureEndNode("917a58a0-63a1-4856-a456-5e44a745cd1b", "C7", "LK_Adventure_NodeTitle_277", 1),
			new AdventureEndNode("917a58a0-63a1-4856-a456-5e44a745cd1b", "C8", "LK_Adventure_NodeTitle_277", 1),
			new AdventureEndNode("917a58a0-63a1-4856-a456-5e44a745cd1b", "C9", "LK_Adventure_NodeTitle_277", 1),
			new AdventureEndNode("917a58a0-63a1-4856-a456-5e44a745cd1b", "C10", "LK_Adventure_NodeTitle_277", 1),
			new AdventureEndNode("917a58a0-63a1-4856-a456-5e44a745cd1b", "C11", "LK_Adventure_NodeTitle_277", 4),
			new AdventureEndNode("917a58a0-63a1-4856-a456-5e44a745cd1b", "C12", "LK_Adventure_NodeTitle_277", 22),
			new AdventureEndNode("917a58a0-63a1-4856-a456-5e44a745cd1b", "C13", "LK_Adventure_NodeTitle_277", 5),
			new AdventureEndNode("917a58a0-63a1-4856-a456-5e44a745cd1b", "C14", "LK_Adventure_NodeTitle_277", 2)
		};
		List<AdventureBaseBranch> baseBranches8 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 15, "1", 1, 5, "", new int[6] { 13, 120, 8, 90, 1, 90 }, new int[25]
			{
				3, 7, 1, 25, 5, 20, 10, 60, 5, 7,
				11, 25, 5, 20, 10, 60, 5, 7, 14, 50,
				5, 20, 10, 60, 5
			}, new int[5] { 10, 100, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "31928037-3497-4879-8006-04d95e0af89b", "50", "0" }, new int[14]
			{
				0, 3, 8, 200, 50, 8, 300, 30, 8, 400,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 2, 0, -5, 1, 5, 0, -11, 1,
				5, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(15, 30, "2", 1, 10, "", new int[6] { 13, 120, 8, 90, 1, 90 }, new int[25]
			{
				3, 7, 1, 50, 5, 20, 10, 60, 5, 7,
				11, 25, 5, 20, 10, 60, 5, 7, 14, 50,
				5, 20, 10, 60, 5
			}, new int[5] { 10, 100, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "1c122053-e860-4cde-b4af-0119777d7a63", "40", "0" }, new int[14]
			{
				0, 3, 8, 400, 50, 8, 600, 30, 8, 800,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 2, 0, -5, 1, 5, 0, -11, 1,
				5, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 16, "1", 1, 5, "", new int[6] { 12, 90, 13, 90, 14, 90 }, new int[33]
			{
				4, 7, 1, 20, 5, 20, 10, 60, 5, 7,
				3, 20, 5, 20, 10, 60, 5, 7, 2, 20,
				5, 20, 10, 60, 5, 7, 6, 10, 5, 20,
				10, 60, 5
			}, new int[5] { 10, 100, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "31928037-3497-4879-8006-04d95e0af89b", "50", "0" }, new int[14]
			{
				0, 3, 8, 200, 50, 8, 300, 30, 8, 400,
				20, 0, 0, 0
			}, new int[17]
			{
				0, 0, 3, 0, -5, 1, 3, 0, -9, 1,
				3, 0, -2, 1, 4, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(16, 31, "2", 1, 10, "", new int[6] { 13, 90, 12, 90, 14, 90 }, new int[33]
			{
				4, 7, 1, 50, 5, 20, 10, 60, 5, 7,
				3, 20, 5, 20, 10, 60, 5, 7, 2, 20,
				5, 20, 10, 60, 5, 7, 6, 10, 5, 20,
				10, 60, 5
			}, new int[5] { 10, 100, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "1c122053-e860-4cde-b4af-0119777d7a63", "40", "0" }, new int[14]
			{
				0, 3, 8, 400, 50, 8, 600, 30, 8, 800,
				20, 0, 0, 0
			}, new int[17]
			{
				0, 0, 3, 0, -5, 1, 3, 0, -9, 1,
				3, 0, -2, 1, 4, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 17, "1", 1, 5, "", new int[10] { 0, 90, 3, 120, 8, 120, 9, 90, 10, 120 }, new int[33]
			{
				4, 7, 10, 30, 5, 20, 10, 60, 5, 7,
				6, 20, 5, 20, 10, 60, 5, 7, 5, 20,
				5, 20, 10, 60, 5, 7, 12, 20, 5, 20,
				10, 60, 5
			}, new int[5] { 10, 100, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "31928037-3497-4879-8006-04d95e0af89b", "50", "0" }, new int[14]
			{
				0, 3, 8, 200, 50, 8, 300, 30, 8, 400,
				20, 0, 0, 0
			}, new int[21]
			{
				0, 0, 4, 0, -5, 1, 3, 0, -1, 1,
				3, 0, -4, 1, 2, 0, -12, 1, 2, 0,
				0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(17, 32, "2", 1, 10, "", new int[10] { 8, 120, 0, 90, 3, 120, 9, 90, 10, 120 }, new int[33]
			{
				4, 7, 10, 50, 5, 20, 10, 60, 5, 7,
				6, 20, 5, 20, 10, 60, 5, 7, 5, 20,
				5, 20, 10, 60, 5, 7, 12, 20, 5, 20,
				10, 60, 5
			}, new int[5] { 10, 100, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "1c122053-e860-4cde-b4af-0119777d7a63", "40", "0" }, new int[14]
			{
				0, 3, 8, 400, 50, 8, 600, 30, 8, 800,
				20, 0, 0, 0
			}, new int[21]
			{
				0, 0, 4, 0, -5, 1, 3, 0, -1, 1,
				3, 0, -4, 1, 2, 0, -12, 1, 2, 0,
				0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(4, 18, "1", 1, 5, "", new int[6] { 2, 90, 4, 60, 12, 120 }, new int[25]
			{
				3, 7, 15, 50, 5, 20, 10, 60, 5, 7,
				16, 25, 5, 20, 10, 60, 5, 7, 11, 25,
				5, 20, 10, 60, 5
			}, new int[5] { 10, 100, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "31928037-3497-4879-8006-04d95e0af89b", "50", "0" }, new int[14]
			{
				0, 3, 8, 200, 50, 8, 300, 30, 8, 400,
				20, 0, 0, 0
			}, new int[17]
			{
				0, 0, 3, 0, -5, 1, 3, 0, -9, 1,
				3, 0, -7, 1, 4, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(18, 33, "2", 1, 10, "", new int[6] { 12, 120, 2, 90, 4, 60 }, new int[25]
			{
				3, 7, 15, 50, 5, 20, 10, 60, 5, 7,
				16, 25, 5, 20, 10, 60, 5, 7, 11, 25,
				5, 20, 10, 60, 5
			}, new int[5] { 10, 100, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "1c122053-e860-4cde-b4af-0119777d7a63", "40", "0" }, new int[14]
			{
				0, 3, 8, 400, 50, 8, 600, 30, 8, 800,
				20, 0, 0, 0
			}, new int[17]
			{
				0, 0, 3, 0, -5, 1, 3, 0, -9, 1,
				3, 0, -7, 1, 4, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(5, 19, "1", 1, 5, "", new int[10] { 8, 60, 9, 60, 12, 60, 13, 60, 15, 60 }, new int[33]
			{
				4, 7, 1, 40, 5, 20, 10, 60, 5, 7,
				18, 20, 5, 20, 10, 60, 5, 7, 21, 30,
				5, 20, 10, 60, 5, 7, 17, 10, 5, 20,
				10, 60, 5
			}, new int[5] { 10, 100, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "31928037-3497-4879-8006-04d95e0af89b", "50", "0" }, new int[14]
			{
				0, 3, 8, 200, 50, 8, 300, 30, 8, 400,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 2, 0, -9, 1, 5, 0, -10, 1,
				5, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(19, 34, "2", 1, 10, "", new int[10] { 8, 60, 9, 60, 12, 60, 13, 60, 15, 60 }, new int[33]
			{
				4, 7, 1, 40, 5, 20, 10, 60, 5, 7,
				18, 20, 5, 20, 10, 60, 5, 7, 21, 30,
				5, 20, 10, 60, 5, 7, 17, 10, 5, 20,
				10, 60, 5
			}, new int[5] { 10, 100, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "1c122053-e860-4cde-b4af-0119777d7a63", "40", "0" }, new int[14]
			{
				0, 3, 8, 400, 50, 8, 600, 30, 8, 800,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 2, 0, -9, 1, 5, 0, -10, 1,
				5, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 20, "1", 1, 5, "", new int[8] { 6, 90, 7, 90, 14, 90, 15, 90 }, new int[41]
			{
				5, 7, 9, 10, 5, 20, 10, 60, 5, 7,
				7, 10, 5, 20, 10, 60, 5, 7, 12, 25,
				5, 20, 10, 60, 5, 7, 17, 25, 5, 20,
				10, 60, 5, 7, 18, 5, 5, 20, 10, 60,
				5
			}, new int[5] { 10, 100, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "31928037-3497-4879-8006-04d95e0af89b", "50", "0" }, new int[14]
			{
				0, 3, 8, 200, 50, 8, 300, 30, 8, 400,
				20, 0, 0, 0
			}, new int[17]
			{
				0, 0, 3, 0, -5, 1, 3, 0, -10, 1,
				4, 0, -11, 1, 3, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(20, 35, "2", 1, 10, "", new int[8] { 6, 90, 7, 90, 14, 90, 15, 90 }, new int[41]
			{
				5, 7, 9, 10, 5, 20, 10, 60, 5, 7,
				7, 10, 5, 20, 10, 60, 5, 7, 12, 25,
				5, 20, 10, 60, 5, 7, 17, 25, 5, 20,
				10, 60, 5, 7, 18, 5, 5, 20, 10, 60,
				5
			}, new int[5] { 10, 100, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "1c122053-e860-4cde-b4af-0119777d7a63", "40", "0" }, new int[14]
			{
				0, 3, 8, 400, 50, 8, 600, 30, 8, 800,
				20, 0, 0, 0
			}, new int[17]
			{
				0, 0, 3, 0, -5, 1, 3, 0, -10, 1,
				4, 0, -11, 1, 3, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(6, 21, "1", 1, 5, "", new int[10] { 2, 120, 4, 90, 12, 120, 13, 120, 15, 90 }, new int[33]
			{
				4, 7, 1, 50, 5, 20, 10, 60, 5, 7,
				21, 20, 5, 20, 10, 60, 5, 7, 22, 10,
				5, 20, 10, 60, 5, 7, 16, 10, 5, 20,
				10, 60, 5
			}, new int[5] { 10, 100, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "31928037-3497-4879-8006-04d95e0af89b", "50", "0" }, new int[14]
			{
				0, 3, 8, 200, 50, 8, 300, 30, 8, 400,
				20, 0, 0, 0
			}, new int[17]
			{
				0, 0, 3, 0, -5, 1, 3, 0, -9, 1,
				3, 0, -14, 1, 4, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(21, 36, "2", 1, 10, "", new int[10] { 2, 120, 4, 90, 12, 120, 13, 120, 15, 90 }, new int[33]
			{
				4, 7, 1, 50, 5, 20, 10, 60, 5, 7,
				21, 20, 5, 20, 10, 60, 5, 7, 22, 10,
				5, 20, 10, 60, 5, 7, 16, 10, 5, 20,
				10, 60, 5
			}, new int[5] { 10, 100, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "1c122053-e860-4cde-b4af-0119777d7a63", "40", "0" }, new int[14]
			{
				0, 3, 8, 400, 50, 8, 600, 30, 8, 800,
				20, 0, 0, 0
			}, new int[17]
			{
				0, 0, 3, 0, -5, 1, 3, 0, -9, 1,
				3, 0, -14, 1, 4, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(7, 22, "1", 1, 5, "", new int[8] { 0, 120, 3, 90, 5, 90, 12, 90 }, new int[33]
			{
				4, 7, 1, 10, 5, 20, 10, 60, 5, 7,
				21, 20, 5, 20, 10, 60, 5, 7, 5, 25,
				5, 20, 10, 60, 5, 7, 6, 25, 5, 20,
				10, 60, 5
			}, new int[5] { 10, 100, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "31928037-3497-4879-8006-04d95e0af89b", "50", "0" }, new int[14]
			{
				0, 3, 8, 200, 50, 8, 300, 30, 8, 400,
				20, 0, 0, 0
			}, new int[17]
			{
				0, 0, 3, 0, -5, 1, 4, 0, -4, 1,
				3, 0, -12, 1, 3, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(22, 37, "2", 1, 10, "", new int[8] { 0, 120, 3, 90, 5, 90, 12, 90 }, new int[33]
			{
				4, 7, 1, 10, 5, 20, 10, 60, 5, 7,
				21, 20, 5, 20, 10, 60, 5, 7, 5, 25,
				5, 20, 10, 60, 5, 7, 6, 25, 5, 20,
				10, 60, 5
			}, new int[5] { 10, 100, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "1c122053-e860-4cde-b4af-0119777d7a63", "40", "0" }, new int[14]
			{
				0, 3, 8, 400, 50, 8, 600, 30, 8, 800,
				20, 0, 0, 0
			}, new int[17]
			{
				0, 0, 3, 0, -5, 1, 4, 0, -4, 1,
				3, 0, -12, 1, 3, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(8, 23, "1", 1, 5, "", new int[8] { 6, 25, 7, 25, 10, 25, 11, 25 }, new int[33]
			{
				4, 7, 16, 30, 5, 20, 10, 60, 5, 7,
				7, 20, 5, 20, 10, 60, 5, 7, 8, 20,
				5, 20, 10, 60, 5, 7, 12, 20, 5, 20,
				10, 60, 5
			}, new int[5] { 10, 100, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "31928037-3497-4879-8006-04d95e0af89b", "50", "0" }, new int[14]
			{
				0, 3, 8, 200, 50, 8, 300, 30, 8, 400,
				20, 0, 0, 0
			}, new int[21]
			{
				0, 0, 4, 0, -9, 1, 3, 0, -10, 1,
				3, 0, -11, 1, 2, 0, -13, 1, 2, 0,
				0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(23, 38, "2", 1, 10, "", new int[8] { 6, 25, 7, 25, 10, 25, 11, 25 }, new int[33]
			{
				4, 7, 16, 30, 5, 20, 10, 60, 5, 7,
				7, 20, 5, 20, 10, 60, 5, 7, 8, 20,
				5, 20, 10, 60, 5, 7, 12, 20, 5, 20,
				10, 60, 5
			}, new int[5] { 10, 100, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "1c122053-e860-4cde-b4af-0119777d7a63", "40", "0" }, new int[14]
			{
				0, 3, 8, 400, 50, 8, 600, 30, 8, 800,
				20, 0, 0, 0
			}, new int[21]
			{
				0, 0, 4, 0, -9, 1, 3, 0, -10, 1,
				3, 0, -11, 1, 2, 0, -13, 1, 3, 0,
				0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(9, 24, "1", 1, 5, "", new int[8] { 8, 120, 9, 120, 10, 60, 11, 60 }, new int[33]
			{
				4, 7, 11, 15, 5, 20, 10, 60, 5, 7,
				12, 15, 5, 20, 10, 60, 5, 7, 1, 20,
				5, 20, 10, 60, 5, 7, 17, 30, 5, 20,
				10, 60, 5
			}, new int[5] { 10, 100, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "31928037-3497-4879-8006-04d95e0af89b", "50", "0" }, new int[14]
			{
				0, 3, 8, 200, 50, 8, 300, 30, 8, 400,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 2, 0, -5, 1, 5, 0, -15, 1,
				5, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(24, 39, "2", 1, 10, "", new int[8] { 8, 120, 9, 120, 10, 60, 11, 60 }, new int[33]
			{
				4, 7, 11, 15, 5, 20, 10, 60, 5, 7,
				12, 15, 5, 20, 10, 60, 5, 7, 1, 20,
				5, 20, 10, 60, 5, 7, 17, 30, 5, 20,
				10, 60, 5
			}, new int[5] { 10, 100, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "1c122053-e860-4cde-b4af-0119777d7a63", "40", "0" }, new int[14]
			{
				0, 3, 8, 400, 50, 8, 600, 30, 8, 800,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 2, 0, -5, 1, 5, 0, -15, 1,
				5, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(10, 25, "1", 1, 5, "", new int[6] { 5, 60, 13, 120, 15, 90 }, new int[33]
			{
				4, 7, 1, 20, 5, 20, 10, 60, 5, 7,
				14, 30, 5, 20, 10, 60, 5, 7, 16, 10,
				5, 20, 10, 60, 5, 7, 19, 20, 5, 20,
				10, 60, 5
			}, new int[5] { 10, 100, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "31928037-3497-4879-8006-04d95e0af89b", "50", "0" }, new int[14]
			{
				0, 3, 8, 200, 50, 8, 300, 30, 8, 400,
				20, 0, 0, 0
			}, new int[17]
			{
				0, 0, 3, 0, -5, 1, 3, 0, -10, 1,
				3, 0, -6, 1, 4, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(25, 40, "2", 1, 10, "", new int[6] { 5, 60, 13, 120, 15, 90 }, new int[33]
			{
				4, 7, 1, 20, 5, 20, 10, 60, 5, 7,
				14, 30, 5, 20, 10, 60, 5, 7, 16, 10,
				5, 20, 10, 60, 5, 7, 19, 20, 5, 20,
				10, 60, 5
			}, new int[5] { 10, 100, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "1c122053-e860-4cde-b4af-0119777d7a63", "40", "0" }, new int[14]
			{
				0, 3, 8, 400, 50, 8, 600, 30, 8, 800,
				20, 0, 0, 0
			}, new int[17]
			{
				0, 0, 3, 0, -5, 1, 3, 0, -10, 1,
				3, 0, -6, 1, 4, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(11, 26, "1", 1, 5, "", new int[6] { 7, 90, 8, 90, 9, 100 }, new int[33]
			{
				4, 7, 12, 30, 5, 20, 10, 60, 5, 7,
				11, 20, 5, 20, 10, 60, 5, 7, 7, 10,
				5, 20, 10, 60, 5, 7, 3, 10, 5, 20,
				10, 60, 5
			}, new int[5] { 10, 100, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "31928037-3497-4879-8006-04d95e0af89b", "50", "0" }, new int[14]
			{
				0, 3, 8, 200, 50, 8, 300, 30, 8, 400,
				20, 0, 0, 0
			}, new int[17]
			{
				0, 0, 3, 0, -9, 1, 3, 0, -8, 1,
				4, 0, -5, 1, 3, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(26, 41, "2", 1, 10, "", new int[6] { 7, 90, 8, 90, 9, 100 }, new int[33]
			{
				4, 7, 12, 30, 5, 20, 10, 60, 5, 7,
				11, 20, 5, 20, 10, 60, 5, 7, 7, 10,
				5, 20, 10, 60, 5, 7, 3, 10, 5, 20,
				10, 60, 5
			}, new int[5] { 10, 100, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "1c122053-e860-4cde-b4af-0119777d7a63", "40", "0" }, new int[14]
			{
				0, 3, 8, 400, 50, 8, 600, 30, 8, 800,
				20, 0, 0, 0
			}, new int[17]
			{
				0, 0, 3, 0, -9, 1, 3, 0, -8, 1,
				4, 0, -5, 1, 3, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(12, 27, "1", 1, 5, "", new int[6] { 1, 120, 4, 120, 8, 90 }, new int[41]
			{
				5, 7, 22, 20, 5, 20, 10, 60, 5, 7,
				21, 30, 5, 20, 10, 60, 5, 7, 20, 10,
				5, 20, 10, 60, 5, 7, 18, 10, 5, 20,
				10, 60, 5, 7, 3, 5, 5, 20, 10, 60,
				5
			}, new int[5] { 10, 100, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "31928037-3497-4879-8006-04d95e0af89b", "50", "0" }, new int[14]
			{
				0, 3, 8, 200, 50, 8, 300, 30, 8, 400,
				20, 0, 0, 0
			}, new int[17]
			{
				0, 0, 3, 0, -5, 1, 2, 0, -3, 1,
				5, 0, -9, 1, 3, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(27, 42, "2", 1, 10, "", new int[6] { 1, 120, 4, 120, 8, 90 }, new int[41]
			{
				5, 7, 22, 20, 5, 20, 10, 60, 5, 7,
				21, 30, 5, 20, 10, 60, 5, 7, 20, 10,
				5, 20, 10, 60, 5, 7, 18, 10, 5, 20,
				10, 60, 5, 7, 3, 5, 5, 20, 10, 60,
				5
			}, new int[5] { 10, 100, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "1c122053-e860-4cde-b4af-0119777d7a63", "40", "0" }, new int[14]
			{
				0, 3, 8, 400, 50, 8, 600, 30, 8, 800,
				20, 0, 0, 0
			}, new int[17]
			{
				0, 0, 3, 0, -5, 1, 2, 0, -3, 1,
				5, 0, -9, 1, 3, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(13, 28, "1", 1, 5, "", new int[6] { 5, 120, 6, 90, 14, 120 }, new int[33]
			{
				4, 7, 16, 25, 5, 20, 10, 60, 5, 7,
				22, 10, 5, 20, 10, 60, 5, 7, 19, 5,
				5, 20, 10, 60, 5, 7, 18, 15, 5, 20,
				10, 60, 5
			}, new int[5] { 10, 100, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "31928037-3497-4879-8006-04d95e0af89b", "50", "0" }, new int[14]
			{
				0, 3, 8, 200, 50, 8, 300, 30, 8, 400,
				20, 0, 0, 0
			}, new int[17]
			{
				0, 0, 3, 0, -5, 1, 3, 0, -3, 1,
				3, 0, -10, 1, 4, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(28, 43, "2", 1, 10, "", new int[6] { 5, 120, 6, 90, 14, 120 }, new int[33]
			{
				4, 7, 16, 25, 5, 20, 10, 60, 5, 7,
				22, 10, 5, 20, 10, 60, 5, 7, 19, 5,
				5, 20, 10, 60, 5, 7, 18, 15, 5, 20,
				10, 60, 5
			}, new int[5] { 10, 100, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "1c122053-e860-4cde-b4af-0119777d7a63", "40", "0" }, new int[14]
			{
				0, 3, 8, 400, 50, 8, 600, 30, 8, 800,
				20, 0, 0, 0
			}, new int[17]
			{
				0, 0, 3, 0, -5, 1, 3, 0, -3, 1,
				3, 0, -10, 1, 4, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(14, 29, "1", 1, 5, "", new int[8] { 5, 90, 8, 90, 9, 90, 13, 90 }, new int[33]
			{
				4, 7, 2, 10, 5, 20, 10, 60, 5, 7,
				3, 20, 5, 20, 10, 60, 5, 7, 18, 30,
				5, 20, 10, 60, 5, 7, 20, 20, 5, 20,
				10, 60, 5
			}, new int[5] { 10, 100, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "31928037-3497-4879-8006-04d95e0af89b", "50", "0" }, new int[14]
			{
				0, 3, 8, 200, 50, 8, 300, 30, 8, 400,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 2, 0, -5, 1, 5, 0, -16, 1,
				5, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(29, 44, "2", 1, 10, "", new int[8] { 5, 90, 8, 90, 9, 90, 13, 90 }, new int[33]
			{
				4, 7, 2, 10, 5, 20, 10, 60, 5, 7,
				3, 20, 5, 20, 10, 60, 5, 7, 18, 30,
				5, 20, 10, 60, 5, 7, 20, 20, 5, 20,
				10, 60, 5
			}, new int[5] { 10, 100, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "1c122053-e860-4cde-b4af-0119777d7a63", "40", "0" }, new int[14]
			{
				0, 3, 8, 400, 50, 8, 600, 30, 8, 800,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 2, 0, -5, 1, 5, 0, -16, 1,
				5, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray16.Add(new AdventureItem(75, config31, config32, 6, 1, 1, 1, 5, 3, resCost16, itemCost15, restrictedByWorldPopulation: false, malice15, adventureParams10, "ae8be239-e7c9-4535-bd79-2dd8c4d9aa09", startNodes9, transferNodes9, endNodes8, baseBranches8, advancedBranches, difficultyAddXiangshuLevel: true));
		List<AdventureItem> dataArray17 = _dataArray;
		string config33 = LocalStringManager.GetConfig("Adventure_language", "Name_76");
		string config34 = LocalStringManager.GetConfig("Adventure_language", "Desc_76");
		int[] resCost17 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost16 = list;
		short[] malice16 = new short[3];
		adventureParams = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams11 = adventureParams;
		List<AdventureStartNode> startNodes10 = new List<AdventureStartNode>
		{
			new AdventureStartNode("b971f7ea-fd88-4777-9ee7-70a3ae2c5284", "A", "LK_Adventure_NodeTitle_243", 9)
		};
		List<AdventureTransferNode> transferNodes10 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("b89eb865-5246-40ad-a59f-f289a5c8831a", "B", "LK_Adventure_NodeTitle_244", 9),
			new AdventureTransferNode("f557b815-3f3b-4c64-80cb-4aa47b7411ae", "C", "LK_Adventure_NodeTitle_244", 9),
			new AdventureTransferNode("7100938d-a0ad-4f76-8870-717d688634b8", "D", "LK_Adventure_NodeTitle_244", 9)
		};
		List<AdventureEndNode> endNodes9 = new List<AdventureEndNode>
		{
			new AdventureEndNode("102fc53f-2d52-46dd-86b9-9c97c21edc30", "E", "LK_Adventure_NodeTitle_245", 9)
		};
		List<AdventureBaseBranch> baseBranches9 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 4, "", new int[2] { 0, 100 }, new int[9] { 1, 7, 9, 50, 10, 10, 10, 60, 10 }, new int[5] { 50, 50, 50, 0, 50 }, new string[7] { "0", "0", "0", "1", "d9cf0899-1916-4eef-ba94-32c5098424b2", "30", "0" }, new int[14]
			{
				0, 0, 0, 3, 8, 200, 5, 8, 300, 3,
				8, 400, 2, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 1, 4, "", new int[2] { 0, 100 }, new int[9] { 1, 7, 9, 50, 10, 10, 10, 60, 10 }, new int[5] { 50, 50, 50, 0, 50 }, new string[7] { "0", "0", "0", "1", "d9cf0899-1916-4eef-ba94-32c5098424b2", "30", "0" }, new int[14]
			{
				0, 0, 0, 3, 8, 300, 5, 8, 450, 3,
				8, 600, 2, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 3, "3", 1, 4, "", new int[2] { 0, 100 }, new int[9] { 1, 7, 9, 50, 10, 10, 10, 60, 10 }, new int[5] { 50, 50, 50, 0, 50 }, new string[7] { "0", "0", "0", "1", "d9cf0899-1916-4eef-ba94-32c5098424b2", "30", "0" }, new int[14]
			{
				0, 0, 0, 3, 8, 500, 5, 8, 750, 3,
				8, 1000, 2, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 4, "4", 1, 4, "", new int[2] { 0, 100 }, new int[9] { 1, 7, 9, 50, 10, 10, 10, 60, 10 }, new int[5] { 50, 50, 50, 0, 50 }, new string[7] { "0", "0", "0", "1", "d9cf0899-1916-4eef-ba94-32c5098424b2", "30", "0" }, new int[14]
			{
				0, 0, 0, 3, 8, 800, 5, 8, 1200, 3,
				8, 1600, 2, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray17.Add(new AdventureItem(76, config33, config34, 6, 6, 4, 1, 10, 3, resCost17, itemCost16, restrictedByWorldPopulation: false, malice16, adventureParams11, "25a42d7a-6aa9-4e64-b8e4-3b8ccbb21dd5", startNodes10, transferNodes10, endNodes9, baseBranches9, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray18 = _dataArray;
		string config35 = LocalStringManager.GetConfig("Adventure_language", "Name_77");
		string config36 = LocalStringManager.GetConfig("Adventure_language", "Desc_77");
		int[] resCost18 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost17 = list;
		short[] malice17 = new short[3];
		List<(string, string, string, string)> adventureParams12 = new List<(string, string, string, string)>
		{
			("BookToalMoney", "LK_Adventure_49_ParamName_0", "adventure_icon_fenxiang", ""),
			("WeaponToalMoney", "LK_Adventure_49_ParamName_1", "adventure_icon_fenxiang", ""),
			("AccessoryToalMoney", "LK_Adventure_49_ParamName_2", "adventure_icon_fenxiang", ""),
			("ConstructionToalMoney", "LK_Adventure_49_ParamName_3", "adventure_icon_fenxiang", ""),
			("MaterialToalMoney", "LK_Adventure_49_ParamName_4", "adventure_icon_fenxiang", ""),
			("FoodToalMoney", "LK_Adventure_49_ParamName_5", "adventure_icon_fenxiang", "")
		};
		List<AdventureStartNode> startNodes11 = new List<AdventureStartNode>
		{
			new AdventureStartNode("63c9a854-16d7-4846-bb3b-310ff7a84755", "A", "LK_Adventure_NodeTitle_147", 9)
		};
		List<AdventureTransferNode> transferNodes11 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("3f80a451-f3d9-4cae-96f7-3f4b06d8de77", "B", "LK_Adventure_NodeTitle_148", 9),
			new AdventureTransferNode("05217e74-2d83-40ae-aa49-9b30c321ab09", "C", "LK_Adventure_NodeTitle_149", 9)
		};
		List<AdventureEndNode> endNodes10 = new List<AdventureEndNode>
		{
			new AdventureEndNode("311e0cc9-183e-432c-b31b-e0103b95eddd", "D", "LK_Adventure_NodeTitle_150", 9)
		};
		List<AdventureBaseBranch> baseBranches10 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 5, "", new int[32]
			{
				0, 1, 1, 1, 2, 1, 3, 1, 4, 1,
				5, 1, 6, 1, 7, 1, 8, 1, 9, 1,
				10, 1, 11, 1, 12, 1, 13, 1, 14, 1,
				15, 1
			}, new int[16]
			{
				5, 2, 9, 50, 2, 8, 10, 2, 7, 5,
				2, 10, 5, 2, 5, 5
			}, new int[5] { 100, 100, 100, 100, 100 }, new string[15]
			{
				"1", "416a2a37-1fc4-4280-86ec-810127075825", "100", "1", "416a2a37-1fc4-4280-86ec-810127075825", "100", "1", "416a2a37-1fc4-4280-86ec-810127075825", "100", "1",
				"416a2a37-1fc4-4280-86ec-810127075825", "100", "1", "416a2a37-1fc4-4280-86ec-810127075825", "100"
			}, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 1, 10, "", new int[32]
			{
				0, 1, 1, 1, 2, 1, 3, 1, 4, 1,
				5, 1, 6, 1, 7, 1, 8, 1, 9, 1,
				10, 1, 11, 1, 12, 1, 13, 1, 14, 1,
				15, 1
			}, new int[16]
			{
				5, 2, 9, 50, 2, 8, 10, 2, 7, 5,
				2, 10, 5, 2, 5, 5
			}, new int[5] { 100, 100, 100, 100, 100 }, new string[15]
			{
				"1", "cf3175ba-b33e-4302-b675-04ea6a31b8fd", "100", "1", "cf3175ba-b33e-4302-b675-04ea6a31b8fd", "100", "1", "cf3175ba-b33e-4302-b675-04ea6a31b8fd", "100", "1",
				"cf3175ba-b33e-4302-b675-04ea6a31b8fd", "100", "1", "cf3175ba-b33e-4302-b675-04ea6a31b8fd", "100"
			}, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 3, "3", 1, 5, "", new int[32]
			{
				0, 1, 1, 1, 2, 1, 3, 1, 4, 1,
				5, 1, 6, 1, 7, 1, 8, 1, 9, 1,
				10, 1, 11, 1, 12, 1, 13, 1, 14, 1,
				15, 1
			}, new int[16]
			{
				5, 2, 9, 50, 2, 8, 10, 2, 7, 5,
				2, 10, 5, 2, 5, 5
			}, new int[5] { 100, 100, 100, 100, 100 }, new string[15]
			{
				"1", "f4124e3b-4c27-4308-a177-998107b76da7", "100", "1", "f4124e3b-4c27-4308-a177-998107b76da7", "100", "1", "f4124e3b-4c27-4308-a177-998107b76da7", "100", "1",
				"f4124e3b-4c27-4308-a177-998107b76da7", "100", "1", "f4124e3b-4c27-4308-a177-998107b76da7", "100"
			}, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray18.Add(new AdventureItem(77, config35, config36, 6, 1, 5, 1, 10, 3, resCost18, itemCost17, restrictedByWorldPopulation: false, malice17, adventureParams12, "5a1babe9-7ae8-43d1-8626-e2ccf180374a", startNodes11, transferNodes11, endNodes10, baseBranches10, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray19 = _dataArray;
		string config37 = LocalStringManager.GetConfig("Adventure_language", "Name_78");
		string config38 = LocalStringManager.GetConfig("Adventure_language", "Desc_78");
		int[] resCost19 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost18 = list;
		short[] malice18 = new short[3];
		adventureParams = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams13 = adventureParams;
		List<AdventureStartNode> startNodes12 = new List<AdventureStartNode>
		{
			new AdventureStartNode("b875ff7a-7c2d-4d3d-805a-0356cdac883b", "A", "LK_Adventure_NodeTitle_243", 9)
		};
		List<AdventureTransferNode> transferNodes12 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("b89eb865-5246-40ad-a59f-f289a5c8831a", "B", "LK_Adventure_NodeTitle_244", 9),
			new AdventureTransferNode("f557b815-3f3b-4c64-80cb-4aa47b7411ae", "C", "LK_Adventure_NodeTitle_244", 9),
			new AdventureTransferNode("7100938d-a0ad-4f76-8870-717d688634b8", "D", "LK_Adventure_NodeTitle_244", 9)
		};
		List<AdventureEndNode> endNodes11 = new List<AdventureEndNode>
		{
			new AdventureEndNode("102fc53f-2d52-46dd-86b9-9c97c21edc30", "E", "LK_Adventure_NodeTitle_278", 9)
		};
		List<AdventureBaseBranch> baseBranches11 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 4, "", new int[8] { 6, 25, 7, 25, 11, 25, 10, 25 }, new int[9] { 1, 7, 9, 50, 10, 10, 10, 60, 10 }, new int[5] { 50, 50, 50, 0, 50 }, new string[7] { "0", "0", "0", "1", "d9cf0899-1916-4eef-ba94-32c5098424b2", "30", "0" }, new int[14]
			{
				0, 0, 0, 3, 8, 200, 5, 8, 300, 3,
				8, 400, 2, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 1, 4, "", new int[8] { 6, 25, 7, 25, 11, 25, 10, 25 }, new int[9] { 1, 7, 9, 50, 10, 10, 10, 60, 10 }, new int[5] { 50, 50, 50, 0, 50 }, new string[7] { "0", "0", "0", "1", "d9cf0899-1916-4eef-ba94-32c5098424b2", "30", "0" }, new int[14]
			{
				0, 0, 0, 3, 8, 300, 5, 8, 450, 3,
				8, 600, 2, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 3, "3", 1, 4, "", new int[8] { 6, 25, 7, 25, 11, 25, 10, 25 }, new int[9] { 1, 7, 9, 50, 10, 10, 10, 60, 10 }, new int[5] { 50, 50, 50, 50, 50 }, new string[7] { "0", "0", "0", "1", "d9cf0899-1916-4eef-ba94-32c5098424b2", "30", "0" }, new int[14]
			{
				0, 0, 0, 3, 8, 500, 5, 8, 750, 3,
				8, 1000, 2, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 4, "4", 1, 4, "", new int[2] { 0, 100 }, new int[9] { 1, 7, 9, 50, 10, 10, 10, 60, 10 }, new int[5] { 50, 50, 50, 0, 50 }, new string[7] { "0", "0", "0", "1", "d9cf0899-1916-4eef-ba94-32c5098424b2", "30", "0" }, new int[14]
			{
				0, 0, 0, 3, 8, 800, 5, 8, 1200, 3,
				8, 1600, 2, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray19.Add(new AdventureItem(78, config37, config38, 6, 6, 6, 1, 10, 3, resCost19, itemCost18, restrictedByWorldPopulation: false, malice18, adventureParams13, "25a42d7a-6aa9-4e64-b8e4-3b8ccbb21dd5", startNodes12, transferNodes12, endNodes11, baseBranches11, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray20 = _dataArray;
		string config39 = LocalStringManager.GetConfig("Adventure_language", "Name_79");
		string config40 = LocalStringManager.GetConfig("Adventure_language", "Desc_79");
		int[] resCost20 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost19 = list;
		short[] malice19 = new short[3];
		adventureParams = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams14 = adventureParams;
		List<AdventureStartNode> startNodes13 = new List<AdventureStartNode>
		{
			new AdventureStartNode("abe33797-17b3-45cc-96be-d74595226b50", "A", "LK_Adventure_NodeTitle_243", 9)
		};
		List<AdventureTransferNode> transferNodes13 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("b89eb865-5246-40ad-a59f-f289a5c8831a", "B", "LK_Adventure_NodeTitle_244", 9),
			new AdventureTransferNode("f557b815-3f3b-4c64-80cb-4aa47b7411ae", "C", "LK_Adventure_NodeTitle_244", 9),
			new AdventureTransferNode("7100938d-a0ad-4f76-8870-717d688634b8", "D", "LK_Adventure_NodeTitle_244", 9)
		};
		List<AdventureEndNode> endNodes12 = new List<AdventureEndNode>
		{
			new AdventureEndNode("102fc53f-2d52-46dd-86b9-9c97c21edc30", "E", "LK_Adventure_NodeTitle_278", 9)
		};
		List<AdventureBaseBranch> baseBranches12 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 4, "", new int[2] { 0, 100 }, new int[9] { 1, 7, 9, 50, 10, 10, 10, 60, 10 }, new int[5] { 50, 50, 50, 0, 50 }, new string[7] { "0", "0", "0", "1", "d9cf0899-1916-4eef-ba94-32c5098424b2", "30", "0" }, new int[14]
			{
				0, 0, 0, 3, 8, 200, 5, 8, 300, 3,
				8, 400, 2, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 1, 4, "", new int[2] { 0, 100 }, new int[9] { 1, 7, 9, 50, 10, 10, 10, 60, 10 }, new int[5] { 50, 50, 50, 0, 50 }, new string[7] { "0", "0", "0", "1", "d9cf0899-1916-4eef-ba94-32c5098424b2", "30", "0" }, new int[14]
			{
				0, 0, 0, 3, 8, 300, 5, 8, 450, 3,
				8, 600, 2, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 3, "3", 1, 4, "", new int[2] { 0, 100 }, new int[9] { 1, 7, 9, 50, 10, 10, 10, 60, 10 }, new int[5] { 50, 50, 50, 0, 50 }, new string[7] { "0", "0", "0", "1", "d9cf0899-1916-4eef-ba94-32c5098424b2", "30", "0" }, new int[14]
			{
				0, 0, 0, 3, 8, 500, 5, 8, 750, 3,
				8, 1000, 2, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 4, "4", 1, 4, "", new int[2] { 0, 100 }, new int[9] { 1, 7, 9, 50, 10, 10, 10, 60, 10 }, new int[5] { 50, 50, 50, 0, 50 }, new string[7] { "0", "0", "0", "1", "d9cf0899-1916-4eef-ba94-32c5098424b2", "30", "0" }, new int[14]
			{
				0, 0, 0, 3, 8, 800, 5, 8, 1200, 3,
				8, 1600, 2, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray20.Add(new AdventureItem(79, config39, config40, 6, 6, 6, 1, 10, 3, resCost20, itemCost19, restrictedByWorldPopulation: false, malice19, adventureParams14, "25a42d7a-6aa9-4e64-b8e4-3b8ccbb21dd5", startNodes13, transferNodes13, endNodes12, baseBranches12, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray21 = _dataArray;
		string config41 = LocalStringManager.GetConfig("Adventure_language", "Name_80");
		string config42 = LocalStringManager.GetConfig("Adventure_language", "Desc_80");
		int[] resCost21 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost20 = list;
		short[] malice20 = new short[3];
		adventureParams = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams15 = adventureParams;
		List<AdventureStartNode> startNodes14 = new List<AdventureStartNode>
		{
			new AdventureStartNode("8fea6c51-834f-4ddc-b502-b20206f30cf7", "A", "LK_Adventure_NodeTitle_243", 9)
		};
		List<AdventureTransferNode> transferNodes14 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("b89eb865-5246-40ad-a59f-f289a5c8831a", "B", "LK_Adventure_NodeTitle_244", 9),
			new AdventureTransferNode("f557b815-3f3b-4c64-80cb-4aa47b7411ae", "C", "LK_Adventure_NodeTitle_244", 9),
			new AdventureTransferNode("7100938d-a0ad-4f76-8870-717d688634b8", "D", "LK_Adventure_NodeTitle_244", 9)
		};
		List<AdventureEndNode> endNodes13 = new List<AdventureEndNode>
		{
			new AdventureEndNode("102fc53f-2d52-46dd-86b9-9c97c21edc30", "E", "LK_Adventure_NodeTitle_245", 9)
		};
		List<AdventureBaseBranch> baseBranches13 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 4, "", new int[2] { 0, 100 }, new int[9] { 1, 7, 9, 50, 10, 10, 10, 60, 10 }, new int[5] { 50, 50, 50, 0, 50 }, new string[7] { "0", "0", "0", "1", "d9cf0899-1916-4eef-ba94-32c5098424b2", "30", "0" }, new int[14]
			{
				0, 0, 0, 3, 8, 200, 5, 8, 300, 3,
				8, 400, 2, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 1, 4, "", new int[2] { 0, 100 }, new int[9] { 1, 7, 9, 50, 10, 10, 10, 60, 10 }, new int[5] { 50, 50, 50, 0, 50 }, new string[7] { "0", "0", "0", "1", "d9cf0899-1916-4eef-ba94-32c5098424b2", "30", "0" }, new int[14]
			{
				0, 0, 0, 3, 8, 300, 5, 8, 450, 3,
				8, 600, 2, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 3, "3", 1, 4, "", new int[2] { 0, 100 }, new int[9] { 1, 7, 9, 50, 10, 10, 10, 60, 10 }, new int[5] { 50, 50, 50, 0, 50 }, new string[7] { "0", "0", "0", "1", "d9cf0899-1916-4eef-ba94-32c5098424b2", "30", "0" }, new int[14]
			{
				0, 0, 0, 3, 8, 500, 5, 8, 750, 3,
				8, 1000, 2, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 4, "4", 1, 4, "", new int[2] { 0, 100 }, new int[9] { 1, 7, 9, 50, 10, 10, 10, 60, 10 }, new int[5] { 50, 50, 50, 0, 50 }, new string[7] { "0", "0", "0", "1", "d9cf0899-1916-4eef-ba94-32c5098424b2", "30", "0" }, new int[14]
			{
				0, 0, 0, 3, 8, 800, 5, 8, 1200, 3,
				8, 1600, 2, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray21.Add(new AdventureItem(80, config41, config42, 6, 6, 6, 1, 10, 3, resCost21, itemCost20, restrictedByWorldPopulation: false, malice20, adventureParams15, "25a42d7a-6aa9-4e64-b8e4-3b8ccbb21dd5", startNodes14, transferNodes14, endNodes13, baseBranches13, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray22 = _dataArray;
		string config43 = LocalStringManager.GetConfig("Adventure_language", "Name_81");
		string config44 = LocalStringManager.GetConfig("Adventure_language", "Desc_81");
		int[] resCost22 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost21 = list;
		short[] malice21 = new short[3];
		adventureParams = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams16 = adventureParams;
		List<AdventureStartNode> startNodes15 = new List<AdventureStartNode>
		{
			new AdventureStartNode("e3ad8b02-b9ae-49c1-84f7-b98df4a45c2e", "A", "LK_Adventure_NodeTitle_243", 9)
		};
		List<AdventureTransferNode> transferNodes15 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("b89eb865-5246-40ad-a59f-f289a5c8831a", "B", "LK_Adventure_NodeTitle_244", 9),
			new AdventureTransferNode("f557b815-3f3b-4c64-80cb-4aa47b7411ae", "C", "LK_Adventure_NodeTitle_244", 9),
			new AdventureTransferNode("7100938d-a0ad-4f76-8870-717d688634b8", "D", "LK_Adventure_NodeTitle_244", 9)
		};
		List<AdventureEndNode> endNodes14 = new List<AdventureEndNode>
		{
			new AdventureEndNode("102fc53f-2d52-46dd-86b9-9c97c21edc30", "E", "LK_Adventure_NodeTitle_278", 9)
		};
		List<AdventureBaseBranch> baseBranches14 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 4, "", new int[2] { 0, 100 }, new int[9] { 1, 7, 9, 50, 10, 10, 10, 60, 10 }, new int[5] { 50, 50, 50, 0, 50 }, new string[7] { "0", "0", "0", "1", "d9cf0899-1916-4eef-ba94-32c5098424b2", "30", "0" }, new int[14]
			{
				0, 0, 0, 3, 8, 200, 5, 8, 300, 3,
				8, 400, 2, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 1, 4, "", new int[2] { 0, 100 }, new int[9] { 1, 7, 9, 50, 10, 10, 10, 60, 10 }, new int[5] { 50, 50, 50, 0, 50 }, new string[7] { "0", "0", "0", "1", "d9cf0899-1916-4eef-ba94-32c5098424b2", "30", "0" }, new int[14]
			{
				0, 0, 0, 3, 8, 300, 5, 8, 450, 3,
				8, 600, 2, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 3, "3", 1, 4, "", new int[2] { 0, 100 }, new int[9] { 1, 7, 9, 50, 10, 10, 10, 60, 10 }, new int[5] { 50, 50, 50, 0, 50 }, new string[7] { "0", "0", "0", "1", "d9cf0899-1916-4eef-ba94-32c5098424b2", "30", "0" }, new int[14]
			{
				0, 0, 0, 3, 8, 500, 5, 8, 750, 3,
				8, 1000, 2, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 4, "4", 1, 4, "", new int[2] { 0, 100 }, new int[9] { 1, 7, 9, 50, 10, 10, 10, 60, 10 }, new int[5] { 50, 50, 50, 0, 50 }, new string[7] { "0", "0", "0", "1", "d9cf0899-1916-4eef-ba94-32c5098424b2", "30", "0" }, new int[14]
			{
				0, 0, 0, 3, 8, 800, 5, 8, 1200, 3,
				8, 1600, 2, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray22.Add(new AdventureItem(81, config43, config44, 6, 6, 6, 1, 10, 3, resCost22, itemCost21, restrictedByWorldPopulation: false, malice21, adventureParams16, "25a42d7a-6aa9-4e64-b8e4-3b8ccbb21dd5", startNodes15, transferNodes15, endNodes14, baseBranches14, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray23 = _dataArray;
		string config45 = LocalStringManager.GetConfig("Adventure_language", "Name_82");
		string config46 = LocalStringManager.GetConfig("Adventure_language", "Desc_82");
		int[] resCost23 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost22 = list;
		short[] malice22 = new short[3];
		adventureParams = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams17 = adventureParams;
		List<AdventureStartNode> startNodes16 = new List<AdventureStartNode>
		{
			new AdventureStartNode("89e61be0-27d9-4c13-b429-77d843be61d0", "A", "LK_Adventure_NodeTitle_243", 9)
		};
		List<AdventureTransferNode> transferNodes16 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("7100938d-a0ad-4f76-8870-717d688634b8", "D", "LK_Adventure_NodeTitle_244", 9),
			new AdventureTransferNode("b89eb865-5246-40ad-a59f-f289a5c8831a", "B", "LK_Adventure_NodeTitle_244", 9),
			new AdventureTransferNode("f557b815-3f3b-4c64-80cb-4aa47b7411ae", "C", "LK_Adventure_NodeTitle_244", 9)
		};
		List<AdventureEndNode> endNodes15 = new List<AdventureEndNode>
		{
			new AdventureEndNode("102fc53f-2d52-46dd-86b9-9c97c21edc30", "E", "LK_Adventure_NodeTitle_278", 9)
		};
		List<AdventureBaseBranch> baseBranches15 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 2, "1", 1, 4, "", new int[2] { 0, 100 }, new int[9] { 1, 7, 9, 50, 10, 10, 10, 60, 10 }, new int[5] { 50, 50, 50, 0, 50 }, new string[7] { "0", "0", "0", "1", "d9cf0899-1916-4eef-ba94-32c5098424b2", "30", "0" }, new int[14]
			{
				0, 0, 0, 3, 8, 200, 5, 8, 300, 3,
				8, 400, 2, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 3, "2", 1, 4, "", new int[2] { 0, 100 }, new int[9] { 1, 7, 9, 50, 10, 10, 10, 60, 10 }, new int[5] { 50, 50, 50, 0, 50 }, new string[7] { "0", "0", "0", "1", "d9cf0899-1916-4eef-ba94-32c5098424b2", "30", "0" }, new int[14]
			{
				0, 0, 0, 3, 8, 300, 5, 8, 450, 3,
				8, 600, 2, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 1, "3", 1, 4, "", new int[2] { 0, 100 }, new int[9] { 1, 7, 9, 50, 10, 10, 10, 60, 10 }, new int[5] { 50, 50, 50, 0, 50 }, new string[7] { "0", "0", "0", "1", "d9cf0899-1916-4eef-ba94-32c5098424b2", "30", "0" }, new int[14]
			{
				0, 0, 0, 3, 8, 500, 5, 8, 750, 3,
				8, 1000, 2, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 4, "4", 1, 4, "", new int[2] { 0, 100 }, new int[9] { 1, 7, 9, 50, 10, 10, 10, 60, 10 }, new int[5] { 50, 50, 50, 0, 50 }, new string[7] { "0", "0", "0", "1", "d9cf0899-1916-4eef-ba94-32c5098424b2", "30", "0" }, new int[14]
			{
				0, 0, 0, 3, 8, 800, 5, 8, 1200, 3,
				8, 1600, 2, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray23.Add(new AdventureItem(82, config45, config46, 6, 6, 6, 1, 10, 3, resCost23, itemCost22, restrictedByWorldPopulation: false, malice22, adventureParams17, "25a42d7a-6aa9-4e64-b8e4-3b8ccbb21dd5", startNodes16, transferNodes16, endNodes15, baseBranches15, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray24 = _dataArray;
		string config47 = LocalStringManager.GetConfig("Adventure_language", "Name_83");
		string config48 = LocalStringManager.GetConfig("Adventure_language", "Desc_83");
		int[] resCost24 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost23 = list;
		short[] malice23 = new short[3];
		adventureParams = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams18 = adventureParams;
		List<AdventureStartNode> startNodes17 = new List<AdventureStartNode>
		{
			new AdventureStartNode("a30b832d-be93-4aba-b371-e378ee0e5811", "A", "LK_Adventure_NodeTitle_243", 9)
		};
		List<AdventureTransferNode> transferNodes17 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("b89eb865-5246-40ad-a59f-f289a5c8831a", "B", "LK_Adventure_NodeTitle_244", 9),
			new AdventureTransferNode("7100938d-a0ad-4f76-8870-717d688634b8", "D", "LK_Adventure_NodeTitle_244", 9),
			new AdventureTransferNode("f557b815-3f3b-4c64-80cb-4aa47b7411ae", "C", "LK_Adventure_NodeTitle_244", 9)
		};
		List<AdventureEndNode> endNodes16 = new List<AdventureEndNode>
		{
			new AdventureEndNode("102fc53f-2d52-46dd-86b9-9c97c21edc30", "E", "LK_Adventure_NodeTitle_278", 9)
		};
		List<AdventureBaseBranch> baseBranches16 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 4, "", new int[2] { 0, 100 }, new int[9] { 1, 7, 9, 50, 10, 10, 10, 60, 10 }, new int[5] { 50, 50, 50, 0, 50 }, new string[7] { "0", "0", "0", "1", "d9cf0899-1916-4eef-ba94-32c5098424b2", "30", "0" }, new int[14]
			{
				0, 0, 0, 3, 8, 200, 5, 8, 300, 3,
				8, 400, 2, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 3, "2", 1, 4, "", new int[2] { 0, 100 }, new int[9] { 1, 7, 9, 50, 10, 10, 10, 60, 10 }, new int[5] { 50, 50, 50, 0, 50 }, new string[7] { "0", "0", "0", "1", "d9cf0899-1916-4eef-ba94-32c5098424b2", "30", "0" }, new int[14]
			{
				0, 0, 0, 3, 8, 300, 5, 8, 450, 3,
				8, 600, 2, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 2, "3", 1, 4, "", new int[2] { 0, 100 }, new int[9] { 1, 7, 9, 50, 10, 10, 10, 60, 10 }, new int[5] { 50, 50, 50, 0, 50 }, new string[7] { "0", "0", "0", "1", "d9cf0899-1916-4eef-ba94-32c5098424b2", "30", "0" }, new int[14]
			{
				0, 0, 0, 3, 8, 500, 5, 8, 750, 3,
				8, 1000, 2, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 4, "4", 1, 4, "", new int[2] { 0, 100 }, new int[9] { 1, 7, 9, 50, 10, 10, 10, 60, 10 }, new int[5] { 50, 50, 50, 0, 50 }, new string[7] { "0", "0", "0", "1", "d9cf0899-1916-4eef-ba94-32c5098424b2", "30", "0" }, new int[14]
			{
				0, 0, 0, 3, 8, 800, 5, 8, 1200, 3,
				8, 1600, 2, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray24.Add(new AdventureItem(83, config47, config48, 6, 6, 6, 1, 10, 3, resCost24, itemCost23, restrictedByWorldPopulation: false, malice23, adventureParams18, "25a42d7a-6aa9-4e64-b8e4-3b8ccbb21dd5", startNodes17, transferNodes17, endNodes16, baseBranches16, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray25 = _dataArray;
		string config49 = LocalStringManager.GetConfig("Adventure_language", "Name_84");
		string config50 = LocalStringManager.GetConfig("Adventure_language", "Desc_84");
		int[] resCost25 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost24 = list;
		short[] malice24 = new short[3];
		adventureParams = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams19 = adventureParams;
		List<AdventureStartNode> startNodes18 = new List<AdventureStartNode>
		{
			new AdventureStartNode("9fa6a204-4e36-4bd0-9796-19d7e51c2373", "A", "LK_Adventure_NodeTitle_243", 9)
		};
		List<AdventureTransferNode> transferNodes18 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("b89eb865-5246-40ad-a59f-f289a5c8831a", "B", "LK_Adventure_NodeTitle_244", 9),
			new AdventureTransferNode("f557b815-3f3b-4c64-80cb-4aa47b7411ae", "C", "LK_Adventure_NodeTitle_244", 9),
			new AdventureTransferNode("7100938d-a0ad-4f76-8870-717d688634b8", "D", "LK_Adventure_NodeTitle_244", 9)
		};
		List<AdventureEndNode> endNodes17 = new List<AdventureEndNode>
		{
			new AdventureEndNode("102fc53f-2d52-46dd-86b9-9c97c21edc30", "E", "LK_Adventure_NodeTitle_278", 9)
		};
		List<AdventureBaseBranch> baseBranches17 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 4, "", new int[2] { 0, 100 }, new int[9] { 1, 7, 9, 50, 10, 10, 10, 60, 10 }, new int[5] { 50, 50, 50, 0, 50 }, new string[7] { "0", "0", "0", "1", "d9cf0899-1916-4eef-ba94-32c5098424b2", "30", "0" }, new int[14]
			{
				0, 0, 0, 3, 8, 200, 5, 8, 300, 3,
				8, 400, 2, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 1, 4, "", new int[2] { 0, 100 }, new int[9] { 1, 7, 9, 50, 10, 10, 10, 60, 10 }, new int[5] { 50, 50, 50, 0, 50 }, new string[7] { "0", "0", "0", "1", "d9cf0899-1916-4eef-ba94-32c5098424b2", "30", "0" }, new int[14]
			{
				0, 0, 0, 3, 8, 300, 5, 8, 450, 3,
				8, 600, 2, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 3, "3", 1, 4, "", new int[2] { 0, 100 }, new int[9] { 1, 7, 9, 50, 10, 10, 10, 60, 10 }, new int[5] { 50, 50, 50, 0, 50 }, new string[7] { "0", "0", "0", "1", "d9cf0899-1916-4eef-ba94-32c5098424b2", "30", "0" }, new int[14]
			{
				0, 0, 0, 3, 8, 500, 5, 8, 750, 3,
				8, 1000, 2, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 4, "4", 1, 4, "", new int[2] { 0, 100 }, new int[9] { 1, 7, 9, 50, 10, 10, 10, 60, 10 }, new int[5] { 50, 50, 50, 0, 50 }, new string[7] { "0", "0", "0", "1", "d9cf0899-1916-4eef-ba94-32c5098424b2", "30", "0" }, new int[14]
			{
				0, 0, 0, 3, 8, 800, 5, 8, 1200, 3,
				8, 1600, 2, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray25.Add(new AdventureItem(84, config49, config50, 6, 6, 6, 1, 10, 3, resCost25, itemCost24, restrictedByWorldPopulation: false, malice24, adventureParams19, "25a42d7a-6aa9-4e64-b8e4-3b8ccbb21dd5", startNodes18, transferNodes18, endNodes17, baseBranches17, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray26 = _dataArray;
		string config51 = LocalStringManager.GetConfig("Adventure_language", "Name_85");
		string config52 = LocalStringManager.GetConfig("Adventure_language", "Desc_85");
		int[] resCost26 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost25 = list;
		short[] malice25 = new short[3];
		adventureParams = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams20 = adventureParams;
		List<AdventureStartNode> startNodes19 = new List<AdventureStartNode>
		{
			new AdventureStartNode("198b153c-c96f-4e97-86ae-4dcc5bb6f7dc", "A", "LK_Adventure_NodeTitle_243", 9)
		};
		List<AdventureTransferNode> transferNodes19 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("b89eb865-5246-40ad-a59f-f289a5c8831a", "B", "LK_Adventure_NodeTitle_244", 9),
			new AdventureTransferNode("f557b815-3f3b-4c64-80cb-4aa47b7411ae", "C", "LK_Adventure_NodeTitle_244", 9),
			new AdventureTransferNode("7100938d-a0ad-4f76-8870-717d688634b8", "D", "LK_Adventure_NodeTitle_244", 9)
		};
		List<AdventureEndNode> endNodes18 = new List<AdventureEndNode>
		{
			new AdventureEndNode("102fc53f-2d52-46dd-86b9-9c97c21edc30", "E", "LK_Adventure_NodeTitle_278", 9)
		};
		List<AdventureBaseBranch> baseBranches18 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 4, "", new int[2] { 0, 100 }, new int[9] { 1, 7, 9, 50, 10, 10, 10, 60, 10 }, new int[5] { 50, 50, 50, 0, 50 }, new string[7] { "0", "0", "0", "1", "d9cf0899-1916-4eef-ba94-32c5098424b2", "30", "0" }, new int[14]
			{
				0, 0, 0, 3, 8, 200, 5, 8, 300, 3,
				8, 400, 2, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 1, 4, "", new int[2] { 0, 100 }, new int[9] { 1, 7, 9, 50, 10, 10, 10, 60, 10 }, new int[5] { 50, 50, 50, 0, 50 }, new string[7] { "0", "0", "0", "1", "d9cf0899-1916-4eef-ba94-32c5098424b2", "30", "0" }, new int[14]
			{
				0, 0, 0, 3, 8, 300, 5, 8, 450, 3,
				8, 600, 2, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 3, "3", 1, 4, "", new int[2] { 0, 100 }, new int[9] { 1, 7, 9, 50, 10, 10, 10, 60, 10 }, new int[5] { 50, 50, 50, 0, 50 }, new string[7] { "0", "0", "0", "1", "d9cf0899-1916-4eef-ba94-32c5098424b2", "30", "0" }, new int[14]
			{
				0, 0, 0, 3, 8, 500, 5, 8, 750, 3,
				8, 1000, 2, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 4, "4", 1, 4, "", new int[2] { 0, 100 }, new int[9] { 1, 7, 9, 50, 10, 10, 10, 60, 10 }, new int[5] { 50, 50, 50, 0, 50 }, new string[7] { "0", "0", "0", "1", "d9cf0899-1916-4eef-ba94-32c5098424b2", "30", "0" }, new int[14]
			{
				0, 0, 0, 3, 8, 800, 5, 8, 1200, 3,
				8, 1600, 2, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray26.Add(new AdventureItem(85, config51, config52, 6, 6, 6, 1, 10, 3, resCost26, itemCost25, restrictedByWorldPopulation: false, malice25, adventureParams20, "25a42d7a-6aa9-4e64-b8e4-3b8ccbb21dd5", startNodes19, transferNodes19, endNodes18, baseBranches18, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray27 = _dataArray;
		string config53 = LocalStringManager.GetConfig("Adventure_language", "Name_86");
		string config54 = LocalStringManager.GetConfig("Adventure_language", "Desc_86");
		int[] resCost27 = new int[9];
		list = new List<int[]>();
		dataArray27.Add(new AdventureItem(86, config53, config54, 6, 1, 6, 1, 10, 3, resCost27, list, restrictedByWorldPopulation: false, new short[3], new List<(string, string, string, string)>
		{
			("colourGrade", "LK_Adventure_86_ParamName_0", "", ""),
			("freshGrade", "LK_Adventure_86_ParamName_1", "", ""),
			("fragrantGrade", "LK_Adventure_86_ParamName_2", "", ""),
			("flavorGrade", "LK_Adventure_86_ParamName_3", "", ""),
			("tasteGrade", "LK_Adventure_86_ParamName_4", "", ""),
			("healthGrade", "LK_Adventure_86_ParamName_5", "", ""),
			("meetingGrade", "LK_Adventure_86_ParamName_6", "", "")
		}, "01fdc8e2-e46c-4804-8d79-a363d81216b4", new List<AdventureStartNode>
		{
			new AdventureStartNode("0b2c5c46-97d6-43fa-8ea9-a77be41df521", "A", "LK_Adventure_NodeTitle_286", 9)
		}, new List<AdventureTransferNode>
		{
			new AdventureTransferNode("dd33b0c0-3013-41ce-b688-eddd1b591dfa", "B", "LK_Adventure_NodeTitle_287", 9)
		}, new List<AdventureEndNode>
		{
			new AdventureEndNode("fc8b17f5-4a32-4307-bc7b-d4547e2f4597", "C", "LK_Adventure_NodeTitle_288", 9)
		}, new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 2, "", new int[2] { 14, 100 }, new int[9] { 1, 7, 9, 100, 60, 10, 10, 10, 10 }, new int[5] { 100, 10, 10, 10, 10 }, new string[5] { "0", "0", "0", "0", "0" }, new int[14]
			{
				3, 0, 320, 50, 0, 480, 30, 0, 640, 20,
				0, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 1, 13, "", new int[2] { 14, 100 }, new int[9] { 1, 7, 9, 100, 30, 10, 0, 30, 30 }, new int[5] { 45, 10, 40, 45, 45 }, new string[17]
			{
				"1", "8f838394-cc57-4765-b316-34b24440bc80", "35", "2", "51a871ad-09a4-4dd1-a68f-a99c1f700c76", "20", "c591035d-f0b2-409d-bad3-f18f897a16a1", "20", "1", "9143d24b-8cdb-488f-86fd-6ff14286ec60",
				"40", "1", "fe831c56-5341-46e1-a445-d77c5799fe62", "35", "1", "f85c81c8-4e82-42b9-bc26-3810f6087ae7", "35"
			}, new int[32]
			{
				3, 0, 320, 10, 0, 480, 6, 0, 640, 4,
				3, 8, 800, 10, 8, 1200, 6, 8, 1600, 4,
				0, 3, 7, 160, 10, 7, 240, 6, 7, 320,
				4, 0
			}, new int[9] { 0, 0, 0, 0, 1, 5, -501, 1, 20 }, new string[5] { "0", "0", "0", "0", "0" })
		}, new List<AdventureAdvancedBranch>
		{
			new AdventureAdvancedBranch(2, "", 1, 14, 200, new int[2] { 14, 100 }, new int[9] { 1, 7, 9, 100, 0, 0, 100, 0, 0 }, new int[5] { 10, 10, 0, 10, 10 }, new string[7] { "0", "0", "1", "9143d24b-8cdb-488f-86fd-6ff14286ec60", "100", "0", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray28 = _dataArray;
		string config55 = LocalStringManager.GetConfig("Adventure_language", "Name_87");
		string config56 = LocalStringManager.GetConfig("Adventure_language", "Desc_87");
		int[] resCost28 = new int[9];
		list = new List<int[]>();
		dataArray28.Add(new AdventureItem(87, config55, config56, 6, 1, 6, 1, 10, 3, resCost28, list, restrictedByWorldPopulation: false, new short[3], new List<(string, string, string, string)>
		{
			("infectGrade", "LK_Adventure_87_ParamName_0", "", ""),
			("hideGrade", "LK_Adventure_87_ParamName_1", "", ""),
			("intenseGrade", "LK_Adventure_87_ParamName_2", "", ""),
			("painGrade", "LK_Adventure_87_ParamName_3", "", ""),
			("queerGrade", "LK_Adventure_87_ParamName_4", "", ""),
			("easyGrade", "LK_Adventure_87_ParamName_5", "", ""),
			("meetingGrade", "LK_Adventure_86_ParamName_6", "", "")
		}, "f9c13f89-cb70-4ece-8b29-96894b87c031", new List<AdventureStartNode>
		{
			new AdventureStartNode("f0eb0ac0-36fa-4fa9-a4f8-2ca598c33451", "A", "LK_Adventure_NodeTitle_295", 9)
		}, new List<AdventureTransferNode>
		{
			new AdventureTransferNode("fcebd5e4-4aa8-4da0-bd6c-2bc4b984d7d1", "B", "LK_Adventure_NodeTitle_287", 9)
		}, new List<AdventureEndNode>
		{
			new AdventureEndNode("d1f40b60-bf30-494f-aba9-660886fd9404", "C", "LK_Adventure_NodeTitle_288", 9)
		}, new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 2, "", new int[2] { 9, 100 }, new int[9] { 1, 7, 9, 100, 60, 10, 10, 10, 10 }, new int[5] { 100, 10, 10, 10, 10 }, new string[5] { "0", "0", "0", "0", "0" }, new int[14]
			{
				3, 5, 320, 50, 5, 480, 30, 5, 640, 20,
				0, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 1, 13, "", new int[2] { 9, 100 }, new int[9] { 1, 7, 9, 100, 30, 10, 0, 30, 30 }, new int[5] { 45, 10, 40, 45, 45 }, new string[17]
			{
				"1", "643c1199-96a0-4cc9-85c9-db148fd9bcdf", "35", "2", "ffa95b20-9021-4b6a-84d3-044e32d10ff7", "20", "6bf23cfe-5f72-4a19-bcbd-8dfc901fdf13", "20", "1", "a0d68cf9-44e7-4ef2-977f-e080affa177b",
				"40", "1", "fa5ac831-fa9e-49ee-a6d8-c38f8275f3b2", "35", "1", "3d05fb7e-ab5f-4ad6-88be-a8086e87b585", "35"
			}, new int[32]
			{
				3, 5, 320, 10, 5, 480, 6, 5, 640, 4,
				3, 8, 800, 10, 8, 1200, 6, 8, 1600, 4,
				0, 3, 7, 160, 10, 7, 240, 6, 7, 320,
				4, 0
			}, new int[9] { 0, 0, 0, 0, 1, 5, -507, 1, 20 }, new string[5] { "0", "0", "0", "0", "0" })
		}, new List<AdventureAdvancedBranch>
		{
			new AdventureAdvancedBranch(2, "", 1, 9, 200, new int[2] { 9, 100 }, new int[9] { 1, 7, 9, 100, 0, 0, 100, 0, 0 }, new int[5] { 10, 10, 0, 10, 10 }, new string[7] { "0", "0", "1", "a0d68cf9-44e7-4ef2-977f-e080affa177b", "100", "0", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray29 = _dataArray;
		string config57 = LocalStringManager.GetConfig("Adventure_language", "Name_88");
		string config58 = LocalStringManager.GetConfig("Adventure_language", "Desc_88");
		int[] resCost29 = new int[9];
		list = new List<int[]>();
		dataArray29.Add(new AdventureItem(88, config57, config58, 6, 1, 6, 1, 10, 3, resCost29, list, restrictedByWorldPopulation: false, new short[3], new List<(string, string, string, string)>
		{
			("lissomGrade", "LK_Adventure_88_ParamName_0", "", ""),
			("durableGrade", "LK_Adventure_88_ParamName_1", "", ""),
			("sharpGrade", "LK_Adventure_88_ParamName_2", "", ""),
			("toughGrade", "LK_Adventure_88_ParamName_3", "", ""),
			("beautifulGrade", "LK_Adventure_88_ParamName_4", "", ""),
			("interestingGrade", "LK_Adventure_88_ParamName_5", "", ""),
			("meetingGrade", "LK_Adventure_86_ParamName_6", "", "")
		}, "97b653d8-5464-4821-8ac6-670bd5dace2b", new List<AdventureStartNode>
		{
			new AdventureStartNode("d3bd899c-b354-445b-99be-387fced3c7cc", "A", "LK_Adventure_NodeTitle_302", 9)
		}, new List<AdventureTransferNode>
		{
			new AdventureTransferNode("4227caf3-89d5-46e1-9dfc-bc55eeb9cf67", "B", "LK_Adventure_NodeTitle_287", 9)
		}, new List<AdventureEndNode>
		{
			new AdventureEndNode("512e0378-4ccb-496b-9d30-0a1152194810", "C", "LK_Adventure_NodeTitle_288", 9)
		}, new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 2, "", new int[2] { 6, 100 }, new int[9] { 1, 7, 9, 100, 60, 10, 10, 10, 10 }, new int[5] { 100, 10, 10, 10, 10 }, new string[5] { "0", "0", "0", "0", "0" }, new int[14]
			{
				3, 2, 320, 50, 2, 480, 30, 2, 640, 20,
				0, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 1, 13, "", new int[2] { 6, 100 }, new int[9] { 1, 7, 9, 100, 30, 10, 0, 30, 30 }, new int[5] { 45, 10, 40, 45, 45 }, new string[17]
			{
				"1", "cb92bac6-1c50-4f94-a709-abc1ef06ceb2", "35", "2", "406bea91-12cb-4737-a046-2f41f416d972", "20", "7881c9c3-ce31-4343-ace9-fd2964b5105c", "20", "1", "f5c8e155-fe21-4bb6-a556-590a8547ece0",
				"40", "1", "403d65a5-27c3-4113-83fd-d30c994e0bb3", "35", "1", "69a7ea7b-503b-40cd-b75c-93b67f9f5742", "35"
			}, new int[32]
			{
				3, 2, 320, 10, 2, 480, 6, 2, 640, 4,
				3, 8, 800, 10, 8, 1200, 6, 8, 1600, 4,
				0, 3, 7, 160, 10, 7, 240, 6, 7, 320,
				4, 0
			}, new int[9] { 0, 0, 0, 0, 1, 5, -503, 1, 20 }, new string[5] { "0", "0", "0", "0", "0" })
		}, new List<AdventureAdvancedBranch>
		{
			new AdventureAdvancedBranch(2, "", 1, 6, 200, new int[2] { 6, 100 }, new int[9] { 1, 7, 9, 100, 0, 0, 100, 0, 0 }, new int[5] { 10, 10, 0, 10, 10 }, new string[7] { "0", "0", "1", "f5c8e155-fe21-4bb6-a556-590a8547ece0", "100", "0", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray30 = _dataArray;
		string config59 = LocalStringManager.GetConfig("Adventure_language", "Name_89");
		string config60 = LocalStringManager.GetConfig("Adventure_language", "Desc_89");
		int[] resCost30 = new int[9];
		list = new List<int[]>();
		dataArray30.Add(new AdventureItem(89, config59, config60, 6, 1, 6, 1, 10, 3, resCost30, list, restrictedByWorldPopulation: false, new short[3], new List<(string, string, string, string)>
		{
			("lissomGrade", "LK_Adventure_88_ParamName_0", "", ""),
			("durableGrade", "LK_Adventure_88_ParamName_1", "", ""),
			("sharpGrade", "LK_Adventure_88_ParamName_2", "", ""),
			("toughGrade", "LK_Adventure_88_ParamName_3", "", ""),
			("beautifulGrade", "LK_Adventure_88_ParamName_4", "", ""),
			("interestingGrade", "LK_Adventure_88_ParamName_5", "", ""),
			("meetingGrade", "LK_Adventure_86_ParamName_6", "", "")
		}, "97b653d8-5464-4821-8ac6-670bd5dace2b", new List<AdventureStartNode>
		{
			new AdventureStartNode("8fd5e97d-3d7d-46a4-b945-f01264d44597", "A", "LK_Adventure_NodeTitle_303", 9)
		}, new List<AdventureTransferNode>
		{
			new AdventureTransferNode("2b93eb89-ebbb-400a-8872-495a485f26ed", "B", "LK_Adventure_NodeTitle_287", 9)
		}, new List<AdventureEndNode>
		{
			new AdventureEndNode("0a879c9b-3869-48e5-bcaa-96381d866abd", "C", "LK_Adventure_NodeTitle_288", 9)
		}, new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 2, "", new int[2] { 11, 100 }, new int[9] { 1, 7, 9, 100, 60, 10, 10, 10, 10 }, new int[5] { 100, 10, 10, 10, 10 }, new string[5] { "0", "0", "0", "0", "0" }, new int[14]
			{
				3, 3, 320, 50, 3, 480, 30, 3, 640, 20,
				0, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 1, 13, "", new int[2] { 11, 100 }, new int[9] { 1, 7, 9, 100, 30, 10, 0, 30, 30 }, new int[5] { 45, 10, 40, 45, 45 }, new string[17]
			{
				"1", "56a6100e-fddb-41d0-880d-4511a2b92bbb", "35", "2", "15aa826b-e2f8-4561-93ee-999beabd1585", "20", "e0e35c35-81f4-4ec4-9f09-fbf2a8328a2d", "20", "1", "8548e806-8179-4864-9d87-4398de12e644",
				"40", "1", "5aeed1f0-710d-4eee-b91c-df3c58400a91", "35", "1", "8547b1e4-d2f2-4447-a8b9-42e9381f0ef3", "35"
			}, new int[32]
			{
				3, 3, 320, 10, 3, 480, 6, 3, 640, 4,
				3, 8, 800, 10, 8, 1200, 6, 8, 1600, 4,
				0, 3, 7, 160, 10, 7, 240, 6, 7, 320,
				4, 0
			}, new int[9] { 0, 0, 0, 0, 1, 5, -504, 1, 20 }, new string[5] { "0", "0", "0", "0", "0" })
		}, new List<AdventureAdvancedBranch>
		{
			new AdventureAdvancedBranch(2, "", 1, 11, 200, new int[2] { 11, 100 }, new int[9] { 1, 7, 9, 100, 0, 0, 100, 0, 0 }, new int[5] { 10, 10, 0, 10, 10 }, new string[7] { "0", "0", "1", "8548e806-8179-4864-9d87-4398de12e644", "100", "0", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray31 = _dataArray;
		string config61 = LocalStringManager.GetConfig("Adventure_language", "Name_90");
		string config62 = LocalStringManager.GetConfig("Adventure_language", "Desc_90");
		int[] resCost31 = new int[9];
		list = new List<int[]>();
		dataArray31.Add(new AdventureItem(90, config61, config62, 6, 1, 6, 1, 10, 3, resCost31, list, restrictedByWorldPopulation: false, new short[3], new List<(string, string, string, string)>
		{
			("speedGrade", "LK_Adventure_90_ParamName_0", "", ""),
			("tasteGrade", "LK_Adventure_90_ParamName_1", "", ""),
			("effectGrade", "LK_Adventure_90_ParamName_2", "", ""),
			("benefitGrade", "LK_Adventure_90_ParamName_3", "", ""),
			("identicalGrade", "LK_Adventure_90_ParamName_4", "", ""),
			("moneyGrade", "LK_Adventure_90_ParamName_5", "", ""),
			("meetingGrade", "LK_Adventure_86_ParamName_6", "", "")
		}, "9bd9f1fb-5f5c-4f1b-a1c8-8ec076847453", new List<AdventureStartNode>
		{
			new AdventureStartNode("97d0df30-5661-4fc7-8fa3-2cf366a746a0", "A", "LK_Adventure_NodeTitle_310", 9)
		}, new List<AdventureTransferNode>
		{
			new AdventureTransferNode("51f15c7f-92cc-4815-a6bf-50c35d262d12", "B", "LK_Adventure_NodeTitle_287", 9)
		}, new List<AdventureEndNode>
		{
			new AdventureEndNode("4f42b2dd-c352-4a44-b7d2-e0ffd6dc77ba", "C", "LK_Adventure_NodeTitle_288", 9)
		}, new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 2, "", new int[2] { 8, 100 }, new int[9] { 1, 7, 9, 100, 60, 10, 10, 10, 10 }, new int[5] { 100, 10, 10, 10, 10 }, new string[5] { "0", "0", "0", "0", "0" }, new int[14]
			{
				3, 5, 320, 50, 5, 480, 30, 5, 640, 20,
				0, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 1, 13, "", new int[2] { 8, 100 }, new int[9] { 1, 7, 9, 100, 30, 10, 0, 30, 30 }, new int[5] { 45, 10, 40, 45, 45 }, new string[17]
			{
				"1", "8a8d951a-ea1e-4153-8764-d5c7fc75ffe3", "35", "2", "3cd6ddbf-d305-4538-823f-3ed5e01959fa", "20", "ac4bc741-f319-4c23-9b18-00c839bf520c", "20", "1", "d7deb455-f671-4bcf-aab1-4cb083e7e192",
				"40", "1", "6be35aae-7f96-48bd-9a46-2882d551df09", "35", "1", "26babb67-87c0-4fab-a068-6d61868900f5", "35"
			}, new int[32]
			{
				3, 5, 320, 10, 5, 480, 6, 5, 640, 4,
				3, 8, 800, 10, 8, 1200, 6, 8, 1600, 4,
				0, 3, 7, 160, 10, 7, 240, 6, 7, 320,
				4, 0
			}, new int[9] { 0, 0, 0, 0, 1, 5, -506, 1, 20 }, new string[5] { "0", "0", "0", "0", "0" })
		}, new List<AdventureAdvancedBranch>
		{
			new AdventureAdvancedBranch(2, "", 1, 8, 200, new int[2] { 8, 100 }, new int[9] { 1, 7, 9, 100, 0, 0, 100, 0, 0 }, new int[5] { 10, 10, 0, 10, 10 }, new string[7] { "0", "0", "1", "d7deb455-f671-4bcf-aab1-4cb083e7e192", "100", "0", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray32 = _dataArray;
		string config63 = LocalStringManager.GetConfig("Adventure_language", "Name_91");
		string config64 = LocalStringManager.GetConfig("Adventure_language", "Desc_91");
		int[] resCost32 = new int[9];
		list = new List<int[]>();
		dataArray32.Add(new AdventureItem(91, config63, config64, 6, 1, 6, 1, 10, 3, resCost32, list, restrictedByWorldPopulation: false, new short[3], new List<(string, string, string, string)>
		{
			("lissomGrade", "LK_Adventure_88_ParamName_0", "", ""),
			("durableGrade", "LK_Adventure_88_ParamName_1", "", ""),
			("sharpGrade", "LK_Adventure_88_ParamName_2", "", ""),
			("toughGrade", "LK_Adventure_88_ParamName_3", "", ""),
			("beautifulGrade", "LK_Adventure_88_ParamName_4", "", ""),
			("interestingGrade", "LK_Adventure_88_ParamName_5", "", ""),
			("meetingGrade", "LK_Adventure_86_ParamName_6", "", "")
		}, "97b653d8-5464-4821-8ac6-670bd5dace2b", new List<AdventureStartNode>
		{
			new AdventureStartNode("ff7b916c-668d-4839-b3e2-60a943b4cd92", "A", "LK_Adventure_NodeTitle_311", 9)
		}, new List<AdventureTransferNode>
		{
			new AdventureTransferNode("92c21190-cd57-4645-8f83-3b1265690b73", "B", "LK_Adventure_NodeTitle_287", 9)
		}, new List<AdventureEndNode>
		{
			new AdventureEndNode("d926eb97-4884-4848-b434-6a76457f592e", "C", "LK_Adventure_NodeTitle_288", 9)
		}, new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 2, "", new int[2] { 10, 100 }, new int[9] { 1, 7, 9, 100, 60, 10, 10, 10, 10 }, new int[5] { 100, 10, 10, 10, 10 }, new string[5] { "0", "0", "0", "0", "0" }, new int[14]
			{
				3, 4, 320, 50, 4, 480, 30, 4, 640, 20,
				0, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 1, 13, "", new int[2] { 10, 100 }, new int[9] { 1, 7, 9, 100, 30, 10, 0, 30, 30 }, new int[5] { 45, 10, 40, 45, 45 }, new string[17]
			{
				"1", "0b896fe9-725f-47ce-9d2b-e3c91d74b0f4", "35", "2", "b12b0708-0a09-404f-8a25-77e73c4ebd10", "20", "ddccbb11-c355-458a-9d11-a00bc5842f8b", "20", "1", "61737c6f-af92-49ca-8a77-a8651e25d918",
				"40", "1", "86d87771-18c8-49bd-b0a4-e32a66823d7a", "35", "1", "fa48b991-d07b-45a6-9eb8-648df7d3762c", "35"
			}, new int[32]
			{
				3, 4, 320, 10, 4, 480, 6, 4, 640, 4,
				3, 8, 800, 10, 8, 1200, 6, 8, 1600, 4,
				0, 3, 7, 160, 10, 7, 240, 6, 7, 320,
				4, 0
			}, new int[9] { 0, 0, 0, 0, 1, 5, -505, 1, 20 }, new string[5] { "0", "0", "0", "0", "0" })
		}, new List<AdventureAdvancedBranch>
		{
			new AdventureAdvancedBranch(2, "", 1, 10, 200, new int[2] { 10, 100 }, new int[9] { 1, 7, 9, 100, 0, 0, 100, 0, 0 }, new int[5] { 10, 10, 0, 10, 10 }, new string[7] { "0", "0", "1", "61737c6f-af92-49ca-8a77-a8651e25d918", "100", "0", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray33 = _dataArray;
		string config65 = LocalStringManager.GetConfig("Adventure_language", "Name_92");
		string config66 = LocalStringManager.GetConfig("Adventure_language", "Desc_92");
		int[] resCost33 = new int[9];
		list = new List<int[]>();
		dataArray33.Add(new AdventureItem(92, config65, config66, 6, 1, 6, 1, 10, 3, resCost33, list, restrictedByWorldPopulation: false, new short[3], new List<(string, string, string, string)>
		{
			("lissomGrade", "LK_Adventure_88_ParamName_0", "", ""),
			("durableGrade", "LK_Adventure_88_ParamName_1", "", ""),
			("sharpGrade", "LK_Adventure_88_ParamName_2", "", ""),
			("toughGrade", "LK_Adventure_88_ParamName_3", "", ""),
			("beautifulGrade", "LK_Adventure_88_ParamName_4", "", ""),
			("interestingGrade", "LK_Adventure_88_ParamName_5", "", ""),
			("meetingGrade", "LK_Adventure_86_ParamName_6", "", "")
		}, "97b653d8-5464-4821-8ac6-670bd5dace2b", new List<AdventureStartNode>
		{
			new AdventureStartNode("e4486190-3a21-41e0-9fcf-065f8a867eab", "A", "LK_Adventure_NodeTitle_312", 9)
		}, new List<AdventureTransferNode>
		{
			new AdventureTransferNode("c2c8afcb-bbe7-4bd3-9b2e-706aee54ea67", "B", "LK_Adventure_NodeTitle_287", 9)
		}, new List<AdventureEndNode>
		{
			new AdventureEndNode("7b9e8841-0fe9-4a18-9adc-e4fea9f49867", "C", "LK_Adventure_NodeTitle_288", 9)
		}, new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 2, "", new int[2] { 7, 100 }, new int[9] { 1, 7, 9, 100, 60, 10, 10, 10, 10 }, new int[5] { 100, 10, 10, 10, 10 }, new string[5] { "0", "0", "0", "0", "0" }, new int[14]
			{
				3, 1, 320, 50, 1, 480, 30, 1, 640, 20,
				0, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 1, 13, "", new int[2] { 7, 100 }, new int[9] { 1, 7, 9, 100, 30, 10, 0, 30, 30 }, new int[5] { 45, 10, 40, 45, 45 }, new string[17]
			{
				"1", "c444096c-bc70-4581-a109-235681c5eee1", "35", "2", "b7743543-fd98-48ba-956d-b132842929a9", "20", "0c155533-5ce5-49c7-9d1c-b4e94feaf56c", "20", "1", "c8d0048b-90ca-4b68-a1f8-fee0165702cc",
				"40", "1", "ce79d03d-241d-4003-a08e-2538928ed180", "35", "1", "a8b26358-1a94-4393-87bd-626a6ebf585b", "35"
			}, new int[32]
			{
				3, 1, 320, 10, 1, 480, 6, 1, 640, 4,
				3, 8, 800, 10, 8, 1200, 6, 8, 1600, 4,
				0, 3, 7, 160, 10, 7, 240, 6, 7, 320,
				4, 0
			}, new int[9] { 0, 0, 0, 0, 1, 5, -502, 1, 20 }, new string[5] { "0", "0", "0", "0", "0" })
		}, new List<AdventureAdvancedBranch>
		{
			new AdventureAdvancedBranch(2, "", 1, 7, 200, new int[2] { 7, 100 }, new int[9] { 1, 7, 9, 100, 0, 0, 100, 0, 0 }, new int[5] { 10, 10, 0, 10, 10 }, new string[7] { "0", "0", "1", "c8d0048b-90ca-4b68-a1f8-fee0165702cc", "100", "0", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray34 = _dataArray;
		string config67 = LocalStringManager.GetConfig("Adventure_language", "Name_93");
		string config68 = LocalStringManager.GetConfig("Adventure_language", "Desc_93");
		int[] resCost34 = new int[9];
		list = new List<int[]>();
		dataArray34.Add(new AdventureItem(93, config67, config68, 6, 1, 7, 1, 10, 3, resCost34, list, restrictedByWorldPopulation: false, new short[3], new List<(string, string, string, string)> { ("totalScore", "LK_Adventure_93_ParamName_0", "adventure_icon_fenxiang", "") }, "6e892342-f7b7-41b0-ae9f-90d9ce791b15", new List<AdventureStartNode>
		{
			new AdventureStartNode("959ef33b-3d70-4b60-815c-e71f78f79d2d", "A", "LK_Adventure_NodeTitle_314", 9)
		}, new List<AdventureTransferNode>
		{
			new AdventureTransferNode("ebee1d8e-d091-4b2f-a536-8894f674b075", "B", "LK_Adventure_NodeTitle_315", 9)
		}, new List<AdventureEndNode>
		{
			new AdventureEndNode("8238cc18-160a-4a9e-8b06-ea3e5c546f06", "C", "LK_Adventure_NodeTitle_316", 9),
			new AdventureEndNode("f35fb196-029c-4d21-ab2c-56a09d3454a0", "D", "LK_Adventure_NodeTitle_316", 9)
		}, new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 2, "", new int[2] { 15, 100 }, new int[16]
			{
				5, 2, 9, 50, 2, 10, 10, 2, 17, 20,
				2, 18, 5, 2, 12, 15
			}, new int[5] { 10, 10, 10, 10, 10 }, new string[5] { "0", "0", "0", "0", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 1, 15, "", new int[2] { 15, 100 }, new int[41]
			{
				5, 7, 9, 50, 10, 10, 20, 60, 10, 7,
				10, 10, 10, 10, 20, 60, 10, 7, 17, 20,
				10, 10, 20, 60, 10, 7, 18, 5, 10, 10,
				20, 60, 10, 7, 12, 15, 10, 10, 20, 60,
				10
			}, new int[5] { 50, 10, 20, 20, 10 }, new string[9] { "0", "0", "1", "3026e4c7-ffea-4bfa-90a2-87465e7ea218", "40", "1", "bea31d94-905c-418e-863a-534c6535e6cd", "40", "0" }, new int[68]
			{
				15, 0, 320, 5, 0, 480, 3, 0, 640, 2,
				1, 320, 5, 1, 480, 3, 1, 640, 2, 2,
				320, 5, 2, 480, 3, 2, 640, 2, 3, 320,
				5, 3, 480, 3, 3, 640, 2, 4, 320, 5,
				4, 480, 3, 4, 640, 2, 3, 8, 800, 5,
				8, 1200, 3, 8, 1600, 2, 0, 0, 3, 5,
				320, 5, 5, 480, 3, 5, 640, 2
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 3, "3", 1, 8, "", new int[2] { 15, 100 }, new int[41]
			{
				5, 7, 9, 50, 10, 10, 40, 10, 10, 7,
				10, 10, 10, 10, 40, 10, 10, 7, 17, 20,
				10, 10, 40, 10, 10, 7, 18, 5, 10, 10,
				40, 10, 10, 7, 12, 15, 10, 10, 40, 10,
				10
			}, new int[5] { 50, 10, 20, 20, 10 }, new string[7] { "0", "0", "1", "3026e4c7-ffea-4bfa-90a2-87465e7ea218", "40", "0", "0" }, new int[68]
			{
				15, 0, 320, 5, 0, 480, 3, 0, 640, 2,
				1, 320, 5, 1, 480, 3, 1, 640, 2, 2,
				320, 5, 2, 480, 3, 2, 640, 2, 3, 320,
				5, 3, 480, 3, 3, 640, 2, 4, 320, 5,
				4, 480, 3, 4, 640, 2, 3, 8, 800, 5,
				8, 1200, 3, 8, 1600, 2, 0, 0, 3, 5,
				320, 5, 5, 480, 3, 5, 640, 2
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, new List<AdventureAdvancedBranch>
		{
			new AdventureAdvancedBranch(5, "", 1, 15, 200, new int[2] { 15, 100 }, new int[9] { 1, 7, 10, 100, 0, 0, 100, 0, 0 }, new int[5] { 10, 10, 0, 10, 10 }, new string[11]
			{
				"0", "0", "3", "bafc2702-498d-4c3c-b5ef-bd5c880ab292", "10", "2499950e-f7e2-4882-a62c-74568d84b571", "10", "45d95880-850d-4f7e-925e-541d92970765", "10", "0",
				"0"
			}, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureAdvancedBranch(2, "", 2, 15, 200, new int[2] { 15, 100 }, new int[9] { 1, 7, 10, 10, 0, 0, 100, 0, 0 }, new int[5] { 10, 10, 0, 10, 10 }, new string[11]
			{
				"0", "0", "3", "bafc2702-498d-4c3c-b5ef-bd5c880ab292", "10", "2499950e-f7e2-4882-a62c-74568d84b571", "10", "45d95880-850d-4f7e-925e-541d92970765", "10", "0",
				"0"
			}, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray35 = _dataArray;
		string config69 = LocalStringManager.GetConfig("Adventure_language", "Name_94");
		string config70 = LocalStringManager.GetConfig("Adventure_language", "Desc_94");
		int[] resCost35 = new int[9] { 0, 0, 0, 0, 0, 0, 0, 500, 0 };
		list = new List<int[]>();
		List<int[]> itemCost26 = list;
		short[] malice26 = new short[3];
		adventureParams = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams21 = adventureParams;
		List<AdventureStartNode> startNodes20 = new List<AdventureStartNode>
		{
			new AdventureStartNode("e0c68df9-99df-4308-bc7b-d9b16bf90a5c", "A", "LK_Adventure_NodeTitle_317", 9)
		};
		transferNodes = new List<AdventureTransferNode>();
		dataArray35.Add(new AdventureItem(94, config69, config70, 7, 5, 5, 1, 5, 6, resCost35, itemCost26, restrictedByWorldPopulation: false, malice26, adventureParams21, "ee3772c8-7c5d-474a-a57b-7de65e595c42", startNodes20, transferNodes, new List<AdventureEndNode>
		{
			new AdventureEndNode("c0d369cf-d312-4e5d-aede-e41a0aadfe4e", "B", "LK_Adventure_NodeTitle_318", 5)
		}, new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 3, 15, "", new int[4] { 15, 20, 5, 80 }, new int[57]
			{
				7, 7, 9, 45, 5, 5, 10, 40, 40, 7,
				7, 5, 5, 5, 10, 40, 40, 7, 8, 10,
				5, 5, 10, 40, 40, 7, 13, 10, 10, 5,
				5, 40, 40, 7, 14, 5, 10, 5, 5, 40,
				40, 7, 15, 5, 10, 5, 5, 40, 40, 7,
				10, 20, 5, 5, 10, 40, 40
			}, new int[5] { 10, 0, 10, 10, 10 }, new string[11]
			{
				"0", "0", "1", "92a51d79-f62c-49d1-86e2-6bc65b7d9755", "15", "1", "d65383dc-6530-425f-82c8-1a5e6ba1d2e8", "10", "1", "38aa70a6-ca54-405b-a3db-e61ca936e514",
				"20"
			}, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[9] { 0, 0, 1, 9, -902, 1, 5, 0, 0 }, new string[5] { "0", "0", "0", "0", "0" })
		}, new List<AdventureAdvancedBranch>
		{
			new AdventureAdvancedBranch(3, "", 0, 5, 150, new int[2] { 5, 100 }, new int[9] { 1, 7, 7, 100, 0, 0, 0, 0, 100 }, new int[5] { 10, 10, 10, 10, 0 }, new string[5] { "0", "0", "0", "0", "0" }, new int[5], new int[5], new string[7] { "0", "0", "0", "0", "1", "e5642386-e2b1-436b-8938-5372bd75aca4", "100" })
		}, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray36 = _dataArray;
		string config71 = LocalStringManager.GetConfig("Adventure_language", "Name_95");
		string config72 = LocalStringManager.GetConfig("Adventure_language", "Desc_95");
		int[] resCost36 = new int[9] { 0, 0, 0, 0, 0, 0, 0, 500, 0 };
		list = new List<int[]>();
		List<int[]> itemCost27 = list;
		short[] malice27 = new short[3];
		adventureParams = new List<(string, string, string, string)>();
		dataArray36.Add(new AdventureItem(95, config71, config72, 7, 5, 5, 1, 5, 6, resCost36, itemCost27, restrictedByWorldPopulation: false, malice27, adventureParams, "eaf9ebab-0b0e-4fc4-9e9b-b8ff5c430c01", new List<AdventureStartNode>
		{
			new AdventureStartNode("78dd2fb3-9443-482a-a114-fdb2f920dc59", "0", "LK_Adventure_NodeTitle_319", 1)
		}, new List<AdventureTransferNode>
		{
			new AdventureTransferNode("452ec26b-2b02-47bb-9537-5bd4393a0ffa", "A", "LK_Adventure_NodeTitle_320", 0)
		}, new List<AdventureEndNode>
		{
			new AdventureEndNode("866b4b0a-2b69-4544-b3cd-ec93c120e5fa", "B", "LK_Adventure_NodeTitle_321", 0)
		}, new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "A", 1, 8, "", new int[4] { 0, 50, 2, 50 }, new int[57]
			{
				7, 7, 12, 30, 10, 10, 60, 10, 10, 7,
				10, 15, 10, 10, 60, 10, 10, 7, 11, 15,
				10, 10, 60, 10, 10, 7, 17, 15, 10, 10,
				60, 10, 10, 7, 1, 15, 10, 10, 60, 10,
				10, 7, 13, 5, 10, 10, 60, 10, 10, 7,
				16, 5, 10, 10, 60, 10, 10
			}, new int[5] { 10, 5, 10, 10, 5 }, new string[11]
			{
				"0", "0", "3", "eabcb45d-9c73-42c1-9f82-0d8e2f5b8c36", "35", "e7610d5d-fcf5-4c2d-afc4-2943f854ab77", "10", "29605573-70e6-4bef-8980-8ac73f020e82", "5", "0",
				"0"
			}, new int[14]
			{
				0, 3, 8, 300, 5, 8, 450, 3, 8, 600,
				2, 0, 0, 0
			}, new int[13]
			{
				0, 0, 0, 0, 2, 5, -506, 1, 5, 5,
				-507, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "B", 1, 7, "", new int[4] { 0, 50, 2, 50 }, new int[57]
			{
				7, 7, 12, 30, 5, 10, 40, 40, 10, 7,
				10, 15, 5, 10, 40, 40, 10, 7, 11, 15,
				5, 10, 40, 40, 10, 7, 17, 15, 5, 10,
				40, 40, 10, 7, 1, 15, 5, 10, 40, 40,
				10, 7, 13, 5, 5, 10, 40, 40, 10, 7,
				16, 5, 5, 10, 40, 40, 10
			}, new int[5] { 10, 5, 10, 30, 5 }, new string[13]
			{
				"0", "0", "3", "9fba6a8e-0899-46c2-8b51-0e1342d8e84d", "35", "b9d687fb-7a20-4154-a6ba-f1dea2de6b60", "10", "d5a88cd8-d256-4df8-b5eb-78c01160d8fc", "5", "1",
				"5abbc25d-064d-4dec-be53-89cfe2978540", "50", "0"
			}, new int[14]
			{
				0, 3, 8, 300, 5, 8, 450, 3, 8, 600,
				2, 0, 0, 0
			}, new int[13]
			{
				0, 0, 0, 0, 2, 5, -506, 1, 5, 5,
				-507, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" })
		}, new List<AdventureAdvancedBranch>
		{
			new AdventureAdvancedBranch(2, "", 1, 0, 150, new int[2] { 0, 100 }, new int[9] { 1, 7, 5, 100, 0, 0, 100, 0, 0 }, new int[5] { 10, 10, 0, 10, 10 }, new string[7] { "0", "0", "1", "b9d687fb-7a20-4154-a6ba-f1dea2de6b60", "100", "0", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray37 = _dataArray;
		string config73 = LocalStringManager.GetConfig("Adventure_language", "Name_96");
		string config74 = LocalStringManager.GetConfig("Adventure_language", "Desc_96");
		int[] resCost37 = new int[9] { 0, 0, 0, 0, 0, 0, 0, 500, 0 };
		list = new List<int[]>();
		dataArray37.Add(new AdventureItem(96, config73, config74, 7, 5, 5, 1, 5, 6, resCost37, list, restrictedByWorldPopulation: false, new short[3], new List<(string, string, string, string)> { ("acceptance", "LK_Adventure_96_ParamName_0", "", "") }, "717b1669-1e1d-45e9-abd8-149d734cbb8a", new List<AdventureStartNode>
		{
			new AdventureStartNode("d159512d-661b-47ca-9b71-aedf6376f9fa", "A", "LK_Adventure_NodeTitle_323", 9)
		}, new List<AdventureTransferNode>
		{
			new AdventureTransferNode("b055238f-2fb8-49d8-b301-0f9be59885aa", "B", "LK_Adventure_NodeTitle_324", 15),
			new AdventureTransferNode("ab48fe68-4bfa-4797-b73f-f259d0168f1f", "C", "LK_Adventure_NodeTitle_325", 15),
			new AdventureTransferNode("ab48fe68-4bfa-4797-b73f-f259d0168f1f", "D", "LK_Adventure_NodeTitle_325", 15),
			new AdventureTransferNode("ab48fe68-4bfa-4797-b73f-f259d0168f1f", "E", "LK_Adventure_NodeTitle_325", 15)
		}, new List<AdventureEndNode>
		{
			new AdventureEndNode("d6797b52-725c-4fbc-bc2f-05e8d5caff2c", "F", "LK_Adventure_NodeTitle_326", 9),
			new AdventureEndNode("d6797b52-725c-4fbc-bc2f-05e8d5caff2c", "G", "LK_Adventure_NodeTitle_326", 9),
			new AdventureEndNode("d6797b52-725c-4fbc-bc2f-05e8d5caff2c", "H", "LK_Adventure_NodeTitle_326", 9)
		}, new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 0, 3, "", new int[4] { 4, 80, 5, 20 }, new int[4] { 1, 2, 9, 100 }, new int[5] { 100, 100, 100, 100, 100 }, new string[5] { "0", "0", "0", "0", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "1", 2, 5, "", new int[4] { 4, 80, 5, 20 }, new int[57]
			{
				7, 7, 9, 35, 50, 5, 10, 30, 5, 7,
				14, 15, 50, 5, 10, 30, 5, 7, 15, 15,
				50, 5, 10, 30, 5, 7, 7, 5, 50, 5,
				10, 30, 5, 7, 8, 5, 50, 5, 10, 30,
				5, 7, 13, 5, 50, 5, 10, 30, 5, 7,
				16, 20, 50, 5, 10, 30, 5
			}, new int[5] { 5, 0, 5, 5, 10 }, new string[9] { "1", "f0de2bd2-428a-4c9d-885f-396c94ba9c90", "30", "0", "0", "1", "6a805286-2e81-47bb-8c30-dcda35d7d902", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 2, 7, -701, 1, 5, 7, -702, 1,
				5, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 3, "2", 2, 7, "", new int[4] { 4, 80, 5, 20 }, new int[57]
			{
				7, 7, 9, 35, 50, 5, 10, 30, 5, 7,
				14, 15, 50, 5, 10, 30, 5, 7, 15, 15,
				50, 5, 10, 30, 5, 7, 7, 5, 50, 5,
				10, 30, 5, 7, 8, 5, 50, 5, 10, 30,
				5, 7, 13, 5, 50, 5, 10, 30, 5, 7,
				16, 20, 50, 5, 10, 30, 5
			}, new int[5] { 10, 0, 5, 10, 10 }, new string[9] { "1", "f0de2bd2-428a-4c9d-885f-396c94ba9c90", "30", "0", "0", "1", "6a805286-2e81-47bb-8c30-dcda35d7d902", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 2, 7, -701, 1, 5, 7, -702, 1,
				5, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 4, "3", 2, 10, "", new int[4] { 4, 80, 5, 20 }, new int[57]
			{
				7, 7, 9, 35, 50, 5, 10, 30, 5, 7,
				14, 15, 50, 5, 10, 30, 5, 7, 15, 15,
				50, 5, 10, 30, 5, 7, 7, 5, 50, 5,
				10, 30, 5, 7, 8, 5, 50, 5, 10, 30,
				5, 7, 13, 5, 50, 5, 10, 30, 5, 7,
				16, 20, 50, 5, 10, 30, 5
			}, new int[5] { 20, 0, 5, 20, 10 }, new string[9] { "1", "f0de2bd2-428a-4c9d-885f-396c94ba9c90", "30", "0", "0", "1", "6a805286-2e81-47bb-8c30-dcda35d7d902", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 2, 7, -701, 1, 5, 7, -702, 1,
				5, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 5, "1", 2, 5, "", new int[4] { 4, 80, 5, 20 }, new int[57]
			{
				7, 7, 9, 35, 40, 5, 10, 40, 5, 7,
				14, 15, 40, 5, 10, 40, 5, 7, 15, 15,
				40, 10, 5, 40, 5, 7, 7, 5, 40, 5,
				10, 40, 5, 7, 8, 5, 40, 5, 5, 40,
				10, 7, 13, 5, 40, 5, 5, 40, 10, 7,
				16, 20, 40, 10, 5, 40, 5
			}, new int[5] { 5, 0, 5, 5, 10 }, new string[9] { "1", "09581dd3-8dbf-4b9b-aafb-b1644578f637", "30", "0", "0", "1", "c4ab0e48-2d0d-48df-9fe4-2ac848a94bf4", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 2, 7, -701, 1, 5, 7, -702, 1,
				5, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 6, "1", 2, 8, "", new int[4] { 4, 80, 5, 20 }, new int[57]
			{
				7, 7, 9, 35, 40, 5, 10, 40, 5, 7,
				14, 15, 40, 5, 10, 40, 5, 7, 15, 15,
				40, 10, 5, 40, 5, 7, 7, 5, 40, 5,
				10, 40, 5, 7, 8, 5, 40, 5, 5, 40,
				10, 7, 13, 5, 40, 5, 5, 40, 10, 7,
				16, 20, 40, 10, 5, 40, 5
			}, new int[5] { 10, 0, 5, 10, 10 }, new string[9] { "1", "09581dd3-8dbf-4b9b-aafb-b1644578f637", "30", "0", "0", "1", "c4ab0e48-2d0d-48df-9fe4-2ac848a94bf4", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 2, 7, -701, 1, 5, 7, -702, 1,
				5, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(4, 7, "1", 2, 10, "", new int[4] { 4, 80, 5, 20 }, new int[57]
			{
				7, 7, 9, 35, 40, 5, 10, 40, 5, 7,
				14, 15, 40, 5, 10, 40, 5, 7, 15, 15,
				40, 10, 5, 40, 5, 7, 7, 5, 40, 5,
				10, 40, 5, 7, 8, 5, 40, 5, 5, 40,
				10, 7, 13, 5, 40, 5, 5, 40, 10, 7,
				16, 20, 40, 10, 5, 40, 5
			}, new int[5] { 20, 0, 5, 20, 10 }, new string[9] { "1", "09581dd3-8dbf-4b9b-aafb-b1644578f637", "30", "0", "0", "1", "c4ab0e48-2d0d-48df-9fe4-2ac848a94bf4", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 2, 7, -701, 1, 5, 7, -702, 1,
				5, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" })
		}, new List<AdventureAdvancedBranch>
		{
			new AdventureAdvancedBranch(3, "", 4, 4, 150, new int[2] { 4, 150 }, new int[9] { 1, 7, 22, 100, 0, 0, 0, 100, 0 }, new int[5] { 10, 10, 10, 0, 10 }, new string[7] { "0", "0", "0", "1", "d2da4095-619b-4bc3-af10-b6e7caa7b490", "100", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureAdvancedBranch(3, "", 5, 4, 150, new int[2] { 4, 100 }, new int[9] { 1, 7, 22, 100, 0, 0, 0, 100, 0 }, new int[5] { 10, 10, 10, 0, 10 }, new string[7] { "0", "0", "0", "1", "d2da4095-619b-4bc3-af10-b6e7caa7b490", "100", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureAdvancedBranch(3, "", 6, 4, 150, new int[2] { 4, 100 }, new int[9] { 1, 7, 22, 100, 0, 0, 0, 100, 0 }, new int[5] { 10, 10, 10, 0, 10 }, new string[7] { "0", "0", "0", "1", "d2da4095-619b-4bc3-af10-b6e7caa7b490", "100", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray38 = _dataArray;
		string config75 = LocalStringManager.GetConfig("Adventure_language", "Name_97");
		string config76 = LocalStringManager.GetConfig("Adventure_language", "Desc_97");
		int[] resCost38 = new int[9] { 0, 0, 0, 0, 0, 0, 0, 500, 0 };
		list = new List<int[]>();
		dataArray38.Add(new AdventureItem(97, config75, config76, 7, 5, 5, 1, 5, 6, resCost38, list, restrictedByWorldPopulation: false, new short[3], new List<(string, string, string, string)>
		{
			("flowerPerceptive", "LK_Adventure_97_ParamName_0", "", ""),
			("flowerFirm", "LK_Adventure_97_ParamName_1", "", ""),
			("flowerEnthusiastic", "LK_Adventure_97_ParamName_2", "", ""),
			("flowerClever", "LK_Adventure_97_ParamName_3", "", ""),
			("flowerBrave", "LK_Adventure_97_ParamName_4", "", ""),
			("flowerCalm", "LK_Adventure_97_ParamName_5", "", ""),
			("flowerLucky", "LK_Adventure_97_ParamName_6", "", "")
		}, "6cfaccc1-6614-422f-8cce-043ce8601808", new List<AdventureStartNode>
		{
			new AdventureStartNode("fec6e30e-ec7e-4b1c-9121-f10f421bcf79", "A", "LK_Adventure_NodeTitle_334", 9)
		}, new List<AdventureTransferNode>
		{
			new AdventureTransferNode("94f459f6-b036-4695-8ab0-ec6bfcc90171", "B", "LK_Adventure_NodeTitle_335", 10)
		}, new List<AdventureEndNode>
		{
			new AdventureEndNode("48b7a7f9-d38c-4355-8eac-c731408cb923", "C", "LK_Adventure_NodeTitle_336", 9)
		}, new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 7, "", new int[4] { 3, 50, 15, 50 }, new int[57]
			{
				7, 7, 9, 35, 20, 20, 20, 20, 20, 7,
				7, 5, 20, 20, 20, 20, 20, 7, 8, 5,
				20, 20, 20, 20, 20, 7, 13, 10, 20, 20,
				20, 20, 20, 7, 11, 5, 20, 20, 20, 20,
				20, 7, 12, 5, 20, 20, 20, 20, 20, 7,
				10, 35, 20, 20, 20, 20, 20
			}, new int[5] { 40, 40, 30, 30, 30 }, new string[15]
			{
				"1", "ac764d9f-c4d9-4626-85fb-9387a9f0e529", "30", "1", "440cb0ed-6722-4f3e-9372-9dc94cdf26bb", "30", "1", "7a21d154-fd1c-4038-b03b-81ca8fa2864c", "30", "1",
				"6544b2b8-d346-46be-b110-69c1b2f33f83", "30", "1", "b86ffa4c-6823-4680-a046-9e64eccd6eb7", "30"
			}, new int[23]
			{
				3, 1, 120, 5, 1, 180, 3, 1, 240, 2,
				3, 8, 300, 5, 8, 450, 3, 8, 600, 2,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 1, 8, "", new int[4] { 3, 50, 15, 50 }, new int[57]
			{
				7, 7, 9, 35, 10, 10, 10, 60, 10, 7,
				7, 5, 10, 10, 10, 60, 10, 7, 8, 5,
				10, 10, 10, 60, 10, 7, 13, 10, 10, 10,
				10, 60, 10, 7, 11, 5, 10, 10, 10, 60,
				10, 7, 12, 5, 10, 10, 10, 60, 10, 7,
				10, 35, 10, 10, 10, 60, 10
			}, new int[5] { 0, 0, 10, 20, 10 }, new string[9] { "0", "0", "0", "2", "e4bd2d09-385e-4ab9-a17b-02554c7719a4", "10", "17abd5f3-3047-4207-a1a3-cbb8840b2671", "40", "0" }, new int[23]
			{
				3, 1, 120, 50, 1, 180, 30, 1, 240, 20,
				3, 8, 300, 50, 8, 450, 30, 8, 600, 20,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, new List<AdventureAdvancedBranch>
		{
			new AdventureAdvancedBranch(2, "", 1, 3, 150, new int[2] { 3, 100 }, new int[9] { 1, 7, 10, 100, 0, 0, 100, 0, 0 }, new int[5] { 10, 10, 0, 10, 10 }, new string[7] { "0", "0", "1", "0113fe32-3fac-491c-b947-fce626e01950", "100", "0", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray39 = _dataArray;
		string config77 = LocalStringManager.GetConfig("Adventure_language", "Name_98");
		string config78 = LocalStringManager.GetConfig("Adventure_language", "Desc_98");
		int[] resCost39 = new int[9];
		list = new List<int[]>();
		dataArray39.Add(new AdventureItem(98, config77, config78, 7, 5, 5, 1, 5, 6, resCost39, list, restrictedByWorldPopulation: false, new short[3], new List<(string, string, string, string)>
		{
			("singJust", "LK_Adventure_98_ParamName_0", "", ""),
			("singKind", "LK_Adventure_98_ParamName_1", "", ""),
			("singEven", "LK_Adventure_98_ParamName_2", "", ""),
			("singRebel", "LK_Adventure_98_ParamName_3", "", ""),
			("singEgoistic", "LK_Adventure_98_ParamName_4", "", "")
		}, "058f3497-24e2-49cd-a266-923b58aed1ff", new List<AdventureStartNode>
		{
			new AdventureStartNode("af7cb5b6-104b-4aa9-8ad7-521e5ac77fbd", "A", "LK_Adventure_NodeTitle_342", 2)
		}, new List<AdventureTransferNode>
		{
			new AdventureTransferNode("1a068dd7-c11e-4f06-93c6-0746046dda84", "B", "LK_Adventure_NodeTitle_343", 1)
		}, new List<AdventureEndNode>
		{
			new AdventureEndNode("439935f0-f5fa-4a90-81d3-eb868a54181d", "C", "LK_Adventure_NodeTitle_344", 1)
		}, new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 2, 7, "", new int[4] { 0, 50, 7, 50 }, new int[57]
			{
				7, 7, 12, 35, 10, 10, 35, 35, 10, 7,
				10, 15, 10, 10, 35, 35, 10, 7, 11, 15,
				10, 10, 35, 35, 10, 7, 17, 15, 10, 10,
				35, 35, 10, 7, 1, 10, 10, 10, 35, 35,
				10, 7, 2, 5, 10, 10, 35, 35, 10, 7,
				16, 5, 10, 10, 35, 35, 10
			}, new int[5] { 10, 0, 10, 10, 10 }, new string[11]
			{
				"0", "0", "2", "ad543c9a-12ce-4623-bb44-adc421d09abb", "15", "4673c876-bd7c-45b1-9072-53629c3c2e0f", "15", "1", "eaeac6d8-c0fe-4a96-af42-3cc98ad48e7a", "30",
				"0"
			}, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[9] { 0, 0, 1, 5, -502, 1, 10, 0, 0 }, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "1", 2, 8, "", new int[4] { 0, 50, 7, 50 }, new int[57]
			{
				7, 7, 12, 35, 10, 10, 35, 35, 10, 7,
				10, 15, 10, 10, 35, 35, 10, 7, 11, 15,
				10, 10, 35, 35, 10, 7, 17, 15, 10, 10,
				35, 35, 10, 7, 1, 10, 10, 10, 35, 35,
				10, 7, 2, 5, 10, 10, 35, 35, 10, 7,
				16, 5, 10, 10, 35, 35, 10
			}, new int[5] { 10, 0, 10, 10, 10 }, new string[11]
			{
				"0", "0", "2", "ad543c9a-12ce-4623-bb44-adc421d09abb", "15", "4673c876-bd7c-45b1-9072-53629c3c2e0f", "15", "1", "eaeac6d8-c0fe-4a96-af42-3cc98ad48e7a", "30",
				"0"
			}, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[9] { 0, 0, 1, 5, -502, 1, 10, 0, 0 }, new string[5] { "0", "0", "0", "0", "0" })
		}, new List<AdventureAdvancedBranch>
		{
			new AdventureAdvancedBranch(1, "", 1, 7, 150, new int[2] { 7, 100 }, new int[9] { 1, 7, 1, 100, 100, 0, 0, 0, 0 }, new int[5] { 0, 10, 10, 10, 10 }, new string[7] { "1", "4008cb1b-0b23-4d20-9683-62dea610961c", "100", "0", "0", "0", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray40 = _dataArray;
		string config79 = LocalStringManager.GetConfig("Adventure_language", "Name_99");
		string config80 = LocalStringManager.GetConfig("Adventure_language", "Desc_99");
		int[] resCost40 = new int[9] { 0, 0, 0, 0, 0, 0, 0, 500, 0 };
		list = new List<int[]>();
		dataArray40.Add(new AdventureItem(99, config79, config80, 7, 5, 5, 1, 5, 6, resCost40, list, restrictedByWorldPopulation: false, new short[3], new List<(string, string, string, string)>
		{
			("lightApperance", "LK_Adventure_99_ParamName_0", "", ""),
			("heal", "LK_Adventure_99_ParamName_1", "", "")
		}, "93d84727-5708-4690-8f45-d700cf314ee1", new List<AdventureStartNode>
		{
			new AdventureStartNode("599fd71a-e88a-4676-b3cf-ec86eb683ed2", "A", "", 5)
		}, new List<AdventureTransferNode>
		{
			new AdventureTransferNode("2666cf86-6b18-4e09-b8b1-e37ffa3d5b7c", "B", "LK_Adventure_NodeTitle_347", 10)
		}, new List<AdventureEndNode>
		{
			new AdventureEndNode("d5e5b9ae-921c-49a3-9c2f-dc8e7274ce08", "C", "LK_Adventure_NodeTitle_348", 5)
		}, new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 2, 7, "", new int[4] { 3, 50, 2, 50 }, new int[57]
			{
				7, 7, 4, 15, 10, 10, 10, 60, 10, 7,
				5, 35, 10, 10, 10, 60, 10, 7, 6, 10,
				10, 10, 10, 60, 10, 7, 1, 10, 10, 10,
				10, 60, 10, 7, 3, 5, 10, 10, 10, 60,
				10, 7, 11, 10, 10, 10, 10, 60, 10, 7,
				12, 15, 10, 10, 10, 60, 10
			}, new int[5] { 10, 0, 5, 20, 10 }, new string[7] { "0", "0", "0", "1", "cbd556cc-d6dc-4100-a44b-aac102779a37", "50", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[9] { 0, 0, 1, 9, -901, 1, 10, 0, 0 }, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "1", 2, 8, "", new int[4] { 3, 50, 2, 50 }, new int[57]
			{
				7, 7, 4, 15, 10, 10, 10, 60, 10, 7,
				5, 35, 10, 10, 10, 60, 10, 7, 6, 10,
				10, 10, 10, 60, 10, 7, 1, 10, 10, 10,
				10, 60, 10, 7, 3, 5, 10, 10, 10, 60,
				10, 7, 11, 10, 10, 10, 10, 60, 10, 7,
				12, 15, 10, 10, 10, 60, 10
			}, new int[5] { 10, 0, 5, 20, 10 }, new string[7] { "0", "0", "0", "1", "cbd556cc-d6dc-4100-a44b-aac102779a37", "50", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[9] { 0, 0, 1, 9, -901, 1, 10, 0, 0 }, new string[5] { "0", "0", "0", "0", "0" })
		}, new List<AdventureAdvancedBranch>
		{
			new AdventureAdvancedBranch(4, "", 1, 2, 150, new int[2] { 2, 100 }, new int[9] { 1, 7, 5, 100, 0, 100, 0, 0, 0 }, new int[5] { 10, 0, 0, 0, 0 }, new string[5] { "0", "0", "0", "0", "0" }, new int[14]
			{
				0, 0, 1, 0, 1, 1, 1, 0, 1, 1,
				1, 0, 1, 1
			}, new int[5], new string[7] { "0", "1", "bc151e17-994f-4efd-a912-43ab6c2ecd6b", "100", "0", "0", "0" })
		}, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray41 = _dataArray;
		string config81 = LocalStringManager.GetConfig("Adventure_language", "Name_100");
		string config82 = LocalStringManager.GetConfig("Adventure_language", "Desc_100");
		int[] resCost41 = new int[9] { 0, 0, 0, 0, 0, 0, 0, 500, 0 };
		list = new List<int[]>();
		List<int[]> itemCost28 = list;
		short[] malice28 = new short[3];
		adventureParams = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams22 = adventureParams;
		List<AdventureStartNode> startNodes21 = new List<AdventureStartNode>
		{
			new AdventureStartNode("2cc3ae03-82c2-4a88-b628-ac62ae533dce", "0", "LK_Adventure_NodeTitle_349", 9)
		};
		transferNodes = new List<AdventureTransferNode>();
		dataArray41.Add(new AdventureItem(100, config81, config82, 7, 5, 5, 1, 5, 6, resCost41, itemCost28, restrictedByWorldPopulation: false, malice28, adventureParams22, "563d4eb4-54e2-4cd9-a0d0-fdd4d618f378", startNodes21, transferNodes, new List<AdventureEndNode>
		{
			new AdventureEndNode("87a94e52-acb9-4399-9759-fe85cdf37c46", "A", "LK_Adventure_NodeTitle_350", 10)
		}, new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "A", 1, 15, "", new int[4] { 5, 50, 1, 50 }, new int[49]
			{
				6, 7, 10, 40, 5, 40, 10, 40, 5, 7,
				12, 30, 5, 40, 5, 40, 10, 7, 5, 10,
				10, 40, 5, 40, 5, 7, 8, 10, 5, 40,
				10, 40, 5, 7, 9, 5, 5, 40, 10, 40,
				5, 7, 1, 5, 5, 40, 5, 40, 10
			}, new int[5] { 0, 25, 10, 30, 10 }, new string[9] { "0", "1", "ec8b5592-5dbb-4396-b7c0-27a1b229c29e", "30", "0", "1", "023a3399-4376-4562-876a-a5d70733c0e1", "40", "0" }, new int[23]
			{
				3, 4, 120, 50, 4, 180, 30, 4, 240, 20,
				3, 8, 300, 5, 8, 450, 3, 8, 600, 2,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, new List<AdventureAdvancedBranch>
		{
			new AdventureAdvancedBranch(1, "", 0, 5, 150, new int[2] { 5, 100 }, new int[9] { 1, 7, 9, 100, 0, 100, 0, 0, 0 }, new int[5] { 10, 0, 10, 10, 10 }, new string[7] { "0", "1", "1d3e480d-2a91-4744-9b6e-787b46f3c9a7", "100", "0", "0", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray42 = _dataArray;
		string config83 = LocalStringManager.GetConfig("Adventure_language", "Name_101");
		string config84 = LocalStringManager.GetConfig("Adventure_language", "Desc_101");
		int[] resCost42 = new int[9] { 0, 0, 0, 0, 0, 0, 0, 500, 0 };
		list = new List<int[]>();
		List<int[]> itemCost29 = list;
		short[] malice29 = new short[3];
		adventureParams = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams23 = adventureParams;
		List<AdventureStartNode> startNodes22 = new List<AdventureStartNode>
		{
			new AdventureStartNode("d944505d-10b5-450f-a7c1-a854caa17949", "0", "LK_Adventure_NodeTitle_351", 9)
		};
		transferNodes = new List<AdventureTransferNode>();
		dataArray42.Add(new AdventureItem(101, config83, config84, 7, 5, 5, 1, 5, 6, resCost42, itemCost29, restrictedByWorldPopulation: false, malice29, adventureParams23, "744a2e31-5e11-46d1-b5d3-03d08977b649", startNodes22, transferNodes, new List<AdventureEndNode>
		{
			new AdventureEndNode("21230132-ae45-4f9e-8ab9-8dbb088c4367", "A", "LK_Adventure_NodeTitle_352", 9)
		}, new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 15, "", new int[4] { 5, 50, 6, 50 }, new int[57]
			{
				7, 7, 9, 45, 40, 10, 10, 40, 5, 7,
				7, 5, 40, 10, 10, 40, 5, 7, 8, 10,
				40, 10, 10, 40, 5, 7, 13, 10, 40, 10,
				5, 40, 10, 7, 14, 5, 40, 10, 5, 40,
				5, 7, 15, 5, 40, 10, 5, 40, 5, 7,
				12, 20, 40, 10, 5, 40, 5
			}, new int[5] { 20, 5, 5, 30, 10 }, new string[19]
			{
				"6", "1d827dd1-86b9-4e3d-921e-4bd7a9675649", "5", "0d7569f4-d6b5-4bcc-9618-7f7c54e1da43", "5", "47512d30-7719-4e76-94a3-db79f8c889b7", "5", "d194850c-4743-44c0-9120-6f530286ba49", "5", "62d45065-3b42-48f8-b495-60cba3eb3b66",
				"5", "5d9f12f2-5155-4fa5-b96e-f8aa0be9e599", "5", "0", "0", "1", "29687be8-4eb9-40a9-98cd-35b6a4a78ca5", "40", "0"
			}, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[9] { 0, 0, 1, 5, -503, 1, 10, 0, 0 }, new string[5] { "0", "0", "0", "0", "0" })
		}, new List<AdventureAdvancedBranch>
		{
			new AdventureAdvancedBranch(2, "", 0, 6, 150, new int[2] { 5, 100 }, new int[9] { 1, 7, 10, 100, 0, 0, 0, 0, 100 }, new int[5] { 10, 10, 10, 10, 0 }, new string[5] { "0", "0", "0", "0", "0" }, new int[5], new int[5], new string[7] { "0", "0", "0", "0", "1", "9298c0a7-34c4-4817-a9a9-d0f50059cf1d", "100" })
		}, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray43 = _dataArray;
		string config85 = LocalStringManager.GetConfig("Adventure_language", "Name_102");
		string config86 = LocalStringManager.GetConfig("Adventure_language", "Desc_102");
		int[] resCost43 = new int[9] { 0, 0, 0, 0, 0, 0, 0, 500, 0 };
		list = new List<int[]>();
		dataArray43.Add(new AdventureItem(102, config85, config86, 7, 5, 5, 1, 5, 6, resCost43, list, restrictedByWorldPopulation: false, new short[3], new List<(string, string, string, string)> { ("distance", "LK_Adventure_102_ParamName_0", "", "") }, "bb02c993-57ea-4cbc-a6ea-0f2ec3044b1f", new List<AdventureStartNode>
		{
			new AdventureStartNode("7183650b-056a-4dc7-b980-bf3afbe9a094", "A", "LK_Adventure_NodeTitle_354", 12)
		}, new List<AdventureTransferNode>
		{
			new AdventureTransferNode("1d9f83ea-b305-4187-8c13-bdf409d1423b", "B", "LK_Adventure_NodeTitle_355", 17)
		}, new List<AdventureEndNode>
		{
			new AdventureEndNode("090c5199-03f5-4c7f-8eb5-0231b7f3abe5", "C", "LK_Adventure_NodeTitle_356", 10)
		}, new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 2, 8, "97ae8434-b8bf-4170-9cb5-aa1eb6afb23e", new int[4] { 15, 80, 4, 20 }, new int[57]
			{
				7, 7, 12, 35, 0, 10, 20, 60, 10, 7,
				10, 15, 10, 10, 20, 60, 0, 7, 11, 15,
				0, 10, 20, 60, 10, 7, 17, 15, 10, 0,
				20, 60, 10, 7, 1, 10, 10, 0, 20, 60,
				10, 7, 13, 5, 10, 10, 20, 60, 0, 7,
				16, 5, 10, 10, 20, 60, 0
			}, new int[5] { 10, 0, 15, 20, 0 }, new string[9] { "0", "0", "1", "ee1b2284-e2a1-4992-9360-26003618da8e", "30", "1", "1a7de9c1-c6ea-4cca-b4e8-b86275fa5b6c", "30", "0" }, new int[23]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 3, 5, 120, 50, 5, 180, 30,
				5, 240, 20
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "1", 2, 7, "97ae8434-b8bf-4170-9cb5-aa1eb6afb23e", new int[4] { 15, 80, 4, 20 }, new int[57]
			{
				7, 7, 12, 35, 0, 10, 20, 60, 10, 7,
				10, 15, 10, 10, 20, 60, 0, 7, 11, 15,
				0, 10, 20, 60, 10, 7, 17, 15, 10, 0,
				20, 60, 10, 7, 1, 10, 10, 0, 20, 60,
				10, 7, 13, 5, 10, 10, 20, 60, 0, 7,
				16, 5, 10, 10, 20, 60, 0
			}, new int[5] { 10, 5, 15, 20, 0 }, new string[9] { "0", "0", "1", "ee1b2284-e2a1-4992-9360-26003618da8e", "30", "1", "1a7de9c1-c6ea-4cca-b4e8-b86275fa5b6c", "30", "0" }, new int[23]
			{
				0, 3, 8, 300, 5, 8, 450, 3, 8, 600,
				2, 0, 0, 3, 5, 120, 5, 5, 180, 3,
				5, 240, 2
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, new List<AdventureAdvancedBranch>
		{
			new AdventureAdvancedBranch(3, "", 0, 15, 150, new int[2] { 15, 100 }, new int[9] { 1, 7, 12, 100, 100, 0, 0, 0, 0 }, new int[5] { 0, 100, 100, 100, 100 }, new string[5] { "0", "0", "0", "0", "0" }, new int[5], new int[5], new string[7] { "1", "ad66c9a4-4392-4e74-8d5a-b3b9d349dce1", "100", "0", "0", "0", "0" })
		}, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray44 = _dataArray;
		string config87 = LocalStringManager.GetConfig("Adventure_language", "Name_103");
		string config88 = LocalStringManager.GetConfig("Adventure_language", "Desc_103");
		int[] resCost44 = new int[9] { 0, 0, 0, 0, 0, 0, 0, 500, 0 };
		list = new List<int[]>();
		dataArray44.Add(new AdventureItem(103, config87, config88, 7, 5, 5, 1, 5, 6, resCost44, list, restrictedByWorldPopulation: false, new short[3], new List<(string, string, string, string)>
		{
			("water", "LK_Adventure_103_ParamName_0", "", ""),
			("debuff", "LK_Adventure_103_ParamName_1", "", "")
		}, "f45af644-2349-432d-b5f2-4b7c61e34d29", new List<AdventureStartNode>
		{
			new AdventureStartNode("ed953a15-4e83-42f5-88b8-4635c8bcd621", "0", "LK_Adventure_NodeTitle_359", 9)
		}, new List<AdventureTransferNode>
		{
			new AdventureTransferNode("29dbf0ba-40d1-4c84-8c01-97f4291a3783", "A", "LK_Adventure_NodeTitle_360", 19),
			new AdventureTransferNode("4273eec5-d04f-4db9-860f-c945349ccbab", "B", "LK_Adventure_NodeTitle_361", 19)
		}, new List<AdventureEndNode>
		{
			new AdventureEndNode("a71c2427-9c44-4132-91b9-0fe39456e7e1", "C", "LK_Adventure_NodeTitle_362", 19)
		}, new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 5, "", new int[4] { 4, 50, 15, 50 }, new int[49]
			{
				6, 7, 17, 10, 10, 5, 15, 35, 35, 7,
				1, 5, 10, 5, 15, 35, 35, 7, 18, 10,
				10, 5, 15, 35, 35, 7, 19, 60, 10, 5,
				15, 35, 35, 7, 8, 5, 10, 5, 15, 35,
				35, 7, 9, 5, 10, 5, 15, 35, 35
			}, new int[5] { 0, 0, 10, 10, 10 }, new string[15]
			{
				"0", "0", "0", "4", "81ca8727-e1a1-4a20-98c3-058fcaf8207f", "5", "5c2a4791-fda4-43df-805d-d7f40ff95ec2", "5", "23154819-5534-4b9d-a084-6639c8e6fe47", "5",
				"597b35b0-c1e7-4e3f-a5ab-bd83a37fe405", "25", "1", "b2ca094c-8955-420c-848b-5b173221a07e", "30"
			}, new int[23]
			{
				3, 3, 120, 50, 3, 180, 30, 3, 240, 20,
				3, 8, 300, 50, 8, 450, 30, 8, 600, 20,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "1", 1, 5, "", new int[4] { 4, 50, 15, 50 }, new int[49]
			{
				6, 7, 17, 10, 10, 5, 15, 35, 35, 7,
				1, 5, 10, 5, 15, 35, 35, 7, 18, 10,
				10, 5, 15, 35, 35, 7, 19, 60, 10, 5,
				15, 35, 35, 7, 8, 5, 10, 5, 15, 35,
				35, 7, 9, 5, 10, 5, 15, 35, 35
			}, new int[5] { 0, 0, 10, 10, 10 }, new string[15]
			{
				"0", "0", "0", "4", "81ca8727-e1a1-4a20-98c3-058fcaf8207f", "5", "5c2a4791-fda4-43df-805d-d7f40ff95ec2", "5", "23154819-5534-4b9d-a084-6639c8e6fe47", "5",
				"597b35b0-c1e7-4e3f-a5ab-bd83a37fe405", "25", "1", "b2ca094c-8955-420c-848b-5b173221a07e", "30"
			}, new int[23]
			{
				3, 3, 120, 50, 3, 180, 30, 3, 240, 20,
				3, 8, 300, 50, 8, 450, 30, 8, 600, 20,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 3, "1", 1, 5, "", new int[4] { 4, 50, 15, 50 }, new int[49]
			{
				6, 7, 17, 10, 10, 5, 15, 35, 35, 7,
				1, 5, 10, 5, 15, 35, 35, 7, 18, 10,
				10, 5, 15, 35, 35, 7, 19, 60, 10, 5,
				15, 35, 35, 7, 8, 5, 10, 5, 15, 35,
				35, 7, 9, 5, 10, 5, 15, 35, 35
			}, new int[5] { 0, 0, 10, 10, 10 }, new string[15]
			{
				"0", "0", "0", "4", "81ca8727-e1a1-4a20-98c3-058fcaf8207f", "5", "5c2a4791-fda4-43df-805d-d7f40ff95ec2", "5", "23154819-5534-4b9d-a084-6639c8e6fe47", "5",
				"597b35b0-c1e7-4e3f-a5ab-bd83a37fe405", "25", "1", "b2ca094c-8955-420c-848b-5b173221a07e", "30"
			}, new int[23]
			{
				3, 3, 120, 50, 3, 180, 30, 3, 240, 20,
				3, 8, 300, 50, 8, 450, 30, 8, 600, 20,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, new List<AdventureAdvancedBranch>
		{
			new AdventureAdvancedBranch(1, "", 0, 4, 150, new int[2] { 4, 100 }, new int[9] { 1, 7, 12, 100, 0, 0, 0, 0, 100 }, new int[5] { 10, 10, 10, 10, 0 }, new string[7] { "0", "0", "0", "0", "1", "c3405fe7-d0f2-4887-b1b6-8b816b778f3c", "100" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureAdvancedBranch(1, "", 1, 4, 150, new int[2] { 4, 100 }, new int[9] { 1, 7, 12, 100, 0, 0, 0, 0, 100 }, new int[5] { 10, 10, 10, 10, 0 }, new string[7] { "0", "0", "0", "0", "1", "c3405fe7-d0f2-4887-b1b6-8b816b778f3c", "100" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureAdvancedBranch(1, "", 2, 4, 150, new int[2] { 4, 100 }, new int[9] { 1, 7, 12, 100, 0, 0, 0, 0, 100 }, new int[5] { 10, 10, 10, 10, 0 }, new string[7] { "0", "0", "0", "0", "1", "c3405fe7-d0f2-4887-b1b6-8b816b778f3c", "100" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray45 = _dataArray;
		string config89 = LocalStringManager.GetConfig("Adventure_language", "Name_104");
		string config90 = LocalStringManager.GetConfig("Adventure_language", "Desc_104");
		int[] resCost45 = new int[9] { 0, 0, 0, 0, 0, 0, 0, 500, 0 };
		list = new List<int[]>();
		dataArray45.Add(new AdventureItem(104, config89, config90, 7, 5, 5, 1, 5, 6, resCost45, list, restrictedByWorldPopulation: false, new short[3], new List<(string, string, string, string)> { ("line", "LK_Adventure_104_ParamName_0", "", "") }, "1e39462f-0c68-43ec-82c4-c0d9c8f12191", new List<AdventureStartNode>
		{
			new AdventureStartNode("9b6ba5cd-662b-4f61-a37d-a8d4671430ec", "A", "LK_Adventure_NodeTitle_364", 9)
		}, new List<AdventureTransferNode>
		{
			new AdventureTransferNode("6f4830d8-74ad-42fe-90e6-290e3ddb5839", "B", "LK_Adventure_NodeTitle_365", 9),
			new AdventureTransferNode("bbe9c4e1-88f8-4c6b-802a-7fbbbcac15f5", "C", "LK_Adventure_NodeTitle_366", 9),
			new AdventureTransferNode("fc3723d2-11d1-4742-8588-e7049fca274e", "D", "LK_Adventure_NodeTitle_366", 9),
			new AdventureTransferNode("b2665bec-db87-4ba6-a1a4-7d72e6befb5b", "E", "LK_Adventure_NodeTitle_366", 9)
		}, new List<AdventureEndNode>
		{
			new AdventureEndNode("8be6bcbb-4f18-4c32-8c3e-74ef2c04055e", "F", "LK_Adventure_NodeTitle_367", 9)
		}, new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(2, 5, "5", 1, 6, "", new int[4] { 10, 50, 4, 50 }, new int[57]
			{
				7, 7, 9, 35, 10, 5, 40, 40, 5, 7,
				7, 5, 5, 5, 40, 40, 10, 7, 8, 10,
				5, 5, 40, 40, 10, 7, 13, 10, 5, 5,
				40, 40, 10, 7, 14, 10, 5, 5, 40, 40,
				10, 7, 15, 10, 5, 5, 40, 40, 10, 7,
				10, 20, 5, 5, 40, 40, 10
			}, new int[5] { 10, 0, 20, 15, 10 }, new string[11]
			{
				"0", "0", "1", "426ffcd4-e68c-4762-b8dc-fe39d4afca6e", "30", "2", "161b4ef1-49eb-4c90-9a4c-bdc66a4be57a", "15", "5226a575-6d73-446d-8010-abe0adb0da1f", "15",
				"0"
			}, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[9] { 0, 0, 1, 5, -505, 1, 10, 0, 0 }, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 5, "6", 1, 6, "", new int[4] { 10, 50, 4, 50 }, new int[57]
			{
				7, 7, 9, 35, 10, 5, 40, 40, 5, 7,
				7, 5, 5, 5, 40, 40, 10, 7, 8, 10,
				5, 5, 40, 40, 10, 7, 13, 10, 5, 5,
				40, 40, 10, 7, 14, 10, 5, 5, 40, 40,
				10, 7, 15, 10, 5, 5, 40, 40, 10, 7,
				10, 20, 5, 5, 40, 40, 10
			}, new int[5] { 10, 0, 20, 15, 10 }, new string[11]
			{
				"0", "0", "1", "426ffcd4-e68c-4762-b8dc-fe39d4afca6e", "30", "2", "161b4ef1-49eb-4c90-9a4c-bdc66a4be57a", "15", "5226a575-6d73-446d-8010-abe0adb0da1f", "15",
				"0"
			}, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[9] { 0, 0, 1, 5, -505, 1, 10, 0, 0 }, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(4, 5, "7", 1, 6, "", new int[4] { 10, 50, 4, 50 }, new int[57]
			{
				7, 7, 9, 35, 10, 5, 40, 40, 5, 7,
				7, 5, 5, 5, 40, 40, 10, 7, 8, 10,
				5, 5, 40, 40, 10, 7, 13, 10, 5, 5,
				40, 40, 10, 7, 14, 10, 5, 5, 40, 40,
				10, 7, 15, 10, 5, 5, 40, 40, 10, 7,
				10, 20, 5, 5, 40, 40, 10
			}, new int[5] { 10, 0, 20, 15, 10 }, new string[11]
			{
				"0", "0", "1", "426ffcd4-e68c-4762-b8dc-fe39d4afca6e", "30", "2", "161b4ef1-49eb-4c90-9a4c-bdc66a4be57a", "15", "5226a575-6d73-446d-8010-abe0adb0da1f", "15",
				"0"
			}, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[9] { 0, 0, 1, 5, -505, 1, 10, 0, 0 }, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(0, 1, "1", 1, 3, "", new int[4] { 10, 50, 4, 50 }, new int[57]
			{
				7, 7, 9, 35, 5, 3, 5, 3, 3, 7,
				7, 5, 5, 3, 5, 3, 3, 7, 8, 10,
				5, 3, 5, 3, 3, 7, 13, 10, 5, 3,
				5, 3, 3, 7, 14, 10, 5, 3, 5, 3,
				3, 7, 15, 10, 5, 3, 5, 3, 3, 7,
				10, 20, 5, 3, 5, 3, 3
			}, new int[5] { 20, 20, 20, 20, 20 }, new string[19]
			{
				"2", "288eb46e-6e65-4d23-b820-81752de21778", "10", "85b6bd5f-dc64-41a5-8cac-cc4f81ec1b40", "10", "1", "82316a09-1493-4639-9d4c-5b87d7405b5e", "20", "2", "e39ddf03-b60a-429e-ab57-e4da1cd40a99",
				"10", "156a6553-cda2-497d-886f-ad49c80fe523", "10", "1", "eaee03bf-e0d1-4304-bb43-9087152abf0c", "20", "1", "a509e4d3-115e-4d6c-9cbe-c95c7892e1e9", "20"
			}, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 1, 6, "", new int[4] { 10, 50, 4, 50 }, new int[57]
			{
				7, 7, 9, 35, 10, 10, 10, 60, 10, 7,
				7, 5, 10, 10, 10, 60, 10, 7, 8, 10,
				10, 10, 10, 60, 10, 7, 13, 10, 10, 10,
				10, 60, 10, 7, 14, 10, 10, 10, 10, 60,
				10, 7, 15, 10, 10, 10, 10, 60, 10, 7,
				10, 20, 10, 10, 10, 60, 10
			}, new int[5] { 10, 0, 5, 20, 20 }, new string[7] { "0", "0", "0", "1", "c85fd5e4-62f2-40ac-99fd-ca39d5feff9d", "40", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[9] { 0, 0, 1, 5, -505, 1, 10, 0, 0 }, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 4, "4", 1, 6, "", new int[4] { 10, 50, 4, 50 }, new int[57]
			{
				7, 7, 9, 35, 10, 10, 10, 60, 10, 7,
				7, 5, 10, 10, 10, 60, 10, 7, 8, 10,
				10, 10, 10, 60, 10, 7, 13, 10, 10, 10,
				10, 60, 10, 7, 14, 10, 10, 10, 10, 60,
				10, 7, 15, 10, 10, 10, 10, 60, 10, 7,
				10, 20, 10, 10, 10, 60, 10
			}, new int[5] { 10, 0, 5, 40, 20 }, new string[7] { "0", "0", "0", "1", "5a11ed74-5ed5-4c60-92f6-ae9896a76957", "40", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[9] { 0, 0, 1, 5, -505, 1, 10, 0, 0 }, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 3, "3", 1, 6, "", new int[4] { 10, 50, 4, 50 }, new int[57]
			{
				7, 7, 9, 35, 10, 10, 10, 60, 10, 7,
				7, 5, 10, 10, 10, 60, 10, 7, 8, 10,
				10, 10, 10, 60, 10, 7, 13, 10, 10, 10,
				10, 60, 10, 7, 14, 10, 10, 10, 10, 60,
				10, 7, 15, 10, 10, 10, 10, 60, 10, 7,
				10, 20, 10, 10, 10, 60, 10
			}, new int[5] { 10, 0, 5, 30, 20 }, new string[7] { "0", "0", "0", "1", "c83ab856-3994-49df-8235-bc4c9bbf5fca", "40", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[9] { 0, 0, 1, 5, -505, 1, 10, 0, 0 }, new string[5] { "0", "0", "0", "0", "0" })
		}, new List<AdventureAdvancedBranch>
		{
			new AdventureAdvancedBranch(3, "", 0, 10, 150, new int[2] { 10, 100 }, new int[9] { 1, 7, 9, 100, 0, 0, 100, 0, 0 }, new int[5] { 10, 10, 0, 10, 10 }, new string[7] { "0", "0", "1", "e90db51b-2812-4c39-ba86-5827f8718e1e", "100", "0", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureAdvancedBranch(3, "", 1, 10, 150, new int[2] { 10, 100 }, new int[9] { 1, 7, 9, 100, 0, 0, 100, 0, 0 }, new int[5] { 10, 10, 0, 10, 10 }, new string[7] { "0", "0", "1", "e90db51b-2812-4c39-ba86-5827f8718e1e", "100", "0", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureAdvancedBranch(3, "", 2, 10, 150, new int[2] { 10, 100 }, new int[9] { 1, 7, 9, 100, 0, 0, 100, 0, 0 }, new int[5] { 10, 10, 0, 10, 10 }, new string[7] { "0", "0", "1", "e90db51b-2812-4c39-ba86-5827f8718e1e", "100", "0", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray46 = _dataArray;
		string config91 = LocalStringManager.GetConfig("Adventure_language", "Name_105");
		string config92 = LocalStringManager.GetConfig("Adventure_language", "Desc_105");
		int[] resCost46 = new int[9] { 0, 0, 0, 0, 0, 0, 0, 500, 0 };
		list = new List<int[]>();
		dataArray46.Add(new AdventureItem(105, config91, config92, 7, 5, 5, 1, 5, 6, resCost46, list, restrictedByWorldPopulation: false, new short[3], new List<(string, string, string, string)>
		{
			("zoon1", "LK_Adventure_105_ParamName_0", "", ""),
			("zoon2", "LK_Adventure_105_ParamName_1", "", ""),
			("zoon3", "LK_Adventure_105_ParamName_2", "", ""),
			("zoon4", "LK_Adventure_105_ParamName_3", "", ""),
			("zoon5", "LK_Adventure_105_ParamName_4", "", ""),
			("zoon6", "LK_Adventure_105_ParamName_5", "", ""),
			("zoon7", "LK_Adventure_105_ParamName_6", "", ""),
			("zoon8", "LK_Adventure_105_ParamName_7", "", ""),
			("zoon9", "LK_Adventure_105_ParamName_8", "", "")
		}, "74f69266-2921-47ff-abd6-f51169cd2d3e", new List<AdventureStartNode>
		{
			new AdventureStartNode("137191a0-7a53-4ce3-9285-cd73c10233d0", "A", "LK_Adventure_NodeTitle_377", 5)
		}, new List<AdventureTransferNode>
		{
			new AdventureTransferNode("1944330b-a810-4b4b-a56e-b111b3eeb37b", "B", "LK_Adventure_NodeTitle_378", 11)
		}, new List<AdventureEndNode>
		{
			new AdventureEndNode("9e2136b6-7400-4310-ab5a-c3a51a9aadb2", "C", "LK_Adventure_NodeTitle_379", 5),
			new AdventureEndNode("9e2136b6-7400-4310-ab5a-c3a51a9aadb2", "D", "LK_Adventure_NodeTitle_379", 5)
		}, new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 5, "", new int[6] { 14, 50, 8, 25, 9, 25 }, new int[57]
			{
				7, 7, 12, 25, 10, 10, 10, 60, 10, 7,
				10, 5, 10, 10, 10, 60, 10, 7, 11, 15,
				10, 10, 10, 60, 10, 7, 1, 10, 10, 10,
				10, 60, 10, 7, 4, 10, 10, 10, 10, 60,
				10, 7, 6, 15, 10, 10, 10, 60, 10, 7,
				5, 20, 10, 10, 10, 60, 10
			}, new int[5] { 0, 0, 10, 30, 10 }, new string[9] { "0", "0", "0", "2", "dfdb1551-3bcb-4d4d-8e10-c0b9c18922ce", "20", "c1b3156f-81af-4fe0-8caa-6833052e2f69", "20", "0" }, new int[23]
			{
				3, 0, 120, 50, 0, 180, 30, 0, 240, 20,
				3, 8, 300, 50, 8, 450, 30, 8, 600, 20,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 1, 10, "", new int[6] { 8, 25, 9, 25, 14, 50 }, new int[57]
			{
				7, 7, 12, 25, 10, 10, 10, 60, 10, 7,
				10, 5, 10, 10, 10, 60, 10, 7, 11, 15,
				10, 10, 10, 60, 10, 7, 1, 10, 10, 10,
				10, 60, 10, 7, 4, 10, 10, 10, 10, 60,
				10, 7, 6, 15, 10, 10, 10, 60, 10, 7,
				5, 20, 10, 10, 10, 60, 10
			}, new int[5] { 0, 0, 10, 30, 10 }, new string[9] { "0", "0", "0", "2", "8d065610-6c24-47ea-8590-6de0827cfcaf", "20", "b67caeb3-7f90-4d90-b530-aa4713942f0f", "20", "0" }, new int[23]
			{
				3, 0, 120, 50, 0, 180, 30, 0, 240, 20,
				3, 8, 300, 50, 8, 450, 30, 8, 600, 20,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 3, "3", 1, 10, "", new int[6] { 14, 50, 8, 25, 9, 25 }, new int[57]
			{
				7, 7, 12, 25, 10, 10, 10, 60, 10, 7,
				10, 5, 10, 10, 10, 60, 10, 7, 11, 15,
				10, 10, 10, 60, 10, 7, 1, 10, 10, 10,
				10, 60, 10, 7, 4, 10, 10, 10, 10, 60,
				10, 7, 6, 15, 10, 10, 10, 60, 10, 7,
				5, 20, 10, 10, 10, 60, 10
			}, new int[5] { 0, 0, 10, 30, 10 }, new string[9] { "0", "0", "0", "2", "dfdb1551-3bcb-4d4d-8e10-c0b9c18922ce", "20", "c1b3156f-81af-4fe0-8caa-6833052e2f69", "20", "0" }, new int[23]
			{
				3, 0, 120, 50, 0, 180, 30, 0, 240, 20,
				3, 8, 300, 50, 8, 450, 30, 8, 600, 20,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, new List<AdventureAdvancedBranch>
		{
			new AdventureAdvancedBranch(3, "", 1, 14, 150, new int[2] { 14, 150 }, new int[9] { 1, 7, 11, 100, 0, 0, 0, 100, 0 }, new int[5] { 10, 10, 10, 0, 10 }, new string[7] { "0", "0", "0", "1", "b67caeb3-7f90-4d90-b530-aa4713942f0f", "100", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureAdvancedBranch(3, "", 2, 14, 150, new int[2] { 14, 100 }, new int[9] { 1, 7, 11, 100, 0, 0, 0, 100, 0 }, new int[5] { 10, 10, 10, 0, 10 }, new string[7] { "0", "0", "0", "1", "b67caeb3-7f90-4d90-b530-aa4713942f0f", "100", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray47 = _dataArray;
		string config93 = LocalStringManager.GetConfig("Adventure_language", "Name_106");
		string config94 = LocalStringManager.GetConfig("Adventure_language", "Desc_106");
		int[] resCost47 = new int[9] { 0, 0, 0, 0, 0, 0, 0, 500, 0 };
		list = new List<int[]>();
		List<int[]> itemCost30 = list;
		short[] malice30 = new short[3];
		adventureParams = new List<(string, string, string, string)>();
		dataArray47.Add(new AdventureItem(106, config93, config94, 7, 5, 5, 1, 5, 6, resCost47, itemCost30, restrictedByWorldPopulation: false, malice30, adventureParams, "233ba3e6-10e2-419a-99a3-e329a58cd43e", new List<AdventureStartNode>
		{
			new AdventureStartNode("77218701-d69b-45fa-99d2-729441773dd9", "A", "LK_Adventure_NodeTitle_380", 9),
			new AdventureStartNode("77218701-d69b-45fa-99d2-729441773dd9", "B", "LK_Adventure_NodeTitle_380", 9),
			new AdventureStartNode("77218701-d69b-45fa-99d2-729441773dd9", "C", "LK_Adventure_NodeTitle_380", 9),
			new AdventureStartNode("77218701-d69b-45fa-99d2-729441773dd9", "D", "LK_Adventure_NodeTitle_380", 9),
			new AdventureStartNode("77218701-d69b-45fa-99d2-729441773dd9", "E", "LK_Adventure_NodeTitle_380", 9),
			new AdventureStartNode("77218701-d69b-45fa-99d2-729441773dd9", "F", "LK_Adventure_NodeTitle_380", 9),
			new AdventureStartNode("77218701-d69b-45fa-99d2-729441773dd9", "G", "", 9),
			new AdventureStartNode("77218701-d69b-45fa-99d2-729441773dd9", "H", "", 9)
		}, new List<AdventureTransferNode>
		{
			new AdventureTransferNode("4df6fce8-1655-45a4-bf46-b71333b0e18a", "J", "LK_Adventure_NodeTitle_381", 9),
			new AdventureTransferNode("4df6fce8-1655-45a4-bf46-b71333b0e18a", "K", "LK_Adventure_NodeTitle_381", 9),
			new AdventureTransferNode("4df6fce8-1655-45a4-bf46-b71333b0e18a", "L", "LK_Adventure_NodeTitle_381", 9),
			new AdventureTransferNode("4df6fce8-1655-45a4-bf46-b71333b0e18a", "M", "LK_Adventure_NodeTitle_381", 9),
			new AdventureTransferNode("f5e4933c-1d5d-44a5-843f-933aa7f61f3a", "N", "LK_Adventure_NodeTitle_382", 9),
			new AdventureTransferNode("f5e4933c-1d5d-44a5-843f-933aa7f61f3a", "O", "LK_Adventure_NodeTitle_382", 9)
		}, new List<AdventureEndNode>
		{
			new AdventureEndNode("7e43909f-74d7-4480-800e-29886d44bb21", "I", "LK_Adventure_NodeTitle_383", 9)
		}, new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 8, "1", 2, 5, "", new int[4] { 8, 50, 9, 50 }, new int[57]
			{
				7, 7, 9, 45, 20, 20, 10, 40, 10, 7,
				7, 5, 20, 20, 10, 40, 10, 7, 8, 5,
				20, 20, 10, 40, 10, 7, 13, 10, 20, 20,
				10, 40, 10, 7, 12, 15, 20, 20, 10, 40,
				10, 7, 10, 10, 20, 20, 10, 40, 10, 7,
				17, 10, 20, 20, 10, 40, 10
			}, new int[5] { 0, 0, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "4d5b5d79-b2c6-40c8-8b97-0815b9270a21", "30", "0" }, new int[23]
			{
				3, 2, 120, 50, 2, 180, 30, 2, 240, 20,
				3, 8, 350, 50, 8, 450, 30, 8, 600, 20,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 8, "1", 2, 5, "", new int[4] { 8, 50, 9, 50 }, new int[57]
			{
				7, 7, 9, 45, 20, 20, 10, 40, 10, 7,
				7, 5, 20, 20, 10, 40, 10, 7, 8, 5,
				20, 20, 10, 40, 10, 7, 13, 10, 20, 20,
				10, 40, 10, 7, 12, 15, 20, 20, 10, 40,
				10, 7, 10, 10, 20, 20, 10, 40, 10, 7,
				17, 10, 20, 20, 10, 40, 10
			}, new int[5] { 0, 0, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "4d5b5d79-b2c6-40c8-8b97-0815b9270a21", "30", "0" }, new int[23]
			{
				3, 2, 120, 50, 2, 180, 30, 2, 240, 20,
				3, 8, 350, 50, 8, 450, 30, 8, 600, 20,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 9, "1", 2, 5, "", new int[4] { 8, 50, 9, 50 }, new int[57]
			{
				7, 7, 9, 45, 20, 20, 10, 40, 10, 7,
				7, 5, 20, 20, 10, 40, 10, 7, 8, 5,
				20, 20, 10, 40, 10, 7, 13, 10, 20, 20,
				10, 40, 10, 7, 12, 15, 20, 20, 10, 40,
				10, 7, 10, 10, 20, 20, 10, 40, 10, 7,
				17, 10, 20, 20, 10, 40, 10
			}, new int[5] { 5, 5, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "4d5b5d79-b2c6-40c8-8b97-0815b9270a21", "30", "0" }, new int[23]
			{
				3, 2, 120, 5, 2, 180, 3, 2, 240, 2,
				3, 8, 350, 5, 8, 450, 3, 8, 600, 2,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 9, "1", 2, 5, "", new int[4] { 8, 50, 9, 50 }, new int[57]
			{
				7, 7, 9, 45, 20, 20, 10, 40, 10, 7,
				7, 5, 20, 20, 10, 40, 10, 7, 8, 5,
				20, 20, 10, 40, 10, 7, 13, 10, 20, 20,
				10, 40, 10, 7, 12, 15, 20, 20, 10, 40,
				10, 7, 10, 10, 20, 20, 10, 40, 10, 7,
				17, 10, 20, 20, 10, 40, 10
			}, new int[5] { 5, 5, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "4d5b5d79-b2c6-40c8-8b97-0815b9270a21", "30", "0" }, new int[23]
			{
				3, 2, 120, 5, 2, 180, 3, 2, 240, 2,
				3, 8, 350, 5, 8, 450, 3, 8, 600, 2,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(4, 10, "1", 2, 5, "", new int[4] { 8, 50, 9, 50 }, new int[57]
			{
				7, 7, 9, 45, 20, 20, 10, 40, 10, 7,
				7, 5, 20, 20, 10, 40, 10, 7, 8, 5,
				20, 20, 10, 40, 10, 7, 13, 10, 20, 20,
				10, 40, 10, 7, 12, 15, 20, 20, 10, 40,
				10, 7, 10, 10, 20, 20, 10, 40, 10, 7,
				17, 10, 20, 20, 10, 40, 10
			}, new int[5] { 5, 5, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "4d5b5d79-b2c6-40c8-8b97-0815b9270a21", "30", "0" }, new int[23]
			{
				3, 2, 120, 5, 2, 180, 3, 2, 240, 2,
				3, 8, 350, 5, 8, 450, 3, 8, 600, 2,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(5, 10, "1", 2, 5, "", new int[4] { 8, 50, 9, 50 }, new int[57]
			{
				7, 7, 9, 45, 20, 20, 10, 40, 10, 7,
				7, 5, 20, 20, 10, 40, 10, 7, 8, 5,
				20, 20, 10, 40, 10, 7, 13, 10, 20, 20,
				10, 40, 10, 7, 12, 15, 20, 20, 10, 40,
				10, 7, 10, 10, 20, 20, 10, 40, 10, 7,
				17, 10, 20, 20, 10, 40, 10
			}, new int[5] { 5, 5, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "4d5b5d79-b2c6-40c8-8b97-0815b9270a21", "30", "0" }, new int[23]
			{
				3, 2, 120, 5, 2, 180, 3, 2, 240, 2,
				3, 8, 350, 5, 8, 450, 3, 8, 600, 2,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(6, 11, "1", 2, 5, "", new int[4] { 8, 50, 9, 50 }, new int[57]
			{
				7, 7, 9, 45, 20, 20, 10, 40, 10, 7,
				7, 5, 20, 20, 10, 40, 10, 7, 8, 5,
				20, 20, 10, 40, 10, 7, 13, 10, 20, 20,
				10, 40, 10, 7, 12, 15, 20, 20, 10, 40,
				10, 7, 10, 10, 20, 20, 10, 40, 10, 7,
				17, 10, 20, 20, 10, 40, 10
			}, new int[5] { 5, 5, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "4d5b5d79-b2c6-40c8-8b97-0815b9270a21", "30", "0" }, new int[23]
			{
				3, 2, 120, 5, 2, 180, 3, 2, 240, 2,
				3, 8, 350, 5, 8, 450, 3, 8, 600, 2,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(7, 11, "1", 2, 5, "", new int[4] { 8, 50, 9, 50 }, new int[57]
			{
				7, 7, 9, 45, 20, 20, 10, 40, 10, 7,
				7, 5, 20, 20, 10, 40, 10, 7, 8, 5,
				20, 20, 10, 40, 10, 7, 13, 10, 20, 20,
				10, 40, 10, 7, 12, 15, 20, 20, 10, 40,
				10, 7, 10, 10, 20, 20, 10, 40, 10, 7,
				17, 10, 20, 20, 10, 40, 10
			}, new int[5] { 5, 5, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "4d5b5d79-b2c6-40c8-8b97-0815b9270a21", "30", "0" }, new int[23]
			{
				3, 2, 120, 5, 2, 180, 3, 2, 240, 2,
				3, 8, 350, 5, 8, 450, 3, 8, 600, 2,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(8, 12, "1", 2, 5, "", new int[4] { 8, 50, 9, 50 }, new int[57]
			{
				7, 7, 9, 45, 20, 20, 10, 40, 10, 7,
				7, 5, 20, 20, 10, 40, 10, 7, 8, 5,
				20, 20, 10, 40, 10, 7, 13, 10, 20, 20,
				10, 40, 10, 7, 12, 15, 20, 20, 10, 40,
				10, 7, 10, 10, 20, 20, 10, 40, 10, 7,
				17, 10, 20, 20, 10, 40, 10
			}, new int[5] { 5, 5, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "4d5b5d79-b2c6-40c8-8b97-0815b9270a21", "30", "0" }, new int[23]
			{
				3, 2, 120, 5, 2, 180, 3, 2, 240, 2,
				3, 8, 350, 5, 8, 450, 3, 8, 600, 2,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(9, 12, "1", 2, 5, "", new int[4] { 8, 50, 9, 50 }, new int[57]
			{
				7, 7, 9, 45, 20, 20, 10, 40, 10, 7,
				7, 5, 20, 20, 10, 40, 10, 7, 8, 5,
				20, 20, 10, 40, 10, 7, 13, 10, 20, 20,
				10, 40, 10, 7, 12, 15, 20, 20, 10, 40,
				10, 7, 10, 10, 20, 20, 10, 40, 10, 7,
				17, 10, 20, 20, 10, 40, 10
			}, new int[5] { 5, 5, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "4d5b5d79-b2c6-40c8-8b97-0815b9270a21", "30", "0" }, new int[23]
			{
				3, 2, 120, 5, 2, 180, 3, 2, 240, 2,
				3, 8, 350, 5, 8, 450, 3, 8, 600, 2,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(10, 13, "1", 2, 5, "", new int[4] { 8, 50, 9, 50 }, new int[57]
			{
				7, 7, 9, 45, 20, 20, 10, 40, 10, 7,
				7, 5, 20, 20, 10, 40, 10, 7, 8, 5,
				20, 20, 10, 40, 10, 7, 13, 10, 20, 20,
				10, 40, 10, 7, 12, 15, 20, 20, 10, 40,
				10, 7, 10, 10, 20, 20, 10, 40, 10, 7,
				17, 10, 20, 20, 10, 40, 10
			}, new int[5] { 5, 5, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "4d5b5d79-b2c6-40c8-8b97-0815b9270a21", "30", "0" }, new int[23]
			{
				3, 2, 120, 5, 2, 180, 3, 2, 240, 2,
				3, 8, 350, 5, 8, 450, 3, 8, 600, 2,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(11, 13, "1", 2, 5, "", new int[4] { 8, 50, 9, 50 }, new int[57]
			{
				7, 7, 9, 45, 20, 20, 10, 40, 10, 7,
				7, 5, 20, 20, 10, 40, 10, 7, 8, 5,
				20, 20, 10, 40, 10, 7, 13, 10, 20, 20,
				10, 40, 10, 7, 12, 15, 20, 20, 10, 40,
				10, 7, 10, 10, 20, 20, 10, 40, 10, 7,
				17, 10, 20, 20, 10, 40, 10
			}, new int[5] { 5, 5, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "4d5b5d79-b2c6-40c8-8b97-0815b9270a21", "30", "0" }, new int[23]
			{
				3, 2, 120, 5, 2, 180, 3, 2, 240, 2,
				3, 8, 350, 5, 8, 450, 3, 8, 600, 2,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(12, 14, "1", 2, 5, "", new int[4] { 8, 50, 9, 50 }, new int[57]
			{
				7, 7, 9, 45, 20, 20, 10, 40, 10, 7,
				7, 5, 20, 20, 10, 40, 10, 7, 8, 5,
				20, 20, 10, 40, 10, 7, 13, 10, 20, 20,
				10, 40, 10, 7, 12, 15, 20, 20, 10, 40,
				10, 7, 10, 10, 20, 20, 10, 40, 10, 7,
				17, 10, 20, 20, 10, 40, 10
			}, new int[5] { 5, 5, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "4d5b5d79-b2c6-40c8-8b97-0815b9270a21", "30", "0" }, new int[23]
			{
				3, 2, 120, 5, 2, 180, 3, 2, 240, 2,
				3, 8, 350, 5, 8, 450, 3, 8, 600, 2,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(13, 14, "1", 2, 5, "", new int[4] { 8, 50, 9, 50 }, new int[57]
			{
				7, 7, 9, 45, 20, 20, 10, 40, 10, 7,
				7, 5, 20, 20, 10, 40, 10, 7, 8, 5,
				20, 20, 10, 40, 10, 7, 13, 10, 20, 20,
				10, 40, 10, 7, 12, 15, 20, 20, 10, 40,
				10, 7, 10, 10, 20, 20, 10, 40, 10, 7,
				17, 10, 20, 20, 10, 40, 10
			}, new int[5] { 5, 5, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "4d5b5d79-b2c6-40c8-8b97-0815b9270a21", "30", "0" }, new int[23]
			{
				3, 2, 120, 5, 2, 180, 3, 2, 240, 2,
				3, 8, 350, 5, 8, 450, 3, 8, 600, 2,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, new List<AdventureAdvancedBranch>
		{
			new AdventureAdvancedBranch(1, "", 8, 8, 150, new int[2] { 8, 100 }, new int[9] { 1, 7, 9, 100, 0, 0, 0, 100, 0 }, new int[5] { 10, 10, 10, 0, 10 }, new string[5] { "0", "0", "0", "0", "0" }, new int[5], new int[5], new string[7] { "0", "0", "0", "1", "fff31a0b-c438-4f17-ab54-20f902d478a1", "100", "0" }),
			new AdventureAdvancedBranch(1, "", 9, 9, 150, new int[2] { 9, 100 }, new int[9] { 1, 7, 9, 100, 0, 0, 0, 100, 0 }, new int[5] { 10, 10, 10, 0, 10 }, new string[5] { "0", "0", "0", "0", "0" }, new int[5], new int[5], new string[7] { "0", "0", "0", "1", "fff31a0b-c438-4f17-ab54-20f902d478a1", "100", "0" }),
			new AdventureAdvancedBranch(1, "", 10, 8, 150, new int[2] { 8, 100 }, new int[9] { 1, 7, 9, 100, 0, 0, 0, 100, 0 }, new int[5] { 10, 10, 10, 0, 10 }, new string[5] { "0", "0", "0", "0", "0" }, new int[5], new int[5], new string[7] { "0", "0", "0", "1", "fff31a0b-c438-4f17-ab54-20f902d478a1", "100", "0" }),
			new AdventureAdvancedBranch(1, "", 11, 9, 150, new int[2] { 9, 100 }, new int[9] { 1, 7, 9, 100, 0, 0, 0, 100, 0 }, new int[5] { 10, 10, 10, 0, 10 }, new string[5] { "0", "0", "0", "0", "0" }, new int[5], new int[5], new string[7] { "0", "0", "0", "1", "fff31a0b-c438-4f17-ab54-20f902d478a1", "100", "0" }),
			new AdventureAdvancedBranch(2, "", 12, 8, 150, new int[2] { 8, 100 }, new int[9] { 1, 7, 9, 100, 0, 0, 0, 100, 0 }, new int[5] { 10, 10, 10, 0, 10 }, new string[5] { "0", "0", "0", "0", "0" }, new int[5], new int[5], new string[7] { "0", "0", "0", "1", "fff31a0b-c438-4f17-ab54-20f902d478a1", "100", "0" }),
			new AdventureAdvancedBranch(2, "", 13, 9, 150, new int[2] { 8, 100 }, new int[9] { 1, 7, 9, 100, 0, 0, 0, 100, 0 }, new int[5] { 10, 10, 10, 0, 10 }, new string[5] { "0", "0", "0", "0", "0" }, new int[5], new int[5], new string[7] { "0", "0", "0", "1", "fff31a0b-c438-4f17-ab54-20f902d478a1", "100", "0" })
		}, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray48 = _dataArray;
		string config95 = LocalStringManager.GetConfig("Adventure_language", "Name_107");
		string config96 = LocalStringManager.GetConfig("Adventure_language", "Desc_107");
		int[] resCost48 = new int[9] { 0, 0, 0, 0, 0, 0, 0, 500, 0 };
		list = new List<int[]>();
		List<int[]> itemCost31 = list;
		short[] malice31 = new short[3];
		List<(string, string, string, string)> adventureParams24 = new List<(string, string, string, string)>
		{
			("brightness", "LK_Adventure_107_ParamName_0", "", ""),
			("quality", "LK_Adventure_107_ParamName_1", "", "")
		};
		List<AdventureStartNode> startNodes23 = new List<AdventureStartNode>
		{
			new AdventureStartNode("acfb81d8-9a09-4da5-b9fe-a25c5d5280b1", "0", "LK_Adventure_NodeTitle_386", 4)
		};
		transferNodes = new List<AdventureTransferNode>();
		dataArray48.Add(new AdventureItem(107, config95, config96, 7, 5, 5, 1, 5, 6, resCost48, itemCost31, restrictedByWorldPopulation: false, malice31, adventureParams24, "9a124e63-d7c9-498d-bc25-85d87276778d", startNodes23, transferNodes, new List<AdventureEndNode>
		{
			new AdventureEndNode("499a2409-2a92-41b7-b5ba-27d3a83bb5b7", "A", "LK_Adventure_NodeTitle_387", 4)
		}, new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "A", 3, 15, "445089f7-000f-4634-8b4d-3e3f7f096944", new int[4] { 11, 50, 1, 50 }, new int[57]
			{
				7, 7, 4, 35, 10, 5, 5, 50, 30, 7,
				5, 15, 5, 10, 5, 50, 30, 7, 6, 10,
				10, 5, 5, 50, 30, 7, 2, 10, 5, 10,
				5, 50, 30, 7, 3, 5, 5, 10, 5, 50,
				30, 7, 11, 10, 5, 5, 10, 50, 30, 7,
				12, 15, 5, 5, 10, 50, 30
			}, new int[5] { 10, 5, 5, 30, 30 }, new string[9] { "0", "0", "0", "1", "f495a941-76a5-4cf7-bf80-ec3f7454775e", "30", "1", "4c2fa3db-8d15-4c44-ae44-b5d57516d124", "30" }, new int[14]
			{
				0, 3, 8, 300, 5, 8, 450, 3, 8, 600,
				2, 0, 0, 0
			}, new int[9] { 0, 0, 1, 5, -504, 1, 10, 0, 0 }, new string[5] { "0", "0", "0", "0", "0" })
		}, new List<AdventureAdvancedBranch>
		{
			new AdventureAdvancedBranch(3, "", 0, 11, 150, new int[2] { 11, 100 }, new int[9] { 1, 7, 1, 100, 100, 0, 0, 0, 0 }, new int[5] { 0, 10, 10, 10, 10 }, new string[7] { "1", "62cc577a-ff84-4d65-ab8a-98e7ca73dc7b", "100", "0", "0", "0", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray49 = _dataArray;
		string config97 = LocalStringManager.GetConfig("Adventure_language", "Name_108");
		string config98 = LocalStringManager.GetConfig("Adventure_language", "Desc_108");
		int[] resCost49 = new int[9] { 0, 0, 0, 0, 0, 0, 0, 500, 0 };
		list = new List<int[]>();
		dataArray49.Add(new AdventureItem(108, config97, config98, 7, 5, 5, 1, 5, 6, resCost49, list, restrictedByWorldPopulation: false, new short[3], new List<(string, string, string, string)> { ("support", "LK_Adventure_108_ParamName_0", "", "") }, "b1a437c3-c095-4fb7-9d61-d7303314e212", new List<AdventureStartNode>
		{
			new AdventureStartNode("da4eca7a-994b-4154-b5c7-57a51d9b86ee", "A", "LK_Adventure_NodeTitle_389", 9)
		}, new List<AdventureTransferNode>
		{
			new AdventureTransferNode("86600254-ab2e-46f8-8cd0-e03798c34f43", "B", "LK_Adventure_NodeTitle_390", 4)
		}, new List<AdventureEndNode>
		{
			new AdventureEndNode("b21ba164-f956-4da0-b99a-a75e2dc54246", "C", "LK_Adventure_NodeTitle_316", 9)
		}, new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(1, 2, "1", 3, 8, "", new int[8] { 0, 25, 1, 25, 2, 25, 3, 25 }, new int[57]
			{
				7, 7, 4, 25, 10, 50, 10, 20, 10, 7,
				5, 25, 10, 50, 10, 20, 10, 7, 6, 10,
				10, 50, 10, 20, 10, 7, 1, 10, 10, 50,
				10, 20, 10, 7, 8, 5, 10, 50, 10, 20,
				10, 7, 9, 10, 10, 50, 10, 20, 10, 7,
				12, 15, 10, 50, 10, 20, 10
			}, new int[5] { 0, 20, 10, 10, 10 }, new string[11]
			{
				"0", "2", "751cc7f4-827f-4860-a81a-c9b7f23945cd", "40", "376ecec4-1171-49cc-aea9-1240502c49e3", "10", "0", "1", "166e9626-1ec5-43bb-96d4-2a705ab535d3", "30",
				"0"
			}, new int[23]
			{
				3, 0, 120, 50, 0, 180, 30, 0, 240, 20,
				3, 8, 300, 5, 8, 450, 3, 8, 600, 2,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(0, 1, "1", 3, 7, "", new int[8] { 0, 25, 1, 25, 2, 25, 3, 25 }, new int[57]
			{
				7, 7, 4, 25, 10, 60, 10, 10, 10, 7,
				5, 25, 10, 60, 10, 10, 10, 7, 6, 10,
				10, 60, 10, 10, 10, 7, 1, 10, 10, 60,
				10, 10, 10, 7, 8, 5, 10, 60, 10, 10,
				10, 7, 9, 10, 10, 60, 10, 10, 10, 7,
				12, 15, 10, 60, 10, 10, 10
			}, new int[5] { 0, 20, 10, 10, 10 }, new string[7] { "0", "1", "91128bda-ecc0-4252-94b9-d49a4e3a0756", "50", "0", "0", "0" }, new int[23]
			{
				3, 0, 120, 50, 0, 180, 30, 0, 240, 20,
				3, 8, 300, 5, 8, 450, 3, 8, 600, 2,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, new List<AdventureAdvancedBranch>
		{
			new AdventureAdvancedBranch(3, "", 0, 1, 150, new int[2] { 1, 150 }, new int[9] { 1, 7, 4, 100, 0, 100, 0, 0, 0 }, new int[5] { 10, 0, 10, 10, 10 }, new string[7] { "0", "1", "5d7c433c-08d4-4035-b757-9eacc9b0c246", "100", "0", "0", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray50 = _dataArray;
		string config99 = LocalStringManager.GetConfig("Adventure_language", "Name_109");
		string config100 = LocalStringManager.GetConfig("Adventure_language", "Desc_109");
		int[] resCost50 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost32 = list;
		short[] malice32 = new short[3];
		adventureParams = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams25 = adventureParams;
		List<AdventureStartNode> startNodes24 = new List<AdventureStartNode>
		{
			new AdventureStartNode("cd03177f-3c93-4221-8d81-d4dbd63abc4b", "A", "LK_Adventure_NodeTitle_317", 9)
		};
		transferNodes = new List<AdventureTransferNode>();
		dataArray50.Add(new AdventureItem(109, config99, config100, 8, 5, 5, 1, 5, 6, resCost50, itemCost32, restrictedByWorldPopulation: false, malice32, adventureParams25, "a58362d6-f20d-4a33-81a2-76f17efb2bbb", startNodes24, transferNodes, new List<AdventureEndNode>
		{
			new AdventureEndNode("c06c719e-5c24-408b-990a-b224eda214e6", "B", "LK_Adventure_NodeTitle_318", 5)
		}, new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 3, 15, "", new int[4] { 15, 20, 5, 80 }, new int[57]
			{
				7, 7, 9, 45, 5, 5, 10, 40, 40, 7,
				7, 5, 5, 5, 10, 40, 40, 7, 8, 10,
				5, 5, 10, 40, 40, 7, 13, 10, 10, 5,
				5, 40, 40, 7, 14, 5, 10, 5, 5, 40,
				40, 7, 15, 5, 10, 5, 5, 40, 40, 7,
				10, 20, 5, 5, 10, 40, 40
			}, new int[5] { 10, 0, 10, 25, 25 }, new string[11]
			{
				"0", "0", "1", "398a8f53-7fc0-464e-95bb-6062526ea89b", "15", "1", "db8674d8-893c-4d3f-b1b2-9dc6471129d8", "20", "1", "9d277202-cb38-462a-8140-bf9a991eb157",
				"20"
			}, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[9] { 0, 0, 1, 9, -902, 1, 5, 0, 0 }, new string[5] { "0", "0", "0", "0", "0" })
		}, new List<AdventureAdvancedBranch>
		{
			new AdventureAdvancedBranch(3, "", 0, 5, 150, new int[2] { 5, 100 }, new int[9] { 1, 7, 7, 100, 0, 0, 0, 0, 100 }, new int[5] { 10, 10, 10, 10, 0 }, new string[5] { "0", "0", "0", "0", "0" }, new int[5], new int[5], new string[7] { "0", "0", "0", "0", "1", "e5642386-e2b1-436b-8938-5372bd75aca4", "100" })
		}, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray51 = _dataArray;
		string config101 = LocalStringManager.GetConfig("Adventure_language", "Name_110");
		string config102 = LocalStringManager.GetConfig("Adventure_language", "Desc_110");
		int[] resCost51 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost33 = list;
		short[] malice33 = new short[3];
		adventureParams = new List<(string, string, string, string)>();
		dataArray51.Add(new AdventureItem(110, config101, config102, 8, 5, 5, 1, 5, 6, resCost51, itemCost33, restrictedByWorldPopulation: false, malice33, adventureParams, "0e2edeb0-9fca-4ae3-9779-3c78a8660705", new List<AdventureStartNode>
		{
			new AdventureStartNode("d8535ab9-ab08-4134-adb5-63d5fd30f9dd", "A", "LK_Adventure_NodeTitle_319", 1)
		}, new List<AdventureTransferNode>
		{
			new AdventureTransferNode("1c275fca-e048-49fc-83cf-729e32a6dc10", "B", "LK_Adventure_NodeTitle_320", 0)
		}, new List<AdventureEndNode>
		{
			new AdventureEndNode("7a731ad6-26e7-461a-8f9c-e827c99848c4", "C", "LK_Adventure_NodeTitle_321", 0)
		}, new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 8, "", new int[4] { 0, 50, 2, 50 }, new int[57]
			{
				7, 7, 12, 30, 10, 10, 60, 10, 10, 7,
				10, 15, 10, 10, 60, 10, 10, 7, 11, 15,
				10, 10, 60, 10, 10, 7, 17, 15, 10, 10,
				60, 10, 10, 7, 1, 15, 10, 10, 60, 10,
				10, 7, 13, 5, 10, 10, 60, 10, 10, 7,
				16, 5, 10, 10, 60, 10, 10
			}, new int[5] { 10, 5, 20, 100, 5 }, new string[11]
			{
				"0", "0", "3", "01854fea-c76b-44c6-ad42-c55f903db305", "20", "67025aec-e180-4f28-96bf-aac316623c77", "10", "e59e9cf6-81dd-473f-a13e-6d34070303a3", "10", "0",
				"0"
			}, new int[14]
			{
				0, 3, 8, 300, 5, 8, 450, 3, 8, 600,
				2, 0, 0, 0
			}, new int[13]
			{
				0, 0, 0, 0, 2, 5, -506, 1, 5, 5,
				-507, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 1, 7, "", new int[4] { 0, 50, 2, 50 }, new int[57]
			{
				7, 7, 12, 30, 10, 10, 60, 10, 10, 7,
				10, 15, 10, 10, 60, 10, 10, 7, 11, 15,
				10, 10, 60, 10, 10, 7, 17, 15, 10, 10,
				60, 10, 10, 7, 1, 15, 10, 10, 60, 10,
				10, 7, 13, 5, 10, 10, 60, 10, 10, 7,
				16, 5, 10, 10, 60, 10, 10
			}, new int[5] { 10, 5, 20, 100, 5 }, new string[11]
			{
				"0", "0", "3", "ccc14801-c474-4f24-8188-8945a8e16ae2", "25", "9a07fe4b-bedf-488c-9d4d-580d5055c438", "10", "73d4a954-6dff-44c6-b9d6-67396f2bf901", "5", "0",
				"0"
			}, new int[14]
			{
				0, 3, 8, 300, 5, 8, 450, 3, 8, 600,
				2, 0, 0, 0
			}, new int[13]
			{
				0, 0, 0, 0, 2, 5, -506, 1, 5, 5,
				-507, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" })
		}, new List<AdventureAdvancedBranch>
		{
			new AdventureAdvancedBranch(2, "", 1, 0, 150, new int[2] { 0, 100 }, new int[9] { 1, 7, 5, 100, 0, 0, 100, 0, 0 }, new int[5] { 10, 10, 0, 10, 10 }, new string[7] { "0", "0", "1", "9a07fe4b-bedf-488c-9d4d-580d5055c438", "100", "0", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray52 = _dataArray;
		string config103 = LocalStringManager.GetConfig("Adventure_language", "Name_111");
		string config104 = LocalStringManager.GetConfig("Adventure_language", "Desc_111");
		int[] resCost52 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost34 = list;
		short[] malice34 = new short[3];
		adventureParams = new List<(string, string, string, string)>();
		dataArray52.Add(new AdventureItem(111, config103, config104, 8, 5, 5, 1, 5, 6, resCost52, itemCost34, restrictedByWorldPopulation: false, malice34, adventureParams, "32743760-beae-4983-9717-8c4595a57d97", new List<AdventureStartNode>
		{
			new AdventureStartNode("b1194501-8d45-4a8a-abbf-5e118a7dd4d5", "A", "LK_Adventure_NodeTitle_323", 9)
		}, new List<AdventureTransferNode>
		{
			new AdventureTransferNode("3efd17fb-cc87-4bf1-b991-b14a9d35b0cd", "B", "LK_Adventure_NodeTitle_324", 15),
			new AdventureTransferNode("9b81c46b-453f-4ef8-a30d-d2327be0f055", "C", "LK_Adventure_NodeTitle_325", 15),
			new AdventureTransferNode("9b81c46b-453f-4ef8-a30d-d2327be0f055", "D", "LK_Adventure_NodeTitle_325", 15),
			new AdventureTransferNode("9b81c46b-453f-4ef8-a30d-d2327be0f055", "E", "LK_Adventure_NodeTitle_325", 15)
		}, new List<AdventureEndNode>
		{
			new AdventureEndNode("a24cb27e-7b9b-4d67-9333-3b7226734759", "F", "LK_Adventure_NodeTitle_326", 15),
			new AdventureEndNode("a24cb27e-7b9b-4d67-9333-3b7226734759", "G", "LK_Adventure_NodeTitle_326", 15),
			new AdventureEndNode("a24cb27e-7b9b-4d67-9333-3b7226734759", "H", "LK_Adventure_NodeTitle_326", 15)
		}, new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 0, 3, "", new int[4] { 4, 80, 5, 20 }, new int[4] { 1, 2, 9, 100 }, new int[5] { 100, 100, 100, 100, 100 }, new string[5] { "0", "0", "0", "0", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 2, 5, "", new int[4] { 4, 80, 5, 20 }, new int[57]
			{
				7, 7, 9, 35, 50, 5, 10, 30, 5, 7,
				14, 15, 50, 5, 10, 30, 5, 7, 15, 15,
				50, 5, 10, 30, 5, 7, 7, 5, 50, 5,
				10, 30, 5, 7, 8, 5, 50, 5, 10, 30,
				5, 7, 13, 5, 50, 5, 10, 30, 5, 7,
				16, 20, 50, 5, 10, 30, 5
			}, new int[5] { 5, 0, 5, 5, 10 }, new string[13]
			{
				"3", "33e0a16e-0a00-4c8c-97c5-2a877e745d61", "10", "b9e927d5-0003-47df-b68b-ded3444b0943", "10", "8a4c32b1-d796-4c39-99b4-b55cbf1fb054", "10", "0", "0", "1",
				"79f57c50-0042-4906-a533-acbc3c5285d9", "30", "0"
			}, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 2, 7, -701, 1, 5, 7, -702, 1,
				5, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 3, "3", 2, 7, "", new int[4] { 4, 80, 5, 20 }, new int[57]
			{
				7, 7, 9, 35, 50, 5, 10, 30, 5, 7,
				14, 15, 50, 5, 10, 30, 5, 7, 15, 15,
				50, 5, 10, 30, 5, 7, 7, 5, 50, 5,
				10, 30, 5, 7, 8, 5, 50, 5, 10, 30,
				5, 7, 13, 5, 50, 5, 10, 30, 5, 7,
				16, 20, 50, 5, 10, 30, 5
			}, new int[5] { 10, 0, 5, 10, 10 }, new string[13]
			{
				"3", "33e0a16e-0a00-4c8c-97c5-2a877e745d61", "10", "b9e927d5-0003-47df-b68b-ded3444b0943", "10", "8a4c32b1-d796-4c39-99b4-b55cbf1fb054", "10", "0", "0", "1",
				"79f57c50-0042-4906-a533-acbc3c5285d9", "30", "0"
			}, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 2, 7, -701, 1, 5, 7, -702, 1,
				5, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 4, "4", 2, 10, "", new int[4] { 4, 80, 5, 20 }, new int[57]
			{
				7, 7, 9, 35, 50, 5, 10, 30, 5, 7,
				14, 15, 50, 5, 10, 30, 5, 7, 15, 15,
				50, 5, 10, 30, 5, 7, 7, 5, 50, 5,
				10, 30, 5, 7, 8, 5, 50, 5, 10, 30,
				5, 7, 13, 5, 50, 5, 10, 30, 5, 7,
				16, 20, 50, 5, 10, 30, 5
			}, new int[5] { 20, 0, 5, 20, 10 }, new string[13]
			{
				"3", "33e0a16e-0a00-4c8c-97c5-2a877e745d61", "10", "b9e927d5-0003-47df-b68b-ded3444b0943", "10", "8a4c32b1-d796-4c39-99b4-b55cbf1fb054", "10", "0", "0", "1",
				"79f57c50-0042-4906-a533-acbc3c5285d9", "30", "0"
			}, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 2, 7, -701, 1, 5, 7, -702, 1,
				5, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 5, "1", 2, 5, "", new int[4] { 4, 80, 5, 20 }, new int[57]
			{
				7, 7, 9, 35, 40, 5, 10, 40, 5, 7,
				14, 15, 40, 5, 10, 40, 5, 7, 15, 15,
				40, 10, 5, 40, 5, 7, 7, 5, 40, 5,
				10, 40, 5, 7, 8, 5, 40, 5, 5, 40,
				10, 7, 13, 5, 40, 5, 5, 40, 10, 7,
				16, 20, 40, 10, 5, 40, 5
			}, new int[5] { 5, 0, 5, 5, 10 }, new string[9] { "1", "866c940d-4a05-46c7-8d5c-91bda0b67a05", "30", "0", "0", "1", "cc034359-a2cf-4ab5-986b-73de1c285caf", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 2, 7, -701, 1, 5, 7, -702, 1,
				5, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 6, "1", 2, 8, "", new int[4] { 4, 80, 5, 20 }, new int[57]
			{
				7, 7, 9, 35, 40, 5, 10, 40, 5, 7,
				14, 15, 40, 5, 10, 40, 5, 7, 15, 15,
				40, 10, 5, 40, 5, 7, 7, 5, 40, 5,
				10, 40, 5, 7, 8, 5, 40, 5, 5, 40,
				10, 7, 13, 5, 40, 5, 5, 40, 10, 7,
				16, 20, 40, 10, 5, 40, 5
			}, new int[5] { 10, 0, 5, 10, 10 }, new string[9] { "1", "866c940d-4a05-46c7-8d5c-91bda0b67a05", "30", "0", "0", "1", "cc034359-a2cf-4ab5-986b-73de1c285caf", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 2, 7, -701, 1, 5, 7, -702, 1,
				5, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(4, 7, "1", 2, 10, "", new int[4] { 4, 80, 5, 20 }, new int[57]
			{
				7, 7, 9, 35, 40, 5, 10, 40, 5, 7,
				14, 15, 40, 5, 10, 40, 5, 7, 15, 15,
				40, 10, 5, 40, 5, 7, 7, 5, 40, 5,
				10, 40, 5, 7, 8, 5, 40, 5, 5, 40,
				10, 7, 13, 5, 40, 5, 5, 40, 10, 7,
				16, 20, 40, 10, 5, 40, 5
			}, new int[5] { 20, 0, 5, 20, 10 }, new string[9] { "1", "866c940d-4a05-46c7-8d5c-91bda0b67a05", "30", "0", "0", "1", "cc034359-a2cf-4ab5-986b-73de1c285caf", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[13]
			{
				0, 0, 2, 7, -701, 1, 5, 7, -702, 1,
				5, 0, 0
			}, new string[5] { "0", "0", "0", "0", "0" })
		}, new List<AdventureAdvancedBranch>
		{
			new AdventureAdvancedBranch(3, "", 4, 4, 150, new int[2] { 4, 100 }, new int[9] { 1, 7, 22, 100, 0, 0, 0, 100, 0 }, new int[5] { 10, 10, 10, 0, 10 }, new string[7] { "0", "0", "0", "1", "cc034359-a2cf-4ab5-986b-73de1c285caf", "100", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureAdvancedBranch(3, "", 5, 4, 150, new int[2] { 4, 100 }, new int[9] { 1, 7, 22, 100, 0, 0, 0, 100, 0 }, new int[5] { 10, 10, 10, 0, 10 }, new string[7] { "0", "0", "0", "1", "cc034359-a2cf-4ab5-986b-73de1c285caf", "100", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureAdvancedBranch(3, "", 6, 4, 150, new int[2] { 4, 100 }, new int[9] { 1, 7, 22, 100, 0, 0, 0, 100, 0 }, new int[5] { 10, 10, 10, 0, 10 }, new string[7] { "0", "0", "0", "1", "cc034359-a2cf-4ab5-986b-73de1c285caf", "100", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray53 = _dataArray;
		string config105 = LocalStringManager.GetConfig("Adventure_language", "Name_112");
		string config106 = LocalStringManager.GetConfig("Adventure_language", "Desc_112");
		int[] resCost53 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost35 = list;
		short[] malice35 = new short[3];
		adventureParams = new List<(string, string, string, string)>();
		dataArray53.Add(new AdventureItem(112, config105, config106, 8, 5, 5, 1, 5, 6, resCost53, itemCost35, restrictedByWorldPopulation: false, malice35, adventureParams, "3726d37b-060a-42d9-8b75-173f63befb7d", new List<AdventureStartNode>
		{
			new AdventureStartNode("3f245e07-3cc3-450a-87ad-81976206bb7b", "A", "LK_Adventure_NodeTitle_334", 9)
		}, new List<AdventureTransferNode>
		{
			new AdventureTransferNode("ea6be41e-23ea-4ddd-b8d6-540132b7c5b4", "B", "LK_Adventure_NodeTitle_335", 10)
		}, new List<AdventureEndNode>
		{
			new AdventureEndNode("4a243f41-f69c-41a6-ad55-26aa50d40461", "C", "LK_Adventure_NodeTitle_336", 9)
		}, new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 7, "", new int[4] { 3, 50, 15, 50 }, new int[57]
			{
				7, 7, 9, 35, 20, 20, 20, 20, 20, 7,
				7, 5, 20, 20, 20, 20, 20, 7, 8, 5,
				20, 20, 20, 20, 20, 7, 13, 10, 20, 20,
				20, 20, 20, 7, 11, 5, 20, 20, 20, 20,
				20, 7, 12, 5, 20, 20, 20, 20, 20, 7,
				10, 35, 20, 20, 20, 20, 20
			}, new int[5] { 50, 50, 40, 40, 40 }, new string[35]
			{
				"3", "2a7e5027-aba7-4754-9a82-bb60a1537d8b", "30", "1467615b-f224-42aa-9b36-68e6973cb89b", "5", "c54cf828-6a92-4ce5-be42-e4f4cdd27e68", "5", "3", "73d59b61-ec0f-48e6-8720-64e27a30cec1", "30",
				"1467615b-f224-42aa-9b36-68e6973cb89b", "5", "c54cf828-6a92-4ce5-be42-e4f4cdd27e68", "5", "3", "c24b35b5-24ce-4dfe-b554-1ab1d46f69aa", "30", "1467615b-f224-42aa-9b36-68e6973cb89b", "5", "c54cf828-6a92-4ce5-be42-e4f4cdd27e68",
				"5", "3", "29140745-266a-4e00-9027-119166a315b6", "30", "1467615b-f224-42aa-9b36-68e6973cb89b", "5", "c54cf828-6a92-4ce5-be42-e4f4cdd27e68", "5", "3", "2b3ed3ad-3cc2-451f-8ce8-2ce871cc22cf",
				"30", "1467615b-f224-42aa-9b36-68e6973cb89b", "5", "c54cf828-6a92-4ce5-be42-e4f4cdd27e68", "5"
			}, new int[23]
			{
				3, 1, 120, 5, 1, 180, 3, 1, 240, 2,
				3, 8, 300, 5, 8, 450, 3, 8, 600, 2,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 1, 8, "", new int[4] { 3, 50, 15, 50 }, new int[57]
			{
				7, 7, 9, 35, 10, 10, 10, 60, 10, 7,
				7, 5, 10, 10, 10, 60, 10, 7, 8, 5,
				10, 10, 10, 60, 10, 7, 13, 10, 10, 10,
				10, 60, 10, 7, 11, 5, 10, 10, 10, 60,
				10, 7, 12, 5, 10, 10, 10, 60, 10, 7,
				10, 35, 10, 10, 10, 60, 10
			}, new int[5] { 0, 0, 10, 10, 20 }, new string[7] { "0", "0", "0", "1", "404cd70c-dc0d-4a95-8272-76b5c240bb16", "50", "0" }, new int[23]
			{
				3, 1, 120, 50, 1, 180, 30, 1, 240, 20,
				3, 8, 300, 50, 8, 450, 30, 8, 600, 20,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, new List<AdventureAdvancedBranch>
		{
			new AdventureAdvancedBranch(1, "", 1, 3, 150, new int[2] { 3, 150 }, new int[4] { 1, 2, 10, 100 }, new int[5], new string[15]
			{
				"1", "8053babb-e3f6-46b7-85be-ab333f9a1745", "100", "1", "8053babb-e3f6-46b7-85be-ab333f9a1745", "100", "1", "8053babb-e3f6-46b7-85be-ab333f9a1745", "100", "1",
				"8053babb-e3f6-46b7-85be-ab333f9a1745", "100", "1", "8053babb-e3f6-46b7-85be-ab333f9a1745", "100"
			}, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray54 = _dataArray;
		string config107 = LocalStringManager.GetConfig("Adventure_language", "Name_113");
		string config108 = LocalStringManager.GetConfig("Adventure_language", "Desc_113");
		int[] resCost54 = new int[9];
		list = new List<int[]>();
		dataArray54.Add(new AdventureItem(113, config107, config108, 8, 5, 5, 1, 5, 6, resCost54, list, restrictedByWorldPopulation: false, new short[3], new List<(string, string, string, string)>
		{
			("singJust", "LK_Adventure_98_ParamName_0", "", ""),
			("singKind", "LK_Adventure_98_ParamName_1", "", ""),
			("singEven", "LK_Adventure_98_ParamName_2", "", ""),
			("singRebel", "LK_Adventure_98_ParamName_3", "", ""),
			("singEgoistic", "LK_Adventure_98_ParamName_4", "", "")
		}, "0c509906-cbfd-4c60-9939-9a83f8106f84", new List<AdventureStartNode>
		{
			new AdventureStartNode("eb195b0d-cc5b-4483-91f8-81841cedbcf7", "A", "LK_Adventure_NodeTitle_342", 2)
		}, new List<AdventureTransferNode>
		{
			new AdventureTransferNode("1c272482-f973-4a62-8d97-b44adc79c82a", "B", "LK_Adventure_NodeTitle_343", 1)
		}, new List<AdventureEndNode>
		{
			new AdventureEndNode("bf84962d-f995-4625-8e76-ce4af9d65431", "C", "LK_Adventure_NodeTitle_344", 1)
		}, new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 2, 7, "", new int[4] { 0, 50, 7, 50 }, new int[57]
			{
				7, 7, 12, 35, 10, 10, 30, 50, 0, 7,
				10, 15, 0, 20, 30, 50, 0, 7, 11, 15,
				0, 0, 30, 50, 20, 7, 17, 15, 0, 0,
				30, 50, 20, 7, 1, 10, 10, 20, 30, 50,
				0, 7, 2, 5, 0, 20, 30, 50, 0, 7,
				16, 5, 0, 20, 30, 50, 0
			}, new int[5] { 10, 0, 10, 10, 10 }, new string[9] { "0", "0", "1", "056e9dff-dea4-4e7b-8ef5-1756885b38ab", "30", "1", "f485dd24-143e-4376-9a3a-4b7045197e69", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[9] { 0, 0, 1, 5, -502, 1, 10, 0, 0 }, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "1", 2, 8, "", new int[4] { 0, 50, 7, 50 }, new int[57]
			{
				7, 7, 12, 35, 10, 10, 30, 50, 0, 7,
				10, 15, 0, 20, 30, 50, 0, 7, 11, 15,
				0, 0, 30, 50, 20, 7, 17, 15, 0, 0,
				30, 50, 20, 7, 1, 10, 10, 20, 30, 50,
				0, 7, 2, 5, 0, 20, 30, 50, 0, 7,
				16, 5, 0, 20, 30, 50, 0
			}, new int[5] { 10, 0, 10, 10, 10 }, new string[9] { "0", "0", "1", "056e9dff-dea4-4e7b-8ef5-1756885b38ab", "30", "1", "f485dd24-143e-4376-9a3a-4b7045197e69", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[9] { 0, 0, 1, 5, -502, 1, 10, 0, 0 }, new string[5] { "0", "0", "0", "0", "0" })
		}, new List<AdventureAdvancedBranch>
		{
			new AdventureAdvancedBranch(1, "", 1, 7, 150, new int[2] { 7, 100 }, new int[9] { 1, 7, 1, 100, 100, 0, 0, 0, 0 }, new int[5] { 0, 10, 10, 10, 10 }, new string[7] { "1", "2e859352-ee66-4375-82ac-60ac3f70a5e3", "100", "0", "0", "0", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray55 = _dataArray;
		string config109 = LocalStringManager.GetConfig("Adventure_language", "Name_114");
		string config110 = LocalStringManager.GetConfig("Adventure_language", "Desc_114");
		int[] resCost55 = new int[9];
		list = new List<int[]>();
		dataArray55.Add(new AdventureItem(114, config109, config110, 8, 5, 5, 1, 5, 6, resCost55, list, restrictedByWorldPopulation: false, new short[3], new List<(string, string, string, string)> { ("light", "LK_Adventure_99_ParamName_0", "", "") }, "231aa2c8-9cc7-4e3a-ad76-7a404caa9feb", new List<AdventureStartNode>
		{
			new AdventureStartNode("dddabf10-6139-4893-b425-b517fb8101f1", "A", "LK_Adventure_NodeTitle_391", 5)
		}, new List<AdventureTransferNode>
		{
			new AdventureTransferNode("358cb5f9-f6ba-447a-8e85-2cf6903e407e", "B", "LK_Adventure_NodeTitle_347", 10)
		}, new List<AdventureEndNode>
		{
			new AdventureEndNode("9d1707fd-2330-4327-a360-0e88e82bfb2a", "C", "LK_Adventure_NodeTitle_348", 5)
		}, new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 2, 7, "5b4b49df-e560-4d7d-9304-0a4ec95c5e51", new int[4] { 3, 50, 2, 50 }, new int[57]
			{
				7, 7, 4, 15, 10, 10, 10, 60, 10, 7,
				5, 35, 10, 10, 10, 60, 10, 7, 6, 10,
				10, 10, 10, 60, 10, 7, 1, 10, 10, 10,
				10, 60, 10, 7, 3, 5, 10, 10, 10, 60,
				10, 7, 11, 10, 10, 10, 10, 60, 10, 7,
				12, 15, 10, 10, 10, 60, 10
			}, new int[5] { 10, 0, 5, 20, 10 }, new string[7] { "0", "0", "0", "1", "c0449315-eedb-4725-9f6e-5d96d9a360f6", "50", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[9] { 0, 0, 1, 9, -901, 1, 10, 0, 0 }, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "1", 2, 8, "5b4b49df-e560-4d7d-9304-0a4ec95c5e51", new int[4] { 3, 50, 2, 50 }, new int[57]
			{
				7, 7, 4, 15, 10, 10, 10, 60, 10, 7,
				5, 35, 10, 10, 10, 60, 10, 7, 6, 10,
				10, 10, 10, 60, 10, 7, 1, 10, 10, 10,
				10, 60, 10, 7, 3, 5, 10, 10, 10, 60,
				10, 7, 11, 10, 10, 10, 10, 60, 10, 7,
				12, 15, 10, 10, 10, 60, 10
			}, new int[5] { 10, 0, 5, 20, 10 }, new string[7] { "0", "0", "0", "1", "95190f39-70b3-4b79-be2e-0e61093e9008", "50", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[9] { 0, 0, 1, 9, -901, 1, 10, 0, 0 }, new string[5] { "0", "0", "0", "0", "0" })
		}, new List<AdventureAdvancedBranch>
		{
			new AdventureAdvancedBranch(3, "", 1, 2, 150, new int[2] { 2, 100 }, new int[9] { 1, 7, 5, 100, 0, 0, 0, 100, 0 }, new int[5] { 10, 10, 10, 0, 10 }, new string[7] { "0", "0", "0", "1", "95190f39-70b3-4b79-be2e-0e61093e9008", "100", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray56 = _dataArray;
		string config111 = LocalStringManager.GetConfig("Adventure_language", "Name_115");
		string config112 = LocalStringManager.GetConfig("Adventure_language", "Desc_115");
		int[] resCost56 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost36 = list;
		short[] malice36 = new short[3];
		adventureParams = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams26 = adventureParams;
		List<AdventureStartNode> startNodes25 = new List<AdventureStartNode>
		{
			new AdventureStartNode("d39961a7-b7e8-4ba8-bc23-4c21438f3740", "A", "LK_Adventure_NodeTitle_349", 9)
		};
		transferNodes = new List<AdventureTransferNode>();
		List<AdventureTransferNode> transferNodes20 = transferNodes;
		List<AdventureEndNode> endNodes19 = new List<AdventureEndNode>
		{
			new AdventureEndNode("4b706858-534b-40af-a8cc-ed13bfe28838", "B", "LK_Adventure_NodeTitle_392", 10)
		};
		List<AdventureBaseBranch> baseBranches19 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 15, "", new int[4] { 5, 50, 1, 50 }, new int[49]
			{
				6, 7, 10, 40, 20, 60, 5, 5, 5, 7,
				12, 30, 20, 60, 5, 5, 5, 7, 5, 10,
				20, 60, 5, 5, 5, 7, 8, 10, 20, 60,
				5, 5, 5, 7, 9, 5, 20, 60, 5, 5,
				5, 7, 1, 5, 20, 60, 5, 5, 5
			}, new int[5] { 0, 20, 10, 10, 10 }, new string[7] { "0", "1", "8de964d7-4948-4a2f-9440-8076594cbd2c", "45", "0", "0", "0" }, new int[23]
			{
				3, 4, 120, 50, 4, 180, 30, 4, 240, 20,
				3, 8, 300, 5, 8, 450, 3, 8, 600, 2,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray56.Add(new AdventureItem(115, config111, config112, 8, 5, 5, 1, 5, 6, resCost56, itemCost36, restrictedByWorldPopulation: false, malice36, adventureParams26, "ab265b1c-bb63-42d1-a348-56fccd4702f2", startNodes25, transferNodes20, endNodes19, baseBranches19, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray57 = _dataArray;
		string config113 = LocalStringManager.GetConfig("Adventure_language", "Name_116");
		string config114 = LocalStringManager.GetConfig("Adventure_language", "Desc_116");
		int[] resCost57 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost37 = list;
		short[] malice37 = new short[3];
		adventureParams = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams27 = adventureParams;
		List<AdventureStartNode> startNodes26 = new List<AdventureStartNode>
		{
			new AdventureStartNode("53d50a56-ee1d-4480-a00f-e489ff224c71", "A", "LK_Adventure_NodeTitle_351", 9)
		};
		transferNodes = new List<AdventureTransferNode>();
		dataArray57.Add(new AdventureItem(116, config113, config114, 8, 5, 5, 1, 5, 6, resCost57, itemCost37, restrictedByWorldPopulation: false, malice37, adventureParams27, "51b57a15-a0bf-464c-bdbb-d9d2f29dd5ed", startNodes26, transferNodes, new List<AdventureEndNode>
		{
			new AdventureEndNode("55206e54-1104-48a6-b9b4-9ca3d59ed171", "B", "LK_Adventure_NodeTitle_352", 9)
		}, new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 15, "", new int[4] { 5, 50, 6, 50 }, new int[57]
			{
				7, 7, 9, 45, 60, 10, 10, 10, 10, 7,
				7, 5, 60, 10, 10, 10, 10, 7, 8, 10,
				60, 10, 10, 10, 10, 7, 13, 10, 60, 10,
				5, 10, 10, 7, 14, 5, 60, 10, 5, 10,
				10, 7, 15, 5, 60, 10, 5, 10, 10, 7,
				12, 20, 60, 10, 10, 10, 10
			}, new int[5] { 20, 0, 5, 10, 10 }, new string[17]
			{
				"6", "feb98fb7-365b-47a4-b411-b034b7c28064", "5", "eebe9454-133d-487c-ba6d-ec88dde7ced2", "5", "fcbe9d36-9d25-4202-8fdc-d871e47c8374", "5", "12f559d8-0d07-41ee-8b75-87183482ae7d", "5", "681e28ef-a9db-4fe8-9d32-bb24b8dff4aa",
				"5", "c2f0f550-c66b-44e4-a590-397cfaf444f2", "5", "0", "0", "0", "0"
			}, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[9] { 0, 0, 1, 5, -503, 1, 10, 0, 0 }, new string[5] { "0", "0", "0", "0", "0" })
		}, new List<AdventureAdvancedBranch>
		{
			new AdventureAdvancedBranch(2, "", 0, 6, 150, new int[2] { 5, 100 }, new int[9] { 1, 7, 10, 100, 0, 0, 0, 0, 100 }, new int[5] { 10, 10, 10, 10, 0 }, new string[7] { "0", "0", "0", "0", "1", "9298c0a7-34c4-4817-a9a9-d0f50059cf1d", "100" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray58 = _dataArray;
		string config115 = LocalStringManager.GetConfig("Adventure_language", "Name_117");
		string config116 = LocalStringManager.GetConfig("Adventure_language", "Desc_117");
		int[] resCost58 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost38 = list;
		short[] malice38 = new short[3];
		adventureParams = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams28 = adventureParams;
		List<AdventureStartNode> startNodes27 = new List<AdventureStartNode>
		{
			new AdventureStartNode("562529d7-89b5-44f2-aeee-016aeb40c3fc", "A", "LK_Adventure_NodeTitle_393", 12)
		};
		transferNodes = new List<AdventureTransferNode>();
		List<AdventureTransferNode> transferNodes21 = transferNodes;
		List<AdventureEndNode> endNodes20 = new List<AdventureEndNode>
		{
			new AdventureEndNode("c7508722-77a3-431e-8631-57de8fcc455d", "B", "LK_Adventure_NodeTitle_394", 10)
		};
		List<AdventureBaseBranch> baseBranches20 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 2, 15, "97ae8434-b8bf-4170-9cb5-aa1eb6afb23e", new int[4] { 15, 80, 4, 20 }, new int[57]
			{
				7, 7, 12, 35, 0, 10, 20, 60, 10, 7,
				10, 15, 10, 10, 20, 60, 0, 7, 11, 15,
				0, 10, 20, 60, 10, 7, 17, 15, 10, 0,
				20, 60, 10, 7, 1, 10, 10, 0, 20, 60,
				10, 7, 13, 5, 10, 10, 20, 60, 0, 7,
				16, 5, 10, 10, 20, 60, 0
			}, new int[5] { 10, 0, 30, 30, 0 }, new string[9] { "0", "0", "1", "8a4a9b40-5d76-468f-a943-6010b606be1a", "30", "1", "e6dc1905-2e6a-420c-8ca9-0c183c39650d", "30", "0" }, new int[23]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 3, 5, 120, 50, 5, 180, 30,
				5, 240, 20
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray58.Add(new AdventureItem(117, config115, config116, 8, 5, 5, 1, 5, 6, resCost58, itemCost38, restrictedByWorldPopulation: false, malice38, adventureParams28, "7fa626b4-8611-4921-8b14-627d20a5e546", startNodes27, transferNodes21, endNodes20, baseBranches20, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray59 = _dataArray;
		string config117 = LocalStringManager.GetConfig("Adventure_language", "Name_118");
		string config118 = LocalStringManager.GetConfig("Adventure_language", "Desc_118");
		int[] resCost59 = new int[9];
		list = new List<int[]>();
		dataArray59.Add(new AdventureItem(118, config117, config118, 8, 5, 5, 1, 5, 6, resCost59, list, restrictedByWorldPopulation: false, new short[3], new List<(string, string, string, string)>
		{
			("water", "LK_Adventure_103_ParamName_0", "", ""),
			("debuff", "LK_Adventure_103_ParamName_1", "", "")
		}, "0720c981-ed80-490b-8302-8aa75aaba1ca", new List<AdventureStartNode>
		{
			new AdventureStartNode("56f4d10a-869e-4e7b-bb01-eaaba5bb9549", "A", "LK_Adventure_NodeTitle_359", 9)
		}, new List<AdventureTransferNode>
		{
			new AdventureTransferNode("577e2b69-3249-4f51-84d8-8d70f1d26c8e", "B", "LK_Adventure_NodeTitle_360", 19),
			new AdventureTransferNode("e2155faa-e8f6-41aa-88fa-ba20a35d6afc", "C", "LK_Adventure_NodeTitle_361", 19)
		}, new List<AdventureEndNode>
		{
			new AdventureEndNode("dd6ecc2b-3d87-40a9-96b8-ff92c0eb84fa", "D", "LK_Adventure_NodeTitle_362", 19)
		}, new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 5, "7c0349a4-2c8b-452c-957a-4699ee8aa1fc", new int[4] { 4, 50, 15, 50 }, new int[49]
			{
				6, 7, 17, 10, 10, 5, 15, 40, 30, 7,
				1, 5, 10, 5, 15, 40, 30, 7, 18, 10,
				10, 5, 15, 40, 30, 7, 19, 60, 10, 5,
				15, 40, 30, 7, 8, 5, 10, 5, 15, 40,
				30, 7, 9, 5, 10, 5, 15, 40, 30
			}, new int[5] { 0, 0, 10, 0, 15 }, new string[15]
			{
				"0", "0", "0", "1", "41cec4f3-c597-4bdf-ae86-2165e81fbbbf", "40", "4", "7447052e-3798-45f3-96c7-ac1f756b9238", "20", "f8886f2d-d0ab-411e-9ec0-50582ba7ad52",
				"5", "a803ac4f-f193-42d6-8fd2-33dd91fd2cbc", "5", "3d46ddf9-a2ba-446a-898d-af20c3f7b0ad", "5"
			}, new int[23]
			{
				3, 3, 120, 50, 3, 180, 30, 3, 240, 20,
				3, 8, 300, 50, 8, 450, 30, 8, 600, 20,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "1", 1, 5, "7c0349a4-2c8b-452c-957a-4699ee8aa1fc", new int[4] { 4, 50, 15, 50 }, new int[49]
			{
				6, 7, 17, 10, 10, 5, 15, 40, 30, 7,
				1, 5, 10, 5, 15, 40, 30, 7, 18, 10,
				10, 5, 15, 40, 30, 7, 19, 60, 10, 5,
				15, 40, 30, 7, 8, 5, 10, 5, 15, 40,
				30, 7, 9, 5, 10, 5, 15, 40, 30
			}, new int[5] { 0, 0, 10, 0, 15 }, new string[15]
			{
				"0", "0", "0", "1", "41cec4f3-c597-4bdf-ae86-2165e81fbbbf", "40", "4", "7447052e-3798-45f3-96c7-ac1f756b9238", "20", "f8886f2d-d0ab-411e-9ec0-50582ba7ad52",
				"5", "a803ac4f-f193-42d6-8fd2-33dd91fd2cbc", "5", "3d46ddf9-a2ba-446a-898d-af20c3f7b0ad", "5"
			}, new int[23]
			{
				3, 3, 120, 50, 3, 180, 30, 3, 240, 20,
				3, 8, 300, 50, 8, 450, 30, 8, 600, 20,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 3, "1", 1, 5, "7c0349a4-2c8b-452c-957a-4699ee8aa1fc", new int[4] { 4, 50, 15, 50 }, new int[49]
			{
				6, 7, 17, 10, 10, 5, 15, 40, 30, 7,
				1, 5, 10, 5, 15, 40, 30, 7, 18, 10,
				10, 5, 15, 40, 30, 7, 19, 60, 10, 5,
				15, 40, 30, 7, 8, 5, 10, 5, 15, 40,
				30, 7, 9, 5, 10, 5, 15, 40, 30
			}, new int[5] { 0, 0, 10, 0, 15 }, new string[15]
			{
				"0", "0", "0", "1", "41cec4f3-c597-4bdf-ae86-2165e81fbbbf", "40", "4", "7447052e-3798-45f3-96c7-ac1f756b9238", "20", "f8886f2d-d0ab-411e-9ec0-50582ba7ad52",
				"5", "a803ac4f-f193-42d6-8fd2-33dd91fd2cbc", "5", "3d46ddf9-a2ba-446a-898d-af20c3f7b0ad", "5"
			}, new int[23]
			{
				3, 3, 120, 50, 3, 180, 30, 3, 240, 20,
				3, 8, 300, 50, 8, 450, 30, 8, 600, 20,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, new List<AdventureAdvancedBranch>
		{
			new AdventureAdvancedBranch(1, "", 0, 4, 150, new int[2] { 4, 100 }, new int[9] { 1, 7, 12, 100, 0, 0, 0, 0, 100 }, new int[5] { 10, 10, 10, 10, 0 }, new string[7] { "0", "0", "0", "0", "1", "c3405fe7-d0f2-4887-b1b6-8b816b778f3c", "100" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureAdvancedBranch(1, "", 1, 4, 150, new int[2] { 4, 100 }, new int[9] { 1, 7, 12, 100, 0, 0, 0, 0, 100 }, new int[5] { 10, 10, 10, 10, 0 }, new string[7] { "0", "0", "0", "0", "1", "c3405fe7-d0f2-4887-b1b6-8b816b778f3c", "100" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureAdvancedBranch(1, "", 2, 4, 150, new int[2] { 4, 100 }, new int[9] { 1, 7, 12, 100, 0, 0, 0, 0, 100 }, new int[5] { 10, 10, 10, 10, 0 }, new string[7] { "0", "0", "0", "0", "1", "c3405fe7-d0f2-4887-b1b6-8b816b778f3c", "100" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray60 = _dataArray;
		string config119 = LocalStringManager.GetConfig("Adventure_language", "Name_119");
		string config120 = LocalStringManager.GetConfig("Adventure_language", "Desc_119");
		int[] resCost60 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost39 = list;
		short[] malice39 = new short[3];
		adventureParams = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams29 = adventureParams;
		List<AdventureStartNode> startNodes28 = new List<AdventureStartNode>
		{
			new AdventureStartNode("faf21b51-d0c0-484d-9a63-91e01b15fa30", "A", "LK_Adventure_NodeTitle_364", 9)
		};
		List<AdventureTransferNode> transferNodes22 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("c081567d-8d97-4f76-8e6c-deaa15961549", "B", "LK_Adventure_NodeTitle_395", 9)
		};
		List<AdventureEndNode> endNodes21 = new List<AdventureEndNode>
		{
			new AdventureEndNode("578ba16b-48ca-4057-924e-e086b93fc114", "C", "LK_Adventure_NodeTitle_396", 9)
		};
		List<AdventureBaseBranch> baseBranches21 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 3, "4a57febb-86f4-463b-bac7-4df090350cae", new int[4] { 10, 50, 4, 50 }, new int[57]
			{
				7, 7, 9, 35, 5, 3, 5, 3, 3, 7,
				7, 5, 5, 3, 5, 3, 3, 7, 8, 10,
				5, 3, 5, 3, 3, 7, 13, 10, 5, 3,
				5, 3, 3, 7, 14, 10, 5, 3, 5, 3,
				3, 7, 15, 10, 5, 3, 5, 3, 3, 7,
				10, 20, 5, 3, 5, 3, 3
			}, new int[5] { 20, 20, 20, 20, 20 }, new string[19]
			{
				"2", "6a007c15-47e3-496f-bd54-a5ec2aa242a5", "10", "e2004b3e-80fa-441a-ba35-36f1f1097ed7", "10", "1", "ecfa7ed7-b2ff-4511-9a3a-55dd997de960", "20", "2", "57583b96-1fd7-4e6d-9305-ddcc9785294a",
				"10", "f67a4c88-09ab-4eb1-b0ec-ca35309d8298", "10", "1", "478720d8-1e18-4e13-9ff0-1b54ba3bf07a", "20", "1", "f4a428ca-e72a-4e0b-ac52-42e3dc1434c8", "20"
			}, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "1", 1, 12, "4a57febb-86f4-463b-bac7-4df090350cae", new int[4] { 10, 50, 4, 50 }, new int[57]
			{
				7, 7, 9, 35, 10, 5, 40, 40, 5, 7,
				7, 5, 5, 5, 40, 40, 10, 7, 8, 10,
				5, 5, 40, 40, 10, 7, 13, 10, 5, 5,
				40, 40, 10, 7, 14, 10, 5, 5, 40, 40,
				10, 7, 15, 10, 5, 5, 40, 40, 10, 7,
				10, 20, 5, 5, 40, 40, 10
			}, new int[5] { 10, 0, 30, 30, 10 }, new string[9] { "0", "0", "1", "643bdec7-abf1-4d4e-bad1-17b17b1df0f1", "30", "1", "643bdec7-abf1-4d4e-bad1-17b17b1df0f1", "30", "0" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[9] { 0, 0, 1, 5, -505, 1, 5, 0, 0 }, new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray60.Add(new AdventureItem(119, config119, config120, 8, 5, 5, 1, 5, 6, resCost60, itemCost39, restrictedByWorldPopulation: false, malice39, adventureParams29, "652857ed-ca33-4403-a835-46b77f08134d", startNodes28, transferNodes22, endNodes21, baseBranches21, advancedBranches, difficultyAddXiangshuLevel: false));
	}

	private void CreateItems2()
	{
		List<AdventureItem> dataArray = _dataArray;
		string config = LocalStringManager.GetConfig("Adventure_language", "Name_120");
		string config2 = LocalStringManager.GetConfig("Adventure_language", "Desc_120");
		int[] resCost = new int[9];
		List<int[]> itemCost = new List<int[]>();
		dataArray.Add(new AdventureItem(120, config, config2, 8, 5, 5, 1, 5, 6, resCost, itemCost, restrictedByWorldPopulation: false, new short[3], new List<(string, string, string, string)>
		{
			("zoon1", "LK_Adventure_105_ParamName_0", "", ""),
			("zoon2", "LK_Adventure_105_ParamName_1", "", ""),
			("zoon3", "LK_Adventure_105_ParamName_2", "", ""),
			("zoon4", "LK_Adventure_105_ParamName_3", "", ""),
			("zoon5", "LK_Adventure_105_ParamName_4", "", ""),
			("zoon6", "LK_Adventure_105_ParamName_5", "", ""),
			("zoon7", "LK_Adventure_105_ParamName_6", "", ""),
			("zoon8", "LK_Adventure_105_ParamName_7", "", ""),
			("zoon9", "LK_Adventure_105_ParamName_8", "", "")
		}, "58848e54-35ef-4507-b56a-322828bcc24c", new List<AdventureStartNode>
		{
			new AdventureStartNode("c73b32a8-6bc5-429c-912f-ee612640cd26", "A", "LK_Adventure_NodeTitle_377", 5)
		}, new List<AdventureTransferNode>
		{
			new AdventureTransferNode("63682fbe-6846-4acd-af7d-7b713bd68323", "B", "LK_Adventure_NodeTitle_378", 11)
		}, new List<AdventureEndNode>
		{
			new AdventureEndNode("9b506be9-1e73-4dc0-85a8-44beb3aed9ac", "C", "LK_Adventure_NodeTitle_379", 5),
			new AdventureEndNode("9b506be9-1e73-4dc0-85a8-44beb3aed9ac", "D", "LK_Adventure_NodeTitle_379", 5)
		}, new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 5, "", new int[6] { 14, 50, 8, 25, 9, 25 }, new int[57]
			{
				7, 7, 12, 25, 10, 10, 30, 60, 5, 7,
				10, 5, 10, 10, 30, 60, 5, 7, 11, 15,
				10, 10, 30, 60, 5, 7, 1, 10, 10, 10,
				30, 60, 5, 7, 4, 10, 10, 10, 30, 60,
				5, 7, 6, 15, 10, 10, 30, 60, 5, 7,
				5, 20, 10, 10, 30, 60, 5
			}, new int[5] { 0, 0, 10, 20, 10 }, new string[11]
			{
				"0", "0", "1", "c59dc523-74f4-4588-a436-2c248f71cf7f", "50", "2", "be0ae32b-31ec-4ca8-a268-19a89ad5ced3", "20", "cb348d28-2f6a-456b-a8d9-8fb9abbaa21e", "20",
				"0"
			}, new int[23]
			{
				3, 0, 120, 50, 0, 180, 30, 0, 240, 20,
				3, 8, 300, 50, 8, 450, 30, 8, 600, 20,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 1, 10, "", new int[6] { 14, 50, 8, 25, 9, 25 }, new int[57]
			{
				7, 7, 12, 25, 10, 10, 30, 60, 5, 7,
				10, 5, 10, 10, 30, 60, 5, 7, 11, 15,
				10, 10, 30, 60, 5, 7, 1, 10, 10, 10,
				30, 60, 5, 7, 4, 10, 10, 10, 30, 60,
				5, 7, 6, 15, 10, 10, 30, 60, 5, 7,
				5, 20, 10, 10, 30, 60, 5
			}, new int[5] { 0, 0, 10, 20, 10 }, new string[11]
			{
				"0", "0", "1", "c59dc523-74f4-4588-a436-2c248f71cf7f", "50", "2", "be0ae32b-31ec-4ca8-a268-19a89ad5ced3", "20", "cb348d28-2f6a-456b-a8d9-8fb9abbaa21e", "20",
				"0"
			}, new int[23]
			{
				3, 0, 120, 50, 0, 180, 30, 0, 240, 20,
				3, 8, 300, 50, 8, 450, 30, 8, 600, 20,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 3, "3", 1, 10, "", new int[6] { 14, 50, 8, 25, 9, 25 }, new int[57]
			{
				7, 7, 12, 25, 10, 10, 30, 60, 5, 7,
				10, 5, 10, 10, 30, 60, 5, 7, 11, 15,
				10, 10, 30, 60, 5, 7, 1, 10, 10, 10,
				30, 60, 5, 7, 4, 10, 10, 10, 30, 60,
				5, 7, 6, 15, 10, 10, 30, 60, 5, 7,
				5, 20, 10, 10, 30, 60, 5
			}, new int[5] { 0, 0, 10, 20, 10 }, new string[11]
			{
				"0", "0", "1", "c59dc523-74f4-4588-a436-2c248f71cf7f", "50", "2", "1cc2586b-db33-4af7-b959-9d29a90d134d", "20", "a2352a35-130c-4580-ad84-50eb9cf3f184", "20",
				"0"
			}, new int[23]
			{
				3, 0, 120, 50, 0, 180, 30, 0, 240, 20,
				3, 8, 300, 50, 8, 450, 30, 8, 600, 20,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, new List<AdventureAdvancedBranch>
		{
			new AdventureAdvancedBranch(3, "", 1, 14, 150, new int[2] { 14, 150 }, new int[9] { 1, 7, 11, 100, 0, 0, 0, 100, 0 }, new int[5] { 10, 10, 10, 0, 10 }, new string[7] { "0", "0", "0", "1", "be0ae32b-31ec-4ca8-a268-19a89ad5ced3", "100", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureAdvancedBranch(3, "", 2, 14, 150, new int[2] { 14, 150 }, new int[9] { 1, 7, 11, 100, 0, 0, 0, 100, 0 }, new int[5] { 10, 10, 10, 0, 10 }, new string[7] { "0", "0", "0", "1", "1cc2586b-db33-4af7-b959-9d29a90d134d", "100", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray2 = _dataArray;
		string config3 = LocalStringManager.GetConfig("Adventure_language", "Name_121");
		string config4 = LocalStringManager.GetConfig("Adventure_language", "Desc_121");
		int[] resCost2 = new int[9];
		itemCost = new List<int[]>();
		List<int[]> itemCost2 = itemCost;
		short[] malice = new short[3];
		List<(string, string, string, string)> list = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams = list;
		List<AdventureStartNode> startNodes = new List<AdventureStartNode>
		{
			new AdventureStartNode("4b94fa31-7053-4b2f-a00b-6c7f8ea040c2", "A", "LK_Adventure_NodeTitle_397", 9)
		};
		List<AdventureTransferNode> transferNodes = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("5463ec88-5b75-4f78-8928-0ac487e9f231", "B", "LK_Adventure_NodeTitle_380", 9),
			new AdventureTransferNode("da957c95-f4c6-4bf7-8b55-0680054993c1", "C", "LK_Adventure_NodeTitle_380", 9),
			new AdventureTransferNode("da957c95-f4c6-4bf7-8b55-0680054993c1", "D", "LK_Adventure_NodeTitle_380", 9),
			new AdventureTransferNode("da957c95-f4c6-4bf7-8b55-0680054993c1", "E", "LK_Adventure_NodeTitle_380", 9),
			new AdventureTransferNode("da957c95-f4c6-4bf7-8b55-0680054993c1", "F", "LK_Adventure_NodeTitle_380", 9),
			new AdventureTransferNode("da957c95-f4c6-4bf7-8b55-0680054993c1", "G", "LK_Adventure_NodeTitle_380", 9),
			new AdventureTransferNode("da957c95-f4c6-4bf7-8b55-0680054993c1", "H", "LK_Adventure_NodeTitle_380", 9),
			new AdventureTransferNode("da957c95-f4c6-4bf7-8b55-0680054993c1", "I", "LK_Adventure_NodeTitle_380", 9),
			new AdventureTransferNode("da957c95-f4c6-4bf7-8b55-0680054993c1", "J", "LK_Adventure_NodeTitle_380", 9),
			new AdventureTransferNode("da957c95-f4c6-4bf7-8b55-0680054993c1", "K", "LK_Adventure_NodeTitle_380", 9),
			new AdventureTransferNode("da957c95-f4c6-4bf7-8b55-0680054993c1", "L", "LK_Adventure_NodeTitle_380", 9),
			new AdventureTransferNode("da957c95-f4c6-4bf7-8b55-0680054993c1", "P", "LK_Adventure_NodeTitle_380", 9),
			new AdventureTransferNode("da957c95-f4c6-4bf7-8b55-0680054993c1", "O", "LK_Adventure_NodeTitle_380", 9),
			new AdventureTransferNode("da957c95-f4c6-4bf7-8b55-0680054993c1", "N", "LK_Adventure_NodeTitle_380", 9),
			new AdventureTransferNode("da957c95-f4c6-4bf7-8b55-0680054993c1", "M", "LK_Adventure_NodeTitle_380", 9),
			new AdventureTransferNode("da957c95-f4c6-4bf7-8b55-0680054993c1", "T", "LK_Adventure_NodeTitle_380", 9),
			new AdventureTransferNode("da957c95-f4c6-4bf7-8b55-0680054993c1", "S", "LK_Adventure_NodeTitle_380", 9),
			new AdventureTransferNode("da957c95-f4c6-4bf7-8b55-0680054993c1", "R", "LK_Adventure_NodeTitle_380", 9),
			new AdventureTransferNode("da957c95-f4c6-4bf7-8b55-0680054993c1", "Q", "LK_Adventure_NodeTitle_380", 9),
			new AdventureTransferNode("da957c95-f4c6-4bf7-8b55-0680054993c1", "U", "LK_Adventure_NodeTitle_380", 9),
			new AdventureTransferNode("da957c95-f4c6-4bf7-8b55-0680054993c1", "V", "LK_Adventure_NodeTitle_380", 9),
			new AdventureTransferNode("da957c95-f4c6-4bf7-8b55-0680054993c1", "W", "LK_Adventure_NodeTitle_380", 9),
			new AdventureTransferNode("da957c95-f4c6-4bf7-8b55-0680054993c1", "X", "LK_Adventure_NodeTitle_380", 9),
			new AdventureTransferNode("da957c95-f4c6-4bf7-8b55-0680054993c1", "Y", "LK_Adventure_NodeTitle_380", 9),
			new AdventureTransferNode("da957c95-f4c6-4bf7-8b55-0680054993c1", "Z", "LK_Adventure_NodeTitle_380", 9),
			new AdventureTransferNode("da957c95-f4c6-4bf7-8b55-0680054993c1", "AA", "LK_Adventure_NodeTitle_380", 9),
			new AdventureTransferNode("da957c95-f4c6-4bf7-8b55-0680054993c1", "AB", "LK_Adventure_NodeTitle_380", 9),
			new AdventureTransferNode("da957c95-f4c6-4bf7-8b55-0680054993c1", "AC", "LK_Adventure_NodeTitle_380", 9),
			new AdventureTransferNode("da957c95-f4c6-4bf7-8b55-0680054993c1", "AD", "LK_Adventure_NodeTitle_380", 9),
			new AdventureTransferNode("da957c95-f4c6-4bf7-8b55-0680054993c1", "AE", "LK_Adventure_NodeTitle_380", 9)
		};
		List<AdventureEndNode> endNodes = new List<AdventureEndNode>
		{
			new AdventureEndNode("744928c8-6d0c-4559-b6a4-bd5e765d70d9", "AF", "LK_Adventure_NodeTitle_380", 9)
		};
		List<AdventureBaseBranch> baseBranches = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 2, 3, "", new int[4] { 8, 50, 9, 50 }, new int[57]
			{
				7, 7, 9, 45, 10, 10, 10, 60, 10, 7,
				7, 5, 10, 10, 10, 60, 10, 7, 8, 5,
				10, 10, 10, 60, 10, 7, 13, 10, 10, 10,
				10, 60, 10, 7, 12, 15, 10, 10, 10, 60,
				10, 7, 10, 10, 10, 10, 10, 60, 10, 7,
				17, 10, 10, 10, 10, 60, 10
			}, new int[5] { 0, 0, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "17b3a67a-2b1c-480f-93cb-4d28de7d590f", "40", "0" }, new int[23]
			{
				3, 2, 120, 50, 2, 180, 30, 2, 250, 20,
				3, 8, 350, 50, 8, 450, 30, 8, 600, 20,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "1", 2, 3, "", new int[4] { 8, 50, 9, 50 }, new int[57]
			{
				7, 7, 9, 45, 10, 10, 10, 60, 10, 7,
				7, 5, 10, 10, 10, 60, 10, 7, 8, 5,
				10, 10, 10, 60, 10, 7, 13, 10, 10, 10,
				10, 60, 10, 7, 12, 15, 10, 10, 10, 60,
				10, 7, 10, 10, 10, 10, 10, 60, 10, 7,
				17, 10, 10, 10, 10, 60, 10
			}, new int[5] { 0, 0, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "17b3a67a-2b1c-480f-93cb-4d28de7d590f", "40", "0" }, new int[23]
			{
				3, 2, 120, 50, 2, 180, 30, 2, 250, 20,
				3, 8, 350, 50, 8, 450, 30, 8, 600, 20,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 3, "1", 2, 3, "", new int[4] { 8, 50, 9, 50 }, new int[57]
			{
				7, 7, 9, 45, 10, 10, 10, 60, 10, 7,
				7, 5, 10, 10, 10, 60, 10, 7, 8, 5,
				10, 10, 10, 60, 10, 7, 13, 10, 10, 10,
				10, 60, 10, 7, 12, 15, 10, 10, 10, 60,
				10, 7, 10, 10, 10, 10, 10, 60, 10, 7,
				17, 10, 10, 10, 10, 60, 10
			}, new int[5] { 0, 0, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "17b3a67a-2b1c-480f-93cb-4d28de7d590f", "40", "0" }, new int[23]
			{
				3, 2, 120, 50, 2, 180, 30, 2, 250, 20,
				3, 8, 350, 50, 8, 450, 30, 8, 600, 20,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 4, "1", 2, 3, "", new int[4] { 8, 50, 9, 50 }, new int[57]
			{
				7, 7, 9, 45, 10, 10, 10, 60, 10, 7,
				7, 5, 10, 10, 10, 60, 10, 7, 8, 5,
				10, 10, 10, 60, 10, 7, 13, 10, 10, 10,
				10, 60, 10, 7, 12, 15, 10, 10, 10, 60,
				10, 7, 10, 10, 10, 10, 10, 60, 10, 7,
				17, 10, 10, 10, 10, 60, 10
			}, new int[5] { 0, 0, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "17b3a67a-2b1c-480f-93cb-4d28de7d590f", "40", "0" }, new int[23]
			{
				3, 2, 120, 50, 2, 180, 30, 2, 250, 20,
				3, 8, 350, 50, 8, 450, 30, 8, 600, 20,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(4, 5, "1", 2, 3, "", new int[4] { 8, 50, 9, 50 }, new int[57]
			{
				7, 7, 9, 45, 10, 10, 10, 60, 10, 7,
				7, 5, 10, 10, 10, 60, 10, 7, 8, 5,
				10, 10, 10, 60, 10, 7, 13, 10, 10, 10,
				10, 60, 10, 7, 12, 15, 10, 10, 10, 60,
				10, 7, 10, 10, 10, 10, 10, 60, 10, 7,
				17, 10, 10, 10, 10, 60, 10
			}, new int[5] { 0, 0, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "17b3a67a-2b1c-480f-93cb-4d28de7d590f", "40", "0" }, new int[23]
			{
				3, 2, 120, 50, 2, 180, 30, 2, 250, 20,
				3, 8, 350, 50, 8, 450, 30, 8, 600, 20,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(5, 6, "1", 2, 3, "", new int[4] { 8, 50, 9, 50 }, new int[57]
			{
				7, 7, 9, 45, 10, 10, 10, 60, 10, 7,
				7, 5, 10, 10, 10, 60, 10, 7, 8, 5,
				10, 10, 10, 60, 10, 7, 13, 10, 10, 10,
				10, 60, 10, 7, 12, 15, 10, 10, 10, 60,
				10, 7, 10, 10, 10, 10, 10, 60, 10, 7,
				17, 10, 10, 10, 10, 60, 10
			}, new int[5] { 0, 0, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "17b3a67a-2b1c-480f-93cb-4d28de7d590f", "40", "0" }, new int[23]
			{
				3, 2, 120, 50, 2, 180, 30, 2, 250, 20,
				3, 8, 350, 50, 8, 450, 30, 8, 600, 20,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(6, 7, "1", 2, 3, "", new int[4] { 8, 50, 9, 50 }, new int[57]
			{
				7, 7, 9, 45, 10, 10, 10, 60, 10, 7,
				7, 5, 10, 10, 10, 60, 10, 7, 8, 5,
				10, 10, 10, 60, 10, 7, 13, 10, 10, 10,
				10, 60, 10, 7, 12, 15, 10, 10, 10, 60,
				10, 7, 10, 10, 10, 10, 10, 60, 10, 7,
				17, 10, 10, 10, 10, 60, 10
			}, new int[5] { 0, 0, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "17b3a67a-2b1c-480f-93cb-4d28de7d590f", "40", "0" }, new int[23]
			{
				3, 2, 120, 50, 2, 180, 30, 2, 250, 20,
				3, 8, 350, 50, 8, 450, 30, 8, 600, 20,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(7, 8, "1", 2, 3, "", new int[4] { 8, 50, 9, 50 }, new int[57]
			{
				7, 7, 9, 45, 10, 10, 10, 60, 10, 7,
				7, 5, 10, 10, 10, 60, 10, 7, 8, 5,
				10, 10, 10, 60, 10, 7, 13, 10, 10, 10,
				10, 60, 10, 7, 12, 15, 10, 10, 10, 60,
				10, 7, 10, 10, 10, 10, 10, 60, 10, 7,
				17, 10, 10, 10, 10, 60, 10
			}, new int[5] { 0, 0, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "17b3a67a-2b1c-480f-93cb-4d28de7d590f", "40", "0" }, new int[23]
			{
				3, 2, 120, 50, 2, 180, 30, 2, 250, 20,
				3, 8, 350, 50, 8, 450, 30, 8, 600, 20,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(8, 9, "1", 2, 3, "", new int[4] { 8, 50, 9, 50 }, new int[57]
			{
				7, 7, 9, 45, 10, 10, 10, 60, 10, 7,
				7, 5, 10, 10, 10, 60, 10, 7, 8, 5,
				10, 10, 10, 60, 10, 7, 13, 10, 10, 10,
				10, 60, 10, 7, 12, 15, 10, 10, 10, 60,
				10, 7, 10, 10, 10, 10, 10, 60, 10, 7,
				17, 10, 10, 10, 10, 60, 10
			}, new int[5] { 0, 0, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "17b3a67a-2b1c-480f-93cb-4d28de7d590f", "40", "0" }, new int[23]
			{
				3, 2, 120, 50, 2, 180, 30, 2, 250, 20,
				3, 8, 350, 50, 8, 450, 30, 8, 600, 20,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(9, 10, "1", 2, 3, "", new int[4] { 8, 50, 9, 50 }, new int[57]
			{
				7, 7, 9, 45, 10, 10, 10, 60, 10, 7,
				7, 5, 10, 10, 10, 60, 10, 7, 8, 5,
				10, 10, 10, 60, 10, 7, 13, 10, 10, 10,
				10, 60, 10, 7, 12, 15, 10, 10, 10, 60,
				10, 7, 10, 10, 10, 10, 10, 60, 10, 7,
				17, 10, 10, 10, 10, 60, 10
			}, new int[5] { 0, 0, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "17b3a67a-2b1c-480f-93cb-4d28de7d590f", "40", "0" }, new int[23]
			{
				3, 2, 120, 50, 2, 180, 30, 2, 250, 20,
				3, 8, 350, 50, 8, 450, 30, 8, 600, 20,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(10, 11, "1", 2, 3, "", new int[4] { 8, 50, 9, 50 }, new int[57]
			{
				7, 7, 9, 45, 10, 10, 10, 60, 10, 7,
				7, 5, 10, 10, 10, 60, 10, 7, 8, 5,
				10, 10, 10, 60, 10, 7, 13, 10, 10, 10,
				10, 60, 10, 7, 12, 15, 10, 10, 10, 60,
				10, 7, 10, 10, 10, 10, 10, 60, 10, 7,
				17, 10, 10, 10, 10, 60, 10
			}, new int[5] { 0, 0, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "17b3a67a-2b1c-480f-93cb-4d28de7d590f", "40", "0" }, new int[23]
			{
				3, 2, 120, 50, 2, 180, 30, 2, 250, 20,
				3, 8, 350, 50, 8, 450, 30, 8, 600, 20,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(11, 15, "1", 2, 3, "", new int[4] { 8, 50, 9, 50 }, new int[57]
			{
				7, 7, 9, 45, 10, 10, 10, 60, 10, 7,
				7, 5, 10, 10, 10, 60, 10, 7, 8, 5,
				10, 10, 10, 60, 10, 7, 13, 10, 10, 10,
				10, 60, 10, 7, 12, 15, 10, 10, 10, 60,
				10, 7, 10, 10, 10, 10, 10, 60, 10, 7,
				17, 10, 10, 10, 10, 60, 10
			}, new int[5] { 0, 0, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "17b3a67a-2b1c-480f-93cb-4d28de7d590f", "40", "0" }, new int[23]
			{
				3, 2, 120, 50, 2, 180, 30, 2, 250, 20,
				3, 8, 350, 50, 8, 450, 30, 8, 600, 20,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(15, 14, "1", 2, 3, "", new int[4] { 8, 50, 9, 50 }, new int[57]
			{
				7, 7, 9, 45, 10, 10, 10, 60, 10, 7,
				7, 5, 10, 10, 10, 60, 10, 7, 8, 5,
				10, 10, 10, 60, 10, 7, 13, 10, 10, 10,
				10, 60, 10, 7, 12, 15, 10, 10, 10, 60,
				10, 7, 10, 10, 10, 10, 10, 60, 10, 7,
				17, 10, 10, 10, 10, 60, 10
			}, new int[5] { 0, 0, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "17b3a67a-2b1c-480f-93cb-4d28de7d590f", "40", "0" }, new int[23]
			{
				3, 2, 120, 50, 2, 180, 30, 2, 250, 20,
				3, 8, 350, 50, 8, 450, 30, 8, 600, 20,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(14, 13, "1", 2, 3, "", new int[4] { 8, 50, 9, 50 }, new int[57]
			{
				7, 7, 9, 45, 10, 10, 10, 60, 10, 7,
				7, 5, 10, 10, 10, 60, 10, 7, 8, 5,
				10, 10, 10, 60, 10, 7, 13, 10, 10, 10,
				10, 60, 10, 7, 12, 15, 10, 10, 10, 60,
				10, 7, 10, 10, 10, 10, 10, 60, 10, 7,
				17, 10, 10, 10, 10, 60, 10
			}, new int[5] { 0, 0, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "17b3a67a-2b1c-480f-93cb-4d28de7d590f", "40", "0" }, new int[23]
			{
				3, 2, 120, 50, 2, 180, 30, 2, 250, 20,
				3, 8, 350, 50, 8, 450, 30, 8, 600, 20,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(13, 12, "1", 2, 3, "", new int[4] { 8, 50, 9, 50 }, new int[57]
			{
				7, 7, 9, 45, 10, 10, 10, 60, 10, 7,
				7, 5, 10, 10, 10, 60, 10, 7, 8, 5,
				10, 10, 10, 60, 10, 7, 13, 10, 10, 10,
				10, 60, 10, 7, 12, 15, 10, 10, 10, 60,
				10, 7, 10, 10, 10, 10, 10, 60, 10, 7,
				17, 10, 10, 10, 10, 60, 10
			}, new int[5] { 0, 0, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "17b3a67a-2b1c-480f-93cb-4d28de7d590f", "40", "0" }, new int[23]
			{
				3, 2, 120, 50, 2, 180, 30, 2, 250, 20,
				3, 8, 350, 50, 8, 450, 30, 8, 600, 20,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(12, 19, "1", 2, 3, "", new int[4] { 8, 50, 9, 50 }, new int[57]
			{
				7, 7, 9, 45, 10, 10, 10, 60, 10, 7,
				7, 5, 10, 10, 10, 60, 10, 7, 8, 5,
				10, 10, 10, 60, 10, 7, 13, 10, 10, 10,
				10, 60, 10, 7, 12, 15, 10, 10, 10, 60,
				10, 7, 10, 10, 10, 10, 10, 60, 10, 7,
				17, 10, 10, 10, 10, 60, 10
			}, new int[5] { 0, 0, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "17b3a67a-2b1c-480f-93cb-4d28de7d590f", "40", "0" }, new int[23]
			{
				3, 2, 120, 50, 2, 180, 30, 2, 250, 20,
				3, 8, 350, 50, 8, 450, 30, 8, 600, 20,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(19, 18, "1", 2, 3, "", new int[4] { 8, 50, 9, 50 }, new int[57]
			{
				7, 7, 9, 45, 10, 10, 10, 60, 10, 7,
				7, 5, 10, 10, 10, 60, 10, 7, 8, 5,
				10, 10, 10, 60, 10, 7, 13, 10, 10, 10,
				10, 60, 10, 7, 12, 15, 10, 10, 10, 60,
				10, 7, 10, 10, 10, 10, 10, 60, 10, 7,
				17, 10, 10, 10, 10, 60, 10
			}, new int[5] { 0, 0, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "17b3a67a-2b1c-480f-93cb-4d28de7d590f", "40", "0" }, new int[23]
			{
				3, 2, 120, 50, 2, 180, 30, 2, 250, 20,
				3, 8, 350, 50, 8, 450, 30, 8, 600, 20,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(18, 17, "1", 2, 3, "", new int[4] { 8, 50, 9, 50 }, new int[57]
			{
				7, 7, 9, 45, 10, 10, 10, 60, 10, 7,
				7, 5, 10, 10, 10, 60, 10, 7, 8, 5,
				10, 10, 10, 60, 10, 7, 13, 10, 10, 10,
				10, 60, 10, 7, 12, 15, 10, 10, 10, 60,
				10, 7, 10, 10, 10, 10, 10, 60, 10, 7,
				17, 10, 10, 10, 10, 60, 10
			}, new int[5] { 0, 0, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "17b3a67a-2b1c-480f-93cb-4d28de7d590f", "40", "0" }, new int[23]
			{
				3, 2, 120, 50, 2, 180, 30, 2, 250, 20,
				3, 8, 350, 50, 8, 450, 30, 8, 600, 20,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(17, 16, "1", 2, 3, "", new int[4] { 8, 50, 9, 50 }, new int[57]
			{
				7, 7, 9, 45, 10, 10, 10, 60, 10, 7,
				7, 5, 10, 10, 10, 60, 10, 7, 8, 5,
				10, 10, 10, 60, 10, 7, 13, 10, 10, 10,
				10, 60, 10, 7, 12, 15, 10, 10, 10, 60,
				10, 7, 10, 10, 10, 10, 10, 60, 10, 7,
				17, 10, 10, 10, 10, 60, 10
			}, new int[5] { 0, 0, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "17b3a67a-2b1c-480f-93cb-4d28de7d590f", "40", "0" }, new int[23]
			{
				3, 2, 120, 50, 2, 180, 30, 2, 250, 20,
				3, 8, 350, 50, 8, 450, 30, 8, 600, 20,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(16, 20, "1", 2, 3, "", new int[4] { 8, 50, 9, 50 }, new int[57]
			{
				7, 7, 9, 45, 10, 10, 10, 60, 10, 7,
				7, 5, 10, 10, 10, 60, 10, 7, 8, 5,
				10, 10, 10, 60, 10, 7, 13, 10, 10, 10,
				10, 60, 10, 7, 12, 15, 10, 10, 10, 60,
				10, 7, 10, 10, 10, 10, 10, 60, 10, 7,
				17, 10, 10, 10, 10, 60, 10
			}, new int[5] { 0, 0, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "17b3a67a-2b1c-480f-93cb-4d28de7d590f", "40", "0" }, new int[23]
			{
				3, 2, 120, 50, 2, 180, 30, 2, 250, 20,
				3, 8, 350, 50, 8, 450, 30, 8, 600, 20,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(20, 21, "1", 2, 3, "", new int[4] { 8, 50, 9, 50 }, new int[57]
			{
				7, 7, 9, 45, 10, 10, 10, 60, 10, 7,
				7, 5, 10, 10, 10, 60, 10, 7, 8, 5,
				10, 10, 10, 60, 10, 7, 13, 10, 10, 10,
				10, 60, 10, 7, 12, 15, 10, 10, 10, 60,
				10, 7, 10, 10, 10, 10, 10, 60, 10, 7,
				17, 10, 10, 10, 10, 60, 10
			}, new int[5] { 0, 0, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "17b3a67a-2b1c-480f-93cb-4d28de7d590f", "40", "0" }, new int[23]
			{
				3, 2, 120, 50, 2, 180, 30, 2, 250, 20,
				3, 8, 350, 50, 8, 450, 30, 8, 600, 20,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(21, 22, "1", 2, 3, "", new int[4] { 8, 50, 9, 50 }, new int[57]
			{
				7, 7, 9, 45, 10, 10, 10, 60, 10, 7,
				7, 5, 10, 10, 10, 60, 10, 7, 8, 5,
				10, 10, 10, 60, 10, 7, 13, 10, 10, 10,
				10, 60, 10, 7, 12, 15, 10, 10, 10, 60,
				10, 7, 10, 10, 10, 10, 10, 60, 10, 7,
				17, 10, 10, 10, 10, 60, 10
			}, new int[5] { 0, 0, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "17b3a67a-2b1c-480f-93cb-4d28de7d590f", "40", "0" }, new int[23]
			{
				3, 2, 120, 50, 2, 180, 30, 2, 250, 20,
				3, 8, 350, 50, 8, 450, 30, 8, 600, 20,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(22, 23, "1", 2, 3, "", new int[4] { 8, 50, 9, 50 }, new int[57]
			{
				7, 7, 9, 45, 10, 10, 10, 60, 10, 7,
				7, 5, 10, 10, 10, 60, 10, 7, 8, 5,
				10, 10, 10, 60, 10, 7, 13, 10, 10, 10,
				10, 60, 10, 7, 12, 15, 10, 10, 10, 60,
				10, 7, 10, 10, 10, 10, 10, 60, 10, 7,
				17, 10, 10, 10, 10, 60, 10
			}, new int[5] { 0, 0, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "17b3a67a-2b1c-480f-93cb-4d28de7d590f", "40", "0" }, new int[23]
			{
				3, 2, 120, 50, 2, 180, 30, 2, 250, 20,
				3, 8, 350, 50, 8, 450, 30, 8, 600, 20,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(23, 24, "1", 2, 3, "", new int[4] { 8, 50, 9, 50 }, new int[57]
			{
				7, 7, 9, 45, 10, 10, 10, 60, 10, 7,
				7, 5, 10, 10, 10, 60, 10, 7, 8, 5,
				10, 10, 10, 60, 10, 7, 13, 10, 10, 10,
				10, 60, 10, 7, 12, 15, 10, 10, 10, 60,
				10, 7, 10, 10, 10, 10, 10, 60, 10, 7,
				17, 10, 10, 10, 10, 60, 10
			}, new int[5] { 0, 0, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "17b3a67a-2b1c-480f-93cb-4d28de7d590f", "40", "0" }, new int[23]
			{
				3, 2, 120, 50, 2, 180, 30, 2, 250, 20,
				3, 8, 350, 50, 8, 450, 30, 8, 600, 20,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(24, 25, "1", 2, 3, "", new int[4] { 8, 50, 9, 50 }, new int[57]
			{
				7, 7, 9, 45, 10, 10, 10, 60, 10, 7,
				7, 5, 10, 10, 10, 60, 10, 7, 8, 5,
				10, 10, 10, 60, 10, 7, 13, 10, 10, 10,
				10, 60, 10, 7, 12, 15, 10, 10, 10, 60,
				10, 7, 10, 10, 10, 10, 10, 60, 10, 7,
				17, 10, 10, 10, 10, 60, 10
			}, new int[5] { 0, 0, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "17b3a67a-2b1c-480f-93cb-4d28de7d590f", "40", "0" }, new int[23]
			{
				3, 2, 120, 50, 2, 180, 30, 2, 250, 20,
				3, 8, 350, 50, 8, 450, 30, 8, 600, 20,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(25, 26, "1", 2, 3, "", new int[4] { 8, 50, 9, 50 }, new int[57]
			{
				7, 7, 9, 45, 10, 10, 10, 60, 10, 7,
				7, 5, 10, 10, 10, 60, 10, 7, 8, 5,
				10, 10, 10, 60, 10, 7, 13, 10, 10, 10,
				10, 60, 10, 7, 12, 15, 10, 10, 10, 60,
				10, 7, 10, 10, 10, 10, 10, 60, 10, 7,
				17, 10, 10, 10, 10, 60, 10
			}, new int[5] { 0, 0, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "17b3a67a-2b1c-480f-93cb-4d28de7d590f", "40", "0" }, new int[23]
			{
				3, 2, 120, 50, 2, 180, 30, 2, 250, 20,
				3, 8, 350, 50, 8, 450, 30, 8, 600, 20,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(26, 27, "1", 2, 3, "", new int[4] { 8, 50, 9, 50 }, new int[57]
			{
				7, 7, 9, 45, 10, 10, 10, 60, 10, 7,
				7, 5, 10, 10, 10, 60, 10, 7, 8, 5,
				10, 10, 10, 60, 10, 7, 13, 10, 10, 10,
				10, 60, 10, 7, 12, 15, 10, 10, 10, 60,
				10, 7, 10, 10, 10, 10, 10, 60, 10, 7,
				17, 10, 10, 10, 10, 60, 10
			}, new int[5] { 0, 0, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "17b3a67a-2b1c-480f-93cb-4d28de7d590f", "40", "0" }, new int[23]
			{
				3, 2, 120, 50, 2, 180, 30, 2, 250, 20,
				3, 8, 350, 50, 8, 450, 30, 8, 600, 20,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(27, 28, "1", 2, 3, "", new int[4] { 8, 50, 9, 50 }, new int[57]
			{
				7, 7, 9, 45, 10, 10, 10, 60, 10, 7,
				7, 5, 10, 10, 10, 60, 10, 7, 8, 5,
				10, 10, 10, 60, 10, 7, 13, 10, 10, 10,
				10, 60, 10, 7, 12, 15, 10, 10, 10, 60,
				10, 7, 10, 10, 10, 10, 10, 60, 10, 7,
				17, 10, 10, 10, 10, 60, 10
			}, new int[5] { 0, 0, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "17b3a67a-2b1c-480f-93cb-4d28de7d590f", "40", "0" }, new int[23]
			{
				3, 2, 120, 50, 2, 180, 30, 2, 250, 20,
				3, 8, 350, 50, 8, 450, 30, 8, 600, 20,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(28, 29, "1", 2, 3, "", new int[4] { 8, 50, 9, 50 }, new int[57]
			{
				7, 7, 9, 45, 10, 10, 10, 60, 10, 7,
				7, 5, 10, 10, 10, 60, 10, 7, 8, 5,
				10, 10, 10, 60, 10, 7, 13, 10, 10, 10,
				10, 60, 10, 7, 12, 15, 10, 10, 10, 60,
				10, 7, 10, 10, 10, 10, 10, 60, 10, 7,
				17, 10, 10, 10, 10, 60, 10
			}, new int[5] { 0, 0, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "17b3a67a-2b1c-480f-93cb-4d28de7d590f", "40", "0" }, new int[23]
			{
				3, 2, 120, 50, 2, 180, 30, 2, 250, 20,
				3, 8, 350, 50, 8, 450, 30, 8, 600, 20,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(29, 30, "1", 2, 3, "", new int[4] { 8, 50, 9, 50 }, new int[57]
			{
				7, 7, 9, 45, 10, 10, 10, 60, 10, 7,
				7, 5, 10, 10, 10, 60, 10, 7, 8, 5,
				10, 10, 10, 60, 10, 7, 13, 10, 10, 10,
				10, 60, 10, 7, 12, 15, 10, 10, 10, 60,
				10, 7, 10, 10, 10, 10, 10, 60, 10, 7,
				17, 10, 10, 10, 10, 60, 10
			}, new int[5] { 0, 0, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "17b3a67a-2b1c-480f-93cb-4d28de7d590f", "40", "0" }, new int[23]
			{
				3, 2, 120, 50, 2, 180, 30, 2, 250, 20,
				3, 8, 350, 50, 8, 450, 30, 8, 600, 20,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(30, 31, "1", 2, 3, "", new int[4] { 8, 50, 9, 50 }, new int[57]
			{
				7, 7, 9, 45, 10, 10, 10, 60, 10, 7,
				7, 5, 10, 10, 10, 60, 10, 7, 8, 5,
				10, 10, 10, 60, 10, 7, 13, 10, 10, 10,
				10, 60, 10, 7, 12, 15, 10, 10, 10, 60,
				10, 7, 10, 10, 10, 10, 10, 60, 10, 7,
				17, 10, 10, 10, 10, 60, 10
			}, new int[5] { 0, 0, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "17b3a67a-2b1c-480f-93cb-4d28de7d590f", "40", "0" }, new int[23]
			{
				3, 2, 120, 50, 2, 180, 30, 2, 250, 20,
				3, 8, 350, 50, 8, 450, 30, 8, 600, 20,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		List<AdventureAdvancedBranch> advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray2.Add(new AdventureItem(121, config3, config4, 8, 5, 5, 1, 5, 6, resCost2, itemCost2, restrictedByWorldPopulation: false, malice, adventureParams, "4fde459f-e5f3-42ff-8b6f-7c4462cfcd44", startNodes, transferNodes, endNodes, baseBranches, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray3 = _dataArray;
		string config5 = LocalStringManager.GetConfig("Adventure_language", "Name_122");
		string config6 = LocalStringManager.GetConfig("Adventure_language", "Desc_122");
		int[] resCost3 = new int[9];
		itemCost = new List<int[]>();
		List<int[]> itemCost3 = itemCost;
		short[] malice2 = new short[3];
		List<(string, string, string, string)> adventureParams2 = new List<(string, string, string, string)>
		{
			("Stone1", "LK_Adventure_122_ParamName_0", "", ""),
			("Stone2", "LK_Adventure_122_ParamName_1", "", ""),
			("Stone3", "LK_Adventure_122_ParamName_2", "", ""),
			("Stone4", "LK_Adventure_122_ParamName_3", "", ""),
			("Stone5", "LK_Adventure_122_ParamName_4", "", "")
		};
		List<AdventureStartNode> startNodes2 = new List<AdventureStartNode>
		{
			new AdventureStartNode("8586122e-6790-41d4-93a7-b3b9c3c4243c", "A", "LK_Adventure_NodeTitle_386", 4)
		};
		List<AdventureTransferNode> transferNodes2 = new List<AdventureTransferNode>();
		dataArray3.Add(new AdventureItem(122, config5, config6, 8, 5, 5, 1, 5, 6, resCost3, itemCost3, restrictedByWorldPopulation: false, malice2, adventureParams2, "23853969-2b4d-4160-82e0-1e38b716da47", startNodes2, transferNodes2, new List<AdventureEndNode>
		{
			new AdventureEndNode("61123250-69bf-4d54-948c-6aa8759641d7", "B", "LK_Adventure_NodeTitle_387", 4)
		}, new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 3, 15, "445089f7-000f-4634-8b4d-3e3f7f096944", new int[4] { 11, 50, 1, 50 }, new int[57]
			{
				7, 7, 4, 35, 10, 5, 5, 40, 40, 7,
				5, 15, 5, 10, 5, 40, 40, 7, 6, 10,
				10, 5, 5, 40, 40, 7, 2, 10, 5, 10,
				5, 40, 40, 7, 3, 5, 5, 10, 5, 40,
				40, 7, 11, 10, 5, 5, 10, 40, 40, 7,
				12, 15, 5, 5, 10, 40, 40
			}, new int[5] { 100, 0, 5, 30, 30 }, new string[9] { "0", "0", "0", "1", "23f24fd1-74f7-4ac3-a574-73aa2955bd51", "30", "1", "a512bb7e-a318-4247-9036-d04eb483e9ae", "30" }, new int[14]
			{
				0, 3, 8, 300, 50, 8, 450, 30, 8, 600,
				20, 0, 0, 0
			}, new int[9] { 0, 0, 1, 5, -504, 1, 10, 0, 0 }, new string[5] { "0", "0", "0", "0", "0" })
		}, new List<AdventureAdvancedBranch>
		{
			new AdventureAdvancedBranch(3, "", 0, 11, 150, new int[2] { 11, 100 }, new int[9] { 1, 7, 4, 100, 0, 0, 100, 0, 0 }, new int[5] { 10, 10, 0, 100, 10 }, new string[7] { "0", "0", "1", "a512bb7e-a318-4247-9036-d04eb483e9ae", "100", "0", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray4 = _dataArray;
		string config7 = LocalStringManager.GetConfig("Adventure_language", "Name_123");
		string config8 = LocalStringManager.GetConfig("Adventure_language", "Desc_123");
		int[] resCost4 = new int[9];
		itemCost = new List<int[]>();
		dataArray4.Add(new AdventureItem(123, config7, config8, 8, 5, 5, 1, 5, 6, resCost4, itemCost, restrictedByWorldPopulation: false, new short[3], new List<(string, string, string, string)> { ("support", "LK_Adventure_108_ParamName_0", "", "") }, "a432b93e-43c1-4b96-b239-76711244096a", new List<AdventureStartNode>
		{
			new AdventureStartNode("5f3feb96-3629-4386-865b-73224a96a01a", "A", "LK_Adventure_NodeTitle_389", 9)
		}, new List<AdventureTransferNode>
		{
			new AdventureTransferNode("fc731c0f-f68a-45af-9c2c-5404dc614759", "B", "LK_Adventure_NodeTitle_403", 4)
		}, new List<AdventureEndNode>
		{
			new AdventureEndNode("551bd909-5c90-4963-9066-39c5bfec730a", "C", "LK_Adventure_NodeTitle_316", 9)
		}, new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 3, 7, "", new int[8] { 0, 25, 1, 25, 2, 25, 3, 25 }, new int[57]
			{
				7, 7, 4, 25, 10, 60, 10, 10, 10, 7,
				5, 25, 10, 60, 10, 10, 10, 7, 6, 10,
				10, 60, 10, 10, 10, 7, 1, 10, 10, 60,
				10, 10, 10, 7, 8, 5, 10, 60, 10, 10,
				10, 7, 9, 10, 10, 60, 10, 10, 10, 7,
				12, 15, 10, 60, 10, 10, 10
			}, new int[5] { 0, 20, 10, 10, 10 }, new string[7] { "0", "1", "6816f5c8-f43d-4402-8131-bd294fa1b51f", "50", "0", "0", "0" }, new int[23]
			{
				3, 0, 120, 50, 0, 180, 30, 0, 240, 20,
				3, 8, 300, 5, 8, 450, 3, 8, 600, 2,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 3, 8, "", new int[8] { 0, 25, 1, 25, 2, 25, 3, 25 }, new int[57]
			{
				7, 7, 4, 25, 10, 50, 10, 20, 10, 7,
				5, 25, 10, 50, 10, 20, 10, 7, 6, 10,
				10, 50, 10, 20, 10, 7, 1, 10, 10, 50,
				10, 20, 10, 7, 8, 5, 10, 50, 10, 20,
				10, 7, 9, 10, 10, 50, 10, 20, 10, 7,
				12, 15, 10, 50, 10, 20, 10
			}, new int[5] { 0, 10, 10, 0, 10 }, new string[11]
			{
				"0", "1", "e118a9d7-d151-436c-89ce-79045a5ad505", "30", "0", "2", "e28cb4b0-dceb-43c4-ba1a-b251a9914645", "30", "bf1eec40-c81c-4d75-bed1-5043e3a2f055", "30",
				"0"
			}, new int[23]
			{
				3, 0, 120, 50, 0, 180, 30, 0, 250, 20,
				3, 8, 300, 5, 8, 450, 3, 8, 600, 2,
				0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, new List<AdventureAdvancedBranch>
		{
			new AdventureAdvancedBranch(3, "", 1, 1, 150, new int[2] { 1, 150 }, new int[9] { 1, 7, 4, 100, 0, 100, 0, 0, 0 }, new int[5] { 10, 0, 10, 10, 10 }, new string[7] { "0", "1", "33f2405f-95e8-4a41-ad72-25c3cf74a0ae", "100", "0", "0", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray5 = _dataArray;
		string config9 = LocalStringManager.GetConfig("Adventure_language", "Name_124");
		string config10 = LocalStringManager.GetConfig("Adventure_language", "Desc_124");
		int[] resCost5 = new int[9];
		itemCost = new List<int[]>();
		List<int[]> itemCost4 = itemCost;
		short[] malice3 = new short[3];
		List<(string, string, string, string)> adventureParams3 = new List<(string, string, string, string)>
		{
			("successRate", "LK_Adventure_124_ParamName_0", "", ""),
			("xiaoCounter", "LK_Adventure_124_ParamName_1", "", ""),
			("qinCounter", "LK_Adventure_124_ParamName_2", "", "")
		};
		List<AdventureStartNode> startNodes3 = new List<AdventureStartNode>
		{
			new AdventureStartNode("698d284a-f95f-4e60-9013-adc2c4bf571d", "A", "LK_Adventure_NodeTitle_407", 11),
			new AdventureStartNode("78863b43-58e0-4d46-b87b-d35cabeeaf60", "B", "LK_Adventure_NodeTitle_407", 11)
		};
		transferNodes2 = new List<AdventureTransferNode>();
		List<AdventureTransferNode> transferNodes3 = transferNodes2;
		List<AdventureEndNode> endNodes2 = new List<AdventureEndNode>
		{
			new AdventureEndNode("e787dbd9-3d47-4f22-a19a-f2cdd0cbebd2", "C", "LK_Adventure_NodeTitle_408", 11),
			new AdventureEndNode("e787dbd9-3d47-4f22-a19a-f2cdd0cbebd2", "D", "LK_Adventure_NodeTitle_408", 11)
		};
		List<AdventureBaseBranch> baseBranches2 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 2, "1", 1, 10, "", new int[2] { 14, 100 }, new int[41]
			{
				5, 7, 11, 50, 20, 10, 30, 35, 5, 7,
				12, 20, 20, 10, 30, 35, 5, 7, 1, 10,
				20, 10, 30, 35, 5, 7, 10, 10, 20, 10,
				30, 35, 5, 7, 17, 10, 20, 10, 30, 35,
				5
			}, new int[5], new string[15]
			{
				"1", "aaa5b414-e690-4942-aa38-f4b7ba6464b0", "500", "1", "148b7136-93e6-4564-bbd8-07a7a9b58ca8", "500", "1", "6ac9ae91-f1fe-4cfe-bc61-b07766a60292", "500", "1",
				"7031c9a4-8b3a-4558-8865-0d5509f2109b", "500", "1", "4f9c2e1f-7aa2-4db6-8a79-de51cba4a220", "500"
			}, new int[50]
			{
				3, 0, 120, 50, 0, 180, 30, 0, 240, 20,
				3, 0, 120, 50, 0, 180, 30, 0, 240, 20,
				3, 0, 120, 50, 0, 180, 30, 0, 240, 20,
				3, 0, 120, 50, 0, 180, 30, 0, 240, 20,
				3, 0, 120, 50, 0, 180, 30, 0, 240, 20
			}, new int[45]
			{
				2, 5, 63, 1, 200, 5, 66, 1, 200, 2,
				5, 63, 1, 200, 5, 67, 1, 200, 2, 5,
				63, 1, 200, 5, 65, 1, 200, 2, 5, 63,
				1, 200, 5, 64, 1, 200, 2, 5, 63, 1,
				200, 5, 68, 1, 200
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 3, "2", 1, 10, "", new int[2] { 14, 100 }, new int[41]
			{
				5, 7, 11, 50, 20, 10, 30, 35, 5, 7,
				12, 20, 20, 10, 30, 35, 5, 7, 1, 10,
				20, 10, 30, 35, 5, 7, 10, 10, 20, 10,
				30, 35, 5, 7, 17, 10, 20, 10, 30, 35,
				5
			}, new int[5], new string[15]
			{
				"1", "aaa5b414-e690-4942-aa38-f4b7ba6464b0", "500", "1", "148b7136-93e6-4564-bbd8-07a7a9b58ca8", "500", "1", "6ac9ae91-f1fe-4cfe-bc61-b07766a60292", "500", "1",
				"7031c9a4-8b3a-4558-8865-0d5509f2109b", "500", "1", "4f9c2e1f-7aa2-4db6-8a79-de51cba4a220", "500"
			}, new int[50]
			{
				3, 0, 120, 50, 0, 180, 30, 0, 240, 20,
				3, 0, 120, 50, 0, 180, 30, 0, 240, 20,
				3, 0, 120, 50, 0, 180, 30, 0, 240, 20,
				3, 0, 120, 50, 0, 180, 30, 0, 240, 20,
				3, 0, 120, 50, 0, 180, 30, 0, 240, 20
			}, new int[45]
			{
				2, 5, 63, 1, 200, 5, 66, 1, 200, 2,
				5, 63, 1, 200, 5, 67, 1, 200, 2, 5,
				63, 1, 200, 5, 65, 1, 200, 2, 5, 63,
				1, 200, 5, 64, 1, 200, 2, 5, 63, 1,
				200, 5, 68, 1, 200
			}, new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray5.Add(new AdventureItem(124, config9, config10, 9, 1, 5, 1, 5, 12, resCost5, itemCost4, restrictedByWorldPopulation: false, malice3, adventureParams3, "00cca1bf-b063-4e92-b681-d31afeee3932", startNodes3, transferNodes3, endNodes2, baseBranches2, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray6 = _dataArray;
		string config11 = LocalStringManager.GetConfig("Adventure_language", "Name_125");
		string config12 = LocalStringManager.GetConfig("Adventure_language", "Desc_125");
		int[] resCost6 = new int[9];
		itemCost = new List<int[]>();
		List<int[]> itemCost5 = itemCost;
		short[] malice4 = new short[3];
		List<(string, string, string, string)> adventureParams4 = new List<(string, string, string, string)> { ("successRate", "LK_Adventure_125_ParamName_0", "", "") };
		List<AdventureStartNode> startNodes4 = new List<AdventureStartNode>
		{
			new AdventureStartNode("f0a1debe-01fa-492e-88f6-ec0d72cb6784", "0", "LK_Adventure_NodeTitle_410", 17),
			new AdventureStartNode("96d474b9-daa1-4b37-bf59-fe7512783241", "1", "LK_Adventure_NodeTitle_410", 17)
		};
		transferNodes2 = new List<AdventureTransferNode>();
		List<AdventureTransferNode> transferNodes4 = transferNodes2;
		List<AdventureEndNode> endNodes3 = new List<AdventureEndNode>
		{
			new AdventureEndNode("6fb150fe-4715-494c-8c2c-6c7aed083cf8", "A", "LK_Adventure_NodeTitle_411", 11),
			new AdventureEndNode("6fb150fe-4715-494c-8c2c-6c7aed083cf8", "B", "LK_Adventure_NodeTitle_411", 11)
		};
		List<AdventureBaseBranch> baseBranches3 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 2, "A", 2, 10, "", new int[2] { 14, 100 }, new int[41]
			{
				5, 7, 12, 50, 20, 30, 10, 5, 35, 7,
				10, 20, 20, 30, 10, 5, 35, 7, 17, 10,
				20, 30, 10, 5, 35, 7, 11, 10, 20, 30,
				10, 5, 35, 7, 5, 10, 20, 30, 10, 5,
				35
			}, new int[5], new string[15]
			{
				"1", "1fa26de2-4792-4228-847d-77d2acaedd2f", "500", "1", "032b50b1-df46-4703-8440-53656b177503", "500", "1", "3e372e31-5fa4-4c5f-916d-b1ea5a956402", "500", "1",
				"b4674a29-2449-4086-aba8-db6f0411470b", "500", "1", "86ee1006-63da-4c0c-b584-f2a4be8fa02e", "500"
			}, new int[50]
			{
				3, 0, 120, 50, 0, 180, 30, 0, 240, 20,
				3, 0, 120, 50, 0, 180, 30, 0, 240, 20,
				3, 0, 120, 50, 0, 180, 30, 0, 240, 20,
				3, 0, 120, 50, 0, 180, 30, 0, 240, 20,
				3, 0, 120, 50, 0, 180, 30, 0, 240, 20
			}, new int[45]
			{
				2, 5, 70, 1, 200, 5, 73, 1, 200, 2,
				5, 70, 1, 200, 5, 72, 1, 200, 2, 5,
				70, 1, 200, 5, 74, 1, 200, 2, 5, 70,
				1, 200, 5, 75, 1, 200, 2, 5, 70, 1,
				200, 5, 71, 1, 200
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 3, "B", 2, 10, "", new int[2] { 14, 100 }, new int[41]
			{
				5, 7, 12, 50, 20, 30, 10, 5, 35, 7,
				10, 20, 20, 30, 10, 5, 35, 7, 17, 10,
				20, 30, 10, 5, 35, 7, 11, 10, 20, 30,
				10, 5, 35, 7, 5, 10, 20, 30, 10, 5,
				35
			}, new int[5], new string[15]
			{
				"1", "1fa26de2-4792-4228-847d-77d2acaedd2f", "500", "1", "032b50b1-df46-4703-8440-53656b177503", "500", "1", "3e372e31-5fa4-4c5f-916d-b1ea5a956402", "500", "1",
				"b4674a29-2449-4086-aba8-db6f0411470b", "500", "1", "86ee1006-63da-4c0c-b584-f2a4be8fa02e", "500"
			}, new int[50]
			{
				3, 0, 120, 50, 0, 180, 30, 0, 240, 20,
				3, 0, 120, 50, 0, 180, 30, 0, 240, 20,
				3, 0, 120, 50, 0, 180, 30, 0, 240, 20,
				3, 0, 120, 50, 0, 180, 30, 0, 240, 20,
				3, 0, 120, 50, 0, 180, 30, 0, 240, 20
			}, new int[45]
			{
				2, 5, 70, 1, 200, 5, 73, 1, 200, 2,
				5, 70, 1, 200, 5, 72, 1, 200, 2, 5,
				70, 1, 200, 5, 74, 1, 200, 2, 5, 70,
				1, 200, 5, 75, 1, 200, 2, 5, 70, 1,
				200, 5, 71, 1, 200
			}, new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray6.Add(new AdventureItem(125, config11, config12, 9, 1, 5, 1, 5, 12, resCost6, itemCost5, restrictedByWorldPopulation: false, malice4, adventureParams4, "041de42a-35ce-497e-9764-4cf5b0d57b0f", startNodes4, transferNodes4, endNodes3, baseBranches3, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray7 = _dataArray;
		string config13 = LocalStringManager.GetConfig("Adventure_language", "Name_126");
		string config14 = LocalStringManager.GetConfig("Adventure_language", "Desc_126");
		int[] resCost7 = new int[9];
		itemCost = new List<int[]>();
		List<int[]> itemCost6 = itemCost;
		short[] malice5 = new short[3];
		List<(string, string, string, string)> adventureParams5 = new List<(string, string, string, string)> { ("successRate", "LK_Adventure_126_ParamName_0", "", "") };
		List<AdventureStartNode> startNodes5 = new List<AdventureStartNode>
		{
			new AdventureStartNode("eda0e236-e29e-4b93-8cee-19ec761f6505", "A", "", 1),
			new AdventureStartNode("726dc601-09e9-4aaf-9454-d8a362af36f5", "B", "", 1)
		};
		transferNodes2 = new List<AdventureTransferNode>();
		List<AdventureTransferNode> transferNodes5 = transferNodes2;
		List<AdventureEndNode> endNodes4 = new List<AdventureEndNode>
		{
			new AdventureEndNode("82d96d2d-7945-4a86-88f8-44c063cf3b27", "C", "LK_Adventure_NodeTitle_413", 5),
			new AdventureEndNode("82d96d2d-7945-4a86-88f8-44c063cf3b27", "D", "LK_Adventure_NodeTitle_413", 5)
		};
		List<AdventureBaseBranch> baseBranches4 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 2, "1", 2, 10, "", new int[2] { 14, 100 }, new int[41]
			{
				5, 7, 1, 30, 5, 30, 35, 20, 10, 7,
				11, 20, 5, 30, 35, 20, 10, 7, 12, 20,
				5, 30, 35, 20, 10, 7, 5, 15, 5, 30,
				35, 20, 10, 7, 2, 15, 5, 30, 35, 20,
				10
			}, new int[5], new string[15]
			{
				"1", "b22b46ec-1d7f-4b12-b51d-bbe7c76e95c3", "500", "1", "64b9f85e-3502-49a5-baa2-d7dd387fecb4", "500", "1", "34704a3d-c5ed-4bf2-b68e-64a56c95d27f", "500", "1",
				"eca3b5fb-34fc-40fe-9c3d-086bdb193e02", "500", "1", "2e90ebb8-3a63-4bd2-99da-6b33a5c93df6", "500"
			}, new int[50]
			{
				3, 0, 120, 50, 0, 180, 30, 0, 240, 20,
				3, 0, 120, 50, 0, 180, 30, 0, 240, 20,
				3, 0, 120, 50, 0, 180, 30, 0, 240, 20,
				3, 0, 120, 50, 0, 180, 30, 0, 240, 20,
				3, 0, 120, 50, 0, 180, 30, 0, 240, 20
			}, new int[45]
			{
				2, 5, 56, 1, 200, 5, 61, 1, 200, 2,
				5, 56, 1, 200, 5, 58, 1, 200, 2, 5,
				56, 1, 200, 5, 57, 1, 200, 2, 5, 56,
				1, 200, 5, 59, 1, 200, 2, 5, 56, 1,
				200, 5, 60, 1, 200
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 3, "1", 2, 10, "", new int[2] { 14, 100 }, new int[41]
			{
				5, 7, 1, 30, 5, 30, 35, 20, 10, 7,
				11, 20, 5, 30, 35, 20, 10, 7, 12, 20,
				5, 30, 35, 20, 10, 7, 5, 15, 5, 30,
				35, 20, 10, 7, 2, 15, 5, 30, 35, 20,
				10
			}, new int[5], new string[15]
			{
				"1", "b22b46ec-1d7f-4b12-b51d-bbe7c76e95c3", "500", "1", "64b9f85e-3502-49a5-baa2-d7dd387fecb4", "500", "1", "34704a3d-c5ed-4bf2-b68e-64a56c95d27f", "500", "1",
				"eca3b5fb-34fc-40fe-9c3d-086bdb193e02", "500", "1", "2e90ebb8-3a63-4bd2-99da-6b33a5c93df6", "500"
			}, new int[50]
			{
				3, 0, 120, 50, 0, 180, 30, 0, 240, 20,
				3, 0, 120, 50, 0, 180, 30, 0, 240, 20,
				3, 0, 120, 50, 0, 180, 30, 0, 240, 20,
				3, 0, 120, 50, 0, 180, 30, 0, 240, 20,
				3, 0, 120, 50, 0, 180, 30, 0, 240, 20
			}, new int[45]
			{
				2, 5, 56, 1, 200, 5, 61, 1, 200, 2,
				5, 56, 1, 200, 5, 58, 1, 200, 2, 5,
				56, 1, 200, 5, 57, 1, 200, 2, 5, 56,
				1, 200, 5, 59, 1, 200, 2, 5, 56, 1,
				200, 5, 60, 1, 200
			}, new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray7.Add(new AdventureItem(126, config13, config14, 9, 1, 5, 1, 5, 12, resCost7, itemCost6, restrictedByWorldPopulation: false, malice5, adventureParams5, "3f1f0389-b205-49cb-8c62-5d5e6326ccc0", startNodes5, transferNodes5, endNodes4, baseBranches4, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray8 = _dataArray;
		string config15 = LocalStringManager.GetConfig("Adventure_language", "Name_127");
		string config16 = LocalStringManager.GetConfig("Adventure_language", "Desc_127");
		int[] resCost8 = new int[9];
		itemCost = new List<int[]>();
		List<int[]> itemCost7 = itemCost;
		short[] malice6 = new short[3];
		List<(string, string, string, string)> adventureParams6 = new List<(string, string, string, string)> { ("successRate", "LK_Adventure_127_ParamName_0", "", "") };
		List<AdventureStartNode> startNodes6 = new List<AdventureStartNode>
		{
			new AdventureStartNode("6dee76c6-447c-4e28-b7db-f1a746b5f8e9", "A", "LK_Adventure_NodeTitle_415", 4),
			new AdventureStartNode("c4ccbae7-eb7a-4887-824a-9caa48a46c96", "B", "LK_Adventure_NodeTitle_415", 4)
		};
		transferNodes2 = new List<AdventureTransferNode>();
		List<AdventureTransferNode> transferNodes6 = transferNodes2;
		List<AdventureEndNode> endNodes5 = new List<AdventureEndNode>
		{
			new AdventureEndNode("f111ee62-1b3a-4ad9-a64b-ca0fe974161f", "C", "LK_Adventure_NodeTitle_416", 4),
			new AdventureEndNode("f111ee62-1b3a-4ad9-a64b-ca0fe974161f", "D", "LK_Adventure_NodeTitle_416", 4)
		};
		List<AdventureBaseBranch> baseBranches5 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 2, "1", 2, 10, "", new int[2] { 14, 100 }, new int[41]
			{
				5, 7, 4, 30, 35, 10, 5, 20, 30, 7,
				6, 20, 35, 10, 5, 20, 30, 7, 5, 30,
				35, 10, 5, 20, 30, 7, 12, 10, 35, 10,
				5, 20, 30, 7, 22, 10, 35, 10, 5, 20,
				30
			}, new int[5], new string[15]
			{
				"1", "29f7e69e-95e3-4610-861a-33c5711286e7", "500", "1", "609cc9ca-c63d-4ad3-a218-c1a0a49c3fc1", "500", "1", "a99552e5-b3be-4cb4-b86b-9e20bf7b6b20", "500", "1",
				"1111b533-e971-4edc-ba5e-7f4e1db8ee24", "500", "1", "4ef099cd-948c-465e-9917-9811fa6da397", "500"
			}, new int[50]
			{
				3, 0, 120, 50, 0, 180, 30, 0, 240, 20,
				3, 0, 120, 50, 0, 180, 30, 0, 240, 20,
				3, 0, 120, 50, 0, 180, 30, 0, 240, 20,
				3, 0, 120, 50, 0, 180, 30, 0, 240, 20,
				3, 0, 120, 50, 0, 180, 30, 0, 240, 20
			}, new int[45]
			{
				2, 5, 77, 1, 200, 5, 78, 1, 200, 2,
				5, 77, 1, 200, 5, 81, 1, 200, 2, 5,
				77, 1, 200, 5, 82, 1, 200, 2, 5, 77,
				1, 200, 5, 80, 1, 200, 2, 5, 77, 1,
				200, 5, 79, 1, 200
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 3, "1", 2, 10, "", new int[2] { 14, 100 }, new int[41]
			{
				5, 7, 4, 30, 35, 10, 5, 20, 30, 7,
				6, 20, 35, 10, 5, 20, 30, 7, 5, 30,
				35, 10, 5, 20, 30, 7, 12, 10, 35, 10,
				5, 20, 30, 7, 22, 10, 35, 10, 5, 20,
				30
			}, new int[5], new string[15]
			{
				"1", "29f7e69e-95e3-4610-861a-33c5711286e7", "500", "1", "609cc9ca-c63d-4ad3-a218-c1a0a49c3fc1", "500", "1", "a99552e5-b3be-4cb4-b86b-9e20bf7b6b20", "500", "1",
				"1111b533-e971-4edc-ba5e-7f4e1db8ee24", "500", "1", "4ef099cd-948c-465e-9917-9811fa6da397", "500"
			}, new int[50]
			{
				3, 0, 120, 50, 0, 180, 30, 0, 240, 20,
				3, 0, 120, 50, 0, 180, 30, 0, 240, 20,
				3, 0, 120, 50, 0, 180, 30, 0, 240, 20,
				3, 0, 120, 50, 0, 180, 30, 0, 240, 20,
				3, 0, 120, 50, 0, 180, 30, 0, 240, 20
			}, new int[45]
			{
				2, 5, 77, 1, 200, 5, 78, 1, 200, 2,
				5, 77, 1, 200, 5, 81, 1, 200, 2, 5,
				77, 1, 200, 5, 82, 1, 200, 2, 5, 77,
				1, 200, 5, 80, 1, 200, 2, 5, 77, 1,
				200, 5, 79, 1, 200
			}, new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray8.Add(new AdventureItem(127, config15, config16, 9, 1, 5, 1, 5, 12, resCost8, itemCost7, restrictedByWorldPopulation: false, malice6, adventureParams6, "552b78a9-f2fd-4a12-b0e4-ade9934eb7d8", startNodes6, transferNodes6, endNodes5, baseBranches5, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray9 = _dataArray;
		string config17 = LocalStringManager.GetConfig("Adventure_language", "Name_128");
		string config18 = LocalStringManager.GetConfig("Adventure_language", "Desc_128");
		int[] resCost9 = new int[9];
		itemCost = new List<int[]>();
		List<int[]> itemCost8 = itemCost;
		short[] malice7 = new short[3];
		List<(string, string, string, string)> adventureParams7 = new List<(string, string, string, string)> { ("successRate", "LK_Adventure_128_ParamName_0", "", "") };
		List<AdventureStartNode> startNodes7 = new List<AdventureStartNode>
		{
			new AdventureStartNode("b605de0d-b011-426c-b90e-11fa85301e90", "A", "", 1),
			new AdventureStartNode("8b9b0ce1-aa45-44ed-aa9b-e8ecd160eee9", "B", "", 1)
		};
		transferNodes2 = new List<AdventureTransferNode>();
		List<AdventureTransferNode> transferNodes7 = transferNodes2;
		List<AdventureEndNode> endNodes6 = new List<AdventureEndNode>
		{
			new AdventureEndNode("b9204bea-0fdb-4822-b828-9e7309750075", "C", "LK_Adventure_NodeTitle_418", 1),
			new AdventureEndNode("b9204bea-0fdb-4822-b828-9e7309750075", "D", "LK_Adventure_NodeTitle_418", 1)
		};
		List<AdventureBaseBranch> baseBranches6 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 2, "1", 2, 10, "", new int[2] { 7, 100 }, new int[41]
			{
				5, 7, 1, 30, 20, 5, 65, 5, 5, 7,
				4, 30, 20, 5, 65, 5, 5, 7, 2, 10,
				20, 5, 65, 5, 5, 7, 3, 10, 20, 5,
				65, 5, 5, 7, 17, 20, 20, 5, 65, 5,
				5
			}, new int[5] { 0, 10, 20, 10, 10 }, new string[7] { "0", "0", "1", "24f13f65-fc2f-44cb-9859-a3d000c57d2c", "50", "0", "0" }, new int[14]
			{
				3, 1, 120, 50, 1, 180, 30, 1, 240, 20,
				0, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 3, "1", 2, 10, "", new int[2] { 7, 100 }, new int[41]
			{
				5, 7, 1, 30, 20, 5, 65, 5, 5, 7,
				4, 30, 20, 5, 65, 5, 5, 7, 2, 10,
				20, 5, 65, 5, 5, 7, 3, 10, 20, 5,
				65, 5, 5, 7, 17, 20, 20, 5, 65, 5,
				5
			}, new int[5] { 0, 10, 20, 10, 10 }, new string[7] { "0", "0", "1", "24f13f65-fc2f-44cb-9859-a3d000c57d2c", "50", "0", "0" }, new int[14]
			{
				3, 1, 120, 50, 1, 180, 30, 1, 240, 20,
				0, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray9.Add(new AdventureItem(128, config17, config18, 10, 1, 5, 1, 5, 12, resCost9, itemCost8, restrictedByWorldPopulation: false, malice7, adventureParams7, "ce13e8f6-0ab8-4aff-b293-52c09b845f46", startNodes7, transferNodes7, endNodes6, baseBranches6, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray10 = _dataArray;
		string config19 = LocalStringManager.GetConfig("Adventure_language", "Name_129");
		string config20 = LocalStringManager.GetConfig("Adventure_language", "Desc_129");
		int[] resCost10 = new int[9];
		itemCost = new List<int[]>();
		List<int[]> itemCost9 = itemCost;
		short[] malice8 = new short[3];
		List<(string, string, string, string)> adventureParams8 = new List<(string, string, string, string)> { ("successRate", "LK_Adventure_129_ParamName_0", "", "") };
		List<AdventureStartNode> startNodes8 = new List<AdventureStartNode>
		{
			new AdventureStartNode("5eac8c87-6e7b-4578-b1b2-45a9e4aaa7a2", "A", "", 11),
			new AdventureStartNode("cd20df70-95f0-4562-be83-37561f3fa168", "B", "", 11)
		};
		transferNodes2 = new List<AdventureTransferNode>();
		List<AdventureTransferNode> transferNodes8 = transferNodes2;
		List<AdventureEndNode> endNodes7 = new List<AdventureEndNode>
		{
			new AdventureEndNode("8c88183d-e182-45de-835e-71e61bc3db92", "C", "LK_Adventure_NodeTitle_420", 11),
			new AdventureEndNode("8c88183d-e182-45de-835e-71e61bc3db92", "D", "LK_Adventure_NodeTitle_420", 0)
		};
		List<AdventureBaseBranch> baseBranches7 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 2, "1", 2, 10, "", new int[2] { 7, 100 }, new int[41]
			{
				5, 7, 11, 50, 80, 5, 5, 5, 5, 7,
				12, 20, 80, 5, 5, 5, 5, 7, 1, 10,
				80, 5, 5, 5, 5, 7, 10, 10, 80, 5,
				5, 5, 5, 7, 17, 10, 80, 5, 5, 5,
				5
			}, new int[5] { 100, 10, 10, 10, 10 }, new string[7] { "1", "d3bbdab6-7edf-4847-9a5b-76e283a7ae51", "300", "0", "0", "0", "0" }, new int[14]
			{
				3, 1, 120, 25, 1, 180, 15, 1, 240, 10,
				0, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 3, "1", 2, 10, "", new int[2] { 7, 100 }, new int[41]
			{
				5, 7, 11, 50, 80, 5, 5, 5, 5, 7,
				12, 20, 80, 5, 5, 5, 5, 7, 1, 10,
				80, 5, 5, 5, 5, 7, 10, 10, 80, 5,
				5, 5, 5, 7, 17, 10, 80, 5, 5, 5,
				5
			}, new int[5] { 100, 10, 10, 10, 10 }, new string[7] { "1", "d3bbdab6-7edf-4847-9a5b-76e283a7ae51", "300", "0", "0", "0", "0" }, new int[14]
			{
				3, 1, 120, 25, 1, 180, 15, 1, 240, 10,
				0, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray10.Add(new AdventureItem(129, config19, config20, 10, 1, 5, 1, 5, 12, resCost10, itemCost9, restrictedByWorldPopulation: false, malice8, adventureParams8, "544abb5e-3037-4755-8819-31fff47f1b0a", startNodes8, transferNodes8, endNodes7, baseBranches7, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray11 = _dataArray;
		string config21 = LocalStringManager.GetConfig("Adventure_language", "Name_130");
		string config22 = LocalStringManager.GetConfig("Adventure_language", "Desc_130");
		int[] resCost11 = new int[9];
		itemCost = new List<int[]>();
		List<int[]> itemCost10 = itemCost;
		short[] malice9 = new short[3];
		List<(string, string, string, string)> adventureParams9 = new List<(string, string, string, string)> { ("successRate", "LK_Adventure_129_ParamName_0", "", "") };
		List<AdventureStartNode> startNodes9 = new List<AdventureStartNode>
		{
			new AdventureStartNode("ec0a9e2f-6b17-4544-99e8-f3e1c3eaefd7", "0", "LK_Adventure_NodeTitle_421", 3),
			new AdventureStartNode("848bdd39-9876-42b8-a76a-05f9104dae2c", "1", "LK_Adventure_NodeTitle_422", 3)
		};
		transferNodes2 = new List<AdventureTransferNode>();
		List<AdventureTransferNode> transferNodes9 = transferNodes2;
		List<AdventureEndNode> endNodes8 = new List<AdventureEndNode>
		{
			new AdventureEndNode("87f43f2d-d0c8-4f1f-a9c9-dc8d4b1d9fb1", "A", "LK_Adventure_NodeTitle_423", 3),
			new AdventureEndNode("87f43f2d-d0c8-4f1f-a9c9-dc8d4b1d9fb1", "B", "LK_Adventure_NodeTitle_423", 3)
		};
		List<AdventureBaseBranch> baseBranches8 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(1, 3, "B", 2, 10, "", new int[2] { 6, 100 }, new int[41]
			{
				5, 7, 3, 50, 20, 5, 5, 65, 5, 7,
				6, 10, 20, 5, 5, 65, 5, 7, 1, 20,
				20, 5, 5, 65, 5, 7, 21, 10, 20, 5,
				5, 65, 5, 7, 18, 10, 20, 5, 5, 65,
				5
			}, new int[5] { 0, 10, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "956901d7-ca35-4a5d-b844-a7ed15faaa72", "50", "0" }, new int[14]
			{
				3, 2, 120, 50, 2, 180, 30, 2, 240, 20,
				0, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(0, 2, "A", 2, 10, "", new int[2] { 6, 100 }, new int[41]
			{
				5, 7, 3, 50, 20, 5, 5, 65, 5, 7,
				6, 10, 20, 5, 5, 65, 5, 7, 1, 20,
				20, 5, 5, 65, 5, 7, 21, 10, 20, 5,
				5, 65, 5, 7, 18, 10, 20, 5, 5, 65,
				5
			}, new int[5] { 0, 10, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "956901d7-ca35-4a5d-b844-a7ed15faaa72", "50", "0" }, new int[14]
			{
				3, 2, 120, 50, 2, 180, 30, 2, 240, 20,
				0, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray11.Add(new AdventureItem(130, config21, config22, 11, 1, 5, 1, 5, 12, resCost11, itemCost10, restrictedByWorldPopulation: false, malice9, adventureParams9, "218c8a4c-877b-4e24-9bf5-759543940065", startNodes9, transferNodes9, endNodes8, baseBranches8, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray12 = _dataArray;
		string config23 = LocalStringManager.GetConfig("Adventure_language", "Name_131");
		string config24 = LocalStringManager.GetConfig("Adventure_language", "Desc_131");
		int[] resCost12 = new int[9];
		itemCost = new List<int[]>();
		List<int[]> itemCost11 = itemCost;
		short[] malice10 = new short[3];
		List<(string, string, string, string)> adventureParams10 = new List<(string, string, string, string)> { ("successRate", "LK_Adventure_131_ParamName_0", "", "") };
		List<AdventureStartNode> startNodes10 = new List<AdventureStartNode>
		{
			new AdventureStartNode("9e339426-1a82-4d7e-86b8-151925a0fe5c", "A", "", 1),
			new AdventureStartNode("ac665d85-e84a-4ab3-8f2e-41af0063e57e", "B", "", 1)
		};
		transferNodes2 = new List<AdventureTransferNode>();
		List<AdventureTransferNode> transferNodes10 = transferNodes2;
		List<AdventureEndNode> endNodes9 = new List<AdventureEndNode>
		{
			new AdventureEndNode("2c9a9214-4d1b-4710-a2f9-6a87e0ec668d", "C", "LK_Adventure_NodeTitle_425", 1),
			new AdventureEndNode("2c9a9214-4d1b-4710-a2f9-6a87e0ec668d", "D", "LK_Adventure_NodeTitle_425", 1)
		};
		List<AdventureBaseBranch> baseBranches9 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 2, "1", 2, 10, "", new int[2] { 6, 100 }, new int[41]
			{
				5, 7, 1, 30, 20, 5, 5, 65, 5, 7,
				22, 30, 20, 5, 5, 65, 5, 7, 2, 10,
				20, 5, 5, 65, 5, 7, 3, 10, 20, 5,
				5, 65, 5, 7, 18, 20, 20, 5, 5, 65,
				5
			}, new int[5] { 0, 10, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "5ca06fbb-9fb0-4246-8ad3-1b82dc384ca5", "50", "0" }, new int[14]
			{
				3, 2, 120, 50, 2, 180, 30, 2, 240, 20,
				0, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 3, "1", 2, 10, "", new int[2] { 6, 100 }, new int[41]
			{
				5, 7, 1, 30, 20, 5, 5, 65, 5, 7,
				22, 30, 20, 5, 5, 65, 5, 7, 2, 10,
				20, 5, 5, 65, 5, 7, 3, 10, 20, 5,
				5, 65, 5, 7, 18, 20, 20, 5, 5, 65,
				5
			}, new int[5] { 0, 10, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "5ca06fbb-9fb0-4246-8ad3-1b82dc384ca5", "50", "0" }, new int[14]
			{
				3, 2, 120, 50, 2, 180, 30, 2, 240, 20,
				0, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray12.Add(new AdventureItem(131, config23, config24, 11, 1, 5, 1, 5, 12, resCost12, itemCost11, restrictedByWorldPopulation: false, malice10, adventureParams10, "68bb6b3f-5e82-4905-86bf-3ee77c684522", startNodes10, transferNodes10, endNodes9, baseBranches9, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray13 = _dataArray;
		string config25 = LocalStringManager.GetConfig("Adventure_language", "Name_132");
		string config26 = LocalStringManager.GetConfig("Adventure_language", "Desc_132");
		int[] resCost13 = new int[9];
		itemCost = new List<int[]>();
		List<int[]> itemCost12 = itemCost;
		short[] malice11 = new short[3];
		List<(string, string, string, string)> adventureParams11 = new List<(string, string, string, string)> { ("successRate", "LK_Adventure_132_ParamName_0", "", "") };
		List<AdventureStartNode> startNodes11 = new List<AdventureStartNode>
		{
			new AdventureStartNode("541afb11-94fe-4ffa-9320-e06ecca1ae28", "A", "LK_Adventure_NodeTitle_427", 1),
			new AdventureStartNode("15c642c4-6347-40b6-ab21-bafbf98f46de", "B", "LK_Adventure_NodeTitle_428", 1)
		};
		transferNodes2 = new List<AdventureTransferNode>();
		List<AdventureTransferNode> transferNodes11 = transferNodes2;
		List<AdventureEndNode> endNodes10 = new List<AdventureEndNode>
		{
			new AdventureEndNode("fa71740f-1f69-4312-a076-88b2a2bb6510", "C", "LK_Adventure_NodeTitle_429", 1),
			new AdventureEndNode("fa71740f-1f69-4312-a076-88b2a2bb6510", "D", "LK_Adventure_NodeTitle_429", 0)
		};
		List<AdventureBaseBranch> baseBranches10 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 2, "1", 2, 10, "", new int[2] { 11, 100 }, new int[41]
			{
				5, 7, 1, 50, 20, 65, 5, 5, 5, 7,
				3, 20, 20, 65, 5, 5, 5, 7, 21, 10,
				20, 65, 5, 5, 5, 7, 2, 10, 20, 65,
				5, 5, 5, 7, 17, 10, 20, 65, 5, 5,
				5
			}, new int[5] { 0, 20, 10, 10, 10 }, new string[7] { "0", "1", "08d2deb0-34b7-4483-9d0e-f133005b1bad", "50", "0", "0", "0" }, new int[14]
			{
				3, 3, 120, 50, 3, 180, 30, 3, 240, 20,
				0, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 3, "2", 2, 10, "", new int[2] { 11, 100 }, new int[41]
			{
				5, 7, 1, 50, 20, 65, 5, 5, 5, 7,
				3, 20, 20, 65, 5, 5, 5, 7, 21, 10,
				20, 65, 5, 5, 5, 7, 2, 10, 20, 65,
				5, 5, 5, 7, 17, 10, 20, 65, 5, 5,
				5
			}, new int[5] { 0, 20, 10, 10, 10 }, new string[7] { "0", "1", "08d2deb0-34b7-4483-9d0e-f133005b1bad", "50", "0", "0", "0" }, new int[14]
			{
				3, 3, 120, 50, 3, 180, 30, 3, 240, 20,
				0, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray13.Add(new AdventureItem(132, config25, config26, 12, 1, 5, 1, 5, 12, resCost13, itemCost12, restrictedByWorldPopulation: false, malice11, adventureParams11, "d40d947b-586d-46df-90fe-11caaa088ab2", startNodes11, transferNodes11, endNodes10, baseBranches10, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray14 = _dataArray;
		string config27 = LocalStringManager.GetConfig("Adventure_language", "Name_133");
		string config28 = LocalStringManager.GetConfig("Adventure_language", "Desc_133");
		int[] resCost14 = new int[9];
		itemCost = new List<int[]>();
		List<int[]> itemCost13 = itemCost;
		short[] malice12 = new short[3];
		List<(string, string, string, string)> adventureParams12 = new List<(string, string, string, string)> { ("successRate", "LK_Adventure_133_ParamName_0", "", "") };
		List<AdventureStartNode> startNodes12 = new List<AdventureStartNode>
		{
			new AdventureStartNode("9a68c0ab-3f7b-4d24-80f3-1c65ddc249d6", "A", "", 1),
			new AdventureStartNode("0d4e908d-bff5-4eba-9e33-74d38c2de5a6", "B", "", 1)
		};
		transferNodes2 = new List<AdventureTransferNode>();
		List<AdventureTransferNode> transferNodes12 = transferNodes2;
		List<AdventureEndNode> endNodes11 = new List<AdventureEndNode>
		{
			new AdventureEndNode("437c4882-ab17-4227-85f5-6051f1653196", "C", "LK_Adventure_NodeTitle_431", 1)
		};
		List<AdventureBaseBranch> baseBranches11 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 2, "1", 2, 10, "", new int[2] { 11, 100 }, new int[41]
			{
				5, 7, 1, 50, 20, 65, 5, 5, 5, 7,
				3, 10, 20, 65, 5, 5, 5, 7, 21, 10,
				20, 65, 5, 5, 5, 7, 2, 20, 20, 65,
				5, 5, 5, 7, 17, 10, 20, 65, 5, 5,
				5
			}, new int[5] { 0, 20, 10, 10, 10 }, new string[7] { "0", "1", "a328a645-6e6a-4aab-950b-fdd2cd874663", "50", "0", "0", "0" }, new int[14]
			{
				3, 3, 120, 50, 3, 180, 30, 3, 240, 20,
				0, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 2, 10, "", new int[2] { 11, 100 }, new int[41]
			{
				5, 7, 1, 50, 20, 65, 5, 5, 5, 7,
				3, 10, 20, 65, 5, 5, 5, 7, 21, 10,
				20, 65, 5, 5, 5, 7, 2, 20, 20, 65,
				5, 5, 5, 7, 17, 10, 20, 65, 5, 5,
				5
			}, new int[5] { 0, 20, 10, 10, 10 }, new string[7] { "0", "1", "a328a645-6e6a-4aab-950b-fdd2cd874663", "50", "0", "0", "0" }, new int[14]
			{
				3, 3, 120, 50, 3, 180, 30, 3, 240, 20,
				0, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray14.Add(new AdventureItem(133, config27, config28, 12, 1, 5, 1, 5, 12, resCost14, itemCost13, restrictedByWorldPopulation: false, malice12, adventureParams12, "34522693-000c-487a-81a8-c7bb74496e2b", startNodes12, transferNodes12, endNodes11, baseBranches11, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray15 = _dataArray;
		string config29 = LocalStringManager.GetConfig("Adventure_language", "Name_134");
		string config30 = LocalStringManager.GetConfig("Adventure_language", "Desc_134");
		int[] resCost15 = new int[9];
		itemCost = new List<int[]>();
		List<int[]> itemCost14 = itemCost;
		short[] malice13 = new short[3];
		List<(string, string, string, string)> adventureParams13 = new List<(string, string, string, string)> { ("successRate", "LK_Adventure_134_ParamName_0", "", "") };
		List<AdventureStartNode> startNodes13 = new List<AdventureStartNode>
		{
			new AdventureStartNode("ad70bab7-e13a-4f25-a69d-579d31a72d86", "0", "", 12),
			new AdventureStartNode("5e7fc604-b3bc-4f31-892f-e8ccae93704e", "1", "", 12)
		};
		transferNodes2 = new List<AdventureTransferNode>();
		List<AdventureTransferNode> transferNodes13 = transferNodes2;
		List<AdventureEndNode> endNodes12 = new List<AdventureEndNode>
		{
			new AdventureEndNode("a17e9424-697c-4d3b-a8af-93cd31108dca", "A", "LK_Adventure_NodeTitle_433", 0),
			new AdventureEndNode("fecce8d6-dbad-4675-83f1-c9b3c134cc66", "B", "LK_Adventure_NodeTitle_433", 0)
		};
		List<AdventureBaseBranch> baseBranches12 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 2, "A", 2, 10, "", new int[2] { 10, 100 }, new int[41]
			{
				5, 7, 11, 50, 20, 5, 65, 5, 5, 7,
				12, 15, 20, 5, 65, 5, 5, 7, 10, 10,
				20, 5, 65, 5, 5, 7, 17, 5, 20, 5,
				65, 5, 5, 7, 5, 5, 20, 5, 65, 5,
				5
			}, new int[5] { 0, 10, 20, 10, 10 }, new string[7] { "0", "0", "1", "3d2f6943-b72c-46e2-8a9b-dcab0d3b73a5", "50", "0", "0" }, new int[14]
			{
				3, 4, 120, 50, 4, 180, 30, 4, 240, 20,
				0, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 3, "B", 2, 10, "", new int[2] { 10, 100 }, new int[41]
			{
				5, 7, 11, 50, 20, 5, 65, 5, 5, 7,
				12, 15, 20, 5, 65, 5, 5, 7, 10, 10,
				20, 5, 65, 5, 5, 7, 17, 5, 20, 5,
				65, 5, 5, 7, 5, 5, 20, 5, 65, 5,
				5
			}, new int[5] { 0, 10, 20, 10, 10 }, new string[7] { "0", "0", "1", "3d2f6943-b72c-46e2-8a9b-dcab0d3b73a5", "50", "0", "0" }, new int[14]
			{
				3, 4, 120, 50, 4, 180, 30, 4, 240, 20,
				0, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray15.Add(new AdventureItem(134, config29, config30, 13, 1, 5, 1, 5, 12, resCost15, itemCost14, restrictedByWorldPopulation: false, malice13, adventureParams13, "84039053-9a77-4c63-8e30-fbb7484a1a42", startNodes13, transferNodes13, endNodes12, baseBranches12, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray16 = _dataArray;
		string config31 = LocalStringManager.GetConfig("Adventure_language", "Name_135");
		string config32 = LocalStringManager.GetConfig("Adventure_language", "Desc_135");
		int[] resCost16 = new int[9];
		itemCost = new List<int[]>();
		List<int[]> itemCost15 = itemCost;
		short[] malice14 = new short[3];
		List<(string, string, string, string)> adventureParams14 = new List<(string, string, string, string)> { ("successRate", "LK_Adventure_135_ParamName_0", "", "") };
		List<AdventureStartNode> startNodes14 = new List<AdventureStartNode>
		{
			new AdventureStartNode("017a8d7a-8e62-4593-9d0d-da2e8c95a6f7", "0", "", 11),
			new AdventureStartNode("fb1bf8ee-69c7-4fa7-9488-59631acc9b29", "1", "", 11)
		};
		transferNodes2 = new List<AdventureTransferNode>();
		List<AdventureTransferNode> transferNodes14 = transferNodes2;
		List<AdventureEndNode> endNodes13 = new List<AdventureEndNode>
		{
			new AdventureEndNode("261178ac-f458-48da-90cc-5d9e4d45f62e", "A", "LK_Adventure_NodeTitle_435", 11),
			new AdventureEndNode("8201f243-ad33-44f5-bd88-f1e28dbdf972", "B", "LK_Adventure_NodeTitle_435", 11)
		};
		List<AdventureBaseBranch> baseBranches13 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 2, "A", 2, 10, "", new int[2] { 10, 100 }, new int[41]
			{
				5, 7, 11, 40, 20, 5, 65, 5, 5, 7,
				12, 20, 20, 5, 65, 5, 5, 7, 10, 20,
				20, 5, 65, 5, 5, 7, 17, 10, 20, 5,
				65, 5, 5, 7, 6, 10, 20, 5, 65, 5,
				5
			}, new int[5] { 0, 10, 20, 10, 10 }, new string[7] { "0", "0", "1", "42fa1c78-1805-41a1-9a18-8b47ce478db5", "50", "0", "0" }, new int[14]
			{
				3, 4, 120, 50, 4, 180, 30, 4, 240, 20,
				0, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 3, "B", 2, 10, "", new int[2] { 10, 100 }, new int[41]
			{
				5, 7, 11, 40, 20, 5, 65, 5, 5, 7,
				12, 20, 20, 5, 65, 5, 5, 7, 10, 20,
				20, 5, 65, 5, 5, 7, 17, 10, 20, 5,
				65, 5, 5, 7, 6, 10, 20, 5, 65, 5,
				5
			}, new int[5] { 0, 10, 20, 10, 10 }, new string[7] { "0", "0", "1", "42fa1c78-1805-41a1-9a18-8b47ce478db5", "50", "0", "0" }, new int[14]
			{
				3, 4, 120, 50, 4, 180, 30, 4, 240, 20,
				0, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray16.Add(new AdventureItem(135, config31, config32, 13, 1, 5, 1, 5, 12, resCost16, itemCost15, restrictedByWorldPopulation: false, malice14, adventureParams14, "d5328f9b-04ce-42fc-a939-1bb53c68a799", startNodes14, transferNodes14, endNodes13, baseBranches13, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray17 = _dataArray;
		string config33 = LocalStringManager.GetConfig("Adventure_language", "Name_136");
		string config34 = LocalStringManager.GetConfig("Adventure_language", "Desc_136");
		int[] resCost17 = new int[9];
		itemCost = new List<int[]>();
		List<int[]> itemCost16 = itemCost;
		short[] malice15 = new short[3];
		List<(string, string, string, string)> adventureParams15 = new List<(string, string, string, string)> { ("successRate", "LK_Adventure_136_ParamName_0", "adventure_icon_shouji", "") };
		List<AdventureStartNode> startNodes15 = new List<AdventureStartNode>
		{
			new AdventureStartNode("bce8223a-ebce-47bd-bbd7-0607ba3714dd", "A", "LK_Adventure_NodeTitle_437", 2)
		};
		List<AdventureTransferNode> transferNodes15 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("077a4a65-ba49-4781-8934-5f514d9b51aa", "B", "LK_Adventure_NodeTitle_438", 1),
			new AdventureTransferNode("5357457e-5de8-4fb9-a31f-3b9d457ae21e", "G", "LK_Adventure_NodeTitle_439", 2),
			new AdventureTransferNode("c9cc8da2-ac9e-43a5-bef2-479aeaf26863", "H", "LK_Adventure_NodeTitle_439", 2)
		};
		List<AdventureEndNode> endNodes14 = new List<AdventureEndNode>
		{
			new AdventureEndNode("096c0bcb-fd68-4696-90f0-5e100edb21d6", "C", "LK_Adventure_NodeTitle_440", 10),
			new AdventureEndNode("8399b5d2-b0ed-4788-9046-b7f49b72b549", "D", "LK_Adventure_NodeTitle_440", 11),
			new AdventureEndNode("3ba99a9a-66ed-42d0-9b78-2ca5f65ecbf5", "E", "LK_Adventure_NodeTitle_441", 17),
			new AdventureEndNode("a5ca4dd8-aec3-4805-aa6c-e20cfac61a3f", "F", "LK_Adventure_NodeTitle_441", 3)
		};
		List<AdventureBaseBranch> baseBranches14 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "2", 1, 2, "", new int[2] { 8, 100 }, new int[16]
			{
				5, 2, 1, 20, 2, 3, 20, 2, 5, 20,
				2, 10, 20, 2, 11, 20
			}, new int[5] { 0, 10, 10, 10, 10 }, new string[5] { "0", "0", "0", "0", "0" }, new int[14]
			{
				3, 5, 120, 50, 5, 180, 30, 5, 240, 20,
				0, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 4, "4", 1, 10, "359076f7-57cd-4df7-aabe-e07f30097e40", new int[2] { 8, 100 }, new int[41]
			{
				5, 7, 1, 20, 20, 5, 5, 65, 5, 7,
				3, 20, 20, 5, 5, 65, 5, 7, 5, 20,
				20, 5, 5, 65, 5, 7, 10, 20, 20, 5,
				5, 65, 5, 7, 11, 20, 20, 5, 5, 65,
				5
			}, new int[5] { 0, 10, 10, 40, 10 }, new string[7] { "0", "0", "0", "1", "26101156-00ff-47b7-aab0-712aa22491a5", "50", "0" }, new int[14]
			{
				3, 5, 120, 50, 5, 180, 30, 5, 240, 20,
				0, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 5, "5", 1, 10, "359076f7-57cd-4df7-aabe-e07f30097e40", new int[2] { 8, 100 }, new int[41]
			{
				5, 7, 1, 20, 20, 5, 5, 65, 5, 7,
				3, 20, 20, 5, 5, 65, 5, 7, 5, 20,
				20, 5, 5, 65, 5, 7, 10, 20, 20, 5,
				5, 65, 5, 7, 11, 20, 20, 5, 5, 65,
				5
			}, new int[5] { 0, 10, 10, 40, 10 }, new string[7] { "0", "0", "0", "1", "f4432d3d-53e3-40c2-aca0-46dcee82eb8f", "50", "0" }, new int[14]
			{
				3, 5, 120, 50, 5, 180, 30, 5, 240, 20,
				0, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 6, "6", 1, 10, "", new int[2] { 8, 100 }, new int[41]
			{
				5, 7, 1, 20, 20, 5, 5, 65, 5, 7,
				3, 20, 20, 5, 5, 65, 5, 7, 5, 20,
				20, 5, 5, 65, 5, 7, 10, 20, 20, 5,
				5, 65, 5, 7, 11, 20, 20, 5, 5, 65,
				5
			}, new int[5] { 0, 10, 10, 40, 10 }, new string[7] { "0", "0", "0", "1", "b7278903-4674-49cb-ada3-8451377ebc1c", "50", "0" }, new int[14]
			{
				3, 5, 120, 50, 5, 180, 30, 5, 240, 20,
				0, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 7, "7", 1, 10, "", new int[2] { 8, 100 }, new int[41]
			{
				5, 7, 1, 20, 20, 5, 5, 65, 5, 7,
				3, 20, 20, 5, 5, 65, 5, 7, 5, 20,
				20, 5, 5, 65, 5, 7, 10, 20, 20, 5,
				5, 65, 5, 7, 11, 20, 20, 5, 5, 65,
				5
			}, new int[5] { 0, 10, 10, 40, 10 }, new string[7] { "0", "0", "0", "1", "31fcfdde-b847-44d6-933b-96cc98bf1712", "50", "0" }, new int[14]
			{
				3, 5, 120, 50, 5, 180, 30, 5, 240, 20,
				0, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 3, "3", 1, 2, "", new int[2] { 8, 100 }, new int[16]
			{
				5, 2, 1, 20, 2, 3, 20, 2, 5, 20,
				2, 10, 20, 2, 11, 20
			}, new int[5] { 0, 10, 10, 10, 10 }, new string[5] { "0", "0", "0", "0", "0" }, new int[14]
			{
				3, 5, 120, 50, 5, 180, 30, 5, 240, 20,
				0, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 1, 2, "", new int[2] { 8, 100 }, new int[16]
			{
				5, 2, 1, 20, 2, 3, 20, 2, 5, 20,
				2, 10, 20, 2, 11, 20
			}, new int[5] { 0, 10, 10, 10, 10 }, new string[5] { "0", "0", "0", "0", "0" }, new int[14]
			{
				3, 5, 120, 50, 5, 180, 30, 5, 240, 20,
				0, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray17.Add(new AdventureItem(136, config33, config34, 14, 1, 5, 1, 5, 12, resCost17, itemCost16, restrictedByWorldPopulation: false, malice15, adventureParams15, "ad3d4a1c-a8f2-40a0-9d0b-71fb5d1d7eed", startNodes15, transferNodes15, endNodes14, baseBranches14, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray18 = _dataArray;
		string config35 = LocalStringManager.GetConfig("Adventure_language", "Name_137");
		string config36 = LocalStringManager.GetConfig("Adventure_language", "Desc_137");
		int[] resCost18 = new int[9];
		itemCost = new List<int[]>();
		List<int[]> itemCost17 = itemCost;
		short[] malice16 = new short[3];
		List<(string, string, string, string)> adventureParams16 = new List<(string, string, string, string)> { ("successRate", "LK_Adventure_137_ParamName_0", "adventure_icon_shouji", "") };
		List<AdventureStartNode> startNodes16 = new List<AdventureStartNode>
		{
			new AdventureStartNode("5ec3bbca-0960-4566-9c35-f24041b3e0bc", "A", "LK_Adventure_NodeTitle_443", 1)
		};
		List<AdventureTransferNode> transferNodes16 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("39385424-d6d6-4033-9653-8711ab9037a8", "B", "LK_Adventure_NodeTitle_444", 1)
		};
		List<AdventureEndNode> endNodes15 = new List<AdventureEndNode>
		{
			new AdventureEndNode("9df40c63-f4f6-48bf-b828-791caad7d5f1", "C", "LK_Adventure_NodeTitle_445", 11),
			new AdventureEndNode("d2a5ee24-a602-4b67-b3d6-8a4192d4f0d5", "D", "LK_Adventure_NodeTitle_446", 10),
			new AdventureEndNode("90df4d31-75ec-4f47-98a7-81f8713a3fa1", "E", "LK_Adventure_NodeTitle_447", 6)
		};
		List<AdventureBaseBranch> baseBranches15 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 2, "", new int[2] { 8, 100 }, new int[16]
			{
				5, 2, 1, 20, 2, 11, 20, 2, 10, 20,
				2, 6, 20, 2, 3, 20
			}, new int[5] { 0, 10, 10, 10, 10 }, new string[5] { "0", "0", "0", "0", "0" }, new int[14]
			{
				3, 5, 120, 50, 5, 180, 30, 5, 240, 20,
				0, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 1, 10, "", new int[2] { 8, 100 }, new int[9] { 1, 7, 11, 20, 20, 5, 5, 65, 5 }, new int[5] { 0, 10, 10, 40, 10 }, new string[7] { "0", "0", "0", "1", "9c56bfd0-9fee-47f7-8c4f-d4b5cba15caa", "50", "0" }, new int[14]
			{
				3, 5, 120, 50, 5, 180, 30, 5, 240, 20,
				0, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 3, "3", 1, 10, "", new int[2] { 8, 100 }, new int[9] { 1, 7, 10, 20, 20, 5, 5, 65, 5 }, new int[5] { 0, 10, 10, 40, 10 }, new string[7] { "0", "0", "0", "1", "f98ea3bd-fc84-4d6c-9973-7c93a1d723fa", "50", "0" }, new int[14]
			{
				3, 5, 120, 50, 5, 180, 30, 5, 240, 20,
				0, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 4, "4", 1, 10, "", new int[2] { 8, 100 }, new int[9] { 1, 7, 6, 20, 20, 5, 5, 65, 5 }, new int[5] { 0, 10, 10, 40, 10 }, new string[7] { "0", "0", "0", "1", "cb50f060-4f04-471f-bc6a-c4b7117575b6", "50", "0" }, new int[14]
			{
				3, 5, 120, 50, 5, 180, 30, 5, 240, 20,
				0, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray18.Add(new AdventureItem(137, config35, config36, 14, 1, 5, 1, 5, 12, resCost18, itemCost17, restrictedByWorldPopulation: false, malice16, adventureParams16, "631a16c1-111d-49c4-b08c-1504272c8ee2", startNodes16, transferNodes16, endNodes15, baseBranches15, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray19 = _dataArray;
		string config37 = LocalStringManager.GetConfig("Adventure_language", "Name_138");
		string config38 = LocalStringManager.GetConfig("Adventure_language", "Desc_138");
		int[] resCost19 = new int[9];
		itemCost = new List<int[]>();
		List<int[]> itemCost18 = itemCost;
		short[] malice17 = new short[3];
		List<(string, string, string, string)> adventureParams17 = new List<(string, string, string, string)> { ("successRate", "LK_Adventure_129_ParamName_0", "adventure_icon_shouji", "") };
		List<AdventureStartNode> startNodes17 = new List<AdventureStartNode>
		{
			new AdventureStartNode("82318721-9d21-45d5-9635-e97a39fe3e97", "A", "LK_Adventure_NodeTitle_448", 2)
		};
		List<AdventureTransferNode> transferNodes17 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("3817df55-556a-4cdf-ac59-0cc719de5f9e", "B", "LK_Adventure_NodeTitle_449", 2)
		};
		List<AdventureEndNode> endNodes16 = new List<AdventureEndNode>
		{
			new AdventureEndNode("8c2f49ae-4f8b-4a38-8b25-2f1dba129953", "C", "LK_Adventure_NodeTitle_450", 2),
			new AdventureEndNode("b5866080-c2f2-4ed4-8447-67f4499fb71b", "D", "LK_Adventure_NodeTitle_451", 11)
		};
		List<AdventureBaseBranch> baseBranches16 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 2, "", new int[2] { 8, 100 }, new int[4] { 1, 2, 3, 20 }, new int[5] { 0, 10, 10, 10, 10 }, new string[5] { "0", "0", "0", "0", "0" }, new int[14]
			{
				3, 5, 120, 50, 5, 180, 30, 5, 240, 20,
				0, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 1, 10, "a800df14-4101-4c53-b6f8-ee109db8f30b", new int[2] { 8, 100 }, new int[17]
			{
				2, 7, 2, 10, 20, 5, 5, 5, 65, 7,
				17, 10, 20, 5, 5, 5, 65
			}, new int[5] { 0, 10, 10, 10, 40 }, new string[7] { "0", "0", "0", "0", "1", "a97d2090-a91d-42b9-bc9f-daed80a7a28a", "50" }, new int[14]
			{
				3, 5, 120, 50, 5, 180, 30, 5, 240, 20,
				0, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 3, "3", 1, 10, "a800df14-4101-4c53-b6f8-ee109db8f30b", new int[2] { 8, 100 }, new int[17]
			{
				2, 7, 2, 10, 20, 5, 5, 5, 65, 7,
				17, 10, 20, 5, 5, 5, 65
			}, new int[5] { 0, 10, 10, 10, 40 }, new string[7] { "0", "0", "0", "0", "1", "f2ac4ac5-05f8-48f3-8b22-17be65bd9068", "50" }, new int[14]
			{
				3, 5, 120, 50, 5, 180, 30, 5, 240, 20,
				0, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray19.Add(new AdventureItem(138, config37, config38, 14, 1, 5, 1, 5, 12, resCost19, itemCost18, restrictedByWorldPopulation: false, malice17, adventureParams17, "6b861928-207d-415c-9d53-c2bffb5c2eea", startNodes17, transferNodes17, endNodes16, baseBranches16, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray20 = _dataArray;
		string config39 = LocalStringManager.GetConfig("Adventure_language", "Name_139");
		string config40 = LocalStringManager.GetConfig("Adventure_language", "Desc_139");
		int[] resCost20 = new int[9];
		itemCost = new List<int[]>();
		List<int[]> itemCost19 = itemCost;
		short[] malice18 = new short[3];
		List<(string, string, string, string)> adventureParams18 = new List<(string, string, string, string)>
		{
			("successRate1", "LK_Adventure_139_ParamName_0", "adventure_icon_shouji", ""),
			("successRate2", "LK_Adventure_139_ParamName_1", "adventure_icon_shouji", "")
		};
		List<AdventureStartNode> startNodes18 = new List<AdventureStartNode>
		{
			new AdventureStartNode("352c34ce-9d2b-41a0-8a64-a17abb65b7a6", "A", "LK_Adventure_NodeTitle_454", 2)
		};
		List<AdventureTransferNode> transferNodes18 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("db45a7c6-79d9-45f1-bc2b-443ecf8b2054", "B", "LK_Adventure_NodeTitle_455", 5)
		};
		List<AdventureEndNode> endNodes17 = new List<AdventureEndNode>
		{
			new AdventureEndNode("ffe97b00-a8b0-44c0-a9c0-6a85ffe0b2b6", "C", "LK_Adventure_NodeTitle_456", 18),
			new AdventureEndNode("79bfc177-00d6-42fb-9ec6-89d4064ca476", "D", "LK_Adventure_NodeTitle_456", 5)
		};
		List<AdventureBaseBranch> baseBranches17 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 3, "", new int[2] { 8, 100 }, new int[9] { 1, 7, 5, 20, 20, 5, 5, 5, 65 }, new int[5] { 0, 10, 10, 10, 10 }, new string[7] { "0", "0", "0", "0", "1", "c55f3e3f-5ffe-400c-9a26-c075ed4d60c5", "50" }, new int[14]
			{
				3, 5, 120, 50, 5, 180, 30, 5, 240, 20,
				0, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 1, 10, "", new int[2] { 8, 100 }, new int[17]
			{
				2, 7, 18, 20, 20, 5, 5, 5, 65, 7,
				5, 20, 20, 5, 5, 5, 65
			}, new int[5] { 0, 10, 10, 10, 40 }, new string[7] { "0", "0", "0", "0", "1", "4532e8dd-3b0c-46bf-bf14-3542effce527", "50" }, new int[14]
			{
				3, 5, 120, 50, 5, 180, 30, 5, 240, 20,
				0, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 3, "3", 1, 10, "", new int[2] { 8, 100 }, new int[17]
			{
				2, 7, 18, 20, 20, 5, 5, 5, 65, 7,
				5, 20, 20, 5, 5, 5, 65
			}, new int[5] { 0, 10, 10, 10, 40 }, new string[7] { "0", "0", "0", "0", "1", "114faa4d-0934-407f-bc97-e9cd036f4925", "50" }, new int[14]
			{
				3, 5, 120, 50, 5, 180, 30, 5, 240, 20,
				0, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray20.Add(new AdventureItem(139, config39, config40, 14, 1, 5, 1, 5, 12, resCost20, itemCost19, restrictedByWorldPopulation: false, malice18, adventureParams18, "bc307506-cc19-49af-b783-f0effb4c10f8", startNodes18, transferNodes18, endNodes17, baseBranches17, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray21 = _dataArray;
		string config41 = LocalStringManager.GetConfig("Adventure_language", "Name_140");
		string config42 = LocalStringManager.GetConfig("Adventure_language", "Desc_140");
		int[] resCost21 = new int[9];
		itemCost = new List<int[]>();
		List<int[]> itemCost20 = itemCost;
		short[] malice19 = new short[3];
		List<(string, string, string, string)> adventureParams19 = new List<(string, string, string, string)> { ("successRate", "LK_Adventure_137_ParamName_0", "adventure_icon_shouji", "") };
		List<AdventureStartNode> startNodes19 = new List<AdventureStartNode>
		{
			new AdventureStartNode("da131f2c-4170-4481-bf06-d9b2391f7fe9", "A", "LK_Adventure_NodeTitle_457", 2)
		};
		List<AdventureTransferNode> transferNodes19 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("c2144f99-a977-42d7-aa76-023530b97f5b", "B", "LK_Adventure_NodeTitle_458", 3),
			new AdventureTransferNode("eeb96243-1165-4b03-ad99-e27f43df43b3", "C", "LK_Adventure_NodeTitle_459", 1),
			new AdventureTransferNode("8c408eb5-04c4-4312-946b-5c50ba6c22eb", "D", "LK_Adventure_NodeTitle_460", 3)
		};
		List<AdventureEndNode> endNodes18 = new List<AdventureEndNode>
		{
			new AdventureEndNode("6e4c508d-2663-4756-bda3-bcedd8cf4c45", "E", "LK_Adventure_NodeTitle_461", 1),
			new AdventureEndNode("2973363a-eb1b-45c3-bc2c-91c51bc528af", "F", "LK_Adventure_NodeTitle_461", 1),
			new AdventureEndNode("413d689b-9395-4e39-906b-c897667543f7", "G", "LK_Adventure_NodeTitle_461", 1),
			new AdventureEndNode("d137f809-70bb-4f56-a8c7-0a62141e0952", "I", "LK_Adventure_NodeTitle_461", 3),
			new AdventureEndNode("f4ac1d76-eb30-40f3-9857-dbe50379ac29", "H", "LK_Adventure_NodeTitle_461", 3),
			new AdventureEndNode("5931374c-ea7f-42f9-8525-a9e28a3fd1ee", "K", "LK_Adventure_NodeTitle_461", 3)
		};
		List<AdventureBaseBranch> baseBranches18 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 2, "", new int[2] { 8, 100 }, new int[4] { 1, 2, 1, 20 }, new int[5] { 0, 10, 10, 10, 10 }, new string[5] { "0", "0", "0", "0", "0" }, new int[14]
			{
				3, 5, 120, 50, 5, 180, 30, 5, 240, 20,
				0, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "2", 1, 2, "", new int[2] { 8, 100 }, new int[4] { 1, 2, 1, 20 }, new int[5] { 0, 10, 10, 10, 10 }, new string[5] { "0", "0", "0", "0", "0" }, new int[14]
			{
				3, 5, 120, 50, 5, 180, 30, 5, 240, 20,
				0, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 3, "3", 1, 2, "", new int[2] { 8, 100 }, new int[4] { 1, 2, 1, 20 }, new int[5] { 0, 10, 10, 10, 10 }, new string[5] { "0", "0", "0", "0", "0" }, new int[14]
			{
				3, 5, 120, 50, 5, 180, 30, 5, 240, 20,
				0, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 4, "4", 1, 10, "", new int[2] { 8, 100 }, new int[9] { 1, 7, 1, 20, 20, 5, 65, 5, 5 }, new int[5] { 0, 10, 40, 10, 10 }, new string[7] { "0", "0", "1", "1c4536d3-b2f3-4dac-a2d4-54f35db2ca72", "50", "0", "0" }, new int[14]
			{
				3, 5, 120, 50, 5, 180, 20, 5, 240, 30,
				0, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 5, "5", 1, 10, "", new int[2] { 8, 100 }, new int[9] { 1, 7, 1, 20, 20, 5, 65, 5, 5 }, new int[5] { 0, 10, 40, 10, 10 }, new string[7] { "0", "0", "1", "5ddaf78b-07c9-49a6-a640-d26737321642", "50", "0", "0" }, new int[14]
			{
				3, 5, 120, 50, 5, 180, 20, 5, 240, 30,
				0, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 6, "6", 1, 10, "", new int[2] { 8, 100 }, new int[9] { 1, 7, 1, 20, 20, 5, 65, 5, 5 }, new int[5] { 0, 10, 40, 10, 10 }, new string[7] { "0", "0", "1", "0445c09e-b9da-48b6-9dcb-0989f2c538d5", "50", "0", "0" }, new int[14]
			{
				3, 5, 120, 50, 5, 180, 20, 5, 240, 30,
				0, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 8, "7", 1, 10, "", new int[2] { 8, 100 }, new int[9] { 1, 7, 1, 20, 20, 5, 65, 5, 5 }, new int[5] { 0, 10, 40, 10, 10 }, new string[7] { "0", "0", "1", "749b3438-5956-4532-9573-136256f0903b", "50", "0", "0" }, new int[14]
			{
				3, 5, 120, 50, 5, 180, 20, 5, 240, 30,
				0, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 7, "8", 1, 10, "", new int[2] { 8, 100 }, new int[9] { 1, 7, 1, 20, 20, 5, 65, 5, 5 }, new int[5] { 0, 10, 40, 10, 10 }, new string[7] { "0", "0", "1", "57ab7fb9-1248-4d14-a09c-17f535094310", "50", "0", "0" }, new int[14]
			{
				3, 5, 120, 50, 5, 180, 20, 5, 240, 30,
				0, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 9, "9", 1, 10, "", new int[2] { 8, 100 }, new int[9] { 1, 7, 1, 20, 20, 5, 65, 5, 5 }, new int[5] { 0, 10, 40, 10, 10 }, new string[7] { "0", "0", "1", "0f35e13d-1532-4f6f-b791-be9c2bc9a2a2", "50", "0", "0" }, new int[14]
			{
				3, 5, 120, 50, 5, 180, 20, 5, 240, 30,
				0, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray21.Add(new AdventureItem(140, config41, config42, 14, 1, 5, 1, 5, 12, resCost21, itemCost20, restrictedByWorldPopulation: false, malice19, adventureParams19, "6177465a-3e7c-4a07-9ca8-9d0473005612", startNodes19, transferNodes19, endNodes18, baseBranches18, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray22 = _dataArray;
		string config43 = LocalStringManager.GetConfig("Adventure_language", "Name_141");
		string config44 = LocalStringManager.GetConfig("Adventure_language", "Desc_141");
		int[] resCost22 = new int[9];
		itemCost = new List<int[]>();
		List<int[]> itemCost21 = itemCost;
		short[] malice20 = new short[3];
		List<(string, string, string, string)> adventureParams20 = new List<(string, string, string, string)> { ("successRate", "LK_Adventure_141_ParamName_0", "", "") };
		List<AdventureStartNode> startNodes20 = new List<AdventureStartNode>
		{
			new AdventureStartNode("99b1d094-02e7-4d23-91de-9edaef5c8f2e", "A", "", 12),
			new AdventureStartNode("a4cd69b4-a687-433a-8a9b-7cd42409704e", "B", "", 12)
		};
		transferNodes2 = new List<AdventureTransferNode>();
		List<AdventureTransferNode> transferNodes20 = transferNodes2;
		List<AdventureEndNode> endNodes19 = new List<AdventureEndNode>
		{
			new AdventureEndNode("408e68df-8a11-425d-8116-95688ca44c93", "C", "LK_Adventure_NodeTitle_463", 12),
			new AdventureEndNode("408e68df-8a11-425d-8116-95688ca44c93", "D", "LK_Adventure_NodeTitle_463", 12)
		};
		List<AdventureBaseBranch> baseBranches19 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 2, "1", 2, 10, "", new int[2] { 9, 100 }, new int[41]
			{
				5, 7, 11, 20, 20, 5, 5, 65, 5, 7,
				12, 40, 20, 5, 5, 65, 5, 7, 1, 10,
				20, 5, 5, 65, 5, 7, 5, 20, 20, 5,
				5, 65, 5, 7, 17, 10, 20, 5, 5, 65,
				5
			}, new int[5] { 0, 10, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "577309c0-a4ed-459e-bae2-be0e34f1ce4a", "50", "0" }, new int[14]
			{
				3, 5, 120, 50, 5, 180, 30, 5, 240, 20,
				0, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 3, "1", 2, 10, "", new int[2] { 9, 100 }, new int[41]
			{
				5, 7, 11, 20, 20, 5, 5, 65, 5, 7,
				12, 40, 20, 5, 5, 65, 5, 7, 1, 10,
				20, 5, 5, 65, 5, 7, 5, 20, 20, 5,
				5, 65, 5, 7, 17, 10, 20, 5, 5, 65,
				5
			}, new int[5] { 0, 10, 10, 20, 10 }, new string[7] { "0", "0", "0", "1", "577309c0-a4ed-459e-bae2-be0e34f1ce4a", "50", "0" }, new int[14]
			{
				3, 5, 120, 50, 5, 180, 30, 5, 240, 20,
				0, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray22.Add(new AdventureItem(141, config43, config44, 14, 1, 5, 1, 5, 12, resCost22, itemCost21, restrictedByWorldPopulation: false, malice20, adventureParams20, "d6039372-073f-47bb-b8e2-0220f91daa63", startNodes20, transferNodes20, endNodes19, baseBranches19, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray23 = _dataArray;
		string config45 = LocalStringManager.GetConfig("Adventure_language", "Name_142");
		string config46 = LocalStringManager.GetConfig("Adventure_language", "Desc_142");
		int[] resCost23 = new int[9];
		itemCost = new List<int[]>();
		List<int[]> itemCost22 = itemCost;
		short[] malice21 = new short[3];
		List<(string, string, string, string)> adventureParams21 = new List<(string, string, string, string)> { ("poison", "LK_Adventure_142_ParamName_0", "", "") };
		List<AdventureStartNode> startNodes21 = new List<AdventureStartNode>
		{
			new AdventureStartNode("af46ec85-538c-4f0b-90fe-4bd849403c47", "0", "LK_Adventure_NodeTitle_465", 11),
			new AdventureStartNode("cfea9bb7-7cc0-4e89-b323-40f7d2bfd004", "1", "LK_Adventure_NodeTitle_466", 11)
		};
		transferNodes2 = new List<AdventureTransferNode>();
		List<AdventureTransferNode> transferNodes21 = transferNodes2;
		List<AdventureEndNode> endNodes20 = new List<AdventureEndNode>
		{
			new AdventureEndNode("89efe84e-d2e1-4b32-9318-94a111c8f044", "A", "LK_Adventure_NodeTitle_467", 11)
		};
		List<AdventureBaseBranch> baseBranches20 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 2, "A", 2, 10, "151b25b7-41b9-4a4c-8742-86e036eafae2", new int[2] { 9, 100 }, new int[41]
			{
				5, 7, 1, 40, 20, 5, 5, 5, 65, 7,
				3, 30, 20, 5, 5, 5, 65, 7, 18, 10,
				20, 5, 5, 5, 65, 7, 2, 10, 20, 5,
				5, 5, 65, 7, 17, 10, 20, 5, 5, 5,
				65
			}, new int[5] { 0, 10, 10, 10, 20 }, new string[7] { "0", "0", "0", "0", "1", "9fd4064e-7b93-4128-9561-6bc0e4a32598", "50" }, new int[14]
			{
				3, 5, 120, 50, 5, 180, 30, 5, 240, 20,
				0, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "B", 2, 5, "151b25b7-41b9-4a4c-8742-86e036eafae2", new int[2] { 9, 100 }, new int[41]
			{
				5, 7, 1, 40, 20, 5, 5, 5, 65, 7,
				3, 30, 20, 5, 5, 5, 65, 7, 18, 10,
				20, 5, 5, 5, 65, 7, 2, 10, 20, 5,
				5, 5, 65, 7, 17, 10, 20, 5, 5, 5,
				65
			}, new int[5] { 0, 10, 10, 10, 20 }, new string[7] { "0", "0", "0", "0", "1", "9fd4064e-7b93-4128-9561-6bc0e4a32598", "50" }, new int[14]
			{
				3, 5, 120, 50, 5, 180, 30, 5, 240, 20,
				0, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray23.Add(new AdventureItem(142, config45, config46, 14, 1, 5, 1, 5, 12, resCost23, itemCost22, restrictedByWorldPopulation: false, malice21, adventureParams21, "6c1a76fb-110e-4b02-92c7-4d42f04799d5", startNodes21, transferNodes21, endNodes20, baseBranches20, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray24 = _dataArray;
		string config47 = LocalStringManager.GetConfig("Adventure_language", "Name_143");
		string config48 = LocalStringManager.GetConfig("Adventure_language", "Desc_143");
		int[] resCost24 = new int[9];
		itemCost = new List<int[]>();
		List<int[]> itemCost23 = itemCost;
		short[] malice22 = new short[3];
		List<(string, string, string, string)> adventureParams22 = new List<(string, string, string, string)> { ("successRate", "LK_Adventure_143_ParamName_0", "", "") };
		List<AdventureStartNode> startNodes22 = new List<AdventureStartNode>
		{
			new AdventureStartNode("b62119db-3f5f-4e1e-a99f-8a40b2562b0e", "0", "LK_Adventure_NodeTitle_469", 2),
			new AdventureStartNode("69a5c686-1695-4185-b542-9d8e7e689a1d", "1", "LK_Adventure_NodeTitle_469", 6)
		};
		List<AdventureTransferNode> transferNodes22 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("1c2f7af8-656b-49a1-9305-2eb81091b0e8", "C", "LK_Adventure_NodeTitle_470", 0)
		};
		List<AdventureEndNode> endNodes21 = new List<AdventureEndNode>
		{
			new AdventureEndNode("a041e4ef-1723-4372-928c-22eec8ce4723", "A", "LK_Adventure_NodeTitle_471", 0)
		};
		List<AdventureBaseBranch> baseBranches21 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 2, "1", 1, 8, "", new int[2] { 9, 100 }, new int[41]
			{
				5, 7, 17, 50, 80, 5, 5, 5, 5, 7,
				11, 20, 80, 5, 5, 5, 5, 7, 12, 10,
				80, 5, 5, 5, 5, 7, 6, 10, 80, 5,
				5, 5, 5, 7, 18, 10, 80, 5, 5, 5,
				5
			}, new int[5] { 35, 10, 10, 10, 10 }, new string[7] { "1", "fa8eee33-e4b6-434b-b1fd-a34cd4f7828b", "100", "0", "0", "0", "0" }, new int[14]
			{
				3, 5, 120, 25, 5, 180, 15, 5, 240, 10,
				0, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 3, "1", 2, 12, "", new int[2] { 9, 100 }, new int[41]
			{
				5, 7, 17, 50, 80, 5, 5, 5, 5, 7,
				11, 20, 80, 5, 5, 5, 5, 7, 12, 10,
				80, 5, 5, 5, 5, 7, 6, 10, 80, 5,
				5, 5, 5, 7, 18, 10, 80, 5, 5, 5,
				5
			}, new int[5] { 100, 10, 10, 10, 10 }, new string[5] { "0", "0", "0", "0", "0" }, new int[14]
			{
				3, 5, 120, 50, 5, 180, 30, 5, 240, 20,
				0, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "1", 1, 8, "", new int[2] { 9, 100 }, new int[41]
			{
				5, 7, 17, 50, 80, 5, 5, 5, 5, 7,
				11, 20, 80, 5, 5, 5, 5, 7, 12, 10,
				80, 5, 5, 5, 5, 7, 6, 10, 80, 5,
				5, 5, 5, 7, 18, 10, 80, 5, 5, 5,
				5
			}, new int[5] { 35, 10, 10, 10, 10 }, new string[7] { "1", "fa8eee33-e4b6-434b-b1fd-a34cd4f7828b", "100", "0", "0", "0", "0" }, new int[14]
			{
				3, 5, 120, 25, 5, 180, 15, 5, 240, 10,
				0, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray24.Add(new AdventureItem(143, config47, config48, 14, 1, 5, 1, 5, 12, resCost24, itemCost23, restrictedByWorldPopulation: false, malice22, adventureParams22, "29a50976-414c-4c8a-bc25-d0ae6c48a321", startNodes22, transferNodes22, endNodes21, baseBranches21, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray25 = _dataArray;
		string config49 = LocalStringManager.GetConfig("Adventure_language", "Name_144");
		string config50 = LocalStringManager.GetConfig("Adventure_language", "Desc_144");
		int[] resCost25 = new int[9];
		itemCost = new List<int[]>();
		List<int[]> itemCost24 = itemCost;
		short[] malice23 = new short[3];
		List<(string, string, string, string)> adventureParams23 = new List<(string, string, string, string)> { ("successRate", "LK_Adventure_144_ParamName_0", "", "") };
		List<AdventureStartNode> startNodes23 = new List<AdventureStartNode>
		{
			new AdventureStartNode("1a4fd27d-8d79-4761-8a36-e3aa5b7e85b3", "A", "", 2),
			new AdventureStartNode("199bc06a-3dea-45d2-beea-84f8d154b894", "B", "", 2)
		};
		List<AdventureTransferNode> transferNodes23 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("56fd7012-ee1c-4c4f-8eb6-57d06ddea78e", "C", "LK_Adventure_NodeTitle_473", 5)
		};
		List<AdventureEndNode> endNodes22 = new List<AdventureEndNode>
		{
			new AdventureEndNode("c030c0f0-7cd6-49ac-b4c4-a46c07d5a171", "D", "LK_Adventure_NodeTitle_474", 5)
		};
		List<AdventureBaseBranch> baseBranches22 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 2, "1", 1, 8, "", new int[2] { 9, 100 }, new int[41]
			{
				5, 7, 11, 30, 20, 65, 5, 5, 5, 7,
				2, 10, 20, 65, 5, 5, 5, 7, 6, 10,
				20, 65, 5, 5, 5, 7, 17, 20, 20, 65,
				5, 5, 5, 7, 1, 30, 20, 65, 5, 5,
				5
			}, new int[5] { 0, 15, 10, 10, 10 }, new string[7] { "0", "1", "ca6e6241-43f7-4ca2-9bbf-e45a85787860", "50", "0", "0", "0" }, new int[14]
			{
				3, 5, 120, 50, 5, 180, 30, 5, 240, 20,
				0, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "1", 1, 8, "", new int[2] { 9, 100 }, new int[41]
			{
				5, 7, 11, 30, 20, 65, 5, 5, 5, 7,
				2, 10, 20, 65, 5, 5, 5, 7, 6, 10,
				20, 65, 5, 5, 5, 7, 17, 20, 20, 65,
				5, 5, 5, 7, 1, 30, 20, 65, 5, 5,
				5
			}, new int[5] { 0, 15, 10, 10, 10 }, new string[7] { "0", "1", "ca6e6241-43f7-4ca2-9bbf-e45a85787860", "50", "0", "0", "0" }, new int[14]
			{
				3, 5, 120, 50, 5, 180, 30, 5, 240, 20,
				0, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 3, "1", 1, 12, "", new int[2] { 9, 100 }, new int[41]
			{
				5, 7, 11, 30, 20, 65, 5, 5, 5, 7,
				2, 10, 20, 65, 5, 5, 5, 7, 6, 10,
				20, 65, 5, 5, 5, 7, 17, 20, 20, 65,
				5, 5, 5, 7, 1, 30, 20, 65, 5, 5,
				5
			}, new int[5] { 0, 100, 10, 10, 10 }, new string[5] { "0", "0", "0", "0", "0" }, new int[14]
			{
				3, 5, 120, 50, 5, 180, 30, 5, 240, 20,
				0, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray25.Add(new AdventureItem(144, config49, config50, 14, 1, 5, 1, 5, 12, resCost25, itemCost24, restrictedByWorldPopulation: false, malice23, adventureParams23, "b85e0f29-032e-4ebc-a197-5f66325ed945", startNodes23, transferNodes23, endNodes22, baseBranches22, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray26 = _dataArray;
		string config51 = LocalStringManager.GetConfig("Adventure_language", "Name_145");
		string config52 = LocalStringManager.GetConfig("Adventure_language", "Desc_145");
		int[] resCost26 = new int[9];
		itemCost = new List<int[]>();
		List<int[]> itemCost25 = itemCost;
		short[] malice24 = new short[3];
		List<(string, string, string, string)> adventureParams24 = new List<(string, string, string, string)> { ("successRate", "LK_Adventure_145_ParamName_0", "", "") };
		List<AdventureStartNode> startNodes24 = new List<AdventureStartNode>
		{
			new AdventureStartNode("550a05e8-40b6-4e02-b080-821aa7c39fb4", "B", "LK_Adventure_NodeTitle_476", 10),
			new AdventureStartNode("41fae591-7976-49e1-baaa-ac9bf3df3794", "A", "LK_Adventure_NodeTitle_476", 10)
		};
		transferNodes2 = new List<AdventureTransferNode>();
		List<AdventureTransferNode> transferNodes24 = transferNodes2;
		List<AdventureEndNode> endNodes23 = new List<AdventureEndNode>
		{
			new AdventureEndNode("c9514975-bd26-423d-b5da-256d0682418b", "C", "LK_Adventure_NodeTitle_477", 10)
		};
		List<AdventureBaseBranch> baseBranches23 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 2, "1", 2, 10, "", new int[2] { 9, 100 }, new int[41]
			{
				5, 7, 10, 50, 20, 5, 65, 5, 5, 7,
				17, 20, 20, 5, 65, 5, 5, 7, 12, 10,
				20, 5, 65, 5, 5, 7, 5, 10, 20, 5,
				65, 5, 5, 7, 6, 10, 20, 5, 65, 5,
				5
			}, new int[5] { 0, 10, 20, 10, 10 }, new string[7] { "0", "0", "1", "3481b77e-f481-4e5f-92fe-0410c25f0e4d", "50", "0", "0" }, new int[14]
			{
				3, 5, 120, 50, 5, 180, 30, 5, 240, 20,
				0, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 2, "1", 2, 10, "", new int[2] { 9, 100 }, new int[41]
			{
				5, 7, 10, 50, 20, 5, 65, 5, 5, 7,
				17, 20, 20, 5, 65, 5, 5, 7, 12, 10,
				20, 5, 65, 5, 5, 7, 5, 10, 20, 5,
				65, 5, 5, 7, 6, 10, 20, 5, 65, 5,
				5
			}, new int[5] { 0, 10, 20, 10, 10 }, new string[7] { "0", "0", "1", "3481b77e-f481-4e5f-92fe-0410c25f0e4d", "50", "0", "0" }, new int[14]
			{
				3, 5, 120, 50, 5, 180, 30, 5, 240, 20,
				0, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray26.Add(new AdventureItem(145, config51, config52, 14, 1, 5, 1, 5, 12, resCost26, itemCost25, restrictedByWorldPopulation: false, malice24, adventureParams24, "3d315eda-edd9-40af-af8f-787bf7622b4b", startNodes24, transferNodes24, endNodes23, baseBranches23, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray27 = _dataArray;
		string config53 = LocalStringManager.GetConfig("Adventure_language", "Name_146");
		string config54 = LocalStringManager.GetConfig("Adventure_language", "Desc_146");
		int[] resCost27 = new int[9];
		itemCost = new List<int[]>();
		List<int[]> itemCost26 = itemCost;
		short[] malice25 = new short[3];
		List<(string, string, string, string)> adventureParams25 = new List<(string, string, string, string)> { ("poison", "LK_Adventure_146_ParamName_0", "", "") };
		List<AdventureStartNode> startNodes25 = new List<AdventureStartNode>
		{
			new AdventureStartNode("258948f4-edb0-4649-9438-05cc0f45c794", "A", "", 4),
			new AdventureStartNode("a16667f0-3a1c-46c3-8793-aa14533ed2c6", "B", "", 4)
		};
		transferNodes2 = new List<AdventureTransferNode>();
		List<AdventureTransferNode> transferNodes25 = transferNodes2;
		List<AdventureEndNode> endNodes24 = new List<AdventureEndNode>
		{
			new AdventureEndNode("707419ea-6d1e-4546-955c-172af3d760c9", "C", "LK_Adventure_NodeTitle_479", 4),
			new AdventureEndNode("9a554422-3a0e-4987-8504-d672d380375e", "D", "LK_Adventure_NodeTitle_479", 4)
		};
		List<AdventureBaseBranch> baseBranches24 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 2, "1", 2, 5, "2a420f40-6e6d-44bd-a242-ecf4e0ff815f", new int[2] { 9, 100 }, new int[41]
			{
				5, 7, 4, 40, 20, 5, 5, 5, 65, 7,
				6, 20, 20, 5, 5, 5, 65, 7, 3, 10,
				20, 5, 5, 5, 65, 7, 17, 10, 20, 5,
				5, 5, 65, 7, 22, 20, 20, 5, 5, 5,
				65
			}, new int[5] { 0, 10, 10, 10, 20 }, new string[7] { "0", "0", "0", "0", "1", "9454ad18-0728-49e8-8b33-9cb18d113a05", "50" }, new int[14]
			{
				3, 5, 120, 50, 5, 180, 30, 5, 240, 20,
				0, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 3, "2", 2, 10, "2a420f40-6e6d-44bd-a242-ecf4e0ff815f", new int[2] { 9, 100 }, new int[41]
			{
				5, 7, 4, 40, 20, 5, 5, 5, 65, 7,
				6, 20, 20, 5, 5, 5, 65, 7, 3, 10,
				20, 5, 5, 5, 65, 7, 17, 10, 20, 5,
				5, 5, 65, 7, 22, 20, 20, 5, 5, 5,
				65
			}, new int[5] { 0, 10, 10, 10, 20 }, new string[7] { "0", "0", "0", "0", "1", "9454ad18-0728-49e8-8b33-9cb18d113a05", "50" }, new int[14]
			{
				3, 5, 120, 50, 5, 180, 30, 5, 240, 20,
				0, 0, 0, 0
			}, new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray27.Add(new AdventureItem(146, config53, config54, 14, 1, 5, 1, 5, 12, resCost27, itemCost26, restrictedByWorldPopulation: false, malice25, adventureParams25, "98fbf818-1cc8-4961-99d4-4c7ff367c7cc", startNodes25, transferNodes25, endNodes24, baseBranches24, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray28 = _dataArray;
		string config55 = LocalStringManager.GetConfig("Adventure_language", "Name_147");
		string config56 = LocalStringManager.GetConfig("Adventure_language", "Desc_147");
		int[] resCost28 = new int[9];
		itemCost = new List<int[]>();
		List<int[]> itemCost27 = itemCost;
		short[] malice26 = new short[3];
		list = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams26 = list;
		List<AdventureStartNode> startNodes26 = new List<AdventureStartNode>
		{
			new AdventureStartNode("b027a934-ec0f-4f47-8de6-36788554b6a1", "A", "LK_Adventure_NodeTitle_480", 6)
		};
		transferNodes2 = new List<AdventureTransferNode>();
		List<AdventureTransferNode> transferNodes26 = transferNodes2;
		List<AdventureEndNode> endNodes25 = new List<AdventureEndNode>
		{
			new AdventureEndNode("67fb5f36-7589-427f-891a-ffa3bf7f651b", "D", "LK_Adventure_NodeTitle_481", 20)
		};
		List<AdventureBaseBranch> baseBranches25 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 12, "", new int[2] { 15, 1 }, new int[25]
			{
				3, 7, 4, 30, 10, 10, 10, 60, 10, 7,
				16, 30, 10, 10, 10, 60, 10, 7, 21, 30,
				10, 10, 10, 60, 10
			}, new int[5] { 100, 100, 160, 100, 100 }, new string[7] { "0", "0", "0", "1", "4249e10e-f8f7-4701-a183-70fe89af5364", "100", "0" }, new int[5], new int[93]
			{
				1, 8, -801, 1, 100, 1, 2, -201, 1, 100,
				16, 0, -1, 1, 10, 0, -2, 1, 10, 0,
				-3, 1, 10, 0, -4, 1, 10, 0, -5, 1,
				10, 0, -6, 1, 10, 0, -7, 1, 10, 0,
				-8, 1, 10, 0, -9, 1, 10, 0, -10, 1,
				10, 0, -11, 1, 10, 0, -12, 1, 10, 0,
				-13, 1, 10, 0, -14, 1, 10, 0, -15, 1,
				10, 0, -16, 1, 10, 0, 4, 1, -101, 1,
				25, 1, -102, 1, 25, 1, -103, 1, 25, 1,
				-104, 1, 25
			}, new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray28.Add(new AdventureItem(147, config55, config56, 15, 1, 1, 0, 10, -1, resCost28, itemCost27, restrictedByWorldPopulation: false, malice26, adventureParams26, "76a36a7c-61dd-4782-84ff-d54483a5e8d7", startNodes26, transferNodes26, endNodes25, baseBranches25, advancedBranches, difficultyAddXiangshuLevel: true));
		List<AdventureItem> dataArray29 = _dataArray;
		string config57 = LocalStringManager.GetConfig("Adventure_language", "Name_148");
		string config58 = LocalStringManager.GetConfig("Adventure_language", "Desc_148");
		int[] resCost29 = new int[9];
		itemCost = new List<int[]>();
		List<int[]> itemCost28 = itemCost;
		short[] malice27 = new short[3];
		list = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams27 = list;
		List<AdventureStartNode> startNodes27 = new List<AdventureStartNode>
		{
			new AdventureStartNode("71da02e3-fe7a-4bed-84a2-0649b530ce48", "A", "LK_Adventure_NodeTitle_480", 19)
		};
		transferNodes2 = new List<AdventureTransferNode>();
		List<AdventureTransferNode> transferNodes27 = transferNodes2;
		List<AdventureEndNode> endNodes26 = new List<AdventureEndNode>
		{
			new AdventureEndNode("ca1b8874-455b-4b52-9fc6-7d37d547239d", "D", "LK_Adventure_NodeTitle_481", 20)
		};
		List<AdventureBaseBranch> baseBranches26 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 12, "", new int[2] { 10, 1 }, new int[25]
			{
				3, 7, 4, 30, 10, 10, 10, 60, 10, 7,
				11, 30, 10, 10, 10, 60, 10, 7, 10, 30,
				10, 10, 10, 60, 10
			}, new int[5] { 100, 100, 160, 100, 100 }, new string[7] { "0", "0", "0", "1", "4249e10e-f8f7-4701-a183-70fe89af5364", "100", "0" }, new int[5], new int[93]
			{
				1, 8, -801, 1, 100, 1, 2, -201, 1, 100,
				16, 0, -1, 1, 10, 0, -2, 1, 10, 0,
				-3, 1, 10, 0, -4, 1, 10, 0, -5, 1,
				10, 0, -6, 1, 10, 0, -7, 1, 10, 0,
				-8, 1, 10, 0, -9, 1, 10, 0, -10, 1,
				10, 0, -11, 1, 10, 0, -12, 1, 10, 0,
				-13, 1, 10, 0, -14, 1, 10, 0, -15, 1,
				10, 0, -16, 1, 10, 0, 4, 1, -101, 1,
				25, 1, -102, 1, 25, 1, -103, 1, 25, 1,
				-104, 1, 25
			}, new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray29.Add(new AdventureItem(148, config57, config58, 15, 1, 1, 0, 10, -1, resCost29, itemCost28, restrictedByWorldPopulation: false, malice27, adventureParams27, "a4cad2c3-6e5a-42fe-b2f5-d5de931ee9c0", startNodes27, transferNodes27, endNodes26, baseBranches26, advancedBranches, difficultyAddXiangshuLevel: true));
		List<AdventureItem> dataArray30 = _dataArray;
		string config59 = LocalStringManager.GetConfig("Adventure_language", "Name_149");
		string config60 = LocalStringManager.GetConfig("Adventure_language", "Desc_149");
		int[] resCost30 = new int[9];
		itemCost = new List<int[]>();
		List<int[]> itemCost29 = itemCost;
		short[] malice28 = new short[3];
		list = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams28 = list;
		List<AdventureStartNode> startNodes28 = new List<AdventureStartNode>
		{
			new AdventureStartNode("20d7d291-1e41-432b-af5b-4db3440bc313", "A", "LK_Adventure_NodeTitle_480", 19)
		};
		transferNodes2 = new List<AdventureTransferNode>();
		List<AdventureTransferNode> transferNodes28 = transferNodes2;
		List<AdventureEndNode> endNodes27 = new List<AdventureEndNode>
		{
			new AdventureEndNode("39a20a00-89c0-469a-8963-199cbfd93702", "E", "LK_Adventure_NodeTitle_481", 20)
		};
		List<AdventureBaseBranch> baseBranches27 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 12, "", new int[2] { 5, 1 }, new int[25]
			{
				3, 7, 13, 30, 10, 10, 10, 60, 10, 7,
				12, 30, 10, 10, 10, 60, 10, 7, 19, 30,
				10, 10, 10, 60, 10
			}, new int[5] { 100, 100, 160, 100, 100 }, new string[7] { "0", "0", "0", "1", "4249e10e-f8f7-4701-a183-70fe89af5364", "100", "0" }, new int[5], new int[93]
			{
				1, 8, -801, 1, 100, 1, 2, -201, 1, 100,
				16, 0, -1, 1, 10, 0, -2, 1, 10, 0,
				-3, 1, 10, 0, -4, 1, 10, 0, -5, 1,
				10, 0, -6, 1, 10, 0, -7, 1, 10, 0,
				-8, 1, 10, 0, -9, 1, 10, 0, -10, 1,
				10, 0, -11, 1, 10, 0, -12, 1, 10, 0,
				-13, 1, 10, 0, -14, 1, 10, 0, -15, 1,
				10, 0, -16, 1, 10, 0, 4, 1, -101, 1,
				25, 1, -102, 1, 25, 1, -103, 1, 25, 1,
				-104, 1, 25
			}, new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray30.Add(new AdventureItem(149, config59, config60, 15, 1, 1, 0, 10, -1, resCost30, itemCost29, restrictedByWorldPopulation: false, malice28, adventureParams28, "346c91d9-b363-4880-ac47-3e497699412d", startNodes28, transferNodes28, endNodes27, baseBranches27, advancedBranches, difficultyAddXiangshuLevel: true));
		List<AdventureItem> dataArray31 = _dataArray;
		string config61 = LocalStringManager.GetConfig("Adventure_language", "Name_150");
		string config62 = LocalStringManager.GetConfig("Adventure_language", "Desc_150");
		int[] resCost31 = new int[9];
		itemCost = new List<int[]>();
		List<int[]> itemCost30 = itemCost;
		short[] malice29 = new short[3];
		list = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams29 = list;
		List<AdventureStartNode> startNodes29 = new List<AdventureStartNode>
		{
			new AdventureStartNode("cd7ce32e-19a9-4746-8903-a60bc43b00f8", "A", "LK_Adventure_NodeTitle_480", 18)
		};
		transferNodes2 = new List<AdventureTransferNode>();
		List<AdventureTransferNode> transferNodes29 = transferNodes2;
		List<AdventureEndNode> endNodes28 = new List<AdventureEndNode>
		{
			new AdventureEndNode("7b35ca42-eb66-4d3a-9706-e928b7e9e89f", "E", "LK_Adventure_NodeTitle_481", 18)
		};
		List<AdventureBaseBranch> baseBranches28 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 12, "", new int[2] { 6, 1 }, new int[25]
			{
				3, 7, 17, 30, 10, 10, 10, 60, 10, 7,
				18, 30, 10, 10, 10, 60, 10, 7, 1, 30,
				10, 10, 10, 60, 10
			}, new int[5] { 100, 100, 160, 100, 100 }, new string[7] { "0", "0", "0", "1", "4249e10e-f8f7-4701-a183-70fe89af5364", "100", "0" }, new int[5], new int[93]
			{
				1, 8, -801, 1, 100, 1, 2, -201, 1, 100,
				16, 0, -1, 1, 10, 0, -2, 1, 10, 0,
				-3, 1, 10, 0, -4, 1, 10, 0, -5, 1,
				10, 0, -6, 1, 10, 0, -7, 1, 10, 0,
				-8, 1, 10, 0, -9, 1, 10, 0, -10, 1,
				10, 0, -11, 1, 10, 0, -12, 1, 10, 0,
				-13, 1, 10, 0, -14, 1, 10, 0, -15, 1,
				10, 0, -16, 1, 10, 0, 4, 1, -101, 1,
				25, 1, -102, 1, 25, 1, -103, 1, 25, 1,
				-104, 1, 25
			}, new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray31.Add(new AdventureItem(150, config61, config62, 15, 1, 1, 0, 10, -1, resCost31, itemCost30, restrictedByWorldPopulation: false, malice29, adventureParams29, "463c694c-056a-405a-b415-58e815965dc8", startNodes29, transferNodes29, endNodes28, baseBranches28, advancedBranches, difficultyAddXiangshuLevel: true));
		List<AdventureItem> dataArray32 = _dataArray;
		string config63 = LocalStringManager.GetConfig("Adventure_language", "Name_151");
		string config64 = LocalStringManager.GetConfig("Adventure_language", "Desc_151");
		int[] resCost32 = new int[9];
		itemCost = new List<int[]>();
		List<int[]> itemCost31 = itemCost;
		short[] malice30 = new short[3];
		list = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams30 = list;
		List<AdventureStartNode> startNodes30 = new List<AdventureStartNode>
		{
			new AdventureStartNode("4e7147b9-8a39-4a6b-b215-3d0e00b812b5", "A", "LK_Adventure_NodeTitle_480", 19)
		};
		transferNodes2 = new List<AdventureTransferNode>();
		List<AdventureTransferNode> transferNodes30 = transferNodes2;
		List<AdventureEndNode> endNodes29 = new List<AdventureEndNode>
		{
			new AdventureEndNode("4acdc0dd-6fb8-4b08-bf0a-77a9ff52728d", "B", "LK_Adventure_NodeTitle_481", 20)
		};
		List<AdventureBaseBranch> baseBranches29 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 12, "", new int[2] { 4, 1 }, new int[25]
			{
				3, 7, 4, 30, 10, 10, 10, 60, 10, 7,
				22, 30, 10, 10, 10, 60, 10, 7, 1, 30,
				10, 10, 10, 60, 10
			}, new int[5] { 100, 100, 160, 100, 100 }, new string[7] { "0", "0", "0", "1", "4249e10e-f8f7-4701-a183-70fe89af5364", "100", "0" }, new int[5], new int[93]
			{
				1, 8, -801, 1, 100, 1, 2, -201, 1, 100,
				16, 0, -1, 1, 10, 0, -2, 1, 10, 0,
				-3, 1, 10, 0, -4, 1, 10, 0, -5, 1,
				10, 0, -6, 1, 10, 0, -7, 1, 10, 0,
				-8, 1, 10, 0, -9, 1, 10, 0, -10, 1,
				10, 0, -11, 1, 10, 0, -12, 1, 10, 0,
				-13, 1, 10, 0, -14, 1, 10, 0, -15, 1,
				10, 0, -16, 1, 10, 0, 4, 1, -101, 1,
				25, 1, -102, 1, 25, 1, -103, 1, 25, 1,
				-104, 1, 25
			}, new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray32.Add(new AdventureItem(151, config63, config64, 15, 1, 1, 0, 10, -1, resCost32, itemCost31, restrictedByWorldPopulation: false, malice30, adventureParams30, "e2780e79-e706-4c37-bd87-9d2f94a70b1a", startNodes30, transferNodes30, endNodes29, baseBranches29, advancedBranches, difficultyAddXiangshuLevel: true));
		List<AdventureItem> dataArray33 = _dataArray;
		string config65 = LocalStringManager.GetConfig("Adventure_language", "Name_152");
		string config66 = LocalStringManager.GetConfig("Adventure_language", "Desc_152");
		int[] resCost33 = new int[9];
		itemCost = new List<int[]>();
		List<int[]> itemCost32 = itemCost;
		short[] malice31 = new short[3];
		list = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams31 = list;
		List<AdventureStartNode> startNodes31 = new List<AdventureStartNode>
		{
			new AdventureStartNode("a5d85805-2d28-4bd5-a8b0-2e462bbd4122", "A", "LK_Adventure_NodeTitle_480", 16)
		};
		transferNodes2 = new List<AdventureTransferNode>();
		List<AdventureTransferNode> transferNodes31 = transferNodes2;
		List<AdventureEndNode> endNodes30 = new List<AdventureEndNode>
		{
			new AdventureEndNode("f7afee5f-231d-4003-a074-1fe7096591d0", "B", "LK_Adventure_NodeTitle_481", 20)
		};
		List<AdventureBaseBranch> baseBranches30 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 12, "", new int[2] { 14, 1 }, new int[25]
			{
				3, 7, 2, 30, 10, 10, 10, 60, 10, 7,
				22, 30, 10, 10, 10, 60, 10, 7, 3, 30,
				10, 10, 10, 60, 10
			}, new int[5] { 100, 100, 160, 100, 100 }, new string[7] { "0", "0", "0", "1", "4249e10e-f8f7-4701-a183-70fe89af5364", "100", "0" }, new int[5], new int[93]
			{
				1, 8, -801, 1, 100, 1, 2, -201, 1, 100,
				16, 0, -1, 1, 10, 0, -2, 1, 10, 0,
				-3, 1, 10, 0, -4, 1, 10, 0, -5, 1,
				10, 0, -6, 1, 10, 0, -7, 1, 10, 0,
				-8, 1, 10, 0, -9, 1, 10, 0, -10, 1,
				10, 0, -11, 1, 10, 0, -12, 1, 10, 0,
				-13, 1, 10, 0, -14, 1, 10, 0, -15, 1,
				10, 0, -16, 1, 10, 0, 4, 1, -101, 1,
				25, 1, -102, 1, 25, 1, -103, 1, 25, 1,
				-104, 1, 25
			}, new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray33.Add(new AdventureItem(152, config65, config66, 15, 1, 1, 0, 10, -1, resCost33, itemCost32, restrictedByWorldPopulation: false, malice31, adventureParams31, "aec6f452-335c-4145-b7a7-f7188ec5183b", startNodes31, transferNodes31, endNodes30, baseBranches30, advancedBranches, difficultyAddXiangshuLevel: true));
		List<AdventureItem> dataArray34 = _dataArray;
		string config67 = LocalStringManager.GetConfig("Adventure_language", "Name_153");
		string config68 = LocalStringManager.GetConfig("Adventure_language", "Desc_153");
		int[] resCost34 = new int[9];
		itemCost = new List<int[]>();
		List<int[]> itemCost33 = itemCost;
		short[] malice32 = new short[3];
		list = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams32 = list;
		List<AdventureStartNode> startNodes32 = new List<AdventureStartNode>
		{
			new AdventureStartNode("6f76f83a-0679-46fa-a9f3-31629a7ae8e3", "A", "LK_Adventure_NodeTitle_480", 10)
		};
		transferNodes2 = new List<AdventureTransferNode>();
		List<AdventureTransferNode> transferNodes32 = transferNodes2;
		List<AdventureEndNode> endNodes31 = new List<AdventureEndNode>
		{
			new AdventureEndNode("85e64188-2fda-4a2d-b4a1-937cd959a0c5", "B", "LK_Adventure_NodeTitle_481", 3)
		};
		List<AdventureBaseBranch> baseBranches31 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 12, "", new int[4] { 8, 1, 9, 1 }, new int[25]
			{
				3, 7, 11, 30, 10, 10, 10, 60, 10, 7,
				10, 30, 10, 10, 10, 60, 10, 7, 5, 30,
				10, 10, 10, 60, 10
			}, new int[5] { 100, 100, 160, 100, 100 }, new string[7] { "0", "0", "0", "1", "4249e10e-f8f7-4701-a183-70fe89af5364", "100", "0" }, new int[5], new int[93]
			{
				1, 8, -801, 1, 100, 1, 2, -201, 1, 100,
				16, 0, -1, 1, 10, 0, -2, 1, 10, 0,
				-3, 1, 10, 0, -4, 1, 10, 0, -5, 1,
				10, 0, -6, 1, 10, 0, -7, 1, 10, 0,
				-8, 1, 10, 0, -9, 1, 10, 0, -10, 1,
				10, 0, -11, 1, 10, 0, -12, 1, 10, 0,
				-13, 1, 10, 0, -14, 1, 10, 0, -15, 1,
				10, 0, -16, 1, 10, 0, 4, 1, -101, 1,
				25, 1, -102, 1, 25, 1, -103, 1, 25, 1,
				-104, 1, 25
			}, new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray34.Add(new AdventureItem(153, config67, config68, 15, 1, 1, 0, 10, -1, resCost34, itemCost33, restrictedByWorldPopulation: false, malice32, adventureParams32, "63615130-b62a-4050-bd04-032cfdab51dd", startNodes32, transferNodes32, endNodes31, baseBranches31, advancedBranches, difficultyAddXiangshuLevel: true));
		List<AdventureItem> dataArray35 = _dataArray;
		string config69 = LocalStringManager.GetConfig("Adventure_language", "Name_154");
		string config70 = LocalStringManager.GetConfig("Adventure_language", "Desc_154");
		int[] resCost35 = new int[9];
		itemCost = new List<int[]>();
		List<int[]> itemCost34 = itemCost;
		short[] malice33 = new short[3];
		list = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams33 = list;
		List<AdventureStartNode> startNodes33 = new List<AdventureStartNode>
		{
			new AdventureStartNode("774ab863-3240-476d-829b-93f298eadd51", "A", "LK_Adventure_NodeTitle_480", 11)
		};
		transferNodes2 = new List<AdventureTransferNode>();
		List<AdventureTransferNode> transferNodes33 = transferNodes2;
		List<AdventureEndNode> endNodes32 = new List<AdventureEndNode>
		{
			new AdventureEndNode("a0d42796-ea53-4096-83c3-86806c71dc9a", "D", "LK_Adventure_NodeTitle_481", 20)
		};
		List<AdventureBaseBranch> baseBranches32 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 12, "", new int[2] { 7, 1 }, new int[25]
			{
				3, 7, 17, 30, 10, 10, 10, 60, 10, 7,
				18, 30, 10, 10, 10, 60, 10, 7, 11, 30,
				10, 10, 10, 60, 10
			}, new int[5] { 100, 100, 160, 100, 100 }, new string[7] { "0", "0", "0", "1", "4249e10e-f8f7-4701-a183-70fe89af5364", "100", "0" }, new int[5], new int[93]
			{
				1, 8, -801, 1, 100, 1, 2, -201, 1, 100,
				16, 0, -1, 1, 10, 0, -2, 1, 10, 0,
				-3, 1, 10, 0, -4, 1, 10, 0, -5, 1,
				10, 0, -6, 1, 10, 0, -7, 1, 10, 0,
				-8, 1, 10, 0, -9, 1, 10, 0, -10, 1,
				10, 0, -11, 1, 10, 0, -12, 1, 10, 0,
				-13, 1, 10, 0, -14, 1, 10, 0, -15, 1,
				10, 0, -16, 1, 10, 0, 4, 1, -101, 1,
				25, 1, -102, 1, 25, 1, -103, 1, 25, 1,
				-104, 1, 25
			}, new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray35.Add(new AdventureItem(154, config69, config70, 15, 1, 1, 0, 10, -1, resCost35, itemCost34, restrictedByWorldPopulation: false, malice33, adventureParams33, "bc043229-1de3-4e04-89e8-92d5b62c9a09", startNodes33, transferNodes33, endNodes32, baseBranches32, advancedBranches, difficultyAddXiangshuLevel: true));
		List<AdventureItem> dataArray36 = _dataArray;
		string config71 = LocalStringManager.GetConfig("Adventure_language", "Name_155");
		string config72 = LocalStringManager.GetConfig("Adventure_language", "Desc_155");
		int[] resCost36 = new int[9];
		itemCost = new List<int[]>();
		List<int[]> itemCost35 = itemCost;
		short[] malice34 = new short[3];
		list = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams34 = list;
		List<AdventureStartNode> startNodes34 = new List<AdventureStartNode>
		{
			new AdventureStartNode("29ad71ff-af24-454a-aba7-2fd42b47d735", "A", "LK_Adventure_NodeTitle_480", 5)
		};
		transferNodes2 = new List<AdventureTransferNode>();
		List<AdventureTransferNode> transferNodes34 = transferNodes2;
		List<AdventureEndNode> endNodes33 = new List<AdventureEndNode>
		{
			new AdventureEndNode("5b83204d-727d-4a6a-8b3e-a81170b81dd1", "D", "LK_Adventure_NodeTitle_481", 20)
		};
		List<AdventureBaseBranch> baseBranches33 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 12, "", new int[2] { 11, 1 }, new int[25]
			{
				3, 7, 6, 30, 10, 10, 10, 60, 10, 7,
				11, 30, 10, 10, 10, 60, 10, 7, 12, 30,
				10, 10, 10, 60, 10
			}, new int[5] { 100, 100, 160, 100, 100 }, new string[7] { "0", "0", "0", "1", "4249e10e-f8f7-4701-a183-70fe89af5364", "100", "0" }, new int[5], new int[93]
			{
				1, 8, -801, 1, 100, 1, 2, -201, 1, 100,
				16, 0, -1, 1, 10, 0, -2, 1, 10, 0,
				-3, 1, 10, 0, -4, 1, 10, 0, -5, 1,
				10, 0, -6, 1, 10, 0, -7, 1, 10, 0,
				-8, 1, 10, 0, -9, 1, 10, 0, -10, 1,
				10, 0, -11, 1, 10, 0, -12, 1, 10, 0,
				-13, 1, 10, 0, -14, 1, 10, 0, -15, 1,
				10, 0, -16, 1, 10, 0, 4, 1, -101, 1,
				25, 1, -102, 1, 25, 1, -103, 1, 25, 1,
				-104, 1, 25
			}, new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray36.Add(new AdventureItem(155, config71, config72, 15, 1, 1, 0, 10, 0, resCost36, itemCost35, restrictedByWorldPopulation: false, malice34, adventureParams34, "ab948084-def7-4847-bb6d-beacbe5ab48e", startNodes34, transferNodes34, endNodes33, baseBranches33, advancedBranches, difficultyAddXiangshuLevel: true));
		List<AdventureItem> dataArray37 = _dataArray;
		string config73 = LocalStringManager.GetConfig("Adventure_language", "Name_156");
		string config74 = LocalStringManager.GetConfig("Adventure_language", "Desc_156");
		int[] resCost37 = new int[9];
		itemCost = new List<int[]>();
		List<int[]> itemCost36 = itemCost;
		short[] malice35 = new short[3];
		list = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams35 = list;
		List<AdventureStartNode> startNodes35 = new List<AdventureStartNode>
		{
			new AdventureStartNode("6cdb0a57-8f2f-4615-8146-d29f7bb8b7a6", "A", "LK_Adventure_NodeTitle_482", 1)
		};
		transferNodes2 = new List<AdventureTransferNode>();
		List<AdventureTransferNode> transferNodes35 = transferNodes2;
		List<AdventureEndNode> endNodes34 = new List<AdventureEndNode>
		{
			new AdventureEndNode("dc03e1f3-662a-40bc-ab3a-c2496810ee78", "B", "LK_Adventure_NodeTitle_483", 1)
		};
		List<AdventureBaseBranch> baseBranches34 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 5, "", new int[2] { 0, 10 }, new int[4] { 1, 2, 1, 10 }, new int[5] { 10, 10, 10, 50, 10 }, new string[7] { "0", "0", "0", "1", "4249e10e-f8f7-4701-a183-70fe89af5364", "100", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray37.Add(new AdventureItem(156, config73, config74, 15, 1, 1, 0, 1, 1, resCost37, itemCost36, restrictedByWorldPopulation: false, malice35, adventureParams35, "3b2788e1-7848-4a57-99fb-d3e955eda2db", startNodes35, transferNodes35, endNodes34, baseBranches34, advancedBranches, difficultyAddXiangshuLevel: true));
		List<AdventureItem> dataArray38 = _dataArray;
		string config75 = LocalStringManager.GetConfig("Adventure_language", "Name_157");
		string config76 = LocalStringManager.GetConfig("Adventure_language", "Desc_157");
		int[] resCost38 = new int[9];
		itemCost = new List<int[]>();
		List<int[]> itemCost37 = itemCost;
		short[] malice36 = new short[3];
		list = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams36 = list;
		List<AdventureStartNode> startNodes36 = new List<AdventureStartNode>
		{
			new AdventureStartNode("7f993a02-96f8-4b08-89da-74aa13abbbb0", "A", "LK_Adventure_NodeTitle_482", 1)
		};
		transferNodes2 = new List<AdventureTransferNode>();
		List<AdventureTransferNode> transferNodes36 = transferNodes2;
		List<AdventureEndNode> endNodes35 = new List<AdventureEndNode>
		{
			new AdventureEndNode("5304bc7a-a35e-491d-bdc2-53f0fb3e3c40", "B", "LK_Adventure_NodeTitle_483", 1)
		};
		List<AdventureBaseBranch> baseBranches35 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 5, "", new int[2] { 0, 10 }, new int[4] { 1, 2, 1, 10 }, new int[5] { 10, 10, 10, 50, 10 }, new string[7] { "0", "0", "0", "1", "4249e10e-f8f7-4701-a183-70fe89af5364", "100", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray38.Add(new AdventureItem(157, config75, config76, 15, 1, 1, 0, 1, 1, resCost38, itemCost37, restrictedByWorldPopulation: false, malice36, adventureParams36, "3b2788e1-7848-4a57-99fb-d3e955eda2db", startNodes36, transferNodes36, endNodes35, baseBranches35, advancedBranches, difficultyAddXiangshuLevel: true));
		List<AdventureItem> dataArray39 = _dataArray;
		string config77 = LocalStringManager.GetConfig("Adventure_language", "Name_158");
		string config78 = LocalStringManager.GetConfig("Adventure_language", "Desc_158");
		int[] resCost39 = new int[9];
		itemCost = new List<int[]>();
		List<int[]> itemCost38 = itemCost;
		short[] malice37 = new short[3];
		list = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams37 = list;
		List<AdventureStartNode> startNodes37 = new List<AdventureStartNode>
		{
			new AdventureStartNode("94b82d8a-9546-4fe9-8706-2f6fa3bf41aa", "A", "LK_Adventure_NodeTitle_482", 1)
		};
		transferNodes2 = new List<AdventureTransferNode>();
		List<AdventureTransferNode> transferNodes37 = transferNodes2;
		List<AdventureEndNode> endNodes36 = new List<AdventureEndNode>
		{
			new AdventureEndNode("6e92f8ce-3be2-4112-b968-7a57c7ff8b2b", "B", "LK_Adventure_NodeTitle_483", 1)
		};
		List<AdventureBaseBranch> baseBranches36 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 5, "", new int[2] { 0, 10 }, new int[4] { 1, 2, 1, 10 }, new int[5] { 10, 10, 10, 50, 10 }, new string[7] { "0", "0", "0", "1", "4249e10e-f8f7-4701-a183-70fe89af5364", "100", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray39.Add(new AdventureItem(158, config77, config78, 15, 1, 1, 0, 1, 1, resCost39, itemCost38, restrictedByWorldPopulation: false, malice37, adventureParams37, "3b2788e1-7848-4a57-99fb-d3e955eda2db", startNodes37, transferNodes37, endNodes36, baseBranches36, advancedBranches, difficultyAddXiangshuLevel: true));
		List<AdventureItem> dataArray40 = _dataArray;
		string config79 = LocalStringManager.GetConfig("Adventure_language", "Name_159");
		string config80 = LocalStringManager.GetConfig("Adventure_language", "Desc_159");
		int[] resCost40 = new int[9];
		itemCost = new List<int[]>();
		List<int[]> itemCost39 = itemCost;
		short[] malice38 = new short[3];
		list = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams38 = list;
		List<AdventureStartNode> startNodes38 = new List<AdventureStartNode>
		{
			new AdventureStartNode("af7ec2ed-dc80-4682-87b1-e7237ac339cd", "A", "LK_Adventure_NodeTitle_482", 1)
		};
		transferNodes2 = new List<AdventureTransferNode>();
		List<AdventureTransferNode> transferNodes38 = transferNodes2;
		List<AdventureEndNode> endNodes37 = new List<AdventureEndNode>
		{
			new AdventureEndNode("c2ef88d6-2b3c-43ca-aa8c-2524ffb97cf2", "B", "LK_Adventure_NodeTitle_483", 1)
		};
		List<AdventureBaseBranch> baseBranches37 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 5, "", new int[2] { 0, 10 }, new int[4] { 1, 2, 1, 10 }, new int[5] { 10, 10, 10, 50, 10 }, new string[7] { "0", "0", "0", "1", "4249e10e-f8f7-4701-a183-70fe89af5364", "100", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray40.Add(new AdventureItem(159, config79, config80, 15, 1, 1, 0, 1, 1, resCost40, itemCost39, restrictedByWorldPopulation: false, malice38, adventureParams38, "3b2788e1-7848-4a57-99fb-d3e955eda2db", startNodes38, transferNodes38, endNodes37, baseBranches37, advancedBranches, difficultyAddXiangshuLevel: true));
		List<AdventureItem> dataArray41 = _dataArray;
		string config81 = LocalStringManager.GetConfig("Adventure_language", "Name_160");
		string config82 = LocalStringManager.GetConfig("Adventure_language", "Desc_160");
		int[] resCost41 = new int[9];
		itemCost = new List<int[]>();
		List<int[]> itemCost40 = itemCost;
		short[] malice39 = new short[3];
		list = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams39 = list;
		List<AdventureStartNode> startNodes39 = new List<AdventureStartNode>
		{
			new AdventureStartNode("6e7cb14d-9188-4ec3-a941-d0ef14a5b6ce", "A", "LK_Adventure_NodeTitle_482", 1)
		};
		transferNodes2 = new List<AdventureTransferNode>();
		List<AdventureTransferNode> transferNodes39 = transferNodes2;
		List<AdventureEndNode> endNodes38 = new List<AdventureEndNode>
		{
			new AdventureEndNode("7303121f-08ad-4a35-a742-7f53eebf8a2b", "B", "LK_Adventure_NodeTitle_483", 1)
		};
		List<AdventureBaseBranch> baseBranches38 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 5, "", new int[2] { 0, 10 }, new int[4] { 1, 2, 1, 10 }, new int[5] { 10, 10, 10, 50, 10 }, new string[7] { "0", "0", "0", "1", "4249e10e-f8f7-4701-a183-70fe89af5364", "100", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray41.Add(new AdventureItem(160, config81, config82, 15, 1, 1, 0, 1, 1, resCost41, itemCost40, restrictedByWorldPopulation: false, malice39, adventureParams39, "3b2788e1-7848-4a57-99fb-d3e955eda2db", startNodes39, transferNodes39, endNodes38, baseBranches38, advancedBranches, difficultyAddXiangshuLevel: true));
		List<AdventureItem> dataArray42 = _dataArray;
		string config83 = LocalStringManager.GetConfig("Adventure_language", "Name_161");
		string config84 = LocalStringManager.GetConfig("Adventure_language", "Desc_161");
		int[] resCost42 = new int[9];
		itemCost = new List<int[]>();
		List<int[]> itemCost41 = itemCost;
		short[] malice40 = new short[3];
		list = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams40 = list;
		List<AdventureStartNode> startNodes40 = new List<AdventureStartNode>
		{
			new AdventureStartNode("bf7fcb6a-4c1a-4856-ac20-7e62fce6a2f2", "A", "LK_Adventure_NodeTitle_482", 1)
		};
		transferNodes2 = new List<AdventureTransferNode>();
		List<AdventureTransferNode> transferNodes40 = transferNodes2;
		List<AdventureEndNode> endNodes39 = new List<AdventureEndNode>
		{
			new AdventureEndNode("57c50965-4e4b-417c-9679-05bf468367e9", "B", "LK_Adventure_NodeTitle_483", 1)
		};
		List<AdventureBaseBranch> baseBranches39 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 5, "", new int[2] { 0, 10 }, new int[4] { 1, 2, 1, 10 }, new int[5] { 10, 10, 10, 50, 10 }, new string[7] { "0", "0", "0", "1", "4249e10e-f8f7-4701-a183-70fe89af5364", "100", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray42.Add(new AdventureItem(161, config83, config84, 15, 1, 1, 0, 1, 1, resCost42, itemCost41, restrictedByWorldPopulation: false, malice40, adventureParams40, "3b2788e1-7848-4a57-99fb-d3e955eda2db", startNodes40, transferNodes40, endNodes39, baseBranches39, advancedBranches, difficultyAddXiangshuLevel: true));
		List<AdventureItem> dataArray43 = _dataArray;
		string config85 = LocalStringManager.GetConfig("Adventure_language", "Name_162");
		string config86 = LocalStringManager.GetConfig("Adventure_language", "Desc_162");
		int[] resCost43 = new int[9];
		itemCost = new List<int[]>();
		List<int[]> itemCost42 = itemCost;
		short[] malice41 = new short[3];
		list = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams41 = list;
		List<AdventureStartNode> startNodes41 = new List<AdventureStartNode>
		{
			new AdventureStartNode("ca55717b-bdb2-4bf0-8db8-ce6c5776dbba", "A", "LK_Adventure_NodeTitle_482", 1)
		};
		transferNodes2 = new List<AdventureTransferNode>();
		List<AdventureTransferNode> transferNodes41 = transferNodes2;
		List<AdventureEndNode> endNodes40 = new List<AdventureEndNode>
		{
			new AdventureEndNode("2907b760-5138-4e84-92da-dda7519ca6ec", "B", "LK_Adventure_NodeTitle_483", 1)
		};
		List<AdventureBaseBranch> baseBranches40 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 5, "", new int[2] { 0, 10 }, new int[4] { 1, 2, 1, 10 }, new int[5] { 10, 10, 10, 50, 10 }, new string[7] { "0", "0", "0", "1", "4249e10e-f8f7-4701-a183-70fe89af5364", "100", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray43.Add(new AdventureItem(162, config85, config86, 15, 1, 1, 0, 1, 1, resCost43, itemCost42, restrictedByWorldPopulation: false, malice41, adventureParams41, "3b2788e1-7848-4a57-99fb-d3e955eda2db", startNodes41, transferNodes41, endNodes40, baseBranches40, advancedBranches, difficultyAddXiangshuLevel: true));
		List<AdventureItem> dataArray44 = _dataArray;
		string config87 = LocalStringManager.GetConfig("Adventure_language", "Name_163");
		string config88 = LocalStringManager.GetConfig("Adventure_language", "Desc_163");
		int[] resCost44 = new int[9];
		itemCost = new List<int[]>();
		List<int[]> itemCost43 = itemCost;
		short[] malice42 = new short[3];
		list = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams42 = list;
		List<AdventureStartNode> startNodes42 = new List<AdventureStartNode>
		{
			new AdventureStartNode("cb48e7b1-d944-4356-9956-ab515c3a7f0d", "A", "LK_Adventure_NodeTitle_482", 1)
		};
		transferNodes2 = new List<AdventureTransferNode>();
		List<AdventureTransferNode> transferNodes42 = transferNodes2;
		List<AdventureEndNode> endNodes41 = new List<AdventureEndNode>
		{
			new AdventureEndNode("d59cca48-3a1f-4803-bfd3-d8f1dd33aada", "B", "LK_Adventure_NodeTitle_483", 1)
		};
		List<AdventureBaseBranch> baseBranches41 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 5, "", new int[2] { 0, 10 }, new int[4] { 1, 2, 1, 10 }, new int[5] { 10, 10, 10, 50, 10 }, new string[7] { "0", "0", "0", "1", "4249e10e-f8f7-4701-a183-70fe89af5364", "100", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray44.Add(new AdventureItem(163, config87, config88, 15, 1, 1, 0, 1, 1, resCost44, itemCost43, restrictedByWorldPopulation: false, malice42, adventureParams42, "3b2788e1-7848-4a57-99fb-d3e955eda2db", startNodes42, transferNodes42, endNodes41, baseBranches41, advancedBranches, difficultyAddXiangshuLevel: true));
		List<AdventureItem> dataArray45 = _dataArray;
		string config89 = LocalStringManager.GetConfig("Adventure_language", "Name_164");
		string config90 = LocalStringManager.GetConfig("Adventure_language", "Desc_164");
		int[] resCost45 = new int[9];
		itemCost = new List<int[]>();
		List<int[]> itemCost44 = itemCost;
		short[] malice43 = new short[3];
		list = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams43 = list;
		List<AdventureStartNode> startNodes43 = new List<AdventureStartNode>
		{
			new AdventureStartNode("715ce0e1-084c-465e-9c5b-ac003df57075", "A", "LK_Adventure_NodeTitle_482", 1)
		};
		transferNodes2 = new List<AdventureTransferNode>();
		List<AdventureTransferNode> transferNodes43 = transferNodes2;
		List<AdventureEndNode> endNodes42 = new List<AdventureEndNode>
		{
			new AdventureEndNode("b0a4ad80-d1cd-4d1a-af81-56e2e0600cfc", "B", "LK_Adventure_NodeTitle_483", 1)
		};
		List<AdventureBaseBranch> baseBranches42 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 5, "", new int[2] { 0, 10 }, new int[4] { 1, 2, 1, 10 }, new int[5] { 10, 10, 10, 50, 10 }, new string[7] { "0", "0", "0", "1", "4249e10e-f8f7-4701-a183-70fe89af5364", "100", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray45.Add(new AdventureItem(164, config89, config90, 15, 1, 1, 0, 1, 1, resCost45, itemCost44, restrictedByWorldPopulation: false, malice43, adventureParams43, "3b2788e1-7848-4a57-99fb-d3e955eda2db", startNodes43, transferNodes43, endNodes42, baseBranches42, advancedBranches, difficultyAddXiangshuLevel: true));
		List<AdventureItem> dataArray46 = _dataArray;
		string config91 = LocalStringManager.GetConfig("Adventure_language", "Name_165");
		string config92 = LocalStringManager.GetConfig("Adventure_language", "Desc_165");
		int[] resCost46 = new int[9];
		itemCost = new List<int[]>();
		List<int[]> itemCost45 = itemCost;
		short[] malice44 = new short[3];
		list = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams44 = list;
		List<AdventureStartNode> startNodes44 = new List<AdventureStartNode>
		{
			new AdventureStartNode("0a07f509-f90f-45be-b44b-a59da0eb034f", "A", "LK_Adventure_NodeTitle_482", 1)
		};
		transferNodes2 = new List<AdventureTransferNode>();
		List<AdventureTransferNode> transferNodes44 = transferNodes2;
		List<AdventureEndNode> endNodes43 = new List<AdventureEndNode>
		{
			new AdventureEndNode("99446c33-627c-4ced-b8c4-bcee002c5dfb", "B", "LK_Adventure_NodeTitle_483", 1)
		};
		List<AdventureBaseBranch> baseBranches43 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 5, "", new int[2] { 0, 10 }, new int[4] { 1, 2, 1, 10 }, new int[5] { 10, 10, 10, 50, 10 }, new string[7] { "0", "0", "0", "1", "4249e10e-f8f7-4701-a183-70fe89af5364", "100", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray46.Add(new AdventureItem(165, config91, config92, 15, 1, 1, 0, 1, 1, resCost46, itemCost45, restrictedByWorldPopulation: false, malice44, adventureParams44, "50814a43-db4b-4012-a85f-00a44c7ee7f9", startNodes44, transferNodes44, endNodes43, baseBranches43, advancedBranches, difficultyAddXiangshuLevel: true));
		List<AdventureItem> dataArray47 = _dataArray;
		string config93 = LocalStringManager.GetConfig("Adventure_language", "Name_166");
		string config94 = LocalStringManager.GetConfig("Adventure_language", "Desc_166");
		int[] resCost47 = new int[9];
		itemCost = new List<int[]>();
		List<int[]> itemCost46 = itemCost;
		short[] malice45 = new short[3];
		list = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams45 = list;
		List<AdventureStartNode> startNodes45 = new List<AdventureStartNode>
		{
			new AdventureStartNode("024dbae5-4cfc-4e57-bcad-f8330d8f1097", "A", "LK_Adventure_NodeTitle_482", 1)
		};
		transferNodes2 = new List<AdventureTransferNode>();
		List<AdventureTransferNode> transferNodes45 = transferNodes2;
		List<AdventureEndNode> endNodes44 = new List<AdventureEndNode>
		{
			new AdventureEndNode("d97378b7-9c95-4540-ba79-cd71c188775b", "B", "LK_Adventure_NodeTitle_483", 1)
		};
		List<AdventureBaseBranch> baseBranches44 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 5, "", new int[2] { 0, 10 }, new int[4] { 1, 2, 1, 10 }, new int[5] { 10, 10, 10, 50, 10 }, new string[7] { "0", "0", "0", "1", "4249e10e-f8f7-4701-a183-70fe89af5364", "100", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray47.Add(new AdventureItem(166, config93, config94, 15, 1, 1, 0, 1, 1, resCost47, itemCost46, restrictedByWorldPopulation: false, malice45, adventureParams45, "50814a43-db4b-4012-a85f-00a44c7ee7f9", startNodes45, transferNodes45, endNodes44, baseBranches44, advancedBranches, difficultyAddXiangshuLevel: true));
		List<AdventureItem> dataArray48 = _dataArray;
		string config95 = LocalStringManager.GetConfig("Adventure_language", "Name_167");
		string config96 = LocalStringManager.GetConfig("Adventure_language", "Desc_167");
		int[] resCost48 = new int[9];
		itemCost = new List<int[]>();
		List<int[]> itemCost47 = itemCost;
		short[] malice46 = new short[3];
		list = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams46 = list;
		List<AdventureStartNode> startNodes46 = new List<AdventureStartNode>
		{
			new AdventureStartNode("43b10c6e-911a-4eed-a7a7-d969f15f8671", "A", "LK_Adventure_NodeTitle_482", 1)
		};
		transferNodes2 = new List<AdventureTransferNode>();
		List<AdventureTransferNode> transferNodes46 = transferNodes2;
		List<AdventureEndNode> endNodes45 = new List<AdventureEndNode>
		{
			new AdventureEndNode("aa791c84-bcce-4c28-a548-9eb17c560b7d", "B", "LK_Adventure_NodeTitle_483", 1)
		};
		List<AdventureBaseBranch> baseBranches45 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 5, "", new int[2] { 0, 10 }, new int[4] { 1, 2, 1, 10 }, new int[5] { 10, 10, 10, 50, 10 }, new string[7] { "0", "0", "0", "1", "4249e10e-f8f7-4701-a183-70fe89af5364", "100", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray48.Add(new AdventureItem(167, config95, config96, 15, 1, 1, 0, 1, 1, resCost48, itemCost47, restrictedByWorldPopulation: false, malice46, adventureParams46, "50814a43-db4b-4012-a85f-00a44c7ee7f9", startNodes46, transferNodes46, endNodes45, baseBranches45, advancedBranches, difficultyAddXiangshuLevel: true));
		List<AdventureItem> dataArray49 = _dataArray;
		string config97 = LocalStringManager.GetConfig("Adventure_language", "Name_168");
		string config98 = LocalStringManager.GetConfig("Adventure_language", "Desc_168");
		int[] resCost49 = new int[9];
		itemCost = new List<int[]>();
		List<int[]> itemCost48 = itemCost;
		short[] malice47 = new short[3];
		list = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams47 = list;
		List<AdventureStartNode> startNodes47 = new List<AdventureStartNode>
		{
			new AdventureStartNode("7885e5ce-8b47-42c7-8bee-38744ec7cf48", "A", "LK_Adventure_NodeTitle_482", 1)
		};
		transferNodes2 = new List<AdventureTransferNode>();
		List<AdventureTransferNode> transferNodes47 = transferNodes2;
		List<AdventureEndNode> endNodes46 = new List<AdventureEndNode>
		{
			new AdventureEndNode("ee206f37-6375-4cf9-a4a7-d61ce0938a06", "B", "LK_Adventure_NodeTitle_483", 1)
		};
		List<AdventureBaseBranch> baseBranches46 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 5, "", new int[2] { 0, 10 }, new int[4] { 1, 2, 1, 10 }, new int[5] { 10, 10, 10, 50, 10 }, new string[7] { "0", "0", "0", "1", "4249e10e-f8f7-4701-a183-70fe89af5364", "100", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray49.Add(new AdventureItem(168, config97, config98, 15, 1, 1, 0, 1, 1, resCost49, itemCost48, restrictedByWorldPopulation: false, malice47, adventureParams47, "50814a43-db4b-4012-a85f-00a44c7ee7f9", startNodes47, transferNodes47, endNodes46, baseBranches46, advancedBranches, difficultyAddXiangshuLevel: true));
		List<AdventureItem> dataArray50 = _dataArray;
		string config99 = LocalStringManager.GetConfig("Adventure_language", "Name_169");
		string config100 = LocalStringManager.GetConfig("Adventure_language", "Desc_169");
		int[] resCost50 = new int[9];
		itemCost = new List<int[]>();
		List<int[]> itemCost49 = itemCost;
		short[] malice48 = new short[3];
		list = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams48 = list;
		List<AdventureStartNode> startNodes48 = new List<AdventureStartNode>
		{
			new AdventureStartNode("1d6992b4-e42b-4cc1-88a7-b34b6b3b36a5", "A", "LK_Adventure_NodeTitle_482", 1)
		};
		transferNodes2 = new List<AdventureTransferNode>();
		List<AdventureTransferNode> transferNodes48 = transferNodes2;
		List<AdventureEndNode> endNodes47 = new List<AdventureEndNode>
		{
			new AdventureEndNode("3f6cbf3d-aedd-4e87-a3bf-e294f7b3fa1a", "B", "LK_Adventure_NodeTitle_483", 1)
		};
		List<AdventureBaseBranch> baseBranches47 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 5, "", new int[2] { 0, 10 }, new int[4] { 1, 2, 1, 10 }, new int[5] { 10, 10, 10, 50, 10 }, new string[7] { "0", "0", "0", "1", "4249e10e-f8f7-4701-a183-70fe89af5364", "100", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray50.Add(new AdventureItem(169, config99, config100, 15, 1, 1, 0, 1, 1, resCost50, itemCost49, restrictedByWorldPopulation: false, malice48, adventureParams48, "50814a43-db4b-4012-a85f-00a44c7ee7f9", startNodes48, transferNodes48, endNodes47, baseBranches47, advancedBranches, difficultyAddXiangshuLevel: true));
		List<AdventureItem> dataArray51 = _dataArray;
		string config101 = LocalStringManager.GetConfig("Adventure_language", "Name_170");
		string config102 = LocalStringManager.GetConfig("Adventure_language", "Desc_170");
		int[] resCost51 = new int[9];
		itemCost = new List<int[]>();
		List<int[]> itemCost50 = itemCost;
		short[] malice49 = new short[3];
		list = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams49 = list;
		List<AdventureStartNode> startNodes49 = new List<AdventureStartNode>
		{
			new AdventureStartNode("8f417f2e-5b25-4a0f-871e-6a845b475aa5", "A", "LK_Adventure_NodeTitle_482", 1)
		};
		transferNodes2 = new List<AdventureTransferNode>();
		List<AdventureTransferNode> transferNodes49 = transferNodes2;
		List<AdventureEndNode> endNodes48 = new List<AdventureEndNode>
		{
			new AdventureEndNode("f4640376-e1e2-4919-8b17-33dd078c7036", "B", "LK_Adventure_NodeTitle_483", 1)
		};
		List<AdventureBaseBranch> baseBranches48 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 5, "", new int[2] { 0, 10 }, new int[4] { 1, 2, 1, 10 }, new int[5] { 10, 10, 10, 50, 10 }, new string[7] { "0", "0", "0", "1", "4249e10e-f8f7-4701-a183-70fe89af5364", "100", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray51.Add(new AdventureItem(170, config101, config102, 15, 1, 1, 0, 1, 1, resCost51, itemCost50, restrictedByWorldPopulation: false, malice49, adventureParams49, "50814a43-db4b-4012-a85f-00a44c7ee7f9", startNodes49, transferNodes49, endNodes48, baseBranches48, advancedBranches, difficultyAddXiangshuLevel: true));
		List<AdventureItem> dataArray52 = _dataArray;
		string config103 = LocalStringManager.GetConfig("Adventure_language", "Name_171");
		string config104 = LocalStringManager.GetConfig("Adventure_language", "Desc_171");
		int[] resCost52 = new int[9];
		itemCost = new List<int[]>();
		List<int[]> itemCost51 = itemCost;
		short[] malice50 = new short[3];
		list = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams50 = list;
		List<AdventureStartNode> startNodes50 = new List<AdventureStartNode>
		{
			new AdventureStartNode("01318833-27f2-4128-9faa-934108a12cea", "A", "LK_Adventure_NodeTitle_482", 1)
		};
		transferNodes2 = new List<AdventureTransferNode>();
		List<AdventureTransferNode> transferNodes50 = transferNodes2;
		List<AdventureEndNode> endNodes49 = new List<AdventureEndNode>
		{
			new AdventureEndNode("331d5e95-c525-4e84-a310-0739e9fd98ef", "B", "LK_Adventure_NodeTitle_483", 1)
		};
		List<AdventureBaseBranch> baseBranches49 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 5, "", new int[2] { 0, 10 }, new int[4] { 1, 2, 1, 10 }, new int[5] { 10, 10, 10, 50, 10 }, new string[7] { "0", "0", "0", "1", "4249e10e-f8f7-4701-a183-70fe89af5364", "100", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray52.Add(new AdventureItem(171, config103, config104, 15, 1, 1, 0, 1, 1, resCost52, itemCost51, restrictedByWorldPopulation: false, malice50, adventureParams50, "50814a43-db4b-4012-a85f-00a44c7ee7f9", startNodes50, transferNodes50, endNodes49, baseBranches49, advancedBranches, difficultyAddXiangshuLevel: true));
		List<AdventureItem> dataArray53 = _dataArray;
		string config105 = LocalStringManager.GetConfig("Adventure_language", "Name_172");
		string config106 = LocalStringManager.GetConfig("Adventure_language", "Desc_172");
		int[] resCost53 = new int[9];
		itemCost = new List<int[]>();
		List<int[]> itemCost52 = itemCost;
		short[] malice51 = new short[3];
		list = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams51 = list;
		List<AdventureStartNode> startNodes51 = new List<AdventureStartNode>
		{
			new AdventureStartNode("b7fb79e2-e44e-4388-a150-a4c513a3e6f4", "A", "LK_Adventure_NodeTitle_482", 1)
		};
		transferNodes2 = new List<AdventureTransferNode>();
		List<AdventureTransferNode> transferNodes51 = transferNodes2;
		List<AdventureEndNode> endNodes50 = new List<AdventureEndNode>
		{
			new AdventureEndNode("0beb4ea1-5cb3-41d5-a4f5-2397055352c2", "B", "LK_Adventure_NodeTitle_483", 1)
		};
		List<AdventureBaseBranch> baseBranches50 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 5, "", new int[2] { 0, 10 }, new int[4] { 1, 2, 1, 10 }, new int[5] { 10, 10, 10, 50, 10 }, new string[7] { "0", "0", "0", "1", "4249e10e-f8f7-4701-a183-70fe89af5364", "100", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray53.Add(new AdventureItem(172, config105, config106, 15, 1, 1, 0, 1, 1, resCost53, itemCost52, restrictedByWorldPopulation: false, malice51, adventureParams51, "50814a43-db4b-4012-a85f-00a44c7ee7f9", startNodes51, transferNodes51, endNodes50, baseBranches50, advancedBranches, difficultyAddXiangshuLevel: true));
		List<AdventureItem> dataArray54 = _dataArray;
		string config107 = LocalStringManager.GetConfig("Adventure_language", "Name_173");
		string config108 = LocalStringManager.GetConfig("Adventure_language", "Desc_173");
		int[] resCost54 = new int[9];
		itemCost = new List<int[]>();
		List<int[]> itemCost53 = itemCost;
		short[] malice52 = new short[3];
		list = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams52 = list;
		List<AdventureStartNode> startNodes52 = new List<AdventureStartNode>
		{
			new AdventureStartNode("19580f84-6860-44fe-8bce-a3790be2afdb", "A", "LK_Adventure_NodeTitle_482", 1)
		};
		transferNodes2 = new List<AdventureTransferNode>();
		List<AdventureTransferNode> transferNodes52 = transferNodes2;
		List<AdventureEndNode> endNodes51 = new List<AdventureEndNode>
		{
			new AdventureEndNode("7b6cb4c2-c211-4c3c-8480-ac27c4c88124", "B", "LK_Adventure_NodeTitle_483", 1)
		};
		List<AdventureBaseBranch> baseBranches51 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 5, "", new int[2] { 0, 10 }, new int[4] { 1, 2, 1, 10 }, new int[5] { 10, 10, 10, 50, 10 }, new string[7] { "0", "0", "0", "1", "4249e10e-f8f7-4701-a183-70fe89af5364", "100", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray54.Add(new AdventureItem(173, config107, config108, 15, 1, 1, 0, 1, 1, resCost54, itemCost53, restrictedByWorldPopulation: false, malice52, adventureParams52, "50814a43-db4b-4012-a85f-00a44c7ee7f9", startNodes52, transferNodes52, endNodes51, baseBranches51, advancedBranches, difficultyAddXiangshuLevel: true));
		List<AdventureItem> dataArray55 = _dataArray;
		string config109 = LocalStringManager.GetConfig("Adventure_language", "Name_174");
		string config110 = LocalStringManager.GetConfig("Adventure_language", "Desc_174");
		int[] resCost55 = new int[9];
		itemCost = new List<int[]>();
		List<int[]> itemCost54 = itemCost;
		short[] malice53 = new short[3];
		list = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams53 = list;
		List<AdventureStartNode> startNodes53 = new List<AdventureStartNode>
		{
			new AdventureStartNode("40a30f71-90cc-4157-8c1b-e8ad268eb54d", "A", "LK_Adventure_NodeTitle_484", 18)
		};
		transferNodes2 = new List<AdventureTransferNode>();
		dataArray55.Add(new AdventureItem(174, config109, config110, 15, 1, 9, 0, 1, -1, resCost55, itemCost54, restrictedByWorldPopulation: false, malice53, adventureParams53, "e2686499-138b-435f-9404-6744a0a03d2a", startNodes53, transferNodes2, new List<AdventureEndNode>
		{
			new AdventureEndNode("8e3fa697-0652-4b83-870b-24663d5b91a8", "B", "LK_Adventure_NodeTitle_484", 16)
		}, new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 3, "", new int[2] { 15, 1 }, new int[10] { 3, 2, 4, 1, 2, 16, 1, 2, 21, 1 }, new int[5] { 100, 100, 100, 100, 100 }, new string[5] { "0", "0", "0", "0", "0" }, new int[5], new int[85]
			{
				4, 12, 4, 1, 20, 12, 5, 1, 40, 12,
				6, 1, 30, 12, 7, 1, 10, 4, 12, 4,
				1, 20, 12, 5, 1, 40, 12, 6, 1, 30,
				12, 7, 1, 10, 4, 12, 4, 1, 20, 12,
				5, 1, 40, 12, 6, 1, 30, 12, 7, 1,
				10, 4, 12, 4, 1, 20, 12, 5, 1, 40,
				12, 6, 1, 30, 12, 7, 1, 10, 4, 12,
				4, 1, 20, 12, 5, 1, 40, 12, 6, 1,
				30, 12, 7, 1, 10
			}, new string[5] { "0", "0", "0", "0", "0" })
		}, new List<AdventureAdvancedBranch>
		{
			new AdventureAdvancedBranch(1, "", 0, 15, 180, new int[2] { 15, 1 }, new int[9] { 1, 7, 16, 1, 0, 0, 1, 0, 0 }, new int[5] { 10, 10, 0, 10, 10 }, new string[7] { "0", "0", "1", "87fb368b-9762-4348-8084-b055a3c6a16c", "100", "0", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray56 = _dataArray;
		string config111 = LocalStringManager.GetConfig("Adventure_language", "Name_175");
		string config112 = LocalStringManager.GetConfig("Adventure_language", "Desc_175");
		int[] resCost56 = new int[9];
		itemCost = new List<int[]>();
		List<int[]> itemCost55 = itemCost;
		short[] malice54 = new short[3];
		list = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams54 = list;
		List<AdventureStartNode> startNodes54 = new List<AdventureStartNode>
		{
			new AdventureStartNode("0960d0fd-104e-4708-b930-167e0927ba90", "A", "LK_Adventure_NodeTitle_484", 18)
		};
		transferNodes2 = new List<AdventureTransferNode>();
		dataArray56.Add(new AdventureItem(175, config111, config112, 15, 1, 9, 0, 1, -1, resCost56, itemCost55, restrictedByWorldPopulation: false, malice54, adventureParams54, "9090299c-4f6e-4485-9ca5-10f487898e98", startNodes54, transferNodes2, new List<AdventureEndNode>
		{
			new AdventureEndNode("c22cfab2-f774-497b-a02a-3b4a345a7d5f", "B", "LK_Adventure_NodeTitle_484", 22)
		}, new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 3, "", new int[2] { 10, 1 }, new int[10] { 3, 2, 4, 1, 2, 11, 1, 2, 10, 1 }, new int[5] { 100, 100, 100, 100, 100 }, new string[5] { "0", "0", "0", "0", "0" }, new int[5], new int[85]
			{
				4, 12, 4, 1, 20, 12, 5, 1, 40, 12,
				6, 1, 30, 12, 7, 1, 10, 4, 12, 4,
				1, 20, 12, 5, 1, 40, 12, 6, 1, 30,
				12, 7, 1, 10, 4, 12, 4, 1, 20, 12,
				5, 1, 40, 12, 6, 1, 30, 12, 7, 1,
				10, 4, 12, 4, 1, 20, 12, 5, 1, 40,
				12, 6, 1, 30, 12, 7, 1, 10, 4, 12,
				4, 1, 20, 12, 5, 1, 40, 12, 6, 1,
				30, 12, 7, 1, 10
			}, new string[5] { "0", "0", "0", "0", "0" })
		}, new List<AdventureAdvancedBranch>
		{
			new AdventureAdvancedBranch(1, "", 0, 10, 180, new int[2] { 10, 1 }, new int[9] { 1, 7, 16, 1, 0, 0, 1, 0, 0 }, new int[5] { 10, 10, 0, 10, 10 }, new string[7] { "0", "0", "1", "a6e40f68-e709-4564-8065-1e7b6754c5c8", "100", "0", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray57 = _dataArray;
		string config113 = LocalStringManager.GetConfig("Adventure_language", "Name_176");
		string config114 = LocalStringManager.GetConfig("Adventure_language", "Desc_176");
		int[] resCost57 = new int[9];
		itemCost = new List<int[]>();
		List<int[]> itemCost56 = itemCost;
		short[] malice55 = new short[3];
		list = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams55 = list;
		List<AdventureStartNode> startNodes55 = new List<AdventureStartNode>
		{
			new AdventureStartNode("b37dd8e3-b162-4c25-ae13-a6995c50ba62", "A", "LK_Adventure_NodeTitle_484", 18)
		};
		transferNodes2 = new List<AdventureTransferNode>();
		dataArray57.Add(new AdventureItem(176, config113, config114, 15, 1, 9, 0, 1, -1, resCost57, itemCost56, restrictedByWorldPopulation: false, malice55, adventureParams55, "c0caacf1-3746-4e6a-a038-f944e4162fa4", startNodes55, transferNodes2, new List<AdventureEndNode>
		{
			new AdventureEndNode("db0721f6-9b39-4e0a-8f2f-fb2e91142904", "B", "LK_Adventure_NodeTitle_484", 22)
		}, new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 3, "", new int[2] { 5, 1 }, new int[10] { 3, 2, 13, 1, 2, 12, 1, 2, 19, 1 }, new int[5] { 100, 100, 100, 100, 100 }, new string[5] { "0", "0", "0", "0", "0" }, new int[5], new int[85]
			{
				4, 12, 4, 1, 20, 12, 5, 1, 40, 12,
				6, 1, 30, 12, 7, 1, 10, 4, 12, 4,
				1, 20, 12, 5, 1, 40, 12, 6, 1, 30,
				12, 7, 1, 10, 4, 12, 4, 1, 20, 12,
				5, 1, 40, 12, 6, 1, 30, 12, 7, 1,
				10, 4, 12, 4, 1, 20, 12, 5, 1, 40,
				12, 6, 1, 30, 12, 7, 1, 10, 4, 12,
				4, 1, 20, 12, 5, 1, 40, 12, 6, 1,
				30, 12, 7, 1, 10
			}, new string[5] { "0", "0", "0", "0", "0" })
		}, new List<AdventureAdvancedBranch>
		{
			new AdventureAdvancedBranch(1, "", 0, 5, 180, new int[2] { 5, 1 }, new int[9] { 1, 7, 16, 1, 0, 0, 1, 0, 0 }, new int[5] { 10, 10, 0, 10, 10 }, new string[7] { "0", "0", "1", "9414de39-0cb5-47eb-8a38-3e827198ab58", "100", "0", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray58 = _dataArray;
		string config115 = LocalStringManager.GetConfig("Adventure_language", "Name_177");
		string config116 = LocalStringManager.GetConfig("Adventure_language", "Desc_177");
		int[] resCost58 = new int[9];
		itemCost = new List<int[]>();
		List<int[]> itemCost57 = itemCost;
		short[] malice56 = new short[3];
		list = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams56 = list;
		List<AdventureStartNode> startNodes56 = new List<AdventureStartNode>
		{
			new AdventureStartNode("29674f0a-6ae8-4aed-b506-42adcb6c2770", "A", "LK_Adventure_NodeTitle_484", 18)
		};
		transferNodes2 = new List<AdventureTransferNode>();
		dataArray58.Add(new AdventureItem(177, config115, config116, 15, 1, 9, 0, 1, -1, resCost58, itemCost57, restrictedByWorldPopulation: false, malice56, adventureParams56, "2674db67-17b5-45d9-9d24-9cececbe22ed", startNodes56, transferNodes2, new List<AdventureEndNode>
		{
			new AdventureEndNode("6ba086b3-147b-4433-8d79-c2f65449f22b", "B", "LK_Adventure_NodeTitle_484", 16)
		}, new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 3, "", new int[2] { 6, 1 }, new int[10] { 3, 2, 17, 1, 2, 18, 1, 2, 1, 1 }, new int[5] { 100, 100, 100, 100, 100 }, new string[5] { "0", "0", "0", "0", "0" }, new int[5], new int[85]
			{
				4, 12, 4, 1, 20, 12, 5, 1, 40, 12,
				6, 1, 30, 12, 7, 1, 10, 4, 12, 4,
				1, 20, 12, 5, 1, 40, 12, 6, 1, 30,
				12, 7, 1, 10, 4, 12, 4, 1, 20, 12,
				5, 1, 40, 12, 6, 1, 30, 12, 7, 1,
				10, 4, 12, 4, 1, 20, 12, 5, 1, 40,
				12, 6, 1, 30, 12, 7, 1, 10, 4, 12,
				4, 1, 20, 12, 5, 1, 40, 12, 6, 1,
				30, 12, 7, 1, 10
			}, new string[5] { "0", "0", "0", "0", "0" })
		}, new List<AdventureAdvancedBranch>
		{
			new AdventureAdvancedBranch(1, "", 0, 6, 180, new int[2] { 6, 1 }, new int[9] { 1, 7, 16, 1, 0, 0, 1, 0, 0 }, new int[5] { 10, 10, 0, 10, 10 }, new string[7] { "0", "0", "1", "3b034949-279e-4cc3-afaf-542264c1256d", "100", "0", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray59 = _dataArray;
		string config117 = LocalStringManager.GetConfig("Adventure_language", "Name_178");
		string config118 = LocalStringManager.GetConfig("Adventure_language", "Desc_178");
		int[] resCost59 = new int[9];
		itemCost = new List<int[]>();
		List<int[]> itemCost58 = itemCost;
		short[] malice57 = new short[3];
		list = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams57 = list;
		List<AdventureStartNode> startNodes57 = new List<AdventureStartNode>
		{
			new AdventureStartNode("4b769621-15dc-4fd0-9f0d-244aaba729e7", "A", "LK_Adventure_NodeTitle_484", 18)
		};
		transferNodes2 = new List<AdventureTransferNode>();
		dataArray59.Add(new AdventureItem(178, config117, config118, 15, 1, 9, 0, 1, -1, resCost59, itemCost58, restrictedByWorldPopulation: false, malice57, adventureParams57, "17192117-357c-4308-99c6-f3b49b1a8a95", startNodes57, transferNodes2, new List<AdventureEndNode>
		{
			new AdventureEndNode("ec32c3a4-f7c4-448c-863c-2d077fae256e", "B", "LK_Adventure_NodeTitle_484", 22)
		}, new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 3, "", new int[2] { 4, 1 }, new int[10] { 3, 2, 1, 1, 2, 22, 1, 2, 4, 1 }, new int[5] { 100, 100, 100, 100, 100 }, new string[5] { "0", "0", "0", "0", "0" }, new int[5], new int[85]
			{
				4, 12, 4, 1, 20, 12, 5, 1, 40, 12,
				6, 1, 30, 12, 7, 1, 10, 4, 12, 4,
				1, 20, 12, 5, 1, 40, 12, 6, 1, 30,
				12, 7, 1, 10, 4, 12, 4, 1, 20, 12,
				5, 1, 40, 12, 6, 1, 30, 12, 7, 1,
				10, 4, 12, 4, 1, 20, 12, 5, 1, 40,
				12, 6, 1, 30, 12, 7, 1, 10, 4, 12,
				4, 1, 20, 12, 5, 1, 40, 12, 6, 1,
				30, 12, 7, 1, 10
			}, new string[5] { "0", "0", "0", "0", "0" })
		}, new List<AdventureAdvancedBranch>
		{
			new AdventureAdvancedBranch(1, "", 0, 4, 180, new int[2] { 4, 1 }, new int[9] { 1, 7, 16, 1, 0, 0, 1, 0, 0 }, new int[5] { 10, 10, 0, 10, 10 }, new string[7] { "0", "0", "1", "0df16ffe-e359-4a8c-8076-a4f8bff64ee3", "100", "0", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray60 = _dataArray;
		string config119 = LocalStringManager.GetConfig("Adventure_language", "Name_179");
		string config120 = LocalStringManager.GetConfig("Adventure_language", "Desc_179");
		int[] resCost60 = new int[9];
		itemCost = new List<int[]>();
		List<int[]> itemCost59 = itemCost;
		short[] malice58 = new short[3];
		list = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams58 = list;
		List<AdventureStartNode> startNodes58 = new List<AdventureStartNode>
		{
			new AdventureStartNode("095ef4ea-5a97-4f0d-ac9c-9d351bee84ab", "A", "LK_Adventure_NodeTitle_484", 18)
		};
		transferNodes2 = new List<AdventureTransferNode>();
		dataArray60.Add(new AdventureItem(179, config119, config120, 15, 1, 9, 0, 1, -1, resCost60, itemCost59, restrictedByWorldPopulation: false, malice58, adventureParams58, "c8c653dd-8dec-41f2-985f-ea95cd5b0965", startNodes58, transferNodes2, new List<AdventureEndNode>
		{
			new AdventureEndNode("07ee2a4d-43a9-4bef-be6d-119d8cab77a5", "B", "LK_Adventure_NodeTitle_484", 22)
		}, new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 3, "", new int[2] { 14, 1 }, new int[10] { 3, 2, 2, 1, 2, 22, 1, 2, 3, 1 }, new int[5] { 100, 100, 100, 100, 100 }, new string[5] { "0", "0", "0", "0", "0" }, new int[5], new int[85]
			{
				4, 12, 4, 1, 20, 12, 5, 1, 40, 12,
				6, 1, 30, 12, 7, 1, 10, 4, 12, 4,
				1, 20, 12, 5, 1, 40, 12, 6, 1, 30,
				12, 7, 1, 10, 4, 12, 4, 1, 20, 12,
				5, 1, 40, 12, 6, 1, 30, 12, 7, 1,
				10, 4, 12, 4, 1, 20, 12, 5, 1, 40,
				12, 6, 1, 30, 12, 7, 1, 10, 4, 12,
				4, 1, 20, 12, 5, 1, 40, 12, 6, 1,
				30, 12, 7, 1, 10
			}, new string[5] { "0", "0", "0", "0", "0" })
		}, new List<AdventureAdvancedBranch>
		{
			new AdventureAdvancedBranch(1, "", 0, 14, 180, new int[2] { 14, 1 }, new int[9] { 1, 7, 16, 1, 0, 0, 1, 0, 0 }, new int[5] { 10, 10, 0, 10, 10 }, new string[7] { "0", "0", "1", "f46d3b28-591b-41e3-9a2a-f1fdfe1a139f", "100", "0", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, difficultyAddXiangshuLevel: false));
	}

	private void CreateItems3()
	{
		List<AdventureItem> dataArray = _dataArray;
		string config = LocalStringManager.GetConfig("Adventure_language", "Name_180");
		string config2 = LocalStringManager.GetConfig("Adventure_language", "Desc_180");
		int[] resCost = new int[9];
		List<int[]> list = new List<int[]>();
		List<int[]> itemCost = list;
		short[] malice = new short[3];
		List<(string, string, string, string)> list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams = list2;
		List<AdventureStartNode> startNodes = new List<AdventureStartNode>
		{
			new AdventureStartNode("fc4b72cc-146e-4c3f-a011-fb5f45f025a7", "A", "LK_Adventure_NodeTitle_484", 18)
		};
		List<AdventureTransferNode> transferNodes = new List<AdventureTransferNode>();
		dataArray.Add(new AdventureItem(180, config, config2, 15, 1, 9, 0, 1, -1, resCost, itemCost, restrictedByWorldPopulation: false, malice, adventureParams, "035f7fbf-9436-4a69-abf9-77fec7e7fb22", startNodes, transferNodes, new List<AdventureEndNode>
		{
			new AdventureEndNode("363874bf-60e3-4f7f-840a-f96dffd45b05", "B", "LK_Adventure_NodeTitle_484", 16)
		}, new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 3, "", new int[2] { 8, 1 }, new int[10] { 3, 2, 11, 1, 2, 10, 1, 2, 5, 1 }, new int[5] { 100, 100, 100, 100, 100 }, new string[5] { "0", "0", "0", "0", "0" }, new int[5], new int[85]
			{
				4, 12, 4, 1, 20, 12, 5, 1, 40, 12,
				6, 1, 30, 12, 7, 1, 10, 4, 12, 4,
				1, 20, 12, 5, 1, 40, 12, 6, 1, 30,
				12, 7, 1, 10, 4, 12, 4, 1, 20, 12,
				5, 1, 40, 12, 6, 1, 30, 12, 7, 1,
				10, 4, 12, 4, 1, 20, 12, 5, 1, 40,
				12, 6, 1, 30, 12, 7, 1, 10, 4, 12,
				4, 1, 20, 12, 5, 1, 40, 12, 6, 1,
				30, 12, 7, 1, 10
			}, new string[5] { "0", "0", "0", "0", "0" })
		}, new List<AdventureAdvancedBranch>
		{
			new AdventureAdvancedBranch(1, "", 0, 8, 180, new int[2] { 8, 1 }, new int[9] { 1, 7, 16, 1, 0, 0, 1, 0, 0 }, new int[5] { 10, 10, 0, 10, 10 }, new string[7] { "0", "0", "1", "559ea94b-fcd7-4e85-b213-bdf7fd7bfd7f", "100", "0", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray2 = _dataArray;
		string config3 = LocalStringManager.GetConfig("Adventure_language", "Name_181");
		string config4 = LocalStringManager.GetConfig("Adventure_language", "Desc_181");
		int[] resCost2 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost2 = list;
		short[] malice2 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams2 = list2;
		List<AdventureStartNode> startNodes2 = new List<AdventureStartNode>
		{
			new AdventureStartNode("484dc041-94e2-4a04-87b4-9a3d7fcef91e", "A", "LK_Adventure_NodeTitle_484", 18)
		};
		transferNodes = new List<AdventureTransferNode>();
		dataArray2.Add(new AdventureItem(181, config3, config4, 15, 1, 9, 0, 1, -1, resCost2, itemCost2, restrictedByWorldPopulation: false, malice2, adventureParams2, "cd0c5e4e-6d43-4e9e-aeb6-3aa8eb13147c", startNodes2, transferNodes, new List<AdventureEndNode>
		{
			new AdventureEndNode("396e1f22-7006-428e-bc94-7da47f9d26c1", "B", "LK_Adventure_NodeTitle_484", 22)
		}, new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 3, "", new int[2] { 7, 1 }, new int[10] { 3, 2, 17, 1, 2, 18, 1, 2, 11, 1 }, new int[5] { 100, 100, 100, 100, 100 }, new string[5] { "0", "0", "0", "0", "0" }, new int[5], new int[85]
			{
				4, 12, 4, 1, 20, 12, 5, 1, 40, 12,
				6, 1, 30, 12, 7, 1, 10, 4, 12, 4,
				1, 20, 12, 5, 1, 40, 12, 6, 1, 30,
				12, 7, 1, 10, 4, 12, 4, 1, 20, 12,
				5, 1, 40, 12, 6, 1, 30, 12, 7, 1,
				10, 4, 12, 4, 1, 20, 12, 5, 1, 40,
				12, 6, 1, 30, 12, 7, 1, 10, 4, 12,
				4, 1, 20, 12, 5, 1, 40, 12, 6, 1,
				30, 12, 7, 1, 10
			}, new string[5] { "0", "0", "0", "0", "0" })
		}, new List<AdventureAdvancedBranch>
		{
			new AdventureAdvancedBranch(1, "", 0, 7, 180, new int[2] { 7, 1 }, new int[9] { 1, 7, 16, 1, 0, 0, 1, 0, 0 }, new int[5] { 10, 10, 0, 10, 10 }, new string[7] { "0", "0", "1", "a1519b97-b82a-4fa4-94c4-52ed7a5fdcf4", "100", "0", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray3 = _dataArray;
		string config5 = LocalStringManager.GetConfig("Adventure_language", "Name_182");
		string config6 = LocalStringManager.GetConfig("Adventure_language", "Desc_182");
		int[] resCost3 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost3 = list;
		short[] malice3 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams3 = list2;
		List<AdventureStartNode> startNodes3 = new List<AdventureStartNode>
		{
			new AdventureStartNode("68d1b2e1-c26f-46e5-9ebd-294dc12f2a6f", "A", "LK_Adventure_NodeTitle_484", 18)
		};
		transferNodes = new List<AdventureTransferNode>();
		dataArray3.Add(new AdventureItem(182, config5, config6, 15, 1, 9, 0, 1, -1, resCost3, itemCost3, restrictedByWorldPopulation: false, malice3, adventureParams3, "31fc88a9-5764-44e6-b4a4-816cd344875f", startNodes3, transferNodes, new List<AdventureEndNode>
		{
			new AdventureEndNode("c337fbba-cad0-4495-a057-5c1be5d79f3b", "B", "LK_Adventure_NodeTitle_484", 22)
		}, new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 1, "1", 1, 3, "", new int[2] { 11, 1 }, new int[10] { 3, 2, 6, 1, 2, 11, 1, 2, 12, 1 }, new int[5] { 100, 100, 100, 100, 100 }, new string[5] { "0", "0", "0", "0", "0" }, new int[5], new int[85]
			{
				4, 12, 4, 1, 20, 12, 5, 1, 40, 12,
				6, 1, 30, 12, 7, 1, 10, 4, 12, 4,
				1, 20, 12, 5, 1, 40, 12, 6, 1, 30,
				12, 7, 1, 10, 4, 12, 4, 1, 20, 12,
				5, 1, 40, 12, 6, 1, 30, 12, 7, 1,
				10, 4, 12, 4, 1, 20, 12, 5, 1, 40,
				12, 6, 1, 30, 12, 7, 1, 10, 4, 12,
				4, 1, 20, 12, 5, 1, 40, 12, 6, 1,
				30, 12, 7, 1, 10
			}, new string[5] { "0", "0", "0", "0", "0" })
		}, new List<AdventureAdvancedBranch>
		{
			new AdventureAdvancedBranch(1, "", 0, 11, 180, new int[2] { 11, 1 }, new int[9] { 1, 7, 16, 1, 0, 0, 1, 0, 0 }, new int[5] { 10, 10, 0, 10, 10 }, new string[7] { "0", "0", "1", "b28f29d4-846c-4e1f-a27c-4bc0a8b3936e", "100", "0", "0" }, new int[5], new int[5], new string[5] { "0", "0", "0", "0", "0" })
		}, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray4 = _dataArray;
		string config7 = LocalStringManager.GetConfig("Adventure_language", "Name_183");
		string config8 = LocalStringManager.GetConfig("Adventure_language", "Desc_183");
		int[] resCost4 = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 2500 };
		list = new List<int[]>();
		List<int[]> itemCost4 = list;
		short[] malice4 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams4 = list2;
		List<AdventureStartNode> startNodes4 = new List<AdventureStartNode>
		{
			new AdventureStartNode("0b072fa2-f556-4a90-8a13-8066bdbd35e3", "E", "LK_Adventure_NodeTitle_485", 0),
			new AdventureStartNode("4efccfc4-b3f8-4833-9751-a6cb2a8d52b9", "A", "LK_Adventure_NodeTitle_485", 0)
		};
		List<AdventureTransferNode> transferNodes2 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("87587fe9-1f60-4cbf-9098-33e225275ea9", "B", "LK_Adventure_NodeTitle_486", 0),
			new AdventureTransferNode("4f244dea-2171-4eb3-a5dd-9a198009b820", "F", "LK_Adventure_NodeTitle_486", 0),
			new AdventureTransferNode("87587fe9-1f60-4cbf-9098-33e225275ea9", "C", "LK_Adventure_NodeTitle_486", 0),
			new AdventureTransferNode("4f244dea-2171-4eb3-a5dd-9a198009b820", "G", "LK_Adventure_NodeTitle_486", 0)
		};
		List<AdventureEndNode> endNodes = new List<AdventureEndNode>
		{
			new AdventureEndNode("5d336ffc-c809-47c9-9b7b-bf5e6bc91f56", "H", "LK_Adventure_NodeTitle_487", 0),
			new AdventureEndNode("5d336ffc-c809-47c9-9b7b-bf5e6bc91f56", "D", "LK_Adventure_NodeTitle_487", 0)
		};
		List<AdventureBaseBranch> baseBranches = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(1, 2, "1", 1, 5, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 9, 25, 10, 10, 20, 50, 10, 7,
				13, 25, 10, 10, 20, 50, 10, 7, 17, 25,
				10, 10, 20, 50, 10, 7, 19, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 15, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "10", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "5", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "30",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "5", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 4, "2", 1, 5, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 9, 25, 10, 10, 20, 50, 10, 7,
				13, 25, 10, 10, 20, 50, 10, 7, 17, 25,
				10, 10, 20, 50, 10, 7, 19, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 30, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "45", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "30", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "10",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "10", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(4, 7, "3", 1, 5, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 9, 25, 10, 10, 20, 50, 10, 7,
				13, 25, 10, 10, 20, 50, 10, 7, 17, 25,
				10, 10, 20, 50, 10, 7, 19, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 15, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "10", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "30", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "5",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "5", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(0, 3, "4", 1, 10, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 9, 25, 10, 10, 20, 50, 10, 7,
				13, 25, 10, 10, 20, 50, 10, 7, 17, 25,
				10, 10, 20, 50, 10, 7, 19, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 15, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "10", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "5", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "30",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "5", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 5, "5", 1, 10, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 9, 25, 10, 10, 20, 50, 10, 7,
				13, 25, 10, 10, 20, 50, 10, 7, 17, 25,
				10, 10, 20, 50, 10, 7, 19, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 30, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "45", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "30", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "10",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "10", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(5, 6, "6", 1, 10, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 9, 25, 10, 10, 20, 50, 10, 7,
				13, 25, 10, 10, 20, 50, 10, 7, 17, 25,
				10, 10, 20, 50, 10, 7, 19, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 15, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "10", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "30", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "5",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "5", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" })
		};
		List<AdventureAdvancedBranch> advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray4.Add(new AdventureItem(183, config7, config8, 17, 7, 7, 2, 10, 6, resCost4, itemCost4, restrictedByWorldPopulation: false, malice4, adventureParams4, "2c18c022-83e0-407f-9982-1db1b2915a6b", startNodes4, transferNodes2, endNodes, baseBranches, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray5 = _dataArray;
		string config9 = LocalStringManager.GetConfig("Adventure_language", "Name_184");
		string config10 = LocalStringManager.GetConfig("Adventure_language", "Desc_184");
		int[] resCost5 = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 2500 };
		list = new List<int[]>();
		List<int[]> itemCost5 = list;
		short[] malice5 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams5 = list2;
		List<AdventureStartNode> startNodes5 = new List<AdventureStartNode>
		{
			new AdventureStartNode("4efccfc4-b3f8-4833-9751-a6cb2a8d52b9", "A", "LK_Adventure_NodeTitle_485", 0),
			new AdventureStartNode("0b072fa2-f556-4a90-8a13-8066bdbd35e3", "E", "LK_Adventure_NodeTitle_485", 0)
		};
		List<AdventureTransferNode> transferNodes3 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("4f244dea-2171-4eb3-a5dd-9a198009b820", "G", "LK_Adventure_NodeTitle_486", 0),
			new AdventureTransferNode("87587fe9-1f60-4cbf-9098-33e225275ea9", "C", "LK_Adventure_NodeTitle_486", 0),
			new AdventureTransferNode("4f244dea-2171-4eb3-a5dd-9a198009b820", "F", "LK_Adventure_NodeTitle_486", 0),
			new AdventureTransferNode("87587fe9-1f60-4cbf-9098-33e225275ea9", "B", "LK_Adventure_NodeTitle_486", 0)
		};
		List<AdventureEndNode> endNodes2 = new List<AdventureEndNode>
		{
			new AdventureEndNode("5d336ffc-c809-47c9-9b7b-bf5e6bc91f56", "H", "LK_Adventure_NodeTitle_487", 0),
			new AdventureEndNode("5d336ffc-c809-47c9-9b7b-bf5e6bc91f56", "D", "LK_Adventure_NodeTitle_487", 0)
		};
		List<AdventureBaseBranch> baseBranches2 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 5, "1", 1, 5, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 12, 25, 10, 10, 20, 50, 10, 7,
				5, 25, 10, 10, 20, 50, 10, 7, 21, 25,
				10, 10, 20, 50, 10, 7, 22, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 15, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "10", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "5", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "30",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "5", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(5, 3, "2", 1, 5, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 12, 25, 10, 10, 20, 50, 10, 7,
				5, 25, 10, 10, 20, 50, 10, 7, 21, 25,
				10, 10, 20, 50, 10, 7, 22, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 30, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "45", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "30", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "10",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "10", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 7, "3", 1, 5, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 12, 25, 10, 10, 20, 50, 10, 7,
				5, 25, 10, 10, 20, 50, 10, 7, 21, 25,
				10, 10, 20, 50, 10, 7, 22, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 15, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "10", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "30", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "5",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "5", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 4, "4", 1, 10, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 12, 25, 10, 10, 20, 50, 10, 7,
				5, 25, 10, 10, 20, 50, 10, 7, 21, 25,
				10, 10, 20, 50, 10, 7, 22, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 15, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "10", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "5", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "30",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "5", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(4, 2, "5", 1, 10, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 12, 25, 10, 10, 20, 50, 10, 7,
				5, 25, 10, 10, 20, 50, 10, 7, 21, 25,
				10, 10, 20, 50, 10, 7, 22, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 30, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "45", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "30", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "10",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "10", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 6, "6", 1, 10, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 12, 25, 10, 10, 20, 50, 10, 7,
				5, 25, 10, 10, 20, 50, 10, 7, 21, 25,
				10, 10, 20, 50, 10, 7, 22, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 15, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "10", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "30", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "5",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "5", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray5.Add(new AdventureItem(184, config9, config10, 17, 7, 7, 2, 10, 6, resCost5, itemCost5, restrictedByWorldPopulation: false, malice5, adventureParams5, "2c18c022-83e0-407f-9982-1db1b2915a6b", startNodes5, transferNodes3, endNodes2, baseBranches2, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray6 = _dataArray;
		string config11 = LocalStringManager.GetConfig("Adventure_language", "Name_185");
		string config12 = LocalStringManager.GetConfig("Adventure_language", "Desc_185");
		int[] resCost6 = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 2500 };
		list = new List<int[]>();
		List<int[]> itemCost6 = list;
		short[] malice6 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams6 = list2;
		List<AdventureStartNode> startNodes6 = new List<AdventureStartNode>
		{
			new AdventureStartNode("0b072fa2-f556-4a90-8a13-8066bdbd35e3", "E", "LK_Adventure_NodeTitle_485", 0),
			new AdventureStartNode("4efccfc4-b3f8-4833-9751-a6cb2a8d52b9", "A", "LK_Adventure_NodeTitle_485", 0)
		};
		List<AdventureTransferNode> transferNodes4 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("4f244dea-2171-4eb3-a5dd-9a198009b820", "F", "LK_Adventure_NodeTitle_486", 0),
			new AdventureTransferNode("87587fe9-1f60-4cbf-9098-33e225275ea9", "B", "LK_Adventure_NodeTitle_486", 0),
			new AdventureTransferNode("4f244dea-2171-4eb3-a5dd-9a198009b820", "G", "LK_Adventure_NodeTitle_486", 0),
			new AdventureTransferNode("87587fe9-1f60-4cbf-9098-33e225275ea9", "C", "LK_Adventure_NodeTitle_486", 0)
		};
		List<AdventureEndNode> endNodes3 = new List<AdventureEndNode>
		{
			new AdventureEndNode("5d336ffc-c809-47c9-9b7b-bf5e6bc91f56", "H", "LK_Adventure_NodeTitle_487", 0),
			new AdventureEndNode("5d336ffc-c809-47c9-9b7b-bf5e6bc91f56", "D", "LK_Adventure_NodeTitle_487", 0)
		};
		List<AdventureBaseBranch> baseBranches3 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(1, 3, "1", 1, 5, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 1, 25, 10, 10, 20, 50, 10, 7,
				4, 25, 10, 10, 20, 50, 10, 7, 20, 25,
				10, 10, 20, 50, 10, 7, 16, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 15, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "10", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "5", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "30",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "5", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 5, "2", 1, 5, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 1, 25, 10, 10, 20, 50, 10, 7,
				4, 25, 10, 10, 20, 50, 10, 7, 20, 25,
				10, 10, 20, 50, 10, 7, 16, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 30, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "45", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "30", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "10",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "10", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(5, 7, "3", 1, 5, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 1, 25, 10, 10, 20, 50, 10, 7,
				4, 25, 10, 10, 20, 50, 10, 7, 20, 25,
				10, 10, 20, 50, 10, 7, 16, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 15, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "10", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "30", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "5",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "5", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(0, 2, "4", 1, 10, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 1, 25, 10, 10, 20, 50, 10, 7,
				4, 25, 10, 10, 20, 50, 10, 7, 20, 25,
				10, 10, 20, 50, 10, 7, 16, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 15, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "10", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "5", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "30",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "5", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 4, "5", 1, 10, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 1, 25, 10, 10, 20, 50, 10, 7,
				4, 25, 10, 10, 20, 50, 10, 7, 20, 25,
				10, 10, 20, 50, 10, 7, 16, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 30, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "45", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "30", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "10",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "10", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(4, 6, "6", 1, 10, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 1, 25, 10, 10, 20, 50, 10, 7,
				4, 25, 10, 10, 20, 50, 10, 7, 20, 25,
				10, 10, 20, 50, 10, 7, 16, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 15, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "10", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "30", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "5",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "5", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray6.Add(new AdventureItem(185, config11, config12, 17, 7, 7, 2, 10, 6, resCost6, itemCost6, restrictedByWorldPopulation: false, malice6, adventureParams6, "2c18c022-83e0-407f-9982-1db1b2915a6b", startNodes6, transferNodes4, endNodes3, baseBranches3, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray7 = _dataArray;
		string config13 = LocalStringManager.GetConfig("Adventure_language", "Name_186");
		string config14 = LocalStringManager.GetConfig("Adventure_language", "Desc_186");
		int[] resCost7 = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 2500 };
		list = new List<int[]>();
		List<int[]> itemCost7 = list;
		short[] malice7 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams7 = list2;
		List<AdventureStartNode> startNodes7 = new List<AdventureStartNode>
		{
			new AdventureStartNode("4efccfc4-b3f8-4833-9751-a6cb2a8d52b9", "A", "LK_Adventure_NodeTitle_485", 0),
			new AdventureStartNode("0b072fa2-f556-4a90-8a13-8066bdbd35e3", "E", "LK_Adventure_NodeTitle_485", 0)
		};
		List<AdventureTransferNode> transferNodes5 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("4f244dea-2171-4eb3-a5dd-9a198009b820", "G", "LK_Adventure_NodeTitle_486", 0),
			new AdventureTransferNode("87587fe9-1f60-4cbf-9098-33e225275ea9", "C", "LK_Adventure_NodeTitle_486", 0),
			new AdventureTransferNode("4f244dea-2171-4eb3-a5dd-9a198009b820", "F", "LK_Adventure_NodeTitle_486", 0),
			new AdventureTransferNode("87587fe9-1f60-4cbf-9098-33e225275ea9", "B", "LK_Adventure_NodeTitle_486", 0)
		};
		List<AdventureEndNode> endNodes4 = new List<AdventureEndNode>
		{
			new AdventureEndNode("5d336ffc-c809-47c9-9b7b-bf5e6bc91f56", "H", "LK_Adventure_NodeTitle_487", 0),
			new AdventureEndNode("5d336ffc-c809-47c9-9b7b-bf5e6bc91f56", "D", "LK_Adventure_NodeTitle_487", 0)
		};
		List<AdventureBaseBranch> baseBranches4 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 5, "1", 1, 5, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 11, 25, 10, 10, 20, 50, 10, 7,
				20, 25, 10, 10, 20, 50, 10, 7, 22, 25,
				10, 10, 20, 50, 10, 7, 6, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 15, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "10", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "5", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "30",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "5", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(5, 3, "2", 1, 5, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 11, 25, 10, 10, 20, 50, 10, 7,
				20, 25, 10, 10, 20, 50, 10, 7, 22, 25,
				10, 10, 20, 50, 10, 7, 6, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 30, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "45", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "30", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "10",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "10", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 7, "3", 1, 5, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 11, 25, 10, 10, 20, 50, 10, 7,
				20, 25, 10, 10, 20, 50, 10, 7, 22, 25,
				10, 10, 20, 50, 10, 7, 6, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 15, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "10", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "30", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "5",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "5", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 4, "4", 1, 10, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 11, 25, 10, 10, 20, 50, 10, 7,
				20, 25, 10, 10, 20, 50, 10, 7, 22, 25,
				10, 10, 20, 50, 10, 7, 6, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 15, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "10", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "5", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "30",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "5", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(4, 2, "5", 1, 10, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 11, 25, 10, 10, 20, 50, 10, 7,
				20, 25, 10, 10, 20, 50, 10, 7, 22, 25,
				10, 10, 20, 50, 10, 7, 6, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 30, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "45", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "30", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "10",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "10", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 6, "6", 1, 10, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 11, 25, 10, 10, 20, 50, 10, 7,
				20, 25, 10, 10, 20, 50, 10, 7, 22, 25,
				10, 10, 20, 50, 10, 7, 6, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 15, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "10", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "30", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "5",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "5", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray7.Add(new AdventureItem(186, config13, config14, 17, 7, 7, 2, 10, 6, resCost7, itemCost7, restrictedByWorldPopulation: false, malice7, adventureParams7, "2c18c022-83e0-407f-9982-1db1b2915a6b", startNodes7, transferNodes5, endNodes4, baseBranches4, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray8 = _dataArray;
		string config15 = LocalStringManager.GetConfig("Adventure_language", "Name_187");
		string config16 = LocalStringManager.GetConfig("Adventure_language", "Desc_187");
		int[] resCost8 = new int[9];
		list = new List<int[]>();
		List<int[]> itemCost8 = list;
		short[] malice8 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams8 = list2;
		List<AdventureStartNode> startNodes8 = new List<AdventureStartNode>
		{
			new AdventureStartNode("4efccfc4-b3f8-4833-9751-a6cb2a8d52b9", "A", "LK_Adventure_NodeTitle_485", 0),
			new AdventureStartNode("0b072fa2-f556-4a90-8a13-8066bdbd35e3", "E", "LK_Adventure_NodeTitle_485", 0)
		};
		List<AdventureTransferNode> transferNodes6 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("87587fe9-1f60-4cbf-9098-33e225275ea9", "B", "LK_Adventure_NodeTitle_486", 0),
			new AdventureTransferNode("87587fe9-1f60-4cbf-9098-33e225275ea9", "C", "LK_Adventure_NodeTitle_486", 0),
			new AdventureTransferNode("4f244dea-2171-4eb3-a5dd-9a198009b820", "F", "LK_Adventure_NodeTitle_486", 0),
			new AdventureTransferNode("4f244dea-2171-4eb3-a5dd-9a198009b820", "G", "LK_Adventure_NodeTitle_486", 0)
		};
		List<AdventureEndNode> endNodes5 = new List<AdventureEndNode>
		{
			new AdventureEndNode("5d336ffc-c809-47c9-9b7b-bf5e6bc91f56", "D", "LK_Adventure_NodeTitle_487", 0),
			new AdventureEndNode("5d336ffc-c809-47c9-9b7b-bf5e6bc91f56", "H", "LK_Adventure_NodeTitle_487", 0)
		};
		List<AdventureBaseBranch> baseBranches5 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 2, "1", 1, 5, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 3, 25, 10, 10, 20, 50, 10, 7,
				11, 25, 10, 10, 20, 50, 10, 7, 12, 25,
				10, 10, 20, 50, 10, 7, 16, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 15, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "10", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "5", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "30",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "5", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 3, "2", 1, 5, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 3, 25, 10, 10, 20, 50, 10, 7,
				11, 25, 10, 10, 20, 50, 10, 7, 12, 25,
				10, 10, 20, 50, 10, 7, 16, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 30, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "45", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "30", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "10",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "10", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 6, "3", 1, 5, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 3, 25, 10, 10, 20, 50, 10, 7,
				11, 25, 10, 10, 20, 50, 10, 7, 12, 25,
				10, 10, 20, 50, 10, 7, 16, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 15, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "10", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "30", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "5",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "5", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 4, "4", 1, 10, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 3, 25, 10, 10, 20, 500, 10, 7,
				11, 25, 10, 10, 20, 500, 10, 7, 12, 25,
				10, 10, 20, 500, 10, 7, 16, 25, 10, 10,
				20, 500, 10
			}, new int[5] { 25, 5, 15, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "10", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "5", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "30",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "5", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(4, 5, "5", 1, 10, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 3, 25, 10, 10, 20, 50, 10, 7,
				11, 25, 10, 10, 20, 50, 10, 7, 12, 25,
				10, 10, 20, 50, 10, 7, 16, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 30, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "45", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "30", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "10",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "10", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(5, 7, "6", 1, 10, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 3, 25, 10, 10, 20, 50, 10, 7,
				11, 25, 10, 10, 20, 50, 10, 7, 12, 25,
				10, 10, 20, 50, 10, 7, 16, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 15, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "10", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "30", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "5",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "5", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray8.Add(new AdventureItem(187, config15, config16, 17, 7, 7, 2, 10, 6, resCost8, itemCost8, restrictedByWorldPopulation: false, malice8, adventureParams8, "2c18c022-83e0-407f-9982-1db1b2915a6b", startNodes8, transferNodes6, endNodes5, baseBranches5, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray9 = _dataArray;
		string config17 = LocalStringManager.GetConfig("Adventure_language", "Name_188");
		string config18 = LocalStringManager.GetConfig("Adventure_language", "Desc_188");
		int[] resCost9 = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 2500 };
		list = new List<int[]>();
		List<int[]> itemCost9 = list;
		short[] malice9 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams9 = list2;
		List<AdventureStartNode> startNodes9 = new List<AdventureStartNode>
		{
			new AdventureStartNode("4efccfc4-b3f8-4833-9751-a6cb2a8d52b9", "A", "LK_Adventure_NodeTitle_485", 0),
			new AdventureStartNode("0b072fa2-f556-4a90-8a13-8066bdbd35e3", "E", "LK_Adventure_NodeTitle_485", 0)
		};
		List<AdventureTransferNode> transferNodes7 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("87587fe9-1f60-4cbf-9098-33e225275ea9", "C", "LK_Adventure_NodeTitle_486", 0),
			new AdventureTransferNode("4f244dea-2171-4eb3-a5dd-9a198009b820", "G", "LK_Adventure_NodeTitle_486", 0),
			new AdventureTransferNode("4f244dea-2171-4eb3-a5dd-9a198009b820", "F", "LK_Adventure_NodeTitle_486", 0),
			new AdventureTransferNode("87587fe9-1f60-4cbf-9098-33e225275ea9", "B", "LK_Adventure_NodeTitle_486", 0)
		};
		List<AdventureEndNode> endNodes6 = new List<AdventureEndNode>
		{
			new AdventureEndNode("5d336ffc-c809-47c9-9b7b-bf5e6bc91f56", "H", "LK_Adventure_NodeTitle_487", 0),
			new AdventureEndNode("5d336ffc-c809-47c9-9b7b-bf5e6bc91f56", "D", "LK_Adventure_NodeTitle_487", 0)
		};
		List<AdventureBaseBranch> baseBranches6 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 5, "1", 1, 5, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 21, 25, 10, 10, 20, 50, 10, 7,
				22, 25, 10, 10, 20, 50, 10, 7, 11, 25,
				10, 10, 20, 50, 10, 7, 10, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 15, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "10", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "5", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "30",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "5", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(5, 2, "2", 1, 5, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 21, 25, 10, 10, 20, 50, 10, 7,
				22, 25, 10, 10, 20, 50, 10, 7, 11, 25,
				10, 10, 20, 50, 10, 7, 10, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 30, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "45", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "30", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "10",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "10", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 7, "3", 1, 5, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 21, 25, 10, 10, 20, 50, 10, 7,
				22, 25, 10, 10, 20, 50, 10, 7, 11, 25,
				10, 10, 20, 50, 10, 7, 10, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 15, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "10", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "30", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "5",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "5", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 4, "4", 1, 10, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 21, 25, 10, 10, 20, 50, 10, 7,
				22, 25, 10, 10, 20, 50, 10, 7, 11, 25,
				10, 10, 20, 50, 10, 7, 10, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 15, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "10", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "5", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "30",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "5", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(4, 3, "5", 1, 10, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 21, 25, 10, 10, 20, 50, 10, 7,
				22, 25, 10, 10, 20, 50, 10, 7, 11, 25,
				10, 10, 20, 50, 10, 7, 10, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 30, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "45", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "30", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "10",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "10", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 6, "6", 1, 10, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 21, 25, 10, 10, 20, 50, 10, 7,
				22, 25, 10, 10, 20, 50, 10, 7, 11, 25,
				10, 10, 20, 50, 10, 7, 10, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 15, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "10", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "30", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "5",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "5", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray9.Add(new AdventureItem(188, config17, config18, 17, 7, 7, 2, 10, 6, resCost9, itemCost9, restrictedByWorldPopulation: false, malice9, adventureParams9, "2c18c022-83e0-407f-9982-1db1b2915a6b", startNodes9, transferNodes7, endNodes6, baseBranches6, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray10 = _dataArray;
		string config19 = LocalStringManager.GetConfig("Adventure_language", "Name_189");
		string config20 = LocalStringManager.GetConfig("Adventure_language", "Desc_189");
		int[] resCost10 = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 2500 };
		list = new List<int[]>();
		List<int[]> itemCost10 = list;
		short[] malice10 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams10 = list2;
		List<AdventureStartNode> startNodes10 = new List<AdventureStartNode>
		{
			new AdventureStartNode("4efccfc4-b3f8-4833-9751-a6cb2a8d52b9", "A", "LK_Adventure_NodeTitle_485", 0),
			new AdventureStartNode("0b072fa2-f556-4a90-8a13-8066bdbd35e3", "E", "LK_Adventure_NodeTitle_485", 0)
		};
		List<AdventureTransferNode> transferNodes8 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("4f244dea-2171-4eb3-a5dd-9a198009b820", "G", "LK_Adventure_NodeTitle_486", 0),
			new AdventureTransferNode("87587fe9-1f60-4cbf-9098-33e225275ea9", "C", "LK_Adventure_NodeTitle_486", 0),
			new AdventureTransferNode("87587fe9-1f60-4cbf-9098-33e225275ea9", "B", "LK_Adventure_NodeTitle_486", 0),
			new AdventureTransferNode("4f244dea-2171-4eb3-a5dd-9a198009b820", "F", "LK_Adventure_NodeTitle_486", 0)
		};
		List<AdventureEndNode> endNodes7 = new List<AdventureEndNode>
		{
			new AdventureEndNode("5d336ffc-c809-47c9-9b7b-bf5e6bc91f56", "H", "LK_Adventure_NodeTitle_487", 0),
			new AdventureEndNode("5d336ffc-c809-47c9-9b7b-bf5e6bc91f56", "D", "LK_Adventure_NodeTitle_487", 0)
		};
		List<AdventureBaseBranch> baseBranches7 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 4, "1", 1, 5, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 7, 25, 10, 10, 20, 50, 10, 7,
				10, 25, 10, 10, 20, 50, 10, 7, 12, 25,
				10, 10, 20, 50, 10, 7, 2, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 15, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "10", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "5", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "30",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "5", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(4, 3, "2", 1, 5, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 7, 25, 10, 10, 20, 50, 10, 7,
				10, 25, 10, 10, 20, 50, 10, 7, 12, 25,
				10, 10, 20, 50, 10, 7, 2, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 30, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "45", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "30", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "10",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "10", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 7, "3", 1, 5, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 7, 25, 10, 10, 20, 50, 10, 7,
				10, 25, 10, 10, 20, 50, 10, 7, 12, 25,
				10, 10, 20, 50, 10, 7, 2, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 15, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "10", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "30", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "5",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "5", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 5, "4", 1, 10, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 7, 25, 10, 10, 20, 50, 10, 7,
				10, 25, 10, 10, 20, 50, 10, 7, 12, 25,
				10, 10, 20, 50, 10, 7, 2, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 15, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "10", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "5", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "30",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "5", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(5, 2, "5", 1, 10, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 7, 25, 10, 10, 20, 50, 10, 7,
				10, 25, 10, 10, 20, 50, 10, 7, 12, 25,
				10, 10, 20, 50, 10, 7, 2, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 30, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "45", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "30", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "10",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "10", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 6, "6", 1, 10, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 7, 25, 10, 10, 20, 50, 10, 7,
				10, 25, 10, 10, 20, 50, 10, 7, 12, 25,
				10, 10, 20, 50, 10, 7, 2, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 15, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "10", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "30", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "5",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "5", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray10.Add(new AdventureItem(189, config19, config20, 17, 7, 7, 2, 10, 6, resCost10, itemCost10, restrictedByWorldPopulation: false, malice10, adventureParams10, "2c18c022-83e0-407f-9982-1db1b2915a6b", startNodes10, transferNodes8, endNodes7, baseBranches7, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray11 = _dataArray;
		string config21 = LocalStringManager.GetConfig("Adventure_language", "Name_190");
		string config22 = LocalStringManager.GetConfig("Adventure_language", "Desc_190");
		int[] resCost11 = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 2500 };
		list = new List<int[]>();
		List<int[]> itemCost11 = list;
		short[] malice11 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams11 = list2;
		List<AdventureStartNode> startNodes11 = new List<AdventureStartNode>
		{
			new AdventureStartNode("0b072fa2-f556-4a90-8a13-8066bdbd35e3", "E", "LK_Adventure_NodeTitle_485", 0),
			new AdventureStartNode("4efccfc4-b3f8-4833-9751-a6cb2a8d52b9", "A", "LK_Adventure_NodeTitle_485", 0)
		};
		List<AdventureTransferNode> transferNodes9 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("4f244dea-2171-4eb3-a5dd-9a198009b820", "F", "LK_Adventure_NodeTitle_486", 0),
			new AdventureTransferNode("87587fe9-1f60-4cbf-9098-33e225275ea9", "B", "LK_Adventure_NodeTitle_486", 0),
			new AdventureTransferNode("4f244dea-2171-4eb3-a5dd-9a198009b820", "G", "LK_Adventure_NodeTitle_486", 0),
			new AdventureTransferNode("87587fe9-1f60-4cbf-9098-33e225275ea9", "C", "LK_Adventure_NodeTitle_486", 0)
		};
		List<AdventureEndNode> endNodes8 = new List<AdventureEndNode>
		{
			new AdventureEndNode("5d336ffc-c809-47c9-9b7b-bf5e6bc91f56", "H", "LK_Adventure_NodeTitle_487", 0),
			new AdventureEndNode("5d336ffc-c809-47c9-9b7b-bf5e6bc91f56", "D", "LK_Adventure_NodeTitle_487", 0)
		};
		List<AdventureBaseBranch> baseBranches8 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(1, 3, "1", 1, 5, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 13, 25, 10, 10, 20, 50, 10, 7,
				17, 25, 10, 10, 20, 50, 10, 7, 16, 25,
				10, 10, 20, 50, 10, 7, 4, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 15, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "10", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "5", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "30",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "5", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 5, "2", 1, 5, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 13, 25, 10, 10, 20, 50, 10, 7,
				17, 25, 10, 10, 20, 50, 10, 7, 16, 25,
				10, 10, 20, 50, 10, 7, 4, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 30, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "45", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "30", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "10",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "10", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(5, 7, "3", 1, 5, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 13, 25, 10, 10, 20, 50, 10, 7,
				17, 25, 10, 10, 20, 50, 10, 7, 16, 25,
				10, 10, 20, 50, 10, 7, 4, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 15, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "10", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "30", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "5",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "5", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(0, 2, "4", 1, 10, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 13, 25, 10, 10, 20, 50, 10, 7,
				17, 25, 10, 10, 20, 50, 10, 7, 16, 25,
				10, 10, 20, 50, 10, 7, 4, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 15, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "10", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "5", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "30",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "5", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 4, "5", 1, 10, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 13, 25, 10, 10, 20, 50, 10, 7,
				17, 25, 10, 10, 20, 50, 10, 7, 16, 25,
				10, 10, 20, 50, 10, 7, 4, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 30, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "45", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "30", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "10",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "10", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(4, 6, "6", 1, 10, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 13, 25, 10, 10, 20, 50, 10, 7,
				17, 25, 10, 10, 20, 50, 10, 7, 16, 25,
				10, 10, 20, 50, 10, 7, 4, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 15, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "10", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "30", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "5",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "5", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray11.Add(new AdventureItem(190, config21, config22, 17, 7, 7, 2, 10, 6, resCost11, itemCost11, restrictedByWorldPopulation: false, malice11, adventureParams11, "2c18c022-83e0-407f-9982-1db1b2915a6b", startNodes11, transferNodes9, endNodes8, baseBranches8, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray12 = _dataArray;
		string config23 = LocalStringManager.GetConfig("Adventure_language", "Name_191");
		string config24 = LocalStringManager.GetConfig("Adventure_language", "Desc_191");
		int[] resCost12 = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 2500 };
		list = new List<int[]>();
		List<int[]> itemCost12 = list;
		short[] malice12 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams12 = list2;
		List<AdventureStartNode> startNodes12 = new List<AdventureStartNode>
		{
			new AdventureStartNode("0b072fa2-f556-4a90-8a13-8066bdbd35e3", "E", "LK_Adventure_NodeTitle_485", 0),
			new AdventureStartNode("4efccfc4-b3f8-4833-9751-a6cb2a8d52b9", "A", "LK_Adventure_NodeTitle_485", 0)
		};
		List<AdventureTransferNode> transferNodes10 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("4f244dea-2171-4eb3-a5dd-9a198009b820", "F", "LK_Adventure_NodeTitle_486", 0),
			new AdventureTransferNode("87587fe9-1f60-4cbf-9098-33e225275ea9", "B", "LK_Adventure_NodeTitle_486", 0),
			new AdventureTransferNode("4f244dea-2171-4eb3-a5dd-9a198009b820", "G", "LK_Adventure_NodeTitle_486", 0),
			new AdventureTransferNode("87587fe9-1f60-4cbf-9098-33e225275ea9", "C", "LK_Adventure_NodeTitle_486", 0)
		};
		List<AdventureEndNode> endNodes9 = new List<AdventureEndNode>
		{
			new AdventureEndNode("5d336ffc-c809-47c9-9b7b-bf5e6bc91f56", "H", "LK_Adventure_NodeTitle_487", 0),
			new AdventureEndNode("5d336ffc-c809-47c9-9b7b-bf5e6bc91f56", "D", "LK_Adventure_NodeTitle_487", 0)
		};
		List<AdventureBaseBranch> baseBranches9 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(1, 3, "1", 1, 5, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 8, 25, 10, 10, 20, 50, 10, 7,
				9, 25, 10, 10, 20, 50, 10, 7, 12, 25,
				10, 10, 20, 50, 10, 7, 10, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 15, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "10", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "5", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "30",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "5", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 5, "2", 1, 5, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 8, 25, 10, 10, 20, 50, 10, 7,
				9, 25, 10, 10, 20, 50, 10, 7, 12, 25,
				10, 10, 20, 50, 10, 7, 10, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 30, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "45", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "30", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "10",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "10", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(5, 7, "3", 1, 5, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 8, 25, 10, 10, 20, 50, 10, 7,
				9, 25, 10, 10, 20, 50, 10, 7, 12, 25,
				10, 10, 20, 50, 10, 7, 10, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 15, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "10", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "30", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "5",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "5", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(0, 2, "4", 1, 10, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 8, 25, 10, 10, 20, 50, 10, 7,
				9, 25, 10, 10, 20, 50, 10, 7, 12, 25,
				10, 10, 20, 50, 10, 7, 10, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 15, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "10", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "5", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "30",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "5", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 4, "5", 1, 10, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 8, 25, 10, 10, 20, 50, 10, 7,
				9, 25, 10, 10, 20, 50, 10, 7, 12, 25,
				10, 10, 20, 50, 10, 7, 10, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 30, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "45", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "30", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "10",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "10", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(4, 6, "6", 1, 10, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 8, 25, 10, 10, 20, 50, 10, 7,
				9, 25, 10, 10, 20, 50, 10, 7, 12, 25,
				10, 10, 20, 50, 10, 7, 10, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 15, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "10", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "30", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "5",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "5", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray12.Add(new AdventureItem(191, config23, config24, 17, 7, 7, 2, 10, 6, resCost12, itemCost12, restrictedByWorldPopulation: false, malice12, adventureParams12, "2c18c022-83e0-407f-9982-1db1b2915a6b", startNodes12, transferNodes10, endNodes9, baseBranches9, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray13 = _dataArray;
		string config25 = LocalStringManager.GetConfig("Adventure_language", "Name_192");
		string config26 = LocalStringManager.GetConfig("Adventure_language", "Desc_192");
		int[] resCost13 = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 2500 };
		list = new List<int[]>();
		List<int[]> itemCost13 = list;
		short[] malice13 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams13 = list2;
		List<AdventureStartNode> startNodes13 = new List<AdventureStartNode>
		{
			new AdventureStartNode("4efccfc4-b3f8-4833-9751-a6cb2a8d52b9", "A", "LK_Adventure_NodeTitle_485", 0),
			new AdventureStartNode("0b072fa2-f556-4a90-8a13-8066bdbd35e3", "E", "LK_Adventure_NodeTitle_485", 0)
		};
		List<AdventureTransferNode> transferNodes11 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("4f244dea-2171-4eb3-a5dd-9a198009b820", "G", "LK_Adventure_NodeTitle_486", 0),
			new AdventureTransferNode("87587fe9-1f60-4cbf-9098-33e225275ea9", "C", "LK_Adventure_NodeTitle_486", 0),
			new AdventureTransferNode("4f244dea-2171-4eb3-a5dd-9a198009b820", "F", "LK_Adventure_NodeTitle_486", 0),
			new AdventureTransferNode("87587fe9-1f60-4cbf-9098-33e225275ea9", "B", "LK_Adventure_NodeTitle_486", 0)
		};
		List<AdventureEndNode> endNodes10 = new List<AdventureEndNode>
		{
			new AdventureEndNode("5d336ffc-c809-47c9-9b7b-bf5e6bc91f56", "H", "LK_Adventure_NodeTitle_487", 0),
			new AdventureEndNode("5d336ffc-c809-47c9-9b7b-bf5e6bc91f56", "D", "LK_Adventure_NodeTitle_487", 0)
		};
		List<AdventureBaseBranch> baseBranches10 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 5, "1", 1, 5, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 3, 25, 10, 10, 20, 50, 10, 7,
				6, 25, 10, 10, 20, 50, 10, 7, 17, 25,
				10, 10, 20, 50, 10, 7, 18, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 15, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "10", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "5", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "30",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "5", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(5, 3, "2", 1, 5, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 3, 25, 10, 10, 20, 50, 10, 7,
				6, 25, 10, 10, 20, 50, 10, 7, 17, 25,
				10, 10, 20, 50, 10, 7, 18, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 30, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "45", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "30", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "10",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "10", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 7, "3", 1, 5, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 3, 25, 10, 10, 20, 50, 10, 7,
				6, 25, 10, 10, 20, 50, 10, 7, 17, 25,
				10, 10, 20, 50, 10, 7, 18, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 15, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "10", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "30", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "5",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "5", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 4, "4", 1, 10, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 3, 25, 10, 10, 20, 50, 10, 7,
				6, 25, 10, 10, 20, 50, 10, 7, 17, 25,
				10, 10, 20, 50, 10, 7, 18, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 15, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "10", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "5", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "30",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "5", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(4, 2, "5", 1, 10, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 3, 25, 10, 10, 20, 50, 10, 7,
				6, 25, 10, 10, 20, 50, 10, 7, 17, 25,
				10, 10, 20, 50, 10, 7, 18, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 30, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "45", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "30", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "10",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "10", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 6, "6", 1, 10, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 3, 25, 10, 10, 20, 50, 10, 7,
				6, 25, 10, 10, 20, 50, 10, 7, 17, 25,
				10, 10, 20, 50, 10, 7, 18, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 15, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "10", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "30", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "5",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "5", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray13.Add(new AdventureItem(192, config25, config26, 17, 7, 7, 2, 10, 6, resCost13, itemCost13, restrictedByWorldPopulation: false, malice13, adventureParams13, "2c18c022-83e0-407f-9982-1db1b2915a6b", startNodes13, transferNodes11, endNodes10, baseBranches10, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray14 = _dataArray;
		string config27 = LocalStringManager.GetConfig("Adventure_language", "Name_193");
		string config28 = LocalStringManager.GetConfig("Adventure_language", "Desc_193");
		int[] resCost14 = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 2500 };
		list = new List<int[]>();
		List<int[]> itemCost14 = list;
		short[] malice14 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams14 = list2;
		List<AdventureStartNode> startNodes14 = new List<AdventureStartNode>
		{
			new AdventureStartNode("0b072fa2-f556-4a90-8a13-8066bdbd35e3", "E", "LK_Adventure_NodeTitle_485", 0),
			new AdventureStartNode("4efccfc4-b3f8-4833-9751-a6cb2a8d52b9", "A", "LK_Adventure_NodeTitle_485", 0)
		};
		List<AdventureTransferNode> transferNodes12 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("87587fe9-1f60-4cbf-9098-33e225275ea9", "C", "LK_Adventure_NodeTitle_486", 0),
			new AdventureTransferNode("4f244dea-2171-4eb3-a5dd-9a198009b820", "G", "LK_Adventure_NodeTitle_486", 0),
			new AdventureTransferNode("4f244dea-2171-4eb3-a5dd-9a198009b820", "F", "LK_Adventure_NodeTitle_486", 0),
			new AdventureTransferNode("87587fe9-1f60-4cbf-9098-33e225275ea9", "B", "LK_Adventure_NodeTitle_486", 0)
		};
		List<AdventureEndNode> endNodes11 = new List<AdventureEndNode>
		{
			new AdventureEndNode("5d336ffc-c809-47c9-9b7b-bf5e6bc91f56", "H", "LK_Adventure_NodeTitle_487", 0),
			new AdventureEndNode("5d336ffc-c809-47c9-9b7b-bf5e6bc91f56", "D", "LK_Adventure_NodeTitle_487", 0)
		};
		List<AdventureBaseBranch> baseBranches11 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(1, 5, "1", 1, 5, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 15, 25, 10, 10, 20, 50, 10, 7,
				14, 25, 10, 10, 20, 50, 10, 7, 1, 25,
				10, 10, 20, 50, 10, 7, 12, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 15, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "10", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "5", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "30",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "5", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(5, 2, "2", 1, 5, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 15, 25, 10, 10, 20, 50, 10, 7,
				14, 25, 10, 10, 20, 50, 10, 7, 1, 25,
				10, 10, 20, 50, 10, 7, 12, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 30, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "45", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "30", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "10",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "10", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 7, "3", 1, 5, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 15, 25, 10, 10, 20, 50, 10, 7,
				14, 25, 10, 10, 20, 50, 10, 7, 1, 25,
				10, 10, 20, 50, 10, 7, 12, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 15, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "10", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "30", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "5",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "5", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(0, 4, "10", 1, 5, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 15, 25, 10, 10, 20, 50, 10, 7,
				14, 25, 10, 10, 20, 50, 10, 7, 1, 25,
				10, 10, 20, 50, 10, 7, 12, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 15, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "10", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "5", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "30",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "5", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(4, 3, "5", 1, 10, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 15, 25, 10, 10, 20, 50, 10, 7,
				14, 25, 10, 10, 20, 50, 10, 7, 1, 25,
				10, 10, 20, 50, 10, 7, 12, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 30, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "45", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "30", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "10",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "10", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 6, "6", 1, 10, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 15, 25, 10, 10, 20, 50, 10, 7,
				14, 25, 10, 10, 20, 50, 10, 7, 1, 25,
				10, 10, 20, 50, 10, 7, 12, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 15, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "10", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "30", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "5",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "5", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray14.Add(new AdventureItem(193, config27, config28, 17, 7, 7, 2, 10, 6, resCost14, itemCost14, restrictedByWorldPopulation: false, malice14, adventureParams14, "2c18c022-83e0-407f-9982-1db1b2915a6b", startNodes14, transferNodes12, endNodes11, baseBranches11, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray15 = _dataArray;
		string config29 = LocalStringManager.GetConfig("Adventure_language", "Name_194");
		string config30 = LocalStringManager.GetConfig("Adventure_language", "Desc_194");
		int[] resCost15 = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 2500 };
		list = new List<int[]>();
		List<int[]> itemCost15 = list;
		short[] malice15 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams15 = list2;
		List<AdventureStartNode> startNodes15 = new List<AdventureStartNode>
		{
			new AdventureStartNode("0b072fa2-f556-4a90-8a13-8066bdbd35e3", "E", "LK_Adventure_NodeTitle_485", 0),
			new AdventureStartNode("4efccfc4-b3f8-4833-9751-a6cb2a8d52b9", "A", "LK_Adventure_NodeTitle_485", 0)
		};
		List<AdventureTransferNode> transferNodes13 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("4f244dea-2171-4eb3-a5dd-9a198009b820", "G", "LK_Adventure_NodeTitle_486", 0),
			new AdventureTransferNode("87587fe9-1f60-4cbf-9098-33e225275ea9", "C", "LK_Adventure_NodeTitle_486", 0),
			new AdventureTransferNode("87587fe9-1f60-4cbf-9098-33e225275ea9", "B", "LK_Adventure_NodeTitle_486", 0),
			new AdventureTransferNode("4f244dea-2171-4eb3-a5dd-9a198009b820", "F", "LK_Adventure_NodeTitle_486", 0)
		};
		List<AdventureEndNode> endNodes12 = new List<AdventureEndNode>
		{
			new AdventureEndNode("5d336ffc-c809-47c9-9b7b-bf5e6bc91f56", "H", "LK_Adventure_NodeTitle_487", 0),
			new AdventureEndNode("5d336ffc-c809-47c9-9b7b-bf5e6bc91f56", "D", "LK_Adventure_NodeTitle_487", 0)
		};
		List<AdventureBaseBranch> baseBranches12 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(1, 4, "1", 1, 5, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 9, 25, 10, 10, 20, 50, 10, 7,
				13, 25, 10, 10, 20, 50, 10, 7, 4, 25,
				10, 10, 20, 50, 10, 7, 19, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 15, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "10", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "5", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "30",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "5", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(4, 3, "2", 1, 5, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 9, 25, 10, 10, 20, 50, 10, 7,
				13, 25, 10, 10, 20, 50, 10, 7, 4, 25,
				10, 10, 20, 50, 10, 7, 19, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 30, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "45", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "30", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "10",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "10", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 7, "3", 1, 5, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 9, 25, 10, 10, 20, 50, 10, 7,
				13, 25, 10, 10, 20, 50, 10, 7, 4, 25,
				10, 10, 20, 50, 10, 7, 19, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 15, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "10", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "30", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "5",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "5", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(0, 5, "4", 1, 10, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 9, 25, 10, 10, 20, 50, 10, 7,
				13, 25, 10, 10, 20, 50, 10, 7, 4, 25,
				10, 10, 20, 50, 10, 7, 19, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 15, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "10", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "5", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "30",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "5", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(5, 2, "5", 1, 10, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 9, 25, 10, 10, 20, 50, 10, 7,
				13, 25, 10, 10, 20, 50, 10, 7, 4, 25,
				10, 10, 20, 50, 10, 7, 19, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 30, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "45", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "30", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "10",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "10", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 6, "6", 1, 10, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 9, 25, 10, 10, 20, 50, 10, 7,
				13, 25, 10, 10, 20, 50, 10, 7, 4, 25,
				10, 10, 20, 50, 10, 7, 19, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 15, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "10", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "30", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "5",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "5", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray15.Add(new AdventureItem(194, config29, config30, 17, 7, 7, 2, 10, 6, resCost15, itemCost15, restrictedByWorldPopulation: false, malice15, adventureParams15, "2c18c022-83e0-407f-9982-1db1b2915a6b", startNodes15, transferNodes13, endNodes12, baseBranches12, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray16 = _dataArray;
		string config31 = LocalStringManager.GetConfig("Adventure_language", "Name_195");
		string config32 = LocalStringManager.GetConfig("Adventure_language", "Desc_195");
		int[] resCost16 = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 2500 };
		list = new List<int[]>();
		List<int[]> itemCost16 = list;
		short[] malice16 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams16 = list2;
		List<AdventureStartNode> startNodes16 = new List<AdventureStartNode>
		{
			new AdventureStartNode("0b072fa2-f556-4a90-8a13-8066bdbd35e3", "E", "LK_Adventure_NodeTitle_485", 0),
			new AdventureStartNode("4efccfc4-b3f8-4833-9751-a6cb2a8d52b9", "A", "LK_Adventure_NodeTitle_485", 0)
		};
		List<AdventureTransferNode> transferNodes14 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("4f244dea-2171-4eb3-a5dd-9a198009b820", "G", "LK_Adventure_NodeTitle_486", 0),
			new AdventureTransferNode("87587fe9-1f60-4cbf-9098-33e225275ea9", "C", "LK_Adventure_NodeTitle_486", 0),
			new AdventureTransferNode("4f244dea-2171-4eb3-a5dd-9a198009b820", "F", "LK_Adventure_NodeTitle_486", 0),
			new AdventureTransferNode("87587fe9-1f60-4cbf-9098-33e225275ea9", "B", "LK_Adventure_NodeTitle_486", 0)
		};
		List<AdventureEndNode> endNodes13 = new List<AdventureEndNode>
		{
			new AdventureEndNode("5d336ffc-c809-47c9-9b7b-bf5e6bc91f56", "H", "LK_Adventure_NodeTitle_487", 0),
			new AdventureEndNode("5d336ffc-c809-47c9-9b7b-bf5e6bc91f56", "D", "LK_Adventure_NodeTitle_487", 0)
		};
		List<AdventureBaseBranch> baseBranches13 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(1, 5, "1", 1, 5, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 15, 25, 10, 10, 20, 50, 10, 7,
				20, 25, 10, 10, 20, 50, 10, 7, 3, 25,
				10, 10, 20, 50, 10, 7, 6, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 15, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "10", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "5", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "30",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "5", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(5, 3, "2", 1, 5, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 15, 25, 10, 10, 20, 50, 10, 7,
				20, 25, 10, 10, 20, 50, 10, 7, 3, 25,
				10, 10, 20, 50, 10, 7, 6, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 30, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "45", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "30", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "10",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "10", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 7, "3", 1, 5, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 15, 25, 10, 10, 20, 50, 10, 7,
				20, 25, 10, 10, 20, 50, 10, 7, 3, 25,
				10, 10, 20, 50, 10, 7, 6, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 15, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "10", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "30", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "5",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "5", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(0, 4, "4", 1, 10, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 15, 25, 10, 10, 20, 50, 10, 7,
				20, 25, 10, 10, 20, 50, 10, 7, 3, 25,
				10, 10, 20, 50, 10, 7, 6, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 15, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "10", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "5", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "30",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "5", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(4, 2, "5", 1, 10, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 15, 25, 10, 10, 20, 50, 10, 7,
				20, 25, 10, 10, 20, 50, 10, 7, 3, 25,
				10, 10, 20, 50, 10, 7, 6, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 30, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "45", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "30", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "10",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "10", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 6, "6", 1, 10, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 15, 25, 10, 10, 20, 50, 10, 7,
				20, 25, 10, 10, 20, 50, 10, 7, 3, 25,
				10, 10, 20, 50, 10, 7, 6, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 15, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "10", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "30", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "5",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "5", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray16.Add(new AdventureItem(195, config31, config32, 17, 7, 7, 2, 10, 6, resCost16, itemCost16, restrictedByWorldPopulation: false, malice16, adventureParams16, "2c18c022-83e0-407f-9982-1db1b2915a6b", startNodes16, transferNodes14, endNodes13, baseBranches13, advancedBranches, difficultyAddXiangshuLevel: false));
		List<AdventureItem> dataArray17 = _dataArray;
		string config33 = LocalStringManager.GetConfig("Adventure_language", "Name_196");
		string config34 = LocalStringManager.GetConfig("Adventure_language", "Desc_196");
		int[] resCost17 = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 2500 };
		list = new List<int[]>();
		List<int[]> itemCost17 = list;
		short[] malice17 = new short[3];
		list2 = new List<(string, string, string, string)>();
		List<(string, string, string, string)> adventureParams17 = list2;
		List<AdventureStartNode> startNodes17 = new List<AdventureStartNode>
		{
			new AdventureStartNode("4efccfc4-b3f8-4833-9751-a6cb2a8d52b9", "A", "LK_Adventure_NodeTitle_485", 0),
			new AdventureStartNode("0b072fa2-f556-4a90-8a13-8066bdbd35e3", "E", "LK_Adventure_NodeTitle_485", 0)
		};
		List<AdventureTransferNode> transferNodes15 = new List<AdventureTransferNode>
		{
			new AdventureTransferNode("87587fe9-1f60-4cbf-9098-33e225275ea9", "B", "LK_Adventure_NodeTitle_486", 0),
			new AdventureTransferNode("87587fe9-1f60-4cbf-9098-33e225275ea9", "C", "LK_Adventure_NodeTitle_486", 0),
			new AdventureTransferNode("4f244dea-2171-4eb3-a5dd-9a198009b820", "G", "LK_Adventure_NodeTitle_486", 0),
			new AdventureTransferNode("4f244dea-2171-4eb3-a5dd-9a198009b820", "F", "LK_Adventure_NodeTitle_486", 0)
		};
		List<AdventureEndNode> endNodes14 = new List<AdventureEndNode>
		{
			new AdventureEndNode("5d336ffc-c809-47c9-9b7b-bf5e6bc91f56", "D", "LK_Adventure_NodeTitle_487", 0),
			new AdventureEndNode("5d336ffc-c809-47c9-9b7b-bf5e6bc91f56", "H", "LK_Adventure_NodeTitle_487", 0)
		};
		List<AdventureBaseBranch> baseBranches14 = new List<AdventureBaseBranch>
		{
			new AdventureBaseBranch(0, 2, "1", 1, 5, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 10, 25, 10, 10, 20, 50, 10, 7,
				19, 25, 10, 10, 20, 50, 10, 7, 18, 25,
				10, 10, 20, 50, 10, 7, 16, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 15, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "10", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "5", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "30",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "5", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(2, 3, "2", 1, 5, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 10, 25, 10, 10, 20, 50, 10, 7,
				19, 25, 10, 10, 20, 50, 10, 7, 18, 25,
				10, 10, 20, 50, 10, 7, 16, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 30, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "45", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "30", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "10",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "10", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(3, 6, "3", 1, 5, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 10, 25, 10, 10, 20, 50, 10, 7,
				19, 25, 10, 10, 20, 50, 10, 7, 18, 25,
				10, 10, 20, 50, 10, 7, 16, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 15, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "10", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "30", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "5",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "5", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(1, 5, "4", 1, 10, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 10, 25, 10, 10, 20, 50, 10, 7,
				19, 25, 10, 10, 20, 50, 10, 7, 18, 25,
				10, 10, 20, 50, 10, 7, 16, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 15, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "10", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "5", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "30",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "5", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(5, 4, "5", 1, 10, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 10, 25, 10, 10, 20, 50, 10, 7,
				19, 25, 10, 10, 20, 50, 10, 7, 18, 25,
				10, 10, 20, 50, 10, 7, 16, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 30, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "45", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "30", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "10",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "10", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" }),
			new AdventureBaseBranch(4, 7, "6", 1, 10, "", new int[32]
			{
				0, 5, 1, 5, 2, 5, 3, 5, 4, 5,
				5, 5, 6, 5, 7, 5, 8, 5, 9, 5,
				10, 5, 11, 5, 12, 5, 13, 5, 14, 5,
				15, 5
			}, new int[33]
			{
				4, 7, 10, 25, 10, 10, 20, 50, 10, 7,
				19, 25, 10, 10, 20, 50, 10, 7, 18, 25,
				10, 10, 20, 50, 10, 7, 16, 25, 10, 10,
				20, 50, 10
			}, new int[5] { 25, 5, 15, 50, 10 }, new string[13]
			{
				"0", "0", "1", "8138ec91-501c-4fb9-b886-800901738e9b", "10", "3", "0050ff4d-60e4-4e9a-9d1e-206981fa22fb", "30", "d9486c37-0e21-444f-9ee8-34b414e4c7ce", "5",
				"80bb079b-44f9-4858-b694-9c76260c80d8", "5", "0"
			}, new int[77]
			{
				15, 0, 200, 5, 0, 300, 3, 0, 400, 2,
				1, 200, 5, 1, 300, 3, 1, 400, 2, 2,
				200, 5, 2, 300, 3, 2, 400, 2, 3, 200,
				5, 3, 300, 3, 3, 400, 2, 4, 200, 5,
				4, 300, 3, 4, 400, 2, 3, 8, 500, 5,
				8, 750, 3, 8, 1000, 2, 0, 3, 7, 160,
				5, 7, 240, 3, 7, 320, 2, 3, 5, 200,
				5, 5, 300, 3, 5, 400, 2
			}, new int[17]
			{
				0, 0, 1, 2, -201, 1, 5, 0, 2, 8,
				-801, 1, 5, 8, -802, 1, 5
			}, new string[5] { "0", "0", "0", "0", "0" })
		};
		advancedBranches = new List<AdventureAdvancedBranch>();
		dataArray17.Add(new AdventureItem(196, config33, config34, 17, 7, 7, 2, 10, 6, resCost17, itemCost17, restrictedByWorldPopulation: false, malice17, adventureParams17, "2c18c022-83e0-407f-9982-1db1b2915a6b", startNodes17, transferNodes15, endNodes14, baseBranches14, advancedBranches, difficultyAddXiangshuLevel: false));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<AdventureItem>(197);
		CreateItems0();
		CreateItems1();
		CreateItems2();
		CreateItems3();
	}
}

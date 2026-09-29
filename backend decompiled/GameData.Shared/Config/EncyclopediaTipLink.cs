using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class EncyclopediaTipLink : ConfigData<EncyclopediaTipLinkItem, int>
{
	public static class DefKey
	{
		public const int TipLegacy = 0;

		public const int MixPoison = 1;

		public const int FuyuSwordGrip = 2;

		public const int Fame = 3;

		public const int SupportCommands = 4;

		public const int Disassembly = 5;

		public const int Equip = 6;

		public const int MainEquip = 7;

		public const int SecondaryEquipment = 8;

		public const int Talent = 9;

		public const int FineArts = 10;

		public const int MartialArts = 11;

		public const int Attainment = 12;

		public const int Breakthrough = 13;

		public const int Mechanism = 14;

		public const int QiAttributes = 15;

		public const int Relation = 16;

		public const int Captive = 17;

		public const int Experience = 18;

		public const int Reincarnation = 19;

		public const int Handpick = 20;

		public const int MartialLoadout = 21;

		public const int Wariness = 22;

		public const int Bloodline = 23;

		public const int Reforged = 24;

		public const int Imprint = 25;

		public const int StudyingBooks = 26;

		public const int MicrocosmicCirculation = 27;

		public const int MedicalCare = 28;

		public const int Faction = 29;

		public const int TaiwuInheritance = 30;

		public const int Shaolin = 31;

		public const int Emei = 32;

		public const int BaihuaLifeLink = 33;

		public const int WudangTree = 34;

		public const int Yuanshan = 35;

		public const int Shixiang = 36;

		public const int Ranshan = 37;

		public const int Xuannv = 38;

		public const int ZhujianGearMate = 39;

		public const int Kongsang = 40;

		public const int Jingang = 41;

		public const int WugKing = 42;

		public const int Jieqing = 43;

		public const int Xuehou = 44;

		public const int ChickenCoop = 45;

		public const int TeaHorseCaravan = 46;

		public const int CricketChamber = 47;

		public const int TaiwuVillage = 48;

		public const int BanquetHall = 49;

		public const int IndustryBuildings = 50;

		public const int WoodeDummy = 51;

		public const int PracticeTechnique = 52;

		public const int Prison = 53;

		public const int Warehouse = 54;

		public const int ExperienceChronicle = 55;

		public const int Secret = 56;

		public const int InheritanceRecords = 57;

		public const int ReincarnationPlatform = 58;

		public const int AspirationInsight = 59;

		public const int DebateTopic = 60;

		public const int Debate = 61;

		public const int Travel = 62;

		public const int SecretTome = 63;

		public const int Exchange = 64;

		public const int Envenom = 65;

		public const int Alteration = 66;

		public const int Detoxify = 67;

		public const int Refinement = 68;

		public const int Repair = 69;

		public const int Craft = 70;

		public const int CricketDue = 71;

		public const int CricketHunt = 72;

		public const int InventiveMind = 73;

		public const int StoneHouse = 74;

		public const int DebateRating = 75;

		public const int InvasionProgress = 76;

		public const int Name = 77;

		public const int BirthTime = 78;

		public const int Age = 79;

		public const int Gender = 80;

		public const int Charm = 81;

		public const int Mood = 82;

		public const int Mindset = 83;

		public const int Rank = 84;

		public const int Favorability = 85;

		public const int CharacterTitle = 86;

		public const int PrimaryAttributes = 87;

		public const int BattleAttributes = 88;

		public const int Trait = 89;

		public const int Dispositions = 90;

		public const int Health = 91;

		public const int Injuries = 92;

		public const int Toxin = 93;

		public const int InnerBreath = 94;

		public const int OralMedication = 95;

		public const int Love = 96;

		public const int Enemy = 97;

		public const int TestingPoison = 98;

		public const int Buildings = 99;

		public const int DebateStrategy = 100;

		public const int FineArtsInsight = 101;

		public const int MartialArtsRatio = 102;

		public const int Simplification = 103;

		public const int DantianQi = 104;

		public const int PureEssence = 105;

		public const int TrueQi = 106;

		public const int Stance = 107;

		public const int Inhale = 108;

		public const int Footwork = 109;

		public const int Distance = 110;

		public const int CombatMoves = 111;

		public const int PinpointStrikes = 112;

		public const int DefeatMarkers = 113;

		public const int BattleStatus = 114;

		public const int Openings = 115;

		public const int SealedAcupoints = 116;

		public const int TrueQiState = 117;

		public const int CombatActions = 118;

		public const int Audience = 119;

		public const int MapBlockCollectResource = 120;

		public const int Companion = 121;

		public const int MonthlyReport = 122;

		public const int Talk = 123;

		public const int Chicken = 124;

		public const int SectLearPermisson = 125;

		public const int SectDebtInteraction = 126;

		public const int BookExchangePersonal = 127;

		public const int JuniorXiangshu = 128;

		public const int WarehouseExchange = 129;

		public const int CharacterCreate = 130;

		public const int BornArea = 131;

		public const int NeiliProperty = 132;

		public const int PresetTricks = 133;

		public const int WorldDetail = 134;

		public const int ChallengeMode = 135;

		public const int Sect = 136;

		public const int MindUpheaval = 137;

		public const int ExchangeAdvantage = 138;

		public const int ChickenPolymorph = 139;

		public const int ChickenCombat = 140;
	}

	public static class DefValue
	{
		public static EncyclopediaTipLinkItem TipLegacy => Instance[0];

		public static EncyclopediaTipLinkItem MixPoison => Instance[1];

		public static EncyclopediaTipLinkItem FuyuSwordGrip => Instance[2];

		public static EncyclopediaTipLinkItem Fame => Instance[3];

		public static EncyclopediaTipLinkItem SupportCommands => Instance[4];

		public static EncyclopediaTipLinkItem Disassembly => Instance[5];

		public static EncyclopediaTipLinkItem Equip => Instance[6];

		public static EncyclopediaTipLinkItem MainEquip => Instance[7];

		public static EncyclopediaTipLinkItem SecondaryEquipment => Instance[8];

		public static EncyclopediaTipLinkItem Talent => Instance[9];

		public static EncyclopediaTipLinkItem FineArts => Instance[10];

		public static EncyclopediaTipLinkItem MartialArts => Instance[11];

		public static EncyclopediaTipLinkItem Attainment => Instance[12];

		public static EncyclopediaTipLinkItem Breakthrough => Instance[13];

		public static EncyclopediaTipLinkItem Mechanism => Instance[14];

		public static EncyclopediaTipLinkItem QiAttributes => Instance[15];

		public static EncyclopediaTipLinkItem Relation => Instance[16];

		public static EncyclopediaTipLinkItem Captive => Instance[17];

		public static EncyclopediaTipLinkItem Experience => Instance[18];

		public static EncyclopediaTipLinkItem Reincarnation => Instance[19];

		public static EncyclopediaTipLinkItem Handpick => Instance[20];

		public static EncyclopediaTipLinkItem MartialLoadout => Instance[21];

		public static EncyclopediaTipLinkItem Wariness => Instance[22];

		public static EncyclopediaTipLinkItem Bloodline => Instance[23];

		public static EncyclopediaTipLinkItem Reforged => Instance[24];

		public static EncyclopediaTipLinkItem Imprint => Instance[25];

		public static EncyclopediaTipLinkItem StudyingBooks => Instance[26];

		public static EncyclopediaTipLinkItem MicrocosmicCirculation => Instance[27];

		public static EncyclopediaTipLinkItem MedicalCare => Instance[28];

		public static EncyclopediaTipLinkItem Faction => Instance[29];

		public static EncyclopediaTipLinkItem TaiwuInheritance => Instance[30];

		public static EncyclopediaTipLinkItem Shaolin => Instance[31];

		public static EncyclopediaTipLinkItem Emei => Instance[32];

		public static EncyclopediaTipLinkItem BaihuaLifeLink => Instance[33];

		public static EncyclopediaTipLinkItem WudangTree => Instance[34];

		public static EncyclopediaTipLinkItem Yuanshan => Instance[35];

		public static EncyclopediaTipLinkItem Shixiang => Instance[36];

		public static EncyclopediaTipLinkItem Ranshan => Instance[37];

		public static EncyclopediaTipLinkItem Xuannv => Instance[38];

		public static EncyclopediaTipLinkItem ZhujianGearMate => Instance[39];

		public static EncyclopediaTipLinkItem Kongsang => Instance[40];

		public static EncyclopediaTipLinkItem Jingang => Instance[41];

		public static EncyclopediaTipLinkItem WugKing => Instance[42];

		public static EncyclopediaTipLinkItem Jieqing => Instance[43];

		public static EncyclopediaTipLinkItem Xuehou => Instance[44];

		public static EncyclopediaTipLinkItem ChickenCoop => Instance[45];

		public static EncyclopediaTipLinkItem TeaHorseCaravan => Instance[46];

		public static EncyclopediaTipLinkItem CricketChamber => Instance[47];

		public static EncyclopediaTipLinkItem TaiwuVillage => Instance[48];

		public static EncyclopediaTipLinkItem BanquetHall => Instance[49];

		public static EncyclopediaTipLinkItem IndustryBuildings => Instance[50];

		public static EncyclopediaTipLinkItem WoodeDummy => Instance[51];

		public static EncyclopediaTipLinkItem PracticeTechnique => Instance[52];

		public static EncyclopediaTipLinkItem Prison => Instance[53];

		public static EncyclopediaTipLinkItem Warehouse => Instance[54];

		public static EncyclopediaTipLinkItem ExperienceChronicle => Instance[55];

		public static EncyclopediaTipLinkItem Secret => Instance[56];

		public static EncyclopediaTipLinkItem InheritanceRecords => Instance[57];

		public static EncyclopediaTipLinkItem ReincarnationPlatform => Instance[58];

		public static EncyclopediaTipLinkItem AspirationInsight => Instance[59];

		public static EncyclopediaTipLinkItem DebateTopic => Instance[60];

		public static EncyclopediaTipLinkItem Debate => Instance[61];

		public static EncyclopediaTipLinkItem Travel => Instance[62];

		public static EncyclopediaTipLinkItem SecretTome => Instance[63];

		public static EncyclopediaTipLinkItem Exchange => Instance[64];

		public static EncyclopediaTipLinkItem Envenom => Instance[65];

		public static EncyclopediaTipLinkItem Alteration => Instance[66];

		public static EncyclopediaTipLinkItem Detoxify => Instance[67];

		public static EncyclopediaTipLinkItem Refinement => Instance[68];

		public static EncyclopediaTipLinkItem Repair => Instance[69];

		public static EncyclopediaTipLinkItem Craft => Instance[70];

		public static EncyclopediaTipLinkItem CricketDue => Instance[71];

		public static EncyclopediaTipLinkItem CricketHunt => Instance[72];

		public static EncyclopediaTipLinkItem InventiveMind => Instance[73];

		public static EncyclopediaTipLinkItem StoneHouse => Instance[74];

		public static EncyclopediaTipLinkItem DebateRating => Instance[75];

		public static EncyclopediaTipLinkItem InvasionProgress => Instance[76];

		public static EncyclopediaTipLinkItem Name => Instance[77];

		public static EncyclopediaTipLinkItem BirthTime => Instance[78];

		public static EncyclopediaTipLinkItem Age => Instance[79];

		public static EncyclopediaTipLinkItem Gender => Instance[80];

		public static EncyclopediaTipLinkItem Charm => Instance[81];

		public static EncyclopediaTipLinkItem Mood => Instance[82];

		public static EncyclopediaTipLinkItem Mindset => Instance[83];

		public static EncyclopediaTipLinkItem Rank => Instance[84];

		public static EncyclopediaTipLinkItem Favorability => Instance[85];

		public static EncyclopediaTipLinkItem CharacterTitle => Instance[86];

		public static EncyclopediaTipLinkItem PrimaryAttributes => Instance[87];

		public static EncyclopediaTipLinkItem BattleAttributes => Instance[88];

		public static EncyclopediaTipLinkItem Trait => Instance[89];

		public static EncyclopediaTipLinkItem Dispositions => Instance[90];

		public static EncyclopediaTipLinkItem Health => Instance[91];

		public static EncyclopediaTipLinkItem Injuries => Instance[92];

		public static EncyclopediaTipLinkItem Toxin => Instance[93];

		public static EncyclopediaTipLinkItem InnerBreath => Instance[94];

		public static EncyclopediaTipLinkItem OralMedication => Instance[95];

		public static EncyclopediaTipLinkItem Love => Instance[96];

		public static EncyclopediaTipLinkItem Enemy => Instance[97];

		public static EncyclopediaTipLinkItem TestingPoison => Instance[98];

		public static EncyclopediaTipLinkItem Buildings => Instance[99];

		public static EncyclopediaTipLinkItem DebateStrategy => Instance[100];

		public static EncyclopediaTipLinkItem FineArtsInsight => Instance[101];

		public static EncyclopediaTipLinkItem MartialArtsRatio => Instance[102];

		public static EncyclopediaTipLinkItem Simplification => Instance[103];

		public static EncyclopediaTipLinkItem DantianQi => Instance[104];

		public static EncyclopediaTipLinkItem PureEssence => Instance[105];

		public static EncyclopediaTipLinkItem TrueQi => Instance[106];

		public static EncyclopediaTipLinkItem Stance => Instance[107];

		public static EncyclopediaTipLinkItem Inhale => Instance[108];

		public static EncyclopediaTipLinkItem Footwork => Instance[109];

		public static EncyclopediaTipLinkItem Distance => Instance[110];

		public static EncyclopediaTipLinkItem CombatMoves => Instance[111];

		public static EncyclopediaTipLinkItem PinpointStrikes => Instance[112];

		public static EncyclopediaTipLinkItem DefeatMarkers => Instance[113];

		public static EncyclopediaTipLinkItem BattleStatus => Instance[114];

		public static EncyclopediaTipLinkItem Openings => Instance[115];

		public static EncyclopediaTipLinkItem SealedAcupoints => Instance[116];

		public static EncyclopediaTipLinkItem TrueQiState => Instance[117];

		public static EncyclopediaTipLinkItem CombatActions => Instance[118];

		public static EncyclopediaTipLinkItem Audience => Instance[119];

		public static EncyclopediaTipLinkItem MapBlockCollectResource => Instance[120];

		public static EncyclopediaTipLinkItem Companion => Instance[121];

		public static EncyclopediaTipLinkItem MonthlyReport => Instance[122];

		public static EncyclopediaTipLinkItem Talk => Instance[123];

		public static EncyclopediaTipLinkItem Chicken => Instance[124];

		public static EncyclopediaTipLinkItem SectLearPermisson => Instance[125];

		public static EncyclopediaTipLinkItem SectDebtInteraction => Instance[126];

		public static EncyclopediaTipLinkItem BookExchangePersonal => Instance[127];

		public static EncyclopediaTipLinkItem JuniorXiangshu => Instance[128];

		public static EncyclopediaTipLinkItem WarehouseExchange => Instance[129];

		public static EncyclopediaTipLinkItem CharacterCreate => Instance[130];

		public static EncyclopediaTipLinkItem BornArea => Instance[131];

		public static EncyclopediaTipLinkItem NeiliProperty => Instance[132];

		public static EncyclopediaTipLinkItem PresetTricks => Instance[133];

		public static EncyclopediaTipLinkItem WorldDetail => Instance[134];

		public static EncyclopediaTipLinkItem ChallengeMode => Instance[135];

		public static EncyclopediaTipLinkItem Sect => Instance[136];

		public static EncyclopediaTipLinkItem MindUpheaval => Instance[137];

		public static EncyclopediaTipLinkItem ExchangeAdvantage => Instance[138];

		public static EncyclopediaTipLinkItem ChickenPolymorph => Instance[139];

		public static EncyclopediaTipLinkItem ChickenCombat => Instance[140];
	}

	public static EncyclopediaTipLink Instance = new EncyclopediaTipLink();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "TemplateId", "RefName", "Type" };

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
		_dataArray.Add(new EncyclopediaTipLinkItem(0, EEncyclopediaTipLinkMode.Default, "遗惠点数", EEncyclopediaTipLinkType.TipLegacy));
		_dataArray.Add(new EncyclopediaTipLinkItem(1, EEncyclopediaTipLinkMode.Default, "混合毒素", EEncyclopediaTipLinkType.MixPoison));
		_dataArray.Add(new EncyclopediaTipLinkItem(2, EEncyclopediaTipLinkMode.Default, "伏虞剑柄", EEncyclopediaTipLinkType.FuyuSwordGrip));
		_dataArray.Add(new EncyclopediaTipLinkItem(3, EEncyclopediaTipLinkMode.Default, "名誉", EEncyclopediaTipLinkType.Fame));
		_dataArray.Add(new EncyclopediaTipLinkItem(4, EEncyclopediaTipLinkMode.Default, "助战指令", EEncyclopediaTipLinkType.SupportCommands));
		_dataArray.Add(new EncyclopediaTipLinkItem(5, EEncyclopediaTipLinkMode.Default, "拆解", EEncyclopediaTipLinkType.Disassembly));
		_dataArray.Add(new EncyclopediaTipLinkItem(6, EEncyclopediaTipLinkMode.Default, "装备", EEncyclopediaTipLinkType.Equip));
		_dataArray.Add(new EncyclopediaTipLinkItem(7, EEncyclopediaTipLinkMode.Default, "武具", EEncyclopediaTipLinkType.MainEquip));
		_dataArray.Add(new EncyclopediaTipLinkItem(8, EEncyclopediaTipLinkMode.Default, "行装", EEncyclopediaTipLinkType.SecondaryEquipment));
		_dataArray.Add(new EncyclopediaTipLinkItem(9, EEncyclopediaTipLinkMode.Default, "人物-人物信息-资质", EEncyclopediaTipLinkType.Talent));
		_dataArray.Add(new EncyclopediaTipLinkItem(10, EEncyclopediaTipLinkMode.Default, "修习-技艺-技艺", EEncyclopediaTipLinkType.FineArts));
		_dataArray.Add(new EncyclopediaTipLinkItem(11, EEncyclopediaTipLinkMode.Default, "修习-武学-功法", EEncyclopediaTipLinkType.MartialArts));
		_dataArray.Add(new EncyclopediaTipLinkItem(12, EEncyclopediaTipLinkMode.Default, "人物-人物信息-造诣", EEncyclopediaTipLinkType.Attainment));
		_dataArray.Add(new EncyclopediaTipLinkItem(13, EEncyclopediaTipLinkMode.Default, "突破", EEncyclopediaTipLinkType.Breakthrough));
		_dataArray.Add(new EncyclopediaTipLinkItem(14, EEncyclopediaTipLinkMode.Default, "玄机", EEncyclopediaTipLinkType.Mechanism));
		_dataArray.Add(new EncyclopediaTipLinkItem(15, EEncyclopediaTipLinkMode.Default, "内力属性", EEncyclopediaTipLinkType.QiAttributes));
		_dataArray.Add(new EncyclopediaTipLinkItem(16, EEncyclopediaTipLinkMode.Default, "关系", EEncyclopediaTipLinkType.Relation));
		_dataArray.Add(new EncyclopediaTipLinkItem(17, EEncyclopediaTipLinkMode.Default, "俘虏", EEncyclopediaTipLinkType.Captive));
		_dataArray.Add(new EncyclopediaTipLinkItem(18, EEncyclopediaTipLinkMode.Default, "经历", EEncyclopediaTipLinkType.Experience));
		_dataArray.Add(new EncyclopediaTipLinkItem(19, EEncyclopediaTipLinkMode.Default, "轮回", EEncyclopediaTipLinkType.Reincarnation));
		_dataArray.Add(new EncyclopediaTipLinkItem(20, EEncyclopediaTipLinkMode.Default, "精挑细选", EEncyclopediaTipLinkType.Handpick));
		_dataArray.Add(new EncyclopediaTipLinkItem(21, EEncyclopediaTipLinkMode.Default, "运功", EEncyclopediaTipLinkType.MartialLoadout));
		_dataArray.Add(new EncyclopediaTipLinkItem(22, EEncyclopediaTipLinkMode.Default, "戒心", EEncyclopediaTipLinkType.Wariness));
		_dataArray.Add(new EncyclopediaTipLinkItem(23, EEncyclopediaTipLinkMode.Default, "族谱", EEncyclopediaTipLinkType.Bloodline));
		_dataArray.Add(new EncyclopediaTipLinkItem(24, EEncyclopediaTipLinkMode.Default, "生铸", EEncyclopediaTipLinkType.Reforged));
		_dataArray.Add(new EncyclopediaTipLinkItem(25, EEncyclopediaTipLinkMode.Default, "铭刻", EEncyclopediaTipLinkType.Imprint));
		_dataArray.Add(new EncyclopediaTipLinkItem(26, EEncyclopediaTipLinkMode.Default, "研读书籍", EEncyclopediaTipLinkType.StudyingBooks));
		_dataArray.Add(new EncyclopediaTipLinkItem(27, EEncyclopediaTipLinkMode.Default, "周天运转", EEncyclopediaTipLinkType.MicrocosmicCirculation));
		_dataArray.Add(new EncyclopediaTipLinkItem(28, EEncyclopediaTipLinkMode.Default, "诊疗", EEncyclopediaTipLinkType.MedicalCare));
		_dataArray.Add(new EncyclopediaTipLinkItem(29, EEncyclopediaTipLinkMode.Default, "势力", EEncyclopediaTipLinkType.Faction));
		_dataArray.Add(new EncyclopediaTipLinkItem(30, EEncyclopediaTipLinkMode.Default, "太吾传承", EEncyclopediaTipLinkType.TaiwuInheritance));
		_dataArray.Add(new EncyclopediaTipLinkItem(31, EEncyclopediaTipLinkMode.Default, "门派-门派一览-少林派-特有功能", EEncyclopediaTipLinkType.Shaolin));
		_dataArray.Add(new EncyclopediaTipLinkItem(32, EEncyclopediaTipLinkMode.Default, "特有功能2", EEncyclopediaTipLinkType.Emei));
		_dataArray.Add(new EncyclopediaTipLinkItem(33, EEncyclopediaTipLinkMode.Default, "特有功能3", EEncyclopediaTipLinkType.BaihuaLifeLink));
		_dataArray.Add(new EncyclopediaTipLinkItem(34, EEncyclopediaTipLinkMode.Default, "特有功能4", EEncyclopediaTipLinkType.WudangTree));
		_dataArray.Add(new EncyclopediaTipLinkItem(35, EEncyclopediaTipLinkMode.Default, "特有功能5", EEncyclopediaTipLinkType.Yuanshan));
		_dataArray.Add(new EncyclopediaTipLinkItem(36, EEncyclopediaTipLinkMode.Default, "特有功能6", EEncyclopediaTipLinkType.Shixiang));
		_dataArray.Add(new EncyclopediaTipLinkItem(37, EEncyclopediaTipLinkMode.Default, "特有功能7", EEncyclopediaTipLinkType.Ranshan));
		_dataArray.Add(new EncyclopediaTipLinkItem(38, EEncyclopediaTipLinkMode.Default, "特有功能8", EEncyclopediaTipLinkType.Xuannv));
		_dataArray.Add(new EncyclopediaTipLinkItem(39, EEncyclopediaTipLinkMode.Default, "特有功能9", EEncyclopediaTipLinkType.ZhujianGearMate));
		_dataArray.Add(new EncyclopediaTipLinkItem(40, EEncyclopediaTipLinkMode.Default, "特有功能10", EEncyclopediaTipLinkType.Kongsang));
		_dataArray.Add(new EncyclopediaTipLinkItem(41, EEncyclopediaTipLinkMode.Default, "特有功能11", EEncyclopediaTipLinkType.Jingang));
		_dataArray.Add(new EncyclopediaTipLinkItem(42, EEncyclopediaTipLinkMode.Default, "特有功能12", EEncyclopediaTipLinkType.WugKing));
		_dataArray.Add(new EncyclopediaTipLinkItem(43, EEncyclopediaTipLinkMode.Default, "特有功能13", EEncyclopediaTipLinkType.Jieqing));
		_dataArray.Add(new EncyclopediaTipLinkItem(44, EEncyclopediaTipLinkMode.Default, "特有功能15", EEncyclopediaTipLinkType.Xuehou));
		_dataArray.Add(new EncyclopediaTipLinkItem(45, EEncyclopediaTipLinkMode.Default, "元鸡舍", EEncyclopediaTipLinkType.ChickenCoop));
		_dataArray.Add(new EncyclopediaTipLinkItem(46, EEncyclopediaTipLinkMode.Default, "茶马帮", EEncyclopediaTipLinkType.TeaHorseCaravan));
		_dataArray.Add(new EncyclopediaTipLinkItem(47, EEncyclopediaTipLinkMode.Default, "蛰室", EEncyclopediaTipLinkType.CricketChamber));
		_dataArray.Add(new EncyclopediaTipLinkItem(48, EEncyclopediaTipLinkMode.Default, "太吾村", EEncyclopediaTipLinkType.TaiwuVillage));
		_dataArray.Add(new EncyclopediaTipLinkItem(49, EEncyclopediaTipLinkMode.Default, "宴堂", EEncyclopediaTipLinkType.BanquetHall));
		_dataArray.Add(new EncyclopediaTipLinkItem(50, EEncyclopediaTipLinkMode.Default, "产业建筑", EEncyclopediaTipLinkType.IndustryBuildings));
		_dataArray.Add(new EncyclopediaTipLinkItem(51, EEncyclopediaTipLinkMode.Default, "木人战斗", EEncyclopediaTipLinkType.WoodeDummy));
		_dataArray.Add(new EncyclopediaTipLinkItem(52, EEncyclopediaTipLinkMode.Default, "练习功法", EEncyclopediaTipLinkType.PracticeTechnique));
		_dataArray.Add(new EncyclopediaTipLinkItem(53, EEncyclopediaTipLinkMode.Default, "监牢", EEncyclopediaTipLinkType.Prison));
		_dataArray.Add(new EncyclopediaTipLinkItem(54, EEncyclopediaTipLinkMode.Default, "库房", EEncyclopediaTipLinkType.Warehouse));
		_dataArray.Add(new EncyclopediaTipLinkItem(55, EEncyclopediaTipLinkMode.Default, "见闻", EEncyclopediaTipLinkType.ExperienceChronicle));
		_dataArray.Add(new EncyclopediaTipLinkItem(56, EEncyclopediaTipLinkMode.Default, "秘闻", EEncyclopediaTipLinkType.Secret));
		_dataArray.Add(new EncyclopediaTipLinkItem(57, EEncyclopediaTipLinkMode.Default, "传承名谱", EEncyclopediaTipLinkType.InheritanceRecords));
		_dataArray.Add(new EncyclopediaTipLinkItem(58, EEncyclopediaTipLinkMode.Default, "轮回台", EEncyclopediaTipLinkType.ReincarnationPlatform));
		_dataArray.Add(new EncyclopediaTipLinkItem(59, EEncyclopediaTipLinkMode.Default, "志向", EEncyclopediaTipLinkType.AspirationInsight));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new EncyclopediaTipLinkItem(60, EEncyclopediaTipLinkMode.Default, "较艺主题", EEncyclopediaTipLinkType.DebateTopic));
		_dataArray.Add(new EncyclopediaTipLinkItem(61, EEncyclopediaTipLinkMode.Default, "较艺", EEncyclopediaTipLinkType.Debate));
		_dataArray.Add(new EncyclopediaTipLinkItem(62, EEncyclopediaTipLinkMode.Default, "旅行", EEncyclopediaTipLinkType.Travel));
		_dataArray.Add(new EncyclopediaTipLinkItem(63, EEncyclopediaTipLinkMode.Default, "解读奇书", EEncyclopediaTipLinkType.SecretTome));
		_dataArray.Add(new EncyclopediaTipLinkItem(64, EEncyclopediaTipLinkMode.Default, "交换物资", EEncyclopediaTipLinkType.Exchange));
		_dataArray.Add(new EncyclopediaTipLinkItem(65, EEncyclopediaTipLinkMode.Default, "淬毒", EEncyclopediaTipLinkType.Envenom));
		_dataArray.Add(new EncyclopediaTipLinkItem(66, EEncyclopediaTipLinkMode.Default, "改制", EEncyclopediaTipLinkType.Alteration));
		_dataArray.Add(new EncyclopediaTipLinkItem(67, EEncyclopediaTipLinkMode.Default, "解毒", EEncyclopediaTipLinkType.Detoxify));
		_dataArray.Add(new EncyclopediaTipLinkItem(68, EEncyclopediaTipLinkMode.Default, "精制", EEncyclopediaTipLinkType.Refinement));
		_dataArray.Add(new EncyclopediaTipLinkItem(69, EEncyclopediaTipLinkMode.Default, "修理", EEncyclopediaTipLinkType.Repair));
		_dataArray.Add(new EncyclopediaTipLinkItem(70, EEncyclopediaTipLinkMode.Default, "制造", EEncyclopediaTipLinkType.Craft));
		_dataArray.Add(new EncyclopediaTipLinkItem(71, EEncyclopediaTipLinkMode.Default, "促织决斗", EEncyclopediaTipLinkType.CricketDue));
		_dataArray.Add(new EncyclopediaTipLinkItem(72, EEncyclopediaTipLinkMode.Default, "捕捉促织", EEncyclopediaTipLinkType.CricketHunt));
		_dataArray.Add(new EncyclopediaTipLinkItem(73, EEncyclopediaTipLinkMode.Default, "独具匠心", EEncyclopediaTipLinkType.InventiveMind));
		_dataArray.Add(new EncyclopediaTipLinkItem(74, EEncyclopediaTipLinkMode.Default, "石屋", EEncyclopediaTipLinkType.StoneHouse));
		_dataArray.Add(new EncyclopediaTipLinkItem(75, EEncyclopediaTipLinkMode.Default, "较艺评价", EEncyclopediaTipLinkType.DebateRating));
		_dataArray.Add(new EncyclopediaTipLinkItem(76, EEncyclopediaTipLinkMode.Default, "侵袭进度", EEncyclopediaTipLinkType.InvasionProgress));
		_dataArray.Add(new EncyclopediaTipLinkItem(77, EEncyclopediaTipLinkMode.Default, "姓名", EEncyclopediaTipLinkType.Name));
		_dataArray.Add(new EncyclopediaTipLinkItem(78, EEncyclopediaTipLinkMode.Default, "生时", EEncyclopediaTipLinkType.BirthTime));
		_dataArray.Add(new EncyclopediaTipLinkItem(79, EEncyclopediaTipLinkMode.Default, "年龄", EEncyclopediaTipLinkType.Age));
		_dataArray.Add(new EncyclopediaTipLinkItem(80, EEncyclopediaTipLinkMode.Default, "性别", EEncyclopediaTipLinkType.Gender));
		_dataArray.Add(new EncyclopediaTipLinkItem(81, EEncyclopediaTipLinkMode.Default, "魅力", EEncyclopediaTipLinkType.Charm));
		_dataArray.Add(new EncyclopediaTipLinkItem(82, EEncyclopediaTipLinkMode.Default, "心情", EEncyclopediaTipLinkType.Mood));
		_dataArray.Add(new EncyclopediaTipLinkItem(83, EEncyclopediaTipLinkMode.Default, "立场", EEncyclopediaTipLinkType.Mindset));
		_dataArray.Add(new EncyclopediaTipLinkItem(84, EEncyclopediaTipLinkMode.Default, "身份", EEncyclopediaTipLinkType.Rank));
		_dataArray.Add(new EncyclopediaTipLinkItem(85, EEncyclopediaTipLinkMode.Default, "好感", EEncyclopediaTipLinkType.Favorability));
		_dataArray.Add(new EncyclopediaTipLinkItem(86, EEncyclopediaTipLinkMode.Default, "称号", EEncyclopediaTipLinkType.CharacterTitle));
		_dataArray.Add(new EncyclopediaTipLinkItem(87, EEncyclopediaTipLinkMode.Default, "主要属性", EEncyclopediaTipLinkType.PrimaryAttributes));
		_dataArray.Add(new EncyclopediaTipLinkItem(88, EEncyclopediaTipLinkMode.Default, "战斗属性", EEncyclopediaTipLinkType.BattleAttributes));
		_dataArray.Add(new EncyclopediaTipLinkItem(89, EEncyclopediaTipLinkMode.Default, "特性", EEncyclopediaTipLinkType.Trait));
		_dataArray.Add(new EncyclopediaTipLinkItem(90, EEncyclopediaTipLinkMode.Default, "七元赋性", EEncyclopediaTipLinkType.Dispositions));
		_dataArray.Add(new EncyclopediaTipLinkItem(91, EEncyclopediaTipLinkMode.Default, "健康", EEncyclopediaTipLinkType.Health));
		_dataArray.Add(new EncyclopediaTipLinkItem(92, EEncyclopediaTipLinkMode.Default, "伤势", EEncyclopediaTipLinkType.Injuries));
		_dataArray.Add(new EncyclopediaTipLinkItem(93, EEncyclopediaTipLinkMode.Default, "毒素", EEncyclopediaTipLinkType.Toxin));
		_dataArray.Add(new EncyclopediaTipLinkItem(94, EEncyclopediaTipLinkMode.Default, "内息", EEncyclopediaTipLinkType.InnerBreath));
		_dataArray.Add(new EncyclopediaTipLinkItem(95, EEncyclopediaTipLinkMode.Default, "服食汲饮", EEncyclopediaTipLinkType.OralMedication));
		_dataArray.Add(new EncyclopediaTipLinkItem(96, EEncyclopediaTipLinkMode.Default, "爱慕", EEncyclopediaTipLinkType.Love));
		_dataArray.Add(new EncyclopediaTipLinkItem(97, EEncyclopediaTipLinkMode.Default, "仇敌", EEncyclopediaTipLinkType.Enemy));
		_dataArray.Add(new EncyclopediaTipLinkItem(98, EEncyclopediaTipLinkMode.Default, "验毒", EEncyclopediaTipLinkType.TestingPoison));
		_dataArray.Add(new EncyclopediaTipLinkItem(99, EEncyclopediaTipLinkMode.Default, "建筑", EEncyclopediaTipLinkType.Buildings));
		_dataArray.Add(new EncyclopediaTipLinkItem(100, EEncyclopediaTipLinkMode.Default, "较艺策略", EEncyclopediaTipLinkType.DebateStrategy));
		_dataArray.Add(new EncyclopediaTipLinkItem(101, EEncyclopediaTipLinkMode.Default, "技艺见闻", EEncyclopediaTipLinkType.FineArtsInsight));
		_dataArray.Add(new EncyclopediaTipLinkItem(102, EEncyclopediaTipLinkMode.Default, "内外功比例", EEncyclopediaTipLinkType.MartialArtsRatio));
		_dataArray.Add(new EncyclopediaTipLinkItem(103, EEncyclopediaTipLinkMode.Default, "精解", EEncyclopediaTipLinkType.Simplification));
		_dataArray.Add(new EncyclopediaTipLinkItem(104, EEncyclopediaTipLinkMode.Default, "丹田内力", EEncyclopediaTipLinkType.DantianQi));
		_dataArray.Add(new EncyclopediaTipLinkItem(105, EEncyclopediaTipLinkMode.Default, "精纯境界", EEncyclopediaTipLinkType.PureEssence));
		_dataArray.Add(new EncyclopediaTipLinkItem(106, EEncyclopediaTipLinkMode.Default, "真气", EEncyclopediaTipLinkType.TrueQi));
		_dataArray.Add(new EncyclopediaTipLinkItem(107, EEncyclopediaTipLinkMode.Default, "架势", EEncyclopediaTipLinkType.Stance));
		_dataArray.Add(new EncyclopediaTipLinkItem(108, EEncyclopediaTipLinkMode.Default, "提气", EEncyclopediaTipLinkType.Inhale));
		_dataArray.Add(new EncyclopediaTipLinkItem(109, EEncyclopediaTipLinkMode.Default, "脚力", EEncyclopediaTipLinkType.Footwork));
		_dataArray.Add(new EncyclopediaTipLinkItem(110, EEncyclopediaTipLinkMode.Default, "距离", EEncyclopediaTipLinkType.Distance));
		_dataArray.Add(new EncyclopediaTipLinkItem(111, EEncyclopediaTipLinkMode.Default, "招式", EEncyclopediaTipLinkType.CombatMoves));
		_dataArray.Add(new EncyclopediaTipLinkItem(112, EEncyclopediaTipLinkMode.Default, "变招", EEncyclopediaTipLinkType.PinpointStrikes));
		_dataArray.Add(new EncyclopediaTipLinkItem(113, EEncyclopediaTipLinkMode.Default, "战败标记", EEncyclopediaTipLinkType.DefeatMarkers));
		_dataArray.Add(new EncyclopediaTipLinkItem(114, EEncyclopediaTipLinkMode.Default, "战斗状态", EEncyclopediaTipLinkType.BattleStatus));
		_dataArray.Add(new EncyclopediaTipLinkItem(115, EEncyclopediaTipLinkMode.Default, "破绽", EEncyclopediaTipLinkType.Openings));
		_dataArray.Add(new EncyclopediaTipLinkItem(116, EEncyclopediaTipLinkMode.Default, "封穴", EEncyclopediaTipLinkType.SealedAcupoints));
		_dataArray.Add(new EncyclopediaTipLinkItem(117, EEncyclopediaTipLinkMode.Default, "真气状态", EEncyclopediaTipLinkType.TrueQiState));
		_dataArray.Add(new EncyclopediaTipLinkItem(118, EEncyclopediaTipLinkMode.Default, "战斗行为", EEncyclopediaTipLinkType.CombatActions));
		_dataArray.Add(new EncyclopediaTipLinkItem(119, EEncyclopediaTipLinkMode.Default, "观众", EEncyclopediaTipLinkType.Audience));
	}

	private void CreateItems2()
	{
		_dataArray.Add(new EncyclopediaTipLinkItem(120, EEncyclopediaTipLinkMode.Default, "采集", EEncyclopediaTipLinkType.MapBlockCollectResource));
		_dataArray.Add(new EncyclopediaTipLinkItem(121, EEncyclopediaTipLinkMode.Default, "同道", EEncyclopediaTipLinkType.Companion));
		_dataArray.Add(new EncyclopediaTipLinkItem(122, EEncyclopediaTipLinkMode.Default, "太吾月报", EEncyclopediaTipLinkType.MonthlyReport));
		_dataArray.Add(new EncyclopediaTipLinkItem(123, EEncyclopediaTipLinkMode.Default, "人物互动", EEncyclopediaTipLinkType.Talk));
		_dataArray.Add(new EncyclopediaTipLinkItem(124, EEncyclopediaTipLinkMode.Default, "元鸡", EEncyclopediaTipLinkType.Chicken));
		_dataArray.Add(new EncyclopediaTipLinkItem(125, EEncyclopediaTipLinkMode.Default, "学艺许可", EEncyclopediaTipLinkType.SectLearPermisson));
		_dataArray.Add(new EncyclopediaTipLinkItem(126, EEncyclopediaTipLinkMode.Default, "门派恩义互动", EEncyclopediaTipLinkType.SectDebtInteraction));
		_dataArray.Add(new EncyclopediaTipLinkItem(127, EEncyclopediaTipLinkMode.Default, "交换私人藏书", EEncyclopediaTipLinkType.BookExchangePersonal));
		_dataArray.Add(new EncyclopediaTipLinkItem(128, EEncyclopediaTipLinkMode.Default, "紫竹化身", EEncyclopediaTipLinkType.JuniorXiangshu));
		_dataArray.Add(new EncyclopediaTipLinkItem(129, EEncyclopediaTipLinkMode.Default, "库房交换", EEncyclopediaTipLinkType.WarehouseExchange));
		_dataArray.Add(new EncyclopediaTipLinkItem(130, EEncyclopediaTipLinkMode.Default, "创建人物", EEncyclopediaTipLinkType.CharacterCreate));
		_dataArray.Add(new EncyclopediaTipLinkItem(131, EEncyclopediaTipLinkMode.Default, "出生地区", EEncyclopediaTipLinkType.BornArea));
		_dataArray.Add(new EncyclopediaTipLinkItem(132, EEncyclopediaTipLinkMode.Default, "内力属性", EEncyclopediaTipLinkType.NeiliProperty));
		_dataArray.Add(new EncyclopediaTipLinkItem(133, EEncyclopediaTipLinkMode.Default, "出身特质", EEncyclopediaTipLinkType.PresetTricks));
		_dataArray.Add(new EncyclopediaTipLinkItem(134, EEncyclopediaTipLinkMode.Default, "世界细节", EEncyclopediaTipLinkType.WorldDetail));
		_dataArray.Add(new EncyclopediaTipLinkItem(135, EEncyclopediaTipLinkMode.Default, "玄狱模式", EEncyclopediaTipLinkType.ChallengeMode));
		_dataArray.Add(new EncyclopediaTipLinkItem(136, EEncyclopediaTipLinkMode.Default, "门派", EEncyclopediaTipLinkType.Sect));
		_dataArray.Add(new EncyclopediaTipLinkItem(137, EEncyclopediaTipLinkMode.Default, "心韵激荡", EEncyclopediaTipLinkType.MindUpheaval));
		_dataArray.Add(new EncyclopediaTipLinkItem(138, EEncyclopediaTipLinkMode.Default, "交换优势", EEncyclopediaTipLinkType.ExchangeAdvantage));
		_dataArray.Add(new EncyclopediaTipLinkItem(139, EEncyclopediaTipLinkMode.Default, "元鸡唤灵", EEncyclopediaTipLinkType.ChickenPolymorph));
		_dataArray.Add(new EncyclopediaTipLinkItem(140, EEncyclopediaTipLinkMode.Default, "元鸡协力", EEncyclopediaTipLinkType.ChickenCombat));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<EncyclopediaTipLinkItem>(141);
		CreateItems0();
		CreateItems1();
		CreateItems2();
	}
}

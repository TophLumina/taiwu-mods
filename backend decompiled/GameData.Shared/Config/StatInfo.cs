using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class StatInfo : ConfigData<StatInfoItem, short>
{
	public static class DefKey
	{
		public const short CookingBeast1Count = 0;

		public const short TaiwuLoverCount = 1;

		public const short TaiwuHaterCount = 2;

		public const short TaiwuHateAndLoveCount = 3;

		public const short SecretCount = 4;

		public const short DebateWinCount = 5;

		public const short MaxLevelWarehouseCount = 6;

		public const short UnlockedFeastCount = 7;

		public const short SkillBreakSuccessAmount = 8;

		public const short SkillBreakGoMadAmount = 9;

		public const short VillagerAssignRole = 10;

		public const short CharacterShaveAvatarFail = 11;

		public const short TransferChickenCount = 12;

		public const short CatchCricketCount = 13;

		public const short CatchCricketTrashCount = 14;

		public const short CatchCricketKingCount = 15;

		public const short OpenChallengeMode = 16;

		public const short MerchantFoodsMaxFavor = 17;

		public const short MerchantBooksMaxFavor = 18;

		public const short MerchantMaterialsMaxFavor = 19;

		public const short MerchantEquipmentsMaxFavor = 20;

		public const short MerchantMedicinesMaxFavor = 21;

		public const short MerchantConstructionsMaxFavor = 22;

		public const short MerchantAccessoriesMaxFavor = 23;

		public const short MakeGradeHighestMetalEquipment = 24;

		public const short MakeGradeHighestWoodEquipment = 25;

		public const short MakeGradeHighestFabricEquipment = 26;

		public const short MakeGradeHighestJadeEquipment = 27;

		public const short MakeGradeHighestMedicine = 28;

		public const short MakeGradeHighestPoison = 29;

		public const short MakeGradeHighestFood = 30;

		public const short MainStoryProgress = 58;

		public const short LegacyPoint = 47;

		public const short LegacyCard = 48;

		public const short PassingLegacyToFamily = 49;

		public const short PassingLegacyToUnfamiliar = 50;

		public const short PassingLegacyToTeammate = 51;

		public const short PassingLegacyCount = 52;

		public const short PassingLegacyToOldTaiwu = 53;

		public const short SamsaraPlatformUsed = 54;

		public const short SamsaraPlatformLevel = 55;

		public const short TeaHorseCaravanLevel = 56;

		public const short StationOpened = 57;

		public const short TaiwuJourneyStarted = 59;

		public const short InscribedToSword = 60;

		public const short InscribedCharacterEvolved = 61;

		public const short ProfessionSkillUnlocked = 62;

		public const short AnyProfessionAllSkillUnlocked = 63;

		public const short SavageAllSkillUnlocked = 64;

		public const short HunterAllSkillUnlocked = 65;

		public const short CraftAllSkillUnlocked = 66;

		public const short MartialArtistAllSkillUnlocked = 67;

		public const short LiteratiAllSkillUnlocked = 68;

		public const short TaoistMonkAllSkillUnlocked = 69;

		public const short BuddhistMonkAllSkillUnlocked = 70;

		public const short WineTasterAllSkillUnlocked = 71;

		public const short AristocratAllSkillUnlocked = 72;

		public const short BeggarAllSkillUnlocked = 73;

		public const short CivilianAllSkillUnlocked = 74;

		public const short TravelerAllSkillUnlocked = 75;

		public const short TravelingBuddhistMonkAllSkillUnlocked = 76;

		public const short DoctorAllSkillUnlocked = 77;

		public const short TravelingTaoistMonkAllSkillUnlocked = 78;

		public const short CapitalistAllSkillUnlocked = 79;

		public const short TeaTasterAllSkillUnlocked = 80;

		public const short DukeAllSkillUnlocked = 81;

		public const short AllProfessionAllSkillUnlocked = 82;

		public const short NeiliAllocationAttackAchieved = 83;

		public const short NeiliAllocationAgilityAchieved = 84;

		public const short NeiliAllocationDefenseAchieved = 85;

		public const short NeiliAllocationAssistanceAchieved = 86;

		public const short NormalResourceMaxLevelAchieved = 87;

		public const short RareResourceMaxLevelAchieved = 88;

		public const short CricketCombatWon = 89;

		public const short SelectOptionMatchBehavior = 90;

		public const short SelectOptionContradictoryBehavior = 91;

		public const short ShaolinApprovingRateMax = 92;

		public const short EmeiApprovingRateMax = 93;

		public const short BaihuaApprovingRateMax = 94;

		public const short WudangApprovingRateMax = 95;

		public const short YuanshanApprovingRateMax = 96;

		public const short ShixiangApprovingRateMax = 97;

		public const short RanshanApprovingRateMax = 98;

		public const short XuannvApprovingRateMax = 99;

		public const short ZhujianApprovingRateMax = 100;

		public const short KongsangApprovingRateMax = 101;

		public const short JingangApprovingRateMax = 102;

		public const short WuxianApprovingRateMax = 103;

		public const short JieqingApprovingRateMax = 104;

		public const short FulongApprovingRateMax = 105;

		public const short XuehouApprovingRateMax = 106;

		public const short TaiwuVillagerAmount = 107;

		public const short CombatWinEscapeXiangshuAvatar = 108;

		public const short CombatWinPlay = 109;

		public const short CombatWinBeat = 110;

		public const short CombatWinTest = 111;

		public const short CombatWinDie = 112;

		public const short CombatWinEnemySixMarkType = 113;

		public const short CombatFlee = 114;

		public const short CombatSurrender = 115;

		public const short CombatKidnap = 116;

		public const short CombatUseFuyuSword = 117;

		public const short CombatWinXiangshuMinion = 118;

		public const short CombatWinHeretic = 119;

		public const short CombatWinRighteous = 120;

		public const short CombatWinAnimal = 121;

		public const short CombatAvoidAttackSkillByEscape = 122;

		public const short CombatAvoidAttackSkillByDefend = 123;

		public const short CombatChangeTrickAttack = 124;

		public const short CombatTeammateCommandSkipCd = 125;

		public const short CombatTeammateCommandNegative = 126;

		public const short CombatWinMoreConsummate = 127;

		public const short CombatCastSkillFistAndPalm = 128;

		public const short CombatCastSkillFinger = 129;

		public const short CombatCastSkillLeg = 130;

		public const short CombatCastSkillThrow = 131;

		public const short CombatCastSkillSword = 132;

		public const short CombatCastSkillBlade = 133;

		public const short CombatCastSkillPolearm = 134;

		public const short CombatCastSkillSpecial = 135;

		public const short CombatCastSkillWhip = 136;

		public const short CombatCastSkillControllableShot = 137;

		public const short CombatCastSkillCombatMusic = 138;

		public const short CombatCastSkillPowerFull = 139;

		public const short CombatCastSkillPowerZero = 140;

		public const short CombatBrokenEnemy = 141;

		public const short CombatBrokenSelf = 142;

		public const short CombatMixPoisonAffect = 143;

		public const short CombatNeiliAllocationBulge = 144;

		public const short CombatNeiliAllocationScatter = 145;

		public const short CombatMakeFatalMark = 146;

		public const short CombatSkillProficiency999 = 147;

		public const short DefeatAllXiangshuAvatar = 148;

		public const short JoinGroupStoryStrongMan = 173;

		public const short JoinGroupStoryLittleUrchin = 174;

		public const short JoinGroupStoryBigWig = 175;

		public const short JoinGroupStoryHuanyue = 176;

		public const short MakeFriends = 221;

		public const short BeMarried = 222;

		public const short SwornBrotherhood = 225;

		public const short RecognizeAdoptive = 226;

		public const short InfectionType = 229;

		public const short Fame = 230;

		public const short Happiness = 231;

		public const short Age = 232;

		public const short OneBirthChildCount = 233;

		public const short MarryLastLifeSpouse = 234;

		public const short ReincarnateAsGrandChild = 235;

		public const short AssassinateJieqingLeader = 236;

		public const short PoisonTypeCount = 237;

		public const short FinishLifeSkillBookCount = 238;

		public const short FinishLifeSkillBookTypeAny = 239;

		public const short FinishLifeSkillBookTypeMusic = 240;

		public const short FinishCombatSkillBookCount = 256;

		public const short FinishCombatSkillBookSectAny = 257;

		public const short FinishCombatSkillBookSectShaolin = 258;

		public const short OwnLegendaryBookNeigong = 273;

		public const short OwnLegendaryBookCount = 287;
	}

	public static class DefValue
	{
		public static StatInfoItem CookingBeast1Count => Instance[(short)0];

		public static StatInfoItem TaiwuLoverCount => Instance[(short)1];

		public static StatInfoItem TaiwuHaterCount => Instance[(short)2];

		public static StatInfoItem TaiwuHateAndLoveCount => Instance[(short)3];

		public static StatInfoItem SecretCount => Instance[(short)4];

		public static StatInfoItem DebateWinCount => Instance[(short)5];

		public static StatInfoItem MaxLevelWarehouseCount => Instance[(short)6];

		public static StatInfoItem UnlockedFeastCount => Instance[(short)7];

		public static StatInfoItem SkillBreakSuccessAmount => Instance[(short)8];

		public static StatInfoItem SkillBreakGoMadAmount => Instance[(short)9];

		public static StatInfoItem VillagerAssignRole => Instance[(short)10];

		public static StatInfoItem CharacterShaveAvatarFail => Instance[(short)11];

		public static StatInfoItem TransferChickenCount => Instance[(short)12];

		public static StatInfoItem CatchCricketCount => Instance[(short)13];

		public static StatInfoItem CatchCricketTrashCount => Instance[(short)14];

		public static StatInfoItem CatchCricketKingCount => Instance[(short)15];

		public static StatInfoItem OpenChallengeMode => Instance[(short)16];

		public static StatInfoItem MerchantFoodsMaxFavor => Instance[(short)17];

		public static StatInfoItem MerchantBooksMaxFavor => Instance[(short)18];

		public static StatInfoItem MerchantMaterialsMaxFavor => Instance[(short)19];

		public static StatInfoItem MerchantEquipmentsMaxFavor => Instance[(short)20];

		public static StatInfoItem MerchantMedicinesMaxFavor => Instance[(short)21];

		public static StatInfoItem MerchantConstructionsMaxFavor => Instance[(short)22];

		public static StatInfoItem MerchantAccessoriesMaxFavor => Instance[(short)23];

		public static StatInfoItem MakeGradeHighestMetalEquipment => Instance[(short)24];

		public static StatInfoItem MakeGradeHighestWoodEquipment => Instance[(short)25];

		public static StatInfoItem MakeGradeHighestFabricEquipment => Instance[(short)26];

		public static StatInfoItem MakeGradeHighestJadeEquipment => Instance[(short)27];

		public static StatInfoItem MakeGradeHighestMedicine => Instance[(short)28];

		public static StatInfoItem MakeGradeHighestPoison => Instance[(short)29];

		public static StatInfoItem MakeGradeHighestFood => Instance[(short)30];

		public static StatInfoItem MainStoryProgress => Instance[(short)58];

		public static StatInfoItem LegacyPoint => Instance[(short)47];

		public static StatInfoItem LegacyCard => Instance[(short)48];

		public static StatInfoItem PassingLegacyToFamily => Instance[(short)49];

		public static StatInfoItem PassingLegacyToUnfamiliar => Instance[(short)50];

		public static StatInfoItem PassingLegacyToTeammate => Instance[(short)51];

		public static StatInfoItem PassingLegacyCount => Instance[(short)52];

		public static StatInfoItem PassingLegacyToOldTaiwu => Instance[(short)53];

		public static StatInfoItem SamsaraPlatformUsed => Instance[(short)54];

		public static StatInfoItem SamsaraPlatformLevel => Instance[(short)55];

		public static StatInfoItem TeaHorseCaravanLevel => Instance[(short)56];

		public static StatInfoItem StationOpened => Instance[(short)57];

		public static StatInfoItem TaiwuJourneyStarted => Instance[(short)59];

		public static StatInfoItem InscribedToSword => Instance[(short)60];

		public static StatInfoItem InscribedCharacterEvolved => Instance[(short)61];

		public static StatInfoItem ProfessionSkillUnlocked => Instance[(short)62];

		public static StatInfoItem AnyProfessionAllSkillUnlocked => Instance[(short)63];

		public static StatInfoItem SavageAllSkillUnlocked => Instance[(short)64];

		public static StatInfoItem HunterAllSkillUnlocked => Instance[(short)65];

		public static StatInfoItem CraftAllSkillUnlocked => Instance[(short)66];

		public static StatInfoItem MartialArtistAllSkillUnlocked => Instance[(short)67];

		public static StatInfoItem LiteratiAllSkillUnlocked => Instance[(short)68];

		public static StatInfoItem TaoistMonkAllSkillUnlocked => Instance[(short)69];

		public static StatInfoItem BuddhistMonkAllSkillUnlocked => Instance[(short)70];

		public static StatInfoItem WineTasterAllSkillUnlocked => Instance[(short)71];

		public static StatInfoItem AristocratAllSkillUnlocked => Instance[(short)72];

		public static StatInfoItem BeggarAllSkillUnlocked => Instance[(short)73];

		public static StatInfoItem CivilianAllSkillUnlocked => Instance[(short)74];

		public static StatInfoItem TravelerAllSkillUnlocked => Instance[(short)75];

		public static StatInfoItem TravelingBuddhistMonkAllSkillUnlocked => Instance[(short)76];

		public static StatInfoItem DoctorAllSkillUnlocked => Instance[(short)77];

		public static StatInfoItem TravelingTaoistMonkAllSkillUnlocked => Instance[(short)78];

		public static StatInfoItem CapitalistAllSkillUnlocked => Instance[(short)79];

		public static StatInfoItem TeaTasterAllSkillUnlocked => Instance[(short)80];

		public static StatInfoItem DukeAllSkillUnlocked => Instance[(short)81];

		public static StatInfoItem AllProfessionAllSkillUnlocked => Instance[(short)82];

		public static StatInfoItem NeiliAllocationAttackAchieved => Instance[(short)83];

		public static StatInfoItem NeiliAllocationAgilityAchieved => Instance[(short)84];

		public static StatInfoItem NeiliAllocationDefenseAchieved => Instance[(short)85];

		public static StatInfoItem NeiliAllocationAssistanceAchieved => Instance[(short)86];

		public static StatInfoItem NormalResourceMaxLevelAchieved => Instance[(short)87];

		public static StatInfoItem RareResourceMaxLevelAchieved => Instance[(short)88];

		public static StatInfoItem CricketCombatWon => Instance[(short)89];

		public static StatInfoItem SelectOptionMatchBehavior => Instance[(short)90];

		public static StatInfoItem SelectOptionContradictoryBehavior => Instance[(short)91];

		public static StatInfoItem ShaolinApprovingRateMax => Instance[(short)92];

		public static StatInfoItem EmeiApprovingRateMax => Instance[(short)93];

		public static StatInfoItem BaihuaApprovingRateMax => Instance[(short)94];

		public static StatInfoItem WudangApprovingRateMax => Instance[(short)95];

		public static StatInfoItem YuanshanApprovingRateMax => Instance[(short)96];

		public static StatInfoItem ShixiangApprovingRateMax => Instance[(short)97];

		public static StatInfoItem RanshanApprovingRateMax => Instance[(short)98];

		public static StatInfoItem XuannvApprovingRateMax => Instance[(short)99];

		public static StatInfoItem ZhujianApprovingRateMax => Instance[(short)100];

		public static StatInfoItem KongsangApprovingRateMax => Instance[(short)101];

		public static StatInfoItem JingangApprovingRateMax => Instance[(short)102];

		public static StatInfoItem WuxianApprovingRateMax => Instance[(short)103];

		public static StatInfoItem JieqingApprovingRateMax => Instance[(short)104];

		public static StatInfoItem FulongApprovingRateMax => Instance[(short)105];

		public static StatInfoItem XuehouApprovingRateMax => Instance[(short)106];

		public static StatInfoItem TaiwuVillagerAmount => Instance[(short)107];

		public static StatInfoItem CombatWinEscapeXiangshuAvatar => Instance[(short)108];

		public static StatInfoItem CombatWinPlay => Instance[(short)109];

		public static StatInfoItem CombatWinBeat => Instance[(short)110];

		public static StatInfoItem CombatWinTest => Instance[(short)111];

		public static StatInfoItem CombatWinDie => Instance[(short)112];

		public static StatInfoItem CombatWinEnemySixMarkType => Instance[(short)113];

		public static StatInfoItem CombatFlee => Instance[(short)114];

		public static StatInfoItem CombatSurrender => Instance[(short)115];

		public static StatInfoItem CombatKidnap => Instance[(short)116];

		public static StatInfoItem CombatUseFuyuSword => Instance[(short)117];

		public static StatInfoItem CombatWinXiangshuMinion => Instance[(short)118];

		public static StatInfoItem CombatWinHeretic => Instance[(short)119];

		public static StatInfoItem CombatWinRighteous => Instance[(short)120];

		public static StatInfoItem CombatWinAnimal => Instance[(short)121];

		public static StatInfoItem CombatAvoidAttackSkillByEscape => Instance[(short)122];

		public static StatInfoItem CombatAvoidAttackSkillByDefend => Instance[(short)123];

		public static StatInfoItem CombatChangeTrickAttack => Instance[(short)124];

		public static StatInfoItem CombatTeammateCommandSkipCd => Instance[(short)125];

		public static StatInfoItem CombatTeammateCommandNegative => Instance[(short)126];

		public static StatInfoItem CombatWinMoreConsummate => Instance[(short)127];

		public static StatInfoItem CombatCastSkillFistAndPalm => Instance[(short)128];

		public static StatInfoItem CombatCastSkillFinger => Instance[(short)129];

		public static StatInfoItem CombatCastSkillLeg => Instance[(short)130];

		public static StatInfoItem CombatCastSkillThrow => Instance[(short)131];

		public static StatInfoItem CombatCastSkillSword => Instance[(short)132];

		public static StatInfoItem CombatCastSkillBlade => Instance[(short)133];

		public static StatInfoItem CombatCastSkillPolearm => Instance[(short)134];

		public static StatInfoItem CombatCastSkillSpecial => Instance[(short)135];

		public static StatInfoItem CombatCastSkillWhip => Instance[(short)136];

		public static StatInfoItem CombatCastSkillControllableShot => Instance[(short)137];

		public static StatInfoItem CombatCastSkillCombatMusic => Instance[(short)138];

		public static StatInfoItem CombatCastSkillPowerFull => Instance[(short)139];

		public static StatInfoItem CombatCastSkillPowerZero => Instance[(short)140];

		public static StatInfoItem CombatBrokenEnemy => Instance[(short)141];

		public static StatInfoItem CombatBrokenSelf => Instance[(short)142];

		public static StatInfoItem CombatMixPoisonAffect => Instance[(short)143];

		public static StatInfoItem CombatNeiliAllocationBulge => Instance[(short)144];

		public static StatInfoItem CombatNeiliAllocationScatter => Instance[(short)145];

		public static StatInfoItem CombatMakeFatalMark => Instance[(short)146];

		public static StatInfoItem CombatSkillProficiency999 => Instance[(short)147];

		public static StatInfoItem DefeatAllXiangshuAvatar => Instance[(short)148];

		public static StatInfoItem JoinGroupStoryStrongMan => Instance[(short)173];

		public static StatInfoItem JoinGroupStoryLittleUrchin => Instance[(short)174];

		public static StatInfoItem JoinGroupStoryBigWig => Instance[(short)175];

		public static StatInfoItem JoinGroupStoryHuanyue => Instance[(short)176];

		public static StatInfoItem MakeFriends => Instance[(short)221];

		public static StatInfoItem BeMarried => Instance[(short)222];

		public static StatInfoItem SwornBrotherhood => Instance[(short)225];

		public static StatInfoItem RecognizeAdoptive => Instance[(short)226];

		public static StatInfoItem InfectionType => Instance[(short)229];

		public static StatInfoItem Fame => Instance[(short)230];

		public static StatInfoItem Happiness => Instance[(short)231];

		public static StatInfoItem Age => Instance[(short)232];

		public static StatInfoItem OneBirthChildCount => Instance[(short)233];

		public static StatInfoItem MarryLastLifeSpouse => Instance[(short)234];

		public static StatInfoItem ReincarnateAsGrandChild => Instance[(short)235];

		public static StatInfoItem AssassinateJieqingLeader => Instance[(short)236];

		public static StatInfoItem PoisonTypeCount => Instance[(short)237];

		public static StatInfoItem FinishLifeSkillBookCount => Instance[(short)238];

		public static StatInfoItem FinishLifeSkillBookTypeAny => Instance[(short)239];

		public static StatInfoItem FinishLifeSkillBookTypeMusic => Instance[(short)240];

		public static StatInfoItem FinishCombatSkillBookCount => Instance[(short)256];

		public static StatInfoItem FinishCombatSkillBookSectAny => Instance[(short)257];

		public static StatInfoItem FinishCombatSkillBookSectShaolin => Instance[(short)258];

		public static StatInfoItem OwnLegendaryBookNeigong => Instance[(short)273];

		public static StatInfoItem OwnLegendaryBookCount => Instance[(short)287];
	}

	public static StatInfo Instance = new StatInfo();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "AchievementTemplateId", "TemplateId", "SteamName" };

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
		_dataArray.Add(new StatInfoItem(0, LocalStringManager.GetConfig("StatInfo_language", "Name_0"), "CookingBeast1Count", EStatInfoSaveType.None, new List<short> { 0 }, EStatInfoType.Int, EStatInfoSetType.AddValue, -1));
		_dataArray.Add(new StatInfoItem(1, LocalStringManager.GetConfig("StatInfo_language", "Name_1"), "TaiwuLoverCount", EStatInfoSaveType.None, new List<short> { 105 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(2, LocalStringManager.GetConfig("StatInfo_language", "Name_2"), "TaiwuHaterCount", EStatInfoSaveType.None, new List<short> { 106 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(3, LocalStringManager.GetConfig("StatInfo_language", "Name_3"), "TaiwuHateAndLoveCount", EStatInfoSaveType.None, new List<short> { 109 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(4, LocalStringManager.GetConfig("StatInfo_language", "Name_4"), "SecretCount", EStatInfoSaveType.Global, new List<short> { 110 }, EStatInfoType.Int, EStatInfoSetType.AddValue, -1));
		_dataArray.Add(new StatInfoItem(5, LocalStringManager.GetConfig("StatInfo_language", "Name_5"), "DebateWinCount", EStatInfoSaveType.Global, new List<short> { 193, 194 }, EStatInfoType.Int, EStatInfoSetType.AddValue, 99));
		_dataArray.Add(new StatInfoItem(6, LocalStringManager.GetConfig("StatInfo_language", "Name_6"), null, EStatInfoSaveType.None, new List<short> { 254 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(7, LocalStringManager.GetConfig("StatInfo_language", "Name_7"), "UnlockedFeastCount", EStatInfoSaveType.None, new List<short> { 256, 257 }, EStatInfoType.ListInt, EStatInfoSetType.AddType, -1));
		_dataArray.Add(new StatInfoItem(8, LocalStringManager.GetConfig("StatInfo_language", "Name_8"), "SkillBreakSuccessAmount", EStatInfoSaveType.Global, new List<short> { 232 }, EStatInfoType.Int, EStatInfoSetType.AddValue, -1));
		_dataArray.Add(new StatInfoItem(9, LocalStringManager.GetConfig("StatInfo_language", "Name_9"), "SkillBreakGoMadAmount", EStatInfoSaveType.Global, new List<short> { 233 }, EStatInfoType.Int, EStatInfoSetType.AddValue, -1));
		_dataArray.Add(new StatInfoItem(10, LocalStringManager.GetConfig("StatInfo_language", "Name_10"), "VillagerAssignRole", EStatInfoSaveType.Global, new List<short> { 253 }, EStatInfoType.Int, EStatInfoSetType.AddValue, -1));
		_dataArray.Add(new StatInfoItem(11, LocalStringManager.GetConfig("StatInfo_language", "Name_11"), "CharacterShaveAvatarFail", EStatInfoSaveType.None, new List<short> { 108 }, EStatInfoType.Int, EStatInfoSetType.AddValue, -1));
		_dataArray.Add(new StatInfoItem(12, LocalStringManager.GetConfig("StatInfo_language", "Name_12"), "TransferChickenCount", EStatInfoSaveType.Global, new List<short> { 255 }, EStatInfoType.ListInt, EStatInfoSetType.AddType, -1));
		_dataArray.Add(new StatInfoItem(13, LocalStringManager.GetConfig("StatInfo_language", "Name_13"), "CatchCricketCount", EStatInfoSaveType.Global, new List<short> { 292 }, EStatInfoType.Int, EStatInfoSetType.AddValue, -1));
		_dataArray.Add(new StatInfoItem(14, LocalStringManager.GetConfig("StatInfo_language", "Name_14"), "CatchCricketTrashCount", EStatInfoSaveType.Global, new List<short> { 293 }, EStatInfoType.Int, EStatInfoSetType.AddValue, -1));
		_dataArray.Add(new StatInfoItem(15, LocalStringManager.GetConfig("StatInfo_language", "Name_15"), "CatchCricketKingCount", EStatInfoSaveType.Global, new List<short> { 294, 295 }, EStatInfoType.ListInt, EStatInfoSetType.AddType, -1));
		_dataArray.Add(new StatInfoItem(16, LocalStringManager.GetConfig("StatInfo_language", "Name_16"), "OpenChallengeMode", EStatInfoSaveType.None, new List<short> { 76 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(17, LocalStringManager.GetConfig("StatInfo_language", "Name_17"), null, EStatInfoSaveType.None, new List<short> { 261 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(18, LocalStringManager.GetConfig("StatInfo_language", "Name_18"), null, EStatInfoSaveType.None, new List<short> { 262 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(19, LocalStringManager.GetConfig("StatInfo_language", "Name_19"), null, EStatInfoSaveType.None, new List<short> { 263 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(20, LocalStringManager.GetConfig("StatInfo_language", "Name_20"), null, EStatInfoSaveType.None, new List<short> { 264 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(21, LocalStringManager.GetConfig("StatInfo_language", "Name_21"), null, EStatInfoSaveType.None, new List<short> { 265 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(22, LocalStringManager.GetConfig("StatInfo_language", "Name_22"), null, EStatInfoSaveType.None, new List<short> { 266 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(23, LocalStringManager.GetConfig("StatInfo_language", "Name_23"), null, EStatInfoSaveType.None, new List<short> { 267 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(24, LocalStringManager.GetConfig("StatInfo_language", "Name_24"), "MakeGradeHighestMetalEquipment", EStatInfoSaveType.None, new List<short> { 268 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(25, LocalStringManager.GetConfig("StatInfo_language", "Name_25"), "MakeGradeHighestWoodEquipment", EStatInfoSaveType.None, new List<short> { 269 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(26, LocalStringManager.GetConfig("StatInfo_language", "Name_26"), "MakeGradeHighestFabricEquipment", EStatInfoSaveType.None, new List<short> { 270 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(27, LocalStringManager.GetConfig("StatInfo_language", "Name_27"), "MakeGradeHighestJadeEquipment", EStatInfoSaveType.None, new List<short> { 271 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(28, LocalStringManager.GetConfig("StatInfo_language", "Name_28"), "MakeGradeHighestMedicine", EStatInfoSaveType.None, new List<short> { 272 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(29, LocalStringManager.GetConfig("StatInfo_language", "Name_29"), "MakeGradeHighestPoison", EStatInfoSaveType.None, new List<short> { 273 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(30, LocalStringManager.GetConfig("StatInfo_language", "Name_30"), "MakeGradeHighestFood", EStatInfoSaveType.None, new List<short> { 274 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(31, LocalStringManager.GetConfig("StatInfo_language", "Name_31"), "CatchPython", EStatInfoSaveType.None, new List<short> { 29 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(32, LocalStringManager.GetConfig("StatInfo_language", "Name_32"), "ViciousBeggarsNestClear", EStatInfoSaveType.None, new List<short> { 277 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(33, LocalStringManager.GetConfig("StatInfo_language", "Name_33"), "ThievesCampClear", EStatInfoSaveType.None, new List<short> { 278 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(34, LocalStringManager.GetConfig("StatInfo_language", "Name_34"), "BanditsStrongholdClear", EStatInfoSaveType.None, new List<short> { 279 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(35, LocalStringManager.GetConfig("StatInfo_language", "Name_35"), "TraitorsGangClear", EStatInfoSaveType.None, new List<short> { 280 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(36, LocalStringManager.GetConfig("StatInfo_language", "Name_36"), "VillainsValleyClear", EStatInfoSaveType.None, new List<short> { 281 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(37, LocalStringManager.GetConfig("StatInfo_language", "Name_37"), "MixiangzhenClear", EStatInfoSaveType.None, new List<short> { 282 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(38, LocalStringManager.GetConfig("StatInfo_language", "Name_38"), "MassGraveClear", EStatInfoSaveType.None, new List<short> { 283 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(39, LocalStringManager.GetConfig("StatInfo_language", "Name_39"), "HereticHomeClear", EStatInfoSaveType.None, new List<short> { 284 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(40, LocalStringManager.GetConfig("StatInfo_language", "Name_40"), "EvilGroundClear", EStatInfoSaveType.None, new List<short> { 285 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(41, LocalStringManager.GetConfig("StatInfo_language", "Name_41"), "XiuluochangClear", EStatInfoSaveType.None, new List<short> { 286 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(42, LocalStringManager.GetConfig("StatInfo_language", "Name_42"), "FlurryofDemonsClear", EStatInfoSaveType.None, new List<short> { 287 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(43, LocalStringManager.GetConfig("StatInfo_language", "Name_43"), "DeadEndClear", EStatInfoSaveType.None, new List<short> { 288 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(44, LocalStringManager.GetConfig("StatInfo_language", "Name_44"), "HallOfTheRighteousClear", EStatInfoSaveType.None, new List<short> { 289 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(45, LocalStringManager.GetConfig("StatInfo_language", "Name_45"), "HerosLeagueClear", EStatInfoSaveType.None, new List<short> { 290 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(46, LocalStringManager.GetConfig("StatInfo_language", "Name_46"), "UnchartedTerritoryClear", EStatInfoSaveType.None, new List<short> { 291 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(47, LocalStringManager.GetConfig("StatInfo_language", "Name_47"), null, EStatInfoSaveType.None, new List<short> { 78 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(48, LocalStringManager.GetConfig("StatInfo_language", "Name_48"), null, EStatInfoSaveType.None, new List<short> { 77 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(49, LocalStringManager.GetConfig("StatInfo_language", "Name_49"), null, EStatInfoSaveType.None, new List<short> { 79 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(50, LocalStringManager.GetConfig("StatInfo_language", "Name_50"), null, EStatInfoSaveType.None, new List<short> { 80 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(51, LocalStringManager.GetConfig("StatInfo_language", "Name_51"), null, EStatInfoSaveType.None, new List<short> { 81 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(52, LocalStringManager.GetConfig("StatInfo_language", "Name_52"), "PassingLegacyCount", EStatInfoSaveType.Local, new List<short> { 82, 83 }, EStatInfoType.Int, EStatInfoSetType.AddValue, -1));
		_dataArray.Add(new StatInfoItem(53, LocalStringManager.GetConfig("StatInfo_language", "Name_53"), null, EStatInfoSaveType.None, new List<short> { 84 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(54, LocalStringManager.GetConfig("StatInfo_language", "Name_54"), "SamsaraPlatformUsed", EStatInfoSaveType.Global, new List<short> { 258 }, EStatInfoType.Int, EStatInfoSetType.AddValue, -1));
		_dataArray.Add(new StatInfoItem(55, LocalStringManager.GetConfig("StatInfo_language", "Name_55"), "SamsaraPlatformLevel", EStatInfoSaveType.None, new List<short> { 259 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(56, LocalStringManager.GetConfig("StatInfo_language", "Name_56"), "TeaHorseCaravanLevel", EStatInfoSaveType.None, new List<short> { 260 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(57, LocalStringManager.GetConfig("StatInfo_language", "Name_57"), "StationOpened", EStatInfoSaveType.None, new List<short> { 275, 276 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(58, LocalStringManager.GetConfig("StatInfo_language", "Name_58"), null, EStatInfoSaveType.None, new List<short>(), EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(59, LocalStringManager.GetConfig("StatInfo_language", "Name_59"), "TaiwuJourneyStarted", EStatInfoSaveType.None, new List<short> { 72 }, EStatInfoType.Int, EStatInfoSetType.Replace, 1));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new StatInfoItem(60, LocalStringManager.GetConfig("StatInfo_language", "Name_60"), "InscribedToSword", EStatInfoSaveType.None, new List<short> { 74 }, EStatInfoType.Int, EStatInfoSetType.Replace, 1));
		_dataArray.Add(new StatInfoItem(61, LocalStringManager.GetConfig("StatInfo_language", "Name_61"), null, EStatInfoSaveType.None, new List<short> { 75 }, EStatInfoType.Int, EStatInfoSetType.Replace, 1));
		_dataArray.Add(new StatInfoItem(62, LocalStringManager.GetConfig("StatInfo_language", "Name_62"), "ProfessionSkillUnlocked", EStatInfoSaveType.None, new List<short> { 153 }, EStatInfoType.Int, EStatInfoSetType.Replace, 1));
		_dataArray.Add(new StatInfoItem(63, LocalStringManager.GetConfig("StatInfo_language", "Name_63"), "AnyProfessionAllSkillUnlocked", EStatInfoSaveType.None, new List<short> { 154 }, EStatInfoType.Int, EStatInfoSetType.Replace, 1));
		_dataArray.Add(new StatInfoItem(64, LocalStringManager.GetConfig("StatInfo_language", "Name_64"), null, EStatInfoSaveType.None, new List<short> { 155 }, EStatInfoType.Int, EStatInfoSetType.Replace, 1));
		_dataArray.Add(new StatInfoItem(65, LocalStringManager.GetConfig("StatInfo_language", "Name_65"), null, EStatInfoSaveType.None, new List<short> { 156 }, EStatInfoType.Int, EStatInfoSetType.Replace, 1));
		_dataArray.Add(new StatInfoItem(66, LocalStringManager.GetConfig("StatInfo_language", "Name_66"), null, EStatInfoSaveType.None, new List<short> { 157 }, EStatInfoType.Int, EStatInfoSetType.Replace, 1));
		_dataArray.Add(new StatInfoItem(67, LocalStringManager.GetConfig("StatInfo_language", "Name_67"), null, EStatInfoSaveType.None, new List<short> { 158 }, EStatInfoType.Int, EStatInfoSetType.Replace, 1));
		_dataArray.Add(new StatInfoItem(68, LocalStringManager.GetConfig("StatInfo_language", "Name_68"), null, EStatInfoSaveType.None, new List<short> { 159 }, EStatInfoType.Int, EStatInfoSetType.Replace, 1));
		_dataArray.Add(new StatInfoItem(69, LocalStringManager.GetConfig("StatInfo_language", "Name_69"), null, EStatInfoSaveType.None, new List<short> { 160 }, EStatInfoType.Int, EStatInfoSetType.Replace, 1));
		_dataArray.Add(new StatInfoItem(70, LocalStringManager.GetConfig("StatInfo_language", "Name_70"), null, EStatInfoSaveType.None, new List<short> { 161 }, EStatInfoType.Int, EStatInfoSetType.Replace, 1));
		_dataArray.Add(new StatInfoItem(71, LocalStringManager.GetConfig("StatInfo_language", "Name_71"), null, EStatInfoSaveType.None, new List<short> { 162 }, EStatInfoType.Int, EStatInfoSetType.Replace, 1));
		_dataArray.Add(new StatInfoItem(72, LocalStringManager.GetConfig("StatInfo_language", "Name_72"), null, EStatInfoSaveType.None, new List<short> { 163 }, EStatInfoType.Int, EStatInfoSetType.Replace, 1));
		_dataArray.Add(new StatInfoItem(73, LocalStringManager.GetConfig("StatInfo_language", "Name_73"), null, EStatInfoSaveType.None, new List<short> { 164 }, EStatInfoType.Int, EStatInfoSetType.Replace, 1));
		_dataArray.Add(new StatInfoItem(74, LocalStringManager.GetConfig("StatInfo_language", "Name_74"), null, EStatInfoSaveType.None, new List<short> { 165 }, EStatInfoType.Int, EStatInfoSetType.Replace, 1));
		_dataArray.Add(new StatInfoItem(75, LocalStringManager.GetConfig("StatInfo_language", "Name_75"), null, EStatInfoSaveType.None, new List<short> { 166 }, EStatInfoType.Int, EStatInfoSetType.Replace, 1));
		_dataArray.Add(new StatInfoItem(76, LocalStringManager.GetConfig("StatInfo_language", "Name_76"), null, EStatInfoSaveType.None, new List<short> { 167 }, EStatInfoType.Int, EStatInfoSetType.Replace, 1));
		_dataArray.Add(new StatInfoItem(77, LocalStringManager.GetConfig("StatInfo_language", "Name_77"), null, EStatInfoSaveType.None, new List<short> { 168 }, EStatInfoType.Int, EStatInfoSetType.Replace, 1));
		_dataArray.Add(new StatInfoItem(78, LocalStringManager.GetConfig("StatInfo_language", "Name_78"), null, EStatInfoSaveType.None, new List<short> { 169 }, EStatInfoType.Int, EStatInfoSetType.Replace, 1));
		_dataArray.Add(new StatInfoItem(79, LocalStringManager.GetConfig("StatInfo_language", "Name_79"), null, EStatInfoSaveType.None, new List<short> { 170 }, EStatInfoType.Int, EStatInfoSetType.Replace, 1));
		_dataArray.Add(new StatInfoItem(80, LocalStringManager.GetConfig("StatInfo_language", "Name_80"), null, EStatInfoSaveType.None, new List<short> { 171 }, EStatInfoType.Int, EStatInfoSetType.Replace, 1));
		_dataArray.Add(new StatInfoItem(81, LocalStringManager.GetConfig("StatInfo_language", "Name_81"), null, EStatInfoSaveType.None, new List<short> { 172 }, EStatInfoType.Int, EStatInfoSetType.Replace, 1));
		_dataArray.Add(new StatInfoItem(82, LocalStringManager.GetConfig("StatInfo_language", "Name_82"), "AllProfessionAllSkillUnlocked", EStatInfoSaveType.None, new List<short> { 173 }, EStatInfoType.Int, EStatInfoSetType.Replace, 1));
		_dataArray.Add(new StatInfoItem(83, LocalStringManager.GetConfig("StatInfo_language", "Name_83"), null, EStatInfoSaveType.None, new List<short> { 228 }, EStatInfoType.Int, EStatInfoSetType.Replace, 1));
		_dataArray.Add(new StatInfoItem(84, LocalStringManager.GetConfig("StatInfo_language", "Name_84"), null, EStatInfoSaveType.None, new List<short> { 229 }, EStatInfoType.Int, EStatInfoSetType.Replace, 1));
		_dataArray.Add(new StatInfoItem(85, LocalStringManager.GetConfig("StatInfo_language", "Name_85"), null, EStatInfoSaveType.None, new List<short> { 230 }, EStatInfoType.Int, EStatInfoSetType.Replace, 1));
		_dataArray.Add(new StatInfoItem(86, LocalStringManager.GetConfig("StatInfo_language", "Name_86"), null, EStatInfoSaveType.None, new List<short> { 231 }, EStatInfoType.Int, EStatInfoSetType.Replace, 1));
		_dataArray.Add(new StatInfoItem(87, LocalStringManager.GetConfig("StatInfo_language", "Name_87"), "NormalResourceMaxLevelAchieved", EStatInfoSaveType.None, new List<short> { 250 }, EStatInfoType.Int, EStatInfoSetType.Replace, 1));
		_dataArray.Add(new StatInfoItem(88, LocalStringManager.GetConfig("StatInfo_language", "Name_88"), "RareResourceMaxLevelAchieved", EStatInfoSaveType.None, new List<short> { 251 }, EStatInfoType.Int, EStatInfoSetType.Replace, 1));
		_dataArray.Add(new StatInfoItem(89, LocalStringManager.GetConfig("StatInfo_language", "Name_89"), "CricketCombatWon", EStatInfoSaveType.None, new List<short> { 296 }, EStatInfoType.Int, EStatInfoSetType.Replace, 1));
		_dataArray.Add(new StatInfoItem(90, LocalStringManager.GetConfig("StatInfo_language", "Name_90"), "SelectOptionMatchBehavior", EStatInfoSaveType.None, new List<short> { 90 }, EStatInfoType.Int, EStatInfoSetType.AddValue, -1));
		_dataArray.Add(new StatInfoItem(91, LocalStringManager.GetConfig("StatInfo_language", "Name_91"), "SelectOptionContradictoryBehavior", EStatInfoSaveType.None, new List<short> { 91 }, EStatInfoType.Int, EStatInfoSetType.AddValue, -1));
		_dataArray.Add(new StatInfoItem(92, LocalStringManager.GetConfig("StatInfo_language", "Name_92"), null, EStatInfoSaveType.None, new List<short> { 213 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(93, LocalStringManager.GetConfig("StatInfo_language", "Name_93"), null, EStatInfoSaveType.None, new List<short> { 214 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(94, LocalStringManager.GetConfig("StatInfo_language", "Name_94"), null, EStatInfoSaveType.None, new List<short> { 215 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(95, LocalStringManager.GetConfig("StatInfo_language", "Name_95"), null, EStatInfoSaveType.None, new List<short> { 216 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(96, LocalStringManager.GetConfig("StatInfo_language", "Name_96"), null, EStatInfoSaveType.None, new List<short> { 217 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(97, LocalStringManager.GetConfig("StatInfo_language", "Name_97"), null, EStatInfoSaveType.None, new List<short> { 218 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(98, LocalStringManager.GetConfig("StatInfo_language", "Name_98"), null, EStatInfoSaveType.None, new List<short> { 219 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(99, LocalStringManager.GetConfig("StatInfo_language", "Name_99"), null, EStatInfoSaveType.None, new List<short> { 220 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(100, LocalStringManager.GetConfig("StatInfo_language", "Name_100"), null, EStatInfoSaveType.None, new List<short> { 221 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(101, LocalStringManager.GetConfig("StatInfo_language", "Name_101"), null, EStatInfoSaveType.None, new List<short> { 222 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(102, LocalStringManager.GetConfig("StatInfo_language", "Name_102"), null, EStatInfoSaveType.None, new List<short> { 223 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(103, LocalStringManager.GetConfig("StatInfo_language", "Name_103"), null, EStatInfoSaveType.None, new List<short> { 224 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(104, LocalStringManager.GetConfig("StatInfo_language", "Name_104"), null, EStatInfoSaveType.None, new List<short> { 225 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(105, LocalStringManager.GetConfig("StatInfo_language", "Name_105"), null, EStatInfoSaveType.None, new List<short> { 226 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(106, LocalStringManager.GetConfig("StatInfo_language", "Name_106"), null, EStatInfoSaveType.None, new List<short> { 227 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(107, LocalStringManager.GetConfig("StatInfo_language", "Name_107"), "TaiwuVillagerAmount", EStatInfoSaveType.None, new List<short> { 252 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(108, LocalStringManager.GetConfig("StatInfo_language", "Name_108"), null, EStatInfoSaveType.Global, new List<short> { 32 }, EStatInfoType.Int, EStatInfoSetType.AddValue, 9));
		_dataArray.Add(new StatInfoItem(109, LocalStringManager.GetConfig("StatInfo_language", "Name_109"), null, EStatInfoSaveType.Global, new List<short> { 111 }, EStatInfoType.Int, EStatInfoSetType.AddValue, 99));
		_dataArray.Add(new StatInfoItem(110, LocalStringManager.GetConfig("StatInfo_language", "Name_110"), null, EStatInfoSaveType.Global, new List<short> { 112 }, EStatInfoType.Int, EStatInfoSetType.AddValue, 99));
		_dataArray.Add(new StatInfoItem(111, LocalStringManager.GetConfig("StatInfo_language", "Name_111"), null, EStatInfoSaveType.Global, new List<short> { 113 }, EStatInfoType.Int, EStatInfoSetType.AddValue, 99));
		_dataArray.Add(new StatInfoItem(112, LocalStringManager.GetConfig("StatInfo_language", "Name_112"), null, EStatInfoSaveType.Global, new List<short> { 114 }, EStatInfoType.Int, EStatInfoSetType.AddValue, 99));
		_dataArray.Add(new StatInfoItem(113, LocalStringManager.GetConfig("StatInfo_language", "Name_113"), "CombatWinEnemySixMarkType", EStatInfoSaveType.None, new List<short> { 117 }, EStatInfoType.Int, EStatInfoSetType.AddValue, 1));
		_dataArray.Add(new StatInfoItem(114, LocalStringManager.GetConfig("StatInfo_language", "Name_114"), "CombatFlee", EStatInfoSaveType.None, new List<short> { 118 }, EStatInfoType.Int, EStatInfoSetType.AddValue, 1));
		_dataArray.Add(new StatInfoItem(115, LocalStringManager.GetConfig("StatInfo_language", "Name_115"), "CombatSurrender", EStatInfoSaveType.None, new List<short> { 119 }, EStatInfoType.Int, EStatInfoSetType.AddValue, 1));
		_dataArray.Add(new StatInfoItem(116, LocalStringManager.GetConfig("StatInfo_language", "Name_116"), "CombatKidnap", EStatInfoSaveType.None, new List<short> { 120 }, EStatInfoType.Int, EStatInfoSetType.AddValue, 1));
		_dataArray.Add(new StatInfoItem(117, LocalStringManager.GetConfig("StatInfo_language", "Name_117"), "CombatUseFuyuSword", EStatInfoSaveType.Global, new List<short> { 121, 123 }, EStatInfoType.Int, EStatInfoSetType.AddValue, 99));
		_dataArray.Add(new StatInfoItem(118, LocalStringManager.GetConfig("StatInfo_language", "Name_118"), null, EStatInfoSaveType.Global, new List<short> { 122 }, EStatInfoType.Int, EStatInfoSetType.AddValue, 99));
		_dataArray.Add(new StatInfoItem(119, LocalStringManager.GetConfig("StatInfo_language", "Name_119"), null, EStatInfoSaveType.Global, new List<short> { 124 }, EStatInfoType.Int, EStatInfoSetType.AddValue, 99));
	}

	private void CreateItems2()
	{
		_dataArray.Add(new StatInfoItem(120, LocalStringManager.GetConfig("StatInfo_language", "Name_120"), null, EStatInfoSaveType.Global, new List<short> { 125 }, EStatInfoType.Int, EStatInfoSetType.AddValue, 99));
		_dataArray.Add(new StatInfoItem(121, LocalStringManager.GetConfig("StatInfo_language", "Name_121"), null, EStatInfoSaveType.Global, new List<short> { 126 }, EStatInfoType.Int, EStatInfoSetType.AddValue, 99));
		_dataArray.Add(new StatInfoItem(122, LocalStringManager.GetConfig("StatInfo_language", "Name_122"), null, EStatInfoSaveType.Global, new List<short> { 127 }, EStatInfoType.Int, EStatInfoSetType.AddValue, 9));
		_dataArray.Add(new StatInfoItem(123, LocalStringManager.GetConfig("StatInfo_language", "Name_123"), null, EStatInfoSaveType.Global, new List<short> { 128 }, EStatInfoType.Int, EStatInfoSetType.AddValue, 9));
		_dataArray.Add(new StatInfoItem(124, LocalStringManager.GetConfig("StatInfo_language", "Name_124"), null, EStatInfoSaveType.Global, new List<short> { 129 }, EStatInfoType.Int, EStatInfoSetType.AddValue, 9));
		_dataArray.Add(new StatInfoItem(125, LocalStringManager.GetConfig("StatInfo_language", "Name_125"), null, EStatInfoSaveType.Global, new List<short> { 130 }, EStatInfoType.Int, EStatInfoSetType.AddValue, 9));
		_dataArray.Add(new StatInfoItem(126, LocalStringManager.GetConfig("StatInfo_language", "Name_126"), null, EStatInfoSaveType.Global, new List<short> { 131 }, EStatInfoType.Int, EStatInfoSetType.AddValue, 9));
		_dataArray.Add(new StatInfoItem(127, LocalStringManager.GetConfig("StatInfo_language", "Name_127"), null, EStatInfoSaveType.Global, new List<short> { 132 }, EStatInfoType.Int, EStatInfoSetType.AddValue, 9));
		_dataArray.Add(new StatInfoItem(128, LocalStringManager.GetConfig("StatInfo_language", "Name_128"), null, EStatInfoSaveType.Global, new List<short> { 133 }, EStatInfoType.Int, EStatInfoSetType.AddValue, 99));
		_dataArray.Add(new StatInfoItem(129, LocalStringManager.GetConfig("StatInfo_language", "Name_129"), null, EStatInfoSaveType.Global, new List<short> { 134 }, EStatInfoType.Int, EStatInfoSetType.AddValue, 99));
		_dataArray.Add(new StatInfoItem(130, LocalStringManager.GetConfig("StatInfo_language", "Name_130"), null, EStatInfoSaveType.Global, new List<short> { 135 }, EStatInfoType.Int, EStatInfoSetType.AddValue, 99));
		_dataArray.Add(new StatInfoItem(131, LocalStringManager.GetConfig("StatInfo_language", "Name_131"), null, EStatInfoSaveType.Global, new List<short> { 136 }, EStatInfoType.Int, EStatInfoSetType.AddValue, 99));
		_dataArray.Add(new StatInfoItem(132, LocalStringManager.GetConfig("StatInfo_language", "Name_132"), null, EStatInfoSaveType.Global, new List<short> { 137 }, EStatInfoType.Int, EStatInfoSetType.AddValue, 99));
		_dataArray.Add(new StatInfoItem(133, LocalStringManager.GetConfig("StatInfo_language", "Name_133"), null, EStatInfoSaveType.Global, new List<short> { 138 }, EStatInfoType.Int, EStatInfoSetType.AddValue, 99));
		_dataArray.Add(new StatInfoItem(134, LocalStringManager.GetConfig("StatInfo_language", "Name_134"), null, EStatInfoSaveType.Global, new List<short> { 139 }, EStatInfoType.Int, EStatInfoSetType.AddValue, 99));
		_dataArray.Add(new StatInfoItem(135, LocalStringManager.GetConfig("StatInfo_language", "Name_135"), null, EStatInfoSaveType.Global, new List<short> { 140 }, EStatInfoType.Int, EStatInfoSetType.AddValue, 99));
		_dataArray.Add(new StatInfoItem(136, LocalStringManager.GetConfig("StatInfo_language", "Name_136"), null, EStatInfoSaveType.Global, new List<short> { 141 }, EStatInfoType.Int, EStatInfoSetType.AddValue, 99));
		_dataArray.Add(new StatInfoItem(137, LocalStringManager.GetConfig("StatInfo_language", "Name_137"), null, EStatInfoSaveType.Global, new List<short> { 142 }, EStatInfoType.Int, EStatInfoSetType.AddValue, 99));
		_dataArray.Add(new StatInfoItem(138, LocalStringManager.GetConfig("StatInfo_language", "Name_138"), null, EStatInfoSaveType.Global, new List<short> { 143 }, EStatInfoType.Int, EStatInfoSetType.AddValue, 99));
		_dataArray.Add(new StatInfoItem(139, LocalStringManager.GetConfig("StatInfo_language", "Name_139"), null, EStatInfoSaveType.Global, new List<short> { 144 }, EStatInfoType.Int, EStatInfoSetType.AddValue, 9));
		_dataArray.Add(new StatInfoItem(140, LocalStringManager.GetConfig("StatInfo_language", "Name_140"), null, EStatInfoSaveType.Global, new List<short> { 145 }, EStatInfoType.Int, EStatInfoSetType.AddValue, 9));
		_dataArray.Add(new StatInfoItem(141, LocalStringManager.GetConfig("StatInfo_language", "Name_141"), "CombatBrokenEnemy", EStatInfoSaveType.None, new List<short> { 146 }, EStatInfoType.Int, EStatInfoSetType.AddValue, 1));
		_dataArray.Add(new StatInfoItem(142, LocalStringManager.GetConfig("StatInfo_language", "Name_142"), "CombatBrokenSelf", EStatInfoSaveType.None, new List<short> { 147 }, EStatInfoType.Int, EStatInfoSetType.AddValue, 1));
		_dataArray.Add(new StatInfoItem(143, LocalStringManager.GetConfig("StatInfo_language", "Name_143"), "CombatMixPoisonAffect", EStatInfoSaveType.Global, new List<short> { 148 }, EStatInfoType.Int, EStatInfoSetType.AddValue, 9));
		_dataArray.Add(new StatInfoItem(144, LocalStringManager.GetConfig("StatInfo_language", "Name_144"), "CombatNeiliAllocationBulge", EStatInfoSaveType.None, new List<short> { 150 }, EStatInfoType.Int, EStatInfoSetType.AddValue, 1));
		_dataArray.Add(new StatInfoItem(145, LocalStringManager.GetConfig("StatInfo_language", "Name_145"), "CombatNeiliAllocationScatter", EStatInfoSaveType.None, new List<short> { 151 }, EStatInfoType.Int, EStatInfoSetType.AddValue, 1));
		_dataArray.Add(new StatInfoItem(146, LocalStringManager.GetConfig("StatInfo_language", "Name_146"), null, EStatInfoSaveType.Global, new List<short> { 152 }, EStatInfoType.Int, EStatInfoSetType.AddValue, 99));
		_dataArray.Add(new StatInfoItem(147, LocalStringManager.GetConfig("StatInfo_language", "Name_147"), null, EStatInfoSaveType.None, new List<short> { 234 }, EStatInfoType.Int, EStatInfoSetType.AddValue, 1));
		_dataArray.Add(new StatInfoItem(148, LocalStringManager.GetConfig("StatInfo_language", "Name_148"), "DefeatAllXiangshuAvatar", EStatInfoSaveType.None, new List<short> { 82 }, EStatInfoType.Int, EStatInfoSetType.Replace, 1));
		_dataArray.Add(new StatInfoItem(149, LocalStringManager.GetConfig("StatInfo_language", "Name_149"), "LeaveTheValley", EStatInfoSaveType.None, new List<short> { 1 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(150, LocalStringManager.GetConfig("StatInfo_language", "Name_150"), "LeaveTheVillage", EStatInfoSaveType.None, new List<short> { 2 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(151, LocalStringManager.GetConfig("StatInfo_language", "Name_151"), "ArrivedTaiwuVillage", EStatInfoSaveType.None, new List<short> { 3 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(152, LocalStringManager.GetConfig("StatInfo_language", "Name_152"), "RebuildTaiwuAncestralHall", EStatInfoSaveType.None, new List<short> { 4 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(153, LocalStringManager.GetConfig("StatInfo_language", "Name_153"), "RebuildTaiwuPostStation", EStatInfoSaveType.None, new List<short> { 5 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(154, LocalStringManager.GetConfig("StatInfo_language", "Name_154"), "DefeatMoNvYi", EStatInfoSaveType.None, new List<short> { 6 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(155, LocalStringManager.GetConfig("StatInfo_language", "Name_155"), "DefeatFuXieTie", EStatInfoSaveType.None, new List<short> { 7 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(156, LocalStringManager.GetConfig("StatInfo_language", "Name_156"), "DefeatDaXuanNing", EStatInfoSaveType.None, new List<short> { 8 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(157, LocalStringManager.GetConfig("StatInfo_language", "Name_157"), "DefeatFengHuangJian", EStatInfoSaveType.None, new List<short> { 9 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(158, LocalStringManager.GetConfig("StatInfo_language", "Name_158"), "DefeatFenShenLian", EStatInfoSaveType.None, new List<short> { 10 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(159, LocalStringManager.GetConfig("StatInfo_language", "Name_159"), "DefeatJieLongPo", EStatInfoSaveType.None, new List<short> { 11 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(160, LocalStringManager.GetConfig("StatInfo_language", "Name_160"), "DefeatRongChenYin", EStatInfoSaveType.None, new List<short> { 12 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(161, LocalStringManager.GetConfig("StatInfo_language", "Name_161"), "DefeatQiuMoMu", EStatInfoSaveType.None, new List<short> { 13 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(162, LocalStringManager.GetConfig("StatInfo_language", "Name_162"), "DefeatGuiShenXia", EStatInfoSaveType.None, new List<short> { 14 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(163, LocalStringManager.GetConfig("StatInfo_language", "Name_163"), "TakeBackAllSword", EStatInfoSaveType.None, new List<short> { 15 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(164, LocalStringManager.GetConfig("StatInfo_language", "Name_164"), "LegendaryBookPresent", EStatInfoSaveType.None, new List<short> { 16 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(165, LocalStringManager.GetConfig("StatInfo_language", "Name_165"), "WuLinCompetition", EStatInfoSaveType.None, new List<short> { 17 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(166, LocalStringManager.GetConfig("StatInfo_language", "Name_166"), "KillSanTuDemon", EStatInfoSaveType.None, new List<short> { 18 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(167, LocalStringManager.GetConfig("StatInfo_language", "Name_167"), "FaceXiangShu", EStatInfoSaveType.None, new List<short> { 19 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(168, LocalStringManager.GetConfig("StatInfo_language", "Name_168"), "TimeTravelEnd", EStatInfoSaveType.None, new List<short> { 20 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(169, LocalStringManager.GetConfig("StatInfo_language", "Name_169"), "ShenHuoEnd", EStatInfoSaveType.None, new List<short> { 21 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(170, LocalStringManager.GetConfig("StatInfo_language", "Name_170"), "QiYuanEnd", EStatInfoSaveType.None, new List<short> { 22 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(171, LocalStringManager.GetConfig("StatInfo_language", "Name_171"), "XieMoEnd", EStatInfoSaveType.None, new List<short> { 23 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(172, LocalStringManager.GetConfig("StatInfo_language", "Name_172"), "SubdueMonkeyKing", EStatInfoSaveType.None, new List<short> { 24 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(173, LocalStringManager.GetConfig("StatInfo_language", "Name_173"), "JoinGroupStoryStrongMan", EStatInfoSaveType.None, new List<short> { 25 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(174, LocalStringManager.GetConfig("StatInfo_language", "Name_174"), "JoinGroupStoryLittleUrchin", EStatInfoSaveType.None, new List<short> { 26 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(175, LocalStringManager.GetConfig("StatInfo_language", "Name_175"), "JoinGroupStoryBigWig", EStatInfoSaveType.None, new List<short> { 27 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(176, LocalStringManager.GetConfig("StatInfo_language", "Name_176"), "JoinGroupStoryHuanyue", EStatInfoSaveType.None, new List<short> { 28 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(177, LocalStringManager.GetConfig("StatInfo_language", "Name_177"), null, EStatInfoSaveType.None, new List<short> { 29 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(178, LocalStringManager.GetConfig("StatInfo_language", "Name_178"), "SwordTombPresent", EStatInfoSaveType.None, new List<short> { 30 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(179, LocalStringManager.GetConfig("StatInfo_language", "Name_179"), "TaiwuVillageDestroyed", EStatInfoSaveType.Global, new List<short> { 31 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
	}

	private void CreateItems3()
	{
		_dataArray.Add(new StatInfoItem(180, LocalStringManager.GetConfig("StatInfo_language", "Name_180"), "MoNvStory", EStatInfoSaveType.None, new List<short> { 33 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(181, LocalStringManager.GetConfig("StatInfo_language", "Name_181"), "DaYueYaoChangStory", EStatInfoSaveType.None, new List<short> { 34 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(182, LocalStringManager.GetConfig("StatInfo_language", "Name_182"), "JiuHanStory", EStatInfoSaveType.None, new List<short> { 35 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(183, LocalStringManager.GetConfig("StatInfo_language", "Name_183"), "JinHuangErStory", EStatInfoSaveType.None, new List<short> { 36 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(184, LocalStringManager.GetConfig("StatInfo_language", "Name_184"), "YiYiHouStory", EStatInfoSaveType.None, new List<short> { 37 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(185, LocalStringManager.GetConfig("StatInfo_language", "Name_185"), "WeiQiStory", EStatInfoSaveType.None, new List<short> { 38 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(186, LocalStringManager.GetConfig("StatInfo_language", "Name_186"), "YiXiangStory", EStatInfoSaveType.None, new List<short> { 39 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(187, LocalStringManager.GetConfig("StatInfo_language", "Name_187"), "XueFengStory", EStatInfoSaveType.None, new List<short> { 40 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(188, LocalStringManager.GetConfig("StatInfo_language", "Name_188"), "ShuFangStory", EStatInfoSaveType.None, new List<short> { 41 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(189, LocalStringManager.GetConfig("StatInfo_language", "Name_189"), "ShaoLinStory", EStatInfoSaveType.None, new List<short> { 42 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(190, LocalStringManager.GetConfig("StatInfo_language", "Name_190"), "ShaoLinAfterStory", EStatInfoSaveType.None, new List<short> { 43 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(191, LocalStringManager.GetConfig("StatInfo_language", "Name_191"), "EMeiStory", EStatInfoSaveType.None, new List<short> { 44 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(192, LocalStringManager.GetConfig("StatInfo_language", "Name_192"), "EMeiAfterStory", EStatInfoSaveType.None, new List<short> { 45 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(193, LocalStringManager.GetConfig("StatInfo_language", "Name_193"), "BaiHuaStory", EStatInfoSaveType.None, new List<short> { 46 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(194, LocalStringManager.GetConfig("StatInfo_language", "Name_194"), "BaiHuaAfterStory", EStatInfoSaveType.None, new List<short> { 47 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(195, LocalStringManager.GetConfig("StatInfo_language", "Name_195"), "WuDangStory", EStatInfoSaveType.None, new List<short> { 48 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(196, LocalStringManager.GetConfig("StatInfo_language", "Name_196"), "WuDangAfterStory", EStatInfoSaveType.None, new List<short> { 49 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(197, LocalStringManager.GetConfig("StatInfo_language", "Name_197"), "YuanShanStory", EStatInfoSaveType.None, new List<short> { 50 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(198, LocalStringManager.GetConfig("StatInfo_language", "Name_198"), "YuanShanAfterStory", EStatInfoSaveType.None, new List<short> { 51 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(199, LocalStringManager.GetConfig("StatInfo_language", "Name_199"), "ShiXiangStory", EStatInfoSaveType.None, new List<short> { 52 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(200, LocalStringManager.GetConfig("StatInfo_language", "Name_200"), "ShiXiangAfterStory", EStatInfoSaveType.None, new List<short> { 53 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(201, LocalStringManager.GetConfig("StatInfo_language", "Name_201"), "RanShanStory", EStatInfoSaveType.None, new List<short> { 54 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(202, LocalStringManager.GetConfig("StatInfo_language", "Name_202"), "RanShanAfterStory", EStatInfoSaveType.None, new List<short> { 55 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(203, LocalStringManager.GetConfig("StatInfo_language", "Name_203"), "XuanNvStory", EStatInfoSaveType.None, new List<short> { 56 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(204, LocalStringManager.GetConfig("StatInfo_language", "Name_204"), "XuanNvAfterStory", EStatInfoSaveType.None, new List<short> { 57 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(205, LocalStringManager.GetConfig("StatInfo_language", "Name_205"), "ZhuJianStory", EStatInfoSaveType.None, new List<short> { 58 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(206, LocalStringManager.GetConfig("StatInfo_language", "Name_206"), "ZhuJianAfterStory", EStatInfoSaveType.None, new List<short> { 59 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(207, LocalStringManager.GetConfig("StatInfo_language", "Name_207"), "KongSangStory", EStatInfoSaveType.None, new List<short> { 60 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(208, LocalStringManager.GetConfig("StatInfo_language", "Name_208"), "KongSangAfterStory", EStatInfoSaveType.None, new List<short> { 61 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(209, LocalStringManager.GetConfig("StatInfo_language", "Name_209"), "JinGangStory", EStatInfoSaveType.None, new List<short> { 62 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(210, LocalStringManager.GetConfig("StatInfo_language", "Name_210"), "JinGangAfterStory", EStatInfoSaveType.None, new List<short> { 63 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(211, LocalStringManager.GetConfig("StatInfo_language", "Name_211"), "WuXianStory", EStatInfoSaveType.None, new List<short> { 64 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(212, LocalStringManager.GetConfig("StatInfo_language", "Name_212"), "WuXianAfterStory", EStatInfoSaveType.None, new List<short> { 65 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(213, LocalStringManager.GetConfig("StatInfo_language", "Name_213"), "JieQingStory", EStatInfoSaveType.None, new List<short> { 66 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(214, LocalStringManager.GetConfig("StatInfo_language", "Name_214"), "JieQingAfterStory", EStatInfoSaveType.None, new List<short> { 67 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(215, LocalStringManager.GetConfig("StatInfo_language", "Name_215"), "FuLongStory", EStatInfoSaveType.None, new List<short> { 68 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(216, LocalStringManager.GetConfig("StatInfo_language", "Name_216"), "FuLongAfterStory", EStatInfoSaveType.None, new List<short> { 69 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(217, LocalStringManager.GetConfig("StatInfo_language", "Name_217"), "XueHouStory", EStatInfoSaveType.None, new List<short> { 70 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(218, LocalStringManager.GetConfig("StatInfo_language", "Name_218"), "XueHouAfterStory", EStatInfoSaveType.None, new List<short> { 71 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(219, LocalStringManager.GetConfig("StatInfo_language", "Name_219"), "YanWuAllClear", EStatInfoSaveType.None, new List<short> { 73 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(220, LocalStringManager.GetConfig("StatInfo_language", "Name_220"), "FuyuProtect", EStatInfoSaveType.None, new List<short> { 85 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(221, LocalStringManager.GetConfig("StatInfo_language", "Name_221"), "MakeFriends", EStatInfoSaveType.None, new List<short> { 95 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(222, LocalStringManager.GetConfig("StatInfo_language", "Name_222"), "BeMarried", EStatInfoSaveType.None, new List<short> { 96 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(223, LocalStringManager.GetConfig("StatInfo_language", "Name_223"), "BirthCrickets", EStatInfoSaveType.None, new List<short> { 99 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(224, LocalStringManager.GetConfig("StatInfo_language", "Name_224"), "Elope", EStatInfoSaveType.None, new List<short> { 100 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(225, LocalStringManager.GetConfig("StatInfo_language", "Name_225"), "SwornBrotherhood", EStatInfoSaveType.None, new List<short> { 101 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(226, LocalStringManager.GetConfig("StatInfo_language", "Name_226"), "RecognizeAdoptive", EStatInfoSaveType.None, new List<short> { 102 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(227, LocalStringManager.GetConfig("StatInfo_language", "Name_227"), null, EStatInfoSaveType.Global, new List<short> { 115 }, EStatInfoType.Int, EStatInfoSetType.AddValue, 99));
		_dataArray.Add(new StatInfoItem(228, LocalStringManager.GetConfig("StatInfo_language", "Name_228"), null, EStatInfoSaveType.Global, new List<short> { 116 }, EStatInfoType.Int, EStatInfoSetType.AddValue, 99));
		_dataArray.Add(new StatInfoItem(229, LocalStringManager.GetConfig("StatInfo_language", "Name_229"), "InfectionType", EStatInfoSaveType.None, new List<short> { 86, 87 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(230, LocalStringManager.GetConfig("StatInfo_language", "Name_230"), null, EStatInfoSaveType.None, new List<short> { 88, 89 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(231, LocalStringManager.GetConfig("StatInfo_language", "Name_231"), null, EStatInfoSaveType.None, new List<short> { 92, 93 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(232, LocalStringManager.GetConfig("StatInfo_language", "Name_232"), "Age", EStatInfoSaveType.None, new List<short> { 94 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(233, LocalStringManager.GetConfig("StatInfo_language", "Name_233"), "OneBirthChildCount", EStatInfoSaveType.None, new List<short> { 97, 98 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(234, LocalStringManager.GetConfig("StatInfo_language", "Name_234"), "MarryLastLifeSpouse", EStatInfoSaveType.None, new List<short> { 103 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(235, LocalStringManager.GetConfig("StatInfo_language", "Name_235"), "ReincarnateAsGrandChild", EStatInfoSaveType.None, new List<short> { 104 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(236, LocalStringManager.GetConfig("StatInfo_language", "Name_236"), "AssassinateJieqingLeader", EStatInfoSaveType.None, new List<short> { 107 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(237, LocalStringManager.GetConfig("StatInfo_language", "Name_237"), "PoisonTypeCount", EStatInfoSaveType.None, new List<short> { 149 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(238, LocalStringManager.GetConfig("StatInfo_language", "Name_238"), "FinishLifeSkillBookCount", EStatInfoSaveType.Local, new List<short> { 174, 192 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(239, LocalStringManager.GetConfig("StatInfo_language", "Name_239"), "FinishLifeSkillBookTypeAny", EStatInfoSaveType.None, new List<short> { 175 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
	}

	private void CreateItems4()
	{
		_dataArray.Add(new StatInfoItem(240, LocalStringManager.GetConfig("StatInfo_language", "Name_240"), null, EStatInfoSaveType.Local, new List<short> { 176 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(241, LocalStringManager.GetConfig("StatInfo_language", "Name_241"), null, EStatInfoSaveType.Local, new List<short> { 177 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(242, LocalStringManager.GetConfig("StatInfo_language", "Name_242"), null, EStatInfoSaveType.Local, new List<short> { 178 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(243, LocalStringManager.GetConfig("StatInfo_language", "Name_243"), null, EStatInfoSaveType.Local, new List<short> { 179 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(244, LocalStringManager.GetConfig("StatInfo_language", "Name_244"), null, EStatInfoSaveType.Local, new List<short> { 180 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(245, LocalStringManager.GetConfig("StatInfo_language", "Name_245"), null, EStatInfoSaveType.Local, new List<short> { 181 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(246, LocalStringManager.GetConfig("StatInfo_language", "Name_246"), null, EStatInfoSaveType.Local, new List<short> { 182 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(247, LocalStringManager.GetConfig("StatInfo_language", "Name_247"), null, EStatInfoSaveType.Local, new List<short> { 183 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(248, LocalStringManager.GetConfig("StatInfo_language", "Name_248"), null, EStatInfoSaveType.Local, new List<short> { 184 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(249, LocalStringManager.GetConfig("StatInfo_language", "Name_249"), null, EStatInfoSaveType.Local, new List<short> { 185 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(250, LocalStringManager.GetConfig("StatInfo_language", "Name_250"), null, EStatInfoSaveType.Local, new List<short> { 186 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(251, LocalStringManager.GetConfig("StatInfo_language", "Name_251"), null, EStatInfoSaveType.Local, new List<short> { 187 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(252, LocalStringManager.GetConfig("StatInfo_language", "Name_252"), null, EStatInfoSaveType.Local, new List<short> { 188 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(253, LocalStringManager.GetConfig("StatInfo_language", "Name_253"), null, EStatInfoSaveType.Local, new List<short> { 189 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(254, LocalStringManager.GetConfig("StatInfo_language", "Name_254"), null, EStatInfoSaveType.Local, new List<short> { 190 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(255, LocalStringManager.GetConfig("StatInfo_language", "Name_255"), null, EStatInfoSaveType.Local, new List<short> { 191 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(256, LocalStringManager.GetConfig("StatInfo_language", "Name_256"), "FinishCombatSkillBookCount", EStatInfoSaveType.Local, new List<short> { 195, 212 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(257, LocalStringManager.GetConfig("StatInfo_language", "Name_257"), "FinishCombatSkillBookSectAny", EStatInfoSaveType.None, new List<short> { 196 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(258, LocalStringManager.GetConfig("StatInfo_language", "Name_258"), null, EStatInfoSaveType.Local, new List<short> { 197 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(259, LocalStringManager.GetConfig("StatInfo_language", "Name_259"), null, EStatInfoSaveType.Local, new List<short> { 198 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(260, LocalStringManager.GetConfig("StatInfo_language", "Name_260"), null, EStatInfoSaveType.Local, new List<short> { 199 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(261, LocalStringManager.GetConfig("StatInfo_language", "Name_261"), null, EStatInfoSaveType.Local, new List<short> { 200 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(262, LocalStringManager.GetConfig("StatInfo_language", "Name_262"), null, EStatInfoSaveType.Local, new List<short> { 201 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(263, LocalStringManager.GetConfig("StatInfo_language", "Name_263"), null, EStatInfoSaveType.Local, new List<short> { 202 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(264, LocalStringManager.GetConfig("StatInfo_language", "Name_264"), null, EStatInfoSaveType.Local, new List<short> { 203 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(265, LocalStringManager.GetConfig("StatInfo_language", "Name_265"), null, EStatInfoSaveType.Local, new List<short> { 204 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(266, LocalStringManager.GetConfig("StatInfo_language", "Name_266"), null, EStatInfoSaveType.Local, new List<short> { 205 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(267, LocalStringManager.GetConfig("StatInfo_language", "Name_267"), null, EStatInfoSaveType.Local, new List<short> { 206 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(268, LocalStringManager.GetConfig("StatInfo_language", "Name_268"), null, EStatInfoSaveType.Local, new List<short> { 207 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(269, LocalStringManager.GetConfig("StatInfo_language", "Name_269"), null, EStatInfoSaveType.Local, new List<short> { 208 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(270, LocalStringManager.GetConfig("StatInfo_language", "Name_270"), null, EStatInfoSaveType.Local, new List<short> { 209 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(271, LocalStringManager.GetConfig("StatInfo_language", "Name_271"), null, EStatInfoSaveType.Local, new List<short> { 210 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(272, LocalStringManager.GetConfig("StatInfo_language", "Name_272"), null, EStatInfoSaveType.Local, new List<short> { 211 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(273, LocalStringManager.GetConfig("StatInfo_language", "Name_273"), "OwnLegendaryBookNeigong", EStatInfoSaveType.None, new List<short> { 235 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(274, LocalStringManager.GetConfig("StatInfo_language", "Name_274"), "OwnLegendaryBookShenfa", EStatInfoSaveType.None, new List<short> { 236 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(275, LocalStringManager.GetConfig("StatInfo_language", "Name_275"), "OwnLegendaryBookJueji", EStatInfoSaveType.None, new List<short> { 237 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(276, LocalStringManager.GetConfig("StatInfo_language", "Name_276"), "OwnLegendaryBookQuanzhang", EStatInfoSaveType.None, new List<short> { 238 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(277, LocalStringManager.GetConfig("StatInfo_language", "Name_277"), "OwnLegendaryBookZhifa", EStatInfoSaveType.None, new List<short> { 239 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(278, LocalStringManager.GetConfig("StatInfo_language", "Name_278"), "OwnLegendaryBookTuifa", EStatInfoSaveType.None, new List<short> { 240 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(279, LocalStringManager.GetConfig("StatInfo_language", "Name_279"), "OwnLegendaryBookAnqi", EStatInfoSaveType.None, new List<short> { 241 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(280, LocalStringManager.GetConfig("StatInfo_language", "Name_280"), "OwnLegendaryBookJianfa", EStatInfoSaveType.None, new List<short> { 242 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(281, LocalStringManager.GetConfig("StatInfo_language", "Name_281"), "OwnLegendaryBookDaofa", EStatInfoSaveType.None, new List<short> { 243 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(282, LocalStringManager.GetConfig("StatInfo_language", "Name_282"), "OwnLegendaryBookChangbing", EStatInfoSaveType.None, new List<short> { 244 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(283, LocalStringManager.GetConfig("StatInfo_language", "Name_283"), "OwnLegendaryBookQimen", EStatInfoSaveType.None, new List<short> { 245 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(284, LocalStringManager.GetConfig("StatInfo_language", "Name_284"), "OwnLegendaryBookRuanbing", EStatInfoSaveType.None, new List<short> { 246 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(285, LocalStringManager.GetConfig("StatInfo_language", "Name_285"), "OwnLegendaryBookYushe", EStatInfoSaveType.None, new List<short> { 247 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(286, LocalStringManager.GetConfig("StatInfo_language", "Name_286"), "OwnLegendaryBookYueqi", EStatInfoSaveType.None, new List<short> { 248 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
		_dataArray.Add(new StatInfoItem(287, LocalStringManager.GetConfig("StatInfo_language", "Name_287"), "OwnLegendaryBookCount", EStatInfoSaveType.None, new List<short> { 249 }, EStatInfoType.Int, EStatInfoSetType.Replace, -1));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<StatInfoItem>(288);
		CreateItems0();
		CreateItems1();
		CreateItems2();
		CreateItems3();
		CreateItems4();
	}
}

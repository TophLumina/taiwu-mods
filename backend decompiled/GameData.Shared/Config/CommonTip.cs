using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class CommonTip : ConfigData<CommonTipItem, int>
{
	public static class DefKey
	{
		public const int DebugTip = 0;

		public const int AttachedPoison = 7;

		public const int BuildingArea = 8;

		public const int BuildingFeast = 9;

		public const int BuildingLevel = 10;

		public const int BuildingTeachBook = 11;

		public const int Destiny = 12;

		public const int JiaoNurturance = 13;

		public const int MatchVillagerRole = 14;

		public const int PracticeRoomActualMode = 15;

		public const int PracticeRoomPracticeMode = 16;

		public const int ProductAddProgress = 17;

		public const int SettlementTreasuryOrPrisonLayer = 18;

		public const int SpecialBuild_Qwxt_Complete = 19;

		public const int SpecialBuild_Qwxt_Unbuilt = 20;

		public const int UpdateBlock = 21;

		public const int Age = 22;

		public const int BodyPart = 23;

		public const int CharacterPoison = 24;

		public const int DisorderOfQi = 25;

		public const int EatingWug = 26;

		public const int EquipLoad = 27;

		public const int Feature = 28;

		public const int FeatureMedalLegacy = 29;

		public const int FiveElements = 30;

		public const int HateButton = 31;

		public const int LoveButton = 32;

		public const int Identity = 33;

		public const int InformationEffect = 34;

		public const int MixPoison = 35;

		public const int Organization = 36;

		public const int PrisonerResistance = 37;

		public const int SecretInformation = 38;

		public const int TeammateCount = 39;

		public const int Guard = 5;

		public const int Charm = 93;

		public const int CombatAcupressure = 40;

		public const int CombatPartialFlaw = 41;

		public const int CombatBeginFirstMove = 42;

		public const int CombatChangeTrick = 43;

		public const int CombatChangeTrickTrick = 3;

		public const int CombatChangeTrickConfirm = 4;

		public const int CombatGangqi = 44;

		public const int CombatWeaponUnlock = 45;

		public const int CostNeiliAllocation = 46;

		public const int CostWugKing = 47;

		public const int CostClearDefend = 92;

		public const int DamageValue = 48;

		public const int MindUpheaval = 94;

		public const int CricketSkillReplace = 1;

		public const int EventOption = 6;

		public const int CustomSectLaw = 2;

		public const int CaravanOperation = 49;

		public const int LegendaryBookBonus_1 = 50;

		public const int LegendaryBookBonus_2 = 51;

		public const int LifeSkillCombatBlock = 52;

		public const int LifeSkillCombatFirstMove = 53;

		public const int LifeSkillCombatLastMove = 54;

		public const int LifeSkillCombatStrategy = 55;

		public const int LifeSkillCombatUnit = 56;

		public const int ActiveLoop = 57;

		public const int ActiveRead = 58;

		public const int Advance = 59;

		public const int Adventure = 60;

		public const int FulongFlame = 61;

		public const int loongDebuff = 62;

		public const int CombatSkillBreakInfo = 63;

		public const int CombatSkillBreakout = 64;

		public const int LifeSkillDetailReadProgress = 65;

		public const int LifeSkillDetailUnlockInformation = 66;

		public const int LifeSkillDetailUnlockStrategy = 67;

		public const int LoopingEvent = 68;

		public const int ReadingEvent = 69;

		public const int ReadingBook = 70;

		public const int SkillBreakNormalCell = 71;

		public const int SkillBreakPower = 72;

		public const int SkillBreakStep = 73;

		public const int SkillBreakSwapButton = 74;

		public const int ExtraProfessionSkill = 75;

		public const int ProfessionSeniority = 76;

		public const int ProfessionSkill = 77;

		public const int ProfessionSkillEncyclopedia = 78;

		public const int DemonSlayer = 79;

		public const int GearMateNeiliAndQiProgress = 80;

		public const int GearMateReadProgress = 81;

		public const int MouseTipGearMateUpgradeAttribute = 82;

		public const int MouseTipGearMateUpgradeFeature = 83;

		public const int LifeLinkNeiliType = 84;

		public const int Music = 85;

		public const int RanshanBookKeeping = 86;

		public const int LegendaryBookGiveUp = 87;

		public const int ShixiangUpgradeTeammateCommand = 88;

		public const int ThreeVitals = 89;

		public const int XuehouJixiGrowProgress = 90;

		public const int XuehouTransferProgress = 91;

		public const int EquipmentMastery = 95;
	}

	public static class DefValue
	{
		public static CommonTipItem DebugTip => Instance[0];

		public static CommonTipItem AttachedPoison => Instance[7];

		public static CommonTipItem BuildingArea => Instance[8];

		public static CommonTipItem BuildingFeast => Instance[9];

		public static CommonTipItem BuildingLevel => Instance[10];

		public static CommonTipItem BuildingTeachBook => Instance[11];

		public static CommonTipItem Destiny => Instance[12];

		public static CommonTipItem JiaoNurturance => Instance[13];

		public static CommonTipItem MatchVillagerRole => Instance[14];

		public static CommonTipItem PracticeRoomActualMode => Instance[15];

		public static CommonTipItem PracticeRoomPracticeMode => Instance[16];

		public static CommonTipItem ProductAddProgress => Instance[17];

		public static CommonTipItem SettlementTreasuryOrPrisonLayer => Instance[18];

		public static CommonTipItem SpecialBuild_Qwxt_Complete => Instance[19];

		public static CommonTipItem SpecialBuild_Qwxt_Unbuilt => Instance[20];

		public static CommonTipItem UpdateBlock => Instance[21];

		public static CommonTipItem Age => Instance[22];

		public static CommonTipItem BodyPart => Instance[23];

		public static CommonTipItem CharacterPoison => Instance[24];

		public static CommonTipItem DisorderOfQi => Instance[25];

		public static CommonTipItem EatingWug => Instance[26];

		public static CommonTipItem EquipLoad => Instance[27];

		public static CommonTipItem Feature => Instance[28];

		public static CommonTipItem FeatureMedalLegacy => Instance[29];

		public static CommonTipItem FiveElements => Instance[30];

		public static CommonTipItem HateButton => Instance[31];

		public static CommonTipItem LoveButton => Instance[32];

		public static CommonTipItem Identity => Instance[33];

		public static CommonTipItem InformationEffect => Instance[34];

		public static CommonTipItem MixPoison => Instance[35];

		public static CommonTipItem Organization => Instance[36];

		public static CommonTipItem PrisonerResistance => Instance[37];

		public static CommonTipItem SecretInformation => Instance[38];

		public static CommonTipItem TeammateCount => Instance[39];

		public static CommonTipItem Guard => Instance[5];

		public static CommonTipItem Charm => Instance[93];

		public static CommonTipItem CombatAcupressure => Instance[40];

		public static CommonTipItem CombatPartialFlaw => Instance[41];

		public static CommonTipItem CombatBeginFirstMove => Instance[42];

		public static CommonTipItem CombatChangeTrick => Instance[43];

		public static CommonTipItem CombatChangeTrickTrick => Instance[3];

		public static CommonTipItem CombatChangeTrickConfirm => Instance[4];

		public static CommonTipItem CombatGangqi => Instance[44];

		public static CommonTipItem CombatWeaponUnlock => Instance[45];

		public static CommonTipItem CostNeiliAllocation => Instance[46];

		public static CommonTipItem CostWugKing => Instance[47];

		public static CommonTipItem CostClearDefend => Instance[92];

		public static CommonTipItem DamageValue => Instance[48];

		public static CommonTipItem MindUpheaval => Instance[94];

		public static CommonTipItem CricketSkillReplace => Instance[1];

		public static CommonTipItem EventOption => Instance[6];

		public static CommonTipItem CustomSectLaw => Instance[2];

		public static CommonTipItem CaravanOperation => Instance[49];

		public static CommonTipItem LegendaryBookBonus_1 => Instance[50];

		public static CommonTipItem LegendaryBookBonus_2 => Instance[51];

		public static CommonTipItem LifeSkillCombatBlock => Instance[52];

		public static CommonTipItem LifeSkillCombatFirstMove => Instance[53];

		public static CommonTipItem LifeSkillCombatLastMove => Instance[54];

		public static CommonTipItem LifeSkillCombatStrategy => Instance[55];

		public static CommonTipItem LifeSkillCombatUnit => Instance[56];

		public static CommonTipItem ActiveLoop => Instance[57];

		public static CommonTipItem ActiveRead => Instance[58];

		public static CommonTipItem Advance => Instance[59];

		public static CommonTipItem Adventure => Instance[60];

		public static CommonTipItem FulongFlame => Instance[61];

		public static CommonTipItem loongDebuff => Instance[62];

		public static CommonTipItem CombatSkillBreakInfo => Instance[63];

		public static CommonTipItem CombatSkillBreakout => Instance[64];

		public static CommonTipItem LifeSkillDetailReadProgress => Instance[65];

		public static CommonTipItem LifeSkillDetailUnlockInformation => Instance[66];

		public static CommonTipItem LifeSkillDetailUnlockStrategy => Instance[67];

		public static CommonTipItem LoopingEvent => Instance[68];

		public static CommonTipItem ReadingEvent => Instance[69];

		public static CommonTipItem ReadingBook => Instance[70];

		public static CommonTipItem SkillBreakNormalCell => Instance[71];

		public static CommonTipItem SkillBreakPower => Instance[72];

		public static CommonTipItem SkillBreakStep => Instance[73];

		public static CommonTipItem SkillBreakSwapButton => Instance[74];

		public static CommonTipItem ExtraProfessionSkill => Instance[75];

		public static CommonTipItem ProfessionSeniority => Instance[76];

		public static CommonTipItem ProfessionSkill => Instance[77];

		public static CommonTipItem ProfessionSkillEncyclopedia => Instance[78];

		public static CommonTipItem DemonSlayer => Instance[79];

		public static CommonTipItem GearMateNeiliAndQiProgress => Instance[80];

		public static CommonTipItem GearMateReadProgress => Instance[81];

		public static CommonTipItem MouseTipGearMateUpgradeAttribute => Instance[82];

		public static CommonTipItem MouseTipGearMateUpgradeFeature => Instance[83];

		public static CommonTipItem LifeLinkNeiliType => Instance[84];

		public static CommonTipItem Music => Instance[85];

		public static CommonTipItem RanshanBookKeeping => Instance[86];

		public static CommonTipItem LegendaryBookGiveUp => Instance[87];

		public static CommonTipItem ShixiangUpgradeTeammateCommand => Instance[88];

		public static CommonTipItem ThreeVitals => Instance[89];

		public static CommonTipItem XuehouJixiGrowProgress => Instance[90];

		public static CommonTipItem XuehouTransferProgress => Instance[91];

		public static CommonTipItem EquipmentMastery => Instance[95];
	}

	public static CommonTip Instance = new CommonTip();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "TemplateId", "Path" };

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
		_dataArray.Add(new CommonTipItem(0, "Debug/DebugTip"));
		_dataArray.Add(new CommonTipItem(1, "Cricket/CricketSkillReplace"));
		_dataArray.Add(new CommonTipItem(2, "Event/CustomSectLaw"));
		_dataArray.Add(new CommonTipItem(3, "Combat/CombatChangeTrickTrickTip"));
		_dataArray.Add(new CommonTipItem(4, "Combat/CombatChangeTrickConfirmTip"));
		_dataArray.Add(new CommonTipItem(5, "Character/Guard"));
		_dataArray.Add(new CommonTipItem(6, "Event/EventOption"));
		_dataArray.Add(new CommonTipItem(7, "Building/AttachedPoison"));
		_dataArray.Add(new CommonTipItem(8, "Building/BuildingArea"));
		_dataArray.Add(new CommonTipItem(9, "Building/BuildingFeast"));
		_dataArray.Add(new CommonTipItem(10, "Building/BuildingLevel"));
		_dataArray.Add(new CommonTipItem(11, "Building/BuildingTeachBook"));
		_dataArray.Add(new CommonTipItem(12, "Building/Destiny"));
		_dataArray.Add(new CommonTipItem(13, "Building/JiaoNurturance"));
		_dataArray.Add(new CommonTipItem(14, "Building/MatchVillagerRole"));
		_dataArray.Add(new CommonTipItem(15, "Building/PracticeRoomActualMode"));
		_dataArray.Add(new CommonTipItem(16, "Building/PracticeRoomPracticeMode"));
		_dataArray.Add(new CommonTipItem(17, "Building/ProductAddProgress"));
		_dataArray.Add(new CommonTipItem(18, "Building/SettlementTreasuryOrPrisonLayer"));
		_dataArray.Add(new CommonTipItem(19, "Building/SpecialBuild_Qwxt_Complete"));
		_dataArray.Add(new CommonTipItem(20, "Building/SpecialBuild_Qwxt_Unbuilt"));
		_dataArray.Add(new CommonTipItem(21, "Building/UpdateBlock"));
		_dataArray.Add(new CommonTipItem(22, "Character/Age"));
		_dataArray.Add(new CommonTipItem(23, "Character/BodyPart"));
		_dataArray.Add(new CommonTipItem(24, "Character/CharacterPoison"));
		_dataArray.Add(new CommonTipItem(25, "Character/DisorderOfQi"));
		_dataArray.Add(new CommonTipItem(26, "Character/EatingWug"));
		_dataArray.Add(new CommonTipItem(27, "Character/EquipLoad"));
		_dataArray.Add(new CommonTipItem(28, "Character/Feature"));
		_dataArray.Add(new CommonTipItem(29, "Character/FeatureMedalLegacy"));
		_dataArray.Add(new CommonTipItem(30, "Character/FiveElements"));
		_dataArray.Add(new CommonTipItem(31, "Character/HateButton"));
		_dataArray.Add(new CommonTipItem(32, "Character/LoveButton"));
		_dataArray.Add(new CommonTipItem(33, "Character/Identity"));
		_dataArray.Add(new CommonTipItem(34, "Character/InformationEffect"));
		_dataArray.Add(new CommonTipItem(35, "Character/MixPoison"));
		_dataArray.Add(new CommonTipItem(36, "Character/Organization"));
		_dataArray.Add(new CommonTipItem(37, "Character/PrisonerResistance"));
		_dataArray.Add(new CommonTipItem(38, "Character/SecretInformation"));
		_dataArray.Add(new CommonTipItem(39, "Character/TeammateCount"));
		_dataArray.Add(new CommonTipItem(40, "Combat/CombatAcupressure"));
		_dataArray.Add(new CommonTipItem(41, "Combat/CombatPartialFlaw"));
		_dataArray.Add(new CommonTipItem(42, "Combat/CombatBeginFirstMove"));
		_dataArray.Add(new CommonTipItem(43, "Combat/CombatChangeTrick"));
		_dataArray.Add(new CommonTipItem(44, "Combat/CombatGangqi"));
		_dataArray.Add(new CommonTipItem(45, "Combat/CombatWeaponUnlock"));
		_dataArray.Add(new CommonTipItem(46, "Combat/CostNeiliAllocation"));
		_dataArray.Add(new CommonTipItem(47, "Combat/CostWugKing"));
		_dataArray.Add(new CommonTipItem(48, "Combat/DamageValue"));
		_dataArray.Add(new CommonTipItem(49, "Event/CaravanOperation"));
		_dataArray.Add(new CommonTipItem(50, "LegendaryBook/LegendaryBookBonus_1"));
		_dataArray.Add(new CommonTipItem(51, "LegendaryBook/LegendaryBookBonus_2"));
		_dataArray.Add(new CommonTipItem(52, "LifeSkillCombat/LifeSkillCombatBlock"));
		_dataArray.Add(new CommonTipItem(53, "LifeSkillCombat/LifeSkillCombatFirstMove"));
		_dataArray.Add(new CommonTipItem(54, "LifeSkillCombat/LifeSkillCombatLastMove"));
		_dataArray.Add(new CommonTipItem(55, "LifeSkillCombat/LifeSkillCombatStrategy"));
		_dataArray.Add(new CommonTipItem(56, "LifeSkillCombat/LifeSkillCombatUnit"));
		_dataArray.Add(new CommonTipItem(57, "Map/ActiveLoop"));
		_dataArray.Add(new CommonTipItem(58, "Map/ActiveRead"));
		_dataArray.Add(new CommonTipItem(59, "Map/Advance"));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new CommonTipItem(60, "Map/Adventure"));
		_dataArray.Add(new CommonTipItem(61, "Map/FulongFlame"));
		_dataArray.Add(new CommonTipItem(62, "Map/loongDebuff"));
		_dataArray.Add(new CommonTipItem(63, "Practice/CombatSkillBreakInfo"));
		_dataArray.Add(new CommonTipItem(64, "Practice/CombatSkillBreakout"));
		_dataArray.Add(new CommonTipItem(65, "Practice/LifeSkillDetailReadProgress"));
		_dataArray.Add(new CommonTipItem(66, "Practice/LifeSkillDetailUnlockInformation"));
		_dataArray.Add(new CommonTipItem(67, "Practice/LifeSkillDetailUnlockStrategy"));
		_dataArray.Add(new CommonTipItem(68, "Practice/LoopingEvent"));
		_dataArray.Add(new CommonTipItem(69, "Practice/ReadingEvent"));
		_dataArray.Add(new CommonTipItem(70, "Practice/ReadingBook"));
		_dataArray.Add(new CommonTipItem(71, "Practice/SkillBreakNormalCell"));
		_dataArray.Add(new CommonTipItem(72, "Practice/SkillBreakPower"));
		_dataArray.Add(new CommonTipItem(73, "Practice/SkillBreakStep"));
		_dataArray.Add(new CommonTipItem(74, "Practice/SkillBreakSwapButton"));
		_dataArray.Add(new CommonTipItem(75, "Profession/ExtraProfessionSkill"));
		_dataArray.Add(new CommonTipItem(76, "Profession/ProfessionSeniority"));
		_dataArray.Add(new CommonTipItem(77, "Profession/ProfessionSkill"));
		_dataArray.Add(new CommonTipItem(78, "Profession/ProfessionSkillEncyclopedia"));
		_dataArray.Add(new CommonTipItem(79, "SectFunction/DemonSlayer"));
		_dataArray.Add(new CommonTipItem(80, "SectFunction/GearMateNeiliAndQiProgress"));
		_dataArray.Add(new CommonTipItem(81, "SectFunction/GearMateReadProgress"));
		_dataArray.Add(new CommonTipItem(82, "SectFunction/MouseTipGearMateUpgradeAttribute"));
		_dataArray.Add(new CommonTipItem(83, "SectFunction/MouseTipGearMateUpgradeFeature"));
		_dataArray.Add(new CommonTipItem(84, "SectFunction/LifeLinkNeiliType"));
		_dataArray.Add(new CommonTipItem(85, "SectFunction/Music"));
		_dataArray.Add(new CommonTipItem(86, "SectFunction/RanshanBookKeeping"));
		_dataArray.Add(new CommonTipItem(87, "SectFunction/LegendaryBookGiveUp"));
		_dataArray.Add(new CommonTipItem(88, "SectFunction/ShixiangUpgradeTeammateCommand"));
		_dataArray.Add(new CommonTipItem(89, "SectFunction/ThreeVitals"));
		_dataArray.Add(new CommonTipItem(90, "SectFunction/XuehouJixiGrowProgress"));
		_dataArray.Add(new CommonTipItem(91, "SectFunction/XuehouTransferProgress"));
		_dataArray.Add(new CommonTipItem(92, "Combat/CostClearDefend"));
		_dataArray.Add(new CommonTipItem(93, "Character/Charm"));
		_dataArray.Add(new CommonTipItem(94, "Combat/MindUpheaval"));
		_dataArray.Add(new CommonTipItem(95, "Make/EquipmentMastery"));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<CommonTipItem>(96);
		CreateItems0();
		CreateItems1();
	}
}

using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class TaiwuLifeSummaryType : ConfigData<TaiwuLifeSummaryTypeItem, int>
{
	public static class DefKey
	{
		public const int CreateRelationCount = 0;

		public const int MakeFriendCount = 1;

		public const int MakeEnemyCount = 2;

		public const int StartAdoreCount = 3;

		public const int BeAdoptedCount = 4;

		public const int SworeBrotherhoodCount = 5;

		public const int MarryCount = 6;

		public const int GetChildrenCount = 7;

		public const int CombatTotalCount = 8;

		public const int CombatWinBeat = 9;

		public const int CombatWinDie = 10;

		public const int CombatWinTest = 11;

		public const int SaveInfectedCharacter = 12;

		public const int CombatHealInjuryTotal = 13;

		public const int CombatHealPoisonTotal = 14;

		public const int CombatMakeOuterInjuryTotal = 15;

		public const int CombatMakeInnerInjuryTotal = 16;

		public const int CombatMakeFatalTotal = 17;

		public const int CombatMakeMindUpheavalTime = 18;

		public const int CombatMakeMindTotal = 19;

		public const int CombatMakeFlawTotal = 20;

		public const int CombatMakeAcupointTotal = 21;

		public const int CombatMakePoisonTotal = 22;

		public const int CombatMakeDieMarkTotal = 23;

		public const int CombatMakeWugCount = 24;

		public const int CombatAcceptOuterInjuryTotal = 25;

		public const int CombatAcceptInnerInjuryTotal = 26;

		public const int CombatAcceptFatalTotal = 27;

		public const int CombatAcceptMindUpheavalTime = 28;

		public const int CombatAcceptMindTotal = 29;

		public const int CombatAcceptFlawTotal = 30;

		public const int CombatAcceptAcupointTotal = 31;

		public const int CombatAcceptPoisonTotal = 32;

		public const int CombatAcceptDieMarkTotal = 33;

		public const int CombatUseItemCount = 34;

		public const int CombatUseSwordFragmentCount = 35;

		public const int CombatTeammateCommandUseCount = 36;

		public const int CombatSilenceEnemySkillTime = 37;

		public const int CombatBeSilenceSkillTime = 38;

		public const int DebateWin = 39;

		public const int DebateStrategyUsed = 40;

		public const int LearnLifeSkillCount = 41;

		public const int ReadLifeSkillBookPageCount = 42;

		public const int ReadIncompleteLifeSkillBookPageCount = 43;

		public const int ReadLifeSkillBookCount = 44;

		public const int UseReadingStrategyCount = 45;

		public const int LearnCombatSkillCount = 46;

		public const int ReadCombatSkillBookPageCount = 47;

		public const int ReadIncompleteCombatSkillBookPageCount = 48;

		public const int ReadCombatSkillBookCount = 49;

		public const int FillSkillBreakBonusCell = 50;

		public const int CompleteSkillBreak = 51;

		public const int ApplyNeigongLoopingEffectCount = 52;

		public const int ApplyQiArtStrategyCount = 53;

		public const int CompleteConstructionCount = 54;

		public const int UpgradeResourceBuildingCount = 55;

		public const int NewTaiwuVillagerCount = 56;

		public const int SamsaraPlatformUsedCount = 57;

		public const int TeaHorseCaravanGotItemCount = 58;

		public const int FeastCount = 59;

		public const int BuildingBlockCollectBuildingCoreItemCount = 60;

		public const int BuildingBlockCollectEarningTotal = 61;

		public const int BuildingBlockCollectMoney = 62;

		public const int BuildingBlockCollectAuthority = 63;

		public const int BuildingBlockCollectRecruit = 64;

		public const int BuildingBlockCollectItem = 65;

		public const int MakeItemCount = 66;

		public const int AssignVillagerRoleCount = 67;

		public const int SwapSoulCount = 68;

		public const int UnlockProfessionSkill0Count = 69;

		public const int UnlockProfessionSkill1Count = 70;

		public const int UnlockProfessionSkill2Count = 71;

		public const int CatchCricketCount = 72;

		public const int CatchCricketKingCount = 73;

		public const int CricketCombatWinCount = 74;

		public const int UnlockStationCount = 75;

		public const int VisitSectCount = 76;

		public const int GetSectMemberSupportCount = 77;

		public const int FinishAdventure = 78;

		public const int TransferChickenCount = 79;

		public const int GoodEndSectStory = 80;

		public const int BadEndSectStory = 81;

		public const int TaiwuWinMartialArtTournament = 82;

		public const int GainLegendaryBook = 83;

		public const int MakeWugKingAmount = 84;

		public const int DefeatMonvDate = 86;

		public const int UnlockJuniorMonvDate = 95;

		public const int FinishJuniorMonvStoryDate = 104;
	}

	public static class DefValue
	{
		public static TaiwuLifeSummaryTypeItem CreateRelationCount => Instance[0];

		public static TaiwuLifeSummaryTypeItem MakeFriendCount => Instance[1];

		public static TaiwuLifeSummaryTypeItem MakeEnemyCount => Instance[2];

		public static TaiwuLifeSummaryTypeItem StartAdoreCount => Instance[3];

		public static TaiwuLifeSummaryTypeItem BeAdoptedCount => Instance[4];

		public static TaiwuLifeSummaryTypeItem SworeBrotherhoodCount => Instance[5];

		public static TaiwuLifeSummaryTypeItem MarryCount => Instance[6];

		public static TaiwuLifeSummaryTypeItem GetChildrenCount => Instance[7];

		public static TaiwuLifeSummaryTypeItem CombatTotalCount => Instance[8];

		public static TaiwuLifeSummaryTypeItem CombatWinBeat => Instance[9];

		public static TaiwuLifeSummaryTypeItem CombatWinDie => Instance[10];

		public static TaiwuLifeSummaryTypeItem CombatWinTest => Instance[11];

		public static TaiwuLifeSummaryTypeItem SaveInfectedCharacter => Instance[12];

		public static TaiwuLifeSummaryTypeItem CombatHealInjuryTotal => Instance[13];

		public static TaiwuLifeSummaryTypeItem CombatHealPoisonTotal => Instance[14];

		public static TaiwuLifeSummaryTypeItem CombatMakeOuterInjuryTotal => Instance[15];

		public static TaiwuLifeSummaryTypeItem CombatMakeInnerInjuryTotal => Instance[16];

		public static TaiwuLifeSummaryTypeItem CombatMakeFatalTotal => Instance[17];

		public static TaiwuLifeSummaryTypeItem CombatMakeMindUpheavalTime => Instance[18];

		public static TaiwuLifeSummaryTypeItem CombatMakeMindTotal => Instance[19];

		public static TaiwuLifeSummaryTypeItem CombatMakeFlawTotal => Instance[20];

		public static TaiwuLifeSummaryTypeItem CombatMakeAcupointTotal => Instance[21];

		public static TaiwuLifeSummaryTypeItem CombatMakePoisonTotal => Instance[22];

		public static TaiwuLifeSummaryTypeItem CombatMakeDieMarkTotal => Instance[23];

		public static TaiwuLifeSummaryTypeItem CombatMakeWugCount => Instance[24];

		public static TaiwuLifeSummaryTypeItem CombatAcceptOuterInjuryTotal => Instance[25];

		public static TaiwuLifeSummaryTypeItem CombatAcceptInnerInjuryTotal => Instance[26];

		public static TaiwuLifeSummaryTypeItem CombatAcceptFatalTotal => Instance[27];

		public static TaiwuLifeSummaryTypeItem CombatAcceptMindUpheavalTime => Instance[28];

		public static TaiwuLifeSummaryTypeItem CombatAcceptMindTotal => Instance[29];

		public static TaiwuLifeSummaryTypeItem CombatAcceptFlawTotal => Instance[30];

		public static TaiwuLifeSummaryTypeItem CombatAcceptAcupointTotal => Instance[31];

		public static TaiwuLifeSummaryTypeItem CombatAcceptPoisonTotal => Instance[32];

		public static TaiwuLifeSummaryTypeItem CombatAcceptDieMarkTotal => Instance[33];

		public static TaiwuLifeSummaryTypeItem CombatUseItemCount => Instance[34];

		public static TaiwuLifeSummaryTypeItem CombatUseSwordFragmentCount => Instance[35];

		public static TaiwuLifeSummaryTypeItem CombatTeammateCommandUseCount => Instance[36];

		public static TaiwuLifeSummaryTypeItem CombatSilenceEnemySkillTime => Instance[37];

		public static TaiwuLifeSummaryTypeItem CombatBeSilenceSkillTime => Instance[38];

		public static TaiwuLifeSummaryTypeItem DebateWin => Instance[39];

		public static TaiwuLifeSummaryTypeItem DebateStrategyUsed => Instance[40];

		public static TaiwuLifeSummaryTypeItem LearnLifeSkillCount => Instance[41];

		public static TaiwuLifeSummaryTypeItem ReadLifeSkillBookPageCount => Instance[42];

		public static TaiwuLifeSummaryTypeItem ReadIncompleteLifeSkillBookPageCount => Instance[43];

		public static TaiwuLifeSummaryTypeItem ReadLifeSkillBookCount => Instance[44];

		public static TaiwuLifeSummaryTypeItem UseReadingStrategyCount => Instance[45];

		public static TaiwuLifeSummaryTypeItem LearnCombatSkillCount => Instance[46];

		public static TaiwuLifeSummaryTypeItem ReadCombatSkillBookPageCount => Instance[47];

		public static TaiwuLifeSummaryTypeItem ReadIncompleteCombatSkillBookPageCount => Instance[48];

		public static TaiwuLifeSummaryTypeItem ReadCombatSkillBookCount => Instance[49];

		public static TaiwuLifeSummaryTypeItem FillSkillBreakBonusCell => Instance[50];

		public static TaiwuLifeSummaryTypeItem CompleteSkillBreak => Instance[51];

		public static TaiwuLifeSummaryTypeItem ApplyNeigongLoopingEffectCount => Instance[52];

		public static TaiwuLifeSummaryTypeItem ApplyQiArtStrategyCount => Instance[53];

		public static TaiwuLifeSummaryTypeItem CompleteConstructionCount => Instance[54];

		public static TaiwuLifeSummaryTypeItem UpgradeResourceBuildingCount => Instance[55];

		public static TaiwuLifeSummaryTypeItem NewTaiwuVillagerCount => Instance[56];

		public static TaiwuLifeSummaryTypeItem SamsaraPlatformUsedCount => Instance[57];

		public static TaiwuLifeSummaryTypeItem TeaHorseCaravanGotItemCount => Instance[58];

		public static TaiwuLifeSummaryTypeItem FeastCount => Instance[59];

		public static TaiwuLifeSummaryTypeItem BuildingBlockCollectBuildingCoreItemCount => Instance[60];

		public static TaiwuLifeSummaryTypeItem BuildingBlockCollectEarningTotal => Instance[61];

		public static TaiwuLifeSummaryTypeItem BuildingBlockCollectMoney => Instance[62];

		public static TaiwuLifeSummaryTypeItem BuildingBlockCollectAuthority => Instance[63];

		public static TaiwuLifeSummaryTypeItem BuildingBlockCollectRecruit => Instance[64];

		public static TaiwuLifeSummaryTypeItem BuildingBlockCollectItem => Instance[65];

		public static TaiwuLifeSummaryTypeItem MakeItemCount => Instance[66];

		public static TaiwuLifeSummaryTypeItem AssignVillagerRoleCount => Instance[67];

		public static TaiwuLifeSummaryTypeItem SwapSoulCount => Instance[68];

		public static TaiwuLifeSummaryTypeItem UnlockProfessionSkill0Count => Instance[69];

		public static TaiwuLifeSummaryTypeItem UnlockProfessionSkill1Count => Instance[70];

		public static TaiwuLifeSummaryTypeItem UnlockProfessionSkill2Count => Instance[71];

		public static TaiwuLifeSummaryTypeItem CatchCricketCount => Instance[72];

		public static TaiwuLifeSummaryTypeItem CatchCricketKingCount => Instance[73];

		public static TaiwuLifeSummaryTypeItem CricketCombatWinCount => Instance[74];

		public static TaiwuLifeSummaryTypeItem UnlockStationCount => Instance[75];

		public static TaiwuLifeSummaryTypeItem VisitSectCount => Instance[76];

		public static TaiwuLifeSummaryTypeItem GetSectMemberSupportCount => Instance[77];

		public static TaiwuLifeSummaryTypeItem FinishAdventure => Instance[78];

		public static TaiwuLifeSummaryTypeItem TransferChickenCount => Instance[79];

		public static TaiwuLifeSummaryTypeItem GoodEndSectStory => Instance[80];

		public static TaiwuLifeSummaryTypeItem BadEndSectStory => Instance[81];

		public static TaiwuLifeSummaryTypeItem TaiwuWinMartialArtTournament => Instance[82];

		public static TaiwuLifeSummaryTypeItem GainLegendaryBook => Instance[83];

		public static TaiwuLifeSummaryTypeItem MakeWugKingAmount => Instance[84];

		public static TaiwuLifeSummaryTypeItem DefeatMonvDate => Instance[86];

		public static TaiwuLifeSummaryTypeItem UnlockJuniorMonvDate => Instance[95];

		public static TaiwuLifeSummaryTypeItem FinishJuniorMonvStoryDate => Instance[104];
	}

	public static TaiwuLifeSummaryType Instance = new TaiwuLifeSummaryType();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "Type", "TemplateId" };

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
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(0, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_0"), 0, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(1, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_1"), 0, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(2, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_2"), 0, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(3, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_3"), 0, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(4, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_4"), 0, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(5, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_5"), 0, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(6, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_6"), 0, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(7, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_7"), 0, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(8, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_8"), 1, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(9, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_9"), 1, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(10, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_10"), 1, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(11, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_11"), 1, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(12, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_12"), 1, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(13, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_13"), 1, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(14, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_14"), 1, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(15, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_15"), 1, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(16, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_16"), 1, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(17, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_17"), 1, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(18, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_18"), 1, displayInScrollOfTaiwu: false, isDate: false, isTime: true));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(19, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_19"), 1, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(20, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_20"), 1, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(21, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_21"), 1, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(22, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_22"), 1, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(23, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_23"), 1, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(24, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_24"), 1, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(25, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_25"), 1, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(26, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_26"), 1, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(27, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_27"), 1, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(28, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_28"), 1, displayInScrollOfTaiwu: false, isDate: false, isTime: true));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(29, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_29"), 1, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(30, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_30"), 1, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(31, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_31"), 1, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(32, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_32"), 1, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(33, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_33"), 1, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(34, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_34"), 1, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(35, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_35"), 1, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(36, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_36"), 1, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(37, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_37"), 1, displayInScrollOfTaiwu: false, isDate: false, isTime: true));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(38, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_38"), 1, displayInScrollOfTaiwu: false, isDate: false, isTime: true));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(39, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_39"), 2, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(40, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_40"), 2, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(41, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_41"), 2, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(42, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_42"), 2, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(43, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_43"), 2, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(44, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_44"), 2, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(45, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_45"), 2, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(46, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_46"), 3, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(47, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_47"), 3, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(48, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_48"), 3, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(49, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_49"), 3, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(50, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_50"), 3, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(51, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_51"), 3, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(52, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_52"), 3, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(53, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_53"), 3, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(54, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_54"), 4, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(55, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_55"), 4, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(56, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_56"), 4, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(57, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_57"), 4, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(58, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_58"), 4, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(59, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_59"), 4, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(60, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_60"), 4, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(61, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_61"), 4, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(62, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_62"), 4, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(63, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_63"), 4, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(64, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_64"), 4, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(65, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_65"), 4, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(66, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_66"), 4, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(67, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_67"), 4, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(68, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_68"), 4, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(69, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_69"), 7, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(70, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_70"), 7, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(71, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_71"), 7, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(72, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_72"), 5, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(73, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_73"), 5, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(74, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_74"), 5, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(75, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_75"), 5, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(76, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_76"), 5, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(77, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_77"), 5, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(78, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_78"), 5, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(79, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_79"), 5, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(80, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_80"), 5, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(81, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_81"), 5, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(82, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_82"), 5, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(83, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_83"), 5, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(84, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_84"), 5, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(85, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_85"), 6, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(86, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_86"), 6, displayInScrollOfTaiwu: true, isDate: true, isTime: true));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(87, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_87"), 6, displayInScrollOfTaiwu: true, isDate: true, isTime: true));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(88, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_88"), 6, displayInScrollOfTaiwu: true, isDate: true, isTime: true));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(89, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_89"), 6, displayInScrollOfTaiwu: true, isDate: true, isTime: true));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(90, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_90"), 6, displayInScrollOfTaiwu: true, isDate: true, isTime: true));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(91, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_91"), 6, displayInScrollOfTaiwu: true, isDate: true, isTime: true));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(92, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_92"), 6, displayInScrollOfTaiwu: true, isDate: true, isTime: true));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(93, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_93"), 6, displayInScrollOfTaiwu: true, isDate: true, isTime: true));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(94, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_94"), 6, displayInScrollOfTaiwu: true, isDate: true, isTime: true));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(95, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_95"), 6, displayInScrollOfTaiwu: false, isDate: true, isTime: true));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(96, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_96"), 6, displayInScrollOfTaiwu: false, isDate: true, isTime: true));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(97, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_97"), 6, displayInScrollOfTaiwu: false, isDate: true, isTime: true));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(98, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_98"), 6, displayInScrollOfTaiwu: false, isDate: true, isTime: true));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(99, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_99"), 6, displayInScrollOfTaiwu: false, isDate: true, isTime: true));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(100, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_100"), 6, displayInScrollOfTaiwu: false, isDate: true, isTime: true));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(101, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_101"), 6, displayInScrollOfTaiwu: false, isDate: true, isTime: true));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(102, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_102"), 6, displayInScrollOfTaiwu: false, isDate: true, isTime: true));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(103, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_103"), 6, displayInScrollOfTaiwu: false, isDate: true, isTime: true));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(104, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_104"), 6, displayInScrollOfTaiwu: false, isDate: true, isTime: true));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(105, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_105"), 6, displayInScrollOfTaiwu: false, isDate: true, isTime: true));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(106, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_106"), 6, displayInScrollOfTaiwu: false, isDate: true, isTime: true));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(107, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_107"), 6, displayInScrollOfTaiwu: false, isDate: true, isTime: true));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(108, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_108"), 6, displayInScrollOfTaiwu: false, isDate: true, isTime: true));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(109, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_109"), 6, displayInScrollOfTaiwu: false, isDate: true, isTime: true));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(110, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_110"), 6, displayInScrollOfTaiwu: false, isDate: true, isTime: true));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(111, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_111"), 6, displayInScrollOfTaiwu: false, isDate: true, isTime: true));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(112, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_112"), 6, displayInScrollOfTaiwu: false, isDate: true, isTime: true));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<TaiwuLifeSummaryTypeItem>(113);
		CreateItems0();
		CreateItems1();
	}
}

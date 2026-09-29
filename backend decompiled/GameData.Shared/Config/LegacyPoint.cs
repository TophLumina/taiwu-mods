using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class LegacyPoint : ConfigData<LegacyPointItem, short>
{
	public static class DefKey
	{
		public const short MeetNewPeople = 0;

		public const short MakeFriends = 1;

		public const short BecomeLovers = 2;

		public const short MarryLovedOne = 3;

		public const short HaveChildren = 4;

		public const short SwornBrothersAndSisters = 5;

		public const short AdoptChildren = 6;

		public const short GetAdopted = 7;

		public const short ChallengeMode = 51;

		public const short DreamBackOneTimeBonus = 52;

		public const short CombatToPlay = 8;

		public const short CombatToTest = 9;

		public const short CombatToBeat = 10;

		public const short CombatToKill = 11;

		public const short SaveTheInfected = 12;

		public const short DestroyEnemyNest = 13;

		public const short LearnLifeSkill = 14;

		public const short ReadLifeSkillNormalPage = 15;

		public const short ReadLifeSkillIncompletePage = 16;

		public const short FinishLifeSkillBook = 17;

		public const short LifeSkillBattleWin = 18;

		public const short TeachLifeSkillInShrine = 19;

		public const short ReadingStrategyUesd = 47;

		public const short LearnCombatSkill = 20;

		public const short ReadCombatSkillNormalPage = 21;

		public const short ReadCombatSkillIncompletePage = 22;

		public const short ProficiencyEnough = 23;

		public const short BreakoutCombatSkill = 24;

		public const short TeachCombatSkillInShrine = 25;

		public const short QiArtStrategy = 48;

		public const short SkillBreakMystery = 49;

		public const short ConstructVillage = 26;

		public const short ExpandVillage = 27;

		public const short GainResources = 28;

		public const short ManagementGain = 29;

		public const short CraftValuableItem = 30;

		public const short HireGoodWorker = 31;

		public const short AppointVillagers = 50;

		public const short CatchCricket = 32;

		public const short CricketBattle = 33;

		public const short GainInformation = 34;

		public const short UseInformation = 35;

		public const short DeliverSaluteToSect = 36;

		public const short UnlockStation = 37;

		public const short GetSupportFromSectMembers = 38;

		public const short CompleteAdventure = 39;

		public const short PrimaryProfession = 42;

		public const short MiddleProfession = 43;

		public const short AdvancedProfession = 44;

		public const short MasterProfession = 45;

		public const short GainExtraLegacyPoint = 46;
	}

	public static class DefValue
	{
		public static LegacyPointItem MeetNewPeople => Instance[(short)0];

		public static LegacyPointItem MakeFriends => Instance[(short)1];

		public static LegacyPointItem BecomeLovers => Instance[(short)2];

		public static LegacyPointItem MarryLovedOne => Instance[(short)3];

		public static LegacyPointItem HaveChildren => Instance[(short)4];

		public static LegacyPointItem SwornBrothersAndSisters => Instance[(short)5];

		public static LegacyPointItem AdoptChildren => Instance[(short)6];

		public static LegacyPointItem GetAdopted => Instance[(short)7];

		public static LegacyPointItem ChallengeMode => Instance[(short)51];

		public static LegacyPointItem DreamBackOneTimeBonus => Instance[(short)52];

		public static LegacyPointItem CombatToPlay => Instance[(short)8];

		public static LegacyPointItem CombatToTest => Instance[(short)9];

		public static LegacyPointItem CombatToBeat => Instance[(short)10];

		public static LegacyPointItem CombatToKill => Instance[(short)11];

		public static LegacyPointItem SaveTheInfected => Instance[(short)12];

		public static LegacyPointItem DestroyEnemyNest => Instance[(short)13];

		public static LegacyPointItem LearnLifeSkill => Instance[(short)14];

		public static LegacyPointItem ReadLifeSkillNormalPage => Instance[(short)15];

		public static LegacyPointItem ReadLifeSkillIncompletePage => Instance[(short)16];

		public static LegacyPointItem FinishLifeSkillBook => Instance[(short)17];

		public static LegacyPointItem LifeSkillBattleWin => Instance[(short)18];

		public static LegacyPointItem TeachLifeSkillInShrine => Instance[(short)19];

		public static LegacyPointItem ReadingStrategyUesd => Instance[(short)47];

		public static LegacyPointItem LearnCombatSkill => Instance[(short)20];

		public static LegacyPointItem ReadCombatSkillNormalPage => Instance[(short)21];

		public static LegacyPointItem ReadCombatSkillIncompletePage => Instance[(short)22];

		public static LegacyPointItem ProficiencyEnough => Instance[(short)23];

		public static LegacyPointItem BreakoutCombatSkill => Instance[(short)24];

		public static LegacyPointItem TeachCombatSkillInShrine => Instance[(short)25];

		public static LegacyPointItem QiArtStrategy => Instance[(short)48];

		public static LegacyPointItem SkillBreakMystery => Instance[(short)49];

		public static LegacyPointItem ConstructVillage => Instance[(short)26];

		public static LegacyPointItem ExpandVillage => Instance[(short)27];

		public static LegacyPointItem GainResources => Instance[(short)28];

		public static LegacyPointItem ManagementGain => Instance[(short)29];

		public static LegacyPointItem CraftValuableItem => Instance[(short)30];

		public static LegacyPointItem HireGoodWorker => Instance[(short)31];

		public static LegacyPointItem AppointVillagers => Instance[(short)50];

		public static LegacyPointItem CatchCricket => Instance[(short)32];

		public static LegacyPointItem CricketBattle => Instance[(short)33];

		public static LegacyPointItem GainInformation => Instance[(short)34];

		public static LegacyPointItem UseInformation => Instance[(short)35];

		public static LegacyPointItem DeliverSaluteToSect => Instance[(short)36];

		public static LegacyPointItem UnlockStation => Instance[(short)37];

		public static LegacyPointItem GetSupportFromSectMembers => Instance[(short)38];

		public static LegacyPointItem CompleteAdventure => Instance[(short)39];

		public static LegacyPointItem PrimaryProfession => Instance[(short)42];

		public static LegacyPointItem MiddleProfession => Instance[(short)43];

		public static LegacyPointItem AdvancedProfession => Instance[(short)44];

		public static LegacyPointItem MasterProfession => Instance[(short)45];

		public static LegacyPointItem GainExtraLegacyPoint => Instance[(short)46];
	}

	public static LegacyPoint Instance = new LegacyPoint();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "Type", "BonusTypes", "ConditionDesc", "TemplateId" };

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
		_dataArray.Add(new LegacyPointItem(0, LocalStringManager.GetConfig("LegacyPoint_language", "Name_0"), 0, 5, 500, isHidden: false, new byte[5] { 12, 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_0")));
		_dataArray.Add(new LegacyPointItem(1, LocalStringManager.GetConfig("LegacyPoint_language", "Name_1"), 0, 10, 500, isHidden: false, new byte[5] { 12, 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_1")));
		_dataArray.Add(new LegacyPointItem(2, LocalStringManager.GetConfig("LegacyPoint_language", "Name_2"), 0, 250, 500, isHidden: false, new byte[5] { 12, 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_2")));
		_dataArray.Add(new LegacyPointItem(3, LocalStringManager.GetConfig("LegacyPoint_language", "Name_3"), 0, 500, 500, isHidden: false, new byte[5] { 12, 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_3")));
		_dataArray.Add(new LegacyPointItem(4, LocalStringManager.GetConfig("LegacyPoint_language", "Name_4"), 0, 250, 500, isHidden: false, new byte[5] { 12, 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_4")));
		_dataArray.Add(new LegacyPointItem(5, LocalStringManager.GetConfig("LegacyPoint_language", "Name_5"), 0, 100, 500, isHidden: false, new byte[5] { 12, 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_5")));
		_dataArray.Add(new LegacyPointItem(6, LocalStringManager.GetConfig("LegacyPoint_language", "Name_6"), 0, 250, 500, isHidden: false, new byte[5] { 12, 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_6")));
		_dataArray.Add(new LegacyPointItem(7, LocalStringManager.GetConfig("LegacyPoint_language", "Name_7"), 0, 250, 500, isHidden: false, new byte[5] { 12, 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_7")));
		_dataArray.Add(new LegacyPointItem(8, LocalStringManager.GetConfig("LegacyPoint_language", "Name_8"), 1, 5, 500, isHidden: false, new byte[9] { 1, 11, 2, 3, 4, 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_8")));
		_dataArray.Add(new LegacyPointItem(9, LocalStringManager.GetConfig("LegacyPoint_language", "Name_9"), 1, 10, 500, isHidden: false, new byte[9] { 1, 11, 2, 3, 4, 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_9")));
		_dataArray.Add(new LegacyPointItem(10, LocalStringManager.GetConfig("LegacyPoint_language", "Name_10"), 1, 10, 500, isHidden: false, new byte[9] { 1, 11, 2, 3, 4, 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_10")));
		_dataArray.Add(new LegacyPointItem(11, LocalStringManager.GetConfig("LegacyPoint_language", "Name_11"), 1, 20, 500, isHidden: false, new byte[9] { 1, 11, 2, 3, 4, 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_11")));
		_dataArray.Add(new LegacyPointItem(12, LocalStringManager.GetConfig("LegacyPoint_language", "Name_12"), 1, 20, 1000, isHidden: false, new byte[9] { 1, 11, 2, 3, 4, 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_12")));
		_dataArray.Add(new LegacyPointItem(13, LocalStringManager.GetConfig("LegacyPoint_language", "Name_13"), 1, 50, 1000, isHidden: false, new byte[9] { 1, 11, 2, 3, 4, 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_13")));
		_dataArray.Add(new LegacyPointItem(14, LocalStringManager.GetConfig("LegacyPoint_language", "Name_14"), 2, 20, 500, isHidden: false, new byte[5] { 2, 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_14")));
		_dataArray.Add(new LegacyPointItem(15, LocalStringManager.GetConfig("LegacyPoint_language", "Name_15"), 2, 10, 500, isHidden: false, new byte[5] { 2, 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_15")));
		_dataArray.Add(new LegacyPointItem(16, LocalStringManager.GetConfig("LegacyPoint_language", "Name_16"), 2, 20, 500, isHidden: false, new byte[5] { 2, 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_16")));
		_dataArray.Add(new LegacyPointItem(17, LocalStringManager.GetConfig("LegacyPoint_language", "Name_17"), 2, 20, 500, isHidden: false, new byte[5] { 2, 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_17")));
		_dataArray.Add(new LegacyPointItem(18, LocalStringManager.GetConfig("LegacyPoint_language", "Name_18"), 2, 10, 500, isHidden: false, new byte[5] { 2, 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_18")));
		_dataArray.Add(new LegacyPointItem(19, LocalStringManager.GetConfig("LegacyPoint_language", "Name_19"), 2, 5, 500, isHidden: false, new byte[5] { 2, 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_19")));
		_dataArray.Add(new LegacyPointItem(20, LocalStringManager.GetConfig("LegacyPoint_language", "Name_20"), 3, 20, 500, isHidden: false, new byte[5] { 2, 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_20")));
		_dataArray.Add(new LegacyPointItem(21, LocalStringManager.GetConfig("LegacyPoint_language", "Name_21"), 3, 10, 500, isHidden: false, new byte[5] { 2, 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_21")));
		_dataArray.Add(new LegacyPointItem(22, LocalStringManager.GetConfig("LegacyPoint_language", "Name_22"), 3, 20, 500, isHidden: false, new byte[5] { 2, 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_22")));
		_dataArray.Add(new LegacyPointItem(23, LocalStringManager.GetConfig("LegacyPoint_language", "Name_23"), 3, 20, 500, isHidden: false, new byte[5] { 2, 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_23")));
		_dataArray.Add(new LegacyPointItem(24, LocalStringManager.GetConfig("LegacyPoint_language", "Name_24"), 3, 20, 500, isHidden: false, new byte[6] { 2, 3, 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_24")));
		_dataArray.Add(new LegacyPointItem(25, LocalStringManager.GetConfig("LegacyPoint_language", "Name_25"), 3, 5, 500, isHidden: false, new byte[6] { 2, 3, 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_25")));
		_dataArray.Add(new LegacyPointItem(26, LocalStringManager.GetConfig("LegacyPoint_language", "Name_26"), 4, 100, 1000, isHidden: false, new byte[4] { 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_26")));
		_dataArray.Add(new LegacyPointItem(27, LocalStringManager.GetConfig("LegacyPoint_language", "Name_27"), 4, 20, 1000, isHidden: false, new byte[4] { 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_27")));
		_dataArray.Add(new LegacyPointItem(28, LocalStringManager.GetConfig("LegacyPoint_language", "Name_28"), 4, 5, 500, isHidden: false, new byte[4] { 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_28")));
		_dataArray.Add(new LegacyPointItem(29, LocalStringManager.GetConfig("LegacyPoint_language", "Name_29"), 4, 5, 500, isHidden: false, new byte[4] { 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_29")));
		_dataArray.Add(new LegacyPointItem(30, LocalStringManager.GetConfig("LegacyPoint_language", "Name_30"), 4, 10, 500, isHidden: false, new byte[4] { 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_30")));
		_dataArray.Add(new LegacyPointItem(31, LocalStringManager.GetConfig("LegacyPoint_language", "Name_31"), 4, 20, 500, isHidden: false, new byte[4] { 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_31")));
		_dataArray.Add(new LegacyPointItem(32, LocalStringManager.GetConfig("LegacyPoint_language", "Name_32"), 5, 10, 500, isHidden: false, new byte[2] { 5, 6 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_32")));
		_dataArray.Add(new LegacyPointItem(33, LocalStringManager.GetConfig("LegacyPoint_language", "Name_33"), 5, 10, 500, isHidden: false, new byte[2] { 5, 6 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_33")));
		_dataArray.Add(new LegacyPointItem(34, LocalStringManager.GetConfig("LegacyPoint_language", "Name_34"), 5, 10, 500, isHidden: false, new byte[2] { 5, 6 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_34")));
		_dataArray.Add(new LegacyPointItem(35, LocalStringManager.GetConfig("LegacyPoint_language", "Name_35"), 5, 10, 500, isHidden: false, new byte[2] { 5, 6 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_35")));
		_dataArray.Add(new LegacyPointItem(36, LocalStringManager.GetConfig("LegacyPoint_language", "Name_36"), 5, 100, 500, isHidden: false, new byte[2] { 5, 6 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_36")));
		_dataArray.Add(new LegacyPointItem(37, LocalStringManager.GetConfig("LegacyPoint_language", "Name_37"), 5, 100, 500, isHidden: false, new byte[4] { 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_37")));
		_dataArray.Add(new LegacyPointItem(38, LocalStringManager.GetConfig("LegacyPoint_language", "Name_38"), 5, 10, 500, isHidden: false, new byte[4] { 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_38")));
		_dataArray.Add(new LegacyPointItem(39, LocalStringManager.GetConfig("LegacyPoint_language", "Name_39"), 5, 20, 500, isHidden: false, new byte[4] { 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_39")));
		_dataArray.Add(new LegacyPointItem(40, LocalStringManager.GetConfig("LegacyPoint_language", "Name_40"), 6, 250, 2500, isHidden: false, new byte[7] { 1, 2, 3, 4, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_40")));
		_dataArray.Add(new LegacyPointItem(41, LocalStringManager.GetConfig("LegacyPoint_language", "Name_41"), 6, 2500, 7500, isHidden: false, new byte[7] { 1, 2, 3, 4, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_41")));
		_dataArray.Add(new LegacyPointItem(42, LocalStringManager.GetConfig("LegacyPoint_language", "Name_42"), 7, 50, 500, isHidden: false, new byte[11]
		{
			12, 1, 11, 2, 3, 4, 5, 6, 7, 13,
			14
		}, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_42")));
		_dataArray.Add(new LegacyPointItem(43, LocalStringManager.GetConfig("LegacyPoint_language", "Name_43"), 7, 50, 500, isHidden: false, new byte[11]
		{
			12, 1, 11, 2, 3, 4, 5, 6, 7, 13,
			14
		}, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_43")));
		_dataArray.Add(new LegacyPointItem(44, LocalStringManager.GetConfig("LegacyPoint_language", "Name_44"), 7, 100, 1000, isHidden: false, new byte[11]
		{
			12, 1, 11, 2, 3, 4, 5, 6, 7, 13,
			14
		}, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_44")));
		_dataArray.Add(new LegacyPointItem(45, LocalStringManager.GetConfig("LegacyPoint_language", "Name_45"), 7, 200, 2000, isHidden: false, new byte[11]
		{
			12, 1, 11, 2, 3, 4, 5, 6, 7, 13,
			14
		}, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_45")));
		_dataArray.Add(new LegacyPointItem(46, LocalStringManager.GetConfig("LegacyPoint_language", "Name_46"), -1, -1, -1, isHidden: true, new byte[10] { 12, 1, 11, 2, 3, 4, 5, 6, 7, 13 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_46")));
		_dataArray.Add(new LegacyPointItem(47, LocalStringManager.GetConfig("LegacyPoint_language", "Name_47"), 2, 5, 500, isHidden: false, new byte[5] { 2, 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_47")));
		_dataArray.Add(new LegacyPointItem(48, LocalStringManager.GetConfig("LegacyPoint_language", "Name_48"), 3, 5, 500, isHidden: false, new byte[5] { 2, 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_48")));
		_dataArray.Add(new LegacyPointItem(49, LocalStringManager.GetConfig("LegacyPoint_language", "Name_49"), 3, 20, 500, isHidden: false, new byte[6] { 2, 3, 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_49")));
		_dataArray.Add(new LegacyPointItem(50, LocalStringManager.GetConfig("LegacyPoint_language", "Name_50"), 4, 20, 500, isHidden: false, new byte[4] { 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_50")));
		_dataArray.Add(new LegacyPointItem(51, LocalStringManager.GetConfig("LegacyPoint_language", "Name_51"), 0, 10000, 10000, isHidden: true, new byte[0], LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_51")));
		_dataArray.Add(new LegacyPointItem(52, LocalStringManager.GetConfig("LegacyPoint_language", "Name_52"), 0, 0, 999999, isHidden: true, new byte[0], LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_52")));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<LegacyPointItem>(53);
		CreateItems0();
	}
}

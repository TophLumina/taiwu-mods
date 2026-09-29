using System;
using System.Collections.Generic;
using Config.Common;
using GameData.ActionPlanning.MonthlyAI;
using GameData.ActionPlanning.State;

namespace Config;

[Serializable]
public class PlanningGoal : ConfigData<PlanningGoalItem, int>
{
	public static class DefKey
	{
		public const int IncreaseMaxHealth = 225;

		public const int IncreaseHealth = 227;

		public const int HealInjury = 228;

		public const int HealPoison = 229;

		public const int RestoreDisorderOfQi = 230;

		public const int KillWug = 231;

		public const int IncreaseHappiness = 232;

		public const int IncreaseNeili = 233;

		public const int RecoverMainAttribute = 234;

		public const int GainExp = 235;

		public const int GainResource = 236;

		public const int SpendResource = 237;

		public const int GainItem = 238;

		public const int SpendItem = 239;

		public const int RepairItem = 240;

		public const int AddPoisonToItem = 241;

		public const int LearnCombatSkill = 242;

		public const int LearnLifeSkill = 243;

		public const int AskForHelpOnReading = 244;

		public const int AskForHelpOnBreakout = 245;

		public const int IncreaseCombatSkillAttainment = 246;

		public const int IncreaseLifeSkillAttainment = 247;

		public const int IncreaseInventoryLoad = 248;

		public const int AddRelationOnce = 249;

		public const int EndRelationOnce = 250;

		public const int AddRelation = 251;

		public const int EndRelation = 252;

		public const int MakeLove = 272;

		public const int DejaVu = 253;

		public const int Appointment = 254;

		public const int GuardTreasury = 255;

		public const int HuntFugitive = 256;

		public const int EscapeFromPrison = 257;

		public const int SeekAsylum = 258;

		public const int EscortPrisoner = 259;

		public const int VillagerRoleArrangement = 260;

		public const int JoinOrganization = 261;

		public const int ProtectFriendOrFamily = 262;

		public const int RescueFriendOrFamily = 263;

		public const int MournForTheDead = 264;

		public const int FindTreasure = 265;

		public const int FindSpecialMaterial = 266;

		public const int ContestForLegendaryBook = 267;

		public const int GetRevenge = 274;

		public const int AdoptInfant = 268;

		public const int SectStoryBaihuaToCureManic = 269;

		public const int SectStoryShixiangToFightEnemy = 270;

		public const int HuntTaiwu = 271;

		public const int ReturnHome = 275;
	}

	public static class DefValue
	{
		public static PlanningGoalItem IncreaseMaxHealth => Instance[225];

		public static PlanningGoalItem IncreaseHealth => Instance[227];

		public static PlanningGoalItem HealInjury => Instance[228];

		public static PlanningGoalItem HealPoison => Instance[229];

		public static PlanningGoalItem RestoreDisorderOfQi => Instance[230];

		public static PlanningGoalItem KillWug => Instance[231];

		public static PlanningGoalItem IncreaseHappiness => Instance[232];

		public static PlanningGoalItem IncreaseNeili => Instance[233];

		public static PlanningGoalItem RecoverMainAttribute => Instance[234];

		public static PlanningGoalItem GainExp => Instance[235];

		public static PlanningGoalItem GainResource => Instance[236];

		public static PlanningGoalItem SpendResource => Instance[237];

		public static PlanningGoalItem GainItem => Instance[238];

		public static PlanningGoalItem SpendItem => Instance[239];

		public static PlanningGoalItem RepairItem => Instance[240];

		public static PlanningGoalItem AddPoisonToItem => Instance[241];

		public static PlanningGoalItem LearnCombatSkill => Instance[242];

		public static PlanningGoalItem LearnLifeSkill => Instance[243];

		public static PlanningGoalItem AskForHelpOnReading => Instance[244];

		public static PlanningGoalItem AskForHelpOnBreakout => Instance[245];

		public static PlanningGoalItem IncreaseCombatSkillAttainment => Instance[246];

		public static PlanningGoalItem IncreaseLifeSkillAttainment => Instance[247];

		public static PlanningGoalItem IncreaseInventoryLoad => Instance[248];

		public static PlanningGoalItem AddRelationOnce => Instance[249];

		public static PlanningGoalItem EndRelationOnce => Instance[250];

		public static PlanningGoalItem AddRelation => Instance[251];

		public static PlanningGoalItem EndRelation => Instance[252];

		public static PlanningGoalItem MakeLove => Instance[272];

		public static PlanningGoalItem DejaVu => Instance[253];

		public static PlanningGoalItem Appointment => Instance[254];

		public static PlanningGoalItem GuardTreasury => Instance[255];

		public static PlanningGoalItem HuntFugitive => Instance[256];

		public static PlanningGoalItem EscapeFromPrison => Instance[257];

		public static PlanningGoalItem SeekAsylum => Instance[258];

		public static PlanningGoalItem EscortPrisoner => Instance[259];

		public static PlanningGoalItem VillagerRoleArrangement => Instance[260];

		public static PlanningGoalItem JoinOrganization => Instance[261];

		public static PlanningGoalItem ProtectFriendOrFamily => Instance[262];

		public static PlanningGoalItem RescueFriendOrFamily => Instance[263];

		public static PlanningGoalItem MournForTheDead => Instance[264];

		public static PlanningGoalItem FindTreasure => Instance[265];

		public static PlanningGoalItem FindSpecialMaterial => Instance[266];

		public static PlanningGoalItem ContestForLegendaryBook => Instance[267];

		public static PlanningGoalItem GetRevenge => Instance[274];

		public static PlanningGoalItem AdoptInfant => Instance[268];

		public static PlanningGoalItem SectStoryBaihuaToCureManic => Instance[269];

		public static PlanningGoalItem SectStoryShixiangToFightEnemy => Instance[270];

		public static PlanningGoalItem HuntTaiwu => Instance[271];

		public static PlanningGoalItem ReturnHome => Instance[275];
	}

	public static PlanningGoal Instance = new PlanningGoal();

	private readonly HashSet<string> RequiredFields = new HashSet<string>
	{
		"Name", "ConflictActions", "AddConditions", "Preconditions", "TargetCharacterConditionsA", "TargetCharacterConditionsB", "TargetCharacterConditionsC", "Parameters", "Validators", "TemplateId",
		"CreateGoalImpl"
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
		_dataArray.Add(new PlanningGoalItem(0, LocalStringManager.GetConfig("PlanningGoal_language", "Name_0"), hideInUI: false, -1, 15, new short[5] { 0, 25, 0, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(460, ">=", 3)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(36, ">=", 125)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(1, LocalStringManager.GetConfig("PlanningGoal_language", "Name_1"), hideInUI: false, -1, 15, new short[5] { 0, 25, 0, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(461, ">=", 3)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(36, "<=", -125)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(2, LocalStringManager.GetConfig("PlanningGoal_language", "Name_2"), hideInUI: false, -1, 15, new short[5] { 0, 25, 0, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(460, ">=", 3)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(42, ">=", 25)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(3, LocalStringManager.GetConfig("PlanningGoal_language", "Name_3"), hideInUI: false, -1, 15, new short[5] { 0, 25, 0, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(461, ">=", 3)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(42, "<=", -25)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(4, LocalStringManager.GetConfig("PlanningGoal_language", "Name_4"), hideInUI: false, -1, 15, new short[5] { 0, 25, 0, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(466, ">=", 3)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(5, LocalStringManager.GetConfig("PlanningGoal_language", "Name_5"), hideInUI: false, -1, 15, new short[5] { 0, 0, 25, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(464, ">=", 3)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(6, LocalStringManager.GetConfig("PlanningGoal_language", "Name_6"), hideInUI: false, -1, 15, new short[5] { 0, 0, 25, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(460, ">=", 3)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(332)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(296),
			new StateConditionAndValue<StateKey>(42, ">=", 25)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(321),
			new StateConditionAndValue<StateKey>(42, ">=", 25)
		}, null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(7, LocalStringManager.GetConfig("PlanningGoal_language", "Name_7"), hideInUI: false, -1, 15, new short[5] { 25, 0, 0, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(461, ">=", 3)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(331)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(296),
			new StateConditionAndValue<StateKey>(42, "<=", -25)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(321),
			new StateConditionAndValue<StateKey>(42, "<=", -25)
		}, null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(8, LocalStringManager.GetConfig("PlanningGoal_language", "Name_8"), hideInUI: false, -1, 15, new short[5] { 0, 0, 0, 25, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(469, ">=", 3)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(51, ">=", -4, 88)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(9, LocalStringManager.GetConfig("PlanningGoal_language", "Name_9"), hideInUI: false, -1, 15, new short[5] { 0, 0, 25, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(468, ">=", 3)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(51, ">=", 0, 88)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(10, LocalStringManager.GetConfig("PlanningGoal_language", "Name_10"), hideInUI: false, -1, 15, new short[5] { 25, 0, 0, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(272)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(11, LocalStringManager.GetConfig("PlanningGoal_language", "Name_11"), hideInUI: false, -1, 15, new short[5] { 25, 0, 0, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(282)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(312)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(12, LocalStringManager.GetConfig("PlanningGoal_language", "Name_12"), hideInUI: false, -1, 15, new short[5] { 0, 0, 25, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[4]
		{
			new StateConditionAndValue<StateKey>(434),
			new StateConditionAndValue<StateKey>(435),
			new StateConditionAndValue<StateKey>(436),
			new StateConditionAndValue<StateKey>(437)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(13, LocalStringManager.GetConfig("PlanningGoal_language", "Name_13"), hideInUI: false, -1, 15, new short[5] { 0, 0, 0, 0, 25 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(438),
			new StateConditionAndValue<StateKey>(439)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(14, LocalStringManager.GetConfig("PlanningGoal_language", "Name_14"), hideInUI: false, -1, 15, new short[5] { 0, 0, 0, 0, 25 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(474)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(15, LocalStringManager.GetConfig("PlanningGoal_language", "Name_15"), hideInUI: false, -1, 15, new short[5] { 0, 0, 0, 25, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(465, ">=", 3)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(16, LocalStringManager.GetConfig("PlanningGoal_language", "Name_16"), hideInUI: false, -1, 15, new short[5] { 0, 0, 0, 25, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(107)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(472),
			new StateConditionAndValue<StateKey>(37, ">=", -2, 74)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(472),
			new StateConditionAndValue<StateKey>(296)
		}, new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(17, LocalStringManager.GetConfig("PlanningGoal_language", "Name_17"), hideInUI: false, -1, 15, new short[5] { 25, 0, 0, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(475)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(18, LocalStringManager.GetConfig("PlanningGoal_language", "Name_18"), hideInUI: false, -1, 15, new short[5] { 0, 0, 0, 0, 25 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(467, ">=", 3)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(51, ">=", -4, 88)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(19, LocalStringManager.GetConfig("PlanningGoal_language", "Name_19"), hideInUI: false, -1, 25, new short[5], isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(493, ">=", 2)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(20, LocalStringManager.GetConfig("PlanningGoal_language", "Name_20"), hideInUI: false, -1, 25, new short[5], isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(494, ">=", 2)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(21, LocalStringManager.GetConfig("PlanningGoal_language", "Name_21"), hideInUI: false, -1, 25, new short[5], isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(495, ">=", 2)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(22, LocalStringManager.GetConfig("PlanningGoal_language", "Name_22"), hideInUI: false, -1, 25, new short[5], isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(496, ">=", 2)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(23, LocalStringManager.GetConfig("PlanningGoal_language", "Name_23"), hideInUI: false, -1, 25, new short[5], isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(497, ">=", 2)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(24, LocalStringManager.GetConfig("PlanningGoal_language", "Name_24"), hideInUI: false, -1, 25, new short[5], isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(498, ">=", 2)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(25, LocalStringManager.GetConfig("PlanningGoal_language", "Name_25"), hideInUI: false, -1, 25, new short[5], isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(499, ">=", 2)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(26, LocalStringManager.GetConfig("PlanningGoal_language", "Name_26"), hideInUI: false, -1, 25, new short[5], isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(500, ">=", 2)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(27, LocalStringManager.GetConfig("PlanningGoal_language", "Name_27"), hideInUI: false, -1, 25, new short[5], isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(501, ">=", 2)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(28, LocalStringManager.GetConfig("PlanningGoal_language", "Name_28"), hideInUI: false, -1, 25, new short[5], isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(502, ">=", 2)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(29, LocalStringManager.GetConfig("PlanningGoal_language", "Name_29"), hideInUI: false, -1, 25, new short[5], isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(503, ">=", 2)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(30, LocalStringManager.GetConfig("PlanningGoal_language", "Name_30"), hideInUI: false, -1, 25, new short[5], isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(504, ">=", 2)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(31, LocalStringManager.GetConfig("PlanningGoal_language", "Name_31"), hideInUI: false, -1, 25, new short[5], isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(505, ">=", 2)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(32, LocalStringManager.GetConfig("PlanningGoal_language", "Name_32"), hideInUI: false, -1, 25, new short[5], isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(506, ">=", 2)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(33, LocalStringManager.GetConfig("PlanningGoal_language", "Name_33"), hideInUI: false, -1, 25, new short[5], isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(507, ">=", 2)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(34, LocalStringManager.GetConfig("PlanningGoal_language", "Name_34"), hideInUI: false, -1, 0, new short[5] { 10, 25, 20, 15, 5 }, isPrioritizedGoal: false, 2, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(454)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(314),
			new StateConditionAndValue<StateKey>(37, "<", 0, 74)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(313),
			new StateConditionAndValue<StateKey>(37, "<", 0, 74)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(296)
		}, null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(35, LocalStringManager.GetConfig("PlanningGoal_language", "Name_35"), hideInUI: false, -1, 25, new short[5], isPrioritizedGoal: false, 2, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(452)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(36, LocalStringManager.GetConfig("PlanningGoal_language", "Name_36"), hideInUI: false, -1, 25, new short[5], isPrioritizedGoal: false, 2, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(458)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(37, LocalStringManager.GetConfig("PlanningGoal_language", "Name_37"), hideInUI: false, -1, 0, new short[5] { 10, 25, 20, 15, 5 }, isPrioritizedGoal: false, 2, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(455)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(314),
			new StateConditionAndValue<StateKey>(37, "<", 0, 74)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(313),
			new StateConditionAndValue<StateKey>(37, "<", 0, 74)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(296)
		}, null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(38, LocalStringManager.GetConfig("PlanningGoal_language", "Name_38"), hideInUI: false, -1, 25, new short[5], isPrioritizedGoal: false, 2, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(453)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(39, LocalStringManager.GetConfig("PlanningGoal_language", "Name_39"), hideInUI: false, -1, 25, new short[5], isPrioritizedGoal: false, 2, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(456)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(314),
			new StateConditionAndValue<StateKey>(37, ">", 0, 74)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(313),
			new StateConditionAndValue<StateKey>(37, ">", 0, 74)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(296)
		}, null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(40, LocalStringManager.GetConfig("PlanningGoal_language", "Name_40"), hideInUI: false, -1, 25, new short[5], isPrioritizedGoal: false, 2, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(457)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(314),
			new StateConditionAndValue<StateKey>(37, ">", 0, 74)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(313),
			new StateConditionAndValue<StateKey>(37, ">", 0, 74)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(296)
		}, null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(41, LocalStringManager.GetConfig("PlanningGoal_language", "Name_41"), hideInUI: false, -1, 10, new short[5] { 0, 25, 0, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(508)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(42, LocalStringManager.GetConfig("PlanningGoal_language", "Name_42"), hideInUI: false, -1, 10, new short[5] { 0, 25, 0, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(509)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(315),
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(43, LocalStringManager.GetConfig("PlanningGoal_language", "Name_43"), hideInUI: false, -1, 10, new short[5] { 0, 25, 0, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(517)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(315),
			new StateConditionAndValue<StateKey>(42, "<=", -25)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(315),
			new StateConditionAndValue<StateKey>(36, "<=", -125)
		}, new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(44, LocalStringManager.GetConfig("PlanningGoal_language", "Name_44"), hideInUI: false, -1, 10, new short[5] { 0, 25, 0, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(518)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(45, LocalStringManager.GetConfig("PlanningGoal_language", "Name_45"), hideInUI: false, -1, 10, new short[5] { 0, 25, 0, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(512)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(315)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(46, LocalStringManager.GetConfig("PlanningGoal_language", "Name_46"), hideInUI: false, -1, 10, new short[5] { 0, 25, 0, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(511)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(47, LocalStringManager.GetConfig("PlanningGoal_language", "Name_47"), hideInUI: false, -1, 10, new short[5] { 0, 25, 0, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(519)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(48, LocalStringManager.GetConfig("PlanningGoal_language", "Name_48"), hideInUI: false, -1, 10, new short[5] { 0, 25, 0, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(509)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(315),
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(49, LocalStringManager.GetConfig("PlanningGoal_language", "Name_49"), hideInUI: false, -1, 10, new short[5] { 0, 25, 0, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(508)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(50, LocalStringManager.GetConfig("PlanningGoal_language", "Name_50"), hideInUI: false, -1, 10, new short[5] { 0, 25, 0, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(520)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(297)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(51, LocalStringManager.GetConfig("PlanningGoal_language", "Name_51"), hideInUI: false, -1, 10, new short[5] { 0, 25, 0, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(521)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(42, "<=", -25)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(36, "<=", -125)
		}, new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(52, LocalStringManager.GetConfig("PlanningGoal_language", "Name_52"), hideInUI: false, -1, 10, new short[5] { 0, 25, 0, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(512)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(315)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(53, LocalStringManager.GetConfig("PlanningGoal_language", "Name_53"), hideInUI: false, -1, 10, new short[5] { 0, 25, 0, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(522)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(54, LocalStringManager.GetConfig("PlanningGoal_language", "Name_54"), hideInUI: false, -1, 10, new short[5] { 0, 25, 0, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(523)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(318),
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(55, LocalStringManager.GetConfig("PlanningGoal_language", "Name_55"), hideInUI: false, -1, 10, new short[5] { 0, 25, 0, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(508)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(56, LocalStringManager.GetConfig("PlanningGoal_language", "Name_56"), hideInUI: false, -1, 10, new short[5] { 0, 25, 0, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(509)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(315),
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(57, LocalStringManager.GetConfig("PlanningGoal_language", "Name_57"), hideInUI: false, -1, 10, new short[5] { 0, 25, 0, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(513)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(60)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(58, LocalStringManager.GetConfig("PlanningGoal_language", "Name_58"), hideInUI: false, -1, 10, new short[5] { 0, 25, 0, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(514)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(64)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(59, LocalStringManager.GetConfig("PlanningGoal_language", "Name_59"), hideInUI: false, -1, 10, new short[5] { 0, 25, 0, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(512)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(315)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new PlanningGoalItem(60, LocalStringManager.GetConfig("PlanningGoal_language", "Name_60"), hideInUI: false, -1, 10, new short[5] { 0, 25, 0, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(382)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(61, LocalStringManager.GetConfig("PlanningGoal_language", "Name_61"), hideInUI: false, -1, 10, new short[5] { 0, 0, 25, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(508)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(62, LocalStringManager.GetConfig("PlanningGoal_language", "Name_62"), hideInUI: false, -1, 10, new short[5] { 0, 0, 25, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(524)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(63, LocalStringManager.GetConfig("PlanningGoal_language", "Name_63"), hideInUI: false, -1, 10, new short[5] { 0, 0, 25, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(509)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(315),
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(64, LocalStringManager.GetConfig("PlanningGoal_language", "Name_64"), hideInUI: false, -1, 10, new short[5] { 0, 0, 25, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(516)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(318),
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(65, LocalStringManager.GetConfig("PlanningGoal_language", "Name_65"), hideInUI: false, -1, 10, new short[5] { 0, 0, 25, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(512)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(315)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(66, LocalStringManager.GetConfig("PlanningGoal_language", "Name_66"), hideInUI: false, -1, 10, new short[5] { 25, 0, 0, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(525)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(67)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(67, LocalStringManager.GetConfig("PlanningGoal_language", "Name_67"), hideInUI: false, -1, 10, new short[5] { 25, 0, 0, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(526)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(65, ">=", 50)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(68, LocalStringManager.GetConfig("PlanningGoal_language", "Name_68"), hideInUI: false, -1, 10, new short[5] { 25, 0, 0, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(510)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(315),
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(69, LocalStringManager.GetConfig("PlanningGoal_language", "Name_69"), hideInUI: false, -1, 10, new short[5] { 25, 0, 0, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(527)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(70, LocalStringManager.GetConfig("PlanningGoal_language", "Name_70"), hideInUI: false, -1, 10, new short[5] { 25, 0, 0, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(511)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(71, LocalStringManager.GetConfig("PlanningGoal_language", "Name_71"), hideInUI: false, -1, 10, new short[5] { 25, 0, 0, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(512)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(315)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(72, LocalStringManager.GetConfig("PlanningGoal_language", "Name_72"), hideInUI: false, -1, 10, new short[5] { 0, 0, 0, 25, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(528)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(315)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(73, LocalStringManager.GetConfig("PlanningGoal_language", "Name_73"), hideInUI: false, -1, 10, new short[5] { 0, 0, 0, 25, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(509)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(315),
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(74, LocalStringManager.GetConfig("PlanningGoal_language", "Name_74"), hideInUI: false, -1, 10, new short[5] { 0, 0, 0, 25, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(529)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(315),
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(75, LocalStringManager.GetConfig("PlanningGoal_language", "Name_75"), hideInUI: false, -1, 10, new short[5] { 0, 0, 0, 25, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(516)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(318),
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(76, LocalStringManager.GetConfig("PlanningGoal_language", "Name_76"), hideInUI: false, -1, 10, new short[5] { 0, 0, 0, 25, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(530)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(315),
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(77, LocalStringManager.GetConfig("PlanningGoal_language", "Name_77"), hideInUI: false, -1, 10, new short[5] { 0, 0, 0, 25, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(531)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(315),
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(78, LocalStringManager.GetConfig("PlanningGoal_language", "Name_78"), hideInUI: false, -1, 10, new short[5] { 0, 0, 0, 25, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(532)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(315),
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(79, LocalStringManager.GetConfig("PlanningGoal_language", "Name_79"), hideInUI: false, -1, 10, new short[5] { 0, 0, 0, 25, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(533)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(315),
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(80, LocalStringManager.GetConfig("PlanningGoal_language", "Name_80"), hideInUI: false, -1, 10, new short[5] { 0, 0, 0, 25, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(515)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(318),
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(81, LocalStringManager.GetConfig("PlanningGoal_language", "Name_81"), hideInUI: false, -1, 10, new short[5] { 0, 0, 25, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(534)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(315)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(82, LocalStringManager.GetConfig("PlanningGoal_language", "Name_82"), hideInUI: false, -1, 10, new short[5] { 0, 0, 25, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(509)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(315),
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(83, LocalStringManager.GetConfig("PlanningGoal_language", "Name_83"), hideInUI: false, -1, 10, new short[5] { 0, 0, 25, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(535)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(84, LocalStringManager.GetConfig("PlanningGoal_language", "Name_84"), hideInUI: false, -1, 10, new short[5] { 0, 0, 25, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(536)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(85, LocalStringManager.GetConfig("PlanningGoal_language", "Name_85"), hideInUI: false, -1, 10, new short[5] { 0, 0, 25, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(511)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(86, LocalStringManager.GetConfig("PlanningGoal_language", "Name_86"), hideInUI: false, -1, 10, new short[5] { 0, 0, 25, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(537)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(87, LocalStringManager.GetConfig("PlanningGoal_language", "Name_87"), hideInUI: false, -1, 10, new short[5] { 0, 0, 25, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(470)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(315),
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(88, LocalStringManager.GetConfig("PlanningGoal_language", "Name_88"), hideInUI: false, -1, 10, new short[5] { 0, 0, 25, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(468)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(315),
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(89, LocalStringManager.GetConfig("PlanningGoal_language", "Name_89"), hideInUI: false, -1, 10, new short[5] { 25, 0, 0, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(508)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(90, LocalStringManager.GetConfig("PlanningGoal_language", "Name_90"), hideInUI: false, -1, 10, new short[5] { 25, 0, 0, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(538)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(318)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(91, LocalStringManager.GetConfig("PlanningGoal_language", "Name_91"), hideInUI: false, -1, 10, new short[5] { 25, 0, 0, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(509)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(315),
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(92, LocalStringManager.GetConfig("PlanningGoal_language", "Name_92"), hideInUI: false, -1, 10, new short[5] { 25, 0, 0, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(511)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(93, LocalStringManager.GetConfig("PlanningGoal_language", "Name_93"), hideInUI: false, -1, 10, new short[5] { 25, 0, 0, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(512)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(315)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(94, LocalStringManager.GetConfig("PlanningGoal_language", "Name_94"), hideInUI: false, -1, 10, new short[5] { 25, 0, 0, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(539)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(315),
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(95, LocalStringManager.GetConfig("PlanningGoal_language", "Name_95"), hideInUI: false, -1, 10, new short[5] { 25, 0, 0, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(540)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(315)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(96, LocalStringManager.GetConfig("PlanningGoal_language", "Name_96"), hideInUI: false, -1, 10, new short[5] { 0, 0, 25, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(508)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(97, LocalStringManager.GetConfig("PlanningGoal_language", "Name_97"), hideInUI: false, -1, 10, new short[5] { 0, 0, 25, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(509)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(315),
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(98, LocalStringManager.GetConfig("PlanningGoal_language", "Name_98"), hideInUI: false, -1, 10, new short[5] { 0, 0, 25, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(511)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(99, LocalStringManager.GetConfig("PlanningGoal_language", "Name_99"), hideInUI: false, -1, 10, new short[5] { 0, 0, 25, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(541)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(100, LocalStringManager.GetConfig("PlanningGoal_language", "Name_100"), hideInUI: false, -1, 10, new short[5] { 0, 0, 25, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(512)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(315)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(101, LocalStringManager.GetConfig("PlanningGoal_language", "Name_101"), hideInUI: false, -1, 10, new short[5] { 0, 0, 25, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(542)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(102, LocalStringManager.GetConfig("PlanningGoal_language", "Name_102"), hideInUI: false, -1, 10, new short[5] { 0, 0, 25, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(543)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(103, LocalStringManager.GetConfig("PlanningGoal_language", "Name_103"), hideInUI: false, -1, 10, new short[5] { 0, 0, 25, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(544)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(104, LocalStringManager.GetConfig("PlanningGoal_language", "Name_104"), hideInUI: false, -1, 10, new short[5] { 0, 0, 0, 0, 25 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(513)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(60)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(105, LocalStringManager.GetConfig("PlanningGoal_language", "Name_105"), hideInUI: false, -1, 10, new short[5] { 0, 0, 0, 0, 25 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(514)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(64)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(106, LocalStringManager.GetConfig("PlanningGoal_language", "Name_106"), hideInUI: false, -1, 10, new short[5] { 0, 0, 0, 0, 25 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(545)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(318),
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(107, LocalStringManager.GetConfig("PlanningGoal_language", "Name_107"), hideInUI: false, -1, 10, new short[5] { 0, 0, 0, 0, 25 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(546)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(318),
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(108, LocalStringManager.GetConfig("PlanningGoal_language", "Name_108"), hideInUI: false, -1, 10, new short[5] { 0, 0, 0, 0, 25 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(547)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(315),
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(109, LocalStringManager.GetConfig("PlanningGoal_language", "Name_109"), hideInUI: false, -1, 10, new short[5] { 0, 0, 0, 0, 25 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(548)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(315),
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(110, LocalStringManager.GetConfig("PlanningGoal_language", "Name_110"), hideInUI: false, -1, 10, new short[5] { 0, 0, 0, 0, 25 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(389)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(111, LocalStringManager.GetConfig("PlanningGoal_language", "Name_111"), hideInUI: false, -1, 10, new short[5] { 0, 0, 0, 0, 25 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(390)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(112, LocalStringManager.GetConfig("PlanningGoal_language", "Name_112"), hideInUI: false, -1, 10, new short[5] { 0, 0, 0, 0, 25 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(512)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(315)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(113, LocalStringManager.GetConfig("PlanningGoal_language", "Name_113"), hideInUI: false, -1, 10, new short[5] { 0, 0, 0, 0, 25 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(549)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(114, LocalStringManager.GetConfig("PlanningGoal_language", "Name_114"), hideInUI: false, -1, 10, new short[5] { 0, 0, 0, 0, 25 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(509)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(315),
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(115, LocalStringManager.GetConfig("PlanningGoal_language", "Name_115"), hideInUI: false, -1, 10, new short[5] { 0, 0, 0, 0, 25 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(510)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(315),
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(116, LocalStringManager.GetConfig("PlanningGoal_language", "Name_116"), hideInUI: false, -1, 10, new short[5] { 0, 0, 0, 0, 25 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(515)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(318),
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(117, LocalStringManager.GetConfig("PlanningGoal_language", "Name_117"), hideInUI: false, -1, 10, new short[5] { 0, 0, 0, 0, 25 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(550)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(118, LocalStringManager.GetConfig("PlanningGoal_language", "Name_118"), hideInUI: false, -1, 10, new short[5] { 0, 0, 0, 0, 25 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(551)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(318),
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(119, LocalStringManager.GetConfig("PlanningGoal_language", "Name_119"), hideInUI: false, -1, 10, new short[5] { 0, 0, 0, 0, 25 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(512)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(315)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
	}

	private void CreateItems2()
	{
		_dataArray.Add(new PlanningGoalItem(120, LocalStringManager.GetConfig("PlanningGoal_language", "Name_120"), hideInUI: false, -1, 10, new short[5] { 0, 0, 0, 25, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(552)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(121, LocalStringManager.GetConfig("PlanningGoal_language", "Name_121"), hideInUI: false, -1, 10, new short[5] { 0, 0, 0, 25, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(511)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(122, LocalStringManager.GetConfig("PlanningGoal_language", "Name_122"), hideInUI: false, -1, 10, new short[5] { 0, 0, 0, 25, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(553)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(315),
			new StateConditionAndValue<StateKey>(37, "==", 7)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(123, LocalStringManager.GetConfig("PlanningGoal_language", "Name_123"), hideInUI: false, -1, 10, new short[5] { 0, 0, 0, 25, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(516)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(318),
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(124, LocalStringManager.GetConfig("PlanningGoal_language", "Name_124"), hideInUI: false, -1, 10, new short[5] { 0, 0, 0, 25, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(509)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(315),
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(125, LocalStringManager.GetConfig("PlanningGoal_language", "Name_125"), hideInUI: false, -1, 10, new short[5] { 0, 0, 0, 25, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(554)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(62)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(126, LocalStringManager.GetConfig("PlanningGoal_language", "Name_126"), hideInUI: false, -1, 10, new short[5] { 0, 0, 0, 25, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(383)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(127, LocalStringManager.GetConfig("PlanningGoal_language", "Name_127"), hideInUI: false, -1, 10, new short[5] { 0, 0, 0, 25, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(555)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(128, LocalStringManager.GetConfig("PlanningGoal_language", "Name_128"), hideInUI: false, -1, 10, new short[5] { 0, 0, 0, 25, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(509)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(315),
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(129, LocalStringManager.GetConfig("PlanningGoal_language", "Name_129"), hideInUI: false, -1, 10, new short[5] { 0, 0, 0, 25, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(556)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(315)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(130, LocalStringManager.GetConfig("PlanningGoal_language", "Name_130"), hideInUI: false, -1, 10, new short[5] { 0, 0, 0, 25, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(557)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(472),
			new StateConditionAndValue<StateKey>(37, ">=", -2, 74)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(131, LocalStringManager.GetConfig("PlanningGoal_language", "Name_131"), hideInUI: false, -1, 10, new short[5] { 0, 0, 0, 25, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(558)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(41)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(132, LocalStringManager.GetConfig("PlanningGoal_language", "Name_132"), hideInUI: false, -1, 10, new short[5] { 0, 0, 0, 25, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(559)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(318),
			new StateConditionAndValue<StateKey>(294, ">=", 1)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(133, LocalStringManager.GetConfig("PlanningGoal_language", "Name_133"), hideInUI: false, -1, 10, new short[5] { 0, 0, 0, 25, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(560)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(315)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(134, LocalStringManager.GetConfig("PlanningGoal_language", "Name_134"), hideInUI: false, -1, 10, new short[5] { 25, 0, 0, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(511)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(135, LocalStringManager.GetConfig("PlanningGoal_language", "Name_135"), hideInUI: false, -1, 10, new short[5] { 25, 0, 0, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(510)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(315),
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(136, LocalStringManager.GetConfig("PlanningGoal_language", "Name_136"), hideInUI: false, -1, 10, new short[5] { 25, 0, 0, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(508)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(137, LocalStringManager.GetConfig("PlanningGoal_language", "Name_137"), hideInUI: false, -1, 10, new short[5] { 25, 0, 0, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(516)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(318),
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(138, LocalStringManager.GetConfig("PlanningGoal_language", "Name_138"), hideInUI: false, -1, 10, new short[5] { 25, 0, 0, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(561)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(139, LocalStringManager.GetConfig("PlanningGoal_language", "Name_139"), hideInUI: false, -1, 10, new short[5] { 25, 0, 0, 0, 0 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(512)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(315)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(140, LocalStringManager.GetConfig("PlanningGoal_language", "Name_140"), hideInUI: false, -1, 10, new short[5] { 0, 0, 0, 0, 25 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(508)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(141, LocalStringManager.GetConfig("PlanningGoal_language", "Name_141"), hideInUI: false, -1, 10, new short[5] { 0, 0, 0, 0, 25 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(510)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(315),
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(142, LocalStringManager.GetConfig("PlanningGoal_language", "Name_142"), hideInUI: false, -1, 10, new short[5] { 0, 0, 0, 0, 25 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(509)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(315),
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(143, LocalStringManager.GetConfig("PlanningGoal_language", "Name_143"), hideInUI: false, -1, 10, new short[5] { 0, 0, 0, 0, 25 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(562)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(315),
			new StateConditionAndValue<StateKey>(37, "<", 0, 74)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(144, LocalStringManager.GetConfig("PlanningGoal_language", "Name_144"), hideInUI: false, -1, 10, new short[5] { 0, 0, 0, 0, 25 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(563)
		}, new StateConditionAndValue<StateKey>[3]
		{
			new StateConditionAndValue<StateKey>(321, 0),
			new StateConditionAndValue<StateKey>(318),
			new StateConditionAndValue<StateKey>(37, "<=", 2)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(145, LocalStringManager.GetConfig("PlanningGoal_language", "Name_145"), hideInUI: false, -1, 10, new short[5] { 0, 0, 0, 0, 25 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(512)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(315)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(146, LocalStringManager.GetConfig("PlanningGoal_language", "Name_146"), hideInUI: false, -1, 0, new short[5] { 25, 15, 20, 5, 10 }, isPrioritizedGoal: false, 2, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(564)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(318),
			new StateConditionAndValue<StateKey>(37, "==", 8)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(147, LocalStringManager.GetConfig("PlanningGoal_language", "Name_147"), hideInUI: false, -1, 0, new short[5] { 15, 5, 20, 10, 25 }, isPrioritizedGoal: false, 2, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(565)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(317),
			new StateConditionAndValue<StateKey>(37, "==", 8)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(148, LocalStringManager.GetConfig("PlanningGoal_language", "Name_148"), hideInUI: false, -1, 0, new short[5] { 5, 10, 25, 20, 15 }, isPrioritizedGoal: false, 2, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(566)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(149, LocalStringManager.GetConfig("PlanningGoal_language", "Name_149"), hideInUI: false, -1, 0, new short[5] { 25, 15, 20, 5, 10 }, isPrioritizedGoal: false, 2, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(567)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(318),
			new StateConditionAndValue<StateKey>(37, "==", 8)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(150, LocalStringManager.GetConfig("PlanningGoal_language", "Name_150"), hideInUI: false, -1, 0, new short[5] { 15, 5, 20, 10, 25 }, isPrioritizedGoal: false, 2, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(568)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(317),
			new StateConditionAndValue<StateKey>(37, "==", 8)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(151, LocalStringManager.GetConfig("PlanningGoal_language", "Name_151"), hideInUI: false, -1, 0, new short[5] { 25, 10, 20, 5, 15 }, isPrioritizedGoal: false, 2, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(569)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(316),
			new StateConditionAndValue<StateKey>(37, ">=", 6)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(152, LocalStringManager.GetConfig("PlanningGoal_language", "Name_152"), hideInUI: false, -1, 0, new short[5] { 10, 15, 25, 5, 20 }, isPrioritizedGoal: false, 2, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(570)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(316),
			new StateConditionAndValue<StateKey>(37, ">=", 3)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(153, LocalStringManager.GetConfig("PlanningGoal_language", "Name_153"), hideInUI: false, -1, 0, new short[5] { 20, 10, 15, 5, 25 }, isPrioritizedGoal: false, 2, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(571)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(316),
			new StateConditionAndValue<StateKey>(37, ">=", 3)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(154, LocalStringManager.GetConfig("PlanningGoal_language", "Name_154"), hideInUI: false, -1, 0, new short[5] { 10, 25, 20, 15, 5 }, isPrioritizedGoal: false, 2, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(572)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(316)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(155, LocalStringManager.GetConfig("PlanningGoal_language", "Name_155"), hideInUI: false, -1, 0, new short[5] { 10, 15, 25, 5, 20 }, isPrioritizedGoal: false, 2, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(573)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(318),
			new StateConditionAndValue<StateKey>(37, "==", 7)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(156, LocalStringManager.GetConfig("PlanningGoal_language", "Name_156"), hideInUI: false, -1, 0, new short[5] { 5, 20, 25, 10, 15 }, isPrioritizedGoal: false, 2, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(574)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(157, LocalStringManager.GetConfig("PlanningGoal_language", "Name_157"), hideInUI: false, -1, 0, new short[5] { 5, 10, 25, 20, 15 }, isPrioritizedGoal: false, 2, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(575)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(158, LocalStringManager.GetConfig("PlanningGoal_language", "Name_158"), hideInUI: false, -1, 0, new short[5] { 10, 25, 20, 15, 5 }, isPrioritizedGoal: false, 2, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(576)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(159, LocalStringManager.GetConfig("PlanningGoal_language", "Name_159"), hideInUI: false, -1, 0, new short[5] { 10, 20, 25, 15, 5 }, isPrioritizedGoal: false, 2, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(577)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(160, LocalStringManager.GetConfig("PlanningGoal_language", "Name_160"), hideInUI: false, -1, 0, new short[5] { 5, 20, 25, 15, 10 }, isPrioritizedGoal: false, 2, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(578)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(161, LocalStringManager.GetConfig("PlanningGoal_language", "Name_161"), hideInUI: false, -1, 0, new short[5] { 20, 25, 15, 10, 5 }, isPrioritizedGoal: false, 2, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(579)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(64)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(162, LocalStringManager.GetConfig("PlanningGoal_language", "Name_162"), hideInUI: false, -1, 25, new short[5], isPrioritizedGoal: false, 2, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(580)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(163, LocalStringManager.GetConfig("PlanningGoal_language", "Name_163"), hideInUI: false, -1, 25, new short[5], isPrioritizedGoal: false, 2, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(581)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(164, LocalStringManager.GetConfig("PlanningGoal_language", "Name_164"), hideInUI: false, -1, 25, new short[5], isPrioritizedGoal: false, 2, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(582)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(165, LocalStringManager.GetConfig("PlanningGoal_language", "Name_165"), hideInUI: false, -1, 0, new short[5] { 5, 15, 25, 20, 10 }, isPrioritizedGoal: false, 2, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(583)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(362, ">=", 1000)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(166, LocalStringManager.GetConfig("PlanningGoal_language", "Name_166"), hideInUI: false, -1, 0, new short[5] { 5, 10, 20, 25, 15 }, isPrioritizedGoal: false, 2, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(584)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(167, LocalStringManager.GetConfig("PlanningGoal_language", "Name_167"), hideInUI: false, -1, 0, new short[5] { 25, 20, 15, 5, 10 }, isPrioritizedGoal: false, 2, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(585)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(168, LocalStringManager.GetConfig("PlanningGoal_language", "Name_168"), hideInUI: false, -1, 300, new short[5], isPrioritizedGoal: false, 1, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(107)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(65, ">=", 20)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(65, ">=", 10),
			new StateConditionAndValue<StateKey>(304)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(296)
		}, null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(169, LocalStringManager.GetConfig("PlanningGoal_language", "Name_169"), hideInUI: false, -1, 300, new short[5], isPrioritizedGoal: false, 1, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(107)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(65, ">=", 40)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(65, ">=", 20),
			new StateConditionAndValue<StateKey>(304)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(296)
		}, null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(170, LocalStringManager.GetConfig("PlanningGoal_language", "Name_170"), hideInUI: false, -1, 300, new short[5], isPrioritizedGoal: false, 1, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(107)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(65, ">=", 60)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(65, ">=", 30),
			new StateConditionAndValue<StateKey>(304)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(296)
		}, null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(171, LocalStringManager.GetConfig("PlanningGoal_language", "Name_171"), hideInUI: false, -1, 300, new short[5], isPrioritizedGoal: false, 1, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(107)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(65, ">=", 80)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(65, ">=", 40),
			new StateConditionAndValue<StateKey>(304)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(296)
		}, null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(172, LocalStringManager.GetConfig("PlanningGoal_language", "Name_172"), hideInUI: false, -1, 300, new short[5], isPrioritizedGoal: false, 1, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(107)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(65, ">=", 100)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(65, ">=", 50),
			new StateConditionAndValue<StateKey>(304)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(296)
		}, null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(173, LocalStringManager.GetConfig("PlanningGoal_language", "Name_173"), hideInUI: false, -1, 300, new short[5], isPrioritizedGoal: false, 1, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(107)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(65, ">=", 120)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(65, ">=", 60),
			new StateConditionAndValue<StateKey>(304)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(296)
		}, null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(174, LocalStringManager.GetConfig("PlanningGoal_language", "Name_174"), hideInUI: false, -1, 300, new short[5], isPrioritizedGoal: false, 1, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(107)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(65, ">=", 140)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(65, ">=", 70),
			new StateConditionAndValue<StateKey>(304)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(296)
		}, null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(175, LocalStringManager.GetConfig("PlanningGoal_language", "Name_175"), hideInUI: false, -1, 300, new short[5], isPrioritizedGoal: false, 1, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(107)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(65, ">=", 160)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(65, ">=", 80),
			new StateConditionAndValue<StateKey>(304)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(296)
		}, null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(176, LocalStringManager.GetConfig("PlanningGoal_language", "Name_176"), hideInUI: false, -1, 300, new short[5], isPrioritizedGoal: false, 1, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(107)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(65, ">=", 180)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(65, ">=", 90),
			new StateConditionAndValue<StateKey>(304)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(296)
		}, null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(177, LocalStringManager.GetConfig("PlanningGoal_language", "Name_177"), hideInUI: false, 6, 50, new short[5], isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(293, ">=", 1)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(471)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(178, LocalStringManager.GetConfig("PlanningGoal_language", "Name_178"), hideInUI: false, 6, 0, new short[5] { 20, 25, 15, 5, 10 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(460, ">=", 2)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(42, ">=", 0)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(36, ">=", -125)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(332)
		}, null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(179, LocalStringManager.GetConfig("PlanningGoal_language", "Name_179"), hideInUI: false, 6, 0, new short[5] { 25, 20, 15, 5, 10 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(461, ">=", 2)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(42, "<=", 0)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(36, "<=", 125)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(331)
		}, null, null, overwrite: false, null, recreateEveryMonth: false));
	}

	private void CreateItems3()
	{
		_dataArray.Add(new PlanningGoalItem(180, LocalStringManager.GetConfig("PlanningGoal_language", "Name_180"), hideInUI: false, 6, 0, new short[5] { 20, 25, 15, 5, 10 }, isPrioritizedGoal: false, 1, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(462, ">=", 2)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(42, ">=", 0)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(36, ">=", -125)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(332)
		}, null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(181, LocalStringManager.GetConfig("PlanningGoal_language", "Name_181"), hideInUI: false, 6, 0, new short[5] { 25, 20, 15, 5, 10 }, isPrioritizedGoal: false, 1, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(463, ">=", 2)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(42, "<=", 0)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(36, "<=", 125)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(331)
		}, null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(182, LocalStringManager.GetConfig("PlanningGoal_language", "Name_182"), hideInUI: false, 6, 0, new short[5] { 15, 25, 20, 10, 5 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(460, ">=", 2)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(183, LocalStringManager.GetConfig("PlanningGoal_language", "Name_183"), hideInUI: false, 6, 0, new short[5] { 15, 10, 5, 25, 20 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(461, ">=", 2)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(184, LocalStringManager.GetConfig("PlanningGoal_language", "Name_184"), hideInUI: false, 6, 0, new short[5] { 15, 25, 20, 10, 5 }, isPrioritizedGoal: false, 1, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(462, ">=", 2)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(185, LocalStringManager.GetConfig("PlanningGoal_language", "Name_185"), hideInUI: false, 6, 0, new short[5] { 15, 10, 5, 25, 20 }, isPrioritizedGoal: false, 1, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(463, ">=", 2)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(186, LocalStringManager.GetConfig("PlanningGoal_language", "Name_186"), hideInUI: false, 6, 0, new short[5] { 5, 10, 15, 25, 20 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(460, ">=", 2)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(42, "<=", 0)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(36, "<=", 125)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(331)
		}, null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(187, LocalStringManager.GetConfig("PlanningGoal_language", "Name_187"), hideInUI: false, 6, 0, new short[5] { 5, 10, 15, 20, 25 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(461, ">=", 2)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(42, ">=", 0)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(36, ">=", -125)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(332)
		}, null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(188, LocalStringManager.GetConfig("PlanningGoal_language", "Name_188"), hideInUI: false, 6, 0, new short[5] { 5, 10, 15, 25, 20 }, isPrioritizedGoal: false, 1, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(462, ">=", 2)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(42, "<=", 0)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(36, "<=", 125)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(331)
		}, null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(189, LocalStringManager.GetConfig("PlanningGoal_language", "Name_189"), hideInUI: false, 6, 0, new short[5] { 5, 10, 15, 20, 25 }, isPrioritizedGoal: false, 1, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(463, ">=", 2)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(42, ">=", 0)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(36, ">=", -125)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(332)
		}, null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(190, LocalStringManager.GetConfig("PlanningGoal_language", "Name_190"), hideInUI: false, 6, 0, new short[5] { 25, 20, 15, 5, 10 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(607, ">=", 1)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(459, ">=", 3)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(307)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(191, LocalStringManager.GetConfig("PlanningGoal_language", "Name_191"), hideInUI: false, 6, 0, new short[5] { 25, 20, 15, 5, 10 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(608, ">=", 1)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(459, ">=", 3)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(306)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(192, LocalStringManager.GetConfig("PlanningGoal_language", "Name_192"), hideInUI: false, 6, 0, new short[5] { 25, 20, 15, 5, 10 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(287, ">=", 1)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(459, ">=", 3)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(308)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(193, LocalStringManager.GetConfig("PlanningGoal_language", "Name_193"), hideInUI: false, 6, 0, new short[5] { 25, 20, 15, 5, 10 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(291, ">=", 1)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(459, ">=", 3)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(311)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(194, LocalStringManager.GetConfig("PlanningGoal_language", "Name_194"), hideInUI: false, 6, 0, new short[5] { 5, 15, 20, 25, 10 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(293, ">=", 1)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(459, ">=", 3)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(302)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(195, LocalStringManager.GetConfig("PlanningGoal_language", "Name_195"), hideInUI: false, 6, 0, new short[5] { 10, 25, 20, 5, 15 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(290, ">=", 1)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(459, ">=", 3)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(310)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(196, LocalStringManager.GetConfig("PlanningGoal_language", "Name_196"), hideInUI: false, 6, 0, new short[5] { 15, 25, 20, 5, 10 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(609, ">=", 1)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(459, ">=", 3)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(305)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(197, LocalStringManager.GetConfig("PlanningGoal_language", "Name_197"), hideInUI: false, 6, 0, new short[5] { 25, 20, 15, 5, 10 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(295, ">=", 1)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(459, ">=", 3)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(313)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(198, LocalStringManager.GetConfig("PlanningGoal_language", "Name_198"), hideInUI: false, 6, 0, new short[5] { 10, 15, 25, 5, 20 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(288, ">=", 1)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(459, ">=", 3)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(314)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(199, LocalStringManager.GetConfig("PlanningGoal_language", "Name_199"), hideInUI: false, 6, 0, new short[5] { 20, 5, 10, 15, 25 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(294, ">=", 1)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(461, ">=", 3)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(303)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(200, LocalStringManager.GetConfig("PlanningGoal_language", "Name_200"), hideInUI: false, 6, 0, new short[5] { 10, 25, 15, 20, 5 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(586)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(201, LocalStringManager.GetConfig("PlanningGoal_language", "Name_201"), hideInUI: false, 6, 0, new short[5] { 10, 25, 15, 20, 5 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(587)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(202, LocalStringManager.GetConfig("PlanningGoal_language", "Name_202"), hideInUI: false, 6, 0, new short[5] { 10, 25, 15, 20, 5 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(588)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(203, LocalStringManager.GetConfig("PlanningGoal_language", "Name_203"), hideInUI: false, 6, 0, new short[5] { 10, 25, 15, 20, 5 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(589)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(204, LocalStringManager.GetConfig("PlanningGoal_language", "Name_204"), hideInUI: false, 6, 0, new short[5] { 10, 15, 20, 25, 5 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(590)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(205, LocalStringManager.GetConfig("PlanningGoal_language", "Name_205"), hideInUI: false, 6, 0, new short[5] { 5, 10, 25, 20, 15 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(591)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(206, LocalStringManager.GetConfig("PlanningGoal_language", "Name_206"), hideInUI: false, 6, 0, new short[5] { 15, 25, 20, 10, 5 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(438)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(207, LocalStringManager.GetConfig("PlanningGoal_language", "Name_207"), hideInUI: false, 6, 0, new short[5] { 5, 10, 15, 25, 20 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(439)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(208, LocalStringManager.GetConfig("PlanningGoal_language", "Name_208"), hideInUI: false, 6, 0, new short[5] { 5, 10, 15, 25, 20 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(441)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(209, LocalStringManager.GetConfig("PlanningGoal_language", "Name_209"), hideInUI: false, 6, 25, new short[5], isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(384)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(210, LocalStringManager.GetConfig("PlanningGoal_language", "Name_210"), hideInUI: false, 6, 25, new short[5], isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(385)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(211, LocalStringManager.GetConfig("PlanningGoal_language", "Name_211"), hideInUI: false, 6, 25, new short[5], isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(386)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(212, LocalStringManager.GetConfig("PlanningGoal_language", "Name_212"), hideInUI: false, 6, 25, new short[5], isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(387)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(213, LocalStringManager.GetConfig("PlanningGoal_language", "Name_213"), hideInUI: false, 6, 25, new short[5], isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(388)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(214, LocalStringManager.GetConfig("PlanningGoal_language", "Name_214"), hideInUI: false, 6, 25, new short[5], isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(434)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(215, LocalStringManager.GetConfig("PlanningGoal_language", "Name_215"), hideInUI: false, 6, 25, new short[5], isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(435)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(216, LocalStringManager.GetConfig("PlanningGoal_language", "Name_216"), hideInUI: false, 6, 25, new short[5], isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(437)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(217, LocalStringManager.GetConfig("PlanningGoal_language", "Name_217"), hideInUI: false, 6, 25, new short[5], isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(436)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(218, LocalStringManager.GetConfig("PlanningGoal_language", "Name_218"), hideInUI: false, 6, 25, new short[5], isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(440)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(219, LocalStringManager.GetConfig("PlanningGoal_language", "Name_219"), hideInUI: false, 6, 0, new short[5] { 15, 20, 25, 5, 10 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(592)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(220, LocalStringManager.GetConfig("PlanningGoal_language", "Name_220"), hideInUI: false, 6, 0, new short[5] { 25, 30, 35, 15, 20 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(593)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(122, ">=", 25)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(296)
		}, new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(221, LocalStringManager.GetConfig("PlanningGoal_language", "Name_221"), hideInUI: false, 6, 0, new short[5] { 15, 20, 25, 5, 10 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(594)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(222, LocalStringManager.GetConfig("PlanningGoal_language", "Name_222"), hideInUI: false, 6, 0, new short[5] { 25, 30, 35, 15, 20 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(595)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(121, ">=", 25)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(296)
		}, new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(223, LocalStringManager.GetConfig("PlanningGoal_language", "Name_223"), hideInUI: false, 6, 0, new short[5] { 5, 15, 20, 25, 10 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(596)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(224, LocalStringManager.GetConfig("PlanningGoal_language", "Name_224"), hideInUI: false, 6, 0, new short[5] { 5, 15, 20, 25, 10 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(597)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(225, LocalStringManager.GetConfig("PlanningGoal_language", "Name_225"), hideInUI: false, 6, 250, new short[5], isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(56, ">=", 36, 46)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new sbyte[1], null, overwrite: true, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(226, LocalStringManager.GetConfig("PlanningGoal_language", "Name_226"), hideInUI: false, 6, 250, new short[5], isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(60, 0)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(296),
			new StateConditionAndValue<StateKey>(5, ">=", 18)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new sbyte[1], null, overwrite: true, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(227, LocalStringManager.GetConfig("PlanningGoal_language", "Name_227"), hideInUI: false, 6, 250, new short[5], isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(55, ">%", 80, 56)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new sbyte[1], null, overwrite: true, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(228, LocalStringManager.GetConfig("PlanningGoal_language", "Name_228"), hideInUI: false, 6, 250, new short[5], isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(57, "<", 2)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new sbyte[2] { 2, 0 }, null, overwrite: true, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(229, LocalStringManager.GetConfig("PlanningGoal_language", "Name_229"), hideInUI: false, 6, 250, new short[5], isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(58, "<", 2)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new sbyte[2] { 3, 0 }, null, overwrite: true, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(230, LocalStringManager.GetConfig("PlanningGoal_language", "Name_230"), hideInUI: false, 6, 250, new short[5], isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(59, "<", 1500)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new sbyte[1], null, overwrite: true, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(231, LocalStringManager.GetConfig("PlanningGoal_language", "Name_231"), hideInUI: false, 6, 150, new short[5], isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(62, 0)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new sbyte[1] { 4 }, null, overwrite: true, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(232, LocalStringManager.GetConfig("PlanningGoal_language", "Name_232"), hideInUI: false, 6, 150, new short[5], isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(43, ">=", 0)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new sbyte[1], null, overwrite: true, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(233, LocalStringManager.GetConfig("PlanningGoal_language", "Name_233"), hideInUI: false, 6, 50, new short[5], isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(52, ">%", 60, 53)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new sbyte[1], null, overwrite: true, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(234, LocalStringManager.GetConfig("PlanningGoal_language", "Name_234"), hideInUI: false, 6, 25, new short[5], isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(6, ">%", 50, 20)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new sbyte[2] { 1, 0 }, null, overwrite: true, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(235, LocalStringManager.GetConfig("PlanningGoal_language", "Name_235"), hideInUI: false, 6, 0, new short[5] { 10, 5, 20, 15, 25 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(48, ">=", 0, 0)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new sbyte[1], null, overwrite: true, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(236, LocalStringManager.GetConfig("PlanningGoal_language", "Name_236"), hideInUI: false, 6, 0, new short[5] { 10, 15, 25, 5, 20 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(355, ">=", 0, 1)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new sbyte[2] { 5, 0 }, null, overwrite: true, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(237, LocalStringManager.GetConfig("PlanningGoal_language", "Name_237"), hideInUI: false, 6, 0, new short[5] { 10, 15, 20, 25, 5 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(365, "<=%", 50, 39)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new sbyte[2] { 5, 0 }, null, overwrite: true, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(238, LocalStringManager.GetConfig("PlanningGoal_language", "Name_238"), hideInUI: false, 6, 0, new short[5] { 10, 15, 25, 5, 20 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(391)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new sbyte[2] { 6, 11 }, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(239, LocalStringManager.GetConfig("PlanningGoal_language", "Name_239"), hideInUI: false, 6, 0, new short[5] { 10, 15, 20, 25, 5 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(112, "<=%", 50, 40)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new sbyte[1], null, overwrite: false, null, recreateEveryMonth: false));
	}

	private void CreateItems4()
	{
		_dataArray.Add(new PlanningGoalItem(240, LocalStringManager.GetConfig("PlanningGoal_language", "Name_240"), hideInUI: false, 6, 25, new short[5], isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(394, ">=", 0, 395)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new sbyte[2] { 6, 12 }, new EPlanningGoalValidator[1], overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(241, LocalStringManager.GetConfig("PlanningGoal_language", "Name_241"), hideInUI: false, 6, 0, new short[5] { 5, 10, 15, 25, 20 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(441)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new sbyte[1] { 3 }, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(242, LocalStringManager.GetConfig("PlanningGoal_language", "Name_242"), hideInUI: false, 6, 0, new short[5] { 15, 5, 10, 20, 25 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(442)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new sbyte[1] { 17 }, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(243, LocalStringManager.GetConfig("PlanningGoal_language", "Name_243"), hideInUI: false, 6, 0, new short[5] { 10, 25, 5, 20, 15 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(443)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new sbyte[1] { 18 }, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(244, LocalStringManager.GetConfig("PlanningGoal_language", "Name_244"), hideInUI: false, 6, 0, new short[5] { 5, 10, 25, 20, 15 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(444)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new sbyte[2] { 6, 12 }, new EPlanningGoalValidator[1], overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(245, LocalStringManager.GetConfig("PlanningGoal_language", "Name_245"), hideInUI: false, 6, 0, new short[5] { 5, 10, 25, 20, 15 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(451)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new sbyte[1] { 17 }, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(246, LocalStringManager.GetConfig("PlanningGoal_language", "Name_246"), hideInUI: false, 6, 0, new short[5] { 15, 5, 10, 20, 25 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(195, ">=", 0, 3)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new sbyte[2] { 7, 0 }, null, overwrite: true, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(247, LocalStringManager.GetConfig("PlanningGoal_language", "Name_247"), hideInUI: false, 6, 0, new short[5] { 10, 25, 5, 20, 15 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(227, ">=", 0, 4)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new sbyte[2] { 8, 0 }, null, overwrite: true, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(248, LocalStringManager.GetConfig("PlanningGoal_language", "Name_248"), hideInUI: false, 6, 25, new short[5], isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(111, ">=", 0, 109)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new sbyte[1], null, overwrite: true, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(249, LocalStringManager.GetConfig("PlanningGoal_language", "Name_249"), hideInUI: false, 9, 0, new short[5] { 10, 15, 20, 25, 5 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(276, ">=", 1)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new sbyte[1] { 9 }, null, overwrite: true, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(250, LocalStringManager.GetConfig("PlanningGoal_language", "Name_250"), hideInUI: false, 6, 0, new short[5] { 15, 5, 10, 25, 20 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(286, ">=", 1)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new sbyte[1] { 9 }, null, overwrite: true, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(251, LocalStringManager.GetConfig("PlanningGoal_language", "Name_251"), hideInUI: false, 9, 0, new short[5] { 10, 15, 20, 25, 5 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(276, ">=", 999)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new sbyte[1] { 9 }, null, overwrite: true, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(252, LocalStringManager.GetConfig("PlanningGoal_language", "Name_252"), hideInUI: false, 6, 0, new short[5] { 15, 5, 10, 25, 20 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(286, ">=", 999)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new sbyte[1] { 9 }, null, overwrite: true, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(253, LocalStringManager.GetConfig("PlanningGoal_language", "Name_253"), hideInUI: false, -1, 100, new short[5], isPrioritizedGoal: true, 1, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(478)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new sbyte[1] { 13 }, null, overwrite: true, "DejaVu", recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(254, LocalStringManager.GetConfig("PlanningGoal_language", "Name_254"), hideInUI: false, -1, 0, new short[5] { 90, 90, 90, 90, 90 }, isPrioritizedGoal: true, 1, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(479)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new sbyte[2] { 13, 15 }, null, overwrite: true, "Appointment", recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(255, LocalStringManager.GetConfig("PlanningGoal_language", "Name_255"), hideInUI: false, -1, 150, new short[5], isPrioritizedGoal: true, 1, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(484)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new sbyte[2] { 14, 15 }, null, overwrite: true, "GuardTreasury", recreateEveryMonth: true));
		_dataArray.Add(new PlanningGoalItem(256, LocalStringManager.GetConfig("PlanningGoal_language", "Name_256"), hideInUI: false, -1, 0, new short[5] { 80, 40, 50, 60, 70 }, isPrioritizedGoal: true, 1, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(485)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new sbyte[1] { 13 }, null, overwrite: false, "HuntFugitive", recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(257, LocalStringManager.GetConfig("PlanningGoal_language", "Name_257"), hideInUI: false, -1, 0, new short[5] { 40, 50, 60, 80, 70 }, isPrioritizedGoal: true, 1, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(486)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new sbyte[1] { 15 }, null, overwrite: true, "EscapeFromPrison", recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(258, LocalStringManager.GetConfig("PlanningGoal_language", "Name_258"), hideInUI: false, -1, 0, new short[5] { 70, 60, 80, 40, 50 }, isPrioritizedGoal: true, 1, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(487)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new sbyte[1] { 14 }, null, overwrite: true, "SeekAsylum", recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(259, LocalStringManager.GetConfig("PlanningGoal_language", "Name_259"), hideInUI: false, -1, 100, new short[5], isPrioritizedGoal: true, 1, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(488)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new sbyte[2] { 13, 14 }, null, overwrite: false, "EscortPrisoner", recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(260, LocalStringManager.GetConfig("PlanningGoal_language", "Name_260"), hideInUI: false, -1, 200, new short[5], isPrioritizedGoal: true, 1, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(473)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new sbyte[1] { 15 }, null, overwrite: true, "VillagerRoleArrangement", recreateEveryMonth: true));
		_dataArray.Add(new PlanningGoalItem(261, LocalStringManager.GetConfig("PlanningGoal_language", "Name_261"), hideInUI: false, 9, 0, new short[5] { 50, 50, 50, 50, 50 }, isPrioritizedGoal: true, 1, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(317)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new sbyte[1] { 14 }, null, overwrite: true, "JoinOrganization", recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(262, LocalStringManager.GetConfig("PlanningGoal_language", "Name_262"), hideInUI: false, 9, 0, new short[5] { 80, 70, 60, 50, 40 }, isPrioritizedGoal: true, 3, new int[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(49, ">=", 0, 86)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(480)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new sbyte[1] { 13 }, null, overwrite: false, "ProtectFriendOrFamily", recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(263, LocalStringManager.GetConfig("PlanningGoal_language", "Name_263"), hideInUI: false, 9, 0, new short[5] { 80, 70, 60, 50, 40 }, isPrioritizedGoal: true, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(481)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new sbyte[1] { 13 }, new EPlanningGoalValidator[1] { EPlanningGoalValidator.TargetCharIsNotNearbyFree }, overwrite: false, "RescueFriendOrFamily", recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(264, LocalStringManager.GetConfig("PlanningGoal_language", "Name_264"), hideInUI: false, 6, 0, new short[5] { 70, 60, 80, 40, 50 }, isPrioritizedGoal: true, 1, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(432, ">=", 0, 433)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new sbyte[1] { 21 }, null, overwrite: true, "MournForTheDead", recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(265, LocalStringManager.GetConfig("PlanningGoal_language", "Name_265"), hideInUI: false, 9, 0, new short[5] { 40, 50, 70, 80, 60 }, isPrioritizedGoal: true, 1, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(482)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new sbyte[1] { 15 }, null, overwrite: false, "FindTreasure", recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(266, LocalStringManager.GetConfig("PlanningGoal_language", "Name_266"), hideInUI: false, 9, 0, new short[5] { 40, 50, 70, 80, 60 }, isPrioritizedGoal: true, 1, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(476)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new sbyte[2] { 16, 15 }, null, overwrite: true, "FindSpecialMaterial", recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(267, LocalStringManager.GetConfig("PlanningGoal_language", "Name_267"), hideInUI: false, 9, 100, new short[5], isPrioritizedGoal: true, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(477)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new sbyte[2] { 13, 7 }, null, overwrite: true, "ContestForLegendaryBook", recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(268, LocalStringManager.GetConfig("PlanningGoal_language", "Name_268"), hideInUI: false, 6, 100, new short[5], isPrioritizedGoal: true, 1, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(483)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new sbyte[1] { 13 }, null, overwrite: true, "AdoptInfant", recreateEveryMonth: true));
		_dataArray.Add(new PlanningGoalItem(269, LocalStringManager.GetConfig("PlanningGoal_language", "Name_269"), hideInUI: false, 9, 300, new short[5], isPrioritizedGoal: true, 1, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(489, ">=", 999)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new sbyte[1] { 13 }, null, overwrite: true, "SectStoryBaihuaToCureManic", recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(270, LocalStringManager.GetConfig("PlanningGoal_language", "Name_270"), hideInUI: false, 9, 300, new short[5], isPrioritizedGoal: true, 1, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(491, ">=", 999)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new sbyte[1] { 15 }, null, overwrite: true, "SectStoryShixiangToFightEnemy ", recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(271, LocalStringManager.GetConfig("PlanningGoal_language", "Name_271"), hideInUI: false, 9, 200, new short[5], isPrioritizedGoal: true, 1, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(492, ">=", 999)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new sbyte[1] { 13 }, null, overwrite: true, "HuntTaiwu", recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(272, LocalStringManager.GetConfig("PlanningGoal_language", "Name_272"), hideInUI: false, 3, 100, new short[5], isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(471)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new sbyte[1] { 13 }, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(273, LocalStringManager.GetConfig("PlanningGoal_language", "Name_273"), hideInUI: true, -1, 0, new short[5] { 100, 100, 100, 100, 100 }, isPrioritizedGoal: false, 3, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(459, ">=", 3)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(296)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], null, null, overwrite: false, null, recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(274, LocalStringManager.GetConfig("PlanningGoal_language", "Name_274"), hideInUI: false, 9, 0, new short[5] { 60, 20, 40, 100, 80 }, isPrioritizedGoal: true, 3, new int[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(321, 0)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(612)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new sbyte[1] { 13 }, null, overwrite: false, "GetRevenge", recreateEveryMonth: false));
		_dataArray.Add(new PlanningGoalItem(275, LocalStringManager.GetConfig("PlanningGoal_language", "Name_275"), hideInUI: false, -1, 10, new short[5], isPrioritizedGoal: true, 1, new int[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(615)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new sbyte[1] { 15 }, null, overwrite: true, "ReturnHome", recreateEveryMonth: true));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<PlanningGoalItem>(276);
		CreateItems0();
		CreateItems1();
		CreateItems2();
		CreateItems3();
		CreateItems4();
	}
}

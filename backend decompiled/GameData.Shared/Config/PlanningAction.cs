using System;
using System.Collections.Generic;
using Config.Common;
using Config.ConfigCells.Character;
using GameData.ActionPlanning.MonthlyAI;
using GameData.ActionPlanning.State;

namespace Config;

[Serializable]
public class PlanningAction : ConfigData<PlanningActionItem, int>
{
	/// <summary>
	/// 配置表实例
	/// </summary>
	public static PlanningAction Instance = new PlanningAction();

	private readonly HashSet<string> RequiredFields = new HashSet<string>
	{
		"Parameters", "PersonalityType", "ProfessionRequirement", "RequiredOrgMembers", "SelfRestrictions", "Preconditions", "TargetCharacterConditions", "Effects", "DeEffects", "RefuseAppointment",
		"MonthlyNotification", "ExecuteSelfLifeRecord", "ExecuteTargetLifeRecord", "RandomItemRewards", "SelfMatcher", "TargetMatcher", "TemplateId", "ImplementationPath", "CharacterSelectCountRange"
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
		_dataArray.Add(new PlanningActionItem(0, null, new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 4, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[3]
		{
			new StateEffect<StateKey>(381),
			new StateEffect<StateKey>(356, "+"),
			new StateEffect<StateKey>(355, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_0"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(1, null, new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 4, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[3]
		{
			new StateEffect<StateKey>(377),
			new StateEffect<StateKey>(358, "+"),
			new StateEffect<StateKey>(355, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_1"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(2, null, new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 4, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[3]
		{
			new StateEffect<StateKey>(378),
			new StateEffect<StateKey>(357, "+"),
			new StateEffect<StateKey>(355, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_2"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(3, null, new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 4, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[3]
		{
			new StateEffect<StateKey>(379),
			new StateEffect<StateKey>(360, "+"),
			new StateEffect<StateKey>(355, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_3"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(4, null, new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 4, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[3]
		{
			new StateEffect<StateKey>(380),
			new StateEffect<StateKey>(359, "+"),
			new StateEffect<StateKey>(355, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_4"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(5, null, new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 4, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[3]
		{
			new StateEffect<StateKey>(382),
			new StateEffect<StateKey>(361, "+"),
			new StateEffect<StateKey>(355, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_5"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(6, null, new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 4, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[3]
		{
			new StateEffect<StateKey>(383),
			new StateEffect<StateKey>(361, "+"),
			new StateEffect<StateKey>(355, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_6"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(7, null, new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 0, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(356, ">=%", 20, 39)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[3]
		{
			new StateEffect<StateKey>(388),
			new StateEffect<StateKey>(402),
			new StateEffect<StateKey>(391)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_7"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(8, null, new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 0, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(358, ">=%", 20, 39)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[3]
		{
			new StateEffect<StateKey>(384),
			new StateEffect<StateKey>(404),
			new StateEffect<StateKey>(391)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_8"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(9, null, new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 0, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(357, ">=%", 20, 39)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[3]
		{
			new StateEffect<StateKey>(385),
			new StateEffect<StateKey>(403),
			new StateEffect<StateKey>(391)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_9"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(10, null, new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 0, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(360, ">=%", 20, 39)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[3]
		{
			new StateEffect<StateKey>(386),
			new StateEffect<StateKey>(406),
			new StateEffect<StateKey>(391)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_10"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(11, null, new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 0, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(359, ">=%", 20, 39)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[3]
		{
			new StateEffect<StateKey>(387),
			new StateEffect<StateKey>(405),
			new StateEffect<StateKey>(391)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_11"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(12, null, new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 0, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(361, ">=%", 20, 39)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[3]
		{
			new StateEffect<StateKey>(389),
			new StateEffect<StateKey>(407),
			new StateEffect<StateKey>(391)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_12"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(13, null, new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 0, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(361, ">=%", 20, 39)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[3]
		{
			new StateEffect<StateKey>(390),
			new StateEffect<StateKey>(408),
			new StateEffect<StateKey>(391)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_13"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(14, "LifeSkillCraftingAction", new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 4, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(404),
			new StateConditionAndValue<StateKey>(234, ">=", 200)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[3]
		{
			new StateEffect<StateKey>(434),
			new StateEffect<StateKey>(391),
			new StateEffect<StateKey>(49, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_14"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(15, "LifeSkillCraftingAction", new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 4, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(403),
			new StateConditionAndValue<StateKey>(235, ">=", 200)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[3]
		{
			new StateEffect<StateKey>(435),
			new StateEffect<StateKey>(391),
			new StateEffect<StateKey>(49, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_15"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(16, "LifeSkillCraftingAction", new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 4, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(405),
			new StateConditionAndValue<StateKey>(239, ">=", 200)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[3]
		{
			new StateEffect<StateKey>(436),
			new StateEffect<StateKey>(391),
			new StateEffect<StateKey>(49, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_16"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(17, "LifeSkillCraftingAction", new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 4, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(406),
			new StateConditionAndValue<StateKey>(238, ">=", 200)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[3]
		{
			new StateEffect<StateKey>(437),
			new StateEffect<StateKey>(391),
			new StateEffect<StateKey>(49, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_17"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(18, "LifeSkillCraftingAction", new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 2, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(402),
			new StateConditionAndValue<StateKey>(242, ">=", 200)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[3]
		{
			new StateEffect<StateKey>(440),
			new StateEffect<StateKey>(421),
			new StateEffect<StateKey>(391)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_18"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(19, "LifeSkillCraftingAction", new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 0, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(407),
			new StateConditionAndValue<StateKey>(236, ">=", 200)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[3]
		{
			new StateEffect<StateKey>(438),
			new StateEffect<StateKey>(422),
			new StateEffect<StateKey>(391)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_19"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(20, "LifeSkillCraftingAction", new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 0, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(407),
			new StateConditionAndValue<StateKey>(236, ">=", 200)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[3]
		{
			new StateEffect<StateKey>(438),
			new StateEffect<StateKey>(415),
			new StateEffect<StateKey>(391)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_20"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(21, "LifeSkillCraftingAction", new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 0, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(407),
			new StateConditionAndValue<StateKey>(236, ">=", 200)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[3]
		{
			new StateEffect<StateKey>(438),
			new StateEffect<StateKey>(418),
			new StateEffect<StateKey>(391)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_21"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(22, "LifeSkillCraftingAction", new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 0, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(407),
			new StateConditionAndValue<StateKey>(236, ">=", 200)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[3]
		{
			new StateEffect<StateKey>(438),
			new StateEffect<StateKey>(417),
			new StateEffect<StateKey>(391)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_22"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(23, "LifeSkillCraftingAction", new sbyte[0], new int[5] { 30, 10, 100, 75, 50 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(408),
			new StateConditionAndValue<StateKey>(237, ">=", 200)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[4]
		{
			new StateEffect<StateKey>(439),
			new StateEffect<StateKey>(416),
			new StateEffect<StateKey>(423),
			new StateEffect<StateKey>(391)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_23"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(24, null, new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 4, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[0], new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_24"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(25, null, new sbyte[0], new int[5] { 30, 10, 50, 100, 75 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[0], new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_25"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(26, "WealthDemandRepairItemAction", new sbyte[2] { 6, 12 }, new int[5] { 10, 75, 100, 50, 30 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 0)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(244, ">=%", 50, 264)
		}, new StateEffect<StateKey>[3]
		{
			new StateEffect<StateKey>(394, "+"),
			new StateEffect<StateKey>(49, "+"),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RequestTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_26"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(27, "WealthDemandAddPoisonToItemAction", new sbyte[1] { 3 }, new int[5] { 30, 10, 50, 100, 75 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 0)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(237, ">=%", 50, 257)
		}, new StateEffect<StateKey>[4]
		{
			new StateEffect<StateKey>(441),
			new StateEffect<StateKey>(49, "+"),
			new StateEffect<StateKey>(465, "+"),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RequestTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_27"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(28, "SpendResourceByGiveResourceAction", new sbyte[2] { 5, 0 }, new int[5] { 30, 75, 100, 50, 10 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(355, ">=%", 20, 39)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 6001)
		}, new StateEffect<StateKey>[3]
		{
			new StateEffect<StateKey>(81, "+"),
			new StateEffect<StateKey>(460, "+"),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.CloseTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_28"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(29, "RandomGiveResourceAction", new sbyte[0], new int[5] { 75, 100, 50, 30, 10 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(355, ">=%", 20, 39)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 0),
			new StateConditionAndValue<StateKey>(42, ">=", 25)
		}, new StateEffect<StateKey>[4]
		{
			new StateEffect<StateKey>(81, "+"),
			new StateEffect<StateKey>(464, "+"),
			new StateEffect<StateKey>(42, "+"),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.CloseTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_29"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(30, "RandomGiveResourceAction", new sbyte[0], new int[5] { 10, 30, 50, 100, 75 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(355, ">=%", 20, 39)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 0),
			new StateConditionAndValue<StateKey>(42, "<=", -25)
		}, new StateEffect<StateKey>[3]
		{
			new StateEffect<StateKey>(81, "+"),
			new StateEffect<StateKey>(465, "+"),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.CloseTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_30"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(31, "SpendItemByGiveItemAction", new sbyte[2] { 6, 11 }, new int[5] { 30, 75, 100, 50, 10 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(391)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 6001)
		}, new StateEffect<StateKey>[3]
		{
			new StateEffect<StateKey>(81, "+"),
			new StateEffect<StateKey>(460, "+"),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.CloseTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_31"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(32, "SpendItemByGiveItemAction", new sbyte[0], new int[5] { 75, 100, 50, 30, 10 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(391)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 0),
			new StateConditionAndValue<StateKey>(42, ">=", 25)
		}, new StateEffect<StateKey>[4]
		{
			new StateEffect<StateKey>(81, "+"),
			new StateEffect<StateKey>(464, "+"),
			new StateEffect<StateKey>(42, "+"),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.CloseTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_32"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(33, "SpendItemByGiveItemAction", new sbyte[0], new int[5] { 10, 30, 50, 100, 75 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(391)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 0),
			new StateConditionAndValue<StateKey>(42, "<=", -25)
		}, new StateEffect<StateKey>[3]
		{
			new StateEffect<StateKey>(81, "+"),
			new StateEffect<StateKey>(465, "+"),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.CloseTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_33"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(34, "WealthDemandPurchaseItemAction", new sbyte[2] { 6, 11 }, new int[5] { 75, 75, 75, 75, 75 }, new int[7], 2, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(603, 0)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(362, ">=", 0, 2)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(391)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_34"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(35, "SpendItemBySellItemAction", new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 2, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(391)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[2]
		{
			new StateEffect<StateKey>(362, "+"),
			new StateEffect<StateKey>(355, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_35"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(36, "WealthDemandRequestItemAction", new sbyte[2] { 6, 11 }, new int[5] { 75, 75, 75, 75, 75 }, new int[7], 2, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 0)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[3]
		{
			new StateEffect<StateKey>(391),
			new StateEffect<StateKey>(459, "+"),
			new StateEffect<StateKey>(49, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RequestTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_36"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(37, "WealthDemandStealItemAction", new sbyte[2] { 6, 11 }, new int[5] { 0, 30, 50, 100, 75 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(81, "<=", 0)
		}, new StateEffect<StateKey>[5]
		{
			new StateEffect<StateKey>(391),
			new StateEffect<StateKey>(461, "+"),
			new StateEffect<StateKey>(49, "+"),
			new StateEffect<StateKey>(459, "+"),
			new StateEffect<StateKey>(81, "-")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.StealTarget, 25, EPlanningActionCharacterSelectRange.BlockRange, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_37"), -1, -1, -1, 0, 0, -3000, 0, new List<PresetInventoryItem>(), 82, 82, 2, 1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(38, "WealthDemandScamItemAction", new sbyte[2] { 6, 11 }, new int[5] { 0, 30, 50, 100, 75 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(81, "<=", 0)
		}, new StateEffect<StateKey>[5]
		{
			new StateEffect<StateKey>(391),
			new StateEffect<StateKey>(461, "+"),
			new StateEffect<StateKey>(49, "+"),
			new StateEffect<StateKey>(459, "+"),
			new StateEffect<StateKey>(81, "-")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.ScamTarget, 25, EPlanningActionCharacterSelectRange.BlockRange, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_38"), -1, -1, -1, 0, 0, -3000, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(39, "WealthDemandRobItemAction", new sbyte[2] { 6, 11 }, new int[5] { 30, 0, 50, 75, 100 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(81, "<=", 0)
		}, new StateEffect<StateKey>[5]
		{
			new StateEffect<StateKey>(391),
			new StateEffect<StateKey>(461, "+"),
			new StateEffect<StateKey>(49, "+"),
			new StateEffect<StateKey>(459, "+"),
			new StateEffect<StateKey>(81, "-")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RobTarget, 25, EPlanningActionCharacterSelectRange.BlockRange, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_39"), -1, -1, -1, 0, 0, -6000, 0, new List<PresetInventoryItem>(), 82, 82, 2, 1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(40, null, new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(111, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_40"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(41, "SpendResourceByExchangeResourceAction", new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 6, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(364, ">=%", 20, 39)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[2]
		{
			new StateEffect<StateKey>(358, "+"),
			new StateEffect<StateKey>(355, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_41"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(42, "SpendResourceByExchangeResourceAction", new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 6, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(364, ">=%", 20, 39)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[2]
		{
			new StateEffect<StateKey>(357, "+"),
			new StateEffect<StateKey>(355, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_42"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(43, "SpendResourceByExchangeResourceAction", new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 6, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(364, ">=%", 20, 39)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[2]
		{
			new StateEffect<StateKey>(359, "+"),
			new StateEffect<StateKey>(355, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_43"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(44, "SpendResourceByExchangeResourceAction", new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 6, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(364, ">=%", 20, 39)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[2]
		{
			new StateEffect<StateKey>(360, "+"),
			new StateEffect<StateKey>(355, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_44"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(45, "SpendResourceByExchangeResourceAction", new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 6, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(364, ">=%", 20, 39)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[2]
		{
			new StateEffect<StateKey>(356, "+"),
			new StateEffect<StateKey>(355, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_45"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(46, "SpendResourceByExchangeResourceAction", new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 6, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(364, ">=%", 20, 39)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[2]
		{
			new StateEffect<StateKey>(361, "+"),
			new StateEffect<StateKey>(355, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_46"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(47, "WealthDemandRequestResourceAction", new sbyte[2] { 5, 0 }, new int[5] { 75, 75, 75, 75, 75 }, new int[7], 6, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 0)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[3]
		{
			new StateEffect<StateKey>(355, "+"),
			new StateEffect<StateKey>(459, "+"),
			new StateEffect<StateKey>(49, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RequestTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_47"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(48, "WealthDemandStealResourceAction", new sbyte[2] { 5, 0 }, new int[5] { 0, 30, 50, 100, 75 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(81, "<=", 0)
		}, new StateEffect<StateKey>[5]
		{
			new StateEffect<StateKey>(355, "+"),
			new StateEffect<StateKey>(461, "+"),
			new StateEffect<StateKey>(49, "+"),
			new StateEffect<StateKey>(459, "+"),
			new StateEffect<StateKey>(81, "-")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.StealTarget, 25, EPlanningActionCharacterSelectRange.BlockRange, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_48"), -1, -1, -1, 0, 0, -3000, 0, new List<PresetInventoryItem>(), 82, 82, 2, 1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(49, "WealthDemandScamResourceAction", new sbyte[2] { 5, 0 }, new int[5] { 0, 30, 50, 100, 75 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(81, "<=", 0)
		}, new StateEffect<StateKey>[5]
		{
			new StateEffect<StateKey>(355, "+"),
			new StateEffect<StateKey>(461, "+"),
			new StateEffect<StateKey>(49, "+"),
			new StateEffect<StateKey>(459, "+"),
			new StateEffect<StateKey>(81, "-")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.ScamTarget, 25, EPlanningActionCharacterSelectRange.BlockRange, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_49"), -1, -1, -1, 0, 0, -3000, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(50, "WealthDemandRobResourceAction", new sbyte[2] { 5, 0 }, new int[5] { 30, 0, 50, 75, 100 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(81, "<=", 0)
		}, new StateEffect<StateKey>[5]
		{
			new StateEffect<StateKey>(355, "+"),
			new StateEffect<StateKey>(461, "+"),
			new StateEffect<StateKey>(49, "+"),
			new StateEffect<StateKey>(459, "+"),
			new StateEffect<StateKey>(81, "-")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RobTarget, 25, EPlanningActionCharacterSelectRange.BlockRange, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_50"), -1, -1, -1, 0, 0, -6000, 0, new List<PresetInventoryItem>(), 82, 82, 2, 1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(51, null, new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 5, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(391)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_51"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(52, "FindTreasureAction", new sbyte[1] { 15 }, new int[5] { 75, 75, 75, 75, 75 }, new int[7], 5, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(482)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_52"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(53, "WealthDemandRobGraveResourceAction", new sbyte[2] { 5, 0 }, new int[5] { 0, 30, 50, 100, 75 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(355, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_53"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(54, "WealthDemandRobGraveItemAction", new sbyte[2] { 6, 11 }, new int[5] { 0, 30, 50, 100, 75 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(391)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_54"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(55, "WealthDemandTakeTreasuryResourceAction", new sbyte[2] { 5, 0 }, new int[5] { 75, 75, 75, 75, 75 }, new int[7], 6, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(606, 0)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(427, ">=", 0, 604)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(355, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_55"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(56, "WealthDemandTakeTreasuryItemAction", new sbyte[2] { 6, 11 }, new int[5] { 75, 75, 75, 75, 75 }, new int[7], 6, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(606, 0)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(427, ">=", 0, 605)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(391)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_56"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(57, "SpendResourceByStoreTreasuryResourceAction", new sbyte[2] { 5, 0 }, new int[5] { 100, 100, 100, 100, 100 }, new int[7], 6, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(606, 0)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(355, ">=%", 20, 39)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(427, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_57"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(58, "SpendItemByStoreTreasuryItemAction", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], 6, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(606, 0)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(391)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(427, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_58"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(59, "GainExpByReadingAction", new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(599)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(48, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_59"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new PlanningActionItem(60, "GainExpByStrollAction", new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(48, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_60"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(61, null, new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 2, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 10001)
		}, new StateEffect<StateKey>[2]
		{
			new StateEffect<StateKey>(267),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_61"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(62, null, new sbyte[0], new int[5] { 100, 75, 50, 30, 0 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 6001),
			new StateConditionAndValue<StateKey>(42, ">=", 25)
		}, new StateEffect<StateKey>[4]
		{
			new StateEffect<StateKey>(267),
			new StateEffect<StateKey>(464, "+"),
			new StateEffect<StateKey>(42, "+"),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_62"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(63, null, new sbyte[0], new int[5] { 10, 30, 50, 75, 100 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 6001),
			new StateConditionAndValue<StateKey>(42, "<=", -25)
		}, new StateEffect<StateKey>[3]
		{
			new StateEffect<StateKey>(267),
			new StateEffect<StateKey>(465, "+"),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_63"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(64, null, new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 2, new int[0], new short[0], isAdultOnly: true, isNonTaiwuTeammate: false, isNonMonk: true, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 18001)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(270)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_64"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(65, null, new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 2, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 18001)
		}, new StateEffect<StateKey>[2]
		{
			new StateEffect<StateKey>(271),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_65"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(66, null, new sbyte[0], new int[5] { 100, 75, 50, 30, 0 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 14001),
			new StateConditionAndValue<StateKey>(42, ">=", 25)
		}, new StateEffect<StateKey>[4]
		{
			new StateEffect<StateKey>(271),
			new StateEffect<StateKey>(464, "+"),
			new StateEffect<StateKey>(42, "+"),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_66"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(67, null, new sbyte[0], new int[5] { 10, 30, 50, 75, 100 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 14001),
			new StateConditionAndValue<StateKey>(42, "<=", -25)
		}, new StateEffect<StateKey>[3]
		{
			new StateEffect<StateKey>(271),
			new StateEffect<StateKey>(465, "+"),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_67"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(68, null, new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 2, new int[0], new short[0], isAdultOnly: true, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 10001)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(272)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_68"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(69, null, new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 2, new int[0], new short[0], isAdultOnly: true, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 0)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(273)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_69"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(70, null, new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 3, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(81, "<=", 0)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(274)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_70"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(71, null, new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 6, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 18001)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(269)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_71"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(72, null, new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 6, new int[0], new short[0], isAdultOnly: true, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 14001)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(269)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_72"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(73, null, new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 6, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 6001)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(275)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_73"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(74, null, new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 6, new int[0], new short[0], isAdultOnly: true, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 6001)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(275)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_74"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(75, null, new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 0, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(81, "<=", 0),
			new StateConditionAndValue<StateKey>(308)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(277)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_75"), -1, -1, -1, 0, 0, -6000, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(76, null, new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 0, new int[0], new short[0], isAdultOnly: true, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(81, "<=", -10001),
			new StateConditionAndValue<StateKey>(310)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(280)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_76"), -1, -1, -1, 0, 0, -18000, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(77, null, new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 0, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(81, "<=", -10001),
			new StateConditionAndValue<StateKey>(311)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(281)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_77"), -1, -1, -1, 0, 0, -9000, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(78, null, new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 0, new int[0], new short[0], isAdultOnly: true, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(81, "<=", -10001),
			new StateConditionAndValue<StateKey>(312)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(282)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_78"), -1, -1, -1, 0, 0, -9000, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(79, null, new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 0, new int[0], new short[0], isAdultOnly: true, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(81, "<=", 0),
			new StateConditionAndValue<StateKey>(302)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(283)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_79"), -1, -1, -1, 0, 0, -9000, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(80, null, new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 0, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 22001),
			new StateConditionAndValue<StateKey>(303)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(284)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_80"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(81, "IdentityActionCommonSingleTarget", new sbyte[0], new int[5] { 30, 100, 75, 50, 10 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 0)
		}, new StateEffect<StateKey>[3]
		{
			new StateEffect<StateKey>(462, "+"),
			new StateEffect<StateKey>(81, "+"),
			new StateEffect<StateKey>(80, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.SameBlock, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_81"), 468, 1364, 1402, 0, 1, 3000, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(82, "IdentityActionCommonSingleTarget", new sbyte[0], new int[5] { 30, 10, 75, 100, 50 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(81, "<=", 0)
		}, new StateEffect<StateKey>[3]
		{
			new StateEffect<StateKey>(463, "+"),
			new StateEffect<StateKey>(81, "-"),
			new StateEffect<StateKey>(80, "-")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 0, EPlanningActionCharacterSelectRange.SameBlock, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_82"), 469, 1365, 1403, 0, -1, -3000, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(83, "GainExpByPlayCombatAction", new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 2, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(49, ">=%", 25, 86)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[3]
		{
			new StateEffect<StateKey>(48, "+"),
			new StateEffect<StateKey>(470, "+"),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_83"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 3, 0, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(84, "GainExpByBeatCombatAction", new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 3, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(49, ">=%", 50, 86)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[3]
		{
			new StateEffect<StateKey>(48, "+"),
			new StateEffect<StateKey>(469, "+"),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_84"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 3, 1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(85, "GainExpByLifeSkillBattleAction", new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(246, ">=", 200)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[3]
		{
			new StateEffect<StateKey>(48, "+"),
			new StateEffect<StateKey>(468, "+"),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_85"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 3, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(86, null, new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 2, new int[0], new short[0], isAdultOnly: true, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(471)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 3, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_86"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(87, null, new sbyte[0], new int[5] { 0, 30, 50, 100, 75 }, new int[7], -1, new int[0], new short[0], isAdultOnly: true, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(471)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 3, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_87"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(88, null, new sbyte[0], new int[5] { 0, 0, 50, 100, 75 }, new int[7], -1, new int[0], new short[0], isAdultOnly: true, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(471)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 0, EPlanningActionCharacterSelectRange.SameBlock, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_88"), -1, -1, -1, 0, 0, -18000, 0, new List<PresetInventoryItem>(), 82, 82, 6, 1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(89, "AttackAction", new sbyte[0], new int[5] { 100, 10, 0, 50, 75 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(49, ">=%", 50, 86),
			new StateConditionAndValue<StateKey>(81, "<=", -10001)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(81, "<=", -10001)
		}, new StateEffect<StateKey>[4]
		{
			new StateEffect<StateKey>(461, "+"),
			new StateEffect<StateKey>(467, "+"),
			new StateEffect<StateKey>(459, "+"),
			new StateEffect<StateKey>(81, "-")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.SameBlock, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_89"), -1, -1, -1, 0, 0, -9000, 0, new List<PresetInventoryItem>(), 82, 82, 3, 1, 0, 10, 80));
		_dataArray.Add(new PlanningActionItem(90, "AttackAction", new sbyte[0], new int[5] { 100, 75, 50, 0, 10 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(49, ">=%", 50, 86),
			new StateConditionAndValue<StateKey>(81, "<=", -6001)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(81, "<=", -6001),
			new StateConditionAndValue<StateKey>(42, "<=", -25)
		}, new StateEffect<StateKey>[6]
		{
			new StateEffect<StateKey>(461, "+"),
			new StateEffect<StateKey>(467, "+"),
			new StateEffect<StateKey>(464, "+"),
			new StateEffect<StateKey>(42, "+"),
			new StateEffect<StateKey>(459, "+"),
			new StateEffect<StateKey>(81, "-")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.SameBlock, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_90"), -1, -1, -1, 0, 0, -9000, 0, new List<PresetInventoryItem>(), 82, 82, 3, 1, 0, 10, 80));
		_dataArray.Add(new PlanningActionItem(91, "AttackAction", new sbyte[0], new int[5] { 10, 0, 50, 100, 75 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(49, ">=%", 50, 86),
			new StateConditionAndValue<StateKey>(81, "<=", -6001)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(81, "<=", -6001),
			new StateConditionAndValue<StateKey>(42, ">=", 25)
		}, new StateEffect<StateKey>[5]
		{
			new StateEffect<StateKey>(461, "+"),
			new StateEffect<StateKey>(467, "+"),
			new StateEffect<StateKey>(465, "+"),
			new StateEffect<StateKey>(459, "+"),
			new StateEffect<StateKey>(81, "-")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.SameBlock, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_91"), -1, -1, -1, 0, 0, -9000, 0, new List<PresetInventoryItem>(), 82, 82, 3, 1, 0, 10, 80));
		_dataArray.Add(new PlanningActionItem(92, null, new sbyte[0], new int[5] { 10, 0, 50, 75, 100 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(49, ">=%", 50, 86),
			new StateConditionAndValue<StateKey>(81, "<=", -18001)
		}, new StateConditionAndValue<StateKey>[3]
		{
			new StateConditionAndValue<StateKey>(45, ">=", 16),
			new StateConditionAndValue<StateKey>(46, ">=", 16),
			new StateConditionAndValue<StateKey>(81, "<=", -18001)
		}, new StateEffect<StateKey>[4]
		{
			new StateEffect<StateKey>(461, "+"),
			new StateEffect<StateKey>(107),
			new StateEffect<StateKey>(459, "+"),
			new StateEffect<StateKey>(81, "-")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 25, EPlanningActionCharacterSelectRange.SameBlock, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_92"), -1, -1, -1, 0, 0, -18000, 0, new List<PresetInventoryItem>(), 82, 82, 3, 2, 10, 20, 40));
		_dataArray.Add(new PlanningActionItem(93, null, new sbyte[0], new int[5] { 100, 75, 50, 0, 10 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(49, ">=%", 50, 86),
			new StateConditionAndValue<StateKey>(81, "<=", -14001)
		}, new StateConditionAndValue<StateKey>[4]
		{
			new StateConditionAndValue<StateKey>(45, ">=", 16),
			new StateConditionAndValue<StateKey>(46, ">=", 16),
			new StateConditionAndValue<StateKey>(81, "<=", -14001),
			new StateConditionAndValue<StateKey>(42, "<=", -25)
		}, new StateEffect<StateKey>[6]
		{
			new StateEffect<StateKey>(461, "+"),
			new StateEffect<StateKey>(107),
			new StateEffect<StateKey>(464, "+"),
			new StateEffect<StateKey>(42, "+"),
			new StateEffect<StateKey>(459, "+"),
			new StateEffect<StateKey>(81, "-")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 25, EPlanningActionCharacterSelectRange.SameBlock, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_93"), -1, -1, -1, 0, 0, -18000, 0, new List<PresetInventoryItem>(), 82, 82, 3, 2, 10, 20, 40));
		_dataArray.Add(new PlanningActionItem(94, null, new sbyte[0], new int[5] { 10, 0, 50, 75, 100 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(49, ">=%", 50, 86),
			new StateConditionAndValue<StateKey>(81, "<=", -14001)
		}, new StateConditionAndValue<StateKey>[4]
		{
			new StateConditionAndValue<StateKey>(45, ">=", 16),
			new StateConditionAndValue<StateKey>(46, ">=", 16),
			new StateConditionAndValue<StateKey>(81, "<=", -14001),
			new StateConditionAndValue<StateKey>(42, ">=", 25)
		}, new StateEffect<StateKey>[5]
		{
			new StateEffect<StateKey>(461, "+"),
			new StateEffect<StateKey>(107),
			new StateEffect<StateKey>(465, "+"),
			new StateEffect<StateKey>(459, "+"),
			new StateEffect<StateKey>(81, "-")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 25, EPlanningActionCharacterSelectRange.SameBlock, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_94"), -1, -1, -1, 0, 0, -18000, 0, new List<PresetInventoryItem>(), 82, 82, 3, 2, 10, 20, 40));
		_dataArray.Add(new PlanningActionItem(95, null, new sbyte[0], new int[5] { 10, 0, 50, 75, 100 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(49, ">=%", 50, 86),
			new StateConditionAndValue<StateKey>(81, "<=", -14001)
		}, new StateConditionAndValue<StateKey>[3]
		{
			new StateConditionAndValue<StateKey>(45, ">=", 16),
			new StateConditionAndValue<StateKey>(46, ">=", 16),
			new StateConditionAndValue<StateKey>(81, "<=", -14001)
		}, new StateEffect<StateKey>[4]
		{
			new StateEffect<StateKey>(461, "+"),
			new StateEffect<StateKey>(467, "+"),
			new StateEffect<StateKey>(459, "+"),
			new StateEffect<StateKey>(81, "-")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 25, EPlanningActionCharacterSelectRange.SameBlock, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_95"), -1, -1, -1, 0, 0, -9000, 0, new List<PresetInventoryItem>(), 82, 82, 3, 1, 0, 100, 0));
		_dataArray.Add(new PlanningActionItem(96, null, new sbyte[0], new int[5] { 100, 75, 50, 0, 10 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(49, ">=%", 50, 86),
			new StateConditionAndValue<StateKey>(81, "<=", -10001)
		}, new StateConditionAndValue<StateKey>[4]
		{
			new StateConditionAndValue<StateKey>(45, ">=", 16),
			new StateConditionAndValue<StateKey>(46, ">=", 16),
			new StateConditionAndValue<StateKey>(81, "<=", -10001),
			new StateConditionAndValue<StateKey>(42, "<=", -25)
		}, new StateEffect<StateKey>[6]
		{
			new StateEffect<StateKey>(461, "+"),
			new StateEffect<StateKey>(467, "+"),
			new StateEffect<StateKey>(464, "+"),
			new StateEffect<StateKey>(42, "+"),
			new StateEffect<StateKey>(459, "+"),
			new StateEffect<StateKey>(81, "-")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 25, EPlanningActionCharacterSelectRange.SameBlock, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_96"), -1, -1, -1, 0, 0, -9000, 0, new List<PresetInventoryItem>(), 82, 82, 3, 1, 0, 100, 0));
		_dataArray.Add(new PlanningActionItem(97, null, new sbyte[0], new int[5] { 10, 0, 50, 75, 100 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(49, ">=%", 50, 86),
			new StateConditionAndValue<StateKey>(81, "<=", -10001)
		}, new StateConditionAndValue<StateKey>[4]
		{
			new StateConditionAndValue<StateKey>(45, ">=", 16),
			new StateConditionAndValue<StateKey>(46, ">=", 16),
			new StateConditionAndValue<StateKey>(81, "<=", -10001),
			new StateConditionAndValue<StateKey>(42, ">=", 25)
		}, new StateEffect<StateKey>[5]
		{
			new StateEffect<StateKey>(461, "+"),
			new StateEffect<StateKey>(467, "+"),
			new StateEffect<StateKey>(465, "+"),
			new StateEffect<StateKey>(459, "+"),
			new StateEffect<StateKey>(81, "-")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 25, EPlanningActionCharacterSelectRange.SameBlock, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_97"), -1, -1, -1, 0, 0, -9000, 0, new List<PresetInventoryItem>(), 82, 82, 3, 1, 0, 100, 0));
		_dataArray.Add(new PlanningActionItem(98, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], 3, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 14001)
		}, new StateEffect<StateKey>[3]
		{
			new StateEffect<StateKey>(460, "+"),
			new StateEffect<StateKey>(466, "+"),
			new StateEffect<StateKey>(81, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_98"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, -1, 2, 1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(99, "RescueFriendOrFamilyAction", new sbyte[1] { 13 }, new int[5] { 100, 100, 100, 100, 100 }, new int[7], 3, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 14001)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(481)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_99"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, -1, 2, 1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(100, "PoisonAction", new sbyte[0], new int[5] { 10, 0, 50, 100, 75 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(81, "<=", 0)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(81, "<=", 0)
		}, new StateEffect<StateKey>[5]
		{
			new StateEffect<StateKey>(461, "+"),
			new StateEffect<StateKey>(467, "+"),
			new StateEffect<StateKey>(49, "+"),
			new StateEffect<StateKey>(459, "+"),
			new StateEffect<StateKey>(81, "-")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.SameBlock, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_100"), -1, -1, -1, 0, 0, -6000, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(101, "PlotHarmAction", new sbyte[0], new int[5] { 10, 0, 50, 100, 75 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(81, "<=", 0)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(81, "<=", 0)
		}, new StateEffect<StateKey>[5]
		{
			new StateEffect<StateKey>(461, "+"),
			new StateEffect<StateKey>(467, "+"),
			new StateEffect<StateKey>(49, "+"),
			new StateEffect<StateKey>(459, "+"),
			new StateEffect<StateKey>(81, "-")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.SameBlock, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_101"), -1, -1, -1, 0, 0, -6000, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(102, null, new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 3, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[0], new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_102"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, 1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(103, null, new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 3, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[0], new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_103"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, 1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(104, null, new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 3, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[0], new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_104"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, 1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(105, null, new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 3, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[0], new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_105"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, 1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(106, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[3]
		{
			new StateEffect<StateKey>(396),
			new StateEffect<StateKey>(49, "+"),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RequestTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_106"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 6, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(107, null, new sbyte[1] { 6 }, new int[5] { 75, 75, 75, 75, 75 }, new int[7], 3, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(391)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[5]
		{
			new StateEffect<StateKey>(48, "+"),
			new StateEffect<StateKey>(195, "+"),
			new StateEffect<StateKey>(49, "+"),
			new StateEffect<StateKey>(442),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_107"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(108, null, new sbyte[1] { 6 }, new int[5] { 75, 75, 75, 75, 75 }, new int[7], 1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(391)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[4]
		{
			new StateEffect<StateKey>(48, "+"),
			new StateEffect<StateKey>(227, "+"),
			new StateEffect<StateKey>(443),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_108"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(109, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[3]
		{
			new StateEffect<StateKey>(195, "+"),
			new StateEffect<StateKey>(451),
			new StateEffect<StateKey>(49, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_109"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(110, "StudyDemandBreakingAction", new sbyte[1] { 17 }, new int[5] { 100, 100, 100, 100, 100 }, new int[7], 6, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 0)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(195, ">=%", 50, 211)
		}, new StateEffect<StateKey>[4]
		{
			new StateEffect<StateKey>(195, "+"),
			new StateEffect<StateKey>(451),
			new StateEffect<StateKey>(49, "+"),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RequestTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_110"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(111, "TeachCombatSkillAction", new sbyte[0], new int[5] { 30, 100, 75, 50, 10 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 6001)
		}, new StateEffect<StateKey>[4]
		{
			new StateEffect<StateKey>(460, "+"),
			new StateEffect<StateKey>(447),
			new StateEffect<StateKey>(81, "+"),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.CloseTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_111"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(112, null, new sbyte[0], new int[5] { 75, 100, 50, 30, 10 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 0),
			new StateConditionAndValue<StateKey>(42, ">=", 25)
		}, new StateEffect<StateKey>[6]
		{
			new StateEffect<StateKey>(460, "+"),
			new StateEffect<StateKey>(447),
			new StateEffect<StateKey>(81, "+"),
			new StateEffect<StateKey>(464, "+"),
			new StateEffect<StateKey>(42, "+"),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.CloseTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_112"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(113, null, new sbyte[0], new int[5] { 10, 30, 50, 100, 75 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 0),
			new StateConditionAndValue<StateKey>(42, "<=", -25)
		}, new StateEffect<StateKey>[5]
		{
			new StateEffect<StateKey>(460, "+"),
			new StateEffect<StateKey>(447),
			new StateEffect<StateKey>(81, "+"),
			new StateEffect<StateKey>(465, "+"),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.CloseTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_113"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(114, "TeachLifeSkillAction", new sbyte[0], new int[5] { 30, 100, 75, 50, 10 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 6001)
		}, new StateEffect<StateKey>[4]
		{
			new StateEffect<StateKey>(460, "+"),
			new StateEffect<StateKey>(448),
			new StateEffect<StateKey>(81, "+"),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.CloseTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_114"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(115, null, new sbyte[0], new int[5] { 75, 100, 50, 30, 10 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 0),
			new StateConditionAndValue<StateKey>(42, ">=", 25)
		}, new StateEffect<StateKey>[6]
		{
			new StateEffect<StateKey>(460, "+"),
			new StateEffect<StateKey>(448),
			new StateEffect<StateKey>(81, "+"),
			new StateEffect<StateKey>(464, "+"),
			new StateEffect<StateKey>(42, "+"),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.CloseTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_115"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(116, null, new sbyte[0], new int[5] { 10, 30, 50, 100, 75 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 0),
			new StateConditionAndValue<StateKey>(42, "<=", -25)
		}, new StateEffect<StateKey>[5]
		{
			new StateEffect<StateKey>(460, "+"),
			new StateEffect<StateKey>(448),
			new StateEffect<StateKey>(81, "+"),
			new StateEffect<StateKey>(465, "+"),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.CloseTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_116"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(117, "StudyDemandReadCombatSkillAction", new sbyte[2] { 6, 12 }, new int[5] { 100, 100, 100, 100, 100 }, new int[7], 6, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(610)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 0)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[4]
		{
			new StateEffect<StateKey>(195, "+"),
			new StateEffect<StateKey>(49, "+"),
			new StateEffect<StateKey>(444),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RequestTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_117"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(118, "StudyDemandReadLifeSkillAction", new sbyte[2] { 6, 12 }, new int[5] { 100, 100, 100, 100, 100 }, new int[7], 6, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(611)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 0)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[3]
		{
			new StateEffect<StateKey>(227, "+"),
			new StateEffect<StateKey>(444),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RequestTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_118"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(119, "StudyDemandRequestCombatSkillAction", new sbyte[1] { 7 }, new int[5] { 100, 100, 100, 100, 100 }, new int[7], 6, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 0)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[4]
		{
			new StateEffect<StateKey>(195, "+"),
			new StateEffect<StateKey>(49, "+"),
			new StateEffect<StateKey>(442),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RequestTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_119"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
	}

	private void CreateItems2()
	{
		_dataArray.Add(new PlanningActionItem(120, "StudyDemandRequestLifeSkillAction", new sbyte[1] { 8 }, new int[5] { 100, 100, 100, 100, 100 }, new int[7], 6, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 0)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[3]
		{
			new StateEffect<StateKey>(227, "+"),
			new StateEffect<StateKey>(443),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RequestTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_120"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(121, "StudyDemandStealCombatSkillAction", new sbyte[1] { 7 }, new int[5] { 0, 30, 50, 100, 75 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(81, "<=", 0)
		}, new StateEffect<StateKey>[5]
		{
			new StateEffect<StateKey>(195, "+"),
			new StateEffect<StateKey>(49, "+"),
			new StateEffect<StateKey>(442),
			new StateEffect<StateKey>(459, "+"),
			new StateEffect<StateKey>(81, "-")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.StealTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_121"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, 1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(122, "StudyDemandStealLifeSkillAction", new sbyte[1] { 8 }, new int[5] { 0, 30, 50, 100, 75 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(81, "<=", 0)
		}, new StateEffect<StateKey>[4]
		{
			new StateEffect<StateKey>(227, "+"),
			new StateEffect<StateKey>(443),
			new StateEffect<StateKey>(459, "+"),
			new StateEffect<StateKey>(81, "-")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.StealTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_122"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, 1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(123, "StudyDemandScamCombatSkillAction", new sbyte[1] { 7 }, new int[5] { 0, 30, 50, 100, 75 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(81, "<=", 0)
		}, new StateEffect<StateKey>[5]
		{
			new StateEffect<StateKey>(195, "+"),
			new StateEffect<StateKey>(49, "+"),
			new StateEffect<StateKey>(442),
			new StateEffect<StateKey>(459, "+"),
			new StateEffect<StateKey>(81, "-")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.ScamTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_123"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(124, "StudyDemandScamLifeSkillAction", new sbyte[1] { 8 }, new int[5] { 0, 30, 50, 100, 75 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(81, "<=", 0)
		}, new StateEffect<StateKey>[4]
		{
			new StateEffect<StateKey>(227, "+"),
			new StateEffect<StateKey>(443),
			new StateEffect<StateKey>(459, "+"),
			new StateEffect<StateKey>(81, "-")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.ScamTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_124"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(125, null, new sbyte[1] { 7 }, new int[5] { 75, 75, 75, 75, 75 }, new int[7], 3, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(317)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(391)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(452)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_125"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(126, null, new sbyte[1] { 8 }, new int[5] { 75, 75, 75, 75, 75 }, new int[7], 1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(317)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(391)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(453)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_126"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(127, null, new sbyte[1] { 7 }, new int[5] { 75, 75, 75, 75, 75 }, new int[7], 2, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(317)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 0),
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(454)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.CloseTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_127"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(128, null, new sbyte[1] { 8 }, new int[5] { 75, 75, 75, 75, 75 }, new int[7], 2, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(317)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 0),
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(455)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.CloseTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_128"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(129, null, new sbyte[1] { 7 }, new int[5] { 75, 75, 75, 75, 75 }, new int[7], 6, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(317)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 0)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(456)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RequestTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_129"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(130, null, new sbyte[1] { 8 }, new int[5] { 75, 75, 75, 75, 75 }, new int[7], 6, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(317)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 0)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(457)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RequestTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_130"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(131, null, new sbyte[1] { 17 }, new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(317)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(458)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_131"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(132, null, new sbyte[0], new int[5] { 150, 150, 150, 150, 150 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(55, "<=%", 80, 56)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[2]
		{
			new StateEffect<StateKey>(55, "+"),
			new StateEffect<StateKey>(49, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_132"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(133, null, new sbyte[1] { 2 }, new int[5] { 150, 150, 150, 150, 150 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(57, ">=", 2)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[2]
		{
			new StateEffect<StateKey>(57, "-"),
			new StateEffect<StateKey>(49, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_133"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(134, null, new sbyte[1] { 3 }, new int[5] { 150, 150, 150, 150, 150 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(58, ">=", 2)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[2]
		{
			new StateEffect<StateKey>(58, "-"),
			new StateEffect<StateKey>(49, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_134"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(135, null, new sbyte[0], new int[5] { 150, 150, 150, 150, 150 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(59, ">=", 1500)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[2]
		{
			new StateEffect<StateKey>(59, "-"),
			new StateEffect<StateKey>(49, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_135"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(136, null, new sbyte[0], new int[5] { 150, 150, 150, 150, 150 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(55, "<=%", 80, 56)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(422)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[2]
		{
			new StateEffect<StateKey>(55, "+"),
			new StateEffect<StateKey>(49, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_136"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(137, null, new sbyte[0], new int[5] { 150, 150, 150, 150, 150 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(57, ">=", 2)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(415)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[2]
		{
			new StateEffect<StateKey>(57, "-"),
			new StateEffect<StateKey>(49, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_137"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(138, null, new sbyte[0], new int[5] { 150, 150, 150, 150, 150 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(58, ">=", 2)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(418)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[2]
		{
			new StateEffect<StateKey>(58, "-"),
			new StateEffect<StateKey>(49, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_138"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(139, null, new sbyte[0], new int[5] { 150, 150, 150, 150, 150 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(59, ">=", 1500)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(417)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[2]
		{
			new StateEffect<StateKey>(59, "-"),
			new StateEffect<StateKey>(49, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_139"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(140, null, new sbyte[1] { 4 }, new int[5] { 150, 150, 150, 150, 150 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(62)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(423)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[2]
		{
			new StateEffect<StateKey>(62, 0),
			new StateEffect<StateKey>(49, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_140"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(141, null, new sbyte[0], new int[5] { 150, 150, 150, 150, 150 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(52, "<=%", 60, 53)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(420)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[2]
		{
			new StateEffect<StateKey>(52, "+"),
			new StateEffect<StateKey>(49, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_141"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(142, null, new sbyte[0], new int[5] { 150, 150, 150, 150, 150 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(6, "<=%", 50, 20)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(421)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[2]
		{
			new StateEffect<StateKey>(6, "+"),
			new StateEffect<StateKey>(43, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_142"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(143, null, new sbyte[0], new int[5] { 150, 150, 150, 150, 150 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(6, "<=%", 50, 20)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(421)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[2]
		{
			new StateEffect<StateKey>(6, "+"),
			new StateEffect<StateKey>(43, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_143"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(144, null, new sbyte[0], new int[5] { 150, 150, 150, 150, 150 }, new int[7], -1, new int[0], new short[0], isAdultOnly: true, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(424)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(43, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_144"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(145, null, new sbyte[0], new int[5] { 150, 150, 150, 150, 150 }, new int[7], -1, new int[0], new short[0], isAdultOnly: true, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(425)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(43, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_145"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(146, null, new sbyte[0], new int[5] { 75, 100, 50, 30, 10 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 6001),
			new StateConditionAndValue<StateKey>(55, "<=%", 80, 56)
		}, new StateEffect<StateKey>[4]
		{
			new StateEffect<StateKey>(92, "+"),
			new StateEffect<StateKey>(466, "+"),
			new StateEffect<StateKey>(81, "+"),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.MaxPriorityTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_146"), -1, -1, -1, 0, 0, 1500, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(147, null, new sbyte[1] { 2 }, new int[5] { 75, 100, 50, 30, 10 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 6001),
			new StateConditionAndValue<StateKey>(57, ">=", 2)
		}, new StateEffect<StateKey>[4]
		{
			new StateEffect<StateKey>(94, "-"),
			new StateEffect<StateKey>(466, "+"),
			new StateEffect<StateKey>(81, "+"),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.MaxPriorityTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_147"), -1, -1, -1, 0, 0, 1500, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(148, null, new sbyte[1] { 3 }, new int[5] { 75, 100, 50, 30, 10 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 6001),
			new StateConditionAndValue<StateKey>(58, ">=", 2)
		}, new StateEffect<StateKey>[4]
		{
			new StateEffect<StateKey>(95, "-"),
			new StateEffect<StateKey>(466, "+"),
			new StateEffect<StateKey>(81, "+"),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.MaxPriorityTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_148"), -1, -1, -1, 0, 0, 1500, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(149, null, new sbyte[0], new int[5] { 75, 100, 50, 30, 10 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 6001),
			new StateConditionAndValue<StateKey>(59, ">=", 1500)
		}, new StateEffect<StateKey>[4]
		{
			new StateEffect<StateKey>(96, "-"),
			new StateEffect<StateKey>(466, "+"),
			new StateEffect<StateKey>(81, "+"),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.MaxPriorityTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_149"), -1, -1, -1, 0, 0, 1500, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(150, null, new sbyte[0], new int[5] { 75, 100, 50, 30, 10 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(422)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 6001),
			new StateConditionAndValue<StateKey>(55, "<=%", 80, 56)
		}, new StateEffect<StateKey>[4]
		{
			new StateEffect<StateKey>(92, "+"),
			new StateEffect<StateKey>(466, "+"),
			new StateEffect<StateKey>(81, "+"),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.MaxPriorityTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_150"), -1, -1, -1, 0, 0, 1500, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(151, null, new sbyte[1] { 2 }, new int[5] { 75, 100, 50, 30, 10 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(415)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 6001),
			new StateConditionAndValue<StateKey>(57, ">=", 2)
		}, new StateEffect<StateKey>[4]
		{
			new StateEffect<StateKey>(94, "-"),
			new StateEffect<StateKey>(466, "+"),
			new StateEffect<StateKey>(81, "+"),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.MaxPriorityTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_151"), -1, -1, -1, 0, 0, 1500, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(152, null, new sbyte[1] { 3 }, new int[5] { 75, 100, 50, 30, 10 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(418)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 6001),
			new StateConditionAndValue<StateKey>(58, ">=", 2)
		}, new StateEffect<StateKey>[4]
		{
			new StateEffect<StateKey>(95, "-"),
			new StateEffect<StateKey>(466, "+"),
			new StateEffect<StateKey>(81, "+"),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.MaxPriorityTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_152"), -1, -1, -1, 0, 0, 1500, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(153, null, new sbyte[0], new int[5] { 75, 100, 50, 30, 10 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(417)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 6001),
			new StateConditionAndValue<StateKey>(59, ">=", 1500)
		}, new StateEffect<StateKey>[4]
		{
			new StateEffect<StateKey>(96, "-"),
			new StateEffect<StateKey>(466, "+"),
			new StateEffect<StateKey>(81, "+"),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.MaxPriorityTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_153"), -1, -1, -1, 0, 0, 1500, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(154, null, new sbyte[1] { 4 }, new int[5] { 75, 100, 50, 30, 10 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(423)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 6001),
			new StateConditionAndValue<StateKey>(62)
		}, new StateEffect<StateKey>[4]
		{
			new StateEffect<StateKey>(99, 0),
			new StateEffect<StateKey>(466, "+"),
			new StateEffect<StateKey>(81, "+"),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.MaxPriorityTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_154"), -1, -1, -1, 0, 0, 1500, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(155, null, new sbyte[0], new int[5] { 75, 100, 50, 30, 10 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(420)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 6001),
			new StateConditionAndValue<StateKey>(52, "<=%", 60, 53)
		}, new StateEffect<StateKey>[4]
		{
			new StateEffect<StateKey>(89, "+"),
			new StateEffect<StateKey>(466, "+"),
			new StateEffect<StateKey>(81, "+"),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.MaxPriorityTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_155"), -1, -1, -1, 0, 0, 1500, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(156, null, new sbyte[0], new int[5] { 75, 100, 50, 30, 10 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(421)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 6001),
			new StateConditionAndValue<StateKey>(6, "<=%", 50, 20)
		}, new StateEffect<StateKey>[5]
		{
			new StateEffect<StateKey>(13, "+"),
			new StateEffect<StateKey>(460, "+"),
			new StateEffect<StateKey>(80, "+"),
			new StateEffect<StateKey>(81, "+"),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.MaxPriorityTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_156"), -1, -1, -1, 0, 0, 1500, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(157, null, new sbyte[0], new int[5] { 75, 100, 50, 30, 10 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(421)
		}, new StateConditionAndValue<StateKey>[3]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 6001),
			new StateConditionAndValue<StateKey>(600, 0),
			new StateConditionAndValue<StateKey>(6, "<=%", 50, 20)
		}, new StateEffect<StateKey>[5]
		{
			new StateEffect<StateKey>(13, "+"),
			new StateEffect<StateKey>(460, "+"),
			new StateEffect<StateKey>(80, "+"),
			new StateEffect<StateKey>(81, "+"),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.MaxPriorityTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_157"), -1, -1, -1, 0, 0, 1500, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(158, null, new sbyte[0], new int[5] { 75, 100, 50, 30, 10 }, new int[7], -1, new int[0], new short[0], isAdultOnly: true, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(424)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 6001),
			new StateConditionAndValue<StateKey>(600, 0)
		}, new StateEffect<StateKey>[4]
		{
			new StateEffect<StateKey>(80, "+"),
			new StateEffect<StateKey>(460, "+"),
			new StateEffect<StateKey>(81, "+"),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.MaxPriorityTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_158"), -1, -1, -1, 0, 0, 1500, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(159, null, new sbyte[0], new int[5] { 75, 100, 50, 30, 10 }, new int[7], -1, new int[0], new short[0], isAdultOnly: true, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 20, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(425)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 6001)
		}, new StateEffect<StateKey>[4]
		{
			new StateEffect<StateKey>(80, "+"),
			new StateEffect<StateKey>(460, "+"),
			new StateEffect<StateKey>(81, "+"),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.MaxPriorityTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_159"), -1, -1, -1, 0, 0, 1500, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(160, null, new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 6, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(55, "<=%", 80, 56)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 0)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(236, ">=%", 50, 256)
		}, new StateEffect<StateKey>[3]
		{
			new StateEffect<StateKey>(55, "+"),
			new StateEffect<StateKey>(49, "+"),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RequestTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_160"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(161, null, new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 6, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(57, ">=", 2)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 0)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(236, ">=%", 50, 256)
		}, new StateEffect<StateKey>[3]
		{
			new StateEffect<StateKey>(57, "-"),
			new StateEffect<StateKey>(49, "+"),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RequestTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_161"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(162, null, new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 6, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(58, ">=", 2)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 0)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(237, ">=%", 50, 257)
		}, new StateEffect<StateKey>[3]
		{
			new StateEffect<StateKey>(58, "-"),
			new StateEffect<StateKey>(49, "+"),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RequestTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_162"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(163, null, new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 6, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(59, ">=", 1500)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 0)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(236, ">=%", 50, 256)
		}, new StateEffect<StateKey>[3]
		{
			new StateEffect<StateKey>(59, "-"),
			new StateEffect<StateKey>(49, "+"),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RequestTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_163"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(164, "RequestIncreaseHealthItemAction", new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 6, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(55, "<=%", 80, 56)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 0)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(422)
		}, new StateEffect<StateKey>[3]
		{
			new StateEffect<StateKey>(55, "+"),
			new StateEffect<StateKey>(49, "+"),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RequestTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_164"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(165, "RequestHealInjuryItemAction", new sbyte[1] { 2 }, new int[5] { 75, 75, 75, 75, 75 }, new int[7], 6, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(57, ">=", 2)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 0)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(415)
		}, new StateEffect<StateKey>[3]
		{
			new StateEffect<StateKey>(57, "-"),
			new StateEffect<StateKey>(49, "+"),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RequestTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_165"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(166, "RequestDetoxPoisonItemAction", new sbyte[1] { 3 }, new int[5] { 75, 75, 75, 75, 75 }, new int[7], 6, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(58, ">=", 2)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 0)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(418)
		}, new StateEffect<StateKey>[3]
		{
			new StateEffect<StateKey>(58, "-"),
			new StateEffect<StateKey>(49, "+"),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RequestTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_166"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(167, "RequestRestoreQiItemAction", new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 6, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(59, ">=", 1500)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 0)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(417)
		}, new StateEffect<StateKey>[3]
		{
			new StateEffect<StateKey>(59, "-"),
			new StateEffect<StateKey>(49, "+"),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RequestTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_167"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(168, "RequestKillWugItemAction", new sbyte[1] { 4 }, new int[5] { 75, 75, 75, 75, 75 }, new int[7], 6, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(62)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 0)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(423)
		}, new StateEffect<StateKey>[3]
		{
			new StateEffect<StateKey>(62, 0),
			new StateEffect<StateKey>(49, "+"),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RequestTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_168"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(169, "RequestIncreaseNeiliAction", new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 6, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(52, "<=%", 60, 53)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 0)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(420)
		}, new StateEffect<StateKey>[3]
		{
			new StateEffect<StateKey>(52, "+"),
			new StateEffect<StateKey>(49, "+"),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RequestTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_169"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(170, "RequestRecoverMainAttributeAction", new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 6, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(6, "<=%", 50, 20)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 0)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(421)
		}, new StateEffect<StateKey>[3]
		{
			new StateEffect<StateKey>(6, "+"),
			new StateEffect<StateKey>(43, "+"),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RequestTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_170"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(171, "RequestRecoverMainAttributeAction", new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 6, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(6, "<=%", 50, 20)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 0)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(421),
			new StateConditionAndValue<StateKey>(600, 0)
		}, new StateEffect<StateKey>[3]
		{
			new StateEffect<StateKey>(6, "+"),
			new StateEffect<StateKey>(43, "+"),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RequestTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_171"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(172, "RequestIncreaseHappinessAction", new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 6, new int[0], new short[0], isAdultOnly: true, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 0)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(424),
			new StateConditionAndValue<StateKey>(600, 0)
		}, new StateEffect<StateKey>[2]
		{
			new StateEffect<StateKey>(43, "+"),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RequestTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_172"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(173, "RequestIncreaseHappinessAction", new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 6, new int[0], new short[0], isAdultOnly: true, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 0)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(425)
		}, new StateEffect<StateKey>[2]
		{
			new StateEffect<StateKey>(43, "+"),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RequestTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_173"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(174, null, new sbyte[0], new int[5] { 150, 150, 150, 150, 150 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(60)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(81, ">=", 0)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(296)
		}, new StateEffect<StateKey>[2]
		{
			new StateEffect<StateKey>(60, 0),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RequestTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_174"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(175, "LifeSkillEntertainmentAction", new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 2, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(228, ">=", 200)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[2]
		{
			new StateEffect<StateKey>(586),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.CloseTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_175"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(176, "LifeSkillEntertainmentAction", new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 0, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(229, ">=", 200)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[2]
		{
			new StateEffect<StateKey>(587),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.CloseTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_176"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(177, "LifeSkillEntertainmentAction", new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(230, ">=", 200)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[2]
		{
			new StateEffect<StateKey>(588),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.CloseTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_177"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(178, "LifeSkillEntertainmentAction", new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 2, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(231, ">=", 200)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[2]
		{
			new StateEffect<StateKey>(589),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.CloseTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_178"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(179, "LifeSkillTeaWineAction", new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 4, new int[0], new short[0], isAdultOnly: true, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(233, ">=", 200)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[3]
		{
			new StateEffect<StateKey>(590),
			new StateEffect<StateKey>(425),
			new StateEffect<StateKey>(424)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_179"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
	}

	private void CreateItems3()
	{
		_dataArray.Add(new PlanningActionItem(180, "LifeSkillDivinationAction", new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(232, ">=", 200)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[2]
		{
			new StateEffect<StateKey>(591),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_180"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(181, null, new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 6, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(240, ">=", 200)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[2]
		{
			new StateEffect<StateKey>(592),
			new StateEffect<StateKey>(43, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_181"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(182, "LifeSkillAwakeningAction", new sbyte[0], new int[5] { 150, 150, 150, 150, 150 }, new int[7], 6, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(240, ">=", 200)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[2]
		{
			new StateEffect<StateKey>(593),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.CloseTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_182"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(183, null, new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 5, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(241, ">=", 200)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[2]
		{
			new StateEffect<StateKey>(594),
			new StateEffect<StateKey>(43, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_183"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(184, "LifeSkillAwakeningAction", new sbyte[0], new int[5] { 150, 150, 150, 150, 150 }, new int[7], 5, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(241, ">=", 200)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[2]
		{
			new StateEffect<StateKey>(595),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.CloseTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_184"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(185, "LifeSkillCricketAction", new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 2, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(243, ">=", 200)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[2]
		{
			new StateEffect<StateKey>(596),
			new StateEffect<StateKey>(459, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.CloseTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_185"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(186, null, new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 3, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(243, ">=", 200)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(597)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_186"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(187, "DejaVuAction", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(478)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_187"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(188, "AppointmentAction", new sbyte[0], new int[5] { 150, 150, 150, 150, 150 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(479)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_188"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(189, "GuardTreasuryAction", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(606, 0)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(484)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_189"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(190, "HuntFugitiveAction", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(606, 0)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(485)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_190"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, 1, 0, 100, 0));
		_dataArray.Add(new PlanningActionItem(191, "EscapeFromPrisonAction", new sbyte[0], new int[5] { 0, 30, 50, 100, 75 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(486)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_191"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(192, "SeekAsylumAction", new sbyte[0], new int[5] { 0, 30, 50, 75, 100 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(487)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_192"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(193, "EscortPrisonerAction", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(606, 0)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(488)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_193"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(194, "VillagerRoleArrangementAction", new sbyte[0], new int[5] { 150, 150, 150, 150, 150 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(473)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_194"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(195, "JoinSectAction", new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 3, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(317)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_195"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 3, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(196, "ProtectFriendOrFamilyAction", new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 3, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(49, ">=", 0, 86)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(480)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_196"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(197, "MournAction", new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 6, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(432, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_197"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 6, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(198, "FindSpecialMaterialAction", new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 5, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(476)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_198"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(199, "ContestForLegendaryBookAction", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[0], isAdultOnly: true, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(477)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_199"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(200, "AdoptInfantAction", new sbyte[0], new int[5] { 75, 100, 50, 30, 10 }, new int[7], -1, new int[0], new short[0], isAdultOnly: true, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(483)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_200"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(201, "SectStoryBaihuaToCureManic", new sbyte[0], new int[5] { 150, 150, 150, 150, 150 }, new int[7], -1, new int[0], new short[0], isAdultOnly: true, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(489, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_201"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(202, "SectStoryShixiangToFightEnemyAction", new sbyte[0], new int[5] { 150, 150, 150, 150, 150 }, new int[7], -1, new int[0], new short[0], isAdultOnly: true, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(491, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_202"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, 2, 100, 0, 0));
		_dataArray.Add(new PlanningActionItem(203, "HuntTaiwuAction", new sbyte[0], new int[5] { 150, 150, 150, 150, 150 }, new int[7], -1, new int[0], new short[0], isAdultOnly: true, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(492, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_203"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, 2, 100, 0, 0));
		_dataArray.Add(new PlanningActionItem(204, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[9] { 136, 137, 138, 139, 140, 141, 142, 143, 144 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(362, ">=%", 50, 39)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(474)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_204"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(205, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[9] { 163, 164, 165, 166, 167, 168, 169, 170, 171 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(391)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(475)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_205"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(206, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 181 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(391)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(37, ">=", 8),
			new StateConditionAndValue<StateKey>(318)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(564)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.OptionalMultiple, new int[2] { 1, 2 }, EPlanningActionCharacterSelector.CloseTarget, 33, EPlanningActionCharacterSelectRange.SameState, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_206"), -1, -1, -1, 0, 0, 4500, 61, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(207, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 181 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(391)
		}, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(37, ">=", 8),
			new StateConditionAndValue<StateKey>(317)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(565)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.OptionalMultiple, new int[2] { 1, 2 }, EPlanningActionCharacterSelector.CloseTarget, 33, EPlanningActionCharacterSelectRange.SameState, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_207"), -1, -1, -1, 0, 0, 4500, 61, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(208, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 181 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(566)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_208"), -1, -1, -1, 0, 0, 0, 61, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(209, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[3] { 190, 199, 208 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(37, ">=", 8),
			new StateConditionAndValue<StateKey>(318)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(567)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.OptionalMultiple, new int[2] { 1, 2 }, EPlanningActionCharacterSelector.CloseTarget, 33, EPlanningActionCharacterSelectRange.SameState, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_209"), -1, -1, -1, 0, 0, 4500, 41, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(210, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[3] { 190, 199, 208 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(37, ">=", 8),
			new StateConditionAndValue<StateKey>(317)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(568)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.OptionalMultiple, new int[2] { 1, 2 }, EPlanningActionCharacterSelector.CloseTarget, 33, EPlanningActionCharacterSelectRange.SameState, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_210"), -1, -1, -1, 0, 0, 4500, 41, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(211, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 182 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[3]
		{
			new StateConditionAndValue<StateKey>(37, ">=", 6),
			new StateConditionAndValue<StateKey>(318),
			new StateConditionAndValue<StateKey>(316)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(569)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.OptionalMultiple, new int[2] { 1, 2 }, EPlanningActionCharacterSelector.CloseTarget, 33, EPlanningActionCharacterSelectRange.SameArea, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_211"), -1, -1, -1, 0, 0, 0, 19, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(212, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 200 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[3]
		{
			new StateConditionAndValue<StateKey>(37, ">=", 3),
			new StateConditionAndValue<StateKey>(318),
			new StateConditionAndValue<StateKey>(316)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(570)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.OptionalMultiple, new int[2] { 1, 2 }, EPlanningActionCharacterSelector.CloseTarget, 33, EPlanningActionCharacterSelectRange.SameArea, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_212"), -1, -1, -1, 0, 0, 0, 19, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(213, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 209 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[3]
		{
			new StateConditionAndValue<StateKey>(37, ">=", 3),
			new StateConditionAndValue<StateKey>(318),
			new StateConditionAndValue<StateKey>(316)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(571)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.OptionalMultiple, new int[2] { 1, 2 }, EPlanningActionCharacterSelector.CloseTarget, 33, EPlanningActionCharacterSelectRange.SameArea, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_213"), -1, -1, -1, 0, 0, 0, 19, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(214, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 191 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(318),
			new StateConditionAndValue<StateKey>(316)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(572)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.OptionalMultiple, new int[2] { 3, 6 }, EPlanningActionCharacterSelector.CloseTarget, 33, EPlanningActionCharacterSelectRange.SameArea, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_214"), -1, -1, -1, 0, 5, 0, 19, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(215, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], 6, new int[0], new short[4] { 182, 191, 200, 209 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(37, "==", 7),
			new StateConditionAndValue<StateKey>(318)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(573)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.OptionalMultiple, new int[2] { 1, 2 }, EPlanningActionCharacterSelector.CloseTarget, 33, EPlanningActionCharacterSelectRange.SameState, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_215"), -1, -1, -1, 0, 0, 4500, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(216, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], 6, new int[0], new short[4] { 183, 192, 201, 210 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(574)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_216"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(217, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], 0, new int[0], new short[4] { 183, 192, 201, 210 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(362, ">=%", 50, 39)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(575)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_217"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(218, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], 4, new int[0], new short[4] { 185, 194, 203, 212 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(578)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_218"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(219, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], 1, new int[0], new short[4] { 184, 193, 202, 211 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(576)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.OptionalMultiple, new int[2] { 1, 2 }, EPlanningActionCharacterSelector.RandomTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_219"), -1, -1, -1, 0, 0, 0, 8, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(220, "SocialStatusSellItemAction", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], 6, new int[0], new short[4] { 185, 194, 203, 212 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(577)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.CloseTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_220"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(221, "SocialStatusHealAction", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], 0, new int[0], new short[4] { 186, 195, 204, 213 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(361, ">=%", 20, 39)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(64)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(579)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.CloseTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_221"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(222, "SocialStatusRepairAction", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], 4, new int[0], new short[4] { 187, 196, 205, 214 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(580)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.CloseTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_222"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(223, "SocialStatusBarbAction", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], 2, new int[0], new short[3] { 188, 206, 215 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(581)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.CloseTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_223"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(224, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], 2, new int[0], new short[3] { 188, 206, 215 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(582)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_224"), -1, -1, -1, 1000, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(225, "SocialStatusBegAction", new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 4, new int[0], new short[4] { 189, 198, 207, 216 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(362, "<=", 10000)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(583)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_225"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(226, "IdentityActionSeekSecret", new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 2, new int[0], new short[4] { 189, 198, 207, 216 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(41)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(584)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 50, EPlanningActionCharacterSelectRange.BlockRange, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_226"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(227, "IdentityActionFarm", new sbyte[0], new int[5] { 75, 75, 75, 75, 75 }, new int[7], 4, new int[0], new short[1] { 197 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(585)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_227"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(228, "IdentityActionSelfSectSkillsImprove", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[3] { 46, 47, 48 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(508)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_228"), -1, 1172, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(229, "IdentityActionTeachSectMembers", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 49 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74),
			new StateConditionAndValue<StateKey>(315)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(509)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredMultiple, new int[2] { 3, 6 }, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_229"), -1, 1171, 1376, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(230, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 50 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(42, "<=", -25),
			new StateConditionAndValue<StateKey>(315)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(517)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 3, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_230"), -1, 1170, 1375, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(231, "IdentityActionAwakening", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 51 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(518)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_231"), -1, 1169, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(232, "IdentityActionCommonMultiTarget", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[3] { 52, 53, 54 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(315)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(512)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.OptionalMultiple, new int[2] { 1, 2 }, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 3, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_232"), -1, 1166, 1207, 1000, 0, 3000, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(233, "IdentityActionBreakOutSectSkill", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[2] { 52, 53 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(511)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_233"), -1, 1167, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(234, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 52 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(519)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_234"), -1, 1168, 1208, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(235, "IdentityActionTeachSectMembers", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 55 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74),
			new StateConditionAndValue<StateKey>(315)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(509)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredMultiple, new int[2] { 3, 6 }, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_235"), -1, 1177, 1210, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(236, "IdentityActionSelfSectSkillsImprove", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 56 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(508)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_236"), -1, 1176, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(237, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 57 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74),
			new StateConditionAndValue<StateKey>(297)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(520)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.SameState, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_237"), -1, 1175, 1209, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, 1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(238, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[9] { 58, 59, 60, 76, 77, 78, 84, 85, 86 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(318),
			new StateConditionAndValue<StateKey>(42, "<=", 0)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(521)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.SameArea, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_238"), -1, 1165, 1206, 0, 0, 4500, 0, new List<PresetInventoryItem>(), 82, 82, 2, 1, 0, 20, 80));
		_dataArray.Add(new PlanningActionItem(239, "IdentityActionCommonMultiTarget", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[3] { 61, 62, 63 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(315)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(512)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.OptionalMultiple, new int[2] { 1, 2 }, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 3, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_239"), -1, 1173, 1380, 1000, 0, 3000, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
	}

	private void CreateItems4()
	{
		_dataArray.Add(new PlanningActionItem(240, "IdentityActionCleanYard", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[2] { 61, 62 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(522)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_240"), -1, 1174, -1, 0, 0, 0, 0, new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Misc", 100, 1, 100),
			new PresetInventoryItem("Misc", 101, 1, 100),
			new PresetInventoryItem("Misc", 102, 1, 100),
			new PresetInventoryItem("Misc", 103, 1, 100),
			new PresetInventoryItem("Misc", 104, 1, 100),
			new PresetInventoryItem("Misc", 105, 1, 100),
			new PresetInventoryItem("Misc", 106, 1, 100),
			new PresetInventoryItem("Misc", 107, 1, 100),
			new PresetInventoryItem("Misc", 108, 1, 100),
			new PresetInventoryItem("Misc", 109, 1, 100)
		}, 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(241, "IdentityActionHelpCivilian", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[4] { 61, 79, 80, 81 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(318)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(523)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.OptionalMultiple, new int[2] { 1, 2 }, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 3, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_241"), -1, 1164, 1205, 0, 0, 4500, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(242, "IdentityActionSelfSectSkillsImprove", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 64 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(508)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_242"), -1, 1184, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(243, "IdentityActionTeachSectMembers", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 65 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74),
			new StateConditionAndValue<StateKey>(315)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(509)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredMultiple, new int[2] { 3, 6 }, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_243"), -1, 1183, 1213, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(244, "IdentityActionRemoveDarkAsh", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 66 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(60)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(513)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.CloseTarget, 33, EPlanningActionCharacterSelectRange.SameState, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_244"), -1, 1182, 1383, 0, 0, 9000, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(245, "IdentityActionHeal", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[3] { 67, 68, 69 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(361, ">=%", 20, 39)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(64)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(514)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredMultiple, new int[2] { 1, 2 }, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 3, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_245"), -1, 1181, 1212, 0, 0, 3000, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(246, "IdentityActionCommonMultiTarget", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[2] { 71, 72 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(315)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(512)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.OptionalMultiple, new int[2] { 1, 2 }, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 3, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_246"), -1, 1178, 1211, 1000, 0, 3000, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(247, "IdentityActionSelfSectSkillsImprove", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 73 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(508)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_247"), -1, 1189, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(248, "IdentityActionAwakening", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 74 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(524)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_248"), -1, 1188, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(249, "IdentityActionTeachSectMembers", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 75 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74),
			new StateConditionAndValue<StateKey>(315)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(509)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredMultiple, new int[2] { 3, 6 }, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_249"), -1, 1187, 1216, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(250, "IdentityActionTeachCivilians", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[2] { 79, 80 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(318),
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(516)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredMultiple, new int[2] { 1, 2 }, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 3, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_250"), -1, 1185, 1214, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(251, "IdentityActionCommonMultiTarget", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 79 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(315)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(512)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.OptionalMultiple, new int[2] { 1, 2 }, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 3, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_251"), -1, 1186, 1215, 1000, 0, 3000, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(252, "IdentityActionSendInfectedToStoneRoom", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 82 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(67),
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(525)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.CloseTarget, 33, EPlanningActionCharacterSelectRange.SameState, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_252"), -1, 1195, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(253, "IdentityActionReduceMemberXiangshuInfection", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 83 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[3]
		{
			new StateConditionAndValue<StateKey>(65, ">=", 50),
			new StateConditionAndValue<StateKey>(315),
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(526)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredMultiple, new int[2] { 1, 2 }, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 3, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_253"), -1, 1194, 1220, 0, -25, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(254, "IdentityActionHelpSectMembersBreak", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 87 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(315)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(510)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredMultiple, new int[2] { 3, 6 }, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_254"), -1, 1193, 1219, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(255, "IdentityActionReduceSelfXiangshuInfection", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 88 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(527)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_255"), -1, 1192, -1, 0, -25, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(256, "IdentityActionBreakOutSectSkill", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 89 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(511)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_256"), -1, 1191, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(257, "IdentityActionCommonMultiTarget", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 90 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(315)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(512)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.OptionalMultiple, new int[2] { 1, 2 }, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 3, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_257"), -1, 1190, 1217, 1000, 0, 3000, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(258, "IdentityActionFavorBetweenSectMembers", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 91 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(315)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(528)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredMultiple, new int[2] { 3, 6 }, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_258"), -1, 1204, 1224, 0, 0, 4500, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(259, "IdentityActionTeachSectMembers", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 92 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74),
			new StateConditionAndValue<StateKey>(315)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(509)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredMultiple, new int[2] { 3, 6 }, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_259"), -1, 1203, 1223, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(260, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 93 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74),
			new StateConditionAndValue<StateKey>(315)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(529)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_260"), -1, 1200, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, 1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(261, "IdentityActionTeachCivilians", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[3] { 93, 94, 95 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(318),
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(516)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredMultiple, new int[2] { 1, 2 }, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_261"), -1, 1201, 1221, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(262, "IdentityActionCommonMultiTarget", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[3] { 93, 94, 95 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74),
			new StateConditionAndValue<StateKey>(315)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(530)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredMultiple, new int[2] { 3, 6 }, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_262"), -1, 1202, 1222, 0, 0, 4500, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(263, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 94 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74),
			new StateConditionAndValue<StateKey>(315)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(531)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_263"), -1, 1199, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, 1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(264, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 95 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74),
			new StateConditionAndValue<StateKey>(315)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(532)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_264"), -1, 1198, -1, 0, 0, 0, 13, new List<PresetInventoryItem>(), 82, 82, 2, 1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(265, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[3] { 96, 97, 98 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74),
			new StateConditionAndValue<StateKey>(315)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(533)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 3, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_265"), -1, 1197, -1, 1000, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, 1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(266, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 99 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74),
			new StateConditionAndValue<StateKey>(318)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(515)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_266"), -1, 1196, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, 1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(267, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 100 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(315)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(534)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.CloseTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 3, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_267"), -1, 1235, 1236, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(268, "IdentityActionTeachSectMembers", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 101 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74),
			new StateConditionAndValue<StateKey>(315)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(509)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredMultiple, new int[2] { 3, 6 }, EPlanningActionCharacterSelector.CloseTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_268"), -1, 1233, 1234, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(269, "IdentityActionReading", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 102 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(535)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_269"), -1, 1232, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(270, "IdentityActionLooping", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[2] { 103, 106 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(536)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_270"), -1, 1229, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(271, "IdentityActionBreakOutSectSkill", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[2] { 103, 105 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(511)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_271"), -1, 1230, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(272, "IdentityActionGetTianJieFuLu", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[2] { 103, 104 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(537)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_272"), -1, 1231, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(273, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 107 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74),
			new StateConditionAndValue<StateKey>(315)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(470, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 3, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_273"), -1, 1227, 1228, 1000, 0, 3000, 0, new List<PresetInventoryItem>(), 82, 82, 2, 0, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(274, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 108 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74),
			new StateConditionAndValue<StateKey>(315)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(468, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 3, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_274"), -1, 1225, 1226, 1000, 0, 3000, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(275, "IdentityActionSelfSectSkillsImprove", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 109 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(508)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_275"), -1, 1246, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(276, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[3] { 110, 111, 112 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(318)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(538)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.SameState, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_276"), -1, 1245, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(277, "IdentityActionTeachSectMembers", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 113 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74),
			new StateConditionAndValue<StateKey>(315)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(509)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredMultiple, new int[2] { 3, 6 }, EPlanningActionCharacterSelector.CloseTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_277"), -1, 1243, 1244, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(278, "IdentityActionBreakOutSectSkill", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 114 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(511)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_278"), -1, 1241, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(279, "IdentityActionCommonMultiTarget", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[3] { 115, 116, 117 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(315)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(512)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.OptionalMultiple, new int[2] { 1, 2 }, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 3, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_279"), -1, 1237, 1238, 1000, 0, 3000, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(280, "SocialStatusBarbAction", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[2] { 115, 116 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74),
			new StateConditionAndValue<StateKey>(315)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(539)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.CloseTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_280"), -1, 1239, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(281, "IdentityActionDuoMeditation", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 115 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74),
			new StateConditionAndValue<StateKey>(315)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(540)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.CloseTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_281"), -1, 1240, -1, 0, 0, 1500, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(282, "IdentityActionSelfSectSkillsImprove", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 118 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(508)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_282"), -1, 1255, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(283, "IdentityActionTeachSectMembers", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 119 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74),
			new StateConditionAndValue<StateKey>(315)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(509)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredMultiple, new int[2] { 3, 6 }, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_283"), -1, 1253, 1254, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(284, "IdentityActionBreakOutSectSkill", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[3] { 120, 121, 122 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(511)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_284"), -1, 1252, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(285, "LifeSkillCraftingAction", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[3] { 120, 121, 122 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(541)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_285"), -1, 1377, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(286, "IdentityActionCommonMultiTarget", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[3] { 124, 125, 126 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(315)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(512)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.OptionalMultiple, new int[2] { 1, 2 }, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 3, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_286"), -1, 1247, 1248, 1000, 0, 3000, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(287, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[3] { 123, 124, 125 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(542)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_287"), -1, 1249, -1, 1000, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(288, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[2] { 123, 124 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(543)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_288"), -1, 1250, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(289, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 123 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(544)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_289"), -1, 1251, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(290, "IdentityActionRemoveDarkAsh", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 127 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(60)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(513)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.CloseTarget, 33, EPlanningActionCharacterSelectRange.SameState, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_290"), -1, 1274, 1385, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(291, "IdentityActionHeal", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 129 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(64)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(514)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredMultiple, new int[2] { 1, 2 }, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 3, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_291"), -1, 1272, 1273, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(292, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 128 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(545)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_292"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(293, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 130 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(546)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_293"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(294, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 131 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74),
			new StateConditionAndValue<StateKey>(315)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(547)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredMultiple, new int[2] { 3, 6 }, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 3, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_294"), -1, 1264, 1265, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(295, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 131 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74),
			new StateConditionAndValue<StateKey>(315)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(548)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredMultiple, new int[2] { 3, 6 }, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 3, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_295"), -1, 1266, 1267, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(296, "IdentityActionCommonMultiTarget", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 135 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(315)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(512)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.OptionalMultiple, new int[2] { 1, 2 }, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 3, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_296"), -1, 1256, 1257, 1000, 0, 3000, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(297, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[3] { 136, 137, 138 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(549)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_297"), -1, 1287, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(298, "IdentityActionTeachSectMembers", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 139 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74),
			new StateConditionAndValue<StateKey>(315)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(509)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredMultiple, new int[2] { 3, 6 }, EPlanningActionCharacterSelector.CloseTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_298"), -1, 1285, 1286, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(299, "IdentityActionHelpSectMembersBreak", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 140 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(315)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(510)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredMultiple, new int[2] { 3, 6 }, EPlanningActionCharacterSelector.CloseTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_299"), -1, 1283, 1284, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
	}

	private void CreateItems5()
	{
		_dataArray.Add(new PlanningActionItem(300, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[3] { 141, 142, 143 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74),
			new StateConditionAndValue<StateKey>(318)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(515)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_300"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, 1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(301, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[8] { 141, 142, 168, 169, 170, 175, 176, 177 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(550)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_301"), -1, 1280, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(302, "IdentityActionRiotControl", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 141 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(318),
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(551)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredMultiple, new int[2] { 3, 6 }, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 3, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_302"), -1, 1281, 1282, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(303, "IdentityActionCommonMultiTarget", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 144 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(315)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(512)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.OptionalMultiple, new int[2] { 1, 2 }, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 3, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_303"), -1, 1275, 1276, 1000, 0, 3000, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(304, "IdentityActionMakeWugKing", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 145 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(552)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_304"), -1, 1295, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(305, "IdentityActionBreakOutSectSkill", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 146 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(511)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_305"), -1, 1294, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(306, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 147 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(37, "==", 7),
			new StateConditionAndValue<StateKey>(315)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(553)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.CloseTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 3, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_306"), -1, 1293, 1378, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(307, "IdentityActionTeachCivilians", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[3] { 148, 149, 150 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74),
			new StateConditionAndValue<StateKey>(318)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(516)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredMultiple, new int[2] { 1, 2 }, EPlanningActionCharacterSelector.CloseTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 3, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_307"), -1, 1379, 1382, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(308, "IdentityActionTeachSectMembers", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 148 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74),
			new StateConditionAndValue<StateKey>(315)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(509)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredMultiple, new int[2] { 3, 6 }, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_308"), -1, 1291, 1292, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(309, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[2] { 149, 151 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(62),
			new StateConditionAndValue<StateKey>(315)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(554)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredMultiple, new int[2] { 3, 6 }, EPlanningActionCharacterSelector.CloseTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_309"), -1, 1289, 1290, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(310, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 154 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(555)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_310"), -1, 1305, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(311, "IdentityActionTeachSectMembers", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 155 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74),
			new StateConditionAndValue<StateKey>(315)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(509)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredMultiple, new int[2] { 3, 6 }, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_311"), -1, 1304, 1381, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(312, "IdentityActionJudgeRandomDuel", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 156 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(315)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(556)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredMultiple, new int[2] { 2, 2 }, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 3, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_312"), -1, 1301, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, 1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(313, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[3] { 157, 158, 159 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(557)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_313"), -1, 1300, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(314, "IdentityActionSeekSecret", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[3] { 160, 161, 162 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(41)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(558)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.OptionalMultiple, new int[2] { 1, 1 }, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 3, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_314"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(315, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[2] { 160, 161 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(318)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(559)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_315"), -1, 1298, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(316, "IdentityActionEraseTraces", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 160 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(315)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(560)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredMultiple, new int[2] { 3, 6 }, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 3, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_316"), -1, 1299, -1, 0, 0, 1500, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(317, "IdentityActionBreakOutSectSkill", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[3] { 163, 164, 165 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(511)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_317"), -1, 1311, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(318, "IdentityActionHelpSectMembersBreak", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[2] { 163, 164 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(315)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(510)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredMultiple, new int[2] { 3, 6 }, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_318"), -1, 1312, 1313, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(319, "IdentityActionSelfSectSkillsImprove", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 163 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(508)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_319"), -1, 1314, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(320, "IdentityActionTeachCivilians", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 166 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74),
			new StateConditionAndValue<StateKey>(318)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(516)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredMultiple, new int[2] { 1, 2 }, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 3, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_320"), -1, 1309, 1310, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(321, "IdentityActionAddTreasuryResources", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 167 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(561)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_321"), -1, 1308, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(322, "IdentityActionCommonMultiTarget", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 171 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(315)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(512)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.OptionalMultiple, new int[2] { 1, 2 }, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 3, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_322"), -1, 1306, 1307, 1000, 0, 3000, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(323, "IdentityActionSelfSectSkillsImprove", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 172 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(508)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_323"), -1, 1329, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(324, "IdentityActionHelpSectMembersBreak", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 173 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(315)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(510)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredMultiple, new int[2] { 3, 6 }, EPlanningActionCharacterSelector.CloseTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_324"), -1, 1327, 1328, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(325, "IdentityActionTeachSectMembers", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 174 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74),
			new StateConditionAndValue<StateKey>(315)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(509)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredMultiple, new int[2] { 3, 6 }, EPlanningActionCharacterSelector.CloseTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_325"), -1, 1325, 1326, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(326, "IdentityActionTestSectMembers", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[2] { 175, 176 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(37, "<=", 0, 74),
			new StateConditionAndValue<StateKey>(315)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(562)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_326"), -1, 1323, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(327, "IdentityActionKidnap", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[1] { 175 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[5]
		{
			new StateConditionAndValue<StateKey>(45, ">=", 16),
			new StateConditionAndValue<StateKey>(46, ">=", 16),
			new StateConditionAndValue<StateKey>(37, "<=", 2),
			new StateConditionAndValue<StateKey>(315, 0),
			new StateConditionAndValue<StateKey>(321, 0)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(563)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_327"), -1, 1324, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, 1, 0, 100, 0));
		_dataArray.Add(new PlanningActionItem(328, "IdentityActionCommonMultiTarget", new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[3] { 178, 179, 180 }, isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(315)
		}, new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(512)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.OptionalMultiple, new int[2] { 1, 2 }, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 3, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_328"), -1, 1315, 1316, 1000, 0, 3000, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(329, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(493, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_329"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(330, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(494, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_330"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(331, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(495, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_331"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(332, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(496, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_332"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(333, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(497, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_333"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(334, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(498, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_334"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(335, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(499, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_335"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(336, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(500, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_336"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(337, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(501, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_337"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(338, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(502, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_338"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(339, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(503, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_339"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(340, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(504, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_340"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(341, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(505, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_341"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(342, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(506, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_342"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(343, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(507, "+")
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_343"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(344, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[2] { 0, 2 }, new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(337)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[0], new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_344"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(345, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[2] { 0, 4 }, new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(337)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[0], new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_345"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(346, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[2] { 1, 1 }, new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(338)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[0], new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_346"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(347, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[2] { 1, 3 }, new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(338)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[0], new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_347"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(348, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[2] { 3, 4 }, new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(340)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[0], new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_348"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(349, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[2] { 4, 1 }, new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(341)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[0], new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_349"), -1, 555, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(350, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[2] { 4, 3 }, new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(341)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[0], new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_350"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(351, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[2] { 4, 4 }, new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(341)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[0], new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredMultiple, new int[2] { 3, 6 }, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 3, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_351"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(352, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[2] { 5, 2 }, new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(342)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[0], new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_352"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(353, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[2] { 5, 3 }, new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(342)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[0], new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_353"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(354, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[2] { 5, 4 }, new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(342)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(411, ">=", 99)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[0], new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_354"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(355, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[2] { 14, 2 }, new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(351)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[0], new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 3, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_355"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(356, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[2] { 14, 3 }, new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(351)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[0], new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredMultiple, new int[2] { 2, 2 }, EPlanningActionCharacterSelector.CloseTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_356"), -1, 601, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(357, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[2] { 6, 2 }, new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(343)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(600, 0)
		}, new StateEffect<StateKey>[0], new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_357"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(358, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[2] { 6, 3 }, new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(343)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[0], new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_358"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(359, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[2] { 12, 2 }, new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(349)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[0], new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_359"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
	}

	private void CreateItems6()
	{
		_dataArray.Add(new PlanningActionItem(360, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[2] { 12, 3 }, new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(349)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[0], new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_360"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(361, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[2] { 8, 1 }, new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(345)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[0], new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.CloseTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_361"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(362, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[2] { 8, 2 }, new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(345)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[0], new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.CloseTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_362"), -1, 560, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(363, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[2] { 8, 4 }, new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(345)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[0], new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.CloseTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_363"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(364, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[2] { 9, 1 }, new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(346)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[0], new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_364"), -1, 571, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(365, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[2] { 9, 3 }, new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(346)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[0], new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredMultiple, new int[2] { 3, 6 }, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.SameArea, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_365"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(366, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[2] { 9, 4 }, new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(346)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[0], new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_366"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(367, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[2] { 10, 2 }, new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(347)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(294, ">=", 1)
		}, new StateEffect<StateKey>[0], new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredMultiple, new int[2] { 3, 6 }, EPlanningActionCharacterSelector.CloseTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_367"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(368, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[2] { 10, 3 }, new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(347)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(297)
		}, new StateEffect<StateKey>[0], new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_368"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(369, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[2] { 10, 4 }, new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(347)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(305)
		}, new StateEffect<StateKey>[0], new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 3, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_369"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(370, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[2] { 11, 3 }, new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(348)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[0], new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_370"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(371, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[2] { 13, 1 }, new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(350)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(64)
		}, new StateEffect<StateKey>[0], new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.CloseTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_371"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(372, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[2] { 13, 2 }, new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(350)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[0], new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredMultiple, new int[2] { 3, 6 }, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.SameArea, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_372"), -1, 566, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(373, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[2] { 13, 3 }, new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(350)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(391)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[0], new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_373"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(374, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[2] { 13, 4 }, new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(350)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(55, "<=", -12, 56)
		}, new StateEffect<StateKey>[0], new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.CloseTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_374"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(375, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[2] { 7, 1 }, new short[0], isAdultOnly: true, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(344)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[0], new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.CloseTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_375"), -1, 551, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(376, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[2] { 7, 4 }, new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(344)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[0], new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredMultiple, new int[2] { 3, 6 }, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.SameArea, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_376"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(377, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[2] { 16, 1 }, new short[0], isAdultOnly: true, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(353)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[0], new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.CloseTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 2, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_377"), -1, 547, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(378, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[2] { 16, 4 }, new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(353)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[0], new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredMultiple, new int[2] { 3, 6 }, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.SameArea, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_378"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(379, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[2] { 15, 1 }, new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(352)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(391)
		}, new StateEffect<StateKey>[0], new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.RequiredSingle, null, EPlanningActionCharacterSelector.RandomTarget, 33, EPlanningActionCharacterSelectRange.BlockRange, 3, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_379"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(380, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[2] { 17, 4 }, new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(354)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[0], new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_380"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(381, null, new sbyte[0], new int[5] { 100, 100, 100, 100, 100 }, new int[7], -1, new int[2] { 2, 3 }, new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(339)
		}, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(391)
		}, new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[0], new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_381"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(382, "WealthDemandMakeArtisanOrderAction", new sbyte[2] { 6, 11 }, new int[5] { 75, 75, 75, 75, 75 }, new int[7], 2, new int[0], new short[0], isAdultOnly: false, isNonTaiwuTeammate: false, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[2]
		{
			new StateConditionAndValue<StateKey>(602),
			new StateConditionAndValue<StateKey>(603, 0)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(391)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_382"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 2, -1, 0, 0, 100));
		_dataArray.Add(new PlanningActionItem(383, "TakeRevengeAction", new sbyte[0], new int[5] { 75, 25, 50, 150, 100 }, new int[7], 3, new int[0], new short[0], isAdultOnly: true, isNonTaiwuTeammate: true, isNonMonk: false, -1, allowMove: true, 10, new StateConditionAndValue<StateKey>[1]
		{
			new StateConditionAndValue<StateKey>(321, 0)
		}, new StateConditionAndValue<StateKey>[0], new StateConditionAndValue<StateKey>[0], new StateEffect<StateKey>[1]
		{
			new StateEffect<StateKey>(612)
		}, new StateEffect<StateKey>[0], EPlanningActionCharacterSelectCountType.None, null, EPlanningActionCharacterSelector.None, 0, EPlanningActionCharacterSelectRange.None, 1, LocalStringManager.GetConfig("PlanningAction_language", "RefuseAppointment_383"), -1, -1, -1, 0, 0, 0, 0, new List<PresetInventoryItem>(), 82, 82, 6, -1, 0, 0, 100));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<PlanningActionItem>(384);
		CreateItems0();
		CreateItems1();
		CreateItems2();
		CreateItems3();
		CreateItems4();
		CreateItems5();
		CreateItems6();
	}
}

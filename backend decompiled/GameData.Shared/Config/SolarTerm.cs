using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class SolarTerm : ConfigData<SolarTermItem, sbyte>
{
	/// <summary>
	/// 配置表实例
	/// </summary>
	public static SolarTerm Instance = new SolarTerm();

	private readonly HashSet<string> RequiredFields = new HashSet<string>
	{
		"Name", "Desc", "Poem", "Month", "MaterialIdsOfFoodBuff", "PoisonBuffType", "DetoxBuffType", "TemplateId", "Type", "Image",
		"Sound", "FiveElementsTypesOfCombatSkillBuff"
	};

	internal override int ToInt(sbyte value)
	{
		return value;
	}

	internal override sbyte ToTemplateId(int value)
	{
		return (sbyte)value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new SolarTermItem(0, LocalStringManager.GetConfig("SolarTerm_language", "Name_0"), 0, LocalStringManager.GetConfig("SolarTerm_language", "Desc_0"), LocalStringManager.GetConfig("SolarTerm_language", "Poem_0"), "TurnChange_3", "se_solarterm_0", 1, new List<byte> { 1, 4 }, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, 5, 4, outerHealingBuff: false, innerHealingBuff: false, qiDisorderRecoveringBuff: true, healthBuff: false));
		_dataArray.Add(new SolarTermItem(1, LocalStringManager.GetConfig("SolarTerm_language", "Name_1"), 1, LocalStringManager.GetConfig("SolarTerm_language", "Desc_1"), LocalStringManager.GetConfig("SolarTerm_language", "Poem_1"), "TurnChange_4", "se_solarterm_1", 1, new List<byte> { 1 }, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, 5, 4, outerHealingBuff: false, innerHealingBuff: false, qiDisorderRecoveringBuff: true, healthBuff: false));
		_dataArray.Add(new SolarTermItem(2, LocalStringManager.GetConfig("SolarTerm_language", "Name_2"), 0, LocalStringManager.GetConfig("SolarTerm_language", "Desc_2"), LocalStringManager.GetConfig("SolarTerm_language", "Poem_2"), "TurnChange_5", "se_solarterm_2", 2, new List<byte> { 1 }, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, 1, 0, outerHealingBuff: false, innerHealingBuff: false, qiDisorderRecoveringBuff: true, healthBuff: false));
		_dataArray.Add(new SolarTermItem(3, LocalStringManager.GetConfig("SolarTerm_language", "Name_3"), 1, LocalStringManager.GetConfig("SolarTerm_language", "Desc_3"), LocalStringManager.GetConfig("SolarTerm_language", "Poem_3"), "TurnChange_6", "se_solarterm_3", 2, new List<byte> { 1, 4 }, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, 1, 0, outerHealingBuff: false, innerHealingBuff: false, qiDisorderRecoveringBuff: true, healthBuff: false));
		_dataArray.Add(new SolarTermItem(4, LocalStringManager.GetConfig("SolarTerm_language", "Name_4"), 0, LocalStringManager.GetConfig("SolarTerm_language", "Desc_4"), LocalStringManager.GetConfig("SolarTerm_language", "Poem_4"), "TurnChange_7", "se_solarterm_4", 3, new List<byte> { 1 }, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, 1, 0, outerHealingBuff: false, innerHealingBuff: false, qiDisorderRecoveringBuff: true, healthBuff: false));
		_dataArray.Add(new SolarTermItem(5, LocalStringManager.GetConfig("SolarTerm_language", "Name_5"), 1, LocalStringManager.GetConfig("SolarTerm_language", "Desc_5"), LocalStringManager.GetConfig("SolarTerm_language", "Poem_5"), "TurnChange_8", "se_solarterm_5", 3, new List<byte> { 1 }, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, 1, 0, outerHealingBuff: false, innerHealingBuff: false, qiDisorderRecoveringBuff: true, healthBuff: false));
		_dataArray.Add(new SolarTermItem(6, LocalStringManager.GetConfig("SolarTerm_language", "Name_6"), 0, LocalStringManager.GetConfig("SolarTerm_language", "Desc_6"), LocalStringManager.GetConfig("SolarTerm_language", "Poem_6"), "TurnChange_9", "se_solarterm_6", 4, new List<byte> { 3, 4 }, new List<short> { 56, 57, 58, 59, 60, 61, 62 }, 0, 1, outerHealingBuff: false, innerHealingBuff: true, qiDisorderRecoveringBuff: false, healthBuff: false));
		_dataArray.Add(new SolarTermItem(7, LocalStringManager.GetConfig("SolarTerm_language", "Name_7"), 1, LocalStringManager.GetConfig("SolarTerm_language", "Desc_7"), LocalStringManager.GetConfig("SolarTerm_language", "Poem_7"), "TurnChange_10", "se_solarterm_7", 4, new List<byte> { 3 }, new List<short> { 56, 57, 58, 59, 60, 61, 62 }, 0, 1, outerHealingBuff: false, innerHealingBuff: true, qiDisorderRecoveringBuff: false, healthBuff: false));
		_dataArray.Add(new SolarTermItem(8, LocalStringManager.GetConfig("SolarTerm_language", "Name_8"), 0, LocalStringManager.GetConfig("SolarTerm_language", "Desc_8"), LocalStringManager.GetConfig("SolarTerm_language", "Poem_8"), "TurnChange_11", "se_solarterm_8", 5, new List<byte> { 3 }, new List<short> { 56, 57, 58, 59, 60, 61, 62 }, 0, 1, outerHealingBuff: false, innerHealingBuff: true, qiDisorderRecoveringBuff: false, healthBuff: false));
		_dataArray.Add(new SolarTermItem(9, LocalStringManager.GetConfig("SolarTerm_language", "Name_9"), 1, LocalStringManager.GetConfig("SolarTerm_language", "Desc_9"), LocalStringManager.GetConfig("SolarTerm_language", "Poem_9"), "TurnChange_12", "se_solarterm_9", 5, new List<byte> { 3, 4 }, new List<short> { 56, 57, 58, 59, 60, 61, 62 }, 0, 1, outerHealingBuff: false, innerHealingBuff: true, qiDisorderRecoveringBuff: false, healthBuff: false));
		_dataArray.Add(new SolarTermItem(10, LocalStringManager.GetConfig("SolarTerm_language", "Name_10"), 0, LocalStringManager.GetConfig("SolarTerm_language", "Desc_10"), LocalStringManager.GetConfig("SolarTerm_language", "Poem_10"), "TurnChange_13", "se_solarterm_10", 6, new List<byte> { 3 }, new List<short> { 56, 57, 58, 59, 60, 61, 62 }, 3, 2, outerHealingBuff: false, innerHealingBuff: true, qiDisorderRecoveringBuff: false, healthBuff: false));
		_dataArray.Add(new SolarTermItem(11, LocalStringManager.GetConfig("SolarTerm_language", "Name_11"), 1, LocalStringManager.GetConfig("SolarTerm_language", "Desc_11"), LocalStringManager.GetConfig("SolarTerm_language", "Poem_11"), "TurnChange_14", "se_solarterm_11", 6, new List<byte> { 3 }, new List<short> { 56, 57, 58, 59, 60, 61, 62 }, 3, 2, outerHealingBuff: false, innerHealingBuff: true, qiDisorderRecoveringBuff: false, healthBuff: false));
		_dataArray.Add(new SolarTermItem(12, LocalStringManager.GetConfig("SolarTerm_language", "Name_12"), 0, LocalStringManager.GetConfig("SolarTerm_language", "Desc_12"), LocalStringManager.GetConfig("SolarTerm_language", "Poem_12"), "TurnChange_15", "se_solarterm_12", 7, new List<byte> { 0, 4 }, new List<short> { 77, 78, 79, 80, 81, 82, 83 }, 3, 2, outerHealingBuff: true, innerHealingBuff: false, qiDisorderRecoveringBuff: false, healthBuff: false));
		_dataArray.Add(new SolarTermItem(13, LocalStringManager.GetConfig("SolarTerm_language", "Name_13"), 1, LocalStringManager.GetConfig("SolarTerm_language", "Desc_13"), LocalStringManager.GetConfig("SolarTerm_language", "Poem_13"), "TurnChange_16", "se_solarterm_13", 7, new List<byte> { 0 }, new List<short> { 77, 78, 79, 80, 81, 82, 83 }, 3, 2, outerHealingBuff: true, innerHealingBuff: false, qiDisorderRecoveringBuff: false, healthBuff: false));
		_dataArray.Add(new SolarTermItem(14, LocalStringManager.GetConfig("SolarTerm_language", "Name_14"), 0, LocalStringManager.GetConfig("SolarTerm_language", "Desc_14"), LocalStringManager.GetConfig("SolarTerm_language", "Poem_14"), "TurnChange_17", "se_solarterm_14", 8, new List<byte> { 0 }, new List<short> { 77, 78, 79, 80, 81, 82, 83 }, 4, 5, outerHealingBuff: true, innerHealingBuff: false, qiDisorderRecoveringBuff: false, healthBuff: false));
		_dataArray.Add(new SolarTermItem(15, LocalStringManager.GetConfig("SolarTerm_language", "Name_15"), 1, LocalStringManager.GetConfig("SolarTerm_language", "Desc_15"), LocalStringManager.GetConfig("SolarTerm_language", "Poem_15"), "TurnChange_18", "se_solarterm_15", 8, new List<byte> { 0, 4 }, new List<short> { 77, 78, 79, 80, 81, 82, 83 }, 4, 5, outerHealingBuff: true, innerHealingBuff: false, qiDisorderRecoveringBuff: false, healthBuff: false));
		_dataArray.Add(new SolarTermItem(16, LocalStringManager.GetConfig("SolarTerm_language", "Name_16"), 0, LocalStringManager.GetConfig("SolarTerm_language", "Desc_16"), LocalStringManager.GetConfig("SolarTerm_language", "Poem_16"), "TurnChange_19", "se_solarterm_16", 9, new List<byte> { 0 }, new List<short> { 77, 78, 79, 80, 81, 82, 83 }, 4, 5, outerHealingBuff: true, innerHealingBuff: false, qiDisorderRecoveringBuff: false, healthBuff: false));
		_dataArray.Add(new SolarTermItem(17, LocalStringManager.GetConfig("SolarTerm_language", "Name_17"), 1, LocalStringManager.GetConfig("SolarTerm_language", "Desc_17"), LocalStringManager.GetConfig("SolarTerm_language", "Poem_17"), "TurnChange_20", "se_solarterm_17", 9, new List<byte> { 0 }, new List<short> { 77, 78, 79, 80, 81, 82, 83 }, 4, 5, outerHealingBuff: true, innerHealingBuff: false, qiDisorderRecoveringBuff: false, healthBuff: false));
		_dataArray.Add(new SolarTermItem(18, LocalStringManager.GetConfig("SolarTerm_language", "Name_18"), 0, LocalStringManager.GetConfig("SolarTerm_language", "Desc_18"), LocalStringManager.GetConfig("SolarTerm_language", "Poem_18"), "TurnChange_21", "se_solarterm_18", 10, new List<byte> { 2, 4 }, new List<short> { 63, 64, 65, 66, 67, 68, 69 }, 2, 3, outerHealingBuff: false, innerHealingBuff: false, qiDisorderRecoveringBuff: false, healthBuff: true));
		_dataArray.Add(new SolarTermItem(19, LocalStringManager.GetConfig("SolarTerm_language", "Name_19"), 1, LocalStringManager.GetConfig("SolarTerm_language", "Desc_19"), LocalStringManager.GetConfig("SolarTerm_language", "Poem_19"), "TurnChange_22", "se_solarterm_19", 10, new List<byte> { 2 }, new List<short> { 63, 64, 65, 66, 67, 68, 69 }, 2, 3, outerHealingBuff: false, innerHealingBuff: false, qiDisorderRecoveringBuff: false, healthBuff: true));
		_dataArray.Add(new SolarTermItem(20, LocalStringManager.GetConfig("SolarTerm_language", "Name_20"), 0, LocalStringManager.GetConfig("SolarTerm_language", "Desc_20"), LocalStringManager.GetConfig("SolarTerm_language", "Poem_20"), "TurnChange_23", "se_solarterm_20", 11, new List<byte> { 2 }, new List<short> { 63, 64, 65, 66, 67, 68, 69 }, 2, 3, outerHealingBuff: false, innerHealingBuff: false, qiDisorderRecoveringBuff: false, healthBuff: true));
		_dataArray.Add(new SolarTermItem(21, LocalStringManager.GetConfig("SolarTerm_language", "Name_21"), 1, LocalStringManager.GetConfig("SolarTerm_language", "Desc_21"), LocalStringManager.GetConfig("SolarTerm_language", "Poem_21"), "TurnChange_24", "se_solarterm_21", 11, new List<byte> { 2, 4 }, new List<short> { 63, 64, 65, 66, 67, 68, 69 }, 2, 3, outerHealingBuff: false, innerHealingBuff: false, qiDisorderRecoveringBuff: false, healthBuff: true));
		_dataArray.Add(new SolarTermItem(22, LocalStringManager.GetConfig("SolarTerm_language", "Name_22"), 0, LocalStringManager.GetConfig("SolarTerm_language", "Desc_22"), LocalStringManager.GetConfig("SolarTerm_language", "Poem_22"), "TurnChange_1", "se_solarterm_22", 0, new List<byte> { 2 }, new List<short> { 63, 64, 65, 66, 67, 68, 69 }, 5, 4, outerHealingBuff: false, innerHealingBuff: false, qiDisorderRecoveringBuff: false, healthBuff: true));
		_dataArray.Add(new SolarTermItem(23, LocalStringManager.GetConfig("SolarTerm_language", "Name_23"), 1, LocalStringManager.GetConfig("SolarTerm_language", "Desc_23"), LocalStringManager.GetConfig("SolarTerm_language", "Poem_23"), "TurnChange_2", "se_solarterm_23", 0, new List<byte> { 2 }, new List<short> { 63, 64, 65, 66, 67, 68, 69 }, 5, 4, outerHealingBuff: false, innerHealingBuff: false, qiDisorderRecoveringBuff: false, healthBuff: true));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<SolarTermItem>(24);
		CreateItems0();
	}
}

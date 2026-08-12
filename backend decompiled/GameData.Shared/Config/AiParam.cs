using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class AiParam : ConfigData<AiParamItem, int>
{
	/// <summary>
	/// 配置表实例
	/// </summary>
	public static AiParam Instance = new AiParam();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "Desc", "PrintingAliases", "TemplateId", "Type" };

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
		_dataArray.Add(new AiParamItem(0, EAiParamType.Int, LocalStringManager.GetConfig("AiParam_language", "Name_0"), LocalStringManager.GetConfig("AiParam_language", "Desc_0"), new string[0], new string[0]));
		_dataArray.Add(new AiParamItem(1, EAiParamType.Bool, LocalStringManager.GetConfig("AiParam_language", "Name_1"), LocalStringManager.GetConfig("AiParam_language", "Desc_1"), new string[2]
		{
			LocalStringManager.GetConfig("AiParam_language", "PrintingAliases_1_0"),
			LocalStringManager.GetConfig("AiParam_language", "PrintingAliases_1_1")
		}, new string[2] { "True", "False" }));
		_dataArray.Add(new AiParamItem(2, EAiParamType.CombatSkill, LocalStringManager.GetConfig("AiParam_language", "Name_2"), LocalStringManager.GetConfig("AiParam_language", "Desc_2"), new string[0], new string[0]));
		_dataArray.Add(new AiParamItem(3, EAiParamType.IsAlly, LocalStringManager.GetConfig("AiParam_language", "Name_3"), LocalStringManager.GetConfig("AiParam_language", "Desc_3"), new string[2]
		{
			LocalStringManager.GetConfig("AiParam_language", "PrintingAliases_3_0"),
			LocalStringManager.GetConfig("AiParam_language", "PrintingAliases_3_1")
		}, new string[2] { "True", "False" }));
		_dataArray.Add(new AiParamItem(4, EAiParamType.String, LocalStringManager.GetConfig("AiParam_language", "Name_4"), LocalStringManager.GetConfig("AiParam_language", "Desc_4"), new string[0], new string[0]));
		_dataArray.Add(new AiParamItem(5, EAiParamType.CombatDifficulty, LocalStringManager.GetConfig("AiParam_language", "Name_5"), LocalStringManager.GetConfig("AiParam_language", "Desc_5"), new string[0], new string[0]));
		_dataArray.Add(new AiParamItem(6, EAiParamType.TeammateCommand, LocalStringManager.GetConfig("AiParam_language", "Name_6"), LocalStringManager.GetConfig("AiParam_language", "Desc_6"), new string[0], new string[0]));
		_dataArray.Add(new AiParamItem(7, EAiParamType.ProactiveSkillType, LocalStringManager.GetConfig("AiParam_language", "Name_7"), LocalStringManager.GetConfig("AiParam_language", "Desc_7"), new string[0], new string[0]));
		_dataArray.Add(new AiParamItem(8, EAiParamType.OtherActionType, LocalStringManager.GetConfig("AiParam_language", "Name_8"), LocalStringManager.GetConfig("AiParam_language", "Desc_8"), new string[0], new string[0]));
		_dataArray.Add(new AiParamItem(9, EAiParamType.IsForward, LocalStringManager.GetConfig("AiParam_language", "Name_9"), LocalStringManager.GetConfig("AiParam_language", "Desc_9"), new string[2]
		{
			LocalStringManager.GetConfig("AiParam_language", "PrintingAliases_9_0"),
			LocalStringManager.GetConfig("AiParam_language", "PrintingAliases_9_1")
		}, new string[2] { "True", "False" }));
		_dataArray.Add(new AiParamItem(10, EAiParamType.BodyPartType, LocalStringManager.GetConfig("AiParam_language", "Name_10"), LocalStringManager.GetConfig("AiParam_language", "Desc_10"), new string[0], new string[0]));
		_dataArray.Add(new AiParamItem(11, EAiParamType.Expression, LocalStringManager.GetConfig("AiParam_language", "Name_11"), LocalStringManager.GetConfig("AiParam_language", "Desc_11"), new string[0], new string[0]));
		_dataArray.Add(new AiParamItem(12, EAiParamType.IsDirect, LocalStringManager.GetConfig("AiParam_language", "Name_12"), LocalStringManager.GetConfig("AiParam_language", "Desc_12"), new string[2]
		{
			LocalStringManager.GetConfig("AiParam_language", "PrintingAliases_12_0"),
			LocalStringManager.GetConfig("AiParam_language", "PrintingAliases_12_1")
		}, new string[2] { "True", "False" }));
		_dataArray.Add(new AiParamItem(13, EAiParamType.IsInner, LocalStringManager.GetConfig("AiParam_language", "Name_13"), LocalStringManager.GetConfig("AiParam_language", "Desc_13"), new string[2]
		{
			LocalStringManager.GetConfig("AiParam_language", "PrintingAliases_13_0"),
			LocalStringManager.GetConfig("AiParam_language", "PrintingAliases_13_1")
		}, new string[2] { "True", "False" }));
		_dataArray.Add(new AiParamItem(14, EAiParamType.PoisonType, LocalStringManager.GetConfig("AiParam_language", "Name_14"), LocalStringManager.GetConfig("AiParam_language", "Desc_14"), new string[0], new string[0]));
		_dataArray.Add(new AiParamItem(15, EAiParamType.IsNotOnlyInCombat, LocalStringManager.GetConfig("AiParam_language", "Name_15"), LocalStringManager.GetConfig("AiParam_language", "Desc_15"), new string[2]
		{
			LocalStringManager.GetConfig("AiParam_language", "PrintingAliases_15_0"),
			LocalStringManager.GetConfig("AiParam_language", "PrintingAliases_15_1")
		}, new string[2] { "True", "False" }));
		_dataArray.Add(new AiParamItem(16, EAiParamType.IsGood, LocalStringManager.GetConfig("AiParam_language", "Name_16"), LocalStringManager.GetConfig("AiParam_language", "Desc_16"), new string[2]
		{
			LocalStringManager.GetConfig("AiParam_language", "PrintingAliases_16_0"),
			LocalStringManager.GetConfig("AiParam_language", "PrintingAliases_16_1")
		}, new string[2] { "True", "False" }));
		_dataArray.Add(new AiParamItem(17, EAiParamType.WugType, LocalStringManager.GetConfig("AiParam_language", "Name_17"), LocalStringManager.GetConfig("AiParam_language", "Desc_17"), new string[8]
		{
			LocalStringManager.GetConfig("AiParam_language", "PrintingAliases_17_0"),
			LocalStringManager.GetConfig("AiParam_language", "PrintingAliases_17_1"),
			LocalStringManager.GetConfig("AiParam_language", "PrintingAliases_17_2"),
			LocalStringManager.GetConfig("AiParam_language", "PrintingAliases_17_3"),
			LocalStringManager.GetConfig("AiParam_language", "PrintingAliases_17_4"),
			LocalStringManager.GetConfig("AiParam_language", "PrintingAliases_17_5"),
			LocalStringManager.GetConfig("AiParam_language", "PrintingAliases_17_6"),
			LocalStringManager.GetConfig("AiParam_language", "PrintingAliases_17_7")
		}, new string[8] { "0", "1", "2", "3", "4", "5", "6", "7" }));
		_dataArray.Add(new AiParamItem(18, EAiParamType.NeiliAllocationType, LocalStringManager.GetConfig("AiParam_language", "Name_18"), LocalStringManager.GetConfig("AiParam_language", "Desc_18"), new string[4]
		{
			LocalStringManager.GetConfig("AiParam_language", "PrintingAliases_18_0"),
			LocalStringManager.GetConfig("AiParam_language", "PrintingAliases_18_1"),
			LocalStringManager.GetConfig("AiParam_language", "PrintingAliases_18_2"),
			LocalStringManager.GetConfig("AiParam_language", "PrintingAliases_18_3")
		}, new string[4] { "0", "1", "2", "3" }));
		_dataArray.Add(new AiParamItem(19, EAiParamType.TrickType, LocalStringManager.GetConfig("AiParam_language", "Name_19"), LocalStringManager.GetConfig("AiParam_language", "Desc_19"), new string[0], new string[0]));
		_dataArray.Add(new AiParamItem(20, EAiParamType.Weapon, LocalStringManager.GetConfig("AiParam_language", "Name_20"), LocalStringManager.GetConfig("AiParam_language", "Desc_20"), new string[0], new string[0]));
		_dataArray.Add(new AiParamItem(21, EAiParamType.WeaponSubType, LocalStringManager.GetConfig("AiParam_language", "Name_21"), LocalStringManager.GetConfig("AiParam_language", "Desc_21"), new string[0], new string[0]));
		_dataArray.Add(new AiParamItem(22, EAiParamType.FiveElementsType, LocalStringManager.GetConfig("AiParam_language", "Name_22"), LocalStringManager.GetConfig("AiParam_language", "Desc_22"), new string[6]
		{
			LocalStringManager.GetConfig("AiParam_language", "PrintingAliases_22_0"),
			LocalStringManager.GetConfig("AiParam_language", "PrintingAliases_22_1"),
			LocalStringManager.GetConfig("AiParam_language", "PrintingAliases_22_2"),
			LocalStringManager.GetConfig("AiParam_language", "PrintingAliases_22_3"),
			LocalStringManager.GetConfig("AiParam_language", "PrintingAliases_22_4"),
			LocalStringManager.GetConfig("AiParam_language", "PrintingAliases_22_5")
		}, new string[6] { "0", "1", "2", "3", "4", "5" }));
		_dataArray.Add(new AiParamItem(23, EAiParamType.CombatType, LocalStringManager.GetConfig("AiParam_language", "Name_23"), LocalStringManager.GetConfig("AiParam_language", "Desc_23"), new string[0], new string[0]));
		_dataArray.Add(new AiParamItem(24, EAiParamType.CombatStateName, LocalStringManager.GetConfig("AiParam_language", "Name_24"), LocalStringManager.GetConfig("AiParam_language", "Desc_24"), new string[0], new string[0]));
		_dataArray.Add(new AiParamItem(25, EAiParamType.Misc, LocalStringManager.GetConfig("AiParam_language", "Name_25"), LocalStringManager.GetConfig("AiParam_language", "Desc_25"), new string[0], new string[0]));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<AiParamItem>(26);
		CreateItems0();
	}
}

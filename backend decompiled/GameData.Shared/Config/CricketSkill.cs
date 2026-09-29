using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class CricketSkill : ConfigData<CricketSkillItem, int>
{
	public static CricketSkill Instance = new CricketSkill();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "EffectCondition", "EffectDesc", "EffectTips", "TemplateId" };

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
		_dataArray.Add(new CricketSkillItem(0, LocalStringManager.GetConfig("CricketSkill_language", "Name_0"), LocalStringManager.GetConfig("CricketSkill_language", "EffectCondition_0"), LocalStringManager.GetConfig("CricketSkill_language", "EffectDesc_0"), LocalStringManager.GetConfig("CricketSkill_language", "EffectTips_0")));
		_dataArray.Add(new CricketSkillItem(1, LocalStringManager.GetConfig("CricketSkill_language", "Name_1"), LocalStringManager.GetConfig("CricketSkill_language", "EffectCondition_1"), LocalStringManager.GetConfig("CricketSkill_language", "EffectDesc_1"), LocalStringManager.GetConfig("CricketSkill_language", "EffectTips_1")));
		_dataArray.Add(new CricketSkillItem(2, LocalStringManager.GetConfig("CricketSkill_language", "Name_2"), LocalStringManager.GetConfig("CricketSkill_language", "EffectCondition_2"), LocalStringManager.GetConfig("CricketSkill_language", "EffectDesc_2"), LocalStringManager.GetConfig("CricketSkill_language", "EffectTips_2")));
		_dataArray.Add(new CricketSkillItem(3, LocalStringManager.GetConfig("CricketSkill_language", "Name_3"), LocalStringManager.GetConfig("CricketSkill_language", "EffectCondition_3"), LocalStringManager.GetConfig("CricketSkill_language", "EffectDesc_3"), LocalStringManager.GetConfig("CricketSkill_language", "EffectTips_3")));
		_dataArray.Add(new CricketSkillItem(4, LocalStringManager.GetConfig("CricketSkill_language", "Name_4"), LocalStringManager.GetConfig("CricketSkill_language", "EffectCondition_4"), LocalStringManager.GetConfig("CricketSkill_language", "EffectDesc_4"), LocalStringManager.GetConfig("CricketSkill_language", "EffectTips_4")));
		_dataArray.Add(new CricketSkillItem(5, LocalStringManager.GetConfig("CricketSkill_language", "Name_5"), LocalStringManager.GetConfig("CricketSkill_language", "EffectCondition_5"), LocalStringManager.GetConfig("CricketSkill_language", "EffectDesc_5"), LocalStringManager.GetConfig("CricketSkill_language", "EffectTips_5")));
		_dataArray.Add(new CricketSkillItem(6, LocalStringManager.GetConfig("CricketSkill_language", "Name_6"), LocalStringManager.GetConfig("CricketSkill_language", "EffectCondition_6"), LocalStringManager.GetConfig("CricketSkill_language", "EffectDesc_6"), LocalStringManager.GetConfig("CricketSkill_language", "EffectTips_6")));
		_dataArray.Add(new CricketSkillItem(7, LocalStringManager.GetConfig("CricketSkill_language", "Name_7"), LocalStringManager.GetConfig("CricketSkill_language", "EffectCondition_7"), LocalStringManager.GetConfig("CricketSkill_language", "EffectDesc_7"), LocalStringManager.GetConfig("CricketSkill_language", "EffectTips_7")));
		_dataArray.Add(new CricketSkillItem(8, LocalStringManager.GetConfig("CricketSkill_language", "Name_8"), LocalStringManager.GetConfig("CricketSkill_language", "EffectCondition_8"), LocalStringManager.GetConfig("CricketSkill_language", "EffectDesc_8"), LocalStringManager.GetConfig("CricketSkill_language", "EffectTips_8")));
		_dataArray.Add(new CricketSkillItem(9, LocalStringManager.GetConfig("CricketSkill_language", "Name_9"), LocalStringManager.GetConfig("CricketSkill_language", "EffectCondition_9"), LocalStringManager.GetConfig("CricketSkill_language", "EffectDesc_9"), LocalStringManager.GetConfig("CricketSkill_language", "EffectTips_9")));
		_dataArray.Add(new CricketSkillItem(10, LocalStringManager.GetConfig("CricketSkill_language", "Name_10"), LocalStringManager.GetConfig("CricketSkill_language", "EffectCondition_10"), LocalStringManager.GetConfig("CricketSkill_language", "EffectDesc_10"), LocalStringManager.GetConfig("CricketSkill_language", "EffectTips_10")));
		_dataArray.Add(new CricketSkillItem(11, LocalStringManager.GetConfig("CricketSkill_language", "Name_11"), LocalStringManager.GetConfig("CricketSkill_language", "EffectCondition_11"), LocalStringManager.GetConfig("CricketSkill_language", "EffectDesc_11"), LocalStringManager.GetConfig("CricketSkill_language", "EffectTips_11")));
		_dataArray.Add(new CricketSkillItem(12, LocalStringManager.GetConfig("CricketSkill_language", "Name_12"), LocalStringManager.GetConfig("CricketSkill_language", "EffectCondition_12"), LocalStringManager.GetConfig("CricketSkill_language", "EffectDesc_12"), LocalStringManager.GetConfig("CricketSkill_language", "EffectTips_12")));
		_dataArray.Add(new CricketSkillItem(13, LocalStringManager.GetConfig("CricketSkill_language", "Name_13"), LocalStringManager.GetConfig("CricketSkill_language", "EffectCondition_13"), LocalStringManager.GetConfig("CricketSkill_language", "EffectDesc_13"), LocalStringManager.GetConfig("CricketSkill_language", "EffectTips_13")));
		_dataArray.Add(new CricketSkillItem(14, LocalStringManager.GetConfig("CricketSkill_language", "Name_14"), LocalStringManager.GetConfig("CricketSkill_language", "EffectCondition_14"), LocalStringManager.GetConfig("CricketSkill_language", "EffectDesc_14"), LocalStringManager.GetConfig("CricketSkill_language", "EffectTips_14")));
		_dataArray.Add(new CricketSkillItem(15, LocalStringManager.GetConfig("CricketSkill_language", "Name_15"), LocalStringManager.GetConfig("CricketSkill_language", "EffectCondition_15"), LocalStringManager.GetConfig("CricketSkill_language", "EffectDesc_15"), LocalStringManager.GetConfig("CricketSkill_language", "EffectTips_15")));
		_dataArray.Add(new CricketSkillItem(16, LocalStringManager.GetConfig("CricketSkill_language", "Name_16"), LocalStringManager.GetConfig("CricketSkill_language", "EffectCondition_16"), LocalStringManager.GetConfig("CricketSkill_language", "EffectDesc_16"), LocalStringManager.GetConfig("CricketSkill_language", "EffectTips_16")));
		_dataArray.Add(new CricketSkillItem(17, LocalStringManager.GetConfig("CricketSkill_language", "Name_17"), LocalStringManager.GetConfig("CricketSkill_language", "EffectCondition_17"), LocalStringManager.GetConfig("CricketSkill_language", "EffectDesc_17"), LocalStringManager.GetConfig("CricketSkill_language", "EffectTips_17")));
		_dataArray.Add(new CricketSkillItem(18, LocalStringManager.GetConfig("CricketSkill_language", "Name_18"), LocalStringManager.GetConfig("CricketSkill_language", "EffectCondition_18"), LocalStringManager.GetConfig("CricketSkill_language", "EffectDesc_18"), LocalStringManager.GetConfig("CricketSkill_language", "EffectTips_18")));
		_dataArray.Add(new CricketSkillItem(19, LocalStringManager.GetConfig("CricketSkill_language", "Name_19"), LocalStringManager.GetConfig("CricketSkill_language", "EffectCondition_19"), LocalStringManager.GetConfig("CricketSkill_language", "EffectDesc_19"), LocalStringManager.GetConfig("CricketSkill_language", "EffectTips_19")));
		_dataArray.Add(new CricketSkillItem(20, LocalStringManager.GetConfig("CricketSkill_language", "Name_20"), LocalStringManager.GetConfig("CricketSkill_language", "EffectCondition_20"), LocalStringManager.GetConfig("CricketSkill_language", "EffectDesc_20"), LocalStringManager.GetConfig("CricketSkill_language", "EffectTips_20")));
		_dataArray.Add(new CricketSkillItem(21, LocalStringManager.GetConfig("CricketSkill_language", "Name_21"), LocalStringManager.GetConfig("CricketSkill_language", "EffectCondition_21"), LocalStringManager.GetConfig("CricketSkill_language", "EffectDesc_21"), LocalStringManager.GetConfig("CricketSkill_language", "EffectTips_21")));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<CricketSkillItem>(22);
		CreateItems0();
	}
}

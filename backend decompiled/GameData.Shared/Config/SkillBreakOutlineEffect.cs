using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class SkillBreakOutlineEffect : ConfigData<SkillBreakOutlineEffectItem, sbyte>
{
	/// <summary>
	/// 配置表实例
	/// </summary>
	public static SkillBreakOutlineEffect Instance = new SkillBreakOutlineEffect();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Desc", "DescShort", "TemplateId" };

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
		_dataArray.Add(new SkillBreakOutlineEffectItem(0, LocalStringManager.GetConfig("SkillBreakOutlineEffect_language", "Desc_0"), 25, -50, 0, 0, 75, 0, 3, 0, 100, 0, 0, LocalStringManager.GetConfig("SkillBreakOutlineEffect_language", "DescShort_0")));
		_dataArray.Add(new SkillBreakOutlineEffectItem(1, LocalStringManager.GetConfig("SkillBreakOutlineEffect_language", "Desc_1"), 0, 0, 25, 50, 0, 0, 3, 0, 0, 0, 50, LocalStringManager.GetConfig("SkillBreakOutlineEffect_language", "DescShort_1")));
		_dataArray.Add(new SkillBreakOutlineEffectItem(2, LocalStringManager.GetConfig("SkillBreakOutlineEffect_language", "Desc_2"), 0, 0, 0, 50, 0, 0, 2, 0, 0, 0, 0, LocalStringManager.GetConfig("SkillBreakOutlineEffect_language", "DescShort_2")));
		_dataArray.Add(new SkillBreakOutlineEffectItem(3, LocalStringManager.GetConfig("SkillBreakOutlineEffect_language", "Desc_3"), 0, 0, -25, 50, 0, 0, 3, 0, 0, 100, 0, LocalStringManager.GetConfig("SkillBreakOutlineEffect_language", "DescShort_3")));
		_dataArray.Add(new SkillBreakOutlineEffectItem(4, LocalStringManager.GetConfig("SkillBreakOutlineEffect_language", "Desc_4"), -25, 50, 0, 0, 0, 75, 3, 50, 0, 0, 0, LocalStringManager.GetConfig("SkillBreakOutlineEffect_language", "DescShort_4")));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<SkillBreakOutlineEffectItem>(5);
		CreateItems0();
	}
}

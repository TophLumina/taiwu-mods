using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class SkillGradeData : ConfigData<SkillGradeDataItem, sbyte>
{
	public static SkillGradeData Instance = new SkillGradeData();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "TemplateId", "PracticeQualificationRequirement", "PracticeExpCost" };

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
		_dataArray.Add(new SkillGradeDataItem(0, 0, 30, 50, 30, 10, 1));
		_dataArray.Add(new SkillGradeDataItem(1, 1, 40, 100, 40, 20, 1));
		_dataArray.Add(new SkillGradeDataItem(2, 2, 60, 200, 50, 40, 1));
		_dataArray.Add(new SkillGradeDataItem(3, 3, 90, 300, 60, 60, 1));
		_dataArray.Add(new SkillGradeDataItem(4, 4, 130, 450, 70, 90, 1));
		_dataArray.Add(new SkillGradeDataItem(5, 5, 180, 600, 80, 120, 1));
		_dataArray.Add(new SkillGradeDataItem(6, 6, 240, 800, 90, 160, 1));
		_dataArray.Add(new SkillGradeDataItem(7, 7, 310, 1000, 100, 200, 1));
		_dataArray.Add(new SkillGradeDataItem(8, 8, 390, 1300, 110, 260, 1));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<SkillGradeDataItem>(9);
		CreateItems0();
	}
}

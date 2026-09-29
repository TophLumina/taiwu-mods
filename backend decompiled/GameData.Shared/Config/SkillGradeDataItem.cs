using System;
using Config.Common;

namespace Config;

[Serializable]
public class SkillGradeDataItem : ConfigItem<SkillGradeDataItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly sbyte Grade;

	public readonly short ReadingAttainmentRequirement;

	public readonly short ReadingExpGainPerPage;

	public readonly short PracticeQualificationRequirement;

	public readonly short PracticeExpCost;

	public readonly sbyte ClearBreakPlateCd;

	public SkillGradeDataItem(sbyte templateId, sbyte grade, short readingAttainmentRequirement, short readingExpGainPerPage, short practiceQualificationRequirement, short practiceExpCost, sbyte clearBreakPlateCd)
	{
		TemplateId = templateId;
		Grade = grade;
		ReadingAttainmentRequirement = readingAttainmentRequirement;
		ReadingExpGainPerPage = readingExpGainPerPage;
		PracticeQualificationRequirement = practiceQualificationRequirement;
		PracticeExpCost = practiceExpCost;
		ClearBreakPlateCd = clearBreakPlateCd;
	}

	public SkillGradeDataItem()
	{
		TemplateId = 0;
		Grade = -1;
		ReadingAttainmentRequirement = -1;
		ReadingExpGainPerPage = -1;
		PracticeQualificationRequirement = 0;
		PracticeExpCost = 0;
		ClearBreakPlateCd = -1;
	}

	public SkillGradeDataItem(sbyte templateId, SkillGradeDataItem other)
	{
		TemplateId = templateId;
		Grade = other.Grade;
		ReadingAttainmentRequirement = other.ReadingAttainmentRequirement;
		ReadingExpGainPerPage = other.ReadingExpGainPerPage;
		PracticeQualificationRequirement = other.PracticeQualificationRequirement;
		PracticeExpCost = other.PracticeExpCost;
		ClearBreakPlateCd = other.ClearBreakPlateCd;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override SkillGradeDataItem Duplicate(int templateId)
	{
		return new SkillGradeDataItem((sbyte)templateId, this);
	}
}

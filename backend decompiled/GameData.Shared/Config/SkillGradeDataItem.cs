using System;
using Config.Common;

namespace Config;

[Serializable]
public class SkillGradeDataItem : ConfigItem<SkillGradeDataItem, sbyte>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly sbyte TemplateId;

	/// <summary>
	/// 品级
	/// - 8为最高品级
	/// </summary>
	public readonly sbyte Grade;

	/// <summary>
	/// 研读造诣需求
	/// - 人物的造诣决定研读书籍的速度：基础速度 * （当前造诣/造诣需求）% + 其它速度加成
	/// </summary>
	public readonly short ReadingAttainmentRequirement;

	/// <summary>
	/// 研读历练收益
	/// - 每读完一页获得的历练值
	/// </summary>
	public readonly short ReadingExpGainPerPage;

	/// <summary>
	/// 突破资质需求
	/// - 用于计算修习收益、突破步数
	/// </summary>
	public readonly short PracticeQualificationRequirement;

	/// <summary>
	/// 修习需要的历练
	/// - 修习每次需要消耗的历练值
	/// </summary>
	public readonly short PracticeExpCost;

	/// <summary>
	/// 重修间隔时间
	/// - 重修之后间隔多久可以再次重修
	/// </summary>
	public readonly sbyte ClearBreakPlateCd;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="grade">品级 - 8为最高品级</param>
	/// <param name="readingAttainmentRequirement">研读造诣需求 - 人物的造诣决定研读书籍的速度：基础速度 * （当前造诣/造诣需求）% + 其它速度加成</param>
	/// <param name="readingExpGainPerPage">研读历练收益 - 每读完一页获得的历练值</param>
	/// <param name="practiceQualificationRequirement">突破资质需求 - 用于计算修习收益、突破步数</param>
	/// <param name="practiceExpCost">修习需要的历练 - 修习每次需要消耗的历练值</param>
	/// <param name="clearBreakPlateCd">重修间隔时间 - 重修之后间隔多久可以再次重修</param>
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

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
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

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
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

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override SkillGradeDataItem Duplicate(int templateId)
	{
		return new SkillGradeDataItem((sbyte)templateId, this);
	}
}

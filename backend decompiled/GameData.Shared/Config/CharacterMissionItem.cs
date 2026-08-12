using System;
using Config.Common;

namespace Config;

[Serializable]
public class CharacterMissionItem : ConfigItem<CharacterMissionItem, int>
{
	/// <summary>
	/// 目标集 ID
	/// </summary>
	public readonly int TemplateId;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 隐藏
	/// - 不显示在UI上
	/// </summary>
	public readonly bool IsHidden;

	/// <summary>
	/// 分类
	/// - 同一分组的不同分类的目标集，过月时只有一个会被选择进行，选择哪个进行，取决于人物的七元优先，如果七元优先相同，则以默认优先为准
	/// </summary>
	public readonly ECharacterMissionType Type;

	/// <summary>
	/// 分组
	/// - 当人物有同个分组的多个任务时，过月只会选择其中一个任务的目标去满足；而有多个不同分组的任务时，过月会同时尝试满足多个目标
	/// </summary>
	public readonly ECharacterMissionGroup Group;

	/// <summary>
	/// 完成期限
	/// - 当此时间计数减少为0时，如果还有目标没有达成，任务就会失败，并进入保留时间
	/// </summary>
	public readonly sbyte Duration;

	/// <summary>
	/// 保留时间
	/// - 在任务的目标全部达成或失败后，任务会保留多少个月才将任务移除；在保留时间内，如果任务的目标达成情况发生变化，也不会再影响目标的达成状态
	/// </summary>
	public readonly sbyte KeepDuration;

	/// <summary>
	/// 进行中发言
	/// </summary>
	public readonly string[] BubbleContentInProgress;

	/// <summary>
	/// 成功保留发言
	/// </summary>
	public readonly string[] BubbleContentSuccess;

	/// <summary>
	/// 失改保留发言
	/// </summary>
	public readonly string[] BubbleContentFail;

	/// <summary>
	/// 默认优先
	/// - 当多个同分组的任务对应的七元相等时，根据任务的默认优先级决定优先去完成哪个任务中的目标
	/// </summary>
	public readonly sbyte Priority;

	/// <summary>
	/// 七元优先
	/// - 过月时，人物如果有分组相同的多个任务时，根据该配置中设置的七元（有多项取最高）为优先级选择去完成哪个任务中的目标（目标也有目标的优先级）；当两个同分组的任务对应的七元相等时，根据任务的默认优先级决定去完成哪个任务中的目标
	/// </summary>
	public readonly sbyte[] PersonalityTypes;

	/// <summary>
	/// 目标列表
	/// </summary>
	public readonly int[] Goals;

	/// <summary>
	/// 州域条件
	/// - 只对分类为州域的项生效.
	/// </summary>
	public readonly sbyte RequiredMapState;

	/// <summary>
	/// 组织条件
	/// - 只对分类为门派的项生效.
	/// </summary>
	public readonly sbyte RequiredOrganization;

	/// <summary>
	/// 组织善恶条件
	/// - 只对分类为品级的项生效.
	/// </summary>
	public readonly sbyte RequiredGoodness;

	/// <summary>
	/// 品级分组条件
	/// - 只对分类为品级的项生效.
	/// </summary>
	public readonly sbyte RequiredGradeGroup;

	/// <summary>
	/// 身份条件
	/// - 只对分类为身份的项生效.
	/// </summary>
	public readonly short RequiredOrgMember;

	/// <summary>
	/// 立场条件
	/// </summary>
	public readonly sbyte RequiredBehaviorType;

	/// <summary>
	/// 技艺类型
	/// </summary>
	public readonly sbyte LifeSkillType;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">目标集 ID</param>
	/// <param name="name">名称</param>
	/// <param name="isHidden">隐藏 - 不显示在UI上</param>
	/// <param name="type">分类 - 同一分组的不同分类的目标集，过月时只有一个会被选择进行，选择哪个进行，取决于人物的七元优先，如果七元优先相同，则以默认优先为准</param>
	/// <param name="group">分组 - 当人物有同个分组的多个任务时，过月只会选择其中一个任务的目标去满足；而有多个不同分组的任务时，过月会同时尝试满足多个目标</param>
	/// <param name="duration">完成期限 - 当此时间计数减少为0时，如果还有目标没有达成，任务就会失败，并进入保留时间</param>
	/// <param name="keepDuration">保留时间 - 在任务的目标全部达成或失败后，任务会保留多少个月才将任务移除；在保留时间内，如果任务的目标达成情况发生变化，也不会再影响目标的达成状态</param>
	/// <param name="bubbleContentInProgress">进行中发言</param>
	/// <param name="bubbleContentSuccess">成功保留发言</param>
	/// <param name="bubbleContentFail">失改保留发言</param>
	/// <param name="priority">默认优先 - 当多个同分组的任务对应的七元相等时，根据任务的默认优先级决定优先去完成哪个任务中的目标</param>
	/// <param name="personalityTypes">七元优先 - 过月时，人物如果有分组相同的多个任务时，根据该配置中设置的七元（有多项取最高）为优先级选择去完成哪个任务中的目标（目标也有目标的优先级）；当两个同分组的任务对应的七元相等时，根据任务的默认优先级决定去完成哪个任务中的目标</param>
	/// <param name="goals">目标列表</param>
	/// <param name="requiredMapState">州域条件 - 只对分类为州域的项生效.</param>
	/// <param name="requiredOrganization">组织条件 - 只对分类为门派的项生效.</param>
	/// <param name="requiredGoodness">组织善恶条件 - 只对分类为品级的项生效.</param>
	/// <param name="requiredGradeGroup">品级分组条件 - 只对分类为品级的项生效.</param>
	/// <param name="requiredOrgMember">身份条件 - 只对分类为身份的项生效.</param>
	/// <param name="requiredBehaviorType">立场条件</param>
	/// <param name="lifeSkillType">技艺类型</param>
	public CharacterMissionItem(int templateId, string name, bool isHidden, ECharacterMissionType type, ECharacterMissionGroup group, sbyte duration, sbyte keepDuration, string[] bubbleContentInProgress, string[] bubbleContentSuccess, string[] bubbleContentFail, sbyte priority, sbyte[] personalityTypes, int[] goals, sbyte requiredMapState, sbyte requiredOrganization, sbyte requiredGoodness, sbyte requiredGradeGroup, short requiredOrgMember, sbyte requiredBehaviorType, sbyte lifeSkillType)
	{
		TemplateId = templateId;
		Name = name;
		IsHidden = isHidden;
		Type = type;
		Group = group;
		Duration = duration;
		KeepDuration = keepDuration;
		BubbleContentInProgress = bubbleContentInProgress;
		BubbleContentSuccess = bubbleContentSuccess;
		BubbleContentFail = bubbleContentFail;
		Priority = priority;
		PersonalityTypes = personalityTypes;
		Goals = goals;
		RequiredMapState = requiredMapState;
		RequiredOrganization = requiredOrganization;
		RequiredGoodness = requiredGoodness;
		RequiredGradeGroup = requiredGradeGroup;
		RequiredOrgMember = requiredOrgMember;
		RequiredBehaviorType = requiredBehaviorType;
		LifeSkillType = lifeSkillType;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public CharacterMissionItem()
	{
		TemplateId = 0;
		Name = null;
		IsHidden = false;
		Type = ECharacterMissionType.Sect;
		Group = ECharacterMissionGroup.Belonging;
		Duration = 4;
		KeepDuration = 2;
		BubbleContentInProgress = new string[5] { "{}", "{}", "{}", "{}", "{}" };
		BubbleContentSuccess = new string[5] { "{}", "{}", "{}", "{}", "{}" };
		BubbleContentFail = new string[5] { "{}", "{}", "{}", "{}", "{}" };
		Priority = 0;
		PersonalityTypes = new sbyte[5] { 0, 2, 1, 3, 4 };
		Goals = null;
		RequiredMapState = 0;
		RequiredOrganization = 0;
		RequiredGoodness = 0;
		RequiredGradeGroup = -1;
		RequiredOrgMember = 0;
		RequiredBehaviorType = 0;
		LifeSkillType = 0;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public CharacterMissionItem(int templateId, CharacterMissionItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		IsHidden = other.IsHidden;
		Type = other.Type;
		Group = other.Group;
		Duration = other.Duration;
		KeepDuration = other.KeepDuration;
		BubbleContentInProgress = other.BubbleContentInProgress;
		BubbleContentSuccess = other.BubbleContentSuccess;
		BubbleContentFail = other.BubbleContentFail;
		Priority = other.Priority;
		PersonalityTypes = other.PersonalityTypes;
		Goals = other.Goals;
		RequiredMapState = other.RequiredMapState;
		RequiredOrganization = other.RequiredOrganization;
		RequiredGoodness = other.RequiredGoodness;
		RequiredGradeGroup = other.RequiredGradeGroup;
		RequiredOrgMember = other.RequiredOrgMember;
		RequiredBehaviorType = other.RequiredBehaviorType;
		LifeSkillType = other.LifeSkillType;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override CharacterMissionItem Duplicate(int templateId)
	{
		return new CharacterMissionItem(templateId, this);
	}
}

using System;
using Config.Common;

namespace Config;

[Serializable]
public class PrioritizedActionsItem : ConfigItem<PrioritizedActionsItem, short>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 行动类别
	/// - AI行为类别的区分，引发AI行为的原因为区分要素，目前为：
	/// - 常规行动：人物日常过月时会产生的行为
	/// - 地区主线：开启地区主线时，会产生的行为
	/// - 梦回剧情：梦回后，会产生的行为
	/// </summary>
	public readonly EPrioritizedActionsActType ActType;

	/// <summary>
	/// 创建失败冷却时间
	/// - 创建失败，添加的冷却
	/// </summary>
	public readonly short FailToCreateActionCoolDown;

	/// <summary>
	/// 行动冷却时间
	/// - 优先行动中断或者执行后添加的冷却
	/// </summary>
	public readonly short ActionCoolDown;

	/// <summary>
	/// 持续时间
	/// - 此行为可持续的最大时间
	/// - 默认-1代表无限持续时间
	/// </summary>
	public readonly int Duration;

	/// <summary>
	/// 基础优先度
	/// - 人物将会依照行为优先度依次进行判定
	/// - 行为优先度=基础优先度+立场额外优先度
	/// </summary>
	public readonly short BasePriority;

	/// <summary>
	/// 立场额外优先度
	/// - 该列由公式生成，禁止手动填写
	/// </summary>
	public readonly short[] MoralityPriority;

	/// <summary>
	/// 是否打断行动
	/// - 若值为true且正在执行的行为优先度低于此行动，则会直接被打断
	/// </summary>
	public readonly bool IsPrevActionInterrupted;

	/// <summary>
	/// 是否需要成年
	/// - 执行此行为是否需要人物成年
	/// - 即使值为false仍会排除婴儿
	/// </summary>
	public readonly bool IsAdultOnly;

	/// <summary>
	/// 是否排除非队长的角色
	/// - 自身为队长或不在队伍中
	/// </summary>
	public readonly bool IsNonLeader;

	/// <summary>
	/// 是否排除太吾的同道
	/// - 值为true时，太吾同道将不会执行此行为
	/// </summary>
	public readonly bool IsNonTaiwuTeammate;

	/// <summary>
	/// 是否排除出家或不许婚配的角色
	/// </summary>
	public readonly bool IsNonMonk;

	/// <summary>
	/// 不能闲逛的角色仍然执行行动的几率
	/// - 默认为-1，即无需闲逛判定
	/// </summary>
	public readonly int LoafChance;

	/// <summary>
	/// 特定身份
	/// - 执行此行为的人物需要满足对应身份
	/// </summary>
	public readonly sbyte[] OrgTemplateId;

	/// <summary>
	/// 可用级别
	/// - 执行此行为的人物允许的身份级别
	/// </summary>
	public readonly sbyte[] OrgGrade;

	/// <summary>
	/// 同行为组队概率
	/// - 人物正在执行优先行动时，发起或者接受邀约的概率
	/// </summary>
	public readonly sbyte[] ActionJointChance;

	/// <summary>
	/// 拒绝邀约
	/// - 当太吾和人物进行邀约聚会的交互时，若人物正在进行此项配置文本不为空的优先行为，将会拒绝太吾邀约,并应用文本于事件中
	/// </summary>
	public readonly string RefuseAppointment;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="actType">行动类别 - AI行为类别的区分，引发AI行为的原因为区分要素，目前为： 常规行动：人物日常过月时会产生的行为 地区主线：开启地区主线时，会产生的行为 梦回剧情：梦回后，会产生的行为</param>
	/// <param name="failToCreateActionCoolDown">创建失败冷却时间 - 创建失败，添加的冷却</param>
	/// <param name="actionCoolDown">行动冷却时间 - 优先行动中断或者执行后添加的冷却</param>
	/// <param name="duration">持续时间 - 此行为可持续的最大时间 默认-1代表无限持续时间</param>
	/// <param name="basePriority">基础优先度 - 人物将会依照行为优先度依次进行判定 行为优先度=基础优先度+立场额外优先度</param>
	/// <param name="moralityPriority">立场额外优先度 - 该列由公式生成，禁止手动填写</param>
	/// <param name="isPrevActionInterrupted">是否打断行动 - 若值为true且正在执行的行为优先度低于此行动，则会直接被打断</param>
	/// <param name="isAdultOnly">是否需要成年 - 执行此行为是否需要人物成年 即使值为false仍会排除婴儿</param>
	/// <param name="isNonLeader">是否排除非队长的角色 - 自身为队长或不在队伍中</param>
	/// <param name="isNonTaiwuTeammate">是否排除太吾的同道 - 值为true时，太吾同道将不会执行此行为</param>
	/// <param name="isNonMonk">是否排除出家或不许婚配的角色</param>
	/// <param name="loafChance">不能闲逛的角色仍然执行行动的几率 - 默认为-1，即无需闲逛判定</param>
	/// <param name="orgTemplateId">特定身份 - 执行此行为的人物需要满足对应身份</param>
	/// <param name="orgGrade">可用级别 - 执行此行为的人物允许的身份级别</param>
	/// <param name="actionJointChance">同行为组队概率 - 人物正在执行优先行动时，发起或者接受邀约的概率</param>
	/// <param name="refuseAppointment">拒绝邀约 - 当太吾和人物进行邀约聚会的交互时，若人物正在进行此项配置文本不为空的优先行为，将会拒绝太吾邀约,并应用文本于事件中</param>
	public PrioritizedActionsItem(short templateId, EPrioritizedActionsActType actType, short failToCreateActionCoolDown, short actionCoolDown, int duration, short basePriority, short[] moralityPriority, bool isPrevActionInterrupted, bool isAdultOnly, bool isNonLeader, bool isNonTaiwuTeammate, bool isNonMonk, int loafChance, sbyte[] orgTemplateId, sbyte[] orgGrade, sbyte[] actionJointChance, string refuseAppointment)
	{
		TemplateId = templateId;
		ActType = actType;
		FailToCreateActionCoolDown = failToCreateActionCoolDown;
		ActionCoolDown = actionCoolDown;
		Duration = duration;
		BasePriority = basePriority;
		MoralityPriority = moralityPriority;
		IsPrevActionInterrupted = isPrevActionInterrupted;
		IsAdultOnly = isAdultOnly;
		IsNonLeader = isNonLeader;
		IsNonTaiwuTeammate = isNonTaiwuTeammate;
		IsNonMonk = isNonMonk;
		LoafChance = loafChance;
		OrgTemplateId = orgTemplateId;
		OrgGrade = orgGrade;
		ActionJointChance = actionJointChance;
		RefuseAppointment = refuseAppointment;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public PrioritizedActionsItem()
	{
		TemplateId = 0;
		ActType = EPrioritizedActionsActType.Normal;
		FailToCreateActionCoolDown = 0;
		ActionCoolDown = 0;
		Duration = -1;
		BasePriority = 0;
		MoralityPriority = new short[0];
		IsPrevActionInterrupted = false;
		IsAdultOnly = false;
		IsNonLeader = false;
		IsNonTaiwuTeammate = false;
		IsNonMonk = false;
		LoafChance = -1;
		OrgTemplateId = new sbyte[0];
		OrgGrade = new sbyte[9] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
		ActionJointChance = new sbyte[5];
		RefuseAppointment = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public PrioritizedActionsItem(short templateId, PrioritizedActionsItem other)
	{
		TemplateId = templateId;
		ActType = other.ActType;
		FailToCreateActionCoolDown = other.FailToCreateActionCoolDown;
		ActionCoolDown = other.ActionCoolDown;
		Duration = other.Duration;
		BasePriority = other.BasePriority;
		MoralityPriority = other.MoralityPriority;
		IsPrevActionInterrupted = other.IsPrevActionInterrupted;
		IsAdultOnly = other.IsAdultOnly;
		IsNonLeader = other.IsNonLeader;
		IsNonTaiwuTeammate = other.IsNonTaiwuTeammate;
		IsNonMonk = other.IsNonMonk;
		LoafChance = other.LoafChance;
		OrgTemplateId = other.OrgTemplateId;
		OrgGrade = other.OrgGrade;
		ActionJointChance = other.ActionJointChance;
		RefuseAppointment = other.RefuseAppointment;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override PrioritizedActionsItem Duplicate(int templateId)
	{
		return new PrioritizedActionsItem((short)templateId, this);
	}
}

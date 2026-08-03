using System;
using System.Collections.Generic;
using Config.Common;
using Config.ConfigCells;

namespace Config;

[Serializable]
public class TaskInfoItem : ConfigItem<TaskInfoItem, int>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly int TemplateId;

	/// <summary>
	/// 任务标题
	/// </summary>
	public readonly string TaskTitle;

	/// <summary>
	/// 任务概述
	/// - 游戏界面中右上角手记界面显示的内容，作为此任务的概述引导，其字数不可多于15，不然会超框导致无法显示；引导玩家行动的重点词句可以通过标记橙色的方式高亮提示。注意：没有任务概述，仅有任务说明的任务为子任务，在任务链表中需填在主任务的后面。
	/// </summary>
	public readonly string TaskOverview;

	/// <summary>
	/// 任务说明
	/// - 界面中下拉后显示的具体的手记任务，文义通顺的情况下无需说明前情提要，更不可剧透，只说明玩家触发下一步剧情需进行的操作，例如互动、前往地格、静待（即过月）即可；高亮并占位符同前任务概述。
	/// </summary>
	public readonly string TaskDescription;

	/// <summary>
	/// 任务气泡框显示内容
	/// - 左下角的太吾弹窗中显示的内容，以第一人称口吻进行描述，提示玩家“太吾视角下，下一步的行为或当前需要注意的事情”，此处字数不宜过多，不可添加占位符，无需添加高亮。
	/// </summary>
	public readonly string TaskBubblesContent;

	/// <summary>
	/// 任务说明（任务满足一定需求时使用此任务说明替换前任务说明）
	/// - 此任务满足特定条件时将显示除当前文本之外的另一个文本，例如剧情中满足了条件，任务仍然维持当前任务不刷新，文案出现满足条件后的下一步提示。
	/// </summary>
	public readonly string TaskDescriptionMeet;

	/// <summary>
	/// 显示时间
	/// - 气泡框在主界面上停顿的帧数/时长，默认120帧 = 2s，可以60为倍数进行类推
	/// </summary>
	public readonly int ShowTime;

	/// <summary>
	/// 进行条件
	/// - 该任务处于进行中，需要满足该条件才可以触发完成，否则显示任务受阻
	/// </summary>
	public readonly List<int> RunCondition;

	/// <summary>
	/// 完成条件
	/// </summary>
	public readonly List<int> FinishCondition;

	/// <summary>
	/// 受阻条件
	/// </summary>
	public readonly List<int> BlockCondition;

	/// <summary>
	/// 是否为触发式任务
	/// - 触发式任务无需填写进行、完成、受阻条件，同一个任务链中所有的任务必须同为触发或同为非触发。
	/// </summary>
	public readonly bool IsTriggeredTask;

	/// <summary>
	/// 不可重复完成
	/// - 为false时，触发任务时如果任务列表存在已完成数据，先移除已完成数据再添加未完成数据
	/// </summary>
	public readonly bool UnableRepeat;

	/// <summary>
	/// 完成后开启的任务链
	/// - 任务完成后开启的任务链
	/// </summary>
	public readonly List<int> StartTaskChainsWhenFinish;

	/// <summary>
	/// 要求已完成任务
	/// - 需要已完成该前置触发式任务. 主要用于状态式任务限定范围。
	/// </summary>
	public readonly int RequireFinishedTask;

	/// <summary>
	/// 要求未完成任务
	/// - 需要尚未触发该触发式任务. 主要用于状态式任务限定范围。
	/// </summary>
	public readonly int RequireUntriggeredTask;

	/// <summary>
	/// 任务顺序
	/// - 任务在弹窗面板显示的顺序：0主线，1地区主线，2支线
	/// </summary>
	public readonly short TaskOrder;

	/// <summary>
	/// NPC模板ID
	/// - 此列NPC模板ID可获取此NPC所在位置，填写文本占位符时使用
	/// </summary>
	public readonly List<short> CharacterTemplateId;

	/// <summary>
	/// 事件参数盒子键值
	/// - 此列固定获取事件参数盒子中的Location以填写任务文本占位符
	/// </summary>
	public readonly string EventArgBoxKey;

	/// <summary>
	/// 功法ID事件参数盒子键值
	/// - 此列固定获取事件参数盒子中的short以填写任务文本占位符
	/// </summary>
	public readonly string[] CombatSkillIdsEventArgBoxKey;

	/// <summary>
	/// 技艺ID事件参数盒子键值
	/// - 此列固定获取事件参数盒子中的short以填写任务文本占位符
	/// </summary>
	public readonly string[] SkillIdsEventArgBoxKey;

	/// <summary>
	/// 前端key
	/// - 此列固定获取前端的key以填写任务文本占位符
	/// </summary>
	public readonly string FrontEndKey;

	/// <summary>
	/// 参数盒子中的string类型值对应的Key
	/// - 此列固定获取事件参数盒子中的string以填写任务文本占位符
	/// </summary>
	public readonly string[] StringArrayEventArgBoxKey;

	/// <summary>
	/// 自动触发过月通知
	/// </summary>
	public readonly short[] MonthlyNotifications;

	/// <summary>
	/// 可能触发的过月事件
	/// - 在进行对应的任务中时，每次过月都会试图触发配置的过月事件. 实际是否触发成功由头部事件的条件决定. 每个元素的第一个参数为过月事件的引用, 其它元素为过月事件的参数在参数盒子中对应的key.
	/// </summary>
	public readonly AutoTriggerMonthlyEvent[] MonthlyEvents;

	/// <summary>
	/// 任务链内排序
	/// - 相同任务链优先按此顺序排序
	/// </summary>
	public readonly sbyte IndexInChain;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="taskTitle">任务标题</param>
	/// <param name="taskOverview">任务概述 - 游戏界面中右上角手记界面显示的内容，作为此任务的概述引导，其字数不可多于15，不然会超框导致无法显示；引导玩家行动的重点词句可以通过标记橙色的方式高亮提示。注意：没有任务概述，仅有任务说明的任务为子任务，在任务链表中需填在主任务的后面。</param>
	/// <param name="taskDescription">任务说明 - 界面中下拉后显示的具体的手记任务，文义通顺的情况下无需说明前情提要，更不可剧透，只说明玩家触发下一步剧情需进行的操作，例如互动、前往地格、静待（即过月）即可；高亮并占位符同前任务概述。</param>
	/// <param name="taskBubblesContent">任务气泡框显示内容 - 左下角的太吾弹窗中显示的内容，以第一人称口吻进行描述，提示玩家“太吾视角下，下一步的行为或当前需要注意的事情”，此处字数不宜过多，不可添加占位符，无需添加高亮。</param>
	/// <param name="taskDescriptionMeet">任务说明（任务满足一定需求时使用此任务说明替换前任务说明） - 此任务满足特定条件时将显示除当前文本之外的另一个文本，例如剧情中满足了条件，任务仍然维持当前任务不刷新，文案出现满足条件后的下一步提示。</param>
	/// <param name="showTime">显示时间 - 气泡框在主界面上停顿的帧数/时长，默认120帧 = 2s，可以60为倍数进行类推</param>
	/// <param name="runCondition">进行条件 - 该任务处于进行中，需要满足该条件才可以触发完成，否则显示任务受阻</param>
	/// <param name="finishCondition">完成条件</param>
	/// <param name="blockCondition">受阻条件</param>
	/// <param name="isTriggeredTask">是否为触发式任务 - 触发式任务无需填写进行、完成、受阻条件，同一个任务链中所有的任务必须同为触发或同为非触发。</param>
	/// <param name="unableRepeat">不可重复完成 - 为false时，触发任务时如果任务列表存在已完成数据，先移除已完成数据再添加未完成数据</param>
	/// <param name="startTaskChainsWhenFinish">完成后开启的任务链 - 任务完成后开启的任务链</param>
	/// <param name="requireFinishedTask">要求已完成任务 - 需要已完成该前置触发式任务. 主要用于状态式任务限定范围。</param>
	/// <param name="requireUntriggeredTask">要求未完成任务 - 需要尚未触发该触发式任务. 主要用于状态式任务限定范围。</param>
	/// <param name="taskOrder">任务顺序 - 任务在弹窗面板显示的顺序：0主线，1地区主线，2支线</param>
	/// <param name="characterTemplateId">NPC模板ID - 此列NPC模板ID可获取此NPC所在位置，填写文本占位符时使用</param>
	/// <param name="eventArgBoxKey">事件参数盒子键值 - 此列固定获取事件参数盒子中的Location以填写任务文本占位符</param>
	/// <param name="combatSkillIdsEventArgBoxKey">功法ID事件参数盒子键值 - 此列固定获取事件参数盒子中的short以填写任务文本占位符</param>
	/// <param name="skillIdsEventArgBoxKey">技艺ID事件参数盒子键值 - 此列固定获取事件参数盒子中的short以填写任务文本占位符</param>
	/// <param name="frontEndKey">前端key - 此列固定获取前端的key以填写任务文本占位符</param>
	/// <param name="stringArrayEventArgBoxKey">参数盒子中的string类型值对应的Key - 此列固定获取事件参数盒子中的string以填写任务文本占位符</param>
	/// <param name="monthlyNotifications">自动触发过月通知</param>
	/// <param name="monthlyEvents">可能触发的过月事件 - 在进行对应的任务中时，每次过月都会试图触发配置的过月事件. 实际是否触发成功由头部事件的条件决定. 每个元素的第一个参数为过月事件的引用, 其它元素为过月事件的参数在参数盒子中对应的key.</param>
	/// <param name="indexInChain">任务链内排序 - 相同任务链优先按此顺序排序</param>
	public TaskInfoItem(int templateId, string taskTitle, string taskOverview, string taskDescription, string taskBubblesContent, string taskDescriptionMeet, int showTime, List<int> runCondition, List<int> finishCondition, List<int> blockCondition, bool isTriggeredTask, bool unableRepeat, List<int> startTaskChainsWhenFinish, int requireFinishedTask, int requireUntriggeredTask, short taskOrder, List<short> characterTemplateId, string eventArgBoxKey, string[] combatSkillIdsEventArgBoxKey, string[] skillIdsEventArgBoxKey, string frontEndKey, string[] stringArrayEventArgBoxKey, short[] monthlyNotifications, AutoTriggerMonthlyEvent[] monthlyEvents, sbyte indexInChain)
	{
		TemplateId = templateId;
		TaskTitle = taskTitle;
		TaskOverview = taskOverview;
		TaskDescription = taskDescription;
		TaskBubblesContent = taskBubblesContent;
		TaskDescriptionMeet = taskDescriptionMeet;
		ShowTime = showTime;
		RunCondition = runCondition;
		FinishCondition = finishCondition;
		BlockCondition = blockCondition;
		IsTriggeredTask = isTriggeredTask;
		UnableRepeat = unableRepeat;
		StartTaskChainsWhenFinish = startTaskChainsWhenFinish;
		RequireFinishedTask = requireFinishedTask;
		RequireUntriggeredTask = requireUntriggeredTask;
		TaskOrder = taskOrder;
		CharacterTemplateId = characterTemplateId;
		EventArgBoxKey = eventArgBoxKey;
		CombatSkillIdsEventArgBoxKey = combatSkillIdsEventArgBoxKey;
		SkillIdsEventArgBoxKey = skillIdsEventArgBoxKey;
		FrontEndKey = frontEndKey;
		StringArrayEventArgBoxKey = stringArrayEventArgBoxKey;
		MonthlyNotifications = monthlyNotifications;
		MonthlyEvents = monthlyEvents;
		IndexInChain = indexInChain;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public TaskInfoItem()
	{
		TemplateId = 0;
		TaskTitle = null;
		TaskOverview = null;
		TaskDescription = null;
		TaskBubblesContent = null;
		TaskDescriptionMeet = null;
		ShowTime = 120;
		RunCondition = new List<int>();
		FinishCondition = new List<int>();
		BlockCondition = new List<int>();
		IsTriggeredTask = false;
		UnableRepeat = true;
		StartTaskChainsWhenFinish = new List<int>();
		RequireFinishedTask = 0;
		RequireUntriggeredTask = 0;
		TaskOrder = 0;
		CharacterTemplateId = new List<short>();
		EventArgBoxKey = null;
		CombatSkillIdsEventArgBoxKey = null;
		SkillIdsEventArgBoxKey = null;
		FrontEndKey = null;
		StringArrayEventArgBoxKey = null;
		MonthlyNotifications = null;
		MonthlyEvents = null;
		IndexInChain = 1;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public TaskInfoItem(int templateId, TaskInfoItem other)
	{
		TemplateId = templateId;
		TaskTitle = other.TaskTitle;
		TaskOverview = other.TaskOverview;
		TaskDescription = other.TaskDescription;
		TaskBubblesContent = other.TaskBubblesContent;
		TaskDescriptionMeet = other.TaskDescriptionMeet;
		ShowTime = other.ShowTime;
		RunCondition = other.RunCondition;
		FinishCondition = other.FinishCondition;
		BlockCondition = other.BlockCondition;
		IsTriggeredTask = other.IsTriggeredTask;
		UnableRepeat = other.UnableRepeat;
		StartTaskChainsWhenFinish = other.StartTaskChainsWhenFinish;
		RequireFinishedTask = other.RequireFinishedTask;
		RequireUntriggeredTask = other.RequireUntriggeredTask;
		TaskOrder = other.TaskOrder;
		CharacterTemplateId = other.CharacterTemplateId;
		EventArgBoxKey = other.EventArgBoxKey;
		CombatSkillIdsEventArgBoxKey = other.CombatSkillIdsEventArgBoxKey;
		SkillIdsEventArgBoxKey = other.SkillIdsEventArgBoxKey;
		FrontEndKey = other.FrontEndKey;
		StringArrayEventArgBoxKey = other.StringArrayEventArgBoxKey;
		MonthlyNotifications = other.MonthlyNotifications;
		MonthlyEvents = other.MonthlyEvents;
		IndexInChain = other.IndexInChain;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override TaskInfoItem Duplicate(int templateId)
	{
		return new TaskInfoItem(templateId, this);
	}
}

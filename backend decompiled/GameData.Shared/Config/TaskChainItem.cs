using System;
using System.Collections.Generic;
using Config.Common;
using Config.ConfigCells;

namespace Config;

[Serializable]
public class TaskChainItem : ConfigItem<TaskChainItem, int>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly int TemplateId;

	/// <summary>
	/// 所属任务组
	/// - 相同任务组的任务链会显示在一个任务组下
	/// </summary>
	public readonly ETaskChainGroup Group;

	/// <summary>
	/// 任务链类型
	/// </summary>
	public readonly ETaskChainType Type;

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
	/// 下级任务链
	/// - 完成该任务链以后自动开启的下级任务链
	/// </summary>
	public readonly int NextTaskChain;

	/// <summary>
	/// 包含的任务列表
	/// </summary>
	public readonly List<int> TaskList;

	/// <summary>
	/// 开启条件
	/// </summary>
	public readonly List<int> StartConditions;

	/// <summary>
	/// 消除条件
	/// </summary>
	public readonly List<int> RemoveCondtions;

	/// <summary>
	/// 名称
	/// - 任务组名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 门派
	/// - 用于判定是哪个门派的任务
	/// </summary>
	public readonly sbyte Sect;

	/// <summary>
	/// 可能触发的过月事件
	/// - 在进行对应的任务中时，每次过月都会试图触发配置的过月事件. 实际是否触发成功由头部事件的条件决定. 每个元素的第一个参数为过月事件的引用, 其它元素为过月事件的参数在参数盒子中对应的key.
	/// </summary>
	public readonly AutoTriggerMonthlyEvent[] MonthlyEvents;

	/// <summary>
	/// 与奇遇关联
	/// </summary>
	public readonly bool RelateAdventure;

	/// <summary>
	/// 图标
	/// </summary>
	public readonly string TaskChainIcon;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="group">所属任务组 - 相同任务组的任务链会显示在一个任务组下</param>
	/// <param name="type">任务链类型</param>
	/// <param name="requireFinishedTask">要求已完成任务 - 需要已完成该前置触发式任务. 主要用于状态式任务限定范围。</param>
	/// <param name="requireUntriggeredTask">要求未完成任务 - 需要尚未触发该触发式任务. 主要用于状态式任务限定范围。</param>
	/// <param name="nextTaskChain">下级任务链 - 完成该任务链以后自动开启的下级任务链</param>
	/// <param name="taskList">包含的任务列表</param>
	/// <param name="startConditions">开启条件</param>
	/// <param name="removeCondtions">消除条件</param>
	/// <param name="name">名称 - 任务组名称</param>
	/// <param name="sect">门派 - 用于判定是哪个门派的任务</param>
	/// <param name="monthlyEvents">可能触发的过月事件 - 在进行对应的任务中时，每次过月都会试图触发配置的过月事件. 实际是否触发成功由头部事件的条件决定. 每个元素的第一个参数为过月事件的引用, 其它元素为过月事件的参数在参数盒子中对应的key.</param>
	/// <param name="relateAdventure">与奇遇关联</param>
	/// <param name="taskChainIcon">图标</param>
	public TaskChainItem(int templateId, ETaskChainGroup group, ETaskChainType type, int requireFinishedTask, int requireUntriggeredTask, int nextTaskChain, List<int> taskList, List<int> startConditions, List<int> removeCondtions, string name, sbyte sect, AutoTriggerMonthlyEvent[] monthlyEvents, bool relateAdventure, string taskChainIcon)
	{
		TemplateId = templateId;
		Group = group;
		Type = type;
		RequireFinishedTask = requireFinishedTask;
		RequireUntriggeredTask = requireUntriggeredTask;
		NextTaskChain = nextTaskChain;
		TaskList = taskList;
		StartConditions = startConditions;
		RemoveCondtions = removeCondtions;
		Name = name;
		Sect = sect;
		MonthlyEvents = monthlyEvents;
		RelateAdventure = relateAdventure;
		TaskChainIcon = taskChainIcon;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public TaskChainItem()
	{
		TemplateId = 0;
		Group = ETaskChainGroup.MainStory;
		Type = ETaskChainType.Line;
		RequireFinishedTask = 0;
		RequireUntriggeredTask = 0;
		NextTaskChain = 0;
		TaskList = new List<int>();
		StartConditions = new List<int>();
		RemoveCondtions = new List<int>();
		Name = null;
		Sect = 0;
		MonthlyEvents = null;
		RelateAdventure = false;
		TaskChainIcon = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public TaskChainItem(int templateId, TaskChainItem other)
	{
		TemplateId = templateId;
		Group = other.Group;
		Type = other.Type;
		RequireFinishedTask = other.RequireFinishedTask;
		RequireUntriggeredTask = other.RequireUntriggeredTask;
		NextTaskChain = other.NextTaskChain;
		TaskList = other.TaskList;
		StartConditions = other.StartConditions;
		RemoveCondtions = other.RemoveCondtions;
		Name = other.Name;
		Sect = other.Sect;
		MonthlyEvents = other.MonthlyEvents;
		RelateAdventure = other.RelateAdventure;
		TaskChainIcon = other.TaskChainIcon;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override TaskChainItem Duplicate(int templateId)
	{
		return new TaskChainItem(templateId, this);
	}
}

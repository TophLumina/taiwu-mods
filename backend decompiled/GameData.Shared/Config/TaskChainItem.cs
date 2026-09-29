using System;
using System.Collections.Generic;
using Config.Common;
using Config.ConfigCells;

namespace Config;

[Serializable]
public class TaskChainItem : ConfigItem<TaskChainItem, int>
{
	public readonly int TemplateId;

	public readonly ETaskChainGroup Group;

	public readonly ETaskChainType Type;

	public readonly int RequireFinishedTask;

	public readonly int RequireUntriggeredTask;

	public readonly int NextTaskChain;

	public readonly List<int> TaskList;

	public readonly List<int> StartConditions;

	public readonly List<int> RemoveCondtions;

	public readonly string Name;

	public readonly sbyte Sect;

	public readonly AutoTriggerMonthlyEvent[] MonthlyEvents;

	public readonly bool RelateAdventure;

	public readonly string TaskChainIcon;

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

	public override TaskChainItem Duplicate(int templateId)
	{
		return new TaskChainItem(templateId, this);
	}
}

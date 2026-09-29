using System;
using System.Collections.Generic;
using Config.Common;
using Config.ConfigCells;

namespace Config;

[Serializable]
public class TaskInfoItem : ConfigItem<TaskInfoItem, int>
{
	public readonly int TemplateId;

	public readonly string TaskTitle;

	public readonly string TaskOverview;

	public readonly string TaskDescription;

	public readonly string TaskBubblesContent;

	public readonly string TaskDescriptionMeet;

	public readonly int ShowTime;

	public readonly List<int> RunCondition;

	public readonly List<int> FinishCondition;

	public readonly List<int> BlockCondition;

	public readonly bool IsTriggeredTask;

	public readonly bool UnableRepeat;

	public readonly List<int> StartTaskChainsWhenFinish;

	public readonly int RequireFinishedTask;

	public readonly int RequireUntriggeredTask;

	public readonly short TaskOrder;

	public readonly List<short> CharacterTemplateId;

	public readonly string EventArgBoxKey;

	public readonly string[] CombatSkillIdsEventArgBoxKey;

	public readonly string[] SkillIdsEventArgBoxKey;

	public readonly string FrontEndKey;

	public readonly string[] StringArrayEventArgBoxKey;

	public readonly short[] MonthlyNotifications;

	public readonly AutoTriggerMonthlyEvent[] MonthlyEvents;

	public readonly sbyte IndexInChain;

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

	public override TaskInfoItem Duplicate(int templateId)
	{
		return new TaskInfoItem(templateId, this);
	}
}

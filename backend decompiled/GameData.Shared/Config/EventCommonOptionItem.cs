using System;
using Config.Common;

namespace Config;

[Serializable]
public class EventCommonOptionItem : ConfigItem<EventCommonOptionItem, short>
{
	/// <summary>
	/// ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 对应事件的guid
	/// </summary>
	public readonly string EventGuid;

	/// <summary>
	/// 选项标题
	/// </summary>
	public readonly string OptionTitle;

	/// <summary>
	/// 选项记录
	/// </summary>
	public readonly string OptionRecordText;

	/// <summary>
	/// 任务完成需求
	/// </summary>
	public readonly int RequiredTask;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">ID</param>
	/// <param name="eventGuid">对应事件的guid</param>
	/// <param name="optionTitle">选项标题</param>
	/// <param name="optionRecordText">选项记录</param>
	/// <param name="requiredTask">任务完成需求</param>
	public EventCommonOptionItem(short templateId, string eventGuid, string optionTitle, string optionRecordText, int requiredTask)
	{
		TemplateId = templateId;
		EventGuid = eventGuid;
		OptionTitle = optionTitle;
		OptionRecordText = optionRecordText;
		RequiredTask = requiredTask;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public EventCommonOptionItem()
	{
		TemplateId = 0;
		EventGuid = null;
		OptionTitle = null;
		OptionRecordText = null;
		RequiredTask = 0;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public EventCommonOptionItem(short templateId, EventCommonOptionItem other)
	{
		TemplateId = templateId;
		EventGuid = other.EventGuid;
		OptionTitle = other.OptionTitle;
		OptionRecordText = other.OptionRecordText;
		RequiredTask = other.RequiredTask;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override EventCommonOptionItem Duplicate(int templateId)
	{
		return new EventCommonOptionItem((short)templateId, this);
	}
}

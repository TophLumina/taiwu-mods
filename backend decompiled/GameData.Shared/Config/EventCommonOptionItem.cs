using System;
using Config.Common;

namespace Config;

[Serializable]
public class EventCommonOptionItem : ConfigItem<EventCommonOptionItem, short>
{
	public readonly short TemplateId;

	public readonly string EventGuid;

	public readonly string OptionTitle;

	public readonly string OptionRecordText;

	public readonly int RequiredTask;

	public EventCommonOptionItem(short templateId, string eventGuid, string optionTitle, string optionRecordText, int requiredTask)
	{
		TemplateId = templateId;
		EventGuid = eventGuid;
		OptionTitle = optionTitle;
		OptionRecordText = optionRecordText;
		RequiredTask = requiredTask;
	}

	public EventCommonOptionItem()
	{
		TemplateId = 0;
		EventGuid = null;
		OptionTitle = null;
		OptionRecordText = null;
		RequiredTask = 0;
	}

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

	public override EventCommonOptionItem Duplicate(int templateId)
	{
		return new EventCommonOptionItem((short)templateId, this);
	}
}

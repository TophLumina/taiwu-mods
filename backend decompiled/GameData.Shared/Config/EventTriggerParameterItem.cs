using System;
using Config.Common;

namespace Config;

[Serializable]
public class EventTriggerParameterItem : ConfigItem<EventTriggerParameterItem, int>
{
	public readonly int TemplateId;

	public readonly string DataTypeName;

	public readonly string ArgBoxKey;

	public EventTriggerParameterItem(int templateId, string dataTypeName, string argBoxKey)
	{
		TemplateId = templateId;
		DataTypeName = dataTypeName;
		ArgBoxKey = argBoxKey;
	}

	public EventTriggerParameterItem()
	{
		TemplateId = 0;
		DataTypeName = null;
		ArgBoxKey = null;
	}

	public EventTriggerParameterItem(int templateId, EventTriggerParameterItem other)
	{
		TemplateId = templateId;
		DataTypeName = other.DataTypeName;
		ArgBoxKey = other.ArgBoxKey;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override EventTriggerParameterItem Duplicate(int templateId)
	{
		return new EventTriggerParameterItem(templateId, this);
	}
}

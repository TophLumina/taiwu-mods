using System;
using Config.Common;

namespace Config;

[Serializable]
public class EventConditionOperatorItem : ConfigItem<EventConditionOperatorItem, int>
{
	public readonly int TemplateId;

	public readonly string Name;

	public EventConditionOperatorItem(int templateId, string name)
	{
		TemplateId = templateId;
		Name = name;
	}

	public EventConditionOperatorItem()
	{
		TemplateId = 0;
		Name = null;
	}

	public EventConditionOperatorItem(int templateId, EventConditionOperatorItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override EventConditionOperatorItem Duplicate(int templateId)
	{
		return new EventConditionOperatorItem(templateId, this);
	}
}

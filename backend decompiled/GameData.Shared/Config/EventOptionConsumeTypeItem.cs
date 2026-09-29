using System;
using Config.Common;

namespace Config;

[Serializable]
public class EventOptionConsumeTypeItem : ConfigItem<EventOptionConsumeTypeItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly string Name;

	public readonly string Icon;

	public EventOptionConsumeTypeItem(sbyte templateId, string name, string icon)
	{
		TemplateId = templateId;
		Name = name;
		Icon = icon;
	}

	public EventOptionConsumeTypeItem()
	{
		TemplateId = 0;
		Name = null;
		Icon = null;
	}

	public EventOptionConsumeTypeItem(sbyte templateId, EventOptionConsumeTypeItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Icon = other.Icon;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override EventOptionConsumeTypeItem Duplicate(int templateId)
	{
		return new EventOptionConsumeTypeItem((sbyte)templateId, this);
	}
}

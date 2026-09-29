using System;
using Config.Common;

namespace Config;

[Serializable]
public class EventBoolStateItem : ConfigItem<EventBoolStateItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly bool RemoveBeforeNextEvent;

	public EventBoolStateItem(short templateId, string name, bool removeBeforeNextEvent)
	{
		TemplateId = templateId;
		Name = name;
		RemoveBeforeNextEvent = removeBeforeNextEvent;
	}

	public EventBoolStateItem()
	{
		TemplateId = 0;
		Name = null;
		RemoveBeforeNextEvent = false;
	}

	public EventBoolStateItem(short templateId, EventBoolStateItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		RemoveBeforeNextEvent = other.RemoveBeforeNextEvent;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override EventBoolStateItem Duplicate(int templateId)
	{
		return new EventBoolStateItem((short)templateId, this);
	}
}

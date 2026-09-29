using System;
using Config.Common;

namespace Config;

[Serializable]
public class EventActionKeyItem : ConfigItem<EventActionKeyItem, int>, IEventArgumentFormatter
{
	public readonly int TemplateId;

	public readonly string KeyCode;

	public readonly int[] Parameters;

	public readonly bool BlockTrigger;

	public readonly bool RegisterByEventFunction;

	public EventActionKeyItem(int templateId, string keyCode, int[] parameters, bool blockTrigger, bool registerByEventFunction)
	{
		TemplateId = templateId;
		KeyCode = keyCode;
		Parameters = parameters;
		BlockTrigger = blockTrigger;
		RegisterByEventFunction = registerByEventFunction;
	}

	public EventActionKeyItem()
	{
		TemplateId = 0;
		KeyCode = null;
		Parameters = null;
		BlockTrigger = false;
		RegisterByEventFunction = true;
	}

	public EventActionKeyItem(int templateId, EventActionKeyItem other)
	{
		TemplateId = templateId;
		KeyCode = other.KeyCode;
		Parameters = other.Parameters;
		BlockTrigger = other.BlockTrigger;
		RegisterByEventFunction = other.RegisterByEventFunction;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override EventActionKeyItem Duplicate(int templateId)
	{
		return new EventActionKeyItem(templateId, this);
	}

	public static implicit operator string(EventActionKeyItem item)
	{
		return item.KeyCode;
	}

	string IEventArgumentFormatter.ToArgString()
	{
		return KeyCode;
	}
}

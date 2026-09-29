using System;
using Config.Common;

namespace Config;

[Serializable]
public class EventCutsceneItem : ConfigItem<EventCutsceneItem, short>
{
	public readonly short TemplateId;

	public readonly string ResourceFormat;

	public readonly bool CanSkip;

	public readonly int[] CommandPanelOffset;

	public EventCutsceneItem(short templateId, string resourceFormat, bool canSkip, int[] commandPanelOffset)
	{
		TemplateId = templateId;
		ResourceFormat = resourceFormat;
		CanSkip = canSkip;
		CommandPanelOffset = commandPanelOffset;
	}

	public EventCutsceneItem()
	{
		TemplateId = 0;
		ResourceFormat = null;
		CanSkip = true;
		CommandPanelOffset = null;
	}

	public EventCutsceneItem(short templateId, EventCutsceneItem other)
	{
		TemplateId = templateId;
		ResourceFormat = other.ResourceFormat;
		CanSkip = other.CanSkip;
		CommandPanelOffset = other.CommandPanelOffset;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override EventCutsceneItem Duplicate(int templateId)
	{
		return new EventCutsceneItem((short)templateId, this);
	}
}

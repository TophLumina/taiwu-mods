using System;
using Config.Common;

namespace Config;

[Serializable]
public class EventCgTextureItem : ConfigItem<EventCgTextureItem, short>
{
	public readonly short TemplateId;

	public readonly string ResourceFormat;

	public readonly float AnimDuration;

	public EventCgTextureItem(short templateId, string resourceFormat, float animDuration)
	{
		TemplateId = templateId;
		ResourceFormat = resourceFormat;
		AnimDuration = animDuration;
	}

	public EventCgTextureItem()
	{
		TemplateId = 0;
		ResourceFormat = null;
		AnimDuration = 1f;
	}

	public EventCgTextureItem(short templateId, EventCgTextureItem other)
	{
		TemplateId = templateId;
		ResourceFormat = other.ResourceFormat;
		AnimDuration = other.AnimDuration;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override EventCgTextureItem Duplicate(int templateId)
	{
		return new EventCgTextureItem((short)templateId, this);
	}
}

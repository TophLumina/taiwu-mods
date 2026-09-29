using System;
using Config.Common;

namespace Config;

[Serializable]
public class SectMainStoryEventArgKeyItem : ConfigItem<SectMainStoryEventArgKeyItem, int>, IEventArgumentFormatter
{
	public readonly int TemplateId;

	public readonly sbyte Sect;

	public readonly string ArgBoxKey;

	public SectMainStoryEventArgKeyItem(int templateId, sbyte sect, string argBoxKey)
	{
		TemplateId = templateId;
		Sect = sect;
		ArgBoxKey = argBoxKey;
	}

	public SectMainStoryEventArgKeyItem()
	{
		TemplateId = 0;
		Sect = 0;
		ArgBoxKey = null;
	}

	public SectMainStoryEventArgKeyItem(int templateId, SectMainStoryEventArgKeyItem other)
	{
		TemplateId = templateId;
		Sect = other.Sect;
		ArgBoxKey = other.ArgBoxKey;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override SectMainStoryEventArgKeyItem Duplicate(int templateId)
	{
		return new SectMainStoryEventArgKeyItem(templateId, this);
	}

	public static implicit operator string(SectMainStoryEventArgKeyItem item)
	{
		return item.ArgBoxKey;
	}

	string IEventArgumentFormatter.ToArgString()
	{
		return ArgBoxKey;
	}
}

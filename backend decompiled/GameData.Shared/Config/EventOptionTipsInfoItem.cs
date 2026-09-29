using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class EventOptionTipsInfoItem : ConfigItem<EventOptionTipsInfoItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly string Title;

	public readonly string Desc;

	public readonly List<string> Guid;

	public EventOptionTipsInfoItem(sbyte templateId, string title, string desc, List<string> guid)
	{
		TemplateId = templateId;
		Title = title;
		Desc = desc;
		Guid = guid;
	}

	public EventOptionTipsInfoItem()
	{
		TemplateId = 0;
		Title = null;
		Desc = null;
		Guid = null;
	}

	public EventOptionTipsInfoItem(sbyte templateId, EventOptionTipsInfoItem other)
	{
		TemplateId = templateId;
		Title = other.Title;
		Desc = other.Desc;
		Guid = other.Guid;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override EventOptionTipsInfoItem Duplicate(int templateId)
	{
		return new EventOptionTipsInfoItem((sbyte)templateId, this);
	}
}

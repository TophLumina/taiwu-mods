using System;
using Config.Common;

namespace Config;

[Serializable]
public class EventValueItem : ConfigItem<EventValueItem, int>
{
	public readonly int TemplateId;

	public readonly EEventValueType Type;

	public readonly string Name;

	public readonly string Desc;

	public readonly string ArgBoxKey;

	public readonly int EventArgument;

	public readonly string Alias;

	public readonly string ConstValue;

	public EventValueItem(int templateId, EEventValueType type, string name, string desc, string argBoxKey, int eventArgument, string alias, string constValue)
	{
		TemplateId = templateId;
		Type = type;
		Name = name;
		Desc = desc;
		ArgBoxKey = argBoxKey;
		EventArgument = eventArgument;
		Alias = alias;
		ConstValue = constValue;
	}

	public EventValueItem()
	{
		TemplateId = 0;
		Type = EEventValueType.Invalid;
		Name = null;
		Desc = null;
		ArgBoxKey = null;
		EventArgument = 0;
		Alias = null;
		ConstValue = null;
	}

	public EventValueItem(int templateId, EventValueItem other)
	{
		TemplateId = templateId;
		Type = other.Type;
		Name = other.Name;
		Desc = other.Desc;
		ArgBoxKey = other.ArgBoxKey;
		EventArgument = other.EventArgument;
		Alias = other.Alias;
		ConstValue = other.ConstValue;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override EventValueItem Duplicate(int templateId)
	{
		return new EventValueItem(templateId, this);
	}
}

using System;
using Config.Common;

namespace Config;

[Serializable]
public class LegendaryBookSlotItem : ConfigItem<LegendaryBookSlotItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly string Desc;

	public readonly string ClassName;

	public LegendaryBookSlotItem(short templateId, string name, string desc, string className)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		ClassName = className;
	}

	public LegendaryBookSlotItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		ClassName = null;
	}

	public LegendaryBookSlotItem(short templateId, LegendaryBookSlotItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		ClassName = other.ClassName;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override LegendaryBookSlotItem Duplicate(int templateId)
	{
		return new LegendaryBookSlotItem((short)templateId, this);
	}
}

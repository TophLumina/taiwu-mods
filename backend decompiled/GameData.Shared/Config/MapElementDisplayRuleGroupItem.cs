using System;
using Config.Common;

namespace Config;

[Serializable]
public class MapElementDisplayRuleGroupItem : ConfigItem<MapElementDisplayRuleGroupItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly string Desc;

	public readonly string Icon;

	public MapElementDisplayRuleGroupItem(short templateId, string name, string desc, string icon)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		Icon = icon;
	}

	public MapElementDisplayRuleGroupItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		Icon = null;
	}

	public MapElementDisplayRuleGroupItem(short templateId, MapElementDisplayRuleGroupItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		Icon = other.Icon;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override MapElementDisplayRuleGroupItem Duplicate(int templateId)
	{
		return new MapElementDisplayRuleGroupItem((short)templateId, this);
	}
}

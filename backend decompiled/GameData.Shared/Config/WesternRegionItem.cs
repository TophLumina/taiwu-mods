using System;
using Config.Common;

namespace Config;

[Serializable]
public class WesternRegionItem : ConfigItem<WesternRegionItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public WesternRegionItem(short templateId, string name)
	{
		TemplateId = templateId;
		Name = name;
	}

	public WesternRegionItem()
	{
		TemplateId = 0;
		Name = null;
	}

	public WesternRegionItem(short templateId, WesternRegionItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override WesternRegionItem Duplicate(int templateId)
	{
		return new WesternRegionItem((short)templateId, this);
	}
}

using System;
using Config.Common;

namespace Config;

[Serializable]
public class MapBlockCharCustomInfoItem : ConfigItem<MapBlockCharCustomInfoItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly EMapBlockCharCustomInfoDisplayType DisplayType;

	public readonly string TipContent;

	public MapBlockCharCustomInfoItem(short templateId, string name, EMapBlockCharCustomInfoDisplayType displayType, string tipContent)
	{
		TemplateId = templateId;
		Name = name;
		DisplayType = displayType;
		TipContent = tipContent;
	}

	public MapBlockCharCustomInfoItem()
	{
		TemplateId = 0;
		Name = null;
		DisplayType = EMapBlockCharCustomInfoDisplayType.Invalid;
		TipContent = null;
	}

	public MapBlockCharCustomInfoItem(short templateId, MapBlockCharCustomInfoItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		DisplayType = other.DisplayType;
		TipContent = other.TipContent;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override MapBlockCharCustomInfoItem Duplicate(int templateId)
	{
		return new MapBlockCharCustomInfoItem((short)templateId, this);
	}
}

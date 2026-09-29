using System;
using Config.Common;

namespace Config;

[Serializable]
public class MapLegendItem : ConfigItem<MapLegendItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly string Name;

	public readonly string Desc;

	public readonly string Sprite;

	public readonly bool ShowInAreaMap;

	public readonly EMapLegendTipType TipType;

	public MapLegendItem(sbyte templateId, string name, string desc, string sprite, bool showInAreaMap, EMapLegendTipType tipType)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		Sprite = sprite;
		ShowInAreaMap = showInAreaMap;
		TipType = tipType;
	}

	public MapLegendItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		Sprite = null;
		ShowInAreaMap = false;
		TipType = EMapLegendTipType.Text;
	}

	public MapLegendItem(sbyte templateId, MapLegendItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		Sprite = other.Sprite;
		ShowInAreaMap = other.ShowInAreaMap;
		TipType = other.TipType;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override MapLegendItem Duplicate(int templateId)
	{
		return new MapLegendItem((sbyte)templateId, this);
	}
}

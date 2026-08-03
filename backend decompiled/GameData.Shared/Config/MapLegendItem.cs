using System;
using Config.Common;

namespace Config;

[Serializable]
public class MapLegendItem : ConfigItem<MapLegendItem, sbyte>
{
	/// <summary>
	/// 模板id
	/// </summary>
	public readonly sbyte TemplateId;

	/// <summary>
	/// 图例名
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 图例含义
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 资源名
	/// </summary>
	public readonly string Sprite;

	/// <summary>
	/// 在世界地图中显示
	/// </summary>
	public readonly bool ShowInAreaMap;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板id</param>
	/// <param name="name">图例名</param>
	/// <param name="desc">图例含义</param>
	/// <param name="sprite">资源名</param>
	/// <param name="showInAreaMap">在世界地图中显示</param>
	public MapLegendItem(sbyte templateId, string name, string desc, string sprite, bool showInAreaMap)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		Sprite = sprite;
		ShowInAreaMap = showInAreaMap;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public MapLegendItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		Sprite = null;
		ShowInAreaMap = false;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public MapLegendItem(sbyte templateId, MapLegendItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		Sprite = other.Sprite;
		ShowInAreaMap = other.ShowInAreaMap;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override MapLegendItem Duplicate(int templateId)
	{
		return new MapLegendItem((sbyte)templateId, this);
	}
}

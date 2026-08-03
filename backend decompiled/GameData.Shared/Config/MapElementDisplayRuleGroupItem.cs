using System;
using Config.Common;

namespace Config;

[Serializable]
public class MapElementDisplayRuleGroupItem : ConfigItem<MapElementDisplayRuleGroupItem, short>
{
	/// <summary>
	/// 模板id
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 图标
	/// </summary>
	public readonly string Icon;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板id</param>
	/// <param name="name">名称</param>
	/// <param name="desc">名称</param>
	/// <param name="icon">图标</param>
	public MapElementDisplayRuleGroupItem(short templateId, string name, string desc, string icon)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		Icon = icon;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public MapElementDisplayRuleGroupItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		Icon = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
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

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override MapElementDisplayRuleGroupItem Duplicate(int templateId)
	{
		return new MapElementDisplayRuleGroupItem((short)templateId, this);
	}
}

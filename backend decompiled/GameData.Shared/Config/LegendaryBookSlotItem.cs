using System;
using Config.Common;

namespace Config;

[Serializable]
public class LegendaryBookSlotItem : ConfigItem<LegendaryBookSlotItem, short>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 说明
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 特效类名
	/// </summary>
	public readonly string ClassName;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">名称</param>
	/// <param name="desc">说明</param>
	/// <param name="className">特效类名</param>
	public LegendaryBookSlotItem(short templateId, string name, string desc, string className)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		ClassName = className;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public LegendaryBookSlotItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		ClassName = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
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

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override LegendaryBookSlotItem Duplicate(int templateId)
	{
		return new LegendaryBookSlotItem((short)templateId, this);
	}
}

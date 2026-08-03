using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class TaiwuLifeSummaryGroupItem : ConfigItem<TaiwuLifeSummaryGroupItem, sbyte>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly sbyte TemplateId;

	/// <summary>
	/// 名称
	/// - 无实际作用，仅作为备注名称分类
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 分类
	/// - 显示在各个页签下的数据
	/// </summary>
	public readonly sbyte Type;

	/// <summary>
	/// 大小
	/// - 在数据界面中背景图的大小，小：1x1，中：2x1，大：2x2
	/// </summary>
	public readonly ETaiwuLifeSummaryGroupSize Size;

	/// <summary>
	/// 子项
	/// - 将会显示在同一张背景图中的数据，此处数据按配置顺序从左到右，从上到下的顺序排列
	/// </summary>
	public readonly List<int> Items;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">名称 - 无实际作用，仅作为备注名称分类</param>
	/// <param name="type">分类 - 显示在各个页签下的数据</param>
	/// <param name="size">大小 - 在数据界面中背景图的大小，小：1x1，中：2x1，大：2x2</param>
	/// <param name="items">子项 - 将会显示在同一张背景图中的数据，此处数据按配置顺序从左到右，从上到下的顺序排列</param>
	public TaiwuLifeSummaryGroupItem(sbyte templateId, string name, sbyte type, ETaiwuLifeSummaryGroupSize size, List<int> items)
	{
		TemplateId = templateId;
		Name = name;
		Type = type;
		Size = size;
		Items = items;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public TaiwuLifeSummaryGroupItem()
	{
		TemplateId = 0;
		Name = null;
		Type = 0;
		Size = ETaiwuLifeSummaryGroupSize.Small;
		Items = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public TaiwuLifeSummaryGroupItem(sbyte templateId, TaiwuLifeSummaryGroupItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Type = other.Type;
		Size = other.Size;
		Items = other.Items;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override TaiwuLifeSummaryGroupItem Duplicate(int templateId)
	{
		return new TaiwuLifeSummaryGroupItem((sbyte)templateId, this);
	}
}

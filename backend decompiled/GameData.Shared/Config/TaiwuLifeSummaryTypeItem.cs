using System;
using Config.Common;

namespace Config;

[Serializable]
public class TaiwuLifeSummaryTypeItem : ConfigItem<TaiwuLifeSummaryTypeItem, int>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly int TemplateId;

	/// <summary>
	/// 数据名称
	/// - 需要显示在数据界面和绘卷界面的数据名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 分类
	/// </summary>
	public readonly sbyte Type;

	/// <summary>
	/// 是否在绘卷显示
	/// </summary>
	public readonly bool DisplayInScrollOfTaiwu;

	/// <summary>
	/// 记录日期
	/// - 默认为数值/次数记录,勾选该项则记录游戏中的日期.
	/// </summary>
	public readonly bool IsDate;

	/// <summary>
	/// 记录时长
	/// - 勾选则前端显示为：数值*1s/60
	/// </summary>
	public readonly bool IsTime;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">数据名称 - 需要显示在数据界面和绘卷界面的数据名称</param>
	/// <param name="type">分类</param>
	/// <param name="displayInScrollOfTaiwu">是否在绘卷显示</param>
	/// <param name="isDate">记录日期 - 默认为数值/次数记录,勾选该项则记录游戏中的日期.</param>
	/// <param name="isTime">记录时长 - 勾选则前端显示为：数值*1s/60</param>
	public TaiwuLifeSummaryTypeItem(int templateId, string name, sbyte type, bool displayInScrollOfTaiwu, bool isDate, bool isTime)
	{
		TemplateId = templateId;
		Name = name;
		Type = type;
		DisplayInScrollOfTaiwu = displayInScrollOfTaiwu;
		IsDate = isDate;
		IsTime = isTime;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public TaiwuLifeSummaryTypeItem()
	{
		TemplateId = 0;
		Name = null;
		Type = 0;
		DisplayInScrollOfTaiwu = false;
		IsDate = false;
		IsTime = false;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public TaiwuLifeSummaryTypeItem(int templateId, TaiwuLifeSummaryTypeItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Type = other.Type;
		DisplayInScrollOfTaiwu = other.DisplayInScrollOfTaiwu;
		IsDate = other.IsDate;
		IsTime = other.IsTime;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override TaiwuLifeSummaryTypeItem Duplicate(int templateId)
	{
		return new TaiwuLifeSummaryTypeItem(templateId, this);
	}
}

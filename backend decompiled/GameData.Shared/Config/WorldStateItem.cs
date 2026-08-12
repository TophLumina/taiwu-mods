using System;
using Config.Common;

namespace Config;

[Serializable]
public class WorldStateItem : ConfigItem<WorldStateItem, sbyte>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly sbyte TemplateId;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 描述
	/// - 目前程序通过split("\n\n")来读取世界进度改变时显示文本，因而各相枢进度需要以\n\n分割文本与世界效果
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 图标
	/// </summary>
	public readonly string Icon;

	/// <summary>
	/// 地区主线触发条件描述
	/// </summary>
	public readonly string[] SectStoryCondition;

	/// <summary>
	/// 对应门派
	/// - 值为门派的团体模板 ID.
	/// </summary>
	public readonly sbyte Sect;

	/// <summary>
	/// 触发地区
	/// - 控制状态是否显示，没配置的在门派所在州域的非毁坏地区显示；配置的在该地区才显示
	/// </summary>
	public readonly short TriggerArea;

	/// <summary>
	/// 可能触发的过月事件
	/// - 在处于对应的世界状态时，每次过月都会试图触发配置的过月事件. 实际是否触发成功由头部事件的条件决定.
	/// </summary>
	public readonly short[] MonthlyEvents;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="name">名称</param>
	/// <param name="desc">描述 - 目前程序通过split("\n\n")来读取世界进度改变时显示文本，因而各相枢进度需要以\n\n分割文本与世界效果</param>
	/// <param name="icon">图标</param>
	/// <param name="sectStoryCondition">地区主线触发条件描述</param>
	/// <param name="sect">对应门派 - 值为门派的团体模板 ID.</param>
	/// <param name="triggerArea">触发地区 - 控制状态是否显示，没配置的在门派所在州域的非毁坏地区显示；配置的在该地区才显示</param>
	/// <param name="monthlyEvents">可能触发的过月事件 - 在处于对应的世界状态时，每次过月都会试图触发配置的过月事件. 实际是否触发成功由头部事件的条件决定.</param>
	public WorldStateItem(sbyte templateId, string name, string desc, string icon, string[] sectStoryCondition, sbyte sect, short triggerArea, short[] monthlyEvents)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		Icon = icon;
		SectStoryCondition = sectStoryCondition;
		Sect = sect;
		TriggerArea = triggerArea;
		MonthlyEvents = monthlyEvents;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public WorldStateItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		Icon = null;
		SectStoryCondition = new string[0];
		Sect = 0;
		TriggerArea = 0;
		MonthlyEvents = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public WorldStateItem(sbyte templateId, WorldStateItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		Icon = other.Icon;
		SectStoryCondition = other.SectStoryCondition;
		Sect = other.Sect;
		TriggerArea = other.TriggerArea;
		MonthlyEvents = other.MonthlyEvents;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override WorldStateItem Duplicate(int templateId)
	{
		return new WorldStateItem((sbyte)templateId, this);
	}
}

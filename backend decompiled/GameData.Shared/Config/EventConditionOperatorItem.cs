using System;
using Config.Common;

namespace Config;

[Serializable]
public class EventConditionOperatorItem : ConfigItem<EventConditionOperatorItem, int>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly int TemplateId;

	/// <summary>
	/// 显示名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="name">显示名称</param>
	public EventConditionOperatorItem(int templateId, string name)
	{
		TemplateId = templateId;
		Name = name;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public EventConditionOperatorItem()
	{
		TemplateId = 0;
		Name = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public EventConditionOperatorItem(int templateId, EventConditionOperatorItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override EventConditionOperatorItem Duplicate(int templateId)
	{
		return new EventConditionOperatorItem(templateId, this);
	}
}

using System;
using Config.Common;

namespace Config;

[Serializable]
public class EventBoolStateItem : ConfigItem<EventBoolStateItem, short>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 显示名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 是否在进入下一级事件前移除
	/// - 默认值
	/// </summary>
	public readonly bool RemoveBeforeNextEvent;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="name">显示名称</param>
	/// <param name="removeBeforeNextEvent">是否在进入下一级事件前移除 - 默认值</param>
	public EventBoolStateItem(short templateId, string name, bool removeBeforeNextEvent)
	{
		TemplateId = templateId;
		Name = name;
		RemoveBeforeNextEvent = removeBeforeNextEvent;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public EventBoolStateItem()
	{
		TemplateId = 0;
		Name = null;
		RemoveBeforeNextEvent = false;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public EventBoolStateItem(short templateId, EventBoolStateItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		RemoveBeforeNextEvent = other.RemoveBeforeNextEvent;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override EventBoolStateItem Duplicate(int templateId)
	{
		return new EventBoolStateItem((short)templateId, this);
	}
}

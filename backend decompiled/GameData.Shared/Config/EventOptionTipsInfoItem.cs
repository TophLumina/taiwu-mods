using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class EventOptionTipsInfoItem : ConfigItem<EventOptionTipsInfoItem, sbyte>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly sbyte TemplateId;

	/// <summary>
	/// 标题
	/// </summary>
	public readonly string Title;

	/// <summary>
	/// 描述
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 事件选项Guid
	/// </summary>
	public readonly List<string> Guid;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="title">标题</param>
	/// <param name="desc">描述</param>
	/// <param name="guid">事件选项Guid</param>
	public EventOptionTipsInfoItem(sbyte templateId, string title, string desc, List<string> guid)
	{
		TemplateId = templateId;
		Title = title;
		Desc = desc;
		Guid = guid;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public EventOptionTipsInfoItem()
	{
		TemplateId = 0;
		Title = null;
		Desc = null;
		Guid = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public EventOptionTipsInfoItem(sbyte templateId, EventOptionTipsInfoItem other)
	{
		TemplateId = templateId;
		Title = other.Title;
		Desc = other.Desc;
		Guid = other.Guid;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override EventOptionTipsInfoItem Duplicate(int templateId)
	{
		return new EventOptionTipsInfoItem((sbyte)templateId, this);
	}
}

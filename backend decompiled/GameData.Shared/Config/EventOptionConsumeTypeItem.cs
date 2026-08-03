using System;
using Config.Common;

namespace Config;

[Serializable]
public class EventOptionConsumeTypeItem : ConfigItem<EventOptionConsumeTypeItem, sbyte>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly sbyte TemplateId;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	public EventOptionConsumeTypeItem(sbyte templateId)
	{
		TemplateId = templateId;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public EventOptionConsumeTypeItem()
	{
		TemplateId = 0;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public EventOptionConsumeTypeItem(sbyte templateId, EventOptionConsumeTypeItem other)
	{
		TemplateId = templateId;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override EventOptionConsumeTypeItem Duplicate(int templateId)
	{
		return new EventOptionConsumeTypeItem((sbyte)templateId, this);
	}
}

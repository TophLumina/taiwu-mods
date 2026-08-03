using System;
using Config.Common;

namespace Config;

[Serializable]
public class TaskHintItem : ConfigItem<TaskHintItem, sbyte>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly sbyte TemplateId;

	/// <summary>
	/// 信息
	/// </summary>
	public readonly string Info;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="info">信息</param>
	public TaskHintItem(sbyte templateId, string info)
	{
		TemplateId = templateId;
		Info = info;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public TaskHintItem()
	{
		TemplateId = 0;
		Info = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public TaskHintItem(sbyte templateId, TaskHintItem other)
	{
		TemplateId = templateId;
		Info = other.Info;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override TaskHintItem Duplicate(int templateId)
	{
		return new TaskHintItem((sbyte)templateId, this);
	}
}

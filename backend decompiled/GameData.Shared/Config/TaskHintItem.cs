using System;
using Config.Common;

namespace Config;

[Serializable]
public class TaskHintItem : ConfigItem<TaskHintItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly string Info;

	public TaskHintItem(sbyte templateId, string info)
	{
		TemplateId = templateId;
		Info = info;
	}

	public TaskHintItem()
	{
		TemplateId = 0;
		Info = null;
	}

	public TaskHintItem(sbyte templateId, TaskHintItem other)
	{
		TemplateId = templateId;
		Info = other.Info;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override TaskHintItem Duplicate(int templateId)
	{
		return new TaskHintItem((sbyte)templateId, this);
	}
}

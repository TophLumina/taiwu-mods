using System;
using Config.Common;

namespace Config;

[Serializable]
public class ExtraNameTextItem : ConfigItem<ExtraNameTextItem, int>
{
	public readonly int TemplateId;

	public readonly string Content;

	public ExtraNameTextItem(int templateId, string content)
	{
		TemplateId = templateId;
		Content = content;
	}

	public ExtraNameTextItem()
	{
		TemplateId = 0;
		Content = null;
	}

	public ExtraNameTextItem(int templateId, ExtraNameTextItem other)
	{
		TemplateId = templateId;
		Content = other.Content;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override ExtraNameTextItem Duplicate(int templateId)
	{
		return new ExtraNameTextItem(templateId, this);
	}
}

using System;
using Config.Common;

namespace Config;

[Serializable]
public class LoadingTipsItem : ConfigItem<LoadingTipsItem, int>
{
	public readonly int TemplateId;

	public readonly string Title;

	public readonly string Content;

	public LoadingTipsItem(int templateId, string title, string content)
	{
		TemplateId = templateId;
		Title = title;
		Content = content;
	}

	public LoadingTipsItem()
	{
		TemplateId = 0;
		Title = null;
		Content = null;
	}

	public LoadingTipsItem(int templateId, LoadingTipsItem other)
	{
		TemplateId = templateId;
		Title = other.Title;
		Content = other.Content;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override LoadingTipsItem Duplicate(int templateId)
	{
		return new LoadingTipsItem(templateId, this);
	}
}

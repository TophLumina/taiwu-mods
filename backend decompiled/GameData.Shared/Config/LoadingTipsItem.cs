using System;
using Config.Common;

namespace Config;

[Serializable]
public class LoadingTipsItem : ConfigItem<LoadingTipsItem, int>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly int TemplateId;

	/// <summary>
	/// 标题
	/// </summary>
	public readonly string Title;

	/// <summary>
	/// 内容
	/// </summary>
	public readonly string Content;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="title">标题</param>
	/// <param name="content">内容</param>
	public LoadingTipsItem(int templateId, string title, string content)
	{
		TemplateId = templateId;
		Title = title;
		Content = content;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public LoadingTipsItem()
	{
		TemplateId = 0;
		Title = null;
		Content = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
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

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override LoadingTipsItem Duplicate(int templateId)
	{
		return new LoadingTipsItem(templateId, this);
	}
}

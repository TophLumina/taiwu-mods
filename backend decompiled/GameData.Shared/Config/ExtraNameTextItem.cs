using System;
using Config.Common;

namespace Config;

[Serializable]
public class ExtraNameTextItem : ConfigItem<ExtraNameTextItem, int>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly int TemplateId;

	/// <summary>
	/// 内容
	/// </summary>
	public readonly string Content;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="content">内容</param>
	public ExtraNameTextItem(int templateId, string content)
	{
		TemplateId = templateId;
		Content = content;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public ExtraNameTextItem()
	{
		TemplateId = 0;
		Content = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public ExtraNameTextItem(int templateId, ExtraNameTextItem other)
	{
		TemplateId = templateId;
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
	public override ExtraNameTextItem Duplicate(int templateId)
	{
		return new ExtraNameTextItem(templateId, this);
	}
}

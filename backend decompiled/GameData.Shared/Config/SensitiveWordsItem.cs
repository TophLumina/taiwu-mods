using System;
using Config.Common;

namespace Config;

[Serializable]
public class SensitiveWordsItem : ConfigItem<SensitiveWordsItem, int>
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
	/// 屏蔽词类别
	/// </summary>
	public readonly ESensitiveWordsType Type;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="content">内容</param>
	/// <param name="type">屏蔽词类别</param>
	public SensitiveWordsItem(int templateId, string content, ESensitiveWordsType type)
	{
		TemplateId = templateId;
		Content = content;
		Type = type;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public SensitiveWordsItem()
	{
		TemplateId = 0;
		Content = null;
		Type = ESensitiveWordsType.Undetermined;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public SensitiveWordsItem(int templateId, SensitiveWordsItem other)
	{
		TemplateId = templateId;
		Content = other.Content;
		Type = other.Type;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override SensitiveWordsItem Duplicate(int templateId)
	{
		return new SensitiveWordsItem(templateId, this);
	}
}

using System;
using Config.Common;

namespace Config;

[Serializable]
public class SensitiveWordsItem : ConfigItem<SensitiveWordsItem, int>
{
	public readonly int TemplateId;

	public readonly string Content;

	public readonly ESensitiveWordsType Type;

	public SensitiveWordsItem(int templateId, string content, ESensitiveWordsType type)
	{
		TemplateId = templateId;
		Content = content;
		Type = type;
	}

	public SensitiveWordsItem()
	{
		TemplateId = 0;
		Content = null;
		Type = ESensitiveWordsType.Undetermined;
	}

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

	public override SensitiveWordsItem Duplicate(int templateId)
	{
		return new SensitiveWordsItem(templateId, this);
	}
}

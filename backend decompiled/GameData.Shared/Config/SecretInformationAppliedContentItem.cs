using System;
using Config.Common;

namespace Config;

[Serializable]
public class SecretInformationAppliedContentItem : ConfigItem<SecretInformationAppliedContentItem, short>
{
	public readonly short TemplateId;

	public readonly short LinkedResult;

	public readonly string[] Texts;

	public SecretInformationAppliedContentItem(short templateId, short linkedResult, string[] texts)
	{
		TemplateId = templateId;
		LinkedResult = linkedResult;
		Texts = texts;
	}

	public SecretInformationAppliedContentItem()
	{
		TemplateId = 0;
		LinkedResult = 0;
		Texts = null;
	}

	public SecretInformationAppliedContentItem(short templateId, SecretInformationAppliedContentItem other)
	{
		TemplateId = templateId;
		LinkedResult = other.LinkedResult;
		Texts = other.Texts;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override SecretInformationAppliedContentItem Duplicate(int templateId)
	{
		return new SecretInformationAppliedContentItem((short)templateId, this);
	}
}

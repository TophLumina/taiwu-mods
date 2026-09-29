using System;
using Config.Common;

namespace Config;

[Serializable]
public class CommonTipItem : ConfigItem<CommonTipItem, int>
{
	public readonly int TemplateId;

	public readonly string Path;

	public CommonTipItem(int templateId, string path)
	{
		TemplateId = templateId;
		Path = path;
	}

	public CommonTipItem()
	{
		TemplateId = 0;
		Path = null;
	}

	public CommonTipItem(int templateId, CommonTipItem other)
	{
		TemplateId = templateId;
		Path = other.Path;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override CommonTipItem Duplicate(int templateId)
	{
		return new CommonTipItem(templateId, this);
	}
}

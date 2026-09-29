using System;
using Config.Common;

namespace Config;

[Serializable]
public class SamsaraPlatformRecordItem : ConfigItem<SamsaraPlatformRecordItem, short>
{
	public readonly short TemplateId;

	public readonly string Desc;

	public readonly string[] Parameters;

	public SamsaraPlatformRecordItem(short templateId, string desc, string[] parameters)
	{
		TemplateId = templateId;
		Desc = desc;
		Parameters = parameters;
	}

	public SamsaraPlatformRecordItem()
	{
		TemplateId = 0;
		Desc = null;
		Parameters = new string[5] { "", "", "", "", "" };
	}

	public SamsaraPlatformRecordItem(short templateId, SamsaraPlatformRecordItem other)
	{
		TemplateId = templateId;
		Desc = other.Desc;
		Parameters = other.Parameters;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override SamsaraPlatformRecordItem Duplicate(int templateId)
	{
		return new SamsaraPlatformRecordItem((short)templateId, this);
	}
}

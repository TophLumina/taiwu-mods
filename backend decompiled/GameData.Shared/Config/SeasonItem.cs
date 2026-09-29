using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class SeasonItem : ConfigItem<SeasonItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly List<sbyte> Months;

	public SeasonItem(sbyte templateId, List<sbyte> months)
	{
		TemplateId = templateId;
		Months = months;
	}

	public SeasonItem()
	{
		TemplateId = 0;
		Months = null;
	}

	public SeasonItem(sbyte templateId, SeasonItem other)
	{
		TemplateId = templateId;
		Months = other.Months;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override SeasonItem Duplicate(int templateId)
	{
		return new SeasonItem((sbyte)templateId, this);
	}
}

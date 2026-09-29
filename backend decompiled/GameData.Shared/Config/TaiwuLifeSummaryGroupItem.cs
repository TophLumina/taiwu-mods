using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class TaiwuLifeSummaryGroupItem : ConfigItem<TaiwuLifeSummaryGroupItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly string Name;

	public readonly sbyte Type;

	public readonly ETaiwuLifeSummaryGroupSize Size;

	public readonly List<int> Items;

	public TaiwuLifeSummaryGroupItem(sbyte templateId, string name, sbyte type, ETaiwuLifeSummaryGroupSize size, List<int> items)
	{
		TemplateId = templateId;
		Name = name;
		Type = type;
		Size = size;
		Items = items;
	}

	public TaiwuLifeSummaryGroupItem()
	{
		TemplateId = 0;
		Name = null;
		Type = 0;
		Size = ETaiwuLifeSummaryGroupSize.Small;
		Items = null;
	}

	public TaiwuLifeSummaryGroupItem(sbyte templateId, TaiwuLifeSummaryGroupItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Type = other.Type;
		Size = other.Size;
		Items = other.Items;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override TaiwuLifeSummaryGroupItem Duplicate(int templateId)
	{
		return new TaiwuLifeSummaryGroupItem((sbyte)templateId, this);
	}
}

using System;
using Config.Common;

namespace Config;

[Serializable]
public class TaiwuLifeSummaryTypeItem : ConfigItem<TaiwuLifeSummaryTypeItem, int>
{
	public readonly int TemplateId;

	public readonly string Name;

	public readonly sbyte Type;

	public readonly bool DisplayInScrollOfTaiwu;

	public readonly bool IsDate;

	public readonly bool IsTime;

	public TaiwuLifeSummaryTypeItem(int templateId, string name, sbyte type, bool displayInScrollOfTaiwu, bool isDate, bool isTime)
	{
		TemplateId = templateId;
		Name = name;
		Type = type;
		DisplayInScrollOfTaiwu = displayInScrollOfTaiwu;
		IsDate = isDate;
		IsTime = isTime;
	}

	public TaiwuLifeSummaryTypeItem()
	{
		TemplateId = 0;
		Name = null;
		Type = 0;
		DisplayInScrollOfTaiwu = false;
		IsDate = false;
		IsTime = false;
	}

	public TaiwuLifeSummaryTypeItem(int templateId, TaiwuLifeSummaryTypeItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Type = other.Type;
		DisplayInScrollOfTaiwu = other.DisplayInScrollOfTaiwu;
		IsDate = other.IsDate;
		IsTime = other.IsTime;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override TaiwuLifeSummaryTypeItem Duplicate(int templateId)
	{
		return new TaiwuLifeSummaryTypeItem(templateId, this);
	}
}

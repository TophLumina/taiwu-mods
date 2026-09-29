using System;
using Config.Common;

namespace Config;

[Serializable]
public class AdvancingMonthStateItem : ConfigItem<AdvancingMonthStateItem, int>
{
	public readonly int TemplateId;

	public readonly string HintText;

	public AdvancingMonthStateItem(int templateId, string hintText)
	{
		TemplateId = templateId;
		HintText = hintText;
	}

	public AdvancingMonthStateItem()
	{
		TemplateId = 0;
		HintText = null;
	}

	public AdvancingMonthStateItem(int templateId, AdvancingMonthStateItem other)
	{
		TemplateId = templateId;
		HintText = other.HintText;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override AdvancingMonthStateItem Duplicate(int templateId)
	{
		return new AdvancingMonthStateItem(templateId, this);
	}
}

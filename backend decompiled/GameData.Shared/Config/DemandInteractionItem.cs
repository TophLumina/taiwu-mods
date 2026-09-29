using System;
using Config.Common;

namespace Config;

[Serializable]
public class DemandInteractionItem : ConfigItem<DemandInteractionItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly string HeadEvent;

	public readonly string AgreeSelect;

	public readonly string AfterAgree;

	public DemandInteractionItem(short templateId, string name, string headEvent, string agreeSelect, string afterAgree)
	{
		TemplateId = templateId;
		Name = name;
		HeadEvent = headEvent;
		AgreeSelect = agreeSelect;
		AfterAgree = afterAgree;
	}

	public DemandInteractionItem()
	{
		TemplateId = 0;
		Name = null;
		HeadEvent = null;
		AgreeSelect = null;
		AfterAgree = null;
	}

	public DemandInteractionItem(short templateId, DemandInteractionItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		HeadEvent = other.HeadEvent;
		AgreeSelect = other.AgreeSelect;
		AfterAgree = other.AfterAgree;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override DemandInteractionItem Duplicate(int templateId)
	{
		return new DemandInteractionItem((short)templateId, this);
	}
}

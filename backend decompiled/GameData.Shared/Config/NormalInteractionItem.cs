using System;
using Config.Common;

namespace Config;

[Serializable]
public class NormalInteractionItem : ConfigItem<NormalInteractionItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly string[] HeadEvent;

	public readonly string[] AgreeAndSuccess;

	public readonly string[] AgreeAndFail;

	public readonly string[] Disagree;

	public NormalInteractionItem(short templateId, string name, string[] headEvent, string[] agreeAndSuccess, string[] agreeAndFail, string[] disagree)
	{
		TemplateId = templateId;
		Name = name;
		HeadEvent = headEvent;
		AgreeAndSuccess = agreeAndSuccess;
		AgreeAndFail = agreeAndFail;
		Disagree = disagree;
	}

	public NormalInteractionItem()
	{
		TemplateId = 0;
		Name = null;
		HeadEvent = null;
		AgreeAndSuccess = null;
		AgreeAndFail = null;
		Disagree = null;
	}

	public NormalInteractionItem(short templateId, NormalInteractionItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		HeadEvent = other.HeadEvent;
		AgreeAndSuccess = other.AgreeAndSuccess;
		AgreeAndFail = other.AgreeAndFail;
		Disagree = other.Disagree;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override NormalInteractionItem Duplicate(int templateId)
	{
		return new NormalInteractionItem((short)templateId, this);
	}
}

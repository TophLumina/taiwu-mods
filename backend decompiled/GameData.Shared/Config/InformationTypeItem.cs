using System;
using Config.Common;

namespace Config;

[Serializable]
public class InformationTypeItem : ConfigItem<InformationTypeItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly string Name;

	public readonly string Desc;

	public readonly string DescGain;

	public readonly string DescEffect;

	public readonly string DescEffectWay;

	public readonly string Title;

	public readonly bool InUse;

	public InformationTypeItem(sbyte templateId, string name, string desc, string descGain, string descEffect, string descEffectWay, string title, bool inUse)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		DescGain = descGain;
		DescEffect = descEffect;
		DescEffectWay = descEffectWay;
		Title = title;
		InUse = inUse;
	}

	public InformationTypeItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		DescGain = null;
		DescEffect = null;
		DescEffectWay = null;
		Title = null;
		InUse = true;
	}

	public InformationTypeItem(sbyte templateId, InformationTypeItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		DescGain = other.DescGain;
		DescEffect = other.DescEffect;
		DescEffectWay = other.DescEffectWay;
		Title = other.Title;
		InUse = other.InUse;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override InformationTypeItem Duplicate(int templateId)
	{
		return new InformationTypeItem((sbyte)templateId, this);
	}
}

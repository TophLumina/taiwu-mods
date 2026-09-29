using System;
using Config.Common;

namespace Config;

[Serializable]
public class BodyPartItem : ConfigItem<BodyPartItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly string Name;

	public readonly string AcupointDesc;

	public readonly int[] AcupointParam;

	public readonly int[] AcupointTime;

	public readonly string MouseTipIcon;

	public readonly string OuterInjuryIcon;

	public readonly string InnerInjuryIcon;

	public BodyPartItem(sbyte templateId, string name, string acupointDesc, int[] acupointParam, int[] acupointTime, string mouseTipIcon, string outerInjuryIcon, string innerInjuryIcon)
	{
		TemplateId = templateId;
		Name = name;
		AcupointDesc = acupointDesc;
		AcupointParam = acupointParam;
		AcupointTime = acupointTime;
		MouseTipIcon = mouseTipIcon;
		OuterInjuryIcon = outerInjuryIcon;
		InnerInjuryIcon = innerInjuryIcon;
	}

	public BodyPartItem()
	{
		TemplateId = 0;
		Name = null;
		AcupointDesc = null;
		AcupointParam = null;
		AcupointTime = new int[3] { 0, 50, 75 };
		MouseTipIcon = null;
		OuterInjuryIcon = null;
		InnerInjuryIcon = null;
	}

	public BodyPartItem(sbyte templateId, BodyPartItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		AcupointDesc = other.AcupointDesc;
		AcupointParam = other.AcupointParam;
		AcupointTime = other.AcupointTime;
		MouseTipIcon = other.MouseTipIcon;
		OuterInjuryIcon = other.OuterInjuryIcon;
		InnerInjuryIcon = other.InnerInjuryIcon;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override BodyPartItem Duplicate(int templateId)
	{
		return new BodyPartItem((sbyte)templateId, this);
	}
}

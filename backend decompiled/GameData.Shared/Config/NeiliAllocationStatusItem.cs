using System;
using Config.Common;

namespace Config;

[Serializable]
public class NeiliAllocationStatusItem : ConfigItem<NeiliAllocationStatusItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly ENeiliAllocationStatusType Type;

	public readonly string Name;

	public readonly string[] Desc;

	public readonly int MinThreshold;

	public readonly int MaxThreshold;

	public readonly bool AllowEqualsMin;

	public readonly int GoneMadInjuryRate;

	public readonly int GoneMadInjuryBonus;

	public readonly int PowerAddPercent;

	public readonly int CostNeiliAllocation;

	public readonly int AddNeiliAllocation;

	public readonly sbyte MarkCount;

	public NeiliAllocationStatusItem(sbyte templateId, ENeiliAllocationStatusType type, string name, string[] desc, int minThreshold, int maxThreshold, bool allowEqualsMin, int goneMadInjuryRate, int goneMadInjuryBonus, int powerAddPercent, int costNeiliAllocation, int addNeiliAllocation, sbyte markCount)
	{
		TemplateId = templateId;
		Type = type;
		Name = name;
		Desc = desc;
		MinThreshold = minThreshold;
		MaxThreshold = maxThreshold;
		AllowEqualsMin = allowEqualsMin;
		GoneMadInjuryRate = goneMadInjuryRate;
		GoneMadInjuryBonus = goneMadInjuryBonus;
		PowerAddPercent = powerAddPercent;
		CostNeiliAllocation = costNeiliAllocation;
		AddNeiliAllocation = addNeiliAllocation;
		MarkCount = markCount;
	}

	public NeiliAllocationStatusItem()
	{
		TemplateId = 0;
		Type = ENeiliAllocationStatusType.Scatter;
		Name = null;
		Desc = null;
		MinThreshold = 0;
		MaxThreshold = 0;
		AllowEqualsMin = false;
		GoneMadInjuryRate = 0;
		GoneMadInjuryBonus = 0;
		PowerAddPercent = 0;
		CostNeiliAllocation = 0;
		AddNeiliAllocation = 0;
		MarkCount = 0;
	}

	public NeiliAllocationStatusItem(sbyte templateId, NeiliAllocationStatusItem other)
	{
		TemplateId = templateId;
		Type = other.Type;
		Name = other.Name;
		Desc = other.Desc;
		MinThreshold = other.MinThreshold;
		MaxThreshold = other.MaxThreshold;
		AllowEqualsMin = other.AllowEqualsMin;
		GoneMadInjuryRate = other.GoneMadInjuryRate;
		GoneMadInjuryBonus = other.GoneMadInjuryBonus;
		PowerAddPercent = other.PowerAddPercent;
		CostNeiliAllocation = other.CostNeiliAllocation;
		AddNeiliAllocation = other.AddNeiliAllocation;
		MarkCount = other.MarkCount;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override NeiliAllocationStatusItem Duplicate(int templateId)
	{
		return new NeiliAllocationStatusItem((sbyte)templateId, this);
	}
}

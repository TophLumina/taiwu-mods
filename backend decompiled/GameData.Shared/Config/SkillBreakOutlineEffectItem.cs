using System;
using Config.Common;

namespace Config;

[Serializable]
public class SkillBreakOutlineEffectItem : ConfigItem<SkillBreakOutlineEffectItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly string Desc;

	public readonly int StepBonusNormal;

	public readonly int StepBonusGoneMad;

	public readonly int PowerAddCenterRate;

	public readonly int BonusAddMaxPower;

	public readonly int BonusAddMaxPowerNormal;

	public readonly int BonusAddMaxPowerGoneMad;

	public readonly int MaxPowerPerGrid;

	public readonly int AddExpCostNormal;

	public readonly int AddExpCostGoneMad;

	public readonly int AddExpCostCenter;

	public readonly int AddExpCostEdge;

	public readonly string DescShort;

	public SkillBreakOutlineEffectItem(sbyte templateId, string desc, int stepBonusNormal, int stepBonusGoneMad, int powerAddCenterRate, int bonusAddMaxPower, int bonusAddMaxPowerNormal, int bonusAddMaxPowerGoneMad, int maxPowerPerGrid, int addExpCostNormal, int addExpCostGoneMad, int addExpCostCenter, int addExpCostEdge, string descShort)
	{
		TemplateId = templateId;
		Desc = desc;
		StepBonusNormal = stepBonusNormal;
		StepBonusGoneMad = stepBonusGoneMad;
		PowerAddCenterRate = powerAddCenterRate;
		BonusAddMaxPower = bonusAddMaxPower;
		BonusAddMaxPowerNormal = bonusAddMaxPowerNormal;
		BonusAddMaxPowerGoneMad = bonusAddMaxPowerGoneMad;
		MaxPowerPerGrid = maxPowerPerGrid;
		AddExpCostNormal = addExpCostNormal;
		AddExpCostGoneMad = addExpCostGoneMad;
		AddExpCostCenter = addExpCostCenter;
		AddExpCostEdge = addExpCostEdge;
		DescShort = descShort;
	}

	public SkillBreakOutlineEffectItem()
	{
		TemplateId = 0;
		Desc = null;
		StepBonusNormal = 0;
		StepBonusGoneMad = 0;
		PowerAddCenterRate = 0;
		BonusAddMaxPower = 0;
		BonusAddMaxPowerNormal = 0;
		BonusAddMaxPowerGoneMad = 0;
		MaxPowerPerGrid = 3;
		AddExpCostNormal = 0;
		AddExpCostGoneMad = 0;
		AddExpCostCenter = 0;
		AddExpCostEdge = 0;
		DescShort = null;
	}

	public SkillBreakOutlineEffectItem(sbyte templateId, SkillBreakOutlineEffectItem other)
	{
		TemplateId = templateId;
		Desc = other.Desc;
		StepBonusNormal = other.StepBonusNormal;
		StepBonusGoneMad = other.StepBonusGoneMad;
		PowerAddCenterRate = other.PowerAddCenterRate;
		BonusAddMaxPower = other.BonusAddMaxPower;
		BonusAddMaxPowerNormal = other.BonusAddMaxPowerNormal;
		BonusAddMaxPowerGoneMad = other.BonusAddMaxPowerGoneMad;
		MaxPowerPerGrid = other.MaxPowerPerGrid;
		AddExpCostNormal = other.AddExpCostNormal;
		AddExpCostGoneMad = other.AddExpCostGoneMad;
		AddExpCostCenter = other.AddExpCostCenter;
		AddExpCostEdge = other.AddExpCostEdge;
		DescShort = other.DescShort;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override SkillBreakOutlineEffectItem Duplicate(int templateId)
	{
		return new SkillBreakOutlineEffectItem((sbyte)templateId, this);
	}
}

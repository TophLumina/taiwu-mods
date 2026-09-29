using System;
using Config.Common;

namespace Config;

[Serializable]
public class SkillBreakGridTypeItem : ConfigItem<SkillBreakGridTypeItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly string Name;

	public readonly ESkillBreakGridTypeType Type;

	public readonly string Desc;

	public readonly string FontColor;

	public readonly int ShowInvisibleCount;

	public readonly byte CostBreakCount;

	public readonly byte AddStepNormal;

	public readonly sbyte FixedSuccessRate;

	public readonly sbyte SuccessRateBonus;

	public readonly sbyte NeighborSuccessRateBonus;

	public readonly sbyte NeighborSuccessRateBonusWhenActive;

	public readonly sbyte SucceedNeighborSuccessRateBonus;

	public readonly sbyte BreakCountAboveHalfBonus;

	public readonly sbyte BreakCountBelowHalfBonus;

	public readonly sbyte NextSuccessRateBonus;

	public readonly sbyte NextStepOffset;

	public readonly bool NextStepCanJumpToSame;

	public readonly bool NeighborFailedToCanSelect;

	public readonly bool RandomNeighborNormalConvertToSameGrid;

	public readonly bool AllNeighborNormalConvertToSpecialGrid;

	public readonly bool AllNeighborSpecialConvertToNormalGrid;

	public readonly bool ClearNeighborMaxPower;

	public readonly bool IgnoreEffectAddMaxPower;

	public readonly int NeighborAddMaxPowerWhenActive;

	public readonly int SucceedNeighborAddMaxPower;

	public readonly int TransferPowerAndConvertToFailedNeighborCount;

	public readonly sbyte HealthCost;

	public readonly short WeightOnGenerate;

	public readonly short WeightOnConvert;

	public SkillBreakGridTypeItem(sbyte templateId, string name, ESkillBreakGridTypeType type, string desc, string fontColor, int showInvisibleCount, byte costBreakCount, byte addStepNormal, sbyte fixedSuccessRate, sbyte successRateBonus, sbyte neighborSuccessRateBonus, sbyte neighborSuccessRateBonusWhenActive, sbyte succeedNeighborSuccessRateBonus, sbyte breakCountAboveHalfBonus, sbyte breakCountBelowHalfBonus, sbyte nextSuccessRateBonus, sbyte nextStepOffset, bool nextStepCanJumpToSame, bool neighborFailedToCanSelect, bool randomNeighborNormalConvertToSameGrid, bool allNeighborNormalConvertToSpecialGrid, bool allNeighborSpecialConvertToNormalGrid, bool clearNeighborMaxPower, bool ignoreEffectAddMaxPower, int neighborAddMaxPowerWhenActive, int succeedNeighborAddMaxPower, int transferPowerAndConvertToFailedNeighborCount, sbyte healthCost, short weightOnGenerate, short weightOnConvert)
	{
		TemplateId = templateId;
		Name = name;
		Type = type;
		Desc = desc;
		FontColor = fontColor;
		ShowInvisibleCount = showInvisibleCount;
		CostBreakCount = costBreakCount;
		AddStepNormal = addStepNormal;
		FixedSuccessRate = fixedSuccessRate;
		SuccessRateBonus = successRateBonus;
		NeighborSuccessRateBonus = neighborSuccessRateBonus;
		NeighborSuccessRateBonusWhenActive = neighborSuccessRateBonusWhenActive;
		SucceedNeighborSuccessRateBonus = succeedNeighborSuccessRateBonus;
		BreakCountAboveHalfBonus = breakCountAboveHalfBonus;
		BreakCountBelowHalfBonus = breakCountBelowHalfBonus;
		NextSuccessRateBonus = nextSuccessRateBonus;
		NextStepOffset = nextStepOffset;
		NextStepCanJumpToSame = nextStepCanJumpToSame;
		NeighborFailedToCanSelect = neighborFailedToCanSelect;
		RandomNeighborNormalConvertToSameGrid = randomNeighborNormalConvertToSameGrid;
		AllNeighborNormalConvertToSpecialGrid = allNeighborNormalConvertToSpecialGrid;
		AllNeighborSpecialConvertToNormalGrid = allNeighborSpecialConvertToNormalGrid;
		ClearNeighborMaxPower = clearNeighborMaxPower;
		IgnoreEffectAddMaxPower = ignoreEffectAddMaxPower;
		NeighborAddMaxPowerWhenActive = neighborAddMaxPowerWhenActive;
		SucceedNeighborAddMaxPower = succeedNeighborAddMaxPower;
		TransferPowerAndConvertToFailedNeighborCount = transferPowerAndConvertToFailedNeighborCount;
		HealthCost = healthCost;
		WeightOnGenerate = weightOnGenerate;
		WeightOnConvert = weightOnConvert;
	}

	public SkillBreakGridTypeItem()
	{
		TemplateId = 0;
		Name = null;
		Type = ESkillBreakGridTypeType.StartPoint;
		Desc = null;
		FontColor = null;
		ShowInvisibleCount = 0;
		CostBreakCount = 1;
		AddStepNormal = 0;
		FixedSuccessRate = -1;
		SuccessRateBonus = 0;
		NeighborSuccessRateBonus = 0;
		NeighborSuccessRateBonusWhenActive = 0;
		SucceedNeighborSuccessRateBonus = 0;
		BreakCountAboveHalfBonus = 0;
		BreakCountBelowHalfBonus = 0;
		NextSuccessRateBonus = 0;
		NextStepOffset = 1;
		NextStepCanJumpToSame = false;
		NeighborFailedToCanSelect = false;
		RandomNeighborNormalConvertToSameGrid = false;
		AllNeighborNormalConvertToSpecialGrid = false;
		AllNeighborSpecialConvertToNormalGrid = false;
		ClearNeighborMaxPower = false;
		IgnoreEffectAddMaxPower = false;
		NeighborAddMaxPowerWhenActive = 0;
		SucceedNeighborAddMaxPower = 0;
		TransferPowerAndConvertToFailedNeighborCount = 0;
		HealthCost = 0;
		WeightOnGenerate = 0;
		WeightOnConvert = 0;
	}

	public SkillBreakGridTypeItem(sbyte templateId, SkillBreakGridTypeItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Type = other.Type;
		Desc = other.Desc;
		FontColor = other.FontColor;
		ShowInvisibleCount = other.ShowInvisibleCount;
		CostBreakCount = other.CostBreakCount;
		AddStepNormal = other.AddStepNormal;
		FixedSuccessRate = other.FixedSuccessRate;
		SuccessRateBonus = other.SuccessRateBonus;
		NeighborSuccessRateBonus = other.NeighborSuccessRateBonus;
		NeighborSuccessRateBonusWhenActive = other.NeighborSuccessRateBonusWhenActive;
		SucceedNeighborSuccessRateBonus = other.SucceedNeighborSuccessRateBonus;
		BreakCountAboveHalfBonus = other.BreakCountAboveHalfBonus;
		BreakCountBelowHalfBonus = other.BreakCountBelowHalfBonus;
		NextSuccessRateBonus = other.NextSuccessRateBonus;
		NextStepOffset = other.NextStepOffset;
		NextStepCanJumpToSame = other.NextStepCanJumpToSame;
		NeighborFailedToCanSelect = other.NeighborFailedToCanSelect;
		RandomNeighborNormalConvertToSameGrid = other.RandomNeighborNormalConvertToSameGrid;
		AllNeighborNormalConvertToSpecialGrid = other.AllNeighborNormalConvertToSpecialGrid;
		AllNeighborSpecialConvertToNormalGrid = other.AllNeighborSpecialConvertToNormalGrid;
		ClearNeighborMaxPower = other.ClearNeighborMaxPower;
		IgnoreEffectAddMaxPower = other.IgnoreEffectAddMaxPower;
		NeighborAddMaxPowerWhenActive = other.NeighborAddMaxPowerWhenActive;
		SucceedNeighborAddMaxPower = other.SucceedNeighborAddMaxPower;
		TransferPowerAndConvertToFailedNeighborCount = other.TransferPowerAndConvertToFailedNeighborCount;
		HealthCost = other.HealthCost;
		WeightOnGenerate = other.WeightOnGenerate;
		WeightOnConvert = other.WeightOnConvert;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override SkillBreakGridTypeItem Duplicate(int templateId)
	{
		return new SkillBreakGridTypeItem((sbyte)templateId, this);
	}
}

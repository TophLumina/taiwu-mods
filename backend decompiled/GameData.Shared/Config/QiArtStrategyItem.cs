using System;
using Config.Common;

namespace Config;

[Serializable]
public class QiArtStrategyItem : ConfigItem<QiArtStrategyItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly string Name;

	public readonly string Desc;

	public readonly string Icon;

	public readonly string Dialog;

	public readonly short ExtractGroup;

	public readonly short ExtractWeight;

	public readonly short ConcentrationCost;

	public readonly short Duration;

	public readonly short NeiliCost;

	public readonly short ActiveGroup;

	public readonly short AnchorFiveElements;

	public readonly short MinGainNeili;

	public readonly short MaxGainNeili;

	public readonly short MinGainFiveElements;

	public readonly short MaxGainFiveElements;

	public readonly short MinGainNeiliAllocation;

	public readonly short MaxGainNeiliAllocation;

	public readonly short MinExtraNeili;

	public readonly short MaxExtraNeili;

	public readonly short MinExtraFiveElements;

	public readonly short MaxExtraFiveElements;

	public readonly short MinExtraNeiliAllocation;

	public readonly short MaxExtraNeiliAllocation;

	public readonly sbyte TransferToFiveElements;

	public readonly sbyte FiveElementsTransferType;

	public readonly bool ClearOtherEffect;

	public QiArtStrategyItem(sbyte templateId, string name, string desc, string icon, string dialog, short extractGroup, short extractWeight, short concentrationCost, short duration, short neiliCost, short activeGroup, short anchorFiveElements, short minGainNeili, short maxGainNeili, short minGainFiveElements, short maxGainFiveElements, short minGainNeiliAllocation, short maxGainNeiliAllocation, short minExtraNeili, short maxExtraNeili, short minExtraFiveElements, short maxExtraFiveElements, short minExtraNeiliAllocation, short maxExtraNeiliAllocation, sbyte transferToFiveElements, sbyte fiveElementsTransferType, bool clearOtherEffect)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		Icon = icon;
		Dialog = dialog;
		ExtractGroup = extractGroup;
		ExtractWeight = extractWeight;
		ConcentrationCost = concentrationCost;
		Duration = duration;
		NeiliCost = neiliCost;
		ActiveGroup = activeGroup;
		AnchorFiveElements = anchorFiveElements;
		MinGainNeili = minGainNeili;
		MaxGainNeili = maxGainNeili;
		MinGainFiveElements = minGainFiveElements;
		MaxGainFiveElements = maxGainFiveElements;
		MinGainNeiliAllocation = minGainNeiliAllocation;
		MaxGainNeiliAllocation = maxGainNeiliAllocation;
		MinExtraNeili = minExtraNeili;
		MaxExtraNeili = maxExtraNeili;
		MinExtraFiveElements = minExtraFiveElements;
		MaxExtraFiveElements = maxExtraFiveElements;
		MinExtraNeiliAllocation = minExtraNeiliAllocation;
		MaxExtraNeiliAllocation = maxExtraNeiliAllocation;
		TransferToFiveElements = transferToFiveElements;
		FiveElementsTransferType = fiveElementsTransferType;
		ClearOtherEffect = clearOtherEffect;
	}

	public QiArtStrategyItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		Icon = null;
		Dialog = null;
		ExtractGroup = 0;
		ExtractWeight = 0;
		ConcentrationCost = 0;
		Duration = 0;
		NeiliCost = 0;
		ActiveGroup = -1;
		AnchorFiveElements = -1;
		MinGainNeili = 0;
		MaxGainNeili = 0;
		MinGainFiveElements = 0;
		MaxGainFiveElements = 0;
		MinGainNeiliAllocation = 0;
		MaxGainNeiliAllocation = 0;
		MinExtraNeili = 0;
		MaxExtraNeili = 0;
		MinExtraFiveElements = 0;
		MaxExtraFiveElements = 0;
		MinExtraNeiliAllocation = 0;
		MaxExtraNeiliAllocation = 0;
		TransferToFiveElements = -1;
		FiveElementsTransferType = -1;
		ClearOtherEffect = false;
	}

	public QiArtStrategyItem(sbyte templateId, QiArtStrategyItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		Icon = other.Icon;
		Dialog = other.Dialog;
		ExtractGroup = other.ExtractGroup;
		ExtractWeight = other.ExtractWeight;
		ConcentrationCost = other.ConcentrationCost;
		Duration = other.Duration;
		NeiliCost = other.NeiliCost;
		ActiveGroup = other.ActiveGroup;
		AnchorFiveElements = other.AnchorFiveElements;
		MinGainNeili = other.MinGainNeili;
		MaxGainNeili = other.MaxGainNeili;
		MinGainFiveElements = other.MinGainFiveElements;
		MaxGainFiveElements = other.MaxGainFiveElements;
		MinGainNeiliAllocation = other.MinGainNeiliAllocation;
		MaxGainNeiliAllocation = other.MaxGainNeiliAllocation;
		MinExtraNeili = other.MinExtraNeili;
		MaxExtraNeili = other.MaxExtraNeili;
		MinExtraFiveElements = other.MinExtraFiveElements;
		MaxExtraFiveElements = other.MaxExtraFiveElements;
		MinExtraNeiliAllocation = other.MinExtraNeiliAllocation;
		MaxExtraNeiliAllocation = other.MaxExtraNeiliAllocation;
		TransferToFiveElements = other.TransferToFiveElements;
		FiveElementsTransferType = other.FiveElementsTransferType;
		ClearOtherEffect = other.ClearOtherEffect;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override QiArtStrategyItem Duplicate(int templateId)
	{
		return new QiArtStrategyItem((sbyte)templateId, this);
	}
}

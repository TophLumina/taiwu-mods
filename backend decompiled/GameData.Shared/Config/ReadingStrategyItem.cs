using System;
using Config.Common;

namespace Config;

[Serializable]
public class ReadingStrategyItem : ConfigItem<ReadingStrategyItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly string Name;

	public readonly string Desc;

	public readonly string Dialog;

	public readonly short ExtractGroup;

	public readonly short ExtractWeight;

	public readonly short IntelligenceCost;

	public readonly short Duration;

	public readonly short DurabilityCost;

	public readonly sbyte MinProgressAddValue;

	public readonly sbyte MaxProgressAddValue;

	public readonly sbyte MaxCurrPageEfficiencyChange;

	public readonly sbyte MinCurrPageEfficiencyChange;

	public readonly sbyte NextPageProgressAddValue;

	public readonly sbyte FollowingPagesEfficiencyChange;

	public readonly short CurrPageIntCostChange;

	public readonly bool SkipPage;

	public readonly bool ClearPageStrategies;

	public ReadingStrategyItem(sbyte templateId, string name, string desc, string dialog, short extractGroup, short extractWeight, short intelligenceCost, short duration, short durabilityCost, sbyte minProgressAddValue, sbyte maxProgressAddValue, sbyte maxCurrPageEfficiencyChange, sbyte minCurrPageEfficiencyChange, sbyte nextPageProgressAddValue, sbyte followingPagesEfficiencyChange, short currPageIntCostChange, bool skipPage, bool clearPageStrategies)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		Dialog = dialog;
		ExtractGroup = extractGroup;
		ExtractWeight = extractWeight;
		IntelligenceCost = intelligenceCost;
		Duration = duration;
		DurabilityCost = durabilityCost;
		MinProgressAddValue = minProgressAddValue;
		MaxProgressAddValue = maxProgressAddValue;
		MaxCurrPageEfficiencyChange = maxCurrPageEfficiencyChange;
		MinCurrPageEfficiencyChange = minCurrPageEfficiencyChange;
		NextPageProgressAddValue = nextPageProgressAddValue;
		FollowingPagesEfficiencyChange = followingPagesEfficiencyChange;
		CurrPageIntCostChange = currPageIntCostChange;
		SkipPage = skipPage;
		ClearPageStrategies = clearPageStrategies;
	}

	public ReadingStrategyItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		Dialog = null;
		ExtractGroup = 0;
		ExtractWeight = 0;
		IntelligenceCost = 0;
		Duration = 0;
		DurabilityCost = 0;
		MinProgressAddValue = 0;
		MaxProgressAddValue = 0;
		MaxCurrPageEfficiencyChange = 0;
		MinCurrPageEfficiencyChange = 0;
		NextPageProgressAddValue = 0;
		FollowingPagesEfficiencyChange = 0;
		CurrPageIntCostChange = 0;
		SkipPage = false;
		ClearPageStrategies = false;
	}

	public ReadingStrategyItem(sbyte templateId, ReadingStrategyItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		Dialog = other.Dialog;
		ExtractGroup = other.ExtractGroup;
		ExtractWeight = other.ExtractWeight;
		IntelligenceCost = other.IntelligenceCost;
		Duration = other.Duration;
		DurabilityCost = other.DurabilityCost;
		MinProgressAddValue = other.MinProgressAddValue;
		MaxProgressAddValue = other.MaxProgressAddValue;
		MaxCurrPageEfficiencyChange = other.MaxCurrPageEfficiencyChange;
		MinCurrPageEfficiencyChange = other.MinCurrPageEfficiencyChange;
		NextPageProgressAddValue = other.NextPageProgressAddValue;
		FollowingPagesEfficiencyChange = other.FollowingPagesEfficiencyChange;
		CurrPageIntCostChange = other.CurrPageIntCostChange;
		SkipPage = other.SkipPage;
		ClearPageStrategies = other.ClearPageStrategies;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override ReadingStrategyItem Duplicate(int templateId)
	{
		return new ReadingStrategyItem((sbyte)templateId, this);
	}
}

using System;
using System.Collections.Generic;
using Config.Common;
using Config.ConfigCells.Character;

namespace Config;

[Serializable]
public class DemonSlayerTrialLevelItem : ConfigItem<DemonSlayerTrialLevelItem, int>
{
	public readonly int TemplateId;

	public readonly string LevelName;

	public readonly int TotalPower;

	public readonly int RestrictRandomCount;

	public readonly int RewardExp;

	public readonly List<PresetInventoryItem> RewardItems;

	public readonly List<short> RewardFeatureOptions;

	public DemonSlayerTrialLevelItem(int templateId, string levelName, int totalPower, int restrictRandomCount, int rewardExp, List<PresetInventoryItem> rewardItems, List<short> rewardFeatureOptions)
	{
		TemplateId = templateId;
		LevelName = levelName;
		TotalPower = totalPower;
		RestrictRandomCount = restrictRandomCount;
		RewardExp = rewardExp;
		RewardItems = rewardItems;
		RewardFeatureOptions = rewardFeatureOptions;
	}

	public DemonSlayerTrialLevelItem()
	{
		TemplateId = 0;
		LevelName = null;
		TotalPower = 0;
		RestrictRandomCount = 3;
		RewardExp = 0;
		RewardItems = new List<PresetInventoryItem>();
		RewardFeatureOptions = new List<short>();
	}

	public DemonSlayerTrialLevelItem(int templateId, DemonSlayerTrialLevelItem other)
	{
		TemplateId = templateId;
		LevelName = other.LevelName;
		TotalPower = other.TotalPower;
		RestrictRandomCount = other.RestrictRandomCount;
		RewardExp = other.RewardExp;
		RewardItems = other.RewardItems;
		RewardFeatureOptions = other.RewardFeatureOptions;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override DemonSlayerTrialLevelItem Duplicate(int templateId)
	{
		return new DemonSlayerTrialLevelItem(templateId, this);
	}
}

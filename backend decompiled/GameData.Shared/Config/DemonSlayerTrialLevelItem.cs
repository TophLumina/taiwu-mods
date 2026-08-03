using System;
using System.Collections.Generic;
using Config.Common;
using Config.ConfigCells.Character;

namespace Config;

[Serializable]
public class DemonSlayerTrialLevelItem : ConfigItem<DemonSlayerTrialLevelItem, int>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly int TemplateId;

	/// <summary>
	/// 关卡名
	/// </summary>
	public readonly string LevelName;

	/// <summary>
	/// 关卡强度
	/// </summary>
	public readonly int TotalPower;

	/// <summary>
	/// 重掷次数
	/// </summary>
	public readonly int RestrictRandomCount;

	/// <summary>
	/// 奖励历练
	/// </summary>
	public readonly int RewardExp;

	/// <summary>
	/// 奖励道具
	/// </summary>
	public readonly List<PresetInventoryItem> RewardItems;

	/// <summary>
	/// 可选奖励特性
	/// </summary>
	public readonly List<short> RewardFeatureOptions;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="levelName">关卡名</param>
	/// <param name="totalPower">关卡强度</param>
	/// <param name="restrictRandomCount">重掷次数</param>
	/// <param name="rewardExp">奖励历练</param>
	/// <param name="rewardItems">奖励道具</param>
	/// <param name="rewardFeatureOptions">可选奖励特性</param>
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

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
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

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
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

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override DemonSlayerTrialLevelItem Duplicate(int templateId)
	{
		return new DemonSlayerTrialLevelItem(templateId, this);
	}
}

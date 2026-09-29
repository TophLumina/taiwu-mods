using System;
using System.Collections.Generic;
using Config.Common;
using Config.ConfigCells.Character;

namespace Config;

[Serializable]
public class DemonSlayerTrialLevel : ConfigData<DemonSlayerTrialLevelItem, int>
{
	public static DemonSlayerTrialLevel Instance = new DemonSlayerTrialLevel();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "LevelName", "RewardItems", "RewardFeatureOptions", "TemplateId", "TotalPower", "RewardExp" };

	internal override int ToInt(int value)
	{
		return value;
	}

	internal override int ToTemplateId(int value)
	{
		return value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new DemonSlayerTrialLevelItem(0, LocalStringManager.GetConfig("DemonSlayerTrialLevel_language", "LevelName_0"), 4, 3, 18000, new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Misc", 15, 1, 100)
		}, new List<short>
		{
			533, 536, 539, 542, 545, 548, 551, 554, 557, 560,
			563, 566, 569, 572
		}));
		_dataArray.Add(new DemonSlayerTrialLevelItem(1, LocalStringManager.GetConfig("DemonSlayerTrialLevel_language", "LevelName_1"), 5, 3, 27000, new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Misc", 15, 2, 100)
		}, new List<short>
		{
			533, 536, 539, 542, 545, 548, 551, 554, 557, 560,
			563, 566, 569, 572
		}));
		_dataArray.Add(new DemonSlayerTrialLevelItem(2, LocalStringManager.GetConfig("DemonSlayerTrialLevel_language", "LevelName_2"), 6, 3, 36000, new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Misc", 15, 3, 100)
		}, new List<short>
		{
			533, 536, 539, 542, 545, 548, 551, 554, 557, 560,
			563, 566, 569, 572
		}));
		_dataArray.Add(new DemonSlayerTrialLevelItem(3, LocalStringManager.GetConfig("DemonSlayerTrialLevel_language", "LevelName_3"), 7, 3, 45000, new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Misc", 16, 1, 100)
		}, new List<short>
		{
			534, 537, 540, 543, 546, 549, 552, 555, 558, 561,
			564, 567, 570, 573
		}));
		_dataArray.Add(new DemonSlayerTrialLevelItem(4, LocalStringManager.GetConfig("DemonSlayerTrialLevel_language", "LevelName_4"), 8, 3, 54000, new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Misc", 16, 2, 100)
		}, new List<short>
		{
			534, 537, 540, 543, 546, 549, 552, 555, 558, 561,
			564, 567, 570, 573
		}));
		_dataArray.Add(new DemonSlayerTrialLevelItem(5, LocalStringManager.GetConfig("DemonSlayerTrialLevel_language", "LevelName_5"), 9, 3, 63000, new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Misc", 16, 3, 100)
		}, new List<short>
		{
			534, 537, 540, 543, 546, 549, 552, 555, 558, 561,
			564, 567, 570, 573
		}));
		_dataArray.Add(new DemonSlayerTrialLevelItem(6, LocalStringManager.GetConfig("DemonSlayerTrialLevel_language", "LevelName_6"), 10, 3, 72000, new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Misc", 17, 1, 100)
		}, new List<short>
		{
			535, 538, 541, 544, 547, 550, 553, 556, 559, 562,
			565, 568, 571, 574
		}));
		_dataArray.Add(new DemonSlayerTrialLevelItem(7, LocalStringManager.GetConfig("DemonSlayerTrialLevel_language", "LevelName_7"), 11, 3, 81000, new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Misc", 17, 2, 100)
		}, new List<short>
		{
			535, 538, 541, 544, 547, 550, 553, 556, 559, 562,
			565, 568, 571, 574
		}));
		_dataArray.Add(new DemonSlayerTrialLevelItem(8, LocalStringManager.GetConfig("DemonSlayerTrialLevel_language", "LevelName_8"), 12, 3, 90000, new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Misc", 17, 3, 100)
		}, new List<short>
		{
			535, 538, 541, 544, 547, 550, 553, 556, 559, 562,
			565, 568, 571, 574
		}));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<DemonSlayerTrialLevelItem>(9);
		CreateItems0();
	}
}

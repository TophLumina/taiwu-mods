using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class DemonSlayerTrial : ConfigData<DemonSlayerTrialItem, int>
{
	public static DemonSlayerTrial Instance = new DemonSlayerTrial();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Desc", "SpecialDesc", "CharacterId", "FirstTimeRewards", "FirstTimeRewardLuohan", "TemplateId" };

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
		_dataArray.Add(new DemonSlayerTrialItem(0, LocalStringManager.GetConfig("DemonSlayerTrial_language", "Desc_0"), LocalStringManager.GetConfig("DemonSlayerTrial_language", "SpecialDesc_0"), 538, 250, 0));
		_dataArray.Add(new DemonSlayerTrialItem(1, LocalStringManager.GetConfig("DemonSlayerTrial_language", "Desc_1"), LocalStringManager.GetConfig("DemonSlayerTrial_language", "SpecialDesc_1"), 539, 251, 1));
		_dataArray.Add(new DemonSlayerTrialItem(2, LocalStringManager.GetConfig("DemonSlayerTrial_language", "Desc_2"), LocalStringManager.GetConfig("DemonSlayerTrial_language", "SpecialDesc_2"), 540, 252, 2));
		_dataArray.Add(new DemonSlayerTrialItem(3, LocalStringManager.GetConfig("DemonSlayerTrial_language", "Desc_3"), LocalStringManager.GetConfig("DemonSlayerTrial_language", "SpecialDesc_3"), 541, 253, 3));
		_dataArray.Add(new DemonSlayerTrialItem(4, LocalStringManager.GetConfig("DemonSlayerTrial_language", "Desc_4"), LocalStringManager.GetConfig("DemonSlayerTrial_language", "SpecialDesc_4"), 542, 254, 4));
		_dataArray.Add(new DemonSlayerTrialItem(5, LocalStringManager.GetConfig("DemonSlayerTrial_language", "Desc_5"), LocalStringManager.GetConfig("DemonSlayerTrial_language", "SpecialDesc_5"), 543, 255, 5));
		_dataArray.Add(new DemonSlayerTrialItem(6, LocalStringManager.GetConfig("DemonSlayerTrial_language", "Desc_6"), LocalStringManager.GetConfig("DemonSlayerTrial_language", "SpecialDesc_6"), 544, 256, 6));
		_dataArray.Add(new DemonSlayerTrialItem(7, LocalStringManager.GetConfig("DemonSlayerTrial_language", "Desc_7"), LocalStringManager.GetConfig("DemonSlayerTrial_language", "SpecialDesc_7"), 545, 257, 7));
		_dataArray.Add(new DemonSlayerTrialItem(8, LocalStringManager.GetConfig("DemonSlayerTrial_language", "Desc_8"), LocalStringManager.GetConfig("DemonSlayerTrial_language", "SpecialDesc_8"), 546, 258, 8));
		_dataArray.Add(new DemonSlayerTrialItem(9, LocalStringManager.GetConfig("DemonSlayerTrial_language", "Desc_9"), LocalStringManager.GetConfig("DemonSlayerTrial_language", "SpecialDesc_9"), 547, 259, 9));
		_dataArray.Add(new DemonSlayerTrialItem(10, LocalStringManager.GetConfig("DemonSlayerTrial_language", "Desc_10"), LocalStringManager.GetConfig("DemonSlayerTrial_language", "SpecialDesc_10"), 548, 260, 10));
		_dataArray.Add(new DemonSlayerTrialItem(11, LocalStringManager.GetConfig("DemonSlayerTrial_language", "Desc_11"), LocalStringManager.GetConfig("DemonSlayerTrial_language", "SpecialDesc_11"), 549, 261, 11));
		_dataArray.Add(new DemonSlayerTrialItem(12, LocalStringManager.GetConfig("DemonSlayerTrial_language", "Desc_12"), LocalStringManager.GetConfig("DemonSlayerTrial_language", "SpecialDesc_12"), 550, 262, 12));
		_dataArray.Add(new DemonSlayerTrialItem(13, LocalStringManager.GetConfig("DemonSlayerTrial_language", "Desc_13"), LocalStringManager.GetConfig("DemonSlayerTrial_language", "SpecialDesc_13"), 551, 263, 13));
		_dataArray.Add(new DemonSlayerTrialItem(14, LocalStringManager.GetConfig("DemonSlayerTrial_language", "Desc_14"), LocalStringManager.GetConfig("DemonSlayerTrial_language", "SpecialDesc_14"), 552, 264, 14));
		_dataArray.Add(new DemonSlayerTrialItem(15, LocalStringManager.GetConfig("DemonSlayerTrial_language", "Desc_15"), LocalStringManager.GetConfig("DemonSlayerTrial_language", "SpecialDesc_15"), 553, 265, 15));
		_dataArray.Add(new DemonSlayerTrialItem(16, LocalStringManager.GetConfig("DemonSlayerTrial_language", "Desc_16"), LocalStringManager.GetConfig("DemonSlayerTrial_language", "SpecialDesc_16"), 554, 266, 16));
		_dataArray.Add(new DemonSlayerTrialItem(17, LocalStringManager.GetConfig("DemonSlayerTrial_language", "Desc_17"), LocalStringManager.GetConfig("DemonSlayerTrial_language", "SpecialDesc_17"), 555, 267, 17));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<DemonSlayerTrialItem>(18);
		CreateItems0();
	}
}

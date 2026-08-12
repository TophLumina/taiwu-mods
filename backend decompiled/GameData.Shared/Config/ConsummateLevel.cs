using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class ConsummateLevel : ConfigData<ConsummateLevelItem, sbyte>
{
	/// <summary>
	/// 配置表实例
	/// </summary>
	public static ConsummateLevel Instance = new ConsummateLevel();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "Desc", "TemplateId", "Grade", "MaxNeiliAllocation" };

	internal override int ToInt(sbyte value)
	{
		return value;
	}

	internal override sbyte ToTemplateId(int value)
	{
		return (sbyte)value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new ConsummateLevelItem(0, LocalStringManager.GetConfig("ConsummateLevel_language", "Name_0"), LocalStringManager.GetConfig("ConsummateLevel_language", "Desc_0"), 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0));
		_dataArray.Add(new ConsummateLevelItem(1, LocalStringManager.GetConfig("ConsummateLevel_language", "Name_1"), LocalStringManager.GetConfig("ConsummateLevel_language", "Desc_1"), 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0));
		_dataArray.Add(new ConsummateLevelItem(2, LocalStringManager.GetConfig("ConsummateLevel_language", "Name_2"), LocalStringManager.GetConfig("ConsummateLevel_language", "Desc_2"), 0, 80, 0, 0, 0, 0, 100, 0, 0, 0, 0));
		_dataArray.Add(new ConsummateLevelItem(3, LocalStringManager.GetConfig("ConsummateLevel_language", "Name_3"), LocalStringManager.GetConfig("ConsummateLevel_language", "Desc_3"), 0, 100, 0, 0, 0, 0, 100, 0, 0, 0, 0));
		_dataArray.Add(new ConsummateLevelItem(4, LocalStringManager.GetConfig("ConsummateLevel_language", "Name_4"), LocalStringManager.GetConfig("ConsummateLevel_language", "Desc_4"), 1, 120, 33, -33, 10, 10, 100, 0, 0, 0, 0));
		_dataArray.Add(new ConsummateLevelItem(5, LocalStringManager.GetConfig("ConsummateLevel_language", "Name_5"), LocalStringManager.GetConfig("ConsummateLevel_language", "Desc_5"), 1, 140, 33, -33, 10, 10, 100, 0, 0, 0, 0));
		_dataArray.Add(new ConsummateLevelItem(6, LocalStringManager.GetConfig("ConsummateLevel_language", "Name_6"), LocalStringManager.GetConfig("ConsummateLevel_language", "Desc_6"), 2, 160, 33, -33, 10, 10, 100, 0, 100, 0, 0));
		_dataArray.Add(new ConsummateLevelItem(7, LocalStringManager.GetConfig("ConsummateLevel_language", "Name_7"), LocalStringManager.GetConfig("ConsummateLevel_language", "Desc_7"), 2, 180, 33, -33, 10, 10, 100, 0, 100, 0, 0));
		_dataArray.Add(new ConsummateLevelItem(8, LocalStringManager.GetConfig("ConsummateLevel_language", "Name_8"), LocalStringManager.GetConfig("ConsummateLevel_language", "Desc_8"), 3, 200, 33, -33, 10, 10, 100, 0, 100, 25, 0));
		_dataArray.Add(new ConsummateLevelItem(9, LocalStringManager.GetConfig("ConsummateLevel_language", "Name_9"), LocalStringManager.GetConfig("ConsummateLevel_language", "Desc_9"), 3, 220, 33, -33, 10, 10, 100, 0, 100, 25, 0));
		_dataArray.Add(new ConsummateLevelItem(10, LocalStringManager.GetConfig("ConsummateLevel_language", "Name_10"), LocalStringManager.GetConfig("ConsummateLevel_language", "Desc_10"), 4, 240, 66, -66, 25, 25, 100, 0, 100, 25, 0));
		_dataArray.Add(new ConsummateLevelItem(11, LocalStringManager.GetConfig("ConsummateLevel_language", "Name_11"), LocalStringManager.GetConfig("ConsummateLevel_language", "Desc_11"), 4, 260, 66, -66, 25, 25, 100, 0, 100, 25, 0));
		_dataArray.Add(new ConsummateLevelItem(12, LocalStringManager.GetConfig("ConsummateLevel_language", "Name_12"), LocalStringManager.GetConfig("ConsummateLevel_language", "Desc_12"), 5, 280, 66, -66, 25, 25, 100, 100, 100, 25, 0));
		_dataArray.Add(new ConsummateLevelItem(13, LocalStringManager.GetConfig("ConsummateLevel_language", "Name_13"), LocalStringManager.GetConfig("ConsummateLevel_language", "Desc_13"), 5, 300, 66, -66, 25, 25, 100, 100, 100, 25, 0));
		_dataArray.Add(new ConsummateLevelItem(14, LocalStringManager.GetConfig("ConsummateLevel_language", "Name_14"), LocalStringManager.GetConfig("ConsummateLevel_language", "Desc_14"), 6, 320, 66, -66, 25, 25, 100, 100, 100, 25, 6));
		_dataArray.Add(new ConsummateLevelItem(15, LocalStringManager.GetConfig("ConsummateLevel_language", "Name_15"), LocalStringManager.GetConfig("ConsummateLevel_language", "Desc_15"), 6, 340, 66, -66, 25, 25, 100, 100, 100, 25, 6));
		_dataArray.Add(new ConsummateLevelItem(16, LocalStringManager.GetConfig("ConsummateLevel_language", "Name_16"), LocalStringManager.GetConfig("ConsummateLevel_language", "Desc_16"), 7, 360, 99, -99, 45, 45, 100, 100, 100, 25, 6));
		_dataArray.Add(new ConsummateLevelItem(17, LocalStringManager.GetConfig("ConsummateLevel_language", "Name_17"), LocalStringManager.GetConfig("ConsummateLevel_language", "Desc_17"), 7, 380, 99, -99, 45, 45, 100, 100, 100, 25, 6));
		_dataArray.Add(new ConsummateLevelItem(18, LocalStringManager.GetConfig("ConsummateLevel_language", "Name_18"), LocalStringManager.GetConfig("ConsummateLevel_language", "Desc_18"), 8, 400, 99, -99, 70, 70, 100, 100, 100, 25, 6));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<ConsummateLevelItem>(19);
		CreateItems0();
	}
}

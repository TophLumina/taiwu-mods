using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class NeiliAllocationStatus : ConfigData<NeiliAllocationStatusItem, sbyte>
{
	/// <summary>
	/// 配置表实例
	/// </summary>
	public static NeiliAllocationStatus Instance = new NeiliAllocationStatus();

	private readonly HashSet<string> RequiredFields = new HashSet<string>
	{
		"Name", "Desc", "TemplateId", "Type", "MinThreshold", "MaxThreshold", "GoneMadInjuryRate", "GoneMadInjuryBonus", "PowerAddPercent", "CostNeiliAllocation",
		"AddNeiliAllocation", "MarkCount"
	};

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
		_dataArray.Add(new NeiliAllocationStatusItem(0, ENeiliAllocationStatusType.Scatter, LocalStringManager.GetConfig("NeiliAllocationStatus_language", "Name_0"), new string[3]
		{
			LocalStringManager.GetConfig("NeiliAllocationStatus_language", "Desc_0_0"),
			LocalStringManager.GetConfig("NeiliAllocationStatus_language", "Desc_0_1"),
			LocalStringManager.GetConfig("NeiliAllocationStatus_language", "Desc_0_2")
		}, 0, 39, allowEqualsMin: true, 100, -50, -20, -30, 60, -2));
		_dataArray.Add(new NeiliAllocationStatusItem(1, ENeiliAllocationStatusType.Leak, LocalStringManager.GetConfig("NeiliAllocationStatus_language", "Name_1"), new string[3]
		{
			LocalStringManager.GetConfig("NeiliAllocationStatus_language", "Desc_1_0"),
			LocalStringManager.GetConfig("NeiliAllocationStatus_language", "Desc_1_1"),
			LocalStringManager.GetConfig("NeiliAllocationStatus_language", "Desc_1_2")
		}, 39, 79, allowEqualsMin: false, 50, -25, -20, -15, 30, -1));
		_dataArray.Add(new NeiliAllocationStatusItem(2, ENeiliAllocationStatusType.None, LocalStringManager.GetConfig("NeiliAllocationStatus_language", "Name_2"), new string[3]
		{
			LocalStringManager.GetConfig("NeiliAllocationStatus_language", "Desc_2_0"),
			LocalStringManager.GetConfig("NeiliAllocationStatus_language", "Desc_2_1"),
			LocalStringManager.GetConfig("NeiliAllocationStatus_language", "Desc_2_2")
		}, 79, 120, allowEqualsMin: false, 0, 0, 0, 0, 0, 0));
		_dataArray.Add(new NeiliAllocationStatusItem(3, ENeiliAllocationStatusType.Full, LocalStringManager.GetConfig("NeiliAllocationStatus_language", "Name_3"), new string[3]
		{
			LocalStringManager.GetConfig("NeiliAllocationStatus_language", "Desc_3_0"),
			LocalStringManager.GetConfig("NeiliAllocationStatus_language", "Desc_3_1"),
			LocalStringManager.GetConfig("NeiliAllocationStatus_language", "Desc_3_2")
		}, 120, 210, allowEqualsMin: false, -25, 50, 20, 30, -15, 0));
		_dataArray.Add(new NeiliAllocationStatusItem(4, ENeiliAllocationStatusType.Bulge, LocalStringManager.GetConfig("NeiliAllocationStatus_language", "Name_4"), new string[3]
		{
			LocalStringManager.GetConfig("NeiliAllocationStatus_language", "Desc_4_0"),
			LocalStringManager.GetConfig("NeiliAllocationStatus_language", "Desc_4_1"),
			LocalStringManager.GetConfig("NeiliAllocationStatus_language", "Desc_4_2")
		}, 210, 300, allowEqualsMin: false, -50, 100, 20, 60, -30, 1));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<NeiliAllocationStatusItem>(5);
		CreateItems0();
	}
}

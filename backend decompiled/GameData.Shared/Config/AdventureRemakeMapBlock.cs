using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class AdventureRemakeMapBlock : ConfigData<AdventureRemakeMapBlockItem, short>
{
	/// <summary>
	/// 配置表实例
	/// </summary>
	public static AdventureRemakeMapBlock Instance = new AdventureRemakeMapBlock();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "Desc", "TemplateId", "CircleCount" };

	internal override int ToInt(short value)
	{
		return value;
	}

	internal override short ToTemplateId(int value)
	{
		return (short)value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new AdventureRemakeMapBlockItem(0, LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Name_0"), LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Desc_0"), 5, new float[10] { 0f, 0.1f, 0.1f, 0.2f, 0.3f, 0.4f, 0.4f, 0.6f, 0.4f, 0.6f }, 20, new float[2] { 0.5f, 0.5f }));
		_dataArray.Add(new AdventureRemakeMapBlockItem(1, LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Name_1"), LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Desc_1"), 5, new float[10] { 0.4f, 0.45f, 0.4f, 0.45f, 0.4f, 0.45f, 0.4f, 0.45f, 0.4f, 0.45f }, 60, new float[2] { 0.5f, 0.5f }));
		_dataArray.Add(new AdventureRemakeMapBlockItem(2, LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Name_2"), LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Desc_2"), 5, new float[10] { 0.45f, 0.45f, 0.45f, 0.45f, 0.35f, 0.35f, 0.35f, 0.35f, 0.3f, 0.3f }, 10, new float[2] { 0.45f, 0.45f }));
		_dataArray.Add(new AdventureRemakeMapBlockItem(3, LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Name_3"), LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Desc_3"), 5, new float[10] { 0.25f, 0.45f, 0.25f, 0.45f, 0.15f, 0.35f, 0.15f, 0.35f, 0.15f, 0.35f }, 25, new float[2] { 0.3f, 0.3f }));
		_dataArray.Add(new AdventureRemakeMapBlockItem(4, LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Name_4"), LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Desc_4"), 5, new float[10] { 0.4f, 0.45f, 0.4f, 0.45f, 0.4f, 0.45f, 0.4f, 0.45f, 0.4f, 0.45f }, 60, new float[2] { 0.5f, 0.5f }));
		_dataArray.Add(new AdventureRemakeMapBlockItem(5, LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Name_5"), LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Desc_5"), 5, new float[10] { 0.4f, 0.45f, 0.4f, 0.45f, 0.4f, 0.45f, 0.4f, 0.45f, 0.4f, 0.45f }, 60, new float[2] { 0.5f, 0.5f }));
		_dataArray.Add(new AdventureRemakeMapBlockItem(6, LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Name_6"), LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Desc_6"), 5, new float[10] { 0.4f, 0.45f, 0.3f, 0.4f, 0.2f, 0.3f, 0.1f, 0.2f, 0f, 0.2f }, 10, new float[2] { 0.3f, 0.3f }));
		_dataArray.Add(new AdventureRemakeMapBlockItem(7, LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Name_7"), LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Desc_7"), 5, new float[10] { 0.45f, 0.5f, 0.45f, 0.5f, 0.2f, 0.25f, 0.2f, 0.25f, 0f, 0.05f }, 0, new float[2] { 0.5f, 0.5f }));
		_dataArray.Add(new AdventureRemakeMapBlockItem(8, LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Name_8"), LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Desc_8"), 5, new float[10] { 0.45f, 0.5f, 0.45f, 0.5f, 0.2f, 0.25f, 0.2f, 0.25f, 0f, 0.05f }, 0, new float[2] { 0.5f, 0.5f }));
		_dataArray.Add(new AdventureRemakeMapBlockItem(9, LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Name_9"), LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Desc_9"), 5, new float[10] { 0f, 0.1f, 0.1f, 0.2f, 0.3f, 0.4f, 0.4f, 0.6f, 0.4f, 0.6f }, 20, new float[2] { 0.5f, 0.5f }));
		_dataArray.Add(new AdventureRemakeMapBlockItem(10, LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Name_10"), LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Desc_10"), 5, new float[10] { 0.1f, 0.2f, 0.1f, 0.2f, 0.1f, 0.2f, 0.1f, 0.2f, 0.1f, 0.2f }, 30, new float[2] { 0.45f, 0.45f }));
		_dataArray.Add(new AdventureRemakeMapBlockItem(11, LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Name_11"), LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Desc_11"), 5, new float[10] { 0.1f, 0.2f, 0.1f, 0.2f, 0.1f, 0.2f, 0.1f, 0.2f, 0.1f, 0.2f }, 30, new float[2] { 0.45f, 0.45f }));
		_dataArray.Add(new AdventureRemakeMapBlockItem(12, LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Name_12"), LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Desc_12"), 5, new float[10] { 0.43f, 0.45f, 0.43f, 0.45f, 0.43f, 0.45f, 0.43f, 0.45f, 0.43f, 0.45f }, 60, new float[2] { 0.5f, 0.5f }));
		_dataArray.Add(new AdventureRemakeMapBlockItem(13, LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Name_13"), LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Desc_13"), 5, new float[10] { 0.43f, 0.45f, 0.43f, 0.45f, 0.43f, 0.45f, 0.43f, 0.45f, 0.43f, 0.45f }, 60, new float[2] { 0.5f, 0.5f }));
		_dataArray.Add(new AdventureRemakeMapBlockItem(14, LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Name_14"), LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Desc_14"), 5, new float[10] { 0.1f, 0.2f, 0.1f, 0.2f, 0.1f, 0.2f, 0.1f, 0.2f, 0.1f, 0.2f }, 30, new float[2] { 0.45f, 0.45f }));
		_dataArray.Add(new AdventureRemakeMapBlockItem(15, LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Name_15"), LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Desc_15"), 5, new float[10] { 0.1f, 0.2f, 0.1f, 0.2f, 0.1f, 0.2f, 0.1f, 0.2f, 0.1f, 0.2f }, 30, new float[2] { 0.45f, 0.45f }));
		_dataArray.Add(new AdventureRemakeMapBlockItem(16, LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Name_16"), LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Desc_16"), 5, new float[10] { 0f, 0.1f, 0.1f, 0.2f, 0.3f, 0.4f, 0.4f, 0.47f, 0.4f, 0.47f }, 20, new float[2] { 0.5f, 0.5f }));
		_dataArray.Add(new AdventureRemakeMapBlockItem(17, LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Name_17"), LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Desc_17"), 5, new float[10] { 0f, 0.1f, 0.1f, 0.2f, 0.3f, 0.4f, 0.4f, 0.6f, 0.4f, 0.6f }, 20, new float[2] { 0.5f, 0.5f }));
		_dataArray.Add(new AdventureRemakeMapBlockItem(18, LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Name_18"), LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Desc_18"), 5, new float[10] { 0.45f, 0.45f, 0.45f, 0.45f, 0.45f, 0.45f, 0.45f, 0.45f, 0.45f, 0.45f }, 90, new float[2] { 0.47f, 0.5f }));
		_dataArray.Add(new AdventureRemakeMapBlockItem(19, LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Name_19"), LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Desc_19"), 5, new float[10] { 0.4f, 0.43f, 0.4f, 0.43f, 0.4f, 0.43f, 0.4f, 0.43f, 0.4f, 0.43f }, 60, new float[2] { 0.47f, 0.5f }));
		_dataArray.Add(new AdventureRemakeMapBlockItem(20, LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Name_20"), LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Desc_20"), 5, new float[10] { 0.2f, 0.22f, 0.2f, 0.22f, 0.2f, 0.22f, 0.2f, 0.22f, 0.2f, 0.22f }, 35, new float[2] { 0.3f, 0.3f }));
		_dataArray.Add(new AdventureRemakeMapBlockItem(21, LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Name_21"), LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Desc_21"), 5, new float[10] { 0.35f, 0.39f, 0.35f, 0.39f, 0.35f, 0.39f, 0.45f, 0.49f, 0.45f, 0.49f }, 15, new float[2] { 0.3f, 0.3f }));
		_dataArray.Add(new AdventureRemakeMapBlockItem(22, LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Name_22"), LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Desc_22"), 5, new float[10] { 0.5f, 0.5f, 0.5f, 0.5f, 0.4f, 0.4f, 0.4f, 0.4f, 0.3f, 0.3f }, 10, new float[2] { 0.45f, 0.45f }));
		_dataArray.Add(new AdventureRemakeMapBlockItem(23, LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Name_23"), LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Desc_23"), 5, new float[10] { 0f, 0.1f, 0.1f, 0.2f, 0.3f, 0.4f, 0.4f, 0.5f, 0.4f, 0.5f }, 20, new float[2] { 0.5f, 0.5f }));
		_dataArray.Add(new AdventureRemakeMapBlockItem(24, LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Name_24"), LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Desc_24"), 5, new float[10] { 0.43f, 0.45f, 0.43f, 0.45f, 0.43f, 0.45f, 0.43f, 0.45f, 0.43f, 0.45f }, 60, new float[2] { 0.5f, 0.5f }));
		_dataArray.Add(new AdventureRemakeMapBlockItem(25, LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Name_25"), LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Desc_25"), 5, new float[10] { 0.25f, 0.5f, 0.3f, 0.4f, 0.25f, 0.45f, 0.3f, 0.4f, 0.25f, 0.45f }, 0, new float[2] { 0.5f, 0.5f }));
		_dataArray.Add(new AdventureRemakeMapBlockItem(26, LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Name_26"), LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Desc_26"), 5, new float[10] { 0.1f, 0.14f, 0.1f, 0.14f, 0.1f, 0.14f, 0.1f, 0.14f, 0.1f, 0.14f }, 40, new float[2] { 0.05f, 0.05f }));
		_dataArray.Add(new AdventureRemakeMapBlockItem(27, LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Name_27"), LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Desc_27"), 5, new float[10] { 0.45f, 0.45f, 0.45f, 0.45f, 0.45f, 0.45f, 0.45f, 0.45f, 0.45f, 0.45f }, 90, new float[2] { 0.47f, 0.5f }));
		_dataArray.Add(new AdventureRemakeMapBlockItem(28, LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Name_28"), LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Desc_28"), 5, new float[10] { 0.1f, 0.2f, 0.1f, 0.2f, 0.1f, 0.2f, 0.1f, 0.2f, 0.1f, 0.2f }, 30, new float[2] { 0.45f, 0.45f }));
		_dataArray.Add(new AdventureRemakeMapBlockItem(29, LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Name_29"), LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Desc_29"), 5, new float[10] { 0.1f, 0.14f, 0.1f, 0.14f, 0.1f, 0.14f, 0.1f, 0.14f, 0.1f, 0.14f }, 40, new float[2] { 0.05f, 0.05f }));
		_dataArray.Add(new AdventureRemakeMapBlockItem(30, LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Name_30"), LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Desc_30"), 5, new float[10] { 0.45f, 0.5f, 0.45f, 0.5f, 0.2f, 0.25f, 0.2f, 0.25f, 0f, 0.05f }, 0, new float[2] { 0.5f, 0.5f }));
		_dataArray.Add(new AdventureRemakeMapBlockItem(31, LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Name_31"), LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Desc_31"), 5, new float[10] { 0.45f, 0.5f, 0.45f, 0.5f, 0.2f, 0.25f, 0.2f, 0.25f, 0f, 0.05f }, 0, new float[2] { 0.5f, 0.5f }));
		_dataArray.Add(new AdventureRemakeMapBlockItem(32, LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Name_32"), LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Desc_32"), 5, new float[10] { 0f, 0.1f, 0.1f, 0.2f, 0.3f, 0.4f, 0.4f, 0.6f, 0.4f, 0.6f }, 20, new float[2] { 0.5f, 0.5f }));
		_dataArray.Add(new AdventureRemakeMapBlockItem(33, LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Name_33"), LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Desc_33"), 5, new float[10] { 0.35f, 0.39f, 0.35f, 0.39f, 0.35f, 0.39f, 0.45f, 0.49f, 0.45f, 0.49f }, 15, new float[2] { 0.3f, 0.3f }));
		_dataArray.Add(new AdventureRemakeMapBlockItem(34, LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Name_34"), LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Desc_34"), 5, new float[10] { 0.48f, 0.5f, 0.48f, 0.5f, 0.48f, 0.5f, 0.48f, 0.5f, 0.48f, 0.5f }, 60, new float[2] { 0.5f, 0.5f }));
		_dataArray.Add(new AdventureRemakeMapBlockItem(35, LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Name_35"), LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Desc_35"), 5, new float[10] { 0.25f, 0.45f, 0.25f, 0.45f, 0.15f, 0.35f, 0.15f, 0.35f, 0.15f, 0.35f }, 25, new float[2] { 0.3f, 0.3f }));
		_dataArray.Add(new AdventureRemakeMapBlockItem(36, LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Name_36"), LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Desc_36"), 5, new float[10] { 0.25f, 0.45f, 0.25f, 0.45f, 0.15f, 0.35f, 0.15f, 0.35f, 0.15f, 0.35f }, 25, new float[2] { 0.3f, 0.3f }));
		_dataArray.Add(new AdventureRemakeMapBlockItem(37, LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Name_37"), LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Desc_37"), 5, new float[10] { 0.25f, 0.45f, 0.25f, 0.45f, 0.15f, 0.35f, 0.15f, 0.35f, 0.15f, 0.35f }, 25, new float[2] { 0.3f, 0.3f }));
		_dataArray.Add(new AdventureRemakeMapBlockItem(38, LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Name_38"), LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Desc_38"), 5, new float[10] { 0.25f, 0.45f, 0.25f, 0.45f, 0.15f, 0.35f, 0.15f, 0.35f, 0.15f, 0.35f }, 25, new float[2] { 0.3f, 0.3f }));
		_dataArray.Add(new AdventureRemakeMapBlockItem(39, LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Name_39"), LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Desc_39"), 5, new float[10] { 0.25f, 0.45f, 0.25f, 0.45f, 0.15f, 0.35f, 0.15f, 0.35f, 0.15f, 0.35f }, 25, new float[2] { 0.3f, 0.3f }));
		_dataArray.Add(new AdventureRemakeMapBlockItem(40, LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Name_40"), LocalStringManager.GetConfig("AdventureRemakeMapBlock_language", "Desc_40"), 5, new float[10] { 0.25f, 0.45f, 0.25f, 0.45f, 0.15f, 0.35f, 0.15f, 0.35f, 0.15f, 0.35f }, 25, new float[2] { 0.3f, 0.3f }));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<AdventureRemakeMapBlockItem>(41);
		CreateItems0();
	}
}

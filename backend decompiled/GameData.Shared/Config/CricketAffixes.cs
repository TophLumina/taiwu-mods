using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class CricketAffixes : ConfigData<CricketAffixesItem, short>
{
	/// <summary>
	/// 配置表实例
	/// </summary>
	public static CricketAffixes Instance = new CricketAffixes();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "Desc", "TemplateId", "Weights" };

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
		_dataArray.Add(new CricketAffixesItem(0, LocalStringManager.GetConfig("CricketAffixes_language", "Name_0"), LocalStringManager.GetConfig("CricketAffixes_language", "Desc_0"), new short[12]
		{
			2, 2, 10, 2, 6, 10, 10, 0, 0, 0,
			6, 2
		}));
		_dataArray.Add(new CricketAffixesItem(1, LocalStringManager.GetConfig("CricketAffixes_language", "Name_1"), LocalStringManager.GetConfig("CricketAffixes_language", "Desc_1"), new short[12]
		{
			2, 2, 2, 10, 2, 0, 0, 6, 10, 4,
			10, 2
		}));
		_dataArray.Add(new CricketAffixesItem(2, LocalStringManager.GetConfig("CricketAffixes_language", "Name_2"), LocalStringManager.GetConfig("CricketAffixes_language", "Desc_2"), new short[12]
		{
			2, 2, 2, 2, 10, 10, 10, 1, 1, 1,
			5, 4
		}));
		_dataArray.Add(new CricketAffixesItem(3, LocalStringManager.GetConfig("CricketAffixes_language", "Name_3"), LocalStringManager.GetConfig("CricketAffixes_language", "Desc_3"), new short[12]
		{
			8, 10, 2, 6, 2, 1, 1, 2, 2, 2,
			6, 8
		}));
		_dataArray.Add(new CricketAffixesItem(4, LocalStringManager.GetConfig("CricketAffixes_language", "Name_4"), LocalStringManager.GetConfig("CricketAffixes_language", "Desc_4"), new short[12]
		{
			2, 2, 6, 4, 5, 6, 2, 1, 6, 8,
			4, 4
		}));
		_dataArray.Add(new CricketAffixesItem(5, LocalStringManager.GetConfig("CricketAffixes_language", "Name_5"), LocalStringManager.GetConfig("CricketAffixes_language", "Desc_5"), new short[12]
		{
			6, 5, 4, 4, 4, 2, 4, 6, 4, 4,
			2, 5
		}));
		_dataArray.Add(new CricketAffixesItem(6, LocalStringManager.GetConfig("CricketAffixes_language", "Name_6"), LocalStringManager.GetConfig("CricketAffixes_language", "Desc_6"), new short[12]
		{
			-2, -2, -2, -2, -2, -2, -2, -2, 10, 10,
			-2, -2
		}));
		_dataArray.Add(new CricketAffixesItem(7, LocalStringManager.GetConfig("CricketAffixes_language", "Name_7"), LocalStringManager.GetConfig("CricketAffixes_language", "Desc_7"), new short[12]
		{
			-2, -2, -2, 10, -2, -2, -2, -2, -2, -2,
			10, -2
		}));
		_dataArray.Add(new CricketAffixesItem(8, LocalStringManager.GetConfig("CricketAffixes_language", "Name_8"), LocalStringManager.GetConfig("CricketAffixes_language", "Desc_8"), new short[12]
		{
			-2, -2, 10, -2, -2, -2, -2, 10, -2, -2,
			-2, -2
		}));
		_dataArray.Add(new CricketAffixesItem(9, LocalStringManager.GetConfig("CricketAffixes_language", "Name_9"), LocalStringManager.GetConfig("CricketAffixes_language", "Desc_9"), new short[12]
		{
			-2, -2, 5, 5, 5, -2, -2, -2, -2, -2,
			-2, 1
		}));
		_dataArray.Add(new CricketAffixesItem(10, LocalStringManager.GetConfig("CricketAffixes_language", "Name_10"), LocalStringManager.GetConfig("CricketAffixes_language", "Desc_10"), new short[12]
		{
			-2, -2, -2, -2, 10, -2, 10, -2, -2, -2,
			-2, -2
		}));
		_dataArray.Add(new CricketAffixesItem(11, LocalStringManager.GetConfig("CricketAffixes_language", "Name_11"), LocalStringManager.GetConfig("CricketAffixes_language", "Desc_11"), new short[12]
		{
			-2, -2, -2, -2, 10, 10, -2, -2, -2, -2,
			-2, -2
		}));
		_dataArray.Add(new CricketAffixesItem(12, LocalStringManager.GetConfig("CricketAffixes_language", "Name_12"), LocalStringManager.GetConfig("CricketAffixes_language", "Desc_12"), new short[12]
		{
			-2, -2, -2, -2, -2, 10, -2, -2, -2, -2,
			10, -2
		}));
		_dataArray.Add(new CricketAffixesItem(13, LocalStringManager.GetConfig("CricketAffixes_language", "Name_13"), LocalStringManager.GetConfig("CricketAffixes_language", "Desc_13"), new short[12]
		{
			-2, -2, 10, -2, -2, 10, -2, -2, -2, -2,
			-2, -2
		}));
		_dataArray.Add(new CricketAffixesItem(14, LocalStringManager.GetConfig("CricketAffixes_language", "Name_14"), LocalStringManager.GetConfig("CricketAffixes_language", "Desc_14"), new short[12]
		{
			-2, -2, -2, -2, -2, -2, -2, -2, 10, 10,
			-2, -2
		}));
		_dataArray.Add(new CricketAffixesItem(15, LocalStringManager.GetConfig("CricketAffixes_language", "Name_15"), LocalStringManager.GetConfig("CricketAffixes_language", "Desc_15"), new short[12]
		{
			-2, 10, -2, -2, -2, -2, -2, -2, -2, -2,
			-2, 10
		}));
		_dataArray.Add(new CricketAffixesItem(16, LocalStringManager.GetConfig("CricketAffixes_language", "Name_16"), LocalStringManager.GetConfig("CricketAffixes_language", "Desc_16"), new short[12]
		{
			10, -2, -2, -2, -2, -2, -2, -2, -2, -2,
			-2, 10
		}));
		_dataArray.Add(new CricketAffixesItem(17, LocalStringManager.GetConfig("CricketAffixes_language", "Name_17"), LocalStringManager.GetConfig("CricketAffixes_language", "Desc_17"), new short[12]
		{
			-2, -2, -2, -2, -2, 10, 10, -2, -2, -2,
			-2, -2
		}));
		_dataArray.Add(new CricketAffixesItem(18, LocalStringManager.GetConfig("CricketAffixes_language", "Name_18"), LocalStringManager.GetConfig("CricketAffixes_language", "Desc_18"), new short[12]
		{
			-2, -2, -2, -2, -2, 10, -2, 10, -2, -2,
			-2, -2
		}));
		_dataArray.Add(new CricketAffixesItem(19, LocalStringManager.GetConfig("CricketAffixes_language", "Name_19"), LocalStringManager.GetConfig("CricketAffixes_language", "Desc_19"), new short[12]
		{
			-2, -2, -2, -2, -2, -2, -2, -2, 10, -2,
			10, -2
		}));
		_dataArray.Add(new CricketAffixesItem(20, LocalStringManager.GetConfig("CricketAffixes_language", "Name_20"), LocalStringManager.GetConfig("CricketAffixes_language", "Desc_20"), new short[12]
		{
			10, 10, -2, -2, -2, -2, -2, -2, -2, -2,
			-2, -2
		}));
		_dataArray.Add(new CricketAffixesItem(21, LocalStringManager.GetConfig("CricketAffixes_language", "Name_21"), LocalStringManager.GetConfig("CricketAffixes_language", "Desc_21"), new short[12]));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<CricketAffixesItem>(22);
		CreateItems0();
	}
}

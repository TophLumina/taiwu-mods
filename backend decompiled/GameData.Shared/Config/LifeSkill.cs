using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class LifeSkill : ConfigData<LifeSkillItem, short>
{
	/// <summary>
	/// 配置表实例
	/// </summary>
	public static LifeSkill Instance = new LifeSkill();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "Desc", "Type", "SkillBookId", "ProvidedReadingStrategies", "UnlockBuildingList", "TemplateId", "UnlockInformationList" };

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
		_dataArray.Add(new LifeSkillItem(0, LocalStringManager.GetConfig("LifeSkill_language", "Name_0"), 0, LocalStringManager.GetConfig("LifeSkill_language", "Desc_0"), 0, 1, 0, new List<byte> { 0, 1 }, 8, new List<ShortList>
		{
			new ShortList(86),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 0, 1 }));
		_dataArray.Add(new LifeSkillItem(1, LocalStringManager.GetConfig("LifeSkill_language", "Name_1"), 1, LocalStringManager.GetConfig("LifeSkill_language", "Desc_1"), 0, 1, 1, new List<byte> { 0, 1 }, 12, new List<ShortList>
		{
			new ShortList(87),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 0, 1 }));
		_dataArray.Add(new LifeSkillItem(2, LocalStringManager.GetConfig("LifeSkill_language", "Name_2"), 2, LocalStringManager.GetConfig("LifeSkill_language", "Desc_2"), 0, 2, 2, new List<byte> { 0, 1 }, 16, new List<ShortList>
		{
			new ShortList(88),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 0, 1 }));
		_dataArray.Add(new LifeSkillItem(3, LocalStringManager.GetConfig("LifeSkill_language", "Name_3"), 3, LocalStringManager.GetConfig("LifeSkill_language", "Desc_3"), 0, 2, 3, new List<byte> { 0, 1 }, 20, new List<ShortList>
		{
			new ShortList(89),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 1, 0, 0, 0 }));
		_dataArray.Add(new LifeSkillItem(4, LocalStringManager.GetConfig("LifeSkill_language", "Name_4"), 4, LocalStringManager.GetConfig("LifeSkill_language", "Desc_4"), 0, 3, 4, new List<byte> { 0, 1 }, 24, new List<ShortList>
		{
			new ShortList(90),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 1, 0, 0, 0 }));
		_dataArray.Add(new LifeSkillItem(5, LocalStringManager.GetConfig("LifeSkill_language", "Name_5"), 5, LocalStringManager.GetConfig("LifeSkill_language", "Desc_5"), 0, 3, 5, new List<byte> { 0, 1 }, 28, new List<ShortList>
		{
			new ShortList(91),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 1, 0, 0, 0 }));
		_dataArray.Add(new LifeSkillItem(6, LocalStringManager.GetConfig("LifeSkill_language", "Name_6"), 6, LocalStringManager.GetConfig("LifeSkill_language", "Desc_6"), 0, 4, 6, new List<byte> { 0, 1 }, 32, new List<ShortList>
		{
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 1, 0 }));
		_dataArray.Add(new LifeSkillItem(7, LocalStringManager.GetConfig("LifeSkill_language", "Name_7"), 7, LocalStringManager.GetConfig("LifeSkill_language", "Desc_7"), 0, 4, 7, new List<byte> { 0, 1 }, 36, new List<ShortList>
		{
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 1, 0 }));
		_dataArray.Add(new LifeSkillItem(8, LocalStringManager.GetConfig("LifeSkill_language", "Name_8"), 8, LocalStringManager.GetConfig("LifeSkill_language", "Desc_8"), 0, 5, 8, new List<byte> { 0, 1 }, 40, new List<ShortList>
		{
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 1, 0 }));
		_dataArray.Add(new LifeSkillItem(9, LocalStringManager.GetConfig("LifeSkill_language", "Name_9"), 0, LocalStringManager.GetConfig("LifeSkill_language", "Desc_9"), 1, 1, 9, new List<byte> { 8, 9 }, 8, new List<ShortList>
		{
			new ShortList(93),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 0, 1 }));
		_dataArray.Add(new LifeSkillItem(10, LocalStringManager.GetConfig("LifeSkill_language", "Name_10"), 1, LocalStringManager.GetConfig("LifeSkill_language", "Desc_10"), 1, 1, 10, new List<byte> { 8, 9 }, 12, new List<ShortList>
		{
			new ShortList(94),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 0, 1 }));
		_dataArray.Add(new LifeSkillItem(11, LocalStringManager.GetConfig("LifeSkill_language", "Name_11"), 2, LocalStringManager.GetConfig("LifeSkill_language", "Desc_11"), 1, 2, 11, new List<byte> { 8, 9 }, 16, new List<ShortList>
		{
			new ShortList(95),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 0, 1 }));
		_dataArray.Add(new LifeSkillItem(12, LocalStringManager.GetConfig("LifeSkill_language", "Name_12"), 3, LocalStringManager.GetConfig("LifeSkill_language", "Desc_12"), 1, 2, 12, new List<byte> { 8, 9 }, 20, new List<ShortList>
		{
			new ShortList(96),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 1, 0, 0, 0 }));
		_dataArray.Add(new LifeSkillItem(13, LocalStringManager.GetConfig("LifeSkill_language", "Name_13"), 4, LocalStringManager.GetConfig("LifeSkill_language", "Desc_13"), 1, 3, 13, new List<byte> { 8, 9 }, 24, new List<ShortList>
		{
			new ShortList(97),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 1, 0, 0, 0 }));
		_dataArray.Add(new LifeSkillItem(14, LocalStringManager.GetConfig("LifeSkill_language", "Name_14"), 5, LocalStringManager.GetConfig("LifeSkill_language", "Desc_14"), 1, 3, 14, new List<byte> { 8, 9 }, 28, new List<ShortList>
		{
			new ShortList(98),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 1, 0, 0, 0 }));
		_dataArray.Add(new LifeSkillItem(15, LocalStringManager.GetConfig("LifeSkill_language", "Name_15"), 6, LocalStringManager.GetConfig("LifeSkill_language", "Desc_15"), 1, 4, 15, new List<byte> { 8, 9 }, 32, new List<ShortList>
		{
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 1, 0 }));
		_dataArray.Add(new LifeSkillItem(16, LocalStringManager.GetConfig("LifeSkill_language", "Name_16"), 7, LocalStringManager.GetConfig("LifeSkill_language", "Desc_16"), 1, 4, 16, new List<byte> { 8, 9 }, 36, new List<ShortList>
		{
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 1, 0 }));
		_dataArray.Add(new LifeSkillItem(17, LocalStringManager.GetConfig("LifeSkill_language", "Name_17"), 8, LocalStringManager.GetConfig("LifeSkill_language", "Desc_17"), 1, 5, 17, new List<byte> { 8, 9 }, 40, new List<ShortList>
		{
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 1, 0 }));
		_dataArray.Add(new LifeSkillItem(18, LocalStringManager.GetConfig("LifeSkill_language", "Name_18"), 0, LocalStringManager.GetConfig("LifeSkill_language", "Desc_18"), 2, 1, 18, new List<byte> { 10, 11 }, 8, new List<ShortList>
		{
			new ShortList(100),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 0, 1 }));
		_dataArray.Add(new LifeSkillItem(19, LocalStringManager.GetConfig("LifeSkill_language", "Name_19"), 1, LocalStringManager.GetConfig("LifeSkill_language", "Desc_19"), 2, 1, 19, new List<byte> { 10, 11 }, 12, new List<ShortList>
		{
			new ShortList(101),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 0, 1 }));
		_dataArray.Add(new LifeSkillItem(20, LocalStringManager.GetConfig("LifeSkill_language", "Name_20"), 2, LocalStringManager.GetConfig("LifeSkill_language", "Desc_20"), 2, 2, 20, new List<byte> { 10, 11 }, 16, new List<ShortList>
		{
			new ShortList(102),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 0, 1 }));
		_dataArray.Add(new LifeSkillItem(21, LocalStringManager.GetConfig("LifeSkill_language", "Name_21"), 3, LocalStringManager.GetConfig("LifeSkill_language", "Desc_21"), 2, 2, 21, new List<byte> { 10, 11 }, 20, new List<ShortList>
		{
			new ShortList(103),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 1, 0, 0, 0 }));
		_dataArray.Add(new LifeSkillItem(22, LocalStringManager.GetConfig("LifeSkill_language", "Name_22"), 4, LocalStringManager.GetConfig("LifeSkill_language", "Desc_22"), 2, 3, 22, new List<byte> { 10, 11 }, 24, new List<ShortList>
		{
			new ShortList(104),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 1, 0, 0, 0 }));
		_dataArray.Add(new LifeSkillItem(23, LocalStringManager.GetConfig("LifeSkill_language", "Name_23"), 5, LocalStringManager.GetConfig("LifeSkill_language", "Desc_23"), 2, 3, 23, new List<byte> { 10, 11 }, 28, new List<ShortList>
		{
			new ShortList(105),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 1, 0, 0, 0 }));
		_dataArray.Add(new LifeSkillItem(24, LocalStringManager.GetConfig("LifeSkill_language", "Name_24"), 6, LocalStringManager.GetConfig("LifeSkill_language", "Desc_24"), 2, 4, 24, new List<byte> { 10, 11 }, 32, new List<ShortList>
		{
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 1, 0 }));
		_dataArray.Add(new LifeSkillItem(25, LocalStringManager.GetConfig("LifeSkill_language", "Name_25"), 7, LocalStringManager.GetConfig("LifeSkill_language", "Desc_25"), 2, 4, 25, new List<byte> { 10, 11 }, 36, new List<ShortList>
		{
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 1, 0 }));
		_dataArray.Add(new LifeSkillItem(26, LocalStringManager.GetConfig("LifeSkill_language", "Name_26"), 8, LocalStringManager.GetConfig("LifeSkill_language", "Desc_26"), 2, 5, 26, new List<byte> { 10, 11 }, 40, new List<ShortList>
		{
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 1, 0 }));
		_dataArray.Add(new LifeSkillItem(27, LocalStringManager.GetConfig("LifeSkill_language", "Name_27"), 0, LocalStringManager.GetConfig("LifeSkill_language", "Desc_27"), 3, 1, 27, new List<byte> { 4, 5 }, 8, new List<ShortList>
		{
			new ShortList(107),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 0, 1 }));
		_dataArray.Add(new LifeSkillItem(28, LocalStringManager.GetConfig("LifeSkill_language", "Name_28"), 1, LocalStringManager.GetConfig("LifeSkill_language", "Desc_28"), 3, 1, 28, new List<byte> { 4, 5 }, 12, new List<ShortList>
		{
			new ShortList(108),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 0, 1 }));
		_dataArray.Add(new LifeSkillItem(29, LocalStringManager.GetConfig("LifeSkill_language", "Name_29"), 2, LocalStringManager.GetConfig("LifeSkill_language", "Desc_29"), 3, 2, 29, new List<byte> { 4, 5 }, 16, new List<ShortList>
		{
			new ShortList(109),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 0, 1 }));
		_dataArray.Add(new LifeSkillItem(30, LocalStringManager.GetConfig("LifeSkill_language", "Name_30"), 3, LocalStringManager.GetConfig("LifeSkill_language", "Desc_30"), 3, 2, 30, new List<byte> { 4, 5 }, 20, new List<ShortList>
		{
			new ShortList(110),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 1, 0, 0, 0 }));
		_dataArray.Add(new LifeSkillItem(31, LocalStringManager.GetConfig("LifeSkill_language", "Name_31"), 4, LocalStringManager.GetConfig("LifeSkill_language", "Desc_31"), 3, 3, 31, new List<byte> { 4, 5 }, 24, new List<ShortList>
		{
			new ShortList(111),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 1, 0, 0, 0 }));
		_dataArray.Add(new LifeSkillItem(32, LocalStringManager.GetConfig("LifeSkill_language", "Name_32"), 5, LocalStringManager.GetConfig("LifeSkill_language", "Desc_32"), 3, 3, 32, new List<byte> { 4, 5 }, 28, new List<ShortList>
		{
			new ShortList(112),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 1, 0, 0, 0 }));
		_dataArray.Add(new LifeSkillItem(33, LocalStringManager.GetConfig("LifeSkill_language", "Name_33"), 6, LocalStringManager.GetConfig("LifeSkill_language", "Desc_33"), 3, 4, 33, new List<byte> { 4, 5 }, 32, new List<ShortList>
		{
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 1, 0 }));
		_dataArray.Add(new LifeSkillItem(34, LocalStringManager.GetConfig("LifeSkill_language", "Name_34"), 7, LocalStringManager.GetConfig("LifeSkill_language", "Desc_34"), 3, 4, 34, new List<byte> { 4, 5 }, 36, new List<ShortList>
		{
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 1, 0 }));
		_dataArray.Add(new LifeSkillItem(35, LocalStringManager.GetConfig("LifeSkill_language", "Name_35"), 8, LocalStringManager.GetConfig("LifeSkill_language", "Desc_35"), 3, 5, 35, new List<byte> { 4, 5 }, 40, new List<ShortList>
		{
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 1, 0 }));
		_dataArray.Add(new LifeSkillItem(36, LocalStringManager.GetConfig("LifeSkill_language", "Name_36"), 0, LocalStringManager.GetConfig("LifeSkill_language", "Desc_36"), 4, 1, 36, new List<byte> { 12, 13 }, 8, new List<ShortList>
		{
			new ShortList(114),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 0, 1 }));
		_dataArray.Add(new LifeSkillItem(37, LocalStringManager.GetConfig("LifeSkill_language", "Name_37"), 1, LocalStringManager.GetConfig("LifeSkill_language", "Desc_37"), 4, 1, 37, new List<byte> { 12, 13 }, 12, new List<ShortList>
		{
			new ShortList(115),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 0, 1 }));
		_dataArray.Add(new LifeSkillItem(38, LocalStringManager.GetConfig("LifeSkill_language", "Name_38"), 2, LocalStringManager.GetConfig("LifeSkill_language", "Desc_38"), 4, 2, 38, new List<byte> { 12, 13 }, 16, new List<ShortList>
		{
			new ShortList(116),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 0, 1 }));
		_dataArray.Add(new LifeSkillItem(39, LocalStringManager.GetConfig("LifeSkill_language", "Name_39"), 3, LocalStringManager.GetConfig("LifeSkill_language", "Desc_39"), 4, 2, 39, new List<byte> { 12, 13 }, 20, new List<ShortList>
		{
			new ShortList(117),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 1, 0, 0, 0 }));
		_dataArray.Add(new LifeSkillItem(40, LocalStringManager.GetConfig("LifeSkill_language", "Name_40"), 4, LocalStringManager.GetConfig("LifeSkill_language", "Desc_40"), 4, 3, 40, new List<byte> { 12, 13 }, 24, new List<ShortList>
		{
			new ShortList(118),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 1, 0, 0, 0 }));
		_dataArray.Add(new LifeSkillItem(41, LocalStringManager.GetConfig("LifeSkill_language", "Name_41"), 5, LocalStringManager.GetConfig("LifeSkill_language", "Desc_41"), 4, 3, 41, new List<byte> { 12, 13 }, 28, new List<ShortList>
		{
			new ShortList(119),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 1, 0, 0, 0 }));
		_dataArray.Add(new LifeSkillItem(42, LocalStringManager.GetConfig("LifeSkill_language", "Name_42"), 6, LocalStringManager.GetConfig("LifeSkill_language", "Desc_42"), 4, 4, 42, new List<byte> { 12, 13 }, 32, new List<ShortList>
		{
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 1, 0 }));
		_dataArray.Add(new LifeSkillItem(43, LocalStringManager.GetConfig("LifeSkill_language", "Name_43"), 7, LocalStringManager.GetConfig("LifeSkill_language", "Desc_43"), 4, 4, 43, new List<byte> { 12, 13 }, 36, new List<ShortList>
		{
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 1, 0 }));
		_dataArray.Add(new LifeSkillItem(44, LocalStringManager.GetConfig("LifeSkill_language", "Name_44"), 8, LocalStringManager.GetConfig("LifeSkill_language", "Desc_44"), 4, 5, 44, new List<byte> { 12, 13 }, 40, new List<ShortList>
		{
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 1, 0 }));
		_dataArray.Add(new LifeSkillItem(45, LocalStringManager.GetConfig("LifeSkill_language", "Name_45"), 0, LocalStringManager.GetConfig("LifeSkill_language", "Desc_45"), 5, 1, 45, new List<byte> { 2, 3 }, 8, new List<ShortList>
		{
			new ShortList(121, 122),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 0, 1 }));
		_dataArray.Add(new LifeSkillItem(46, LocalStringManager.GetConfig("LifeSkill_language", "Name_46"), 1, LocalStringManager.GetConfig("LifeSkill_language", "Desc_46"), 5, 1, 46, new List<byte> { 2, 3 }, 12, new List<ShortList>
		{
			new ShortList(123),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 0, 1 }));
		_dataArray.Add(new LifeSkillItem(47, LocalStringManager.GetConfig("LifeSkill_language", "Name_47"), 2, LocalStringManager.GetConfig("LifeSkill_language", "Desc_47"), 5, 2, 47, new List<byte> { 2, 3 }, 16, new List<ShortList>
		{
			new ShortList(124),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 0, 1 }));
		_dataArray.Add(new LifeSkillItem(48, LocalStringManager.GetConfig("LifeSkill_language", "Name_48"), 3, LocalStringManager.GetConfig("LifeSkill_language", "Desc_48"), 5, 2, 48, new List<byte> { 2, 3 }, 20, new List<ShortList>
		{
			new ShortList(125),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 1, 0, 0, 0 }));
		_dataArray.Add(new LifeSkillItem(49, LocalStringManager.GetConfig("LifeSkill_language", "Name_49"), 4, LocalStringManager.GetConfig("LifeSkill_language", "Desc_49"), 5, 3, 49, new List<byte> { 2, 3 }, 24, new List<ShortList>
		{
			new ShortList(126),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 1, 0, 0, 0 }));
		_dataArray.Add(new LifeSkillItem(50, LocalStringManager.GetConfig("LifeSkill_language", "Name_50"), 5, LocalStringManager.GetConfig("LifeSkill_language", "Desc_50"), 5, 3, 50, new List<byte> { 2, 3 }, 28, new List<ShortList>
		{
			new ShortList(127, 128),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 1, 0, 0, 0 }));
		_dataArray.Add(new LifeSkillItem(51, LocalStringManager.GetConfig("LifeSkill_language", "Name_51"), 6, LocalStringManager.GetConfig("LifeSkill_language", "Desc_51"), 5, 4, 51, new List<byte> { 2, 3 }, 32, new List<ShortList>
		{
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 1, 0 }));
		_dataArray.Add(new LifeSkillItem(52, LocalStringManager.GetConfig("LifeSkill_language", "Name_52"), 7, LocalStringManager.GetConfig("LifeSkill_language", "Desc_52"), 5, 4, 52, new List<byte> { 2, 3 }, 36, new List<ShortList>
		{
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 1, 0 }));
		_dataArray.Add(new LifeSkillItem(53, LocalStringManager.GetConfig("LifeSkill_language", "Name_53"), 8, LocalStringManager.GetConfig("LifeSkill_language", "Desc_53"), 5, 5, 53, new List<byte> { 2, 3 }, 40, new List<ShortList>
		{
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 1, 0 }));
		_dataArray.Add(new LifeSkillItem(54, LocalStringManager.GetConfig("LifeSkill_language", "Name_54"), 0, LocalStringManager.GetConfig("LifeSkill_language", "Desc_54"), 6, 1, 54, new List<byte>(), 8, new List<ShortList>
		{
			new ShortList(130),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 0, 1 }));
		_dataArray.Add(new LifeSkillItem(55, LocalStringManager.GetConfig("LifeSkill_language", "Name_55"), 1, LocalStringManager.GetConfig("LifeSkill_language", "Desc_55"), 6, 1, 55, new List<byte>(), 12, new List<ShortList>
		{
			new ShortList(131),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 0, 1 }));
		_dataArray.Add(new LifeSkillItem(56, LocalStringManager.GetConfig("LifeSkill_language", "Name_56"), 2, LocalStringManager.GetConfig("LifeSkill_language", "Desc_56"), 6, 2, 56, new List<byte>(), 16, new List<ShortList>
		{
			new ShortList(132),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 0, 1 }));
		_dataArray.Add(new LifeSkillItem(57, LocalStringManager.GetConfig("LifeSkill_language", "Name_57"), 3, LocalStringManager.GetConfig("LifeSkill_language", "Desc_57"), 6, 2, 57, new List<byte>(), 20, new List<ShortList>
		{
			new ShortList(133),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 1, 0, 0, 0 }));
		_dataArray.Add(new LifeSkillItem(58, LocalStringManager.GetConfig("LifeSkill_language", "Name_58"), 4, LocalStringManager.GetConfig("LifeSkill_language", "Desc_58"), 6, 3, 58, new List<byte>(), 24, new List<ShortList>
		{
			new ShortList(134),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 1, 0, 0, 0 }));
		_dataArray.Add(new LifeSkillItem(59, LocalStringManager.GetConfig("LifeSkill_language", "Name_59"), 5, LocalStringManager.GetConfig("LifeSkill_language", "Desc_59"), 6, 3, 59, new List<byte>(), 28, new List<ShortList>
		{
			new ShortList(135, 136),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 1, 0, 0, 0 }));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new LifeSkillItem(60, LocalStringManager.GetConfig("LifeSkill_language", "Name_60"), 6, LocalStringManager.GetConfig("LifeSkill_language", "Desc_60"), 6, 4, 60, new List<byte>(), 32, new List<ShortList>
		{
			new ShortList(137),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 1, 0 }));
		_dataArray.Add(new LifeSkillItem(61, LocalStringManager.GetConfig("LifeSkill_language", "Name_61"), 7, LocalStringManager.GetConfig("LifeSkill_language", "Desc_61"), 6, 4, 61, new List<byte>(), 36, new List<ShortList>
		{
			new ShortList(138),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 1, 0 }));
		_dataArray.Add(new LifeSkillItem(62, LocalStringManager.GetConfig("LifeSkill_language", "Name_62"), 8, LocalStringManager.GetConfig("LifeSkill_language", "Desc_62"), 6, 5, 62, new List<byte>(), 40, new List<ShortList>
		{
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 1, 0 }));
		_dataArray.Add(new LifeSkillItem(63, LocalStringManager.GetConfig("LifeSkill_language", "Name_63"), 0, LocalStringManager.GetConfig("LifeSkill_language", "Desc_63"), 7, 1, 63, new List<byte>(), 8, new List<ShortList>
		{
			new ShortList(140),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 0, 1 }));
		_dataArray.Add(new LifeSkillItem(64, LocalStringManager.GetConfig("LifeSkill_language", "Name_64"), 1, LocalStringManager.GetConfig("LifeSkill_language", "Desc_64"), 7, 1, 64, new List<byte>(), 12, new List<ShortList>
		{
			new ShortList(141),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 0, 1 }));
		_dataArray.Add(new LifeSkillItem(65, LocalStringManager.GetConfig("LifeSkill_language", "Name_65"), 2, LocalStringManager.GetConfig("LifeSkill_language", "Desc_65"), 7, 2, 65, new List<byte>(), 16, new List<ShortList>
		{
			new ShortList(142),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 0, 1 }));
		_dataArray.Add(new LifeSkillItem(66, LocalStringManager.GetConfig("LifeSkill_language", "Name_66"), 3, LocalStringManager.GetConfig("LifeSkill_language", "Desc_66"), 7, 2, 66, new List<byte>(), 20, new List<ShortList>
		{
			new ShortList(143),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 1, 0, 0, 0 }));
		_dataArray.Add(new LifeSkillItem(67, LocalStringManager.GetConfig("LifeSkill_language", "Name_67"), 4, LocalStringManager.GetConfig("LifeSkill_language", "Desc_67"), 7, 3, 67, new List<byte>(), 24, new List<ShortList>
		{
			new ShortList(144),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 1, 0, 0, 0 }));
		_dataArray.Add(new LifeSkillItem(68, LocalStringManager.GetConfig("LifeSkill_language", "Name_68"), 5, LocalStringManager.GetConfig("LifeSkill_language", "Desc_68"), 7, 3, 68, new List<byte>(), 28, new List<ShortList>
		{
			new ShortList(145, 146),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 1, 0, 0, 0 }));
		_dataArray.Add(new LifeSkillItem(69, LocalStringManager.GetConfig("LifeSkill_language", "Name_69"), 6, LocalStringManager.GetConfig("LifeSkill_language", "Desc_69"), 7, 4, 69, new List<byte>(), 32, new List<ShortList>
		{
			new ShortList(147),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 1, 0 }));
		_dataArray.Add(new LifeSkillItem(70, LocalStringManager.GetConfig("LifeSkill_language", "Name_70"), 7, LocalStringManager.GetConfig("LifeSkill_language", "Desc_70"), 7, 4, 70, new List<byte>(), 36, new List<ShortList>
		{
			new ShortList(148),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 1, 0 }));
		_dataArray.Add(new LifeSkillItem(71, LocalStringManager.GetConfig("LifeSkill_language", "Name_71"), 8, LocalStringManager.GetConfig("LifeSkill_language", "Desc_71"), 7, 5, 71, new List<byte>(), 40, new List<ShortList>
		{
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 1, 0 }));
		_dataArray.Add(new LifeSkillItem(72, LocalStringManager.GetConfig("LifeSkill_language", "Name_72"), 0, LocalStringManager.GetConfig("LifeSkill_language", "Desc_72"), 8, 1, 72, new List<byte>(), 8, new List<ShortList>
		{
			new ShortList(150),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 0, 1 }));
		_dataArray.Add(new LifeSkillItem(73, LocalStringManager.GetConfig("LifeSkill_language", "Name_73"), 1, LocalStringManager.GetConfig("LifeSkill_language", "Desc_73"), 8, 1, 73, new List<byte>(), 12, new List<ShortList>
		{
			new ShortList(151),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 0, 1 }));
		_dataArray.Add(new LifeSkillItem(74, LocalStringManager.GetConfig("LifeSkill_language", "Name_74"), 2, LocalStringManager.GetConfig("LifeSkill_language", "Desc_74"), 8, 2, 74, new List<byte>(), 16, new List<ShortList>
		{
			new ShortList(152),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 0, 1 }));
		_dataArray.Add(new LifeSkillItem(75, LocalStringManager.GetConfig("LifeSkill_language", "Name_75"), 3, LocalStringManager.GetConfig("LifeSkill_language", "Desc_75"), 8, 2, 75, new List<byte>(), 20, new List<ShortList>
		{
			new ShortList(153),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 1, 0, 0, 0 }));
		_dataArray.Add(new LifeSkillItem(76, LocalStringManager.GetConfig("LifeSkill_language", "Name_76"), 4, LocalStringManager.GetConfig("LifeSkill_language", "Desc_76"), 8, 3, 76, new List<byte>(), 24, new List<ShortList>
		{
			new ShortList(154),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 1, 0, 0, 0 }));
		_dataArray.Add(new LifeSkillItem(77, LocalStringManager.GetConfig("LifeSkill_language", "Name_77"), 5, LocalStringManager.GetConfig("LifeSkill_language", "Desc_77"), 8, 3, 77, new List<byte>(), 28, new List<ShortList>
		{
			new ShortList(155, 156),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 1, 0, 0, 0 }));
		_dataArray.Add(new LifeSkillItem(78, LocalStringManager.GetConfig("LifeSkill_language", "Name_78"), 6, LocalStringManager.GetConfig("LifeSkill_language", "Desc_78"), 8, 4, 78, new List<byte>(), 32, new List<ShortList>
		{
			new ShortList(157),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 1, 0 }));
		_dataArray.Add(new LifeSkillItem(79, LocalStringManager.GetConfig("LifeSkill_language", "Name_79"), 7, LocalStringManager.GetConfig("LifeSkill_language", "Desc_79"), 8, 4, 79, new List<byte>(), 36, new List<ShortList>
		{
			new ShortList(158),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 1, 0 }));
		_dataArray.Add(new LifeSkillItem(80, LocalStringManager.GetConfig("LifeSkill_language", "Name_80"), 8, LocalStringManager.GetConfig("LifeSkill_language", "Desc_80"), 8, 5, 80, new List<byte>(), 40, new List<ShortList>
		{
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 1, 0 }));
		_dataArray.Add(new LifeSkillItem(81, LocalStringManager.GetConfig("LifeSkill_language", "Name_81"), 0, LocalStringManager.GetConfig("LifeSkill_language", "Desc_81"), 9, 1, 81, new List<byte>(), 8, new List<ShortList>
		{
			new ShortList(160),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 0, 1 }));
		_dataArray.Add(new LifeSkillItem(82, LocalStringManager.GetConfig("LifeSkill_language", "Name_82"), 1, LocalStringManager.GetConfig("LifeSkill_language", "Desc_82"), 9, 1, 82, new List<byte>(), 12, new List<ShortList>
		{
			new ShortList(161),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 0, 1 }));
		_dataArray.Add(new LifeSkillItem(83, LocalStringManager.GetConfig("LifeSkill_language", "Name_83"), 2, LocalStringManager.GetConfig("LifeSkill_language", "Desc_83"), 9, 2, 83, new List<byte>(), 16, new List<ShortList>
		{
			new ShortList(162),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 0, 1 }));
		_dataArray.Add(new LifeSkillItem(84, LocalStringManager.GetConfig("LifeSkill_language", "Name_84"), 3, LocalStringManager.GetConfig("LifeSkill_language", "Desc_84"), 9, 2, 84, new List<byte>(), 20, new List<ShortList>
		{
			new ShortList(163),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 1, 0, 0, 0 }));
		_dataArray.Add(new LifeSkillItem(85, LocalStringManager.GetConfig("LifeSkill_language", "Name_85"), 4, LocalStringManager.GetConfig("LifeSkill_language", "Desc_85"), 9, 3, 85, new List<byte>(), 24, new List<ShortList>
		{
			new ShortList(164),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 1, 0, 0, 0 }));
		_dataArray.Add(new LifeSkillItem(86, LocalStringManager.GetConfig("LifeSkill_language", "Name_86"), 5, LocalStringManager.GetConfig("LifeSkill_language", "Desc_86"), 9, 3, 86, new List<byte>(), 28, new List<ShortList>
		{
			new ShortList(165, 166),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 1, 0, 0, 0 }));
		_dataArray.Add(new LifeSkillItem(87, LocalStringManager.GetConfig("LifeSkill_language", "Name_87"), 6, LocalStringManager.GetConfig("LifeSkill_language", "Desc_87"), 9, 4, 87, new List<byte>(), 32, new List<ShortList>
		{
			new ShortList(167),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 1, 0 }));
		_dataArray.Add(new LifeSkillItem(88, LocalStringManager.GetConfig("LifeSkill_language", "Name_88"), 7, LocalStringManager.GetConfig("LifeSkill_language", "Desc_88"), 9, 4, 88, new List<byte>(), 36, new List<ShortList>
		{
			new ShortList(168),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 1, 0 }));
		_dataArray.Add(new LifeSkillItem(89, LocalStringManager.GetConfig("LifeSkill_language", "Name_89"), 8, LocalStringManager.GetConfig("LifeSkill_language", "Desc_89"), 9, 5, 89, new List<byte>(), 40, new List<ShortList>
		{
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 1, 0 }));
		_dataArray.Add(new LifeSkillItem(90, LocalStringManager.GetConfig("LifeSkill_language", "Name_90"), 0, LocalStringManager.GetConfig("LifeSkill_language", "Desc_90"), 10, 1, 90, new List<byte>(), 8, new List<ShortList>
		{
			new ShortList(170),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 0, 1 }));
		_dataArray.Add(new LifeSkillItem(91, LocalStringManager.GetConfig("LifeSkill_language", "Name_91"), 1, LocalStringManager.GetConfig("LifeSkill_language", "Desc_91"), 10, 1, 91, new List<byte>(), 12, new List<ShortList>
		{
			new ShortList(171),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 0, 1 }));
		_dataArray.Add(new LifeSkillItem(92, LocalStringManager.GetConfig("LifeSkill_language", "Name_92"), 2, LocalStringManager.GetConfig("LifeSkill_language", "Desc_92"), 10, 2, 92, new List<byte>(), 16, new List<ShortList>
		{
			new ShortList(172),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 0, 1 }));
		_dataArray.Add(new LifeSkillItem(93, LocalStringManager.GetConfig("LifeSkill_language", "Name_93"), 3, LocalStringManager.GetConfig("LifeSkill_language", "Desc_93"), 10, 2, 93, new List<byte>(), 20, new List<ShortList>
		{
			new ShortList(173),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 1, 0, 0, 0 }));
		_dataArray.Add(new LifeSkillItem(94, LocalStringManager.GetConfig("LifeSkill_language", "Name_94"), 4, LocalStringManager.GetConfig("LifeSkill_language", "Desc_94"), 10, 3, 94, new List<byte>(), 24, new List<ShortList>
		{
			new ShortList(174),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 1, 0, 0, 0 }));
		_dataArray.Add(new LifeSkillItem(95, LocalStringManager.GetConfig("LifeSkill_language", "Name_95"), 5, LocalStringManager.GetConfig("LifeSkill_language", "Desc_95"), 10, 3, 95, new List<byte>(), 28, new List<ShortList>
		{
			new ShortList(175, 176),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 1, 0, 0, 0 }));
		_dataArray.Add(new LifeSkillItem(96, LocalStringManager.GetConfig("LifeSkill_language", "Name_96"), 6, LocalStringManager.GetConfig("LifeSkill_language", "Desc_96"), 10, 4, 96, new List<byte>(), 32, new List<ShortList>
		{
			new ShortList(177),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 1, 0 }));
		_dataArray.Add(new LifeSkillItem(97, LocalStringManager.GetConfig("LifeSkill_language", "Name_97"), 7, LocalStringManager.GetConfig("LifeSkill_language", "Desc_97"), 10, 4, 97, new List<byte>(), 36, new List<ShortList>
		{
			new ShortList(178),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 1, 0 }));
		_dataArray.Add(new LifeSkillItem(98, LocalStringManager.GetConfig("LifeSkill_language", "Name_98"), 8, LocalStringManager.GetConfig("LifeSkill_language", "Desc_98"), 10, 5, 98, new List<byte>(), 40, new List<ShortList>
		{
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 1, 0 }));
		_dataArray.Add(new LifeSkillItem(99, LocalStringManager.GetConfig("LifeSkill_language", "Name_99"), 0, LocalStringManager.GetConfig("LifeSkill_language", "Desc_99"), 11, 1, 99, new List<byte>(), 8, new List<ShortList>
		{
			new ShortList(180),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 0, 1 }));
		_dataArray.Add(new LifeSkillItem(100, LocalStringManager.GetConfig("LifeSkill_language", "Name_100"), 1, LocalStringManager.GetConfig("LifeSkill_language", "Desc_100"), 11, 1, 100, new List<byte>(), 12, new List<ShortList>
		{
			new ShortList(181),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 0, 1 }));
		_dataArray.Add(new LifeSkillItem(101, LocalStringManager.GetConfig("LifeSkill_language", "Name_101"), 2, LocalStringManager.GetConfig("LifeSkill_language", "Desc_101"), 11, 2, 101, new List<byte>(), 16, new List<ShortList>
		{
			new ShortList(182),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 0, 1 }));
		_dataArray.Add(new LifeSkillItem(102, LocalStringManager.GetConfig("LifeSkill_language", "Name_102"), 3, LocalStringManager.GetConfig("LifeSkill_language", "Desc_102"), 11, 2, 102, new List<byte>(), 20, new List<ShortList>
		{
			new ShortList(183),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 1, 0, 0, 0 }));
		_dataArray.Add(new LifeSkillItem(103, LocalStringManager.GetConfig("LifeSkill_language", "Name_103"), 4, LocalStringManager.GetConfig("LifeSkill_language", "Desc_103"), 11, 3, 103, new List<byte>(), 24, new List<ShortList>
		{
			new ShortList(184),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 1, 0, 0, 0 }));
		_dataArray.Add(new LifeSkillItem(104, LocalStringManager.GetConfig("LifeSkill_language", "Name_104"), 5, LocalStringManager.GetConfig("LifeSkill_language", "Desc_104"), 11, 3, 104, new List<byte>(), 28, new List<ShortList>
		{
			new ShortList(185, 186),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 1, 0, 0, 0 }));
		_dataArray.Add(new LifeSkillItem(105, LocalStringManager.GetConfig("LifeSkill_language", "Name_105"), 6, LocalStringManager.GetConfig("LifeSkill_language", "Desc_105"), 11, 4, 105, new List<byte>(), 32, new List<ShortList>
		{
			new ShortList(187),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 1, 0 }));
		_dataArray.Add(new LifeSkillItem(106, LocalStringManager.GetConfig("LifeSkill_language", "Name_106"), 7, LocalStringManager.GetConfig("LifeSkill_language", "Desc_106"), 11, 4, 106, new List<byte>(), 36, new List<ShortList>
		{
			new ShortList(188),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 1, 0 }));
		_dataArray.Add(new LifeSkillItem(107, LocalStringManager.GetConfig("LifeSkill_language", "Name_107"), 8, LocalStringManager.GetConfig("LifeSkill_language", "Desc_107"), 11, 5, 107, new List<byte>(), 40, new List<ShortList>
		{
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 1, 0 }));
		_dataArray.Add(new LifeSkillItem(108, LocalStringManager.GetConfig("LifeSkill_language", "Name_108"), 0, LocalStringManager.GetConfig("LifeSkill_language", "Desc_108"), 12, 1, 108, new List<byte> { 14, 15 }, 8, new List<ShortList>
		{
			new ShortList(190),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 0, 1 }));
		_dataArray.Add(new LifeSkillItem(109, LocalStringManager.GetConfig("LifeSkill_language", "Name_109"), 1, LocalStringManager.GetConfig("LifeSkill_language", "Desc_109"), 12, 1, 109, new List<byte> { 14, 15 }, 12, new List<ShortList>
		{
			new ShortList(191),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 0, 1 }));
		_dataArray.Add(new LifeSkillItem(110, LocalStringManager.GetConfig("LifeSkill_language", "Name_110"), 2, LocalStringManager.GetConfig("LifeSkill_language", "Desc_110"), 12, 2, 110, new List<byte> { 14, 15 }, 16, new List<ShortList>
		{
			new ShortList(192),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 0, 1 }));
		_dataArray.Add(new LifeSkillItem(111, LocalStringManager.GetConfig("LifeSkill_language", "Name_111"), 3, LocalStringManager.GetConfig("LifeSkill_language", "Desc_111"), 12, 2, 111, new List<byte> { 14, 15 }, 20, new List<ShortList>
		{
			new ShortList(193),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 1, 0, 0, 0 }));
		_dataArray.Add(new LifeSkillItem(112, LocalStringManager.GetConfig("LifeSkill_language", "Name_112"), 4, LocalStringManager.GetConfig("LifeSkill_language", "Desc_112"), 12, 3, 112, new List<byte> { 14, 15 }, 24, new List<ShortList>
		{
			new ShortList(194),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 1, 0, 0, 0 }));
		_dataArray.Add(new LifeSkillItem(113, LocalStringManager.GetConfig("LifeSkill_language", "Name_113"), 5, LocalStringManager.GetConfig("LifeSkill_language", "Desc_113"), 12, 3, 113, new List<byte> { 14, 15 }, 28, new List<ShortList>
		{
			new ShortList(195),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 1, 0, 0, 0 }));
		_dataArray.Add(new LifeSkillItem(114, LocalStringManager.GetConfig("LifeSkill_language", "Name_114"), 6, LocalStringManager.GetConfig("LifeSkill_language", "Desc_114"), 12, 4, 114, new List<byte> { 14, 15 }, 32, new List<ShortList>
		{
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 1, 0 }));
		_dataArray.Add(new LifeSkillItem(115, LocalStringManager.GetConfig("LifeSkill_language", "Name_115"), 7, LocalStringManager.GetConfig("LifeSkill_language", "Desc_115"), 12, 4, 115, new List<byte> { 14, 15 }, 36, new List<ShortList>
		{
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 1, 0 }));
		_dataArray.Add(new LifeSkillItem(116, LocalStringManager.GetConfig("LifeSkill_language", "Name_116"), 8, LocalStringManager.GetConfig("LifeSkill_language", "Desc_116"), 12, 5, 116, new List<byte> { 14, 15 }, 40, new List<ShortList>
		{
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 1, 0 }));
		_dataArray.Add(new LifeSkillItem(117, LocalStringManager.GetConfig("LifeSkill_language", "Name_117"), 0, LocalStringManager.GetConfig("LifeSkill_language", "Desc_117"), 13, 1, 117, new List<byte> { 16, 17 }, 8, new List<ShortList>
		{
			new ShortList(197),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 0, 1 }));
		_dataArray.Add(new LifeSkillItem(118, LocalStringManager.GetConfig("LifeSkill_language", "Name_118"), 1, LocalStringManager.GetConfig("LifeSkill_language", "Desc_118"), 13, 1, 118, new List<byte> { 16, 17 }, 12, new List<ShortList>
		{
			new ShortList(198),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 0, 1 }));
		_dataArray.Add(new LifeSkillItem(119, LocalStringManager.GetConfig("LifeSkill_language", "Name_119"), 2, LocalStringManager.GetConfig("LifeSkill_language", "Desc_119"), 13, 2, 119, new List<byte> { 16, 17 }, 16, new List<ShortList>
		{
			new ShortList(199),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 0, 1 }));
	}

	private void CreateItems2()
	{
		_dataArray.Add(new LifeSkillItem(120, LocalStringManager.GetConfig("LifeSkill_language", "Name_120"), 3, LocalStringManager.GetConfig("LifeSkill_language", "Desc_120"), 13, 2, 120, new List<byte> { 16, 17 }, 20, new List<ShortList>
		{
			new ShortList(200),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 1, 0, 0, 0 }));
		_dataArray.Add(new LifeSkillItem(121, LocalStringManager.GetConfig("LifeSkill_language", "Name_121"), 4, LocalStringManager.GetConfig("LifeSkill_language", "Desc_121"), 13, 3, 121, new List<byte> { 16, 17 }, 24, new List<ShortList>
		{
			new ShortList(201),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 1, 0, 0, 0 }));
		_dataArray.Add(new LifeSkillItem(122, LocalStringManager.GetConfig("LifeSkill_language", "Name_122"), 5, LocalStringManager.GetConfig("LifeSkill_language", "Desc_122"), 13, 3, 122, new List<byte> { 16, 17 }, 28, new List<ShortList>
		{
			new ShortList(202),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 1, 0, 0, 0 }));
		_dataArray.Add(new LifeSkillItem(123, LocalStringManager.GetConfig("LifeSkill_language", "Name_123"), 6, LocalStringManager.GetConfig("LifeSkill_language", "Desc_123"), 13, 4, 123, new List<byte> { 16, 17 }, 32, new List<ShortList>
		{
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 1, 0 }));
		_dataArray.Add(new LifeSkillItem(124, LocalStringManager.GetConfig("LifeSkill_language", "Name_124"), 7, LocalStringManager.GetConfig("LifeSkill_language", "Desc_124"), 13, 4, 124, new List<byte> { 16, 17 }, 36, new List<ShortList>
		{
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 1, 0 }));
		_dataArray.Add(new LifeSkillItem(125, LocalStringManager.GetConfig("LifeSkill_language", "Name_125"), 8, LocalStringManager.GetConfig("LifeSkill_language", "Desc_125"), 13, 5, 125, new List<byte> { 16, 17 }, 40, new List<ShortList>
		{
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 1, 0 }));
		_dataArray.Add(new LifeSkillItem(126, LocalStringManager.GetConfig("LifeSkill_language", "Name_126"), 0, LocalStringManager.GetConfig("LifeSkill_language", "Desc_126"), 14, 1, 126, new List<byte>(), 8, new List<ShortList>
		{
			new ShortList(204),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 0, 1 }));
		_dataArray.Add(new LifeSkillItem(127, LocalStringManager.GetConfig("LifeSkill_language", "Name_127"), 1, LocalStringManager.GetConfig("LifeSkill_language", "Desc_127"), 14, 1, 127, new List<byte>(), 12, new List<ShortList>
		{
			new ShortList(205),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 0, 1 }));
		_dataArray.Add(new LifeSkillItem(128, LocalStringManager.GetConfig("LifeSkill_language", "Name_128"), 2, LocalStringManager.GetConfig("LifeSkill_language", "Desc_128"), 14, 2, 128, new List<byte>(), 16, new List<ShortList>
		{
			new ShortList(206),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 0, 1 }));
		_dataArray.Add(new LifeSkillItem(129, LocalStringManager.GetConfig("LifeSkill_language", "Name_129"), 3, LocalStringManager.GetConfig("LifeSkill_language", "Desc_129"), 14, 2, 129, new List<byte>(), 20, new List<ShortList>
		{
			new ShortList(207),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 1, 0, 0, 0 }));
		_dataArray.Add(new LifeSkillItem(130, LocalStringManager.GetConfig("LifeSkill_language", "Name_130"), 4, LocalStringManager.GetConfig("LifeSkill_language", "Desc_130"), 14, 3, 130, new List<byte>(), 24, new List<ShortList>
		{
			new ShortList(208),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 1, 0, 0, 0 }));
		_dataArray.Add(new LifeSkillItem(131, LocalStringManager.GetConfig("LifeSkill_language", "Name_131"), 5, LocalStringManager.GetConfig("LifeSkill_language", "Desc_131"), 14, 3, 131, new List<byte>(), 28, new List<ShortList>
		{
			new ShortList(209, 210),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 1, 0, 0, 0 }));
		_dataArray.Add(new LifeSkillItem(132, LocalStringManager.GetConfig("LifeSkill_language", "Name_132"), 6, LocalStringManager.GetConfig("LifeSkill_language", "Desc_132"), 14, 4, 132, new List<byte>(), 32, new List<ShortList>
		{
			new ShortList(211),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 1, 0 }));
		_dataArray.Add(new LifeSkillItem(133, LocalStringManager.GetConfig("LifeSkill_language", "Name_133"), 7, LocalStringManager.GetConfig("LifeSkill_language", "Desc_133"), 14, 4, 133, new List<byte>(), 36, new List<ShortList>
		{
			new ShortList(212),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 1, 0 }));
		_dataArray.Add(new LifeSkillItem(134, LocalStringManager.GetConfig("LifeSkill_language", "Name_134"), 8, LocalStringManager.GetConfig("LifeSkill_language", "Desc_134"), 14, 5, 134, new List<byte>(), 40, new List<ShortList>
		{
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 1, 0 }));
		_dataArray.Add(new LifeSkillItem(135, LocalStringManager.GetConfig("LifeSkill_language", "Name_135"), 0, LocalStringManager.GetConfig("LifeSkill_language", "Desc_135"), 15, 1, 135, new List<byte> { 6, 7 }, 8, new List<ShortList>
		{
			new ShortList(214, 215),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 0, 1 }));
		_dataArray.Add(new LifeSkillItem(136, LocalStringManager.GetConfig("LifeSkill_language", "Name_136"), 1, LocalStringManager.GetConfig("LifeSkill_language", "Desc_136"), 15, 1, 136, new List<byte> { 6, 7 }, 12, new List<ShortList>
		{
			new ShortList(216, 217),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 0, 1 }));
		_dataArray.Add(new LifeSkillItem(137, LocalStringManager.GetConfig("LifeSkill_language", "Name_137"), 2, LocalStringManager.GetConfig("LifeSkill_language", "Desc_137"), 15, 2, 137, new List<byte> { 6, 7 }, 16, new List<ShortList>
		{
			new ShortList(218),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 0, 1 }));
		_dataArray.Add(new LifeSkillItem(138, LocalStringManager.GetConfig("LifeSkill_language", "Name_138"), 3, LocalStringManager.GetConfig("LifeSkill_language", "Desc_138"), 15, 2, 138, new List<byte> { 6, 7 }, 20, new List<ShortList>
		{
			new ShortList(219),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 1, 0, 0, 0 }));
		_dataArray.Add(new LifeSkillItem(139, LocalStringManager.GetConfig("LifeSkill_language", "Name_139"), 4, LocalStringManager.GetConfig("LifeSkill_language", "Desc_139"), 15, 3, 139, new List<byte> { 6, 7 }, 24, new List<ShortList>
		{
			new ShortList(220),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 1, 0, 0, 0 }));
		_dataArray.Add(new LifeSkillItem(140, LocalStringManager.GetConfig("LifeSkill_language", "Name_140"), 5, LocalStringManager.GetConfig("LifeSkill_language", "Desc_140"), 15, 3, 140, new List<byte> { 6, 7 }, 28, new List<ShortList>
		{
			new ShortList(221),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 1, 0, 0, 0 }));
		_dataArray.Add(new LifeSkillItem(141, LocalStringManager.GetConfig("LifeSkill_language", "Name_141"), 6, LocalStringManager.GetConfig("LifeSkill_language", "Desc_141"), 15, 4, 141, new List<byte> { 6, 7 }, 32, new List<ShortList>
		{
			new ShortList(222, 223),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 1, 0 }));
		_dataArray.Add(new LifeSkillItem(142, LocalStringManager.GetConfig("LifeSkill_language", "Name_142"), 7, LocalStringManager.GetConfig("LifeSkill_language", "Desc_142"), 15, 4, 142, new List<byte> { 6, 7 }, 36, new List<ShortList>
		{
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 1, 0 }));
		_dataArray.Add(new LifeSkillItem(143, LocalStringManager.GetConfig("LifeSkill_language", "Name_143"), 8, LocalStringManager.GetConfig("LifeSkill_language", "Desc_143"), 15, 5, 143, new List<byte> { 6, 7 }, 40, new List<ShortList>
		{
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		}, new sbyte[5] { 0, 0, 0, 1, 0 }));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<LifeSkillItem>(144);
		CreateItems0();
		CreateItems1();
		CreateItems2();
	}
}

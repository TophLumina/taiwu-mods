using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class AdventureGenerateCondition : ConfigData<AdventureGenerateConditionItem, int>
{
	/// <summary>
	/// 配置表实例
	/// </summary>
	public static AdventureGenerateCondition Instance = new AdventureGenerateCondition();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "TargetId", "EnterMonthList", "IncludeTypes", "ActiveNotification", "PrepareNotification", "TemplateId", "StateWeights", "AreaWeights" };

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
		_dataArray.Add(new AdventureGenerateConditionItem(0, 17, forceDisable: false, new List<sbyte>(), 2, 20, 4, new int[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new int[3] { 1, 1, 1 }, new EMapBlockType[1] { EMapBlockType.Wild }, 3, 3, 119, -1));
		_dataArray.Add(new AdventureGenerateConditionItem(1, 268182972, forceDisable: false, new List<sbyte>(), 2, 20, 4, new int[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new int[3] { 1, 1, 1 }, new EMapBlockType[1] { EMapBlockType.Wild }, 3, 3, 120, -1));
		_dataArray.Add(new AdventureGenerateConditionItem(2, 81638591, forceDisable: false, new List<sbyte>(), 2, 20, 4, new int[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new int[3] { 1, 1, 1 }, new EMapBlockType[1] { EMapBlockType.Wild }, 3, 3, 121, -1));
		_dataArray.Add(new AdventureGenerateConditionItem(3, 1157686666, forceDisable: false, new List<sbyte>(), 2, 20, 4, new int[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new int[3] { 1, 1, 1 }, new EMapBlockType[1] { EMapBlockType.Wild }, 3, 3, 122, -1));
		_dataArray.Add(new AdventureGenerateConditionItem(4, 24, forceDisable: false, new List<sbyte>(), 2, 20, 4, new int[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new int[3] { 1, 1, 1 }, new EMapBlockType[1] { EMapBlockType.Wild }, 3, 4, 123, -1));
		_dataArray.Add(new AdventureGenerateConditionItem(5, 1016260222, forceDisable: false, new List<sbyte>(), 2, 20, 4, new int[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new int[3] { 1, 1, 1 }, new EMapBlockType[1] { EMapBlockType.Wild }, 3, 4, 124, -1));
		_dataArray.Add(new AdventureGenerateConditionItem(6, 26, forceDisable: false, new List<sbyte>(), 1, 10, 2, new int[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new int[3] { 1, 1, 1 }, new EMapBlockType[1] { EMapBlockType.Wild }, 3, 4, 125, -1));
		_dataArray.Add(new AdventureGenerateConditionItem(7, 242525420, forceDisable: false, new List<sbyte>(), 1, 10, 2, new int[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new int[3] { 1, 1, 1 }, new EMapBlockType[1] { EMapBlockType.Wild }, 3, 4, 126, -1));
		_dataArray.Add(new AdventureGenerateConditionItem(8, 719558403, forceDisable: false, new List<sbyte>(), 1, 10, 2, new int[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new int[3] { 1, 1, 0 }, new EMapBlockType[1] { EMapBlockType.Wild }, 3, 5, 127, -1));
		_dataArray.Add(new AdventureGenerateConditionItem(9, 493756853, forceDisable: false, new List<sbyte>(), 1, 5, 1, new int[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new int[3] { 1, 1, 0 }, new EMapBlockType[1] { EMapBlockType.Wild }, 3, 5, 128, -1));
		_dataArray.Add(new AdventureGenerateConditionItem(10, 150293747, forceDisable: false, new List<sbyte>(), 1, 5, 1, new int[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new int[3] { 1, 1, 0 }, new EMapBlockType[1] { EMapBlockType.Wild }, 3, 5, 129, -1));
		_dataArray.Add(new AdventureGenerateConditionItem(11, 267084840, forceDisable: false, new List<sbyte>(), 1, 5, 1, new int[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new int[3] { 1, 1, 0 }, new EMapBlockType[1] { EMapBlockType.Wild }, 3, 5, 130, -1));
		_dataArray.Add(new AdventureGenerateConditionItem(12, 38844009, forceDisable: false, new List<sbyte>(), 1, 20, 4, new int[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new int[3] { 1, 1, 1 }, new EMapBlockType[1] { EMapBlockType.Wild }, 3, 3, 464, -1));
		_dataArray.Add(new AdventureGenerateConditionItem(13, 176747589, forceDisable: false, new List<sbyte>(), 1, 10, 2, new int[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new int[3] { 1, 1, 1 }, new EMapBlockType[1] { EMapBlockType.Wild }, 3, 4, 465, -1));
		_dataArray.Add(new AdventureGenerateConditionItem(14, 81053777, forceDisable: false, new List<sbyte>(), 1, 5, 1, new int[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new int[3] { 1, 1, 0 }, new EMapBlockType[1] { EMapBlockType.Wild }, 3, 5, 466, -1));
		_dataArray.Add(new AdventureGenerateConditionItem(15, 188232035, forceDisable: false, new List<sbyte>(), 1, 1, 1, new int[15]
		{
			1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new int[3] { 0, 1, 0 }, new EMapBlockType[1], 3, 9, 459, -1));
		_dataArray.Add(new AdventureGenerateConditionItem(16, 105359907, forceDisable: false, new List<sbyte>(), 1, 1, 1, new int[15]
		{
			0, 1, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new int[3] { 0, 1, 0 }, new EMapBlockType[1], 3, 9, 459, -1));
		_dataArray.Add(new AdventureGenerateConditionItem(17, 237792035, forceDisable: false, new List<sbyte>(), 1, 1, 1, new int[15]
		{
			0, 0, 1, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new int[3] { 0, 1, 0 }, new EMapBlockType[1], 3, 9, 459, -1));
		_dataArray.Add(new AdventureGenerateConditionItem(18, 127124572, forceDisable: false, new List<sbyte>(), 1, 1, 1, new int[15]
		{
			0, 0, 0, 1, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new int[3] { 0, 1, 0 }, new EMapBlockType[1], 3, 9, 459, -1));
		_dataArray.Add(new AdventureGenerateConditionItem(19, 276536439, forceDisable: false, new List<sbyte>(), 1, 1, 1, new int[15]
		{
			0, 0, 0, 0, 1, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new int[3] { 0, 1, 0 }, new EMapBlockType[1], 3, 9, 459, -1));
		_dataArray.Add(new AdventureGenerateConditionItem(20, 273883467, forceDisable: false, new List<sbyte>(), 1, 1, 1, new int[15]
		{
			0, 0, 0, 0, 0, 1, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new int[3] { 0, 1, 0 }, new EMapBlockType[1], 3, 9, 459, -1));
		_dataArray.Add(new AdventureGenerateConditionItem(21, 267053085, forceDisable: false, new List<sbyte>(), 1, 1, 1, new int[15]
		{
			0, 0, 0, 0, 0, 0, 1, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new int[3] { 0, 1, 0 }, new EMapBlockType[1], 3, 9, 459, -1));
		_dataArray.Add(new AdventureGenerateConditionItem(22, 188179646, forceDisable: false, new List<sbyte>(), 1, 1, 1, new int[15]
		{
			0, 0, 0, 0, 0, 0, 0, 1, 0, 0,
			0, 0, 0, 0, 0
		}, new int[3] { 0, 1, 0 }, new EMapBlockType[1], 3, 9, 459, -1));
		_dataArray.Add(new AdventureGenerateConditionItem(23, 81323826, forceDisable: false, new List<sbyte>(), 1, 1, 1, new int[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 1, 0,
			0, 0, 0, 0, 0
		}, new int[3] { 0, 1, 0 }, new EMapBlockType[1], 3, 9, 459, -1));
		_dataArray.Add(new AdventureGenerateConditionItem(24, 250238142, forceDisable: false, new List<sbyte>(), 1, 1, 1, new int[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
			0, 0, 0, 0, 0
		}, new int[3] { 0, 1, 0 }, new EMapBlockType[1], 3, 9, 459, -1));
		_dataArray.Add(new AdventureGenerateConditionItem(25, 193727808, forceDisable: false, new List<sbyte>(), 1, 1, 1, new int[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			1, 0, 0, 0, 0
		}, new int[3] { 0, 1, 0 }, new EMapBlockType[1], 3, 9, 459, -1));
		_dataArray.Add(new AdventureGenerateConditionItem(26, 126255790, forceDisable: false, new List<sbyte>(), 1, 1, 1, new int[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 1, 0, 0, 0
		}, new int[3] { 0, 1, 0 }, new EMapBlockType[1], 3, 9, 459, -1));
		_dataArray.Add(new AdventureGenerateConditionItem(27, 223138325, forceDisable: false, new List<sbyte>(), 1, 1, 1, new int[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 1, 0, 0
		}, new int[3] { 0, 1, 0 }, new EMapBlockType[1], 3, 9, 459, -1));
		_dataArray.Add(new AdventureGenerateConditionItem(28, 47952823, forceDisable: false, new List<sbyte>(), 1, 1, 1, new int[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 1, 0
		}, new int[3] { 0, 1, 0 }, new EMapBlockType[1], 3, 9, 459, -1));
		_dataArray.Add(new AdventureGenerateConditionItem(29, 219787682, forceDisable: false, new List<sbyte>(), 1, 1, 1, new int[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 1
		}, new int[3] { 0, 1, 0 }, new EMapBlockType[1], 3, 9, 459, -1));
		_dataArray.Add(new AdventureGenerateConditionItem(30, 77650614, forceDisable: false, new List<sbyte> { 3 }, 1, 1, 1, new int[15]
		{
			1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new int[3] { 1, 0, 0 }, new EMapBlockType[1] { EMapBlockType.Sect }, 3, 21, 183, 343));
		_dataArray.Add(new AdventureGenerateConditionItem(31, 156949079, forceDisable: false, new List<sbyte> { 3 }, 1, 1, 1, new int[15]
		{
			0, 1, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new int[3] { 1, 0, 0 }, new EMapBlockType[1] { EMapBlockType.Sect }, 3, 21, 183, 343));
		_dataArray.Add(new AdventureGenerateConditionItem(32, 159746670, forceDisable: false, new List<sbyte> { 3 }, 1, 1, 1, new int[15]
		{
			0, 0, 1, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new int[3] { 1, 0, 0 }, new EMapBlockType[1] { EMapBlockType.Sect }, 3, 21, 183, 343));
		_dataArray.Add(new AdventureGenerateConditionItem(33, 160771085, forceDisable: false, new List<sbyte> { 3 }, 1, 1, 1, new int[15]
		{
			0, 0, 0, 1, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new int[3] { 1, 0, 0 }, new EMapBlockType[1] { EMapBlockType.Sect }, 3, 21, 183, 343));
		_dataArray.Add(new AdventureGenerateConditionItem(34, 167689626, forceDisable: false, new List<sbyte> { 3 }, 1, 1, 1, new int[15]
		{
			0, 0, 0, 0, 1, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new int[3] { 1, 0, 0 }, new EMapBlockType[1] { EMapBlockType.Sect }, 3, 21, 183, 343));
		_dataArray.Add(new AdventureGenerateConditionItem(35, 195392640, forceDisable: false, new List<sbyte> { 3 }, 1, 1, 1, new int[15]
		{
			0, 0, 0, 0, 0, 1, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new int[3] { 1, 0, 0 }, new EMapBlockType[1] { EMapBlockType.Sect }, 3, 21, 183, 343));
		_dataArray.Add(new AdventureGenerateConditionItem(36, 195785273, forceDisable: false, new List<sbyte> { 3 }, 1, 1, 1, new int[15]
		{
			0, 0, 0, 0, 0, 0, 1, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new int[3] { 1, 0, 0 }, new EMapBlockType[1] { EMapBlockType.Sect }, 3, 21, 183, 343));
		_dataArray.Add(new AdventureGenerateConditionItem(37, 196105066, forceDisable: false, new List<sbyte> { 3 }, 1, 1, 1, new int[15]
		{
			0, 0, 0, 0, 0, 0, 0, 1, 0, 0,
			0, 0, 0, 0, 0
		}, new int[3] { 1, 0, 0 }, new EMapBlockType[1] { EMapBlockType.Sect }, 3, 21, 183, 343));
		_dataArray.Add(new AdventureGenerateConditionItem(38, 196521058, forceDisable: false, new List<sbyte> { 3 }, 1, 1, 1, new int[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 1, 0,
			0, 0, 0, 0, 0
		}, new int[3] { 1, 0, 0 }, new EMapBlockType[1] { EMapBlockType.Sect }, 3, 21, 183, 343));
		_dataArray.Add(new AdventureGenerateConditionItem(39, 197067030, forceDisable: false, new List<sbyte> { 3 }, 1, 1, 1, new int[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
			0, 0, 0, 0, 0
		}, new int[3] { 1, 0, 0 }, new EMapBlockType[1] { EMapBlockType.Sect }, 3, 21, 183, 343));
		_dataArray.Add(new AdventureGenerateConditionItem(40, 197667641, forceDisable: false, new List<sbyte> { 3 }, 1, 1, 1, new int[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			1, 0, 0, 0, 0
		}, new int[3] { 1, 0, 0 }, new EMapBlockType[1] { EMapBlockType.Sect }, 3, 21, 183, 343));
		_dataArray.Add(new AdventureGenerateConditionItem(41, 197997887, forceDisable: false, new List<sbyte> { 3 }, 1, 1, 1, new int[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 1, 0, 0, 0
		}, new int[3] { 1, 0, 0 }, new EMapBlockType[1] { EMapBlockType.Sect }, 3, 21, 183, 343));
		_dataArray.Add(new AdventureGenerateConditionItem(42, 198499621, forceDisable: false, new List<sbyte> { 3 }, 1, 1, 1, new int[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 1, 0, 0
		}, new int[3] { 1, 0, 0 }, new EMapBlockType[1] { EMapBlockType.Sect }, 3, 21, 183, 343));
		_dataArray.Add(new AdventureGenerateConditionItem(43, 198845455, forceDisable: false, new List<sbyte> { 3 }, 1, 1, 1, new int[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 1, 0
		}, new int[3] { 1, 0, 0 }, new EMapBlockType[1] { EMapBlockType.Sect }, 3, 21, 183, 343));
		_dataArray.Add(new AdventureGenerateConditionItem(44, 199144444, forceDisable: false, new List<sbyte> { 3 }, 1, 1, 1, new int[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 1
		}, new int[3] { 1, 0, 0 }, new EMapBlockType[1] { EMapBlockType.Sect }, 3, 21, 183, 343));
		_dataArray.Add(new AdventureGenerateConditionItem(45, 79192151, forceDisable: false, new List<sbyte> { 1 }, 1, 2, 2, new int[15]
		{
			0, 0, 0, 0, 1, 1, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new int[3] { 0, 1, 0 }, new EMapBlockType[1] { EMapBlockType.Developed }, 3, 3, 470, 339));
		_dataArray.Add(new AdventureGenerateConditionItem(46, 138213700, forceDisable: false, new List<sbyte> { 1 }, 1, 2, 2, new int[15]
		{
			1, 0, 0, 0, 0, 0, 0, 0, 1, 0,
			0, 0, 0, 0, 0
		}, new int[3] { 0, 1, 0 }, new EMapBlockType[1] { EMapBlockType.Developed }, 3, 3, 470, 339));
		_dataArray.Add(new AdventureGenerateConditionItem(47, 136028250, forceDisable: false, new List<sbyte> { 1 }, 1, 2, 2, new int[15]
		{
			0, 0, 0, 0, 0, 0, 1, 0, 0, 0,
			0, 1, 0, 0, 0
		}, new int[3] { 0, 1, 0 }, new EMapBlockType[1] { EMapBlockType.Developed }, 3, 3, 470, 339));
		_dataArray.Add(new AdventureGenerateConditionItem(48, 208306838, forceDisable: false, new List<sbyte> { 1 }, 1, 2, 2, new int[15]
		{
			0, 0, 1, 0, 0, 0, 0, 0, 0, 1,
			0, 0, 0, 0, 0
		}, new int[3] { 0, 1, 0 }, new EMapBlockType[1] { EMapBlockType.Developed }, 3, 3, 470, 339));
		_dataArray.Add(new AdventureGenerateConditionItem(49, 215837382, forceDisable: false, new List<sbyte> { 1 }, 1, 2, 2, new int[15]
		{
			0, 0, 0, 0, 0, 0, 0, 1, 0, 0,
			0, 0, 0, 1, 0
		}, new int[3] { 0, 1, 0 }, new EMapBlockType[1] { EMapBlockType.Developed }, 3, 3, 470, 339));
		_dataArray.Add(new AdventureGenerateConditionItem(50, 201143504, forceDisable: false, new List<sbyte> { 1 }, 1, 2, 2, new int[15]
		{
			0, 1, 0, 1, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new int[3] { 0, 1, 0 }, new EMapBlockType[1] { EMapBlockType.Developed }, 3, 3, 470, 339));
		_dataArray.Add(new AdventureGenerateConditionItem(51, 147235164, forceDisable: false, new List<sbyte> { 1 }, 1, 2, 2, new int[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 1, 0, 1
		}, new int[3] { 0, 1, 0 }, new EMapBlockType[1] { EMapBlockType.Developed }, 3, 3, 470, 339));
		_dataArray.Add(new AdventureGenerateConditionItem(52, 234831431, forceDisable: false, new List<sbyte> { 1 }, 1, 15, 15, new int[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new int[3] { 1, 1, 1 }, new EMapBlockType[1] { EMapBlockType.Developed }, 3, 3, 460, -1));
		_dataArray.Add(new AdventureGenerateConditionItem(53, 204473129, forceDisable: false, new List<sbyte> { 1 }, 1, 15, 15, new int[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new int[3] { 1, 1, 1 }, new EMapBlockType[1] { EMapBlockType.Developed }, 3, 3, 460, -1));
		_dataArray.Add(new AdventureGenerateConditionItem(54, 219146022, forceDisable: false, new List<sbyte> { 1 }, 1, 15, 15, new int[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new int[3] { 1, 1, 1 }, new EMapBlockType[1] { EMapBlockType.Developed }, 3, 3, 460, -1));
		_dataArray.Add(new AdventureGenerateConditionItem(55, 203646235, forceDisable: false, new List<sbyte> { 1 }, 1, 15, 15, new int[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new int[3] { 1, 1, 1 }, new EMapBlockType[1] { EMapBlockType.Developed }, 3, 3, 460, -1));
		_dataArray.Add(new AdventureGenerateConditionItem(56, 457682621, forceDisable: false, new List<sbyte> { 1 }, 1, 15, 15, new int[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new int[3] { 1, 1, 1 }, new EMapBlockType[1] { EMapBlockType.Developed }, 3, 3, 460, -1));
		_dataArray.Add(new AdventureGenerateConditionItem(57, 240819632, forceDisable: false, new List<sbyte> { 1 }, 1, 15, 15, new int[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new int[3] { 1, 1, 1 }, new EMapBlockType[1] { EMapBlockType.Developed }, 3, 3, 460, -1));
		_dataArray.Add(new AdventureGenerateConditionItem(58, 155365445, forceDisable: false, new List<sbyte> { 1 }, 1, 15, 15, new int[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new int[3] { 1, 1, 1 }, new EMapBlockType[1] { EMapBlockType.Developed }, 3, 3, 460, -1));
		_dataArray.Add(new AdventureGenerateConditionItem(59, 237866249, forceDisable: false, new List<sbyte> { 4 }, 1, 3, 3, new int[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new int[3] { 0, 1, 0 }, new EMapBlockType[1] { EMapBlockType.Developed }, 3, 3, 132, 340));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new AdventureGenerateConditionItem(60, 248555998, forceDisable: false, new List<sbyte> { 4 }, 1, 3, 3, new int[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new int[3] { 0, 1, 0 }, new EMapBlockType[1] { EMapBlockType.Developed }, 3, 3, 132, 340));
		_dataArray.Add(new AdventureGenerateConditionItem(61, 163293008, forceDisable: false, new List<sbyte> { 4 }, 1, 3, 3, new int[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new int[3] { 0, 1, 0 }, new EMapBlockType[1] { EMapBlockType.Developed }, 3, 3, 132, 340));
		_dataArray.Add(new AdventureGenerateConditionItem(62, 559598543, forceDisable: false, new List<sbyte> { 7 }, 1, 1, 1, new int[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new int[3] { 0, 1, 0 }, new EMapBlockType[1] { EMapBlockType.Developed }, 3, 33, 134, 341));
		_dataArray.Add(new AdventureGenerateConditionItem(63, 220651289, forceDisable: false, new List<sbyte> { 10 }, 1, 3, 3, new int[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new int[3] { 0, 1, 0 }, new EMapBlockType[1] { EMapBlockType.Developed }, 3, 3, 135, 342));
		_dataArray.Add(new AdventureGenerateConditionItem(64, 138832582, forceDisable: false, new List<sbyte> { 10 }, 1, 3, 3, new int[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new int[3] { 0, 1, 0 }, new EMapBlockType[1] { EMapBlockType.Developed }, 3, 3, 135, 342));
		_dataArray.Add(new AdventureGenerateConditionItem(65, 229567807, forceDisable: false, new List<sbyte> { 10 }, 1, 3, 3, new int[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new int[3] { 0, 1, 0 }, new EMapBlockType[1] { EMapBlockType.Developed }, 3, 3, 135, 342));
		_dataArray.Add(new AdventureGenerateConditionItem(66, 199565159, forceDisable: false, new List<sbyte> { 10 }, 1, 3, 3, new int[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new int[3] { 0, 1, 0 }, new EMapBlockType[1] { EMapBlockType.Developed }, 3, 3, 135, 342));
		_dataArray.Add(new AdventureGenerateConditionItem(67, 193578729, forceDisable: false, new List<sbyte> { 0 }, 1, 3, 3, new int[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 2, 0,
			0, 3, 0, 5, 0
		}, new int[3] { 0, 0, 1 }, new EMapBlockType[2]
		{
			EMapBlockType.Normal,
			EMapBlockType.Wild
		}, 3, 3, 461, 467));
		_dataArray.Add(new AdventureGenerateConditionItem(68, 220197686, forceDisable: false, new List<sbyte> { 0 }, 1, 3, 3, new int[15]
		{
			3, 0, 0, 0, 0, 2, 0, 0, 0, 0,
			0, 0, 0, 0, 5
		}, new int[3] { 0, 0, 1 }, new EMapBlockType[2]
		{
			EMapBlockType.Normal,
			EMapBlockType.Wild
		}, 3, 3, 461, 467));
		_dataArray.Add(new AdventureGenerateConditionItem(69, 180900478, forceDisable: false, new List<sbyte> { 2 }, 1, 3, 3, new int[15]
		{
			0, 0, 0, 5, 0, 2, 0, 0, 3, 0,
			0, 0, 0, 0, 0
		}, new int[3] { 0, 0, 1 }, new EMapBlockType[2]
		{
			EMapBlockType.Normal,
			EMapBlockType.Wild
		}, 3, 3, 461, 467));
		_dataArray.Add(new AdventureGenerateConditionItem(70, 143078419, forceDisable: false, new List<sbyte> { 2 }, 1, 3, 3, new int[15]
		{
			0, 0, 0, 0, 0, 0, 5, 0, 0, 0,
			0, 2, 0, 3, 0
		}, new int[3] { 0, 0, 1 }, new EMapBlockType[2]
		{
			EMapBlockType.Normal,
			EMapBlockType.Wild
		}, 3, 3, 461, 467));
		_dataArray.Add(new AdventureGenerateConditionItem(71, 185385626, forceDisable: false, new List<sbyte> { 3 }, 1, 3, 3, new int[15]
		{
			0, 2, 0, 0, 0, 0, 0, 3, 0, 0,
			0, 0, 5, 0, 0
		}, new int[3] { 0, 0, 1 }, new EMapBlockType[2]
		{
			EMapBlockType.Normal,
			EMapBlockType.Wild
		}, 3, 3, 461, 467));
		_dataArray.Add(new AdventureGenerateConditionItem(72, 131586422, forceDisable: false, new List<sbyte> { 3 }, 1, 3, 3, new int[15]
		{
			0, 3, 0, 0, 0, 0, 0, 0, 5, 0,
			0, 0, 0, 0, 0
		}, new int[3] { 0, 0, 1 }, new EMapBlockType[2]
		{
			EMapBlockType.Normal,
			EMapBlockType.Wild
		}, 3, 3, 461, 467));
		_dataArray.Add(new AdventureGenerateConditionItem(73, 211278072, forceDisable: false, new List<sbyte> { 4 }, 1, 3, 3, new int[15]
		{
			0, 0, 2, 0, 0, 0, 0, 3, 0, 0,
			0, 0, 0, 0, 5
		}, new int[3] { 0, 0, 1 }, new EMapBlockType[2]
		{
			EMapBlockType.Normal,
			EMapBlockType.Wild
		}, 3, 3, 461, 467));
		_dataArray.Add(new AdventureGenerateConditionItem(74, 247627268, forceDisable: false, new List<sbyte> { 4 }, 1, 3, 3, new int[15]
		{
			0, 3, 0, 0, 0, 0, 0, 2, 0, 0,
			0, 0, 0, 5, 0
		}, new int[3] { 0, 0, 1 }, new EMapBlockType[2]
		{
			EMapBlockType.Normal,
			EMapBlockType.Wild
		}, 3, 3, 461, 467));
		_dataArray.Add(new AdventureGenerateConditionItem(75, 183412332, forceDisable: false, new List<sbyte> { 5 }, 1, 3, 3, new int[15]
		{
			0, 0, 0, 2, 5, 0, 3, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new int[3] { 0, 0, 1 }, new EMapBlockType[2]
		{
			EMapBlockType.Normal,
			EMapBlockType.Wild
		}, 3, 3, 461, 467));
		_dataArray.Add(new AdventureGenerateConditionItem(76, 204326576, forceDisable: false, new List<sbyte> { 5 }, 1, 3, 3, new int[15]
		{
			0, 0, 3, 0, 0, 0, 0, 0, 0, 2,
			0, 0, 0, 5, 0
		}, new int[3] { 0, 0, 1 }, new EMapBlockType[2]
		{
			EMapBlockType.Normal,
			EMapBlockType.Wild
		}, 3, 3, 461, 467));
		_dataArray.Add(new AdventureGenerateConditionItem(77, 207273516, forceDisable: false, new List<sbyte> { 6 }, 1, 3, 3, new int[15]
		{
			5, 0, 0, 0, 3, 0, 2, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new int[3] { 0, 0, 1 }, new EMapBlockType[2]
		{
			EMapBlockType.Normal,
			EMapBlockType.Wild
		}, 3, 3, 461, 467));
		_dataArray.Add(new AdventureGenerateConditionItem(78, 205870078, forceDisable: false, new List<sbyte> { 6 }, 1, 3, 3, new int[15]
		{
			0, 3, 0, 0, 0, 0, 0, 0, 0, 0,
			2, 5, 0, 0, 0
		}, new int[3] { 0, 0, 1 }, new EMapBlockType[2]
		{
			EMapBlockType.Normal,
			EMapBlockType.Wild
		}, 3, 3, 461, 467));
		_dataArray.Add(new AdventureGenerateConditionItem(79, 233198059, forceDisable: false, new List<sbyte> { 7 }, 1, 3, 3, new int[15]
		{
			0, 0, 0, 2, 3, 0, 5, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new int[3] { 0, 0, 1 }, new EMapBlockType[2]
		{
			EMapBlockType.Normal,
			EMapBlockType.Wild
		}, 3, 3, 461, 467));
		_dataArray.Add(new AdventureGenerateConditionItem(80, 178199098, forceDisable: false, new List<sbyte> { 7 }, 1, 3, 3, new int[15]
		{
			0, 0, 3, 0, 0, 0, 0, 0, 0, 0,
			2, 0, 0, 5, 0
		}, new int[3] { 0, 0, 1 }, new EMapBlockType[2]
		{
			EMapBlockType.Normal,
			EMapBlockType.Wild
		}, 3, 3, 461, 467));
		_dataArray.Add(new AdventureGenerateConditionItem(81, 143672448, forceDisable: false, new List<sbyte> { 8 }, 1, 3, 3, new int[15]
		{
			0, 3, 0, 0, 0, 0, 0, 0, 0, 0,
			2, 5, 0, 0, 0
		}, new int[3] { 0, 0, 1 }, new EMapBlockType[2]
		{
			EMapBlockType.Normal,
			EMapBlockType.Wild
		}, 3, 3, 461, 467));
		_dataArray.Add(new AdventureGenerateConditionItem(82, 222224446, forceDisable: false, new List<sbyte> { 8 }, 1, 3, 3, new int[15]
		{
			0, 0, 0, 0, 2, 0, 0, 0, 0, 5,
			3, 0, 0, 0, 0
		}, new int[3] { 0, 0, 1 }, new EMapBlockType[2]
		{
			EMapBlockType.Normal,
			EMapBlockType.Wild
		}, 3, 3, 461, 467));
		_dataArray.Add(new AdventureGenerateConditionItem(83, 144003422, forceDisable: false, new List<sbyte> { 9 }, 1, 3, 3, new int[15]
		{
			5, 0, 0, 0, 0, 2, 3, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new int[3] { 0, 0, 1 }, new EMapBlockType[2]
		{
			EMapBlockType.Normal,
			EMapBlockType.Wild
		}, 3, 3, 461, 467));
		_dataArray.Add(new AdventureGenerateConditionItem(84, 205458592, forceDisable: false, new List<sbyte> { 9 }, 1, 3, 3, new int[15]
		{
			0, 0, 0, 0, 5, 0, 2, 0, 0, 0,
			0, 3, 0, 0, 0
		}, new int[3] { 0, 0, 1 }, new EMapBlockType[2]
		{
			EMapBlockType.Normal,
			EMapBlockType.Wild
		}, 3, 3, 461, 467));
		_dataArray.Add(new AdventureGenerateConditionItem(85, 137542532, forceDisable: false, new List<sbyte> { 10 }, 1, 3, 3, new int[15]
		{
			5, 0, 0, 0, 3, 0, 0, 0, 0, 2,
			0, 0, 0, 0, 0
		}, new int[3] { 0, 0, 1 }, new EMapBlockType[2]
		{
			EMapBlockType.Normal,
			EMapBlockType.Wild
		}, 3, 3, 461, 467));
		_dataArray.Add(new AdventureGenerateConditionItem(86, 152760008, forceDisable: false, new List<sbyte> { 10 }, 1, 3, 3, new int[15]
		{
			0, 0, 0, 2, 3, 0, 0, 0, 0, 5,
			0, 0, 0, 0, 0
		}, new int[3] { 0, 0, 1 }, new EMapBlockType[2]
		{
			EMapBlockType.Normal,
			EMapBlockType.Wild
		}, 3, 3, 461, 467));
		_dataArray.Add(new AdventureGenerateConditionItem(87, 153656244, forceDisable: false, new List<sbyte> { 11 }, 1, 3, 3, new int[15]
		{
			0, 0, 0, 0, 2, 0, 0, 0, 0, 3,
			5, 0, 0, 0, 0
		}, new int[3] { 0, 0, 1 }, new EMapBlockType[2]
		{
			EMapBlockType.Normal,
			EMapBlockType.Wild
		}, 3, 3, 461, 467));
		_dataArray.Add(new AdventureGenerateConditionItem(88, 190378897, forceDisable: false, new List<sbyte> { 11 }, 1, 3, 3, new int[15]
		{
			0, 0, 0, 2, 0, 3, 0, 0, 5, 0,
			0, 0, 0, 0, 0
		}, new int[3] { 0, 0, 1 }, new EMapBlockType[2]
		{
			EMapBlockType.Normal,
			EMapBlockType.Wild
		}, 3, 3, 461, 467));
		_dataArray.Add(new AdventureGenerateConditionItem(89, 233499641, forceDisable: false, new List<sbyte> { 1 }, 1, 3, 3, new int[15]
		{
			0, 0, 2, 0, 0, 0, 0, 0, 0, 0,
			0, 3, 0, 5, 0
		}, new int[3] { 0, 0, 1 }, new EMapBlockType[2]
		{
			EMapBlockType.Normal,
			EMapBlockType.Wild
		}, 3, 3, 461, 467));
		_dataArray.Add(new AdventureGenerateConditionItem(90, 215076486, forceDisable: false, new List<sbyte> { 1 }, 1, 3, 3, new int[15]
		{
			0, 0, 0, 0, 0, 0, 0, 5, 3, 0,
			0, 0, 0, 0, 2
		}, new int[3] { 0, 0, 1 }, new EMapBlockType[2]
		{
			EMapBlockType.Normal,
			EMapBlockType.Wild
		}, 3, 3, 461, 467));
		_dataArray.Add(new AdventureGenerateConditionItem(91, 230120484, forceDisable: false, new List<sbyte>(), 1, 3, 3, new int[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new int[3] { 0, 1, 0 }, new EMapBlockType[1] { EMapBlockType.Developed }, 3, 9, 139, -1));
		_dataArray.Add(new AdventureGenerateConditionItem(92, 154314652, forceDisable: false, new List<sbyte>(), 1, 3, 3, new int[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new int[3] { 0, 1, 0 }, new EMapBlockType[1] { EMapBlockType.Developed }, 3, 9, 139, -1));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<AdventureGenerateConditionItem>(93);
		CreateItems0();
		CreateItems1();
	}
}

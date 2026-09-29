using System;
using System.Collections.Generic;
using Config.Common;
using Config.ConfigCells.Character;

namespace Config;

[Serializable]
public class SkillBreakPlateGridBonusType : ConfigData<SkillBreakPlateGridBonusTypeItem, short>
{
	public static SkillBreakPlateGridBonusType Instance = new SkillBreakPlateGridBonusType();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "Desc", "ExtraBonusFitCombatSkillTypes", "ExtraBonusFitLifeSkillTypes", "ExtraBonusFitItemSubTypes", "CharacterPropertyBonusList", "CombatSkillPropertyBonusList", "TemplateId" };

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
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(0, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_0"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_0"), isExtraBonus: false, new sbyte[0], new sbyte[0], new short[0], new PropertyAndValue[1]
		{
			new PropertyAndValue(6, 10)
		}, new PropertyAndValue[0], ESkillBreakPlateGridBonusTypeAppearType.Never, -1));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(1, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_1"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_1"), isExtraBonus: false, new sbyte[0], new sbyte[0], new short[0], new PropertyAndValue[1]
		{
			new PropertyAndValue(7, 10)
		}, new PropertyAndValue[0], ESkillBreakPlateGridBonusTypeAppearType.Never, -1));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(2, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_2"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_2"), isExtraBonus: false, new sbyte[0], new sbyte[0], new short[0], new PropertyAndValue[1]
		{
			new PropertyAndValue(8, 10)
		}, new PropertyAndValue[0], ESkillBreakPlateGridBonusTypeAppearType.Never, -1));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(3, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_3"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_3"), isExtraBonus: false, new sbyte[0], new sbyte[0], new short[0], new PropertyAndValue[1]
		{
			new PropertyAndValue(9, 10)
		}, new PropertyAndValue[0], ESkillBreakPlateGridBonusTypeAppearType.Never, -1));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(4, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_4"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_4"), isExtraBonus: false, new sbyte[0], new sbyte[0], new short[0], new PropertyAndValue[1]
		{
			new PropertyAndValue(10, 10)
		}, new PropertyAndValue[0], ESkillBreakPlateGridBonusTypeAppearType.Never, -1));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(5, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_5"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_5"), isExtraBonus: false, new sbyte[0], new sbyte[0], new short[0], new PropertyAndValue[1]
		{
			new PropertyAndValue(11, 10)
		}, new PropertyAndValue[0], ESkillBreakPlateGridBonusTypeAppearType.Never, -1));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(6, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_6"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_6"), isExtraBonus: false, new sbyte[0], new sbyte[0], new short[0], new PropertyAndValue[1]
		{
			new PropertyAndValue(12, 10)
		}, new PropertyAndValue[0], ESkillBreakPlateGridBonusTypeAppearType.Never, -1));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(7, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_7"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_7"), isExtraBonus: false, new sbyte[0], new sbyte[0], new short[0], new PropertyAndValue[1]
		{
			new PropertyAndValue(13, 10)
		}, new PropertyAndValue[0], ESkillBreakPlateGridBonusTypeAppearType.Never, -1));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(8, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_8"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_8"), isExtraBonus: false, new sbyte[0], new sbyte[0], new short[0], new PropertyAndValue[1]
		{
			new PropertyAndValue(14, 10)
		}, new PropertyAndValue[0], ESkillBreakPlateGridBonusTypeAppearType.Never, -1));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(9, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_9"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_9"), isExtraBonus: false, new sbyte[0], new sbyte[0], new short[0], new PropertyAndValue[1]
		{
			new PropertyAndValue(15, 10)
		}, new PropertyAndValue[0], ESkillBreakPlateGridBonusTypeAppearType.Never, -1));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(10, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_10"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_10"), isExtraBonus: false, new sbyte[0], new sbyte[0], new short[0], new PropertyAndValue[1]
		{
			new PropertyAndValue(16, 10)
		}, new PropertyAndValue[0], ESkillBreakPlateGridBonusTypeAppearType.Never, -1));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(11, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_11"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_11"), isExtraBonus: false, new sbyte[0], new sbyte[0], new short[0], new PropertyAndValue[1]
		{
			new PropertyAndValue(17, 10)
		}, new PropertyAndValue[0], ESkillBreakPlateGridBonusTypeAppearType.Never, -1));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(12, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_12"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_12"), isExtraBonus: false, new sbyte[0], new sbyte[0], new short[0], new PropertyAndValue[1]
		{
			new PropertyAndValue(18, 5)
		}, new PropertyAndValue[0], ESkillBreakPlateGridBonusTypeAppearType.Never, -1));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(13, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_13"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_13"), isExtraBonus: false, new sbyte[0], new sbyte[0], new short[0], new PropertyAndValue[1]
		{
			new PropertyAndValue(19, 5)
		}, new PropertyAndValue[0], ESkillBreakPlateGridBonusTypeAppearType.Never, -1));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(14, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_14"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_14"), isExtraBonus: false, new sbyte[0], new sbyte[0], new short[0], new PropertyAndValue[1]
		{
			new PropertyAndValue(20, 5)
		}, new PropertyAndValue[0], ESkillBreakPlateGridBonusTypeAppearType.Never, -1));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(15, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_15"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_15"), isExtraBonus: false, new sbyte[0], new sbyte[0], new short[0], new PropertyAndValue[1]
		{
			new PropertyAndValue(21, 5)
		}, new PropertyAndValue[0], ESkillBreakPlateGridBonusTypeAppearType.Never, -1));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(16, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_16"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_16"), isExtraBonus: false, new sbyte[0], new sbyte[0], new short[0], new PropertyAndValue[1]
		{
			new PropertyAndValue(22, 5)
		}, new PropertyAndValue[0], ESkillBreakPlateGridBonusTypeAppearType.Never, -1));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(17, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_17"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_17"), isExtraBonus: false, new sbyte[0], new sbyte[0], new short[0], new PropertyAndValue[1]
		{
			new PropertyAndValue(23, 5)
		}, new PropertyAndValue[0], ESkillBreakPlateGridBonusTypeAppearType.Never, -1));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(18, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_18"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_18"), isExtraBonus: false, new sbyte[0], new sbyte[0], new short[0], new PropertyAndValue[1]
		{
			new PropertyAndValue(24, 5)
		}, new PropertyAndValue[0], ESkillBreakPlateGridBonusTypeAppearType.Never, -1));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(19, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_19"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_19"), isExtraBonus: false, new sbyte[0], new sbyte[0], new short[0], new PropertyAndValue[1]
		{
			new PropertyAndValue(25, 5)
		}, new PropertyAndValue[0], ESkillBreakPlateGridBonusTypeAppearType.Never, -1));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(20, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_20"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_20"), isExtraBonus: false, new sbyte[0], new sbyte[0], new short[0], new PropertyAndValue[1]
		{
			new PropertyAndValue(26, 5)
		}, new PropertyAndValue[0], ESkillBreakPlateGridBonusTypeAppearType.Never, -1));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(21, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_21"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_21"), isExtraBonus: false, new sbyte[0], new sbyte[0], new short[0], new PropertyAndValue[1]
		{
			new PropertyAndValue(27, 5)
		}, new PropertyAndValue[0], ESkillBreakPlateGridBonusTypeAppearType.Never, -1));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(22, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_22"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_22"), isExtraBonus: false, new sbyte[0], new sbyte[0], new short[0], new PropertyAndValue[1]
		{
			new PropertyAndValue(28, 3)
		}, new PropertyAndValue[0], ESkillBreakPlateGridBonusTypeAppearType.Never, -1));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(23, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_23"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_23"), isExtraBonus: false, new sbyte[0], new sbyte[0], new short[0], new PropertyAndValue[1]
		{
			new PropertyAndValue(29, 3)
		}, new PropertyAndValue[0], ESkillBreakPlateGridBonusTypeAppearType.Never, -1));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(24, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_24"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_24"), isExtraBonus: false, new sbyte[0], new sbyte[0], new short[0], new PropertyAndValue[1]
		{
			new PropertyAndValue(30, 3)
		}, new PropertyAndValue[0], ESkillBreakPlateGridBonusTypeAppearType.Never, -1));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(25, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_25"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_25"), isExtraBonus: false, new sbyte[0], new sbyte[0], new short[0], new PropertyAndValue[1]
		{
			new PropertyAndValue(31, 3)
		}, new PropertyAndValue[0], ESkillBreakPlateGridBonusTypeAppearType.Never, -1));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(26, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_26"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_26"), isExtraBonus: false, new sbyte[0], new sbyte[0], new short[0], new PropertyAndValue[1]
		{
			new PropertyAndValue(32, 3)
		}, new PropertyAndValue[0], ESkillBreakPlateGridBonusTypeAppearType.Never, -1));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(27, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_27"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_27"), isExtraBonus: false, new sbyte[0], new sbyte[0], new short[0], new PropertyAndValue[1]
		{
			new PropertyAndValue(33, 3)
		}, new PropertyAndValue[0], ESkillBreakPlateGridBonusTypeAppearType.Never, -1));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(28, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_28"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_28"), isExtraBonus: true, new sbyte[1], new sbyte[0], new short[0], new PropertyAndValue[1]
		{
			new PropertyAndValue(101, 50)
		}, new PropertyAndValue[0], ESkillBreakPlateGridBonusTypeAppearType.NeigongAndPassiveSkill, 1));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(29, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_29"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_29"), isExtraBonus: true, new sbyte[1], new sbyte[0], new short[0], new PropertyAndValue[1]
		{
			new PropertyAndValue(102, 20)
		}, new PropertyAndValue[0], ESkillBreakPlateGridBonusTypeAppearType.NeigongAndPassiveSkill, 1));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(30, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_30"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_30"), isExtraBonus: false, new sbyte[0], new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[1]
		{
			new PropertyAndValue(0, 5)
		}, ESkillBreakPlateGridBonusTypeAppearType.Never, -1));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(31, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_31"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_31"), isExtraBonus: false, new sbyte[0], new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[1]
		{
			new PropertyAndValue(1, 10)
		}, ESkillBreakPlateGridBonusTypeAppearType.Never, -1));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(32, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_32"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_32"), isExtraBonus: false, new sbyte[0], new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[1]
		{
			new PropertyAndValue(2, -10)
		}, ESkillBreakPlateGridBonusTypeAppearType.Never, -1));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(33, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_33"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_33"), isExtraBonus: false, new sbyte[0], new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[1]
		{
			new PropertyAndValue(3, -5)
		}, ESkillBreakPlateGridBonusTypeAppearType.Never, -1));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(34, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_34"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_34"), isExtraBonus: true, new sbyte[1], new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[1]
		{
			new PropertyAndValue(4, 10)
		}, ESkillBreakPlateGridBonusTypeAppearType.NeigongAndPassiveSkillExclude, 0));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(35, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_35"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_35"), isExtraBonus: true, new sbyte[1], new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[1]
		{
			new PropertyAndValue(5, 5)
		}, ESkillBreakPlateGridBonusTypeAppearType.NeigongAndPassiveSkillExclude, 0));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(36, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_36"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_36"), isExtraBonus: false, new sbyte[0], new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[1]
		{
			new PropertyAndValue(6, 30)
		}, ESkillBreakPlateGridBonusTypeAppearType.Never, -1));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(37, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_37"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_37"), isExtraBonus: false, new sbyte[0], new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[1]
		{
			new PropertyAndValue(7, 3)
		}, ESkillBreakPlateGridBonusTypeAppearType.Never, -1));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(38, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_38"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_38"), isExtraBonus: true, new sbyte[1], new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[1]
		{
			new PropertyAndValue(8, 1)
		}, ESkillBreakPlateGridBonusTypeAppearType.NeigongOnlyExcludeMix, 1));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(39, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_39"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_39"), isExtraBonus: false, new sbyte[0], new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[1]
		{
			new PropertyAndValue(9, 1)
		}, ESkillBreakPlateGridBonusTypeAppearType.Never, -1));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(40, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_40"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_40"), isExtraBonus: false, new sbyte[0], new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[1]
		{
			new PropertyAndValue(10, -3)
		}, ESkillBreakPlateGridBonusTypeAppearType.Never, -1));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(41, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_41"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_41"), isExtraBonus: false, new sbyte[0], new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[1]
		{
			new PropertyAndValue(11, 10)
		}, ESkillBreakPlateGridBonusTypeAppearType.Never, -1));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(42, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_42"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_42"), isExtraBonus: true, new sbyte[1] { 1 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[2]
		{
			new PropertyAndValue(12, 15),
			new PropertyAndValue(10, 5)
		}, ESkillBreakPlateGridBonusTypeAppearType.PosingAndStrength, 3));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(43, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_43"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_43"), isExtraBonus: true, new sbyte[1] { 1 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[2]
		{
			new PropertyAndValue(13, 15),
			new PropertyAndValue(10, 5)
		}, ESkillBreakPlateGridBonusTypeAppearType.PosingAndTechnique, 3));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(44, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_44"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_44"), isExtraBonus: true, new sbyte[1] { 1 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[2]
		{
			new PropertyAndValue(14, 15),
			new PropertyAndValue(10, 5)
		}, ESkillBreakPlateGridBonusTypeAppearType.PosingAndSpeed, 3));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(45, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_45"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_45"), isExtraBonus: true, new sbyte[1] { 1 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[2]
		{
			new PropertyAndValue(15, 15),
			new PropertyAndValue(10, 5)
		}, ESkillBreakPlateGridBonusTypeAppearType.PosingAndMind, 3));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(46, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_46"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_46"), isExtraBonus: true, new sbyte[1] { 1 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[1]
		{
			new PropertyAndValue(16, -15)
		}, ESkillBreakPlateGridBonusTypeAppearType.PosingAndSpeedCost, 3));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(47, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_47"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_47"), isExtraBonus: true, new sbyte[1] { 1 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[1]
		{
			new PropertyAndValue(17, -15)
		}, ESkillBreakPlateGridBonusTypeAppearType.PosingAndMoveCost, 3));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(48, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_48"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_48"), isExtraBonus: true, new sbyte[1] { 2 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[2]
		{
			new PropertyAndValue(18, 15),
			new PropertyAndValue(3, 10)
		}, ESkillBreakPlateGridBonusTypeAppearType.DefendSkillAndOuterDef, 4));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(49, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_49"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_49"), isExtraBonus: true, new sbyte[1] { 2 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[2]
		{
			new PropertyAndValue(19, 15),
			new PropertyAndValue(3, 10)
		}, ESkillBreakPlateGridBonusTypeAppearType.DefendSkillAndInnerDef, 4));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(50, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_50"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_50"), isExtraBonus: true, new sbyte[1] { 2 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[2]
		{
			new PropertyAndValue(20, 15),
			new PropertyAndValue(3, 10)
		}, ESkillBreakPlateGridBonusTypeAppearType.DefendSkillAndAvoidStrength, 4));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(51, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_51"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_51"), isExtraBonus: true, new sbyte[1] { 2 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[2]
		{
			new PropertyAndValue(21, 15),
			new PropertyAndValue(3, 10)
		}, ESkillBreakPlateGridBonusTypeAppearType.DefendSkillAndAvoidTechnique, 4));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(52, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_52"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_52"), isExtraBonus: true, new sbyte[1] { 2 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[2]
		{
			new PropertyAndValue(22, 15),
			new PropertyAndValue(3, 10)
		}, ESkillBreakPlateGridBonusTypeAppearType.DefendSkillAndAvoidSpeed, 4));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(53, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_53"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_53"), isExtraBonus: true, new sbyte[1] { 2 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[2]
		{
			new PropertyAndValue(23, 15),
			new PropertyAndValue(3, 10)
		}, ESkillBreakPlateGridBonusTypeAppearType.DefendSkillAndAvoidMind, 4));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(54, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_54"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_54"), isExtraBonus: true, new sbyte[1] { 2 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[2]
		{
			new PropertyAndValue(24, 15),
			new PropertyAndValue(3, 10)
		}, ESkillBreakPlateGridBonusTypeAppearType.DefendSkillAndFightbackPower, 4));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(55, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_55"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_55"), isExtraBonus: true, new sbyte[1] { 2 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[2]
		{
			new PropertyAndValue(25, 15),
			new PropertyAndValue(3, 10)
		}, ESkillBreakPlateGridBonusTypeAppearType.DefendSkillAndBouncePowerOuter, 4));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(56, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_56"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_56"), isExtraBonus: true, new sbyte[1] { 2 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[2]
		{
			new PropertyAndValue(26, 15),
			new PropertyAndValue(3, 10)
		}, ESkillBreakPlateGridBonusTypeAppearType.DefendSkillAndBouncePowerInner, 4));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(57, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_57"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_57"), isExtraBonus: true, new sbyte[1] { 2 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[2]
		{
			new PropertyAndValue(27, 5),
			new PropertyAndValue(3, 10)
		}, ESkillBreakPlateGridBonusTypeAppearType.DefendSkillAndBounceDistance, 4));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(58, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_58"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_58"), isExtraBonus: true, new sbyte[1] { 2 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[2]
		{
			new PropertyAndValue(28, 25),
			new PropertyAndValue(3, 10)
		}, ESkillBreakPlateGridBonusTypeAppearType.DefendSkillOnly, 4));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(59, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_59"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_59"), isExtraBonus: false, new sbyte[0], new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[1]
		{
			new PropertyAndValue(29, 10)
		}, ESkillBreakPlateGridBonusTypeAppearType.Never, -1));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(60, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_60"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_60"), isExtraBonus: false, new sbyte[0], new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[1]
		{
			new PropertyAndValue(30, 10)
		}, ESkillBreakPlateGridBonusTypeAppearType.Never, -1));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(61, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_61"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_61"), isExtraBonus: true, new sbyte[1] { 8 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[3]
		{
			new PropertyAndValue(31, 10),
			new PropertyAndValue(32, -10),
			new PropertyAndValue(30, -20)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndTechniqueHitDistribution, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(62, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_62"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_62"), isExtraBonus: true, new sbyte[1] { 3 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[3]
		{
			new PropertyAndValue(31, 10),
			new PropertyAndValue(33, -10),
			new PropertyAndValue(30, -20)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndSpeedHitDistribution, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(63, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_63"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_63"), isExtraBonus: true, new sbyte[1] { 4 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[3]
		{
			new PropertyAndValue(32, 10),
			new PropertyAndValue(31, -10),
			new PropertyAndValue(30, -20)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndStrengthHitDistribution, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(64, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_64"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_64"), isExtraBonus: true, new sbyte[1] { 9 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[3]
		{
			new PropertyAndValue(32, 10),
			new PropertyAndValue(33, -10),
			new PropertyAndValue(30, -20)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndSpeedHitDistribution, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(65, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_65"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_65"), isExtraBonus: true, new sbyte[1] { 7 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[3]
		{
			new PropertyAndValue(33, 10),
			new PropertyAndValue(31, -10),
			new PropertyAndValue(30, -20)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndStrengthHitDistribution, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(66, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_66"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_66"), isExtraBonus: true, new sbyte[1] { 6 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[3]
		{
			new PropertyAndValue(33, 10),
			new PropertyAndValue(32, -10),
			new PropertyAndValue(30, -20)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndTechniqueHitDistribution, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(67, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_67"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_67"), isExtraBonus: true, new sbyte[1] { 5 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[2]
		{
			new PropertyAndValue(34, 5),
			new PropertyAndValue(29, -20)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillOnly, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(68, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_68"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_68"), isExtraBonus: true, new sbyte[1] { 3 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[2]
		{
			new PropertyAndValue(35, 300),
			new PropertyAndValue(34, -5)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndHitChest, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(69, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_69"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_69"), isExtraBonus: true, new sbyte[1] { 4 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[2]
		{
			new PropertyAndValue(36, 300),
			new PropertyAndValue(34, -5)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndHitBelly, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(70, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_70"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_70"), isExtraBonus: true, new sbyte[1] { 7 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[2]
		{
			new PropertyAndValue(37, 3000),
			new PropertyAndValue(34, -5)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndHitHead, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(71, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_71"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_71"), isExtraBonus: true, new sbyte[1] { 9 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[2]
		{
			new PropertyAndValue(38, 300),
			new PropertyAndValue(34, -5)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndHitBothHands, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(72, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_72"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_72"), isExtraBonus: true, new sbyte[1] { 8 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[2]
		{
			new PropertyAndValue(39, 300),
			new PropertyAndValue(34, -5)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndHitBothLegs, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(73, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_73"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_73"), isExtraBonus: true, new sbyte[1] { 4 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[2]
		{
			new PropertyAndValue(40, 1),
			new PropertyAndValue(2, 25)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndHasAtkAcupointEffect, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(74, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_74"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_74"), isExtraBonus: true, new sbyte[1] { 3 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[2]
		{
			new PropertyAndValue(41, 1),
			new PropertyAndValue(2, 25)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndHasAtkFlawEffect, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(75, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_75"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_75"), isExtraBonus: true, new sbyte[0], new sbyte[1] { 9 }, new short[0], new PropertyAndValue[1]
		{
			new PropertyAndValue(28, -100)
		}, new PropertyAndValue[1]
		{
			new PropertyAndValue(42, 50)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndHotPoison, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(76, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_76"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_76"), isExtraBonus: true, new sbyte[0], new sbyte[1] { 9 }, new short[0], new PropertyAndValue[1]
		{
			new PropertyAndValue(29, -100)
		}, new PropertyAndValue[1]
		{
			new PropertyAndValue(43, 50)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndGloomyPoison, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(77, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_77"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_77"), isExtraBonus: true, new sbyte[0], new sbyte[1] { 9 }, new short[0], new PropertyAndValue[1]
		{
			new PropertyAndValue(30, -100)
		}, new PropertyAndValue[1]
		{
			new PropertyAndValue(44, 50)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndColdPoison, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(78, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_78"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_78"), isExtraBonus: true, new sbyte[0], new sbyte[1] { 9 }, new short[0], new PropertyAndValue[1]
		{
			new PropertyAndValue(31, -100)
		}, new PropertyAndValue[1]
		{
			new PropertyAndValue(45, 50)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndRedPoison, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(79, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_79"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_79"), isExtraBonus: true, new sbyte[0], new sbyte[1] { 9 }, new short[0], new PropertyAndValue[1]
		{
			new PropertyAndValue(32, -100)
		}, new PropertyAndValue[1]
		{
			new PropertyAndValue(46, 50)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndRottenPoison, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(80, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_80"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_80"), isExtraBonus: true, new sbyte[0], new sbyte[1] { 9 }, new short[0], new PropertyAndValue[1]
		{
			new PropertyAndValue(33, -100)
		}, new PropertyAndValue[1]
		{
			new PropertyAndValue(47, 50)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndIllusoryPoison, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(81, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_81"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_81"), isExtraBonus: true, new sbyte[1] { 2 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[1]
		{
			new PropertyAndValue(48, -10)
		}, ESkillBreakPlateGridBonusTypeAppearType.NoLimit, 0));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(82, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_82"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_82"), isExtraBonus: true, new sbyte[1], new sbyte[0], new short[0], new PropertyAndValue[2]
		{
			new PropertyAndValue(18, -25),
			new PropertyAndValue(19, -25)
		}, new PropertyAndValue[1]
		{
			new PropertyAndValue(49, 1)
		}, ESkillBreakPlateGridBonusTypeAppearType.NeigongOnly, 1));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(83, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_83"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_83"), isExtraBonus: true, new sbyte[1], new sbyte[0], new short[0], new PropertyAndValue[2]
		{
			new PropertyAndValue(20, -25),
			new PropertyAndValue(21, -25)
		}, new PropertyAndValue[1]
		{
			new PropertyAndValue(50, 1)
		}, ESkillBreakPlateGridBonusTypeAppearType.NeigongOnly, 1));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(84, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_84"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_84"), isExtraBonus: true, new sbyte[1], new sbyte[0], new short[0], new PropertyAndValue[2]
		{
			new PropertyAndValue(24, -25),
			new PropertyAndValue(25, -25)
		}, new PropertyAndValue[1]
		{
			new PropertyAndValue(51, 1)
		}, ESkillBreakPlateGridBonusTypeAppearType.NeigongOnly, 1));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(85, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_85"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_85"), isExtraBonus: true, new sbyte[1], new sbyte[0], new short[0], new PropertyAndValue[2]
		{
			new PropertyAndValue(22, -25),
			new PropertyAndValue(23, -25)
		}, new PropertyAndValue[1]
		{
			new PropertyAndValue(52, 1)
		}, ESkillBreakPlateGridBonusTypeAppearType.NeigongOnly, 1));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(86, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_86"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_86"), isExtraBonus: true, new sbyte[1] { 6 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[3]
		{
			new PropertyAndValue(53, -1),
			new PropertyAndValue(70, 33),
			new PropertyAndValue(71, 600)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndTrickCost, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(87, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_87"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_87"), isExtraBonus: true, new sbyte[1] { 6 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[3]
		{
			new PropertyAndValue(54, -1),
			new PropertyAndValue(70, 33),
			new PropertyAndValue(71, 600)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndTrickCost, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(88, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_88"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_88"), isExtraBonus: true, new sbyte[1] { 6 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[3]
		{
			new PropertyAndValue(55, -1),
			new PropertyAndValue(70, 33),
			new PropertyAndValue(71, 600)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndTrickCost, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(89, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_89"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_89"), isExtraBonus: true, new sbyte[3] { 8, 7, 9 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[3]
		{
			new PropertyAndValue(56, -1),
			new PropertyAndValue(70, 33),
			new PropertyAndValue(71, 600)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndTrickCost, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(90, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_90"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_90"), isExtraBonus: true, new sbyte[3] { 8, 7, 9 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[3]
		{
			new PropertyAndValue(57, -1),
			new PropertyAndValue(70, 33),
			new PropertyAndValue(71, 600)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndTrickCost, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(91, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_91"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_91"), isExtraBonus: true, new sbyte[3] { 8, 7, 9 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[3]
		{
			new PropertyAndValue(58, -1),
			new PropertyAndValue(70, 33),
			new PropertyAndValue(71, 600)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndTrickCost, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(92, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_92"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_92"), isExtraBonus: true, new sbyte[2] { 3, 4 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[3]
		{
			new PropertyAndValue(59, -1),
			new PropertyAndValue(70, 33),
			new PropertyAndValue(71, 600)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndTrickCost, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(93, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_93"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_93"), isExtraBonus: true, new sbyte[2] { 3, 4 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[3]
		{
			new PropertyAndValue(60, -1),
			new PropertyAndValue(70, 33),
			new PropertyAndValue(71, 600)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndTrickCost, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(94, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_94"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_94"), isExtraBonus: true, new sbyte[2] { 3, 4 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[3]
		{
			new PropertyAndValue(61, -1),
			new PropertyAndValue(70, 33),
			new PropertyAndValue(71, 600)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndTrickCost, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(95, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_95"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_95"), isExtraBonus: true, new sbyte[1] { 13 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[3]
		{
			new PropertyAndValue(62, -1),
			new PropertyAndValue(70, 33),
			new PropertyAndValue(71, 600)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndTrickCost, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(96, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_96"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_96"), isExtraBonus: true, new sbyte[1] { 11 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[3]
		{
			new PropertyAndValue(63, -1),
			new PropertyAndValue(70, 33),
			new PropertyAndValue(71, 600)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndTrickCost, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(97, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_97"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_97"), isExtraBonus: true, new sbyte[1] { 10 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[3]
		{
			new PropertyAndValue(64, -1),
			new PropertyAndValue(70, 33),
			new PropertyAndValue(71, 600)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndTrickCost, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(98, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_98"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_98"), isExtraBonus: true, new sbyte[1] { 12 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[3]
		{
			new PropertyAndValue(65, -1),
			new PropertyAndValue(70, 33),
			new PropertyAndValue(71, 600)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndTrickCost, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(99, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_99"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_99"), isExtraBonus: true, new sbyte[0], new sbyte[1] { 8 }, new short[0], new PropertyAndValue[0], new PropertyAndValue[3]
		{
			new PropertyAndValue(66, -1),
			new PropertyAndValue(70, 33),
			new PropertyAndValue(71, 600)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndTrickCost, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(100, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_100"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_100"), isExtraBonus: true, new sbyte[0], new sbyte[1] { 9 }, new short[0], new PropertyAndValue[0], new PropertyAndValue[3]
		{
			new PropertyAndValue(67, -1),
			new PropertyAndValue(70, 33),
			new PropertyAndValue(71, 600)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndTrickCost, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(101, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_101"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_101"), isExtraBonus: true, new sbyte[1] { 11 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[3]
		{
			new PropertyAndValue(68, -1),
			new PropertyAndValue(70, 33),
			new PropertyAndValue(71, 600)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndTrickCost, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(102, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_102"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_102"), isExtraBonus: true, new sbyte[1] { 1 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[1]
		{
			new PropertyAndValue(69, 20)
		}, ESkillBreakPlateGridBonusTypeAppearType.PosingAndJumpPrepareFrame, 3));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(103, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_103"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_103"), isExtraBonus: true, new sbyte[1] { 6 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[3]
		{
			new PropertyAndValue(53, 1),
			new PropertyAndValue(29, 20),
			new PropertyAndValue(72, 100)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndTrickCostExist, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(104, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_104"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_104"), isExtraBonus: true, new sbyte[1] { 6 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[3]
		{
			new PropertyAndValue(54, 1),
			new PropertyAndValue(29, 20),
			new PropertyAndValue(72, 100)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndTrickCostExist, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(105, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_105"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_105"), isExtraBonus: true, new sbyte[1] { 6 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[3]
		{
			new PropertyAndValue(55, 1),
			new PropertyAndValue(29, 20),
			new PropertyAndValue(72, 100)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndTrickCostExist, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(106, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_106"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_106"), isExtraBonus: true, new sbyte[3] { 8, 7, 9 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[3]
		{
			new PropertyAndValue(56, 1),
			new PropertyAndValue(29, 20),
			new PropertyAndValue(72, 100)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndTrickCostExist, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(107, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_107"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_107"), isExtraBonus: true, new sbyte[3] { 8, 7, 9 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[3]
		{
			new PropertyAndValue(57, 1),
			new PropertyAndValue(29, 20),
			new PropertyAndValue(72, 100)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndTrickCostExist, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(108, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_108"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_108"), isExtraBonus: true, new sbyte[3] { 8, 7, 9 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[3]
		{
			new PropertyAndValue(58, 1),
			new PropertyAndValue(29, 20),
			new PropertyAndValue(72, 100)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndTrickCostExist, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(109, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_109"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_109"), isExtraBonus: true, new sbyte[2] { 3, 4 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[3]
		{
			new PropertyAndValue(59, 1),
			new PropertyAndValue(29, 20),
			new PropertyAndValue(72, 100)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndTrickCostExist, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(110, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_110"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_110"), isExtraBonus: true, new sbyte[2] { 3, 4 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[3]
		{
			new PropertyAndValue(60, 1),
			new PropertyAndValue(29, 20),
			new PropertyAndValue(72, 100)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndTrickCostExist, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(111, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_111"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_111"), isExtraBonus: true, new sbyte[2] { 3, 4 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[3]
		{
			new PropertyAndValue(61, 1),
			new PropertyAndValue(29, 20),
			new PropertyAndValue(72, 100)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndTrickCostExist, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(112, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_112"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_112"), isExtraBonus: true, new sbyte[1] { 11 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[3]
		{
			new PropertyAndValue(63, 1),
			new PropertyAndValue(29, 20),
			new PropertyAndValue(72, 100)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndTrickCostExist, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(113, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_113"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_113"), isExtraBonus: true, new sbyte[1] { 12 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[3]
		{
			new PropertyAndValue(65, 1),
			new PropertyAndValue(29, 20),
			new PropertyAndValue(72, 100)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndTrickCostExist, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(114, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_114"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_114"), isExtraBonus: true, new sbyte[0], new sbyte[1] { 8 }, new short[0], new PropertyAndValue[0], new PropertyAndValue[3]
		{
			new PropertyAndValue(66, 1),
			new PropertyAndValue(29, 20),
			new PropertyAndValue(72, 100)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndTrickCostExist, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(115, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_115"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_115"), isExtraBonus: true, new sbyte[0], new sbyte[1] { 9 }, new short[0], new PropertyAndValue[0], new PropertyAndValue[3]
		{
			new PropertyAndValue(67, 1),
			new PropertyAndValue(29, 20),
			new PropertyAndValue(72, 100)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndTrickCostExist, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(116, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_116"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_116"), isExtraBonus: true, new sbyte[1] { 11 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[3]
		{
			new PropertyAndValue(68, 1),
			new PropertyAndValue(29, 20),
			new PropertyAndValue(72, 100)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndTrickCostExist, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(117, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_117"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_117"), isExtraBonus: true, new sbyte[1] { 6 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[3]
		{
			new PropertyAndValue(53, 1),
			new PropertyAndValue(30, 20),
			new PropertyAndValue(73, 25)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndTrickCostExist, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(118, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_118"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_118"), isExtraBonus: true, new sbyte[1] { 6 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[3]
		{
			new PropertyAndValue(54, 1),
			new PropertyAndValue(30, 20),
			new PropertyAndValue(73, 25)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndTrickCostExist, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(119, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_119"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_119"), isExtraBonus: true, new sbyte[1] { 6 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[3]
		{
			new PropertyAndValue(55, 1),
			new PropertyAndValue(30, 20),
			new PropertyAndValue(73, 25)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndTrickCostExist, 2));
	}

	private void CreateItems2()
	{
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(120, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_120"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_120"), isExtraBonus: true, new sbyte[3] { 8, 7, 9 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[3]
		{
			new PropertyAndValue(56, 1),
			new PropertyAndValue(30, 20),
			new PropertyAndValue(73, 25)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndTrickCostExist, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(121, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_121"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_121"), isExtraBonus: true, new sbyte[3] { 8, 7, 9 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[3]
		{
			new PropertyAndValue(57, 1),
			new PropertyAndValue(30, 20),
			new PropertyAndValue(73, 25)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndTrickCostExist, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(122, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_122"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_122"), isExtraBonus: true, new sbyte[3] { 8, 7, 9 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[3]
		{
			new PropertyAndValue(58, 1),
			new PropertyAndValue(30, 20),
			new PropertyAndValue(73, 25)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndTrickCostExist, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(123, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_123"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_123"), isExtraBonus: true, new sbyte[2] { 3, 4 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[3]
		{
			new PropertyAndValue(59, 1),
			new PropertyAndValue(30, 20),
			new PropertyAndValue(73, 25)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndTrickCostExist, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(124, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_124"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_124"), isExtraBonus: true, new sbyte[2] { 3, 4 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[3]
		{
			new PropertyAndValue(60, 1),
			new PropertyAndValue(30, 20),
			new PropertyAndValue(73, 25)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndTrickCostExist, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(125, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_125"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_125"), isExtraBonus: true, new sbyte[2] { 3, 4 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[3]
		{
			new PropertyAndValue(61, 1),
			new PropertyAndValue(30, 20),
			new PropertyAndValue(73, 25)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndTrickCostExist, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(126, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_126"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_126"), isExtraBonus: true, new sbyte[1] { 13 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[3]
		{
			new PropertyAndValue(62, 1),
			new PropertyAndValue(30, 20),
			new PropertyAndValue(73, 50)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndTrickCostExist, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(127, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_127"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_127"), isExtraBonus: true, new sbyte[1] { 11 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[3]
		{
			new PropertyAndValue(63, 1),
			new PropertyAndValue(30, 20),
			new PropertyAndValue(73, 25)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndTrickCostExist, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(128, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_128"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_128"), isExtraBonus: true, new sbyte[1] { 10 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[3]
		{
			new PropertyAndValue(64, 1),
			new PropertyAndValue(30, 20),
			new PropertyAndValue(73, 50)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndTrickCostExist, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(129, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_129"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_129"), isExtraBonus: true, new sbyte[1] { 12 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[3]
		{
			new PropertyAndValue(65, 1),
			new PropertyAndValue(30, 20),
			new PropertyAndValue(73, 25)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndTrickCostExist, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(130, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_130"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_130"), isExtraBonus: true, new sbyte[0], new sbyte[1] { 8 }, new short[0], new PropertyAndValue[0], new PropertyAndValue[3]
		{
			new PropertyAndValue(66, 1),
			new PropertyAndValue(30, 20),
			new PropertyAndValue(73, 25)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndTrickCostExist, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(131, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_131"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_131"), isExtraBonus: true, new sbyte[0], new sbyte[1] { 9 }, new short[0], new PropertyAndValue[0], new PropertyAndValue[3]
		{
			new PropertyAndValue(67, 1),
			new PropertyAndValue(30, 20),
			new PropertyAndValue(73, 25)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndTrickCostExist, 2));
		_dataArray.Add(new SkillBreakPlateGridBonusTypeItem(132, LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Name_132"), LocalStringManager.GetConfig("SkillBreakPlateGridBonusType_language", "Desc_132"), isExtraBonus: true, new sbyte[1] { 11 }, new sbyte[0], new short[0], new PropertyAndValue[0], new PropertyAndValue[3]
		{
			new PropertyAndValue(68, 1),
			new PropertyAndValue(30, 20),
			new PropertyAndValue(73, 25)
		}, ESkillBreakPlateGridBonusTypeAppearType.AttackSkillAndTrickCostExist, 2));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<SkillBreakPlateGridBonusTypeItem>(133);
		CreateItems0();
		CreateItems1();
		CreateItems2();
	}
}

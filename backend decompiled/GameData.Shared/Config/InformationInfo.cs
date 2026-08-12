using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class InformationInfo : ConfigData<InformationInfoItem, short>
{
	/// <summary>
	/// 配置表实例
	/// </summary>
	public static InformationInfo Instance = new InformationInfo();

	private readonly HashSet<string> RequiredFields = new HashSet<string>
	{
		"Name", "Oraganization", "LifeSkillType", "WesternRegionId", "SwordTombTemplateId", "Profession", "Desc", "EffectiveAnswer", "NormalAnswer", "InvalidAnswer",
		"BehaviorTypePlaceHolders", "SwordTombPlaceHolder", "TemplateId", "Grade"
	};

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
		_dataArray.Add(new InformationInfoItem(0, LocalStringManager.GetConfig("InformationInfo_language", "Name_0"), 0, 21, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_0"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_0"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_0"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_0"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_0_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_0_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_0_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_0_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_0_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_0")));
		_dataArray.Add(new InformationInfoItem(1, LocalStringManager.GetConfig("InformationInfo_language", "Name_1"), 1, 21, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_1"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_1"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_1"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_1"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_1_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_1_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_1_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_1_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_1_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_1")));
		_dataArray.Add(new InformationInfoItem(2, LocalStringManager.GetConfig("InformationInfo_language", "Name_2"), 2, 21, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_2"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_2"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_2"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_2"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_2_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_2_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_2_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_2_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_2_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_2")));
		_dataArray.Add(new InformationInfoItem(3, LocalStringManager.GetConfig("InformationInfo_language", "Name_3"), 3, 21, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_3"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_3"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_3"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_3"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_3_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_3_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_3_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_3_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_3_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_3")));
		_dataArray.Add(new InformationInfoItem(4, LocalStringManager.GetConfig("InformationInfo_language", "Name_4"), 4, 21, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_4"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_4"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_4"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_4"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_4_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_4_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_4_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_4_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_4_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_4")));
		_dataArray.Add(new InformationInfoItem(5, LocalStringManager.GetConfig("InformationInfo_language", "Name_5"), 5, 21, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_5"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_5"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_5"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_5"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_5_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_5_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_5_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_5_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_5_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_5")));
		_dataArray.Add(new InformationInfoItem(6, LocalStringManager.GetConfig("InformationInfo_language", "Name_6"), 6, 21, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_6"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_6"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_6"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_6"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_6_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_6_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_6_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_6_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_6_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_6")));
		_dataArray.Add(new InformationInfoItem(7, LocalStringManager.GetConfig("InformationInfo_language", "Name_7"), 7, 21, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_7"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_7"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_7"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_7"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_7_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_7_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_7_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_7_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_7_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_7")));
		_dataArray.Add(new InformationInfoItem(8, LocalStringManager.GetConfig("InformationInfo_language", "Name_8"), 8, 21, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_8"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_8"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_8"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_8"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_8_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_8_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_8_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_8_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_8_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_8")));
		_dataArray.Add(new InformationInfoItem(9, LocalStringManager.GetConfig("InformationInfo_language", "Name_9"), 0, 22, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_9"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_9"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_9"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_9"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_9_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_9_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_9_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_9_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_9_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_9")));
		_dataArray.Add(new InformationInfoItem(10, LocalStringManager.GetConfig("InformationInfo_language", "Name_10"), 1, 22, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_10"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_10"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_10"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_10"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_10_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_10_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_10_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_10_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_10_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_10")));
		_dataArray.Add(new InformationInfoItem(11, LocalStringManager.GetConfig("InformationInfo_language", "Name_11"), 2, 22, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_11"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_11"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_11"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_11"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_11_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_11_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_11_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_11_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_11_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_11")));
		_dataArray.Add(new InformationInfoItem(12, LocalStringManager.GetConfig("InformationInfo_language", "Name_12"), 3, 22, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_12"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_12"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_12"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_12"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_12_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_12_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_12_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_12_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_12_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_12")));
		_dataArray.Add(new InformationInfoItem(13, LocalStringManager.GetConfig("InformationInfo_language", "Name_13"), 4, 22, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_13"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_13"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_13"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_13"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_13_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_13_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_13_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_13_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_13_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_13")));
		_dataArray.Add(new InformationInfoItem(14, LocalStringManager.GetConfig("InformationInfo_language", "Name_14"), 5, 22, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_14"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_14"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_14"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_14"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_14_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_14_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_14_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_14_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_14_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_14")));
		_dataArray.Add(new InformationInfoItem(15, LocalStringManager.GetConfig("InformationInfo_language", "Name_15"), 6, 22, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_15"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_15"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_15"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_15"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_15_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_15_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_15_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_15_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_15_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_15")));
		_dataArray.Add(new InformationInfoItem(16, LocalStringManager.GetConfig("InformationInfo_language", "Name_16"), 7, 22, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_16"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_16"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_16"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_16"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_16_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_16_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_16_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_16_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_16_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_16")));
		_dataArray.Add(new InformationInfoItem(17, LocalStringManager.GetConfig("InformationInfo_language", "Name_17"), 8, 22, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_17"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_17"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_17"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_17"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_17_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_17_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_17_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_17_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_17_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_17")));
		_dataArray.Add(new InformationInfoItem(18, LocalStringManager.GetConfig("InformationInfo_language", "Name_18"), 0, 23, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_18"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_18"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_18"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_18"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_18_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_18_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_18_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_18_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_18_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_18")));
		_dataArray.Add(new InformationInfoItem(19, LocalStringManager.GetConfig("InformationInfo_language", "Name_19"), 1, 23, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_19"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_19"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_19"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_19"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_19_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_19_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_19_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_19_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_19_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_19")));
		_dataArray.Add(new InformationInfoItem(20, LocalStringManager.GetConfig("InformationInfo_language", "Name_20"), 2, 23, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_20"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_20"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_20"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_20"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_20_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_20_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_20_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_20_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_20_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_20")));
		_dataArray.Add(new InformationInfoItem(21, LocalStringManager.GetConfig("InformationInfo_language", "Name_21"), 3, 23, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_21"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_21"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_21"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_21"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_21_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_21_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_21_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_21_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_21_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_21")));
		_dataArray.Add(new InformationInfoItem(22, LocalStringManager.GetConfig("InformationInfo_language", "Name_22"), 4, 23, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_22"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_22"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_22"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_22"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_22_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_22_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_22_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_22_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_22_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_22")));
		_dataArray.Add(new InformationInfoItem(23, LocalStringManager.GetConfig("InformationInfo_language", "Name_23"), 5, 23, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_23"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_23"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_23"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_23"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_23_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_23_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_23_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_23_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_23_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_23")));
		_dataArray.Add(new InformationInfoItem(24, LocalStringManager.GetConfig("InformationInfo_language", "Name_24"), 6, 23, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_24"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_24"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_24"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_24"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_24_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_24_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_24_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_24_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_24_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_24")));
		_dataArray.Add(new InformationInfoItem(25, LocalStringManager.GetConfig("InformationInfo_language", "Name_25"), 7, 23, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_25"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_25"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_25"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_25"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_25_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_25_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_25_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_25_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_25_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_25")));
		_dataArray.Add(new InformationInfoItem(26, LocalStringManager.GetConfig("InformationInfo_language", "Name_26"), 8, 23, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_26"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_26"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_26"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_26"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_26_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_26_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_26_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_26_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_26_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_26")));
		_dataArray.Add(new InformationInfoItem(27, LocalStringManager.GetConfig("InformationInfo_language", "Name_27"), 0, 24, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_27"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_27"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_27"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_27"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_27_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_27_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_27_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_27_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_27_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_27")));
		_dataArray.Add(new InformationInfoItem(28, LocalStringManager.GetConfig("InformationInfo_language", "Name_28"), 1, 24, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_28"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_28"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_28"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_28"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_28_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_28_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_28_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_28_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_28_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_28")));
		_dataArray.Add(new InformationInfoItem(29, LocalStringManager.GetConfig("InformationInfo_language", "Name_29"), 2, 24, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_29"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_29"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_29"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_29"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_29_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_29_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_29_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_29_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_29_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_29")));
		_dataArray.Add(new InformationInfoItem(30, LocalStringManager.GetConfig("InformationInfo_language", "Name_30"), 3, 24, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_30"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_30"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_30"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_30"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_30_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_30_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_30_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_30_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_30_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_30")));
		_dataArray.Add(new InformationInfoItem(31, LocalStringManager.GetConfig("InformationInfo_language", "Name_31"), 4, 24, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_31"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_31"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_31"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_31"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_31_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_31_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_31_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_31_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_31_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_31")));
		_dataArray.Add(new InformationInfoItem(32, LocalStringManager.GetConfig("InformationInfo_language", "Name_32"), 5, 24, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_32"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_32"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_32"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_32"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_32_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_32_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_32_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_32_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_32_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_32")));
		_dataArray.Add(new InformationInfoItem(33, LocalStringManager.GetConfig("InformationInfo_language", "Name_33"), 6, 24, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_33"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_33"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_33"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_33"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_33_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_33_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_33_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_33_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_33_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_33")));
		_dataArray.Add(new InformationInfoItem(34, LocalStringManager.GetConfig("InformationInfo_language", "Name_34"), 7, 24, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_34"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_34"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_34"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_34"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_34_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_34_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_34_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_34_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_34_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_34")));
		_dataArray.Add(new InformationInfoItem(35, LocalStringManager.GetConfig("InformationInfo_language", "Name_35"), 8, 24, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_35"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_35"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_35"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_35"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_35_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_35_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_35_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_35_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_35_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_35")));
		_dataArray.Add(new InformationInfoItem(36, LocalStringManager.GetConfig("InformationInfo_language", "Name_36"), 0, 25, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_36"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_36"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_36"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_36"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_36_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_36_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_36_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_36_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_36_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_36")));
		_dataArray.Add(new InformationInfoItem(37, LocalStringManager.GetConfig("InformationInfo_language", "Name_37"), 1, 25, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_37"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_37"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_37"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_37"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_37_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_37_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_37_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_37_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_37_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_37")));
		_dataArray.Add(new InformationInfoItem(38, LocalStringManager.GetConfig("InformationInfo_language", "Name_38"), 2, 25, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_38"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_38"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_38"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_38"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_38_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_38_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_38_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_38_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_38_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_38")));
		_dataArray.Add(new InformationInfoItem(39, LocalStringManager.GetConfig("InformationInfo_language", "Name_39"), 3, 25, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_39"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_39"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_39"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_39"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_39_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_39_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_39_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_39_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_39_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_39")));
		_dataArray.Add(new InformationInfoItem(40, LocalStringManager.GetConfig("InformationInfo_language", "Name_40"), 4, 25, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_40"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_40"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_40"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_40"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_40_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_40_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_40_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_40_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_40_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_40")));
		_dataArray.Add(new InformationInfoItem(41, LocalStringManager.GetConfig("InformationInfo_language", "Name_41"), 5, 25, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_41"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_41"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_41"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_41"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_41_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_41_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_41_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_41_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_41_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_41")));
		_dataArray.Add(new InformationInfoItem(42, LocalStringManager.GetConfig("InformationInfo_language", "Name_42"), 6, 25, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_42"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_42"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_42"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_42"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_42_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_42_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_42_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_42_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_42_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_42")));
		_dataArray.Add(new InformationInfoItem(43, LocalStringManager.GetConfig("InformationInfo_language", "Name_43"), 7, 25, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_43"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_43"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_43"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_43"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_43_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_43_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_43_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_43_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_43_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_43")));
		_dataArray.Add(new InformationInfoItem(44, LocalStringManager.GetConfig("InformationInfo_language", "Name_44"), 8, 25, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_44"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_44"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_44"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_44"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_44_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_44_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_44_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_44_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_44_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_44")));
		_dataArray.Add(new InformationInfoItem(45, LocalStringManager.GetConfig("InformationInfo_language", "Name_45"), 0, 26, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_45"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_45"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_45"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_45"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_45_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_45_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_45_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_45_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_45_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_45")));
		_dataArray.Add(new InformationInfoItem(46, LocalStringManager.GetConfig("InformationInfo_language", "Name_46"), 1, 26, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_46"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_46"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_46"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_46"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_46_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_46_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_46_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_46_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_46_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_46")));
		_dataArray.Add(new InformationInfoItem(47, LocalStringManager.GetConfig("InformationInfo_language", "Name_47"), 2, 26, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_47"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_47"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_47"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_47"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_47_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_47_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_47_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_47_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_47_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_47")));
		_dataArray.Add(new InformationInfoItem(48, LocalStringManager.GetConfig("InformationInfo_language", "Name_48"), 3, 26, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_48"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_48"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_48"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_48"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_48_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_48_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_48_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_48_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_48_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_48")));
		_dataArray.Add(new InformationInfoItem(49, LocalStringManager.GetConfig("InformationInfo_language", "Name_49"), 4, 26, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_49"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_49"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_49"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_49"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_49_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_49_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_49_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_49_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_49_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_49")));
		_dataArray.Add(new InformationInfoItem(50, LocalStringManager.GetConfig("InformationInfo_language", "Name_50"), 5, 26, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_50"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_50"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_50"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_50"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_50_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_50_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_50_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_50_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_50_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_50")));
		_dataArray.Add(new InformationInfoItem(51, LocalStringManager.GetConfig("InformationInfo_language", "Name_51"), 6, 26, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_51"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_51"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_51"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_51"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_51_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_51_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_51_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_51_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_51_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_51")));
		_dataArray.Add(new InformationInfoItem(52, LocalStringManager.GetConfig("InformationInfo_language", "Name_52"), 7, 26, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_52"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_52"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_52"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_52"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_52_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_52_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_52_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_52_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_52_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_52")));
		_dataArray.Add(new InformationInfoItem(53, LocalStringManager.GetConfig("InformationInfo_language", "Name_53"), 8, 26, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_53"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_53"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_53"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_53"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_53_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_53_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_53_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_53_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_53_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_53")));
		_dataArray.Add(new InformationInfoItem(54, LocalStringManager.GetConfig("InformationInfo_language", "Name_54"), 0, 27, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_54"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_54"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_54"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_54"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_54_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_54_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_54_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_54_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_54_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_54")));
		_dataArray.Add(new InformationInfoItem(55, LocalStringManager.GetConfig("InformationInfo_language", "Name_55"), 1, 27, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_55"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_55"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_55"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_55"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_55_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_55_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_55_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_55_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_55_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_55")));
		_dataArray.Add(new InformationInfoItem(56, LocalStringManager.GetConfig("InformationInfo_language", "Name_56"), 2, 27, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_56"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_56"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_56"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_56"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_56_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_56_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_56_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_56_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_56_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_56")));
		_dataArray.Add(new InformationInfoItem(57, LocalStringManager.GetConfig("InformationInfo_language", "Name_57"), 3, 27, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_57"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_57"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_57"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_57"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_57_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_57_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_57_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_57_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_57_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_57")));
		_dataArray.Add(new InformationInfoItem(58, LocalStringManager.GetConfig("InformationInfo_language", "Name_58"), 4, 27, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_58"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_58"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_58"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_58"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_58_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_58_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_58_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_58_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_58_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_58")));
		_dataArray.Add(new InformationInfoItem(59, LocalStringManager.GetConfig("InformationInfo_language", "Name_59"), 5, 27, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_59"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_59"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_59"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_59"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_59_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_59_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_59_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_59_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_59_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_59")));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new InformationInfoItem(60, LocalStringManager.GetConfig("InformationInfo_language", "Name_60"), 6, 27, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_60"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_60"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_60"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_60"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_60_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_60_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_60_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_60_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_60_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_60")));
		_dataArray.Add(new InformationInfoItem(61, LocalStringManager.GetConfig("InformationInfo_language", "Name_61"), 7, 27, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_61"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_61"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_61"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_61"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_61_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_61_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_61_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_61_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_61_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_61")));
		_dataArray.Add(new InformationInfoItem(62, LocalStringManager.GetConfig("InformationInfo_language", "Name_62"), 8, 27, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_62"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_62"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_62"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_62"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_62_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_62_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_62_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_62_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_62_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_62")));
		_dataArray.Add(new InformationInfoItem(63, LocalStringManager.GetConfig("InformationInfo_language", "Name_63"), 0, 28, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_63"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_63"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_63"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_63"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_63_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_63_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_63_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_63_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_63_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_63")));
		_dataArray.Add(new InformationInfoItem(64, LocalStringManager.GetConfig("InformationInfo_language", "Name_64"), 1, 28, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_64"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_64"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_64"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_64"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_64_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_64_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_64_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_64_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_64_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_64")));
		_dataArray.Add(new InformationInfoItem(65, LocalStringManager.GetConfig("InformationInfo_language", "Name_65"), 2, 28, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_65"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_65"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_65"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_65"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_65_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_65_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_65_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_65_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_65_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_65")));
		_dataArray.Add(new InformationInfoItem(66, LocalStringManager.GetConfig("InformationInfo_language", "Name_66"), 3, 28, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_66"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_66"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_66"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_66"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_66_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_66_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_66_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_66_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_66_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_66")));
		_dataArray.Add(new InformationInfoItem(67, LocalStringManager.GetConfig("InformationInfo_language", "Name_67"), 4, 28, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_67"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_67"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_67"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_67"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_67_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_67_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_67_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_67_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_67_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_67")));
		_dataArray.Add(new InformationInfoItem(68, LocalStringManager.GetConfig("InformationInfo_language", "Name_68"), 5, 28, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_68"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_68"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_68"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_68"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_68_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_68_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_68_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_68_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_68_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_68")));
		_dataArray.Add(new InformationInfoItem(69, LocalStringManager.GetConfig("InformationInfo_language", "Name_69"), 6, 28, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_69"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_69"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_69"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_69"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_69_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_69_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_69_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_69_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_69_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_69")));
		_dataArray.Add(new InformationInfoItem(70, LocalStringManager.GetConfig("InformationInfo_language", "Name_70"), 7, 28, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_70"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_70"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_70"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_70"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_70_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_70_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_70_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_70_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_70_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_70")));
		_dataArray.Add(new InformationInfoItem(71, LocalStringManager.GetConfig("InformationInfo_language", "Name_71"), 8, 28, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_71"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_71"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_71"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_71"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_71_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_71_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_71_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_71_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_71_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_71")));
		_dataArray.Add(new InformationInfoItem(72, LocalStringManager.GetConfig("InformationInfo_language", "Name_72"), 0, 29, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_72"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_72"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_72"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_72"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_72_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_72_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_72_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_72_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_72_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_72")));
		_dataArray.Add(new InformationInfoItem(73, LocalStringManager.GetConfig("InformationInfo_language", "Name_73"), 1, 29, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_73"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_73"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_73"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_73"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_73_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_73_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_73_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_73_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_73_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_73")));
		_dataArray.Add(new InformationInfoItem(74, LocalStringManager.GetConfig("InformationInfo_language", "Name_74"), 2, 29, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_74"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_74"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_74"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_74"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_74_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_74_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_74_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_74_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_74_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_74")));
		_dataArray.Add(new InformationInfoItem(75, LocalStringManager.GetConfig("InformationInfo_language", "Name_75"), 3, 29, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_75"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_75"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_75"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_75"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_75_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_75_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_75_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_75_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_75_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_75")));
		_dataArray.Add(new InformationInfoItem(76, LocalStringManager.GetConfig("InformationInfo_language", "Name_76"), 4, 29, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_76"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_76"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_76"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_76"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_76_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_76_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_76_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_76_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_76_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_76")));
		_dataArray.Add(new InformationInfoItem(77, LocalStringManager.GetConfig("InformationInfo_language", "Name_77"), 5, 29, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_77"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_77"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_77"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_77"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_77_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_77_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_77_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_77_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_77_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_77")));
		_dataArray.Add(new InformationInfoItem(78, LocalStringManager.GetConfig("InformationInfo_language", "Name_78"), 6, 29, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_78"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_78"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_78"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_78"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_78_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_78_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_78_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_78_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_78_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_78")));
		_dataArray.Add(new InformationInfoItem(79, LocalStringManager.GetConfig("InformationInfo_language", "Name_79"), 7, 29, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_79"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_79"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_79"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_79"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_79_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_79_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_79_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_79_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_79_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_79")));
		_dataArray.Add(new InformationInfoItem(80, LocalStringManager.GetConfig("InformationInfo_language", "Name_80"), 8, 29, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_80"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_80"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_80"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_80"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_80_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_80_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_80_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_80_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_80_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_80")));
		_dataArray.Add(new InformationInfoItem(81, LocalStringManager.GetConfig("InformationInfo_language", "Name_81"), 0, 30, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_81"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_81"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_81"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_81"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_81_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_81_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_81_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_81_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_81_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_81")));
		_dataArray.Add(new InformationInfoItem(82, LocalStringManager.GetConfig("InformationInfo_language", "Name_82"), 1, 30, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_82"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_82"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_82"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_82"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_82_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_82_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_82_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_82_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_82_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_82")));
		_dataArray.Add(new InformationInfoItem(83, LocalStringManager.GetConfig("InformationInfo_language", "Name_83"), 2, 30, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_83"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_83"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_83"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_83"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_83_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_83_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_83_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_83_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_83_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_83")));
		_dataArray.Add(new InformationInfoItem(84, LocalStringManager.GetConfig("InformationInfo_language", "Name_84"), 3, 30, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_84"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_84"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_84"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_84"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_84_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_84_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_84_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_84_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_84_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_84")));
		_dataArray.Add(new InformationInfoItem(85, LocalStringManager.GetConfig("InformationInfo_language", "Name_85"), 4, 30, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_85"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_85"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_85"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_85"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_85_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_85_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_85_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_85_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_85_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_85")));
		_dataArray.Add(new InformationInfoItem(86, LocalStringManager.GetConfig("InformationInfo_language", "Name_86"), 5, 30, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_86"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_86"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_86"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_86"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_86_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_86_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_86_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_86_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_86_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_86")));
		_dataArray.Add(new InformationInfoItem(87, LocalStringManager.GetConfig("InformationInfo_language", "Name_87"), 6, 30, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_87"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_87"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_87"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_87"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_87_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_87_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_87_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_87_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_87_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_87")));
		_dataArray.Add(new InformationInfoItem(88, LocalStringManager.GetConfig("InformationInfo_language", "Name_88"), 7, 30, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_88"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_88"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_88"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_88"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_88_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_88_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_88_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_88_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_88_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_88")));
		_dataArray.Add(new InformationInfoItem(89, LocalStringManager.GetConfig("InformationInfo_language", "Name_89"), 8, 30, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_89"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_89"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_89"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_89"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_89_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_89_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_89_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_89_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_89_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_89")));
		_dataArray.Add(new InformationInfoItem(90, LocalStringManager.GetConfig("InformationInfo_language", "Name_90"), 0, 31, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_90"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_90"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_90"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_90"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_90_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_90_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_90_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_90_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_90_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_90")));
		_dataArray.Add(new InformationInfoItem(91, LocalStringManager.GetConfig("InformationInfo_language", "Name_91"), 1, 31, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_91"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_91"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_91"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_91"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_91_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_91_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_91_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_91_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_91_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_91")));
		_dataArray.Add(new InformationInfoItem(92, LocalStringManager.GetConfig("InformationInfo_language", "Name_92"), 2, 31, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_92"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_92"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_92"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_92"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_92_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_92_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_92_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_92_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_92_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_92")));
		_dataArray.Add(new InformationInfoItem(93, LocalStringManager.GetConfig("InformationInfo_language", "Name_93"), 3, 31, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_93"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_93"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_93"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_93"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_93_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_93_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_93_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_93_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_93_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_93")));
		_dataArray.Add(new InformationInfoItem(94, LocalStringManager.GetConfig("InformationInfo_language", "Name_94"), 4, 31, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_94"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_94"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_94"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_94"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_94_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_94_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_94_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_94_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_94_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_94")));
		_dataArray.Add(new InformationInfoItem(95, LocalStringManager.GetConfig("InformationInfo_language", "Name_95"), 5, 31, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_95"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_95"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_95"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_95"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_95_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_95_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_95_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_95_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_95_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_95")));
		_dataArray.Add(new InformationInfoItem(96, LocalStringManager.GetConfig("InformationInfo_language", "Name_96"), 6, 31, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_96"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_96"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_96"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_96"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_96_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_96_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_96_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_96_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_96_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_96")));
		_dataArray.Add(new InformationInfoItem(97, LocalStringManager.GetConfig("InformationInfo_language", "Name_97"), 7, 31, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_97"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_97"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_97"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_97"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_97_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_97_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_97_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_97_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_97_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_97")));
		_dataArray.Add(new InformationInfoItem(98, LocalStringManager.GetConfig("InformationInfo_language", "Name_98"), 8, 31, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_98"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_98"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_98"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_98"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_98_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_98_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_98_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_98_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_98_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_98")));
		_dataArray.Add(new InformationInfoItem(99, LocalStringManager.GetConfig("InformationInfo_language", "Name_99"), 0, 32, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_99"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_99"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_99"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_99"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_99_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_99_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_99_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_99_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_99_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_99")));
		_dataArray.Add(new InformationInfoItem(100, LocalStringManager.GetConfig("InformationInfo_language", "Name_100"), 1, 32, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_100"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_100"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_100"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_100"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_100_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_100_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_100_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_100_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_100_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_100")));
		_dataArray.Add(new InformationInfoItem(101, LocalStringManager.GetConfig("InformationInfo_language", "Name_101"), 2, 32, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_101"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_101"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_101"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_101"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_101_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_101_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_101_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_101_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_101_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_101")));
		_dataArray.Add(new InformationInfoItem(102, LocalStringManager.GetConfig("InformationInfo_language", "Name_102"), 3, 32, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_102"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_102"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_102"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_102"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_102_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_102_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_102_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_102_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_102_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_102")));
		_dataArray.Add(new InformationInfoItem(103, LocalStringManager.GetConfig("InformationInfo_language", "Name_103"), 4, 32, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_103"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_103"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_103"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_103"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_103_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_103_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_103_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_103_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_103_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_103")));
		_dataArray.Add(new InformationInfoItem(104, LocalStringManager.GetConfig("InformationInfo_language", "Name_104"), 5, 32, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_104"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_104"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_104"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_104"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_104_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_104_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_104_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_104_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_104_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_104")));
		_dataArray.Add(new InformationInfoItem(105, LocalStringManager.GetConfig("InformationInfo_language", "Name_105"), 6, 32, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_105"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_105"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_105"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_105"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_105_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_105_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_105_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_105_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_105_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_105")));
		_dataArray.Add(new InformationInfoItem(106, LocalStringManager.GetConfig("InformationInfo_language", "Name_106"), 7, 32, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_106"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_106"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_106"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_106"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_106_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_106_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_106_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_106_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_106_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_106")));
		_dataArray.Add(new InformationInfoItem(107, LocalStringManager.GetConfig("InformationInfo_language", "Name_107"), 8, 32, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_107"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_107"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_107"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_107"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_107_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_107_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_107_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_107_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_107_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_107")));
		_dataArray.Add(new InformationInfoItem(108, LocalStringManager.GetConfig("InformationInfo_language", "Name_108"), 0, 33, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_108"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_108"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_108"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_108"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_108_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_108_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_108_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_108_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_108_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_108")));
		_dataArray.Add(new InformationInfoItem(109, LocalStringManager.GetConfig("InformationInfo_language", "Name_109"), 1, 33, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_109"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_109"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_109"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_109"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_109_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_109_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_109_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_109_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_109_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_109")));
		_dataArray.Add(new InformationInfoItem(110, LocalStringManager.GetConfig("InformationInfo_language", "Name_110"), 2, 33, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_110"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_110"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_110"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_110"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_110_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_110_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_110_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_110_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_110_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_110")));
		_dataArray.Add(new InformationInfoItem(111, LocalStringManager.GetConfig("InformationInfo_language", "Name_111"), 3, 33, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_111"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_111"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_111"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_111"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_111_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_111_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_111_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_111_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_111_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_111")));
		_dataArray.Add(new InformationInfoItem(112, LocalStringManager.GetConfig("InformationInfo_language", "Name_112"), 4, 33, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_112"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_112"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_112"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_112"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_112_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_112_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_112_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_112_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_112_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_112")));
		_dataArray.Add(new InformationInfoItem(113, LocalStringManager.GetConfig("InformationInfo_language", "Name_113"), 5, 33, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_113"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_113"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_113"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_113"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_113_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_113_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_113_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_113_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_113_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_113")));
		_dataArray.Add(new InformationInfoItem(114, LocalStringManager.GetConfig("InformationInfo_language", "Name_114"), 6, 33, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_114"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_114"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_114"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_114"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_114_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_114_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_114_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_114_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_114_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_114")));
		_dataArray.Add(new InformationInfoItem(115, LocalStringManager.GetConfig("InformationInfo_language", "Name_115"), 7, 33, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_115"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_115"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_115"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_115"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_115_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_115_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_115_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_115_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_115_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_115")));
		_dataArray.Add(new InformationInfoItem(116, LocalStringManager.GetConfig("InformationInfo_language", "Name_116"), 8, 33, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_116"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_116"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_116"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_116"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_116_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_116_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_116_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_116_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_116_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_116")));
		_dataArray.Add(new InformationInfoItem(117, LocalStringManager.GetConfig("InformationInfo_language", "Name_117"), 0, 34, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_117"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_117"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_117"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_117"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_117_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_117_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_117_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_117_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_117_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_117")));
		_dataArray.Add(new InformationInfoItem(118, LocalStringManager.GetConfig("InformationInfo_language", "Name_118"), 1, 34, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_118"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_118"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_118"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_118"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_118_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_118_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_118_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_118_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_118_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_118")));
		_dataArray.Add(new InformationInfoItem(119, LocalStringManager.GetConfig("InformationInfo_language", "Name_119"), 2, 34, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_119"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_119"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_119"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_119"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_119_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_119_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_119_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_119_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_119_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_119")));
	}

	private void CreateItems2()
	{
		_dataArray.Add(new InformationInfoItem(120, LocalStringManager.GetConfig("InformationInfo_language", "Name_120"), 3, 34, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_120"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_120"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_120"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_120"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_120_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_120_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_120_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_120_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_120_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_120")));
		_dataArray.Add(new InformationInfoItem(121, LocalStringManager.GetConfig("InformationInfo_language", "Name_121"), 4, 34, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_121"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_121"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_121"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_121"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_121_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_121_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_121_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_121_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_121_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_121")));
		_dataArray.Add(new InformationInfoItem(122, LocalStringManager.GetConfig("InformationInfo_language", "Name_122"), 5, 34, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_122"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_122"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_122"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_122"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_122_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_122_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_122_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_122_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_122_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_122")));
		_dataArray.Add(new InformationInfoItem(123, LocalStringManager.GetConfig("InformationInfo_language", "Name_123"), 6, 34, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_123"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_123"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_123"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_123"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_123_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_123_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_123_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_123_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_123_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_123")));
		_dataArray.Add(new InformationInfoItem(124, LocalStringManager.GetConfig("InformationInfo_language", "Name_124"), 7, 34, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_124"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_124"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_124"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_124"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_124_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_124_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_124_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_124_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_124_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_124")));
		_dataArray.Add(new InformationInfoItem(125, LocalStringManager.GetConfig("InformationInfo_language", "Name_125"), 8, 34, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_125"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_125"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_125"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_125"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_125_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_125_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_125_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_125_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_125_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_125")));
		_dataArray.Add(new InformationInfoItem(126, LocalStringManager.GetConfig("InformationInfo_language", "Name_126"), 0, 35, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_126"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_126"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_126"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_126"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_126_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_126_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_126_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_126_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_126_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_126")));
		_dataArray.Add(new InformationInfoItem(127, LocalStringManager.GetConfig("InformationInfo_language", "Name_127"), 1, 35, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_127"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_127"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_127"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_127"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_127_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_127_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_127_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_127_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_127_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_127")));
		_dataArray.Add(new InformationInfoItem(128, LocalStringManager.GetConfig("InformationInfo_language", "Name_128"), 2, 35, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_128"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_128"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_128"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_128"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_128_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_128_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_128_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_128_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_128_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_128")));
		_dataArray.Add(new InformationInfoItem(129, LocalStringManager.GetConfig("InformationInfo_language", "Name_129"), 3, 35, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_129"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_129"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_129"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_129"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_129_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_129_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_129_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_129_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_129_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_129")));
		_dataArray.Add(new InformationInfoItem(130, LocalStringManager.GetConfig("InformationInfo_language", "Name_130"), 4, 35, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_130"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_130"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_130"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_130"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_130_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_130_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_130_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_130_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_130_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_130")));
		_dataArray.Add(new InformationInfoItem(131, LocalStringManager.GetConfig("InformationInfo_language", "Name_131"), 5, 35, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_131"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_131"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_131"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_131"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_131_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_131_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_131_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_131_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_131_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_131")));
		_dataArray.Add(new InformationInfoItem(132, LocalStringManager.GetConfig("InformationInfo_language", "Name_132"), 6, 35, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_132"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_132"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_132"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_132"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_132_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_132_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_132_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_132_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_132_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_132")));
		_dataArray.Add(new InformationInfoItem(133, LocalStringManager.GetConfig("InformationInfo_language", "Name_133"), 7, 35, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_133"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_133"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_133"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_133"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_133_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_133_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_133_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_133_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_133_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_133")));
		_dataArray.Add(new InformationInfoItem(134, LocalStringManager.GetConfig("InformationInfo_language", "Name_134"), 8, 35, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_134"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_134"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_134"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_134"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_134_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_134_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_134_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_134_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_134_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_134")));
		_dataArray.Add(new InformationInfoItem(135, LocalStringManager.GetConfig("InformationInfo_language", "Name_135"), 0, 1, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_135"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_135"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_135"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_135"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_135_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_135_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_135_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_135_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_135_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_135")));
		_dataArray.Add(new InformationInfoItem(136, LocalStringManager.GetConfig("InformationInfo_language", "Name_136"), 1, 1, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_136"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_136"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_136"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_136"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_136_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_136_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_136_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_136_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_136_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_136")));
		_dataArray.Add(new InformationInfoItem(137, LocalStringManager.GetConfig("InformationInfo_language", "Name_137"), 2, 1, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_137"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_137"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_137"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_137"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_137_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_137_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_137_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_137_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_137_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_137")));
		_dataArray.Add(new InformationInfoItem(138, LocalStringManager.GetConfig("InformationInfo_language", "Name_138"), 3, 1, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_138"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_138"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_138"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_138"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_138_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_138_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_138_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_138_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_138_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_138")));
		_dataArray.Add(new InformationInfoItem(139, LocalStringManager.GetConfig("InformationInfo_language", "Name_139"), 4, 1, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_139"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_139"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_139"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_139"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_139_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_139_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_139_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_139_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_139_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_139")));
		_dataArray.Add(new InformationInfoItem(140, LocalStringManager.GetConfig("InformationInfo_language", "Name_140"), 5, 1, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_140"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_140"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_140"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_140"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_140_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_140_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_140_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_140_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_140_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_140")));
		_dataArray.Add(new InformationInfoItem(141, LocalStringManager.GetConfig("InformationInfo_language", "Name_141"), 6, 1, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_141"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_141"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_141"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_141"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_141_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_141_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_141_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_141_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_141_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_141")));
		_dataArray.Add(new InformationInfoItem(142, LocalStringManager.GetConfig("InformationInfo_language", "Name_142"), 7, 1, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_142"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_142"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_142"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_142"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_142_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_142_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_142_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_142_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_142_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_142")));
		_dataArray.Add(new InformationInfoItem(143, LocalStringManager.GetConfig("InformationInfo_language", "Name_143"), 8, 1, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_143"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_143"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_143"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_143"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_143_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_143_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_143_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_143_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_143_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_143")));
		_dataArray.Add(new InformationInfoItem(144, LocalStringManager.GetConfig("InformationInfo_language", "Name_144"), 0, 2, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_144"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_144"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_144"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_144"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_144_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_144_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_144_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_144_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_144_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_144")));
		_dataArray.Add(new InformationInfoItem(145, LocalStringManager.GetConfig("InformationInfo_language", "Name_145"), 1, 2, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_145"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_145"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_145"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_145"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_145_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_145_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_145_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_145_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_145_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_145")));
		_dataArray.Add(new InformationInfoItem(146, LocalStringManager.GetConfig("InformationInfo_language", "Name_146"), 2, 2, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_146"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_146"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_146"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_146"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_146_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_146_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_146_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_146_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_146_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_146")));
		_dataArray.Add(new InformationInfoItem(147, LocalStringManager.GetConfig("InformationInfo_language", "Name_147"), 3, 2, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_147"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_147"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_147"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_147"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_147_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_147_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_147_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_147_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_147_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_147")));
		_dataArray.Add(new InformationInfoItem(148, LocalStringManager.GetConfig("InformationInfo_language", "Name_148"), 4, 2, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_148"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_148"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_148"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_148"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_148_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_148_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_148_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_148_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_148_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_148")));
		_dataArray.Add(new InformationInfoItem(149, LocalStringManager.GetConfig("InformationInfo_language", "Name_149"), 5, 2, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_149"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_149"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_149"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_149"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_149_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_149_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_149_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_149_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_149_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_149")));
		_dataArray.Add(new InformationInfoItem(150, LocalStringManager.GetConfig("InformationInfo_language", "Name_150"), 6, 2, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_150"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_150"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_150"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_150"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_150_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_150_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_150_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_150_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_150_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_150")));
		_dataArray.Add(new InformationInfoItem(151, LocalStringManager.GetConfig("InformationInfo_language", "Name_151"), 7, 2, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_151"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_151"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_151"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_151"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_151_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_151_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_151_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_151_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_151_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_151")));
		_dataArray.Add(new InformationInfoItem(152, LocalStringManager.GetConfig("InformationInfo_language", "Name_152"), 8, 2, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_152"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_152"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_152"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_152"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_152_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_152_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_152_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_152_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_152_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_152")));
		_dataArray.Add(new InformationInfoItem(153, LocalStringManager.GetConfig("InformationInfo_language", "Name_153"), 0, 3, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_153"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_153"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_153"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_153"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_153_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_153_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_153_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_153_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_153_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_153")));
		_dataArray.Add(new InformationInfoItem(154, LocalStringManager.GetConfig("InformationInfo_language", "Name_154"), 1, 3, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_154"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_154"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_154"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_154"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_154_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_154_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_154_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_154_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_154_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_154")));
		_dataArray.Add(new InformationInfoItem(155, LocalStringManager.GetConfig("InformationInfo_language", "Name_155"), 2, 3, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_155"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_155"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_155"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_155"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_155_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_155_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_155_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_155_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_155_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_155")));
		_dataArray.Add(new InformationInfoItem(156, LocalStringManager.GetConfig("InformationInfo_language", "Name_156"), 3, 3, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_156"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_156"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_156"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_156"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_156_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_156_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_156_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_156_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_156_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_156")));
		_dataArray.Add(new InformationInfoItem(157, LocalStringManager.GetConfig("InformationInfo_language", "Name_157"), 4, 3, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_157"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_157"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_157"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_157"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_157_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_157_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_157_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_157_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_157_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_157")));
		_dataArray.Add(new InformationInfoItem(158, LocalStringManager.GetConfig("InformationInfo_language", "Name_158"), 5, 3, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_158"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_158"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_158"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_158"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_158_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_158_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_158_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_158_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_158_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_158")));
		_dataArray.Add(new InformationInfoItem(159, LocalStringManager.GetConfig("InformationInfo_language", "Name_159"), 6, 3, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_159"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_159"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_159"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_159"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_159_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_159_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_159_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_159_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_159_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_159")));
		_dataArray.Add(new InformationInfoItem(160, LocalStringManager.GetConfig("InformationInfo_language", "Name_160"), 7, 3, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_160"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_160"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_160"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_160"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_160_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_160_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_160_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_160_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_160_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_160")));
		_dataArray.Add(new InformationInfoItem(161, LocalStringManager.GetConfig("InformationInfo_language", "Name_161"), 8, 3, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_161"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_161"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_161"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_161"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_161_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_161_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_161_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_161_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_161_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_161")));
		_dataArray.Add(new InformationInfoItem(162, LocalStringManager.GetConfig("InformationInfo_language", "Name_162"), 0, 4, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_162"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_162"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_162"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_162"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_162_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_162_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_162_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_162_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_162_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_162")));
		_dataArray.Add(new InformationInfoItem(163, LocalStringManager.GetConfig("InformationInfo_language", "Name_163"), 1, 4, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_163"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_163"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_163"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_163"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_163_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_163_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_163_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_163_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_163_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_163")));
		_dataArray.Add(new InformationInfoItem(164, LocalStringManager.GetConfig("InformationInfo_language", "Name_164"), 2, 4, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_164"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_164"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_164"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_164"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_164_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_164_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_164_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_164_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_164_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_164")));
		_dataArray.Add(new InformationInfoItem(165, LocalStringManager.GetConfig("InformationInfo_language", "Name_165"), 3, 4, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_165"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_165"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_165"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_165"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_165_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_165_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_165_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_165_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_165_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_165")));
		_dataArray.Add(new InformationInfoItem(166, LocalStringManager.GetConfig("InformationInfo_language", "Name_166"), 4, 4, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_166"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_166"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_166"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_166"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_166_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_166_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_166_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_166_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_166_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_166")));
		_dataArray.Add(new InformationInfoItem(167, LocalStringManager.GetConfig("InformationInfo_language", "Name_167"), 5, 4, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_167"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_167"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_167"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_167"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_167_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_167_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_167_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_167_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_167_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_167")));
		_dataArray.Add(new InformationInfoItem(168, LocalStringManager.GetConfig("InformationInfo_language", "Name_168"), 6, 4, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_168"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_168"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_168"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_168"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_168_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_168_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_168_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_168_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_168_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_168")));
		_dataArray.Add(new InformationInfoItem(169, LocalStringManager.GetConfig("InformationInfo_language", "Name_169"), 7, 4, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_169"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_169"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_169"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_169"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_169_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_169_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_169_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_169_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_169_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_169")));
		_dataArray.Add(new InformationInfoItem(170, LocalStringManager.GetConfig("InformationInfo_language", "Name_170"), 8, 4, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_170"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_170"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_170"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_170"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_170_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_170_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_170_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_170_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_170_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_170")));
		_dataArray.Add(new InformationInfoItem(171, LocalStringManager.GetConfig("InformationInfo_language", "Name_171"), 0, 5, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_171"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_171"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_171"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_171"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_171_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_171_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_171_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_171_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_171_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_171")));
		_dataArray.Add(new InformationInfoItem(172, LocalStringManager.GetConfig("InformationInfo_language", "Name_172"), 1, 5, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_172"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_172"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_172"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_172"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_172_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_172_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_172_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_172_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_172_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_172")));
		_dataArray.Add(new InformationInfoItem(173, LocalStringManager.GetConfig("InformationInfo_language", "Name_173"), 2, 5, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_173"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_173"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_173"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_173"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_173_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_173_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_173_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_173_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_173_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_173")));
		_dataArray.Add(new InformationInfoItem(174, LocalStringManager.GetConfig("InformationInfo_language", "Name_174"), 3, 5, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_174"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_174"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_174"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_174"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_174_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_174_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_174_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_174_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_174_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_174")));
		_dataArray.Add(new InformationInfoItem(175, LocalStringManager.GetConfig("InformationInfo_language", "Name_175"), 4, 5, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_175"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_175"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_175"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_175"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_175_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_175_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_175_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_175_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_175_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_175")));
		_dataArray.Add(new InformationInfoItem(176, LocalStringManager.GetConfig("InformationInfo_language", "Name_176"), 5, 5, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_176"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_176"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_176"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_176"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_176_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_176_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_176_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_176_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_176_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_176")));
		_dataArray.Add(new InformationInfoItem(177, LocalStringManager.GetConfig("InformationInfo_language", "Name_177"), 6, 5, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_177"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_177"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_177"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_177"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_177_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_177_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_177_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_177_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_177_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_177")));
		_dataArray.Add(new InformationInfoItem(178, LocalStringManager.GetConfig("InformationInfo_language", "Name_178"), 7, 5, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_178"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_178"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_178"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_178"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_178_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_178_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_178_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_178_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_178_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_178")));
		_dataArray.Add(new InformationInfoItem(179, LocalStringManager.GetConfig("InformationInfo_language", "Name_179"), 8, 5, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_179"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_179"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_179"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_179"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_179_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_179_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_179_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_179_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_179_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_179")));
	}

	private void CreateItems3()
	{
		_dataArray.Add(new InformationInfoItem(180, LocalStringManager.GetConfig("InformationInfo_language", "Name_180"), 0, 6, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_180"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_180"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_180"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_180"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_180_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_180_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_180_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_180_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_180_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_180")));
		_dataArray.Add(new InformationInfoItem(181, LocalStringManager.GetConfig("InformationInfo_language", "Name_181"), 1, 6, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_181"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_181"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_181"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_181"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_181_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_181_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_181_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_181_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_181_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_181")));
		_dataArray.Add(new InformationInfoItem(182, LocalStringManager.GetConfig("InformationInfo_language", "Name_182"), 2, 6, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_182"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_182"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_182"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_182"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_182_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_182_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_182_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_182_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_182_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_182")));
		_dataArray.Add(new InformationInfoItem(183, LocalStringManager.GetConfig("InformationInfo_language", "Name_183"), 3, 6, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_183"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_183"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_183"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_183"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_183_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_183_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_183_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_183_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_183_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_183")));
		_dataArray.Add(new InformationInfoItem(184, LocalStringManager.GetConfig("InformationInfo_language", "Name_184"), 4, 6, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_184"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_184"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_184"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_184"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_184_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_184_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_184_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_184_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_184_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_184")));
		_dataArray.Add(new InformationInfoItem(185, LocalStringManager.GetConfig("InformationInfo_language", "Name_185"), 5, 6, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_185"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_185"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_185"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_185"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_185_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_185_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_185_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_185_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_185_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_185")));
		_dataArray.Add(new InformationInfoItem(186, LocalStringManager.GetConfig("InformationInfo_language", "Name_186"), 6, 6, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_186"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_186"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_186"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_186"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_186_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_186_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_186_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_186_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_186_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_186")));
		_dataArray.Add(new InformationInfoItem(187, LocalStringManager.GetConfig("InformationInfo_language", "Name_187"), 7, 6, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_187"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_187"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_187"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_187"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_187_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_187_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_187_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_187_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_187_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_187")));
		_dataArray.Add(new InformationInfoItem(188, LocalStringManager.GetConfig("InformationInfo_language", "Name_188"), 8, 6, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_188"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_188"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_188"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_188"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_188_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_188_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_188_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_188_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_188_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_188")));
		_dataArray.Add(new InformationInfoItem(189, LocalStringManager.GetConfig("InformationInfo_language", "Name_189"), 0, 7, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_189"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_189"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_189"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_189"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_189_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_189_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_189_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_189_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_189_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_189")));
		_dataArray.Add(new InformationInfoItem(190, LocalStringManager.GetConfig("InformationInfo_language", "Name_190"), 1, 7, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_190"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_190"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_190"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_190"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_190_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_190_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_190_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_190_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_190_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_190")));
		_dataArray.Add(new InformationInfoItem(191, LocalStringManager.GetConfig("InformationInfo_language", "Name_191"), 2, 7, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_191"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_191"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_191"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_191"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_191_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_191_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_191_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_191_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_191_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_191")));
		_dataArray.Add(new InformationInfoItem(192, LocalStringManager.GetConfig("InformationInfo_language", "Name_192"), 3, 7, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_192"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_192"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_192"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_192"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_192_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_192_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_192_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_192_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_192_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_192")));
		_dataArray.Add(new InformationInfoItem(193, LocalStringManager.GetConfig("InformationInfo_language", "Name_193"), 4, 7, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_193"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_193"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_193"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_193"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_193_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_193_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_193_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_193_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_193_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_193")));
		_dataArray.Add(new InformationInfoItem(194, LocalStringManager.GetConfig("InformationInfo_language", "Name_194"), 5, 7, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_194"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_194"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_194"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_194"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_194_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_194_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_194_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_194_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_194_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_194")));
		_dataArray.Add(new InformationInfoItem(195, LocalStringManager.GetConfig("InformationInfo_language", "Name_195"), 6, 7, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_195"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_195"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_195"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_195"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_195_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_195_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_195_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_195_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_195_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_195")));
		_dataArray.Add(new InformationInfoItem(196, LocalStringManager.GetConfig("InformationInfo_language", "Name_196"), 7, 7, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_196"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_196"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_196"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_196"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_196_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_196_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_196_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_196_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_196_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_196")));
		_dataArray.Add(new InformationInfoItem(197, LocalStringManager.GetConfig("InformationInfo_language", "Name_197"), 8, 7, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_197"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_197"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_197"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_197"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_197_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_197_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_197_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_197_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_197_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_197")));
		_dataArray.Add(new InformationInfoItem(198, LocalStringManager.GetConfig("InformationInfo_language", "Name_198"), 0, 8, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_198"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_198"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_198"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_198"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_198_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_198_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_198_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_198_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_198_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_198")));
		_dataArray.Add(new InformationInfoItem(199, LocalStringManager.GetConfig("InformationInfo_language", "Name_199"), 1, 8, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_199"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_199"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_199"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_199"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_199_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_199_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_199_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_199_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_199_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_199")));
		_dataArray.Add(new InformationInfoItem(200, LocalStringManager.GetConfig("InformationInfo_language", "Name_200"), 2, 8, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_200"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_200"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_200"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_200"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_200_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_200_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_200_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_200_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_200_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_200")));
		_dataArray.Add(new InformationInfoItem(201, LocalStringManager.GetConfig("InformationInfo_language", "Name_201"), 3, 8, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_201"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_201"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_201"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_201"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_201_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_201_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_201_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_201_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_201_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_201")));
		_dataArray.Add(new InformationInfoItem(202, LocalStringManager.GetConfig("InformationInfo_language", "Name_202"), 4, 8, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_202"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_202"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_202"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_202"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_202_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_202_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_202_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_202_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_202_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_202")));
		_dataArray.Add(new InformationInfoItem(203, LocalStringManager.GetConfig("InformationInfo_language", "Name_203"), 5, 8, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_203"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_203"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_203"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_203"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_203_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_203_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_203_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_203_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_203_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_203")));
		_dataArray.Add(new InformationInfoItem(204, LocalStringManager.GetConfig("InformationInfo_language", "Name_204"), 6, 8, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_204"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_204"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_204"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_204"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_204_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_204_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_204_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_204_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_204_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_204")));
		_dataArray.Add(new InformationInfoItem(205, LocalStringManager.GetConfig("InformationInfo_language", "Name_205"), 7, 8, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_205"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_205"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_205"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_205"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_205_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_205_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_205_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_205_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_205_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_205")));
		_dataArray.Add(new InformationInfoItem(206, LocalStringManager.GetConfig("InformationInfo_language", "Name_206"), 8, 8, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_206"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_206"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_206"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_206"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_206_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_206_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_206_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_206_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_206_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_206")));
		_dataArray.Add(new InformationInfoItem(207, LocalStringManager.GetConfig("InformationInfo_language", "Name_207"), 0, 9, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_207"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_207"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_207"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_207"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_207_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_207_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_207_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_207_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_207_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_207")));
		_dataArray.Add(new InformationInfoItem(208, LocalStringManager.GetConfig("InformationInfo_language", "Name_208"), 1, 9, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_208"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_208"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_208"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_208"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_208_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_208_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_208_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_208_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_208_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_208")));
		_dataArray.Add(new InformationInfoItem(209, LocalStringManager.GetConfig("InformationInfo_language", "Name_209"), 2, 9, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_209"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_209"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_209"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_209"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_209_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_209_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_209_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_209_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_209_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_209")));
		_dataArray.Add(new InformationInfoItem(210, LocalStringManager.GetConfig("InformationInfo_language", "Name_210"), 3, 9, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_210"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_210"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_210"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_210"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_210_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_210_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_210_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_210_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_210_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_210")));
		_dataArray.Add(new InformationInfoItem(211, LocalStringManager.GetConfig("InformationInfo_language", "Name_211"), 4, 9, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_211"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_211"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_211"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_211"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_211_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_211_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_211_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_211_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_211_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_211")));
		_dataArray.Add(new InformationInfoItem(212, LocalStringManager.GetConfig("InformationInfo_language", "Name_212"), 5, 9, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_212"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_212"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_212"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_212"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_212_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_212_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_212_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_212_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_212_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_212")));
		_dataArray.Add(new InformationInfoItem(213, LocalStringManager.GetConfig("InformationInfo_language", "Name_213"), 6, 9, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_213"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_213"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_213"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_213"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_213_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_213_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_213_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_213_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_213_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_213")));
		_dataArray.Add(new InformationInfoItem(214, LocalStringManager.GetConfig("InformationInfo_language", "Name_214"), 7, 9, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_214"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_214"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_214"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_214"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_214_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_214_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_214_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_214_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_214_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_214")));
		_dataArray.Add(new InformationInfoItem(215, LocalStringManager.GetConfig("InformationInfo_language", "Name_215"), 8, 9, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_215"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_215"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_215"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_215"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_215_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_215_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_215_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_215_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_215_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_215")));
		_dataArray.Add(new InformationInfoItem(216, LocalStringManager.GetConfig("InformationInfo_language", "Name_216"), 0, 10, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_216"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_216"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_216"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_216"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_216_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_216_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_216_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_216_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_216_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_216")));
		_dataArray.Add(new InformationInfoItem(217, LocalStringManager.GetConfig("InformationInfo_language", "Name_217"), 1, 10, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_217"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_217"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_217"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_217"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_217_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_217_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_217_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_217_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_217_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_217")));
		_dataArray.Add(new InformationInfoItem(218, LocalStringManager.GetConfig("InformationInfo_language", "Name_218"), 2, 10, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_218"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_218"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_218"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_218"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_218_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_218_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_218_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_218_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_218_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_218")));
		_dataArray.Add(new InformationInfoItem(219, LocalStringManager.GetConfig("InformationInfo_language", "Name_219"), 3, 10, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_219"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_219"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_219"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_219"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_219_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_219_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_219_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_219_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_219_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_219")));
		_dataArray.Add(new InformationInfoItem(220, LocalStringManager.GetConfig("InformationInfo_language", "Name_220"), 4, 10, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_220"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_220"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_220"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_220"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_220_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_220_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_220_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_220_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_220_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_220")));
		_dataArray.Add(new InformationInfoItem(221, LocalStringManager.GetConfig("InformationInfo_language", "Name_221"), 5, 10, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_221"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_221"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_221"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_221"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_221_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_221_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_221_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_221_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_221_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_221")));
		_dataArray.Add(new InformationInfoItem(222, LocalStringManager.GetConfig("InformationInfo_language", "Name_222"), 6, 10, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_222"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_222"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_222"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_222"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_222_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_222_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_222_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_222_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_222_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_222")));
		_dataArray.Add(new InformationInfoItem(223, LocalStringManager.GetConfig("InformationInfo_language", "Name_223"), 7, 10, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_223"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_223"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_223"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_223"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_223_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_223_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_223_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_223_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_223_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_223")));
		_dataArray.Add(new InformationInfoItem(224, LocalStringManager.GetConfig("InformationInfo_language", "Name_224"), 8, 10, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_224"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_224"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_224"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_224"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_224_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_224_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_224_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_224_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_224_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_224")));
		_dataArray.Add(new InformationInfoItem(225, LocalStringManager.GetConfig("InformationInfo_language", "Name_225"), 0, 11, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_225"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_225"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_225"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_225"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_225_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_225_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_225_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_225_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_225_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_225")));
		_dataArray.Add(new InformationInfoItem(226, LocalStringManager.GetConfig("InformationInfo_language", "Name_226"), 1, 11, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_226"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_226"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_226"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_226"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_226_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_226_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_226_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_226_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_226_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_226")));
		_dataArray.Add(new InformationInfoItem(227, LocalStringManager.GetConfig("InformationInfo_language", "Name_227"), 2, 11, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_227"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_227"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_227"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_227"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_227_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_227_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_227_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_227_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_227_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_227")));
		_dataArray.Add(new InformationInfoItem(228, LocalStringManager.GetConfig("InformationInfo_language", "Name_228"), 3, 11, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_228"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_228"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_228"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_228"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_228_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_228_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_228_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_228_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_228_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_228")));
		_dataArray.Add(new InformationInfoItem(229, LocalStringManager.GetConfig("InformationInfo_language", "Name_229"), 4, 11, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_229"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_229"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_229"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_229"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_229_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_229_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_229_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_229_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_229_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_229")));
		_dataArray.Add(new InformationInfoItem(230, LocalStringManager.GetConfig("InformationInfo_language", "Name_230"), 5, 11, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_230"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_230"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_230"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_230"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_230_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_230_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_230_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_230_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_230_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_230")));
		_dataArray.Add(new InformationInfoItem(231, LocalStringManager.GetConfig("InformationInfo_language", "Name_231"), 6, 11, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_231"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_231"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_231"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_231"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_231_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_231_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_231_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_231_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_231_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_231")));
		_dataArray.Add(new InformationInfoItem(232, LocalStringManager.GetConfig("InformationInfo_language", "Name_232"), 7, 11, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_232"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_232"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_232"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_232"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_232_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_232_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_232_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_232_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_232_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_232")));
		_dataArray.Add(new InformationInfoItem(233, LocalStringManager.GetConfig("InformationInfo_language", "Name_233"), 8, 11, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_233"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_233"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_233"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_233"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_233_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_233_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_233_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_233_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_233_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_233")));
		_dataArray.Add(new InformationInfoItem(234, LocalStringManager.GetConfig("InformationInfo_language", "Name_234"), 0, 12, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_234"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_234"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_234"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_234"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_234_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_234_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_234_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_234_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_234_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_234")));
		_dataArray.Add(new InformationInfoItem(235, LocalStringManager.GetConfig("InformationInfo_language", "Name_235"), 1, 12, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_235"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_235"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_235"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_235"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_235_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_235_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_235_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_235_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_235_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_235")));
		_dataArray.Add(new InformationInfoItem(236, LocalStringManager.GetConfig("InformationInfo_language", "Name_236"), 2, 12, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_236"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_236"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_236"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_236"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_236_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_236_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_236_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_236_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_236_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_236")));
		_dataArray.Add(new InformationInfoItem(237, LocalStringManager.GetConfig("InformationInfo_language", "Name_237"), 3, 12, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_237"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_237"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_237"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_237"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_237_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_237_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_237_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_237_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_237_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_237")));
		_dataArray.Add(new InformationInfoItem(238, LocalStringManager.GetConfig("InformationInfo_language", "Name_238"), 4, 12, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_238"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_238"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_238"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_238"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_238_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_238_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_238_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_238_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_238_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_238")));
		_dataArray.Add(new InformationInfoItem(239, LocalStringManager.GetConfig("InformationInfo_language", "Name_239"), 5, 12, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_239"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_239"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_239"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_239"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_239_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_239_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_239_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_239_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_239_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_239")));
	}

	private void CreateItems4()
	{
		_dataArray.Add(new InformationInfoItem(240, LocalStringManager.GetConfig("InformationInfo_language", "Name_240"), 6, 12, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_240"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_240"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_240"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_240"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_240_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_240_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_240_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_240_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_240_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_240")));
		_dataArray.Add(new InformationInfoItem(241, LocalStringManager.GetConfig("InformationInfo_language", "Name_241"), 7, 12, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_241"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_241"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_241"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_241"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_241_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_241_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_241_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_241_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_241_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_241")));
		_dataArray.Add(new InformationInfoItem(242, LocalStringManager.GetConfig("InformationInfo_language", "Name_242"), 8, 12, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_242"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_242"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_242"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_242"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_242_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_242_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_242_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_242_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_242_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_242")));
		_dataArray.Add(new InformationInfoItem(243, LocalStringManager.GetConfig("InformationInfo_language", "Name_243"), 0, 13, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_243"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_243"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_243"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_243"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_243_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_243_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_243_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_243_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_243_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_243")));
		_dataArray.Add(new InformationInfoItem(244, LocalStringManager.GetConfig("InformationInfo_language", "Name_244"), 1, 13, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_244"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_244"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_244"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_244"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_244_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_244_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_244_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_244_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_244_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_244")));
		_dataArray.Add(new InformationInfoItem(245, LocalStringManager.GetConfig("InformationInfo_language", "Name_245"), 2, 13, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_245"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_245"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_245"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_245"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_245_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_245_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_245_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_245_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_245_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_245")));
		_dataArray.Add(new InformationInfoItem(246, LocalStringManager.GetConfig("InformationInfo_language", "Name_246"), 3, 13, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_246"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_246"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_246"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_246"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_246_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_246_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_246_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_246_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_246_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_246")));
		_dataArray.Add(new InformationInfoItem(247, LocalStringManager.GetConfig("InformationInfo_language", "Name_247"), 4, 13, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_247"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_247"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_247"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_247"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_247_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_247_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_247_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_247_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_247_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_247")));
		_dataArray.Add(new InformationInfoItem(248, LocalStringManager.GetConfig("InformationInfo_language", "Name_248"), 5, 13, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_248"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_248"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_248"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_248"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_248_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_248_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_248_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_248_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_248_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_248")));
		_dataArray.Add(new InformationInfoItem(249, LocalStringManager.GetConfig("InformationInfo_language", "Name_249"), 6, 13, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_249"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_249"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_249"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_249"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_249_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_249_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_249_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_249_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_249_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_249")));
		_dataArray.Add(new InformationInfoItem(250, LocalStringManager.GetConfig("InformationInfo_language", "Name_250"), 7, 13, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_250"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_250"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_250"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_250"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_250_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_250_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_250_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_250_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_250_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_250")));
		_dataArray.Add(new InformationInfoItem(251, LocalStringManager.GetConfig("InformationInfo_language", "Name_251"), 8, 13, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_251"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_251"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_251"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_251"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_251_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_251_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_251_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_251_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_251_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_251")));
		_dataArray.Add(new InformationInfoItem(252, LocalStringManager.GetConfig("InformationInfo_language", "Name_252"), 0, 14, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_252"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_252"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_252"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_252"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_252_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_252_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_252_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_252_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_252_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_252")));
		_dataArray.Add(new InformationInfoItem(253, LocalStringManager.GetConfig("InformationInfo_language", "Name_253"), 1, 14, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_253"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_253"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_253"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_253"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_253_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_253_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_253_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_253_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_253_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_253")));
		_dataArray.Add(new InformationInfoItem(254, LocalStringManager.GetConfig("InformationInfo_language", "Name_254"), 2, 14, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_254"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_254"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_254"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_254"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_254_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_254_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_254_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_254_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_254_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_254")));
		_dataArray.Add(new InformationInfoItem(255, LocalStringManager.GetConfig("InformationInfo_language", "Name_255"), 3, 14, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_255"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_255"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_255"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_255"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_255_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_255_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_255_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_255_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_255_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_255")));
		_dataArray.Add(new InformationInfoItem(256, LocalStringManager.GetConfig("InformationInfo_language", "Name_256"), 4, 14, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_256"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_256"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_256"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_256"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_256_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_256_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_256_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_256_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_256_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_256")));
		_dataArray.Add(new InformationInfoItem(257, LocalStringManager.GetConfig("InformationInfo_language", "Name_257"), 5, 14, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_257"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_257"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_257"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_257"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_257_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_257_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_257_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_257_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_257_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_257")));
		_dataArray.Add(new InformationInfoItem(258, LocalStringManager.GetConfig("InformationInfo_language", "Name_258"), 6, 14, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_258"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_258"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_258"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_258"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_258_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_258_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_258_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_258_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_258_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_258")));
		_dataArray.Add(new InformationInfoItem(259, LocalStringManager.GetConfig("InformationInfo_language", "Name_259"), 7, 14, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_259"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_259"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_259"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_259"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_259_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_259_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_259_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_259_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_259_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_259")));
		_dataArray.Add(new InformationInfoItem(260, LocalStringManager.GetConfig("InformationInfo_language", "Name_260"), 8, 14, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_260"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_260"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_260"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_260"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_260_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_260_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_260_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_260_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_260_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_260")));
		_dataArray.Add(new InformationInfoItem(261, LocalStringManager.GetConfig("InformationInfo_language", "Name_261"), 0, 15, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_261"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_261"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_261"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_261"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_261_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_261_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_261_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_261_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_261_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_261")));
		_dataArray.Add(new InformationInfoItem(262, LocalStringManager.GetConfig("InformationInfo_language", "Name_262"), 1, 15, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_262"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_262"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_262"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_262"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_262_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_262_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_262_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_262_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_262_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_262")));
		_dataArray.Add(new InformationInfoItem(263, LocalStringManager.GetConfig("InformationInfo_language", "Name_263"), 2, 15, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_263"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_263"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_263"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_263"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_263_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_263_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_263_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_263_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_263_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_263")));
		_dataArray.Add(new InformationInfoItem(264, LocalStringManager.GetConfig("InformationInfo_language", "Name_264"), 3, 15, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_264"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_264"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_264"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_264"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_264_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_264_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_264_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_264_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_264_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_264")));
		_dataArray.Add(new InformationInfoItem(265, LocalStringManager.GetConfig("InformationInfo_language", "Name_265"), 4, 15, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_265"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_265"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_265"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_265"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_265_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_265_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_265_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_265_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_265_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_265")));
		_dataArray.Add(new InformationInfoItem(266, LocalStringManager.GetConfig("InformationInfo_language", "Name_266"), 5, 15, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_266"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_266"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_266"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_266"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_266_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_266_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_266_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_266_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_266_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_266")));
		_dataArray.Add(new InformationInfoItem(267, LocalStringManager.GetConfig("InformationInfo_language", "Name_267"), 6, 15, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_267"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_267"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_267"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_267"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_267_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_267_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_267_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_267_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_267_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_267")));
		_dataArray.Add(new InformationInfoItem(268, LocalStringManager.GetConfig("InformationInfo_language", "Name_268"), 7, 15, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_268"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_268"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_268"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_268"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_268_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_268_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_268_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_268_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_268_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_268")));
		_dataArray.Add(new InformationInfoItem(269, LocalStringManager.GetConfig("InformationInfo_language", "Name_269"), 8, 15, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_269"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_269"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_269"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_269"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_269_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_269_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_269_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_269_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_269_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_269")));
		_dataArray.Add(new InformationInfoItem(270, LocalStringManager.GetConfig("InformationInfo_language", "Name_270"), 0, -1, 0, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_270"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_270"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_270"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_270"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_270_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_270_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_270_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_270_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_270_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_270")));
		_dataArray.Add(new InformationInfoItem(271, LocalStringManager.GetConfig("InformationInfo_language", "Name_271"), 1, -1, 0, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_271"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_271"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_271"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_271"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_271_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_271_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_271_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_271_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_271_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_271")));
		_dataArray.Add(new InformationInfoItem(272, LocalStringManager.GetConfig("InformationInfo_language", "Name_272"), 2, -1, 0, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_272"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_272"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_272"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_272"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_272_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_272_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_272_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_272_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_272_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_272")));
		_dataArray.Add(new InformationInfoItem(273, LocalStringManager.GetConfig("InformationInfo_language", "Name_273"), 3, -1, 0, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_273"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_273"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_273"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_273"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_273_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_273_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_273_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_273_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_273_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_273")));
		_dataArray.Add(new InformationInfoItem(274, LocalStringManager.GetConfig("InformationInfo_language", "Name_274"), 4, -1, 0, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_274"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_274"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_274"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_274"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_274_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_274_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_274_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_274_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_274_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_274")));
		_dataArray.Add(new InformationInfoItem(275, LocalStringManager.GetConfig("InformationInfo_language", "Name_275"), 5, -1, 0, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_275"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_275"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_275"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_275"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_275_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_275_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_275_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_275_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_275_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_275")));
		_dataArray.Add(new InformationInfoItem(276, LocalStringManager.GetConfig("InformationInfo_language", "Name_276"), 6, -1, 0, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_276"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_276"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_276"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_276"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_276_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_276_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_276_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_276_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_276_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_276")));
		_dataArray.Add(new InformationInfoItem(277, LocalStringManager.GetConfig("InformationInfo_language", "Name_277"), 7, -1, 0, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_277"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_277"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_277"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_277"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_277_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_277_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_277_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_277_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_277_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_277")));
		_dataArray.Add(new InformationInfoItem(278, LocalStringManager.GetConfig("InformationInfo_language", "Name_278"), 8, -1, 0, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_278"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_278"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_278"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_278"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_278_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_278_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_278_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_278_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_278_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_278")));
		_dataArray.Add(new InformationInfoItem(279, LocalStringManager.GetConfig("InformationInfo_language", "Name_279"), 0, -1, 1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_279"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_279"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_279"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_279"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_279_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_279_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_279_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_279_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_279_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_279")));
		_dataArray.Add(new InformationInfoItem(280, LocalStringManager.GetConfig("InformationInfo_language", "Name_280"), 1, -1, 1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_280"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_280"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_280"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_280"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_280_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_280_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_280_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_280_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_280_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_280")));
		_dataArray.Add(new InformationInfoItem(281, LocalStringManager.GetConfig("InformationInfo_language", "Name_281"), 2, -1, 1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_281"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_281"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_281"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_281"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_281_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_281_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_281_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_281_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_281_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_281")));
		_dataArray.Add(new InformationInfoItem(282, LocalStringManager.GetConfig("InformationInfo_language", "Name_282"), 3, -1, 1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_282"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_282"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_282"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_282"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_282_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_282_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_282_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_282_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_282_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_282")));
		_dataArray.Add(new InformationInfoItem(283, LocalStringManager.GetConfig("InformationInfo_language", "Name_283"), 4, -1, 1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_283"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_283"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_283"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_283"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_283_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_283_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_283_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_283_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_283_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_283")));
		_dataArray.Add(new InformationInfoItem(284, LocalStringManager.GetConfig("InformationInfo_language", "Name_284"), 5, -1, 1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_284"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_284"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_284"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_284"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_284_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_284_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_284_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_284_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_284_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_284")));
		_dataArray.Add(new InformationInfoItem(285, LocalStringManager.GetConfig("InformationInfo_language", "Name_285"), 6, -1, 1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_285"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_285"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_285"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_285"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_285_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_285_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_285_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_285_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_285_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_285")));
		_dataArray.Add(new InformationInfoItem(286, LocalStringManager.GetConfig("InformationInfo_language", "Name_286"), 7, -1, 1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_286"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_286"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_286"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_286"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_286_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_286_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_286_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_286_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_286_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_286")));
		_dataArray.Add(new InformationInfoItem(287, LocalStringManager.GetConfig("InformationInfo_language", "Name_287"), 8, -1, 1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_287"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_287"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_287"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_287"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_287_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_287_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_287_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_287_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_287_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_287")));
		_dataArray.Add(new InformationInfoItem(288, LocalStringManager.GetConfig("InformationInfo_language", "Name_288"), 0, -1, 2, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_288"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_288"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_288"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_288"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_288_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_288_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_288_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_288_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_288_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_288")));
		_dataArray.Add(new InformationInfoItem(289, LocalStringManager.GetConfig("InformationInfo_language", "Name_289"), 1, -1, 2, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_289"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_289"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_289"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_289"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_289_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_289_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_289_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_289_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_289_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_289")));
		_dataArray.Add(new InformationInfoItem(290, LocalStringManager.GetConfig("InformationInfo_language", "Name_290"), 2, -1, 2, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_290"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_290"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_290"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_290"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_290_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_290_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_290_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_290_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_290_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_290")));
		_dataArray.Add(new InformationInfoItem(291, LocalStringManager.GetConfig("InformationInfo_language", "Name_291"), 3, -1, 2, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_291"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_291"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_291"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_291"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_291_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_291_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_291_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_291_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_291_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_291")));
		_dataArray.Add(new InformationInfoItem(292, LocalStringManager.GetConfig("InformationInfo_language", "Name_292"), 4, -1, 2, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_292"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_292"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_292"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_292"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_292_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_292_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_292_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_292_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_292_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_292")));
		_dataArray.Add(new InformationInfoItem(293, LocalStringManager.GetConfig("InformationInfo_language", "Name_293"), 5, -1, 2, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_293"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_293"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_293"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_293"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_293_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_293_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_293_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_293_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_293_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_293")));
		_dataArray.Add(new InformationInfoItem(294, LocalStringManager.GetConfig("InformationInfo_language", "Name_294"), 6, -1, 2, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_294"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_294"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_294"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_294"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_294_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_294_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_294_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_294_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_294_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_294")));
		_dataArray.Add(new InformationInfoItem(295, LocalStringManager.GetConfig("InformationInfo_language", "Name_295"), 7, -1, 2, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_295"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_295"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_295"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_295"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_295_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_295_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_295_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_295_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_295_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_295")));
		_dataArray.Add(new InformationInfoItem(296, LocalStringManager.GetConfig("InformationInfo_language", "Name_296"), 8, -1, 2, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_296"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_296"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_296"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_296"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_296_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_296_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_296_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_296_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_296_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_296")));
		_dataArray.Add(new InformationInfoItem(297, LocalStringManager.GetConfig("InformationInfo_language", "Name_297"), 0, -1, 3, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_297"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_297"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_297"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_297"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_297_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_297_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_297_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_297_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_297_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_297")));
		_dataArray.Add(new InformationInfoItem(298, LocalStringManager.GetConfig("InformationInfo_language", "Name_298"), 1, -1, 3, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_298"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_298"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_298"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_298"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_298_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_298_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_298_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_298_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_298_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_298")));
		_dataArray.Add(new InformationInfoItem(299, LocalStringManager.GetConfig("InformationInfo_language", "Name_299"), 2, -1, 3, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_299"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_299"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_299"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_299"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_299_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_299_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_299_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_299_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_299_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_299")));
	}

	private void CreateItems5()
	{
		_dataArray.Add(new InformationInfoItem(300, LocalStringManager.GetConfig("InformationInfo_language", "Name_300"), 3, -1, 3, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_300"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_300"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_300"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_300"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_300_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_300_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_300_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_300_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_300_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_300")));
		_dataArray.Add(new InformationInfoItem(301, LocalStringManager.GetConfig("InformationInfo_language", "Name_301"), 4, -1, 3, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_301"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_301"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_301"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_301"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_301_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_301_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_301_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_301_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_301_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_301")));
		_dataArray.Add(new InformationInfoItem(302, LocalStringManager.GetConfig("InformationInfo_language", "Name_302"), 5, -1, 3, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_302"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_302"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_302"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_302"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_302_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_302_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_302_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_302_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_302_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_302")));
		_dataArray.Add(new InformationInfoItem(303, LocalStringManager.GetConfig("InformationInfo_language", "Name_303"), 6, -1, 3, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_303"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_303"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_303"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_303"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_303_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_303_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_303_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_303_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_303_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_303")));
		_dataArray.Add(new InformationInfoItem(304, LocalStringManager.GetConfig("InformationInfo_language", "Name_304"), 7, -1, 3, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_304"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_304"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_304"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_304"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_304_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_304_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_304_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_304_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_304_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_304")));
		_dataArray.Add(new InformationInfoItem(305, LocalStringManager.GetConfig("InformationInfo_language", "Name_305"), 8, -1, 3, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_305"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_305"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_305"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_305"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_305_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_305_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_305_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_305_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_305_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_305")));
		_dataArray.Add(new InformationInfoItem(306, LocalStringManager.GetConfig("InformationInfo_language", "Name_306"), 0, -1, 4, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_306"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_306"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_306"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_306"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_306_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_306_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_306_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_306_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_306_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_306")));
		_dataArray.Add(new InformationInfoItem(307, LocalStringManager.GetConfig("InformationInfo_language", "Name_307"), 1, -1, 4, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_307"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_307"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_307"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_307"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_307_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_307_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_307_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_307_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_307_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_307")));
		_dataArray.Add(new InformationInfoItem(308, LocalStringManager.GetConfig("InformationInfo_language", "Name_308"), 2, -1, 4, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_308"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_308"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_308"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_308"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_308_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_308_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_308_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_308_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_308_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_308")));
		_dataArray.Add(new InformationInfoItem(309, LocalStringManager.GetConfig("InformationInfo_language", "Name_309"), 3, -1, 4, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_309"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_309"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_309"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_309"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_309_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_309_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_309_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_309_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_309_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_309")));
		_dataArray.Add(new InformationInfoItem(310, LocalStringManager.GetConfig("InformationInfo_language", "Name_310"), 4, -1, 4, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_310"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_310"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_310"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_310"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_310_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_310_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_310_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_310_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_310_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_310")));
		_dataArray.Add(new InformationInfoItem(311, LocalStringManager.GetConfig("InformationInfo_language", "Name_311"), 5, -1, 4, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_311"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_311"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_311"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_311"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_311_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_311_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_311_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_311_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_311_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_311")));
		_dataArray.Add(new InformationInfoItem(312, LocalStringManager.GetConfig("InformationInfo_language", "Name_312"), 6, -1, 4, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_312"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_312"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_312"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_312"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_312_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_312_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_312_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_312_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_312_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_312")));
		_dataArray.Add(new InformationInfoItem(313, LocalStringManager.GetConfig("InformationInfo_language", "Name_313"), 7, -1, 4, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_313"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_313"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_313"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_313"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_313_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_313_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_313_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_313_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_313_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_313")));
		_dataArray.Add(new InformationInfoItem(314, LocalStringManager.GetConfig("InformationInfo_language", "Name_314"), 8, -1, 4, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_314"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_314"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_314"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_314"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_314_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_314_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_314_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_314_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_314_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_314")));
		_dataArray.Add(new InformationInfoItem(315, LocalStringManager.GetConfig("InformationInfo_language", "Name_315"), 0, -1, 5, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_315"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_315"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_315"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_315"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_315_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_315_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_315_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_315_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_315_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_315")));
		_dataArray.Add(new InformationInfoItem(316, LocalStringManager.GetConfig("InformationInfo_language", "Name_316"), 1, -1, 5, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_316"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_316"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_316"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_316"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_316_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_316_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_316_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_316_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_316_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_316")));
		_dataArray.Add(new InformationInfoItem(317, LocalStringManager.GetConfig("InformationInfo_language", "Name_317"), 2, -1, 5, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_317"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_317"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_317"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_317"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_317_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_317_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_317_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_317_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_317_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_317")));
		_dataArray.Add(new InformationInfoItem(318, LocalStringManager.GetConfig("InformationInfo_language", "Name_318"), 3, -1, 5, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_318"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_318"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_318"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_318"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_318_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_318_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_318_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_318_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_318_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_318")));
		_dataArray.Add(new InformationInfoItem(319, LocalStringManager.GetConfig("InformationInfo_language", "Name_319"), 4, -1, 5, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_319"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_319"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_319"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_319"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_319_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_319_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_319_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_319_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_319_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_319")));
		_dataArray.Add(new InformationInfoItem(320, LocalStringManager.GetConfig("InformationInfo_language", "Name_320"), 5, -1, 5, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_320"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_320"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_320"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_320"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_320_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_320_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_320_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_320_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_320_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_320")));
		_dataArray.Add(new InformationInfoItem(321, LocalStringManager.GetConfig("InformationInfo_language", "Name_321"), 6, -1, 5, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_321"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_321"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_321"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_321"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_321_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_321_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_321_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_321_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_321_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_321")));
		_dataArray.Add(new InformationInfoItem(322, LocalStringManager.GetConfig("InformationInfo_language", "Name_322"), 7, -1, 5, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_322"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_322"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_322"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_322"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_322_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_322_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_322_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_322_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_322_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_322")));
		_dataArray.Add(new InformationInfoItem(323, LocalStringManager.GetConfig("InformationInfo_language", "Name_323"), 8, -1, 5, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_323"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_323"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_323"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_323"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_323_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_323_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_323_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_323_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_323_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_323")));
		_dataArray.Add(new InformationInfoItem(324, LocalStringManager.GetConfig("InformationInfo_language", "Name_324"), 0, -1, 6, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_324"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_324"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_324"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_324"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_324_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_324_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_324_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_324_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_324_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_324")));
		_dataArray.Add(new InformationInfoItem(325, LocalStringManager.GetConfig("InformationInfo_language", "Name_325"), 1, -1, 6, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_325"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_325"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_325"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_325"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_325_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_325_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_325_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_325_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_325_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_325")));
		_dataArray.Add(new InformationInfoItem(326, LocalStringManager.GetConfig("InformationInfo_language", "Name_326"), 2, -1, 6, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_326"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_326"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_326"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_326"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_326_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_326_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_326_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_326_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_326_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_326")));
		_dataArray.Add(new InformationInfoItem(327, LocalStringManager.GetConfig("InformationInfo_language", "Name_327"), 3, -1, 6, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_327"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_327"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_327"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_327"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_327_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_327_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_327_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_327_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_327_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_327")));
		_dataArray.Add(new InformationInfoItem(328, LocalStringManager.GetConfig("InformationInfo_language", "Name_328"), 4, -1, 6, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_328"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_328"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_328"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_328"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_328_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_328_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_328_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_328_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_328_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_328")));
		_dataArray.Add(new InformationInfoItem(329, LocalStringManager.GetConfig("InformationInfo_language", "Name_329"), 5, -1, 6, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_329"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_329"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_329"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_329"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_329_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_329_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_329_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_329_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_329_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_329")));
		_dataArray.Add(new InformationInfoItem(330, LocalStringManager.GetConfig("InformationInfo_language", "Name_330"), 6, -1, 6, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_330"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_330"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_330"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_330"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_330_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_330_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_330_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_330_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_330_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_330")));
		_dataArray.Add(new InformationInfoItem(331, LocalStringManager.GetConfig("InformationInfo_language", "Name_331"), 7, -1, 6, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_331"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_331"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_331"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_331"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_331_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_331_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_331_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_331_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_331_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_331")));
		_dataArray.Add(new InformationInfoItem(332, LocalStringManager.GetConfig("InformationInfo_language", "Name_332"), 8, -1, 6, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_332"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_332"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_332"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_332"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_332_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_332_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_332_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_332_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_332_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_332")));
		_dataArray.Add(new InformationInfoItem(333, LocalStringManager.GetConfig("InformationInfo_language", "Name_333"), 0, -1, 7, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_333"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_333"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_333"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_333"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_333_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_333_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_333_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_333_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_333_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_333")));
		_dataArray.Add(new InformationInfoItem(334, LocalStringManager.GetConfig("InformationInfo_language", "Name_334"), 1, -1, 7, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_334"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_334"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_334"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_334"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_334_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_334_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_334_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_334_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_334_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_334")));
		_dataArray.Add(new InformationInfoItem(335, LocalStringManager.GetConfig("InformationInfo_language", "Name_335"), 2, -1, 7, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_335"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_335"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_335"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_335"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_335_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_335_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_335_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_335_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_335_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_335")));
		_dataArray.Add(new InformationInfoItem(336, LocalStringManager.GetConfig("InformationInfo_language", "Name_336"), 3, -1, 7, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_336"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_336"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_336"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_336"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_336_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_336_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_336_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_336_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_336_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_336")));
		_dataArray.Add(new InformationInfoItem(337, LocalStringManager.GetConfig("InformationInfo_language", "Name_337"), 4, -1, 7, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_337"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_337"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_337"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_337"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_337_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_337_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_337_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_337_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_337_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_337")));
		_dataArray.Add(new InformationInfoItem(338, LocalStringManager.GetConfig("InformationInfo_language", "Name_338"), 5, -1, 7, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_338"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_338"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_338"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_338"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_338_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_338_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_338_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_338_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_338_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_338")));
		_dataArray.Add(new InformationInfoItem(339, LocalStringManager.GetConfig("InformationInfo_language", "Name_339"), 6, -1, 7, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_339"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_339"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_339"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_339"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_339_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_339_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_339_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_339_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_339_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_339")));
		_dataArray.Add(new InformationInfoItem(340, LocalStringManager.GetConfig("InformationInfo_language", "Name_340"), 7, -1, 7, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_340"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_340"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_340"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_340"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_340_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_340_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_340_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_340_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_340_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_340")));
		_dataArray.Add(new InformationInfoItem(341, LocalStringManager.GetConfig("InformationInfo_language", "Name_341"), 8, -1, 7, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_341"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_341"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_341"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_341"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_341_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_341_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_341_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_341_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_341_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_341")));
		_dataArray.Add(new InformationInfoItem(342, LocalStringManager.GetConfig("InformationInfo_language", "Name_342"), 0, -1, 8, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_342"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_342"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_342"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_342"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_342_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_342_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_342_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_342_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_342_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_342")));
		_dataArray.Add(new InformationInfoItem(343, LocalStringManager.GetConfig("InformationInfo_language", "Name_343"), 1, -1, 8, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_343"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_343"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_343"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_343"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_343_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_343_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_343_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_343_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_343_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_343")));
		_dataArray.Add(new InformationInfoItem(344, LocalStringManager.GetConfig("InformationInfo_language", "Name_344"), 2, -1, 8, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_344"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_344"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_344"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_344"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_344_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_344_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_344_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_344_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_344_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_344")));
		_dataArray.Add(new InformationInfoItem(345, LocalStringManager.GetConfig("InformationInfo_language", "Name_345"), 3, -1, 8, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_345"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_345"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_345"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_345"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_345_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_345_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_345_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_345_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_345_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_345")));
		_dataArray.Add(new InformationInfoItem(346, LocalStringManager.GetConfig("InformationInfo_language", "Name_346"), 4, -1, 8, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_346"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_346"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_346"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_346"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_346_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_346_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_346_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_346_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_346_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_346")));
		_dataArray.Add(new InformationInfoItem(347, LocalStringManager.GetConfig("InformationInfo_language", "Name_347"), 5, -1, 8, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_347"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_347"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_347"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_347"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_347_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_347_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_347_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_347_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_347_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_347")));
		_dataArray.Add(new InformationInfoItem(348, LocalStringManager.GetConfig("InformationInfo_language", "Name_348"), 6, -1, 8, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_348"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_348"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_348"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_348"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_348_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_348_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_348_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_348_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_348_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_348")));
		_dataArray.Add(new InformationInfoItem(349, LocalStringManager.GetConfig("InformationInfo_language", "Name_349"), 7, -1, 8, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_349"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_349"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_349"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_349"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_349_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_349_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_349_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_349_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_349_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_349")));
		_dataArray.Add(new InformationInfoItem(350, LocalStringManager.GetConfig("InformationInfo_language", "Name_350"), 8, -1, 8, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_350"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_350"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_350"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_350"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_350_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_350_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_350_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_350_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_350_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_350")));
		_dataArray.Add(new InformationInfoItem(351, LocalStringManager.GetConfig("InformationInfo_language", "Name_351"), 0, -1, 9, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_351"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_351"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_351"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_351"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_351_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_351_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_351_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_351_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_351_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_351")));
		_dataArray.Add(new InformationInfoItem(352, LocalStringManager.GetConfig("InformationInfo_language", "Name_352"), 1, -1, 9, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_352"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_352"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_352"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_352"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_352_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_352_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_352_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_352_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_352_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_352")));
		_dataArray.Add(new InformationInfoItem(353, LocalStringManager.GetConfig("InformationInfo_language", "Name_353"), 2, -1, 9, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_353"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_353"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_353"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_353"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_353_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_353_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_353_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_353_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_353_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_353")));
		_dataArray.Add(new InformationInfoItem(354, LocalStringManager.GetConfig("InformationInfo_language", "Name_354"), 3, -1, 9, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_354"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_354"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_354"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_354"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_354_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_354_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_354_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_354_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_354_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_354")));
		_dataArray.Add(new InformationInfoItem(355, LocalStringManager.GetConfig("InformationInfo_language", "Name_355"), 4, -1, 9, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_355"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_355"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_355"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_355"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_355_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_355_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_355_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_355_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_355_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_355")));
		_dataArray.Add(new InformationInfoItem(356, LocalStringManager.GetConfig("InformationInfo_language", "Name_356"), 5, -1, 9, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_356"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_356"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_356"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_356"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_356_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_356_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_356_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_356_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_356_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_356")));
		_dataArray.Add(new InformationInfoItem(357, LocalStringManager.GetConfig("InformationInfo_language", "Name_357"), 6, -1, 9, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_357"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_357"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_357"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_357"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_357_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_357_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_357_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_357_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_357_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_357")));
		_dataArray.Add(new InformationInfoItem(358, LocalStringManager.GetConfig("InformationInfo_language", "Name_358"), 7, -1, 9, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_358"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_358"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_358"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_358"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_358_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_358_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_358_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_358_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_358_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_358")));
		_dataArray.Add(new InformationInfoItem(359, LocalStringManager.GetConfig("InformationInfo_language", "Name_359"), 8, -1, 9, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_359"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_359"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_359"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_359"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_359_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_359_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_359_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_359_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_359_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_359")));
	}

	private void CreateItems6()
	{
		_dataArray.Add(new InformationInfoItem(360, LocalStringManager.GetConfig("InformationInfo_language", "Name_360"), 0, -1, 10, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_360"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_360"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_360"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_360"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_360_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_360_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_360_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_360_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_360_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_360")));
		_dataArray.Add(new InformationInfoItem(361, LocalStringManager.GetConfig("InformationInfo_language", "Name_361"), 1, -1, 10, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_361"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_361"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_361"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_361"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_361_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_361_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_361_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_361_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_361_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_361")));
		_dataArray.Add(new InformationInfoItem(362, LocalStringManager.GetConfig("InformationInfo_language", "Name_362"), 2, -1, 10, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_362"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_362"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_362"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_362"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_362_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_362_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_362_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_362_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_362_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_362")));
		_dataArray.Add(new InformationInfoItem(363, LocalStringManager.GetConfig("InformationInfo_language", "Name_363"), 3, -1, 10, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_363"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_363"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_363"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_363"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_363_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_363_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_363_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_363_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_363_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_363")));
		_dataArray.Add(new InformationInfoItem(364, LocalStringManager.GetConfig("InformationInfo_language", "Name_364"), 4, -1, 10, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_364"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_364"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_364"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_364"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_364_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_364_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_364_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_364_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_364_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_364")));
		_dataArray.Add(new InformationInfoItem(365, LocalStringManager.GetConfig("InformationInfo_language", "Name_365"), 5, -1, 10, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_365"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_365"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_365"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_365"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_365_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_365_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_365_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_365_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_365_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_365")));
		_dataArray.Add(new InformationInfoItem(366, LocalStringManager.GetConfig("InformationInfo_language", "Name_366"), 6, -1, 10, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_366"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_366"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_366"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_366"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_366_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_366_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_366_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_366_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_366_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_366")));
		_dataArray.Add(new InformationInfoItem(367, LocalStringManager.GetConfig("InformationInfo_language", "Name_367"), 7, -1, 10, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_367"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_367"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_367"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_367"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_367_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_367_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_367_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_367_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_367_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_367")));
		_dataArray.Add(new InformationInfoItem(368, LocalStringManager.GetConfig("InformationInfo_language", "Name_368"), 8, -1, 10, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_368"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_368"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_368"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_368"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_368_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_368_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_368_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_368_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_368_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_368")));
		_dataArray.Add(new InformationInfoItem(369, LocalStringManager.GetConfig("InformationInfo_language", "Name_369"), 0, -1, 11, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_369"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_369"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_369"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_369"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_369_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_369_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_369_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_369_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_369_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_369")));
		_dataArray.Add(new InformationInfoItem(370, LocalStringManager.GetConfig("InformationInfo_language", "Name_370"), 1, -1, 11, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_370"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_370"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_370"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_370"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_370_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_370_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_370_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_370_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_370_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_370")));
		_dataArray.Add(new InformationInfoItem(371, LocalStringManager.GetConfig("InformationInfo_language", "Name_371"), 2, -1, 11, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_371"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_371"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_371"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_371"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_371_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_371_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_371_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_371_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_371_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_371")));
		_dataArray.Add(new InformationInfoItem(372, LocalStringManager.GetConfig("InformationInfo_language", "Name_372"), 3, -1, 11, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_372"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_372"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_372"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_372"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_372_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_372_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_372_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_372_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_372_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_372")));
		_dataArray.Add(new InformationInfoItem(373, LocalStringManager.GetConfig("InformationInfo_language", "Name_373"), 4, -1, 11, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_373"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_373"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_373"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_373"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_373_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_373_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_373_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_373_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_373_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_373")));
		_dataArray.Add(new InformationInfoItem(374, LocalStringManager.GetConfig("InformationInfo_language", "Name_374"), 5, -1, 11, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_374"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_374"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_374"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_374"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_374_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_374_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_374_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_374_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_374_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_374")));
		_dataArray.Add(new InformationInfoItem(375, LocalStringManager.GetConfig("InformationInfo_language", "Name_375"), 6, -1, 11, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_375"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_375"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_375"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_375"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_375_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_375_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_375_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_375_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_375_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_375")));
		_dataArray.Add(new InformationInfoItem(376, LocalStringManager.GetConfig("InformationInfo_language", "Name_376"), 7, -1, 11, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_376"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_376"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_376"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_376"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_376_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_376_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_376_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_376_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_376_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_376")));
		_dataArray.Add(new InformationInfoItem(377, LocalStringManager.GetConfig("InformationInfo_language", "Name_377"), 8, -1, 11, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_377"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_377"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_377"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_377"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_377_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_377_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_377_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_377_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_377_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_377")));
		_dataArray.Add(new InformationInfoItem(378, LocalStringManager.GetConfig("InformationInfo_language", "Name_378"), 0, -1, 12, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_378"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_378"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_378"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_378"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_378_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_378_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_378_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_378_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_378_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_378")));
		_dataArray.Add(new InformationInfoItem(379, LocalStringManager.GetConfig("InformationInfo_language", "Name_379"), 1, -1, 12, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_379"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_379"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_379"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_379"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_379_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_379_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_379_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_379_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_379_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_379")));
		_dataArray.Add(new InformationInfoItem(380, LocalStringManager.GetConfig("InformationInfo_language", "Name_380"), 2, -1, 12, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_380"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_380"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_380"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_380"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_380_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_380_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_380_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_380_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_380_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_380")));
		_dataArray.Add(new InformationInfoItem(381, LocalStringManager.GetConfig("InformationInfo_language", "Name_381"), 3, -1, 12, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_381"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_381"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_381"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_381"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_381_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_381_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_381_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_381_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_381_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_381")));
		_dataArray.Add(new InformationInfoItem(382, LocalStringManager.GetConfig("InformationInfo_language", "Name_382"), 4, -1, 12, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_382"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_382"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_382"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_382"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_382_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_382_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_382_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_382_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_382_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_382")));
		_dataArray.Add(new InformationInfoItem(383, LocalStringManager.GetConfig("InformationInfo_language", "Name_383"), 5, -1, 12, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_383"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_383"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_383"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_383"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_383_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_383_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_383_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_383_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_383_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_383")));
		_dataArray.Add(new InformationInfoItem(384, LocalStringManager.GetConfig("InformationInfo_language", "Name_384"), 6, -1, 12, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_384"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_384"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_384"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_384"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_384_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_384_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_384_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_384_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_384_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_384")));
		_dataArray.Add(new InformationInfoItem(385, LocalStringManager.GetConfig("InformationInfo_language", "Name_385"), 7, -1, 12, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_385"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_385"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_385"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_385"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_385_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_385_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_385_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_385_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_385_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_385")));
		_dataArray.Add(new InformationInfoItem(386, LocalStringManager.GetConfig("InformationInfo_language", "Name_386"), 8, -1, 12, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_386"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_386"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_386"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_386"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_386_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_386_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_386_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_386_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_386_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_386")));
		_dataArray.Add(new InformationInfoItem(387, LocalStringManager.GetConfig("InformationInfo_language", "Name_387"), 0, -1, 13, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_387"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_387"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_387"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_387"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_387_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_387_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_387_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_387_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_387_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_387")));
		_dataArray.Add(new InformationInfoItem(388, LocalStringManager.GetConfig("InformationInfo_language", "Name_388"), 1, -1, 13, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_388"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_388"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_388"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_388"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_388_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_388_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_388_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_388_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_388_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_388")));
		_dataArray.Add(new InformationInfoItem(389, LocalStringManager.GetConfig("InformationInfo_language", "Name_389"), 2, -1, 13, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_389"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_389"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_389"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_389"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_389_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_389_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_389_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_389_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_389_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_389")));
		_dataArray.Add(new InformationInfoItem(390, LocalStringManager.GetConfig("InformationInfo_language", "Name_390"), 3, -1, 13, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_390"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_390"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_390"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_390"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_390_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_390_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_390_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_390_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_390_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_390")));
		_dataArray.Add(new InformationInfoItem(391, LocalStringManager.GetConfig("InformationInfo_language", "Name_391"), 4, -1, 13, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_391"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_391"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_391"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_391"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_391_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_391_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_391_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_391_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_391_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_391")));
		_dataArray.Add(new InformationInfoItem(392, LocalStringManager.GetConfig("InformationInfo_language", "Name_392"), 5, -1, 13, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_392"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_392"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_392"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_392"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_392_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_392_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_392_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_392_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_392_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_392")));
		_dataArray.Add(new InformationInfoItem(393, LocalStringManager.GetConfig("InformationInfo_language", "Name_393"), 6, -1, 13, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_393"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_393"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_393"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_393"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_393_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_393_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_393_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_393_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_393_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_393")));
		_dataArray.Add(new InformationInfoItem(394, LocalStringManager.GetConfig("InformationInfo_language", "Name_394"), 7, -1, 13, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_394"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_394"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_394"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_394"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_394_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_394_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_394_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_394_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_394_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_394")));
		_dataArray.Add(new InformationInfoItem(395, LocalStringManager.GetConfig("InformationInfo_language", "Name_395"), 8, -1, 13, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_395"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_395"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_395"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_395"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_395_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_395_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_395_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_395_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_395_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_395")));
		_dataArray.Add(new InformationInfoItem(396, LocalStringManager.GetConfig("InformationInfo_language", "Name_396"), 0, -1, 14, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_396"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_396"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_396"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_396"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_396_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_396_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_396_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_396_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_396_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_396")));
		_dataArray.Add(new InformationInfoItem(397, LocalStringManager.GetConfig("InformationInfo_language", "Name_397"), 1, -1, 14, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_397"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_397"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_397"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_397"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_397_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_397_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_397_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_397_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_397_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_397")));
		_dataArray.Add(new InformationInfoItem(398, LocalStringManager.GetConfig("InformationInfo_language", "Name_398"), 2, -1, 14, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_398"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_398"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_398"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_398"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_398_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_398_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_398_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_398_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_398_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_398")));
		_dataArray.Add(new InformationInfoItem(399, LocalStringManager.GetConfig("InformationInfo_language", "Name_399"), 3, -1, 14, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_399"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_399"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_399"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_399"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_399_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_399_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_399_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_399_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_399_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_399")));
		_dataArray.Add(new InformationInfoItem(400, LocalStringManager.GetConfig("InformationInfo_language", "Name_400"), 4, -1, 14, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_400"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_400"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_400"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_400"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_400_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_400_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_400_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_400_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_400_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_400")));
		_dataArray.Add(new InformationInfoItem(401, LocalStringManager.GetConfig("InformationInfo_language", "Name_401"), 5, -1, 14, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_401"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_401"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_401"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_401"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_401_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_401_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_401_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_401_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_401_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_401")));
		_dataArray.Add(new InformationInfoItem(402, LocalStringManager.GetConfig("InformationInfo_language", "Name_402"), 6, -1, 14, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_402"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_402"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_402"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_402"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_402_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_402_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_402_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_402_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_402_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_402")));
		_dataArray.Add(new InformationInfoItem(403, LocalStringManager.GetConfig("InformationInfo_language", "Name_403"), 7, -1, 14, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_403"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_403"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_403"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_403"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_403_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_403_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_403_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_403_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_403_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_403")));
		_dataArray.Add(new InformationInfoItem(404, LocalStringManager.GetConfig("InformationInfo_language", "Name_404"), 8, -1, 14, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_404"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_404"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_404"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_404"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_404_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_404_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_404_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_404_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_404_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_404")));
		_dataArray.Add(new InformationInfoItem(405, LocalStringManager.GetConfig("InformationInfo_language", "Name_405"), 0, -1, 15, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_405"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_405"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_405"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_405"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_405_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_405_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_405_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_405_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_405_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_405")));
		_dataArray.Add(new InformationInfoItem(406, LocalStringManager.GetConfig("InformationInfo_language", "Name_406"), 1, -1, 15, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_406"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_406"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_406"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_406"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_406_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_406_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_406_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_406_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_406_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_406")));
		_dataArray.Add(new InformationInfoItem(407, LocalStringManager.GetConfig("InformationInfo_language", "Name_407"), 2, -1, 15, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_407"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_407"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_407"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_407"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_407_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_407_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_407_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_407_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_407_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_407")));
		_dataArray.Add(new InformationInfoItem(408, LocalStringManager.GetConfig("InformationInfo_language", "Name_408"), 3, -1, 15, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_408"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_408"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_408"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_408"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_408_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_408_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_408_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_408_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_408_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_408")));
		_dataArray.Add(new InformationInfoItem(409, LocalStringManager.GetConfig("InformationInfo_language", "Name_409"), 4, -1, 15, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_409"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_409"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_409"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_409"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_409_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_409_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_409_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_409_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_409_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_409")));
		_dataArray.Add(new InformationInfoItem(410, LocalStringManager.GetConfig("InformationInfo_language", "Name_410"), 5, -1, 15, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_410"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_410"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_410"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_410"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_410_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_410_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_410_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_410_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_410_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_410")));
		_dataArray.Add(new InformationInfoItem(411, LocalStringManager.GetConfig("InformationInfo_language", "Name_411"), 6, -1, 15, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_411"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_411"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_411"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_411"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_411_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_411_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_411_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_411_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_411_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_411")));
		_dataArray.Add(new InformationInfoItem(412, LocalStringManager.GetConfig("InformationInfo_language", "Name_412"), 7, -1, 15, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_412"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_412"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_412"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_412"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_412_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_412_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_412_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_412_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_412_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_412")));
		_dataArray.Add(new InformationInfoItem(413, LocalStringManager.GetConfig("InformationInfo_language", "Name_413"), 8, -1, 15, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_413"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_413"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_413"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_413"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_413_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_413_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_413_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_413_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_413_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_413")));
		_dataArray.Add(new InformationInfoItem(414, LocalStringManager.GetConfig("InformationInfo_language", "Name_414"), 0, -1, -1, 0, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_414"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_414"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_414"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_414"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_414_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_414_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_414_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_414_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_414_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_414")));
		_dataArray.Add(new InformationInfoItem(415, LocalStringManager.GetConfig("InformationInfo_language", "Name_415"), 1, -1, -1, 0, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_415"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_415"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_415"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_415"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_415_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_415_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_415_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_415_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_415_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_415")));
		_dataArray.Add(new InformationInfoItem(416, LocalStringManager.GetConfig("InformationInfo_language", "Name_416"), 2, -1, -1, 0, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_416"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_416"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_416"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_416"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_416_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_416_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_416_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_416_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_416_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_416")));
		_dataArray.Add(new InformationInfoItem(417, LocalStringManager.GetConfig("InformationInfo_language", "Name_417"), 3, -1, -1, 0, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_417"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_417"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_417"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_417"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_417_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_417_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_417_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_417_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_417_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_417")));
		_dataArray.Add(new InformationInfoItem(418, LocalStringManager.GetConfig("InformationInfo_language", "Name_418"), 4, -1, -1, 0, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_418"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_418"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_418"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_418"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_418_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_418_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_418_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_418_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_418_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_418")));
		_dataArray.Add(new InformationInfoItem(419, LocalStringManager.GetConfig("InformationInfo_language", "Name_419"), 5, -1, -1, 0, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_419"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_419"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_419"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_419"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_419_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_419_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_419_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_419_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_419_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_419")));
	}

	private void CreateItems7()
	{
		_dataArray.Add(new InformationInfoItem(420, LocalStringManager.GetConfig("InformationInfo_language", "Name_420"), 6, -1, -1, 0, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_420"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_420"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_420"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_420"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_420_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_420_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_420_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_420_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_420_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_420")));
		_dataArray.Add(new InformationInfoItem(421, LocalStringManager.GetConfig("InformationInfo_language", "Name_421"), 7, -1, -1, 0, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_421"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_421"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_421"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_421"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_421_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_421_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_421_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_421_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_421_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_421")));
		_dataArray.Add(new InformationInfoItem(422, LocalStringManager.GetConfig("InformationInfo_language", "Name_422"), 8, -1, -1, 0, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_422"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_422"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_422"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_422"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_422_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_422_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_422_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_422_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_422_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_422")));
		_dataArray.Add(new InformationInfoItem(423, LocalStringManager.GetConfig("InformationInfo_language", "Name_423"), 0, -1, -1, 1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_423"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_423"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_423"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_423"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_423_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_423_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_423_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_423_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_423_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_423")));
		_dataArray.Add(new InformationInfoItem(424, LocalStringManager.GetConfig("InformationInfo_language", "Name_424"), 1, -1, -1, 1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_424"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_424"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_424"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_424"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_424_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_424_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_424_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_424_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_424_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_424")));
		_dataArray.Add(new InformationInfoItem(425, LocalStringManager.GetConfig("InformationInfo_language", "Name_425"), 2, -1, -1, 1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_425"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_425"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_425"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_425"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_425_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_425_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_425_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_425_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_425_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_425")));
		_dataArray.Add(new InformationInfoItem(426, LocalStringManager.GetConfig("InformationInfo_language", "Name_426"), 3, -1, -1, 1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_426"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_426"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_426"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_426"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_426_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_426_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_426_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_426_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_426_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_426")));
		_dataArray.Add(new InformationInfoItem(427, LocalStringManager.GetConfig("InformationInfo_language", "Name_427"), 4, -1, -1, 1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_427"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_427"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_427"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_427"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_427_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_427_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_427_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_427_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_427_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_427")));
		_dataArray.Add(new InformationInfoItem(428, LocalStringManager.GetConfig("InformationInfo_language", "Name_428"), 5, -1, -1, 1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_428"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_428"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_428"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_428"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_428_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_428_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_428_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_428_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_428_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_428")));
		_dataArray.Add(new InformationInfoItem(429, LocalStringManager.GetConfig("InformationInfo_language", "Name_429"), 6, -1, -1, 1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_429"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_429"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_429"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_429"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_429_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_429_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_429_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_429_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_429_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_429")));
		_dataArray.Add(new InformationInfoItem(430, LocalStringManager.GetConfig("InformationInfo_language", "Name_430"), 7, -1, -1, 1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_430"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_430"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_430"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_430"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_430_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_430_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_430_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_430_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_430_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_430")));
		_dataArray.Add(new InformationInfoItem(431, LocalStringManager.GetConfig("InformationInfo_language", "Name_431"), 8, -1, -1, 1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_431"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_431"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_431"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_431"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_431_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_431_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_431_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_431_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_431_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_431")));
		_dataArray.Add(new InformationInfoItem(432, LocalStringManager.GetConfig("InformationInfo_language", "Name_432"), 0, -1, -1, 2, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_432"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_432"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_432"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_432"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_432_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_432_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_432_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_432_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_432_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_432")));
		_dataArray.Add(new InformationInfoItem(433, LocalStringManager.GetConfig("InformationInfo_language", "Name_433"), 1, -1, -1, 2, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_433"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_433"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_433"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_433"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_433_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_433_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_433_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_433_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_433_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_433")));
		_dataArray.Add(new InformationInfoItem(434, LocalStringManager.GetConfig("InformationInfo_language", "Name_434"), 2, -1, -1, 2, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_434"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_434"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_434"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_434"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_434_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_434_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_434_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_434_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_434_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_434")));
		_dataArray.Add(new InformationInfoItem(435, LocalStringManager.GetConfig("InformationInfo_language", "Name_435"), 3, -1, -1, 2, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_435"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_435"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_435"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_435"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_435_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_435_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_435_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_435_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_435_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_435")));
		_dataArray.Add(new InformationInfoItem(436, LocalStringManager.GetConfig("InformationInfo_language", "Name_436"), 4, -1, -1, 2, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_436"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_436"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_436"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_436"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_436_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_436_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_436_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_436_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_436_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_436")));
		_dataArray.Add(new InformationInfoItem(437, LocalStringManager.GetConfig("InformationInfo_language", "Name_437"), 5, -1, -1, 2, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_437"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_437"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_437"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_437"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_437_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_437_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_437_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_437_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_437_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_437")));
		_dataArray.Add(new InformationInfoItem(438, LocalStringManager.GetConfig("InformationInfo_language", "Name_438"), 6, -1, -1, 2, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_438"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_438"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_438"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_438"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_438_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_438_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_438_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_438_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_438_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_438")));
		_dataArray.Add(new InformationInfoItem(439, LocalStringManager.GetConfig("InformationInfo_language", "Name_439"), 7, -1, -1, 2, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_439"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_439"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_439"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_439"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_439_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_439_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_439_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_439_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_439_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_439")));
		_dataArray.Add(new InformationInfoItem(440, LocalStringManager.GetConfig("InformationInfo_language", "Name_440"), 8, -1, -1, 2, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_440"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_440"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_440"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_440"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_440_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_440_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_440_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_440_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_440_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_440")));
		_dataArray.Add(new InformationInfoItem(441, LocalStringManager.GetConfig("InformationInfo_language", "Name_441"), 0, -1, -1, 3, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_441"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_441"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_441"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_441"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_441_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_441_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_441_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_441_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_441_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_441")));
		_dataArray.Add(new InformationInfoItem(442, LocalStringManager.GetConfig("InformationInfo_language", "Name_442"), 1, -1, -1, 3, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_442"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_442"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_442"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_442"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_442_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_442_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_442_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_442_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_442_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_442")));
		_dataArray.Add(new InformationInfoItem(443, LocalStringManager.GetConfig("InformationInfo_language", "Name_443"), 2, -1, -1, 3, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_443"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_443"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_443"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_443"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_443_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_443_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_443_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_443_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_443_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_443")));
		_dataArray.Add(new InformationInfoItem(444, LocalStringManager.GetConfig("InformationInfo_language", "Name_444"), 3, -1, -1, 3, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_444"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_444"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_444"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_444"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_444_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_444_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_444_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_444_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_444_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_444")));
		_dataArray.Add(new InformationInfoItem(445, LocalStringManager.GetConfig("InformationInfo_language", "Name_445"), 4, -1, -1, 3, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_445"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_445"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_445"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_445"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_445_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_445_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_445_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_445_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_445_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_445")));
		_dataArray.Add(new InformationInfoItem(446, LocalStringManager.GetConfig("InformationInfo_language", "Name_446"), 5, -1, -1, 3, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_446"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_446"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_446"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_446"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_446_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_446_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_446_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_446_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_446_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_446")));
		_dataArray.Add(new InformationInfoItem(447, LocalStringManager.GetConfig("InformationInfo_language", "Name_447"), 6, -1, -1, 3, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_447"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_447"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_447"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_447"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_447_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_447_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_447_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_447_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_447_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_447")));
		_dataArray.Add(new InformationInfoItem(448, LocalStringManager.GetConfig("InformationInfo_language", "Name_448"), 7, -1, -1, 3, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_448"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_448"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_448"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_448"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_448_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_448_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_448_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_448_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_448_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_448")));
		_dataArray.Add(new InformationInfoItem(449, LocalStringManager.GetConfig("InformationInfo_language", "Name_449"), 8, -1, -1, 3, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_449"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_449"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_449"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_449"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_449_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_449_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_449_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_449_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_449_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_449")));
		_dataArray.Add(new InformationInfoItem(450, LocalStringManager.GetConfig("InformationInfo_language", "Name_450"), 0, -1, -1, 4, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_450"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_450"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_450"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_450"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_450_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_450_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_450_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_450_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_450_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_450")));
		_dataArray.Add(new InformationInfoItem(451, LocalStringManager.GetConfig("InformationInfo_language", "Name_451"), 1, -1, -1, 4, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_451"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_451"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_451"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_451"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_451_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_451_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_451_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_451_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_451_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_451")));
		_dataArray.Add(new InformationInfoItem(452, LocalStringManager.GetConfig("InformationInfo_language", "Name_452"), 2, -1, -1, 4, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_452"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_452"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_452"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_452"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_452_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_452_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_452_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_452_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_452_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_452")));
		_dataArray.Add(new InformationInfoItem(453, LocalStringManager.GetConfig("InformationInfo_language", "Name_453"), 3, -1, -1, 4, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_453"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_453"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_453"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_453"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_453_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_453_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_453_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_453_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_453_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_453")));
		_dataArray.Add(new InformationInfoItem(454, LocalStringManager.GetConfig("InformationInfo_language", "Name_454"), 4, -1, -1, 4, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_454"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_454"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_454"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_454"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_454_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_454_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_454_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_454_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_454_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_454")));
		_dataArray.Add(new InformationInfoItem(455, LocalStringManager.GetConfig("InformationInfo_language", "Name_455"), 5, -1, -1, 4, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_455"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_455"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_455"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_455"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_455_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_455_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_455_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_455_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_455_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_455")));
		_dataArray.Add(new InformationInfoItem(456, LocalStringManager.GetConfig("InformationInfo_language", "Name_456"), 6, -1, -1, 4, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_456"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_456"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_456"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_456"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_456_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_456_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_456_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_456_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_456_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_456")));
		_dataArray.Add(new InformationInfoItem(457, LocalStringManager.GetConfig("InformationInfo_language", "Name_457"), 7, -1, -1, 4, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_457"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_457"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_457"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_457"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_457_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_457_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_457_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_457_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_457_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_457")));
		_dataArray.Add(new InformationInfoItem(458, LocalStringManager.GetConfig("InformationInfo_language", "Name_458"), 8, -1, -1, 4, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_458"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_458"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_458"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_458"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_458_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_458_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_458_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_458_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_458_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_458")));
		_dataArray.Add(new InformationInfoItem(459, LocalStringManager.GetConfig("InformationInfo_language", "Name_459"), 0, -1, -1, 5, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_459"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_459"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_459"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_459"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_459_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_459_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_459_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_459_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_459_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_459")));
		_dataArray.Add(new InformationInfoItem(460, LocalStringManager.GetConfig("InformationInfo_language", "Name_460"), 1, -1, -1, 5, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_460"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_460"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_460"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_460"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_460_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_460_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_460_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_460_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_460_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_460")));
		_dataArray.Add(new InformationInfoItem(461, LocalStringManager.GetConfig("InformationInfo_language", "Name_461"), 2, -1, -1, 5, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_461"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_461"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_461"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_461"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_461_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_461_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_461_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_461_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_461_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_461")));
		_dataArray.Add(new InformationInfoItem(462, LocalStringManager.GetConfig("InformationInfo_language", "Name_462"), 3, -1, -1, 5, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_462"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_462"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_462"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_462"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_462_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_462_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_462_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_462_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_462_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_462")));
		_dataArray.Add(new InformationInfoItem(463, LocalStringManager.GetConfig("InformationInfo_language", "Name_463"), 4, -1, -1, 5, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_463"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_463"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_463"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_463"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_463_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_463_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_463_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_463_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_463_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_463")));
		_dataArray.Add(new InformationInfoItem(464, LocalStringManager.GetConfig("InformationInfo_language", "Name_464"), 5, -1, -1, 5, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_464"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_464"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_464"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_464"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_464_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_464_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_464_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_464_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_464_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_464")));
		_dataArray.Add(new InformationInfoItem(465, LocalStringManager.GetConfig("InformationInfo_language", "Name_465"), 6, -1, -1, 5, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_465"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_465"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_465"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_465"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_465_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_465_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_465_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_465_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_465_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_465")));
		_dataArray.Add(new InformationInfoItem(466, LocalStringManager.GetConfig("InformationInfo_language", "Name_466"), 7, -1, -1, 5, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_466"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_466"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_466"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_466"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_466_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_466_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_466_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_466_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_466_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_466")));
		_dataArray.Add(new InformationInfoItem(467, LocalStringManager.GetConfig("InformationInfo_language", "Name_467"), 8, -1, -1, 5, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_467"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_467"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_467"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_467"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_467_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_467_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_467_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_467_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_467_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_467")));
		_dataArray.Add(new InformationInfoItem(468, LocalStringManager.GetConfig("InformationInfo_language", "Name_468"), 0, -1, -1, 6, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_468"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_468"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_468"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_468"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_468_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_468_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_468_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_468_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_468_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_468")));
		_dataArray.Add(new InformationInfoItem(469, LocalStringManager.GetConfig("InformationInfo_language", "Name_469"), 1, -1, -1, 6, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_469"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_469"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_469"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_469"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_469_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_469_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_469_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_469_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_469_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_469")));
		_dataArray.Add(new InformationInfoItem(470, LocalStringManager.GetConfig("InformationInfo_language", "Name_470"), 2, -1, -1, 6, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_470"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_470"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_470"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_470"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_470_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_470_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_470_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_470_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_470_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_470")));
		_dataArray.Add(new InformationInfoItem(471, LocalStringManager.GetConfig("InformationInfo_language", "Name_471"), 3, -1, -1, 6, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_471"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_471"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_471"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_471"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_471_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_471_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_471_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_471_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_471_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_471")));
		_dataArray.Add(new InformationInfoItem(472, LocalStringManager.GetConfig("InformationInfo_language", "Name_472"), 4, -1, -1, 6, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_472"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_472"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_472"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_472"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_472_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_472_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_472_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_472_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_472_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_472")));
		_dataArray.Add(new InformationInfoItem(473, LocalStringManager.GetConfig("InformationInfo_language", "Name_473"), 5, -1, -1, 6, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_473"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_473"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_473"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_473"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_473_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_473_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_473_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_473_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_473_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_473")));
		_dataArray.Add(new InformationInfoItem(474, LocalStringManager.GetConfig("InformationInfo_language", "Name_474"), 6, -1, -1, 6, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_474"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_474"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_474"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_474"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_474_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_474_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_474_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_474_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_474_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_474")));
		_dataArray.Add(new InformationInfoItem(475, LocalStringManager.GetConfig("InformationInfo_language", "Name_475"), 7, -1, -1, 6, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_475"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_475"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_475"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_475"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_475_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_475_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_475_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_475_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_475_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_475")));
		_dataArray.Add(new InformationInfoItem(476, LocalStringManager.GetConfig("InformationInfo_language", "Name_476"), 8, -1, -1, 6, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_476"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_476"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_476"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_476"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_476_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_476_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_476_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_476_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_476_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_476")));
		_dataArray.Add(new InformationInfoItem(477, LocalStringManager.GetConfig("InformationInfo_language", "Name_477"), 0, -1, -1, 7, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_477"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_477"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_477"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_477"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_477_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_477_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_477_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_477_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_477_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_477")));
		_dataArray.Add(new InformationInfoItem(478, LocalStringManager.GetConfig("InformationInfo_language", "Name_478"), 1, -1, -1, 7, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_478"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_478"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_478"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_478"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_478_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_478_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_478_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_478_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_478_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_478")));
		_dataArray.Add(new InformationInfoItem(479, LocalStringManager.GetConfig("InformationInfo_language", "Name_479"), 2, -1, -1, 7, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_479"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_479"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_479"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_479"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_479_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_479_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_479_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_479_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_479_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_479")));
	}

	private void CreateItems8()
	{
		_dataArray.Add(new InformationInfoItem(480, LocalStringManager.GetConfig("InformationInfo_language", "Name_480"), 3, -1, -1, 7, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_480"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_480"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_480"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_480"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_480_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_480_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_480_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_480_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_480_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_480")));
		_dataArray.Add(new InformationInfoItem(481, LocalStringManager.GetConfig("InformationInfo_language", "Name_481"), 4, -1, -1, 7, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_481"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_481"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_481"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_481"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_481_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_481_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_481_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_481_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_481_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_481")));
		_dataArray.Add(new InformationInfoItem(482, LocalStringManager.GetConfig("InformationInfo_language", "Name_482"), 5, -1, -1, 7, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_482"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_482"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_482"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_482"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_482_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_482_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_482_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_482_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_482_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_482")));
		_dataArray.Add(new InformationInfoItem(483, LocalStringManager.GetConfig("InformationInfo_language", "Name_483"), 6, -1, -1, 7, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_483"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_483"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_483"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_483"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_483_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_483_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_483_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_483_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_483_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_483")));
		_dataArray.Add(new InformationInfoItem(484, LocalStringManager.GetConfig("InformationInfo_language", "Name_484"), 7, -1, -1, 7, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_484"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_484"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_484"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_484"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_484_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_484_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_484_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_484_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_484_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_484")));
		_dataArray.Add(new InformationInfoItem(485, LocalStringManager.GetConfig("InformationInfo_language", "Name_485"), 8, -1, -1, 7, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_485"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_485"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_485"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_485"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_485_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_485_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_485_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_485_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_485_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_485")));
		_dataArray.Add(new InformationInfoItem(486, LocalStringManager.GetConfig("InformationInfo_language", "Name_486"), 0, -1, -1, 8, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_486"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_486"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_486"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_486"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_486_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_486_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_486_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_486_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_486_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_486")));
		_dataArray.Add(new InformationInfoItem(487, LocalStringManager.GetConfig("InformationInfo_language", "Name_487"), 1, -1, -1, 8, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_487"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_487"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_487"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_487"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_487_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_487_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_487_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_487_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_487_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_487")));
		_dataArray.Add(new InformationInfoItem(488, LocalStringManager.GetConfig("InformationInfo_language", "Name_488"), 2, -1, -1, 8, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_488"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_488"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_488"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_488"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_488_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_488_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_488_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_488_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_488_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_488")));
		_dataArray.Add(new InformationInfoItem(489, LocalStringManager.GetConfig("InformationInfo_language", "Name_489"), 3, -1, -1, 8, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_489"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_489"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_489"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_489"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_489_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_489_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_489_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_489_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_489_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_489")));
		_dataArray.Add(new InformationInfoItem(490, LocalStringManager.GetConfig("InformationInfo_language", "Name_490"), 4, -1, -1, 8, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_490"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_490"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_490"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_490"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_490_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_490_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_490_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_490_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_490_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_490")));
		_dataArray.Add(new InformationInfoItem(491, LocalStringManager.GetConfig("InformationInfo_language", "Name_491"), 5, -1, -1, 8, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_491"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_491"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_491"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_491"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_491_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_491_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_491_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_491_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_491_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_491")));
		_dataArray.Add(new InformationInfoItem(492, LocalStringManager.GetConfig("InformationInfo_language", "Name_492"), 6, -1, -1, 8, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_492"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_492"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_492"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_492"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_492_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_492_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_492_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_492_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_492_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_492")));
		_dataArray.Add(new InformationInfoItem(493, LocalStringManager.GetConfig("InformationInfo_language", "Name_493"), 7, -1, -1, 8, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_493"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_493"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_493"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_493"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_493_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_493_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_493_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_493_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_493_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_493")));
		_dataArray.Add(new InformationInfoItem(494, LocalStringManager.GetConfig("InformationInfo_language", "Name_494"), 8, -1, -1, 8, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_494"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_494"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_494"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_494"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_494_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_494_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_494_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_494_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_494_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_494")));
		_dataArray.Add(new InformationInfoItem(495, LocalStringManager.GetConfig("InformationInfo_language", "Name_495"), 8, 10, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_495"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_495"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_495"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_495"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_495_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_495_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_495_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_495_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_495_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_495")));
		_dataArray.Add(new InformationInfoItem(496, LocalStringManager.GetConfig("InformationInfo_language", "Name_496"), 8, 10, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_496"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_496"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_496"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_496"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_496_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_496_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_496_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_496_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_496_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_496")));
		_dataArray.Add(new InformationInfoItem(497, LocalStringManager.GetConfig("InformationInfo_language", "Name_497"), 8, 15, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_497"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_497"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_497"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_497"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_497_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_497_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_497_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_497_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_497_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_497")));
		_dataArray.Add(new InformationInfoItem(498, LocalStringManager.GetConfig("InformationInfo_language", "Name_498"), 8, 15, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_498"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_498"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_498"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_498"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_498_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_498_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_498_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_498_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_498_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_498")));
		_dataArray.Add(new InformationInfoItem(499, LocalStringManager.GetConfig("InformationInfo_language", "Name_499"), 8, 1, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_499"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_499"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_499"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_499"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_499_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_499_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_499_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_499_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_499_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_499")));
		_dataArray.Add(new InformationInfoItem(500, LocalStringManager.GetConfig("InformationInfo_language", "Name_500"), 8, 1, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_500"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_500"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_500"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_500"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_500_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_500_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_500_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_500_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_500_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_500")));
		_dataArray.Add(new InformationInfoItem(501, LocalStringManager.GetConfig("InformationInfo_language", "Name_501"), 8, 4, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_501"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_501"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_501"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_501"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_501_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_501_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_501_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_501_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_501_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_501")));
		_dataArray.Add(new InformationInfoItem(502, LocalStringManager.GetConfig("InformationInfo_language", "Name_502"), 8, 4, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_502"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_502"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_502"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_502"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_502_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_502_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_502_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_502_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_502_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_502")));
		_dataArray.Add(new InformationInfoItem(503, LocalStringManager.GetConfig("InformationInfo_language", "Name_503"), 8, 8, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_503"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_503"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_503"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_503"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_503_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_503_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_503_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_503_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_503_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_503")));
		_dataArray.Add(new InformationInfoItem(504, LocalStringManager.GetConfig("InformationInfo_language", "Name_504"), 8, 8, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_504"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_504"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_504"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_504"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_504_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_504_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_504_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_504_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_504_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_504")));
		_dataArray.Add(new InformationInfoItem(505, LocalStringManager.GetConfig("InformationInfo_language", "Name_505"), 8, 5, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_505"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_505"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_505"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_505"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_505_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_505_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_505_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_505_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_505_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_505")));
		_dataArray.Add(new InformationInfoItem(506, LocalStringManager.GetConfig("InformationInfo_language", "Name_506"), 8, 5, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_506"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_506"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_506"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_506"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_506_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_506_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_506_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_506_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_506_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_506")));
		_dataArray.Add(new InformationInfoItem(507, LocalStringManager.GetConfig("InformationInfo_language", "Name_507"), 8, 6, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_507"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_507"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_507"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_507"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_507_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_507_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_507_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_507_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_507_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_507")));
		_dataArray.Add(new InformationInfoItem(508, LocalStringManager.GetConfig("InformationInfo_language", "Name_508"), 8, 6, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_508"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_508"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_508"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_508"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_508_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_508_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_508_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_508_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_508_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_508")));
		_dataArray.Add(new InformationInfoItem(509, LocalStringManager.GetConfig("InformationInfo_language", "Name_509"), 8, 11, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_509"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_509"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_509"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_509"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_509_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_509_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_509_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_509_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_509_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_509")));
		_dataArray.Add(new InformationInfoItem(510, LocalStringManager.GetConfig("InformationInfo_language", "Name_510"), 8, 11, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_510"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_510"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_510"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_510"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_510_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_510_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_510_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_510_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_510_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_510")));
		_dataArray.Add(new InformationInfoItem(511, LocalStringManager.GetConfig("InformationInfo_language", "Name_511"), 8, 12, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_511"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_511"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_511"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_511"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_511_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_511_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_511_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_511_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_511_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_511")));
		_dataArray.Add(new InformationInfoItem(512, LocalStringManager.GetConfig("InformationInfo_language", "Name_512"), 8, 12, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_512"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_512"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_512"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_512"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_512_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_512_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_512_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_512_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_512_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_512")));
		_dataArray.Add(new InformationInfoItem(513, LocalStringManager.GetConfig("InformationInfo_language", "Name_513"), 8, 12, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_513"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_513"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_513"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_513"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_513_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_513_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_513_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_513_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_513_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_513")));
		_dataArray.Add(new InformationInfoItem(514, LocalStringManager.GetConfig("InformationInfo_language", "Name_514"), 8, 2, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_514"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_514"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_514"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_514"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_514_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_514_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_514_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_514_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_514_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_514")));
		_dataArray.Add(new InformationInfoItem(515, LocalStringManager.GetConfig("InformationInfo_language", "Name_515"), 8, 2, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_515"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_515"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_515"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_515"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_515_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_515_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_515_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_515_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_515_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_515")));
		_dataArray.Add(new InformationInfoItem(516, LocalStringManager.GetConfig("InformationInfo_language", "Name_516"), 8, 13, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_516"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_516"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_516"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_516"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_516_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_516_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_516_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_516_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_516_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_516")));
		_dataArray.Add(new InformationInfoItem(517, LocalStringManager.GetConfig("InformationInfo_language", "Name_517"), 8, 13, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_517"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_517"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_517"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_517"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_517_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_517_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_517_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_517_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_517_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_517")));
		_dataArray.Add(new InformationInfoItem(518, LocalStringManager.GetConfig("InformationInfo_language", "Name_518"), 8, 7, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_518"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_518"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_518"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_518"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_518_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_518_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_518_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_518_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_518_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_518")));
		_dataArray.Add(new InformationInfoItem(519, LocalStringManager.GetConfig("InformationInfo_language", "Name_519"), 8, 7, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_519"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_519"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_519"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_519"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_519_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_519_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_519_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_519_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_519_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_519")));
		_dataArray.Add(new InformationInfoItem(520, LocalStringManager.GetConfig("InformationInfo_language", "Name_520"), 5, -1, -1, -1, EInformationInfoSwordInformationType.SwordTombHuman, 0, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_520"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_520"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_520"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_520"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_520_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_520_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_520_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_520_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_520_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_520")));
		_dataArray.Add(new InformationInfoItem(521, LocalStringManager.GetConfig("InformationInfo_language", "Name_521"), 5, -1, -1, -1, EInformationInfoSwordInformationType.SwordTombHuman, 1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_521"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_521"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_521"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_521"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_521_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_521_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_521_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_521_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_521_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_521")));
		_dataArray.Add(new InformationInfoItem(522, LocalStringManager.GetConfig("InformationInfo_language", "Name_522"), 5, -1, -1, -1, EInformationInfoSwordInformationType.SwordTombHuman, 2, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_522"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_522"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_522"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_522"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_522_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_522_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_522_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_522_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_522_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_522")));
		_dataArray.Add(new InformationInfoItem(523, LocalStringManager.GetConfig("InformationInfo_language", "Name_523"), 5, -1, -1, -1, EInformationInfoSwordInformationType.SwordTombHuman, 3, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_523"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_523"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_523"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_523"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_523_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_523_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_523_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_523_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_523_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_523")));
		_dataArray.Add(new InformationInfoItem(524, LocalStringManager.GetConfig("InformationInfo_language", "Name_524"), 5, -1, -1, -1, EInformationInfoSwordInformationType.SwordTombHuman, 4, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_524"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_524"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_524"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_524"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_524_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_524_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_524_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_524_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_524_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_524")));
		_dataArray.Add(new InformationInfoItem(525, LocalStringManager.GetConfig("InformationInfo_language", "Name_525"), 5, -1, -1, -1, EInformationInfoSwordInformationType.SwordTombHuman, 5, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_525"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_525"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_525"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_525"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_525_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_525_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_525_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_525_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_525_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_525")));
		_dataArray.Add(new InformationInfoItem(526, LocalStringManager.GetConfig("InformationInfo_language", "Name_526"), 5, -1, -1, -1, EInformationInfoSwordInformationType.SwordTombHuman, 6, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_526"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_526"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_526"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_526"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_526_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_526_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_526_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_526_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_526_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_526")));
		_dataArray.Add(new InformationInfoItem(527, LocalStringManager.GetConfig("InformationInfo_language", "Name_527"), 5, -1, -1, -1, EInformationInfoSwordInformationType.SwordTombHuman, 7, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_527"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_527"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_527"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_527"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_527_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_527_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_527_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_527_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_527_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_527")));
		_dataArray.Add(new InformationInfoItem(528, LocalStringManager.GetConfig("InformationInfo_language", "Name_528"), 5, -1, -1, -1, EInformationInfoSwordInformationType.SwordTombHuman, 8, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_528"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_528"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_528"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_528"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_528_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_528_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_528_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_528_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_528_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_528")));
		_dataArray.Add(new InformationInfoItem(529, LocalStringManager.GetConfig("InformationInfo_language", "Name_529"), 8, -1, -1, -1, EInformationInfoSwordInformationType.SwordTombHeaven, 0, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_529"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_529"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_529"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_529"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_529_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_529_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_529_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_529_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_529_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_529")));
		_dataArray.Add(new InformationInfoItem(530, LocalStringManager.GetConfig("InformationInfo_language", "Name_530"), 8, -1, -1, -1, EInformationInfoSwordInformationType.SwordTombHeaven, 1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_530"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_530"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_530"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_530"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_530_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_530_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_530_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_530_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_530_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_530")));
		_dataArray.Add(new InformationInfoItem(531, LocalStringManager.GetConfig("InformationInfo_language", "Name_531"), 8, -1, -1, -1, EInformationInfoSwordInformationType.SwordTombHeaven, 2, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_531"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_531"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_531"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_531"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_531_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_531_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_531_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_531_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_531_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_531")));
		_dataArray.Add(new InformationInfoItem(532, LocalStringManager.GetConfig("InformationInfo_language", "Name_532"), 8, -1, -1, -1, EInformationInfoSwordInformationType.SwordTombHeaven, 3, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_532"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_532"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_532"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_532"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_532_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_532_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_532_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_532_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_532_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_532")));
		_dataArray.Add(new InformationInfoItem(533, LocalStringManager.GetConfig("InformationInfo_language", "Name_533"), 8, -1, -1, -1, EInformationInfoSwordInformationType.SwordTombHeaven, 4, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_533"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_533"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_533"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_533"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_533_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_533_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_533_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_533_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_533_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_533")));
		_dataArray.Add(new InformationInfoItem(534, LocalStringManager.GetConfig("InformationInfo_language", "Name_534"), 8, -1, -1, -1, EInformationInfoSwordInformationType.SwordTombHeaven, 5, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_534"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_534"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_534"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_534"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_534_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_534_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_534_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_534_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_534_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_534")));
		_dataArray.Add(new InformationInfoItem(535, LocalStringManager.GetConfig("InformationInfo_language", "Name_535"), 8, -1, -1, -1, EInformationInfoSwordInformationType.SwordTombHeaven, 6, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_535"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_535"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_535"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_535"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_535_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_535_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_535_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_535_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_535_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_535")));
		_dataArray.Add(new InformationInfoItem(536, LocalStringManager.GetConfig("InformationInfo_language", "Name_536"), 8, -1, -1, -1, EInformationInfoSwordInformationType.SwordTombHeaven, 7, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_536"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_536"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_536"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_536"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_536_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_536_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_536_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_536_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_536_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_536")));
		_dataArray.Add(new InformationInfoItem(537, LocalStringManager.GetConfig("InformationInfo_language", "Name_537"), 8, -1, -1, -1, EInformationInfoSwordInformationType.SwordTombHeaven, 8, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_537"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_537"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_537"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_537"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_537_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_537_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_537_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_537_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_537_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_537")));
		_dataArray.Add(new InformationInfoItem(538, LocalStringManager.GetConfig("InformationInfo_language", "Name_538"), 8, -1, -1, -1, EInformationInfoSwordInformationType.SwordTombNormal, 0, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_538"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_538"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_538"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_538"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_538_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_538_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_538_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_538_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_538_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_538")));
		_dataArray.Add(new InformationInfoItem(539, LocalStringManager.GetConfig("InformationInfo_language", "Name_539"), 8, -1, -1, -1, EInformationInfoSwordInformationType.SwordTombNormal, 1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_539"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_539"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_539"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_539"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_539_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_539_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_539_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_539_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_539_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_539")));
	}

	private void CreateItems9()
	{
		_dataArray.Add(new InformationInfoItem(540, LocalStringManager.GetConfig("InformationInfo_language", "Name_540"), 8, -1, -1, -1, EInformationInfoSwordInformationType.SwordTombNormal, 2, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_540"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_540"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_540"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_540"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_540_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_540_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_540_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_540_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_540_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_540")));
		_dataArray.Add(new InformationInfoItem(541, LocalStringManager.GetConfig("InformationInfo_language", "Name_541"), 8, -1, -1, -1, EInformationInfoSwordInformationType.SwordTombNormal, 3, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_541"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_541"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_541"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_541"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_541_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_541_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_541_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_541_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_541_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_541")));
		_dataArray.Add(new InformationInfoItem(542, LocalStringManager.GetConfig("InformationInfo_language", "Name_542"), 8, -1, -1, -1, EInformationInfoSwordInformationType.SwordTombNormal, 4, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_542"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_542"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_542"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_542"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_542_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_542_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_542_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_542_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_542_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_542")));
		_dataArray.Add(new InformationInfoItem(543, LocalStringManager.GetConfig("InformationInfo_language", "Name_543"), 8, -1, -1, -1, EInformationInfoSwordInformationType.SwordTombNormal, 5, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_543"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_543"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_543"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_543"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_543_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_543_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_543_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_543_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_543_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_543")));
		_dataArray.Add(new InformationInfoItem(544, LocalStringManager.GetConfig("InformationInfo_language", "Name_544"), 8, -1, -1, -1, EInformationInfoSwordInformationType.SwordTombNormal, 6, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_544"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_544"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_544"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_544"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_544_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_544_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_544_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_544_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_544_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_544")));
		_dataArray.Add(new InformationInfoItem(545, LocalStringManager.GetConfig("InformationInfo_language", "Name_545"), 8, -1, -1, -1, EInformationInfoSwordInformationType.SwordTombNormal, 7, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_545"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_545"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_545"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_545"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_545_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_545_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_545_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_545_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_545_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_545")));
		_dataArray.Add(new InformationInfoItem(546, LocalStringManager.GetConfig("InformationInfo_language", "Name_546"), 8, -1, -1, -1, EInformationInfoSwordInformationType.SwordTombNormal, 8, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_546"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_546"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_546"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_546"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_546_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_546_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_546_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_546_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_546_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_546")));
		_dataArray.Add(new InformationInfoItem(547, LocalStringManager.GetConfig("InformationInfo_language", "Name_547"), 8, 3, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_547"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_547"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_547"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_547"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_547_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_547_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_547_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_547_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_547_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_547")));
		_dataArray.Add(new InformationInfoItem(548, LocalStringManager.GetConfig("InformationInfo_language", "Name_548"), 8, 3, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_548"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_548"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_548"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_548"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_548_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_548_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_548_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_548_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_548_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_548")));
		_dataArray.Add(new InformationInfoItem(549, LocalStringManager.GetConfig("InformationInfo_language", "Name_549"), 8, 14, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_549"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_549"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_549"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_549"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_549_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_549_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_549_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_549_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_549_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_549")));
		_dataArray.Add(new InformationInfoItem(550, LocalStringManager.GetConfig("InformationInfo_language", "Name_550"), 8, 14, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_550"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_550"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_550"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_550"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_550_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_550_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_550_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_550_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_550_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_550")));
		_dataArray.Add(new InformationInfoItem(551, LocalStringManager.GetConfig("InformationInfo_language", "Name_551"), 8, -1, -1, -1, EInformationInfoSwordInformationType.SwordTombEarth, 0, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_551"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_551"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_551"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_551"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_551_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_551_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_551_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_551_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_551_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_551")));
		_dataArray.Add(new InformationInfoItem(552, LocalStringManager.GetConfig("InformationInfo_language", "Name_552"), 8, -1, -1, -1, EInformationInfoSwordInformationType.SwordTombEarth, 1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_552"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_552"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_552"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_552"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_552_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_552_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_552_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_552_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_552_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_552")));
		_dataArray.Add(new InformationInfoItem(553, LocalStringManager.GetConfig("InformationInfo_language", "Name_553"), 8, -1, -1, -1, EInformationInfoSwordInformationType.SwordTombEarth, 2, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_553"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_553"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_553"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_553"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_553_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_553_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_553_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_553_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_553_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_553")));
		_dataArray.Add(new InformationInfoItem(554, LocalStringManager.GetConfig("InformationInfo_language", "Name_554"), 8, -1, -1, -1, EInformationInfoSwordInformationType.SwordTombEarth, 3, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_554"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_554"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_554"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_554"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_554_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_554_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_554_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_554_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_554_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_554")));
		_dataArray.Add(new InformationInfoItem(555, LocalStringManager.GetConfig("InformationInfo_language", "Name_555"), 8, -1, -1, -1, EInformationInfoSwordInformationType.SwordTombEarth, 4, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_555"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_555"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_555"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_555"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_555_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_555_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_555_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_555_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_555_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_555")));
		_dataArray.Add(new InformationInfoItem(556, LocalStringManager.GetConfig("InformationInfo_language", "Name_556"), 8, -1, -1, -1, EInformationInfoSwordInformationType.SwordTombEarth, 5, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_556"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_556"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_556"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_556"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_556_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_556_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_556_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_556_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_556_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_556")));
		_dataArray.Add(new InformationInfoItem(557, LocalStringManager.GetConfig("InformationInfo_language", "Name_557"), 8, -1, -1, -1, EInformationInfoSwordInformationType.SwordTombEarth, 6, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_557"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_557"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_557"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_557"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_557_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_557_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_557_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_557_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_557_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_557")));
		_dataArray.Add(new InformationInfoItem(558, LocalStringManager.GetConfig("InformationInfo_language", "Name_558"), 8, -1, -1, -1, EInformationInfoSwordInformationType.SwordTombEarth, 7, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_558"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_558"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_558"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_558"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_558_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_558_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_558_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_558_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_558_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_558")));
		_dataArray.Add(new InformationInfoItem(559, LocalStringManager.GetConfig("InformationInfo_language", "Name_559"), 8, -1, -1, -1, EInformationInfoSwordInformationType.SwordTombEarth, 8, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_559"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_559"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_559"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_559"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_559_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_559_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_559_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_559_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_559_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_559")));
		_dataArray.Add(new InformationInfoItem(560, LocalStringManager.GetConfig("InformationInfo_language", "Name_560"), 8, 9, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_560"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_560"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_560"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_560"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_560_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_560_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_560_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_560_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_560_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_560")));
		_dataArray.Add(new InformationInfoItem(561, LocalStringManager.GetConfig("InformationInfo_language", "Name_561"), 8, 9, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, -1, consume: false, LocalStringManager.GetConfig("InformationInfo_language", "Desc_561"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_561"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_561"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_561"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_561_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_561_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_561_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_561_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_561_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_561")));
		_dataArray.Add(new InformationInfoItem(562, LocalStringManager.GetConfig("InformationInfo_language", "Name_562"), 8, -1, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, 0, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_562"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_562"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_562"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_562"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_562_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_562_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_562_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_562_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_562_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_562")));
		_dataArray.Add(new InformationInfoItem(563, LocalStringManager.GetConfig("InformationInfo_language", "Name_563"), 8, -1, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, 1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_563"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_563"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_563"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_563"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_563_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_563_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_563_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_563_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_563_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_563")));
		_dataArray.Add(new InformationInfoItem(564, LocalStringManager.GetConfig("InformationInfo_language", "Name_564"), 8, -1, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, 2, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_564"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_564"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_564"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_564"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_564_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_564_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_564_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_564_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_564_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_564")));
		_dataArray.Add(new InformationInfoItem(565, LocalStringManager.GetConfig("InformationInfo_language", "Name_565"), 8, -1, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, 3, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_565"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_565"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_565"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_565"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_565_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_565_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_565_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_565_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_565_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_565")));
		_dataArray.Add(new InformationInfoItem(566, LocalStringManager.GetConfig("InformationInfo_language", "Name_566"), 8, -1, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, 4, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_566"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_566"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_566"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_566"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_566_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_566_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_566_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_566_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_566_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_566")));
		_dataArray.Add(new InformationInfoItem(567, LocalStringManager.GetConfig("InformationInfo_language", "Name_567"), 8, -1, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, 5, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_567"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_567"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_567"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_567"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_567_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_567_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_567_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_567_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_567_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_567")));
		_dataArray.Add(new InformationInfoItem(568, LocalStringManager.GetConfig("InformationInfo_language", "Name_568"), 8, -1, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, 6, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_568"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_568"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_568"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_568"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_568_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_568_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_568_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_568_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_568_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_568")));
		_dataArray.Add(new InformationInfoItem(569, LocalStringManager.GetConfig("InformationInfo_language", "Name_569"), 8, -1, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, 7, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_569"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_569"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_569"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_569"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_569_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_569_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_569_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_569_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_569_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_569")));
		_dataArray.Add(new InformationInfoItem(570, LocalStringManager.GetConfig("InformationInfo_language", "Name_570"), 8, -1, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, 8, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_570"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_570"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_570"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_570"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_570_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_570_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_570_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_570_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_570_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_570")));
		_dataArray.Add(new InformationInfoItem(571, LocalStringManager.GetConfig("InformationInfo_language", "Name_571"), 8, -1, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, 9, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_571"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_571"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_571"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_571"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_571_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_571_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_571_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_571_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_571_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_571")));
		_dataArray.Add(new InformationInfoItem(572, LocalStringManager.GetConfig("InformationInfo_language", "Name_572"), 8, -1, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, 10, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_572"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_572"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_572"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_572"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_572_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_572_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_572_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_572_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_572_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_572")));
		_dataArray.Add(new InformationInfoItem(573, LocalStringManager.GetConfig("InformationInfo_language", "Name_573"), 8, -1, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, 11, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_573"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_573"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_573"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_573"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_573_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_573_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_573_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_573_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_573_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_573")));
		_dataArray.Add(new InformationInfoItem(574, LocalStringManager.GetConfig("InformationInfo_language", "Name_574"), 8, -1, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, 12, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_574"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_574"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_574"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_574"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_574_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_574_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_574_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_574_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_574_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_574")));
		_dataArray.Add(new InformationInfoItem(575, LocalStringManager.GetConfig("InformationInfo_language", "Name_575"), 8, -1, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, 13, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_575"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_575"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_575"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_575"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_575_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_575_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_575_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_575_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_575_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_575")));
		_dataArray.Add(new InformationInfoItem(576, LocalStringManager.GetConfig("InformationInfo_language", "Name_576"), 8, -1, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, 14, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_576"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_576"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_576"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_576"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_576_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_576_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_576_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_576_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_576_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_576")));
		_dataArray.Add(new InformationInfoItem(577, LocalStringManager.GetConfig("InformationInfo_language", "Name_577"), 8, -1, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, 15, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_577"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_577"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_577"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_577"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_577_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_577_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_577_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_577_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_577_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_577")));
		_dataArray.Add(new InformationInfoItem(578, LocalStringManager.GetConfig("InformationInfo_language", "Name_578"), 8, -1, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, 16, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_578"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_578"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_578"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_578"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_578_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_578_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_578_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_578_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_578_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_578")));
		_dataArray.Add(new InformationInfoItem(579, LocalStringManager.GetConfig("InformationInfo_language", "Name_579"), 8, -1, -1, -1, EInformationInfoSwordInformationType.Invalid, -1, 17, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_579"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_579"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_579"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_579"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_579_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_579_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_579_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_579_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_579_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_579")));
		_dataArray.Add(new InformationInfoItem(580, LocalStringManager.GetConfig("InformationInfo_language", "Name_580"), 5, -1, -1, -1, EInformationInfoSwordInformationType.Invalid, 0, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_580"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_580"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_580"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_580"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_580_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_580_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_580_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_580_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_580_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_580")));
		_dataArray.Add(new InformationInfoItem(581, LocalStringManager.GetConfig("InformationInfo_language", "Name_581"), 5, -1, -1, -1, EInformationInfoSwordInformationType.Invalid, 1, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_581"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_581"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_581"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_581"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_581_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_581_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_581_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_581_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_581_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_581")));
		_dataArray.Add(new InformationInfoItem(582, LocalStringManager.GetConfig("InformationInfo_language", "Name_582"), 5, -1, -1, -1, EInformationInfoSwordInformationType.Invalid, 2, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_582"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_582"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_582"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_582"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_582_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_582_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_582_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_582_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_582_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_582")));
		_dataArray.Add(new InformationInfoItem(583, LocalStringManager.GetConfig("InformationInfo_language", "Name_583"), 5, -1, -1, -1, EInformationInfoSwordInformationType.Invalid, 3, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_583"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_583"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_583"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_583"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_583_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_583_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_583_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_583_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_583_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_583")));
		_dataArray.Add(new InformationInfoItem(584, LocalStringManager.GetConfig("InformationInfo_language", "Name_584"), 5, -1, -1, -1, EInformationInfoSwordInformationType.Invalid, 4, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_584"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_584"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_584"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_584"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_584_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_584_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_584_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_584_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_584_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_584")));
		_dataArray.Add(new InformationInfoItem(585, LocalStringManager.GetConfig("InformationInfo_language", "Name_585"), 5, -1, -1, -1, EInformationInfoSwordInformationType.Invalid, 5, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_585"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_585"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_585"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_585"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_585_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_585_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_585_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_585_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_585_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_585")));
		_dataArray.Add(new InformationInfoItem(586, LocalStringManager.GetConfig("InformationInfo_language", "Name_586"), 5, -1, -1, -1, EInformationInfoSwordInformationType.Invalid, 6, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_586"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_586"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_586"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_586"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_586_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_586_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_586_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_586_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_586_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_586")));
		_dataArray.Add(new InformationInfoItem(587, LocalStringManager.GetConfig("InformationInfo_language", "Name_587"), 5, -1, -1, -1, EInformationInfoSwordInformationType.Invalid, 7, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_587"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_587"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_587"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_587"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_587_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_587_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_587_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_587_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_587_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_587")));
		_dataArray.Add(new InformationInfoItem(588, LocalStringManager.GetConfig("InformationInfo_language", "Name_588"), 5, -1, -1, -1, EInformationInfoSwordInformationType.Invalid, 8, -1, consume: true, LocalStringManager.GetConfig("InformationInfo_language", "Desc_588"), LocalStringManager.GetConfig("InformationInfo_language", "EffectiveAnswer_588"), LocalStringManager.GetConfig("InformationInfo_language", "NormalAnswer_588"), LocalStringManager.GetConfig("InformationInfo_language", "InvalidAnswer_588"), new string[5]
		{
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_588_0"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_588_1"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_588_2"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_588_3"),
			LocalStringManager.GetConfig("InformationInfo_language", "BehaviorTypePlaceHolders_588_4")
		}, LocalStringManager.GetConfig("InformationInfo_language", "SwordTombPlaceHolder_588")));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<InformationInfoItem>(589);
		CreateItems0();
		CreateItems1();
		CreateItems2();
		CreateItems3();
		CreateItems4();
		CreateItems5();
		CreateItems6();
		CreateItems7();
		CreateItems8();
		CreateItems9();
	}
}

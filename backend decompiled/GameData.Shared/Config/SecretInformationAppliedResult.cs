using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class SecretInformationAppliedResult : ConfigData<SecretInformationAppliedResultItem, short>
{
	public static SecretInformationAppliedResult Instance = new SecretInformationAppliedResult();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "InnerResultEvent", "Texts", "SelectionIds", "SecretInformation", "CombatConfigId", "SpecialConditionId", "SpecialConditionResultIds", "TemplateId", "ResultEventGuid", "ResultEventGuidKey" };

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
		_dataArray.Add(new SecretInformationAppliedResultItem(0, -1, "05e87c45-f14e-49ef-8769-cbaced4753ae", "MainInteractionHeadEvent", endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_0_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_0_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_0_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_0_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_0_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(1, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_1_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_1_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_1_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_1_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_1_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 3, 0, 1600, -1, -1, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(2, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_2_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_2_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_2_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_2_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_2_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, -3, 0, -3200, 1, 1, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(3, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_3_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_3_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_3_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_3_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_3_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 3, 0, 1600, -2, -2, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(4, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_4_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_4_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_4_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_4_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_4_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, -3, 0, -3200, 2, 2, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(5, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_5_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_5_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_5_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_5_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_5_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 3, 0, 1600, 3, 3, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(6, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_6_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_6_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_6_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_6_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_6_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, -3, 0, -3200, 3, 3, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(7, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_7_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_7_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_7_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_7_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_7_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 3, 0, 1600, -1, -1, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(8, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_8_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_8_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_8_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_8_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_8_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, -3, 0, -3200, 1, 1, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(9, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_9_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_9_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_9_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_9_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_9_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, -3, -3, -1600, -1600, -2, -2, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(10, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_10_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_10_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_10_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_10_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_10_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, -3, -3, -3200, -3200, 2, 2, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(11, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_11_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_11_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_11_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_11_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_11_4")
		}, new short[1] { 37 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, 38, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 10, 0, 6000, 3, 3, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(12, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_12_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_12_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_12_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_12_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_12_4")
		}, new short[1] { 41 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, -10, 0, -12000, 1, 1, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(13, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_13_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_13_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_13_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_13_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_13_4")
		}, new short[1] { 37 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, 39, new List<ShortList>
		{
			new ShortList(-1)
		}, 10, 0, 6000, 0, 3, 3, isFavorabilityCost: true));
		_dataArray.Add(new SecretInformationAppliedResultItem(14, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_14_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_14_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_14_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_14_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_14_4")
		}, new short[2] { 40, 0 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, -10, 0, -12000, 0, 1, 1, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(15, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_15_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_15_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_15_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_15_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_15_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, 1, noGuard: false, 17, new List<ShortList>
		{
			new ShortList(18, 19, 30, 31, 27, 23, 28, 19, 18),
			new ShortList(69)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(16, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_16_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_16_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_16_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_16_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_16_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, 2, noGuard: false, 17, new List<ShortList>
		{
			new ShortList(20, 24, 30, 31, 27, 21, 29, 19, 18),
			new ShortList(67)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(17, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_17_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_17_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_17_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_17_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_17_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, 2, noGuard: false, 17, new List<ShortList>
		{
			new ShortList(22, 25, 30, 31, 27, 23, 28, 19, 18),
			new ShortList(68)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(18, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_18_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_18_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_18_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_18_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_18_4")
		}, new short[1] { 37 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 3, -3, -3000, -6000, 0, 3, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(19, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_19_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_19_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_19_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_19_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_19_4")
		}, new short[1] { 38 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, -3, 3, -6000, -3000, 3, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(20, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_20_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_20_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_20_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_20_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_20_4")
		}, new short[2] { 69, 47 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 3, -3, -6000, -9000, 0, 3, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(21, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_21_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_21_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_21_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_21_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_21_4")
		}, new short[2] { 68, 70 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 5, -5, -6000, -9000, 0, 3, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(22, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_22_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_22_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_22_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_22_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_22_4")
		}, new short[3] { 68, 70, 47 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 5, -5, -9000, -12000, 0, 3, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(23, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_23_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_23_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_23_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_23_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_23_4")
		}, new short[2] { 68, 70 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 5, -5, -9000, -12000, 0, 3, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(24, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_24_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_24_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_24_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_24_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_24_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, 27, new List<ShortList>
		{
			new ShortList(62),
			new ShortList(56, 57),
			new ShortList(59, 60)
		}, -3, 3, -9000, -6000, 3, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(25, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_25_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_25_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_25_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_25_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_25_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, 27, new List<ShortList>
		{
			new ShortList(62),
			new ShortList(56, 57),
			new ShortList(59, 60)
		}, -5, 5, -12000, -9000, 3, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(26, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_26_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_26_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_26_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_26_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_26_4")
		}, new short[1] { 52 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(27, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_27_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_27_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_27_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_27_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_27_4")
		}, new short[1] { 52 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, 27, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(28, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_28_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_28_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_28_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_28_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_28_4")
		}, new short[3] { 71, 73, 47 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(29, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_29_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_29_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_29_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_29_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_29_4")
		}, new short[2] { 72, 47 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(30, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_30_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_30_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_30_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_30_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_30_4")
		}, new short[1] { 66 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(31, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_31_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_31_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_31_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_31_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_31_4")
		}, new short[1] { 67 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(32, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_32_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_32_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_32_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_32_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_32_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, 33, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(33, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_33_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_33_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_33_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_33_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_33_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, 32, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(34, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_34_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_34_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_34_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_34_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_34_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, 2, noGuard: false, 25, new List<ShortList>
		{
			new ShortList(277, 278, 278),
			new ShortList(40)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(35, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_35_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_35_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_35_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_35_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_35_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, 24, new List<ShortList>
		{
			new ShortList(36, 37, 38),
			new ShortList(33)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(36, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_36_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_36_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_36_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_36_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_36_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, 1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(41, 44, 30, 31, 46, 23, 28, 44, 41)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(37, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_37_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_37_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_37_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_37_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_37_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, 2, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(42, 45, 30, 31, 58, 23, 28, 44, 41)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(38, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_38_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_38_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_38_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_38_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_38_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, 2, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(43, 46, 30, 31, 27, 23, 28, 44, 41)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(39, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_39_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_39_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_39_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_39_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_39_4")
		}, new short[1] { 42 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(40, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_40_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_40_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_40_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_40_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_40_4")
		}, new short[1] { 42 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(41, 18, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_41_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_41_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_41_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_41_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_41_4")
		}, new short[1] { 37 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 3, -3, -3000, -6000, 0, 3, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(42, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_42_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_42_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_42_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_42_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_42_4")
		}, new short[3] { 68, 70, 47 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 3, -3, -6000, -9000, 0, 3, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(43, 22, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_43_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_43_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_43_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_43_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_43_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 5, -5, -9000, -12000, 0, 3, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(44, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_44_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_44_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_44_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_44_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_44_4")
		}, new short[1] { 38 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, -3, 3, -6000, -3000, 3, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(45, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_45_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_45_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_45_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_45_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_45_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, 28, new List<ShortList>
		{
			new ShortList(63),
			new ShortList(58),
			new ShortList(61)
		}, -3, 3, -9000, -6000, 3, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(46, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_46_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_46_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_46_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_46_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_46_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, 27, new List<ShortList>
		{
			new ShortList(63),
			new ShortList(56, 57),
			new ShortList(59, 60)
		}, -5, 5, -12000, -9000, 3, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(47, 28, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_47_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_47_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_47_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_47_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_47_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(48, 23, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_48_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_48_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_48_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_48_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_48_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(49, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_49_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_49_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_49_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_49_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_49_4")
		}, new short[1] { 37 }, new List<ShortList>
		{
			new ShortList(1, 5, 3)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 10, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(50, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_50_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_50_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_50_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_50_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_50_4")
		}, new short[1] { 37 }, new List<ShortList>
		{
			new ShortList(95, 5, 3)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 10, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(51, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_51_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_51_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_51_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_51_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_51_4")
		}, new short[1] { 37 }, new List<ShortList>
		{
			new ShortList(3, 5, 3)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 10, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(52, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_52_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_52_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_52_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_52_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_52_4")
		}, new short[1] { 37 }, new List<ShortList>
		{
			new ShortList(2, 5, 3)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 5, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(53, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_53_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_53_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_53_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_53_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_53_4")
		}, new short[1] { 37 }, new List<ShortList>
		{
			new ShortList(96, 5, 3)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 5, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(54, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_54_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_54_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_54_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_54_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_54_4")
		}, new short[1] { 37 }, new List<ShortList>
		{
			new ShortList(4, 5, 3)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 5, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(55, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_55_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_55_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_55_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_55_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_55_4")
		}, new short[1] { 37 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(56, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_56_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_56_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_56_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_56_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_56_4")
		}, new short[1] { 52 }, new List<ShortList>
		{
			new ShortList(1, 3, 5)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 10, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(57, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_57_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_57_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_57_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_57_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_57_4")
		}, new short[1] { 52 }, new List<ShortList>
		{
			new ShortList(95, 3, 5)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 10, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(58, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_58_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_58_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_58_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_58_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_58_4")
		}, new short[1] { 52 }, new List<ShortList>
		{
			new ShortList(3, 3, 5)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 10, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(59, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_59_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_59_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_59_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_59_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_59_4")
		}, new short[1] { 52 }, new List<ShortList>
		{
			new ShortList(2, 3, 5)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 5, isFavorabilityCost: false));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new SecretInformationAppliedResultItem(60, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_60_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_60_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_60_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_60_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_60_4")
		}, new short[1] { 52 }, new List<ShortList>
		{
			new ShortList(96, 3, 5)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 5, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(61, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_61_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_61_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_61_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_61_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_61_4")
		}, new short[1] { 52 }, new List<ShortList>
		{
			new ShortList(4, 3, 5)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 5, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(62, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_62_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_62_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_62_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_62_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_62_4")
		}, new short[1] { 37 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(63, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_63_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_63_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_63_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_63_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_63_4")
		}, new short[1] { 37 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(64, -1, "24b66f5e-cd47-486c-ad8f-6e069bd8dd71", null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_64_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_64_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_64_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_64_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_64_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(65, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_65_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_65_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_65_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_65_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_65_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, 30, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(66, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_66_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_66_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_66_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_66_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_66_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, 31, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(67, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_67_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_67_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_67_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_67_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_67_4")
		}, new short[3] { 45, 69, 47 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(68, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_68_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_68_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_68_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_68_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_68_4")
		}, new short[3] { 44, 46, 47 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(69, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_69_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_69_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_69_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_69_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_69_4")
		}, new short[2] { 43, 47 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(70, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_70_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_70_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_70_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_70_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_70_4")
		}, new short[2] { 48, 49 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, 34, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(71, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_71_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_71_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_71_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_71_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_71_4")
		}, new short[2] { 48, 50 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, 34, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(72, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_72_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_72_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_72_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_72_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_72_4")
		}, new short[2] { 48, 51 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, 34, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(73, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_73_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_73_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_73_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_73_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_73_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, 35, new List<ShortList>
		{
			new ShortList(74, 28)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(74, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_74_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_74_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_74_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_74_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_74_4")
		}, new short[1] { 67 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(75, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_75_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_75_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_75_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_75_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_75_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, 18, new List<ShortList>
		{
			new ShortList(76, 77, 78, 79, 80)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(76, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_76_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_76_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_76_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_76_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_76_4")
		}, new short[1] { 39 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(77, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_77_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_77_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_77_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_77_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_77_4")
		}, new short[1] { 39 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(78, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_78_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_78_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_78_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_78_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_78_4")
		}, new short[1] { 39 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(79, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_79_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_79_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_79_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_79_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_79_4")
		}, new short[1] { 38 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(80, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_80_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_80_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_80_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_80_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_80_4")
		}, new short[1] { 53 }, new List<ShortList>
		{
			new ShortList(25, 5, 1, 3)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(81, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_81_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_81_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_81_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_81_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_81_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, 1, noGuard: false, 21, new List<ShortList>
		{
			new ShortList(84, 85, 86, 87, 27, 89, 88, 85, 84),
			new ShortList(82, 83),
			new ShortList(98, 97)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(82, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_82_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_82_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_82_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_82_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_82_4")
		}, new short[1] { 42 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(83, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_83_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_83_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_83_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_83_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_83_4")
		}, new short[1] { 37 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(84, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_84_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_84_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_84_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_84_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_84_4")
		}, new short[1] { 37 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 3, -3, -6000, -9000, 0, 3, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(85, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_85_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_85_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_85_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_85_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_85_4")
		}, new short[1] { 37 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, -3, 3, -9000, -6000, 3, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(86, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_86_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_86_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_86_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_86_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_86_4")
		}, new short[1] { 66 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, -3, 3, -9000, -6000, 3, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(87, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_87_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_87_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_87_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_87_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_87_4")
		}, new short[1] { 67 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(88, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_88_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_88_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_88_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_88_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_88_4")
		}, new short[3] { 71, 73, 78 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(89, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_89_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_89_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_89_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_89_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_89_4")
		}, new short[2] { 68, 70 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, -5, 5, -12000, -9000, 3, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(90, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_90_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_90_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_90_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_90_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_90_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, 19, new List<ShortList>
		{
			new ShortList(91, 92, 93, 94),
			new ShortList(95, 96)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(91, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_91_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_91_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_91_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_91_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_91_4")
		}, new short[1] { 39 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(92, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_92_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_92_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_92_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_92_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_92_4")
		}, new short[1] { 39 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(93, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_93_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_93_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_93_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_93_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_93_4")
		}, new short[1] { 39 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(94, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_94_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_94_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_94_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_94_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_94_4")
		}, new short[1] { 74 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(95, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_95_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_95_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_95_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_95_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_95_4")
		}, new short[1] { 53 }, new List<ShortList>
		{
			new ShortList(25, 5, 1, 3)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(96, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_96_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_96_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_96_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_96_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_96_4")
		}, new short[1] { 38 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(97, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_97_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_97_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_97_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_97_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_97_4")
		}, new short[1] { 37 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(98, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_98_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_98_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_98_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_98_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_98_4")
		}, new short[1] { 42 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(99, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_99_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_99_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_99_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_99_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_99_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, 1, noGuard: false, 20, new List<ShortList>
		{
			new ShortList(105, 106, 107, 108, 27, 109, 110, 106, 105),
			new ShortList(100, 101, 102, 103, 104)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(100, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_100_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_100_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_100_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_100_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_100_4")
		}, new short[1] { 39 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(101, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_101_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_101_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_101_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_101_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_101_4")
		}, new short[1] { 39 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(102, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_102_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_102_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_102_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_102_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_102_4")
		}, new short[1] { 39 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(103, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_103_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_103_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_103_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_103_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_103_4")
		}, new short[1] { 38 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(104, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_104_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_104_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_104_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_104_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_104_4")
		}, new short[1] { 42 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(105, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_105_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_105_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_105_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_105_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_105_4")
		}, new short[1] { 37 }, new List<ShortList>
		{
			new ShortList(25, 5, 1, 3)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 3, -3, -6000, -9000, 0, 3, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(106, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_106_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_106_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_106_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_106_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_106_4")
		}, new short[1] { 38 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, -3, 3, -9000, -6000, 3, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(107, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_107_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_107_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_107_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_107_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_107_4")
		}, new short[1] { 66 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, -3, 3, -9000, -6000, 3, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(108, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_108_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_108_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_108_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_108_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_108_4")
		}, new short[1] { 67 }, new List<ShortList>
		{
			new ShortList(25, 5, 1, 3)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, -3, 3, -9000, -6000, 3, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(109, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_109_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_109_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_109_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_109_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_109_4")
		}, new short[2] { 68, 70 }, new List<ShortList>
		{
			new ShortList(25, 5, 1, 3)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(110, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_110_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_110_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_110_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_110_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_110_4")
		}, new short[2] { 71, 73 }, new List<ShortList>
		{
			new ShortList(25, 5, 1, 3)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(111, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_111_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_111_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_111_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_111_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_111_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, 18, new List<ShortList>
		{
			new ShortList(112, 113, 114, 115, 116)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(112, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_112_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_112_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_112_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_112_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_112_4")
		}, new short[1] { 39 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(113, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_113_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_113_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_113_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_113_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_113_4")
		}, new short[1] { 39 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(114, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_114_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_114_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_114_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_114_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_114_4")
		}, new short[1] { 39 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(115, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_115_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_115_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_115_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_115_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_115_4")
		}, new short[1] { 38 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(116, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_116_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_116_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_116_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_116_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_116_4")
		}, new short[1] { 54 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(117, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_117_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_117_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_117_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_117_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_117_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, 1, noGuard: false, 21, new List<ShortList>
		{
			new ShortList(120, 121, 122, 123, 27, 125, 124, 121, 120),
			new ShortList(118, 119),
			new ShortList(145, 144)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(118, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_118_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_118_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_118_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_118_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_118_4")
		}, new short[1] { 42 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(119, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_119_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_119_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_119_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_119_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_119_4")
		}, new short[1] { 55 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
	}

	private void CreateItems2()
	{
		_dataArray.Add(new SecretInformationAppliedResultItem(120, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_120_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_120_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_120_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_120_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_120_4")
		}, new short[1] { 55 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(121, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_121_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_121_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_121_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_121_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_121_4")
		}, new short[1] { 38 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(122, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_122_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_122_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_122_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_122_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_122_4")
		}, new short[1] { 66 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, -3, 3, -9000, -6000, 3, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(123, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_123_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_123_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_123_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_123_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_123_4")
		}, new short[1] { 58 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(124, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_124_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_124_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_124_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_124_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_124_4")
		}, new short[3] { 56, 57, 63 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(125, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_125_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_125_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_125_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_125_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_125_4")
		}, new short[2] { 61, 62 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(126, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_126_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_126_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_126_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_126_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_126_4")
		}, new short[1] { 55 }, new List<ShortList>
		{
			new ShortList(1, 5, 3)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 10, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(127, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_127_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_127_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_127_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_127_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_127_4")
		}, new short[1] { 55 }, new List<ShortList>
		{
			new ShortList(95, 5, 3)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 10, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(128, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_128_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_128_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_128_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_128_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_128_4")
		}, new short[1] { 55 }, new List<ShortList>
		{
			new ShortList(2, 5, 3)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 5, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(129, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_129_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_129_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_129_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_129_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_129_4")
		}, new short[1] { 55 }, new List<ShortList>
		{
			new ShortList(96, 5, 3)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 5, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(130, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_130_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_130_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_130_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_130_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_130_4")
		}, new short[1] { 55 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(131, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_131_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_131_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_131_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_131_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_131_4")
		}, new short[2] { 64, 65 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(132, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_132_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_132_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_132_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_132_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_132_4")
		}, new short[1] { 37 }, new List<ShortList>
		{
			new ShortList(2, 5, 1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 5, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(133, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_133_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_133_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_133_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_133_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_133_4")
		}, new short[1] { 37 }, new List<ShortList>
		{
			new ShortList(96, 5, 1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 5, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(134, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_134_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_134_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_134_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_134_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_134_4")
		}, new short[2] { 59, 60 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(135, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_135_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_135_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_135_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_135_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_135_4")
		}, new short[1] { 37 }, new List<ShortList>
		{
			new ShortList(2, 5, 1)
		}, -1, noGuard: false, 31, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 5, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(136, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_136_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_136_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_136_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_136_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_136_4")
		}, new short[1] { 37 }, new List<ShortList>
		{
			new ShortList(96, 5, 1)
		}, -1, noGuard: false, 31, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 5, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(137, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_137_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_137_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_137_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_137_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_137_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, 19, new List<ShortList>
		{
			new ShortList(138, 139, 140, 141),
			new ShortList(142, 143)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(138, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_138_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_138_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_138_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_138_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_138_4")
		}, new short[1] { 39 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(139, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_139_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_139_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_139_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_139_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_139_4")
		}, new short[1] { 39 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(140, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_140_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_140_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_140_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_140_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_140_4")
		}, new short[1] { 39 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(141, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_141_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_141_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_141_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_141_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_141_4")
		}, new short[1] { 74 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(142, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_142_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_142_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_142_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_142_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_142_4")
		}, new short[1] { 54 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(143, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_143_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_143_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_143_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_143_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_143_4")
		}, new short[1] { 38 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(144, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_144_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_144_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_144_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_144_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_144_4")
		}, new short[1] { 37 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(145, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_145_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_145_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_145_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_145_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_145_4")
		}, new short[1] { 42 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(146, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_146_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_146_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_146_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_146_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_146_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, 1, noGuard: false, 20, new List<ShortList>
		{
			new ShortList(120, 121, 122, 123, 27, 125, 124, 121, 120),
			new ShortList(147, 148, 149, 150, 151)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(147, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_147_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_147_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_147_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_147_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_147_4")
		}, new short[1] { 39 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(148, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_148_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_148_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_148_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_148_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_148_4")
		}, new short[1] { 39 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(149, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_149_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_149_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_149_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_149_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_149_4")
		}, new short[1] { 39 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(150, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_150_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_150_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_150_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_150_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_150_4")
		}, new short[1] { 38 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(151, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_151_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_151_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_151_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_151_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_151_4")
		}, new short[1] { 42 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(152, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_152_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_152_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_152_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_152_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_152_4")
		}, new short[1] { 37 }, new List<ShortList>
		{
			new ShortList(24, 5, 1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 5, 0, 6000, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(153, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_153_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_153_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_153_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_153_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_153_4")
		}, new short[1] { 75 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, -5, 0, -6000, 0, 3, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(154, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_154_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_154_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_154_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_154_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_154_4")
		}, new short[1] { 37 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, 29, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 5, 0, 6000, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(155, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_155_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_155_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_155_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_155_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_155_4")
		}, new short[1] { 76 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, -5, 0, -6000, 0, 3, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(156, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_156_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_156_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_156_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_156_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_156_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, 26, new List<ShortList>
		{
			new ShortList(158, 167, 174),
			new ShortList(160, 159),
			new ShortList(168),
			new ShortList(175)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(157, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_157_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_157_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_157_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_157_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_157_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, 17, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(158, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_158_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_158_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_158_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_158_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_158_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, 1, noGuard: true, -1, new List<ShortList>
		{
			new ShortList(161, 162, 163, 164, 27, 23, 165, 162, 161),
			new ShortList(69)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(159, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_159_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_159_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_159_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_159_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_159_4")
		}, new short[1] { 38 }, new List<ShortList>
		{
			new ShortList(25, 3, 1, 5)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, -1600, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(160, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_160_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_160_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_160_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_160_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_160_4")
		}, new short[2] { 77, 78 }, new List<ShortList>
		{
			new ShortList(25, 3, 1, 5)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, -1600, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(161, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_161_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_161_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_161_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_161_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_161_4")
		}, new short[1] { 38 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 3, -3, -6000, -9000, 0, 3, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(162, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_162_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_162_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_162_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_162_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_162_4")
		}, new short[1] { 38 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, -3, 3, -6000, -9000, 0, 3, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(163, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_163_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_163_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_163_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_163_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_163_4")
		}, new short[1] { 66 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(164, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_164_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_164_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_164_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_164_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_164_4")
		}, new short[1] { 67 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(165, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_165_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_165_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_165_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_165_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_165_4")
		}, new short[3] { 71, 73, 78 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(166, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_166_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_166_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_166_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_166_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_166_4")
		}, new short[1] { 37 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, -3, 3, -6000, -9000, 0, 3, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(167, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_167_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_167_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_167_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_167_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_167_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(169, 170)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(168, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_168_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_168_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_168_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_168_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_168_4")
		}, new short[1] { 79 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, -3200, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(169, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_169_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_169_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_169_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_169_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_169_4")
		}, new short[1] { 37 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 3, -3, -6000, -9000, 0, 3, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(170, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_170_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_170_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_170_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_170_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_170_4")
		}, new short[1] { 80 }, new List<ShortList>
		{
			new ShortList(25, 3, 1, 5)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, -3, 3, -6000, -9000, 0, 3, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(171, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_171_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_171_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_171_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_171_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_171_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, 1, noGuard: true, 22, new List<ShortList>
		{
			new ShortList(161, 162, 163, 164, 27, 23, 165, 162, 161),
			new ShortList(69),
			new ShortList(173, 172)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(172, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_172_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_172_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_172_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_172_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_172_4")
		}, new short[1] { 37 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(173, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_173_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_173_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_173_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_173_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_173_4")
		}, new short[2] { 77, 78 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(174, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_174_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_174_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_174_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_174_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_174_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, 1, noGuard: true, -1, new List<ShortList>
		{
			new ShortList(177, 178, 179, 180, 181, 182, 165, 178, 177),
			new ShortList(69)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(175, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_175_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_175_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_175_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_175_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_175_4")
		}, new short[2] { 82, 84 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, -4800, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(176, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_176_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_176_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_176_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_176_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_176_4")
		}, new short[1] { 85 }, new List<ShortList>
		{
			new ShortList(25, 3, 1, 5)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(177, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_177_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_177_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_177_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_177_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_177_4")
		}, new short[1] { 37 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 3, -3, -9000, -6000, 3, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(178, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_178_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_178_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_178_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_178_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_178_4")
		}, new short[1] { 85 }, new List<ShortList>
		{
			new ShortList(25, 3, 1, 5)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, -3, 3, -6000, -9000, 0, 3, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(179, 163, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_179_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_179_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_179_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_179_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_179_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
	}

	private void CreateItems3()
	{
		_dataArray.Add(new SecretInformationAppliedResultItem(180, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_180_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_180_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_180_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_180_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_180_4")
		}, new short[1] { 67 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(181, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_181_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_181_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_181_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_181_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_181_4")
		}, new short[1] { 52 }, new List<ShortList>
		{
			new ShortList(25, 3, 1, 5)
		}, -1, noGuard: false, 27, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(182, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_182_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_182_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_182_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_182_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_182_4")
		}, new short[2] { 68, 70 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(183, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_183_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_183_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_183_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_183_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_183_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, 26, new List<ShortList>
		{
			new ShortList(184, 192, 199),
			new ShortList(186, 185),
			new ShortList(193),
			new ShortList(200)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(184, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_184_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_184_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_184_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_184_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_184_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, 1, noGuard: true, -1, new List<ShortList>
		{
			new ShortList(187, 188, 189, 190, 27, 23, 191, 188, 187),
			new ShortList(69)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(185, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_185_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_185_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_185_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_185_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_185_4")
		}, new short[1] { 38 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, 29, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, -1600, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(186, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_186_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_186_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_186_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_186_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_186_4")
		}, new short[2] { 77, 78 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, -1600, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(187, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_187_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_187_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_187_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_187_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_187_4")
		}, new short[1] { 37 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 3, -3, -6000, -9000, 0, 3, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(188, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_188_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_188_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_188_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_188_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_188_4")
		}, new short[1] { 38 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, 29, new List<ShortList>
		{
			new ShortList(-1)
		}, -3, 3, -6000, -9000, 0, 3, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(189, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_189_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_189_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_189_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_189_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_189_4")
		}, new short[1] { 66 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, 29, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(190, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_190_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_190_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_190_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_190_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_190_4")
		}, new short[1] { 67 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(191, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_191_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_191_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_191_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_191_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_191_4")
		}, new short[3] { 71, 73, 78 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(192, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_192_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_192_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_192_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_192_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_192_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(194, 195)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(193, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_193_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_193_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_193_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_193_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_193_4")
		}, new short[1] { 79 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, -3200, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(194, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_194_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_194_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_194_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_194_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_194_4")
		}, new short[1] { 37 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 3, -3, -9000, -6000, 3, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(195, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_195_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_195_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_195_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_195_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_195_4")
		}, new short[1] { 81 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, -3, 3, -6000, -9000, 0, 3, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(196, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_196_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_196_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_196_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_196_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_196_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, 1, noGuard: true, 22, new List<ShortList>
		{
			new ShortList(187, 188, 189, 190, 27, 23, 191, 188, 187),
			new ShortList(69),
			new ShortList(173, 172)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(197, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_197_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_197_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_197_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_197_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_197_4")
		}, new short[1] { 37 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, 29, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(198, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_198_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_198_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_198_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_198_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_198_4")
		}, new short[2] { 77, 78 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(199, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_199_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_199_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_199_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_199_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_199_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, 1, noGuard: true, -1, new List<ShortList>
		{
			new ShortList(202, 203, 204, 205, 206, 207, 191, 203, 202),
			new ShortList(69)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(200, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_200_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_200_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_200_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_200_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_200_4")
		}, new short[2] { 82, 84 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, -4800, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(201, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_201_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_201_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_201_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_201_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_201_4")
		}, new short[1] { 85 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, 29, new List<ShortList>
		{
			new ShortList(-1)
		}, -3, 3, -6000, -9000, 0, 3, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(202, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_202_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_202_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_202_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_202_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_202_4")
		}, new short[1] { 37 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 3, -3, -9000, -6000, 3, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(203, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_203_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_203_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_203_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_203_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_203_4")
		}, new short[1] { 38 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, 29, new List<ShortList>
		{
			new ShortList(-1)
		}, -3, 3, -6000, -9000, 0, 3, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(204, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_204_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_204_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_204_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_204_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_204_4")
		}, new short[1] { 66 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, 29, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(205, 31, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_205_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_205_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_205_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_205_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_205_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(206, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_206_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_206_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_206_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_206_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_206_4")
		}, new short[1] { 52 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, 29, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(207, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_207_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_207_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_207_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_207_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_207_4")
		}, new short[2] { 68, 70 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(208, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_208_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_208_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_208_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_208_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_208_4")
		}, new short[1] { 37 }, new List<ShortList>
		{
			new ShortList(24, 3, 1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 5, 0, 6000, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(209, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_209_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_209_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_209_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_209_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_209_4")
		}, new short[4] { 25, 26, 27, 0 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, -5, 0, -6000, 0, 3, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(210, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_210_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_210_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_210_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_210_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_210_4")
		}, new short[1] { 55 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 5, 0, 6000, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(211, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_211_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_211_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_211_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_211_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_211_4")
		}, new short[4] { 28, 29, 30, 0 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, -5, 0, -6000, 0, 3, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(212, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_212_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_212_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_212_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_212_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_212_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(32, 5, 3)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 5, 5, 3000, 3000, -1, -1, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(213, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_213_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_213_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_213_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_213_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_213_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, 37, new List<ShortList>
		{
			new ShortList(-1)
		}, 10, 0, 6000, 0, 3, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(214, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_214_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_214_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_214_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_214_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_214_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(37, 5, 3)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 10, 10, 9000, 9000, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(215, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_215_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_215_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_215_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_215_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_215_4")
		}, new short[1] { 37 }, new List<ShortList>
		{
			new ShortList(31, 5, 3)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, -3, 0, -3000, 0, 1, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(216, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_216_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_216_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_216_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_216_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_216_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(33, 5, 3)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, -5, -5, -6000, -6000, 3, 3, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(217, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_217_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_217_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_217_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_217_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_217_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, -10, 0, -9000, 0, 5, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(218, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_218_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_218_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_218_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_218_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_218_4")
		}, new short[1] { 38 }, new List<ShortList>
		{
			new ShortList(35, 5, 3)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, -10, -10, -9000, -9000, 5, 5, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(219, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_219_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_219_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_219_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_219_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_219_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(38, 5, 3)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, -10, -10, -12000, -12000, 5, 5, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(220, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_220_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_220_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_220_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_220_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_220_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(30, 5, 3)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 3, 0, 3000, 0, -3, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(221, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_221_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_221_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_221_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_221_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_221_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(32, 3, 5)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 5, 5, 3000, 3000, -1, -1, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(222, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_222_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_222_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_222_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_222_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_222_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, 36, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 10, 0, 6000, 0, 3, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(223, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_223_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_223_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_223_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_223_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_223_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(37, 3, 5)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 10, 10, 9000, 9000, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(224, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_224_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_224_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_224_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_224_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_224_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(31, 3, 5)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, -3, 0, -3000, 0, 1, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(225, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_225_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_225_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_225_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_225_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_225_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(33, 3, 5)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, -5, -5, -6000, -6000, 3, 3, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(226, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_226_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_226_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_226_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_226_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_226_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, -10, 0, -9000, 0, 5, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(227, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_227_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_227_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_227_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_227_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_227_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(35, 3, 5)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, -10, -10, -9000, -9000, 5, 5, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(228, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_228_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_228_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_228_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_228_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_228_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(38, 3, 5)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, -10, -10, -12000, -12000, 5, 5, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(229, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_229_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_229_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_229_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_229_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_229_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(30, 3, 5)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 3, 0, 3000, 0, -3, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(230, -1, "5966af43-b141-43fc-9446-f2c30c57b933", null, endEventAfterJump: false, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_230_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_230_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_230_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_230_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_230_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(231, -1, "324eb6e5-d208-4773-8126-8e14a79b6890", null, endEventAfterJump: false, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_231_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_231_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_231_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_231_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_231_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(232, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_232_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_232_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_232_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_232_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_232_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, 43, new List<ShortList>
		{
			new ShortList(234, 236, 237),
			new ShortList(235, 236, 238),
			new ShortList(241, 243, 244),
			new ShortList(242, 243, 245)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(233, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_233_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_233_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_233_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_233_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_233_4")
		}, new short[1] { 38 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(234, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_234_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_234_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_234_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_234_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_234_4")
		}, new short[1] { 38 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(235, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_235_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_235_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_235_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_235_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_235_4")
		}, new short[1] { 38 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(236, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_236_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_236_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_236_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_236_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_236_4")
		}, new short[4] { 14, 13, 90, 37 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(237, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_237_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_237_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_237_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_237_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_237_4")
		}, new short[4] { 14, 13, 90, 10 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(238, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_238_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_238_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_238_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_238_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_238_4")
		}, new short[4] { 14, 13, 90, 37 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(239, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_239_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_239_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_239_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_239_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_239_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, 43, new List<ShortList>
		{
			new ShortList(234, 236, 237),
			new ShortList(235, 236, 238),
			new ShortList(241, 243, 244),
			new ShortList(242, 243, 245)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
	}

	private void CreateItems4()
	{
		_dataArray.Add(new SecretInformationAppliedResultItem(240, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_240_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_240_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_240_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_240_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_240_4")
		}, new short[2] { 3, 4 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(241, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_241_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_241_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_241_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_241_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_241_4")
		}, new short[2] { 3, 4 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(242, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_242_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_242_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_242_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_242_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_242_4")
		}, new short[2] { 3, 4 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(243, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_243_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_243_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_243_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_243_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_243_4")
		}, new short[2] { 3, 4 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(244, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_244_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_244_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_244_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_244_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_244_4")
		}, new short[2] { 3, 4 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(245, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_245_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_245_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_245_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_245_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_245_4")
		}, new short[2] { 3, 4 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(246, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_246_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_246_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_246_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_246_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_246_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, 44, new List<ShortList>
		{
			new ShortList(248, 249, 251, 250),
			new ShortList(255, 256, 253),
			new ShortList(36, 37)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(247, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_247_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_247_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_247_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_247_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_247_4")
		}, new short[1] { 38 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(248, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_248_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_248_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_248_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_248_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_248_4")
		}, new short[1] { 38 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(249, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_249_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_249_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_249_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_249_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_249_4")
		}, new short[1] { 38 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(250, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_250_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_250_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_250_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_250_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_250_4")
		}, new short[1] { 36 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(251, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_251_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_251_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_251_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_251_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_251_4")
		}, new short[3] { 14, 13, 10 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(252, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_252_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_252_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_252_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_252_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_252_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, 44, new List<ShortList>
		{
			new ShortList(248, 249, 251, 250),
			new ShortList(255, 256, 253),
			new ShortList(36, 37)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(253, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_253_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_253_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_253_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_253_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_253_4")
		}, new short[2] { 1, 2 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(254, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_254_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_254_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_254_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_254_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_254_4")
		}, new short[2] { 3, 4 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(255, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_255_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_255_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_255_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_255_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_255_4")
		}, new short[2] { 3, 4 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(256, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_256_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_256_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_256_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_256_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_256_4")
		}, new short[2] { 3, 4 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(257, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_257_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_257_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_257_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_257_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_257_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(258, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_258_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_258_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_258_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_258_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_258_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(259, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_259_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_259_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_259_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_259_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_259_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(260, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_260_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_260_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_260_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_260_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_260_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(261, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_261_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_261_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_261_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_261_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_261_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(262, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_262_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_262_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_262_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_262_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_262_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(263, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_263_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_263_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_263_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_263_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_263_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, 47, new List<ShortList>
		{
			new ShortList(14, 13)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(264, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_264_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_264_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_264_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_264_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_264_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, 48, new List<ShortList>
		{
			new ShortList(209, 208)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(265, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_265_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_265_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_265_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_265_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_265_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, 48, new List<ShortList>
		{
			new ShortList(211, 210)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(266, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_266_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_266_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_266_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_266_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_266_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, 52, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(267, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_267_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_267_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_267_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_267_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_267_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, 49, new List<ShortList>
		{
			new ShortList(268, 269, 270)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(268, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_268_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_268_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_268_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_268_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_268_4")
		}, new short[1] { 38 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(269, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_269_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_269_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_269_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_269_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_269_4")
		}, new short[1] { 37 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(270, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_270_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_270_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_270_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_270_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_270_4")
		}, new short[1] { 38 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(271, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_271_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_271_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_271_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_271_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_271_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, 50, new List<ShortList>
		{
			new ShortList(272),
			new ShortList(273),
			new ShortList(274),
			new ShortList(270)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(272, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_272_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_272_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_272_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_272_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_272_4")
		}, new short[2] { 91, 92 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(273, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_273_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_273_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_273_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_273_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_273_4")
		}, new short[1] { 37 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(274, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_274_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_274_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_274_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_274_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_274_4")
		}, new short[1] { 38 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(275, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_275_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_275_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_275_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_275_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_275_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, 51, new List<ShortList>
		{
			new ShortList(276),
			new ShortList(273),
			new ShortList(270)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(276, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_276_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_276_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_276_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_276_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_276_4")
		}, new short[1] { 38 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(277, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_277_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_277_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_277_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_277_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_277_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, 1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(41, 279, 30, 31, 281, 23, 28, 279, 41)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(278, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_278_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_278_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_278_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_278_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_278_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, 2, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(43, 280, 30, 31, 281, 23, 28, 279, 41)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(279, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_279_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_279_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_279_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_279_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_279_4")
		}, new short[1] { 38 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, 38, new List<ShortList>
		{
			new ShortList(-1)
		}, -3, 3, -6000, -3000, 3, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(280, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_280_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_280_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_280_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_280_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_280_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, 27, new List<ShortList>
		{
			new ShortList(286),
			new ShortList(282, 283),
			new ShortList(284, 285)
		}, -5, 5, -12000, -9000, 3, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(281, -1, null, null, endEventAfterJump: true, revealCharacters: false, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_281_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_281_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_281_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_281_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_281_4")
		}, new short[1] { 52 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, 27, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(282, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_282_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_282_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_282_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_282_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_282_4")
		}, new short[1] { 52 }, new List<ShortList>
		{
			new ShortList(1, 3, 5)
		}, -1, noGuard: false, 38, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 10, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(283, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_283_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_283_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_283_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_283_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_283_4")
		}, new short[1] { 52 }, new List<ShortList>
		{
			new ShortList(95, 3, 5)
		}, -1, noGuard: false, 38, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 10, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(284, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_284_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_284_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_284_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_284_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_284_4")
		}, new short[1] { 52 }, new List<ShortList>
		{
			new ShortList(2, 3, 5)
		}, -1, noGuard: false, 38, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 5, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(285, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_285_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_285_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_285_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_285_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_285_4")
		}, new short[1] { 52 }, new List<ShortList>
		{
			new ShortList(96, 3, 5)
		}, -1, noGuard: false, 38, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 5, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(286, -1, null, null, endEventAfterJump: true, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_286_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_286_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_286_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_286_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_286_4")
		}, new short[1] { 37 }, new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, 38, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
		_dataArray.Add(new SecretInformationAppliedResultItem(287, -1, "56b42732-239a-48b6-bfcd-a9fae0fa1147", null, endEventAfterJump: false, revealCharacters: true, new string[5]
		{
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_287_0"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_287_1"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_287_2"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_287_3"),
			LocalStringManager.GetConfig("SecretInformationAppliedResult_language", "Texts_287_4")
		}, new short[0], new List<ShortList>
		{
			new ShortList(-1)
		}, -1, noGuard: false, -1, new List<ShortList>
		{
			new ShortList(-1)
		}, 0, 0, 0, 0, 0, 0, isFavorabilityCost: false));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<SecretInformationAppliedResultItem>(288);
		CreateItems0();
		CreateItems1();
		CreateItems2();
		CreateItems3();
		CreateItems4();
	}
}

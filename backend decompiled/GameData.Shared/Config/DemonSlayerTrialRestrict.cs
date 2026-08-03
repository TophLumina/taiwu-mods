using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class DemonSlayerTrialRestrict : ConfigData<DemonSlayerTrialRestrictItem, int>
{
	/// <summary>
	/// 配置表实例
	/// </summary>
	public static DemonSlayerTrialRestrict Instance = new DemonSlayerTrialRestrict();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Desc", "MutexGroupId", "MutexDemonId", "PreferCombatConfig", "EffectiveCombatConfigs", "TemplateId", "Power", "Weight", "EffectClassName" };

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
		_dataArray.Add(new DemonSlayerTrialRestrictItem(0, LocalStringManager.GetConfig("DemonSlayerTrialRestrict_language", "Desc_0"), 0, new List<int>(), 3, 9, 0, 5, -1, -1, -1, -1, -1, 211, new List<short>
		{
			211, 212, 213, 214, 215, 216, 217, 218, 219, 220,
			221, 222
		}, null, new int[0]));
		_dataArray.Add(new DemonSlayerTrialRestrictItem(1, LocalStringManager.GetConfig("DemonSlayerTrialRestrict_language", "Desc_1"), 0, new List<int>(), 6, 36, 3, 5, -1, -1, -1, -1, -1, 211, new List<short>
		{
			211, 212, 213, 214, 215, 216, 217, 218, 219, 220,
			221, 222
		}, null, new int[0]));
		_dataArray.Add(new DemonSlayerTrialRestrictItem(2, LocalStringManager.GetConfig("DemonSlayerTrialRestrict_language", "Desc_2"), 0, new List<int>(), 9, 81, 0, 2, -1, -1, -1, -1, -1, 211, new List<short>
		{
			211, 212, 213, 214, 215, 216, 217, 218, 219, 220,
			221, 222
		}, null, new int[0]));
		_dataArray.Add(new DemonSlayerTrialRestrictItem(3, LocalStringManager.GetConfig("DemonSlayerTrialRestrict_language", "Desc_3"), 3, new List<int>(), 4, 16, 0, 8, 4, -1, -1, -1, -1, 211, new List<short>
		{
			211, 212, 213, 214, 215, 216, 217, 218, 219, 220,
			221, 222
		}, null, new int[0]));
		_dataArray.Add(new DemonSlayerTrialRestrictItem(4, LocalStringManager.GetConfig("DemonSlayerTrialRestrict_language", "Desc_4"), 3, new List<int>(), 6, 36, 0, 8, 3, -1, -1, -1, -1, 211, new List<short>
		{
			211, 212, 213, 214, 215, 216, 217, 218, 219, 220,
			221, 222
		}, null, new int[0]));
		_dataArray.Add(new DemonSlayerTrialRestrictItem(5, LocalStringManager.GetConfig("DemonSlayerTrialRestrict_language", "Desc_5"), 3, new List<int>(), 8, 64, 0, 8, 2, -1, -1, -1, -1, 211, new List<short>
		{
			211, 212, 213, 214, 215, 216, 217, 218, 219, 220,
			221, 222
		}, null, new int[0]));
		_dataArray.Add(new DemonSlayerTrialRestrictItem(6, LocalStringManager.GetConfig("DemonSlayerTrialRestrict_language", "Desc_6"), 6, new List<int>(), 2, 4, 0, 8, -1, 4, -1, -1, -1, 211, new List<short>
		{
			211, 212, 213, 214, 215, 216, 217, 218, 219, 220,
			221, 222
		}, null, new int[0]));
		_dataArray.Add(new DemonSlayerTrialRestrictItem(7, LocalStringManager.GetConfig("DemonSlayerTrialRestrict_language", "Desc_7"), 6, new List<int>(), 4, 16, 0, 8, -1, 3, -1, -1, -1, 211, new List<short>
		{
			211, 212, 213, 214, 215, 216, 217, 218, 219, 220,
			221, 222
		}, null, new int[0]));
		_dataArray.Add(new DemonSlayerTrialRestrictItem(8, LocalStringManager.GetConfig("DemonSlayerTrialRestrict_language", "Desc_8"), 6, new List<int>(), 6, 36, 0, 8, -1, 2, -1, -1, -1, 211, new List<short>
		{
			211, 212, 213, 214, 215, 216, 217, 218, 219, 220,
			221, 222
		}, null, new int[0]));
		_dataArray.Add(new DemonSlayerTrialRestrictItem(9, LocalStringManager.GetConfig("DemonSlayerTrialRestrict_language", "Desc_9"), 9, new List<int>(), 2, 4, 0, 8, -1, -1, 4, -1, -1, 211, new List<short>
		{
			211, 212, 213, 214, 215, 216, 217, 218, 219, 220,
			221, 222
		}, null, new int[0]));
		_dataArray.Add(new DemonSlayerTrialRestrictItem(10, LocalStringManager.GetConfig("DemonSlayerTrialRestrict_language", "Desc_10"), 9, new List<int>(), 4, 16, 0, 8, -1, -1, 3, -1, -1, 211, new List<short>
		{
			211, 212, 213, 214, 215, 216, 217, 218, 219, 220,
			221, 222
		}, null, new int[0]));
		_dataArray.Add(new DemonSlayerTrialRestrictItem(11, LocalStringManager.GetConfig("DemonSlayerTrialRestrict_language", "Desc_11"), 9, new List<int>(), 6, 36, 0, 8, -1, -1, 2, -1, -1, 211, new List<short>
		{
			211, 212, 213, 214, 215, 216, 217, 218, 219, 220,
			221, 222
		}, null, new int[0]));
		_dataArray.Add(new DemonSlayerTrialRestrictItem(12, LocalStringManager.GetConfig("DemonSlayerTrialRestrict_language", "Desc_12"), 12, new List<int>(), 4, 16, 0, 8, -1, -1, -1, 4, -1, 211, new List<short>
		{
			211, 212, 213, 214, 215, 216, 217, 218, 219, 220,
			221, 222
		}, null, new int[0]));
		_dataArray.Add(new DemonSlayerTrialRestrictItem(13, LocalStringManager.GetConfig("DemonSlayerTrialRestrict_language", "Desc_13"), 12, new List<int>(), 6, 36, 0, 8, -1, -1, -1, 3, -1, 211, new List<short>
		{
			211, 212, 213, 214, 215, 216, 217, 218, 219, 220,
			221, 222
		}, null, new int[0]));
		_dataArray.Add(new DemonSlayerTrialRestrictItem(14, LocalStringManager.GetConfig("DemonSlayerTrialRestrict_language", "Desc_14"), 12, new List<int>(), 8, 64, 0, 8, -1, -1, -1, 2, -1, 211, new List<short>
		{
			211, 212, 213, 214, 215, 216, 217, 218, 219, 220,
			221, 222
		}, null, new int[0]));
		_dataArray.Add(new DemonSlayerTrialRestrictItem(15, LocalStringManager.GetConfig("DemonSlayerTrialRestrict_language", "Desc_15"), 15, new List<int>(), 5, 25, 0, 8, -1, -1, -1, -1, 1, 211, new List<short>
		{
			211, 212, 213, 214, 215, 216, 217, 218, 219, 220,
			221, 222
		}, null, new int[0]));
		_dataArray.Add(new DemonSlayerTrialRestrictItem(16, LocalStringManager.GetConfig("DemonSlayerTrialRestrict_language", "Desc_16"), 16, new List<int>(), 3, 9, 0, 8, -1, -1, -1, -1, -1, 214, new List<short> { 214, 217, 220 }, null, new int[0]));
		_dataArray.Add(new DemonSlayerTrialRestrictItem(17, LocalStringManager.GetConfig("DemonSlayerTrialRestrict_language", "Desc_17"), 16, new List<int>(), 5, 25, 0, 8, -1, -1, -1, -1, -1, 215, new List<short> { 215, 218, 221 }, null, new int[0]));
		_dataArray.Add(new DemonSlayerTrialRestrictItem(18, LocalStringManager.GetConfig("DemonSlayerTrialRestrict_language", "Desc_18"), 16, new List<int>(), 7, 49, 0, 8, -1, -1, -1, -1, -1, 216, new List<short> { 216, 219, 222 }, null, new int[0]));
		_dataArray.Add(new DemonSlayerTrialRestrictItem(19, LocalStringManager.GetConfig("DemonSlayerTrialRestrict_language", "Desc_19"), 19, new List<int> { 5, 6, 10, 12, 16 }, 1, 1, 0, 8, -1, -1, -1, -1, -1, 212, new List<short> { 212, 217, 218, 219 }, null, new int[0]));
		_dataArray.Add(new DemonSlayerTrialRestrictItem(20, LocalStringManager.GetConfig("DemonSlayerTrialRestrict_language", "Desc_20"), 19, new List<int> { 0, 1, 3, 7, 9, 15, 17 }, 1, 1, 0, 8, -1, -1, -1, -1, -1, 213, new List<short> { 213, 220, 221, 222 }, null, new int[0]));
		_dataArray.Add(new DemonSlayerTrialRestrictItem(21, LocalStringManager.GetConfig("DemonSlayerTrialRestrict_language", "Desc_21"), 21, new List<int>(), 1, 1, 0, 8, -1, -1, -1, -1, -1, 211, new List<short>
		{
			211, 212, 213, 214, 215, 216, 217, 218, 219, 220,
			221, 222
		}, "GameData.Domains.SpecialEffect.SectStory.Shaolin.AddRandomInjury", new int[3] { 3, 2, 2 }));
		_dataArray.Add(new DemonSlayerTrialRestrictItem(22, LocalStringManager.GetConfig("DemonSlayerTrialRestrict_language", "Desc_22"), 21, new List<int>(), 3, 9, 0, 8, -1, -1, -1, -1, -1, 211, new List<short>
		{
			211, 212, 213, 214, 215, 216, 217, 218, 219, 220,
			221, 222
		}, "GameData.Domains.SpecialEffect.SectStory.Shaolin.AddRandomInjury", new int[3] { 2, 3, 3 }));
		_dataArray.Add(new DemonSlayerTrialRestrictItem(23, LocalStringManager.GetConfig("DemonSlayerTrialRestrict_language", "Desc_23"), 21, new List<int>(), 5, 25, 0, 8, -1, -1, -1, -1, -1, 211, new List<short>
		{
			211, 212, 213, 214, 215, 216, 217, 218, 219, 220,
			221, 222
		}, "GameData.Domains.SpecialEffect.SectStory.Shaolin.AddRandomInjury", new int[3] { 1, 6, 6 }));
		_dataArray.Add(new DemonSlayerTrialRestrictItem(24, LocalStringManager.GetConfig("DemonSlayerTrialRestrict_language", "Desc_24"), 24, new List<int>(), 1, 1, 0, 8, -1, -1, -1, -1, -1, 211, new List<short>
		{
			211, 212, 213, 214, 215, 216, 217, 218, 219, 220,
			221, 222
		}, "GameData.Domains.SpecialEffect.SectStory.Shaolin.AddRandomFlawAndAcupoint", new int[5] { 2, 1, 3, 1, 3 }));
		_dataArray.Add(new DemonSlayerTrialRestrictItem(25, LocalStringManager.GetConfig("DemonSlayerTrialRestrict_language", "Desc_25"), 24, new List<int>(), 3, 9, 0, 8, -1, -1, -1, -1, -1, 211, new List<short>
		{
			211, 212, 213, 214, 215, 216, 217, 218, 219, 220,
			221, 222
		}, "GameData.Domains.SpecialEffect.SectStory.Shaolin.AddRandomFlawAndAcupoint", new int[5] { 4, 1, 3, 1, 3 }));
		_dataArray.Add(new DemonSlayerTrialRestrictItem(26, LocalStringManager.GetConfig("DemonSlayerTrialRestrict_language", "Desc_26"), 24, new List<int>(), 5, 25, 0, 8, -1, -1, -1, -1, -1, 211, new List<short>
		{
			211, 212, 213, 214, 215, 216, 217, 218, 219, 220,
			221, 222
		}, "GameData.Domains.SpecialEffect.SectStory.Shaolin.AddRandomFlawAndAcupoint", new int[5] { 6, 1, 3, 1, 3 }));
		_dataArray.Add(new DemonSlayerTrialRestrictItem(27, LocalStringManager.GetConfig("DemonSlayerTrialRestrict_language", "Desc_27"), 27, new List<int>(), 1, 1, 0, 8, -1, -1, -1, -1, -1, 211, new List<short>
		{
			211, 212, 213, 214, 215, 216, 217, 218, 219, 220,
			221, 222
		}, "GameData.Domains.SpecialEffect.SectStory.Shaolin.CostNeiliAllocation", new int[1] { 33 }));
		_dataArray.Add(new DemonSlayerTrialRestrictItem(28, LocalStringManager.GetConfig("DemonSlayerTrialRestrict_language", "Desc_28"), 27, new List<int>(), 3, 9, 0, 8, -1, -1, -1, -1, -1, 211, new List<short>
		{
			211, 212, 213, 214, 215, 216, 217, 218, 219, 220,
			221, 222
		}, "GameData.Domains.SpecialEffect.SectStory.Shaolin.CostNeiliAllocation", new int[1] { 66 }));
		_dataArray.Add(new DemonSlayerTrialRestrictItem(29, LocalStringManager.GetConfig("DemonSlayerTrialRestrict_language", "Desc_29"), 27, new List<int>(), 5, 25, 0, 8, -1, -1, -1, -1, -1, 211, new List<short>
		{
			211, 212, 213, 214, 215, 216, 217, 218, 219, 220,
			221, 222
		}, "GameData.Domains.SpecialEffect.SectStory.Shaolin.CostNeiliAllocation", new int[1] { 99 }));
		_dataArray.Add(new DemonSlayerTrialRestrictItem(30, LocalStringManager.GetConfig("DemonSlayerTrialRestrict_language", "Desc_30"), 30, new List<int>(), 2, 4, 0, 8, -1, -1, -1, -1, -1, 211, new List<short>
		{
			211, 212, 213, 214, 215, 216, 217, 218, 219, 220,
			221, 222
		}, "GameData.Domains.SpecialEffect.SectStory.Shaolin.ChangeSubAttribute1", new int[1] { 80 }));
		_dataArray.Add(new DemonSlayerTrialRestrictItem(31, LocalStringManager.GetConfig("DemonSlayerTrialRestrict_language", "Desc_31"), 31, new List<int>(), 2, 4, 0, 8, -1, -1, -1, -1, -1, 211, new List<short>
		{
			211, 212, 213, 214, 215, 216, 217, 218, 219, 220,
			221, 222
		}, "GameData.Domains.SpecialEffect.SectStory.Shaolin.ChangeSubAttribute2", new int[1] { 80 }));
		_dataArray.Add(new DemonSlayerTrialRestrictItem(32, LocalStringManager.GetConfig("DemonSlayerTrialRestrict_language", "Desc_32"), 32, new List<int>(), 2, 4, 0, 8, -1, -1, -1, -1, -1, 211, new List<short>
		{
			211, 212, 213, 214, 215, 216, 217, 218, 219, 220,
			221, 222
		}, "GameData.Domains.SpecialEffect.SectStory.Shaolin.ChangeSubAttribute3", new int[1] { 80 }));
		_dataArray.Add(new DemonSlayerTrialRestrictItem(33, LocalStringManager.GetConfig("DemonSlayerTrialRestrict_language", "Desc_33"), 33, new List<int>(), 2, 4, 0, 8, -1, -1, -1, -1, -1, 211, new List<short>
		{
			211, 212, 213, 214, 215, 216, 217, 218, 219, 220,
			221, 222
		}, "GameData.Domains.SpecialEffect.SectStory.Shaolin.ChangeSubAttribute4", new int[1] { 80 }));
		_dataArray.Add(new DemonSlayerTrialRestrictItem(34, LocalStringManager.GetConfig("DemonSlayerTrialRestrict_language", "Desc_34"), 34, new List<int>(), 2, 4, 0, 8, -1, -1, -1, -1, -1, 211, new List<short>
		{
			211, 212, 213, 214, 215, 216, 217, 218, 219, 220,
			221, 222
		}, "GameData.Domains.SpecialEffect.SectStory.Shaolin.ChangeSubAttribute5", new int[1] { 80 }));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<DemonSlayerTrialRestrictItem>(35);
		CreateItems0();
	}
}

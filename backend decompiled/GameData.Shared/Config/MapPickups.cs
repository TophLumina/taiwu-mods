using System;
using System.Collections.Generic;
using Config.Common;
using Config.ConfigCells;
using Config.ConfigCells.Character;

namespace Config;

[Serializable]
public class MapPickups : ConfigData<MapPickupsItem, short>
{
	public static class DefKey
	{
		public const short FoodResource = 0;

		public const short WoodResource = 1;

		public const short StonResource = 2;

		public const short JadeResource = 3;

		public const short SilkResource = 4;

		public const short HerbalResource = 5;

		public const short MoneyResource = 6;

		public const short AuthorityResource = 7;
	}

	public static class DefValue
	{
		public static MapPickupsItem FoodResource => Instance[(short)0];

		public static MapPickupsItem WoodResource => Instance[(short)1];

		public static MapPickupsItem StonResource => Instance[(short)2];

		public static MapPickupsItem JadeResource => Instance[(short)3];

		public static MapPickupsItem SilkResource => Instance[(short)4];

		public static MapPickupsItem HerbalResource => Instance[(short)5];

		public static MapPickupsItem MoneyResource => Instance[(short)6];

		public static MapPickupsItem AuthorityResource => Instance[(short)7];
	}

	public static MapPickups Instance = new MapPickups();

	private readonly HashSet<string> RequiredFields = new HashSet<string>
	{
		"Name", "TipsContent", "BlockList", "ItemGroup", "ShowConditionInformation", "ShowConditionOrganizationApproving", "InstantNotification", "ExtraBonusAddInstantNotification", "ExtraBonusReplaceInstantNotification", "EventMainContent",
		"EventMainOptions", "EventSecondContents", "EventSecondOptions", "EventSecondItemRewards", "EventSecondResourceRewards", "EventSecondPropertyRewards", "EventSecondItemRewardSelection1", "EventSecondItemRewardSelection2", "TemplateId", "Icon"
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
		_dataArray.Add(new MapPickupsItem(0, LocalStringManager.GetConfig("MapPickups_language", "Name_0"), EMapPickupsType.Resource, EMapPickupsType2.Resource, "map_eventicon_0", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_0"), 2, new byte[15]
		{
			3, 5, 4, 4, 3, 5, 4, 4, 4, 2,
			2, 3, 4, 5, 4
		}, new List<short> { 39, 40, 41, 75, 76, 77, 78, 79, 80, 93 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[8] { 50, 100, 200, 400, 800, 1600, 2400, 3200 }, new sbyte[0], default(PresetItemTemplateId), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6] { 50, 0, 0, 0, 0, 0 }, new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 179, 244, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_0"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(1, LocalStringManager.GetConfig("MapPickups_language", "Name_1"), EMapPickupsType.Resource, EMapPickupsType2.Resource, "map_eventicon_1", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_1"), 2, new byte[15]
		{
			2, 5, 4, 4, 3, 4, 5, 4, 4, 4,
			3, 5, 4, 2, 3
		}, new List<short>
		{
			42, 43, 44, 81, 82, 83, 84, 85, 86, 94,
			95, 96
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[8] { 50, 100, 200, 400, 800, 1600, 2400, 3200 }, new sbyte[0], default(PresetItemTemplateId), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6] { 0, 50, 0, 0, 0, 0 }, new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 179, 244, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_1"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(2, LocalStringManager.GetConfig("MapPickups_language", "Name_2"), EMapPickupsType.Resource, EMapPickupsType2.Resource, "map_eventicon_2", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_2"), 2, new byte[15]
		{
			4, 4, 3, 2, 5, 4, 2, 3, 4, 5,
			5, 3, 4, 4, 4
		}, new List<short>
		{
			45, 46, 47, 57, 58, 59, 60, 61, 62, 97,
			98, 99
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[8] { 50, 100, 200, 400, 800, 1600, 2400, 3200 }, new sbyte[0], default(PresetItemTemplateId), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6] { 0, 0, 50, 0, 0, 0 }, new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 179, 244, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_2"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(3, LocalStringManager.GetConfig("MapPickups_language", "Name_3"), EMapPickupsType.Resource, EMapPickupsType2.Resource, "map_eventicon_3", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_3"), 2, new byte[15]
		{
			4, 2, 5, 5, 2, 3, 5, 4, 3, 3,
			4, 4, 4, 4, 4
		}, new List<short>
		{
			54, 55, 56, 87, 88, 89, 90, 91, 92, 106,
			107, 108
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[8] { 50, 100, 200, 400, 800, 1600, 2400, 3200 }, new sbyte[0], default(PresetItemTemplateId), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6] { 0, 0, 0, 50, 0, 0 }, new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 179, 244, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_3"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(4, LocalStringManager.GetConfig("MapPickups_language", "Name_4"), EMapPickupsType.Resource, EMapPickupsType2.Resource, "map_eventicon_4", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_4"), 2, new byte[15]
		{
			3, 4, 5, 4, 2, 2, 4, 5, 4, 3,
			3, 5, 4, 4, 4
		}, new List<short>
		{
			48, 49, 50, 69, 70, 71, 72, 73, 74, 103,
			104, 105
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[8] { 50, 100, 200, 400, 800, 1600, 2400, 3200 }, new sbyte[0], default(PresetItemTemplateId), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6] { 0, 0, 0, 0, 50, 0 }, new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 179, 244, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_4"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(5, LocalStringManager.GetConfig("MapPickups_language", "Name_5"), EMapPickupsType.Resource, EMapPickupsType2.Resource, "map_eventicon_5", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_5"), 2, new byte[15]
		{
			3, 4, 5, 4, 2, 3, 4, 4, 3, 5,
			2, 5, 4, 4, 4
		}, new List<short>
		{
			51, 52, 53, 63, 64, 65, 66, 67, 68, 100,
			101, 102
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[8] { 50, 100, 200, 400, 800, 1600, 2400, 3200 }, new sbyte[0], default(PresetItemTemplateId), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6] { 0, 0, 0, 0, 0, 50 }, new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 179, 244, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_5"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(6, LocalStringManager.GetConfig("MapPickups_language", "Name_6"), EMapPickupsType.Resource, EMapPickupsType2.Resource, "map_eventicon_6", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_6"), 0, new byte[15]
		{
			5, 4, 2, 4, 4, 4, 3, 4, 5, 3,
			3, 2, 4, 4, 5
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36, 19, 20, 21, 22,
			23, 24, 25, 26, 27, 28, 29, 30, 31, 32,
			33
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[8] { 250, 500, 1000, 2000, 4000, 8000, 12000, 16000 }, new sbyte[0], default(PresetItemTemplateId), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 179, 244, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_6"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(7, LocalStringManager.GetConfig("MapPickups_language", "Name_7"), EMapPickupsType.Resource, EMapPickupsType2.Resource, "map_eventicon_7", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_7"), 0, new byte[15]
		{
			5, 4, 3, 4, 4, 4, 4, 4, 4, 3,
			3, 2, 5, 5, 2
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36, 19, 20, 21, 22,
			23, 24, 25, 26, 27, 28, 29, 30, 31, 32,
			33
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[8] { 25, 50, 100, 200, 400, 800, 1200, 1600 }, new sbyte[0], default(PresetItemTemplateId), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 179, 244, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_7"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(8, LocalStringManager.GetConfig("MapPickups_language", "Name_8"), EMapPickupsType.Item, EMapPickupsType2.Material, "map_eventicon_0", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_8"), 1, new byte[15]
		{
			1, 0, 0, 0, 1, 0, 0, 1, 0, 0,
			0, 1, 0, 1, 0
		}, new List<short> { 39, 40, 41, 75, 76, 77, 78, 79, 80, 93 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 4, 5, 5 }, new PresetItemTemplateId("Material", 56), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, false, false, false, true, true, true, false, false, false,
			true, true
		}, -1, new OrganizationApproving(), 180, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_8"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(9, LocalStringManager.GetConfig("MapPickups_language", "Name_9"), EMapPickupsType.Item, EMapPickupsType2.Material, "map_eventicon_0", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_9"), 1, new byte[15]
		{
			0, 1, 0, 0, 0, 1, 0, 0, 0, 1,
			1, 0, 0, 0, 1
		}, new List<short>
		{
			81, 82, 83, 84, 85, 86, 75, 76, 77, 78,
			79, 80
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 4, 5, 5 }, new PresetItemTemplateId("Material", 63), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, false, false, false, false, false, false, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 180, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_9"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(10, LocalStringManager.GetConfig("MapPickups_language", "Name_10"), EMapPickupsType.Item, EMapPickupsType2.Material, "map_eventicon_0", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_10"), 1, new byte[15]
		{
			0, 0, 1, 0, 1, 0, 1, 0, 1, 0,
			0, 0, 1, 0, 0
		}, new List<short> { 39, 40, 41, 75, 76, 77, 78, 79, 80, 93 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 4, 5, 5 }, new PresetItemTemplateId("Material", 70), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			false, true, true, true, false, false, false, true, true, true,
			false, false
		}, -1, new OrganizationApproving(), 180, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_10"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(11, LocalStringManager.GetConfig("MapPickups_language", "Name_11"), EMapPickupsType.Item, EMapPickupsType2.Material, "map_eventicon_0", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_11"), 1, new byte[15]
		{
			0, 0, 1, 1, 0, 0, 1, 0, 1, 0,
			0, 0, 0, 1, 0
		}, new List<short> { 87, 88, 89, 90, 91, 92, 106, 107, 108, 93 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 4, 5, 5 }, new PresetItemTemplateId("Material", 77), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			false, true, true, true, true, true, true, false, false, false,
			false, false
		}, -1, new OrganizationApproving(), 180, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_11"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(12, LocalStringManager.GetConfig("MapPickups_language", "Name_12"), EMapPickupsType.Item, EMapPickupsType2.Material, "map_eventicon_1", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_12"), 1, new byte[15]
		{
			1, 0, 0, 1, 0, 0, 0, 1, 0, 0,
			0, 1, 1, 0, 0
		}, new List<short>
		{
			42, 43, 44, 81, 82, 83, 84, 85, 86, 94,
			95, 96
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 1, 2, 3, 4, 5, 5, 6, 6 }, new PresetItemTemplateId("Material", 0), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 181, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_12"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(13, LocalStringManager.GetConfig("MapPickups_language", "Name_13"), EMapPickupsType.Item, EMapPickupsType2.Material, "map_eventicon_1", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_13"), 1, new byte[15]
		{
			1, 0, 0, 1, 0, 0, 0, 1, 0, 0,
			0, 1, 1, 0, 0
		}, new List<short>
		{
			42, 43, 44, 81, 82, 83, 84, 85, 86, 94,
			95, 96
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 1, 2, 3, 4, 5, 5, 6, 6 }, new PresetItemTemplateId("Material", 7), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 181, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_13"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(14, LocalStringManager.GetConfig("MapPickups_language", "Name_14"), EMapPickupsType.Item, EMapPickupsType2.Material, "map_eventicon_2", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_14"), 1, new byte[15]
		{
			0, 1, 0, 0, 1, 0, 1, 0, 1, 0,
			0, 0, 0, 1, 0
		}, new List<short>
		{
			45, 46, 47, 57, 58, 59, 60, 61, 62, 97,
			98, 99
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 1, 2, 3, 4, 5, 5, 6, 6 }, new PresetItemTemplateId("Material", 14), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 181, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_14"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(15, LocalStringManager.GetConfig("MapPickups_language", "Name_15"), EMapPickupsType.Item, EMapPickupsType2.Material, "map_eventicon_2", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_15"), 1, new byte[15]
		{
			0, 1, 0, 0, 1, 0, 1, 0, 1, 0,
			0, 0, 0, 1, 0
		}, new List<short>
		{
			45, 46, 47, 57, 58, 59, 60, 61, 62, 97,
			98, 99
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 1, 2, 3, 4, 5, 5, 6, 6 }, new PresetItemTemplateId("Material", 21), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 181, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_15"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(16, LocalStringManager.GetConfig("MapPickups_language", "Name_16"), EMapPickupsType.Item, EMapPickupsType2.Material, "map_eventicon_3", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_16"), 1, new byte[15]
		{
			0, 0, 1, 0, 0, 0, 1, 1, 0, 0,
			1, 1, 0, 0, 1
		}, new List<short>
		{
			54, 55, 56, 87, 88, 89, 90, 91, 92, 106,
			107, 108
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 1, 2, 3, 4, 5, 5, 6, 6 }, new PresetItemTemplateId("Material", 28), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 181, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_16"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(17, LocalStringManager.GetConfig("MapPickups_language", "Name_17"), EMapPickupsType.Item, EMapPickupsType2.Material, "map_eventicon_3", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_17"), 1, new byte[15]
		{
			0, 0, 1, 0, 0, 0, 1, 1, 0, 0,
			1, 1, 0, 0, 1
		}, new List<short>
		{
			54, 55, 56, 87, 88, 89, 90, 91, 92, 106,
			107, 108
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 1, 2, 3, 4, 5, 5, 6, 6 }, new PresetItemTemplateId("Material", 35), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 181, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_17"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(18, LocalStringManager.GetConfig("MapPickups_language", "Name_18"), EMapPickupsType.Item, EMapPickupsType2.Material, "map_eventicon_4", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_18"), 1, new byte[15]
		{
			0, 0, 1, 0, 0, 1, 0, 0, 0, 1,
			1, 0, 1, 0, 0
		}, new List<short> { 69, 70, 71, 72, 73, 74, 103, 104, 105 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 1, 2, 3, 4, 5, 5, 6, 6 }, new PresetItemTemplateId("Material", 42), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 181, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_18"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(19, LocalStringManager.GetConfig("MapPickups_language", "Name_19"), EMapPickupsType.Item, EMapPickupsType2.Material, "map_eventicon_4", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_19"), 1, new byte[15]
		{
			0, 0, 1, 0, 0, 1, 0, 0, 0, 1,
			1, 0, 1, 0, 0
		}, new List<short> { 48, 49, 50, 69, 70, 71, 103, 104, 105 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 1, 2, 3, 4, 5, 5, 6, 6 }, new PresetItemTemplateId("Material", 49), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 181, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_19"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(20, LocalStringManager.GetConfig("MapPickups_language", "Name_20"), EMapPickupsType.Item, EMapPickupsType2.Material, "map_eventicon_5", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_20"), 0, new byte[15]
		{
			0, 1, 0, 1, 0, 1, 1, 0, 0, 0,
			0, 0, 0, 1, 0
		}, new List<short>
		{
			51, 52, 53, 57, 58, 59, 60, 61, 62, 63,
			64, 65, 66, 67, 68, 69, 70, 71, 72, 73,
			74, 75, 76, 77, 78, 79, 80, 81, 82, 83,
			84, 85, 86, 87, 88, 89, 90, 91, 92
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[3] { 2, 4, 6 }, new PresetItemTemplateId("Material", 140), new sbyte[3] { 1, 3, 5 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 182, 254, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_20"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(21, LocalStringManager.GetConfig("MapPickups_language", "Name_21"), EMapPickupsType.Item, EMapPickupsType2.Material, "map_eventicon_5", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_21"), 0, new byte[15]
		{
			0, 0, 1, 0, 0, 0, 0, 1, 0, 1,
			1, 0, 0, 0, 1
		}, new List<short>
		{
			51, 52, 53, 57, 58, 59, 60, 61, 62, 63,
			64, 65, 66, 67, 68, 69, 70, 71, 72, 73,
			74, 75, 76, 77, 78, 79, 80, 81, 82, 83,
			84, 85, 86, 87, 88, 89, 90, 91, 92
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[3] { 2, 4, 6 }, new PresetItemTemplateId("Material", 144), new sbyte[3] { 1, 3, 5 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 182, 254, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_21"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(22, LocalStringManager.GetConfig("MapPickups_language", "Name_22"), EMapPickupsType.Item, EMapPickupsType2.Material, "map_eventicon_5", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_22"), 0, new byte[15]
		{
			1, 0, 1, 0, 0, 0, 0, 0, 1, 0,
			1, 0, 1, 0, 0
		}, new List<short>
		{
			51, 52, 53, 57, 58, 59, 60, 61, 62, 63,
			64, 65, 66, 67, 68, 69, 70, 71, 72, 73,
			74, 75, 76, 77, 78, 79, 80, 81, 82, 83,
			84, 85, 86, 87, 88, 89, 90, 91, 92
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[3] { 2, 4, 6 }, new PresetItemTemplateId("Material", 148), new sbyte[3] { 1, 3, 5 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 182, 254, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_22"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(23, LocalStringManager.GetConfig("MapPickups_language", "Name_23"), EMapPickupsType.Item, EMapPickupsType2.Material, "map_eventicon_5", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_23"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 1, 0, 1,
			1, 1, 0, 0, 1
		}, new List<short>
		{
			51, 52, 53, 57, 58, 59, 60, 61, 62, 63,
			64, 65, 66, 67, 68, 69, 70, 71, 72, 73,
			74, 75, 76, 77, 78, 79, 80, 81, 82, 83,
			84, 85, 86, 87, 88, 89, 90, 91, 92
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[3] { 2, 4, 6 }, new PresetItemTemplateId("Material", 152), new sbyte[3] { 1, 3, 5 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 182, 254, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_23"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(24, LocalStringManager.GetConfig("MapPickups_language", "Name_24"), EMapPickupsType.Item, EMapPickupsType2.Material, "map_eventicon_5", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_24"), 0, new byte[15]
		{
			0, 0, 1, 1, 0, 1, 0, 0, 0, 1,
			0, 0, 1, 0, 0
		}, new List<short>
		{
			51, 52, 53, 57, 58, 59, 60, 61, 62, 63,
			64, 65, 66, 67, 68, 69, 70, 71, 72, 73,
			74, 75, 76, 77, 78, 79, 80, 81, 82, 83,
			84, 85, 86, 87, 88, 89, 90, 91, 92
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[3] { 2, 4, 6 }, new PresetItemTemplateId("Material", 156), new sbyte[3] { 1, 3, 5 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 182, 254, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_24"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(25, LocalStringManager.GetConfig("MapPickups_language", "Name_25"), EMapPickupsType.Item, EMapPickupsType2.Material, "map_eventicon_5", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_25"), 0, new byte[15]
		{
			0, 1, 0, 1, 0, 0, 1, 0, 1, 0,
			0, 0, 0, 0, 1
		}, new List<short>
		{
			51, 52, 53, 57, 58, 59, 60, 61, 62, 63,
			64, 65, 66, 67, 68, 69, 70, 71, 72, 73,
			74, 75, 76, 77, 78, 79, 80, 81, 82, 83,
			84, 85, 86, 87, 88, 89, 90, 91, 92
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[3] { 2, 4, 6 }, new PresetItemTemplateId("Material", 160), new sbyte[3] { 1, 3, 5 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 182, 254, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_25"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(26, LocalStringManager.GetConfig("MapPickups_language", "Name_26"), EMapPickupsType.Item, EMapPickupsType2.Material, "map_eventicon_5", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_26"), 0, new byte[15]
		{
			1, 1, 0, 0, 0, 0, 0, 1, 0, 0,
			1, 0, 0, 1, 0
		}, new List<short>
		{
			51, 52, 53, 57, 58, 59, 60, 61, 62, 63,
			64, 65, 66, 67, 68, 69, 70, 71, 72, 73,
			74, 75, 76, 77, 78, 79, 80, 81, 82, 83,
			84, 85, 86, 87, 88, 89, 90, 91, 92
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[3] { 2, 4, 6 }, new PresetItemTemplateId("Material", 164), new sbyte[3] { 1, 3, 5 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 182, 254, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_26"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(27, LocalStringManager.GetConfig("MapPickups_language", "Name_27"), EMapPickupsType.Item, EMapPickupsType2.Material, "map_eventicon_5", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_27"), 0, new byte[15]
		{
			1, 1, 0, 0, 0, 0, 0, 1, 0, 0,
			1, 0, 0, 1, 0
		}, new List<short>
		{
			51, 52, 53, 57, 58, 59, 60, 61, 62, 63,
			64, 65, 66, 67, 68, 69, 70, 71, 72, 73,
			74, 75, 76, 77, 78, 79, 80, 81, 82, 83,
			84, 85, 86, 87, 88, 89, 90, 91, 92
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[3] { 2, 4, 6 }, new PresetItemTemplateId("Material", 168), new sbyte[3] { 1, 3, 5 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 182, 254, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_27"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(28, LocalStringManager.GetConfig("MapPickups_language", "Name_28"), EMapPickupsType.Item, EMapPickupsType2.Material, "map_eventicon_5", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_28"), 0, new byte[15]
		{
			1, 0, 0, 1, 0, 0, 0, 1, 0, 0,
			0, 1, 1, 0, 0
		}, new List<short>
		{
			51, 52, 53, 57, 58, 59, 60, 61, 62, 63,
			64, 65, 66, 67, 68, 69, 70, 71, 72, 73,
			74, 75, 76, 77, 78, 79, 80, 81, 82, 83,
			84, 85, 86, 87, 88, 89, 90, 91, 92
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[3] { 2, 4, 6 }, new PresetItemTemplateId("Material", 172), new sbyte[3] { 1, 3, 5 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 182, 254, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_28"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(29, LocalStringManager.GetConfig("MapPickups_language", "Name_29"), EMapPickupsType.Item, EMapPickupsType2.Material, "map_eventicon_5", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_29"), 0, new byte[15]
		{
			0, 0, 0, 1, 0, 1, 0, 0, 0, 1,
			0, 1, 0, 0, 1
		}, new List<short>
		{
			51, 52, 53, 57, 58, 59, 60, 61, 62, 63,
			64, 65, 66, 67, 68, 69, 70, 71, 72, 73,
			74, 75, 76, 77, 78, 79, 80, 81, 82, 83,
			84, 85, 86, 87, 88, 89, 90, 91, 92
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[3] { 2, 4, 6 }, new PresetItemTemplateId("Material", 176), new sbyte[3] { 1, 3, 5 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 182, 254, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_29"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(30, LocalStringManager.GetConfig("MapPickups_language", "Name_30"), EMapPickupsType.Item, EMapPickupsType2.Material, "map_eventicon_5", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_30"), 0, new byte[15]
		{
			0, 0, 1, 0, 1, 0, 1, 1, 0, 0,
			0, 0, 0, 1, 0
		}, new List<short>
		{
			51, 52, 53, 57, 58, 59, 60, 61, 62, 63,
			64, 65, 66, 67, 68, 69, 70, 71, 72, 73,
			74, 75, 76, 77, 78, 79, 80, 81, 82, 83,
			84, 85, 86, 87, 88, 89, 90, 91, 92
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[3] { 2, 4, 6 }, new PresetItemTemplateId("Material", 180), new sbyte[3] { 1, 3, 5 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 182, 254, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_30"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(31, LocalStringManager.GetConfig("MapPickups_language", "Name_31"), EMapPickupsType.Item, EMapPickupsType2.Material, "map_eventicon_5", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_31"), 0, new byte[15]
		{
			0, 0, 1, 0, 1, 0, 1, 0, 1, 0,
			0, 0, 0, 1, 0
		}, new List<short>
		{
			51, 52, 53, 57, 58, 59, 60, 61, 62, 63,
			64, 65, 66, 67, 68, 69, 70, 71, 72, 73,
			74, 75, 76, 77, 78, 79, 80, 81, 82, 83,
			84, 85, 86, 87, 88, 89, 90, 91, 92
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[3] { 2, 4, 6 }, new PresetItemTemplateId("Material", 184), new sbyte[3] { 1, 3, 5 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 182, 254, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_31"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(32, LocalStringManager.GetConfig("MapPickups_language", "Name_32"), EMapPickupsType.Item, EMapPickupsType2.Material, "map_eventicon_5", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_32"), 0, new byte[15]
		{
			0, 0, 0, 0, 1, 0, 1, 1, 0, 0,
			0, 1, 1, 0, 0
		}, new List<short>
		{
			51, 52, 53, 57, 58, 59, 60, 61, 62, 63,
			64, 65, 66, 67, 68, 69, 70, 71, 72, 73,
			74, 75, 76, 77, 78, 79, 80, 81, 82, 83,
			84, 85, 86, 87, 88, 89, 90, 91, 92
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[3] { 2, 4, 6 }, new PresetItemTemplateId("Material", 188), new sbyte[3] { 1, 3, 5 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 182, 254, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_32"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(33, LocalStringManager.GetConfig("MapPickups_language", "Name_33"), EMapPickupsType.Item, EMapPickupsType2.Material, "map_eventicon_5", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_33"), 0, new byte[15]
		{
			1, 0, 1, 1, 0, 0, 0, 0, 1, 0,
			0, 0, 0, 1, 0
		}, new List<short>
		{
			51, 52, 53, 57, 58, 59, 60, 61, 62, 63,
			64, 65, 66, 67, 68, 69, 70, 71, 72, 73,
			74, 75, 76, 77, 78, 79, 80, 81, 82, 83,
			84, 85, 86, 87, 88, 89, 90, 91, 92
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[3] { 2, 4, 6 }, new PresetItemTemplateId("Material", 192), new sbyte[3] { 1, 3, 5 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 182, 254, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_33"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(34, LocalStringManager.GetConfig("MapPickups_language", "Name_34"), EMapPickupsType.Item, EMapPickupsType2.Material, "map_eventicon_5", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_34"), 0, new byte[15]
		{
			1, 1, 0, 0, 0, 1, 0, 0, 0, 0,
			1, 0, 0, 0, 1
		}, new List<short>
		{
			51, 52, 53, 57, 58, 59, 60, 61, 62, 63,
			64, 65, 66, 67, 68, 69, 70, 71, 72, 73,
			74, 75, 76, 77, 78, 79, 80, 81, 82, 83,
			84, 85, 86, 87, 88, 89, 90, 91, 92
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[3] { 2, 4, 6 }, new PresetItemTemplateId("Material", 196), new sbyte[3] { 1, 3, 5 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 182, 254, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_34"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(35, LocalStringManager.GetConfig("MapPickups_language", "Name_35"), EMapPickupsType.Item, EMapPickupsType2.Material, "map_eventicon_5", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_35"), 0, new byte[15]
		{
			0, 0, 1, 0, 0, 1, 0, 0, 0, 1,
			1, 0, 1, 0, 0
		}, new List<short>
		{
			51, 52, 53, 57, 58, 59, 60, 61, 62, 63,
			64, 65, 66, 67, 68, 69, 70, 71, 72, 73,
			74, 75, 76, 77, 78, 79, 80, 81, 82, 83,
			84, 85, 86, 87, 88, 89, 90, 91, 92
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[3] { 2, 4, 6 }, new PresetItemTemplateId("Material", 200), new sbyte[3] { 1, 3, 5 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 182, 254, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_35"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(36, LocalStringManager.GetConfig("MapPickups_language", "Name_36"), EMapPickupsType.Item, EMapPickupsType2.Material, "map_eventicon_5", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_36"), 0, new byte[15]
		{
			0, 0, 1, 0, 0, 1, 0, 0, 0, 1,
			1, 0, 0, 0, 1
		}, new List<short>
		{
			51, 52, 53, 57, 58, 59, 60, 61, 62, 63,
			64, 65, 66, 67, 68, 69, 70, 71, 72, 73,
			74, 75, 76, 77, 78, 79, 80, 81, 82, 83,
			84, 85, 86, 87, 88, 89, 90, 91, 92
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[3] { 2, 4, 6 }, new PresetItemTemplateId("Material", 204), new sbyte[3] { 1, 3, 5 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 182, 254, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_36"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(37, LocalStringManager.GetConfig("MapPickups_language", "Name_37"), EMapPickupsType.Item, EMapPickupsType2.Material, "map_eventicon_5", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_37"), 0, new byte[15]
		{
			0, 0, 0, 1, 0, 0, 0, 0, 1, 1,
			0, 1, 1, 0, 0
		}, new List<short>
		{
			51, 52, 53, 57, 58, 59, 60, 61, 62, 63,
			64, 65, 66, 67, 68, 69, 70, 71, 72, 73,
			74, 75, 76, 77, 78, 79, 80, 81, 82, 83,
			84, 85, 86, 87, 88, 89, 90, 91, 92
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[3] { 2, 4, 6 }, new PresetItemTemplateId("Material", 208), new sbyte[3] { 1, 3, 5 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 182, 254, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_37"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(38, LocalStringManager.GetConfig("MapPickups_language", "Name_38"), EMapPickupsType.Item, EMapPickupsType2.Material, "map_eventicon_5", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_38"), 0, new byte[15]
		{
			1, 1, 0, 0, 1, 0, 0, 1, 0, 0,
			0, 0, 0, 1, 0
		}, new List<short>
		{
			51, 52, 53, 57, 58, 59, 60, 61, 62, 63,
			64, 65, 66, 67, 68, 69, 70, 71, 72, 73,
			74, 75, 76, 77, 78, 79, 80, 81, 82, 83,
			84, 85, 86, 87, 88, 89, 90, 91, 92
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[3] { 2, 4, 6 }, new PresetItemTemplateId("Material", 212), new sbyte[3] { 1, 3, 5 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 182, 254, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_38"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(39, LocalStringManager.GetConfig("MapPickups_language", "Name_39"), EMapPickupsType.Item, EMapPickupsType2.Material, "map_eventicon_5", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_39"), 0, new byte[15]
		{
			1, 0, 1, 0, 1, 0, 0, 0, 1, 0,
			0, 0, 1, 0, 0
		}, new List<short>
		{
			51, 52, 53, 57, 58, 59, 60, 61, 62, 63,
			64, 65, 66, 67, 68, 69, 70, 71, 72, 73,
			74, 75, 76, 77, 78, 79, 80, 81, 82, 83,
			84, 85, 86, 87, 88, 89, 90, 91, 92
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[3] { 2, 4, 6 }, new PresetItemTemplateId("Material", 216), new sbyte[3] { 1, 3, 5 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 182, 254, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_39"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(40, LocalStringManager.GetConfig("MapPickups_language", "Name_40"), EMapPickupsType.Item, EMapPickupsType2.Material, "map_eventicon_5", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_40"), 0, new byte[15]
		{
			0, 0, 1, 1, 0, 1, 0, 0, 0, 1,
			0, 0, 1, 0, 0
		}, new List<short>
		{
			51, 52, 53, 57, 58, 59, 60, 61, 62, 63,
			64, 65, 66, 67, 68, 69, 70, 71, 72, 73,
			74, 75, 76, 77, 78, 79, 80, 81, 82, 83,
			84, 85, 86, 87, 88, 89, 90, 91, 92
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[3] { 2, 4, 6 }, new PresetItemTemplateId("Material", 220), new sbyte[3] { 1, 3, 5 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 182, 254, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_40"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(41, LocalStringManager.GetConfig("MapPickups_language", "Name_41"), EMapPickupsType.Item, EMapPickupsType2.Material, "map_eventicon_5", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_41"), 0, new byte[15]
		{
			1, 0, 0, 0, 0, 0, 0, 1, 0, 0,
			1, 1, 0, 0, 1
		}, new List<short>
		{
			51, 52, 53, 57, 58, 59, 60, 61, 62, 63,
			64, 65, 66, 67, 68, 69, 70, 71, 72, 73,
			74, 75, 76, 77, 78, 79, 80, 81, 82, 83,
			84, 85, 86, 87, 88, 89, 90, 91, 92
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[3] { 2, 4, 6 }, new PresetItemTemplateId("Material", 224), new sbyte[3] { 1, 3, 5 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 182, 254, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_41"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(42, LocalStringManager.GetConfig("MapPickups_language", "Name_42"), EMapPickupsType.Item, EMapPickupsType2.Material, "map_eventicon_5", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_42"), 0, new byte[15]
		{
			0, 0, 1, 0, 1, 1, 1, 0, 0, 0,
			0, 0, 0, 1, 0
		}, new List<short>
		{
			51, 52, 53, 57, 58, 59, 60, 61, 62, 63,
			64, 65, 66, 67, 68, 69, 70, 71, 72, 73,
			74, 75, 76, 77, 78, 79, 80, 81, 82, 83,
			84, 85, 86, 87, 88, 89, 90, 91, 92
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[3] { 2, 4, 6 }, new PresetItemTemplateId("Material", 228), new sbyte[3] { 1, 3, 5 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 182, 254, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_42"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(43, LocalStringManager.GetConfig("MapPickups_language", "Name_43"), EMapPickupsType.Item, EMapPickupsType2.Material, "map_eventicon_5", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_43"), 0, new byte[15]
		{
			1, 1, 0, 0, 0, 0, 0, 0, 1, 0,
			1, 0, 0, 0, 1
		}, new List<short>
		{
			51, 52, 53, 57, 58, 59, 60, 61, 62, 63,
			64, 65, 66, 67, 68, 69, 70, 71, 72, 73,
			74, 75, 76, 77, 78, 79, 80, 81, 82, 83,
			84, 85, 86, 87, 88, 89, 90, 91, 92
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[3] { 2, 4, 6 }, new PresetItemTemplateId("Material", 232), new sbyte[3] { 1, 3, 5 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 182, 254, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_43"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(44, LocalStringManager.GetConfig("MapPickups_language", "Name_44"), EMapPickupsType.Item, EMapPickupsType2.Material, "map_eventicon_5", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_44"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
			1, 1, 0, 1, 1
		}, new List<short>
		{
			94, 95, 96, 97, 98, 99, 100, 101, 102, 103,
			104, 105, 106, 107, 108
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[6] { 1, 2, 3, 4, 5, 6 }, new PresetItemTemplateId("Material", 236), new sbyte[6] { 1, 2, 3, 4, 5, 6 }, new short[6], new bool[12]
		{
			false, false, false, false, true, true, true, true, true, true,
			false, false
		}, -1, new OrganizationApproving(), 183, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_44"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(45, LocalStringManager.GetConfig("MapPickups_language", "Name_45"), EMapPickupsType.Item, EMapPickupsType2.Material, "map_eventicon_5", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_45"), 0, new byte[15]
		{
			0, 0, 1, 0, 0, 0, 0, 1, 0, 1,
			0, 1, 1, 0, 0
		}, new List<short>
		{
			94, 95, 96, 97, 98, 99, 100, 101, 102, 103,
			104, 105, 106, 107, 108
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[6] { 1, 2, 3, 4, 5, 6 }, new PresetItemTemplateId("Material", 243), new sbyte[6] { 1, 2, 3, 4, 5, 6 }, new short[6], new bool[12]
		{
			true, true, true, true, false, false, false, false, false, false,
			true, true
		}, -1, new OrganizationApproving(), 183, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_45"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(46, LocalStringManager.GetConfig("MapPickups_language", "Name_46"), EMapPickupsType.Item, EMapPickupsType2.Material, "map_eventicon_5", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_46"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
			1, 1, 0, 1, 1
		}, new List<short>
		{
			94, 95, 96, 97, 98, 99, 100, 101, 102, 103,
			104, 105, 106, 107, 108
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[6] { 1, 2, 3, 4, 5, 6 }, new PresetItemTemplateId("Material", 250), new sbyte[6] { 1, 2, 3, 4, 5, 6 }, new short[6], new bool[12]
		{
			true, true, true, true, false, false, false, false, false, false,
			true, true
		}, -1, new OrganizationApproving(), 183, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_46"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(47, LocalStringManager.GetConfig("MapPickups_language", "Name_47"), EMapPickupsType.Item, EMapPickupsType2.Material, "map_eventicon_5", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_47"), 0, new byte[15]
		{
			0, 0, 1, 0, 0, 0, 0, 1, 0, 1,
			0, 1, 1, 0, 0
		}, new List<short>
		{
			94, 95, 96, 97, 98, 99, 100, 101, 102, 103,
			104, 105, 106, 107, 108
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[6] { 1, 2, 3, 4, 5, 6 }, new PresetItemTemplateId("Material", 257), new sbyte[6] { 1, 2, 3, 4, 5, 6 }, new short[6], new bool[12]
		{
			false, false, false, false, true, true, true, true, true, true,
			false, false
		}, -1, new OrganizationApproving(), 183, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_47"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(48, LocalStringManager.GetConfig("MapPickups_language", "Name_48"), EMapPickupsType.Item, EMapPickupsType2.Material, "map_eventicon_5", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_48"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
			1, 1, 0, 1, 1
		}, new List<short>
		{
			94, 95, 96, 97, 98, 99, 100, 101, 102, 103,
			104, 105, 106, 107, 108
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[6] { 1, 2, 3, 4, 5, 6 }, new PresetItemTemplateId("Material", 264), new sbyte[6] { 1, 2, 3, 4, 5, 6 }, new short[6], new bool[12]
		{
			false, true, true, true, true, true, true, false, false, false,
			false, false
		}, -1, new OrganizationApproving(), 183, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_48"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(49, LocalStringManager.GetConfig("MapPickups_language", "Name_49"), EMapPickupsType.Item, EMapPickupsType2.Material, "map_eventicon_5", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_49"), 0, new byte[15]
		{
			0, 0, 1, 0, 0, 0, 0, 1, 0, 1,
			0, 1, 1, 0, 0
		}, new List<short>
		{
			94, 95, 96, 97, 98, 99, 100, 101, 102, 103,
			104, 105, 106, 107, 108
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[6] { 1, 2, 3, 4, 5, 6 }, new PresetItemTemplateId("Material", 271), new sbyte[6] { 1, 2, 3, 4, 5, 6 }, new short[6], new bool[12]
		{
			true, false, false, false, false, false, false, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 183, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_49"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(50, LocalStringManager.GetConfig("MapPickups_language", "Name_50"), EMapPickupsType.Item, EMapPickupsType2.Medicine, "map_eventicon_8", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_50"), 1, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
			1, 1, 0, 1, 1
		}, new List<short>
		{
			94, 95, 96, 97, 98, 99, 100, 101, 102, 103,
			104, 105, 106, 107, 108
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Medicine", 0), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 184, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_50"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(51, LocalStringManager.GetConfig("MapPickups_language", "Name_51"), EMapPickupsType.Item, EMapPickupsType2.Medicine, "map_eventicon_8", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_51"), 1, new byte[15]
		{
			0, 0, 1, 0, 0, 0, 0, 1, 0, 1,
			0, 1, 1, 0, 0
		}, new List<short>
		{
			94, 95, 96, 97, 98, 99, 100, 101, 102, 103,
			104, 105, 106, 107, 108
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Medicine", 9), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 184, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_51"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(52, LocalStringManager.GetConfig("MapPickups_language", "Name_52"), EMapPickupsType.Item, EMapPickupsType2.Medicine, "map_eventicon_8", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_52"), 1, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
			1, 1, 0, 1, 1
		}, new List<short>
		{
			94, 95, 96, 97, 98, 99, 100, 101, 102, 103,
			104, 105, 106, 107, 108
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Medicine", 27), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 184, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_52"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(53, LocalStringManager.GetConfig("MapPickups_language", "Name_53"), EMapPickupsType.Item, EMapPickupsType2.Medicine, "map_eventicon_8", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_53"), 1, new byte[15]
		{
			0, 0, 1, 0, 0, 0, 0, 1, 0, 1,
			0, 1, 1, 0, 0
		}, new List<short>
		{
			94, 95, 96, 97, 98, 99, 100, 101, 102, 103,
			104, 105, 106, 107, 108
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Medicine", 18), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 184, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_53"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(54, LocalStringManager.GetConfig("MapPickups_language", "Name_54"), EMapPickupsType.Item, EMapPickupsType2.Medicine, "map_eventicon_8", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_54"), 1, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
			1, 1, 0, 1, 1
		}, new List<short>
		{
			94, 95, 96, 97, 98, 99, 100, 101, 102, 103,
			104, 105, 106, 107, 108
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Medicine", 36), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 184, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_54"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(55, LocalStringManager.GetConfig("MapPickups_language", "Name_55"), EMapPickupsType.Item, EMapPickupsType2.Medicine, "map_eventicon_8", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_55"), 1, new byte[15]
		{
			0, 0, 1, 0, 0, 0, 0, 1, 0, 1,
			0, 1, 1, 0, 0
		}, new List<short>
		{
			94, 95, 96, 97, 98, 99, 100, 101, 102, 103,
			104, 105, 106, 107, 108
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Medicine", 45), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 184, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_55"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(56, LocalStringManager.GetConfig("MapPickups_language", "Name_56"), EMapPickupsType.Item, EMapPickupsType2.Medicine, "map_eventicon_8", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_56"), 1, new byte[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new List<short>
		{
			51, 52, 53, 1, 2, 3, 4, 5, 6, 7,
			8, 9, 10, 11, 12, 13, 14, 15, 34, 35,
			36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[6] { 0, 1, 2, 3, 4, 5 }, new PresetItemTemplateId("Medicine", 54), new sbyte[6] { 0, 1, 2, 3, 4, 5 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 185, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_56"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(57, LocalStringManager.GetConfig("MapPickups_language", "Name_57"), EMapPickupsType.Item, EMapPickupsType2.Medicine, "map_eventicon_8", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_57"), 0, new byte[15]
		{
			0, 0, 1, 0, 0, 1, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			51, 52, 53, 1, 2, 3, 4, 5, 6, 7,
			8, 9, 10, 11, 12, 13, 14, 15, 34, 35,
			36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[5] { 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Medicine", 60), new sbyte[5] { 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 185, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_57"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(58, LocalStringManager.GetConfig("MapPickups_language", "Name_58"), EMapPickupsType.Item, EMapPickupsType2.Medicine, "map_eventicon_8", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_58"), 1, new byte[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new List<short>
		{
			51, 52, 53, 1, 2, 3, 4, 5, 6, 7,
			8, 9, 10, 11, 12, 13, 14, 15, 34, 35,
			36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[6] { 0, 1, 2, 3, 4, 5 }, new PresetItemTemplateId("Medicine", 66), new sbyte[6] { 0, 1, 2, 3, 4, 5 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 185, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_58"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(59, LocalStringManager.GetConfig("MapPickups_language", "Name_59"), EMapPickupsType.Item, EMapPickupsType2.Medicine, "map_eventicon_8", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_59"), 0, new byte[15]
		{
			0, 0, 1, 0, 0, 0, 1, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			51, 52, 53, 1, 2, 3, 4, 5, 6, 7,
			8, 9, 10, 11, 12, 13, 14, 15, 34, 35,
			36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[5] { 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Medicine", 72), new sbyte[5] { 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 185, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_59"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new MapPickupsItem(60, LocalStringManager.GetConfig("MapPickups_language", "Name_60"), EMapPickupsType.Item, EMapPickupsType2.Medicine, "map_eventicon_8", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_60"), 1, new byte[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new List<short>
		{
			51, 52, 53, 1, 2, 3, 4, 5, 6, 7,
			8, 9, 10, 11, 12, 13, 14, 15, 34, 35,
			36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[6] { 0, 1, 2, 3, 4, 5 }, new PresetItemTemplateId("Medicine", 82), new sbyte[6] { 0, 1, 2, 3, 4, 5 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 185, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_60"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(61, LocalStringManager.GetConfig("MapPickups_language", "Name_61"), EMapPickupsType.Item, EMapPickupsType2.Medicine, "map_eventicon_8", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_61"), 0, new byte[15]
		{
			0, 0, 0, 1, 0, 0, 0, 0, 0, 1,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			51, 52, 53, 1, 2, 3, 4, 5, 6, 7,
			8, 9, 10, 11, 12, 13, 14, 15, 34, 35,
			36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[5] { 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Medicine", 88), new sbyte[5] { 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 185, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_61"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(62, LocalStringManager.GetConfig("MapPickups_language", "Name_62"), EMapPickupsType.Item, EMapPickupsType2.Medicine, "map_eventicon_8", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_62"), 1, new byte[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new List<short>
		{
			51, 52, 53, 1, 2, 3, 4, 5, 6, 7,
			8, 9, 10, 11, 12, 13, 14, 15, 34, 35,
			36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[6] { 0, 1, 2, 3, 4, 5 }, new PresetItemTemplateId("Medicine", 94), new sbyte[6] { 0, 1, 2, 3, 4, 5 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 185, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_62"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(63, LocalStringManager.GetConfig("MapPickups_language", "Name_63"), EMapPickupsType.Item, EMapPickupsType2.Medicine, "map_eventicon_8", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_63"), 0, new byte[15]
		{
			1, 0, 0, 0, 0, 0, 0, 0, 0, 1,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			51, 52, 53, 1, 2, 3, 4, 5, 6, 7,
			8, 9, 10, 11, 12, 13, 14, 15, 34, 35,
			36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[5] { 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Medicine", 100), new sbyte[5] { 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 185, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_63"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(64, LocalStringManager.GetConfig("MapPickups_language", "Name_64"), EMapPickupsType.Item, EMapPickupsType2.Medicine, "map_eventicon_8", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_64"), 0, new byte[15]
		{
			1, 0, 0, 0, 0, 0, 0, 1, 0, 0,
			1, 1, 0, 0, 1
		}, new List<short>
		{
			51, 52, 53, 1, 2, 3, 4, 5, 6, 7,
			8, 9, 10, 11, 12, 13, 14, 15, 34, 35,
			36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[6] { 0, 1, 2, 3, 4, 5 }, new PresetItemTemplateId("Medicine", 130), new sbyte[6] { 0, 1, 2, 3, 4, 5 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 186, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_64"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(65, LocalStringManager.GetConfig("MapPickups_language", "Name_65"), EMapPickupsType.Item, EMapPickupsType2.Medicine, "map_eventicon_8", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_65"), 0, new byte[15]
		{
			0, 0, 1, 1, 0, 1, 0, 0, 0, 1,
			0, 0, 0, 0, 1
		}, new List<short>
		{
			51, 52, 53, 1, 2, 3, 4, 5, 6, 7,
			8, 9, 10, 11, 12, 13, 14, 15, 34, 35,
			36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[5] { 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Medicine", 136), new sbyte[5] { 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 186, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_65"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(66, LocalStringManager.GetConfig("MapPickups_language", "Name_66"), EMapPickupsType.Item, EMapPickupsType2.Medicine, "map_eventicon_8", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_66"), 0, new byte[15]
		{
			0, 1, 0, 0, 1, 0, 1, 0, 1, 0,
			0, 0, 0, 1, 0
		}, new List<short>
		{
			51, 52, 53, 1, 2, 3, 4, 5, 6, 7,
			8, 9, 10, 11, 12, 13, 14, 15, 34, 35,
			36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[6] { 0, 1, 2, 3, 4, 5 }, new PresetItemTemplateId("Medicine", 142), new sbyte[6] { 0, 1, 2, 3, 4, 5 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 186, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_66"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(67, LocalStringManager.GetConfig("MapPickups_language", "Name_67"), EMapPickupsType.Item, EMapPickupsType2.Medicine, "map_eventicon_8", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_67"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 1, 0, 1,
			1, 1, 0, 0, 1
		}, new List<short>
		{
			51, 52, 53, 1, 2, 3, 4, 5, 6, 7,
			8, 9, 10, 11, 12, 13, 14, 15, 34, 35,
			36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[5] { 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Medicine", 148), new sbyte[5] { 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 186, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_67"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(68, LocalStringManager.GetConfig("MapPickups_language", "Name_68"), EMapPickupsType.Item, EMapPickupsType2.Medicine, "map_eventicon_8", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_68"), 0, new byte[15]
		{
			0, 0, 1, 0, 0, 0, 0, 1, 0, 1,
			1, 0, 1, 0, 0
		}, new List<short>
		{
			51, 52, 53, 1, 2, 3, 4, 5, 6, 7,
			8, 9, 10, 11, 12, 13, 14, 15, 34, 35,
			36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[6] { 0, 1, 2, 3, 4, 5 }, new PresetItemTemplateId("Medicine", 166), new sbyte[6] { 0, 1, 2, 3, 4, 5 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 186, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_68"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(69, LocalStringManager.GetConfig("MapPickups_language", "Name_69"), EMapPickupsType.Item, EMapPickupsType2.Medicine, "map_eventicon_8", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_69"), 0, new byte[15]
		{
			0, 1, 0, 0, 1, 0, 1, 0, 0, 0,
			0, 0, 0, 0, 1
		}, new List<short>
		{
			51, 52, 53, 1, 2, 3, 4, 5, 6, 7,
			8, 9, 10, 11, 12, 13, 14, 15, 34, 35,
			36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[5] { 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Medicine", 172), new sbyte[5] { 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 186, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_69"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(70, LocalStringManager.GetConfig("MapPickups_language", "Name_70"), EMapPickupsType.Item, EMapPickupsType2.Medicine, "map_eventicon_8", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_70"), 0, new byte[15]
		{
			1, 0, 1, 1, 0, 1, 0, 0, 0, 1,
			0, 0, 0, 1, 0
		}, new List<short>
		{
			51, 52, 53, 1, 2, 3, 4, 5, 6, 7,
			8, 9, 10, 11, 12, 13, 14, 15, 34, 35,
			36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[6] { 0, 1, 2, 3, 4, 5 }, new PresetItemTemplateId("Medicine", 154), new sbyte[6] { 0, 1, 2, 3, 4, 5 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 186, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_70"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(71, LocalStringManager.GetConfig("MapPickups_language", "Name_71"), EMapPickupsType.Item, EMapPickupsType2.Medicine, "map_eventicon_8", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_71"), 0, new byte[15]
		{
			1, 0, 0, 0, 0, 1, 0, 0, 0, 0,
			1, 1, 0, 0, 1
		}, new List<short>
		{
			51, 52, 53, 1, 2, 3, 4, 5, 6, 7,
			8, 9, 10, 11, 12, 13, 14, 15, 34, 35,
			36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[5] { 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Medicine", 160), new sbyte[5] { 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 186, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_71"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(72, LocalStringManager.GetConfig("MapPickups_language", "Name_72"), EMapPickupsType.Item, EMapPickupsType2.Medicine, "map_eventicon_8", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_72"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 1, 1,
			1, 1, 0, 0, 1
		}, new List<short>
		{
			51, 52, 53, 1, 2, 3, 4, 5, 6, 7,
			8, 9, 10, 11, 12, 13, 14, 15, 34, 35,
			36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[6] { 0, 1, 2, 3, 4, 5 }, new PresetItemTemplateId("Medicine", 178), new sbyte[6] { 0, 1, 2, 3, 4, 5 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 186, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_72"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(73, LocalStringManager.GetConfig("MapPickups_language", "Name_73"), EMapPickupsType.Item, EMapPickupsType2.Medicine, "map_eventicon_8", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_73"), 0, new byte[15]
		{
			0, 0, 1, 0, 1, 1, 1, 0, 0, 0,
			0, 0, 1, 0, 0
		}, new List<short>
		{
			51, 52, 53, 1, 2, 3, 4, 5, 6, 7,
			8, 9, 10, 11, 12, 13, 14, 15, 34, 35,
			36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[5] { 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Medicine", 184), new sbyte[5] { 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 186, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_73"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(74, LocalStringManager.GetConfig("MapPickups_language", "Name_74"), EMapPickupsType.Item, EMapPickupsType2.Medicine, "map_eventicon_8", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_74"), 0, new byte[15]
		{
			0, 0, 0, 1, 0, 0, 1, 1, 0, 0,
			0, 1, 0, 1, 0
		}, new List<short>
		{
			51, 52, 53, 1, 2, 3, 4, 5, 6, 7,
			8, 9, 10, 11, 12, 13, 14, 15, 34, 35,
			36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[6] { 0, 1, 2, 3, 4, 5 }, new PresetItemTemplateId("Medicine", 190), new sbyte[6] { 0, 1, 2, 3, 4, 5 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 186, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_74"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(75, LocalStringManager.GetConfig("MapPickups_language", "Name_75"), EMapPickupsType.Item, EMapPickupsType2.Medicine, "map_eventicon_8", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_75"), 0, new byte[15]
		{
			1, 0, 1, 0, 0, 0, 0, 0, 1, 1,
			0, 0, 0, 0, 1
		}, new List<short>
		{
			51, 52, 53, 1, 2, 3, 4, 5, 6, 7,
			8, 9, 10, 11, 12, 13, 14, 15, 34, 35,
			36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[5] { 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Medicine", 196), new sbyte[5] { 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 186, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_75"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(76, LocalStringManager.GetConfig("MapPickups_language", "Name_76"), EMapPickupsType.Item, EMapPickupsType2.Medicine, "map_eventicon_8", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_76"), 0, new byte[15]
		{
			1, 1, 0, 0, 1, 0, 0, 0, 1, 0,
			0, 0, 0, 1, 0
		}, new List<short>
		{
			51, 52, 53, 1, 2, 3, 4, 5, 6, 7,
			8, 9, 10, 11, 12, 13, 14, 15, 34, 35,
			36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[6] { 0, 1, 2, 3, 4, 5 }, new PresetItemTemplateId("Medicine", 274), new sbyte[6] { 0, 1, 2, 3, 4, 5 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 187, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_76"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(77, LocalStringManager.GetConfig("MapPickups_language", "Name_77"), EMapPickupsType.Item, EMapPickupsType2.Medicine, "map_eventicon_8", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_77"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 1, 0, 0, 0, 0,
			1, 0, 0, 0, 0
		}, new List<short>
		{
			51, 52, 53, 1, 2, 3, 4, 5, 6, 7,
			8, 9, 10, 11, 12, 13, 14, 15, 34, 35,
			36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[5] { 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Medicine", 280), new sbyte[5] { 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 187, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_77"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(78, LocalStringManager.GetConfig("MapPickups_language", "Name_78"), EMapPickupsType.Item, EMapPickupsType2.Medicine, "map_eventicon_8", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_78"), 0, new byte[15]
		{
			0, 0, 1, 1, 0, 0, 1, 1, 0, 0,
			0, 0, 1, 0, 0
		}, new List<short>
		{
			51, 52, 53, 1, 2, 3, 4, 5, 6, 7,
			8, 9, 10, 11, 12, 13, 14, 15, 34, 35,
			36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[6] { 0, 1, 2, 3, 4, 5 }, new PresetItemTemplateId("Medicine", 298), new sbyte[6] { 0, 1, 2, 3, 4, 5 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 187, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_78"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(79, LocalStringManager.GetConfig("MapPickups_language", "Name_79"), EMapPickupsType.Item, EMapPickupsType2.Medicine, "map_eventicon_8", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_79"), 0, new byte[15]
		{
			0, 1, 0, 0, 0, 0, 0, 0, 0, 1,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			51, 52, 53, 1, 2, 3, 4, 5, 6, 7,
			8, 9, 10, 11, 12, 13, 14, 15, 34, 35,
			36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[5] { 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Medicine", 304), new sbyte[5] { 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 187, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_79"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(80, LocalStringManager.GetConfig("MapPickups_language", "Name_80"), EMapPickupsType.Item, EMapPickupsType2.Medicine, "map_eventicon_8", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_80"), 0, new byte[15]
		{
			0, 1, 0, 1, 0, 0, 1, 1, 0, 0,
			0, 0, 0, 0, 1
		}, new List<short>
		{
			51, 52, 53, 1, 2, 3, 4, 5, 6, 7,
			8, 9, 10, 11, 12, 13, 14, 15, 34, 35,
			36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[6] { 0, 1, 2, 3, 4, 5 }, new PresetItemTemplateId("Medicine", 322), new sbyte[6] { 0, 1, 2, 3, 4, 5 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 187, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_80"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(81, LocalStringManager.GetConfig("MapPickups_language", "Name_81"), EMapPickupsType.Item, EMapPickupsType2.Medicine, "map_eventicon_8", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_81"), 0, new byte[15]
		{
			0, 0, 1, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 1, 0, 0
		}, new List<short>
		{
			51, 52, 53, 1, 2, 3, 4, 5, 6, 7,
			8, 9, 10, 11, 12, 13, 14, 15, 34, 35,
			36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[5] { 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Medicine", 328), new sbyte[5] { 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 187, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_81"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(82, LocalStringManager.GetConfig("MapPickups_language", "Name_82"), EMapPickupsType.Item, EMapPickupsType2.Medicine, "map_eventicon_8", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_82"), 0, new byte[15]
		{
			1, 0, 0, 0, 1, 1, 0, 0, 0, 0,
			0, 1, 1, 0, 0
		}, new List<short>
		{
			51, 52, 53, 1, 2, 3, 4, 5, 6, 7,
			8, 9, 10, 11, 12, 13, 14, 15, 34, 35,
			36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[6] { 0, 1, 2, 3, 4, 5 }, new PresetItemTemplateId("Medicine", 334), new sbyte[6] { 0, 1, 2, 3, 4, 5 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 187, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_82"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(83, LocalStringManager.GetConfig("MapPickups_language", "Name_83"), EMapPickupsType.Item, EMapPickupsType2.Medicine, "map_eventicon_8", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_83"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			1, 0, 0, 1, 0
		}, new List<short>
		{
			51, 52, 53, 1, 2, 3, 4, 5, 6, 7,
			8, 9, 10, 11, 12, 13, 14, 15, 34, 35,
			36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[5] { 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Medicine", 340), new sbyte[5] { 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 187, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_83"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(84, LocalStringManager.GetConfig("MapPickups_language", "Name_84"), EMapPickupsType.Item, EMapPickupsType2.Medicine, "map_eventicon_8", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_84"), 0, new byte[15]
		{
			0, 0, 1, 1, 0, 0, 1, 1, 0, 0,
			0, 0, 0, 0, 1
		}, new List<short>
		{
			51, 52, 53, 1, 2, 3, 4, 5, 6, 7,
			8, 9, 10, 11, 12, 13, 14, 15, 34, 35,
			36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[6] { 0, 1, 2, 3, 4, 5 }, new PresetItemTemplateId("Medicine", 118), new sbyte[6] { 0, 1, 2, 3, 4, 5 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 187, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_84"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(85, LocalStringManager.GetConfig("MapPickups_language", "Name_85"), EMapPickupsType.Item, EMapPickupsType2.Medicine, "map_eventicon_8", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_85"), 0, new byte[15]
		{
			0, 1, 0, 0, 0, 0, 1, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			51, 52, 53, 1, 2, 3, 4, 5, 6, 7,
			8, 9, 10, 11, 12, 13, 14, 15, 34, 35,
			36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[5] { 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Medicine", 124), new sbyte[5] { 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 187, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_85"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(86, LocalStringManager.GetConfig("MapPickups_language", "Name_86"), EMapPickupsType.Item, EMapPickupsType2.Medicine, "map_eventicon_8", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_86"), 0, new byte[15]
		{
			0, 0, 0, 0, 1, 0, 0, 0, 1, 1,
			0, 1, 0, 0, 1
		}, new List<short>
		{
			51, 52, 53, 1, 2, 3, 4, 5, 6, 7,
			8, 9, 10, 11, 12, 13, 14, 15, 34, 35,
			36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[6] { 0, 1, 2, 3, 4, 5 }, new PresetItemTemplateId("Medicine", 226), new sbyte[6] { 0, 1, 2, 3, 4, 5 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 187, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_86"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(87, LocalStringManager.GetConfig("MapPickups_language", "Name_87"), EMapPickupsType.Item, EMapPickupsType2.Medicine, "map_eventicon_8", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_87"), 0, new byte[15]
		{
			1, 0, 0, 1, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			51, 52, 53, 1, 2, 3, 4, 5, 6, 7,
			8, 9, 10, 11, 12, 13, 14, 15, 34, 35,
			36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[5] { 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Medicine", 232), new sbyte[5] { 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 187, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_87"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(88, LocalStringManager.GetConfig("MapPickups_language", "Name_88"), EMapPickupsType.Item, EMapPickupsType2.Medicine, "map_eventicon_8", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_88"), 0, new byte[15]
		{
			0, 1, 0, 1, 0, 0, 0, 1, 0, 1,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			51, 52, 53, 1, 2, 3, 4, 5, 6, 7,
			8, 9, 10, 11, 12, 13, 14, 15, 34, 35,
			36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[6] { 0, 1, 2, 3, 4, 5 }, new PresetItemTemplateId("Medicine", 238), new sbyte[6] { 0, 1, 2, 3, 4, 5 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 187, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_88"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(89, LocalStringManager.GetConfig("MapPickups_language", "Name_89"), EMapPickupsType.Item, EMapPickupsType2.Medicine, "map_eventicon_8", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_89"), 0, new byte[15]
		{
			0, 0, 0, 0, 1, 0, 0, 0, 0, 0,
			0, 0, 0, 1, 0
		}, new List<short>
		{
			51, 52, 53, 1, 2, 3, 4, 5, 6, 7,
			8, 9, 10, 11, 12, 13, 14, 15, 34, 35,
			36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[5] { 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Medicine", 244), new sbyte[5] { 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 187, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_89"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(90, LocalStringManager.GetConfig("MapPickups_language", "Name_90"), EMapPickupsType.Item, EMapPickupsType2.Medicine, "map_eventicon_8", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_90"), 0, new byte[15]
		{
			0, 1, 0, 1, 0, 0, 1, 0, 1, 0,
			0, 0, 1, 0, 0
		}, new List<short>
		{
			51, 52, 53, 1, 2, 3, 4, 5, 6, 7,
			8, 9, 10, 11, 12, 13, 14, 15, 34, 35,
			36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[6] { 0, 1, 2, 3, 4, 5 }, new PresetItemTemplateId("Medicine", 250), new sbyte[6] { 0, 1, 2, 3, 4, 5 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 187, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_90"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(91, LocalStringManager.GetConfig("MapPickups_language", "Name_91"), EMapPickupsType.Item, EMapPickupsType2.Medicine, "map_eventicon_8", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_91"), 0, new byte[15]
		{
			0, 0, 1, 0, 0, 0, 0, 1, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			51, 52, 53, 1, 2, 3, 4, 5, 6, 7,
			8, 9, 10, 11, 12, 13, 14, 15, 34, 35,
			36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[5] { 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Medicine", 256), new sbyte[5] { 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 187, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_91"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(92, LocalStringManager.GetConfig("MapPickups_language", "Name_92"), EMapPickupsType.Item, EMapPickupsType2.Medicine, "map_eventicon_8", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_92"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 1, 1,
			1, 1, 0, 1, 0
		}, new List<short>
		{
			51, 52, 53, 1, 2, 3, 4, 5, 6, 7,
			8, 9, 10, 11, 12, 13, 14, 15, 34, 35,
			36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[6] { 0, 1, 2, 3, 4, 5 }, new PresetItemTemplateId("Medicine", 202), new sbyte[6] { 0, 1, 2, 3, 4, 5 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 187, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_92"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(93, LocalStringManager.GetConfig("MapPickups_language", "Name_93"), EMapPickupsType.Item, EMapPickupsType2.Medicine, "map_eventicon_8", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_93"), 0, new byte[15]
		{
			1, 0, 0, 0, 0, 1, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			51, 52, 53, 1, 2, 3, 4, 5, 6, 7,
			8, 9, 10, 11, 12, 13, 14, 15, 34, 35,
			36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[5] { 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Medicine", 208), new sbyte[5] { 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 187, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_93"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(94, LocalStringManager.GetConfig("MapPickups_language", "Name_94"), EMapPickupsType.Item, EMapPickupsType2.Medicine, "map_eventicon_8", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_94"), 0, new byte[15]
		{
			0, 0, 1, 0, 1, 1, 1, 0, 0, 0,
			0, 0, 0, 0, 1
		}, new List<short>
		{
			51, 52, 53, 1, 2, 3, 4, 5, 6, 7,
			8, 9, 10, 11, 12, 13, 14, 15, 34, 35,
			36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[6] { 0, 1, 2, 3, 4, 5 }, new PresetItemTemplateId("Medicine", 214), new sbyte[6] { 0, 1, 2, 3, 4, 5 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 187, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_94"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(95, LocalStringManager.GetConfig("MapPickups_language", "Name_95"), EMapPickupsType.Item, EMapPickupsType2.Medicine, "map_eventicon_8", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_95"), 0, new byte[15]
		{
			0, 0, 0, 1, 0, 0, 0, 1, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			51, 52, 53, 1, 2, 3, 4, 5, 6, 7,
			8, 9, 10, 11, 12, 13, 14, 15, 34, 35,
			36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[5] { 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Medicine", 220), new sbyte[5] { 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 187, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_95"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(96, LocalStringManager.GetConfig("MapPickups_language", "Name_96"), EMapPickupsType.Item, EMapPickupsType2.Medicine, "map_eventicon_8", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_96"), 0, new byte[15]
		{
			1, 1, 0, 0, 1, 1, 0, 0, 0, 0,
			0, 0, 0, 1, 0
		}, new List<short>
		{
			51, 52, 53, 1, 2, 3, 4, 5, 6, 7,
			8, 9, 10, 11, 12, 13, 14, 15, 34, 35,
			36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[6] { 0, 1, 2, 3, 4, 5 }, new PresetItemTemplateId("Medicine", 106), new sbyte[6] { 0, 1, 2, 3, 4, 5 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 187, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_96"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(97, LocalStringManager.GetConfig("MapPickups_language", "Name_97"), EMapPickupsType.Item, EMapPickupsType2.Medicine, "map_eventicon_8", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_97"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 1, 0, 0, 0,
			0, 0, 0, 0, 1
		}, new List<short>
		{
			51, 52, 53, 1, 2, 3, 4, 5, 6, 7,
			8, 9, 10, 11, 12, 13, 14, 15, 34, 35,
			36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[5] { 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Medicine", 112), new sbyte[5] { 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 187, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_97"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(98, LocalStringManager.GetConfig("MapPickups_language", "Name_98"), EMapPickupsType.Item, EMapPickupsType2.Medicine, "map_eventicon_8", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_98"), 0, new byte[15]
		{
			0, 0, 1, 1, 0, 0, 1, 0, 1, 0,
			0, 0, 0, 1, 0
		}, new List<short>
		{
			51, 52, 53, 1, 2, 3, 4, 5, 6, 7,
			8, 9, 10, 11, 12, 13, 14, 15, 34, 35,
			36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[6] { 0, 1, 2, 3, 4, 5 }, new PresetItemTemplateId("Medicine", 310), new sbyte[6] { 0, 1, 2, 3, 4, 5 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 187, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_98"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(99, LocalStringManager.GetConfig("MapPickups_language", "Name_99"), EMapPickupsType.Item, EMapPickupsType2.Medicine, "map_eventicon_8", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_99"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 1, 0, 0,
			0, 0, 1, 0, 0
		}, new List<short>
		{
			51, 52, 53, 1, 2, 3, 4, 5, 6, 7,
			8, 9, 10, 11, 12, 13, 14, 15, 34, 35,
			36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[5] { 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Medicine", 316), new sbyte[5] { 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 187, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_99"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(100, LocalStringManager.GetConfig("MapPickups_language", "Name_100"), EMapPickupsType.Item, EMapPickupsType2.Medicine, "map_eventicon_8", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_100"), 0, new byte[15]
		{
			0, 1, 0, 0, 1, 0, 0, 1, 0, 1,
			0, 0, 0, 0, 1
		}, new List<short>
		{
			51, 52, 53, 1, 2, 3, 4, 5, 6, 7,
			8, 9, 10, 11, 12, 13, 14, 15, 34, 35,
			36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[6] { 0, 1, 2, 3, 4, 5 }, new PresetItemTemplateId("Medicine", 262), new sbyte[6] { 0, 1, 2, 3, 4, 5 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 187, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_100"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(101, LocalStringManager.GetConfig("MapPickups_language", "Name_101"), EMapPickupsType.Item, EMapPickupsType2.Medicine, "map_eventicon_8", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_101"), 0, new byte[15]
		{
			0, 0, 0, 1, 0, 0, 0, 0, 1, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			51, 52, 53, 1, 2, 3, 4, 5, 6, 7,
			8, 9, 10, 11, 12, 13, 14, 15, 34, 35,
			36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[5] { 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Medicine", 268), new sbyte[5] { 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 187, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_101"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(102, LocalStringManager.GetConfig("MapPickups_language", "Name_102"), EMapPickupsType.Item, EMapPickupsType2.Medicine, "map_eventicon_8", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_102"), 0, new byte[15]
		{
			0, 0, 0, 1, 0, 0, 0, 1, 0, 1,
			0, 1, 0, 0, 1
		}, new List<short>
		{
			51, 52, 53, 1, 2, 3, 4, 5, 6, 7,
			8, 9, 10, 11, 12, 13, 14, 15, 34, 35,
			36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[6] { 0, 1, 2, 3, 4, 5 }, new PresetItemTemplateId("Medicine", 286), new sbyte[6] { 0, 1, 2, 3, 4, 5 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 187, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_102"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(103, LocalStringManager.GetConfig("MapPickups_language", "Name_103"), EMapPickupsType.Item, EMapPickupsType2.Medicine, "map_eventicon_8", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_103"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 1, 0, 0, 0,
			0, 0, 1, 0, 0
		}, new List<short>
		{
			51, 52, 53, 1, 2, 3, 4, 5, 6, 7,
			8, 9, 10, 11, 12, 13, 14, 15, 34, 35,
			36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[5] { 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Medicine", 292), new sbyte[5] { 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 187, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_103"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(104, LocalStringManager.GetConfig("MapPickups_language", "Name_104"), EMapPickupsType.Item, EMapPickupsType2.Food, "map_eventicon_9", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_104"), 2, new byte[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Food", 0), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			false, true, true, true, true, true, true, true, true, true,
			false, false
		}, -1, new OrganizationApproving(), 188, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_104"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(105, LocalStringManager.GetConfig("MapPickups_language", "Name_105"), EMapPickupsType.Item, EMapPickupsType2.Food, "map_eventicon_9", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_105"), 1, new byte[15]
		{
			0, 0, 1, 1, 0, 0, 1, 0, 1, 0,
			0, 0, 1, 0, 0
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Food", 9), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, false, false, false, true, true, true, false, false, false,
			true, true
		}, -1, new OrganizationApproving(), 189, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_105"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(106, LocalStringManager.GetConfig("MapPickups_language", "Name_106"), EMapPickupsType.Item, EMapPickupsType2.Food, "map_eventicon_9", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_106"), 0, new byte[15]
		{
			0, 1, 0, 0, 1, 1, 0, 0, 0, 1,
			0, 0, 0, 0, 1
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[7] { 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Food", 18), new sbyte[7] { 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, false, false, false, true, true, true, false, false, false,
			true, true
		}, -1, new OrganizationApproving(), 189, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_106"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(107, LocalStringManager.GetConfig("MapPickups_language", "Name_107"), EMapPickupsType.Item, EMapPickupsType2.Food, "map_eventicon_9", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_107"), 0, new byte[15]
		{
			1, 0, 0, 1, 0, 0, 0, 0, 1, 0,
			0, 1, 0, 0, 1
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[6] { 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Food", 26), new sbyte[6] { 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, false, false, false, true, true, true, false, false, false,
			true, true
		}, -1, new OrganizationApproving(), 189, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_107"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(108, LocalStringManager.GetConfig("MapPickups_language", "Name_108"), EMapPickupsType.Item, EMapPickupsType2.Food, "map_eventicon_9", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_108"), 0, new byte[15]
		{
			0, 0, 1, 0, 1, 0, 1, 1, 0, 0,
			0, 0, 1, 0, 0
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[5] { 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Food", 33), new sbyte[5] { 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, false, false, false, true, true, true, false, false, false,
			true, true
		}, -1, new OrganizationApproving(), 189, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_108"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(109, LocalStringManager.GetConfig("MapPickups_language", "Name_109"), EMapPickupsType.Item, EMapPickupsType2.Food, "map_eventicon_9", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_109"), 0, new byte[15]
		{
			1, 1, 0, 0, 0, 0, 0, 0, 1, 0,
			1, 0, 0, 1, 0
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[4] { 4, 5, 6, 7 }, new PresetItemTemplateId("Food", 39), new sbyte[4] { 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, false, false, false, true, true, true, false, false, false,
			true, true
		}, -1, new OrganizationApproving(), 189, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_109"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(110, LocalStringManager.GetConfig("MapPickups_language", "Name_110"), EMapPickupsType.Item, EMapPickupsType2.Food, "map_eventicon_9", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_110"), 0, new byte[15]
		{
			0, 0, 0, 1, 0, 1, 0, 0, 0, 1,
			0, 1, 0, 1, 0
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[3] { 5, 6, 7 }, new PresetItemTemplateId("Food", 44), new sbyte[3] { 5, 6, 7 }, new short[6], new bool[12]
		{
			true, false, false, false, true, true, true, false, false, false,
			true, true
		}, -1, new OrganizationApproving(), 189, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_110"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(111, LocalStringManager.GetConfig("MapPickups_language", "Name_111"), EMapPickupsType.Item, EMapPickupsType2.Food, "map_eventicon_9", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_111"), 0, new byte[15]
		{
			1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			1, 1, 0, 0, 1
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[2] { 6, 7 }, new PresetItemTemplateId("Food", 48), new sbyte[2] { 6, 7 }, new short[6], new bool[12]
		{
			true, false, false, false, true, true, true, false, false, false,
			true, true
		}, -1, new OrganizationApproving(), 189, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_111"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(112, LocalStringManager.GetConfig("MapPickups_language", "Name_112"), EMapPickupsType.Item, EMapPickupsType2.Food, "map_eventicon_9", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_112"), 1, new byte[15]
		{
			0, 1, 0, 0, 0, 0, 1, 1, 0, 0,
			1, 0, 1, 0, 0
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Food", 51), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, false, false, false, false, false, false, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 190, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_112"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(113, LocalStringManager.GetConfig("MapPickups_language", "Name_113"), EMapPickupsType.Item, EMapPickupsType2.Food, "map_eventicon_9", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_113"), 0, new byte[15]
		{
			0, 1, 0, 1, 0, 0, 0, 1, 0, 1,
			0, 0, 1, 0, 0
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[7] { 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Food", 60), new sbyte[7] { 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, false, false, false, false, false, false, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 190, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_113"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(114, LocalStringManager.GetConfig("MapPickups_language", "Name_114"), EMapPickupsType.Item, EMapPickupsType2.Food, "map_eventicon_9", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_114"), 0, new byte[15]
		{
			1, 0, 1, 0, 0, 0, 0, 0, 1, 0,
			1, 0, 0, 0, 1
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[6] { 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Food", 68), new sbyte[6] { 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, false, false, false, false, false, false, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 190, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_114"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(115, LocalStringManager.GetConfig("MapPickups_language", "Name_115"), EMapPickupsType.Item, EMapPickupsType2.Food, "map_eventicon_9", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_115"), 0, new byte[15]
		{
			0, 0, 0, 0, 1, 1, 0, 0, 0, 1,
			0, 1, 1, 0, 0
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[5] { 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Food", 75), new sbyte[5] { 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, false, false, false, false, false, false, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 190, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_115"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(116, LocalStringManager.GetConfig("MapPickups_language", "Name_116"), EMapPickupsType.Item, EMapPickupsType2.Food, "map_eventicon_9", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_116"), 0, new byte[15]
		{
			0, 0, 1, 1, 0, 0, 0, 1, 0, 1,
			0, 0, 0, 1, 0
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[4] { 4, 5, 6, 7 }, new PresetItemTemplateId("Food", 81), new sbyte[4] { 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, false, false, false, false, false, false, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 190, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_116"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(117, LocalStringManager.GetConfig("MapPickups_language", "Name_117"), EMapPickupsType.Item, EMapPickupsType2.Food, "map_eventicon_9", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_117"), 0, new byte[15]
		{
			1, 0, 1, 0, 0, 1, 0, 0, 0, 0,
			1, 0, 0, 0, 1
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[3] { 5, 6, 7 }, new PresetItemTemplateId("Food", 86), new sbyte[3] { 5, 6, 7 }, new short[6], new bool[12]
		{
			true, false, false, false, false, false, false, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 190, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_117"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(118, LocalStringManager.GetConfig("MapPickups_language", "Name_118"), EMapPickupsType.Item, EMapPickupsType2.Food, "map_eventicon_9", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_118"), 0, new byte[15]
		{
			1, 1, 0, 1, 0, 0, 0, 0, 1, 0,
			0, 0, 1, 0, 0
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[2] { 6, 7 }, new PresetItemTemplateId("Food", 90), new sbyte[2] { 6, 7 }, new short[6], new bool[12]
		{
			true, false, false, false, false, false, false, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 190, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_118"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(119, LocalStringManager.GetConfig("MapPickups_language", "Name_119"), EMapPickupsType.Item, EMapPickupsType2.Food, "map_eventicon_9", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_119"), 1, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 1, 1, 0, 0,
			1, 1, 0, 0, 1
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Food", 93), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			false, true, true, true, false, false, false, true, true, true,
			false, false
		}, -1, new OrganizationApproving(), 191, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_119"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
	}

	private void CreateItems2()
	{
		_dataArray.Add(new MapPickupsItem(120, LocalStringManager.GetConfig("MapPickups_language", "Name_120"), EMapPickupsType.Item, EMapPickupsType2.Food, "map_eventicon_9", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_120"), 0, new byte[15]
		{
			1, 0, 0, 0, 1, 1, 0, 0, 0, 0,
			0, 1, 1, 0, 0
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[7] { 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Food", 102), new sbyte[7] { 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			false, true, true, true, false, false, false, true, true, true,
			false, false
		}, -1, new OrganizationApproving(), 191, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_120"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(121, LocalStringManager.GetConfig("MapPickups_language", "Name_121"), EMapPickupsType.Item, EMapPickupsType2.Food, "map_eventicon_9", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_121"), 0, new byte[15]
		{
			0, 0, 0, 1, 0, 0, 0, 1, 0, 1,
			0, 1, 0, 1, 0
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[6] { 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Food", 110), new sbyte[6] { 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			false, true, true, true, false, false, false, true, true, true,
			false, false
		}, -1, new OrganizationApproving(), 191, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_121"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(122, LocalStringManager.GetConfig("MapPickups_language", "Name_122"), EMapPickupsType.Item, EMapPickupsType2.Food, "map_eventicon_9", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_122"), 0, new byte[15]
		{
			0, 1, 0, 1, 0, 0, 0, 1, 0, 1,
			0, 0, 0, 0, 1
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[5] { 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Food", 117), new sbyte[5] { 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			false, true, true, true, false, false, false, true, true, true,
			false, false
		}, -1, new OrganizationApproving(), 191, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_122"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(123, LocalStringManager.GetConfig("MapPickups_language", "Name_123"), EMapPickupsType.Item, EMapPickupsType2.Food, "map_eventicon_9", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_123"), 0, new byte[15]
		{
			0, 0, 1, 0, 0, 1, 1, 0, 0, 0,
			1, 0, 0, 1, 0
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[4] { 4, 5, 6, 7 }, new PresetItemTemplateId("Food", 123), new sbyte[4] { 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			false, true, true, true, false, false, false, true, true, true,
			false, false
		}, -1, new OrganizationApproving(), 191, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_123"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(124, LocalStringManager.GetConfig("MapPickups_language", "Name_124"), EMapPickupsType.Item, EMapPickupsType2.Food, "map_eventicon_9", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_124"), 0, new byte[15]
		{
			1, 0, 1, 1, 0, 0, 0, 1, 0, 0,
			0, 0, 0, 1, 0
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[3] { 5, 6, 7 }, new PresetItemTemplateId("Food", 128), new sbyte[3] { 5, 6, 7 }, new short[6], new bool[12]
		{
			false, true, true, true, false, false, false, true, true, true,
			false, false
		}, -1, new OrganizationApproving(), 191, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_124"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(125, LocalStringManager.GetConfig("MapPickups_language", "Name_125"), EMapPickupsType.Item, EMapPickupsType2.Food, "map_eventicon_9", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_125"), 0, new byte[15]
		{
			0, 0, 0, 0, 1, 0, 1, 0, 1, 0,
			0, 1, 1, 0, 0
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[2] { 6, 7 }, new PresetItemTemplateId("Food", 132), new sbyte[2] { 6, 7 }, new short[6], new bool[12]
		{
			false, true, true, true, false, false, false, true, true, true,
			false, false
		}, -1, new OrganizationApproving(), 191, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_125"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(126, LocalStringManager.GetConfig("MapPickups_language", "Name_126"), EMapPickupsType.Item, EMapPickupsType2.Food, "map_eventicon_9", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_126"), 1, new byte[15]
		{
			0, 1, 0, 0, 0, 0, 1, 0, 1, 0,
			1, 0, 0, 0, 1
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Food", 135), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			false, true, true, true, true, true, true, false, false, false,
			false, false
		}, -1, new OrganizationApproving(), 192, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_126"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(127, LocalStringManager.GetConfig("MapPickups_language", "Name_127"), EMapPickupsType.Item, EMapPickupsType2.Food, "map_eventicon_9", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_127"), 0, new byte[15]
		{
			0, 0, 0, 1, 0, 1, 0, 0, 0, 1,
			0, 1, 0, 1, 0
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[7] { 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Food", 144), new sbyte[7] { 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			false, true, true, true, true, true, true, false, false, false,
			false, false
		}, -1, new OrganizationApproving(), 192, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_127"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(128, LocalStringManager.GetConfig("MapPickups_language", "Name_128"), EMapPickupsType.Item, EMapPickupsType2.Food, "map_eventicon_9", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_128"), 0, new byte[15]
		{
			1, 0, 1, 0, 1, 0, 0, 1, 0, 0,
			0, 0, 1, 0, 0
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[6] { 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Food", 152), new sbyte[6] { 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			false, true, true, true, true, true, true, false, false, false,
			false, false
		}, -1, new OrganizationApproving(), 192, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_128"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(129, LocalStringManager.GetConfig("MapPickups_language", "Name_129"), EMapPickupsType.Item, EMapPickupsType2.Food, "map_eventicon_9", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_129"), 0, new byte[15]
		{
			0, 0, 1, 0, 0, 0, 1, 0, 1, 0,
			0, 0, 0, 0, 1
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[5] { 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Food", 159), new sbyte[5] { 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			false, true, true, true, true, true, true, false, false, false,
			false, false
		}, -1, new OrganizationApproving(), 192, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_129"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(130, LocalStringManager.GetConfig("MapPickups_language", "Name_130"), EMapPickupsType.Item, EMapPickupsType2.Food, "map_eventicon_9", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_130"), 0, new byte[15]
		{
			1, 0, 0, 1, 0, 1, 0, 0, 0, 0,
			0, 1, 0, 1, 0
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[4] { 4, 5, 6, 7 }, new PresetItemTemplateId("Food", 165), new sbyte[4] { 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			false, true, true, true, true, true, true, false, false, false,
			false, false
		}, -1, new OrganizationApproving(), 192, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_130"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(131, LocalStringManager.GetConfig("MapPickups_language", "Name_131"), EMapPickupsType.Item, EMapPickupsType2.Food, "map_eventicon_9", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_131"), 0, new byte[15]
		{
			0, 0, 1, 1, 0, 0, 1, 1, 0, 0,
			0, 0, 1, 0, 0
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[3] { 5, 6, 7 }, new PresetItemTemplateId("Food", 170), new sbyte[3] { 5, 6, 7 }, new short[6], new bool[12]
		{
			false, true, true, true, true, true, true, false, false, false,
			false, false
		}, -1, new OrganizationApproving(), 192, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_131"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(132, LocalStringManager.GetConfig("MapPickups_language", "Name_132"), EMapPickupsType.Item, EMapPickupsType2.Food, "map_eventicon_9", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_132"), 0, new byte[15]
		{
			0, 1, 0, 0, 0, 1, 0, 0, 0, 1,
			1, 0, 0, 1, 0
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[2] { 6, 7 }, new PresetItemTemplateId("Food", 174), new sbyte[2] { 6, 7 }, new short[6], new bool[12]
		{
			false, true, true, true, true, true, true, false, false, false,
			false, false
		}, -1, new OrganizationApproving(), 192, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_132"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(133, LocalStringManager.GetConfig("MapPickups_language", "Name_133"), EMapPickupsType.Item, EMapPickupsType2.TeaWine, "map_eventicon_10", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_133"), 1, new byte[15]
		{
			0, 1, 0, 0, 1, 1, 0, 0, 0, 1,
			0, 0, 0, 1, 0
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("TeaWine", 0), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, false, false, false, true, true, true, false, false, false,
			true, true
		}, -1, new OrganizationApproving(), 193, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_133"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(134, LocalStringManager.GetConfig("MapPickups_language", "Name_134"), EMapPickupsType.Item, EMapPickupsType2.TeaWine, "map_eventicon_10", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_134"), 1, new byte[15]
		{
			0, 0, 1, 0, 0, 1, 1, 0, 0, 0,
			1, 0, 1, 0, 0
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("TeaWine", 9), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, false, false, false, true, true, true, false, false, false,
			true, true
		}, -1, new OrganizationApproving(), 193, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_134"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(135, LocalStringManager.GetConfig("MapPickups_language", "Name_135"), EMapPickupsType.Item, EMapPickupsType2.TeaWine, "map_eventicon_10", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_135"), 1, new byte[15]
		{
			1, 0, 0, 1, 0, 0, 0, 0, 1, 0,
			0, 1, 0, 0, 1
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("TeaWine", 18), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			false, true, true, true, false, false, false, true, true, true,
			false, false
		}, -1, new OrganizationApproving(), 194, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_135"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(136, LocalStringManager.GetConfig("MapPickups_language", "Name_136"), EMapPickupsType.Item, EMapPickupsType2.TeaWine, "map_eventicon_10", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_136"), 1, new byte[15]
		{
			1, 0, 0, 1, 0, 0, 0, 1, 0, 0,
			0, 1, 1, 0, 0
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("TeaWine", 27), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			false, true, true, true, false, false, false, true, true, true,
			false, false
		}, -1, new OrganizationApproving(), 194, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_136"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(137, LocalStringManager.GetConfig("MapPickups_language", "Name_137"), EMapPickupsType.Item, EMapPickupsType2.Tool, "map_eventicon_11", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_137"), 0, new byte[15]
		{
			0, 1, 0, 0, 1, 1, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
			11, 12, 13, 14, 15, 34, 35, 36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[7] { 0, 1, 2, 3, 4, 5, 6 }, new PresetItemTemplateId("CraftTool", 36), new sbyte[7] { 0, 1, 2, 3, 4, 5, 6 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 195, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_137"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(138, LocalStringManager.GetConfig("MapPickups_language", "Name_138"), EMapPickupsType.Item, EMapPickupsType2.Tool, "map_eventicon_11", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_138"), 0, new byte[15]
		{
			0, 0, 0, 1, 0, 1, 0, 0, 1, 0,
			0, 1, 0, 0, 0
		}, new List<short>
		{
			1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
			11, 12, 13, 14, 15, 34, 35, 36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[7] { 0, 1, 2, 3, 4, 5, 6 }, new PresetItemTemplateId("CraftTool", 0), new sbyte[7] { 0, 1, 2, 3, 4, 5, 6 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 195, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_138"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(139, LocalStringManager.GetConfig("MapPickups_language", "Name_139"), EMapPickupsType.Item, EMapPickupsType2.Tool, "map_eventicon_11", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_139"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 1, 0, 0, 1, 0,
			0, 0, 0, 1, 0
		}, new List<short>
		{
			1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
			11, 12, 13, 14, 15, 34, 35, 36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[7] { 0, 1, 2, 3, 4, 5, 6 }, new PresetItemTemplateId("CraftTool", 9), new sbyte[7] { 0, 1, 2, 3, 4, 5, 6 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 195, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_139"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(140, LocalStringManager.GetConfig("MapPickups_language", "Name_140"), EMapPickupsType.Item, EMapPickupsType2.Tool, "map_eventicon_11", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_140"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 1, 0, 1, 1,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
			11, 12, 13, 14, 15, 34, 35, 36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[7] { 0, 1, 2, 3, 4, 5, 6 }, new PresetItemTemplateId("CraftTool", 18), new sbyte[7] { 0, 1, 2, 3, 4, 5, 6 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 195, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_140"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(141, LocalStringManager.GetConfig("MapPickups_language", "Name_141"), EMapPickupsType.Item, EMapPickupsType2.Tool, "map_eventicon_11", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_141"), 0, new byte[15]
		{
			0, 0, 1, 0, 0, 0, 0, 0, 1, 1,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
			11, 12, 13, 14, 15, 34, 35, 36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[7] { 0, 1, 2, 3, 4, 5, 6 }, new PresetItemTemplateId("CraftTool", 27), new sbyte[7] { 0, 1, 2, 3, 4, 5, 6 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 195, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_141"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(142, LocalStringManager.GetConfig("MapPickups_language", "Name_142"), EMapPickupsType.Item, EMapPickupsType2.Tool, "map_eventicon_11", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_142"), 0, new byte[15]
		{
			1, 0, 1, 0, 1, 0, 0, 0, 0, 1,
			0, 1, 1, 0, 1
		}, new List<short>
		{
			1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
			11, 12, 13, 14, 15, 34, 35, 36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[7] { 0, 1, 2, 3, 4, 5, 6 }, new PresetItemTemplateId("CraftTool", 45), new sbyte[7] { 0, 1, 2, 3, 4, 5, 6 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 195, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_142"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(143, LocalStringManager.GetConfig("MapPickups_language", "Name_143"), EMapPickupsType.Item, EMapPickupsType2.Accessory, "map_eventicon_12", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_143"), 0, new byte[15]
		{
			1, 0, 0, 0, 1, 1, 0, 0, 1, 0,
			1, 0, 0, 1, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Accessory", 90), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 196, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_143"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(144, LocalStringManager.GetConfig("MapPickups_language", "Name_144"), EMapPickupsType.Item, EMapPickupsType2.Accessory, "map_eventicon_12", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_144"), 0, new byte[15]
		{
			1, 0, 0, 0, 1, 1, 0, 0, 1, 0,
			1, 0, 0, 1, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Accessory", 0), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 196, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_144"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(145, LocalStringManager.GetConfig("MapPickups_language", "Name_145"), EMapPickupsType.Item, EMapPickupsType2.Accessory, "map_eventicon_12", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_145"), 0, new byte[15]
		{
			0, 1, 1, 1, 0, 0, 1, 1, 0, 1,
			0, 1, 1, 0, 1
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Accessory", 207), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 196, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_145"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(146, LocalStringManager.GetConfig("MapPickups_language", "Name_146"), EMapPickupsType.Item, EMapPickupsType2.Accessory, "map_eventicon_12", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_146"), 0, new byte[15]
		{
			1, 0, 0, 0, 1, 1, 0, 0, 1, 0,
			1, 0, 0, 1, 1
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Accessory", 99), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 196, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_146"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(147, LocalStringManager.GetConfig("MapPickups_language", "Name_147"), EMapPickupsType.Item, EMapPickupsType2.Accessory, "map_eventicon_12", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_147"), 0, new byte[15]
		{
			0, 1, 1, 1, 1, 0, 0, 1, 1, 0,
			0, 1, 1, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Accessory", 117), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 196, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_147"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(148, LocalStringManager.GetConfig("MapPickups_language", "Name_148"), EMapPickupsType.Item, EMapPickupsType2.Accessory, "map_eventicon_12", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_148"), 0, new byte[15]
		{
			1, 1, 1, 1, 1, 0, 1, 0, 0, 0,
			1, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Accessory", 180), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 196, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_148"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(149, LocalStringManager.GetConfig("MapPickups_language", "Name_149"), EMapPickupsType.Item, EMapPickupsType2.Accessory, "map_eventicon_12", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_149"), 0, new byte[15]
		{
			1, 0, 0, 0, 0, 1, 0, 0, 1, 1,
			1, 0, 0, 1, 1
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Accessory", 108), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 196, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_149"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(150, LocalStringManager.GetConfig("MapPickups_language", "Name_150"), EMapPickupsType.Item, EMapPickupsType2.Accessory, "map_eventicon_12", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_150"), 0, new byte[15]
		{
			0, 0, 0, 1, 0, 0, 1, 1, 0, 1,
			0, 1, 1, 1, 1
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Accessory", 171), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 196, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_150"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(151, LocalStringManager.GetConfig("MapPickups_language", "Name_151"), EMapPickupsType.Item, EMapPickupsType2.Accessory, "map_eventicon_12", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_151"), 0, new byte[15]
		{
			0, 1, 1, 0, 0, 0, 1, 1, 0, 1,
			0, 1, 1, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Accessory", 162), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 196, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_151"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(152, LocalStringManager.GetConfig("MapPickups_language", "Name_152"), EMapPickupsType.Item, EMapPickupsType2.Accessory, "map_eventicon_12", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_152"), 0, new byte[15]
		{
			1, 0, 0, 0, 1, 1, 0, 0, 1, 0,
			1, 0, 0, 1, 1
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Accessory", 153), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 196, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_152"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(153, LocalStringManager.GetConfig("MapPickups_language", "Name_153"), EMapPickupsType.Item, EMapPickupsType2.Accessory, "map_eventicon_12", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_153"), 0, new byte[15]
		{
			0, 1, 1, 1, 0, 0, 1, 1, 1, 1,
			0, 0, 0, 0, 1
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Accessory", 144), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 196, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_153"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(154, LocalStringManager.GetConfig("MapPickups_language", "Name_154"), EMapPickupsType.Item, EMapPickupsType2.Accessory, "map_eventicon_12", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_154"), 0, new byte[15]
		{
			0, 1, 0, 0, 1, 1, 0, 1, 1, 0,
			0, 0, 1, 0, 1
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Accessory", 135), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 196, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_154"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(155, LocalStringManager.GetConfig("MapPickups_language", "Name_155"), EMapPickupsType.Item, EMapPickupsType2.Accessory, "map_eventicon_12", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_155"), 0, new byte[15]
		{
			1, 0, 0, 0, 1, 1, 0, 0, 1, 0,
			1, 1, 1, 1, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Accessory", 72), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 196, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_155"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(156, LocalStringManager.GetConfig("MapPickups_language", "Name_156"), EMapPickupsType.Item, EMapPickupsType2.Accessory, "map_eventicon_12", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_156"), 0, new byte[15]
		{
			0, 1, 1, 1, 0, 0, 1, 1, 0, 1,
			0, 1, 0, 0, 1
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Accessory", 81), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 196, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_156"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(157, LocalStringManager.GetConfig("MapPickups_language", "Name_157"), EMapPickupsType.Item, EMapPickupsType2.Accessory, "map_eventicon_12", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_157"), 0, new byte[15]
		{
			1, 1, 0, 0, 1, 1, 0, 0, 0, 0,
			1, 1, 1, 1, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Accessory", 9), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 196, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_157"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(158, LocalStringManager.GetConfig("MapPickups_language", "Name_158"), EMapPickupsType.Item, EMapPickupsType2.Accessory, "map_eventicon_12", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_158"), 0, new byte[15]
		{
			1, 0, 1, 1, 0, 0, 1, 1, 0, 1,
			0, 0, 1, 1, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Accessory", 126), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 196, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_158"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(159, LocalStringManager.GetConfig("MapPickups_language", "Name_159"), EMapPickupsType.Item, EMapPickupsType2.Accessory, "map_eventicon_12", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_159"), 0, new byte[15]
		{
			0, 0, 0, 0, 1, 1, 0, 0, 1, 0,
			1, 1, 1, 0, 1
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Accessory", 189), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 196, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_159"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(160, LocalStringManager.GetConfig("MapPickups_language", "Name_160"), EMapPickupsType.Item, EMapPickupsType2.Accessory, "map_eventicon_12", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_160"), 0, new byte[15]
		{
			0, 1, 1, 1, 0, 0, 1, 1, 0, 1,
			0, 1, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Accessory", 216), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 196, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_160"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(161, LocalStringManager.GetConfig("MapPickups_language", "Name_161"), EMapPickupsType.Item, EMapPickupsType2.Accessory, "map_eventicon_12", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_161"), 0, new byte[15]
		{
			1, 0, 1, 1, 0, 0, 1, 1, 0, 1,
			1, 0, 0, 1, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Accessory", 198), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 196, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_161"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(162, LocalStringManager.GetConfig("MapPickups_language", "Name_162"), EMapPickupsType.Item, EMapPickupsType2.Accessory, "map_eventicon_12", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_162"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
			1, 1, 0, 0, 1
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Accessory", 18), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 196, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_162"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(163, LocalStringManager.GetConfig("MapPickups_language", "Name_163"), EMapPickupsType.Item, EMapPickupsType2.Accessory, "map_eventicon_12", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_163"), 0, new byte[15]
		{
			0, 0, 1, 0, 0, 0, 0, 1, 0, 1,
			0, 1, 1, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Accessory", 45), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 196, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_163"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(164, LocalStringManager.GetConfig("MapPickups_language", "Name_164"), EMapPickupsType.Item, EMapPickupsType2.Accessory, "map_eventicon_12", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_164"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
			1, 1, 0, 0, 1
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Accessory", 54), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 196, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_164"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(165, LocalStringManager.GetConfig("MapPickups_language", "Name_165"), EMapPickupsType.Item, EMapPickupsType2.Accessory, "map_eventicon_12", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_165"), 0, new byte[15]
		{
			0, 0, 1, 0, 0, 0, 0, 1, 0, 1,
			0, 1, 1, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Accessory", 27), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 196, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_165"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(166, LocalStringManager.GetConfig("MapPickups_language", "Name_166"), EMapPickupsType.Item, EMapPickupsType2.Accessory, "map_eventicon_12", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_166"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
			1, 1, 0, 0, 1
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Accessory", 36), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 196, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_166"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(167, LocalStringManager.GetConfig("MapPickups_language", "Name_167"), EMapPickupsType.Item, EMapPickupsType2.Accessory, "map_eventicon_12", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_167"), 0, new byte[15]
		{
			0, 0, 1, 0, 0, 0, 0, 1, 0, 1,
			0, 1, 1, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Accessory", 63), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 196, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_167"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(168, LocalStringManager.GetConfig("MapPickups_language", "Name_168"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_168"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 3), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 197, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_168"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(169, LocalStringManager.GetConfig("MapPickups_language", "Name_169"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_169"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 1
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 12), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 197, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_169"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(170, LocalStringManager.GetConfig("MapPickups_language", "Name_170"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_170"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 1, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 21), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 198, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_170"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(171, LocalStringManager.GetConfig("MapPickups_language", "Name_171"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_171"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 1, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 30), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 198, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_171"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(172, LocalStringManager.GetConfig("MapPickups_language", "Name_172"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_172"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 1, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 39), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 199, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_172"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(173, LocalStringManager.GetConfig("MapPickups_language", "Name_173"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_173"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 1, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 48), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 199, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_173"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(174, LocalStringManager.GetConfig("MapPickups_language", "Name_174"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_174"), 0, new byte[15]
		{
			0, 0, 1, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 57), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 200, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_174"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(175, LocalStringManager.GetConfig("MapPickups_language", "Name_175"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_175"), 0, new byte[15]
		{
			0, 0, 1, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 66), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 200, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_175"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(176, LocalStringManager.GetConfig("MapPickups_language", "Name_176"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_176"), 0, new byte[15]
		{
			0, 0, 1, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 75), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 200, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_176"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(177, LocalStringManager.GetConfig("MapPickups_language", "Name_177"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_177"), 0, new byte[15]
		{
			0, 0, 1, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 84), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 200, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_177"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(178, LocalStringManager.GetConfig("MapPickups_language", "Name_178"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_178"), 0, new byte[15]
		{
			0, 0, 1, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 93), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 200, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_178"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(179, LocalStringManager.GetConfig("MapPickups_language", "Name_179"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_179"), 0, new byte[15]
		{
			0, 0, 1, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 102), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 200, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_179"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
	}

	private void CreateItems3()
	{
		_dataArray.Add(new MapPickupsItem(180, LocalStringManager.GetConfig("MapPickups_language", "Name_180"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_180"), 0, new byte[15]
		{
			0, 1, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 111), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 201, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_180"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(181, LocalStringManager.GetConfig("MapPickups_language", "Name_181"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_181"), 0, new byte[15]
		{
			0, 1, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 120), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 201, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_181"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(182, LocalStringManager.GetConfig("MapPickups_language", "Name_182"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_182"), 0, new byte[15]
		{
			0, 1, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 129), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 201, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_182"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(183, LocalStringManager.GetConfig("MapPickups_language", "Name_183"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_183"), 0, new byte[15]
		{
			0, 1, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 138), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 201, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_183"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(184, LocalStringManager.GetConfig("MapPickups_language", "Name_184"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_184"), 0, new byte[15]
		{
			0, 1, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 147), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 201, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_184"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(185, LocalStringManager.GetConfig("MapPickups_language", "Name_185"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_185"), 0, new byte[15]
		{
			0, 1, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 156), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 201, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_185"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(186, LocalStringManager.GetConfig("MapPickups_language", "Name_186"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_186"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 1, 1, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 165), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 202, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_186"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(187, LocalStringManager.GetConfig("MapPickups_language", "Name_187"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_187"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 1, 1, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 174), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 202, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_187"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(188, LocalStringManager.GetConfig("MapPickups_language", "Name_188"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_188"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 1, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 183), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 202, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_188"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(189, LocalStringManager.GetConfig("MapPickups_language", "Name_189"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_189"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 1, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 192), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 202, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_189"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(190, LocalStringManager.GetConfig("MapPickups_language", "Name_190"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_190"), 0, new byte[15]
		{
			0, 0, 1, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 1, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 201), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 202, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_190"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(191, LocalStringManager.GetConfig("MapPickups_language", "Name_191"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_191"), 0, new byte[15]
		{
			0, 0, 1, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 1, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 210), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 202, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_191"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(192, LocalStringManager.GetConfig("MapPickups_language", "Name_192"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_192"), 0, new byte[15]
		{
			0, 0, 1, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 219), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 203, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_192"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(193, LocalStringManager.GetConfig("MapPickups_language", "Name_193"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_193"), 0, new byte[15]
		{
			0, 0, 1, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 228), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 203, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_193"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(194, LocalStringManager.GetConfig("MapPickups_language", "Name_194"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_194"), 0, new byte[15]
		{
			0, 0, 1, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 237), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 203, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_194"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(195, LocalStringManager.GetConfig("MapPickups_language", "Name_195"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_195"), 0, new byte[15]
		{
			0, 0, 1, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 246), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 203, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_195"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(196, LocalStringManager.GetConfig("MapPickups_language", "Name_196"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_196"), 0, new byte[15]
		{
			0, 0, 1, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 255), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 203, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_196"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(197, LocalStringManager.GetConfig("MapPickups_language", "Name_197"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_197"), 0, new byte[15]
		{
			0, 0, 1, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 264), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 203, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_197"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(198, LocalStringManager.GetConfig("MapPickups_language", "Name_198"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_198"), 0, new byte[15]
		{
			1, 0, 0, 1, 0, 1, 0, 0, 0, 0,
			0, 1, 0, 1, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 273), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 204, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_198"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(199, LocalStringManager.GetConfig("MapPickups_language", "Name_199"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_199"), 0, new byte[15]
		{
			1, 0, 0, 0, 0, 1, 0, 0, 0, 0,
			1, 1, 0, 1, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 282), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 204, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_199"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(200, LocalStringManager.GetConfig("MapPickups_language", "Name_200"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_200"), 0, new byte[15]
		{
			0, 1, 0, 1, 0, 0, 0, 0, 0, 1,
			0, 1, 0, 0, 1
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 291), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 204, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_200"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(201, LocalStringManager.GetConfig("MapPickups_language", "Name_201"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_201"), 0, new byte[15]
		{
			0, 1, 0, 1, 0, 1, 0, 0, 0, 1,
			0, 0, 0, 0, 1
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 300), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 204, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_201"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(202, LocalStringManager.GetConfig("MapPickups_language", "Name_202"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_202"), 0, new byte[15]
		{
			0, 0, 1, 0, 0, 0, 1, 1, 0, 1,
			0, 1, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 309), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 204, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_202"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(203, LocalStringManager.GetConfig("MapPickups_language", "Name_203"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_203"), 0, new byte[15]
		{
			0, 0, 1, 0, 0, 0, 1, 1, 0, 1,
			0, 1, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 318), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 204, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_203"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(204, LocalStringManager.GetConfig("MapPickups_language", "Name_204"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_204"), 0, new byte[15]
		{
			1, 1, 0, 0, 0, 0, 1, 1, 0, 0,
			0, 0, 1, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 327), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 204, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_204"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(205, LocalStringManager.GetConfig("MapPickups_language", "Name_205"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_205"), 0, new byte[15]
		{
			1, 1, 0, 0, 0, 0, 1, 1, 0, 0,
			0, 0, 1, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 336), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 204, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_205"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(206, LocalStringManager.GetConfig("MapPickups_language", "Name_206"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_206"), 0, new byte[15]
		{
			0, 1, 1, 0, 0, 0, 0, 0, 0, 1,
			0, 1, 0, 0, 1
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 345), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 205, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_206"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(207, LocalStringManager.GetConfig("MapPickups_language", "Name_207"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_207"), 0, new byte[15]
		{
			0, 1, 1, 0, 0, 0, 0, 0, 0, 1,
			0, 1, 0, 0, 1
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 354), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 205, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_207"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(208, LocalStringManager.GetConfig("MapPickups_language", "Name_208"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_208"), 0, new byte[15]
		{
			0, 0, 1, 1, 0, 0, 0, 1, 0, 0,
			0, 1, 1, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 363), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 205, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_208"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(209, LocalStringManager.GetConfig("MapPickups_language", "Name_209"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_209"), 0, new byte[15]
		{
			0, 0, 1, 1, 0, 0, 0, 1, 0, 0,
			0, 1, 1, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 372), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 205, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_209"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(210, LocalStringManager.GetConfig("MapPickups_language", "Name_210"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_210"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			1, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 381), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 206, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_210"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(211, LocalStringManager.GetConfig("MapPickups_language", "Name_211"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_211"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			1, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 390), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 206, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_211"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(212, LocalStringManager.GetConfig("MapPickups_language", "Name_212"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_212"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			1, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 399), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 206, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_212"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(213, LocalStringManager.GetConfig("MapPickups_language", "Name_213"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_213"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			1, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 408), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 206, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_213"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(214, LocalStringManager.GetConfig("MapPickups_language", "Name_214"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_214"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			1, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 417), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 206, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_214"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(215, LocalStringManager.GetConfig("MapPickups_language", "Name_215"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_215"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			1, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 426), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 206, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_215"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(216, LocalStringManager.GetConfig("MapPickups_language", "Name_216"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_216"), 0, new byte[15]
		{
			0, 1, 0, 0, 1, 0, 0, 0, 1, 0,
			0, 1, 1, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 435), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 207, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_216"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(217, LocalStringManager.GetConfig("MapPickups_language", "Name_217"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_217"), 0, new byte[15]
		{
			0, 1, 0, 0, 1, 0, 0, 0, 1, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 444), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 207, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_217"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(218, LocalStringManager.GetConfig("MapPickups_language", "Name_218"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_218"), 0, new byte[15]
		{
			0, 0, 0, 1, 1, 0, 0, 0, 1, 0,
			0, 1, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 453), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 207, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_218"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(219, LocalStringManager.GetConfig("MapPickups_language", "Name_219"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_219"), 0, new byte[15]
		{
			0, 1, 0, 0, 1, 0, 0, 0, 1, 0,
			0, 0, 1, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 462), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 207, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_219"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(220, LocalStringManager.GetConfig("MapPickups_language", "Name_220"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_220"), 0, new byte[15]
		{
			0, 0, 0, 1, 0, 0, 0, 0, 1, 0,
			0, 1, 1, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 471), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 207, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_220"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(221, LocalStringManager.GetConfig("MapPickups_language", "Name_221"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_221"), 0, new byte[15]
		{
			0, 1, 0, 1, 0, 0, 0, 0, 1, 0,
			0, 1, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 480), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 207, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_221"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(222, LocalStringManager.GetConfig("MapPickups_language", "Name_222"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_222"), 0, new byte[15]
		{
			0, 1, 0, 0, 1, 0, 1, 0, 1, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 489), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 207, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_222"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(223, LocalStringManager.GetConfig("MapPickups_language", "Name_223"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_223"), 0, new byte[15]
		{
			0, 0, 0, 1, 1, 0, 1, 0, 1, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 498), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 207, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_223"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(224, LocalStringManager.GetConfig("MapPickups_language", "Name_224"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_224"), 0, new byte[15]
		{
			0, 0, 0, 1, 0, 0, 1, 0, 1, 0,
			0, 1, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 507), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 207, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_224"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(225, LocalStringManager.GetConfig("MapPickups_language", "Name_225"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_225"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 1, 0, 1, 0,
			0, 1, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 516), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 207, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_225"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(226, LocalStringManager.GetConfig("MapPickups_language", "Name_226"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_226"), 0, new byte[15]
		{
			0, 0, 0, 0, 1, 0, 0, 0, 1, 0,
			1, 0, 0, 1, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 525), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 208, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_226"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(227, LocalStringManager.GetConfig("MapPickups_language", "Name_227"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_227"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 1, 0, 0, 1, 0,
			1, 0, 0, 1, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 534), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 208, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_227"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(228, LocalStringManager.GetConfig("MapPickups_language", "Name_228"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_228"), 0, new byte[15]
		{
			0, 0, 0, 0, 1, 0, 0, 0, 1, 0,
			1, 0, 0, 1, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 543), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 208, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_228"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(229, LocalStringManager.GetConfig("MapPickups_language", "Name_229"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_229"), 0, new byte[15]
		{
			0, 0, 0, 0, 1, 1, 0, 0, 1, 0,
			0, 0, 0, 1, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 552), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 208, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_229"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(230, LocalStringManager.GetConfig("MapPickups_language", "Name_230"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_230"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 1, 0, 0, 1, 0,
			1, 0, 0, 1, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 561), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 208, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_230"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(231, LocalStringManager.GetConfig("MapPickups_language", "Name_231"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_231"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 1, 0, 0, 1, 0,
			1, 0, 0, 1, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 570), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 208, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_231"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(232, LocalStringManager.GetConfig("MapPickups_language", "Name_232"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_232"), 0, new byte[15]
		{
			0, 0, 0, 0, 1, 1, 0, 0, 1, 0,
			1, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 579), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 208, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_232"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(233, LocalStringManager.GetConfig("MapPickups_language", "Name_233"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_233"), 0, new byte[15]
		{
			0, 0, 0, 0, 1, 0, 0, 0, 1, 0,
			1, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 588), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 208, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_233"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(234, LocalStringManager.GetConfig("MapPickups_language", "Name_234"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_234"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 1, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 597), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 208, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_234"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(235, LocalStringManager.GetConfig("MapPickups_language", "Name_235"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_235"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 1, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 606), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 208, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_235"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(236, LocalStringManager.GetConfig("MapPickups_language", "Name_236"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_236"), 0, new byte[15]
		{
			1, 0, 0, 0, 0, 0, 0, 0, 1, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 615), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 209, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_236"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(237, LocalStringManager.GetConfig("MapPickups_language", "Name_237"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_237"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 1, 0, 0, 1, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 624), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 209, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_237"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(238, LocalStringManager.GetConfig("MapPickups_language", "Name_238"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_238"), 0, new byte[15]
		{
			1, 0, 0, 0, 0, 0, 0, 0, 1, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 633), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 209, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_238"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(239, LocalStringManager.GetConfig("MapPickups_language", "Name_239"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_239"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 1, 0, 0, 1, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 642), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 209, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_239"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
	}

	private void CreateItems4()
	{
		_dataArray.Add(new MapPickupsItem(240, LocalStringManager.GetConfig("MapPickups_language", "Name_240"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_240"), 0, new byte[15]
		{
			1, 0, 0, 0, 0, 1, 0, 0, 1, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 651), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 209, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_240"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(241, LocalStringManager.GetConfig("MapPickups_language", "Name_241"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_241"), 0, new byte[15]
		{
			1, 0, 0, 0, 0, 1, 0, 0, 1, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 660), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 209, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_241"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(242, LocalStringManager.GetConfig("MapPickups_language", "Name_242"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_242"), 0, new byte[15]
		{
			1, 0, 0, 0, 0, 0, 0, 0, 1, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 669), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 209, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_242"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(243, LocalStringManager.GetConfig("MapPickups_language", "Name_243"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_243"), 0, new byte[15]
		{
			1, 0, 0, 0, 0, 0, 0, 0, 1, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 678), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 209, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_243"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(244, LocalStringManager.GetConfig("MapPickups_language", "Name_244"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_244"), 0, new byte[15]
		{
			1, 0, 0, 0, 0, 0, 0, 0, 1, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 687), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 209, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_244"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(245, LocalStringManager.GetConfig("MapPickups_language", "Name_245"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_245"), 0, new byte[15]
		{
			1, 0, 0, 0, 0, 0, 0, 0, 1, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 696), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 209, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_245"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(246, LocalStringManager.GetConfig("MapPickups_language", "Name_246"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_246"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 1, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 705), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 210, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_246"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(247, LocalStringManager.GetConfig("MapPickups_language", "Name_247"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_247"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 1, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 714), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 210, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_247"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(248, LocalStringManager.GetConfig("MapPickups_language", "Name_248"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_248"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 1, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 723), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 210, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_248"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(249, LocalStringManager.GetConfig("MapPickups_language", "Name_249"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_249"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 1, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 732), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 210, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_249"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(250, LocalStringManager.GetConfig("MapPickups_language", "Name_250"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_250"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 1, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 741), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 210, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_250"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(251, LocalStringManager.GetConfig("MapPickups_language", "Name_251"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_251"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 1, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 750), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 210, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_251"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(252, LocalStringManager.GetConfig("MapPickups_language", "Name_252"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_252"), 0, new byte[15]
		{
			0, 0, 0, 1, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 759), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 211, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_252"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(253, LocalStringManager.GetConfig("MapPickups_language", "Name_253"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_253"), 0, new byte[15]
		{
			0, 0, 0, 1, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 768), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 211, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_253"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(254, LocalStringManager.GetConfig("MapPickups_language", "Name_254"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_254"), 0, new byte[15]
		{
			0, 0, 0, 1, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 777), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 211, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_254"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(255, LocalStringManager.GetConfig("MapPickups_language", "Name_255"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_255"), 0, new byte[15]
		{
			0, 0, 0, 1, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 786), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 211, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_255"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(256, LocalStringManager.GetConfig("MapPickups_language", "Name_256"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_256"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 1, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 795), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 212, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_256"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(257, LocalStringManager.GetConfig("MapPickups_language", "Name_257"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_257"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 1, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 804), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 212, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_257"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(258, LocalStringManager.GetConfig("MapPickups_language", "Name_258"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_258"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 1, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 813), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 212, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_258"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(259, LocalStringManager.GetConfig("MapPickups_language", "Name_259"), EMapPickupsType.Item, EMapPickupsType2.Weapon, "map_eventicon_13", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_259"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 1, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Weapon", 822), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 212, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_259"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(260, LocalStringManager.GetConfig("MapPickups_language", "Name_260"), EMapPickupsType.Item, EMapPickupsType2.Armor, "map_eventicon_14", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_260"), 0, new byte[15]
		{
			1, 0, 0, 0, 1, 1, 0, 0, 1, 0,
			1, 0, 0, 1, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Armor", 0), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 213, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_260"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(261, LocalStringManager.GetConfig("MapPickups_language", "Name_261"), EMapPickupsType.Item, EMapPickupsType2.Armor, "map_eventicon_14", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_261"), 0, new byte[15]
		{
			1, 0, 0, 0, 1, 1, 0, 0, 1, 0,
			1, 0, 0, 1, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Armor", 9), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 213, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_261"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(262, LocalStringManager.GetConfig("MapPickups_language", "Name_262"), EMapPickupsType.Item, EMapPickupsType2.Armor, "map_eventicon_14", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_262"), 0, new byte[15]
		{
			0, 1, 0, 1, 1, 0, 1, 0, 1, 0,
			0, 0, 0, 0, 1
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Armor", 18), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 213, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_262"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(263, LocalStringManager.GetConfig("MapPickups_language", "Name_263"), EMapPickupsType.Item, EMapPickupsType2.Armor, "map_eventicon_14", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_263"), 0, new byte[15]
		{
			0, 0, 1, 1, 1, 0, 1, 0, 1, 0,
			0, 0, 0, 0, 1
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Armor", 27), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 213, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_263"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(264, LocalStringManager.GetConfig("MapPickups_language", "Name_264"), EMapPickupsType.Item, EMapPickupsType2.Armor, "map_eventicon_14", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_264"), 0, new byte[15]
		{
			1, 0, 0, 0, 0, 1, 0, 0, 0, 1,
			1, 1, 0, 1, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Armor", 36), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 213, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_264"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(265, LocalStringManager.GetConfig("MapPickups_language", "Name_265"), EMapPickupsType.Item, EMapPickupsType2.Armor, "map_eventicon_14", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_265"), 0, new byte[15]
		{
			1, 0, 0, 0, 0, 0, 0, 0, 0, 1,
			1, 1, 0, 1, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Armor", 45), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 213, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_265"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(266, LocalStringManager.GetConfig("MapPickups_language", "Name_266"), EMapPickupsType.Item, EMapPickupsType2.Armor, "map_eventicon_14", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_266"), 0, new byte[15]
		{
			0, 0, 0, 1, 0, 1, 0, 0, 0, 1,
			0, 0, 1, 0, 1
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Armor", 54), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 213, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_266"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(267, LocalStringManager.GetConfig("MapPickups_language", "Name_267"), EMapPickupsType.Item, EMapPickupsType2.Armor, "map_eventicon_14", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_267"), 0, new byte[15]
		{
			0, 0, 0, 1, 0, 1, 0, 0, 0, 1,
			0, 0, 1, 0, 1
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Armor", 63), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 213, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_267"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(268, LocalStringManager.GetConfig("MapPickups_language", "Name_268"), EMapPickupsType.Item, EMapPickupsType2.Armor, "map_eventicon_14", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_268"), 0, new byte[15]
		{
			0, 1, 1, 0, 0, 0, 1, 1, 0, 0,
			0, 1, 1, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Armor", 72), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 213, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_268"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(269, LocalStringManager.GetConfig("MapPickups_language", "Name_269"), EMapPickupsType.Item, EMapPickupsType2.Armor, "map_eventicon_14", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_269"), 0, new byte[15]
		{
			0, 1, 1, 0, 0, 0, 1, 1, 0, 0,
			0, 1, 1, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Armor", 81), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 213, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_269"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(270, LocalStringManager.GetConfig("MapPickups_language", "Name_270"), EMapPickupsType.Item, EMapPickupsType2.Armor, "map_eventicon_14", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_270"), 0, new byte[15]
		{
			0, 1, 0, 1, 0, 0, 1, 1, 0, 0,
			0, 1, 1, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Armor", 90), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 213, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_270"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(271, LocalStringManager.GetConfig("MapPickups_language", "Name_271"), EMapPickupsType.Item, EMapPickupsType2.Armor, "map_eventicon_14", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_271"), 0, new byte[15]
		{
			0, 1, 0, 1, 0, 0, 1, 1, 0, 0,
			0, 1, 1, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Armor", 99), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 213, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_271"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(272, LocalStringManager.GetConfig("MapPickups_language", "Name_272"), EMapPickupsType.Item, EMapPickupsType2.Armor, "map_eventicon_14", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_272"), 0, new byte[15]
		{
			0, 0, 1, 0, 1, 0, 0, 1, 0, 1,
			1, 0, 0, 1, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Armor", 108), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 213, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_272"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(273, LocalStringManager.GetConfig("MapPickups_language", "Name_273"), EMapPickupsType.Item, EMapPickupsType2.Armor, "map_eventicon_14", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_273"), 0, new byte[15]
		{
			0, 0, 1, 0, 0, 0, 1, 1, 0, 1,
			1, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Armor", 117), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 213, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_273"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(274, LocalStringManager.GetConfig("MapPickups_language", "Name_274"), EMapPickupsType.Item, EMapPickupsType2.Armor, "map_eventicon_14", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_274"), 0, new byte[15]
		{
			1, 0, 0, 0, 1, 1, 0, 0, 1, 0,
			1, 0, 0, 1, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Armor", 126), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 214, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_274"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(275, LocalStringManager.GetConfig("MapPickups_language", "Name_275"), EMapPickupsType.Item, EMapPickupsType2.Armor, "map_eventicon_14", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_275"), 0, new byte[15]
		{
			1, 0, 0, 0, 1, 1, 0, 0, 1, 0,
			1, 0, 0, 1, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Armor", 135), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 214, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_275"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(276, LocalStringManager.GetConfig("MapPickups_language", "Name_276"), EMapPickupsType.Item, EMapPickupsType2.Armor, "map_eventicon_14", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_276"), 0, new byte[15]
		{
			0, 1, 0, 1, 1, 0, 1, 0, 1, 0,
			0, 0, 0, 0, 1
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Armor", 144), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 214, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_276"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(277, LocalStringManager.GetConfig("MapPickups_language", "Name_277"), EMapPickupsType.Item, EMapPickupsType2.Armor, "map_eventicon_14", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_277"), 0, new byte[15]
		{
			0, 0, 1, 1, 1, 0, 1, 0, 1, 0,
			0, 0, 0, 0, 1
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Armor", 153), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 214, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_277"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(278, LocalStringManager.GetConfig("MapPickups_language", "Name_278"), EMapPickupsType.Item, EMapPickupsType2.Armor, "map_eventicon_14", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_278"), 0, new byte[15]
		{
			1, 0, 0, 0, 0, 1, 0, 0, 0, 1,
			1, 1, 0, 1, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Armor", 162), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 214, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_278"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(279, LocalStringManager.GetConfig("MapPickups_language", "Name_279"), EMapPickupsType.Item, EMapPickupsType2.Armor, "map_eventicon_14", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_279"), 0, new byte[15]
		{
			1, 0, 0, 0, 0, 0, 0, 0, 0, 1,
			1, 1, 0, 1, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Armor", 171), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 214, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_279"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(280, LocalStringManager.GetConfig("MapPickups_language", "Name_280"), EMapPickupsType.Item, EMapPickupsType2.Armor, "map_eventicon_14", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_280"), 0, new byte[15]
		{
			0, 0, 0, 1, 0, 1, 0, 0, 0, 1,
			0, 0, 1, 0, 1
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Armor", 180), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 214, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_280"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(281, LocalStringManager.GetConfig("MapPickups_language", "Name_281"), EMapPickupsType.Item, EMapPickupsType2.Armor, "map_eventicon_14", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_281"), 0, new byte[15]
		{
			0, 0, 0, 1, 0, 1, 0, 0, 0, 1,
			0, 0, 1, 0, 1
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Armor", 189), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 214, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_281"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(282, LocalStringManager.GetConfig("MapPickups_language", "Name_282"), EMapPickupsType.Item, EMapPickupsType2.Armor, "map_eventicon_14", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_282"), 0, new byte[15]
		{
			0, 1, 1, 0, 0, 0, 1, 1, 0, 0,
			0, 1, 1, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Armor", 198), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 214, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_282"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(283, LocalStringManager.GetConfig("MapPickups_language", "Name_283"), EMapPickupsType.Item, EMapPickupsType2.Armor, "map_eventicon_14", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_283"), 0, new byte[15]
		{
			0, 1, 1, 0, 0, 0, 1, 1, 0, 0,
			0, 1, 1, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Armor", 207), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 214, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_283"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(284, LocalStringManager.GetConfig("MapPickups_language", "Name_284"), EMapPickupsType.Item, EMapPickupsType2.Armor, "map_eventicon_14", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_284"), 0, new byte[15]
		{
			0, 1, 0, 1, 0, 0, 1, 1, 0, 0,
			0, 1, 1, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Armor", 216), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 214, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_284"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(285, LocalStringManager.GetConfig("MapPickups_language", "Name_285"), EMapPickupsType.Item, EMapPickupsType2.Armor, "map_eventicon_14", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_285"), 0, new byte[15]
		{
			0, 1, 0, 1, 0, 0, 1, 1, 0, 0,
			0, 1, 1, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Armor", 225), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 214, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_285"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(286, LocalStringManager.GetConfig("MapPickups_language", "Name_286"), EMapPickupsType.Item, EMapPickupsType2.Armor, "map_eventicon_14", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_286"), 0, new byte[15]
		{
			0, 0, 1, 0, 1, 0, 0, 1, 0, 1,
			1, 0, 0, 1, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Armor", 234), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 214, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_286"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(287, LocalStringManager.GetConfig("MapPickups_language", "Name_287"), EMapPickupsType.Item, EMapPickupsType2.Armor, "map_eventicon_14", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_287"), 0, new byte[15]
		{
			0, 0, 1, 0, 0, 0, 1, 1, 0, 1,
			1, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Armor", 243), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 214, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_287"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(288, LocalStringManager.GetConfig("MapPickups_language", "Name_288"), EMapPickupsType.Item, EMapPickupsType2.Armor, "map_eventicon_14", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_288"), 0, new byte[15]
		{
			1, 0, 0, 0, 1, 1, 0, 0, 1, 0,
			1, 0, 0, 1, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Armor", 252), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 215, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_288"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(289, LocalStringManager.GetConfig("MapPickups_language", "Name_289"), EMapPickupsType.Item, EMapPickupsType2.Armor, "map_eventicon_14", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_289"), 0, new byte[15]
		{
			1, 0, 0, 0, 1, 1, 0, 0, 1, 0,
			1, 0, 0, 1, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Armor", 261), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 215, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_289"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(290, LocalStringManager.GetConfig("MapPickups_language", "Name_290"), EMapPickupsType.Item, EMapPickupsType2.Armor, "map_eventicon_14", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_290"), 0, new byte[15]
		{
			1, 0, 0, 0, 1, 1, 0, 0, 1, 0,
			1, 0, 0, 1, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Armor", 270), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 215, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_290"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(291, LocalStringManager.GetConfig("MapPickups_language", "Name_291"), EMapPickupsType.Item, EMapPickupsType2.Armor, "map_eventicon_14", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_291"), 0, new byte[15]
		{
			1, 0, 0, 0, 1, 1, 0, 0, 1, 0,
			1, 0, 0, 1, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Armor", 279), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 215, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_291"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(292, LocalStringManager.GetConfig("MapPickups_language", "Name_292"), EMapPickupsType.Item, EMapPickupsType2.Armor, "map_eventicon_14", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_292"), 0, new byte[15]
		{
			0, 1, 0, 1, 1, 0, 1, 0, 1, 0,
			0, 0, 0, 0, 1
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Armor", 288), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 215, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_292"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(293, LocalStringManager.GetConfig("MapPickups_language", "Name_293"), EMapPickupsType.Item, EMapPickupsType2.Armor, "map_eventicon_14", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_293"), 0, new byte[15]
		{
			0, 0, 1, 1, 1, 0, 1, 0, 1, 0,
			0, 0, 0, 0, 1
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Armor", 297), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 215, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_293"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(294, LocalStringManager.GetConfig("MapPickups_language", "Name_294"), EMapPickupsType.Item, EMapPickupsType2.Armor, "map_eventicon_14", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_294"), 0, new byte[15]
		{
			1, 0, 0, 0, 0, 1, 0, 0, 0, 1,
			1, 1, 0, 1, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Armor", 306), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 215, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_294"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(295, LocalStringManager.GetConfig("MapPickups_language", "Name_295"), EMapPickupsType.Item, EMapPickupsType2.Armor, "map_eventicon_14", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_295"), 0, new byte[15]
		{
			1, 0, 0, 0, 0, 0, 0, 0, 0, 1,
			1, 1, 0, 1, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Armor", 315), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 215, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_295"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(296, LocalStringManager.GetConfig("MapPickups_language", "Name_296"), EMapPickupsType.Item, EMapPickupsType2.Armor, "map_eventicon_14", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_296"), 0, new byte[15]
		{
			0, 0, 0, 1, 0, 1, 0, 0, 0, 1,
			0, 0, 1, 0, 1
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Armor", 324), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 215, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_296"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(297, LocalStringManager.GetConfig("MapPickups_language", "Name_297"), EMapPickupsType.Item, EMapPickupsType2.Armor, "map_eventicon_14", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_297"), 0, new byte[15]
		{
			0, 0, 0, 1, 0, 1, 0, 0, 0, 1,
			0, 0, 1, 0, 1
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Armor", 333), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 215, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_297"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(298, LocalStringManager.GetConfig("MapPickups_language", "Name_298"), EMapPickupsType.Item, EMapPickupsType2.Armor, "map_eventicon_14", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_298"), 0, new byte[15]
		{
			0, 1, 1, 0, 0, 0, 1, 1, 0, 0,
			0, 1, 1, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Armor", 342), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 215, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_298"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(299, LocalStringManager.GetConfig("MapPickups_language", "Name_299"), EMapPickupsType.Item, EMapPickupsType2.Armor, "map_eventicon_14", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_299"), 0, new byte[15]
		{
			0, 1, 1, 0, 0, 0, 1, 1, 0, 0,
			0, 1, 1, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Armor", 351), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 215, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_299"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
	}

	private void CreateItems5()
	{
		_dataArray.Add(new MapPickupsItem(300, LocalStringManager.GetConfig("MapPickups_language", "Name_300"), EMapPickupsType.Item, EMapPickupsType2.Armor, "map_eventicon_14", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_300"), 0, new byte[15]
		{
			0, 1, 0, 1, 0, 0, 1, 1, 0, 0,
			0, 1, 1, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Armor", 360), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 215, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_300"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(301, LocalStringManager.GetConfig("MapPickups_language", "Name_301"), EMapPickupsType.Item, EMapPickupsType2.Armor, "map_eventicon_14", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_301"), 0, new byte[15]
		{
			0, 1, 0, 1, 0, 0, 1, 1, 0, 0,
			0, 1, 1, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Armor", 369), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 215, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_301"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(302, LocalStringManager.GetConfig("MapPickups_language", "Name_302"), EMapPickupsType.Item, EMapPickupsType2.Armor, "map_eventicon_14", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_302"), 0, new byte[15]
		{
			0, 0, 1, 0, 1, 0, 0, 1, 0, 1,
			1, 0, 0, 1, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Armor", 378), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 215, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_302"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(303, LocalStringManager.GetConfig("MapPickups_language", "Name_303"), EMapPickupsType.Item, EMapPickupsType2.Armor, "map_eventicon_14", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_303"), 0, new byte[15]
		{
			0, 0, 1, 0, 0, 0, 1, 1, 0, 1,
			1, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Armor", 387), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 215, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_303"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(304, LocalStringManager.GetConfig("MapPickups_language", "Name_304"), EMapPickupsType.Item, EMapPickupsType2.Armor, "map_eventicon_14", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_304"), 0, new byte[15]
		{
			1, 0, 0, 0, 1, 1, 0, 0, 1, 0,
			1, 0, 0, 1, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Armor", 396), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 216, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_304"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(305, LocalStringManager.GetConfig("MapPickups_language", "Name_305"), EMapPickupsType.Item, EMapPickupsType2.Armor, "map_eventicon_14", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_305"), 0, new byte[15]
		{
			1, 0, 0, 0, 1, 1, 0, 0, 1, 0,
			1, 0, 0, 1, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Armor", 405), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 216, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_305"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(306, LocalStringManager.GetConfig("MapPickups_language", "Name_306"), EMapPickupsType.Item, EMapPickupsType2.Armor, "map_eventicon_14", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_306"), 0, new byte[15]
		{
			0, 1, 0, 1, 1, 0, 1, 0, 1, 0,
			0, 0, 0, 0, 1
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Armor", 414), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 216, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_306"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(307, LocalStringManager.GetConfig("MapPickups_language", "Name_307"), EMapPickupsType.Item, EMapPickupsType2.Armor, "map_eventicon_14", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_307"), 0, new byte[15]
		{
			0, 0, 1, 1, 1, 0, 1, 0, 1, 0,
			0, 0, 0, 0, 1
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Armor", 423), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 216, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_307"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(308, LocalStringManager.GetConfig("MapPickups_language", "Name_308"), EMapPickupsType.Item, EMapPickupsType2.Armor, "map_eventicon_14", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_308"), 0, new byte[15]
		{
			1, 0, 0, 0, 0, 1, 0, 0, 0, 1,
			1, 1, 0, 1, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Armor", 432), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 216, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_308"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(309, LocalStringManager.GetConfig("MapPickups_language", "Name_309"), EMapPickupsType.Item, EMapPickupsType2.Armor, "map_eventicon_14", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_309"), 0, new byte[15]
		{
			1, 0, 0, 0, 0, 0, 0, 0, 0, 1,
			1, 1, 0, 1, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Armor", 441), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 216, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_309"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(310, LocalStringManager.GetConfig("MapPickups_language", "Name_310"), EMapPickupsType.Item, EMapPickupsType2.Armor, "map_eventicon_14", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_310"), 0, new byte[15]
		{
			0, 0, 0, 1, 0, 1, 0, 0, 0, 1,
			0, 0, 1, 0, 1
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Armor", 450), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 216, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_310"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(311, LocalStringManager.GetConfig("MapPickups_language", "Name_311"), EMapPickupsType.Item, EMapPickupsType2.Armor, "map_eventicon_14", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_311"), 0, new byte[15]
		{
			0, 0, 0, 1, 0, 1, 0, 0, 0, 1,
			0, 0, 1, 0, 1
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Armor", 459), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 216, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_311"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(312, LocalStringManager.GetConfig("MapPickups_language", "Name_312"), EMapPickupsType.Item, EMapPickupsType2.Armor, "map_eventicon_14", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_312"), 0, new byte[15]
		{
			0, 1, 1, 0, 0, 0, 1, 1, 0, 0,
			0, 1, 1, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Armor", 468), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 216, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_312"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(313, LocalStringManager.GetConfig("MapPickups_language", "Name_313"), EMapPickupsType.Item, EMapPickupsType2.Armor, "map_eventicon_14", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_313"), 0, new byte[15]
		{
			0, 1, 1, 0, 0, 0, 1, 1, 0, 0,
			0, 1, 1, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Armor", 477), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 216, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_313"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(314, LocalStringManager.GetConfig("MapPickups_language", "Name_314"), EMapPickupsType.Item, EMapPickupsType2.Armor, "map_eventicon_14", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_314"), 0, new byte[15]
		{
			0, 1, 0, 1, 0, 0, 1, 1, 0, 0,
			0, 1, 1, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Armor", 486), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 216, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_314"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(315, LocalStringManager.GetConfig("MapPickups_language", "Name_315"), EMapPickupsType.Item, EMapPickupsType2.Armor, "map_eventicon_14", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_315"), 0, new byte[15]
		{
			0, 1, 0, 1, 0, 0, 1, 1, 0, 0,
			0, 1, 1, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Armor", 495), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 216, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_315"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(316, LocalStringManager.GetConfig("MapPickups_language", "Name_316"), EMapPickupsType.Item, EMapPickupsType2.Armor, "map_eventicon_14", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_316"), 0, new byte[15]
		{
			0, 0, 1, 0, 1, 0, 0, 1, 0, 1,
			1, 0, 0, 1, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Armor", 504), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 216, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_316"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(317, LocalStringManager.GetConfig("MapPickups_language", "Name_317"), EMapPickupsType.Item, EMapPickupsType2.Armor, "map_eventicon_14", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_317"), 0, new byte[15]
		{
			0, 0, 1, 0, 0, 0, 1, 1, 0, 1,
			1, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93, 118, 119, 120,
			121, 122, 123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Armor", 513), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 216, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_317"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(318, LocalStringManager.GetConfig("MapPickups_language", "Name_318"), EMapPickupsType.Item, EMapPickupsType2.Carrier, "map_eventicon_15", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_318"), 1, new byte[15]
		{
			1, 0, 0, 0, 0, 1, 0, 0, 1, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Carrier", 0), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 217, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_318"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(319, LocalStringManager.GetConfig("MapPickups_language", "Name_319"), EMapPickupsType.Item, EMapPickupsType2.Carrier, "map_eventicon_15", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_319"), 1, new byte[15]
		{
			0, 0, 0, 1, 0, 0, 0, 1, 0, 0,
			0, 0, 0, 0, 1
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Carrier", 9), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 217, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_319"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(320, LocalStringManager.GetConfig("MapPickups_language", "Name_320"), EMapPickupsType.Item, EMapPickupsType2.Carrier, "map_eventicon_15", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_320"), 0, new byte[15]
		{
			0, 0, 1, 0, 0, 0, 0, 0, 0, 1,
			1, 0, 0, 0, 0
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new PresetItemTemplateId("Carrier", 18), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 217, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_320"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(321, LocalStringManager.GetConfig("MapPickups_language", "Name_321"), EMapPickupsType.Item, EMapPickupsType2.Carrier, "map_eventicon_15", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_321"), 0, new byte[15]
		{
			0, 1, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 1, 0, 1, 0
		}, new List<short>
		{
			94, 95, 96, 97, 98, 99, 100, 101, 102, 103,
			104, 105, 106, 107, 108
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[3] { 2, 3, 4 }, new PresetItemTemplateId("Carrier", 27), new sbyte[3] { 2, 4, 6 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 217, -1, 247, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_321"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(322, LocalStringManager.GetConfig("MapPickups_language", "Name_322"), EMapPickupsType.Growth, EMapPickupsType2.Exp, "map_eventicon_20", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_322"), 2, new byte[15]
		{
			2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
			2, 2, 2, 2, 2
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36
		}, readEffect: false, loopEffect: false, isExpBonus: true, isDebtBonus: false, new int[8] { 100, 200, 400, 800, 1600, 3200, 6400, 12800 }, new sbyte[0], default(PresetItemTemplateId), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 218, 245, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_322"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(323, LocalStringManager.GetConfig("MapPickups_language", "Name_323"), EMapPickupsType.Growth, EMapPickupsType2.Exp, "map_eventicon_20", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_323"), 2, new byte[15]
		{
			3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
			3, 3, 3, 3, 3
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93
		}, readEffect: false, loopEffect: false, isExpBonus: true, isDebtBonus: false, new int[8] { 150, 300, 600, 1200, 2400, 4800, 9600, 19200 }, new sbyte[0], default(PresetItemTemplateId), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 218, 245, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_323"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(324, LocalStringManager.GetConfig("MapPickups_language", "Name_324"), EMapPickupsType.Growth, EMapPickupsType2.Exp, "map_eventicon_20", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_324"), 2, new byte[15]
		{
			3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
			3, 3, 3, 3, 3
		}, new List<short>
		{
			94, 95, 96, 97, 98, 99, 100, 101, 102, 103,
			104, 105, 106, 107, 108, 118, 119, 120, 121, 122,
			123, 124
		}, readEffect: false, loopEffect: false, isExpBonus: true, isDebtBonus: false, new int[8] { 200, 400, 800, 1600, 3200, 6400, 12800, 25600 }, new sbyte[0], default(PresetItemTemplateId), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 218, 245, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_324"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(325, LocalStringManager.GetConfig("MapPickups_language", "Name_325"), EMapPickupsType.Growth, EMapPickupsType2.Read, "map_eventicon_16", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_325"), 1, new byte[15]
		{
			3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
			3, 3, 3, 3, 3
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 63, 64, 65, 66,
			67, 68, 69, 70, 71, 72, 73, 74, 75, 76,
			77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
			87, 88, 89, 90, 91, 92, 93
		}, readEffect: true, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[6] { 0, 1, 2, 3, 4, 5 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 219, -1, 248, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_325"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(326, LocalStringManager.GetConfig("MapPickups_language", "Name_326"), EMapPickupsType.Growth, EMapPickupsType2.Loop, "map_eventicon_19", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_326"), 1, new byte[15]
		{
			3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
			3, 3, 3, 3, 3
		}, new List<short>
		{
			94, 95, 96, 97, 98, 99, 100, 101, 102, 103,
			104, 105, 106, 107, 108
		}, readEffect: false, loopEffect: true, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[6] { 0, 1, 2, 3, 4, 5 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 220, -1, 249, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_326"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(327, LocalStringManager.GetConfig("MapPickups_language", "Name_327"), EMapPickupsType.Growth, EMapPickupsType2.SpiritualDebt, "map_eventicon_17", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_327"), 0, new byte[15]
		{
			2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
			2, 2, 2, 2, 2
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: true, new int[8] { 25, 50, 75, 125, 175, 225, 300, 375 }, new sbyte[0], default(PresetItemTemplateId), new sbyte[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), 221, 246, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_327"), new string[0], new string[0], new string[0], new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(328, LocalStringManager.GetConfig("MapPickups_language", "Name_328"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_328"), 0, new byte[15]
		{
			1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 19 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_328"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_328_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_328_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_328_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_328_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_328_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_328_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Accessory", 13, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Accessory", 184, 1)
		}));
		_dataArray.Add(new MapPickupsItem(329, LocalStringManager.GetConfig("MapPickups_language", "Name_329"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_329"), 0, new byte[15]
		{
			1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 19 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_329"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_329_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_329_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_329_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_329_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_329_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_329_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Armor", 418, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Armor", 400, 1),
			new PresetItemWithCount("Armor", 508, 1)
		}));
		_dataArray.Add(new MapPickupsItem(330, LocalStringManager.GetConfig("MapPickups_language", "Name_330"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_330"), 0, new byte[15]
		{
			1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 19 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_330"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_330_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_330_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_330_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_330_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_330_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_330_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Weapon", 286, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Weapon", 655, 1),
			new PresetItemWithCount("Weapon", 664, 1),
			new PresetItemWithCount("Weapon", 682, 1),
			new PresetItemWithCount("Weapon", 700, 1)
		}));
		_dataArray.Add(new MapPickupsItem(331, LocalStringManager.GetConfig("MapPickups_language", "Name_331"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_331"), 0, new byte[15]
		{
			1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 19 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(1, 50), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_331"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_331_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_331_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_331_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_331_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_331_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_331_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>
		{
			default(ResourceInfo),
			new ResourceInfo(7, 1000)
		}, new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Clothing", 18, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(332, LocalStringManager.GetConfig("MapPickups_language", "Name_332"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_332"), 0, new byte[15]
		{
			1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 19 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(1, 100), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_332"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_332_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_332_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_332_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_332_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_332_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_332_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>
		{
			default(ResourceInfo),
			new ResourceInfo(7, 2000)
		}, new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Clothing", 19, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(333, LocalStringManager.GetConfig("MapPickups_language", "Name_333"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_333"), 0, new byte[15]
		{
			1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 19 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(1, 200), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_333"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_333_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_333_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_333_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_333_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_333_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_333_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>
		{
			default(ResourceInfo),
			new ResourceInfo(7, 3000)
		}, new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Clothing", 20, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(334, LocalStringManager.GetConfig("MapPickups_language", "Name_334"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_334"), 0, new byte[15]
		{
			1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 19 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(1, 300), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_334"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_334_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_334_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_334_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_334_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_334_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_334_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int> { -1, 5000 }, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("SkillBook", 148, 1),
			new PresetItemWithCount("SkillBook", 149, 1),
			new PresetItemWithCount("SkillBook", 150, 1),
			new PresetItemWithCount("SkillBook", 258, 1),
			new PresetItemWithCount("SkillBook", 259, 1),
			new PresetItemWithCount("SkillBook", 260, 1),
			new PresetItemWithCount("SkillBook", 353, 1),
			new PresetItemWithCount("SkillBook", 354, 1),
			new PresetItemWithCount("SkillBook", 355, 1),
			new PresetItemWithCount("SkillBook", 473, 1),
			new PresetItemWithCount("SkillBook", 474, 1),
			new PresetItemWithCount("SkillBook", 475, 1),
			new PresetItemWithCount("SkillBook", 552, 1),
			new PresetItemWithCount("SkillBook", 553, 1),
			new PresetItemWithCount("SkillBook", 554, 1),
			new PresetItemWithCount("SkillBook", 776, 1),
			new PresetItemWithCount("SkillBook", 777, 1),
			new PresetItemWithCount("SkillBook", 778, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(335, LocalStringManager.GetConfig("MapPickups_language", "Name_335"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_335"), 0, new byte[15]
		{
			1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 19 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(1, 500), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_335"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_335_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_335_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_335_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_335_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_335_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_335_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int> { -1, 10000 }, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("SkillBook", 151, 1),
			new PresetItemWithCount("SkillBook", 152, 1),
			new PresetItemWithCount("SkillBook", 153, 1),
			new PresetItemWithCount("SkillBook", 261, 1),
			new PresetItemWithCount("SkillBook", 262, 1),
			new PresetItemWithCount("SkillBook", 263, 1),
			new PresetItemWithCount("SkillBook", 356, 1),
			new PresetItemWithCount("SkillBook", 357, 1),
			new PresetItemWithCount("SkillBook", 358, 1),
			new PresetItemWithCount("SkillBook", 476, 1),
			new PresetItemWithCount("SkillBook", 477, 1),
			new PresetItemWithCount("SkillBook", 478, 1),
			new PresetItemWithCount("SkillBook", 555, 1),
			new PresetItemWithCount("SkillBook", 556, 1),
			new PresetItemWithCount("SkillBook", 557, 1),
			new PresetItemWithCount("SkillBook", 779, 1),
			new PresetItemWithCount("SkillBook", 780, 1),
			new PresetItemWithCount("SkillBook", 781, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(336, LocalStringManager.GetConfig("MapPickups_language", "Name_336"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_336"), 0, new byte[15]
		{
			0, 1, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 19 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(1, 1000), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_336"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_336_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_336_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_336_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_336_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_336_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_336_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int> { -1, 20000 }, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("SkillBook", 154, 1),
			new PresetItemWithCount("SkillBook", 155, 1),
			new PresetItemWithCount("SkillBook", 359, 1),
			new PresetItemWithCount("SkillBook", 360, 1),
			new PresetItemWithCount("SkillBook", 479, 1),
			new PresetItemWithCount("SkillBook", 480, 1),
			new PresetItemWithCount("SkillBook", 782, 1),
			new PresetItemWithCount("SkillBook", 783, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(337, LocalStringManager.GetConfig("MapPickups_language", "Name_337"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_337"), 0, new byte[15]
		{
			0, 1, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 20 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_337"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_337_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_337_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_337_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_337_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_337_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_337_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Accessory", 121, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Accessory", 211, 1)
		}));
		_dataArray.Add(new MapPickupsItem(338, LocalStringManager.GetConfig("MapPickups_language", "Name_338"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_338"), 0, new byte[15]
		{
			0, 1, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 20 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_338"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_338_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_338_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_338_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_338_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_338_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_338_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Armor", 346, 1),
			new PresetItemWithCount("Armor", 373, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Armor", 355, 1),
			new PresetItemWithCount("Armor", 364, 1)
		}));
		_dataArray.Add(new MapPickupsItem(339, LocalStringManager.GetConfig("MapPickups_language", "Name_339"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_339"), 0, new byte[15]
		{
			0, 1, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 20 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_339"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_339_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_339_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_339_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_339_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_339_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_339_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Weapon", 331, 1),
			new PresetItemWithCount("Weapon", 151, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Weapon", 484, 1),
			new PresetItemWithCount("Weapon", 466, 1),
			new PresetItemWithCount("Weapon", 439, 1)
		}));
		_dataArray.Add(new MapPickupsItem(340, LocalStringManager.GetConfig("MapPickups_language", "Name_340"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_340"), 0, new byte[15]
		{
			0, 1, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 20 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(2, 50), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_340"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_340_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_340_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_340_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_340_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_340_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_340_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>
		{
			default(ResourceInfo),
			new ResourceInfo(7, 1000)
		}, new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Clothing", 21, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(341, LocalStringManager.GetConfig("MapPickups_language", "Name_341"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_341"), 0, new byte[15]
		{
			0, 1, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 20 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(2, 100), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_341"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_341_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_341_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_341_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_341_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_341_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_341_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>
		{
			default(ResourceInfo),
			new ResourceInfo(7, 2000)
		}, new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Clothing", 22, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(342, LocalStringManager.GetConfig("MapPickups_language", "Name_342"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_342"), 0, new byte[15]
		{
			0, 1, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 20 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(2, 200), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_342"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_342_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_342_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_342_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_342_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_342_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_342_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>
		{
			default(ResourceInfo),
			new ResourceInfo(7, 3000)
		}, new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Clothing", 23, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(343, LocalStringManager.GetConfig("MapPickups_language", "Name_343"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_343"), 0, new byte[15]
		{
			0, 1, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 20 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(2, 300), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_343"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_343_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_343_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_343_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_343_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_343_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_343_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int> { -1, 5000 }, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("SkillBook", 157, 1),
			new PresetItemWithCount("SkillBook", 158, 1),
			new PresetItemWithCount("SkillBook", 159, 1),
			new PresetItemWithCount("SkillBook", 264, 1),
			new PresetItemWithCount("SkillBook", 265, 1),
			new PresetItemWithCount("SkillBook", 266, 1),
			new PresetItemWithCount("SkillBook", 362, 1),
			new PresetItemWithCount("SkillBook", 363, 1),
			new PresetItemWithCount("SkillBook", 364, 1),
			new PresetItemWithCount("SkillBook", 481, 1),
			new PresetItemWithCount("SkillBook", 482, 1),
			new PresetItemWithCount("SkillBook", 483, 1),
			new PresetItemWithCount("SkillBook", 558, 1),
			new PresetItemWithCount("SkillBook", 559, 1),
			new PresetItemWithCount("SkillBook", 560, 1),
			new PresetItemWithCount("SkillBook", 678, 1),
			new PresetItemWithCount("SkillBook", 679, 1),
			new PresetItemWithCount("SkillBook", 680, 1),
			new PresetItemWithCount("SkillBook", 802, 1),
			new PresetItemWithCount("SkillBook", 803, 1),
			new PresetItemWithCount("SkillBook", 804, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(344, LocalStringManager.GetConfig("MapPickups_language", "Name_344"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_344"), 0, new byte[15]
		{
			0, 1, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 20 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(2, 500), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_344"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_344_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_344_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_344_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_344_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_344_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_344_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int> { -1, 10000 }, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("SkillBook", 160, 1),
			new PresetItemWithCount("SkillBook", 161, 1),
			new PresetItemWithCount("SkillBook", 162, 1),
			new PresetItemWithCount("SkillBook", 267, 1),
			new PresetItemWithCount("SkillBook", 268, 1),
			new PresetItemWithCount("SkillBook", 269, 1),
			new PresetItemWithCount("SkillBook", 365, 1),
			new PresetItemWithCount("SkillBook", 366, 1),
			new PresetItemWithCount("SkillBook", 367, 1),
			new PresetItemWithCount("SkillBook", 484, 1),
			new PresetItemWithCount("SkillBook", 485, 1),
			new PresetItemWithCount("SkillBook", 486, 1),
			new PresetItemWithCount("SkillBook", 561, 1),
			new PresetItemWithCount("SkillBook", 562, 1),
			new PresetItemWithCount("SkillBook", 563, 1),
			new PresetItemWithCount("SkillBook", 681, 1),
			new PresetItemWithCount("SkillBook", 682, 1),
			new PresetItemWithCount("SkillBook", 683, 1),
			new PresetItemWithCount("SkillBook", 805, 1),
			new PresetItemWithCount("SkillBook", 806, 1),
			new PresetItemWithCount("SkillBook", 807, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(345, LocalStringManager.GetConfig("MapPickups_language", "Name_345"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_345"), 0, new byte[15]
		{
			0, 1, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 20 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(2, 1000), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_345"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_345_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_345_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_345_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_345_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_345_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_345_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int> { -1, 20000 }, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("SkillBook", 163, 1),
			new PresetItemWithCount("SkillBook", 164, 1),
			new PresetItemWithCount("SkillBook", 270, 1),
			new PresetItemWithCount("SkillBook", 368, 1),
			new PresetItemWithCount("SkillBook", 369, 1),
			new PresetItemWithCount("SkillBook", 487, 1),
			new PresetItemWithCount("SkillBook", 564, 1),
			new PresetItemWithCount("SkillBook", 565, 1),
			new PresetItemWithCount("SkillBook", 684, 1),
			new PresetItemWithCount("SkillBook", 808, 1),
			new PresetItemWithCount("SkillBook", 809, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(346, LocalStringManager.GetConfig("MapPickups_language", "Name_346"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_346"), 0, new byte[15]
		{
			0, 0, 1, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 21 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_346"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_346_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_346_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_346_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_346_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_346_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_346_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Accessory", 130, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Accessory", 175, 1)
		}));
		_dataArray.Add(new MapPickupsItem(347, LocalStringManager.GetConfig("MapPickups_language", "Name_347"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_347"), 0, new byte[15]
		{
			0, 0, 1, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 21 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_347"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_347_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_347_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_347_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_347_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_347_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_347_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Armor", 472, 1),
			new PresetItemWithCount("Armor", 481, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Armor", 490, 1),
			new PresetItemWithCount("Armor", 499, 1)
		}));
		_dataArray.Add(new MapPickupsItem(348, LocalStringManager.GetConfig("MapPickups_language", "Name_348"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_348"), 0, new byte[15]
		{
			0, 0, 1, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 21 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_348"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_348_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_348_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_348_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_348_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_348_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_348_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Weapon", 88, 1),
			new PresetItemWithCount("Weapon", 97, 1),
			new PresetItemWithCount("Weapon", 106, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Weapon", 259, 1),
			new PresetItemWithCount("Weapon", 367, 1)
		}));
		_dataArray.Add(new MapPickupsItem(349, LocalStringManager.GetConfig("MapPickups_language", "Name_349"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_349"), 0, new byte[15]
		{
			0, 0, 1, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 21 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(3, 50), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_349"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_349_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_349_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_349_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_349_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_349_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_349_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>
		{
			default(ResourceInfo),
			new ResourceInfo(7, 1000)
		}, new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Clothing", 24, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(350, LocalStringManager.GetConfig("MapPickups_language", "Name_350"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_350"), 0, new byte[15]
		{
			0, 0, 1, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 21 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(3, 100), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_350"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_350_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_350_1")
		}, new string[3]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_350_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_350_1"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_350_2")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_350_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_350_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>
		{
			default(ResourceInfo),
			new ResourceInfo(7, 2000)
		}, new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Clothing", 25, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(351, LocalStringManager.GetConfig("MapPickups_language", "Name_351"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_351"), 0, new byte[15]
		{
			0, 0, 1, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 21 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(3, 200), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_351"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_351_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_351_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_351_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_351_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_351_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_351_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>
		{
			default(ResourceInfo),
			new ResourceInfo(7, 3000)
		}, new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Clothing", 26, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(352, LocalStringManager.GetConfig("MapPickups_language", "Name_352"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_352"), 0, new byte[15]
		{
			0, 0, 1, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 21 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(3, 300), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_352"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_352_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_352_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_352_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_352_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_352_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_352_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int> { -1, 5000 }, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("SkillBook", 166, 1),
			new PresetItemWithCount("SkillBook", 167, 1),
			new PresetItemWithCount("SkillBook", 271, 1),
			new PresetItemWithCount("SkillBook", 272, 1),
			new PresetItemWithCount("SkillBook", 273, 1),
			new PresetItemWithCount("SkillBook", 371, 1),
			new PresetItemWithCount("SkillBook", 372, 1),
			new PresetItemWithCount("SkillBook", 373, 1),
			new PresetItemWithCount("SkillBook", 567, 1),
			new PresetItemWithCount("SkillBook", 568, 1),
			new PresetItemWithCount("SkillBook", 569, 1),
			new PresetItemWithCount("SkillBook", 844, 1),
			new PresetItemWithCount("SkillBook", 845, 1),
			new PresetItemWithCount("SkillBook", 846, 1),
			new PresetItemWithCount("SkillBook", 862, 1),
			new PresetItemWithCount("SkillBook", 863, 1),
			new PresetItemWithCount("SkillBook", 864, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(353, LocalStringManager.GetConfig("MapPickups_language", "Name_353"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_353"), 0, new byte[15]
		{
			0, 0, 1, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 21 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(3, 500), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_353"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_353_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_353_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_353_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_353_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_353_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_353_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int> { -1, 10000 }, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("SkillBook", 168, 1),
			new PresetItemWithCount("SkillBook", 169, 1),
			new PresetItemWithCount("SkillBook", 274, 1),
			new PresetItemWithCount("SkillBook", 275, 1),
			new PresetItemWithCount("SkillBook", 276, 1),
			new PresetItemWithCount("SkillBook", 374, 1),
			new PresetItemWithCount("SkillBook", 375, 1),
			new PresetItemWithCount("SkillBook", 376, 1),
			new PresetItemWithCount("SkillBook", 570, 1),
			new PresetItemWithCount("SkillBook", 571, 1),
			new PresetItemWithCount("SkillBook", 572, 1),
			new PresetItemWithCount("SkillBook", 847, 1),
			new PresetItemWithCount("SkillBook", 848, 1),
			new PresetItemWithCount("SkillBook", 849, 1),
			new PresetItemWithCount("SkillBook", 865, 1),
			new PresetItemWithCount("SkillBook", 866, 1),
			new PresetItemWithCount("SkillBook", 867, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(354, LocalStringManager.GetConfig("MapPickups_language", "Name_354"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_354"), 0, new byte[15]
		{
			0, 0, 1, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 21 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(3, 1000), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_354"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_354_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_354_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_354_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_354_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_354_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_354_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int> { -1, 20000 }, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("SkillBook", 277, 1),
			new PresetItemWithCount("SkillBook", 278, 1),
			new PresetItemWithCount("SkillBook", 377, 1),
			new PresetItemWithCount("SkillBook", 378, 1),
			new PresetItemWithCount("SkillBook", 573, 1),
			new PresetItemWithCount("SkillBook", 574, 1),
			new PresetItemWithCount("SkillBook", 850, 1),
			new PresetItemWithCount("SkillBook", 851, 1),
			new PresetItemWithCount("SkillBook", 868, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(355, LocalStringManager.GetConfig("MapPickups_language", "Name_355"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_355"), 0, new byte[15]
		{
			0, 0, 0, 1, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 22 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_355"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_355_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_355_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_355_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_355_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_355_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_355_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Accessory", 220, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Accessory", 175, 1)
		}));
		_dataArray.Add(new MapPickupsItem(356, LocalStringManager.GetConfig("MapPickups_language", "Name_356"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_356"), 0, new byte[15]
		{
			0, 0, 0, 1, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 22 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_356"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_356_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_356_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_356_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_356_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_356_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_356_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Armor", 40, 1),
			new PresetItemWithCount("Armor", 49, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Armor", 58, 1),
			new PresetItemWithCount("Armor", 67, 1)
		}));
		_dataArray.Add(new MapPickupsItem(357, LocalStringManager.GetConfig("MapPickups_language", "Name_357"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_357"), 0, new byte[15]
		{
			0, 0, 0, 1, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 22 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_357"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_357_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_357_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_357_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_357_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_357_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_357_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Weapon", 493, 1),
			new PresetItemWithCount("Weapon", 484, 1),
			new PresetItemWithCount("Weapon", 457, 1),
			new PresetItemWithCount("Weapon", 439, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Weapon", 790, 1),
			new PresetItemWithCount("Weapon", 781, 1),
			new PresetItemWithCount("Weapon", 358, 1)
		}));
		_dataArray.Add(new MapPickupsItem(358, LocalStringManager.GetConfig("MapPickups_language", "Name_358"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_358"), 0, new byte[15]
		{
			0, 0, 0, 1, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 22 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(4, 50), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_358"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_358_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_358_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_358_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_358_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_358_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_358_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>
		{
			default(ResourceInfo),
			new ResourceInfo(7, 1000)
		}, new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Clothing", 27, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(359, LocalStringManager.GetConfig("MapPickups_language", "Name_359"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_359"), 0, new byte[15]
		{
			0, 0, 0, 1, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 22 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(4, 100), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_359"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_359_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_359_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_359_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_359_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_359_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_359_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>
		{
			default(ResourceInfo),
			new ResourceInfo(7, 2000)
		}, new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Clothing", 28, 1)
		}, new List<PresetItemWithCount>()));
	}

	private void CreateItems6()
	{
		_dataArray.Add(new MapPickupsItem(360, LocalStringManager.GetConfig("MapPickups_language", "Name_360"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_360"), 0, new byte[15]
		{
			0, 0, 0, 1, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 22 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(4, 200), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_360"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_360_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_360_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_360_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_360_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_360_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_360_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>
		{
			default(ResourceInfo),
			new ResourceInfo(7, 3000)
		}, new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Clothing", 29, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(361, LocalStringManager.GetConfig("MapPickups_language", "Name_361"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_361"), 0, new byte[15]
		{
			0, 0, 0, 1, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 22 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(4, 300), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_361"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_361_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_361_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_361_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_361_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_361_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_361_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int> { -1, 5000 }, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("SkillBook", 170, 1),
			new PresetItemWithCount("SkillBook", 171, 1),
			new PresetItemWithCount("SkillBook", 172, 1),
			new PresetItemWithCount("SkillBook", 279, 1),
			new PresetItemWithCount("SkillBook", 280, 1),
			new PresetItemWithCount("SkillBook", 281, 1),
			new PresetItemWithCount("SkillBook", 380, 1),
			new PresetItemWithCount("SkillBook", 381, 1),
			new PresetItemWithCount("SkillBook", 382, 1),
			new PresetItemWithCount("SkillBook", 488, 1),
			new PresetItemWithCount("SkillBook", 489, 1),
			new PresetItemWithCount("SkillBook", 490, 1),
			new PresetItemWithCount("SkillBook", 685, 1),
			new PresetItemWithCount("SkillBook", 686, 1),
			new PresetItemWithCount("SkillBook", 687, 1),
			new PresetItemWithCount("SkillBook", 827, 1),
			new PresetItemWithCount("SkillBook", 828, 1),
			new PresetItemWithCount("SkillBook", 829, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(362, LocalStringManager.GetConfig("MapPickups_language", "Name_362"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_362"), 0, new byte[15]
		{
			0, 0, 0, 1, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 22 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(4, 500), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_362"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_362_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_362_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_362_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_362_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_362_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_362_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int> { -1, 10000 }, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("SkillBook", 173, 1),
			new PresetItemWithCount("SkillBook", 174, 1),
			new PresetItemWithCount("SkillBook", 175, 1),
			new PresetItemWithCount("SkillBook", 282, 1),
			new PresetItemWithCount("SkillBook", 283, 1),
			new PresetItemWithCount("SkillBook", 284, 1),
			new PresetItemWithCount("SkillBook", 383, 1),
			new PresetItemWithCount("SkillBook", 384, 1),
			new PresetItemWithCount("SkillBook", 385, 1),
			new PresetItemWithCount("SkillBook", 491, 1),
			new PresetItemWithCount("SkillBook", 492, 1),
			new PresetItemWithCount("SkillBook", 493, 1),
			new PresetItemWithCount("SkillBook", 688, 1),
			new PresetItemWithCount("SkillBook", 689, 1),
			new PresetItemWithCount("SkillBook", 690, 1),
			new PresetItemWithCount("SkillBook", 830, 1),
			new PresetItemWithCount("SkillBook", 831, 1),
			new PresetItemWithCount("SkillBook", 832, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(363, LocalStringManager.GetConfig("MapPickups_language", "Name_363"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_363"), 0, new byte[15]
		{
			0, 0, 0, 1, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 22 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(4, 1000), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_363"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_363_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_363_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_363_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_363_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_363_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_363_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int> { -1, 20000 }, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("SkillBook", 176, 1),
			new PresetItemWithCount("SkillBook", 177, 1),
			new PresetItemWithCount("SkillBook", 285, 1),
			new PresetItemWithCount("SkillBook", 386, 1),
			new PresetItemWithCount("SkillBook", 387, 1),
			new PresetItemWithCount("SkillBook", 494, 1),
			new PresetItemWithCount("SkillBook", 495, 1),
			new PresetItemWithCount("SkillBook", 691, 1),
			new PresetItemWithCount("SkillBook", 692, 1),
			new PresetItemWithCount("SkillBook", 833, 1),
			new PresetItemWithCount("SkillBook", 834, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(364, LocalStringManager.GetConfig("MapPickups_language", "Name_364"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_364"), 0, new byte[15]
		{
			0, 0, 0, 0, 1, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 23 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_364"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_364_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_364_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_364_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_364_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_364_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_364_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Accessory", 157, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Accessory", 184, 1)
		}));
		_dataArray.Add(new MapPickupsItem(365, LocalStringManager.GetConfig("MapPickups_language", "Name_365"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_365"), 0, new byte[15]
		{
			0, 0, 0, 0, 1, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 23 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_365"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_365_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_365_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_365_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_365_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_365_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_365_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Armor", 238, 1),
			new PresetItemWithCount("Armor", 139, 1),
			new PresetItemWithCount("Armor", 130, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Armor", 157, 1),
			new PresetItemWithCount("Armor", 148, 1)
		}));
		_dataArray.Add(new MapPickupsItem(366, LocalStringManager.GetConfig("MapPickups_language", "Name_366"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_366"), 0, new byte[15]
		{
			0, 0, 0, 0, 1, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 23 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_366"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_366_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_366_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_366_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_366_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_366_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_366_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Weapon", 529, 1),
			new PresetItemWithCount("Weapon", 574, 1),
			new PresetItemWithCount("Weapon", 583, 1),
			new PresetItemWithCount("Weapon", 592, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Weapon", 457, 1),
			new PresetItemWithCount("Weapon", 475, 1),
			new PresetItemWithCount("Weapon", 502, 1)
		}));
		_dataArray.Add(new MapPickupsItem(367, LocalStringManager.GetConfig("MapPickups_language", "Name_367"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_367"), 0, new byte[15]
		{
			0, 0, 0, 0, 1, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 23 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(5, 50), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_367"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_367_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_367_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_367_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_367_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_367_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_367_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>
		{
			default(ResourceInfo),
			new ResourceInfo(7, 1000)
		}, new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Clothing", 31, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(368, LocalStringManager.GetConfig("MapPickups_language", "Name_368"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_368"), 0, new byte[15]
		{
			0, 0, 0, 0, 1, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 23 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(5, 100), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_368"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_368_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_368_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_368_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_368_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_368_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_368_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>
		{
			default(ResourceInfo),
			new ResourceInfo(7, 2000)
		}, new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Clothing", 32, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(369, LocalStringManager.GetConfig("MapPickups_language", "Name_369"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_369"), 0, new byte[15]
		{
			0, 0, 0, 0, 1, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 23 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(5, 200), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_369"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_369_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_369_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_369_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_369_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_369_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_369_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>
		{
			default(ResourceInfo),
			new ResourceInfo(7, 3000)
		}, new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Clothing", 33, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(370, LocalStringManager.GetConfig("MapPickups_language", "Name_370"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_370"), 0, new byte[15]
		{
			0, 0, 0, 0, 1, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 23 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(5, 300), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_370"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_370_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_370_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_370_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_370_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_370_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_370_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int> { -1, 5000 }, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("SkillBook", 179, 1),
			new PresetItemWithCount("SkillBook", 180, 1),
			new PresetItemWithCount("SkillBook", 181, 1),
			new PresetItemWithCount("SkillBook", 286, 1),
			new PresetItemWithCount("SkillBook", 287, 1),
			new PresetItemWithCount("SkillBook", 288, 1),
			new PresetItemWithCount("SkillBook", 388, 1),
			new PresetItemWithCount("SkillBook", 389, 1),
			new PresetItemWithCount("SkillBook", 390, 1),
			new PresetItemWithCount("SkillBook", 622, 1),
			new PresetItemWithCount("SkillBook", 623, 1),
			new PresetItemWithCount("SkillBook", 624, 1),
			new PresetItemWithCount("SkillBook", 694, 1),
			new PresetItemWithCount("SkillBook", 695, 1),
			new PresetItemWithCount("SkillBook", 696, 1),
			new PresetItemWithCount("SkillBook", 734, 1),
			new PresetItemWithCount("SkillBook", 735, 1),
			new PresetItemWithCount("SkillBook", 736, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(371, LocalStringManager.GetConfig("MapPickups_language", "Name_371"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_371"), 0, new byte[15]
		{
			0, 0, 0, 0, 1, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 23 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(5, 500), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_371"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_371_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_371_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_371_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_371_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_371_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_371_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int> { -1, 10000 }, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("SkillBook", 182, 1),
			new PresetItemWithCount("SkillBook", 183, 1),
			new PresetItemWithCount("SkillBook", 289, 1),
			new PresetItemWithCount("SkillBook", 391, 1),
			new PresetItemWithCount("SkillBook", 392, 1),
			new PresetItemWithCount("SkillBook", 393, 1),
			new PresetItemWithCount("SkillBook", 625, 1),
			new PresetItemWithCount("SkillBook", 626, 1),
			new PresetItemWithCount("SkillBook", 627, 1),
			new PresetItemWithCount("SkillBook", 697, 1),
			new PresetItemWithCount("SkillBook", 698, 1),
			new PresetItemWithCount("SkillBook", 699, 1),
			new PresetItemWithCount("SkillBook", 737, 1),
			new PresetItemWithCount("SkillBook", 738, 1),
			new PresetItemWithCount("SkillBook", 739, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(372, LocalStringManager.GetConfig("MapPickups_language", "Name_372"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_372"), 0, new byte[15]
		{
			0, 0, 0, 0, 1, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 23 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(5, 1000), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_372"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_372_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_372_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_372_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_372_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_372_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_372_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int> { -1, 20000 }, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("SkillBook", 394, 1),
			new PresetItemWithCount("SkillBook", 628, 1),
			new PresetItemWithCount("SkillBook", 629, 1),
			new PresetItemWithCount("SkillBook", 700, 1),
			new PresetItemWithCount("SkillBook", 701, 1),
			new PresetItemWithCount("SkillBook", 740, 1),
			new PresetItemWithCount("SkillBook", 741, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(373, LocalStringManager.GetConfig("MapPickups_language", "Name_373"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_373"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 1, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 24 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_373"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_373_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_373_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_373_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_373_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_373_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_373_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Accessory", 103, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Accessory", 157, 1)
		}));
		_dataArray.Add(new MapPickupsItem(374, LocalStringManager.GetConfig("MapPickups_language", "Name_374"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_374"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 1, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 24 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_374"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_374_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_374_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_374_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_374_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_374_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_374_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Armor", 256, 1),
			new PresetItemWithCount("Armor", 274, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Armor", 391, 1),
			new PresetItemWithCount("Armor", 382, 1)
		}));
		_dataArray.Add(new MapPickupsItem(375, LocalStringManager.GetConfig("MapPickups_language", "Name_375"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_375"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 1, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 24 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_375"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_375_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_375_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_375_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_375_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_375_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_375_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Weapon", 646, 1),
			new PresetItemWithCount("Weapon", 628, 1),
			new PresetItemWithCount("Weapon", 286, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Weapon", 565, 1),
			new PresetItemWithCount("Weapon", 556, 1),
			new PresetItemWithCount("Weapon", 547, 1),
			new PresetItemWithCount("Weapon", 529, 1)
		}));
		_dataArray.Add(new MapPickupsItem(376, LocalStringManager.GetConfig("MapPickups_language", "Name_376"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_376"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 1, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 24 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(6, 50), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_376"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_376_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_376_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_376_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_376_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_376_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_376_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>
		{
			default(ResourceInfo),
			new ResourceInfo(7, 1000)
		}, new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Clothing", 34, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(377, LocalStringManager.GetConfig("MapPickups_language", "Name_377"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_377"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 1, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 24 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(6, 100), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_377"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_377_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_377_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_377_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_377_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_377_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_377_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>
		{
			default(ResourceInfo),
			new ResourceInfo(7, 2000)
		}, new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Clothing", 35, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(378, LocalStringManager.GetConfig("MapPickups_language", "Name_378"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_378"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 1, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 24 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(6, 200), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_378"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_378_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_378_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_378_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_378_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_378_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_378_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>
		{
			default(ResourceInfo),
			new ResourceInfo(7, 3000)
		}, new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Clothing", 36, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(379, LocalStringManager.GetConfig("MapPickups_language", "Name_379"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_379"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 1, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 24 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(6, 300), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_379"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_379_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_379_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_379_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_379_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_379_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_379_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int> { -1, 5000 }, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("SkillBook", 184, 1),
			new PresetItemWithCount("SkillBook", 185, 1),
			new PresetItemWithCount("SkillBook", 186, 1),
			new PresetItemWithCount("SkillBook", 290, 1),
			new PresetItemWithCount("SkillBook", 291, 1),
			new PresetItemWithCount("SkillBook", 292, 1),
			new PresetItemWithCount("SkillBook", 395, 1),
			new PresetItemWithCount("SkillBook", 396, 1),
			new PresetItemWithCount("SkillBook", 397, 1),
			new PresetItemWithCount("SkillBook", 497, 1),
			new PresetItemWithCount("SkillBook", 498, 1),
			new PresetItemWithCount("SkillBook", 499, 1),
			new PresetItemWithCount("SkillBook", 742, 1),
			new PresetItemWithCount("SkillBook", 743, 1),
			new PresetItemWithCount("SkillBook", 744, 1),
			new PresetItemWithCount("SkillBook", 785, 1),
			new PresetItemWithCount("SkillBook", 786, 1),
			new PresetItemWithCount("SkillBook", 787, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(380, LocalStringManager.GetConfig("MapPickups_language", "Name_380"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_380"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 1, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 24 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(6, 500), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_380"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_380_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_380_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_380_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_380_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_380_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_380_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int> { -1, 10000 }, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("SkillBook", 187, 1),
			new PresetItemWithCount("SkillBook", 293, 1),
			new PresetItemWithCount("SkillBook", 398, 1),
			new PresetItemWithCount("SkillBook", 399, 1),
			new PresetItemWithCount("SkillBook", 400, 1),
			new PresetItemWithCount("SkillBook", 500, 1),
			new PresetItemWithCount("SkillBook", 501, 1),
			new PresetItemWithCount("SkillBook", 502, 1),
			new PresetItemWithCount("SkillBook", 745, 1),
			new PresetItemWithCount("SkillBook", 746, 1),
			new PresetItemWithCount("SkillBook", 747, 1),
			new PresetItemWithCount("SkillBook", 788, 1),
			new PresetItemWithCount("SkillBook", 789, 1),
			new PresetItemWithCount("SkillBook", 790, 1),
			new PresetItemWithCount("SkillBook", 188, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(381, LocalStringManager.GetConfig("MapPickups_language", "Name_381"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_381"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 1, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 24 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(6, 1000), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_381"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_381_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_381_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_381_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_381_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_381_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_381_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int> { -1, 20000 }, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("SkillBook", 503, 1),
			new PresetItemWithCount("SkillBook", 504, 1),
			new PresetItemWithCount("SkillBook", 748, 1),
			new PresetItemWithCount("SkillBook", 749, 1),
			new PresetItemWithCount("SkillBook", 791, 1),
			new PresetItemWithCount("SkillBook", 792, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(382, LocalStringManager.GetConfig("MapPickups_language", "Name_382"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_382"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 1, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 25 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_382"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_382_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_382_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_382_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_382_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_382_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_382_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Accessory", 148, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Accessory", 166, 1)
		}));
		_dataArray.Add(new MapPickupsItem(383, LocalStringManager.GetConfig("MapPickups_language", "Name_383"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_383"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 1, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 25 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_383"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_383_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_383_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_383_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_383_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_383_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_383_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Armor", 31, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Armor", 13, 1),
			new PresetItemWithCount("Armor", 121, 1)
		}));
		_dataArray.Add(new MapPickupsItem(384, LocalStringManager.GetConfig("MapPickups_language", "Name_384"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_384"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 1, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 25 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_384"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_384_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_384_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_384_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_384_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_384_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_384_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Weapon", 313, 1),
			new PresetItemWithCount("Weapon", 52, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Weapon", 520, 1),
			new PresetItemWithCount("Weapon", 502, 1)
		}));
		_dataArray.Add(new MapPickupsItem(385, LocalStringManager.GetConfig("MapPickups_language", "Name_385"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_385"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 1, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 25 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(7, 50), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_385"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_385_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_385_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_385_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_385_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_385_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_385_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>
		{
			default(ResourceInfo),
			new ResourceInfo(7, 1000)
		}, new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Clothing", 37, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(386, LocalStringManager.GetConfig("MapPickups_language", "Name_386"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_386"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 1, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 25 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(7, 100), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_386"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_386_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_386_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_386_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_386_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_386_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_386_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>
		{
			default(ResourceInfo),
			new ResourceInfo(7, 2000)
		}, new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Clothing", 38, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(387, LocalStringManager.GetConfig("MapPickups_language", "Name_387"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_387"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 1, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 25 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(7, 200), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_387"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_387_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_387_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_387_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_387_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_387_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_387_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>
		{
			default(ResourceInfo),
			new ResourceInfo(7, 3000)
		}, new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Clothing", 39, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(388, LocalStringManager.GetConfig("MapPickups_language", "Name_388"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_388"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 1, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 25 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(7, 300), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_388"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_388_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_388_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_388_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_388_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_388_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_388_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int> { -1, 5000 }, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("SkillBook", 189, 1),
			new PresetItemWithCount("SkillBook", 190, 1),
			new PresetItemWithCount("SkillBook", 191, 1),
			new PresetItemWithCount("SkillBook", 294, 1),
			new PresetItemWithCount("SkillBook", 295, 1),
			new PresetItemWithCount("SkillBook", 296, 1),
			new PresetItemWithCount("SkillBook", 401, 1),
			new PresetItemWithCount("SkillBook", 402, 1),
			new PresetItemWithCount("SkillBook", 403, 1),
			new PresetItemWithCount("SkillBook", 576, 1),
			new PresetItemWithCount("SkillBook", 577, 1),
			new PresetItemWithCount("SkillBook", 578, 1),
			new PresetItemWithCount("SkillBook", 702, 1),
			new PresetItemWithCount("SkillBook", 703, 1),
			new PresetItemWithCount("SkillBook", 704, 1),
			new PresetItemWithCount("SkillBook", 810, 1),
			new PresetItemWithCount("SkillBook", 811, 1),
			new PresetItemWithCount("SkillBook", 812, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(389, LocalStringManager.GetConfig("MapPickups_language", "Name_389"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_389"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 1, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 25 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(7, 500), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_389"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_389_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_389_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_389_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_389_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_389_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_389_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int> { -1, 10000 }, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("SkillBook", 192, 1),
			new PresetItemWithCount("SkillBook", 193, 1),
			new PresetItemWithCount("SkillBook", 194, 1),
			new PresetItemWithCount("SkillBook", 297, 1),
			new PresetItemWithCount("SkillBook", 298, 1),
			new PresetItemWithCount("SkillBook", 299, 1),
			new PresetItemWithCount("SkillBook", 404, 1),
			new PresetItemWithCount("SkillBook", 405, 1),
			new PresetItemWithCount("SkillBook", 406, 1),
			new PresetItemWithCount("SkillBook", 579, 1),
			new PresetItemWithCount("SkillBook", 580, 1),
			new PresetItemWithCount("SkillBook", 581, 1),
			new PresetItemWithCount("SkillBook", 705, 1),
			new PresetItemWithCount("SkillBook", 706, 1),
			new PresetItemWithCount("SkillBook", 707, 1),
			new PresetItemWithCount("SkillBook", 813, 1),
			new PresetItemWithCount("SkillBook", 814, 1),
			new PresetItemWithCount("SkillBook", 815, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(390, LocalStringManager.GetConfig("MapPickups_language", "Name_390"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_390"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 1, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 25 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(7, 1000), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_390"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_390_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_390_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_390_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_390_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_390_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_390_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int> { -1, 20000 }, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("SkillBook", 195, 1),
			new PresetItemWithCount("SkillBook", 196, 1),
			new PresetItemWithCount("SkillBook", 300, 1),
			new PresetItemWithCount("SkillBook", 407, 1),
			new PresetItemWithCount("SkillBook", 408, 1),
			new PresetItemWithCount("SkillBook", 582, 1),
			new PresetItemWithCount("SkillBook", 708, 1),
			new PresetItemWithCount("SkillBook", 709, 1),
			new PresetItemWithCount("SkillBook", 816, 1),
			new PresetItemWithCount("SkillBook", 817, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(391, LocalStringManager.GetConfig("MapPickups_language", "Name_391"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_391"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 1, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 26 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_391"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_391_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_391_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_391_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_391_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_391_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_391_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Accessory", 85, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Accessory", 175, 1)
		}));
		_dataArray.Add(new MapPickupsItem(392, LocalStringManager.GetConfig("MapPickups_language", "Name_392"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_392"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 1, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 26 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_392"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_392_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_392_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_392_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_392_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_392_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_392_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Armor", 76, 1),
			new PresetItemWithCount("Armor", 103, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Armor", 94, 1),
			new PresetItemWithCount("Armor", 85, 1)
		}));
		_dataArray.Add(new MapPickupsItem(393, LocalStringManager.GetConfig("MapPickups_language", "Name_393"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_393"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 1, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 26 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_393"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_393_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_393_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_393_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_393_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_393_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_393_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Weapon", 340, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Weapon", 745, 1)
		}));
		_dataArray.Add(new MapPickupsItem(394, LocalStringManager.GetConfig("MapPickups_language", "Name_394"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_394"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 1, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 26 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(8, 50), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_394"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_394_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_394_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_394_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_394_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_394_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_394_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>
		{
			default(ResourceInfo),
			new ResourceInfo(7, 1000)
		}, new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Clothing", 40, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(395, LocalStringManager.GetConfig("MapPickups_language", "Name_395"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_395"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 1, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 26 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(8, 100), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_395"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_395_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_395_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_395_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_395_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_395_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_395_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>
		{
			default(ResourceInfo),
			new ResourceInfo(7, 2000)
		}, new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Clothing", 41, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(396, LocalStringManager.GetConfig("MapPickups_language", "Name_396"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_396"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 1, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 26 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(8, 200), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_396"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_396_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_396_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_396_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_396_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_396_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_396_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>
		{
			default(ResourceInfo),
			new ResourceInfo(7, 3000)
		}, new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Clothing", 42, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(397, LocalStringManager.GetConfig("MapPickups_language", "Name_397"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_397"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 1, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 26 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(8, 300), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_397"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_397_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_397_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_397_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_397_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_397_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_397_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int> { -1, 5000 }, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("SkillBook", 198, 1),
			new PresetItemWithCount("SkillBook", 199, 1),
			new PresetItemWithCount("SkillBook", 200, 1),
			new PresetItemWithCount("SkillBook", 301, 1),
			new PresetItemWithCount("SkillBook", 302, 1),
			new PresetItemWithCount("SkillBook", 303, 1),
			new PresetItemWithCount("SkillBook", 409, 1),
			new PresetItemWithCount("SkillBook", 410, 1),
			new PresetItemWithCount("SkillBook", 411, 1),
			new PresetItemWithCount("SkillBook", 506, 1),
			new PresetItemWithCount("SkillBook", 507, 1),
			new PresetItemWithCount("SkillBook", 508, 1),
			new PresetItemWithCount("SkillBook", 583, 1),
			new PresetItemWithCount("SkillBook", 584, 1),
			new PresetItemWithCount("SkillBook", 585, 1),
			new PresetItemWithCount("SkillBook", 869, 1),
			new PresetItemWithCount("SkillBook", 870, 1),
			new PresetItemWithCount("SkillBook", 871, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(398, LocalStringManager.GetConfig("MapPickups_language", "Name_398"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_398"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 1, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 26 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(8, 500), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_398"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_398_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_398_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_398_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_398_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_398_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_398_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int> { -1, 10000 }, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("SkillBook", 201, 1),
			new PresetItemWithCount("SkillBook", 202, 1),
			new PresetItemWithCount("SkillBook", 203, 1),
			new PresetItemWithCount("SkillBook", 304, 1),
			new PresetItemWithCount("SkillBook", 305, 1),
			new PresetItemWithCount("SkillBook", 306, 1),
			new PresetItemWithCount("SkillBook", 412, 1),
			new PresetItemWithCount("SkillBook", 413, 1),
			new PresetItemWithCount("SkillBook", 414, 1),
			new PresetItemWithCount("SkillBook", 509, 1),
			new PresetItemWithCount("SkillBook", 510, 1),
			new PresetItemWithCount("SkillBook", 511, 1),
			new PresetItemWithCount("SkillBook", 586, 1),
			new PresetItemWithCount("SkillBook", 587, 1),
			new PresetItemWithCount("SkillBook", 588, 1),
			new PresetItemWithCount("SkillBook", 872, 1),
			new PresetItemWithCount("SkillBook", 873, 1),
			new PresetItemWithCount("SkillBook", 874, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(399, LocalStringManager.GetConfig("MapPickups_language", "Name_399"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_399"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 1, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 26 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(8, 1000), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_399"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_399_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_399_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_399_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_399_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_399_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_399_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int> { -1, 20000 }, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("SkillBook", 204, 1),
			new PresetItemWithCount("SkillBook", 205, 1),
			new PresetItemWithCount("SkillBook", 307, 1),
			new PresetItemWithCount("SkillBook", 308, 1),
			new PresetItemWithCount("SkillBook", 415, 1),
			new PresetItemWithCount("SkillBook", 512, 1),
			new PresetItemWithCount("SkillBook", 589, 1),
			new PresetItemWithCount("SkillBook", 590, 1),
			new PresetItemWithCount("SkillBook", 875, 1),
			new PresetItemWithCount("SkillBook", 876, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(400, LocalStringManager.GetConfig("MapPickups_language", "Name_400"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_400"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 1, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 27 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_400"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_400_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_400_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_400_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_400_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_400_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_400_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Accessory", 193, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Accessory", 112, 1)
		}));
		_dataArray.Add(new MapPickupsItem(401, LocalStringManager.GetConfig("MapPickups_language", "Name_401"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_401"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 1, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 27 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_401"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_401_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_401_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_401_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_401_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_401_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_401_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Armor", 283, 1),
			new PresetItemWithCount("Armor", 265, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Armor", 391, 1),
			new PresetItemWithCount("Armor", 292, 1)
		}));
		_dataArray.Add(new MapPickupsItem(402, LocalStringManager.GetConfig("MapPickups_language", "Name_402"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_402"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 1, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 27 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_402"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_402_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_402_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_402_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_402_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_402_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_402_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Weapon", 439, 1),
			new PresetItemWithCount("Weapon", 448, 1),
			new PresetItemWithCount("Weapon", 457, 1),
			new PresetItemWithCount("Weapon", 466, 1),
			new PresetItemWithCount("Weapon", 475, 1),
			new PresetItemWithCount("Weapon", 484, 1),
			new PresetItemWithCount("Weapon", 529, 1),
			new PresetItemWithCount("Weapon", 538, 1),
			new PresetItemWithCount("Weapon", 547, 1),
			new PresetItemWithCount("Weapon", 556, 1),
			new PresetItemWithCount("Weapon", 565, 1),
			new PresetItemWithCount("Weapon", 574, 1),
			new PresetItemWithCount("Weapon", 619, 1),
			new PresetItemWithCount("Weapon", 637, 1),
			new PresetItemWithCount("Weapon", 655, 1),
			new PresetItemWithCount("Weapon", 664, 1),
			new PresetItemWithCount("Weapon", 673, 1),
			new PresetItemWithCount("Weapon", 691, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Weapon", 34, 1),
			new PresetItemWithCount("Weapon", 25, 1)
		}));
		_dataArray.Add(new MapPickupsItem(403, LocalStringManager.GetConfig("MapPickups_language", "Name_403"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_403"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 1, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 27 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(9, 50), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_403"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_403_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_403_1")
		}, new string[1] { LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_403_0") }, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_403_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_403_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>
		{
			default(ResourceInfo),
			new ResourceInfo(7, 1000)
		}, new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Clothing", 43, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(404, LocalStringManager.GetConfig("MapPickups_language", "Name_404"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_404"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 1, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 27 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(9, 100), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_404"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_404_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_404_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_404_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_404_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_404_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_404_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>
		{
			default(ResourceInfo),
			new ResourceInfo(7, 2000)
		}, new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Clothing", 44, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(405, LocalStringManager.GetConfig("MapPickups_language", "Name_405"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_405"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 1, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 27 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(9, 200), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_405"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_405_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_405_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_405_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_405_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_405_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_405_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>
		{
			default(ResourceInfo),
			new ResourceInfo(7, 3000)
		}, new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Clothing", 45, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(406, LocalStringManager.GetConfig("MapPickups_language", "Name_406"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_406"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 1, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 27 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(9, 300), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_406"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_406_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_406_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_406_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_406_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_406_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_406_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int> { -1, 5000 }, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("SkillBook", 207, 1),
			new PresetItemWithCount("SkillBook", 208, 1),
			new PresetItemWithCount("SkillBook", 209, 1),
			new PresetItemWithCount("SkillBook", 310, 1),
			new PresetItemWithCount("SkillBook", 311, 1),
			new PresetItemWithCount("SkillBook", 312, 1),
			new PresetItemWithCount("SkillBook", 416, 1),
			new PresetItemWithCount("SkillBook", 417, 1),
			new PresetItemWithCount("SkillBook", 418, 1),
			new PresetItemWithCount("SkillBook", 711, 1),
			new PresetItemWithCount("SkillBook", 712, 1),
			new PresetItemWithCount("SkillBook", 713, 1),
			new PresetItemWithCount("SkillBook", 751, 1),
			new PresetItemWithCount("SkillBook", 752, 1),
			new PresetItemWithCount("SkillBook", 753, 1),
			new PresetItemWithCount("SkillBook", 794, 1),
			new PresetItemWithCount("SkillBook", 795, 1),
			new PresetItemWithCount("SkillBook", 796, 1),
			new PresetItemWithCount("SkillBook", 853, 1),
			new PresetItemWithCount("SkillBook", 854, 1),
			new PresetItemWithCount("SkillBook", 855, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(407, LocalStringManager.GetConfig("MapPickups_language", "Name_407"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_407"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 1, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 27 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(9, 500), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_407"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_407_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_407_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_407_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_407_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_407_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_407_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int> { -1, 10000 }, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("SkillBook", 210, 1),
			new PresetItemWithCount("SkillBook", 211, 1),
			new PresetItemWithCount("SkillBook", 313, 1),
			new PresetItemWithCount("SkillBook", 314, 1),
			new PresetItemWithCount("SkillBook", 315, 1),
			new PresetItemWithCount("SkillBook", 419, 1),
			new PresetItemWithCount("SkillBook", 420, 1),
			new PresetItemWithCount("SkillBook", 421, 1),
			new PresetItemWithCount("SkillBook", 714, 1),
			new PresetItemWithCount("SkillBook", 715, 1),
			new PresetItemWithCount("SkillBook", 716, 1),
			new PresetItemWithCount("SkillBook", 754, 1),
			new PresetItemWithCount("SkillBook", 755, 1),
			new PresetItemWithCount("SkillBook", 756, 1),
			new PresetItemWithCount("SkillBook", 797, 1),
			new PresetItemWithCount("SkillBook", 798, 1),
			new PresetItemWithCount("SkillBook", 799, 1),
			new PresetItemWithCount("SkillBook", 856, 1),
			new PresetItemWithCount("SkillBook", 857, 1),
			new PresetItemWithCount("SkillBook", 858, 1),
			new PresetItemWithCount("SkillBook", 212, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(408, LocalStringManager.GetConfig("MapPickups_language", "Name_408"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_408"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 1, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 27 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(9, 1000), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_408"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_408_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_408_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_408_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_408_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_408_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_408_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int> { -1, 20000 }, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("SkillBook", 316, 1),
			new PresetItemWithCount("SkillBook", 422, 1),
			new PresetItemWithCount("SkillBook", 717, 1),
			new PresetItemWithCount("SkillBook", 718, 1),
			new PresetItemWithCount("SkillBook", 757, 1),
			new PresetItemWithCount("SkillBook", 758, 1),
			new PresetItemWithCount("SkillBook", 800, 1),
			new PresetItemWithCount("SkillBook", 801, 1),
			new PresetItemWithCount("SkillBook", 859, 1),
			new PresetItemWithCount("SkillBook", 860, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(409, LocalStringManager.GetConfig("MapPickups_language", "Name_409"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_409"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
			0, 0, 0, 0, 0
		}, new List<short> { 28 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_409"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_409_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_409_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_409_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_409_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_409_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_409_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Accessory", 148, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Accessory", 112, 1)
		}));
		_dataArray.Add(new MapPickupsItem(410, LocalStringManager.GetConfig("MapPickups_language", "Name_410"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_410"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
			0, 0, 0, 0, 0
		}, new List<short> { 28 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_410"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_410_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_410_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_410_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_410_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_410_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_410_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Armor", 184, 1),
			new PresetItemWithCount("Armor", 166, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Armor", 193, 1),
			new PresetItemWithCount("Armor", 175, 1)
		}));
		_dataArray.Add(new MapPickupsItem(411, LocalStringManager.GetConfig("MapPickups_language", "Name_411"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_411"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
			0, 0, 0, 0, 0
		}, new List<short> { 28 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_411"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_411_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_411_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_411_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_411_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_411_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_411_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Weapon", 7, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Weapon", 277, 1)
		}));
		_dataArray.Add(new MapPickupsItem(412, LocalStringManager.GetConfig("MapPickups_language", "Name_412"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_412"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
			0, 0, 0, 0, 0
		}, new List<short> { 28 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(10, 50), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_412"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_412_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_412_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_412_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_412_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_412_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_412_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>
		{
			default(ResourceInfo),
			new ResourceInfo(7, 1000)
		}, new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Clothing", 46, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(413, LocalStringManager.GetConfig("MapPickups_language", "Name_413"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_413"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
			0, 0, 0, 0, 0
		}, new List<short> { 28 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(10, 100), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_413"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_413_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_413_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_413_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_413_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_413_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_413_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>
		{
			default(ResourceInfo),
			new ResourceInfo(7, 2000)
		}, new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Clothing", 47, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(414, LocalStringManager.GetConfig("MapPickups_language", "Name_414"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_414"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
			0, 0, 0, 0, 0
		}, new List<short> { 28 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(10, 200), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_414"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_414_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_414_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_414_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_414_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_414_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_414_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>
		{
			default(ResourceInfo),
			new ResourceInfo(7, 3000)
		}, new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Clothing", 48, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(415, LocalStringManager.GetConfig("MapPickups_language", "Name_415"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_415"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
			0, 0, 0, 0, 0
		}, new List<short> { 28 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(10, 300), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_415"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_415_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_415_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_415_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_415_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_415_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_415_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int> { -1, 5000 }, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("SkillBook", 213, 1),
			new PresetItemWithCount("SkillBook", 214, 1),
			new PresetItemWithCount("SkillBook", 215, 1),
			new PresetItemWithCount("SkillBook", 317, 1),
			new PresetItemWithCount("SkillBook", 318, 1),
			new PresetItemWithCount("SkillBook", 319, 1),
			new PresetItemWithCount("SkillBook", 423, 1),
			new PresetItemWithCount("SkillBook", 424, 1),
			new PresetItemWithCount("SkillBook", 425, 1),
			new PresetItemWithCount("SkillBook", 513, 1),
			new PresetItemWithCount("SkillBook", 514, 1),
			new PresetItemWithCount("SkillBook", 515, 1),
			new PresetItemWithCount("SkillBook", 591, 1),
			new PresetItemWithCount("SkillBook", 592, 1),
			new PresetItemWithCount("SkillBook", 593, 1),
			new PresetItemWithCount("SkillBook", 631, 1),
			new PresetItemWithCount("SkillBook", 632, 1),
			new PresetItemWithCount("SkillBook", 633, 1),
			new PresetItemWithCount("SkillBook", 647, 1),
			new PresetItemWithCount("SkillBook", 648, 1),
			new PresetItemWithCount("SkillBook", 649, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(416, LocalStringManager.GetConfig("MapPickups_language", "Name_416"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_416"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
			0, 0, 0, 0, 0
		}, new List<short> { 28 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(10, 500), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_416"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_416_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_416_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_416_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_416_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_416_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_416_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int> { -1, 10000 }, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("SkillBook", 216, 1),
			new PresetItemWithCount("SkillBook", 217, 1),
			new PresetItemWithCount("SkillBook", 320, 1),
			new PresetItemWithCount("SkillBook", 321, 1),
			new PresetItemWithCount("SkillBook", 426, 1),
			new PresetItemWithCount("SkillBook", 427, 1),
			new PresetItemWithCount("SkillBook", 428, 1),
			new PresetItemWithCount("SkillBook", 516, 1),
			new PresetItemWithCount("SkillBook", 517, 1),
			new PresetItemWithCount("SkillBook", 518, 1),
			new PresetItemWithCount("SkillBook", 594, 1),
			new PresetItemWithCount("SkillBook", 595, 1),
			new PresetItemWithCount("SkillBook", 596, 1),
			new PresetItemWithCount("SkillBook", 634, 1),
			new PresetItemWithCount("SkillBook", 635, 1),
			new PresetItemWithCount("SkillBook", 636, 1),
			new PresetItemWithCount("SkillBook", 650, 1),
			new PresetItemWithCount("SkillBook", 651, 1),
			new PresetItemWithCount("SkillBook", 652, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(417, LocalStringManager.GetConfig("MapPickups_language", "Name_417"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_417"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
			0, 0, 0, 0, 0
		}, new List<short> { 28 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(10, 1000), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_417"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_417_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_417_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_417_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_417_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_417_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_417_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int> { -1, 20000 }, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("SkillBook", 429, 1),
			new PresetItemWithCount("SkillBook", 430, 1),
			new PresetItemWithCount("SkillBook", 637, 1),
			new PresetItemWithCount("SkillBook", 638, 1),
			new PresetItemWithCount("SkillBook", 653, 1),
			new PresetItemWithCount("SkillBook", 654, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(418, LocalStringManager.GetConfig("MapPickups_language", "Name_418"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_418"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			1, 0, 0, 0, 0
		}, new List<short> { 29 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_418"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_418_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_418_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_418_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_418_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_418_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_418_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Accessory", 202, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Accessory", 103, 1)
		}));
		_dataArray.Add(new MapPickupsItem(419, LocalStringManager.GetConfig("MapPickups_language", "Name_419"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_419"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			1, 0, 0, 0, 0
		}, new List<short> { 29 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_419"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_419_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_419_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_419_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_419_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_419_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_419_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Armor", 4, 1),
			new PresetItemWithCount("Armor", 112, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Armor", 22, 1)
		}));
	}

	private void CreateItems7()
	{
		_dataArray.Add(new MapPickupsItem(420, LocalStringManager.GetConfig("MapPickups_language", "Name_420"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_420"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			1, 0, 0, 0, 0
		}, new List<short> { 29 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_420"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_420_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_420_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_420_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_420_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_420_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_420_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Weapon", 412, 1),
			new PresetItemWithCount("Weapon", 394, 1),
			new PresetItemWithCount("Weapon", 385, 1),
			new PresetItemWithCount("Weapon", 286, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Weapon", 574, 1),
			new PresetItemWithCount("Weapon", 556, 1),
			new PresetItemWithCount("Weapon", 538, 1),
			new PresetItemWithCount("Weapon", 529, 1)
		}));
		_dataArray.Add(new MapPickupsItem(421, LocalStringManager.GetConfig("MapPickups_language", "Name_421"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_421"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			1, 0, 0, 0, 0
		}, new List<short> { 29 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(11, 50), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_421"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_421_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_421_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_421_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_421_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_421_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_421_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>
		{
			default(ResourceInfo),
			new ResourceInfo(7, 1000)
		}, new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Clothing", 49, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(422, LocalStringManager.GetConfig("MapPickups_language", "Name_422"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_422"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			1, 0, 0, 0, 0
		}, new List<short> { 29 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(11, 100), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_422"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_422_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_422_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_422_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_422_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_422_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_422_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>
		{
			default(ResourceInfo),
			new ResourceInfo(7, 2000)
		}, new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Clothing", 50, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(423, LocalStringManager.GetConfig("MapPickups_language", "Name_423"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_423"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			1, 0, 0, 0, 0
		}, new List<short> { 29 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(11, 200), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_423"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_423_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_423_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_423_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_423_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_423_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_423_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>
		{
			default(ResourceInfo),
			new ResourceInfo(7, 3000)
		}, new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Clothing", 51, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(424, LocalStringManager.GetConfig("MapPickups_language", "Name_424"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_424"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			1, 0, 0, 0, 0
		}, new List<short> { 29 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(11, 300), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_424"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_424_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_424_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_424_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_424_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_424_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_424_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int> { -1, 5000 }, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("SkillBook", 218, 1),
			new PresetItemWithCount("SkillBook", 219, 1),
			new PresetItemWithCount("SkillBook", 220, 1),
			new PresetItemWithCount("SkillBook", 322, 1),
			new PresetItemWithCount("SkillBook", 323, 1),
			new PresetItemWithCount("SkillBook", 324, 1),
			new PresetItemWithCount("SkillBook", 432, 1),
			new PresetItemWithCount("SkillBook", 433, 1),
			new PresetItemWithCount("SkillBook", 434, 1),
			new PresetItemWithCount("SkillBook", 519, 1),
			new PresetItemWithCount("SkillBook", 520, 1),
			new PresetItemWithCount("SkillBook", 521, 1),
			new PresetItemWithCount("SkillBook", 759, 1),
			new PresetItemWithCount("SkillBook", 760, 1),
			new PresetItemWithCount("SkillBook", 761, 1),
			new PresetItemWithCount("SkillBook", 819, 1),
			new PresetItemWithCount("SkillBook", 820, 1),
			new PresetItemWithCount("SkillBook", 821, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(425, LocalStringManager.GetConfig("MapPickups_language", "Name_425"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_425"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			1, 0, 0, 0, 0
		}, new List<short> { 29 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(11, 500), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_425"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_425_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_425_1")
		}, new string[1] { LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_425_0") }, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_425_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_425_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int> { -1, 10000 }, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("SkillBook", 221, 1),
			new PresetItemWithCount("SkillBook", 222, 1),
			new PresetItemWithCount("SkillBook", 223, 1),
			new PresetItemWithCount("SkillBook", 325, 1),
			new PresetItemWithCount("SkillBook", 435, 1),
			new PresetItemWithCount("SkillBook", 436, 1),
			new PresetItemWithCount("SkillBook", 437, 1),
			new PresetItemWithCount("SkillBook", 522, 1),
			new PresetItemWithCount("SkillBook", 523, 1),
			new PresetItemWithCount("SkillBook", 524, 1),
			new PresetItemWithCount("SkillBook", 762, 1),
			new PresetItemWithCount("SkillBook", 763, 1),
			new PresetItemWithCount("SkillBook", 764, 1),
			new PresetItemWithCount("SkillBook", 822, 1),
			new PresetItemWithCount("SkillBook", 823, 1),
			new PresetItemWithCount("SkillBook", 824, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(426, LocalStringManager.GetConfig("MapPickups_language", "Name_426"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_426"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			1, 0, 0, 0, 0
		}, new List<short> { 29 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(11, 1000), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_426"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_426_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_426_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_426_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_426_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_426_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_426_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int> { -1, 20000 }, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("SkillBook", 224, 1),
			new PresetItemWithCount("SkillBook", 225, 1),
			new PresetItemWithCount("SkillBook", 438, 1),
			new PresetItemWithCount("SkillBook", 439, 1),
			new PresetItemWithCount("SkillBook", 525, 1),
			new PresetItemWithCount("SkillBook", 526, 1),
			new PresetItemWithCount("SkillBook", 765, 1),
			new PresetItemWithCount("SkillBook", 766, 1),
			new PresetItemWithCount("SkillBook", 825, 1),
			new PresetItemWithCount("SkillBook", 826, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(427, LocalStringManager.GetConfig("MapPickups_language", "Name_427"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_427"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 1, 0, 0, 0
		}, new List<short> { 30 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_427"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_427_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_427_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_427_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_427_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_427_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_427_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Accessory", 139, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Accessory", 121, 1)
		}));
		_dataArray.Add(new MapPickupsItem(428, LocalStringManager.GetConfig("MapPickups_language", "Name_428"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_428"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 1, 0, 0, 0
		}, new List<short> { 30 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_428"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_428_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_428_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_428_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_428_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_428_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_428_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Armor", 517, 1),
			new PresetItemWithCount("Armor", 409, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Armor", 427, 1)
		}));
		_dataArray.Add(new MapPickupsItem(429, LocalStringManager.GetConfig("MapPickups_language", "Name_429"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_429"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 1, 0, 0, 0
		}, new List<short> { 30 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_429"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_429_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_429_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_429_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_429_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_429_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_429_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Weapon", 817, 1),
			new PresetItemWithCount("Weapon", 799, 1),
			new PresetItemWithCount("Weapon", 376, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Weapon", 502, 1),
			new PresetItemWithCount("Weapon", 493, 1),
			new PresetItemWithCount("Weapon", 484, 1)
		}));
		_dataArray.Add(new MapPickupsItem(430, LocalStringManager.GetConfig("MapPickups_language", "Name_430"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_430"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 1, 0, 0, 0
		}, new List<short> { 30 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(12, 50), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_430"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_430_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_430_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_430_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_430_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_430_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_430_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>
		{
			default(ResourceInfo),
			new ResourceInfo(7, 1000)
		}, new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Clothing", 52, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(431, LocalStringManager.GetConfig("MapPickups_language", "Name_431"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_431"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 1, 0, 0, 0
		}, new List<short> { 30 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(12, 100), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_431"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_431_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_431_1")
		}, new string[3]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_431_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_431_1"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_431_2")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_431_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_431_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>
		{
			default(ResourceInfo),
			new ResourceInfo(7, 2000)
		}, new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Clothing", 53, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(432, LocalStringManager.GetConfig("MapPickups_language", "Name_432"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_432"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 1, 0, 0, 0
		}, new List<short> { 30 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(12, 200), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_432"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_432_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_432_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_432_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_432_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_432_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_432_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>
		{
			default(ResourceInfo),
			new ResourceInfo(7, 3000)
		}, new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Clothing", 54, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(433, LocalStringManager.GetConfig("MapPickups_language", "Name_433"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_433"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 1, 0, 0, 0
		}, new List<short> { 30 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(12, 300), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_433"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_433_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_433_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_433_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_433_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_433_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_433_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int> { -1, 5000 }, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("SkillBook", 227, 1),
			new PresetItemWithCount("SkillBook", 228, 1),
			new PresetItemWithCount("SkillBook", 229, 1),
			new PresetItemWithCount("SkillBook", 326, 1),
			new PresetItemWithCount("SkillBook", 327, 1),
			new PresetItemWithCount("SkillBook", 328, 1),
			new PresetItemWithCount("SkillBook", 440, 1),
			new PresetItemWithCount("SkillBook", 441, 1),
			new PresetItemWithCount("SkillBook", 442, 1),
			new PresetItemWithCount("SkillBook", 527, 1),
			new PresetItemWithCount("SkillBook", 528, 1),
			new PresetItemWithCount("SkillBook", 529, 1),
			new PresetItemWithCount("SkillBook", 597, 1),
			new PresetItemWithCount("SkillBook", 598, 1),
			new PresetItemWithCount("SkillBook", 599, 1),
			new PresetItemWithCount("SkillBook", 719, 1),
			new PresetItemWithCount("SkillBook", 720, 1),
			new PresetItemWithCount("SkillBook", 721, 1),
			new PresetItemWithCount("SkillBook", 835, 1),
			new PresetItemWithCount("SkillBook", 836, 1),
			new PresetItemWithCount("SkillBook", 837, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(434, LocalStringManager.GetConfig("MapPickups_language", "Name_434"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_434"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 1, 0, 0, 0
		}, new List<short> { 30 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(12, 500), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_434"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_434_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_434_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_434_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_434_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_434_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_434_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int> { -1, 10000 }, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("SkillBook", 230, 1),
			new PresetItemWithCount("SkillBook", 231, 1),
			new PresetItemWithCount("SkillBook", 232, 1),
			new PresetItemWithCount("SkillBook", 329, 1),
			new PresetItemWithCount("SkillBook", 330, 1),
			new PresetItemWithCount("SkillBook", 331, 1),
			new PresetItemWithCount("SkillBook", 443, 1),
			new PresetItemWithCount("SkillBook", 444, 1),
			new PresetItemWithCount("SkillBook", 445, 1),
			new PresetItemWithCount("SkillBook", 530, 1),
			new PresetItemWithCount("SkillBook", 531, 1),
			new PresetItemWithCount("SkillBook", 532, 1),
			new PresetItemWithCount("SkillBook", 600, 1),
			new PresetItemWithCount("SkillBook", 601, 1),
			new PresetItemWithCount("SkillBook", 602, 1),
			new PresetItemWithCount("SkillBook", 722, 1),
			new PresetItemWithCount("SkillBook", 723, 1),
			new PresetItemWithCount("SkillBook", 724, 1),
			new PresetItemWithCount("SkillBook", 838, 1),
			new PresetItemWithCount("SkillBook", 839, 1),
			new PresetItemWithCount("SkillBook", 840, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(435, LocalStringManager.GetConfig("MapPickups_language", "Name_435"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_435"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 1, 0, 0, 0
		}, new List<short> { 30 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(12, 1000), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_435"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_435_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_435_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_435_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_435_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_435_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_435_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int> { -1, 20000 }, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("SkillBook", 233, 1),
			new PresetItemWithCount("SkillBook", 332, 1),
			new PresetItemWithCount("SkillBook", 446, 1),
			new PresetItemWithCount("SkillBook", 447, 1),
			new PresetItemWithCount("SkillBook", 533, 1),
			new PresetItemWithCount("SkillBook", 534, 1),
			new PresetItemWithCount("SkillBook", 603, 1),
			new PresetItemWithCount("SkillBook", 604, 1),
			new PresetItemWithCount("SkillBook", 725, 1),
			new PresetItemWithCount("SkillBook", 841, 1),
			new PresetItemWithCount("SkillBook", 842, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(436, LocalStringManager.GetConfig("MapPickups_language", "Name_436"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_436"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 1, 0, 0
		}, new List<short> { 31 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_436"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_436_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_436_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_436_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_436_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_436_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_436_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Accessory", 139, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Accessory", 121, 1)
		}));
		_dataArray.Add(new MapPickupsItem(437, LocalStringManager.GetConfig("MapPickups_language", "Name_437"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_437"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 1, 0, 0
		}, new List<short> { 31 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_437"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_437_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_437_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_437_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_437_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_437_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_437_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Armor", 436, 1),
			new PresetItemWithCount("Armor", 445, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Armor", 454, 1),
			new PresetItemWithCount("Armor", 463, 1)
		}));
		_dataArray.Add(new MapPickupsItem(438, LocalStringManager.GetConfig("MapPickups_language", "Name_438"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_438"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 1, 0, 0
		}, new List<short> { 31 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_438"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_438_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_438_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_438_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_438_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_438_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_438_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Armor", 463, 1),
			new PresetItemWithCount("Armor", 436, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Armor", 445, 1),
			new PresetItemWithCount("Armor", 454, 1)
		}));
		_dataArray.Add(new MapPickupsItem(439, LocalStringManager.GetConfig("MapPickups_language", "Name_439"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_439"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 1, 0, 0
		}, new List<short> { 31 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(13, 50), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_439"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_439_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_439_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_439_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_439_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_439_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_439_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>
		{
			default(ResourceInfo),
			new ResourceInfo(7, 1000)
		}, new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Clothing", 55, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(440, LocalStringManager.GetConfig("MapPickups_language", "Name_440"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_440"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 1, 0, 0
		}, new List<short> { 31 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(13, 100), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_440"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_440_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_440_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_440_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_440_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_440_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_440_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>
		{
			default(ResourceInfo),
			new ResourceInfo(7, 2000)
		}, new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Clothing", 56, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(441, LocalStringManager.GetConfig("MapPickups_language", "Name_441"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_441"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 1, 0, 0
		}, new List<short> { 31 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(13, 200), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_441"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_441_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_441_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_441_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_441_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_441_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_441_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>
		{
			default(ResourceInfo),
			new ResourceInfo(7, 3000)
		}, new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Clothing", 57, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(442, LocalStringManager.GetConfig("MapPickups_language", "Name_442"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_442"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 1, 0, 0
		}, new List<short> { 31 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(13, 300), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_442"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_442_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_442_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_442_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_442_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_442_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_442_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int> { -1, 5000 }, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("SkillBook", 234, 1),
			new PresetItemWithCount("SkillBook", 235, 1),
			new PresetItemWithCount("SkillBook", 236, 1),
			new PresetItemWithCount("SkillBook", 333, 1),
			new PresetItemWithCount("SkillBook", 334, 1),
			new PresetItemWithCount("SkillBook", 335, 1),
			new PresetItemWithCount("SkillBook", 449, 1),
			new PresetItemWithCount("SkillBook", 450, 1),
			new PresetItemWithCount("SkillBook", 451, 1),
			new PresetItemWithCount("SkillBook", 606, 1),
			new PresetItemWithCount("SkillBook", 607, 1),
			new PresetItemWithCount("SkillBook", 608, 1),
			new PresetItemWithCount("SkillBook", 656, 1),
			new PresetItemWithCount("SkillBook", 657, 1),
			new PresetItemWithCount("SkillBook", 658, 1),
			new PresetItemWithCount("SkillBook", 726, 1),
			new PresetItemWithCount("SkillBook", 727, 1),
			new PresetItemWithCount("SkillBook", 728, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(443, LocalStringManager.GetConfig("MapPickups_language", "Name_443"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_443"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 1, 0, 0
		}, new List<short> { 31 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(13, 500), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_443"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_443_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_443_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_443_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_443_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_443_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_443_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int> { -1, 10000 }, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("SkillBook", 237, 1),
			new PresetItemWithCount("SkillBook", 238, 1),
			new PresetItemWithCount("SkillBook", 239, 1),
			new PresetItemWithCount("SkillBook", 336, 1),
			new PresetItemWithCount("SkillBook", 337, 1),
			new PresetItemWithCount("SkillBook", 338, 1),
			new PresetItemWithCount("SkillBook", 452, 1),
			new PresetItemWithCount("SkillBook", 453, 1),
			new PresetItemWithCount("SkillBook", 454, 1),
			new PresetItemWithCount("SkillBook", 609, 1),
			new PresetItemWithCount("SkillBook", 610, 1),
			new PresetItemWithCount("SkillBook", 611, 1),
			new PresetItemWithCount("SkillBook", 659, 1),
			new PresetItemWithCount("SkillBook", 660, 1),
			new PresetItemWithCount("SkillBook", 661, 1),
			new PresetItemWithCount("SkillBook", 729, 1),
			new PresetItemWithCount("SkillBook", 730, 1),
			new PresetItemWithCount("SkillBook", 731, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(444, LocalStringManager.GetConfig("MapPickups_language", "Name_444"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_444"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 1, 0, 0
		}, new List<short> { 31 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(13, 1000), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_444"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_444_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_444_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_444_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_444_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_444_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_444_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int> { -1, 20000 }, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("SkillBook", 240, 1),
			new PresetItemWithCount("SkillBook", 339, 1),
			new PresetItemWithCount("SkillBook", 340, 1),
			new PresetItemWithCount("SkillBook", 455, 1),
			new PresetItemWithCount("SkillBook", 612, 1),
			new PresetItemWithCount("SkillBook", 613, 1),
			new PresetItemWithCount("SkillBook", 662, 1),
			new PresetItemWithCount("SkillBook", 663, 1),
			new PresetItemWithCount("SkillBook", 732, 1),
			new PresetItemWithCount("SkillBook", 733, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(445, LocalStringManager.GetConfig("MapPickups_language", "Name_445"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_445"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 1, 0
		}, new List<short> { 32 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_445"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_445_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_445_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_445_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_445_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_445_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_445_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Accessory", 4, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Accessory", 103, 1)
		}));
		_dataArray.Add(new MapPickupsItem(446, LocalStringManager.GetConfig("MapPickups_language", "Name_446"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_446"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 1, 0
		}, new List<short> { 32 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_446"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_446_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_446_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_446_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_446_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_446_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_446_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Armor", 328, 1),
			new PresetItemWithCount("Armor", 310, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Armor", 337, 1),
			new PresetItemWithCount("Armor", 319, 1)
		}));
		_dataArray.Add(new MapPickupsItem(447, LocalStringManager.GetConfig("MapPickups_language", "Name_447"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_447"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 1, 0
		}, new List<short> { 32 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_447"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_447_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_447_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_447_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_447_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_447_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_447_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Weapon", 169, 1),
			new PresetItemWithCount("Weapon", 349, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Weapon", 565, 1),
			new PresetItemWithCount("Weapon", 547, 1),
			new PresetItemWithCount("Weapon", 529, 1)
		}));
		_dataArray.Add(new MapPickupsItem(448, LocalStringManager.GetConfig("MapPickups_language", "Name_448"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_448"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 1, 0
		}, new List<short> { 32 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(14, 50), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_448"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_448_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_448_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_448_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_448_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_448_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_448_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>
		{
			default(ResourceInfo),
			new ResourceInfo(7, 1000)
		}, new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Clothing", 58, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(449, LocalStringManager.GetConfig("MapPickups_language", "Name_449"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_449"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 1, 0
		}, new List<short> { 32 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(14, 100), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_449"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_449_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_449_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_449_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_449_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_449_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_449_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>
		{
			default(ResourceInfo),
			new ResourceInfo(7, 2000)
		}, new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Clothing", 59, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(450, LocalStringManager.GetConfig("MapPickups_language", "Name_450"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_450"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 1, 0
		}, new List<short> { 32 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(14, 200), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_450"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_450_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_450_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_450_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_450_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_450_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_450_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>
		{
			default(ResourceInfo),
			new ResourceInfo(7, 3000)
		}, new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Clothing", 60, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(451, LocalStringManager.GetConfig("MapPickups_language", "Name_451"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_451"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 1, 0
		}, new List<short> { 32 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(14, 300), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_451"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_451_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_451_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_451_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_451_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_451_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_451_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int> { -1, 5000 }, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("SkillBook", 241, 1),
			new PresetItemWithCount("SkillBook", 242, 1),
			new PresetItemWithCount("SkillBook", 243, 1),
			new PresetItemWithCount("SkillBook", 342, 1),
			new PresetItemWithCount("SkillBook", 343, 1),
			new PresetItemWithCount("SkillBook", 344, 1),
			new PresetItemWithCount("SkillBook", 456, 1),
			new PresetItemWithCount("SkillBook", 457, 1),
			new PresetItemWithCount("SkillBook", 458, 1),
			new PresetItemWithCount("SkillBook", 535, 1),
			new PresetItemWithCount("SkillBook", 536, 1),
			new PresetItemWithCount("SkillBook", 537, 1),
			new PresetItemWithCount("SkillBook", 665, 1),
			new PresetItemWithCount("SkillBook", 666, 1),
			new PresetItemWithCount("SkillBook", 667, 1),
			new PresetItemWithCount("SkillBook", 768, 1),
			new PresetItemWithCount("SkillBook", 769, 1),
			new PresetItemWithCount("SkillBook", 770, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(452, LocalStringManager.GetConfig("MapPickups_language", "Name_452"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_452"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 1, 0
		}, new List<short> { 32 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(14, 500), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_452"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_452_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_452_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_452_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_452_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_452_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_452_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int> { -1, 10000 }, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("SkillBook", 244, 1),
			new PresetItemWithCount("SkillBook", 245, 1),
			new PresetItemWithCount("SkillBook", 246, 1),
			new PresetItemWithCount("SkillBook", 345, 1),
			new PresetItemWithCount("SkillBook", 346, 1),
			new PresetItemWithCount("SkillBook", 347, 1),
			new PresetItemWithCount("SkillBook", 459, 1),
			new PresetItemWithCount("SkillBook", 460, 1),
			new PresetItemWithCount("SkillBook", 461, 1),
			new PresetItemWithCount("SkillBook", 538, 1),
			new PresetItemWithCount("SkillBook", 539, 1),
			new PresetItemWithCount("SkillBook", 540, 1),
			new PresetItemWithCount("SkillBook", 668, 1),
			new PresetItemWithCount("SkillBook", 669, 1),
			new PresetItemWithCount("SkillBook", 670, 1),
			new PresetItemWithCount("SkillBook", 771, 1),
			new PresetItemWithCount("SkillBook", 772, 1),
			new PresetItemWithCount("SkillBook", 773, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(453, LocalStringManager.GetConfig("MapPickups_language", "Name_453"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_453"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 1, 0
		}, new List<short> { 32 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(14, 1000), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_453"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_453_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_453_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_453_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_453_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_453_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_453_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int> { -1, 20000 }, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("SkillBook", 247, 1),
			new PresetItemWithCount("SkillBook", 248, 1),
			new PresetItemWithCount("SkillBook", 462, 1),
			new PresetItemWithCount("SkillBook", 463, 1),
			new PresetItemWithCount("SkillBook", 541, 1),
			new PresetItemWithCount("SkillBook", 542, 1),
			new PresetItemWithCount("SkillBook", 774, 1),
			new PresetItemWithCount("SkillBook", 775, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(454, LocalStringManager.GetConfig("MapPickups_language", "Name_454"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_454"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 1
		}, new List<short> { 33 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_454"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_454_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_454_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_454_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_454_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_454_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_454_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Accessory", 76, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Accessory", 166, 1)
		}));
		_dataArray.Add(new MapPickupsItem(455, LocalStringManager.GetConfig("MapPickups_language", "Name_455"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_455"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 1
		}, new List<short> { 33 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_455"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_455_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_455_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_455_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_455_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_455_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_455_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Armor", 202, 1),
			new PresetItemWithCount("Armor", 211, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Armor", 220, 1),
			new PresetItemWithCount("Armor", 229, 1)
		}));
		_dataArray.Add(new MapPickupsItem(456, LocalStringManager.GetConfig("MapPickups_language", "Name_456"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_456"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 1
		}, new List<short> { 33 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_456"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_456_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_456_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_456_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_456_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_456_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_456_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Weapon", 16, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Weapon", 295, 1)
		}));
		_dataArray.Add(new MapPickupsItem(457, LocalStringManager.GetConfig("MapPickups_language", "Name_457"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_457"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 1
		}, new List<short> { 33 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(15, 50), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_457"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_457_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_457_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_457_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_457_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_457_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_457_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>
		{
			default(ResourceInfo),
			new ResourceInfo(7, 1000)
		}, new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Clothing", 61, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(458, LocalStringManager.GetConfig("MapPickups_language", "Name_458"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_458"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 1
		}, new List<short> { 33 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(15, 100), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_458"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_458_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_458_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_458_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_458_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_458_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_458_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>
		{
			default(ResourceInfo),
			new ResourceInfo(7, 2000)
		}, new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Clothing", 62, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(459, LocalStringManager.GetConfig("MapPickups_language", "Name_459"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_459"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 1
		}, new List<short> { 33 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(15, 200), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_459"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_459_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_459_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_459_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_459_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_459_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_459_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>
		{
			default(ResourceInfo),
			new ResourceInfo(7, 3000)
		}, new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Clothing", 63, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(460, LocalStringManager.GetConfig("MapPickups_language", "Name_460"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_460"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 1
		}, new List<short> { 33 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(15, 300), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_460"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_460_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_460_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_460_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_460_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_460_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_460_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int> { -1, 5000 }, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("SkillBook", 249, 1),
			new PresetItemWithCount("SkillBook", 250, 1),
			new PresetItemWithCount("SkillBook", 251, 1),
			new PresetItemWithCount("SkillBook", 348, 1),
			new PresetItemWithCount("SkillBook", 349, 1),
			new PresetItemWithCount("SkillBook", 350, 1),
			new PresetItemWithCount("SkillBook", 464, 1),
			new PresetItemWithCount("SkillBook", 465, 1),
			new PresetItemWithCount("SkillBook", 466, 1),
			new PresetItemWithCount("SkillBook", 544, 1),
			new PresetItemWithCount("SkillBook", 545, 1),
			new PresetItemWithCount("SkillBook", 546, 1),
			new PresetItemWithCount("SkillBook", 615, 1),
			new PresetItemWithCount("SkillBook", 616, 1),
			new PresetItemWithCount("SkillBook", 617, 1),
			new PresetItemWithCount("SkillBook", 639, 1),
			new PresetItemWithCount("SkillBook", 640, 1),
			new PresetItemWithCount("SkillBook", 641, 1),
			new PresetItemWithCount("SkillBook", 671, 1),
			new PresetItemWithCount("SkillBook", 672, 1),
			new PresetItemWithCount("SkillBook", 673, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(461, LocalStringManager.GetConfig("MapPickups_language", "Name_461"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_461"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 1
		}, new List<short> { 33 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(15, 500), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_461"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_461_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_461_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_461_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_461_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_461_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_461_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int> { -1, 10000 }, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("SkillBook", 252, 1),
			new PresetItemWithCount("SkillBook", 253, 1),
			new PresetItemWithCount("SkillBook", 254, 1),
			new PresetItemWithCount("SkillBook", 351, 1),
			new PresetItemWithCount("SkillBook", 352, 1),
			new PresetItemWithCount("SkillBook", 467, 1),
			new PresetItemWithCount("SkillBook", 468, 1),
			new PresetItemWithCount("SkillBook", 469, 1),
			new PresetItemWithCount("SkillBook", 547, 1),
			new PresetItemWithCount("SkillBook", 548, 1),
			new PresetItemWithCount("SkillBook", 549, 1),
			new PresetItemWithCount("SkillBook", 618, 1),
			new PresetItemWithCount("SkillBook", 619, 1),
			new PresetItemWithCount("SkillBook", 620, 1),
			new PresetItemWithCount("SkillBook", 642, 1),
			new PresetItemWithCount("SkillBook", 643, 1),
			new PresetItemWithCount("SkillBook", 644, 1),
			new PresetItemWithCount("SkillBook", 674, 1),
			new PresetItemWithCount("SkillBook", 675, 1),
			new PresetItemWithCount("SkillBook", 676, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(462, LocalStringManager.GetConfig("MapPickups_language", "Name_462"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_462"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 1
		}, new List<short> { 33 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(15, 1000), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_462"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_462_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_462_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_462_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_462_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_462_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_462_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int> { -1, 20000 }, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("SkillBook", 255, 1),
			new PresetItemWithCount("SkillBook", 256, 1),
			new PresetItemWithCount("SkillBook", 470, 1),
			new PresetItemWithCount("SkillBook", 471, 1),
			new PresetItemWithCount("SkillBook", 550, 1),
			new PresetItemWithCount("SkillBook", 551, 1),
			new PresetItemWithCount("SkillBook", 621, 1),
			new PresetItemWithCount("SkillBook", 645, 1),
			new PresetItemWithCount("SkillBook", 646, 1),
			new PresetItemWithCount("SkillBook", 677, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(463, LocalStringManager.GetConfig("MapPickups_language", "Name_463"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_463"), 0, new byte[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 69, 70, 71, 72,
			73, 74, 81, 82, 83, 84, 85, 86, 103, 104,
			105, 106, 107, 108
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			false, true, true, true, false, false, false, false, false, false,
			false, false
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_463"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_463_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_463_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_463_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_463_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_463_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_463_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>
		{
			new PropertyAndValue(37, 5),
			new PropertyAndValue(34, 5)
		}, new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(464, LocalStringManager.GetConfig("MapPickups_language", "Name_464"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_464"), 0, new byte[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			false, true, true, true, false, false, false, false, false, false,
			false, false
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_464"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_464_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_464_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_464_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_464_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_464_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_464_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>
		{
			new PropertyAndValue(34, 5),
			new PropertyAndValue(37, 5)
		}, new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(465, LocalStringManager.GetConfig("MapPickups_language", "Name_465"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_465"), 0, new byte[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			false, true, true, true, false, false, false, false, false, false,
			false, false
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_465"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_465_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_465_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_465_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_465_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_465_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_465_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>
		{
			new PropertyAndValue(48, 5),
			new PropertyAndValue(49, 5)
		}, new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(466, LocalStringManager.GetConfig("MapPickups_language", "Name_466"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_466"), 0, new byte[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			false, true, true, true, false, false, false, false, false, false,
			false, false
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_466"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_466_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_466_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_466_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_466_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_466_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_466_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>
		{
			new PropertyAndValue(38, 5),
			new PropertyAndValue(44, 5)
		}, new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(467, LocalStringManager.GetConfig("MapPickups_language", "Name_467"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_467"), 0, new byte[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new List<short>
		{
			57, 58, 59, 69, 70, 71, 72, 73, 74, 106,
			107, 108
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			false, true, true, true, false, false, false, false, false, false,
			false, false
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_467"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_467_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_467_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_467_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_467_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_467_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_467_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>
		{
			new PropertyAndValue(41, 5),
			new PropertyAndValue(39, 5)
		}, new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(468, LocalStringManager.GetConfig("MapPickups_language", "Name_468"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_468"), 0, new byte[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new List<short>
		{
			42, 43, 44, 69, 70, 71, 78, 79, 80, 87,
			88, 89, 90, 91, 92, 93, 103, 104, 105
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			false, false, false, false, true, true, true, false, false, false,
			false, false
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_468"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_468_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_468_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_468_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_468_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_468_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_468_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("TeaWine", 21, 9),
			new PresetItemWithCount("TeaWine", 22, 3),
			new PresetItemWithCount("TeaWine", 23, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("TeaWine", 30, 9),
			new PresetItemWithCount("TeaWine", 31, 3),
			new PresetItemWithCount("TeaWine", 32, 1)
		}));
		_dataArray.Add(new MapPickupsItem(469, LocalStringManager.GetConfig("MapPickups_language", "Name_469"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_469"), 0, new byte[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 69, 70, 71, 72,
			73, 74, 81, 103, 104, 105, 106, 107, 108
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			false, false, false, false, true, true, true, false, false, false,
			false, false
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_469"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_469_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_469_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_469_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_469_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_469_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_469_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>
		{
			new PropertyAndValue(38, 5),
			new PropertyAndValue(42, 5)
		}, new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(470, LocalStringManager.GetConfig("MapPickups_language", "Name_470"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_470"), 0, new byte[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 57, 58,
			59, 69, 70, 71, 72, 73, 74, 106, 107, 108
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			false, false, false, false, true, true, true, false, false, false,
			false, false
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_470"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_470_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_470_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_470_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_470_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_470_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_470_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>
		{
			new PropertyAndValue(36, 5),
			new PropertyAndValue(45, 5)
		}, new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(471, LocalStringManager.GetConfig("MapPickups_language", "Name_471"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_471"), 0, new byte[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new List<short>
		{
			1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
			11, 12, 13, 14, 15, 34, 35, 36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			false, false, false, false, true, true, true, false, false, false,
			false, false
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_471"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_471_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_471_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_471_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_471_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_471_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_471_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>
		{
			new PropertyAndValue(43, 5),
			new PropertyAndValue(40, 5)
		}, new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(472, LocalStringManager.GetConfig("MapPickups_language", "Name_472"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_472"), 0, new byte[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new List<short> { 97, 98, 99 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			false, false, false, false, true, true, true, false, false, false,
			false, false
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_472"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_472_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_472_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_472_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_472_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_472_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_472_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("TeaWine", 3, 9),
			new PresetItemWithCount("TeaWine", 4, 3),
			new PresetItemWithCount("TeaWine", 5, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("TeaWine", 12, 9),
			new PresetItemWithCount("TeaWine", 13, 3),
			new PresetItemWithCount("TeaWine", 14, 1)
		}));
		_dataArray.Add(new MapPickupsItem(473, LocalStringManager.GetConfig("MapPickups_language", "Name_473"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_473"), 0, new byte[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new List<short>
		{
			42, 43, 44, 81, 82, 83, 84, 85, 86, 94,
			95, 96
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			false, false, false, false, false, false, false, true, true, true,
			false, false
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_473"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_473_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_473_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_473_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_473_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_473_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_473_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>
		{
			new PropertyAndValue(39, 5),
			new PropertyAndValue(35, 5)
		}, new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(474, LocalStringManager.GetConfig("MapPickups_language", "Name_474"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_474"), 0, new byte[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			false, false, false, false, false, false, false, true, true, true,
			false, false
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_474"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_474_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_474_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_474_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_474_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_474_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_474_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>
		{
			new PropertyAndValue(111, 150),
			default(PropertyAndValue)
		}, new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Misc", 18, 50)
		}));
		_dataArray.Add(new MapPickupsItem(475, LocalStringManager.GetConfig("MapPickups_language", "Name_475"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_475"), 0, new byte[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new List<short>
		{
			75, 76, 77, 81, 82, 83, 84, 85, 86, 94,
			95, 96
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			false, false, false, false, false, false, false, true, true, true,
			false, false
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_475"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_475_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_475_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_475_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_475_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_475_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_475_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>
		{
			new PropertyAndValue(35, 5),
			new PropertyAndValue(44, 5)
		}, new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(476, LocalStringManager.GetConfig("MapPickups_language", "Name_476"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_476"), 0, new byte[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 34, 35,
			36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			false, false, false, false, false, false, false, true, true, true,
			false, false
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_476"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_476_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_476_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_476_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_476_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_476_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_476_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>
		{
			new PropertyAndValue(48, 5),
			new PropertyAndValue(41, 5)
		}, new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(477, LocalStringManager.GetConfig("MapPickups_language", "Name_477"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_477"), 0, new byte[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new List<short>
		{
			57, 58, 59, 66, 67, 68, 69, 70, 71, 90,
			91, 92, 106, 107, 108
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			false, false, false, false, false, false, false, true, true, true,
			false, false
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_477"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_477_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_477_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_477_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_477_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_477_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_477_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>
		{
			new PropertyAndValue(40, 5),
			new PropertyAndValue(43, 5)
		}, new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(478, LocalStringManager.GetConfig("MapPickups_language", "Name_478"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_478"), 0, new byte[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new List<short>
		{
			57, 58, 59, 69, 70, 71, 90, 91, 92, 106,
			107, 108
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, false, false, false, false, false, false, false, false, false,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_478"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_478_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_478_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_478_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_478_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_478_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_478_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>
		{
			new PropertyAndValue(42, 5),
			new PropertyAndValue(45, 5)
		}, new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(479, LocalStringManager.GetConfig("MapPickups_language", "Name_479"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_479"), 0, new byte[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new List<short>
		{
			69, 70, 71, 81, 82, 83, 84, 85, 86, 100,
			101, 102
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, false, false, false, false, false, false, false, false, false,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_479"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_479_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_479_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_479_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_479_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_479_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_479_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Material", 140, 9),
			new PresetItemWithCount("Material", 141, 3),
			new PresetItemWithCount("Material", 142, 1),
			new PresetItemWithCount("Material", 144, 9),
			new PresetItemWithCount("Material", 145, 3),
			new PresetItemWithCount("Material", 146, 1),
			new PresetItemWithCount("Material", 148, 9),
			new PresetItemWithCount("Material", 149, 3),
			new PresetItemWithCount("Material", 150, 1),
			new PresetItemWithCount("Material", 152, 9),
			new PresetItemWithCount("Material", 153, 3),
			new PresetItemWithCount("Material", 154, 1),
			new PresetItemWithCount("Material", 176, 9),
			new PresetItemWithCount("Material", 177, 3),
			new PresetItemWithCount("Material", 178, 1),
			new PresetItemWithCount("Material", 180, 9),
			new PresetItemWithCount("Material", 181, 3),
			new PresetItemWithCount("Material", 182, 1),
			new PresetItemWithCount("Material", 184, 9),
			new PresetItemWithCount("Material", 185, 3),
			new PresetItemWithCount("Material", 186, 1),
			new PresetItemWithCount("Material", 188, 9),
			new PresetItemWithCount("Material", 189, 3),
			new PresetItemWithCount("Material", 190, 1),
			new PresetItemWithCount("Material", 208, 9),
			new PresetItemWithCount("Material", 209, 3),
			new PresetItemWithCount("Material", 210, 1),
			new PresetItemWithCount("Material", 212, 9),
			new PresetItemWithCount("Material", 213, 3),
			new PresetItemWithCount("Material", 214, 1),
			new PresetItemWithCount("Material", 220, 9),
			new PresetItemWithCount("Material", 221, 3),
			new PresetItemWithCount("Material", 222, 1),
			new PresetItemWithCount("Material", 232, 9),
			new PresetItemWithCount("Material", 233, 3),
			new PresetItemWithCount("Material", 234, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Material", 192, 9),
			new PresetItemWithCount("Material", 193, 3),
			new PresetItemWithCount("Material", 194, 1),
			new PresetItemWithCount("Material", 196, 9),
			new PresetItemWithCount("Material", 197, 3),
			new PresetItemWithCount("Material", 198, 1),
			new PresetItemWithCount("Material", 200, 9),
			new PresetItemWithCount("Material", 201, 3),
			new PresetItemWithCount("Material", 202, 1),
			new PresetItemWithCount("Material", 204, 9),
			new PresetItemWithCount("Material", 205, 3),
			new PresetItemWithCount("Material", 206, 1),
			new PresetItemWithCount("Material", 216, 9),
			new PresetItemWithCount("Material", 217, 3),
			new PresetItemWithCount("Material", 218, 1),
			new PresetItemWithCount("Material", 224, 9),
			new PresetItemWithCount("Material", 225, 3),
			new PresetItemWithCount("Material", 226, 1),
			new PresetItemWithCount("Material", 228, 9),
			new PresetItemWithCount("Material", 229, 3),
			new PresetItemWithCount("Material", 230, 1),
			new PresetItemWithCount("Material", 156, 9),
			new PresetItemWithCount("Material", 157, 3),
			new PresetItemWithCount("Material", 158, 1),
			new PresetItemWithCount("Material", 160, 9),
			new PresetItemWithCount("Material", 161, 3),
			new PresetItemWithCount("Material", 162, 1),
			new PresetItemWithCount("Material", 164, 9),
			new PresetItemWithCount("Material", 165, 3),
			new PresetItemWithCount("Material", 166, 1),
			new PresetItemWithCount("Material", 168, 9),
			new PresetItemWithCount("Material", 169, 3),
			new PresetItemWithCount("Material", 170, 1),
			new PresetItemWithCount("Material", 172, 9),
			new PresetItemWithCount("Material", 173, 3),
			new PresetItemWithCount("Material", 174, 1)
		}));
	}

	private void CreateItems8()
	{
		_dataArray.Add(new MapPickupsItem(480, LocalStringManager.GetConfig("MapPickups_language", "Name_480"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_480"), 0, new byte[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new List<short>
		{
			1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
			11, 12, 13, 14, 15, 34, 35, 36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, false, false, false, false, false, false, false, false, false,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_480"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_480_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_480_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_480_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_480_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_480_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_480_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>
		{
			new PropertyAndValue(49, 5),
			new PropertyAndValue(36, 5)
		}, new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(481, LocalStringManager.GetConfig("MapPickups_language", "Name_481"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_481"), 0, new byte[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new List<short> { 87, 88, 89, 90, 91, 92, 93, 103, 104, 105 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, false, false, false, false, false, false, false, false, false,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_481"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_481_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_481_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_481_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_481_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_481_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_481_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>
		{
			new PropertyAndValue(47, 5),
			new PropertyAndValue(46, 5)
		}, new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(482, LocalStringManager.GetConfig("MapPickups_language", "Name_482"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_482"), 0, new byte[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new List<short>
		{
			57, 58, 59, 69, 70, 71, 72, 73, 74, 106,
			107, 108
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, false, false, false, false, false, false, false, false, false,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_482"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_482_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_482_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_482_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_482_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_482_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_482_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>
		{
			new PropertyAndValue(47, 5),
			new PropertyAndValue(46, 5)
		}, new List<int>(), new List<int>(), new List<PresetItemWithCount>(), new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(483, LocalStringManager.GetConfig("MapPickups_language", "Name_483"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_483"), 0, new byte[15]
		{
			1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 57, 58, 59, 69, 70, 71, 72, 73, 74 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_483"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_483_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_483_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_483_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_483_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_483_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_483_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Material", 3, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Material", 10, 1)
		}));
		_dataArray.Add(new MapPickupsItem(484, LocalStringManager.GetConfig("MapPickups_language", "Name_484"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_484"), 0, new byte[15]
		{
			1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 87, 88, 89, 90, 91, 92, 93, 103, 104, 105 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_484"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_484_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_484_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_484_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_484_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_484_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_484_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Material", 60, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Material", 81, 1)
		}));
		_dataArray.Add(new MapPickupsItem(485, LocalStringManager.GetConfig("MapPickups_language", "Name_485"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_485"), 0, new byte[15]
		{
			1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
			11, 12, 13, 14, 15, 34, 35, 36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_485"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_485_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_485_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_485_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_485_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_485_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_485_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int> { -1, 5000 }, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("SkillBook", 11, 1),
			new PresetItemWithCount("SkillBook", 12, 1),
			new PresetItemWithCount("SkillBook", 13, 1),
			new PresetItemWithCount("SkillBook", 74, 1),
			new PresetItemWithCount("SkillBook", 75, 1),
			new PresetItemWithCount("SkillBook", 76, 1),
			new PresetItemWithCount("SkillBook", 119, 1),
			new PresetItemWithCount("SkillBook", 120, 1),
			new PresetItemWithCount("SkillBook", 121, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(486, LocalStringManager.GetConfig("MapPickups_language", "Name_486"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_486"), 0, new byte[15]
		{
			0, 1, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 69, 70, 71, 63, 64, 65, 66,
			67, 68
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_486"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_486_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_486_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_486_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_486_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_486_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_486_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Material", 52, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Material", 45, 1)
		}));
		_dataArray.Add(new MapPickupsItem(487, LocalStringManager.GetConfig("MapPickups_language", "Name_487"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_487"), 0, new byte[15]
		{
			0, 1, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
			11, 12, 13, 14, 15, 34, 35, 36
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_487"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_487_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_487_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_487_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_487_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_487_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_487_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Food", 55, 1),
			new PresetItemWithCount("Food", 63, 1),
			new PresetItemWithCount("Food", 70, 1),
			new PresetItemWithCount("Food", 76, 1),
			new PresetItemWithCount("Food", 81, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Food", 139, 1),
			new PresetItemWithCount("Food", 147, 1),
			new PresetItemWithCount("Food", 154, 1),
			new PresetItemWithCount("Food", 160, 1),
			new PresetItemWithCount("Food", 165, 1)
		}));
		_dataArray.Add(new MapPickupsItem(488, LocalStringManager.GetConfig("MapPickups_language", "Name_488"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_488"), 0, new byte[15]
		{
			0, 1, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 63, 64, 65, 90, 91, 92, 106, 107, 108 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_488"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_488_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_488_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_488_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_488_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_488_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_488_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int> { -1, 5000 }, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("SkillBook", 110, 1),
			new PresetItemWithCount("SkillBook", 111, 1),
			new PresetItemWithCount("SkillBook", 112, 1),
			new PresetItemWithCount("SkillBook", 119, 1),
			new PresetItemWithCount("SkillBook", 120, 1),
			new PresetItemWithCount("SkillBook", 121, 1),
			new PresetItemWithCount("SkillBook", 128, 1),
			new PresetItemWithCount("SkillBook", 129, 1),
			new PresetItemWithCount("SkillBook", 130, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(489, LocalStringManager.GetConfig("MapPickups_language", "Name_489"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_489"), 0, new byte[15]
		{
			0, 0, 1, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_489"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_489_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_489_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_489_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_489_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_489_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_489_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Material", 52, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Material", 45, 1)
		}));
		_dataArray.Add(new MapPickupsItem(490, LocalStringManager.GetConfig("MapPickups_language", "Name_490"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_490"), 0, new byte[15]
		{
			0, 0, 1, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36, 37
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_490"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_490_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_490_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_490_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_490_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_490_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_490_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Material", 74, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Material", 81, 1)
		}));
		_dataArray.Add(new MapPickupsItem(491, LocalStringManager.GetConfig("MapPickups_language", "Name_491"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_491"), 0, new byte[15]
		{
			0, 0, 1, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36, 37
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_491"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_491_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_491_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_491_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_491_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_491_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_491_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int> { -1, 5000 }, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("SkillBook", 2, 1),
			new PresetItemWithCount("SkillBook", 3, 1),
			new PresetItemWithCount("SkillBook", 4, 1),
			new PresetItemWithCount("SkillBook", 29, 1),
			new PresetItemWithCount("SkillBook", 30, 1),
			new PresetItemWithCount("SkillBook", 31, 1),
			new PresetItemWithCount("SkillBook", 74, 1),
			new PresetItemWithCount("SkillBook", 75, 1),
			new PresetItemWithCount("SkillBook", 76, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(492, LocalStringManager.GetConfig("MapPickups_language", "Name_492"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_492"), 0, new byte[15]
		{
			0, 0, 0, 1, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 57, 58, 59, 69, 70, 71, 72, 73, 74 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_492"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_492_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_492_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_492_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_492_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_492_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_492_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Material", 141, 1),
			new PresetItemWithCount("Material", 145, 1),
			new PresetItemWithCount("Material", 149, 1),
			new PresetItemWithCount("Material", 153, 1),
			new PresetItemWithCount("Material", 177, 1),
			new PresetItemWithCount("Material", 181, 1),
			new PresetItemWithCount("Material", 185, 1),
			new PresetItemWithCount("Material", 189, 1),
			new PresetItemWithCount("Material", 209, 1),
			new PresetItemWithCount("Material", 213, 1),
			new PresetItemWithCount("Material", 221, 1),
			new PresetItemWithCount("Material", 233, 1),
			new PresetItemWithCount("Material", 238, 1),
			new PresetItemWithCount("Material", 259, 1),
			new PresetItemWithCount("Material", 266, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Material", 157, 1),
			new PresetItemWithCount("Material", 161, 1),
			new PresetItemWithCount("Material", 165, 1),
			new PresetItemWithCount("Material", 169, 1),
			new PresetItemWithCount("Material", 173, 1),
			new PresetItemWithCount("Material", 193, 1),
			new PresetItemWithCount("Material", 197, 1),
			new PresetItemWithCount("Material", 201, 1),
			new PresetItemWithCount("Material", 205, 1),
			new PresetItemWithCount("Material", 217, 1),
			new PresetItemWithCount("Material", 221, 1),
			new PresetItemWithCount("Material", 225, 1),
			new PresetItemWithCount("Material", 229, 1),
			new PresetItemWithCount("Material", 245, 1),
			new PresetItemWithCount("Material", 252, 1),
			new PresetItemWithCount("Material", 273, 1)
		}));
		_dataArray.Add(new MapPickupsItem(493, LocalStringManager.GetConfig("MapPickups_language", "Name_493"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_493"), 0, new byte[15]
		{
			0, 0, 0, 1, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			78, 79, 80, 87, 88, 89, 90, 91, 92, 93,
			100, 101, 102
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_493"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_493_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_493_1")
		}, new string[4]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_493_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_493_1"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_493_2"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_493_3")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_493_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_493_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Material", 81, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Food", 4, 1)
		}));
		_dataArray.Add(new MapPickupsItem(494, LocalStringManager.GetConfig("MapPickups_language", "Name_494"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_494"), 0, new byte[15]
		{
			0, 0, 0, 1, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 57, 58, 59, 60, 61, 62, 72, 73, 74 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_494"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_494_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_494_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_494_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_494_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_494_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_494_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int> { -1, 5000 }, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("SkillBook", 20, 1),
			new PresetItemWithCount("SkillBook", 21, 1),
			new PresetItemWithCount("SkillBook", 22, 1),
			new PresetItemWithCount("SkillBook", 38, 1),
			new PresetItemWithCount("SkillBook", 39, 1),
			new PresetItemWithCount("SkillBook", 40, 1),
			new PresetItemWithCount("SkillBook", 110, 1),
			new PresetItemWithCount("SkillBook", 111, 1),
			new PresetItemWithCount("SkillBook", 112, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(495, LocalStringManager.GetConfig("MapPickups_language", "Name_495"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_495"), 0, new byte[15]
		{
			0, 0, 0, 0, 1, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			63, 64, 65, 90, 91, 92, 106, 107, 108, 87,
			88, 89
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_495"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_495_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_495_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_495_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_495_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_495_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_495_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Material", 17, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Material", 24, 1)
		}));
		_dataArray.Add(new MapPickupsItem(496, LocalStringManager.GetConfig("MapPickups_language", "Name_496"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_496"), 0, new byte[15]
		{
			0, 0, 0, 0, 1, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_496"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_496_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_496_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_496_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_496_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_496_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_496_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Material", 60, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Material", 74, 1)
		}));
		_dataArray.Add(new MapPickupsItem(497, LocalStringManager.GetConfig("MapPickups_language", "Name_497"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_497"), 0, new byte[15]
		{
			0, 0, 0, 0, 1, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 69, 70, 71, 63, 64, 65, 66,
			67, 68
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_497"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_497_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_497_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_497_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_497_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_497_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_497_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int> { -1, 5000 }, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("SkillBook", 119, 1),
			new PresetItemWithCount("SkillBook", 120, 1),
			new PresetItemWithCount("SkillBook", 121, 1),
			new PresetItemWithCount("SkillBook", 110, 1),
			new PresetItemWithCount("SkillBook", 111, 1),
			new PresetItemWithCount("SkillBook", 112, 1),
			new PresetItemWithCount("SkillBook", 128, 1),
			new PresetItemWithCount("SkillBook", 129, 1),
			new PresetItemWithCount("SkillBook", 130, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(498, LocalStringManager.GetConfig("MapPickups_language", "Name_498"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_498"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 1, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			54, 55, 56, 87, 88, 89, 90, 91, 92, 106,
			107, 108
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_498"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_498_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_498_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_498_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_498_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_498_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_498_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Material", 17, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Material", 24, 1)
		}));
		_dataArray.Add(new MapPickupsItem(499, LocalStringManager.GetConfig("MapPickups_language", "Name_499"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_499"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 1, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			78, 79, 80, 87, 88, 89, 90, 91, 92, 57,
			58, 59, 69, 70, 71
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_499"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_499_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_499_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_499_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_499_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_499_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_499_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Material", 67, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Food", 4, 1)
		}));
		_dataArray.Add(new MapPickupsItem(500, LocalStringManager.GetConfig("MapPickups_language", "Name_500"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_500"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 1, 0, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36, 37
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_500"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_500_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_500_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_500_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_500_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_500_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_500_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int> { -1, 5000 }, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("SkillBook", 56, 1),
			new PresetItemWithCount("SkillBook", 57, 1),
			new PresetItemWithCount("SkillBook", 58, 1),
			new PresetItemWithCount("SkillBook", 65, 1),
			new PresetItemWithCount("SkillBook", 66, 1),
			new PresetItemWithCount("SkillBook", 67, 1),
			new PresetItemWithCount("SkillBook", 137, 1),
			new PresetItemWithCount("SkillBook", 138, 1),
			new PresetItemWithCount("SkillBook", 139, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(501, LocalStringManager.GetConfig("MapPickups_language", "Name_501"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_501"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 1, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36, 37
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_501"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_501_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_501_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_501_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_501_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_501_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_501_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Material", 38, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Material", 31, 1)
		}));
		_dataArray.Add(new MapPickupsItem(502, LocalStringManager.GetConfig("MapPickups_language", "Name_502"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_502"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 1, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36, 37
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_502"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_502_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_502_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_502_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_502_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_502_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_502_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Material", 81, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Food", 4, 1)
		}));
		_dataArray.Add(new MapPickupsItem(503, LocalStringManager.GetConfig("MapPickups_language", "Name_503"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_503"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 1, 0, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 57, 58, 59, 69, 70, 71, 72, 73, 74 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_503"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_503_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_503_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_503_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_503_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_503_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_503_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int> { -1, 5000 }, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("SkillBook", 20, 1),
			new PresetItemWithCount("SkillBook", 21, 1),
			new PresetItemWithCount("SkillBook", 22, 1),
			new PresetItemWithCount("SkillBook", 38, 1),
			new PresetItemWithCount("SkillBook", 39, 1),
			new PresetItemWithCount("SkillBook", 40, 1),
			new PresetItemWithCount("SkillBook", 110, 1),
			new PresetItemWithCount("SkillBook", 111, 1),
			new PresetItemWithCount("SkillBook", 112, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(504, LocalStringManager.GetConfig("MapPickups_language", "Name_504"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_504"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 1, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 97, 98, 99 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_504"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_504_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_504_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_504_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_504_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_504_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_504_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Material", 38, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Material", 31, 1)
		}));
		_dataArray.Add(new MapPickupsItem(505, LocalStringManager.GetConfig("MapPickups_language", "Name_505"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_505"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 1, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_505"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_505_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_505_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_505_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_505_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_505_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_505_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Material", 60, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Material", 74, 1)
		}));
		_dataArray.Add(new MapPickupsItem(506, LocalStringManager.GetConfig("MapPickups_language", "Name_506"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_506"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 1, 0, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			75, 76, 77, 81, 82, 83, 84, 85, 86, 94,
			95, 96
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_506"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_506_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_506_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_506_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_506_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_506_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_506_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int> { -1, 5000 }, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("SkillBook", 2, 1),
			new PresetItemWithCount("SkillBook", 3, 1),
			new PresetItemWithCount("SkillBook", 4, 1),
			new PresetItemWithCount("SkillBook", 29, 1),
			new PresetItemWithCount("SkillBook", 30, 1),
			new PresetItemWithCount("SkillBook", 31, 1),
			new PresetItemWithCount("SkillBook", 47, 1),
			new PresetItemWithCount("SkillBook", 48, 1),
			new PresetItemWithCount("SkillBook", 49, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(507, LocalStringManager.GetConfig("MapPickups_language", "Name_507"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_507"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 1, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			75, 76, 77, 81, 82, 83, 84, 85, 86, 94,
			95, 96
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_507"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_507_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_507_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_507_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_507_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_507_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_507_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Material", 17, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Material", 24, 1)
		}));
		_dataArray.Add(new MapPickupsItem(508, LocalStringManager.GetConfig("MapPickups_language", "Name_508"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_508"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 1, 0,
			0, 0, 0, 0, 0
		}, new List<short> { 81, 82, 83, 84, 85, 86, 94, 95, 96 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_508"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_508_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_508_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_508_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_508_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_508_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_508_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Material", 74, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Material", 81, 1)
		}));
		_dataArray.Add(new MapPickupsItem(509, LocalStringManager.GetConfig("MapPickups_language", "Name_509"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_509"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 1, 0,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36, 37
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_509"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_509_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_509_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_509_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_509_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_509_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_509_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int> { -1, 5000 }, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("SkillBook", 56, 1),
			new PresetItemWithCount("SkillBook", 57, 1),
			new PresetItemWithCount("SkillBook", 58, 1),
			new PresetItemWithCount("SkillBook", 65, 1),
			new PresetItemWithCount("SkillBook", 66, 1),
			new PresetItemWithCount("SkillBook", 67, 1),
			new PresetItemWithCount("SkillBook", 92, 1),
			new PresetItemWithCount("SkillBook", 93, 1),
			new PresetItemWithCount("SkillBook", 94, 1),
			new PresetItemWithCount("SkillBook", 101, 1),
			new PresetItemWithCount("SkillBook", 102, 1),
			new PresetItemWithCount("SkillBook", 103, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(510, LocalStringManager.GetConfig("MapPickups_language", "Name_510"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_510"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
			0, 0, 0, 0, 0
		}, new List<short> { 81, 82, 83, 84, 85, 86, 94, 95, 96 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_510"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_510_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_510_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_510_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_510_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_510_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_510_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Material", 141, 1),
			new PresetItemWithCount("Material", 145, 1),
			new PresetItemWithCount("Material", 149, 1),
			new PresetItemWithCount("Material", 153, 1),
			new PresetItemWithCount("Material", 177, 1),
			new PresetItemWithCount("Material", 181, 1),
			new PresetItemWithCount("Material", 185, 1),
			new PresetItemWithCount("Material", 189, 1),
			new PresetItemWithCount("Material", 209, 1),
			new PresetItemWithCount("Material", 213, 1),
			new PresetItemWithCount("Material", 221, 1),
			new PresetItemWithCount("Material", 233, 1),
			new PresetItemWithCount("Material", 238, 1),
			new PresetItemWithCount("Material", 259, 1),
			new PresetItemWithCount("Material", 266, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Material", 157, 1),
			new PresetItemWithCount("Material", 161, 1),
			new PresetItemWithCount("Material", 165, 1),
			new PresetItemWithCount("Material", 169, 1),
			new PresetItemWithCount("Material", 173, 1),
			new PresetItemWithCount("Material", 193, 1),
			new PresetItemWithCount("Material", 197, 1),
			new PresetItemWithCount("Material", 201, 1),
			new PresetItemWithCount("Material", 205, 1),
			new PresetItemWithCount("Material", 217, 1),
			new PresetItemWithCount("Material", 221, 1),
			new PresetItemWithCount("Material", 225, 1),
			new PresetItemWithCount("Material", 229, 1),
			new PresetItemWithCount("Material", 245, 1),
			new PresetItemWithCount("Material", 252, 1),
			new PresetItemWithCount("Material", 273, 1)
		}));
		_dataArray.Add(new MapPickupsItem(511, LocalStringManager.GetConfig("MapPickups_language", "Name_511"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_511"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
			0, 0, 0, 0, 0
		}, new List<short> { 81, 82, 83, 84, 85, 86, 94, 95, 96 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_511"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_511_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_511_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_511_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_511_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_511_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_511_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Material", 67, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Material", 74, 1)
		}));
		_dataArray.Add(new MapPickupsItem(512, LocalStringManager.GetConfig("MapPickups_language", "Name_512"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_512"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
			0, 0, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 69, 70, 71, 72, 73, 74, 106,
			107, 108
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_512"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_512_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_512_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_512_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_512_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_512_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_512_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int> { -1, 5000 }, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("SkillBook", 74, 1),
			new PresetItemWithCount("SkillBook", 75, 1),
			new PresetItemWithCount("SkillBook", 76, 1),
			new PresetItemWithCount("SkillBook", 83, 1),
			new PresetItemWithCount("SkillBook", 84, 1),
			new PresetItemWithCount("SkillBook", 85, 1),
			new PresetItemWithCount("SkillBook", 92, 1),
			new PresetItemWithCount("SkillBook", 93, 1),
			new PresetItemWithCount("SkillBook", 94, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(513, LocalStringManager.GetConfig("MapPickups_language", "Name_513"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_513"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			1, 0, 0, 0, 0
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36, 37
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_513"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_513_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_513_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_513_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_513_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_513_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_513_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Material", 38, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Material", 31, 1)
		}));
		_dataArray.Add(new MapPickupsItem(514, LocalStringManager.GetConfig("MapPickups_language", "Name_514"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_514"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			1, 0, 0, 0, 0
		}, new List<short> { 103, 104, 105, 75, 76, 77, 78, 79, 80, 93 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_514"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_514_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_514_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_514_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_514_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_514_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_514_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Material", 67, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Food", 4, 1)
		}));
		_dataArray.Add(new MapPickupsItem(515, LocalStringManager.GetConfig("MapPickups_language", "Name_515"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_515"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			1, 0, 0, 0, 0
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36, 37
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_515"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_515_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_515_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_515_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_515_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_515_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_515_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int> { -1, 5000 }, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("SkillBook", 119, 1),
			new PresetItemWithCount("SkillBook", 120, 1),
			new PresetItemWithCount("SkillBook", 121, 1),
			new PresetItemWithCount("SkillBook", 101, 1),
			new PresetItemWithCount("SkillBook", 102, 1),
			new PresetItemWithCount("SkillBook", 103, 1),
			new PresetItemWithCount("SkillBook", 137, 1),
			new PresetItemWithCount("SkillBook", 138, 1),
			new PresetItemWithCount("SkillBook", 139, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(516, LocalStringManager.GetConfig("MapPickups_language", "Name_516"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_516"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 1, 0, 0, 0
		}, new List<short>
		{
			103, 104, 105, 75, 76, 77, 78, 79, 80, 39,
			40, 41, 48, 49, 50, 51, 52, 53
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_516"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_516_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_516_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_516_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_516_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_516_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_516_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Material", 3, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Material", 10, 1)
		}));
		_dataArray.Add(new MapPickupsItem(517, LocalStringManager.GetConfig("MapPickups_language", "Name_517"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_517"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 1, 0, 0, 0
		}, new List<short> { 57, 58, 59, 69, 70, 71, 72, 73, 74 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_517"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_517_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_517_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_517_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_517_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_517_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_517_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Material", 60, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Food", 4, 1)
		}));
		_dataArray.Add(new MapPickupsItem(518, LocalStringManager.GetConfig("MapPickups_language", "Name_518"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_518"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 1, 0, 0, 0
		}, new List<short>
		{
			57, 58, 59, 60, 61, 62, 69, 70, 71, 72,
			73, 74, 81, 82, 83, 84, 85, 86, 106, 107,
			108
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_518"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_518_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_518_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_518_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_518_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_518_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_518_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int> { -1, 5000 }, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("SkillBook", 74, 1),
			new PresetItemWithCount("SkillBook", 75, 1),
			new PresetItemWithCount("SkillBook", 76, 1),
			new PresetItemWithCount("SkillBook", 83, 1),
			new PresetItemWithCount("SkillBook", 84, 1),
			new PresetItemWithCount("SkillBook", 85, 1),
			new PresetItemWithCount("SkillBook", 65, 1),
			new PresetItemWithCount("SkillBook", 66, 1),
			new PresetItemWithCount("SkillBook", 67, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(519, LocalStringManager.GetConfig("MapPickups_language", "Name_519"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_519"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 1, 0, 0
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36, 37
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_519"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_519_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_519_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_519_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_519_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_519_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_519_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Material", 52, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Material", 45, 1)
		}));
		_dataArray.Add(new MapPickupsItem(520, LocalStringManager.GetConfig("MapPickups_language", "Name_520"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_520"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 1, 0, 0
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36, 37
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_520"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_520_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_520_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_520_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_520_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_520_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_520_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Material", 67, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Material", 74, 1)
		}));
		_dataArray.Add(new MapPickupsItem(521, LocalStringManager.GetConfig("MapPickups_language", "Name_521"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_521"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 1, 0, 0
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36, 37
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_521"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_521_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_521_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_521_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_521_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_521_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_521_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int> { -1, 5000 }, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("SkillBook", 11, 1),
			new PresetItemWithCount("SkillBook", 12, 1),
			new PresetItemWithCount("SkillBook", 13, 1),
			new PresetItemWithCount("SkillBook", 38, 1),
			new PresetItemWithCount("SkillBook", 39, 1),
			new PresetItemWithCount("SkillBook", 40, 1),
			new PresetItemWithCount("SkillBook", 83, 1),
			new PresetItemWithCount("SkillBook", 84, 1),
			new PresetItemWithCount("SkillBook", 85, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(522, LocalStringManager.GetConfig("MapPickups_language", "Name_522"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_522"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 1, 0
		}, new List<short>
		{
			78, 79, 80, 87, 88, 89, 90, 91, 92, 93,
			100, 101, 102
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_522"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_522_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_522_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_522_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_522_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_522_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_522_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Material", 3, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Material", 10, 1)
		}));
		_dataArray.Add(new MapPickupsItem(523, LocalStringManager.GetConfig("MapPickups_language", "Name_523"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_523"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 1, 0
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36, 37
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_523"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_523_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_523_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_523_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_523_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_523_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_523_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Material", 74, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Material", 81, 1)
		}));
		_dataArray.Add(new MapPickupsItem(524, LocalStringManager.GetConfig("MapPickups_language", "Name_524"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_524"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 1, 0
		}, new List<short> { 42, 43, 44, 45, 46, 47 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_524"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_524_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_524_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_524_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_524_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_524_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_524_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int> { -1, 5000 }, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("SkillBook", 47, 1),
			new PresetItemWithCount("SkillBook", 48, 1),
			new PresetItemWithCount("SkillBook", 49, 1),
			new PresetItemWithCount("SkillBook", 56, 1),
			new PresetItemWithCount("SkillBook", 57, 1),
			new PresetItemWithCount("SkillBook", 58, 1),
			new PresetItemWithCount("SkillBook", 128, 1),
			new PresetItemWithCount("SkillBook", 129, 1),
			new PresetItemWithCount("SkillBook", 130, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(525, LocalStringManager.GetConfig("MapPickups_language", "Name_525"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_525"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 1
		}, new List<short> { 57, 58, 59, 69, 70, 71, 72, 73, 74 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_525"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_525_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_525_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_525_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_525_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_525_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_525_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Material", 239, 1),
			new PresetItemWithCount("Material", 260, 1),
			new PresetItemWithCount("Material", 267, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Material", 246, 1),
			new PresetItemWithCount("Material", 253, 1),
			new PresetItemWithCount("Material", 274, 1)
		}));
		_dataArray.Add(new MapPickupsItem(526, LocalStringManager.GetConfig("MapPickups_language", "Name_526"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_526"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 1
		}, new List<short>
		{
			103, 104, 105, 75, 76, 77, 78, 79, 80, 39,
			40, 41, 48, 49, 50, 51, 52, 53
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_526"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_526_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_526_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_526_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_526_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_526_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_526_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Material", 67, 1)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Material", 60, 1)
		}));
		_dataArray.Add(new MapPickupsItem(527, LocalStringManager.GetConfig("MapPickups_language", "Name_527"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_527"), 0, new byte[15]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 1
		}, new List<short> { 57, 58, 59, 60, 61, 62, 97, 98, 99 }, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_527"), new string[1] { LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_527_0") }, new string[1] { LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_527_0") }, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_527_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_527_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int> { -1, 5000 }, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("SkillBook", 47, 1),
			new PresetItemWithCount("SkillBook", 48, 1),
			new PresetItemWithCount("SkillBook", 49, 1),
			new PresetItemWithCount("SkillBook", 137, 1),
			new PresetItemWithCount("SkillBook", 138, 1),
			new PresetItemWithCount("SkillBook", 139, 1),
			new PresetItemWithCount("SkillBook", 83, 1),
			new PresetItemWithCount("SkillBook", 84, 1),
			new PresetItemWithCount("SkillBook", 85, 1)
		}, new List<PresetItemWithCount>()));
		_dataArray.Add(new MapPickupsItem(528, LocalStringManager.GetConfig("MapPickups_language", "Name_528"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_528"), 0, new byte[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36, 37
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_528"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_528_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_528_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_528_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_528_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_528_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_528_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Medicine", 69, 3),
			new PresetItemWithCount("Medicine", 72, 3),
			new PresetItemWithCount("Medicine", 57, 3),
			new PresetItemWithCount("Medicine", 60, 3)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Medicine", 337, 3),
			new PresetItemWithCount("Medicine", 340, 3),
			new PresetItemWithCount("Medicine", 121, 3),
			new PresetItemWithCount("Medicine", 124, 3)
		}));
		_dataArray.Add(new MapPickupsItem(529, LocalStringManager.GetConfig("MapPickups_language", "Name_529"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_529"), 0, new byte[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36, 37
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_529"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_529_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_529_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_529_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_529_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_529_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_529_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Medicine", 3, 3),
			new PresetItemWithCount("Medicine", 12, 3),
			new PresetItemWithCount("Medicine", 21, 3),
			new PresetItemWithCount("Medicine", 30, 3),
			new PresetItemWithCount("Medicine", 39, 3),
			new PresetItemWithCount("Medicine", 48, 3),
			new PresetItemWithCount("Medicine", 133, 3),
			new PresetItemWithCount("Medicine", 136, 3),
			new PresetItemWithCount("Medicine", 145, 3),
			new PresetItemWithCount("Medicine", 148, 3),
			new PresetItemWithCount("Medicine", 157, 3),
			new PresetItemWithCount("Medicine", 160, 3),
			new PresetItemWithCount("Medicine", 169, 3),
			new PresetItemWithCount("Medicine", 172, 3),
			new PresetItemWithCount("Medicine", 181, 3),
			new PresetItemWithCount("Medicine", 184, 3),
			new PresetItemWithCount("Medicine", 193, 3),
			new PresetItemWithCount("Medicine", 196, 3)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Medicine", 205, 3),
			new PresetItemWithCount("Medicine", 208, 3),
			new PresetItemWithCount("Medicine", 217, 3),
			new PresetItemWithCount("Medicine", 220, 3)
		}));
		_dataArray.Add(new MapPickupsItem(530, LocalStringManager.GetConfig("MapPickups_language", "Name_530"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_530"), 0, new byte[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36, 37
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_530"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_530_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_530_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_530_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_530_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_530_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_530_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Medicine", 97, 3),
			new PresetItemWithCount("Medicine", 100, 3),
			new PresetItemWithCount("Medicine", 85, 3),
			new PresetItemWithCount("Medicine", 88, 3)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Medicine", 109, 3),
			new PresetItemWithCount("Medicine", 112, 3),
			new PresetItemWithCount("Medicine", 313, 3),
			new PresetItemWithCount("Medicine", 316, 3)
		}));
		_dataArray.Add(new MapPickupsItem(531, LocalStringManager.GetConfig("MapPickups_language", "Name_531"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_531"), 0, new byte[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36, 37
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_531"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_531_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_531_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_531_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_531_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_531_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_531_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Medicine", 277, 3),
			new PresetItemWithCount("Medicine", 280, 3),
			new PresetItemWithCount("Medicine", 301, 3),
			new PresetItemWithCount("Medicine", 304, 3),
			new PresetItemWithCount("Medicine", 325, 3),
			new PresetItemWithCount("Medicine", 328, 3),
			new PresetItemWithCount("Medicine", 229, 3),
			new PresetItemWithCount("Medicine", 232, 3),
			new PresetItemWithCount("Medicine", 241, 3),
			new PresetItemWithCount("Medicine", 244, 3),
			new PresetItemWithCount("Medicine", 253, 3),
			new PresetItemWithCount("Medicine", 256, 3)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Medicine", 265, 3),
			new PresetItemWithCount("Medicine", 268, 3),
			new PresetItemWithCount("Medicine", 289, 3),
			new PresetItemWithCount("Medicine", 292, 3)
		}));
		_dataArray.Add(new MapPickupsItem(532, LocalStringManager.GetConfig("MapPickups_language", "Name_532"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_532"), 0, new byte[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36, 37
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_532"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_532_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_532_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_532_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_532_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_532_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_532_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Medicine", 123, 3),
			new PresetItemWithCount("Medicine", 126, 3),
			new PresetItemWithCount("Medicine", 339, 3),
			new PresetItemWithCount("Medicine", 342, 3)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Medicine", 71, 3),
			new PresetItemWithCount("Medicine", 74, 3),
			new PresetItemWithCount("Medicine", 59, 3),
			new PresetItemWithCount("Medicine", 62, 3)
		}));
		_dataArray.Add(new MapPickupsItem(533, LocalStringManager.GetConfig("MapPickups_language", "Name_533"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_533"), 0, new byte[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36, 37
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_533"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_533_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_533_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_533_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_533_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_533_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_533_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Medicine", 219, 3),
			new PresetItemWithCount("Medicine", 222, 3),
			new PresetItemWithCount("Medicine", 207, 3),
			new PresetItemWithCount("Medicine", 210, 3)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Medicine", 5, 3),
			new PresetItemWithCount("Medicine", 14, 3),
			new PresetItemWithCount("Medicine", 23, 3),
			new PresetItemWithCount("Medicine", 32, 3),
			new PresetItemWithCount("Medicine", 41, 3),
			new PresetItemWithCount("Medicine", 50, 3),
			new PresetItemWithCount("Medicine", 135, 3),
			new PresetItemWithCount("Medicine", 138, 3),
			new PresetItemWithCount("Medicine", 147, 3),
			new PresetItemWithCount("Medicine", 150, 3),
			new PresetItemWithCount("Medicine", 159, 3),
			new PresetItemWithCount("Medicine", 162, 3),
			new PresetItemWithCount("Medicine", 171, 3),
			new PresetItemWithCount("Medicine", 174, 3),
			new PresetItemWithCount("Medicine", 183, 3),
			new PresetItemWithCount("Medicine", 186, 3),
			new PresetItemWithCount("Medicine", 195, 3),
			new PresetItemWithCount("Medicine", 198, 3)
		}));
		_dataArray.Add(new MapPickupsItem(534, LocalStringManager.GetConfig("MapPickups_language", "Name_534"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_534"), 0, new byte[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36, 37
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_534"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_534_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_534_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_534_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_534_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_534_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_534_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Medicine", 111, 3),
			new PresetItemWithCount("Medicine", 114, 3),
			new PresetItemWithCount("Medicine", 315, 3),
			new PresetItemWithCount("Medicine", 318, 3)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Medicine", 99, 3),
			new PresetItemWithCount("Medicine", 102, 3),
			new PresetItemWithCount("Medicine", 87, 3),
			new PresetItemWithCount("Medicine", 90, 3)
		}));
		_dataArray.Add(new MapPickupsItem(535, LocalStringManager.GetConfig("MapPickups_language", "Name_535"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_535"), 0, new byte[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36, 37
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_535"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_535_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_535_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_535_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_535_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_535_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_535_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Medicine", 267, 3),
			new PresetItemWithCount("Medicine", 270, 3),
			new PresetItemWithCount("Medicine", 291, 3),
			new PresetItemWithCount("Medicine", 294, 3)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Medicine", 279, 3),
			new PresetItemWithCount("Medicine", 282, 3),
			new PresetItemWithCount("Medicine", 303, 3),
			new PresetItemWithCount("Medicine", 306, 3),
			new PresetItemWithCount("Medicine", 327, 3),
			new PresetItemWithCount("Medicine", 330, 3),
			new PresetItemWithCount("Medicine", 231, 3),
			new PresetItemWithCount("Medicine", 234, 3),
			new PresetItemWithCount("Medicine", 243, 3),
			new PresetItemWithCount("Medicine", 246, 3),
			new PresetItemWithCount("Medicine", 255, 3),
			new PresetItemWithCount("Medicine", 258, 3)
		}));
		_dataArray.Add(new MapPickupsItem(536, LocalStringManager.GetConfig("MapPickups_language", "Name_536"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_536"), 0, new byte[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36, 37
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_536"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_536_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_536_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_536_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_536_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_536_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_536_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Medicine", 284, 3),
			new PresetItemWithCount("Medicine", 308, 3),
			new PresetItemWithCount("Medicine", 332, 3),
			new PresetItemWithCount("Medicine", 236, 3),
			new PresetItemWithCount("Medicine", 248, 3),
			new PresetItemWithCount("Medicine", 260, 3)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Medicine", 296, 3),
			new PresetItemWithCount("Medicine", 272, 3)
		}));
		_dataArray.Add(new MapPickupsItem(537, LocalStringManager.GetConfig("MapPickups_language", "Name_537"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_537"), 0, new byte[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36, 37
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_537"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_537_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_537_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_537_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_537_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_537_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_537_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Medicine", 104, 3),
			new PresetItemWithCount("Medicine", 92, 3)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Medicine", 116, 3),
			new PresetItemWithCount("Medicine", 320, 3)
		}));
		_dataArray.Add(new MapPickupsItem(538, LocalStringManager.GetConfig("MapPickups_language", "Name_538"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_538"), 0, new byte[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36, 37
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_538"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_538_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_538_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_538_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_538_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_538_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_538_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Medicine", 64, 3),
			new PresetItemWithCount("Medicine", 76, 3)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Medicine", 344, 3),
			new PresetItemWithCount("Medicine", 128, 3)
		}));
		_dataArray.Add(new MapPickupsItem(539, LocalStringManager.GetConfig("MapPickups_language", "Name_539"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_539"), 0, new byte[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36, 37
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_539"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_539_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_539_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_539_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_539_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_539_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_539_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Medicine", 69, 3),
			new PresetItemWithCount("Medicine", 72, 3),
			new PresetItemWithCount("Medicine", 57, 3),
			new PresetItemWithCount("Medicine", 60, 3)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Medicine", 97, 3),
			new PresetItemWithCount("Medicine", 100, 3),
			new PresetItemWithCount("Medicine", 85, 3),
			new PresetItemWithCount("Medicine", 88, 3)
		}));
	}

	private void CreateItems9()
	{
		_dataArray.Add(new MapPickupsItem(540, LocalStringManager.GetConfig("MapPickups_language", "Name_540"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_540"), 0, new byte[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36, 37
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_540"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_540_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_540_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_540_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_540_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_540_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_540_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Medicine", 123, 3),
			new PresetItemWithCount("Medicine", 126, 3),
			new PresetItemWithCount("Medicine", 339, 3),
			new PresetItemWithCount("Medicine", 342, 3)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Medicine", 219, 3),
			new PresetItemWithCount("Medicine", 222, 3),
			new PresetItemWithCount("Medicine", 207, 3),
			new PresetItemWithCount("Medicine", 210, 3)
		}));
		_dataArray.Add(new MapPickupsItem(541, LocalStringManager.GetConfig("MapPickups_language", "Name_541"), EMapPickupsType.Event, EMapPickupsType2.Invalid, "map_eventicon_18", LocalStringManager.GetConfig("MapPickups_language", "TipsContent_541"), 0, new byte[15]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1
		}, new List<short>
		{
			39, 40, 41, 42, 43, 44, 45, 46, 47, 54,
			55, 56, 48, 49, 50, 51, 52, 53, 1, 2,
			3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
			13, 14, 15, 34, 35, 36, 37
		}, readEffect: false, loopEffect: false, isExpBonus: false, isDebtBonus: false, new int[0], new sbyte[0], default(PresetItemTemplateId), new sbyte[1], new short[6], new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		}, -1, new OrganizationApproving(), -1, -1, -1, LocalStringManager.GetConfig("MapPickups_language", "EventMainContent_541"), new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_541_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventMainOptions_541_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_541_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondContents_541_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_541_0"),
			LocalStringManager.GetConfig("MapPickups_language", "EventSecondOptions_541_1")
		}, new List<PresetItemWithCount>(), new List<ResourceInfo>(), new List<PropertyAndValue>(), new List<int>(), new List<int>(), new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Medicine", 284, 3),
			new PresetItemWithCount("Medicine", 308, 3),
			new PresetItemWithCount("Medicine", 332, 3),
			new PresetItemWithCount("Medicine", 236, 3),
			new PresetItemWithCount("Medicine", 248, 3),
			new PresetItemWithCount("Medicine", 260, 3)
		}, new List<PresetItemWithCount>
		{
			new PresetItemWithCount("Medicine", 7, 3),
			new PresetItemWithCount("Medicine", 16, 3),
			new PresetItemWithCount("Medicine", 25, 3),
			new PresetItemWithCount("Medicine", 34, 3),
			new PresetItemWithCount("Medicine", 43, 3),
			new PresetItemWithCount("Medicine", 52, 3),
			new PresetItemWithCount("Medicine", 140, 3),
			new PresetItemWithCount("Medicine", 152, 3),
			new PresetItemWithCount("Medicine", 164, 3),
			new PresetItemWithCount("Medicine", 176, 3),
			new PresetItemWithCount("Medicine", 188, 3),
			new PresetItemWithCount("Medicine", 200, 3)
		}));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<MapPickupsItem>(542);
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

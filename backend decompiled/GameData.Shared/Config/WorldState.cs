using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class WorldState : ConfigData<WorldStateItem, sbyte>
{
	public static class DefKey
	{
		public const sbyte XiangshuLevel01 = 0;

		public const sbyte XiangshuLevel02 = 1;

		public const sbyte XiangshuLevel0 = 2;

		public const sbyte XiangshuLevel1 = 3;

		public const sbyte XiangshuLevel2 = 4;

		public const sbyte XiangshuLevel3 = 5;

		public const sbyte XiangshuLevel4 = 6;

		public const sbyte XiangshuLevel5 = 7;

		public const sbyte XiangshuLevel6 = 8;

		public const sbyte XiangshuLevel7 = 9;

		public const sbyte EquipmentOverload = 10;

		public const sbyte InventoryOverload = 11;

		public const sbyte WarehouseOverload = 12;

		public const sbyte ResourceOverload = 13;

		public const sbyte OuterInjury = 14;

		public const sbyte InnerInjury = 15;

		public const sbyte DisorderOfQi = 16;

		public const sbyte Poisons = 17;

		public const sbyte XiangshuPartiallyInfected = 18;

		public const sbyte XiangshuCompletelyInfected = 19;

		public const sbyte XiangshuAvatarAwake = 20;

		public const sbyte XiangshuAvatarAttack = 21;

		public const sbyte MartialArtTournamentPrepare = 22;

		public const sbyte MartialArtTournamentWait = 23;

		public const sbyte MartialArtTournamentOpen = 24;

		public const sbyte SectMainStoryShaolin = 25;

		public const sbyte SectMainStoryEmei = 26;

		public const sbyte SectMainStoryBaihua = 27;

		public const sbyte SectMainStoryWudang = 28;

		public const sbyte SectMainStoryYuanshan = 29;

		public const sbyte SectMainStoryShixiang = 30;

		public const sbyte SectMainStoryRanshan = 31;

		public const sbyte SectMainStoryXuannv = 32;

		public const sbyte SectMainStoryZhujian = 33;

		public const sbyte SectMainStoryKongsang = 34;

		public const sbyte SectMainStoryJingang = 35;

		public const sbyte SectMainStoryWuxian = 36;

		public const sbyte SectMainStoryJieqing = 37;

		public const sbyte SectMainStoryFulong = 38;

		public const sbyte SectMainStoryXuehou = 39;

		public const sbyte TeammateSeverelyInjured = 40;

		public const sbyte ChangeWorldCreation = 41;

		public const sbyte FiveLoongLei = 42;

		public const sbyte FiveLoongHong = 43;

		public const sbyte FiveLoongFeng = 44;

		public const sbyte FiveLoongYan = 45;

		public const sbyte FiveLoongSha = 46;

		public const sbyte TheLandOfFire = 47;

		public const sbyte ThunderStrikeTrial = 48;

		public const sbyte TaiwuWanted = 49;

		public const sbyte WardOffXiangshu = 50;

		public const sbyte TearmateDying = 51;

		public const sbyte HomelessVillager = 52;

		public const sbyte NeiliConflicting = 53;

		public const sbyte PracticeNotice = 54;

		public const sbyte ChallengeMode = 55;

		public const sbyte ChallengeModeChanged = 56;
	}

	public static class DefValue
	{
		public static WorldStateItem XiangshuLevel01 => Instance[(sbyte)0];

		public static WorldStateItem XiangshuLevel02 => Instance[(sbyte)1];

		public static WorldStateItem XiangshuLevel0 => Instance[(sbyte)2];

		public static WorldStateItem XiangshuLevel1 => Instance[(sbyte)3];

		public static WorldStateItem XiangshuLevel2 => Instance[(sbyte)4];

		public static WorldStateItem XiangshuLevel3 => Instance[(sbyte)5];

		public static WorldStateItem XiangshuLevel4 => Instance[(sbyte)6];

		public static WorldStateItem XiangshuLevel5 => Instance[(sbyte)7];

		public static WorldStateItem XiangshuLevel6 => Instance[(sbyte)8];

		public static WorldStateItem XiangshuLevel7 => Instance[(sbyte)9];

		public static WorldStateItem EquipmentOverload => Instance[(sbyte)10];

		public static WorldStateItem InventoryOverload => Instance[(sbyte)11];

		public static WorldStateItem WarehouseOverload => Instance[(sbyte)12];

		public static WorldStateItem ResourceOverload => Instance[(sbyte)13];

		public static WorldStateItem OuterInjury => Instance[(sbyte)14];

		public static WorldStateItem InnerInjury => Instance[(sbyte)15];

		public static WorldStateItem DisorderOfQi => Instance[(sbyte)16];

		public static WorldStateItem Poisons => Instance[(sbyte)17];

		public static WorldStateItem XiangshuPartiallyInfected => Instance[(sbyte)18];

		public static WorldStateItem XiangshuCompletelyInfected => Instance[(sbyte)19];

		public static WorldStateItem XiangshuAvatarAwake => Instance[(sbyte)20];

		public static WorldStateItem XiangshuAvatarAttack => Instance[(sbyte)21];

		public static WorldStateItem MartialArtTournamentPrepare => Instance[(sbyte)22];

		public static WorldStateItem MartialArtTournamentWait => Instance[(sbyte)23];

		public static WorldStateItem MartialArtTournamentOpen => Instance[(sbyte)24];

		public static WorldStateItem SectMainStoryShaolin => Instance[(sbyte)25];

		public static WorldStateItem SectMainStoryEmei => Instance[(sbyte)26];

		public static WorldStateItem SectMainStoryBaihua => Instance[(sbyte)27];

		public static WorldStateItem SectMainStoryWudang => Instance[(sbyte)28];

		public static WorldStateItem SectMainStoryYuanshan => Instance[(sbyte)29];

		public static WorldStateItem SectMainStoryShixiang => Instance[(sbyte)30];

		public static WorldStateItem SectMainStoryRanshan => Instance[(sbyte)31];

		public static WorldStateItem SectMainStoryXuannv => Instance[(sbyte)32];

		public static WorldStateItem SectMainStoryZhujian => Instance[(sbyte)33];

		public static WorldStateItem SectMainStoryKongsang => Instance[(sbyte)34];

		public static WorldStateItem SectMainStoryJingang => Instance[(sbyte)35];

		public static WorldStateItem SectMainStoryWuxian => Instance[(sbyte)36];

		public static WorldStateItem SectMainStoryJieqing => Instance[(sbyte)37];

		public static WorldStateItem SectMainStoryFulong => Instance[(sbyte)38];

		public static WorldStateItem SectMainStoryXuehou => Instance[(sbyte)39];

		public static WorldStateItem TeammateSeverelyInjured => Instance[(sbyte)40];

		public static WorldStateItem ChangeWorldCreation => Instance[(sbyte)41];

		public static WorldStateItem FiveLoongLei => Instance[(sbyte)42];

		public static WorldStateItem FiveLoongHong => Instance[(sbyte)43];

		public static WorldStateItem FiveLoongFeng => Instance[(sbyte)44];

		public static WorldStateItem FiveLoongYan => Instance[(sbyte)45];

		public static WorldStateItem FiveLoongSha => Instance[(sbyte)46];

		public static WorldStateItem TheLandOfFire => Instance[(sbyte)47];

		public static WorldStateItem ThunderStrikeTrial => Instance[(sbyte)48];

		public static WorldStateItem TaiwuWanted => Instance[(sbyte)49];

		public static WorldStateItem WardOffXiangshu => Instance[(sbyte)50];

		public static WorldStateItem TearmateDying => Instance[(sbyte)51];

		public static WorldStateItem HomelessVillager => Instance[(sbyte)52];

		public static WorldStateItem NeiliConflicting => Instance[(sbyte)53];

		public static WorldStateItem PracticeNotice => Instance[(sbyte)54];

		public static WorldStateItem ChallengeMode => Instance[(sbyte)55];

		public static WorldStateItem ChallengeModeChanged => Instance[(sbyte)56];
	}

	public static WorldState Instance = new WorldState();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "Desc", "SectStoryCondition", "SectStoryConditionTaiwuAsXiangshu", "Sect", "TriggerArea", "MonthlyEvents", "TemplateId", "Icon" };

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
		_dataArray.Add(new WorldStateItem(0, LocalStringManager.GetConfig("WorldState_language", "Name_0"), LocalStringManager.GetConfig("WorldState_language", "Desc_0"), "worldstate_icon_63", new string[0], new string[0], -1, -1, null));
		_dataArray.Add(new WorldStateItem(1, LocalStringManager.GetConfig("WorldState_language", "Name_1"), LocalStringManager.GetConfig("WorldState_language", "Desc_1"), "worldstate_icon_64", new string[0], new string[0], -1, -1, null));
		_dataArray.Add(new WorldStateItem(2, LocalStringManager.GetConfig("WorldState_language", "Name_2"), LocalStringManager.GetConfig("WorldState_language", "Desc_2"), "worldstate_icon_22", new string[0], new string[0], -1, -1, null));
		_dataArray.Add(new WorldStateItem(3, LocalStringManager.GetConfig("WorldState_language", "Name_3"), LocalStringManager.GetConfig("WorldState_language", "Desc_3"), "worldstate_icon_21", new string[0], new string[0], -1, -1, null));
		_dataArray.Add(new WorldStateItem(4, LocalStringManager.GetConfig("WorldState_language", "Name_4"), LocalStringManager.GetConfig("WorldState_language", "Desc_4"), "worldstate_icon_20", new string[0], new string[0], -1, -1, null));
		_dataArray.Add(new WorldStateItem(5, LocalStringManager.GetConfig("WorldState_language", "Name_5"), LocalStringManager.GetConfig("WorldState_language", "Desc_5"), "worldstate_icon_19", new string[0], new string[0], -1, -1, null));
		_dataArray.Add(new WorldStateItem(6, LocalStringManager.GetConfig("WorldState_language", "Name_6"), LocalStringManager.GetConfig("WorldState_language", "Desc_6"), "worldstate_icon_23", new string[0], new string[0], -1, -1, null));
		_dataArray.Add(new WorldStateItem(7, LocalStringManager.GetConfig("WorldState_language", "Name_7"), LocalStringManager.GetConfig("WorldState_language", "Desc_7"), "worldstate_icon_24", new string[0], new string[0], -1, -1, null));
		_dataArray.Add(new WorldStateItem(8, LocalStringManager.GetConfig("WorldState_language", "Name_8"), LocalStringManager.GetConfig("WorldState_language", "Desc_8"), "worldstate_icon_18", new string[0], new string[0], -1, -1, null));
		_dataArray.Add(new WorldStateItem(9, LocalStringManager.GetConfig("WorldState_language", "Name_9"), LocalStringManager.GetConfig("WorldState_language", "Desc_9"), "worldstate_icon_65", new string[0], new string[0], -1, -1, null));
		_dataArray.Add(new WorldStateItem(10, LocalStringManager.GetConfig("WorldState_language", "Name_10"), LocalStringManager.GetConfig("WorldState_language", "Desc_10"), "worldstate_icon_83", new string[0], new string[0], -1, -1, null));
		_dataArray.Add(new WorldStateItem(11, LocalStringManager.GetConfig("WorldState_language", "Name_11"), LocalStringManager.GetConfig("WorldState_language", "Desc_11"), "worldstate_icon_7", new string[0], new string[0], -1, -1, null));
		_dataArray.Add(new WorldStateItem(12, LocalStringManager.GetConfig("WorldState_language", "Name_12"), LocalStringManager.GetConfig("WorldState_language", "Desc_12"), "worldstate_icon_5", new string[0], new string[0], -1, -1, null));
		_dataArray.Add(new WorldStateItem(13, LocalStringManager.GetConfig("WorldState_language", "Name_13"), LocalStringManager.GetConfig("WorldState_language", "Desc_13"), "worldstate_icon_6", new string[0], new string[0], -1, -1, null));
		_dataArray.Add(new WorldStateItem(14, LocalStringManager.GetConfig("WorldState_language", "Name_14"), LocalStringManager.GetConfig("WorldState_language", "Desc_14"), "worldstate_icon_13", new string[0], new string[0], -1, -1, null));
		_dataArray.Add(new WorldStateItem(15, LocalStringManager.GetConfig("WorldState_language", "Name_15"), LocalStringManager.GetConfig("WorldState_language", "Desc_15"), "worldstate_icon_12", new string[0], new string[0], -1, -1, null));
		_dataArray.Add(new WorldStateItem(16, LocalStringManager.GetConfig("WorldState_language", "Name_16"), LocalStringManager.GetConfig("WorldState_language", "Desc_16"), "worldstate_icon_8", new string[0], new string[0], -1, -1, null));
		_dataArray.Add(new WorldStateItem(17, LocalStringManager.GetConfig("WorldState_language", "Name_17"), LocalStringManager.GetConfig("WorldState_language", "Desc_17"), "worldstate_icon_9", new string[0], new string[0], -1, -1, null));
		_dataArray.Add(new WorldStateItem(18, LocalStringManager.GetConfig("WorldState_language", "Name_18"), LocalStringManager.GetConfig("WorldState_language", "Desc_18"), "worldstate_icon_17", new string[0], new string[0], -1, -1, null));
		_dataArray.Add(new WorldStateItem(19, LocalStringManager.GetConfig("WorldState_language", "Name_19"), LocalStringManager.GetConfig("WorldState_language", "Desc_19"), "worldstate_icon_16", new string[0], new string[0], -1, -1, null));
		_dataArray.Add(new WorldStateItem(20, LocalStringManager.GetConfig("WorldState_language", "Name_20"), LocalStringManager.GetConfig("WorldState_language", "Desc_20"), "worldstate_icon_15", new string[0], new string[0], -1, -1, null));
		_dataArray.Add(new WorldStateItem(21, LocalStringManager.GetConfig("WorldState_language", "Name_21"), LocalStringManager.GetConfig("WorldState_language", "Desc_21"), "worldstate_icon_14", new string[0], new string[0], -1, -1, null));
		_dataArray.Add(new WorldStateItem(22, LocalStringManager.GetConfig("WorldState_language", "Name_22"), LocalStringManager.GetConfig("WorldState_language", "Desc_22"), "worldstate_icon_3", new string[0], new string[0], -1, -1, null));
		_dataArray.Add(new WorldStateItem(23, LocalStringManager.GetConfig("WorldState_language", "Name_23"), LocalStringManager.GetConfig("WorldState_language", "Desc_23"), "worldstate_icon_3", new string[0], new string[0], -1, -1, null));
		_dataArray.Add(new WorldStateItem(24, LocalStringManager.GetConfig("WorldState_language", "Name_24"), LocalStringManager.GetConfig("WorldState_language", "Desc_24"), "worldstate_icon_3", new string[0], new string[0], -1, -1, null));
		_dataArray.Add(new WorldStateItem(25, LocalStringManager.GetConfig("WorldState_language", "Name_25"), LocalStringManager.GetConfig("WorldState_language", "Desc_25"), "worldstate_icon_77", new string[2]
		{
			LocalStringManager.GetConfig("WorldState_language", "SectStoryCondition_25_0"),
			LocalStringManager.GetConfig("WorldState_language", "SectStoryCondition_25_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("WorldState_language", "SectStoryConditionTaiwuAsXiangshu_25_0"),
			LocalStringManager.GetConfig("WorldState_language", "SectStoryConditionTaiwuAsXiangshu_25_1")
		}, 1, 16, null));
		_dataArray.Add(new WorldStateItem(26, LocalStringManager.GetConfig("WorldState_language", "Name_26"), LocalStringManager.GetConfig("WorldState_language", "Desc_26"), "worldstate_icon_67", new string[2]
		{
			LocalStringManager.GetConfig("WorldState_language", "SectStoryCondition_26_0"),
			LocalStringManager.GetConfig("WorldState_language", "SectStoryCondition_26_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("WorldState_language", "SectStoryConditionTaiwuAsXiangshu_26_0"),
			LocalStringManager.GetConfig("WorldState_language", "SectStoryConditionTaiwuAsXiangshu_26_1")
		}, 2, 17, null));
		_dataArray.Add(new WorldStateItem(27, LocalStringManager.GetConfig("WorldState_language", "Name_27"), LocalStringManager.GetConfig("WorldState_language", "Desc_27"), "worldstate_icon_70", new string[2]
		{
			LocalStringManager.GetConfig("WorldState_language", "SectStoryCondition_27_0"),
			LocalStringManager.GetConfig("WorldState_language", "SectStoryCondition_27_1")
		}, new string[1] { LocalStringManager.GetConfig("WorldState_language", "SectStoryConditionTaiwuAsXiangshu_27_0") }, 3, 18, null));
		_dataArray.Add(new WorldStateItem(28, LocalStringManager.GetConfig("WorldState_language", "Name_28"), LocalStringManager.GetConfig("WorldState_language", "Desc_28"), "worldstate_icon_73", new string[2]
		{
			LocalStringManager.GetConfig("WorldState_language", "SectStoryCondition_28_0"),
			LocalStringManager.GetConfig("WorldState_language", "SectStoryCondition_28_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("WorldState_language", "SectStoryConditionTaiwuAsXiangshu_28_0"),
			LocalStringManager.GetConfig("WorldState_language", "SectStoryConditionTaiwuAsXiangshu_28_1")
		}, 4, 19, null));
		_dataArray.Add(new WorldStateItem(29, LocalStringManager.GetConfig("WorldState_language", "Name_29"), LocalStringManager.GetConfig("WorldState_language", "Desc_29"), "worldstate_icon_82", new string[3]
		{
			LocalStringManager.GetConfig("WorldState_language", "SectStoryCondition_29_0"),
			LocalStringManager.GetConfig("WorldState_language", "SectStoryCondition_29_1"),
			LocalStringManager.GetConfig("WorldState_language", "SectStoryCondition_29_2")
		}, new string[2]
		{
			LocalStringManager.GetConfig("WorldState_language", "SectStoryConditionTaiwuAsXiangshu_29_0"),
			LocalStringManager.GetConfig("WorldState_language", "SectStoryConditionTaiwuAsXiangshu_29_1")
		}, 5, 20, null));
		_dataArray.Add(new WorldStateItem(30, LocalStringManager.GetConfig("WorldState_language", "Name_30"), LocalStringManager.GetConfig("WorldState_language", "Desc_30"), "worldstate_icon_78", new string[2]
		{
			LocalStringManager.GetConfig("WorldState_language", "SectStoryCondition_30_0"),
			LocalStringManager.GetConfig("WorldState_language", "SectStoryCondition_30_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("WorldState_language", "SectStoryConditionTaiwuAsXiangshu_30_0"),
			LocalStringManager.GetConfig("WorldState_language", "SectStoryConditionTaiwuAsXiangshu_30_1")
		}, 6, -1, null));
		_dataArray.Add(new WorldStateItem(31, LocalStringManager.GetConfig("WorldState_language", "Name_31"), LocalStringManager.GetConfig("WorldState_language", "Desc_31"), "worldstate_icon_69", new string[3]
		{
			LocalStringManager.GetConfig("WorldState_language", "SectStoryCondition_31_0"),
			LocalStringManager.GetConfig("WorldState_language", "SectStoryCondition_31_1"),
			LocalStringManager.GetConfig("WorldState_language", "SectStoryCondition_31_2")
		}, new string[3]
		{
			LocalStringManager.GetConfig("WorldState_language", "SectStoryConditionTaiwuAsXiangshu_31_0"),
			LocalStringManager.GetConfig("WorldState_language", "SectStoryConditionTaiwuAsXiangshu_31_1"),
			LocalStringManager.GetConfig("WorldState_language", "SectStoryConditionTaiwuAsXiangshu_31_2")
		}, 7, -1, null));
		_dataArray.Add(new WorldStateItem(32, LocalStringManager.GetConfig("WorldState_language", "Name_32"), LocalStringManager.GetConfig("WorldState_language", "Desc_32"), "worldstate_icon_75", new string[2]
		{
			LocalStringManager.GetConfig("WorldState_language", "SectStoryCondition_32_0"),
			LocalStringManager.GetConfig("WorldState_language", "SectStoryCondition_32_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("WorldState_language", "SectStoryConditionTaiwuAsXiangshu_32_0"),
			LocalStringManager.GetConfig("WorldState_language", "SectStoryConditionTaiwuAsXiangshu_32_1")
		}, 8, 23, null));
		_dataArray.Add(new WorldStateItem(33, LocalStringManager.GetConfig("WorldState_language", "Name_33"), LocalStringManager.GetConfig("WorldState_language", "Desc_33"), "worldstate_icon_71", new string[2]
		{
			LocalStringManager.GetConfig("WorldState_language", "SectStoryCondition_33_0"),
			LocalStringManager.GetConfig("WorldState_language", "SectStoryCondition_33_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("WorldState_language", "SectStoryConditionTaiwuAsXiangshu_33_0"),
			LocalStringManager.GetConfig("WorldState_language", "SectStoryConditionTaiwuAsXiangshu_33_1")
		}, 9, -1, null));
		_dataArray.Add(new WorldStateItem(34, LocalStringManager.GetConfig("WorldState_language", "Name_34"), LocalStringManager.GetConfig("WorldState_language", "Desc_34"), "worldstate_icon_72", new string[2]
		{
			LocalStringManager.GetConfig("WorldState_language", "SectStoryCondition_34_0"),
			LocalStringManager.GetConfig("WorldState_language", "SectStoryCondition_34_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("WorldState_language", "SectStoryConditionTaiwuAsXiangshu_34_0"),
			LocalStringManager.GetConfig("WorldState_language", "SectStoryConditionTaiwuAsXiangshu_34_1")
		}, 10, 25, null));
		_dataArray.Add(new WorldStateItem(35, LocalStringManager.GetConfig("WorldState_language", "Name_35"), LocalStringManager.GetConfig("WorldState_language", "Desc_35"), "worldstate_icon_79", new string[2]
		{
			LocalStringManager.GetConfig("WorldState_language", "SectStoryCondition_35_0"),
			LocalStringManager.GetConfig("WorldState_language", "SectStoryCondition_35_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("WorldState_language", "SectStoryConditionTaiwuAsXiangshu_35_0"),
			LocalStringManager.GetConfig("WorldState_language", "SectStoryConditionTaiwuAsXiangshu_35_1")
		}, 11, -1, null));
		_dataArray.Add(new WorldStateItem(36, LocalStringManager.GetConfig("WorldState_language", "Name_36"), LocalStringManager.GetConfig("WorldState_language", "Desc_36"), "worldstate_icon_76", new string[2]
		{
			LocalStringManager.GetConfig("WorldState_language", "SectStoryCondition_36_0"),
			LocalStringManager.GetConfig("WorldState_language", "SectStoryCondition_36_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("WorldState_language", "SectStoryConditionTaiwuAsXiangshu_36_0"),
			LocalStringManager.GetConfig("WorldState_language", "SectStoryConditionTaiwuAsXiangshu_36_1")
		}, 12, 27, null));
		_dataArray.Add(new WorldStateItem(37, LocalStringManager.GetConfig("WorldState_language", "Name_37"), LocalStringManager.GetConfig("WorldState_language", "Desc_37"), "worldstate_icon_26", new string[3]
		{
			LocalStringManager.GetConfig("WorldState_language", "SectStoryCondition_37_0"),
			LocalStringManager.GetConfig("WorldState_language", "SectStoryCondition_37_1"),
			LocalStringManager.GetConfig("WorldState_language", "SectStoryCondition_37_2")
		}, new string[2]
		{
			LocalStringManager.GetConfig("WorldState_language", "SectStoryConditionTaiwuAsXiangshu_37_0"),
			LocalStringManager.GetConfig("WorldState_language", "SectStoryConditionTaiwuAsXiangshu_37_1")
		}, 13, 13, null));
		_dataArray.Add(new WorldStateItem(38, LocalStringManager.GetConfig("WorldState_language", "Name_38"), LocalStringManager.GetConfig("WorldState_language", "Desc_38"), "worldstate_icon_74", new string[2]
		{
			LocalStringManager.GetConfig("WorldState_language", "SectStoryCondition_38_0"),
			LocalStringManager.GetConfig("WorldState_language", "SectStoryCondition_38_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("WorldState_language", "SectStoryConditionTaiwuAsXiangshu_38_0"),
			LocalStringManager.GetConfig("WorldState_language", "SectStoryConditionTaiwuAsXiangshu_38_1")
		}, 14, 29, null));
		_dataArray.Add(new WorldStateItem(39, LocalStringManager.GetConfig("WorldState_language", "Name_39"), LocalStringManager.GetConfig("WorldState_language", "Desc_39"), "worldstate_icon_68", new string[1] { LocalStringManager.GetConfig("WorldState_language", "SectStoryCondition_39_0") }, new string[1] { LocalStringManager.GetConfig("WorldState_language", "SectStoryConditionTaiwuAsXiangshu_39_0") }, 15, 15, null));
		_dataArray.Add(new WorldStateItem(40, LocalStringManager.GetConfig("WorldState_language", "Name_40"), LocalStringManager.GetConfig("WorldState_language", "Desc_40"), "worldstate_icon_27", new string[0], new string[0], -1, -1, null));
		_dataArray.Add(new WorldStateItem(41, LocalStringManager.GetConfig("WorldState_language", "Name_41"), LocalStringManager.GetConfig("WorldState_language", "Desc_41"), "worldstate_icon_28", new string[0], new string[0], -1, -1, null));
		_dataArray.Add(new WorldStateItem(42, LocalStringManager.GetConfig("WorldState_language", "Name_42"), LocalStringManager.GetConfig("WorldState_language", "Desc_42"), "worldstate_icon_29", new string[0], new string[0], -1, -1, null));
		_dataArray.Add(new WorldStateItem(43, LocalStringManager.GetConfig("WorldState_language", "Name_43"), LocalStringManager.GetConfig("WorldState_language", "Desc_43"), "worldstate_icon_30", new string[0], new string[0], -1, -1, null));
		_dataArray.Add(new WorldStateItem(44, LocalStringManager.GetConfig("WorldState_language", "Name_44"), LocalStringManager.GetConfig("WorldState_language", "Desc_44"), "worldstate_icon_32", new string[0], new string[0], -1, -1, null));
		_dataArray.Add(new WorldStateItem(45, LocalStringManager.GetConfig("WorldState_language", "Name_45"), LocalStringManager.GetConfig("WorldState_language", "Desc_45"), "worldstate_icon_31", new string[0], new string[0], -1, -1, null));
		_dataArray.Add(new WorldStateItem(46, LocalStringManager.GetConfig("WorldState_language", "Name_46"), LocalStringManager.GetConfig("WorldState_language", "Desc_46"), "worldstate_icon_33", new string[0], new string[0], -1, -1, null));
		_dataArray.Add(new WorldStateItem(47, LocalStringManager.GetConfig("WorldState_language", "Name_47"), LocalStringManager.GetConfig("WorldState_language", "Desc_47"), "worldstate_icon_34", new string[0], new string[0], -1, -1, null));
		_dataArray.Add(new WorldStateItem(48, LocalStringManager.GetConfig("WorldState_language", "Name_48"), LocalStringManager.GetConfig("WorldState_language", "Desc_48"), "worldstate_icon_37", new string[0], new string[0], -1, -1, null));
		_dataArray.Add(new WorldStateItem(49, LocalStringManager.GetConfig("WorldState_language", "Name_49"), LocalStringManager.GetConfig("WorldState_language", "Desc_49"), "worldstate_icon_66", new string[0], new string[0], -1, -1, null));
		_dataArray.Add(new WorldStateItem(50, LocalStringManager.GetConfig("WorldState_language", "Name_50"), LocalStringManager.GetConfig("WorldState_language", "Desc_50"), "worldstate_icon_84", new string[0], new string[0], -1, -1, null));
		_dataArray.Add(new WorldStateItem(51, LocalStringManager.GetConfig("WorldState_language", "Name_51"), LocalStringManager.GetConfig("WorldState_language", "Desc_51"), "worldstate_icon_36", new string[0], new string[0], -1, -1, null));
		_dataArray.Add(new WorldStateItem(52, LocalStringManager.GetConfig("WorldState_language", "Name_52"), LocalStringManager.GetConfig("WorldState_language", "Desc_52"), "worldstate_icon_81", new string[0], new string[0], -1, -1, null));
		_dataArray.Add(new WorldStateItem(53, LocalStringManager.GetConfig("WorldState_language", "Name_53"), LocalStringManager.GetConfig("WorldState_language", "Desc_53"), "worldstate_icon_80", new string[0], new string[0], -1, -1, null));
		_dataArray.Add(new WorldStateItem(54, LocalStringManager.GetConfig("WorldState_language", "Name_54"), LocalStringManager.GetConfig("WorldState_language", "Desc_54"), "worldstate_icon_38", new string[0], new string[0], -1, -1, null));
		_dataArray.Add(new WorldStateItem(55, LocalStringManager.GetConfig("WorldState_language", "Name_55"), LocalStringManager.GetConfig("WorldState_language", "Desc_55"), "worldstate_icon_85", new string[0], new string[0], -1, -1, null));
		_dataArray.Add(new WorldStateItem(56, LocalStringManager.GetConfig("WorldState_language", "Name_56"), LocalStringManager.GetConfig("WorldState_language", "Desc_56"), "worldstate_icon_86", new string[0], new string[0], -1, -1, null));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<WorldStateItem>(57);
		CreateItems0();
	}
}

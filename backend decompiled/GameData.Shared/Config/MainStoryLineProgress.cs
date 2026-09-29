using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class MainStoryLineProgress : ConfigData<MainStoryLineProgressItem, short>
{
	public static class DefKey
	{
		public const short Beginning = 0;

		public const short ExploringValley = 1;

		public const short LeavingValley = 2;

		public const short EnteringSmallVillage = 3;

		public const short ExploringSmallVillage = 4;

		public const short LeavingSmallVillage = 5;

		public const short EnteringBrokenPerformArea = 6;

		public const short EnteringTaiwuVillage = 7;

		public const short InheritingTaiwu = 8;

		public const short DevelopingTaiwuVillage = 9;

		public const short MeetingImmortalXu = 10;

		public const short LeavingAncientTomb = 11;

		public const short FirstAppearanceOfXiangshuAvatar = 12;

		public const short DefeatOfImmortalXu = 13;

		public const short VisitOfOldMonk = 14;

		public const short LeavingOfOldMonk = 15;

		public const short ExploringTheState = 16;

		public const short LearningCombatSkill = 17;

		public const short ExploringTheWorld = 18;

		public const short DefeatingXiangshuAvatar1 = 19;

		public const short DefeatingXiangshuAvatar2 = 20;

		public const short DefeatingXiangshuAvatar3 = 21;

		public const short DefeatingXiangshuAvatar4 = 22;

		public const short DefeatingXiangshuAvatar5 = 23;

		public const short DefeatingXiangshuAvatar6 = 24;

		public const short DefeatingXiangshuAvatar7 = 25;

		public const short ReturnOfImmortalXu = 26;

		public const short SpiritualWanderPlace = 27;

		public const short LeaveOfImmortalXu = 28;

		public const short FinalRanChenDemon = 29;

		public const short FinalRanChenReincarnate = 30;

		public const short FinalXiangShuDormant = 31;

		public const short GameOver = 32;
	}

	public static class DefValue
	{
		public static MainStoryLineProgressItem Beginning => Instance[(short)0];

		public static MainStoryLineProgressItem ExploringValley => Instance[(short)1];

		public static MainStoryLineProgressItem LeavingValley => Instance[(short)2];

		public static MainStoryLineProgressItem EnteringSmallVillage => Instance[(short)3];

		public static MainStoryLineProgressItem ExploringSmallVillage => Instance[(short)4];

		public static MainStoryLineProgressItem LeavingSmallVillage => Instance[(short)5];

		public static MainStoryLineProgressItem EnteringBrokenPerformArea => Instance[(short)6];

		public static MainStoryLineProgressItem EnteringTaiwuVillage => Instance[(short)7];

		public static MainStoryLineProgressItem InheritingTaiwu => Instance[(short)8];

		public static MainStoryLineProgressItem DevelopingTaiwuVillage => Instance[(short)9];

		public static MainStoryLineProgressItem MeetingImmortalXu => Instance[(short)10];

		public static MainStoryLineProgressItem LeavingAncientTomb => Instance[(short)11];

		public static MainStoryLineProgressItem FirstAppearanceOfXiangshuAvatar => Instance[(short)12];

		public static MainStoryLineProgressItem DefeatOfImmortalXu => Instance[(short)13];

		public static MainStoryLineProgressItem VisitOfOldMonk => Instance[(short)14];

		public static MainStoryLineProgressItem LeavingOfOldMonk => Instance[(short)15];

		public static MainStoryLineProgressItem ExploringTheState => Instance[(short)16];

		public static MainStoryLineProgressItem LearningCombatSkill => Instance[(short)17];

		public static MainStoryLineProgressItem ExploringTheWorld => Instance[(short)18];

		public static MainStoryLineProgressItem DefeatingXiangshuAvatar1 => Instance[(short)19];

		public static MainStoryLineProgressItem DefeatingXiangshuAvatar2 => Instance[(short)20];

		public static MainStoryLineProgressItem DefeatingXiangshuAvatar3 => Instance[(short)21];

		public static MainStoryLineProgressItem DefeatingXiangshuAvatar4 => Instance[(short)22];

		public static MainStoryLineProgressItem DefeatingXiangshuAvatar5 => Instance[(short)23];

		public static MainStoryLineProgressItem DefeatingXiangshuAvatar6 => Instance[(short)24];

		public static MainStoryLineProgressItem DefeatingXiangshuAvatar7 => Instance[(short)25];

		public static MainStoryLineProgressItem ReturnOfImmortalXu => Instance[(short)26];

		public static MainStoryLineProgressItem SpiritualWanderPlace => Instance[(short)27];

		public static MainStoryLineProgressItem LeaveOfImmortalXu => Instance[(short)28];

		public static MainStoryLineProgressItem FinalRanChenDemon => Instance[(short)29];

		public static MainStoryLineProgressItem FinalRanChenReincarnate => Instance[(short)30];

		public static MainStoryLineProgressItem FinalXiangShuDormant => Instance[(short)31];

		public static MainStoryLineProgressItem GameOver => Instance[(short)32];
	}

	public static MainStoryLineProgress Instance = new MainStoryLineProgress();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "MainStoryName", "TemplateId", "MainStoryOrder" };

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
		_dataArray.Add(new MainStoryLineProgressItem(0, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_0"), 0));
		_dataArray.Add(new MainStoryLineProgressItem(1, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_1"), 1));
		_dataArray.Add(new MainStoryLineProgressItem(2, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_2"), 2));
		_dataArray.Add(new MainStoryLineProgressItem(3, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_3"), 3));
		_dataArray.Add(new MainStoryLineProgressItem(4, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_4"), 4));
		_dataArray.Add(new MainStoryLineProgressItem(5, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_5"), 5));
		_dataArray.Add(new MainStoryLineProgressItem(6, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_6"), 6));
		_dataArray.Add(new MainStoryLineProgressItem(7, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_7"), 7));
		_dataArray.Add(new MainStoryLineProgressItem(8, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_8"), 8));
		_dataArray.Add(new MainStoryLineProgressItem(9, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_9"), 9));
		_dataArray.Add(new MainStoryLineProgressItem(10, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_10"), 10));
		_dataArray.Add(new MainStoryLineProgressItem(11, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_11"), 11));
		_dataArray.Add(new MainStoryLineProgressItem(12, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_12"), 12));
		_dataArray.Add(new MainStoryLineProgressItem(13, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_13"), 13));
		_dataArray.Add(new MainStoryLineProgressItem(14, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_14"), 14));
		_dataArray.Add(new MainStoryLineProgressItem(15, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_15"), 15));
		_dataArray.Add(new MainStoryLineProgressItem(16, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_16"), 16));
		_dataArray.Add(new MainStoryLineProgressItem(17, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_17"), 17));
		_dataArray.Add(new MainStoryLineProgressItem(18, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_18"), 18));
		_dataArray.Add(new MainStoryLineProgressItem(19, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_19"), 19));
		_dataArray.Add(new MainStoryLineProgressItem(20, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_20"), 20));
		_dataArray.Add(new MainStoryLineProgressItem(21, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_21"), 21));
		_dataArray.Add(new MainStoryLineProgressItem(22, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_22"), 22));
		_dataArray.Add(new MainStoryLineProgressItem(23, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_23"), 23));
		_dataArray.Add(new MainStoryLineProgressItem(24, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_24"), 24));
		_dataArray.Add(new MainStoryLineProgressItem(25, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_25"), 25));
		_dataArray.Add(new MainStoryLineProgressItem(26, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_26"), 26));
		_dataArray.Add(new MainStoryLineProgressItem(27, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_27"), 27));
		_dataArray.Add(new MainStoryLineProgressItem(28, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_28"), 28));
		_dataArray.Add(new MainStoryLineProgressItem(29, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_29"), 29));
		_dataArray.Add(new MainStoryLineProgressItem(30, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_30"), 30));
		_dataArray.Add(new MainStoryLineProgressItem(31, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_31"), 31));
		_dataArray.Add(new MainStoryLineProgressItem(32, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_32"), 99));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<MainStoryLineProgressItem>(33);
		CreateItems0();
	}
}

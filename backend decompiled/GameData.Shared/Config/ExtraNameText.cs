using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class ExtraNameText : ConfigData<ExtraNameTextItem, int>
{
	public static class DefKey
	{
		public const int TaiwuSurname = 0;

		public const int NonSectTaoistFemale = 1;

		public const int NonSectTaoistMale = 2;

		public const int NonSectBuddhistFemale = 3;

		public const int NonSectBuddhistMale = 4;

		public const int UnknownCharName = 5;

		public const int SectMainStoryWudangMountainTree = 6;

		public const int SectMainStoryWudangCaveTree = 7;

		public const int SectMainStoryWudangCanyonTree = 8;

		public const int SectMainStoryWudangSwampTree = 9;

		public const int SectMainStoryWudangHillTree = 10;

		public const int SectMainStoryWudangTaoyuanTree = 11;

		public const int SectMainStoryWudangFieldTree = 12;

		public const int SectMainStoryWudangLakeTree = 13;

		public const int SectMainStoryWudangWoodTree = 14;

		public const int SectMainStoryWudangJungleTree = 15;

		public const int SectMainStoryWudangRiverBeachTree = 16;

		public const int SectMainStoryWudangValleyTree = 17;

		public const int NoNameInfantFemale = 18;

		public const int NoNameInfantMale = 19;

		public const int SectMainStoryWudangMountainTreeNormal = 20;

		public const int SectMainStoryWudangCaveTreeNormal = 21;

		public const int SectMainStoryWudangCanyonTreeNormal = 22;

		public const int SectMainStoryWudangSwampTreeNormal = 23;

		public const int SectMainStoryWudangHillTreeNormal = 24;

		public const int SectMainStoryWudangTaoyuanTreeNormal = 25;

		public const int SectMainStoryWudangFieldTreeNormal = 26;

		public const int SectMainStoryWudangLakeTreeNormal = 27;

		public const int SectMainStoryWudangWoodTreeNormal = 28;

		public const int SectMainStoryWudangJungleTreeNormal = 29;

		public const int SectMainStoryWudangRiverBeachTreeNormal = 30;

		public const int SectMainStoryWudangValleyTreeNormal = 31;
	}

	public static class DefValue
	{
		public static ExtraNameTextItem TaiwuSurname => Instance[0];

		public static ExtraNameTextItem NonSectTaoistFemale => Instance[1];

		public static ExtraNameTextItem NonSectTaoistMale => Instance[2];

		public static ExtraNameTextItem NonSectBuddhistFemale => Instance[3];

		public static ExtraNameTextItem NonSectBuddhistMale => Instance[4];

		public static ExtraNameTextItem UnknownCharName => Instance[5];

		public static ExtraNameTextItem SectMainStoryWudangMountainTree => Instance[6];

		public static ExtraNameTextItem SectMainStoryWudangCaveTree => Instance[7];

		public static ExtraNameTextItem SectMainStoryWudangCanyonTree => Instance[8];

		public static ExtraNameTextItem SectMainStoryWudangSwampTree => Instance[9];

		public static ExtraNameTextItem SectMainStoryWudangHillTree => Instance[10];

		public static ExtraNameTextItem SectMainStoryWudangTaoyuanTree => Instance[11];

		public static ExtraNameTextItem SectMainStoryWudangFieldTree => Instance[12];

		public static ExtraNameTextItem SectMainStoryWudangLakeTree => Instance[13];

		public static ExtraNameTextItem SectMainStoryWudangWoodTree => Instance[14];

		public static ExtraNameTextItem SectMainStoryWudangJungleTree => Instance[15];

		public static ExtraNameTextItem SectMainStoryWudangRiverBeachTree => Instance[16];

		public static ExtraNameTextItem SectMainStoryWudangValleyTree => Instance[17];

		public static ExtraNameTextItem NoNameInfantFemale => Instance[18];

		public static ExtraNameTextItem NoNameInfantMale => Instance[19];

		public static ExtraNameTextItem SectMainStoryWudangMountainTreeNormal => Instance[20];

		public static ExtraNameTextItem SectMainStoryWudangCaveTreeNormal => Instance[21];

		public static ExtraNameTextItem SectMainStoryWudangCanyonTreeNormal => Instance[22];

		public static ExtraNameTextItem SectMainStoryWudangSwampTreeNormal => Instance[23];

		public static ExtraNameTextItem SectMainStoryWudangHillTreeNormal => Instance[24];

		public static ExtraNameTextItem SectMainStoryWudangTaoyuanTreeNormal => Instance[25];

		public static ExtraNameTextItem SectMainStoryWudangFieldTreeNormal => Instance[26];

		public static ExtraNameTextItem SectMainStoryWudangLakeTreeNormal => Instance[27];

		public static ExtraNameTextItem SectMainStoryWudangWoodTreeNormal => Instance[28];

		public static ExtraNameTextItem SectMainStoryWudangJungleTreeNormal => Instance[29];

		public static ExtraNameTextItem SectMainStoryWudangRiverBeachTreeNormal => Instance[30];

		public static ExtraNameTextItem SectMainStoryWudangValleyTreeNormal => Instance[31];
	}

	public static ExtraNameText Instance = new ExtraNameText();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Content", "TemplateId" };

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
		_dataArray.Add(new ExtraNameTextItem(0, LocalStringManager.GetConfig("ExtraNameText_language", "Content_0")));
		_dataArray.Add(new ExtraNameTextItem(1, LocalStringManager.GetConfig("ExtraNameText_language", "Content_1")));
		_dataArray.Add(new ExtraNameTextItem(2, LocalStringManager.GetConfig("ExtraNameText_language", "Content_2")));
		_dataArray.Add(new ExtraNameTextItem(3, LocalStringManager.GetConfig("ExtraNameText_language", "Content_3")));
		_dataArray.Add(new ExtraNameTextItem(4, LocalStringManager.GetConfig("ExtraNameText_language", "Content_4")));
		_dataArray.Add(new ExtraNameTextItem(5, LocalStringManager.GetConfig("ExtraNameText_language", "Content_5")));
		_dataArray.Add(new ExtraNameTextItem(6, LocalStringManager.GetConfig("ExtraNameText_language", "Content_6")));
		_dataArray.Add(new ExtraNameTextItem(7, LocalStringManager.GetConfig("ExtraNameText_language", "Content_7")));
		_dataArray.Add(new ExtraNameTextItem(8, LocalStringManager.GetConfig("ExtraNameText_language", "Content_8")));
		_dataArray.Add(new ExtraNameTextItem(9, LocalStringManager.GetConfig("ExtraNameText_language", "Content_9")));
		_dataArray.Add(new ExtraNameTextItem(10, LocalStringManager.GetConfig("ExtraNameText_language", "Content_10")));
		_dataArray.Add(new ExtraNameTextItem(11, LocalStringManager.GetConfig("ExtraNameText_language", "Content_11")));
		_dataArray.Add(new ExtraNameTextItem(12, LocalStringManager.GetConfig("ExtraNameText_language", "Content_12")));
		_dataArray.Add(new ExtraNameTextItem(13, LocalStringManager.GetConfig("ExtraNameText_language", "Content_13")));
		_dataArray.Add(new ExtraNameTextItem(14, LocalStringManager.GetConfig("ExtraNameText_language", "Content_14")));
		_dataArray.Add(new ExtraNameTextItem(15, LocalStringManager.GetConfig("ExtraNameText_language", "Content_15")));
		_dataArray.Add(new ExtraNameTextItem(16, LocalStringManager.GetConfig("ExtraNameText_language", "Content_16")));
		_dataArray.Add(new ExtraNameTextItem(17, LocalStringManager.GetConfig("ExtraNameText_language", "Content_17")));
		_dataArray.Add(new ExtraNameTextItem(18, LocalStringManager.GetConfig("ExtraNameText_language", "Content_18")));
		_dataArray.Add(new ExtraNameTextItem(19, LocalStringManager.GetConfig("ExtraNameText_language", "Content_19")));
		_dataArray.Add(new ExtraNameTextItem(20, LocalStringManager.GetConfig("ExtraNameText_language", "Content_20")));
		_dataArray.Add(new ExtraNameTextItem(21, LocalStringManager.GetConfig("ExtraNameText_language", "Content_21")));
		_dataArray.Add(new ExtraNameTextItem(22, LocalStringManager.GetConfig("ExtraNameText_language", "Content_22")));
		_dataArray.Add(new ExtraNameTextItem(23, LocalStringManager.GetConfig("ExtraNameText_language", "Content_23")));
		_dataArray.Add(new ExtraNameTextItem(24, LocalStringManager.GetConfig("ExtraNameText_language", "Content_24")));
		_dataArray.Add(new ExtraNameTextItem(25, LocalStringManager.GetConfig("ExtraNameText_language", "Content_25")));
		_dataArray.Add(new ExtraNameTextItem(26, LocalStringManager.GetConfig("ExtraNameText_language", "Content_26")));
		_dataArray.Add(new ExtraNameTextItem(27, LocalStringManager.GetConfig("ExtraNameText_language", "Content_27")));
		_dataArray.Add(new ExtraNameTextItem(28, LocalStringManager.GetConfig("ExtraNameText_language", "Content_28")));
		_dataArray.Add(new ExtraNameTextItem(29, LocalStringManager.GetConfig("ExtraNameText_language", "Content_29")));
		_dataArray.Add(new ExtraNameTextItem(30, LocalStringManager.GetConfig("ExtraNameText_language", "Content_30")));
		_dataArray.Add(new ExtraNameTextItem(31, LocalStringManager.GetConfig("ExtraNameText_language", "Content_31")));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<ExtraNameTextItem>(32);
		CreateItems0();
	}
}

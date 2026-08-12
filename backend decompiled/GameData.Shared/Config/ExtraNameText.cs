using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class ExtraNameText : ConfigData<ExtraNameTextItem, int>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 太吾姓氏
		/// </summary>
		public const int TaiwuSurname = 0;

		/// <summary>
		/// 非门派女道
		/// </summary>
		public const int NonSectTaoistFemale = 1;

		/// <summary>
		/// 非门派男道
		/// </summary>
		public const int NonSectTaoistMale = 2;

		/// <summary>
		/// 非门派女僧
		/// </summary>
		public const int NonSectBuddhistFemale = 3;

		/// <summary>
		/// 非门派男僧
		/// </summary>
		public const int NonSectBuddhistMale = 4;

		/// <summary>
		/// 未知角色
		/// </summary>
		public const int UnknownCharName = 5;

		/// <summary>
		/// 山岳神木
		/// </summary>
		public const int SectMainStoryWudangMountainTree = 6;

		/// <summary>
		/// 洞穴神木
		/// </summary>
		public const int SectMainStoryWudangCaveTree = 7;

		/// <summary>
		/// 峡谷神木
		/// </summary>
		public const int SectMainStoryWudangCanyonTree = 8;

		/// <summary>
		/// 沼泽神木
		/// </summary>
		public const int SectMainStoryWudangSwampTree = 9;

		/// <summary>
		/// 丘陵神木
		/// </summary>
		public const int SectMainStoryWudangHillTree = 10;

		/// <summary>
		/// 桃源神木
		/// </summary>
		public const int SectMainStoryWudangTaoyuanTree = 11;

		/// <summary>
		/// 原野神木
		/// </summary>
		public const int SectMainStoryWudangFieldTree = 12;

		/// <summary>
		/// 湖泊神木
		/// </summary>
		public const int SectMainStoryWudangLakeTree = 13;

		/// <summary>
		/// 林地神木
		/// </summary>
		public const int SectMainStoryWudangWoodTree = 14;

		/// <summary>
		/// 密林神木
		/// </summary>
		public const int SectMainStoryWudangJungleTree = 15;

		/// <summary>
		/// 河滩神木
		/// </summary>
		public const int SectMainStoryWudangRiverBeachTree = 16;

		/// <summary>
		/// 溪谷神木
		/// </summary>
		public const int SectMainStoryWudangValleyTree = 17;

		/// <summary>
		/// 无名女婴
		/// </summary>
		public const int NoNameInfantFemale = 18;

		/// <summary>
		/// 无名男婴
		/// </summary>
		public const int NoNameInfantMale = 19;

		/// <summary>
		/// 山岳普通神木
		/// </summary>
		public const int SectMainStoryWudangMountainTreeNormal = 20;

		/// <summary>
		/// 洞穴普通神木
		/// </summary>
		public const int SectMainStoryWudangCaveTreeNormal = 21;

		/// <summary>
		/// 峡谷普通神木
		/// </summary>
		public const int SectMainStoryWudangCanyonTreeNormal = 22;

		/// <summary>
		/// 沼泽普通神木
		/// </summary>
		public const int SectMainStoryWudangSwampTreeNormal = 23;

		/// <summary>
		/// 丘陵普通神木
		/// </summary>
		public const int SectMainStoryWudangHillTreeNormal = 24;

		/// <summary>
		/// 桃源普通神木
		/// </summary>
		public const int SectMainStoryWudangTaoyuanTreeNormal = 25;

		/// <summary>
		/// 原野普通神木
		/// </summary>
		public const int SectMainStoryWudangFieldTreeNormal = 26;

		/// <summary>
		/// 湖泊普通神木
		/// </summary>
		public const int SectMainStoryWudangLakeTreeNormal = 27;

		/// <summary>
		/// 林地普通神木
		/// </summary>
		public const int SectMainStoryWudangWoodTreeNormal = 28;

		/// <summary>
		/// 密林普通神木
		/// </summary>
		public const int SectMainStoryWudangJungleTreeNormal = 29;

		/// <summary>
		/// 河滩普通神木
		/// </summary>
		public const int SectMainStoryWudangRiverBeachTreeNormal = 30;

		/// <summary>
		/// 溪谷普通神木
		/// </summary>
		public const int SectMainStoryWudangValleyTreeNormal = 31;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 太吾姓氏
		/// </summary>
		public static ExtraNameTextItem TaiwuSurname => Instance[0];

		/// <summary>
		/// 非门派女道
		/// </summary>
		public static ExtraNameTextItem NonSectTaoistFemale => Instance[1];

		/// <summary>
		/// 非门派男道
		/// </summary>
		public static ExtraNameTextItem NonSectTaoistMale => Instance[2];

		/// <summary>
		/// 非门派女僧
		/// </summary>
		public static ExtraNameTextItem NonSectBuddhistFemale => Instance[3];

		/// <summary>
		/// 非门派男僧
		/// </summary>
		public static ExtraNameTextItem NonSectBuddhistMale => Instance[4];

		/// <summary>
		/// 未知角色
		/// </summary>
		public static ExtraNameTextItem UnknownCharName => Instance[5];

		/// <summary>
		/// 山岳神木
		/// </summary>
		public static ExtraNameTextItem SectMainStoryWudangMountainTree => Instance[6];

		/// <summary>
		/// 洞穴神木
		/// </summary>
		public static ExtraNameTextItem SectMainStoryWudangCaveTree => Instance[7];

		/// <summary>
		/// 峡谷神木
		/// </summary>
		public static ExtraNameTextItem SectMainStoryWudangCanyonTree => Instance[8];

		/// <summary>
		/// 沼泽神木
		/// </summary>
		public static ExtraNameTextItem SectMainStoryWudangSwampTree => Instance[9];

		/// <summary>
		/// 丘陵神木
		/// </summary>
		public static ExtraNameTextItem SectMainStoryWudangHillTree => Instance[10];

		/// <summary>
		/// 桃源神木
		/// </summary>
		public static ExtraNameTextItem SectMainStoryWudangTaoyuanTree => Instance[11];

		/// <summary>
		/// 原野神木
		/// </summary>
		public static ExtraNameTextItem SectMainStoryWudangFieldTree => Instance[12];

		/// <summary>
		/// 湖泊神木
		/// </summary>
		public static ExtraNameTextItem SectMainStoryWudangLakeTree => Instance[13];

		/// <summary>
		/// 林地神木
		/// </summary>
		public static ExtraNameTextItem SectMainStoryWudangWoodTree => Instance[14];

		/// <summary>
		/// 密林神木
		/// </summary>
		public static ExtraNameTextItem SectMainStoryWudangJungleTree => Instance[15];

		/// <summary>
		/// 河滩神木
		/// </summary>
		public static ExtraNameTextItem SectMainStoryWudangRiverBeachTree => Instance[16];

		/// <summary>
		/// 溪谷神木
		/// </summary>
		public static ExtraNameTextItem SectMainStoryWudangValleyTree => Instance[17];

		/// <summary>
		/// 无名女婴
		/// </summary>
		public static ExtraNameTextItem NoNameInfantFemale => Instance[18];

		/// <summary>
		/// 无名男婴
		/// </summary>
		public static ExtraNameTextItem NoNameInfantMale => Instance[19];

		/// <summary>
		/// 山岳普通神木
		/// </summary>
		public static ExtraNameTextItem SectMainStoryWudangMountainTreeNormal => Instance[20];

		/// <summary>
		/// 洞穴普通神木
		/// </summary>
		public static ExtraNameTextItem SectMainStoryWudangCaveTreeNormal => Instance[21];

		/// <summary>
		/// 峡谷普通神木
		/// </summary>
		public static ExtraNameTextItem SectMainStoryWudangCanyonTreeNormal => Instance[22];

		/// <summary>
		/// 沼泽普通神木
		/// </summary>
		public static ExtraNameTextItem SectMainStoryWudangSwampTreeNormal => Instance[23];

		/// <summary>
		/// 丘陵普通神木
		/// </summary>
		public static ExtraNameTextItem SectMainStoryWudangHillTreeNormal => Instance[24];

		/// <summary>
		/// 桃源普通神木
		/// </summary>
		public static ExtraNameTextItem SectMainStoryWudangTaoyuanTreeNormal => Instance[25];

		/// <summary>
		/// 原野普通神木
		/// </summary>
		public static ExtraNameTextItem SectMainStoryWudangFieldTreeNormal => Instance[26];

		/// <summary>
		/// 湖泊普通神木
		/// </summary>
		public static ExtraNameTextItem SectMainStoryWudangLakeTreeNormal => Instance[27];

		/// <summary>
		/// 林地普通神木
		/// </summary>
		public static ExtraNameTextItem SectMainStoryWudangWoodTreeNormal => Instance[28];

		/// <summary>
		/// 密林普通神木
		/// </summary>
		public static ExtraNameTextItem SectMainStoryWudangJungleTreeNormal => Instance[29];

		/// <summary>
		/// 河滩普通神木
		/// </summary>
		public static ExtraNameTextItem SectMainStoryWudangRiverBeachTreeNormal => Instance[30];

		/// <summary>
		/// 溪谷普通神木
		/// </summary>
		public static ExtraNameTextItem SectMainStoryWudangValleyTreeNormal => Instance[31];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
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

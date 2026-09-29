using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class SectMainStory : ConfigData<SectMainStoryItem, sbyte>
{
	public static class DefKey
	{
		public const sbyte Shaolin = 0;

		public const sbyte Emei = 1;

		public const sbyte Baihua = 2;

		public const sbyte Wudang = 3;

		public const sbyte Yuanshan = 4;

		public const sbyte Shixiang = 5;

		public const sbyte Ranshan = 6;

		public const sbyte Xuannv = 7;

		public const sbyte Zhujian = 8;

		public const sbyte Kongsang = 9;

		public const sbyte Jingang = 10;

		public const sbyte Wuxian = 11;

		public const sbyte Jieqing = 12;

		public const sbyte Fulong = 13;

		public const sbyte Xuehou = 14;
	}

	public static class DefValue
	{
		public static SectMainStoryItem Shaolin => Instance[(sbyte)0];

		public static SectMainStoryItem Emei => Instance[(sbyte)1];

		public static SectMainStoryItem Baihua => Instance[(sbyte)2];

		public static SectMainStoryItem Wudang => Instance[(sbyte)3];

		public static SectMainStoryItem Yuanshan => Instance[(sbyte)4];

		public static SectMainStoryItem Shixiang => Instance[(sbyte)5];

		public static SectMainStoryItem Ranshan => Instance[(sbyte)6];

		public static SectMainStoryItem Xuannv => Instance[(sbyte)7];

		public static SectMainStoryItem Zhujian => Instance[(sbyte)8];

		public static SectMainStoryItem Kongsang => Instance[(sbyte)9];

		public static SectMainStoryItem Jingang => Instance[(sbyte)10];

		public static SectMainStoryItem Wuxian => Instance[(sbyte)11];

		public static SectMainStoryItem Jieqing => Instance[(sbyte)12];

		public static SectMainStoryItem Fulong => Instance[(sbyte)13];

		public static SectMainStoryItem Xuehou => Instance[(sbyte)14];
	}

	public static SectMainStory Instance = new SectMainStory();

	private readonly HashSet<string> RequiredFields = new HashSet<string>
	{
		"Name", "UnlockStoryDesc", "TaskChains", "TaskReadyWorldState", "GoodEndingsInformation", "BadEndingsInformation", "GoodEndingMonthlyEvent", "BadEndingMonthlyEvent", "TemplateId", "UnlockStoryLogo",
		"UnlockStoryBg", "GoodEndDateKey", "BadEndDateKey"
	};

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
		_dataArray.Add(new SectMainStoryItem(0, LocalStringManager.GetConfig("SectMainStory_language", "Name_0"), "ui9_tex_story_text_1", "ui9_tex_story_bg_1", LocalStringManager.GetConfig("SectMainStory_language", "UnlockStoryDesc_0"), new int[1] { 27 }, 25, new List<short> { 59 }, new List<short> { 60 }, 198, 199, "ConchShip_PresetKey_SectMainStoryShaolinProsperousEndDate", "ConchShip_PresetKey_SectMainStoryShaolinFailingEndDate", 0));
		_dataArray.Add(new SectMainStoryItem(1, LocalStringManager.GetConfig("SectMainStory_language", "Name_1"), "ui9_tex_story_text_2", "ui9_tex_story_bg_2", LocalStringManager.GetConfig("SectMainStory_language", "UnlockStoryDesc_1"), new int[3] { 172, 173, 174 }, 26, new List<short> { 73 }, new List<short> { 72 }, 234, 235, "ConchShip_PresetKey_SectMainStoryEmeiProsperousEndDate", "ConchShip_PresetKey_SectMainStoryEmeiFailingEndDate", 0));
		_dataArray.Add(new SectMainStoryItem(2, LocalStringManager.GetConfig("SectMainStory_language", "Name_2"), "ui9_tex_story_text_3", "ui9_tex_story_bg_3", LocalStringManager.GetConfig("SectMainStory_language", "UnlockStoryDesc_2"), new int[3] { 43, 45, 46 }, 27, new List<short> { 107 }, new List<short> { 108 }, 315, 316, "ConchShip_PresetKey_SectMainStoryBaihuaProsperousEndDate", "ConchShip_PresetKey_SectMainStoryBaihuaFailingEndDate", 5));
		_dataArray.Add(new SectMainStoryItem(3, LocalStringManager.GetConfig("SectMainStory_language", "Name_3"), "ui9_tex_story_text_4", "ui9_tex_story_bg_4", LocalStringManager.GetConfig("SectMainStory_language", "UnlockStoryDesc_3"), new int[2] { 29, 36 }, 28, new List<short> { 61 }, new List<short> { 62 }, 208, 209, "ConchShip_PresetKey_SectMainStoryWudangProsperousEndDate", "ConchShip_PresetKey_SectMainStoryWudangFailingEndDate", 0));
		_dataArray.Add(new SectMainStoryItem(4, LocalStringManager.GetConfig("SectMainStory_language", "Name_4"), "ui9_tex_story_text_5", "ui9_tex_story_bg_5", LocalStringManager.GetConfig("SectMainStory_language", "UnlockStoryDesc_4"), new int[1] { 30 }, 29, new List<short> { 65 }, new List<short> { 66 }, -1, 362, "ConchShip_PresetKey_SectMainStoryYuanshanProsperousEndDate", "ConchShip_PresetKey_SectMainStoryYuanshanFailingEndDate", 4));
		_dataArray.Add(new SectMainStoryItem(5, LocalStringManager.GetConfig("SectMainStory_language", "Name_5"), "ui9_tex_story_text_6", "ui9_tex_story_bg_6", LocalStringManager.GetConfig("SectMainStory_language", "UnlockStoryDesc_5"), new int[1] { 31 }, 30, new List<short> { 67 }, new List<short> { 68 }, 253, 218, "ConchShip_PresetKey_SectMainStoryShixiangProsperousEndDate", "ConchShip_PresetKey_SectMainStoryShixiangFailingEndDate", 0));
		_dataArray.Add(new SectMainStoryItem(6, LocalStringManager.GetConfig("SectMainStory_language", "Name_6"), "ui9_tex_story_text_7", "ui9_tex_story_bg_7", LocalStringManager.GetConfig("SectMainStory_language", "UnlockStoryDesc_6"), new int[2] { 35, 44 }, 31, new List<short> { 76 }, new List<short> { 77 }, 244, 245, "ConchShip_PresetKey_SectMainStoryRanshanProsperousEndDate", "ConchShip_PresetKey_SectMainStoryRanshanFailingEndDate", 0));
		_dataArray.Add(new SectMainStoryItem(7, LocalStringManager.GetConfig("SectMainStory_language", "Name_7"), "ui9_tex_story_text_8", "ui9_tex_story_bg_8", LocalStringManager.GetConfig("SectMainStory_language", "UnlockStoryDesc_7"), new int[1] { 28 }, 32, new List<short> { 63 }, new List<short> { 64 }, 203, 204, "ConchShip_PresetKey_SectMainStoryXuannvProsperousEndDate", "ConchShip_PresetKey_SectMainStoryXuannvFailingEndDate", 0));
		_dataArray.Add(new SectMainStoryItem(8, LocalStringManager.GetConfig("SectMainStory_language", "Name_8"), "ui9_tex_story_text_9", "ui9_tex_story_bg_9", LocalStringManager.GetConfig("SectMainStory_language", "UnlockStoryDesc_8"), new int[2] { 49, 50 }, 33, new List<short> { 120 }, new List<short> { 121 }, 351, 352, "ConchShip_PresetKey_SectMainStoryZhujianProsperousEndDate", "ConchShip_PresetKey_SectMainStoryZhujianFailingEndDate", 0));
		_dataArray.Add(new SectMainStoryItem(9, LocalStringManager.GetConfig("SectMainStory_language", "Name_9"), "ui9_tex_story_text_10", "ui9_tex_story_bg_10", LocalStringManager.GetConfig("SectMainStory_language", "UnlockStoryDesc_9"), new int[1] { 24 }, 34, new List<short> { 55 }, new List<short> { 56 }, 170, 171, "ConchShip_PresetKey_SectMainStoryKongsangProsperousEndDate", "ConchShip_PresetKey_SectMainStoryKongsangFailingEndDate", 0));
		_dataArray.Add(new SectMainStoryItem(10, LocalStringManager.GetConfig("SectMainStory_language", "Name_10"), "ui9_tex_story_text_11", "ui9_tex_story_bg_11", LocalStringManager.GetConfig("SectMainStory_language", "UnlockStoryDesc_10"), new int[1] { 32 }, 35, new List<short> { 78 }, new List<short> { 79 }, 225, 226, "ConchShip_PresetKey_SectMainStoryJingangProsperousEndDate", "ConchShip_PresetKey_SectMainStoryJingangFailingEndDate", 0));
		_dataArray.Add(new SectMainStoryItem(11, LocalStringManager.GetConfig("SectMainStory_language", "Name_11"), "ui9_tex_story_text_12", "ui9_tex_story_bg_12", LocalStringManager.GetConfig("SectMainStory_language", "UnlockStoryDesc_11"), new int[1] { 33 }, 36, new List<short> { 69 }, new List<short> { 70, 71 }, -1, -1, "ConchShip_PresetKey_SectMainStoryWuxianProsperousEndDate", "ConchShip_PresetKey_SectMainStoryWuxianFailingEndDate", 0));
		_dataArray.Add(new SectMainStoryItem(12, LocalStringManager.GetConfig("SectMainStory_language", "Name_12"), "ui9_tex_story_text_13", "ui9_tex_story_bg_13", LocalStringManager.GetConfig("SectMainStory_language", "UnlockStoryDesc_12"), new int[1] { 52 }, 37, new List<short> { 75 }, new List<short> { 74 }, 236, 237, "ConchShip_PresetKey_SectMainStoryJieqingProsperousEndDate", "ConchShip_PresetKey_SectMainStoryJieqingFailingEndDate", 4));
		_dataArray.Add(new SectMainStoryItem(13, LocalStringManager.GetConfig("SectMainStory_language", "Name_13"), "ui9_tex_story_text_14", "ui9_tex_story_bg_14", LocalStringManager.GetConfig("SectMainStory_language", "UnlockStoryDesc_13"), new int[1] { 47 }, 38, new List<short> { 109 }, new List<short> { 110 }, 334, 335, "ConchShip_PresetKey_SectMainStoryFulongProsperousEndDate", "ConchShip_PresetKey_SectMainStoryFulongFailingEndDate", 0));
		_dataArray.Add(new SectMainStoryItem(14, LocalStringManager.GetConfig("SectMainStory_language", "Name_14"), "ui9_tex_story_text_15", "ui9_tex_story_bg_15", LocalStringManager.GetConfig("SectMainStory_language", "UnlockStoryDesc_14"), new int[2] { 25, 26 }, 39, new List<short> { 57 }, new List<short> { 58 }, 188, 189, "ConchShip_PresetKey_SectMainStoryXuehouProsperousEndDate", "ConchShip_PresetKey_SectMainStoryXuehouFailingEndDate", 0));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<SectMainStoryItem>(15);
		CreateItems0();
	}
}

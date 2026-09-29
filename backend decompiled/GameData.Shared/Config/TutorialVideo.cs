using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class TutorialVideo : ConfigData<TutorialVideoItem, short>
{
	public static TutorialVideo Instance = new TutorialVideo();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "PartsTitle", "PartsDesc", "Chapter", "ChapterName", "VideoSummary", "TemplateId", "VideoPath", "PartVideos", "CustomPosition" };

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
		_dataArray.Add(new TutorialVideoItem(0, "Tutorial_Chapter_1_1", LocalStringManager.GetConfig("TutorialVideo_language", "Name_0"), new string[2]
		{
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_0_0"),
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_0_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_0_0"),
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_0_1")
		}, new string[2] { "Tutorial_Chapter_1_1a", "Tutorial_Chapter_1_1b" }, 0, 0, LocalStringManager.GetConfig("TutorialVideo_language", "ChapterName_0"), LocalStringManager.GetConfig("TutorialVideo_language", "VideoSummary_0"), null));
		_dataArray.Add(new TutorialVideoItem(1, "Tutorial_Chapter_1_2", LocalStringManager.GetConfig("TutorialVideo_language", "Name_1"), new string[4]
		{
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_1_0"),
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_1_1"),
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_1_2"),
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_1_3")
		}, new string[4]
		{
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_1_0"),
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_1_1"),
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_1_2"),
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_1_3")
		}, new string[4] { "Tutorial_Chapter_1_2a", "Tutorial_Chapter_1_2b", "Tutorial_Chapter_1_2c", "Tutorial_Chapter_1_2d" }, 0, 1, LocalStringManager.GetConfig("TutorialVideo_language", "ChapterName_1"), LocalStringManager.GetConfig("TutorialVideo_language", "VideoSummary_1"), null));
		_dataArray.Add(new TutorialVideoItem(2, "Tutorial_Chapter_1_3", LocalStringManager.GetConfig("TutorialVideo_language", "Name_2"), new string[3]
		{
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_2_0"),
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_2_1"),
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_2_2")
		}, new string[3]
		{
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_2_0"),
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_2_1"),
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_2_2")
		}, new string[3] { "Tutorial_Chapter_1_3a", "Tutorial_Chapter_1_3b", "Tutorial_Chapter_1_3c" }, 0, 2, LocalStringManager.GetConfig("TutorialVideo_language", "ChapterName_2"), LocalStringManager.GetConfig("TutorialVideo_language", "VideoSummary_2"), null));
		_dataArray.Add(new TutorialVideoItem(3, "Tutorial_Chapter_1_4", LocalStringManager.GetConfig("TutorialVideo_language", "Name_3"), new string[1] { LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_3_0") }, new string[1] { LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_3_0") }, new string[1] { "Tutorial_Chapter_1_4a" }, 0, 3, LocalStringManager.GetConfig("TutorialVideo_language", "ChapterName_3"), LocalStringManager.GetConfig("TutorialVideo_language", "VideoSummary_3"), null));
		_dataArray.Add(new TutorialVideoItem(4, "Tutorial_Chapter_2_1", LocalStringManager.GetConfig("TutorialVideo_language", "Name_4"), new string[1] { LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_4_0") }, new string[1] { LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_4_0") }, new string[1] { "Tutorial_Chapter_2_1a" }, 1, 0, LocalStringManager.GetConfig("TutorialVideo_language", "ChapterName_4"), LocalStringManager.GetConfig("TutorialVideo_language", "VideoSummary_4"), null));
		_dataArray.Add(new TutorialVideoItem(5, "Tutorial_Chapter_2_2", LocalStringManager.GetConfig("TutorialVideo_language", "Name_5"), new string[3]
		{
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_5_0"),
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_5_1"),
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_5_2")
		}, new string[3]
		{
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_5_0"),
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_5_1"),
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_5_2")
		}, new string[3] { "Tutorial_Chapter_2_2a", "Tutorial_Chapter_2_2b", "Tutorial_Chapter_2_2c" }, 1, 1, LocalStringManager.GetConfig("TutorialVideo_language", "ChapterName_5"), LocalStringManager.GetConfig("TutorialVideo_language", "VideoSummary_5"), null));
		_dataArray.Add(new TutorialVideoItem(6, "Tutorial_Chapter_2_3", LocalStringManager.GetConfig("TutorialVideo_language", "Name_6"), new string[1] { LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_6_0") }, new string[1] { LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_6_0") }, new string[1] { "Tutorial_Chapter_2_3a" }, 1, 2, LocalStringManager.GetConfig("TutorialVideo_language", "ChapterName_6"), LocalStringManager.GetConfig("TutorialVideo_language", "VideoSummary_6"), null));
		_dataArray.Add(new TutorialVideoItem(7, "Tutorial_Chapter_3_1", LocalStringManager.GetConfig("TutorialVideo_language", "Name_7"), new string[1] { LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_7_0") }, new string[1] { LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_7_0") }, new string[1] { "Tutorial_Chapter_3_1a" }, 2, 0, LocalStringManager.GetConfig("TutorialVideo_language", "ChapterName_7"), LocalStringManager.GetConfig("TutorialVideo_language", "VideoSummary_7"), null));
		_dataArray.Add(new TutorialVideoItem(8, "Tutorial_Chapter_3_2", LocalStringManager.GetConfig("TutorialVideo_language", "Name_8"), new string[2]
		{
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_8_0"),
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_8_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_8_0"),
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_8_1")
		}, new string[2] { "Tutorial_Chapter_3_2a", "Tutorial_Chapter_3_2b" }, 2, 1, LocalStringManager.GetConfig("TutorialVideo_language", "ChapterName_8"), LocalStringManager.GetConfig("TutorialVideo_language", "VideoSummary_8"), null));
		_dataArray.Add(new TutorialVideoItem(9, "Tutorial_Chapter_3_3", LocalStringManager.GetConfig("TutorialVideo_language", "Name_9"), new string[1] { LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_9_0") }, new string[1] { LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_9_0") }, new string[1] { "Tutorial_Chapter_3_3a" }, 2, 2, LocalStringManager.GetConfig("TutorialVideo_language", "ChapterName_9"), LocalStringManager.GetConfig("TutorialVideo_language", "VideoSummary_9"), null));
		_dataArray.Add(new TutorialVideoItem(10, "Tutorial_Chapter_3_4", LocalStringManager.GetConfig("TutorialVideo_language", "Name_10"), new string[2]
		{
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_10_0"),
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_10_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_10_0"),
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_10_1")
		}, new string[2] { "Tutorial_Chapter_3_4a", "Tutorial_Chapter_3_4b" }, 2, 3, LocalStringManager.GetConfig("TutorialVideo_language", "ChapterName_10"), LocalStringManager.GetConfig("TutorialVideo_language", "VideoSummary_10"), null));
		_dataArray.Add(new TutorialVideoItem(11, "Tutorial_Chapter_3_5", LocalStringManager.GetConfig("TutorialVideo_language", "Name_11"), new string[1] { LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_11_0") }, new string[1] { LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_11_0") }, new string[1] { "Tutorial_Chapter_3_5a" }, 2, 4, LocalStringManager.GetConfig("TutorialVideo_language", "ChapterName_11"), LocalStringManager.GetConfig("TutorialVideo_language", "VideoSummary_11"), null));
		_dataArray.Add(new TutorialVideoItem(12, "Tutorial_Chapter_3_6", LocalStringManager.GetConfig("TutorialVideo_language", "Name_12"), new string[2]
		{
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_12_0"),
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_12_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_12_0"),
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_12_1")
		}, new string[2] { "Tutorial_Chapter_3_6a", "Tutorial_Chapter_3_6b" }, 2, 5, LocalStringManager.GetConfig("TutorialVideo_language", "ChapterName_12"), LocalStringManager.GetConfig("TutorialVideo_language", "VideoSummary_12"), null));
		_dataArray.Add(new TutorialVideoItem(13, "Tutorial_Chapter_4_1", LocalStringManager.GetConfig("TutorialVideo_language", "Name_13"), new string[1] { LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_13_0") }, new string[1] { LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_13_0") }, new string[1] { "Tutorial_Chapter_4_1a" }, 3, 0, LocalStringManager.GetConfig("TutorialVideo_language", "ChapterName_13"), LocalStringManager.GetConfig("TutorialVideo_language", "VideoSummary_13"), null));
		_dataArray.Add(new TutorialVideoItem(14, "Tutorial_Chapter_4_2", LocalStringManager.GetConfig("TutorialVideo_language", "Name_14"), new string[1] { LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_14_0") }, new string[1] { LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_14_0") }, new string[1] { "Tutorial_Chapter_4_2a" }, 3, 1, LocalStringManager.GetConfig("TutorialVideo_language", "ChapterName_14"), LocalStringManager.GetConfig("TutorialVideo_language", "VideoSummary_14"), null));
		_dataArray.Add(new TutorialVideoItem(15, "Tutorial_Chapter_4_3", LocalStringManager.GetConfig("TutorialVideo_language", "Name_15"), new string[2]
		{
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_15_0"),
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_15_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_15_0"),
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_15_1")
		}, new string[2] { "Tutorial_Chapter_4_3a", "Tutorial_Chapter_4_3b" }, 3, 2, LocalStringManager.GetConfig("TutorialVideo_language", "ChapterName_15"), LocalStringManager.GetConfig("TutorialVideo_language", "VideoSummary_15"), null));
		_dataArray.Add(new TutorialVideoItem(16, "Tutorial_Chapter_4_4", LocalStringManager.GetConfig("TutorialVideo_language", "Name_16"), new string[2]
		{
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_16_0"),
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_16_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_16_0"),
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_16_1")
		}, new string[2] { "Tutorial_Chapter_4_4a", "Tutorial_Chapter_4_4b" }, 3, 3, LocalStringManager.GetConfig("TutorialVideo_language", "ChapterName_16"), LocalStringManager.GetConfig("TutorialVideo_language", "VideoSummary_16"), null));
		_dataArray.Add(new TutorialVideoItem(17, "Tutorial_Chapter_4_6", LocalStringManager.GetConfig("TutorialVideo_language", "Name_17"), new string[2]
		{
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_17_0"),
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_17_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_17_0"),
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_17_1")
		}, new string[2] { "Tutorial_Chapter_4_6a", "Tutorial_Chapter_4_6b" }, 3, 5, LocalStringManager.GetConfig("TutorialVideo_language", "ChapterName_17"), LocalStringManager.GetConfig("TutorialVideo_language", "VideoSummary_17"), null));
		_dataArray.Add(new TutorialVideoItem(18, "Tutorial_Chapter_4_7", LocalStringManager.GetConfig("TutorialVideo_language", "Name_18"), new string[5]
		{
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_18_0"),
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_18_1"),
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_18_2"),
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_18_3"),
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_18_4")
		}, new string[5]
		{
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_18_0"),
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_18_1"),
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_18_2"),
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_18_3"),
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_18_4")
		}, new string[5] { "Tutorial_Chapter_4_7a", "Tutorial_Chapter_4_7b", "Tutorial_Chapter_4_7c", "Tutorial_Chapter_4_7d", "Tutorial_Chapter_4_7e" }, 3, 6, LocalStringManager.GetConfig("TutorialVideo_language", "ChapterName_18"), LocalStringManager.GetConfig("TutorialVideo_language", "VideoSummary_18"), new int[2] { -972, -502 }));
		_dataArray.Add(new TutorialVideoItem(19, "Tutorial_Chapter_5_1", LocalStringManager.GetConfig("TutorialVideo_language", "Name_19"), new string[3]
		{
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_19_0"),
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_19_1"),
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_19_2")
		}, new string[3]
		{
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_19_0"),
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_19_1"),
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_19_2")
		}, new string[3] { "Tutorial_Chapter_5_1a", "Tutorial_Chapter_5_1b", "Tutorial_Chapter_5_1c" }, 4, 0, LocalStringManager.GetConfig("TutorialVideo_language", "ChapterName_19"), LocalStringManager.GetConfig("TutorialVideo_language", "VideoSummary_19"), null));
		_dataArray.Add(new TutorialVideoItem(20, "Tutorial_Chapter_5_2", LocalStringManager.GetConfig("TutorialVideo_language", "Name_20"), new string[1] { LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_20_0") }, new string[1] { LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_20_0") }, new string[1] { "Tutorial_Chapter_5_2a" }, 4, 1, LocalStringManager.GetConfig("TutorialVideo_language", "ChapterName_20"), LocalStringManager.GetConfig("TutorialVideo_language", "VideoSummary_20"), null));
		_dataArray.Add(new TutorialVideoItem(21, "Tutorial_Chapter_5_3", LocalStringManager.GetConfig("TutorialVideo_language", "Name_21"), new string[2]
		{
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_21_0"),
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_21_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_21_0"),
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_21_1")
		}, new string[2] { "Tutorial_Chapter_5_3a", "Tutorial_Chapter_5_3b" }, 4, 2, LocalStringManager.GetConfig("TutorialVideo_language", "ChapterName_21"), LocalStringManager.GetConfig("TutorialVideo_language", "VideoSummary_21"), null));
		_dataArray.Add(new TutorialVideoItem(22, "Tutorial_Chapter_5_4", LocalStringManager.GetConfig("TutorialVideo_language", "Name_22"), new string[1] { LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_22_0") }, new string[1] { LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_22_0") }, new string[1] { "Tutorial_Chapter_5_4a" }, 4, 3, LocalStringManager.GetConfig("TutorialVideo_language", "ChapterName_22"), LocalStringManager.GetConfig("TutorialVideo_language", "VideoSummary_22"), null));
		_dataArray.Add(new TutorialVideoItem(23, "Tutorial_Chapter_6_1", LocalStringManager.GetConfig("TutorialVideo_language", "Name_23"), new string[2]
		{
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_23_0"),
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_23_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_23_0"),
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_23_1")
		}, new string[2] { "Tutorial_Chapter_6_1a", "Tutorial_Chapter_6_1b" }, 5, 0, LocalStringManager.GetConfig("TutorialVideo_language", "ChapterName_23"), LocalStringManager.GetConfig("TutorialVideo_language", "VideoSummary_23"), null));
		_dataArray.Add(new TutorialVideoItem(24, "Tutorial_Chapter_6_2", LocalStringManager.GetConfig("TutorialVideo_language", "Name_24"), new string[1] { LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_24_0") }, new string[1] { LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_24_0") }, new string[1] { "Tutorial_Chapter_6_2a" }, 5, 1, LocalStringManager.GetConfig("TutorialVideo_language", "ChapterName_24"), LocalStringManager.GetConfig("TutorialVideo_language", "VideoSummary_24"), null));
		_dataArray.Add(new TutorialVideoItem(25, "Tutorial_Chapter_6_3", LocalStringManager.GetConfig("TutorialVideo_language", "Name_25"), new string[2]
		{
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_25_0"),
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_25_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_25_0"),
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_25_1")
		}, new string[2] { "Tutorial_Chapter_6_3a", "Tutorial_Chapter_6_3b" }, 5, 2, LocalStringManager.GetConfig("TutorialVideo_language", "ChapterName_25"), LocalStringManager.GetConfig("TutorialVideo_language", "VideoSummary_25"), null));
		_dataArray.Add(new TutorialVideoItem(26, "Tutorial_Chapter_6_4", LocalStringManager.GetConfig("TutorialVideo_language", "Name_26"), new string[1] { LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_26_0") }, new string[1] { LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_26_0") }, new string[1] { "Tutorial_Chapter_6_4a" }, 5, 3, LocalStringManager.GetConfig("TutorialVideo_language", "ChapterName_26"), LocalStringManager.GetConfig("TutorialVideo_language", "VideoSummary_26"), null));
		_dataArray.Add(new TutorialVideoItem(27, "Tutorial_Chapter_6_5", LocalStringManager.GetConfig("TutorialVideo_language", "Name_27"), new string[2]
		{
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_27_0"),
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_27_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_27_0"),
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_27_1")
		}, new string[2] { "Tutorial_Chapter_6_5a", "Tutorial_Chapter_6_5b" }, 5, 4, LocalStringManager.GetConfig("TutorialVideo_language", "ChapterName_27"), LocalStringManager.GetConfig("TutorialVideo_language", "VideoSummary_27"), null));
		_dataArray.Add(new TutorialVideoItem(28, "Tutorial_Chapter_6_6", LocalStringManager.GetConfig("TutorialVideo_language", "Name_28"), new string[1] { LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_28_0") }, new string[1] { LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_28_0") }, new string[1] { "Tutorial_Chapter_6_6a" }, 5, 5, LocalStringManager.GetConfig("TutorialVideo_language", "ChapterName_28"), LocalStringManager.GetConfig("TutorialVideo_language", "VideoSummary_28"), null));
		_dataArray.Add(new TutorialVideoItem(29, "Tutorial_Chapter_7_1", LocalStringManager.GetConfig("TutorialVideo_language", "Name_29"), new string[1] { LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_29_0") }, new string[1] { LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_29_0") }, new string[1] { "Tutorial_Chapter_7_1a" }, 6, 0, LocalStringManager.GetConfig("TutorialVideo_language", "ChapterName_29"), LocalStringManager.GetConfig("TutorialVideo_language", "VideoSummary_29"), null));
		_dataArray.Add(new TutorialVideoItem(30, "Tutorial_Chapter_7_2", LocalStringManager.GetConfig("TutorialVideo_language", "Name_30"), new string[1] { LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_30_0") }, new string[1] { LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_30_0") }, new string[1] { "Tutorial_Chapter_7_2a" }, 6, 1, LocalStringManager.GetConfig("TutorialVideo_language", "ChapterName_30"), LocalStringManager.GetConfig("TutorialVideo_language", "VideoSummary_30"), null));
		_dataArray.Add(new TutorialVideoItem(31, "Tutorial_Chapter_7_3", LocalStringManager.GetConfig("TutorialVideo_language", "Name_31"), new string[1] { LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_31_0") }, new string[1] { LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_31_0") }, new string[1] { "Tutorial_Chapter_7_3a" }, 6, 2, LocalStringManager.GetConfig("TutorialVideo_language", "ChapterName_31"), LocalStringManager.GetConfig("TutorialVideo_language", "VideoSummary_31"), null));
		_dataArray.Add(new TutorialVideoItem(32, "Tutorial_Chapter_7_4", LocalStringManager.GetConfig("TutorialVideo_language", "Name_32"), new string[2]
		{
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_32_0"),
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_32_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_32_0"),
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_32_1")
		}, new string[2] { "Tutorial_Chapter_7_4a", "Tutorial_Chapter_7_4b" }, 6, 3, LocalStringManager.GetConfig("TutorialVideo_language", "ChapterName_32"), LocalStringManager.GetConfig("TutorialVideo_language", "VideoSummary_32"), null));
		_dataArray.Add(new TutorialVideoItem(33, "Tutorial_Chapter_8_1", LocalStringManager.GetConfig("TutorialVideo_language", "Name_33"), new string[1] { LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_33_0") }, new string[1] { LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_33_0") }, new string[1] { "Tutorial_Chapter_8_1a" }, 7, 0, LocalStringManager.GetConfig("TutorialVideo_language", "ChapterName_33"), LocalStringManager.GetConfig("TutorialVideo_language", "VideoSummary_33"), null));
		_dataArray.Add(new TutorialVideoItem(34, "Tutorial_Chapter_8_2", LocalStringManager.GetConfig("TutorialVideo_language", "Name_34"), new string[2]
		{
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_34_0"),
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_34_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_34_0"),
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_34_1")
		}, new string[2] { "Tutorial_Chapter_8_2a", "Tutorial_Chapter_8_2b" }, 7, 1, LocalStringManager.GetConfig("TutorialVideo_language", "ChapterName_34"), LocalStringManager.GetConfig("TutorialVideo_language", "VideoSummary_34"), new int[2] { -550, 560 }));
		_dataArray.Add(new TutorialVideoItem(35, "Tutorial_Chapter_9_1", LocalStringManager.GetConfig("TutorialVideo_language", "Name_35"), new string[1] { LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_35_0") }, new string[1] { LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_35_0") }, new string[1] { "Tutorial_Chapter_9_1a" }, 8, 0, LocalStringManager.GetConfig("TutorialVideo_language", "ChapterName_35"), LocalStringManager.GetConfig("TutorialVideo_language", "VideoSummary_35"), null));
		_dataArray.Add(new TutorialVideoItem(36, "Tutorial_Chapter_10_1", LocalStringManager.GetConfig("TutorialVideo_language", "Name_36"), new string[2]
		{
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_36_0"),
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_36_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_36_0"),
			LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_36_1")
		}, new string[2] { "Tutorial_Chapter_10_1a", "Tutorial_Chapter_10_1b" }, 9, 0, LocalStringManager.GetConfig("TutorialVideo_language", "ChapterName_36"), LocalStringManager.GetConfig("TutorialVideo_language", "VideoSummary_36"), null));
		_dataArray.Add(new TutorialVideoItem(37, "Tutorial_Chapter_4_5", LocalStringManager.GetConfig("TutorialVideo_language", "Name_37"), new string[1] { LocalStringManager.GetConfig("TutorialVideo_language", "PartsTitle_37_0") }, new string[1] { LocalStringManager.GetConfig("TutorialVideo_language", "PartsDesc_37_0") }, new string[1] { "Tutorial_Chapter_4_5a" }, 3, 4, LocalStringManager.GetConfig("TutorialVideo_language", "ChapterName_37"), LocalStringManager.GetConfig("TutorialVideo_language", "VideoSummary_37"), null));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<TutorialVideoItem>(38);
		CreateItems0();
	}
}

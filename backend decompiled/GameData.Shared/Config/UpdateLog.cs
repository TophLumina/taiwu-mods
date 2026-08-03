using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class UpdateLog : ConfigData<UpdateLogItem, byte>
{
	/// <summary>
	/// 配置表实例
	/// </summary>
	public static UpdateLog Instance = new UpdateLog();

	private readonly HashSet<string> RequiredFields = new HashSet<string>
	{
		"VersionTitle", "SubentryTitles", "SubentryDescriptions", "TemplateId", "IncrementSortOrder", "VersionTagBackground", "VersionTagIcon", "VersionPublishDate", "OfficialLink", "SubentryIcons",
		"SubentryTitleIcon"
	};

	internal override int ToInt(byte value)
	{
		return value;
	}

	internal override byte ToTemplateId(int value)
	{
		return (byte)value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new UpdateLogItem(0, 0, "UpdateNote_Bg_0", "ui9_tex_update_log_versiontag_0", LocalStringManager.GetConfig("UpdateLog_language", "VersionTitle_0"), "22-11-18", "https://www.conchship.com.cn/archives/4261", new string[4]
		{
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_0_0"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_0_1"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_0_2"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_0_3")
		}, new string[4] { "ui9_tex_update_log_subicon_0_0", "ui9_tex_update_log_subicon_0_1", "ui9_tex_update_log_subicon_0_2", "ui9_tex_update_log_subicon_0_3" }, new string[4]
		{
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_0_0"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_0_1"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_0_2"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_0_3")
		}, "ui9_tex_system_log_temp_titleimg_0"));
		_dataArray.Add(new UpdateLogItem(1, 1, "UpdateNote_Bg_1", "ui9_tex_update_log_versiontag_1", LocalStringManager.GetConfig("UpdateLog_language", "VersionTitle_1"), "22-11-25", "https://www.conchship.com.cn/archives/4270", new string[7]
		{
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_1_0"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_1_1"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_1_2"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_1_3"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_1_4"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_1_5"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_1_6")
		}, new string[7] { "ui9_tex_update_log_subicon_1_0", "ui9_tex_update_log_subicon_1_1", "ui9_tex_update_log_subicon_1_2", "ui9_tex_update_log_subicon_1_3", "ui9_tex_update_log_subicon_1_4", "ui9_tex_update_log_subicon_1_5", "ui9_tex_update_log_subicon_1_6" }, new string[7]
		{
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_1_0"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_1_1"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_1_2"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_1_3"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_1_4"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_1_5"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_1_6")
		}, "ui9_tex_system_log_temp_titleimg_1"));
		_dataArray.Add(new UpdateLogItem(2, 2, "UpdateNote_Bg_2", "ui9_tex_update_log_versiontag_2", LocalStringManager.GetConfig("UpdateLog_language", "VersionTitle_2"), "22-12-09", "https://www.conchship.com.cn/archives/4276", new string[4]
		{
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_2_0"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_2_1"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_2_2"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_2_3")
		}, new string[4] { "ui9_tex_update_log_subicon_2_0", "ui9_tex_update_log_subicon_2_1", "ui9_tex_update_log_subicon_2_2", "ui9_tex_update_log_subicon_2_3" }, new string[4]
		{
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_2_0"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_2_1"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_2_2"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_2_3")
		}, "ui9_tex_system_log_temp_titleimg_2"));
		_dataArray.Add(new UpdateLogItem(3, 3, "UpdateNote_Bg_3", "ui9_tex_update_log_versiontag_3", LocalStringManager.GetConfig("UpdateLog_language", "VersionTitle_3"), "23-01-18", "https://www.conchship.com.cn/archives/4282", new string[4]
		{
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_3_0"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_3_1"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_3_2"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_3_3")
		}, new string[4] { "ui9_tex_update_log_subicon_3_0", "ui9_tex_update_log_subicon_3_1", "ui9_tex_update_log_subicon_3_2", "ui9_tex_update_log_subicon_3_3" }, new string[4]
		{
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_3_0"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_3_1"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_3_2"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_3_3")
		}, "ui9_tex_system_log_temp_titleimg_3"));
		_dataArray.Add(new UpdateLogItem(4, 4, "UpdateNote_Bg_4", "ui9_tex_update_log_versiontag_4", LocalStringManager.GetConfig("UpdateLog_language", "VersionTitle_4"), "23-03-16", "https://www.conchship.com.cn/archives/4297", new string[6]
		{
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_4_0"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_4_1"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_4_2"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_4_3"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_4_4"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_4_5")
		}, new string[6] { "ui9_tex_update_log_subicon_4_0", "ui9_tex_update_log_subicon_4_1", "ui9_tex_update_log_subicon_4_2", "ui9_tex_update_log_subicon_4_3", "ui9_tex_update_log_subicon_4_4", "ui9_tex_update_log_subicon_4_5" }, new string[6]
		{
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_4_0"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_4_1"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_4_2"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_4_3"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_4_4"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_4_5")
		}, "ui9_tex_system_log_temp_titleimg_4"));
		_dataArray.Add(new UpdateLogItem(5, 5, "UpdateNote_Bg_5", "ui9_tex_update_log_versiontag_5", LocalStringManager.GetConfig("UpdateLog_language", "VersionTitle_5"), "23-05-10", "https://www.conchship.com.cn/archives/4303", new string[6]
		{
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_5_0"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_5_1"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_5_2"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_5_3"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_5_4"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_5_5")
		}, new string[6] { "ui9_tex_update_log_subicon_5_0", "ui9_tex_update_log_subicon_5_1", "ui9_tex_update_log_subicon_5_2", "ui9_tex_update_log_subicon_5_3", "ui9_tex_update_log_subicon_5_4", "ui9_tex_update_log_subicon_5_5" }, new string[6]
		{
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_5_0"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_5_1"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_5_2"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_5_3"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_5_4"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_5_5")
		}, "ui9_tex_system_log_temp_titleimg_5"));
		_dataArray.Add(new UpdateLogItem(6, 6, "UpdateNote_Bg_6", "ui9_tex_update_log_versiontag_6", LocalStringManager.GetConfig("UpdateLog_language", "VersionTitle_6"), "23-06-20", "https://www.conchship.com.cn/archives/4323", new string[5]
		{
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_6_0"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_6_1"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_6_2"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_6_3"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_6_4")
		}, new string[5] { "ui9_tex_update_log_subicon_6_0", "ui9_tex_update_log_subicon_6_1", "ui9_tex_update_log_subicon_6_2", "ui9_tex_update_log_subicon_6_3", "ui9_tex_update_log_subicon_6_4" }, new string[5]
		{
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_6_0"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_6_1"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_6_2"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_6_3"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_6_4")
		}, "ui9_tex_system_log_temp_titleimg_6"));
		_dataArray.Add(new UpdateLogItem(7, 7, "UpdateNote_Bg_7", "ui9_tex_update_log_versiontag_7", LocalStringManager.GetConfig("UpdateLog_language", "VersionTitle_7"), "23-07-31", "https://www.conchship.com.cn/archives/4401", new string[5]
		{
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_7_0"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_7_1"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_7_2"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_7_3"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_7_4")
		}, new string[5] { "ui9_tex_update_log_subicon_7_0", "ui9_tex_update_log_subicon_7_1", "ui9_tex_update_log_subicon_7_2", "ui9_tex_update_log_subicon_7_3", "ui9_tex_update_log_subicon_7_4" }, new string[5]
		{
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_7_0"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_7_1"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_7_2"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_7_3"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_7_4")
		}, "ui9_tex_system_log_temp_titleimg_7"));
		_dataArray.Add(new UpdateLogItem(8, 8, "UpdateNote_Bg_8", "ui9_tex_update_log_versiontag_8", LocalStringManager.GetConfig("UpdateLog_language", "VersionTitle_8"), "23-09-10", "https://www.conchship.com.cn/archives/4414", new string[8]
		{
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_8_0"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_8_1"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_8_2"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_8_3"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_8_4"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_8_5"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_8_6"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_8_7")
		}, new string[8] { "ui9_tex_update_log_subicon_8_0", "ui9_tex_update_log_subicon_8_1", "ui9_tex_update_log_subicon_8_2", "ui9_tex_update_log_subicon_8_3", "ui9_tex_update_log_subicon_8_4", "ui9_tex_update_log_subicon_8_5", "ui9_tex_update_log_subicon_8_6", "ui9_tex_update_log_subicon_8_7" }, new string[8]
		{
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_8_0"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_8_1"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_8_2"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_8_3"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_8_4"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_8_5"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_8_6"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_8_7")
		}, "ui9_tex_system_log_temp_titleimg_8"));
		_dataArray.Add(new UpdateLogItem(9, 9, "UpdateNote_Bg_9", "ui9_tex_update_log_versiontag_9", LocalStringManager.GetConfig("UpdateLog_language", "VersionTitle_9"), "23-11-10", "https://www.conchship.com.cn/archives/4432", new string[8]
		{
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_9_0"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_9_1"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_9_2"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_9_3"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_9_4"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_9_5"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_9_6"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_9_7")
		}, new string[8] { "ui9_tex_update_log_subicon_9_0", "ui9_tex_update_log_subicon_9_1", "ui9_tex_update_log_subicon_9_2", "ui9_tex_update_log_subicon_9_3", "ui9_tex_update_log_subicon_9_4", "ui9_tex_update_log_subicon_9_5", "ui9_tex_update_log_subicon_9_6", "ui9_tex_update_log_subicon_9_7" }, new string[8]
		{
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_9_0"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_9_1"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_9_2"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_9_3"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_9_4"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_9_5"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_9_6"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_9_7")
		}, "ui9_tex_system_log_temp_titleimg_9"));
		_dataArray.Add(new UpdateLogItem(10, 10, "UpdateNote_Bg_10", "ui9_tex_update_log_versiontag_10", LocalStringManager.GetConfig("UpdateLog_language", "VersionTitle_10"), "24-01-05", "https://www.conchship.com.cn/archives/4442", new string[8]
		{
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_10_0"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_10_1"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_10_2"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_10_3"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_10_4"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_10_5"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_10_6"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_10_7")
		}, new string[8] { "ui9_tex_update_log_subicon_10_0", "ui9_tex_update_log_subicon_10_1", "ui9_tex_update_log_subicon_10_2", "ui9_tex_update_log_subicon_10_3", "ui9_tex_update_log_subicon_10_4", "ui9_tex_update_log_subicon_10_5", "ui9_tex_update_log_subicon_10_6", "ui9_tex_update_log_subicon_10_7" }, new string[8]
		{
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_10_0"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_10_1"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_10_2"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_10_3"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_10_4"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_10_5"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_10_6"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_10_7")
		}, "ui9_tex_system_log_temp_titleimg_10"));
		_dataArray.Add(new UpdateLogItem(11, 11, "UpdateNote_Bg_11", "ui9_tex_update_log_versiontag_11", LocalStringManager.GetConfig("UpdateLog_language", "VersionTitle_11"), "24-01-31", "https://www.conchship.com.cn/new", new string[1] { LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_11_0") }, new string[1] { "ui9_tex_update_log_subicon_11_0" }, new string[1] { LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_11_0") }, "ui9_tex_system_log_temp_titleimg_11"));
		_dataArray.Add(new UpdateLogItem(12, 12, "UpdateNote_Bg_12", "ui9_tex_update_log_versiontag_12", LocalStringManager.GetConfig("UpdateLog_language", "VersionTitle_12"), "24-04-19", "https://www.conchship.com.cn/archives/4465", new string[5]
		{
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_12_0"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_12_1"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_12_2"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_12_3"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_12_4")
		}, new string[5] { "ui9_tex_update_log_subicon_12_0", "ui9_tex_update_log_subicon_12_1", "ui9_tex_update_log_subicon_12_2", "ui9_tex_update_log_subicon_12_3", "ui9_tex_update_log_subicon_12_4" }, new string[5]
		{
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_12_0"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_12_1"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_12_2"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_12_3"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_12_4")
		}, "ui9_tex_system_log_temp_titleimg_12"));
		_dataArray.Add(new UpdateLogItem(13, 13, "UpdateNote_Bg_13", "ui9_tex_update_log_versiontag_13", LocalStringManager.GetConfig("UpdateLog_language", "VersionTitle_13"), "24-07-09", "https://www.conchship.com.cn/archives/4579", new string[14]
		{
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_13_0"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_13_1"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_13_2"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_13_3"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_13_4"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_13_5"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_13_6"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_13_7"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_13_8"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_13_9"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_13_10"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_13_11"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_13_12"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_13_13")
		}, new string[14]
		{
			"ui9_tex_update_log_subicon_13_0", "ui9_tex_update_log_subicon_13_1", "ui9_tex_update_log_subicon_13_2", "ui9_tex_update_log_subicon_13_3", "ui9_tex_update_log_subicon_13_4", "ui9_tex_update_log_subicon_13_5", "ui9_tex_update_log_subicon_13_6", "ui9_tex_update_log_subicon_13_7", "ui9_tex_update_log_subicon_13_8", "ui9_tex_update_log_subicon_13_9",
			"ui9_tex_update_log_subicon_13_10", "ui9_tex_update_log_subicon_13_11", "ui9_tex_update_log_subicon_13_12", "ui9_tex_update_log_subicon_13_13"
		}, new string[14]
		{
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_13_0"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_13_1"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_13_2"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_13_3"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_13_4"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_13_5"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_13_6"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_13_7"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_13_8"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_13_9"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_13_10"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_13_11"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_13_12"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_13_13")
		}, "ui9_tex_system_log_temp_titleimg_13"));
		_dataArray.Add(new UpdateLogItem(14, 14, "UpdateNote_Bg_14", "ui9_tex_update_log_versiontag_14", LocalStringManager.GetConfig("UpdateLog_language", "VersionTitle_14"), "24-09-26", "https://www.conchship.com.cn/archives/4621", new string[10]
		{
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_14_0"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_14_1"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_14_2"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_14_3"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_14_4"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_14_5"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_14_6"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_14_7"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_14_8"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_14_9")
		}, new string[10] { "ui9_tex_update_log_subicon_14_0", "ui9_tex_update_log_subicon_14_1", "ui9_tex_update_log_subicon_14_2", "ui9_tex_update_log_subicon_14_3", "ui9_tex_update_log_subicon_14_4", "ui9_tex_update_log_subicon_14_5", "ui9_tex_update_log_subicon_14_6", "ui9_tex_update_log_subicon_14_7", "ui9_tex_update_log_subicon_14_8", "ui9_tex_update_log_subicon_14_9" }, new string[10]
		{
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_14_0"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_14_1"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_14_2"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_14_3"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_14_4"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_14_5"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_14_6"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_14_7"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_14_8"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_14_9")
		}, "ui9_tex_system_log_temp_titleimg_14"));
		_dataArray.Add(new UpdateLogItem(15, 15, "UpdateNote_Bg_15", "ui9_tex_update_log_versiontag_15", LocalStringManager.GetConfig("UpdateLog_language", "VersionTitle_15"), "24-12-26", "https://www.conchship.com.cn/archives/4899", new string[8]
		{
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_15_0"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_15_1"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_15_2"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_15_3"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_15_4"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_15_5"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_15_6"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_15_7")
		}, new string[8] { "ui9_tex_update_log_subicon_15_0", "ui9_tex_update_log_subicon_15_1", "ui9_tex_update_log_subicon_15_2", "ui9_tex_update_log_subicon_15_3", "ui9_tex_update_log_subicon_15_4", "ui9_tex_update_log_subicon_15_5", "ui9_tex_update_log_subicon_15_6", "ui9_tex_update_log_subicon_15_7" }, new string[8]
		{
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_15_0"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_15_1"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_15_2"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_15_3"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_15_4"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_15_5"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_15_6"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_15_7")
		}, "ui9_tex_system_log_temp_titleimg_15"));
		_dataArray.Add(new UpdateLogItem(16, 16, "UpdateNote_Bg_16", "ui9_tex_update_log_versiontag_16", LocalStringManager.GetConfig("UpdateLog_language", "VersionTitle_16"), "25-01-21", "https://www.conchship.com.cn/new", new string[4]
		{
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_16_0"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_16_1"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_16_2"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_16_3")
		}, new string[4] { "ui9_tex_update_log_subicon_16_0", "ui9_tex_update_log_subicon_16_1", "ui9_tex_update_log_subicon_16_2", "ui9_tex_update_log_subicon_16_3" }, new string[4]
		{
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_16_0"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_16_1"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_16_2"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_16_3")
		}, "ui9_tex_system_log_temp_titleimg_16"));
		_dataArray.Add(new UpdateLogItem(17, 17, "UpdateNote_Bg_17", "ui9_tex_update_log_versiontag_17", LocalStringManager.GetConfig("UpdateLog_language", "VersionTitle_17"), "25-03-26", "https://www.conchship.com.cn/archives/4980", new string[4]
		{
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_17_0"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_17_1"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_17_2"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_17_3")
		}, new string[4] { "ui9_tex_update_log_subicon_17_0", "ui9_tex_update_log_subicon_17_1", "ui9_tex_update_log_subicon_17_2", "ui9_tex_update_log_subicon_17_3" }, new string[4]
		{
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_17_0"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_17_1"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_17_2"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_17_3")
		}, "ui9_tex_system_log_temp_titleimg_17"));
		_dataArray.Add(new UpdateLogItem(18, 18, "UpdateNote_Bg_18", "ui9_tex_update_log_versiontag_18", LocalStringManager.GetConfig("UpdateLog_language", "VersionTitle_18"), "25-04-29", "https://www.conchship.com.cn/archives/5009", new string[3]
		{
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_18_0"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_18_1"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_18_2")
		}, new string[3] { "ui9_tex_update_log_subicon_18_0", "ui9_tex_update_log_subicon_18_1", "ui9_tex_update_log_subicon_18_2" }, new string[3]
		{
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_18_0"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_18_1"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_18_2")
		}, "ui9_tex_system_log_temp_titleimg_18"));
		_dataArray.Add(new UpdateLogItem(19, 19, "UpdateNote_Bg_19", "ui9_tex_update_log_versiontag_19", LocalStringManager.GetConfig("UpdateLog_language", "VersionTitle_19"), "25-06-05", "https://www.conchship.com.cn/archives/5036", new string[6]
		{
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_19_0"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_19_1"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_19_2"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_19_3"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_19_4"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_19_5")
		}, new string[6] { "ui9_tex_update_log_subicon_19_0", "ui9_tex_update_log_subicon_19_1", "ui9_tex_update_log_subicon_19_2", "ui9_tex_update_log_subicon_19_3", "ui9_tex_update_log_subicon_19_4", "ui9_tex_update_log_subicon_19_5" }, new string[6]
		{
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_19_0"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_19_1"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_19_2"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_19_3"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_19_4"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_19_5")
		}, "ui9_tex_system_log_temp_titleimg_19"));
		_dataArray.Add(new UpdateLogItem(20, 20, "UpdateNote_Bg_20", "ui9_tex_update_log_versiontag_20", LocalStringManager.GetConfig("UpdateLog_language", "VersionTitle_20"), "25-09-22", "https://www.conchship.com.cn/archives/5087", new string[12]
		{
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_20_0"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_20_1"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_20_2"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_20_3"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_20_4"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_20_5"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_20_6"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_20_7"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_20_8"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_20_9"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_20_10"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryTitles_20_11")
		}, new string[12]
		{
			"ui9_tex_update_log_subicon_20_0", "ui9_tex_update_log_subicon_20_1", "ui9_tex_update_log_subicon_20_2", "ui9_tex_update_log_subicon_20_3", "ui9_tex_update_log_subicon_20_4", "ui9_tex_update_log_subicon_20_5", "ui9_tex_update_log_subicon_20_6", "ui9_tex_update_log_subicon_20_7", "ui9_tex_update_log_subicon_20_8", "ui9_tex_update_log_subicon_20_9",
			"ui9_tex_update_log_subicon_20_10", "ui9_tex_update_log_subicon_20_11"
		}, new string[12]
		{
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_20_0"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_20_1"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_20_2"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_20_3"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_20_4"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_20_5"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_20_6"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_20_7"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_20_8"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_20_9"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_20_10"),
			LocalStringManager.GetConfig("UpdateLog_language", "SubentryDescriptions_20_11")
		}, "ui9_tex_system_log_temp_titleimg_20"));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<UpdateLogItem>(21);
		CreateItems0();
	}
}

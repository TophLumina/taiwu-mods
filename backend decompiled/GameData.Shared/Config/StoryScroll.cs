using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class StoryScroll : ConfigData<StoryScrollItem, short>
{
	public static class DefKey
	{
		public const short MonvBegin = 0;

		public const short DaYueYaoChangBegin = 6;

		public const short JiuHanBegin = 12;

		public const short JinHuangerBegin = 18;

		public const short YiYiHouBegin = 24;

		public const short WeiQiBegin = 30;

		public const short YiXiangBegin = 36;

		public const short XueFengBegin = 42;

		public const short ShuFangBegin = 48;

		public const short SectShaoLinGood = 54;

		public const short SectShaoLinBad = 55;

		public const short SectEMeiGood = 56;

		public const short SectEMeiBad = 57;

		public const short SectBaiHuaGood = 58;

		public const short SectBaiHuaBad = 59;

		public const short SectWuDangGood = 60;

		public const short SectWuDangBad = 61;

		public const short SectYuanShanGood = 62;

		public const short SectYuanShanBad = 63;

		public const short SectShiXiangGood = 64;

		public const short SectShiXiangBad = 65;

		public const short SectRanShanGood = 66;

		public const short SectRanShanBad = 67;

		public const short SectXuanNvGood = 68;

		public const short SectXuanNvBad = 69;

		public const short SectZhuJianGood = 70;

		public const short SectZhuJianBad = 71;

		public const short SectKongSangGood = 72;

		public const short SectKongSangBad = 73;

		public const short SectJinGangGood = 74;

		public const short SectJinGangBad = 75;

		public const short SectWuXianGood = 76;

		public const short SectWuXianBad = 77;

		public const short SectJieQingGood = 78;

		public const short SectJieQingBad = 79;

		public const short SectFuLongGood = 80;

		public const short SectFuLongBad = 81;

		public const short SectXueHouGood = 82;

		public const short SectXueHouBad = 83;
	}

	public static class DefValue
	{
		public static StoryScrollItem MonvBegin => Instance[(short)0];

		public static StoryScrollItem DaYueYaoChangBegin => Instance[(short)6];

		public static StoryScrollItem JiuHanBegin => Instance[(short)12];

		public static StoryScrollItem JinHuangerBegin => Instance[(short)18];

		public static StoryScrollItem YiYiHouBegin => Instance[(short)24];

		public static StoryScrollItem WeiQiBegin => Instance[(short)30];

		public static StoryScrollItem YiXiangBegin => Instance[(short)36];

		public static StoryScrollItem XueFengBegin => Instance[(short)42];

		public static StoryScrollItem ShuFangBegin => Instance[(short)48];

		public static StoryScrollItem SectShaoLinGood => Instance[(short)54];

		public static StoryScrollItem SectShaoLinBad => Instance[(short)55];

		public static StoryScrollItem SectEMeiGood => Instance[(short)56];

		public static StoryScrollItem SectEMeiBad => Instance[(short)57];

		public static StoryScrollItem SectBaiHuaGood => Instance[(short)58];

		public static StoryScrollItem SectBaiHuaBad => Instance[(short)59];

		public static StoryScrollItem SectWuDangGood => Instance[(short)60];

		public static StoryScrollItem SectWuDangBad => Instance[(short)61];

		public static StoryScrollItem SectYuanShanGood => Instance[(short)62];

		public static StoryScrollItem SectYuanShanBad => Instance[(short)63];

		public static StoryScrollItem SectShiXiangGood => Instance[(short)64];

		public static StoryScrollItem SectShiXiangBad => Instance[(short)65];

		public static StoryScrollItem SectRanShanGood => Instance[(short)66];

		public static StoryScrollItem SectRanShanBad => Instance[(short)67];

		public static StoryScrollItem SectXuanNvGood => Instance[(short)68];

		public static StoryScrollItem SectXuanNvBad => Instance[(short)69];

		public static StoryScrollItem SectZhuJianGood => Instance[(short)70];

		public static StoryScrollItem SectZhuJianBad => Instance[(short)71];

		public static StoryScrollItem SectKongSangGood => Instance[(short)72];

		public static StoryScrollItem SectKongSangBad => Instance[(short)73];

		public static StoryScrollItem SectJinGangGood => Instance[(short)74];

		public static StoryScrollItem SectJinGangBad => Instance[(short)75];

		public static StoryScrollItem SectWuXianGood => Instance[(short)76];

		public static StoryScrollItem SectWuXianBad => Instance[(short)77];

		public static StoryScrollItem SectJieQingGood => Instance[(short)78];

		public static StoryScrollItem SectJieQingBad => Instance[(short)79];

		public static StoryScrollItem SectFuLongGood => Instance[(short)80];

		public static StoryScrollItem SectFuLongBad => Instance[(short)81];

		public static StoryScrollItem SectXueHouGood => Instance[(short)82];

		public static StoryScrollItem SectXueHouBad => Instance[(short)83];
	}

	public static StoryScroll Instance = new StoryScroll();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "StoryBoss", "StorySect", "StoryNote", "TemplateId", "StoryResultMark", "StoryUnlocked", "StoryTypeIcon", "StoryCharm", "StoryEnd", "StoryImage" };

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
		_dataArray.Add(new StoryScrollItem(0, 0, -1, EStoryScrollStoryResultMark.StoryResultMark0, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_0"), null, "gamelinescroll_icon_big_npcface_2001", "gamelinescroll_icon_big_charm_2001", "gamelinescroll_icon_big_npcface_2001_end", "npcface_image_2001_0"));
		_dataArray.Add(new StoryScrollItem(1, 0, -1, EStoryScrollStoryResultMark.StoryResultMark1, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_1"), null, "gamelinescroll_icon_big_npcface_2001", "gamelinescroll_icon_big_charm_2001", "gamelinescroll_icon_big_npcface_2001_end", "npcface_image_2001_1"));
		_dataArray.Add(new StoryScrollItem(2, 0, -1, EStoryScrollStoryResultMark.StoryResultMark2, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_2"), null, "gamelinescroll_icon_big_npcface_2001", "gamelinescroll_icon_big_charm_2001", "gamelinescroll_icon_big_npcface_2001_end", "npcface_image_2001_2"));
		_dataArray.Add(new StoryScrollItem(3, 0, -1, EStoryScrollStoryResultMark.StoryResultMark3, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_3"), null, "gamelinescroll_icon_big_npcface_2001", "gamelinescroll_icon_big_charm_2001", "gamelinescroll_icon_big_npcface_2001_end", "npcface_image_2001_3"));
		_dataArray.Add(new StoryScrollItem(4, 0, -1, EStoryScrollStoryResultMark.StoryResultMark4, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_4"), null, "gamelinescroll_icon_big_npcface_2001", "gamelinescroll_icon_big_charm_2001", "gamelinescroll_icon_big_npcface_2001_end", "npcface_image_2001_4_1"));
		_dataArray.Add(new StoryScrollItem(5, 0, -1, EStoryScrollStoryResultMark.StoryResultMark5, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_5"), null, "gamelinescroll_icon_big_npcface_2001", "gamelinescroll_icon_big_charm_2001", "gamelinescroll_icon_big_npcface_2001_end", "npcface_image_2001_4_0"));
		_dataArray.Add(new StoryScrollItem(6, 1, -1, EStoryScrollStoryResultMark.StoryResultMark0, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_6"), null, "gamelinescroll_icon_big_npcface_2001", "gamelinescroll_icon_big_charm_2002", "gamelinescroll_icon_big_npcface_2001_end", "npcface_image_2002_0"));
		_dataArray.Add(new StoryScrollItem(7, 1, -1, EStoryScrollStoryResultMark.StoryResultMark1, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_7"), null, "gamelinescroll_icon_big_npcface_2001", "gamelinescroll_icon_big_charm_2002", "gamelinescroll_icon_big_npcface_2001_end", "npcface_image_2002_1"));
		_dataArray.Add(new StoryScrollItem(8, 1, -1, EStoryScrollStoryResultMark.StoryResultMark2, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_8"), null, "gamelinescroll_icon_big_npcface_2001", "gamelinescroll_icon_big_charm_2002", "gamelinescroll_icon_big_npcface_2001_end", "npcface_image_2002_2"));
		_dataArray.Add(new StoryScrollItem(9, 1, -1, EStoryScrollStoryResultMark.StoryResultMark3, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_9"), null, "gamelinescroll_icon_big_npcface_2001", "gamelinescroll_icon_big_charm_2002", "gamelinescroll_icon_big_npcface_2001_end", "npcface_image_2002_3"));
		_dataArray.Add(new StoryScrollItem(10, 1, -1, EStoryScrollStoryResultMark.StoryResultMark4, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_10"), null, "gamelinescroll_icon_big_npcface_2001", "gamelinescroll_icon_big_charm_2002", "gamelinescroll_icon_big_npcface_2001_end", "npcface_image_2002_4_1"));
		_dataArray.Add(new StoryScrollItem(11, 1, -1, EStoryScrollStoryResultMark.StoryResultMark5, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_11"), null, "gamelinescroll_icon_big_npcface_2001", "gamelinescroll_icon_big_charm_2002", "gamelinescroll_icon_big_npcface_2001_end", "npcface_image_2002_4_0"));
		_dataArray.Add(new StoryScrollItem(12, 2, -1, EStoryScrollStoryResultMark.StoryResultMark0, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_12"), null, "gamelinescroll_icon_big_npcface_2001", "gamelinescroll_icon_big_charm_2003", "gamelinescroll_icon_big_npcface_2001_end", "npcface_image_2003_0"));
		_dataArray.Add(new StoryScrollItem(13, 2, -1, EStoryScrollStoryResultMark.StoryResultMark1, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_13"), null, "gamelinescroll_icon_big_npcface_2001", "gamelinescroll_icon_big_charm_2003", "gamelinescroll_icon_big_npcface_2001_end", "npcface_image_2003_1"));
		_dataArray.Add(new StoryScrollItem(14, 2, -1, EStoryScrollStoryResultMark.StoryResultMark2, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_14"), null, "gamelinescroll_icon_big_npcface_2001", "gamelinescroll_icon_big_charm_2003", "gamelinescroll_icon_big_npcface_2001_end", "npcface_image_2003_2"));
		_dataArray.Add(new StoryScrollItem(15, 2, -1, EStoryScrollStoryResultMark.StoryResultMark3, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_15"), null, "gamelinescroll_icon_big_npcface_2001", "gamelinescroll_icon_big_charm_2003", "gamelinescroll_icon_big_npcface_2001_end", "npcface_image_2003_3"));
		_dataArray.Add(new StoryScrollItem(16, 2, -1, EStoryScrollStoryResultMark.StoryResultMark4, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_16"), null, "gamelinescroll_icon_big_npcface_2001", "gamelinescroll_icon_big_charm_2003", "gamelinescroll_icon_big_npcface_2001_end", "npcface_image_2003_4_1"));
		_dataArray.Add(new StoryScrollItem(17, 2, -1, EStoryScrollStoryResultMark.StoryResultMark5, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_17"), null, "gamelinescroll_icon_big_npcface_2001", "gamelinescroll_icon_big_charm_2003", "gamelinescroll_icon_big_npcface_2001_end", "npcface_image_2003_4_0"));
		_dataArray.Add(new StoryScrollItem(18, 3, -1, EStoryScrollStoryResultMark.StoryResultMark0, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_18"), null, "gamelinescroll_icon_big_npcface_2001", "gamelinescroll_icon_big_charm_2004", "gamelinescroll_icon_big_npcface_2001_end", "npcface_image_2004_0"));
		_dataArray.Add(new StoryScrollItem(19, 3, -1, EStoryScrollStoryResultMark.StoryResultMark1, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_19"), null, "gamelinescroll_icon_big_npcface_2001", "gamelinescroll_icon_big_charm_2004", "gamelinescroll_icon_big_npcface_2001_end", "npcface_image_2004_1"));
		_dataArray.Add(new StoryScrollItem(20, 3, -1, EStoryScrollStoryResultMark.StoryResultMark2, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_20"), null, "gamelinescroll_icon_big_npcface_2001", "gamelinescroll_icon_big_charm_2004", "gamelinescroll_icon_big_npcface_2001_end", "npcface_image_2004_2"));
		_dataArray.Add(new StoryScrollItem(21, 3, -1, EStoryScrollStoryResultMark.StoryResultMark3, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_21"), null, "gamelinescroll_icon_big_npcface_2001", "gamelinescroll_icon_big_charm_2004", "gamelinescroll_icon_big_npcface_2001_end", "npcface_image_2004_3"));
		_dataArray.Add(new StoryScrollItem(22, 3, -1, EStoryScrollStoryResultMark.StoryResultMark4, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_22"), null, "gamelinescroll_icon_big_npcface_2001", "gamelinescroll_icon_big_charm_2004", "gamelinescroll_icon_big_npcface_2001_end", "npcface_image_2004_4_1"));
		_dataArray.Add(new StoryScrollItem(23, 3, -1, EStoryScrollStoryResultMark.StoryResultMark5, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_23"), null, "gamelinescroll_icon_big_npcface_2001", "gamelinescroll_icon_big_charm_2004", "gamelinescroll_icon_big_npcface_2001_end", "npcface_image_2004_4_0"));
		_dataArray.Add(new StoryScrollItem(24, 4, -1, EStoryScrollStoryResultMark.StoryResultMark0, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_24"), null, "gamelinescroll_icon_big_npcface_2001", "gamelinescroll_icon_big_charm_2005", "gamelinescroll_icon_big_npcface_2001_end", "npcface_image_2005_0"));
		_dataArray.Add(new StoryScrollItem(25, 4, -1, EStoryScrollStoryResultMark.StoryResultMark1, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_25"), null, "gamelinescroll_icon_big_npcface_2001", "gamelinescroll_icon_big_charm_2005", "gamelinescroll_icon_big_npcface_2001_end", "npcface_image_2005_1"));
		_dataArray.Add(new StoryScrollItem(26, 4, -1, EStoryScrollStoryResultMark.StoryResultMark2, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_26"), null, "gamelinescroll_icon_big_npcface_2001", "gamelinescroll_icon_big_charm_2005", "gamelinescroll_icon_big_npcface_2001_end", "npcface_image_2005_2"));
		_dataArray.Add(new StoryScrollItem(27, 4, -1, EStoryScrollStoryResultMark.StoryResultMark3, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_27"), null, "gamelinescroll_icon_big_npcface_2001", "gamelinescroll_icon_big_charm_2005", "gamelinescroll_icon_big_npcface_2001_end", "npcface_image_2005_3"));
		_dataArray.Add(new StoryScrollItem(28, 4, -1, EStoryScrollStoryResultMark.StoryResultMark4, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_28"), null, "gamelinescroll_icon_big_npcface_2001", "gamelinescroll_icon_big_charm_2005", "gamelinescroll_icon_big_npcface_2001_end", "npcface_image_2005_4_1"));
		_dataArray.Add(new StoryScrollItem(29, 4, -1, EStoryScrollStoryResultMark.StoryResultMark5, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_29"), null, "gamelinescroll_icon_big_npcface_2001", "gamelinescroll_icon_big_charm_2005", "gamelinescroll_icon_big_npcface_2001_end", "npcface_image_2005_4_0"));
		_dataArray.Add(new StoryScrollItem(30, 5, -1, EStoryScrollStoryResultMark.StoryResultMark0, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_30"), null, "gamelinescroll_icon_big_npcface_2001", "gamelinescroll_icon_big_charm_2006", "gamelinescroll_icon_big_npcface_2001_end", "npcface_image_2006_0"));
		_dataArray.Add(new StoryScrollItem(31, 5, -1, EStoryScrollStoryResultMark.StoryResultMark1, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_31"), null, "gamelinescroll_icon_big_npcface_2001", "gamelinescroll_icon_big_charm_2006", "gamelinescroll_icon_big_npcface_2001_end", "npcface_image_2006_1"));
		_dataArray.Add(new StoryScrollItem(32, 5, -1, EStoryScrollStoryResultMark.StoryResultMark2, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_32"), null, "gamelinescroll_icon_big_npcface_2001", "gamelinescroll_icon_big_charm_2006", "gamelinescroll_icon_big_npcface_2001_end", "npcface_image_2006_2"));
		_dataArray.Add(new StoryScrollItem(33, 5, -1, EStoryScrollStoryResultMark.StoryResultMark3, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_33"), null, "gamelinescroll_icon_big_npcface_2001", "gamelinescroll_icon_big_charm_2006", "gamelinescroll_icon_big_npcface_2001_end", "npcface_image_2006_3"));
		_dataArray.Add(new StoryScrollItem(34, 5, -1, EStoryScrollStoryResultMark.StoryResultMark4, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_34"), null, "gamelinescroll_icon_big_npcface_2001", "gamelinescroll_icon_big_charm_2006", "gamelinescroll_icon_big_npcface_2001_end", "npcface_image_2006_4_1"));
		_dataArray.Add(new StoryScrollItem(35, 5, -1, EStoryScrollStoryResultMark.StoryResultMark5, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_35"), null, "gamelinescroll_icon_big_npcface_2001", "gamelinescroll_icon_big_charm_2006", "gamelinescroll_icon_big_npcface_2001_end", "npcface_image_2006_4_0"));
		_dataArray.Add(new StoryScrollItem(36, 6, -1, EStoryScrollStoryResultMark.StoryResultMark0, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_36"), null, "gamelinescroll_icon_big_npcface_2001", "gamelinescroll_icon_big_charm_2007", "gamelinescroll_icon_big_npcface_2001_end", "npcface_image_2007_0"));
		_dataArray.Add(new StoryScrollItem(37, 6, -1, EStoryScrollStoryResultMark.StoryResultMark1, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_37"), null, "gamelinescroll_icon_big_npcface_2001", "gamelinescroll_icon_big_charm_2007", "gamelinescroll_icon_big_npcface_2001_end", "npcface_image_2007_1"));
		_dataArray.Add(new StoryScrollItem(38, 6, -1, EStoryScrollStoryResultMark.StoryResultMark2, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_38"), null, "gamelinescroll_icon_big_npcface_2001", "gamelinescroll_icon_big_charm_2007", "gamelinescroll_icon_big_npcface_2001_end", "npcface_image_2007_2"));
		_dataArray.Add(new StoryScrollItem(39, 6, -1, EStoryScrollStoryResultMark.StoryResultMark3, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_39"), null, "gamelinescroll_icon_big_npcface_2001", "gamelinescroll_icon_big_charm_2007", "gamelinescroll_icon_big_npcface_2001_end", "npcface_image_2007_3"));
		_dataArray.Add(new StoryScrollItem(40, 6, -1, EStoryScrollStoryResultMark.StoryResultMark4, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_40"), null, "gamelinescroll_icon_big_npcface_2001", "gamelinescroll_icon_big_charm_2007", "gamelinescroll_icon_big_npcface_2001_end", "npcface_image_2007_4_1"));
		_dataArray.Add(new StoryScrollItem(41, 6, -1, EStoryScrollStoryResultMark.StoryResultMark5, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_41"), null, "gamelinescroll_icon_big_npcface_2001", "gamelinescroll_icon_big_charm_2007", "gamelinescroll_icon_big_npcface_2001_end", "npcface_image_2007_4_0"));
		_dataArray.Add(new StoryScrollItem(42, 7, -1, EStoryScrollStoryResultMark.StoryResultMark0, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_42"), null, "gamelinescroll_icon_big_npcface_2001", "gamelinescroll_icon_big_charm_2008", "gamelinescroll_icon_big_npcface_2001_end", "npcface_image_2008_0"));
		_dataArray.Add(new StoryScrollItem(43, 7, -1, EStoryScrollStoryResultMark.StoryResultMark1, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_43"), null, "gamelinescroll_icon_big_npcface_2001", "gamelinescroll_icon_big_charm_2008", "gamelinescroll_icon_big_npcface_2001_end", "npcface_image_2008_1"));
		_dataArray.Add(new StoryScrollItem(44, 7, -1, EStoryScrollStoryResultMark.StoryResultMark2, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_44"), null, "gamelinescroll_icon_big_npcface_2001", "gamelinescroll_icon_big_charm_2008", "gamelinescroll_icon_big_npcface_2001_end", "npcface_image_2008_2"));
		_dataArray.Add(new StoryScrollItem(45, 7, -1, EStoryScrollStoryResultMark.StoryResultMark3, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_45"), null, "gamelinescroll_icon_big_npcface_2001", "gamelinescroll_icon_big_charm_2008", "gamelinescroll_icon_big_npcface_2001_end", "npcface_image_2008_3"));
		_dataArray.Add(new StoryScrollItem(46, 7, -1, EStoryScrollStoryResultMark.StoryResultMark4, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_46"), null, "gamelinescroll_icon_big_npcface_2001", "gamelinescroll_icon_big_charm_2008", "gamelinescroll_icon_big_npcface_2001_end", "npcface_image_2008_4_1"));
		_dataArray.Add(new StoryScrollItem(47, 7, -1, EStoryScrollStoryResultMark.StoryResultMark5, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_47"), null, "gamelinescroll_icon_big_npcface_2001", "gamelinescroll_icon_big_charm_2008", "gamelinescroll_icon_big_npcface_2001_end", "npcface_image_2008_4_0"));
		_dataArray.Add(new StoryScrollItem(48, 8, -1, EStoryScrollStoryResultMark.StoryResultMark0, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_48"), null, "gamelinescroll_icon_big_npcface_2001", "gamelinescroll_icon_big_charm_2009", "gamelinescroll_icon_big_npcface_2001_end", "npcface_image_2009_0"));
		_dataArray.Add(new StoryScrollItem(49, 8, -1, EStoryScrollStoryResultMark.StoryResultMark1, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_49"), null, "gamelinescroll_icon_big_npcface_2001", "gamelinescroll_icon_big_charm_2009", "gamelinescroll_icon_big_npcface_2001_end", "npcface_image_2009_1"));
		_dataArray.Add(new StoryScrollItem(50, 8, -1, EStoryScrollStoryResultMark.StoryResultMark2, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_50"), null, "gamelinescroll_icon_big_npcface_2001", "gamelinescroll_icon_big_charm_2009", "gamelinescroll_icon_big_npcface_2001_end", "npcface_image_2009_2"));
		_dataArray.Add(new StoryScrollItem(51, 8, -1, EStoryScrollStoryResultMark.StoryResultMark3, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_51"), null, "gamelinescroll_icon_big_npcface_2001", "gamelinescroll_icon_big_charm_2009", "gamelinescroll_icon_big_npcface_2001_end", "npcface_image_2009_3"));
		_dataArray.Add(new StoryScrollItem(52, 8, -1, EStoryScrollStoryResultMark.StoryResultMark4, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_52"), null, "gamelinescroll_icon_big_npcface_2001", "gamelinescroll_icon_big_charm_2009", "gamelinescroll_icon_big_npcface_2001_end", "npcface_image_2009_4_1"));
		_dataArray.Add(new StoryScrollItem(53, 8, -1, EStoryScrollStoryResultMark.StoryResultMark5, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_53"), null, "gamelinescroll_icon_big_npcface_2001", "gamelinescroll_icon_big_charm_2009", "gamelinescroll_icon_big_npcface_2001_end", "npcface_image_2009_4_0"));
		_dataArray.Add(new StoryScrollItem(54, -1, 1, EStoryScrollStoryResultMark.StoryResultMark6, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_54"), "settlementInformation_icon_sect_1_enter", "settlementInformation_icon_sect_1", "settlementInformation_icon_sect_charm_1", "settlementInformation_icon_sect_1_end", "sectstory_image_1_0"));
		_dataArray.Add(new StoryScrollItem(55, -1, 1, EStoryScrollStoryResultMark.StoryResultMark7, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_55"), "settlementInformation_icon_sect_1_enter", "settlementInformation_icon_sect_1", "settlementInformation_icon_sect_charm_1", "settlementInformation_icon_sect_1_end", "sectstory_image_1_1"));
		_dataArray.Add(new StoryScrollItem(56, -1, 2, EStoryScrollStoryResultMark.StoryResultMark6, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_56"), "settlementInformation_icon_sect_2_enter", "settlementInformation_icon_sect_2", "settlementInformation_icon_sect_charm_2", "settlementInformation_icon_sect_1_end", "sectstory_image_2_0"));
		_dataArray.Add(new StoryScrollItem(57, -1, 2, EStoryScrollStoryResultMark.StoryResultMark7, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_57"), "settlementInformation_icon_sect_2_enter", "settlementInformation_icon_sect_2", "settlementInformation_icon_sect_charm_2", "settlementInformation_icon_sect_1_end", "sectstory_image_2_1"));
		_dataArray.Add(new StoryScrollItem(58, -1, 3, EStoryScrollStoryResultMark.StoryResultMark6, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_58"), "settlementInformation_icon_sect_3_enter", "settlementInformation_icon_sect_3", "settlementInformation_icon_sect_charm_3", "settlementInformation_icon_sect_1_end", "sectstory_image_3_0"));
		_dataArray.Add(new StoryScrollItem(59, -1, 3, EStoryScrollStoryResultMark.StoryResultMark7, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_59"), "settlementInformation_icon_sect_3_enter", "settlementInformation_icon_sect_3", "settlementInformation_icon_sect_charm_3", "settlementInformation_icon_sect_1_end", "sectstory_image_3_1"));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new StoryScrollItem(60, -1, 4, EStoryScrollStoryResultMark.StoryResultMark6, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_60"), "settlementInformation_icon_sect_4_enter", "settlementInformation_icon_sect_4", "settlementInformation_icon_sect_charm_4", "settlementInformation_icon_sect_1_end", "sectstory_image_4_0"));
		_dataArray.Add(new StoryScrollItem(61, -1, 4, EStoryScrollStoryResultMark.StoryResultMark7, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_61"), "settlementInformation_icon_sect_4_enter", "settlementInformation_icon_sect_4", "settlementInformation_icon_sect_charm_4", "settlementInformation_icon_sect_1_end", "sectstory_image_4_1"));
		_dataArray.Add(new StoryScrollItem(62, -1, 5, EStoryScrollStoryResultMark.StoryResultMark6, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_62"), "settlementInformation_icon_sect_5_enter", "settlementInformation_icon_sect_5", "settlementInformation_icon_sect_charm_5", "settlementInformation_icon_sect_1_end", "sectstory_image_5_0"));
		_dataArray.Add(new StoryScrollItem(63, -1, 5, EStoryScrollStoryResultMark.StoryResultMark7, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_63"), "settlementInformation_icon_sect_5_enter", "settlementInformation_icon_sect_5", "settlementInformation_icon_sect_charm_5", "settlementInformation_icon_sect_1_end", "sectstory_image_5_1"));
		_dataArray.Add(new StoryScrollItem(64, -1, 6, EStoryScrollStoryResultMark.StoryResultMark6, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_64"), "settlementInformation_icon_sect_6_enter", "settlementInformation_icon_sect_6", "settlementInformation_icon_sect_charm_6", "settlementInformation_icon_sect_2_end", "sectstory_image_6_0"));
		_dataArray.Add(new StoryScrollItem(65, -1, 6, EStoryScrollStoryResultMark.StoryResultMark7, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_65"), "settlementInformation_icon_sect_6_enter", "settlementInformation_icon_sect_6", "settlementInformation_icon_sect_charm_6", "settlementInformation_icon_sect_2_end", "sectstory_image_6_1"));
		_dataArray.Add(new StoryScrollItem(66, -1, 7, EStoryScrollStoryResultMark.StoryResultMark6, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_66"), "settlementInformation_icon_sect_7_enter", "settlementInformation_icon_sect_7", "settlementInformation_icon_sect_charm_7", "settlementInformation_icon_sect_2_end", "sectstory_image_7_0"));
		_dataArray.Add(new StoryScrollItem(67, -1, 7, EStoryScrollStoryResultMark.StoryResultMark7, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_67"), "settlementInformation_icon_sect_7_enter", "settlementInformation_icon_sect_7", "settlementInformation_icon_sect_charm_7", "settlementInformation_icon_sect_2_end", "sectstory_image_7_1"));
		_dataArray.Add(new StoryScrollItem(68, -1, 8, EStoryScrollStoryResultMark.StoryResultMark6, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_68"), "settlementInformation_icon_sect_8_enter", "settlementInformation_icon_sect_8", "settlementInformation_icon_sect_charm_8", "settlementInformation_icon_sect_2_end", "sectstory_image_8_0"));
		_dataArray.Add(new StoryScrollItem(69, -1, 8, EStoryScrollStoryResultMark.StoryResultMark7, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_69"), "settlementInformation_icon_sect_8_enter", "settlementInformation_icon_sect_8", "settlementInformation_icon_sect_charm_8", "settlementInformation_icon_sect_2_end", "sectstory_image_8_1"));
		_dataArray.Add(new StoryScrollItem(70, -1, 9, EStoryScrollStoryResultMark.StoryResultMark6, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_70"), "settlementInformation_icon_sect_9_enter", "settlementInformation_icon_sect_9", "settlementInformation_icon_sect_charm_9", "settlementInformation_icon_sect_2_end", "sectstory_image_9_0"));
		_dataArray.Add(new StoryScrollItem(71, -1, 9, EStoryScrollStoryResultMark.StoryResultMark7, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_71"), "settlementInformation_icon_sect_9_enter", "settlementInformation_icon_sect_9", "settlementInformation_icon_sect_charm_9", "settlementInformation_icon_sect_2_end", "sectstory_image_9_1"));
		_dataArray.Add(new StoryScrollItem(72, -1, 10, EStoryScrollStoryResultMark.StoryResultMark6, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_72"), "settlementInformation_icon_sect_10_enter", "settlementInformation_icon_sect_10", "settlementInformation_icon_sect_charm_10", "settlementInformation_icon_sect_2_end", "sectstory_image_10_0"));
		_dataArray.Add(new StoryScrollItem(73, -1, 10, EStoryScrollStoryResultMark.StoryResultMark7, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_73"), "settlementInformation_icon_sect_10_enter", "settlementInformation_icon_sect_10", "settlementInformation_icon_sect_charm_10", "settlementInformation_icon_sect_2_end", "sectstory_image_10_1"));
		_dataArray.Add(new StoryScrollItem(74, -1, 11, EStoryScrollStoryResultMark.StoryResultMark6, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_74"), "settlementInformation_icon_sect_11_enter", "settlementInformation_icon_sect_11", "settlementInformation_icon_sect_charm_11", "settlementInformation_icon_sect_3_end", "sectstory_image_11_0"));
		_dataArray.Add(new StoryScrollItem(75, -1, 11, EStoryScrollStoryResultMark.StoryResultMark7, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_75"), "settlementInformation_icon_sect_11_enter", "settlementInformation_icon_sect_11", "settlementInformation_icon_sect_charm_11", "settlementInformation_icon_sect_3_end", "sectstory_image_11_1"));
		_dataArray.Add(new StoryScrollItem(76, -1, 12, EStoryScrollStoryResultMark.StoryResultMark6, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_76"), "settlementInformation_icon_sect_12_enter", "settlementInformation_icon_sect_12", "settlementInformation_icon_sect_charm_12", "settlementInformation_icon_sect_3_end", "sectstory_image_12_0"));
		_dataArray.Add(new StoryScrollItem(77, -1, 12, EStoryScrollStoryResultMark.StoryResultMark7, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_77"), "settlementInformation_icon_sect_12_enter", "settlementInformation_icon_sect_12", "settlementInformation_icon_sect_charm_12", "settlementInformation_icon_sect_3_end", "sectstory_image_12_1"));
		_dataArray.Add(new StoryScrollItem(78, -1, 13, EStoryScrollStoryResultMark.StoryResultMark6, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_78"), null, "settlementInformation_icon_sect_13", "settlementInformation_icon_sect_charm_13", "settlementInformation_icon_sect_3_end", "sectstory_image_13_0"));
		_dataArray.Add(new StoryScrollItem(79, -1, 13, EStoryScrollStoryResultMark.StoryResultMark7, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_79"), null, "settlementInformation_icon_sect_13", "settlementInformation_icon_sect_charm_13", "settlementInformation_icon_sect_3_end", "sectstory_image_13_1"));
		_dataArray.Add(new StoryScrollItem(80, -1, 14, EStoryScrollStoryResultMark.StoryResultMark6, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_80"), "settlementInformation_icon_sect_14_enter", "settlementInformation_icon_sect_14", "settlementInformation_icon_sect_charm_14", "settlementInformation_icon_sect_3_end", "sectstory_image_14_0"));
		_dataArray.Add(new StoryScrollItem(81, -1, 14, EStoryScrollStoryResultMark.StoryResultMark7, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_81"), "settlementInformation_icon_sect_14_enter", "settlementInformation_icon_sect_14", "settlementInformation_icon_sect_charm_14", "settlementInformation_icon_sect_3_end", "sectstory_image_14_1"));
		_dataArray.Add(new StoryScrollItem(82, -1, 15, EStoryScrollStoryResultMark.StoryResultMark6, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_82"), "settlementInformation_icon_sect_15_enter", "settlementInformation_icon_sect_15", "settlementInformation_icon_sect_charm_15", "settlementInformation_icon_sect_3_end", "sectstory_image_15_0"));
		_dataArray.Add(new StoryScrollItem(83, -1, 15, EStoryScrollStoryResultMark.StoryResultMark7, LocalStringManager.GetConfig("StoryScroll_language", "StoryNote_83"), "settlementInformation_icon_sect_15_enter", "settlementInformation_icon_sect_15", "settlementInformation_icon_sect_charm_15", "settlementInformation_icon_sect_3_end", "sectstory_image_15_1"));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<StoryScrollItem>(84);
		CreateItems0();
		CreateItems1();
	}
}

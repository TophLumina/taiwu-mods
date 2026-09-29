using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class ImplementedDlc : ConfigData<ImplementedDlcItem, byte>
{
	public static class DefKey
	{
		public const byte InteractOfLove = 0;

		public const byte GiftFromConchShip1 = 1;

		public const byte GiftFromConchShip2 = 2;

		public const byte FiveLoong = 3;

		public const byte HappyNewYear2024 = 4;

		public const byte YearOfSnakeCloth = 5;

		public const byte HappyNewYear2026 = 6;

		public const byte OST = 7;

		public const byte OST2 = 8;

		public const byte CricketPolymorph = 9;

		public const byte GreenHillsRemain = 10;

		public const byte EightYears = 11;

		public const byte SmarterChicken = 12;

		public const byte TaiwuAsXiangshu = 13;

		public const byte TameLoong = 14;
	}

	public static class DefValue
	{
		public static ImplementedDlcItem InteractOfLove => Instance[(byte)0];

		public static ImplementedDlcItem GiftFromConchShip1 => Instance[(byte)1];

		public static ImplementedDlcItem GiftFromConchShip2 => Instance[(byte)2];

		public static ImplementedDlcItem FiveLoong => Instance[(byte)3];

		public static ImplementedDlcItem HappyNewYear2024 => Instance[(byte)4];

		public static ImplementedDlcItem YearOfSnakeCloth => Instance[(byte)5];

		public static ImplementedDlcItem HappyNewYear2026 => Instance[(byte)6];

		public static ImplementedDlcItem OST => Instance[(byte)7];

		public static ImplementedDlcItem OST2 => Instance[(byte)8];

		public static ImplementedDlcItem CricketPolymorph => Instance[(byte)9];

		public static ImplementedDlcItem GreenHillsRemain => Instance[(byte)10];

		public static ImplementedDlcItem EightYears => Instance[(byte)11];

		public static ImplementedDlcItem SmarterChicken => Instance[(byte)12];

		public static ImplementedDlcItem TaiwuAsXiangshu => Instance[(byte)13];

		public static ImplementedDlcItem TameLoong => Instance[(byte)14];
	}

	public static ImplementedDlc Instance = new ImplementedDlc();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Desc", "TemplateId", "Name", "DisplayName", "ScrollIcon", "MainImageHorizontal", "MainImageVertical", "Screenshots" };

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
		_dataArray.Add(new ImplementedDlcItem(0, 2305890u, "InteractOfLove", "恋爱互动", new string[0], null, null, null, null, onlyDisplay: false, -1, EImplementedDlcType.Gameplay, isFree: true, isImplemented: false));
		_dataArray.Add(new ImplementedDlcItem(1, 2241120u, "GiftFromConchShip1", "宛渠之民的赠礼之一", new string[2]
		{
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_1_0"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_1_1")
		}, "ui9_back_dlc_introduce_scroll_0", "ui9_tex_dlc_introduce_horiztontal_4", "ui9_tex_dlc_introduce_vertical_1", new string[2] { "ui9_back_dlc_introduce_screenshoot_1", "ui9_back_dlc_introduce_screenshoot_2" }, onlyDisplay: false, 2, EImplementedDlcType.Appearance, isFree: true, isImplemented: true));
		_dataArray.Add(new ImplementedDlcItem(2, 2172690u, "GiftFromConchShip2", "宛渠之民的赠礼之二", new string[2]
		{
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_2_0"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_2_1")
		}, "ui9_back_dlc_introduce_scroll_6", "ui9_tex_dlc_introduce_horiztontal_4", "ui9_tex_dlc_introduce_vertical_1", new string[2] { "ui9_back_dlc_introduce_screenshoot_1", "ui9_back_dlc_introduce_screenshoot_2" }, onlyDisplay: false, 1, EImplementedDlcType.Appearance, isFree: true, isImplemented: true));
		_dataArray.Add(new ImplementedDlcItem(3, 2764950u, "FiveLoong", "五方神龙", new string[2]
		{
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_3_0"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_3_1")
		}, "ui9_back_dlc_introduce_scroll_2", "ui9_tex_dlc_introduce_horiztontal_0", "ui9_tex_dlc_introduce_vertical_5", new string[4] { "ui9_back_dlc_introduce_screenshoot_6", "ui9_back_dlc_introduce_screenshoot_7", "ui9_back_dlc_introduce_screenshoot_8", "ui9_back_dlc_introduce_screenshoot_9" }, onlyDisplay: false, 3, EImplementedDlcType.Gameplay, isFree: true, isImplemented: true));
		_dataArray.Add(new ImplementedDlcItem(4, 2764960u, "HappyNewYear2024", "新衣贺春", new string[6]
		{
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_4_0"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_4_1"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_4_2"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_4_3"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_4_4"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_4_5")
		}, "ui9_back_dlc_introduce_scroll_1", "ui9_tex_dlc_introduce_horiztontal_2", "ui9_tex_dlc_introduce_vertical_3", new string[1] { "ui9_back_dlc_introduce_screenshoot_4" }, onlyDisplay: false, 4, EImplementedDlcType.Appearance, isFree: false, isImplemented: true));
		_dataArray.Add(new ImplementedDlcItem(5, 3464590u, "YearOfSnakeCloth", "碧霄蛇影", new string[4]
		{
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_5_0"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_5_1"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_5_2"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_5_3")
		}, "ui9_back_dlc_introduce_scroll_5", "ui9_tex_dlc_introduce_horiztontal_1", "ui9_tex_dlc_introduce_vertical_2", new string[1] { "ui9_back_dlc_introduce_screenshoot_3" }, onlyDisplay: false, 6, EImplementedDlcType.Appearance, isFree: false, isImplemented: true));
		_dataArray.Add(new ImplementedDlcItem(6, 4395170u, "HappyNewYear2026", "跃马听香", new string[4]
		{
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_6_0"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_6_1"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_6_2"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_6_3")
		}, "ui9_back_dlc_introduce_scroll_4", "ui9_tex_dlc_introduce_horiztontal_3", "ui9_tex_dlc_introduce_vertical_4", new string[1] { "ui9_back_dlc_introduce_screenshoot_5" }, onlyDisplay: false, 7, EImplementedDlcType.Appearance, isFree: true, isImplemented: true));
		_dataArray.Add(new ImplementedDlcItem(7, 946970u, "OST", "原声带", new string[4]
		{
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_7_0"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_7_1"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_7_2"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_7_3")
		}, "ui9_back_dlc_introduce_scroll_3", "ui9_tex_dlc_introduce_horiztontal_5", "ui9_tex_dlc_introduce_vertical_0", new string[1] { "ui9_back_dlc_introduce_screenshoot_0" }, onlyDisplay: true, 0, EImplementedDlcType.Music, isFree: false, isImplemented: true));
		_dataArray.Add(new ImplementedDlcItem(8, 2819320u, "OST2", "原声带2", new string[6]
		{
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_8_0"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_8_1"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_8_2"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_8_3"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_8_4"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_8_5")
		}, "ui9_back_dlc_introduce_scroll_3", "ui9_tex_dlc_introduce_horiztontal_5", "ui9_tex_dlc_introduce_vertical_0", new string[1] { "ui9_back_dlc_introduce_screenshoot_0" }, onlyDisplay: true, 5, EImplementedDlcType.Music, isFree: true, isImplemented: true));
		_dataArray.Add(new ImplementedDlcItem(9, 4528730u, "CricketPolymorph", "促织化影", new string[2]
		{
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_9_0"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_9_1")
		}, "ui9_back_dlc_introduce_scroll_7", "ui9_tex_dlc_introduce_horiztontal_6", "ui9_tex_dlc_introduce_vertical_6", new string[1] { "ui9_back_dlc_introduce_screenshoot_10" }, onlyDisplay: false, 8, EImplementedDlcType.Gameplay, isFree: false, isImplemented: true));
		_dataArray.Add(new ImplementedDlcItem(10, 4834450u, "GreenHillsRemain", "青山依旧", new string[4]
		{
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_10_0"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_10_1"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_10_2"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_10_3")
		}, "ui9_back_dlc_introduce_scroll_8", "ui9_tex_dlc_introduce_horiztontal_7", "ui9_tex_dlc_introduce_vertical_7", new string[1] { "ui9_back_dlc_introduce_screenshoot_11" }, onlyDisplay: false, 9, EImplementedDlcType.Appearance, isFree: false, isImplemented: true));
		_dataArray.Add(new ImplementedDlcItem(11, 4834440u, "EightYears", "八载同舟", new string[4]
		{
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_11_0"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_11_1"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_11_2"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_11_3")
		}, "ui9_back_dlc_introduce_scroll_9", "ui9_tex_dlc_introduce_horiztontal_8", "ui9_tex_dlc_introduce_vertical_8", new string[1] { "ui9_back_dlc_introduce_screenshoot_12" }, onlyDisplay: false, 10, EImplementedDlcType.Appearance, isFree: true, isImplemented: true));
		_dataArray.Add(new ImplementedDlcItem(12, 4975570u, "SmarterChicken", "元鸡化影", new string[4]
		{
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_12_0"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_12_1"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_12_2"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_12_3")
		}, "ui9_back_dlc_introduce_scroll_10", "ui9_tex_dlc_introduce_horiztontal_9", "ui9_tex_dlc_introduce_vertical_9", new string[1] { "ui9_back_dlc_introduce_screenshoot_13" }, onlyDisplay: false, 11, EImplementedDlcType.Gameplay, isFree: false, isImplemented: true));
		_dataArray.Add(new ImplementedDlcItem(13, 5093790u, "TaiwuAsXiangshu", "玄相通天", new string[4]
		{
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_13_0"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_13_1"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_13_2"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_13_3")
		}, "ui9_back_dlc_introduce_scroll_12", "ui9_tex_dlc_introduce_horiztontal_11", "ui9_tex_dlc_introduce_vertical_11", new string[1] { "ui9_back_dlc_introduce_screenshoot_15" }, onlyDisplay: false, 12, EImplementedDlcType.Gameplay, isFree: true, isImplemented: true));
		_dataArray.Add(new ImplementedDlcItem(14, 5093830u, "TameLoong", "神龙归心", new string[4]
		{
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_14_0"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_14_1"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_14_2"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_14_3")
		}, "ui9_back_dlc_introduce_scroll_11", "ui9_tex_dlc_introduce_horiztontal_10", "ui9_tex_dlc_introduce_vertical_10", new string[1] { "ui9_back_dlc_introduce_screenshoot_14" }, onlyDisplay: false, 13, EImplementedDlcType.Gameplay, isFree: true, isImplemented: true));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<ImplementedDlcItem>(15);
		CreateItems0();
	}
}

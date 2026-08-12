using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class ImplementedDlc : ConfigData<ImplementedDlcItem, byte>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 恋爱互动
		/// </summary>
		public const byte InteractOfLove = 0;

		/// <summary>
		/// 宛渠之民的赠礼之一
		/// </summary>
		public const byte GiftFromConchShip1 = 1;

		/// <summary>
		/// 宛渠之民的赠礼之二
		/// </summary>
		public const byte GiftFromConchShip2 = 2;

		/// <summary>
		/// 五方神龙
		/// </summary>
		public const byte FiveLoong = 3;

		/// <summary>
		/// 新衣贺春
		/// </summary>
		public const byte HappyNewYear2024 = 4;

		/// <summary>
		/// 碧霄蛇影
		/// </summary>
		public const byte YearOfSnakeCloth = 5;

		/// <summary>
		/// 跃马听香
		/// </summary>
		public const byte HappyNewYear2026 = 6;

		/// <summary>
		/// OST
		/// </summary>
		public const byte OST = 7;

		/// <summary>
		/// OST2
		/// </summary>
		public const byte OST2 = 8;

		/// <summary>
		/// 促织有灵
		/// </summary>
		public const byte CricketPolymorph = 9;

		/// <summary>
		/// 青山依旧
		/// </summary>
		public const byte GreenHillsRemain = 10;

		/// <summary>
		/// 八载同舟
		/// </summary>
		public const byte EightYears = 11;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 恋爱互动
		/// </summary>
		public static ImplementedDlcItem InteractOfLove => Instance[(byte)0];

		/// <summary>
		/// 宛渠之民的赠礼之一
		/// </summary>
		public static ImplementedDlcItem GiftFromConchShip1 => Instance[(byte)1];

		/// <summary>
		/// 宛渠之民的赠礼之二
		/// </summary>
		public static ImplementedDlcItem GiftFromConchShip2 => Instance[(byte)2];

		/// <summary>
		/// 五方神龙
		/// </summary>
		public static ImplementedDlcItem FiveLoong => Instance[(byte)3];

		/// <summary>
		/// 新衣贺春
		/// </summary>
		public static ImplementedDlcItem HappyNewYear2024 => Instance[(byte)4];

		/// <summary>
		/// 碧霄蛇影
		/// </summary>
		public static ImplementedDlcItem YearOfSnakeCloth => Instance[(byte)5];

		/// <summary>
		/// 跃马听香
		/// </summary>
		public static ImplementedDlcItem HappyNewYear2026 => Instance[(byte)6];

		/// <summary>
		/// OST
		/// </summary>
		public static ImplementedDlcItem OST => Instance[(byte)7];

		/// <summary>
		/// OST2
		/// </summary>
		public static ImplementedDlcItem OST2 => Instance[(byte)8];

		/// <summary>
		/// 促织有灵
		/// </summary>
		public static ImplementedDlcItem CricketPolymorph => Instance[(byte)9];

		/// <summary>
		/// 青山依旧
		/// </summary>
		public static ImplementedDlcItem GreenHillsRemain => Instance[(byte)10];

		/// <summary>
		/// 八载同舟
		/// </summary>
		public static ImplementedDlcItem EightYears => Instance[(byte)11];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
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
		_dataArray.Add(new ImplementedDlcItem(0, 2305890u, "InteractOfLove", "恋爱互动", new string[0], null, null, null, null, onlyDisplay: false, -1, EImplementedDlcType.Gameplay, isFree: true));
		_dataArray.Add(new ImplementedDlcItem(1, 2241120u, "GiftFromConchShip1", "宛渠之民的赠礼之一", new string[2]
		{
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_1_0"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_1_1")
		}, "ui9_back_dlc_introduce_scroll_0", "ui9_tex_dlc_introduce_horiztontal_4", "ui9_tex_dlc_introduce_vertical_1", new string[2] { "ui9_back_dlc_introduce_screenshoot_1", "ui9_back_dlc_introduce_screenshoot_2" }, onlyDisplay: false, 2, EImplementedDlcType.Appearance, isFree: true));
		_dataArray.Add(new ImplementedDlcItem(2, 2172690u, "GiftFromConchShip2", "宛渠之民的赠礼之二", new string[2]
		{
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_2_0"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_2_1")
		}, "ui9_back_dlc_introduce_scroll_6", "ui9_tex_dlc_introduce_horiztontal_4", "ui9_tex_dlc_introduce_vertical_1", new string[2] { "ui9_back_dlc_introduce_screenshoot_1", "ui9_back_dlc_introduce_screenshoot_2" }, onlyDisplay: false, 1, EImplementedDlcType.Appearance, isFree: true));
		_dataArray.Add(new ImplementedDlcItem(3, 2764950u, "FiveLoong", "五方神龙", new string[2]
		{
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_3_0"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_3_1")
		}, "ui9_back_dlc_introduce_scroll_2", "ui9_tex_dlc_introduce_horiztontal_0", "ui9_tex_dlc_introduce_vertical_5", new string[4] { "ui9_back_dlc_introduce_screenshoot_6", "ui9_back_dlc_introduce_screenshoot_7", "ui9_back_dlc_introduce_screenshoot_8", "ui9_back_dlc_introduce_screenshoot_9" }, onlyDisplay: false, 3, EImplementedDlcType.Gameplay, isFree: true));
		_dataArray.Add(new ImplementedDlcItem(4, 2764960u, "HappyNewYear2024", "新衣贺春", new string[6]
		{
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_4_0"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_4_1"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_4_2"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_4_3"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_4_4"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_4_5")
		}, "ui9_back_dlc_introduce_scroll_1", "ui9_tex_dlc_introduce_horiztontal_2", "ui9_tex_dlc_introduce_vertical_3", new string[1] { "ui9_back_dlc_introduce_screenshoot_4" }, onlyDisplay: false, 4, EImplementedDlcType.Appearance, isFree: false));
		_dataArray.Add(new ImplementedDlcItem(5, 3464590u, "YearOfSnakeCloth", "碧霄蛇影", new string[4]
		{
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_5_0"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_5_1"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_5_2"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_5_3")
		}, "ui9_back_dlc_introduce_scroll_5", "ui9_tex_dlc_introduce_horiztontal_1", "ui9_tex_dlc_introduce_vertical_2", new string[1] { "ui9_back_dlc_introduce_screenshoot_3" }, onlyDisplay: false, 6, EImplementedDlcType.Appearance, isFree: false));
		_dataArray.Add(new ImplementedDlcItem(6, 4395170u, "HappyNewYear2026", "跃马听香", new string[4]
		{
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_6_0"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_6_1"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_6_2"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_6_3")
		}, "ui9_back_dlc_introduce_scroll_4", "ui9_tex_dlc_introduce_horiztontal_3", "ui9_tex_dlc_introduce_vertical_4", new string[1] { "ui9_back_dlc_introduce_screenshoot_5" }, onlyDisplay: false, 7, EImplementedDlcType.Appearance, isFree: true));
		_dataArray.Add(new ImplementedDlcItem(7, 946970u, "OST", "原声带", new string[4]
		{
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_7_0"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_7_1"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_7_2"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_7_3")
		}, "ui9_back_dlc_introduce_scroll_3", "ui9_tex_dlc_introduce_horiztontal_5", "ui9_tex_dlc_introduce_vertical_0", new string[1] { "ui9_back_dlc_introduce_screenshoot_0" }, onlyDisplay: true, 0, EImplementedDlcType.Music, isFree: false));
		_dataArray.Add(new ImplementedDlcItem(8, 2819320u, "OST2", "原声带2", new string[6]
		{
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_8_0"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_8_1"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_8_2"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_8_3"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_8_4"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_8_5")
		}, "ui9_back_dlc_introduce_scroll_3", "ui9_tex_dlc_introduce_horiztontal_5", "ui9_tex_dlc_introduce_vertical_0", new string[1] { "ui9_back_dlc_introduce_screenshoot_0" }, onlyDisplay: true, 5, EImplementedDlcType.Music, isFree: true));
		_dataArray.Add(new ImplementedDlcItem(9, 4528730u, "CricketPolymorph", "促织化影", new string[2]
		{
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_9_0"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_9_1")
		}, "ui9_back_dlc_introduce_scroll_7", "ui9_tex_dlc_introduce_horiztontal_6", "ui9_tex_dlc_introduce_vertical_6", new string[1] { "ui9_back_dlc_introduce_screenshoot_10" }, onlyDisplay: false, 8, EImplementedDlcType.Gameplay, isFree: false));
		_dataArray.Add(new ImplementedDlcItem(10, 4834450u, "GreenHillsRemain", "青山依旧", new string[4]
		{
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_10_0"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_10_1"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_10_2"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_10_3")
		}, "ui9_back_dlc_introduce_scroll_8", "ui9_tex_dlc_introduce_horiztontal_7", "ui9_tex_dlc_introduce_vertical_7", new string[1] { "ui9_back_dlc_introduce_screenshoot_11" }, onlyDisplay: false, 9, EImplementedDlcType.Appearance, isFree: false));
		_dataArray.Add(new ImplementedDlcItem(11, 4834440u, "EightYears", "八载同舟", new string[4]
		{
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_11_0"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_11_1"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_11_2"),
			LocalStringManager.GetConfig("ImplementedDlc_language", "Desc_11_3")
		}, "ui9_back_dlc_introduce_scroll_9", "ui9_tex_dlc_introduce_horiztontal_8", "ui9_tex_dlc_introduce_vertical_8", new string[1] { "ui9_back_dlc_introduce_screenshoot_12" }, onlyDisplay: false, 10, EImplementedDlcType.Appearance, isFree: true));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<ImplementedDlcItem>(12);
		CreateItems0();
	}
}

using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class AvatarHairColors : ConfigData<AvatarHairColorsItem, byte>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 毛发颜色_43
		/// </summary>
		public const byte White = 42;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 毛发颜色_43
		/// </summary>
		public static AvatarHairColorsItem White => Instance[(byte)42];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static AvatarHairColors Instance = new AvatarHairColors();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "DisplayDesc", "TemplateId", "ColorHex" };

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
		_dataArray.Add(new AvatarHairColorsItem(0, "7e6c6c", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarHairColors_language", "DisplayDesc_0")));
		_dataArray.Add(new AvatarHairColorsItem(1, "786161", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarHairColors_language", "DisplayDesc_1")));
		_dataArray.Add(new AvatarHairColorsItem(2, "665050", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarHairColors_language", "DisplayDesc_2")));
		_dataArray.Add(new AvatarHairColorsItem(3, "4d3a3a", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarHairColors_language", "DisplayDesc_3")));
		_dataArray.Add(new AvatarHairColorsItem(4, "392a2a", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarHairColors_language", "DisplayDesc_4")));
		_dataArray.Add(new AvatarHairColorsItem(5, "351717", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarHairColors_language", "DisplayDesc_5")));
		_dataArray.Add(new AvatarHairColorsItem(6, "7c706e", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarHairColors_language", "DisplayDesc_6")));
		_dataArray.Add(new AvatarHairColorsItem(7, "786361", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarHairColors_language", "DisplayDesc_7")));
		_dataArray.Add(new AvatarHairColorsItem(8, "665450", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarHairColors_language", "DisplayDesc_8")));
		_dataArray.Add(new AvatarHairColorsItem(9, "4d3d3a", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarHairColors_language", "DisplayDesc_9")));
		_dataArray.Add(new AvatarHairColorsItem(10, "392d2a", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarHairColors_language", "DisplayDesc_10")));
		_dataArray.Add(new AvatarHairColorsItem(11, "2d2522", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarHairColors_language", "DisplayDesc_11")));
		_dataArray.Add(new AvatarHairColorsItem(12, "c2aa82", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarHairColors_language", "DisplayDesc_12")));
		_dataArray.Add(new AvatarHairColorsItem(13, "786c61", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarHairColors_language", "DisplayDesc_13")));
		_dataArray.Add(new AvatarHairColorsItem(14, "665950", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarHairColors_language", "DisplayDesc_14")));
		_dataArray.Add(new AvatarHairColorsItem(15, "4d433a", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarHairColors_language", "DisplayDesc_15")));
		_dataArray.Add(new AvatarHairColorsItem(16, "39312a", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarHairColors_language", "DisplayDesc_16")));
		_dataArray.Add(new AvatarHairColorsItem(17, "2d2722", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarHairColors_language", "DisplayDesc_17")));
		_dataArray.Add(new AvatarHairColorsItem(18, "747872", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarHairColors_language", "DisplayDesc_18")));
		_dataArray.Add(new AvatarHairColorsItem(19, "6c7168", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarHairColors_language", "DisplayDesc_19")));
		_dataArray.Add(new AvatarHairColorsItem(20, "5a6056", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarHairColors_language", "DisplayDesc_20")));
		_dataArray.Add(new AvatarHairColorsItem(21, "43483f", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarHairColors_language", "DisplayDesc_21")));
		_dataArray.Add(new AvatarHairColorsItem(22, "31352e", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarHairColors_language", "DisplayDesc_22")));
		_dataArray.Add(new AvatarHairColorsItem(23, "272d22", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarHairColors_language", "DisplayDesc_23")));
		_dataArray.Add(new AvatarHairColorsItem(24, "727678", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarHairColors_language", "DisplayDesc_24")));
		_dataArray.Add(new AvatarHairColorsItem(25, "686e71", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarHairColors_language", "DisplayDesc_25")));
		_dataArray.Add(new AvatarHairColorsItem(26, "565c60", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarHairColors_language", "DisplayDesc_26")));
		_dataArray.Add(new AvatarHairColorsItem(27, "3f4548", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarHairColors_language", "DisplayDesc_27")));
		_dataArray.Add(new AvatarHairColorsItem(28, "2e3335", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarHairColors_language", "DisplayDesc_28")));
		_dataArray.Add(new AvatarHairColorsItem(29, "222a2d", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarHairColors_language", "DisplayDesc_29")));
		_dataArray.Add(new AvatarHairColorsItem(30, "727378", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarHairColors_language", "DisplayDesc_30")));
		_dataArray.Add(new AvatarHairColorsItem(31, "686971", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarHairColors_language", "DisplayDesc_31")));
		_dataArray.Add(new AvatarHairColorsItem(32, "565760", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarHairColors_language", "DisplayDesc_32")));
		_dataArray.Add(new AvatarHairColorsItem(33, "3f4048", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarHairColors_language", "DisplayDesc_33")));
		_dataArray.Add(new AvatarHairColorsItem(34, "2e2f35", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarHairColors_language", "DisplayDesc_34")));
		_dataArray.Add(new AvatarHairColorsItem(35, "22232d", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarHairColors_language", "DisplayDesc_35")));
		_dataArray.Add(new AvatarHairColorsItem(36, "7c6e78", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarHairColors_language", "DisplayDesc_36")));
		_dataArray.Add(new AvatarHairColorsItem(37, "786170", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarHairColors_language", "DisplayDesc_37")));
		_dataArray.Add(new AvatarHairColorsItem(38, "66505d", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarHairColors_language", "DisplayDesc_38")));
		_dataArray.Add(new AvatarHairColorsItem(39, "483f45", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarHairColors_language", "DisplayDesc_39")));
		_dataArray.Add(new AvatarHairColorsItem(40, "352e33", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarHairColors_language", "DisplayDesc_40")));
		_dataArray.Add(new AvatarHairColorsItem(41, "2d222a", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarHairColors_language", "DisplayDesc_41")));
		_dataArray.Add(new AvatarHairColorsItem(42, "cdcdcd", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarHairColors_language", "DisplayDesc_42")));
		_dataArray.Add(new AvatarHairColorsItem(43, "a5a5a5", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarHairColors_language", "DisplayDesc_43")));
		_dataArray.Add(new AvatarHairColorsItem(44, "797979", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarHairColors_language", "DisplayDesc_44")));
		_dataArray.Add(new AvatarHairColorsItem(45, "545454", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarHairColors_language", "DisplayDesc_45")));
		_dataArray.Add(new AvatarHairColorsItem(46, "383838", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarHairColors_language", "DisplayDesc_46")));
		_dataArray.Add(new AvatarHairColorsItem(47, "202020", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarHairColors_language", "DisplayDesc_47")));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<AvatarHairColorsItem>(48);
		CreateItems0();
	}
}

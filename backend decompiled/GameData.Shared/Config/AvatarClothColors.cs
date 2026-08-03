using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class AvatarClothColors : ConfigData<AvatarClothColorsItem, byte>
{
	/// <summary>
	/// 配置表实例
	/// </summary>
	public static AvatarClothColors Instance = new AvatarClothColors();

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
		_dataArray.Add(new AvatarClothColorsItem(0, "a18a90", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarClothColors_language", "DisplayDesc_0")));
		_dataArray.Add(new AvatarClothColorsItem(1, "9d647c", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarClothColors_language", "DisplayDesc_1")));
		_dataArray.Add(new AvatarClothColorsItem(2, "7d3432", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarClothColors_language", "DisplayDesc_2")));
		_dataArray.Add(new AvatarClothColorsItem(3, "6c4442", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarClothColors_language", "DisplayDesc_3")));
		_dataArray.Add(new AvatarClothColorsItem(4, "652d2a", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarClothColors_language", "DisplayDesc_4")));
		_dataArray.Add(new AvatarClothColorsItem(5, "412021", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarClothColors_language", "DisplayDesc_5")));
		_dataArray.Add(new AvatarClothColorsItem(6, "b5a191", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarClothColors_language", "DisplayDesc_6")));
		_dataArray.Add(new AvatarClothColorsItem(7, "996038", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarClothColors_language", "DisplayDesc_7")));
		_dataArray.Add(new AvatarClothColorsItem(8, "7e6b5f", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarClothColors_language", "DisplayDesc_8")));
		_dataArray.Add(new AvatarClothColorsItem(9, "684832", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarClothColors_language", "DisplayDesc_9")));
		_dataArray.Add(new AvatarClothColorsItem(10, "594737", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarClothColors_language", "DisplayDesc_10")));
		_dataArray.Add(new AvatarClothColorsItem(11, "4d2d23", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarClothColors_language", "DisplayDesc_11")));
		_dataArray.Add(new AvatarClothColorsItem(12, "ccbea9", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarClothColors_language", "DisplayDesc_12")));
		_dataArray.Add(new AvatarClothColorsItem(13, "c8b483", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarClothColors_language", "DisplayDesc_13")));
		_dataArray.Add(new AvatarClothColorsItem(14, "c28f55", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarClothColors_language", "DisplayDesc_14")));
		_dataArray.Add(new AvatarClothColorsItem(15, "ac9d82", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarClothColors_language", "DisplayDesc_15")));
		_dataArray.Add(new AvatarClothColorsItem(16, "907941", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarClothColors_language", "DisplayDesc_16")));
		_dataArray.Add(new AvatarClothColorsItem(17, "392b1e", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarClothColors_language", "DisplayDesc_17")));
		_dataArray.Add(new AvatarClothColorsItem(18, "c9c9b4", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarClothColors_language", "DisplayDesc_18")));
		_dataArray.Add(new AvatarClothColorsItem(19, "a5ae96", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarClothColors_language", "DisplayDesc_19")));
		_dataArray.Add(new AvatarClothColorsItem(20, "7b8b86", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarClothColors_language", "DisplayDesc_20")));
		_dataArray.Add(new AvatarClothColorsItem(21, "63917b", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarClothColors_language", "DisplayDesc_21")));
		_dataArray.Add(new AvatarClothColorsItem(22, "567964", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarClothColors_language", "DisplayDesc_22")));
		_dataArray.Add(new AvatarClothColorsItem(23, "2a3436", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarClothColors_language", "DisplayDesc_23")));
		_dataArray.Add(new AvatarClothColorsItem(24, "8aa1a0", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarClothColors_language", "DisplayDesc_24")));
		_dataArray.Add(new AvatarClothColorsItem(25, "6c929a", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarClothColors_language", "DisplayDesc_25")));
		_dataArray.Add(new AvatarClothColorsItem(26, "547a7e", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarClothColors_language", "DisplayDesc_26")));
		_dataArray.Add(new AvatarClothColorsItem(27, "5d7a76", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarClothColors_language", "DisplayDesc_27")));
		_dataArray.Add(new AvatarClothColorsItem(28, "3c4c52", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarClothColors_language", "DisplayDesc_28")));
		_dataArray.Add(new AvatarClothColorsItem(29, "363f3c", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarClothColors_language", "DisplayDesc_29")));
		_dataArray.Add(new AvatarClothColorsItem(30, "7f91a6", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarClothColors_language", "DisplayDesc_30")));
		_dataArray.Add(new AvatarClothColorsItem(31, "6f8caf", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarClothColors_language", "DisplayDesc_31")));
		_dataArray.Add(new AvatarClothColorsItem(32, "587b9b", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarClothColors_language", "DisplayDesc_32")));
		_dataArray.Add(new AvatarClothColorsItem(33, "4e607f", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarClothColors_language", "DisplayDesc_33")));
		_dataArray.Add(new AvatarClothColorsItem(34, "3c3f50", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarClothColors_language", "DisplayDesc_34")));
		_dataArray.Add(new AvatarClothColorsItem(35, "252d37", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarClothColors_language", "DisplayDesc_35")));
		_dataArray.Add(new AvatarClothColorsItem(36, "8c8ca2", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarClothColors_language", "DisplayDesc_36")));
		_dataArray.Add(new AvatarClothColorsItem(37, "645f74", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarClothColors_language", "DisplayDesc_37")));
		_dataArray.Add(new AvatarClothColorsItem(38, "675d85", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarClothColors_language", "DisplayDesc_38")));
		_dataArray.Add(new AvatarClothColorsItem(39, "553f66", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarClothColors_language", "DisplayDesc_39")));
		_dataArray.Add(new AvatarClothColorsItem(40, "5a4555", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarClothColors_language", "DisplayDesc_40")));
		_dataArray.Add(new AvatarClothColorsItem(41, "372c3d", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarClothColors_language", "DisplayDesc_41")));
		_dataArray.Add(new AvatarClothColorsItem(42, "d7d7d7", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarClothColors_language", "DisplayDesc_42")));
		_dataArray.Add(new AvatarClothColorsItem(43, "b4b4b4", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarClothColors_language", "DisplayDesc_43")));
		_dataArray.Add(new AvatarClothColorsItem(44, "939393", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarClothColors_language", "DisplayDesc_44")));
		_dataArray.Add(new AvatarClothColorsItem(45, "6c6c6c", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarClothColors_language", "DisplayDesc_45")));
		_dataArray.Add(new AvatarClothColorsItem(46, "424242", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarClothColors_language", "DisplayDesc_46")));
		_dataArray.Add(new AvatarClothColorsItem(47, "262626", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarClothColors_language", "DisplayDesc_47")));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<AvatarClothColorsItem>(48);
		CreateItems0();
	}
}

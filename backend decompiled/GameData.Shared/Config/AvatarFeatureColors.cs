using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class AvatarFeatureColors : ConfigData<AvatarFeatureColorsItem, byte>
{
	/// <summary>
	/// 配置表实例
	/// </summary>
	public static AvatarFeatureColors Instance = new AvatarFeatureColors();

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
		_dataArray.Add(new AvatarFeatureColorsItem(0, "9d4953", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarFeatureColors_language", "DisplayDesc_0")));
		_dataArray.Add(new AvatarFeatureColorsItem(1, "b63443", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarFeatureColors_language", "DisplayDesc_1")));
		_dataArray.Add(new AvatarFeatureColorsItem(2, "9d212f", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarFeatureColors_language", "DisplayDesc_2")));
		_dataArray.Add(new AvatarFeatureColorsItem(3, "7c1521", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarFeatureColors_language", "DisplayDesc_3")));
		_dataArray.Add(new AvatarFeatureColorsItem(4, "9b1212", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarFeatureColors_language", "DisplayDesc_4")));
		_dataArray.Add(new AvatarFeatureColorsItem(5, "740017", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarFeatureColors_language", "DisplayDesc_5")));
		_dataArray.Add(new AvatarFeatureColorsItem(6, "975e4e", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarFeatureColors_language", "DisplayDesc_6")));
		_dataArray.Add(new AvatarFeatureColorsItem(7, "ad553c", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarFeatureColors_language", "DisplayDesc_7")));
		_dataArray.Add(new AvatarFeatureColorsItem(8, "954129", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarFeatureColors_language", "DisplayDesc_8")));
		_dataArray.Add(new AvatarFeatureColorsItem(9, "752f1b", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarFeatureColors_language", "DisplayDesc_9")));
		_dataArray.Add(new AvatarFeatureColorsItem(10, "92421b", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarFeatureColors_language", "DisplayDesc_10")));
		_dataArray.Add(new AvatarFeatureColorsItem(11, "6c1407", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarFeatureColors_language", "DisplayDesc_11")));
		_dataArray.Add(new AvatarFeatureColorsItem(12, "97714e", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarFeatureColors_language", "DisplayDesc_12")));
		_dataArray.Add(new AvatarFeatureColorsItem(13, "ad733c", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarFeatureColors_language", "DisplayDesc_13")));
		_dataArray.Add(new AvatarFeatureColorsItem(14, "955e29", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarFeatureColors_language", "DisplayDesc_14")));
		_dataArray.Add(new AvatarFeatureColorsItem(15, "75471b", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarFeatureColors_language", "DisplayDesc_15")));
		_dataArray.Add(new AvatarFeatureColorsItem(16, "92621b", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarFeatureColors_language", "DisplayDesc_16")));
		_dataArray.Add(new AvatarFeatureColorsItem(17, "6c2f07", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarFeatureColors_language", "DisplayDesc_17")));
		_dataArray.Add(new AvatarFeatureColorsItem(18, "cdddac", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarFeatureColors_language", "DisplayDesc_18")));
		_dataArray.Add(new AvatarFeatureColorsItem(19, "abb498", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarFeatureColors_language", "DisplayDesc_19")));
		_dataArray.Add(new AvatarFeatureColorsItem(20, "868e77", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarFeatureColors_language", "DisplayDesc_20")));
		_dataArray.Add(new AvatarFeatureColorsItem(21, "6a715d", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarFeatureColors_language", "DisplayDesc_21")));
		_dataArray.Add(new AvatarFeatureColorsItem(22, "4f7125", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarFeatureColors_language", "DisplayDesc_22")));
		_dataArray.Add(new AvatarFeatureColorsItem(23, "394421", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarFeatureColors_language", "DisplayDesc_23")));
		_dataArray.Add(new AvatarFeatureColorsItem(24, "497973", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarFeatureColors_language", "DisplayDesc_24")));
		_dataArray.Add(new AvatarFeatureColorsItem(25, "3d8880", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarFeatureColors_language", "DisplayDesc_25")));
		_dataArray.Add(new AvatarFeatureColorsItem(26, "2c746c", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarFeatureColors_language", "DisplayDesc_26")));
		_dataArray.Add(new AvatarFeatureColorsItem(27, "1f5b54", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarFeatureColors_language", "DisplayDesc_27")));
		_dataArray.Add(new AvatarFeatureColorsItem(28, "217171", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarFeatureColors_language", "DisplayDesc_28")));
		_dataArray.Add(new AvatarFeatureColorsItem(29, "0f5346", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarFeatureColors_language", "DisplayDesc_29")));
		_dataArray.Add(new AvatarFeatureColorsItem(30, "4e5e76", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarFeatureColors_language", "DisplayDesc_30")));
		_dataArray.Add(new AvatarFeatureColorsItem(31, "465e86", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarFeatureColors_language", "DisplayDesc_31")));
		_dataArray.Add(new AvatarFeatureColorsItem(32, "344c72", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarFeatureColors_language", "DisplayDesc_32")));
		_dataArray.Add(new AvatarFeatureColorsItem(33, "263a5a", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarFeatureColors_language", "DisplayDesc_33")));
		_dataArray.Add(new AvatarFeatureColorsItem(34, "40419d", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarFeatureColors_language", "DisplayDesc_34")));
		_dataArray.Add(new AvatarFeatureColorsItem(35, "2f3071", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarFeatureColors_language", "DisplayDesc_35")));
		_dataArray.Add(new AvatarFeatureColorsItem(36, "9d4971", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarFeatureColors_language", "DisplayDesc_36")));
		_dataArray.Add(new AvatarFeatureColorsItem(37, "b63472", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarFeatureColors_language", "DisplayDesc_37")));
		_dataArray.Add(new AvatarFeatureColorsItem(38, "9d215c", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarFeatureColors_language", "DisplayDesc_38")));
		_dataArray.Add(new AvatarFeatureColorsItem(39, "7c1546", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarFeatureColors_language", "DisplayDesc_39")));
		_dataArray.Add(new AvatarFeatureColorsItem(40, "9b1244", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarFeatureColors_language", "DisplayDesc_40")));
		_dataArray.Add(new AvatarFeatureColorsItem(41, "740041", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarFeatureColors_language", "DisplayDesc_41")));
		_dataArray.Add(new AvatarFeatureColorsItem(42, "ffffff", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarFeatureColors_language", "DisplayDesc_42")));
		_dataArray.Add(new AvatarFeatureColorsItem(43, "999999", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarFeatureColors_language", "DisplayDesc_43")));
		_dataArray.Add(new AvatarFeatureColorsItem(44, "777777", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarFeatureColors_language", "DisplayDesc_44")));
		_dataArray.Add(new AvatarFeatureColorsItem(45, "4b4b4b", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarFeatureColors_language", "DisplayDesc_45")));
		_dataArray.Add(new AvatarFeatureColorsItem(46, "2b2b2b", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarFeatureColors_language", "DisplayDesc_46")));
		_dataArray.Add(new AvatarFeatureColorsItem(47, "000000", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarFeatureColors_language", "DisplayDesc_47")));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<AvatarFeatureColorsItem>(48);
		CreateItems0();
	}
}

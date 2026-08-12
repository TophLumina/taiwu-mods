using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class AvatarEyeballColors : ConfigData<AvatarEyeballColorsItem, byte>
{
	/// <summary>
	/// 配置表实例
	/// </summary>
	public static AvatarEyeballColors Instance = new AvatarEyeballColors();

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
		_dataArray.Add(new AvatarEyeballColorsItem(0, "726666", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarEyeballColors_language", "DisplayDesc_0")));
		_dataArray.Add(new AvatarEyeballColorsItem(1, "6f5050", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarEyeballColors_language", "DisplayDesc_1")));
		_dataArray.Add(new AvatarEyeballColorsItem(2, "512020", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarEyeballColors_language", "DisplayDesc_2")));
		_dataArray.Add(new AvatarEyeballColorsItem(3, "3d1212", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarEyeballColors_language", "DisplayDesc_3")));
		_dataArray.Add(new AvatarEyeballColorsItem(4, "220b0b", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarEyeballColors_language", "DisplayDesc_4")));
		_dataArray.Add(new AvatarEyeballColorsItem(5, "c66565", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarEyeballColors_language", "DisplayDesc_5")));
		_dataArray.Add(new AvatarEyeballColorsItem(6, "726966", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarEyeballColors_language", "DisplayDesc_6")));
		_dataArray.Add(new AvatarEyeballColorsItem(7, "6f5950", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarEyeballColors_language", "DisplayDesc_7")));
		_dataArray.Add(new AvatarEyeballColorsItem(8, "512e20", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarEyeballColors_language", "DisplayDesc_8")));
		_dataArray.Add(new AvatarEyeballColorsItem(9, "3d1e12", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarEyeballColors_language", "DisplayDesc_9")));
		_dataArray.Add(new AvatarEyeballColorsItem(10, "22110b", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarEyeballColors_language", "DisplayDesc_10")));
		_dataArray.Add(new AvatarEyeballColorsItem(11, "c68165", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarEyeballColors_language", "DisplayDesc_11")));
		_dataArray.Add(new AvatarEyeballColorsItem(12, "726e66", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarEyeballColors_language", "DisplayDesc_12")));
		_dataArray.Add(new AvatarEyeballColorsItem(13, "6f6450", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarEyeballColors_language", "DisplayDesc_13")));
		_dataArray.Add(new AvatarEyeballColorsItem(14, "514020", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarEyeballColors_language", "DisplayDesc_14")));
		_dataArray.Add(new AvatarEyeballColorsItem(15, "3d2e12", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarEyeballColors_language", "DisplayDesc_15")));
		_dataArray.Add(new AvatarEyeballColorsItem(16, "221a0b", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarEyeballColors_language", "DisplayDesc_16")));
		_dataArray.Add(new AvatarEyeballColorsItem(17, "c6a465", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarEyeballColors_language", "DisplayDesc_17")));
		_dataArray.Add(new AvatarEyeballColorsItem(18, "6a7266", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarEyeballColors_language", "DisplayDesc_18")));
		_dataArray.Add(new AvatarEyeballColorsItem(19, "5a6f50", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarEyeballColors_language", "DisplayDesc_19")));
		_dataArray.Add(new AvatarEyeballColorsItem(20, "2f5120", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarEyeballColors_language", "DisplayDesc_20")));
		_dataArray.Add(new AvatarEyeballColorsItem(21, "203d12", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarEyeballColors_language", "DisplayDesc_21")));
		_dataArray.Add(new AvatarEyeballColorsItem(22, "12220b", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarEyeballColors_language", "DisplayDesc_22")));
		_dataArray.Add(new AvatarEyeballColorsItem(23, "84c665", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarEyeballColors_language", "DisplayDesc_23")));
		_dataArray.Add(new AvatarEyeballColorsItem(24, "667072", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarEyeballColors_language", "DisplayDesc_24")));
		_dataArray.Add(new AvatarEyeballColorsItem(25, "506a6f", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarEyeballColors_language", "DisplayDesc_25")));
		_dataArray.Add(new AvatarEyeballColorsItem(26, "204851", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarEyeballColors_language", "DisplayDesc_26")));
		_dataArray.Add(new AvatarEyeballColorsItem(27, "12363d", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarEyeballColors_language", "DisplayDesc_27")));
		_dataArray.Add(new AvatarEyeballColorsItem(28, "0b1e22", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarEyeballColors_language", "DisplayDesc_28")));
		_dataArray.Add(new AvatarEyeballColorsItem(29, "65b5c6", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarEyeballColors_language", "DisplayDesc_29")));
		_dataArray.Add(new AvatarEyeballColorsItem(30, "666872", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarEyeballColors_language", "DisplayDesc_30")));
		_dataArray.Add(new AvatarEyeballColorsItem(31, "50576f", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarEyeballColors_language", "DisplayDesc_31")));
		_dataArray.Add(new AvatarEyeballColorsItem(32, "202a51", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarEyeballColors_language", "DisplayDesc_32")));
		_dataArray.Add(new AvatarEyeballColorsItem(33, "121b3d", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarEyeballColors_language", "DisplayDesc_33")));
		_dataArray.Add(new AvatarEyeballColorsItem(34, "0b1022", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarEyeballColors_language", "DisplayDesc_34")));
		_dataArray.Add(new AvatarEyeballColorsItem(35, "657ac6", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarEyeballColors_language", "DisplayDesc_35")));
		_dataArray.Add(new AvatarEyeballColorsItem(36, "716672", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarEyeballColors_language", "DisplayDesc_36")));
		_dataArray.Add(new AvatarEyeballColorsItem(37, "6e506f", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarEyeballColors_language", "DisplayDesc_37")));
		_dataArray.Add(new AvatarEyeballColorsItem(38, "4f2051", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarEyeballColors_language", "DisplayDesc_38")));
		_dataArray.Add(new AvatarEyeballColorsItem(39, "3b123d", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarEyeballColors_language", "DisplayDesc_39")));
		_dataArray.Add(new AvatarEyeballColorsItem(40, "220b22", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarEyeballColors_language", "DisplayDesc_40")));
		_dataArray.Add(new AvatarEyeballColorsItem(41, "c165c6", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarEyeballColors_language", "DisplayDesc_41")));
		_dataArray.Add(new AvatarEyeballColorsItem(42, "676767", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarEyeballColors_language", "DisplayDesc_42")));
		_dataArray.Add(new AvatarEyeballColorsItem(43, "535353", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarEyeballColors_language", "DisplayDesc_43")));
		_dataArray.Add(new AvatarEyeballColorsItem(44, "2a2a2a", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarEyeballColors_language", "DisplayDesc_44")));
		_dataArray.Add(new AvatarEyeballColorsItem(45, "1c1c1c", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarEyeballColors_language", "DisplayDesc_45")));
		_dataArray.Add(new AvatarEyeballColorsItem(46, "101010", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarEyeballColors_language", "DisplayDesc_46")));
		_dataArray.Add(new AvatarEyeballColorsItem(47, "797979", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarEyeballColors_language", "DisplayDesc_47")));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<AvatarEyeballColorsItem>(48);
		CreateItems0();
	}
}

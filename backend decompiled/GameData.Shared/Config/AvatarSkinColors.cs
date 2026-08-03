using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class AvatarSkinColors : ConfigData<AvatarSkinColorsItem, byte>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 皮肤颜色_1
		/// </summary>
		public const byte MostWhite = 0;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 皮肤颜色_1
		/// </summary>
		public static AvatarSkinColorsItem MostWhite => Instance[(byte)0];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static AvatarSkinColors Instance = new AvatarSkinColors();

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
		_dataArray.Add(new AvatarSkinColorsItem(0, "edd6d5", 8, 8, 8, 8, LocalStringManager.GetConfig("AvatarSkinColors_language", "DisplayDesc_0")));
		_dataArray.Add(new AvatarSkinColorsItem(1, "e7caca", 16, 16, 16, 16, LocalStringManager.GetConfig("AvatarSkinColors_language", "DisplayDesc_1")));
		_dataArray.Add(new AvatarSkinColorsItem(2, "e2c3c2", 8, 8, 8, 8, LocalStringManager.GetConfig("AvatarSkinColors_language", "DisplayDesc_2")));
		_dataArray.Add(new AvatarSkinColorsItem(3, "d7b4b4", 4, 4, 4, 4, LocalStringManager.GetConfig("AvatarSkinColors_language", "DisplayDesc_3")));
		_dataArray.Add(new AvatarSkinColorsItem(4, "d1aeae", 2, 2, 2, 2, LocalStringManager.GetConfig("AvatarSkinColors_language", "DisplayDesc_4")));
		_dataArray.Add(new AvatarSkinColorsItem(5, "c5a09c", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarSkinColors_language", "DisplayDesc_5")));
		_dataArray.Add(new AvatarSkinColorsItem(6, "f7d8d2", 16, 16, 16, 16, LocalStringManager.GetConfig("AvatarSkinColors_language", "DisplayDesc_6")));
		_dataArray.Add(new AvatarSkinColorsItem(7, "f0c8c0", 32, 32, 32, 32, LocalStringManager.GetConfig("AvatarSkinColors_language", "DisplayDesc_7")));
		_dataArray.Add(new AvatarSkinColorsItem(8, "ebc1b9", 16, 16, 16, 16, LocalStringManager.GetConfig("AvatarSkinColors_language", "DisplayDesc_8")));
		_dataArray.Add(new AvatarSkinColorsItem(9, "deb3ab", 8, 8, 8, 8, LocalStringManager.GetConfig("AvatarSkinColors_language", "DisplayDesc_9")));
		_dataArray.Add(new AvatarSkinColorsItem(10, "cfa69e", 4, 4, 4, 4, LocalStringManager.GetConfig("AvatarSkinColors_language", "DisplayDesc_10")));
		_dataArray.Add(new AvatarSkinColorsItem(11, "c69e98", 2, 2, 2, 2, LocalStringManager.GetConfig("AvatarSkinColors_language", "DisplayDesc_11")));
		_dataArray.Add(new AvatarSkinColorsItem(12, "f5ded4", 32, 32, 32, 32, LocalStringManager.GetConfig("AvatarSkinColors_language", "DisplayDesc_12")));
		_dataArray.Add(new AvatarSkinColorsItem(13, "eacfc3", 64, 64, 64, 64, LocalStringManager.GetConfig("AvatarSkinColors_language", "DisplayDesc_13")));
		_dataArray.Add(new AvatarSkinColorsItem(14, "e6c3b3", 32, 32, 32, 32, LocalStringManager.GetConfig("AvatarSkinColors_language", "DisplayDesc_14")));
		_dataArray.Add(new AvatarSkinColorsItem(15, "dab4a3", 16, 16, 16, 16, LocalStringManager.GetConfig("AvatarSkinColors_language", "DisplayDesc_15")));
		_dataArray.Add(new AvatarSkinColorsItem(16, "cfa898", 8, 8, 8, 8, LocalStringManager.GetConfig("AvatarSkinColors_language", "DisplayDesc_16")));
		_dataArray.Add(new AvatarSkinColorsItem(17, "c39a88", 4, 4, 4, 4, LocalStringManager.GetConfig("AvatarSkinColors_language", "DisplayDesc_17")));
		_dataArray.Add(new AvatarSkinColorsItem(18, "f7d5c6", 64, 64, 64, 64, LocalStringManager.GetConfig("AvatarSkinColors_language", "DisplayDesc_18")));
		_dataArray.Add(new AvatarSkinColorsItem(19, "f0ccbc", 128, 128, 128, 128, LocalStringManager.GetConfig("AvatarSkinColors_language", "DisplayDesc_19")));
		_dataArray.Add(new AvatarSkinColorsItem(20, "ebc0ad", 64, 64, 64, 64, LocalStringManager.GetConfig("AvatarSkinColors_language", "DisplayDesc_20")));
		_dataArray.Add(new AvatarSkinColorsItem(21, "d9b09e", 32, 32, 32, 32, LocalStringManager.GetConfig("AvatarSkinColors_language", "DisplayDesc_21")));
		_dataArray.Add(new AvatarSkinColorsItem(22, "caa693", 16, 16, 16, 16, LocalStringManager.GetConfig("AvatarSkinColors_language", "DisplayDesc_22")));
		_dataArray.Add(new AvatarSkinColorsItem(23, "c49e8a", 8, 8, 8, 8, LocalStringManager.GetConfig("AvatarSkinColors_language", "DisplayDesc_23")));
		_dataArray.Add(new AvatarSkinColorsItem(24, "f0d5c6", 32, 32, 32, 32, LocalStringManager.GetConfig("AvatarSkinColors_language", "DisplayDesc_24")));
		_dataArray.Add(new AvatarSkinColorsItem(25, "ecd1bf", 64, 64, 64, 64, LocalStringManager.GetConfig("AvatarSkinColors_language", "DisplayDesc_25")));
		_dataArray.Add(new AvatarSkinColorsItem(26, "e8cbb9", 32, 32, 32, 32, LocalStringManager.GetConfig("AvatarSkinColors_language", "DisplayDesc_26")));
		_dataArray.Add(new AvatarSkinColorsItem(27, "e2c3b0", 16, 16, 16, 16, LocalStringManager.GetConfig("AvatarSkinColors_language", "DisplayDesc_27")));
		_dataArray.Add(new AvatarSkinColorsItem(28, "debda9", 8, 8, 8, 8, LocalStringManager.GetConfig("AvatarSkinColors_language", "DisplayDesc_28")));
		_dataArray.Add(new AvatarSkinColorsItem(29, "d4b19b", 4, 4, 4, 4, LocalStringManager.GetConfig("AvatarSkinColors_language", "DisplayDesc_29")));
		_dataArray.Add(new AvatarSkinColorsItem(30, "f0d7c6", 16, 16, 16, 16, LocalStringManager.GetConfig("AvatarSkinColors_language", "DisplayDesc_30")));
		_dataArray.Add(new AvatarSkinColorsItem(31, "eecfba", 32, 32, 32, 32, LocalStringManager.GetConfig("AvatarSkinColors_language", "DisplayDesc_31")));
		_dataArray.Add(new AvatarSkinColorsItem(32, "e9c5ab", 16, 16, 16, 16, LocalStringManager.GetConfig("AvatarSkinColors_language", "DisplayDesc_32")));
		_dataArray.Add(new AvatarSkinColorsItem(33, "e5c1a7", 8, 8, 8, 8, LocalStringManager.GetConfig("AvatarSkinColors_language", "DisplayDesc_33")));
		_dataArray.Add(new AvatarSkinColorsItem(34, "dcb69b", 4, 4, 4, 4, LocalStringManager.GetConfig("AvatarSkinColors_language", "DisplayDesc_34")));
		_dataArray.Add(new AvatarSkinColorsItem(35, "d5af94", 2, 2, 2, 2, LocalStringManager.GetConfig("AvatarSkinColors_language", "DisplayDesc_35")));
		_dataArray.Add(new AvatarSkinColorsItem(36, "f0d9c6", 8, 8, 8, 8, LocalStringManager.GetConfig("AvatarSkinColors_language", "DisplayDesc_36")));
		_dataArray.Add(new AvatarSkinColorsItem(37, "ebd4bf", 16, 16, 16, 16, LocalStringManager.GetConfig("AvatarSkinColors_language", "DisplayDesc_37")));
		_dataArray.Add(new AvatarSkinColorsItem(38, "e6cbb3", 8, 8, 8, 8, LocalStringManager.GetConfig("AvatarSkinColors_language", "DisplayDesc_38")));
		_dataArray.Add(new AvatarSkinColorsItem(39, "e2c4ab", 4, 4, 4, 4, LocalStringManager.GetConfig("AvatarSkinColors_language", "DisplayDesc_39")));
		_dataArray.Add(new AvatarSkinColorsItem(40, "e0c1a5", 2, 2, 2, 2, LocalStringManager.GetConfig("AvatarSkinColors_language", "DisplayDesc_40")));
		_dataArray.Add(new AvatarSkinColorsItem(41, "d8b799", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarSkinColors_language", "DisplayDesc_41")));
		_dataArray.Add(new AvatarSkinColorsItem(42, "ede1d4", 8, 8, 8, 8, LocalStringManager.GetConfig("AvatarSkinColors_language", "DisplayDesc_42")));
		_dataArray.Add(new AvatarSkinColorsItem(43, "e8d9c8", 16, 16, 16, 16, LocalStringManager.GetConfig("AvatarSkinColors_language", "DisplayDesc_43")));
		_dataArray.Add(new AvatarSkinColorsItem(44, "e3d2bc", 8, 8, 8, 8, LocalStringManager.GetConfig("AvatarSkinColors_language", "DisplayDesc_44")));
		_dataArray.Add(new AvatarSkinColorsItem(45, "d8c3ab", 4, 4, 4, 4, LocalStringManager.GetConfig("AvatarSkinColors_language", "DisplayDesc_45")));
		_dataArray.Add(new AvatarSkinColorsItem(46, "ccb79b", 2, 2, 2, 2, LocalStringManager.GetConfig("AvatarSkinColors_language", "DisplayDesc_46")));
		_dataArray.Add(new AvatarSkinColorsItem(47, "c2a98d", 1, 1, 1, 1, LocalStringManager.GetConfig("AvatarSkinColors_language", "DisplayDesc_47")));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<AvatarSkinColorsItem>(48);
		CreateItems0();
	}
}

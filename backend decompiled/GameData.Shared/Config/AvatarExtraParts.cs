using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class AvatarExtraParts : ConfigData<AvatarExtraPartsItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 1号体型_面纱_1
		/// </summary>
		public const short Avatar_1_Veil_1 = 0;

		/// <summary>
		/// 2号体型_面纱_1
		/// </summary>
		public const short Avatar_2_Veil_1 = 1;

		/// <summary>
		/// 3号体型_面纱_1
		/// </summary>
		public const short Avatar_3_Veil_1 = 2;

		/// <summary>
		/// 4号体型_面纱_1
		/// </summary>
		public const short Avatar_4_Veil_1 = 3;

		/// <summary>
		/// 5号体型_面纱_1
		/// </summary>
		public const short Avatar_5_Veil_1 = 4;

		/// <summary>
		/// 6号体型_面纱_1
		/// </summary>
		public const short Avatar_6_Veil_1 = 5;

		/// <summary>
		/// 1号体型_面具_1
		/// </summary>
		public const short AvatarMask_0 = 6;

		/// <summary>
		/// 6号体型_面具_3
		/// </summary>
		public const short AvatarMask_Count = 23;

		/// <summary>
		/// 1号体型_羞红_1
		/// </summary>
		public const short Avatar_1_Blush_1 = 24;

		/// <summary>
		/// 2号体型_羞红_1
		/// </summary>
		public const short Avatar_2_Blush_1 = 25;

		/// <summary>
		/// 3号体型_羞红_1
		/// </summary>
		public const short Avatar_3_Blush_1 = 26;

		/// <summary>
		/// 4号体型_羞红_1
		/// </summary>
		public const short Avatar_4_Blush_1 = 27;

		/// <summary>
		/// 5号体型_羞红_1
		/// </summary>
		public const short Avatar_5_Blush_1 = 28;

		/// <summary>
		/// 6号体型_羞红_1
		/// </summary>
		public const short Avatar_6_Blush_1 = 29;

		/// <summary>
		/// 1号体型_鸭头_1
		/// </summary>
		public const short avatar_1_clothpart_31_1 = 30;

		/// <summary>
		/// 2号体型_鸭头_1
		/// </summary>
		public const short avatar_2_clothpart_31_1 = 31;

		/// <summary>
		/// 3号体型_鸭头_1
		/// </summary>
		public const short avatar_3_clothpart_31_1 = 32;

		/// <summary>
		/// 4号体型_鸭头_1
		/// </summary>
		public const short avatar_4_clothpart_31_1 = 33;

		/// <summary>
		/// 5号体型_鸭头_1
		/// </summary>
		public const short avatar_5_clothpart_31_1 = 34;

		/// <summary>
		/// 6号体型_鸭头_1
		/// </summary>
		public const short avatar_6_clothpart_31_1 = 35;

		/// <summary>
		/// 1号体型_界青面具_1
		/// </summary>
		public const short Avatar_1_JieqingMask_1 = 36;

		/// <summary>
		/// 2号体型_界青面具_1
		/// </summary>
		public const short Avatar_2_JieqingMask_1 = 37;

		/// <summary>
		/// 3号体型_界青面具_1
		/// </summary>
		public const short Avatar_3_JieqingMask_1 = 38;

		/// <summary>
		/// 4号体型_界青面具_1
		/// </summary>
		public const short Avatar_4_JieqingMask_1 = 39;

		/// <summary>
		/// 5号体型_界青面具_1
		/// </summary>
		public const short Avatar_5_JieqingMask_1 = 40;

		/// <summary>
		/// 6号体型_界青面具_1
		/// </summary>
		public const short Avatar_6_JieqingMask_1 = 41;

		/// <summary>
		/// 251号体型_界青面具_1
		/// </summary>
		public const short Avatar_251_JieqingMask_1 = 42;

		/// <summary>
		/// 252号体型_界青面具_1
		/// </summary>
		public const short Avatar_252_JieqingMask_1 = 43;

		/// <summary>
		/// 253号体型_界青面具_1
		/// </summary>
		public const short Avatar_253_JieqingMask_1 = 44;

		/// <summary>
		/// 254号体型_界青面具_1
		/// </summary>
		public const short Avatar_254_JieqingMask_1 = 45;

		/// <summary>
		/// 1号体型_玄灰标记_1
		/// </summary>
		public const short Avatar_1_DashAsh_1 = 46;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 1号体型_面纱_1
		/// </summary>
		public static AvatarExtraPartsItem Avatar_1_Veil_1 => Instance[(short)0];

		/// <summary>
		/// 2号体型_面纱_1
		/// </summary>
		public static AvatarExtraPartsItem Avatar_2_Veil_1 => Instance[(short)1];

		/// <summary>
		/// 3号体型_面纱_1
		/// </summary>
		public static AvatarExtraPartsItem Avatar_3_Veil_1 => Instance[(short)2];

		/// <summary>
		/// 4号体型_面纱_1
		/// </summary>
		public static AvatarExtraPartsItem Avatar_4_Veil_1 => Instance[(short)3];

		/// <summary>
		/// 5号体型_面纱_1
		/// </summary>
		public static AvatarExtraPartsItem Avatar_5_Veil_1 => Instance[(short)4];

		/// <summary>
		/// 6号体型_面纱_1
		/// </summary>
		public static AvatarExtraPartsItem Avatar_6_Veil_1 => Instance[(short)5];

		/// <summary>
		/// 1号体型_面具_1
		/// </summary>
		public static AvatarExtraPartsItem AvatarMask_0 => Instance[(short)6];

		/// <summary>
		/// 6号体型_面具_3
		/// </summary>
		public static AvatarExtraPartsItem AvatarMask_Count => Instance[(short)23];

		/// <summary>
		/// 1号体型_羞红_1
		/// </summary>
		public static AvatarExtraPartsItem Avatar_1_Blush_1 => Instance[(short)24];

		/// <summary>
		/// 2号体型_羞红_1
		/// </summary>
		public static AvatarExtraPartsItem Avatar_2_Blush_1 => Instance[(short)25];

		/// <summary>
		/// 3号体型_羞红_1
		/// </summary>
		public static AvatarExtraPartsItem Avatar_3_Blush_1 => Instance[(short)26];

		/// <summary>
		/// 4号体型_羞红_1
		/// </summary>
		public static AvatarExtraPartsItem Avatar_4_Blush_1 => Instance[(short)27];

		/// <summary>
		/// 5号体型_羞红_1
		/// </summary>
		public static AvatarExtraPartsItem Avatar_5_Blush_1 => Instance[(short)28];

		/// <summary>
		/// 6号体型_羞红_1
		/// </summary>
		public static AvatarExtraPartsItem Avatar_6_Blush_1 => Instance[(short)29];

		/// <summary>
		/// 1号体型_鸭头_1
		/// </summary>
		public static AvatarExtraPartsItem avatar_1_clothpart_31_1 => Instance[(short)30];

		/// <summary>
		/// 2号体型_鸭头_1
		/// </summary>
		public static AvatarExtraPartsItem avatar_2_clothpart_31_1 => Instance[(short)31];

		/// <summary>
		/// 3号体型_鸭头_1
		/// </summary>
		public static AvatarExtraPartsItem avatar_3_clothpart_31_1 => Instance[(short)32];

		/// <summary>
		/// 4号体型_鸭头_1
		/// </summary>
		public static AvatarExtraPartsItem avatar_4_clothpart_31_1 => Instance[(short)33];

		/// <summary>
		/// 5号体型_鸭头_1
		/// </summary>
		public static AvatarExtraPartsItem avatar_5_clothpart_31_1 => Instance[(short)34];

		/// <summary>
		/// 6号体型_鸭头_1
		/// </summary>
		public static AvatarExtraPartsItem avatar_6_clothpart_31_1 => Instance[(short)35];

		/// <summary>
		/// 1号体型_界青面具_1
		/// </summary>
		public static AvatarExtraPartsItem Avatar_1_JieqingMask_1 => Instance[(short)36];

		/// <summary>
		/// 2号体型_界青面具_1
		/// </summary>
		public static AvatarExtraPartsItem Avatar_2_JieqingMask_1 => Instance[(short)37];

		/// <summary>
		/// 3号体型_界青面具_1
		/// </summary>
		public static AvatarExtraPartsItem Avatar_3_JieqingMask_1 => Instance[(short)38];

		/// <summary>
		/// 4号体型_界青面具_1
		/// </summary>
		public static AvatarExtraPartsItem Avatar_4_JieqingMask_1 => Instance[(short)39];

		/// <summary>
		/// 5号体型_界青面具_1
		/// </summary>
		public static AvatarExtraPartsItem Avatar_5_JieqingMask_1 => Instance[(short)40];

		/// <summary>
		/// 6号体型_界青面具_1
		/// </summary>
		public static AvatarExtraPartsItem Avatar_6_JieqingMask_1 => Instance[(short)41];

		/// <summary>
		/// 251号体型_界青面具_1
		/// </summary>
		public static AvatarExtraPartsItem Avatar_251_JieqingMask_1 => Instance[(short)42];

		/// <summary>
		/// 252号体型_界青面具_1
		/// </summary>
		public static AvatarExtraPartsItem Avatar_252_JieqingMask_1 => Instance[(short)43];

		/// <summary>
		/// 253号体型_界青面具_1
		/// </summary>
		public static AvatarExtraPartsItem Avatar_253_JieqingMask_1 => Instance[(short)44];

		/// <summary>
		/// 254号体型_界青面具_1
		/// </summary>
		public static AvatarExtraPartsItem Avatar_254_JieqingMask_1 => Instance[(short)45];

		/// <summary>
		/// 1号体型_玄灰标记_1
		/// </summary>
		public static AvatarExtraPartsItem Avatar_1_DashAsh_1 => Instance[(short)46];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static AvatarExtraParts Instance = new AvatarExtraParts();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "TemplateId", "AvatarId", "Type", "Name", "PositionFollow", "LayerFollow", "LayerOffset", "ColorFollow", "ScaleFollow", "DynamicDuckHead" };

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
		_dataArray.Add(new AvatarExtraPartsItem(0, 1, EAvatarExtraPartsType.Veil, "avatar_1_veil_1", "Head", new float[2] { 5f, -61f }, "FrontHair", 1, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(1, 2, EAvatarExtraPartsType.Veil, "avatar_2_veil_1", "Head", new float[2] { 4f, -60f }, "FrontHair", 1, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(2, 3, EAvatarExtraPartsType.Veil, "avatar_3_veil_1", "Head", new float[2] { 5f, -60f }, "FrontHair", 1, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(3, 4, EAvatarExtraPartsType.Veil, "avatar_4_veil_1", "Head", new float[2] { 3f, -64f }, "FrontHair", 1, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(4, 5, EAvatarExtraPartsType.Veil, "avatar_5_veil_1", "Head", new float[2] { 5f, -61f }, "FrontHair", 1, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(5, 6, EAvatarExtraPartsType.Veil, "avatar_6_veil_1", "Head", new float[2] { 3f, -63f }, "FrontHair", 1, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(6, 1, EAvatarExtraPartsType.Mask, "avatar_1_mask_1", "EyesArea", new float[2] { 0f, -3f }, "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(7, 1, EAvatarExtraPartsType.Mask, "avatar_1_mask_2", "EyesArea", new float[2] { 0f, -2f }, "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(8, 1, EAvatarExtraPartsType.Mask, "avatar_1_mask_3", "EyesArea", new float[2] { 0f, -12f }, "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(9, 2, EAvatarExtraPartsType.Mask, "avatar_2_mask_1", "EyesArea", new float[2] { 0f, -1f }, "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(10, 2, EAvatarExtraPartsType.Mask, "avatar_2_mask_2", "EyesArea", new float[2] { 0f, -1f }, "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(11, 2, EAvatarExtraPartsType.Mask, "avatar_2_mask_3", "EyesArea", new float[2] { 0f, -8f }, "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(12, 3, EAvatarExtraPartsType.Mask, "avatar_3_mask_1", "EyesArea", new float[2] { 0f, -2f }, "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(13, 3, EAvatarExtraPartsType.Mask, "avatar_3_mask_2", "EyesArea", new float[2] { 0f, -2f }, "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(14, 3, EAvatarExtraPartsType.Mask, "avatar_3_mask_3", "EyesArea", new float[2] { 0f, -12f }, "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(15, 4, EAvatarExtraPartsType.Mask, "avatar_4_mask_1", "EyesArea", new float[2] { 0f, -2f }, "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(16, 4, EAvatarExtraPartsType.Mask, "avatar_4_mask_2", "EyesArea", new float[2] { 0f, -2f }, "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(17, 4, EAvatarExtraPartsType.Mask, "avatar_4_mask_3", "EyesArea", new float[2] { 0f, -12f }, "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(18, 5, EAvatarExtraPartsType.Mask, "avatar_5_mask_1", "EyesArea", new float[2] { 0f, -2f }, "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(19, 5, EAvatarExtraPartsType.Mask, "avatar_5_mask_2", "EyesArea", new float[2] { 0f, -1f }, "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(20, 5, EAvatarExtraPartsType.Mask, "avatar_5_mask_3", "EyesArea", new float[2] { 0f, -14f }, "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(21, 6, EAvatarExtraPartsType.Mask, "avatar_6_mask_1", "EyesArea", new float[2] { 0f, -2f }, "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(22, 6, EAvatarExtraPartsType.Mask, "avatar_6_mask_2", "EyesArea", new float[2] { 0f, -1f }, "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(23, 6, EAvatarExtraPartsType.Mask, "avatar_6_mask_3", "EyesArea", new float[2] { 0f, -11f }, "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(24, 1, EAvatarExtraPartsType.Blush, "avatar_1_blush_1", "Head", new float[2] { 12f, 12f }, "Beard_2", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(25, 2, EAvatarExtraPartsType.Blush, "avatar_2_blush_1", "Head", new float[2] { 13f, 11f }, "Beard_2", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(26, 3, EAvatarExtraPartsType.Blush, "avatar_3_blush_1", "Head", new float[2] { 14f, 14f }, "Beard_2", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(27, 4, EAvatarExtraPartsType.Blush, "avatar_4_blush_1", "Head", new float[2] { 16f, 13f }, "Beard_2", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(28, 5, EAvatarExtraPartsType.Blush, "avatar_5_blush_1", "Head", new float[2] { 11f, 12f }, "Beard_2", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(29, 6, EAvatarExtraPartsType.Blush, "avatar_6_blush_1", "Head", new float[2] { 13f, 17f }, "Beard_2", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(30, 1, EAvatarExtraPartsType.DuckHead, "avatar_1_clothpart_31_1", "Body", new float[2], "FrontHair", 1, null, null, "duck_cover_male_small"));
		_dataArray.Add(new AvatarExtraPartsItem(31, 2, EAvatarExtraPartsType.DuckHead, "avatar_2_clothpart_31_1", "Body", new float[2], "FrontHair", 1, null, null, "duck_cover_female_small"));
		_dataArray.Add(new AvatarExtraPartsItem(32, 3, EAvatarExtraPartsType.DuckHead, "avatar_3_clothpart_31_1", "Body", new float[2], "FrontHair", 1, null, null, "duck_cover_male_middle"));
		_dataArray.Add(new AvatarExtraPartsItem(33, 4, EAvatarExtraPartsType.DuckHead, "avatar_4_clothpart_31_1", "Body", new float[2], "FrontHair", 1, null, null, "duck_cover_female_middle"));
		_dataArray.Add(new AvatarExtraPartsItem(34, 5, EAvatarExtraPartsType.DuckHead, "avatar_5_clothpart_31_1", "Body", new float[2], "FrontHair", 1, null, null, "duck_cover_male_big"));
		_dataArray.Add(new AvatarExtraPartsItem(35, 6, EAvatarExtraPartsType.DuckHead, "avatar_6_clothpart_31_1", "Body", new float[2], "FrontHair", 1, null, null, "duck_cover_female_big"));
		_dataArray.Add(new AvatarExtraPartsItem(36, 1, EAvatarExtraPartsType.Mask, "avatar_1_mask_4", "EyesArea", new float[2] { 0f, 7f }, "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(37, 2, EAvatarExtraPartsType.Mask, "avatar_2_mask_4", "EyesArea", new float[2] { 0f, 7f }, "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(38, 3, EAvatarExtraPartsType.Mask, "avatar_3_mask_4", "EyesArea", new float[2] { 0f, 7f }, "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(39, 4, EAvatarExtraPartsType.Mask, "avatar_4_mask_4", "EyesArea", new float[2] { 0f, 7f }, "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(40, 5, EAvatarExtraPartsType.Mask, "avatar_5_mask_4", "EyesArea", new float[2] { 0f, 7f }, "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(41, 6, EAvatarExtraPartsType.Mask, "avatar_6_mask_4", "EyesArea", new float[2] { 0f, 7f }, "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(42, 251, EAvatarExtraPartsType.Mask, "avatar_251_mask_4", "EyesArea", new float[2] { 0f, 7f }, "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(43, 252, EAvatarExtraPartsType.Mask, "avatar_252_mask_4", "EyesArea", new float[2] { 0f, 7f }, "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(44, 253, EAvatarExtraPartsType.Mask, "avatar_253_mask_4", "EyesArea", new float[2] { 0f, 7f }, "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(45, 254, EAvatarExtraPartsType.Mask, "avatar_254_mask_4", "EyesArea", new float[2] { 0f, 7f }, "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(46, 1, EAvatarExtraPartsType.DashAsh, "avatar_1_feature2_21_ver1", "Head", new float[2], "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(47, 2, EAvatarExtraPartsType.DashAsh, "avatar_2_feature2_21_ver1", "Head", new float[2], "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(48, 3, EAvatarExtraPartsType.DashAsh, "avatar_3_feature2_21_ver1", "Head", new float[2], "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(49, 4, EAvatarExtraPartsType.DashAsh, "avatar_4_feature2_21_ver1", "Head", new float[2], "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(50, 5, EAvatarExtraPartsType.DashAsh, "avatar_5_feature2_21_ver1", "Head", new float[2], "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(51, 6, EAvatarExtraPartsType.DashAsh, "avatar_6_feature2_21_ver2", "Head", new float[2], "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(52, 251, EAvatarExtraPartsType.DashAsh, "avatar_251_feature2_1_ver2", "Head", new float[2], "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(53, 252, EAvatarExtraPartsType.DashAsh, "avatar_252_feature2_1_ver2", "Head", new float[2], "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(54, 253, EAvatarExtraPartsType.DashAsh, "avatar_253_feature2_1_ver2", "Head", new float[2], "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(55, 254, EAvatarExtraPartsType.DashAsh, "avatar_254_feature2_1_ver2", "Head", new float[2], "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(56, 1, EAvatarExtraPartsType.DashAsh, "avatar_1_feature2_21_ver2", "Head", new float[2], "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(57, 2, EAvatarExtraPartsType.DashAsh, "avatar_2_feature2_21_ver2", "Head", new float[2], "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(58, 3, EAvatarExtraPartsType.DashAsh, "avatar_3_feature2_21_ver2", "Head", new float[2], "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(59, 4, EAvatarExtraPartsType.DashAsh, "avatar_4_feature2_21_ver2", "Head", new float[2], "FrontHair", 0, null, null, null));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new AvatarExtraPartsItem(60, 5, EAvatarExtraPartsType.DashAsh, "avatar_5_feature2_21_ver2", "Head", new float[2], "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(61, 6, EAvatarExtraPartsType.DashAsh, "avatar_6_feature2_21_ver2", "Head", new float[2], "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(62, 251, EAvatarExtraPartsType.DashAsh, "avatar_251_feature2_1_ver2", "Head", new float[2], "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(63, 252, EAvatarExtraPartsType.DashAsh, "avatar_252_feature2_1_ver2", "Head", new float[2], "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(64, 253, EAvatarExtraPartsType.DashAsh, "avatar_253_feature2_1_ver2", "Head", new float[2], "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(65, 254, EAvatarExtraPartsType.DashAsh, "avatar_254_feature2_1_ver2", "Head", new float[2], "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(66, 1, EAvatarExtraPartsType.DashAsh, "avatar_1_feature2_21_ver3", "Head", new float[2], "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(67, 2, EAvatarExtraPartsType.DashAsh, "avatar_2_feature2_21_ver3", "Head", new float[2], "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(68, 3, EAvatarExtraPartsType.DashAsh, "avatar_3_feature2_21_ver3", "Head", new float[2], "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(69, 4, EAvatarExtraPartsType.DashAsh, "avatar_4_feature2_21_ver3", "Head", new float[2], "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(70, 5, EAvatarExtraPartsType.DashAsh, "avatar_5_feature2_21_ver3", "Head", new float[2], "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(71, 6, EAvatarExtraPartsType.DashAsh, "avatar_6_feature2_21_ver3", "Head", new float[2], "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(72, 251, EAvatarExtraPartsType.DashAsh, "avatar_251_feature2_1_ver3", "Head", new float[2], "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(73, 252, EAvatarExtraPartsType.DashAsh, "avatar_252_feature2_1_ver3", "Head", new float[2], "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(74, 253, EAvatarExtraPartsType.DashAsh, "avatar_253_feature2_1_ver3", "Head", new float[2], "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(75, 254, EAvatarExtraPartsType.DashAsh, "avatar_254_feature2_1_ver3", "Head", new float[2], "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(76, 1, EAvatarExtraPartsType.DashAsh, "avatar_1_feature2_21_ver4", "Head", new float[2], "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(77, 2, EAvatarExtraPartsType.DashAsh, "avatar_2_feature2_21_ver4", "Head", new float[2], "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(78, 3, EAvatarExtraPartsType.DashAsh, "avatar_3_feature2_21_ver4", "Head", new float[2], "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(79, 4, EAvatarExtraPartsType.DashAsh, "avatar_4_feature2_21_ver4", "Head", new float[2], "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(80, 5, EAvatarExtraPartsType.DashAsh, "avatar_5_feature2_21_ver4", "Head", new float[2], "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(81, 6, EAvatarExtraPartsType.DashAsh, "avatar_6_feature2_21_ver4", "Head", new float[2], "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(82, 251, EAvatarExtraPartsType.DashAsh, "avatar_251_feature2_1_ver4", "Head", new float[2], "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(83, 252, EAvatarExtraPartsType.DashAsh, "avatar_252_feature2_1_ver4", "Head", new float[2], "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(84, 253, EAvatarExtraPartsType.DashAsh, "avatar_253_feature2_1_ver4", "Head", new float[2], "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(85, 254, EAvatarExtraPartsType.DashAsh, "avatar_254_feature2_1_ver4", "Head", new float[2], "FrontHair", 0, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(86, 1, EAvatarExtraPartsType.Hat, "avatar_1_cloth_hat_front_30011", "EyesArea", new float[2] { 0f, -10f }, "FrontHair", 1, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(87, 2, EAvatarExtraPartsType.Hat, "avatar_2_cloth_hat_front_30011", "EyesArea", new float[2] { 0f, -4f }, "FrontHair", 1, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(88, 3, EAvatarExtraPartsType.Hat, "avatar_3_cloth_hat_front_30011", "EyesArea", new float[2] { 0f, -4f }, "FrontHair", 1, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(89, 4, EAvatarExtraPartsType.Hat, "avatar_4_cloth_hat_front_30011", "EyesArea", new float[2] { 0f, -4f }, "FrontHair", 1, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(90, 5, EAvatarExtraPartsType.Hat, "avatar_5_cloth_hat_front_30011", "EyesArea", new float[2] { 0f, 4f }, "FrontHair", 1, null, null, null));
		_dataArray.Add(new AvatarExtraPartsItem(91, 6, EAvatarExtraPartsType.Hat, "avatar_6_cloth_hat_front_30011", "EyesArea", new float[2] { 0f, 4f }, "FrontHair", 1, null, null, null));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<AvatarExtraPartsItem>(92);
		CreateItems0();
		CreateItems1();
	}
}

using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class AvatarHead : ConfigData<AvatarHeadItem, byte>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 男孩瘦头型
		/// </summary>
		public const byte ThinBoy = 6;

		/// <summary>
		/// 女孩瘦头型
		/// </summary>
		public const byte ThinGirl = 7;

		/// <summary>
		/// 男孩胖头型
		/// </summary>
		public const byte FatBoy = 8;

		/// <summary>
		/// 女孩胖头型
		/// </summary>
		public const byte FatGirl = 9;

		/// <summary>
		/// 男性瘦骷髅
		/// </summary>
		public const byte MaleThinSkeleton = 10;

		/// <summary>
		/// 女性瘦骷髅
		/// </summary>
		public const byte FemaleThinSkeleton = 11;

		/// <summary>
		/// 男性中骷髅
		/// </summary>
		public const byte MaleNormalSkeleton = 12;

		/// <summary>
		/// 女性中骷髅
		/// </summary>
		public const byte FemaleNormalSkeleton = 13;

		/// <summary>
		/// 男性胖骷髅
		/// </summary>
		public const byte MaleStrongSkeleton = 14;

		/// <summary>
		/// 女性胖骷髅
		/// </summary>
		public const byte FemaleStrongSkeleton = 15;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 男孩瘦头型
		/// </summary>
		public static AvatarHeadItem ThinBoy => Instance[(byte)6];

		/// <summary>
		/// 女孩瘦头型
		/// </summary>
		public static AvatarHeadItem ThinGirl => Instance[(byte)7];

		/// <summary>
		/// 男孩胖头型
		/// </summary>
		public static AvatarHeadItem FatBoy => Instance[(byte)8];

		/// <summary>
		/// 女孩胖头型
		/// </summary>
		public static AvatarHeadItem FatGirl => Instance[(byte)9];

		/// <summary>
		/// 男性瘦骷髅
		/// </summary>
		public static AvatarHeadItem MaleThinSkeleton => Instance[(byte)10];

		/// <summary>
		/// 女性瘦骷髅
		/// </summary>
		public static AvatarHeadItem FemaleThinSkeleton => Instance[(byte)11];

		/// <summary>
		/// 男性中骷髅
		/// </summary>
		public static AvatarHeadItem MaleNormalSkeleton => Instance[(byte)12];

		/// <summary>
		/// 女性中骷髅
		/// </summary>
		public static AvatarHeadItem FemaleNormalSkeleton => Instance[(byte)13];

		/// <summary>
		/// 男性胖骷髅
		/// </summary>
		public static AvatarHeadItem MaleStrongSkeleton => Instance[(byte)14];

		/// <summary>
		/// 女性胖骷髅
		/// </summary>
		public static AvatarHeadItem FemaleStrongSkeleton => Instance[(byte)15];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static AvatarHead Instance = new AvatarHead();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "DisplayDesc", "RelativeExtraPart", "TemplateId", "HeadId", "NameOrPath" };

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
		_dataArray.Add(new AvatarHeadItem(0, 1, 1, LocalStringManager.GetConfig("AvatarHead_language", "DisplayDesc_0"), "avatar_1_head_1", -20, 25, 15, 70, 36, 53, 10, 22, -1, canRandom: true));
		_dataArray.Add(new AvatarHeadItem(1, 1, 2, LocalStringManager.GetConfig("AvatarHead_language", "DisplayDesc_1"), "avatar_2_head_1", -20, 26, 12, 66, 33, 50, 11, 22, -1, canRandom: true));
		_dataArray.Add(new AvatarHeadItem(2, 1, 3, LocalStringManager.GetConfig("AvatarHead_language", "DisplayDesc_2"), "avatar_3_head_1", -12, 26, 17, 72, 42, 59, 12, 27, -1, canRandom: true));
		_dataArray.Add(new AvatarHeadItem(3, 1, 4, LocalStringManager.GetConfig("AvatarHead_language", "DisplayDesc_3"), "avatar_4_head_1", -16, 26, 16, 73, 38, 54, 10, 25, -1, canRandom: true));
		_dataArray.Add(new AvatarHeadItem(4, 1, 5, LocalStringManager.GetConfig("AvatarHead_language", "DisplayDesc_4"), "avatar_5_head_1", -5, 29, 18, 74, 43, 61, 13, 30, -1, canRandom: true));
		_dataArray.Add(new AvatarHeadItem(5, 1, 6, LocalStringManager.GetConfig("AvatarHead_language", "DisplayDesc_5"), "avatar_6_head_1", -4, 28, 15, 73, 41, 58, 13, 28, -1, canRandom: true));
		_dataArray.Add(new AvatarHeadItem(6, 1, 251, LocalStringManager.GetConfig("AvatarHead_language", "DisplayDesc_6"), "avatar_251_head_1", -9, 14, 16, 74, 33, 48, 9, 20, -1, canRandom: false));
		_dataArray.Add(new AvatarHeadItem(7, 1, 252, LocalStringManager.GetConfig("AvatarHead_language", "DisplayDesc_7"), "avatar_252_head_1", -9, 10, 14, 76, 32, 48, 9, 19, -1, canRandom: false));
		_dataArray.Add(new AvatarHeadItem(8, 1, 253, LocalStringManager.GetConfig("AvatarHead_language", "DisplayDesc_8"), "avatar_253_head_1", -9, 18, 19, 85, 36, 54, 13, 25, -1, canRandom: false));
		_dataArray.Add(new AvatarHeadItem(9, 1, 254, LocalStringManager.GetConfig("AvatarHead_language", "DisplayDesc_9"), "avatar_254_head_1", -9, 12, 17, 79, 32, 47, 9, 19, -1, canRandom: false));
		_dataArray.Add(new AvatarHeadItem(10, byte.MaxValue, 1, LocalStringManager.GetConfig("AvatarHead_language", "DisplayDesc_10"), "avatar_1_head_skull", 0, 0, 0, 0, 0, 0, 0, 0, -1, canRandom: false));
		_dataArray.Add(new AvatarHeadItem(11, byte.MaxValue, 2, LocalStringManager.GetConfig("AvatarHead_language", "DisplayDesc_11"), "avatar_2_head_skull", 0, 0, 0, 0, 0, 0, 0, 0, -1, canRandom: false));
		_dataArray.Add(new AvatarHeadItem(12, byte.MaxValue, 3, LocalStringManager.GetConfig("AvatarHead_language", "DisplayDesc_12"), "avatar_3_head_skull", 0, 0, 0, 0, 0, 0, 0, 0, -1, canRandom: false));
		_dataArray.Add(new AvatarHeadItem(13, byte.MaxValue, 4, LocalStringManager.GetConfig("AvatarHead_language", "DisplayDesc_13"), "avatar_4_head_skull", 0, 0, 0, 0, 0, 0, 0, 0, -1, canRandom: false));
		_dataArray.Add(new AvatarHeadItem(14, byte.MaxValue, 5, LocalStringManager.GetConfig("AvatarHead_language", "DisplayDesc_14"), "avatar_5_head_skull", 0, 0, 0, 0, 0, 0, 0, 0, -1, canRandom: false));
		_dataArray.Add(new AvatarHeadItem(15, byte.MaxValue, 6, LocalStringManager.GetConfig("AvatarHead_language", "DisplayDesc_15"), "avatar_6_head_skull", 0, 0, 0, 0, 0, 0, 0, 0, -1, canRandom: false));
		_dataArray.Add(new AvatarHeadItem(16, 2, 1, LocalStringManager.GetConfig("AvatarHead_language", "DisplayDesc_16"), "avatar_1_head_2", -20, 25, 15, 70, 36, 53, 10, 22, -1, canRandom: true));
		_dataArray.Add(new AvatarHeadItem(17, 2, 2, LocalStringManager.GetConfig("AvatarHead_language", "DisplayDesc_17"), "avatar_2_head_2", -20, 26, 12, 66, 33, 50, 11, 22, -1, canRandom: true));
		_dataArray.Add(new AvatarHeadItem(18, 2, 3, LocalStringManager.GetConfig("AvatarHead_language", "DisplayDesc_18"), "avatar_3_head_2", -12, 26, 17, 72, 42, 59, 12, 27, -1, canRandom: true));
		_dataArray.Add(new AvatarHeadItem(19, 2, 4, LocalStringManager.GetConfig("AvatarHead_language", "DisplayDesc_19"), "avatar_4_head_2", -16, 26, 16, 73, 38, 54, 10, 25, -1, canRandom: true));
		_dataArray.Add(new AvatarHeadItem(20, 2, 5, LocalStringManager.GetConfig("AvatarHead_language", "DisplayDesc_20"), "avatar_5_head_2", -5, 29, 18, 74, 43, 61, 13, 30, -1, canRandom: true));
		_dataArray.Add(new AvatarHeadItem(21, 2, 6, LocalStringManager.GetConfig("AvatarHead_language", "DisplayDesc_21"), "avatar_6_head_2", -4, 28, 15, 73, 41, 58, 13, 28, -1, canRandom: true));
		_dataArray.Add(new AvatarHeadItem(22, 3, 1, LocalStringManager.GetConfig("AvatarHead_language", "DisplayDesc_22"), "avatar_1_head_3", -20, 25, 15, 70, 36, 53, 10, 22, -1, canRandom: true));
		_dataArray.Add(new AvatarHeadItem(23, 3, 2, LocalStringManager.GetConfig("AvatarHead_language", "DisplayDesc_23"), "avatar_2_head_3", -20, 26, 12, 66, 33, 50, 11, 22, -1, canRandom: true));
		_dataArray.Add(new AvatarHeadItem(24, 3, 3, LocalStringManager.GetConfig("AvatarHead_language", "DisplayDesc_24"), "avatar_3_head_3", -12, 26, 17, 72, 42, 59, 12, 27, -1, canRandom: true));
		_dataArray.Add(new AvatarHeadItem(25, 3, 4, LocalStringManager.GetConfig("AvatarHead_language", "DisplayDesc_25"), "avatar_4_head_3", -16, 26, 16, 73, 38, 54, 10, 25, -1, canRandom: true));
		_dataArray.Add(new AvatarHeadItem(26, 3, 5, LocalStringManager.GetConfig("AvatarHead_language", "DisplayDesc_26"), "avatar_5_head_3", -5, 29, 18, 74, 43, 61, 13, 30, -1, canRandom: true));
		_dataArray.Add(new AvatarHeadItem(27, 3, 6, LocalStringManager.GetConfig("AvatarHead_language", "DisplayDesc_27"), "avatar_6_head_3", -4, 28, 15, 73, 41, 58, 13, 28, -1, canRandom: true));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<AvatarHeadItem>(28);
		CreateItems0();
	}
}

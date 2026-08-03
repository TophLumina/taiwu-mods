using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class VillagerRole : ConfigData<VillagerRoleItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 太吾村农户
		/// </summary>
		public const short Farmer = 0;

		/// <summary>
		/// 太吾村匠人
		/// </summary>
		public const short Craftsman = 1;

		/// <summary>
		/// 太吾村大夫
		/// </summary>
		public const short Doctor = 2;

		/// <summary>
		/// 太吾村商人
		/// </summary>
		public const short Merchant = 3;

		/// <summary>
		/// 太吾村文人
		/// </summary>
		public const short Literati = 4;

		/// <summary>
		/// 太吾村护冢
		/// </summary>
		public const short SwordTombKeeper = 5;

		/// <summary>
		/// 太吾村村长
		/// </summary>
		public const short VillageHead = 6;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 太吾村农户
		/// </summary>
		public static VillagerRoleItem Farmer => Instance[(short)0];

		/// <summary>
		/// 太吾村匠人
		/// </summary>
		public static VillagerRoleItem Craftsman => Instance[(short)1];

		/// <summary>
		/// 太吾村大夫
		/// </summary>
		public static VillagerRoleItem Doctor => Instance[(short)2];

		/// <summary>
		/// 太吾村商人
		/// </summary>
		public static VillagerRoleItem Merchant => Instance[(short)3];

		/// <summary>
		/// 太吾村文人
		/// </summary>
		public static VillagerRoleItem Literati => Instance[(short)4];

		/// <summary>
		/// 太吾村护冢
		/// </summary>
		public static VillagerRoleItem SwordTombKeeper => Instance[(short)5];

		/// <summary>
		/// 太吾村村长
		/// </summary>
		public static VillagerRoleItem VillageHead => Instance[(short)6];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static VillagerRole Instance = new VillagerRole();

	private readonly HashSet<string> RequiredFields = new HashSet<string>
	{
		"OrganizationMember", "PersonalityType", "NeedPersonalityList", "EffectTextList", "EffectValueTextList", "Clothing", "FeatureId", "LearnableLifeSkillTypes", "LearnableCombatSkillTypes", "AutoActions",
		"TemplateId", "IdleIcon"
	};

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
		_dataArray.Add(new VillagerRoleItem(0, 17, 6, new NeedPersonality[1]
		{
			new NeedPersonality(6, 3)
		}, new string[3]
		{
			LocalStringManager.GetConfig("VillagerRole_language", "EffectTextList_0_0"),
			LocalStringManager.GetConfig("VillagerRole_language", "EffectTextList_0_1"),
			LocalStringManager.GetConfig("VillagerRole_language", "EffectTextList_0_2")
		}, new string[3]
		{
			LocalStringManager.GetConfig("VillagerRole_language", "EffectValueTextList_0_0"),
			LocalStringManager.GetConfig("VillagerRole_language", "EffectValueTextList_0_1"),
			LocalStringManager.GetConfig("VillagerRole_language", "EffectValueTextList_0_2")
		}, new List<float[]>
		{
			new float[1] { 0.2f },
			new float[1] { 0.1f },
			new float[1] { 0.05f }
		}, new int[1] { 1 }, 85, "sp_icon_gongzuozhuangtai_1", 590, new sbyte[1] { 14 }, new sbyte[0], int.MaxValue, 100, new short[1]));
		_dataArray.Add(new VillagerRoleItem(1, 16, 4, new NeedPersonality[1]
		{
			new NeedPersonality(4, 3)
		}, new string[3]
		{
			LocalStringManager.GetConfig("VillagerRole_language", "EffectTextList_1_0"),
			LocalStringManager.GetConfig("VillagerRole_language", "EffectTextList_1_1"),
			LocalStringManager.GetConfig("VillagerRole_language", "EffectTextList_1_2")
		}, new string[3]
		{
			LocalStringManager.GetConfig("VillagerRole_language", "EffectValueTextList_1_0"),
			LocalStringManager.GetConfig("VillagerRole_language", "EffectValueTextList_1_1"),
			LocalStringManager.GetConfig("VillagerRole_language", "EffectValueTextList_1_2")
		}, new List<float[]>
		{
			new float[1] { 0.05f },
			new float[1] { 0.1f },
			new float[1] { 0.1f }
		}, new int[1] { 2 }, 86, "sp_icon_gongzuozhuangtai_3", 591, new sbyte[4] { 6, 7, 10, 11 }, new sbyte[0], int.MaxValue, 250, new short[3] { 1, 2, 3 }));
		_dataArray.Add(new VillagerRoleItem(2, 15, 0, new NeedPersonality[1]
		{
			new NeedPersonality(0, 3)
		}, new string[2]
		{
			LocalStringManager.GetConfig("VillagerRole_language", "EffectTextList_2_0"),
			LocalStringManager.GetConfig("VillagerRole_language", "EffectTextList_2_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("VillagerRole_language", "EffectValueTextList_2_0"),
			LocalStringManager.GetConfig("VillagerRole_language", "EffectValueTextList_2_1")
		}, new List<float[]>
		{
			new float[1] { 0.0677f },
			new float[1] { 1f }
		}, new int[1] { 1 }, 87, "sp_icon_gongzuozhuangtai_4", 592, new sbyte[2] { 8, 9 }, new sbyte[0], int.MaxValue, 500, new short[1] { 4 }));
		_dataArray.Add(new VillagerRoleItem(3, 14, 2, new NeedPersonality[1]
		{
			new NeedPersonality(2, 3)
		}, new string[2]
		{
			LocalStringManager.GetConfig("VillagerRole_language", "EffectTextList_3_0"),
			LocalStringManager.GetConfig("VillagerRole_language", "EffectTextList_3_1")
		}, new string[2]
		{
			LocalStringManager.GetConfig("VillagerRole_language", "EffectValueTextList_3_0"),
			LocalStringManager.GetConfig("VillagerRole_language", "EffectValueTextList_3_1")
		}, new List<float[]>
		{
			new float[1] { 0.0677f },
			new float[1] { 1f }
		}, new int[1] { 1 }, 88, "sp_icon_gongzuozhuangtai_6", 593, new sbyte[1] { 15 }, new sbyte[0], int.MaxValue, 750, new short[1] { 5 }));
		_dataArray.Add(new VillagerRoleItem(4, 13, 1, new NeedPersonality[1]
		{
			new NeedPersonality(1, 3)
		}, new string[3]
		{
			LocalStringManager.GetConfig("VillagerRole_language", "EffectTextList_4_0"),
			LocalStringManager.GetConfig("VillagerRole_language", "EffectTextList_4_1"),
			LocalStringManager.GetConfig("VillagerRole_language", "EffectTextList_4_2")
		}, new string[3]
		{
			LocalStringManager.GetConfig("VillagerRole_language", "EffectValueTextList_4_0"),
			LocalStringManager.GetConfig("VillagerRole_language", "EffectValueTextList_4_1"),
			LocalStringManager.GetConfig("VillagerRole_language", "EffectValueTextList_4_2")
		}, new List<float[]>
		{
			new float[1] { 0.05f },
			new float[1] { 0.05f },
			new float[1] { 0.1f }
		}, new int[1] { 1 }, 89, "sp_icon_gongzuozhuangtai_11", 594, new sbyte[5] { 0, 1, 2, 3, 5 }, new sbyte[0], int.MaxValue, 1000, new short[1] { 6 }));
		_dataArray.Add(new VillagerRoleItem(5, 12, 3, new NeedPersonality[1]
		{
			new NeedPersonality(3, 3)
		}, new string[5]
		{
			LocalStringManager.GetConfig("VillagerRole_language", "EffectTextList_5_0"),
			LocalStringManager.GetConfig("VillagerRole_language", "EffectTextList_5_1"),
			LocalStringManager.GetConfig("VillagerRole_language", "EffectTextList_5_2"),
			LocalStringManager.GetConfig("VillagerRole_language", "EffectTextList_5_3"),
			LocalStringManager.GetConfig("VillagerRole_language", "EffectTextList_5_4")
		}, new string[5]
		{
			LocalStringManager.GetConfig("VillagerRole_language", "EffectValueTextList_5_0"),
			LocalStringManager.GetConfig("VillagerRole_language", "EffectValueTextList_5_1"),
			LocalStringManager.GetConfig("VillagerRole_language", "EffectValueTextList_5_2"),
			LocalStringManager.GetConfig("VillagerRole_language", "EffectValueTextList_5_3"),
			LocalStringManager.GetConfig("VillagerRole_language", "EffectValueTextList_5_4")
		}, new List<float[]>
		{
			new float[1] { 1f },
			new float[1] { 1f },
			new float[1] { 1f },
			new float[1] { 1f },
			new float[1] { 0.05f }
		}, new int[1] { 3 }, 90, "sp_icon_gongzuozhuangtai_16", 595, new sbyte[2] { 13, 12 }, new sbyte[14]
		{
			0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
			10, 11, 12, 13
		}, int.MaxValue, 1500, new short[1] { 7 }));
		_dataArray.Add(new VillagerRoleItem(6, 11, 5, new NeedPersonality[1]
		{
			new NeedPersonality(5, 3)
		}, new string[3]
		{
			LocalStringManager.GetConfig("VillagerRole_language", "EffectTextList_6_0"),
			LocalStringManager.GetConfig("VillagerRole_language", "EffectTextList_6_1"),
			LocalStringManager.GetConfig("VillagerRole_language", "EffectTextList_6_2")
		}, new string[3]
		{
			LocalStringManager.GetConfig("VillagerRole_language", "EffectValueTextList_6_0"),
			LocalStringManager.GetConfig("VillagerRole_language", "EffectValueTextList_6_1"),
			LocalStringManager.GetConfig("VillagerRole_language", "EffectValueTextList_6_2")
		}, new List<float[]>
		{
			new float[1] { 0.05f },
			new float[1] { 0.05f },
			new float[1] { 0.5f }
		}, new int[1] { 2 }, 91, "sp_icon_gongzuozhuangtai_21", 596, new sbyte[1] { 4 }, new sbyte[0], int.MaxValue, 2500, new short[1] { 8 }));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<VillagerRoleItem>(7);
		CreateItems0();
	}
}

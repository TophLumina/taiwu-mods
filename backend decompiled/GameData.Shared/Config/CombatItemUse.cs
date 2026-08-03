using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class CombatItemUse : ConfigData<CombatItemUseItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 服食道具
		/// </summary>
		public const short EatItem = 0;

		/// <summary>
		/// 外敷药品
		/// </summary>
		public const short TopicalMedicine = 1;

		/// <summary>
		/// 使用相枢剑柄
		/// </summary>
		public const short UseXiangshuSword = 2;

		/// <summary>
		/// 修理道具准备
		/// </summary>
		public const short PrepareRepair = 3;

		/// <summary>
		/// 使用绳子准备
		/// </summary>
		public const short PrepareRope = 4;

		/// <summary>
		/// 使用绳子成功
		/// </summary>
		public const short UseRopeSuccess = 5;

		/// <summary>
		/// 使用绳子失败
		/// </summary>
		public const short UseRopeFail = 6;

		/// <summary>
		/// 伏虞剑准备
		/// </summary>
		public const short PrepareFuyuSword = 7;

		/// <summary>
		/// 伏虞剑攻击
		/// </summary>
		public const short UseFuyuSword = 8;

		/// <summary>
		/// 投掷毒药准备
		/// </summary>
		public const short PrepareThrowPoison = 9;

		/// <summary>
		/// 投掷毒药施展
		/// </summary>
		public const short UseThrowPoison = 10;

		/// <summary>
		/// 符箓道具准备
		/// </summary>
		public const short PrepareFulu = 11;

		/// <summary>
		/// 符箓道具灵文使用
		/// </summary>
		public const short UseFuluSpiritWords = 12;

		/// <summary>
		/// 符箓道具秘文使用
		/// </summary>
		public const short UseFuluMysteryWords = 13;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 服食道具
		/// </summary>
		public static CombatItemUseItem EatItem => Instance[(short)0];

		/// <summary>
		/// 外敷药品
		/// </summary>
		public static CombatItemUseItem TopicalMedicine => Instance[(short)1];

		/// <summary>
		/// 使用相枢剑柄
		/// </summary>
		public static CombatItemUseItem UseXiangshuSword => Instance[(short)2];

		/// <summary>
		/// 修理道具准备
		/// </summary>
		public static CombatItemUseItem PrepareRepair => Instance[(short)3];

		/// <summary>
		/// 使用绳子准备
		/// </summary>
		public static CombatItemUseItem PrepareRope => Instance[(short)4];

		/// <summary>
		/// 使用绳子成功
		/// </summary>
		public static CombatItemUseItem UseRopeSuccess => Instance[(short)5];

		/// <summary>
		/// 使用绳子失败
		/// </summary>
		public static CombatItemUseItem UseRopeFail => Instance[(short)6];

		/// <summary>
		/// 伏虞剑准备
		/// </summary>
		public static CombatItemUseItem PrepareFuyuSword => Instance[(short)7];

		/// <summary>
		/// 伏虞剑攻击
		/// </summary>
		public static CombatItemUseItem UseFuyuSword => Instance[(short)8];

		/// <summary>
		/// 投掷毒药准备
		/// </summary>
		public static CombatItemUseItem PrepareThrowPoison => Instance[(short)9];

		/// <summary>
		/// 投掷毒药施展
		/// </summary>
		public static CombatItemUseItem UseThrowPoison => Instance[(short)10];

		/// <summary>
		/// 符箓道具准备
		/// </summary>
		public static CombatItemUseItem PrepareFulu => Instance[(short)11];

		/// <summary>
		/// 符箓道具灵文使用
		/// </summary>
		public static CombatItemUseItem UseFuluSpiritWords => Instance[(short)12];

		/// <summary>
		/// 符箓道具秘文使用
		/// </summary>
		public static CombatItemUseItem UseFuluMysteryWords => Instance[(short)13];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static CombatItemUse Instance = new CombatItemUse();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "TemplateId", "Animation", "Particle", "Sound", "BeHitAnimation", "Distance" };

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
		_dataArray.Add(new CombatItemUseItem(0, "C_020", "Particle_C_020", null, null, 38));
		_dataArray.Add(new CombatItemUseItem(1, "C_021", "Particle_C_021", null, null, 38));
		_dataArray.Add(new CombatItemUseItem(2, "C_022", null, null, null, 38));
		_dataArray.Add(new CombatItemUseItem(3, "C_019", "Particle_C_019", null, null, 38));
		_dataArray.Add(new CombatItemUseItem(4, "C_023", "Particle_C_023", "se_c_023", null, 38));
		_dataArray.Add(new CombatItemUseItem(5, "C_023_1", "Particle_C_023_1", "se_c_023_1", "H_023_1", 38));
		_dataArray.Add(new CombatItemUseItem(6, "C_023_2", "Particle_C_023_2", "se_c_023_2", null, 38));
		_dataArray.Add(new CombatItemUseItem(7, "C_024", "Particle_C_024", "se_c_024", null, 38));
		_dataArray.Add(new CombatItemUseItem(8, "C_024_1", "Particle_C_024_1", "se_c_024_1", "H_024_1", 20));
		_dataArray.Add(new CombatItemUseItem(9, "C_025", "Particle_C_025", "se_c_025", null, 38));
		_dataArray.Add(new CombatItemUseItem(10, "C_025_1", "Particle_C_025_1", "se_c_025_1", null, 30));
		_dataArray.Add(new CombatItemUseItem(11, "C_025", "Particle_C_025", null, null, 38));
		_dataArray.Add(new CombatItemUseItem(12, "C_025_2", "Particle_C_025_2", "se_c_025_baolu_use", null, 38));
		_dataArray.Add(new CombatItemUseItem(13, "C_025_3", "Particle_C_025_3", "se_c_025_baolu_use", null, 38));
		_dataArray.Add(new CombatItemUseItem(14, "C_023_1_bear", "Particle_C_023_1_bear", "SE_C_023_1_bear", "H_023_1", 38));
		_dataArray.Add(new CombatItemUseItem(15, "C_023_1_bull", "Particle_C_023_1_bull", "SE_C_023_1_bull", "H_023_1", 38));
		_dataArray.Add(new CombatItemUseItem(16, "C_023_1_eagle", "Particle_C_023_1_eagle", "SE_C_023_1_eagle", "H_023_1", 38));
		_dataArray.Add(new CombatItemUseItem(17, "C_023_1_jaguar", "Particle_C_023_1_jaguar", "SE_C_023_1_jaguar", "H_023_1", 38));
		_dataArray.Add(new CombatItemUseItem(18, "C_023_1_lion", "Particle_C_023_1_lion", "SE_C_023_1_lion", "H_023_1", 38));
		_dataArray.Add(new CombatItemUseItem(19, "C_023_1_monkey", "Particle_C_023_1_monkey", "SE_C_023_1_monkey", "H_023_1", 38));
		_dataArray.Add(new CombatItemUseItem(20, "C_023_1_pig", "Particle_C_023_1_pig", "SE_C_023_1_pig", "H_023_1", 38));
		_dataArray.Add(new CombatItemUseItem(21, "C_023_1_snake", "Particle_C_023_1_snake", "SE_C_023_1_snake", "H_023_1", 38));
		_dataArray.Add(new CombatItemUseItem(22, "C_023_1_tiger", "Particle_C_023_1_tiger", "SE_C_023_1_tiger", "H_023_1", 38));
		_dataArray.Add(new CombatItemUseItem(23, "C_023_1_bear", "Particle_C_023_1_bear_elite", "SE_C_023_1_bear", "H_023_1", 38));
		_dataArray.Add(new CombatItemUseItem(24, "C_023_1_bull", "Particle_C_023_1_bull_elite", "SE_C_023_1_bull", "H_023_1", 38));
		_dataArray.Add(new CombatItemUseItem(25, "C_023_1_eagle", "Particle_C_023_1_eagle_elite", "SE_C_023_1_eagle", "H_023_1", 38));
		_dataArray.Add(new CombatItemUseItem(26, "C_023_1_jaguar", "Particle_C_023_1_jaguar_elite", "SE_C_023_1_jaguar", "H_023_1", 38));
		_dataArray.Add(new CombatItemUseItem(27, "C_023_1_lion", "Particle_C_023_1_lion_elite", "SE_C_023_1_lion", "H_023_1", 38));
		_dataArray.Add(new CombatItemUseItem(28, "C_023_1_monkey", "Particle_C_023_1_monkey_elite", "SE_C_023_1_monkey", "H_023_1", 38));
		_dataArray.Add(new CombatItemUseItem(29, "C_023_1_pig", "Particle_C_023_1_pig_elite", "SE_C_023_1_pig", "H_023_1", 38));
		_dataArray.Add(new CombatItemUseItem(30, "C_023_1_snake", "Particle_C_023_1_snake_elite", "SE_C_023_1_snake", "H_023_1", 38));
		_dataArray.Add(new CombatItemUseItem(31, "C_023_1_tiger", "Particle_C_023_1_tiger_elite", "SE_C_023_1_tiger", "H_023_1", 38));
		_dataArray.Add(new CombatItemUseItem(32, "C_023_1_monkey", "Particle_C_023_1_monkey_king", "SE_C_023_1_monkey", "H_023_1", 38));
		_dataArray.Add(new CombatItemUseItem(33, "C_023_1_Loong", "Particle_C_023_1_Loong", "SE_C_023_1_Loong", "H_023_1", 38));
		_dataArray.Add(new CombatItemUseItem(34, "C_023_1_Loong_jiao", "Particle_C_023_1_Loong_jiao", "SE_C_023_1_Loong", "H_023_1", 38));
		_dataArray.Add(new CombatItemUseItem(35, "C_023_1_dragon_qiuniu", "Particle_C_023_1_dragon_qiuniu", "SE_C_023_1_dragon_qiuniu", "H_023_1", 38));
		_dataArray.Add(new CombatItemUseItem(36, "C_023_1_dragon_yazi", "Particle_C_023_1_dragon_yazi", "SE_C_023_1_dragon_yazi", "H_023_1", 38));
		_dataArray.Add(new CombatItemUseItem(37, "C_023_1_dragon_chaofeng", "Particle_C_023_1_dragon_chaofeng", "SE_C_023_1_dragon_chaofeng", "H_023_1", 38));
		_dataArray.Add(new CombatItemUseItem(38, "C_023_1_dragon_pulao", "Particle_C_023_1_dragon_pulao", "SE_C_023_1_dragon_pulao", "H_023_1", 38));
		_dataArray.Add(new CombatItemUseItem(39, "C_023_1_dragon_suanni", "Particle_C_023_1_dragon_suanni", "SE_C_023_1_dragon_suanni", "H_023_1", 38));
		_dataArray.Add(new CombatItemUseItem(40, "C_023_1_dragon_baxia", "Particle_C_023_1_dragon_baxia", "SE_C_023_1_dragon_baxia", "H_023_1", 38));
		_dataArray.Add(new CombatItemUseItem(41, "C_023_1_dragon_bian", "Particle_C_023_1_dragon_bian", "SE_C_023_1_dragon_bian", "H_023_1", 38));
		_dataArray.Add(new CombatItemUseItem(42, "C_023_1_dragon_fuxi", "Particle_C_023_1_dragon_fuxi", "SE_C_023_1_Loong", "H_023_1", 38));
		_dataArray.Add(new CombatItemUseItem(43, "C_023_1_dragon_chiwen", "Particle_C_023_1_dragon_chiwen", "SE_C_023_1_dragon_chiwen", "H_023_1", 38));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<CombatItemUseItem>(44);
		CreateItems0();
	}
}

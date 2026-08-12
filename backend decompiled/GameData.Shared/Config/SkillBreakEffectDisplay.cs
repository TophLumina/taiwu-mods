using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class SkillBreakEffectDisplay : ConfigData<SkillBreakEffectDisplayItem, sbyte>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 提气消耗
		/// </summary>
		public const sbyte CostBreath = 0;

		/// <summary>
		/// 架势消耗
		/// </summary>
		public const sbyte CostStance = 1;

		/// <summary>
		/// 技艺发挥-音律
		/// </summary>
		public const sbyte AttainmentMusic = 2;

		/// <summary>
		/// 技艺发挥-弈棋
		/// </summary>
		public const sbyte AttainmentChess = 3;

		/// <summary>
		/// 技艺发挥-诗书
		/// </summary>
		public const sbyte AttainmentPoem = 4;

		/// <summary>
		/// 技艺发挥-绘画
		/// </summary>
		public const sbyte AttainmentPainting = 5;

		/// <summary>
		/// 技艺发挥-术数
		/// </summary>
		public const sbyte AttainmentMath = 6;

		/// <summary>
		/// 技艺发挥-品鉴
		/// </summary>
		public const sbyte AttainmentAppraisal = 7;

		/// <summary>
		/// 技艺发挥-锻造
		/// </summary>
		public const sbyte AttainmentForging = 8;

		/// <summary>
		/// 技艺发挥-制木
		/// </summary>
		public const sbyte AttainmentWoodworking = 9;

		/// <summary>
		/// 技艺发挥-医术
		/// </summary>
		public const sbyte AttainmentMedicine = 10;

		/// <summary>
		/// 技艺发挥-毒术
		/// </summary>
		public const sbyte AttainmentToxicology = 11;

		/// <summary>
		/// 技艺发挥-织锦
		/// </summary>
		public const sbyte AttainmentWeaving = 12;

		/// <summary>
		/// 技艺发挥-巧匠
		/// </summary>
		public const sbyte AttainmentJade = 13;

		/// <summary>
		/// 技艺发挥-道法
		/// </summary>
		public const sbyte AttainmentTaoism = 14;

		/// <summary>
		/// 技艺发挥-佛学
		/// </summary>
		public const sbyte AttainmentBuddhism = 15;

		/// <summary>
		/// 技艺发挥-厨艺
		/// </summary>
		public const sbyte AttainmentCooking = 16;

		/// <summary>
		/// 技艺发挥-杂学
		/// </summary>
		public const sbyte AttainmentEclectic = 17;

		/// <summary>
		/// 外伤阈值-头颈
		/// </summary>
		public const sbyte OuterInjuryStepHead = 18;

		/// <summary>
		/// 外伤阈值-胸背
		/// </summary>
		public const sbyte OuterInjuryStepChest = 19;

		/// <summary>
		/// 外伤阈值-腰腹
		/// </summary>
		public const sbyte OuterInjuryStepBelly = 20;

		/// <summary>
		/// 外伤阈值-左臂
		/// </summary>
		public const sbyte OuterInjuryStepLeftHand = 21;

		/// <summary>
		/// 外伤阈值-右臂
		/// </summary>
		public const sbyte OuterInjuryStepRightHand = 22;

		/// <summary>
		/// 外伤阈值-左腿
		/// </summary>
		public const sbyte OuterInjuryStepLeftLeg = 23;

		/// <summary>
		/// 外伤阈值-右腿
		/// </summary>
		public const sbyte OuterInjuryStepRightLeg = 24;

		/// <summary>
		/// 内伤阈值-头颈
		/// </summary>
		public const sbyte InnerInjuryStepHead = 25;

		/// <summary>
		/// 内伤阈值-胸背
		/// </summary>
		public const sbyte InnerInjuryStepChest = 26;

		/// <summary>
		/// 内伤阈值-腰腹
		/// </summary>
		public const sbyte InnerInjuryStepBelly = 27;

		/// <summary>
		/// 内伤阈值-左臂
		/// </summary>
		public const sbyte InnerInjuryStepLeftHand = 28;

		/// <summary>
		/// 内伤阈值-右臂
		/// </summary>
		public const sbyte InnerInjuryStepRightHand = 29;

		/// <summary>
		/// 内伤阈值-左腿
		/// </summary>
		public const sbyte InnerInjuryStepLeftLeg = 30;

		/// <summary>
		/// 内伤阈值-右腿
		/// </summary>
		public const sbyte InnerInjuryStepRightLeg = 31;

		/// <summary>
		/// 重创阈值
		/// </summary>
		public const sbyte FatalStep = 32;

		/// <summary>
		/// 失神阈值
		/// </summary>
		public const sbyte MindStep = 33;

		/// <summary>
		/// 已装备摧破威力上限
		/// </summary>
		public const sbyte EquippedPowerAttack = 34;

		/// <summary>
		/// 已装备轻灵威力上限
		/// </summary>
		public const sbyte EquippedPowerAgile = 35;

		/// <summary>
		/// 已装备护体威力上限
		/// </summary>
		public const sbyte EquippedPowerDefense = 36;

		/// <summary>
		/// 已装备奇窍威力上限
		/// </summary>
		public const sbyte EquippedPowerAssist = 37;

		/// <summary>
		/// 攻击范围前
		/// </summary>
		public const sbyte AttackRangeForward = 38;

		/// <summary>
		/// 攻击范围后
		/// </summary>
		public const sbyte AttackRangeBackward = 39;

		/// <summary>
		/// 造成伤害
		/// </summary>
		public const sbyte MakeDirectDamage = 40;

		/// <summary>
		/// 移动间隔影响
		/// </summary>
		public const sbyte MoveCdBonus = 41;

		/// <summary>
		/// 加快破绽消退的速度
		/// </summary>
		public const sbyte FlawRecoverSpeed = 42;

		/// <summary>
		/// 加快封穴消退的速度
		/// </summary>
		public const sbyte AcupointRecoverSpeed = 43;

		/// <summary>
		/// 被封概率变化
		/// </summary>
		public const sbyte SilenceRate = 44;

		/// <summary>
		/// 被封时间变化
		/// </summary>
		public const sbyte SilenceFrame = 45;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 提气消耗
		/// </summary>
		public static SkillBreakEffectDisplayItem CostBreath => Instance[(sbyte)0];

		/// <summary>
		/// 架势消耗
		/// </summary>
		public static SkillBreakEffectDisplayItem CostStance => Instance[(sbyte)1];

		/// <summary>
		/// 技艺发挥-音律
		/// </summary>
		public static SkillBreakEffectDisplayItem AttainmentMusic => Instance[(sbyte)2];

		/// <summary>
		/// 技艺发挥-弈棋
		/// </summary>
		public static SkillBreakEffectDisplayItem AttainmentChess => Instance[(sbyte)3];

		/// <summary>
		/// 技艺发挥-诗书
		/// </summary>
		public static SkillBreakEffectDisplayItem AttainmentPoem => Instance[(sbyte)4];

		/// <summary>
		/// 技艺发挥-绘画
		/// </summary>
		public static SkillBreakEffectDisplayItem AttainmentPainting => Instance[(sbyte)5];

		/// <summary>
		/// 技艺发挥-术数
		/// </summary>
		public static SkillBreakEffectDisplayItem AttainmentMath => Instance[(sbyte)6];

		/// <summary>
		/// 技艺发挥-品鉴
		/// </summary>
		public static SkillBreakEffectDisplayItem AttainmentAppraisal => Instance[(sbyte)7];

		/// <summary>
		/// 技艺发挥-锻造
		/// </summary>
		public static SkillBreakEffectDisplayItem AttainmentForging => Instance[(sbyte)8];

		/// <summary>
		/// 技艺发挥-制木
		/// </summary>
		public static SkillBreakEffectDisplayItem AttainmentWoodworking => Instance[(sbyte)9];

		/// <summary>
		/// 技艺发挥-医术
		/// </summary>
		public static SkillBreakEffectDisplayItem AttainmentMedicine => Instance[(sbyte)10];

		/// <summary>
		/// 技艺发挥-毒术
		/// </summary>
		public static SkillBreakEffectDisplayItem AttainmentToxicology => Instance[(sbyte)11];

		/// <summary>
		/// 技艺发挥-织锦
		/// </summary>
		public static SkillBreakEffectDisplayItem AttainmentWeaving => Instance[(sbyte)12];

		/// <summary>
		/// 技艺发挥-巧匠
		/// </summary>
		public static SkillBreakEffectDisplayItem AttainmentJade => Instance[(sbyte)13];

		/// <summary>
		/// 技艺发挥-道法
		/// </summary>
		public static SkillBreakEffectDisplayItem AttainmentTaoism => Instance[(sbyte)14];

		/// <summary>
		/// 技艺发挥-佛学
		/// </summary>
		public static SkillBreakEffectDisplayItem AttainmentBuddhism => Instance[(sbyte)15];

		/// <summary>
		/// 技艺发挥-厨艺
		/// </summary>
		public static SkillBreakEffectDisplayItem AttainmentCooking => Instance[(sbyte)16];

		/// <summary>
		/// 技艺发挥-杂学
		/// </summary>
		public static SkillBreakEffectDisplayItem AttainmentEclectic => Instance[(sbyte)17];

		/// <summary>
		/// 外伤阈值-头颈
		/// </summary>
		public static SkillBreakEffectDisplayItem OuterInjuryStepHead => Instance[(sbyte)18];

		/// <summary>
		/// 外伤阈值-胸背
		/// </summary>
		public static SkillBreakEffectDisplayItem OuterInjuryStepChest => Instance[(sbyte)19];

		/// <summary>
		/// 外伤阈值-腰腹
		/// </summary>
		public static SkillBreakEffectDisplayItem OuterInjuryStepBelly => Instance[(sbyte)20];

		/// <summary>
		/// 外伤阈值-左臂
		/// </summary>
		public static SkillBreakEffectDisplayItem OuterInjuryStepLeftHand => Instance[(sbyte)21];

		/// <summary>
		/// 外伤阈值-右臂
		/// </summary>
		public static SkillBreakEffectDisplayItem OuterInjuryStepRightHand => Instance[(sbyte)22];

		/// <summary>
		/// 外伤阈值-左腿
		/// </summary>
		public static SkillBreakEffectDisplayItem OuterInjuryStepLeftLeg => Instance[(sbyte)23];

		/// <summary>
		/// 外伤阈值-右腿
		/// </summary>
		public static SkillBreakEffectDisplayItem OuterInjuryStepRightLeg => Instance[(sbyte)24];

		/// <summary>
		/// 内伤阈值-头颈
		/// </summary>
		public static SkillBreakEffectDisplayItem InnerInjuryStepHead => Instance[(sbyte)25];

		/// <summary>
		/// 内伤阈值-胸背
		/// </summary>
		public static SkillBreakEffectDisplayItem InnerInjuryStepChest => Instance[(sbyte)26];

		/// <summary>
		/// 内伤阈值-腰腹
		/// </summary>
		public static SkillBreakEffectDisplayItem InnerInjuryStepBelly => Instance[(sbyte)27];

		/// <summary>
		/// 内伤阈值-左臂
		/// </summary>
		public static SkillBreakEffectDisplayItem InnerInjuryStepLeftHand => Instance[(sbyte)28];

		/// <summary>
		/// 内伤阈值-右臂
		/// </summary>
		public static SkillBreakEffectDisplayItem InnerInjuryStepRightHand => Instance[(sbyte)29];

		/// <summary>
		/// 内伤阈值-左腿
		/// </summary>
		public static SkillBreakEffectDisplayItem InnerInjuryStepLeftLeg => Instance[(sbyte)30];

		/// <summary>
		/// 内伤阈值-右腿
		/// </summary>
		public static SkillBreakEffectDisplayItem InnerInjuryStepRightLeg => Instance[(sbyte)31];

		/// <summary>
		/// 重创阈值
		/// </summary>
		public static SkillBreakEffectDisplayItem FatalStep => Instance[(sbyte)32];

		/// <summary>
		/// 失神阈值
		/// </summary>
		public static SkillBreakEffectDisplayItem MindStep => Instance[(sbyte)33];

		/// <summary>
		/// 已装备摧破威力上限
		/// </summary>
		public static SkillBreakEffectDisplayItem EquippedPowerAttack => Instance[(sbyte)34];

		/// <summary>
		/// 已装备轻灵威力上限
		/// </summary>
		public static SkillBreakEffectDisplayItem EquippedPowerAgile => Instance[(sbyte)35];

		/// <summary>
		/// 已装备护体威力上限
		/// </summary>
		public static SkillBreakEffectDisplayItem EquippedPowerDefense => Instance[(sbyte)36];

		/// <summary>
		/// 已装备奇窍威力上限
		/// </summary>
		public static SkillBreakEffectDisplayItem EquippedPowerAssist => Instance[(sbyte)37];

		/// <summary>
		/// 攻击范围前
		/// </summary>
		public static SkillBreakEffectDisplayItem AttackRangeForward => Instance[(sbyte)38];

		/// <summary>
		/// 攻击范围后
		/// </summary>
		public static SkillBreakEffectDisplayItem AttackRangeBackward => Instance[(sbyte)39];

		/// <summary>
		/// 造成伤害
		/// </summary>
		public static SkillBreakEffectDisplayItem MakeDirectDamage => Instance[(sbyte)40];

		/// <summary>
		/// 移动间隔影响
		/// </summary>
		public static SkillBreakEffectDisplayItem MoveCdBonus => Instance[(sbyte)41];

		/// <summary>
		/// 加快破绽消退的速度
		/// </summary>
		public static SkillBreakEffectDisplayItem FlawRecoverSpeed => Instance[(sbyte)42];

		/// <summary>
		/// 加快封穴消退的速度
		/// </summary>
		public static SkillBreakEffectDisplayItem AcupointRecoverSpeed => Instance[(sbyte)43];

		/// <summary>
		/// 被封概率变化
		/// </summary>
		public static SkillBreakEffectDisplayItem SilenceRate => Instance[(sbyte)44];

		/// <summary>
		/// 被封时间变化
		/// </summary>
		public static SkillBreakEffectDisplayItem SilenceFrame => Instance[(sbyte)45];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static SkillBreakEffectDisplay Instance = new SkillBreakEffectDisplay();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "ShortName", "TemplateId", "Icon", "BigIcon", "IsPercent" };

	internal override int ToInt(sbyte value)
	{
		return value;
	}

	internal override sbyte ToTemplateId(int value)
	{
		return (sbyte)value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new SkillBreakEffectDisplayItem(0, LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "Name_0"), LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "ShortName_0"), "mousetip_tiqi", "mousetip_tiqi_big", isPercent: true, "brightblue", "brightred", isInverse: true));
		_dataArray.Add(new SkillBreakEffectDisplayItem(1, LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "Name_1"), LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "ShortName_1"), "mousetip_jiashi", "mousetip_jiashi_big", isPercent: true, "brightblue", "brightred", isInverse: true));
		_dataArray.Add(new SkillBreakEffectDisplayItem(2, LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "Name_2"), LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "ShortName_2"), "mousetip_jiyi_0", "mousetip_jiyi_big_0", isPercent: false, "brightblue", "brightred", isInverse: false));
		_dataArray.Add(new SkillBreakEffectDisplayItem(3, LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "Name_3"), LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "ShortName_3"), "mousetip_jiyi_1", "mousetip_jiyi_big_1", isPercent: false, "brightblue", "brightred", isInverse: false));
		_dataArray.Add(new SkillBreakEffectDisplayItem(4, LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "Name_4"), LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "ShortName_4"), "mousetip_jiyi_2", "mousetip_jiyi_big_2", isPercent: false, "brightblue", "brightred", isInverse: false));
		_dataArray.Add(new SkillBreakEffectDisplayItem(5, LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "Name_5"), LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "ShortName_5"), "mousetip_jiyi_3", "mousetip_jiyi_big_3", isPercent: false, "brightblue", "brightred", isInverse: false));
		_dataArray.Add(new SkillBreakEffectDisplayItem(6, LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "Name_6"), LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "ShortName_6"), "mousetip_jiyi_4", "mousetip_jiyi_big_4", isPercent: false, "brightblue", "brightred", isInverse: false));
		_dataArray.Add(new SkillBreakEffectDisplayItem(7, LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "Name_7"), LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "ShortName_7"), "mousetip_jiyi_5", "mousetip_jiyi_big_5", isPercent: false, "brightblue", "brightred", isInverse: false));
		_dataArray.Add(new SkillBreakEffectDisplayItem(8, LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "Name_8"), LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "ShortName_8"), "mousetip_jiyi_6", "mousetip_jiyi_big_6", isPercent: false, "brightblue", "brightred", isInverse: false));
		_dataArray.Add(new SkillBreakEffectDisplayItem(9, LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "Name_9"), LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "ShortName_9"), "mousetip_jiyi_7", "mousetip_jiyi_big_7", isPercent: false, "brightblue", "brightred", isInverse: false));
		_dataArray.Add(new SkillBreakEffectDisplayItem(10, LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "Name_10"), LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "ShortName_10"), "mousetip_jiyi_8", "mousetip_jiyi_big_8", isPercent: false, "brightblue", "brightred", isInverse: false));
		_dataArray.Add(new SkillBreakEffectDisplayItem(11, LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "Name_11"), LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "ShortName_11"), "mousetip_jiyi_9", "mousetip_jiyi_big_9", isPercent: false, "brightblue", "brightred", isInverse: false));
		_dataArray.Add(new SkillBreakEffectDisplayItem(12, LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "Name_12"), LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "ShortName_12"), "mousetip_jiyi_10", "mousetip_jiyi_big_10", isPercent: false, "brightblue", "brightred", isInverse: false));
		_dataArray.Add(new SkillBreakEffectDisplayItem(13, LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "Name_13"), LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "ShortName_13"), "mousetip_jiyi_11", "mousetip_jiyi_big_11", isPercent: false, "brightblue", "brightred", isInverse: false));
		_dataArray.Add(new SkillBreakEffectDisplayItem(14, LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "Name_14"), LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "ShortName_14"), "mousetip_jiyi_12", "mousetip_jiyi_big_12", isPercent: false, "brightblue", "brightred", isInverse: false));
		_dataArray.Add(new SkillBreakEffectDisplayItem(15, LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "Name_15"), LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "ShortName_15"), "mousetip_jiyi_13", "mousetip_jiyi_big_13", isPercent: false, "brightblue", "brightred", isInverse: false));
		_dataArray.Add(new SkillBreakEffectDisplayItem(16, LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "Name_16"), LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "ShortName_16"), "mousetip_jiyi_14", "mousetip_jiyi_big_14", isPercent: false, "brightblue", "brightred", isInverse: false));
		_dataArray.Add(new SkillBreakEffectDisplayItem(17, LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "Name_17"), LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "ShortName_17"), "mousetip_jiyi_15", "mousetip_jiyi_big_15", isPercent: false, "brightblue", "brightred", isInverse: false));
		_dataArray.Add(new SkillBreakEffectDisplayItem(18, LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "Name_18"), LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "ShortName_18"), "mousetip_waishang_0", "mousetip_waishang_big_0", isPercent: true, "brightblue", "brightred", isInverse: false));
		_dataArray.Add(new SkillBreakEffectDisplayItem(19, LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "Name_19"), LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "ShortName_19"), "mousetip_waishang_1", "mousetip_waishang_big_1", isPercent: true, "brightblue", "brightred", isInverse: false));
		_dataArray.Add(new SkillBreakEffectDisplayItem(20, LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "Name_20"), LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "ShortName_20"), "mousetip_waishang_2", "mousetip_waishang_big_2", isPercent: true, "brightblue", "brightred", isInverse: false));
		_dataArray.Add(new SkillBreakEffectDisplayItem(21, LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "Name_21"), LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "ShortName_21"), "mousetip_waishang_3", "mousetip_waishang_big_3", isPercent: true, "brightblue", "brightred", isInverse: false));
		_dataArray.Add(new SkillBreakEffectDisplayItem(22, LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "Name_22"), LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "ShortName_22"), "mousetip_waishang_4", "mousetip_waishang_big_4", isPercent: true, "brightblue", "brightred", isInverse: false));
		_dataArray.Add(new SkillBreakEffectDisplayItem(23, LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "Name_23"), LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "ShortName_23"), "mousetip_waishang_5", "mousetip_waishang_big_5", isPercent: true, "brightblue", "brightred", isInverse: false));
		_dataArray.Add(new SkillBreakEffectDisplayItem(24, LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "Name_24"), LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "ShortName_24"), "mousetip_waishang_6", "mousetip_waishang_big_6", isPercent: true, "brightblue", "brightred", isInverse: false));
		_dataArray.Add(new SkillBreakEffectDisplayItem(25, LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "Name_25"), LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "ShortName_25"), "mousetip_neishang_0", "mousetip_neishang_big_0", isPercent: true, "brightblue", "brightred", isInverse: false));
		_dataArray.Add(new SkillBreakEffectDisplayItem(26, LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "Name_26"), LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "ShortName_26"), "mousetip_neishang_1", "mousetip_neishang_big_1", isPercent: true, "brightblue", "brightred", isInverse: false));
		_dataArray.Add(new SkillBreakEffectDisplayItem(27, LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "Name_27"), LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "ShortName_27"), "mousetip_neishang_2", "mousetip_neishang_big_2", isPercent: true, "brightblue", "brightred", isInverse: false));
		_dataArray.Add(new SkillBreakEffectDisplayItem(28, LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "Name_28"), LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "ShortName_28"), "mousetip_neishang_3", "mousetip_neishang_big_3", isPercent: true, "brightblue", "brightred", isInverse: false));
		_dataArray.Add(new SkillBreakEffectDisplayItem(29, LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "Name_29"), LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "ShortName_29"), "mousetip_neishang_4", "mousetip_neishang_big_4", isPercent: true, "brightblue", "brightred", isInverse: false));
		_dataArray.Add(new SkillBreakEffectDisplayItem(30, LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "Name_30"), LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "ShortName_30"), "mousetip_neishang_5", "mousetip_neishang_big_5", isPercent: true, "brightblue", "brightred", isInverse: false));
		_dataArray.Add(new SkillBreakEffectDisplayItem(31, LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "Name_31"), LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "ShortName_31"), "mousetip_neishang_6", "mousetip_neishang_big_6", isPercent: true, "brightblue", "brightred", isInverse: false));
		_dataArray.Add(new SkillBreakEffectDisplayItem(32, LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "Name_32"), LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "ShortName_32"), "mousetip_zhongchuang_0", "mousetip_zhongchuang_big", isPercent: true, "brightblue", "brightred", isInverse: false));
		_dataArray.Add(new SkillBreakEffectDisplayItem(33, LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "Name_33"), LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "ShortName_33"), "mousetip_dongxin_0", "mousetip_dongxin_big", isPercent: true, "brightblue", "brightred", isInverse: false));
		_dataArray.Add(new SkillBreakEffectDisplayItem(34, LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "Name_34"), LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "ShortName_34"), "mousetip_maxpower", "mousetip_maxpower_big", isPercent: false, "brightblue", "brightred", isInverse: false));
		_dataArray.Add(new SkillBreakEffectDisplayItem(35, LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "Name_35"), LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "ShortName_35"), "mousetip_maxpower", "mousetip_maxpower_big", isPercent: false, "brightblue", "brightred", isInverse: false));
		_dataArray.Add(new SkillBreakEffectDisplayItem(36, LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "Name_36"), LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "ShortName_36"), "mousetip_maxpower", "mousetip_maxpower_big", isPercent: false, "brightblue", "brightred", isInverse: false));
		_dataArray.Add(new SkillBreakEffectDisplayItem(37, LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "Name_37"), LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "ShortName_37"), "mousetip_maxpower", "mousetip_maxpower_big", isPercent: false, "brightblue", "brightred", isInverse: false));
		_dataArray.Add(new SkillBreakEffectDisplayItem(38, LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "Name_38"), LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "ShortName_38"), "mousetip_attackrangeforward", "mousetip_attackrangeforward_big", isPercent: false, "brightblue", "brightred", isInverse: false));
		_dataArray.Add(new SkillBreakEffectDisplayItem(39, LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "Name_39"), LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "ShortName_39"), "mousetip_attackrangebackward", "mousetip_attackrangebackward_big", isPercent: false, "brightblue", "brightred", isInverse: false));
		_dataArray.Add(new SkillBreakEffectDisplayItem(40, LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "Name_40"), LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "ShortName_40"), "mousetip_makedirectdamage", "mousetip_makedirectdamage_big", isPercent: true, "brightblue", "brightred", isInverse: false));
		_dataArray.Add(new SkillBreakEffectDisplayItem(41, LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "Name_41"), LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "ShortName_41"), "mousetip_movecdbonus", "mousetip_movecdbonus_big", isPercent: true, "brightblue", "brightred", isInverse: false));
		_dataArray.Add(new SkillBreakEffectDisplayItem(42, LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "Name_42"), LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "ShortName_42"), "mousetip_pozhanjibie", "mousetip_pozhanjibie_big", isPercent: true, "brightblue", "brightred", isInverse: false));
		_dataArray.Add(new SkillBreakEffectDisplayItem(43, LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "Name_43"), LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "ShortName_43"), "mousetip_dianxuejibie", "mousetip_dianxuejibie_big", isPercent: true, "brightblue", "brightred", isInverse: false));
		_dataArray.Add(new SkillBreakEffectDisplayItem(44, LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "Name_44"), LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "ShortName_44"), "mousetip_fengjinggailv", "mousetip_fengjinggailv_big", isPercent: true, "brightblue", "brightred", isInverse: true));
		_dataArray.Add(new SkillBreakEffectDisplayItem(45, LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "Name_45"), LocalStringManager.GetConfig("SkillBreakEffectDisplay_language", "ShortName_45"), "mousetip_fengjingshijian", "mousetip_fengjingshijian_big", isPercent: true, "brightblue", "brightred", isInverse: true));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<SkillBreakEffectDisplayItem>(46);
		CreateItems0();
	}
}

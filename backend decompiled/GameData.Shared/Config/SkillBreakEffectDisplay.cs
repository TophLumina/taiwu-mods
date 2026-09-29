using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class SkillBreakEffectDisplay : ConfigData<SkillBreakEffectDisplayItem, sbyte>
{
	public static class DefKey
	{
		public const sbyte CostBreath = 0;

		public const sbyte CostStance = 1;

		public const sbyte AttainmentMusic = 2;

		public const sbyte AttainmentChess = 3;

		public const sbyte AttainmentPoem = 4;

		public const sbyte AttainmentPainting = 5;

		public const sbyte AttainmentMath = 6;

		public const sbyte AttainmentAppraisal = 7;

		public const sbyte AttainmentForging = 8;

		public const sbyte AttainmentWoodworking = 9;

		public const sbyte AttainmentMedicine = 10;

		public const sbyte AttainmentToxicology = 11;

		public const sbyte AttainmentWeaving = 12;

		public const sbyte AttainmentJade = 13;

		public const sbyte AttainmentTaoism = 14;

		public const sbyte AttainmentBuddhism = 15;

		public const sbyte AttainmentCooking = 16;

		public const sbyte AttainmentEclectic = 17;

		public const sbyte OuterInjuryStepHead = 18;

		public const sbyte OuterInjuryStepChest = 19;

		public const sbyte OuterInjuryStepBelly = 20;

		public const sbyte OuterInjuryStepLeftHand = 21;

		public const sbyte OuterInjuryStepRightHand = 22;

		public const sbyte OuterInjuryStepLeftLeg = 23;

		public const sbyte OuterInjuryStepRightLeg = 24;

		public const sbyte InnerInjuryStepHead = 25;

		public const sbyte InnerInjuryStepChest = 26;

		public const sbyte InnerInjuryStepBelly = 27;

		public const sbyte InnerInjuryStepLeftHand = 28;

		public const sbyte InnerInjuryStepRightHand = 29;

		public const sbyte InnerInjuryStepLeftLeg = 30;

		public const sbyte InnerInjuryStepRightLeg = 31;

		public const sbyte FatalStep = 32;

		public const sbyte MindStep = 33;

		public const sbyte EquippedPowerAttack = 34;

		public const sbyte EquippedPowerAgile = 35;

		public const sbyte EquippedPowerDefense = 36;

		public const sbyte EquippedPowerAssist = 37;

		public const sbyte AttackRangeForward = 38;

		public const sbyte AttackRangeBackward = 39;

		public const sbyte MakeDirectDamage = 40;

		public const sbyte MoveCdBonus = 41;

		public const sbyte FlawRecoverSpeed = 42;

		public const sbyte AcupointRecoverSpeed = 43;

		public const sbyte SilenceRate = 44;

		public const sbyte SilenceFrame = 45;
	}

	public static class DefValue
	{
		public static SkillBreakEffectDisplayItem CostBreath => Instance[(sbyte)0];

		public static SkillBreakEffectDisplayItem CostStance => Instance[(sbyte)1];

		public static SkillBreakEffectDisplayItem AttainmentMusic => Instance[(sbyte)2];

		public static SkillBreakEffectDisplayItem AttainmentChess => Instance[(sbyte)3];

		public static SkillBreakEffectDisplayItem AttainmentPoem => Instance[(sbyte)4];

		public static SkillBreakEffectDisplayItem AttainmentPainting => Instance[(sbyte)5];

		public static SkillBreakEffectDisplayItem AttainmentMath => Instance[(sbyte)6];

		public static SkillBreakEffectDisplayItem AttainmentAppraisal => Instance[(sbyte)7];

		public static SkillBreakEffectDisplayItem AttainmentForging => Instance[(sbyte)8];

		public static SkillBreakEffectDisplayItem AttainmentWoodworking => Instance[(sbyte)9];

		public static SkillBreakEffectDisplayItem AttainmentMedicine => Instance[(sbyte)10];

		public static SkillBreakEffectDisplayItem AttainmentToxicology => Instance[(sbyte)11];

		public static SkillBreakEffectDisplayItem AttainmentWeaving => Instance[(sbyte)12];

		public static SkillBreakEffectDisplayItem AttainmentJade => Instance[(sbyte)13];

		public static SkillBreakEffectDisplayItem AttainmentTaoism => Instance[(sbyte)14];

		public static SkillBreakEffectDisplayItem AttainmentBuddhism => Instance[(sbyte)15];

		public static SkillBreakEffectDisplayItem AttainmentCooking => Instance[(sbyte)16];

		public static SkillBreakEffectDisplayItem AttainmentEclectic => Instance[(sbyte)17];

		public static SkillBreakEffectDisplayItem OuterInjuryStepHead => Instance[(sbyte)18];

		public static SkillBreakEffectDisplayItem OuterInjuryStepChest => Instance[(sbyte)19];

		public static SkillBreakEffectDisplayItem OuterInjuryStepBelly => Instance[(sbyte)20];

		public static SkillBreakEffectDisplayItem OuterInjuryStepLeftHand => Instance[(sbyte)21];

		public static SkillBreakEffectDisplayItem OuterInjuryStepRightHand => Instance[(sbyte)22];

		public static SkillBreakEffectDisplayItem OuterInjuryStepLeftLeg => Instance[(sbyte)23];

		public static SkillBreakEffectDisplayItem OuterInjuryStepRightLeg => Instance[(sbyte)24];

		public static SkillBreakEffectDisplayItem InnerInjuryStepHead => Instance[(sbyte)25];

		public static SkillBreakEffectDisplayItem InnerInjuryStepChest => Instance[(sbyte)26];

		public static SkillBreakEffectDisplayItem InnerInjuryStepBelly => Instance[(sbyte)27];

		public static SkillBreakEffectDisplayItem InnerInjuryStepLeftHand => Instance[(sbyte)28];

		public static SkillBreakEffectDisplayItem InnerInjuryStepRightHand => Instance[(sbyte)29];

		public static SkillBreakEffectDisplayItem InnerInjuryStepLeftLeg => Instance[(sbyte)30];

		public static SkillBreakEffectDisplayItem InnerInjuryStepRightLeg => Instance[(sbyte)31];

		public static SkillBreakEffectDisplayItem FatalStep => Instance[(sbyte)32];

		public static SkillBreakEffectDisplayItem MindStep => Instance[(sbyte)33];

		public static SkillBreakEffectDisplayItem EquippedPowerAttack => Instance[(sbyte)34];

		public static SkillBreakEffectDisplayItem EquippedPowerAgile => Instance[(sbyte)35];

		public static SkillBreakEffectDisplayItem EquippedPowerDefense => Instance[(sbyte)36];

		public static SkillBreakEffectDisplayItem EquippedPowerAssist => Instance[(sbyte)37];

		public static SkillBreakEffectDisplayItem AttackRangeForward => Instance[(sbyte)38];

		public static SkillBreakEffectDisplayItem AttackRangeBackward => Instance[(sbyte)39];

		public static SkillBreakEffectDisplayItem MakeDirectDamage => Instance[(sbyte)40];

		public static SkillBreakEffectDisplayItem MoveCdBonus => Instance[(sbyte)41];

		public static SkillBreakEffectDisplayItem FlawRecoverSpeed => Instance[(sbyte)42];

		public static SkillBreakEffectDisplayItem AcupointRecoverSpeed => Instance[(sbyte)43];

		public static SkillBreakEffectDisplayItem SilenceRate => Instance[(sbyte)44];

		public static SkillBreakEffectDisplayItem SilenceFrame => Instance[(sbyte)45];
	}

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

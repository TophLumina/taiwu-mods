using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class CombatSkillProperty : ConfigData<CombatSkillPropertyItem, sbyte>
{
	public static class DefKey
	{
		public const sbyte Power = 0;

		public const sbyte MaxPower = 1;

		public const sbyte PrepareTotalProgress = 2;

		public const sbyte BreathStanceTotalCost = 3;

		public const sbyte BaseInnerRatio = 4;

		public const sbyte InnerRatioChangeRange = 5;

		public const sbyte TotalObtainableNeili = 6;

		public const sbyte ObtainedNeiliPerLoop = 7;

		public const sbyte FiveElementChangePerLoop = 8;

		public const sbyte GenericGrid = 9;

		public const sbyte MobilityCost = 10;

		public const sbyte AddMoveSpeedOnCast = 11;

		public const sbyte AddHitOnCast0 = 12;

		public const sbyte AddHitOnCast1 = 13;

		public const sbyte AddHitOnCast2 = 14;

		public const sbyte AddHitOnCast3 = 15;

		public const sbyte MobilityReduceSpeed = 16;

		public const sbyte MoveCostMobility = 17;

		public const sbyte AddOuterPenetrateResistOnCast = 18;

		public const sbyte AddInnerPenetrateResistOnCast = 19;

		public const sbyte AddAvoidOnCast0 = 20;

		public const sbyte AddAvoidOnCast1 = 21;

		public const sbyte AddAvoidOnCast2 = 22;

		public const sbyte AddAvoidOnCast3 = 23;

		public const sbyte FightBackDamage = 24;

		public const sbyte BounceRateOfOuterInjury = 25;

		public const sbyte BounceRateOfInnerInjury = 26;

		public const sbyte BounceDistance = 27;

		public const sbyte ContinuousFrames = 28;

		public const sbyte AddPercentPenetrate = 29;

		public const sbyte AddPercentTotalHit = 30;

		public const sbyte PerHitDamageRateDistribution0 = 31;

		public const sbyte PerHitDamageRateDistribution1 = 32;

		public const sbyte PerHitDamageRateDistribution2 = 33;

		public const sbyte DistanceAdditionWhenCast = 34;

		public const sbyte InjuryPartAtkRateDistributionChest = 35;

		public const sbyte InjuryPartAtkRateDistributionBelly = 36;

		public const sbyte InjuryPartAtkRateDistributionHead = 37;

		public const sbyte InjuryPartAtkRateDistributionHand = 38;

		public const sbyte InjuryPartAtkRateDistributionLeg = 39;

		public const sbyte AcupointLevel = 40;

		public const sbyte FlawLevel = 41;

		public const sbyte Poisons0 = 42;

		public const sbyte Poisons1 = 43;

		public const sbyte Poisons2 = 44;

		public const sbyte Poisons3 = 45;

		public const sbyte Poisons4 = 46;

		public const sbyte Poisons5 = 47;

		public const sbyte Requirements = 48;

		public const sbyte SlotCountAttack = 49;

		public const sbyte SlotCountAgile = 50;

		public const sbyte SlotCountDefense = 51;

		public const sbyte SlotCountAssist = 52;

		public const sbyte NeedTrick0 = 53;

		public const sbyte NeedTrick1 = 54;

		public const sbyte NeedTrick2 = 55;

		public const sbyte NeedTrick3 = 56;

		public const sbyte NeedTrick4 = 57;

		public const sbyte NeedTrick5 = 58;

		public const sbyte NeedTrick6 = 59;

		public const sbyte NeedTrick7 = 60;

		public const sbyte NeedTrick8 = 61;

		public const sbyte NeedTrick9 = 62;

		public const sbyte NeedTrick10 = 63;

		public const sbyte NeedTrick11 = 64;

		public const sbyte NeedTrick12 = 65;

		public const sbyte NeedTrick13 = 66;

		public const sbyte NeedTrick14 = 67;

		public const sbyte NeedTrick15 = 68;

		public const sbyte AgileJumpSpeed = 69;

		public const sbyte SilenceRate = 70;

		public const sbyte SilenceFrame = 71;

		public const sbyte AddPenetrate = 72;

		public const sbyte AddTotalHit = 73;
	}

	public static class DefValue
	{
		public static CombatSkillPropertyItem Power => Instance[(sbyte)0];

		public static CombatSkillPropertyItem MaxPower => Instance[(sbyte)1];

		public static CombatSkillPropertyItem PrepareTotalProgress => Instance[(sbyte)2];

		public static CombatSkillPropertyItem BreathStanceTotalCost => Instance[(sbyte)3];

		public static CombatSkillPropertyItem BaseInnerRatio => Instance[(sbyte)4];

		public static CombatSkillPropertyItem InnerRatioChangeRange => Instance[(sbyte)5];

		public static CombatSkillPropertyItem TotalObtainableNeili => Instance[(sbyte)6];

		public static CombatSkillPropertyItem ObtainedNeiliPerLoop => Instance[(sbyte)7];

		public static CombatSkillPropertyItem FiveElementChangePerLoop => Instance[(sbyte)8];

		public static CombatSkillPropertyItem GenericGrid => Instance[(sbyte)9];

		public static CombatSkillPropertyItem MobilityCost => Instance[(sbyte)10];

		public static CombatSkillPropertyItem AddMoveSpeedOnCast => Instance[(sbyte)11];

		public static CombatSkillPropertyItem AddHitOnCast0 => Instance[(sbyte)12];

		public static CombatSkillPropertyItem AddHitOnCast1 => Instance[(sbyte)13];

		public static CombatSkillPropertyItem AddHitOnCast2 => Instance[(sbyte)14];

		public static CombatSkillPropertyItem AddHitOnCast3 => Instance[(sbyte)15];

		public static CombatSkillPropertyItem MobilityReduceSpeed => Instance[(sbyte)16];

		public static CombatSkillPropertyItem MoveCostMobility => Instance[(sbyte)17];

		public static CombatSkillPropertyItem AddOuterPenetrateResistOnCast => Instance[(sbyte)18];

		public static CombatSkillPropertyItem AddInnerPenetrateResistOnCast => Instance[(sbyte)19];

		public static CombatSkillPropertyItem AddAvoidOnCast0 => Instance[(sbyte)20];

		public static CombatSkillPropertyItem AddAvoidOnCast1 => Instance[(sbyte)21];

		public static CombatSkillPropertyItem AddAvoidOnCast2 => Instance[(sbyte)22];

		public static CombatSkillPropertyItem AddAvoidOnCast3 => Instance[(sbyte)23];

		public static CombatSkillPropertyItem FightBackDamage => Instance[(sbyte)24];

		public static CombatSkillPropertyItem BounceRateOfOuterInjury => Instance[(sbyte)25];

		public static CombatSkillPropertyItem BounceRateOfInnerInjury => Instance[(sbyte)26];

		public static CombatSkillPropertyItem BounceDistance => Instance[(sbyte)27];

		public static CombatSkillPropertyItem ContinuousFrames => Instance[(sbyte)28];

		public static CombatSkillPropertyItem AddPercentPenetrate => Instance[(sbyte)29];

		public static CombatSkillPropertyItem AddPercentTotalHit => Instance[(sbyte)30];

		public static CombatSkillPropertyItem PerHitDamageRateDistribution0 => Instance[(sbyte)31];

		public static CombatSkillPropertyItem PerHitDamageRateDistribution1 => Instance[(sbyte)32];

		public static CombatSkillPropertyItem PerHitDamageRateDistribution2 => Instance[(sbyte)33];

		public static CombatSkillPropertyItem DistanceAdditionWhenCast => Instance[(sbyte)34];

		public static CombatSkillPropertyItem InjuryPartAtkRateDistributionChest => Instance[(sbyte)35];

		public static CombatSkillPropertyItem InjuryPartAtkRateDistributionBelly => Instance[(sbyte)36];

		public static CombatSkillPropertyItem InjuryPartAtkRateDistributionHead => Instance[(sbyte)37];

		public static CombatSkillPropertyItem InjuryPartAtkRateDistributionHand => Instance[(sbyte)38];

		public static CombatSkillPropertyItem InjuryPartAtkRateDistributionLeg => Instance[(sbyte)39];

		public static CombatSkillPropertyItem AcupointLevel => Instance[(sbyte)40];

		public static CombatSkillPropertyItem FlawLevel => Instance[(sbyte)41];

		public static CombatSkillPropertyItem Poisons0 => Instance[(sbyte)42];

		public static CombatSkillPropertyItem Poisons1 => Instance[(sbyte)43];

		public static CombatSkillPropertyItem Poisons2 => Instance[(sbyte)44];

		public static CombatSkillPropertyItem Poisons3 => Instance[(sbyte)45];

		public static CombatSkillPropertyItem Poisons4 => Instance[(sbyte)46];

		public static CombatSkillPropertyItem Poisons5 => Instance[(sbyte)47];

		public static CombatSkillPropertyItem Requirements => Instance[(sbyte)48];

		public static CombatSkillPropertyItem SlotCountAttack => Instance[(sbyte)49];

		public static CombatSkillPropertyItem SlotCountAgile => Instance[(sbyte)50];

		public static CombatSkillPropertyItem SlotCountDefense => Instance[(sbyte)51];

		public static CombatSkillPropertyItem SlotCountAssist => Instance[(sbyte)52];

		public static CombatSkillPropertyItem NeedTrick0 => Instance[(sbyte)53];

		public static CombatSkillPropertyItem NeedTrick1 => Instance[(sbyte)54];

		public static CombatSkillPropertyItem NeedTrick2 => Instance[(sbyte)55];

		public static CombatSkillPropertyItem NeedTrick3 => Instance[(sbyte)56];

		public static CombatSkillPropertyItem NeedTrick4 => Instance[(sbyte)57];

		public static CombatSkillPropertyItem NeedTrick5 => Instance[(sbyte)58];

		public static CombatSkillPropertyItem NeedTrick6 => Instance[(sbyte)59];

		public static CombatSkillPropertyItem NeedTrick7 => Instance[(sbyte)60];

		public static CombatSkillPropertyItem NeedTrick8 => Instance[(sbyte)61];

		public static CombatSkillPropertyItem NeedTrick9 => Instance[(sbyte)62];

		public static CombatSkillPropertyItem NeedTrick10 => Instance[(sbyte)63];

		public static CombatSkillPropertyItem NeedTrick11 => Instance[(sbyte)64];

		public static CombatSkillPropertyItem NeedTrick12 => Instance[(sbyte)65];

		public static CombatSkillPropertyItem NeedTrick13 => Instance[(sbyte)66];

		public static CombatSkillPropertyItem NeedTrick14 => Instance[(sbyte)67];

		public static CombatSkillPropertyItem NeedTrick15 => Instance[(sbyte)68];

		public static CombatSkillPropertyItem AgileJumpSpeed => Instance[(sbyte)69];

		public static CombatSkillPropertyItem SilenceRate => Instance[(sbyte)70];

		public static CombatSkillPropertyItem SilenceFrame => Instance[(sbyte)71];

		public static CombatSkillPropertyItem AddPenetrate => Instance[(sbyte)72];

		public static CombatSkillPropertyItem AddTotalHit => Instance[(sbyte)73];
	}

	public static CombatSkillProperty Instance = new CombatSkillProperty();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "TemplateId", "PlusColor", "MinusColor", "TipsSmallIcon", "TipsIcon" };

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
		_dataArray.Add(new CombatSkillPropertyItem(0, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_0"), isPercent: true, "brightblue", "brightred", "mousetip_power", "mousetip_power_big", isInverse: false, 0, isDisplaySpecially: true));
		_dataArray.Add(new CombatSkillPropertyItem(1, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_1"), isPercent: true, "brightblue", "brightred", "mousetip_maxpower", "mousetip_maxpower_big", isInverse: false, 0, isDisplaySpecially: true));
		_dataArray.Add(new CombatSkillPropertyItem(2, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_2"), isPercent: true, "brightred", "brightblue", "mousetip_ciyao_2", "mousetip_ciyao_big_2", isInverse: true, 0, isDisplaySpecially: false));
		_dataArray.Add(new CombatSkillPropertyItem(3, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_3"), isPercent: true, "brightred", "brightblue", null, null, isInverse: true, 0, isDisplaySpecially: true));
		_dataArray.Add(new CombatSkillPropertyItem(4, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_4"), isPercent: true, "yellow", "yellow", "mousetip_neigongbili", "mousetip_neigongbili_big", isInverse: false, 0, isDisplaySpecially: false));
		_dataArray.Add(new CombatSkillPropertyItem(5, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_5"), isPercent: true, "brightblue", "brightred", null, "mousetip_neigongzhuanhuan_big", isInverse: false, 0, isDisplaySpecially: false));
		_dataArray.Add(new CombatSkillPropertyItem(6, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_6"), isPercent: false, "brightblue", "brightred", "mousetip_neilizongliang", "mousetip_neilizongliang_big", isInverse: false, 0, isDisplaySpecially: false));
		_dataArray.Add(new CombatSkillPropertyItem(7, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_7"), isPercent: false, "brightblue", "brightred", "mousetip_huoquneili", "mousetip_huoquneili_big", isInverse: false, 0, isDisplaySpecially: false));
		_dataArray.Add(new CombatSkillPropertyItem(8, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_8"), isPercent: false, "yellow", "yellow", null, "mousetip_wuxingzhuanyi_big", isInverse: false, 0, isDisplaySpecially: false));
		_dataArray.Add(new CombatSkillPropertyItem(9, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_9"), isPercent: false, "brightblue", "brightred", "mousetip_zhenqi_4", "mousetip_zhenqi_big_4", isInverse: false, 0, isDisplaySpecially: true));
		_dataArray.Add(new CombatSkillPropertyItem(10, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_10"), isPercent: true, "brightred", "brightblue", "mousetip_mobilitycost", "mousetip_mobilitycost_big", isInverse: true, 0, isDisplaySpecially: true));
		_dataArray.Add(new CombatSkillPropertyItem(11, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_11"), isPercent: true, "brightblue", "brightred", "mousetip_ciyao_1", "mousetip_ciyao_big_1", isInverse: false, 0, isDisplaySpecially: false));
		_dataArray.Add(new CombatSkillPropertyItem(12, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_12"), isPercent: true, "brightblue", "brightred", "mousetip_mingzhong_0", "mousetip_mingzhong_big_0", isInverse: false, 0, isDisplaySpecially: true));
		_dataArray.Add(new CombatSkillPropertyItem(13, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_13"), isPercent: true, "brightblue", "brightred", "mousetip_mingzhong_1", "mousetip_mingzhong_big_1", isInverse: false, 0, isDisplaySpecially: true));
		_dataArray.Add(new CombatSkillPropertyItem(14, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_14"), isPercent: true, "brightblue", "brightred", "mousetip_mingzhong_2", "mousetip_mingzhong_big_2", isInverse: false, 0, isDisplaySpecially: true));
		_dataArray.Add(new CombatSkillPropertyItem(15, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_15"), isPercent: true, "brightblue", "brightred", "mousetip_mingzhong_3", "mousetip_mingzhong_big_3", isInverse: false, 0, isDisplaySpecially: true));
		_dataArray.Add(new CombatSkillPropertyItem(16, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_16"), isPercent: true, "brightred", "brightblue", "mousetip_shenfachixu", "mousetip_shenfachixu_big", isInverse: true, 0, isDisplaySpecially: false));
		_dataArray.Add(new CombatSkillPropertyItem(17, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_17"), isPercent: true, "brightred", "brightblue", "mousetip_shenfaxiaohao", "mousetip_shenfaxiaohao_big", isInverse: true, 0, isDisplaySpecially: false));
		_dataArray.Add(new CombatSkillPropertyItem(18, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_18"), isPercent: true, "brightblue", "brightred", "mousetip_fangyu_0", "mousetip_fangyu_big_0", isInverse: false, 0, isDisplaySpecially: true));
		_dataArray.Add(new CombatSkillPropertyItem(19, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_19"), isPercent: true, "brightblue", "brightred", "mousetip_fangyu_1", "mousetip_fangyu_big_1", isInverse: false, 0, isDisplaySpecially: true));
		_dataArray.Add(new CombatSkillPropertyItem(20, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_20"), isPercent: true, "brightblue", "brightred", "mousetip_huajie_0", "mousetip_huajie_big_0", isInverse: false, 0, isDisplaySpecially: true));
		_dataArray.Add(new CombatSkillPropertyItem(21, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_21"), isPercent: true, "brightblue", "brightred", "mousetip_huajie_1", "mousetip_huajie_big_1", isInverse: false, 0, isDisplaySpecially: true));
		_dataArray.Add(new CombatSkillPropertyItem(22, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_22"), isPercent: true, "brightblue", "brightred", "mousetip_huajie_2", "mousetip_huajie_big_2", isInverse: false, 0, isDisplaySpecially: true));
		_dataArray.Add(new CombatSkillPropertyItem(23, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_23"), isPercent: true, "brightblue", "brightred", "mousetip_huajie_3", "mousetip_huajie_big_3", isInverse: false, 0, isDisplaySpecially: true));
		_dataArray.Add(new CombatSkillPropertyItem(24, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_24"), isPercent: true, "brightblue", "brightred", "mousetip_fightbackdamage", "mousetip_fightbackdamage_big", isInverse: false, 0, isDisplaySpecially: true));
		_dataArray.Add(new CombatSkillPropertyItem(25, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_25"), isPercent: true, "brightblue", "brightred", "mousetip_waishang", "mousetip_waishang_big", isInverse: false, 0, isDisplaySpecially: true));
		_dataArray.Add(new CombatSkillPropertyItem(26, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_26"), isPercent: true, "brightblue", "brightred", "mousetip_neishang", "mousetip_neishang_big", isInverse: false, 0, isDisplaySpecially: true));
		_dataArray.Add(new CombatSkillPropertyItem(27, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_27"), isPercent: false, "brightblue", "brightred", null, null, isInverse: false, -10, isDisplaySpecially: true));
		_dataArray.Add(new CombatSkillPropertyItem(28, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_28"), isPercent: true, "brightblue", "brightred", null, null, isInverse: false, 0, isDisplaySpecially: true));
		_dataArray.Add(new CombatSkillPropertyItem(29, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_29"), isPercent: true, "brightblue", "brightred", null, null, isInverse: false, 0, isDisplaySpecially: true));
		_dataArray.Add(new CombatSkillPropertyItem(30, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_30"), isPercent: true, "brightblue", "brightred", null, null, isInverse: false, 0, isDisplaySpecially: true));
		_dataArray.Add(new CombatSkillPropertyItem(31, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_31"), isPercent: false, "yellow", "yellow", null, null, isInverse: false, 0, isDisplaySpecially: true));
		_dataArray.Add(new CombatSkillPropertyItem(32, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_32"), isPercent: false, "yellow", "yellow", null, null, isInverse: false, 0, isDisplaySpecially: true));
		_dataArray.Add(new CombatSkillPropertyItem(33, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_33"), isPercent: false, "yellow", "yellow", null, null, isInverse: false, 0, isDisplaySpecially: true));
		_dataArray.Add(new CombatSkillPropertyItem(34, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_34"), isPercent: false, "brightblue", "brightred", null, null, isInverse: false, -10, isDisplaySpecially: true));
		_dataArray.Add(new CombatSkillPropertyItem(35, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_35"), isPercent: true, "yellow", "yellow", null, null, isInverse: false, 0, isDisplaySpecially: true));
		_dataArray.Add(new CombatSkillPropertyItem(36, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_36"), isPercent: true, "yellow", "yellow", null, null, isInverse: false, 0, isDisplaySpecially: true));
		_dataArray.Add(new CombatSkillPropertyItem(37, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_37"), isPercent: true, "yellow", "yellow", null, null, isInverse: false, 0, isDisplaySpecially: true));
		_dataArray.Add(new CombatSkillPropertyItem(38, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_38"), isPercent: true, "yellow", "yellow", null, null, isInverse: false, 0, isDisplaySpecially: true));
		_dataArray.Add(new CombatSkillPropertyItem(39, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_39"), isPercent: true, "yellow", "yellow", null, null, isInverse: false, 0, isDisplaySpecially: true));
		_dataArray.Add(new CombatSkillPropertyItem(40, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_40"), isPercent: false, "brightblue", "brightred", "mousetip_dianxuejibie", "mousetip_dianxuejibie_big", isInverse: false, 0, isDisplaySpecially: false));
		_dataArray.Add(new CombatSkillPropertyItem(41, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_41"), isPercent: false, "brightblue", "brightred", "mousetip_pozhanjibie", "mousetip_pozhanjibie_big", isInverse: false, 0, isDisplaySpecially: false));
		_dataArray.Add(new CombatSkillPropertyItem(42, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_42"), isPercent: true, "brightblue", "brightred", "mousetip_duxing_0", "mousetip_duxing_big_0", isInverse: false, 0, isDisplaySpecially: true));
		_dataArray.Add(new CombatSkillPropertyItem(43, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_43"), isPercent: true, "brightblue", "brightred", "mousetip_duxing_1", "mousetip_duxing_big_1", isInverse: false, 0, isDisplaySpecially: true));
		_dataArray.Add(new CombatSkillPropertyItem(44, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_44"), isPercent: true, "brightblue", "brightred", "mousetip_duxing_2", "mousetip_duxing_big_2", isInverse: false, 0, isDisplaySpecially: true));
		_dataArray.Add(new CombatSkillPropertyItem(45, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_45"), isPercent: true, "brightblue", "brightred", "mousetip_duxing_3", "mousetip_duxing_big_3", isInverse: false, 0, isDisplaySpecially: true));
		_dataArray.Add(new CombatSkillPropertyItem(46, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_46"), isPercent: true, "brightblue", "brightred", "mousetip_duxing_4", "mousetip_duxing_big_4", isInverse: false, 0, isDisplaySpecially: true));
		_dataArray.Add(new CombatSkillPropertyItem(47, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_47"), isPercent: true, "brightblue", "brightred", "mousetip_duxing_5", "mousetip_duxing_big_5", isInverse: false, 0, isDisplaySpecially: true));
		_dataArray.Add(new CombatSkillPropertyItem(48, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_48"), isPercent: true, "brightred", "brightblue", "mousetip_requirements", "mousetip_requirements_big", isInverse: true, 0, isDisplaySpecially: true));
		_dataArray.Add(new CombatSkillPropertyItem(49, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_49"), isPercent: false, "brightblue", "brightred", "mousetip_zhenqi_0", "mousetip_zhenqi_big_0", isInverse: false, 0, isDisplaySpecially: true));
		_dataArray.Add(new CombatSkillPropertyItem(50, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_50"), isPercent: false, "brightblue", "brightred", "mousetip_zhenqi_1", "mousetip_zhenqi_big_1", isInverse: false, 0, isDisplaySpecially: true));
		_dataArray.Add(new CombatSkillPropertyItem(51, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_51"), isPercent: false, "brightblue", "brightred", "mousetip_zhenqi_2", "mousetip_zhenqi_big_2", isInverse: false, 0, isDisplaySpecially: true));
		_dataArray.Add(new CombatSkillPropertyItem(52, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_52"), isPercent: false, "brightblue", "brightred", "mousetip_zhenqi_3", "mousetip_zhenqi_big_3", isInverse: false, 0, isDisplaySpecially: true));
		_dataArray.Add(new CombatSkillPropertyItem(53, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_53"), isPercent: false, "brightred", "brightblue", null, null, isInverse: true, 0, isDisplaySpecially: true));
		_dataArray.Add(new CombatSkillPropertyItem(54, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_54"), isPercent: false, "brightred", "brightblue", null, null, isInverse: true, 0, isDisplaySpecially: true));
		_dataArray.Add(new CombatSkillPropertyItem(55, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_55"), isPercent: false, "brightred", "brightblue", null, null, isInverse: true, 0, isDisplaySpecially: true));
		_dataArray.Add(new CombatSkillPropertyItem(56, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_56"), isPercent: false, "brightred", "brightblue", null, null, isInverse: true, 0, isDisplaySpecially: true));
		_dataArray.Add(new CombatSkillPropertyItem(57, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_57"), isPercent: false, "brightred", "brightblue", null, null, isInverse: true, 0, isDisplaySpecially: true));
		_dataArray.Add(new CombatSkillPropertyItem(58, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_58"), isPercent: false, "brightred", "brightblue", null, null, isInverse: true, 0, isDisplaySpecially: true));
		_dataArray.Add(new CombatSkillPropertyItem(59, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_59"), isPercent: false, "brightred", "brightblue", null, null, isInverse: true, 0, isDisplaySpecially: true));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new CombatSkillPropertyItem(60, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_60"), isPercent: false, "brightred", "brightblue", null, null, isInverse: true, 0, isDisplaySpecially: true));
		_dataArray.Add(new CombatSkillPropertyItem(61, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_61"), isPercent: false, "brightred", "brightblue", null, null, isInverse: true, 0, isDisplaySpecially: true));
		_dataArray.Add(new CombatSkillPropertyItem(62, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_62"), isPercent: false, "brightred", "brightblue", null, null, isInverse: true, 0, isDisplaySpecially: true));
		_dataArray.Add(new CombatSkillPropertyItem(63, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_63"), isPercent: false, "brightred", "brightblue", null, null, isInverse: true, 0, isDisplaySpecially: true));
		_dataArray.Add(new CombatSkillPropertyItem(64, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_64"), isPercent: false, "brightred", "brightblue", null, null, isInverse: true, 0, isDisplaySpecially: true));
		_dataArray.Add(new CombatSkillPropertyItem(65, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_65"), isPercent: false, "brightred", "brightblue", null, null, isInverse: true, 0, isDisplaySpecially: true));
		_dataArray.Add(new CombatSkillPropertyItem(66, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_66"), isPercent: false, "brightred", "brightblue", null, null, isInverse: true, 0, isDisplaySpecially: true));
		_dataArray.Add(new CombatSkillPropertyItem(67, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_67"), isPercent: false, "brightred", "brightblue", null, null, isInverse: true, 0, isDisplaySpecially: true));
		_dataArray.Add(new CombatSkillPropertyItem(68, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_68"), isPercent: false, "brightred", "brightblue", null, null, isInverse: true, 0, isDisplaySpecially: true));
		_dataArray.Add(new CombatSkillPropertyItem(69, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_69"), isPercent: true, "brightblue", "brightred", null, "mousetip_xulishijian_big", isInverse: false, 0, isDisplaySpecially: false));
		_dataArray.Add(new CombatSkillPropertyItem(70, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_70"), isPercent: true, "brightred", "brightblue", "mousetip_fengjinggailv", "mousetip_fengjinggailv_big", isInverse: true, 0, isDisplaySpecially: false));
		_dataArray.Add(new CombatSkillPropertyItem(71, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_71"), isPercent: false, "brightred", "brightblue", "mousetip_fengjingshijian", "mousetip_fengjingshijian_big", isInverse: true, 0, isDisplaySpecially: false));
		_dataArray.Add(new CombatSkillPropertyItem(72, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_72"), isPercent: false, "brightblue", "brightred", "ui9_mousetip_increaseattack", "ui9_mousetip_increaseattack_big", isInverse: false, 0, isDisplaySpecially: true));
		_dataArray.Add(new CombatSkillPropertyItem(73, LocalStringManager.GetConfig("CombatSkillProperty_language", "Name_73"), isPercent: false, "brightblue", "brightred", "ui9_mousetip_increasehitrate", "ui9_mousetip_increasehitrate_big", isInverse: false, 0, isDisplaySpecially: true));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<CombatSkillPropertyItem>(74);
		CreateItems0();
		CreateItems1();
	}
}

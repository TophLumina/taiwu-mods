using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class CombatSkillProperty : ConfigData<CombatSkillPropertyItem, sbyte>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 当前威力
		/// </summary>
		public const sbyte Power = 0;

		/// <summary>
		/// 威力上限
		/// </summary>
		public const sbyte MaxPower = 1;

		/// <summary>
		/// 施展速度
		/// </summary>
		public const sbyte PrepareTotalProgress = 2;

		/// <summary>
		/// 气势消耗
		/// </summary>
		public const sbyte BreathStanceTotalCost = 3;

		/// <summary>
		/// 内功比例
		/// </summary>
		public const sbyte BaseInnerRatio = 4;

		/// <summary>
		/// 内功转换
		/// </summary>
		public const sbyte InnerRatioChangeRange = 5;

		/// <summary>
		/// 内力总量
		/// </summary>
		public const sbyte TotalObtainableNeili = 6;

		/// <summary>
		/// 获取内力
		/// </summary>
		public const sbyte ObtainedNeiliPerLoop = 7;

		/// <summary>
		/// 五行转移
		/// </summary>
		public const sbyte FiveElementChangePerLoop = 8;

		/// <summary>
		/// 万用格数
		/// </summary>
		public const sbyte GenericGrid = 9;

		/// <summary>
		/// 消耗脚力
		/// </summary>
		public const sbyte MobilityCost = 10;

		/// <summary>
		/// 移动速度
		/// </summary>
		public const sbyte AddMoveSpeedOnCast = 11;

		/// <summary>
		/// 增加力道
		/// </summary>
		public const sbyte AddHitOnCast0 = 12;

		/// <summary>
		/// 增加精妙
		/// </summary>
		public const sbyte AddHitOnCast1 = 13;

		/// <summary>
		/// 增加迅疾
		/// </summary>
		public const sbyte AddHitOnCast2 = 14;

		/// <summary>
		/// 增加动心
		/// </summary>
		public const sbyte AddHitOnCast3 = 15;

		/// <summary>
		/// 身法持续
		/// </summary>
		public const sbyte MobilityReduceSpeed = 16;

		/// <summary>
		/// 身法消耗
		/// </summary>
		public const sbyte MoveCostMobility = 17;

		/// <summary>
		/// 增加御体
		/// </summary>
		public const sbyte AddOuterPenetrateResistOnCast = 18;

		/// <summary>
		/// 增加御气
		/// </summary>
		public const sbyte AddInnerPenetrateResistOnCast = 19;

		/// <summary>
		/// 增加卸力
		/// </summary>
		public const sbyte AddAvoidOnCast0 = 20;

		/// <summary>
		/// 增加拆招
		/// </summary>
		public const sbyte AddAvoidOnCast1 = 21;

		/// <summary>
		/// 增加闪避
		/// </summary>
		public const sbyte AddAvoidOnCast2 = 22;

		/// <summary>
		/// 增加守心
		/// </summary>
		public const sbyte AddAvoidOnCast3 = 23;

		/// <summary>
		/// 反击威力
		/// </summary>
		public const sbyte FightBackDamage = 24;

		/// <summary>
		/// 外伤反震
		/// </summary>
		public const sbyte BounceRateOfOuterInjury = 25;

		/// <summary>
		/// 内伤反震
		/// </summary>
		public const sbyte BounceRateOfInnerInjury = 26;

		/// <summary>
		/// 反震距离
		/// </summary>
		public const sbyte BounceDistance = 27;

		/// <summary>
		/// 持续时间
		/// </summary>
		public const sbyte ContinuousFrames = 28;

		/// <summary>
		/// 破体破气
		/// </summary>
		public const sbyte AddPercentPenetrate = 29;

		/// <summary>
		/// 总体命中
		/// </summary>
		public const sbyte AddPercentTotalHit = 30;

		/// <summary>
		/// 力道成数
		/// </summary>
		public const sbyte PerHitDamageRateDistribution0 = 31;

		/// <summary>
		/// 精妙成数
		/// </summary>
		public const sbyte PerHitDamageRateDistribution1 = 32;

		/// <summary>
		/// 迅疾成数
		/// </summary>
		public const sbyte PerHitDamageRateDistribution2 = 33;

		/// <summary>
		/// 攻击范围
		/// </summary>
		public const sbyte DistanceAdditionWhenCast = 34;

		/// <summary>
		/// 攻击胸背
		/// </summary>
		public const sbyte InjuryPartAtkRateDistributionChest = 35;

		/// <summary>
		/// 攻击腰腹
		/// </summary>
		public const sbyte InjuryPartAtkRateDistributionBelly = 36;

		/// <summary>
		/// 攻击头部
		/// </summary>
		public const sbyte InjuryPartAtkRateDistributionHead = 37;

		/// <summary>
		/// 攻击双手
		/// </summary>
		public const sbyte InjuryPartAtkRateDistributionHand = 38;

		/// <summary>
		/// 攻击双足
		/// </summary>
		public const sbyte InjuryPartAtkRateDistributionLeg = 39;

		/// <summary>
		/// 点穴级别
		/// </summary>
		public const sbyte AcupointLevel = 40;

		/// <summary>
		/// 破绽级别
		/// </summary>
		public const sbyte FlawLevel = 41;

		/// <summary>
		/// 施加烈毒
		/// </summary>
		public const sbyte Poisons0 = 42;

		/// <summary>
		/// 施加郁毒
		/// </summary>
		public const sbyte Poisons1 = 43;

		/// <summary>
		/// 施加寒毒
		/// </summary>
		public const sbyte Poisons2 = 44;

		/// <summary>
		/// 施加赤毒
		/// </summary>
		public const sbyte Poisons3 = 45;

		/// <summary>
		/// 施加腐毒
		/// </summary>
		public const sbyte Poisons4 = 46;

		/// <summary>
		/// 施加幻毒
		/// </summary>
		public const sbyte Poisons5 = 47;

		/// <summary>
		/// 使用需求
		/// </summary>
		public const sbyte Requirements = 48;

		/// <summary>
		/// 摧破栏位
		/// </summary>
		public const sbyte SlotCountAttack = 49;

		/// <summary>
		/// 轻灵栏位
		/// </summary>
		public const sbyte SlotCountAgile = 50;

		/// <summary>
		/// 护体栏位
		/// </summary>
		public const sbyte SlotCountDefense = 51;

		/// <summary>
		/// 奇窍栏位
		/// </summary>
		public const sbyte SlotCountAssist = 52;

		/// <summary>
		/// 需要掷式
		/// </summary>
		public const sbyte NeedTrick0 = 53;

		/// <summary>
		/// 需要弹式
		/// </summary>
		public const sbyte NeedTrick1 = 54;

		/// <summary>
		/// 需要御式
		/// </summary>
		public const sbyte NeedTrick2 = 55;

		/// <summary>
		/// 需要劈式
		/// </summary>
		public const sbyte NeedTrick3 = 56;

		/// <summary>
		/// 需要刺式
		/// </summary>
		public const sbyte NeedTrick4 = 57;

		/// <summary>
		/// 需要撩式
		/// </summary>
		public const sbyte NeedTrick5 = 58;

		/// <summary>
		/// 需要崩式
		/// </summary>
		public const sbyte NeedTrick6 = 59;

		/// <summary>
		/// 需要点式
		/// </summary>
		public const sbyte NeedTrick7 = 60;

		/// <summary>
		/// 需要拿式
		/// </summary>
		public const sbyte NeedTrick8 = 61;

		/// <summary>
		/// 需要音式
		/// </summary>
		public const sbyte NeedTrick9 = 62;

		/// <summary>
		/// 需要缠式
		/// </summary>
		public const sbyte NeedTrick10 = 63;

		/// <summary>
		/// 需要咒式
		/// </summary>
		public const sbyte NeedTrick11 = 64;

		/// <summary>
		/// 需要机式
		/// </summary>
		public const sbyte NeedTrick12 = 65;

		/// <summary>
		/// 需要药式
		/// </summary>
		public const sbyte NeedTrick13 = 66;

		/// <summary>
		/// 需要毒式
		/// </summary>
		public const sbyte NeedTrick14 = 67;

		/// <summary>
		/// 需要扫式
		/// </summary>
		public const sbyte NeedTrick15 = 68;

		/// <summary>
		/// 蓄力进度
		/// </summary>
		public const sbyte AgileJumpSpeed = 69;

		/// <summary>
		/// 封禁概率
		/// </summary>
		public const sbyte SilenceRate = 70;

		/// <summary>
		/// 封禁帧数
		/// </summary>
		public const sbyte SilenceFrame = 71;

		/// <summary>
		/// 增加攻击
		/// </summary>
		public const sbyte AddPenetrate = 72;

		/// <summary>
		/// 增加命中
		/// </summary>
		public const sbyte AddTotalHit = 73;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 当前威力
		/// </summary>
		public static CombatSkillPropertyItem Power => Instance[(sbyte)0];

		/// <summary>
		/// 威力上限
		/// </summary>
		public static CombatSkillPropertyItem MaxPower => Instance[(sbyte)1];

		/// <summary>
		/// 施展速度
		/// </summary>
		public static CombatSkillPropertyItem PrepareTotalProgress => Instance[(sbyte)2];

		/// <summary>
		/// 气势消耗
		/// </summary>
		public static CombatSkillPropertyItem BreathStanceTotalCost => Instance[(sbyte)3];

		/// <summary>
		/// 内功比例
		/// </summary>
		public static CombatSkillPropertyItem BaseInnerRatio => Instance[(sbyte)4];

		/// <summary>
		/// 内功转换
		/// </summary>
		public static CombatSkillPropertyItem InnerRatioChangeRange => Instance[(sbyte)5];

		/// <summary>
		/// 内力总量
		/// </summary>
		public static CombatSkillPropertyItem TotalObtainableNeili => Instance[(sbyte)6];

		/// <summary>
		/// 获取内力
		/// </summary>
		public static CombatSkillPropertyItem ObtainedNeiliPerLoop => Instance[(sbyte)7];

		/// <summary>
		/// 五行转移
		/// </summary>
		public static CombatSkillPropertyItem FiveElementChangePerLoop => Instance[(sbyte)8];

		/// <summary>
		/// 万用格数
		/// </summary>
		public static CombatSkillPropertyItem GenericGrid => Instance[(sbyte)9];

		/// <summary>
		/// 消耗脚力
		/// </summary>
		public static CombatSkillPropertyItem MobilityCost => Instance[(sbyte)10];

		/// <summary>
		/// 移动速度
		/// </summary>
		public static CombatSkillPropertyItem AddMoveSpeedOnCast => Instance[(sbyte)11];

		/// <summary>
		/// 增加力道
		/// </summary>
		public static CombatSkillPropertyItem AddHitOnCast0 => Instance[(sbyte)12];

		/// <summary>
		/// 增加精妙
		/// </summary>
		public static CombatSkillPropertyItem AddHitOnCast1 => Instance[(sbyte)13];

		/// <summary>
		/// 增加迅疾
		/// </summary>
		public static CombatSkillPropertyItem AddHitOnCast2 => Instance[(sbyte)14];

		/// <summary>
		/// 增加动心
		/// </summary>
		public static CombatSkillPropertyItem AddHitOnCast3 => Instance[(sbyte)15];

		/// <summary>
		/// 身法持续
		/// </summary>
		public static CombatSkillPropertyItem MobilityReduceSpeed => Instance[(sbyte)16];

		/// <summary>
		/// 身法消耗
		/// </summary>
		public static CombatSkillPropertyItem MoveCostMobility => Instance[(sbyte)17];

		/// <summary>
		/// 增加御体
		/// </summary>
		public static CombatSkillPropertyItem AddOuterPenetrateResistOnCast => Instance[(sbyte)18];

		/// <summary>
		/// 增加御气
		/// </summary>
		public static CombatSkillPropertyItem AddInnerPenetrateResistOnCast => Instance[(sbyte)19];

		/// <summary>
		/// 增加卸力
		/// </summary>
		public static CombatSkillPropertyItem AddAvoidOnCast0 => Instance[(sbyte)20];

		/// <summary>
		/// 增加拆招
		/// </summary>
		public static CombatSkillPropertyItem AddAvoidOnCast1 => Instance[(sbyte)21];

		/// <summary>
		/// 增加闪避
		/// </summary>
		public static CombatSkillPropertyItem AddAvoidOnCast2 => Instance[(sbyte)22];

		/// <summary>
		/// 增加守心
		/// </summary>
		public static CombatSkillPropertyItem AddAvoidOnCast3 => Instance[(sbyte)23];

		/// <summary>
		/// 反击威力
		/// </summary>
		public static CombatSkillPropertyItem FightBackDamage => Instance[(sbyte)24];

		/// <summary>
		/// 外伤反震
		/// </summary>
		public static CombatSkillPropertyItem BounceRateOfOuterInjury => Instance[(sbyte)25];

		/// <summary>
		/// 内伤反震
		/// </summary>
		public static CombatSkillPropertyItem BounceRateOfInnerInjury => Instance[(sbyte)26];

		/// <summary>
		/// 反震距离
		/// </summary>
		public static CombatSkillPropertyItem BounceDistance => Instance[(sbyte)27];

		/// <summary>
		/// 持续时间
		/// </summary>
		public static CombatSkillPropertyItem ContinuousFrames => Instance[(sbyte)28];

		/// <summary>
		/// 破体破气
		/// </summary>
		public static CombatSkillPropertyItem AddPercentPenetrate => Instance[(sbyte)29];

		/// <summary>
		/// 总体命中
		/// </summary>
		public static CombatSkillPropertyItem AddPercentTotalHit => Instance[(sbyte)30];

		/// <summary>
		/// 力道成数
		/// </summary>
		public static CombatSkillPropertyItem PerHitDamageRateDistribution0 => Instance[(sbyte)31];

		/// <summary>
		/// 精妙成数
		/// </summary>
		public static CombatSkillPropertyItem PerHitDamageRateDistribution1 => Instance[(sbyte)32];

		/// <summary>
		/// 迅疾成数
		/// </summary>
		public static CombatSkillPropertyItem PerHitDamageRateDistribution2 => Instance[(sbyte)33];

		/// <summary>
		/// 攻击范围
		/// </summary>
		public static CombatSkillPropertyItem DistanceAdditionWhenCast => Instance[(sbyte)34];

		/// <summary>
		/// 攻击胸背
		/// </summary>
		public static CombatSkillPropertyItem InjuryPartAtkRateDistributionChest => Instance[(sbyte)35];

		/// <summary>
		/// 攻击腰腹
		/// </summary>
		public static CombatSkillPropertyItem InjuryPartAtkRateDistributionBelly => Instance[(sbyte)36];

		/// <summary>
		/// 攻击头部
		/// </summary>
		public static CombatSkillPropertyItem InjuryPartAtkRateDistributionHead => Instance[(sbyte)37];

		/// <summary>
		/// 攻击双手
		/// </summary>
		public static CombatSkillPropertyItem InjuryPartAtkRateDistributionHand => Instance[(sbyte)38];

		/// <summary>
		/// 攻击双足
		/// </summary>
		public static CombatSkillPropertyItem InjuryPartAtkRateDistributionLeg => Instance[(sbyte)39];

		/// <summary>
		/// 点穴级别
		/// </summary>
		public static CombatSkillPropertyItem AcupointLevel => Instance[(sbyte)40];

		/// <summary>
		/// 破绽级别
		/// </summary>
		public static CombatSkillPropertyItem FlawLevel => Instance[(sbyte)41];

		/// <summary>
		/// 施加烈毒
		/// </summary>
		public static CombatSkillPropertyItem Poisons0 => Instance[(sbyte)42];

		/// <summary>
		/// 施加郁毒
		/// </summary>
		public static CombatSkillPropertyItem Poisons1 => Instance[(sbyte)43];

		/// <summary>
		/// 施加寒毒
		/// </summary>
		public static CombatSkillPropertyItem Poisons2 => Instance[(sbyte)44];

		/// <summary>
		/// 施加赤毒
		/// </summary>
		public static CombatSkillPropertyItem Poisons3 => Instance[(sbyte)45];

		/// <summary>
		/// 施加腐毒
		/// </summary>
		public static CombatSkillPropertyItem Poisons4 => Instance[(sbyte)46];

		/// <summary>
		/// 施加幻毒
		/// </summary>
		public static CombatSkillPropertyItem Poisons5 => Instance[(sbyte)47];

		/// <summary>
		/// 使用需求
		/// </summary>
		public static CombatSkillPropertyItem Requirements => Instance[(sbyte)48];

		/// <summary>
		/// 摧破栏位
		/// </summary>
		public static CombatSkillPropertyItem SlotCountAttack => Instance[(sbyte)49];

		/// <summary>
		/// 轻灵栏位
		/// </summary>
		public static CombatSkillPropertyItem SlotCountAgile => Instance[(sbyte)50];

		/// <summary>
		/// 护体栏位
		/// </summary>
		public static CombatSkillPropertyItem SlotCountDefense => Instance[(sbyte)51];

		/// <summary>
		/// 奇窍栏位
		/// </summary>
		public static CombatSkillPropertyItem SlotCountAssist => Instance[(sbyte)52];

		/// <summary>
		/// 需要掷式
		/// </summary>
		public static CombatSkillPropertyItem NeedTrick0 => Instance[(sbyte)53];

		/// <summary>
		/// 需要弹式
		/// </summary>
		public static CombatSkillPropertyItem NeedTrick1 => Instance[(sbyte)54];

		/// <summary>
		/// 需要御式
		/// </summary>
		public static CombatSkillPropertyItem NeedTrick2 => Instance[(sbyte)55];

		/// <summary>
		/// 需要劈式
		/// </summary>
		public static CombatSkillPropertyItem NeedTrick3 => Instance[(sbyte)56];

		/// <summary>
		/// 需要刺式
		/// </summary>
		public static CombatSkillPropertyItem NeedTrick4 => Instance[(sbyte)57];

		/// <summary>
		/// 需要撩式
		/// </summary>
		public static CombatSkillPropertyItem NeedTrick5 => Instance[(sbyte)58];

		/// <summary>
		/// 需要崩式
		/// </summary>
		public static CombatSkillPropertyItem NeedTrick6 => Instance[(sbyte)59];

		/// <summary>
		/// 需要点式
		/// </summary>
		public static CombatSkillPropertyItem NeedTrick7 => Instance[(sbyte)60];

		/// <summary>
		/// 需要拿式
		/// </summary>
		public static CombatSkillPropertyItem NeedTrick8 => Instance[(sbyte)61];

		/// <summary>
		/// 需要音式
		/// </summary>
		public static CombatSkillPropertyItem NeedTrick9 => Instance[(sbyte)62];

		/// <summary>
		/// 需要缠式
		/// </summary>
		public static CombatSkillPropertyItem NeedTrick10 => Instance[(sbyte)63];

		/// <summary>
		/// 需要咒式
		/// </summary>
		public static CombatSkillPropertyItem NeedTrick11 => Instance[(sbyte)64];

		/// <summary>
		/// 需要机式
		/// </summary>
		public static CombatSkillPropertyItem NeedTrick12 => Instance[(sbyte)65];

		/// <summary>
		/// 需要药式
		/// </summary>
		public static CombatSkillPropertyItem NeedTrick13 => Instance[(sbyte)66];

		/// <summary>
		/// 需要毒式
		/// </summary>
		public static CombatSkillPropertyItem NeedTrick14 => Instance[(sbyte)67];

		/// <summary>
		/// 需要扫式
		/// </summary>
		public static CombatSkillPropertyItem NeedTrick15 => Instance[(sbyte)68];

		/// <summary>
		/// 蓄力进度
		/// </summary>
		public static CombatSkillPropertyItem AgileJumpSpeed => Instance[(sbyte)69];

		/// <summary>
		/// 封禁概率
		/// </summary>
		public static CombatSkillPropertyItem SilenceRate => Instance[(sbyte)70];

		/// <summary>
		/// 封禁帧数
		/// </summary>
		public static CombatSkillPropertyItem SilenceFrame => Instance[(sbyte)71];

		/// <summary>
		/// 增加攻击
		/// </summary>
		public static CombatSkillPropertyItem AddPenetrate => Instance[(sbyte)72];

		/// <summary>
		/// 增加命中
		/// </summary>
		public static CombatSkillPropertyItem AddTotalHit => Instance[(sbyte)73];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
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

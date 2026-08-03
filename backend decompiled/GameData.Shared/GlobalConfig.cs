using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Config;
using Config.Common;
using GameData.Domains.Combat;
using GameData.Serializer;

[Serializable]
public class GlobalConfig : IConfigData
{
	public static GlobalConfig Instance = new GlobalConfig();

	/// <summary>
	/// 弃婴遗弃到太吾村的概率.
	/// </summary>
	public sbyte AbandonBabyToTaiwuVillageChance = 20;

	/// <summary>
	/// 过月AI主要目标每月行动点.
	/// </summary>
	public sbyte PrimaryGoalActionPointsPerMonth = 40;

	/// <summary>
	/// 过月AI次要目标每月行动点.
	/// </summary>
	public sbyte SecondaryGoalActionPointsPerMonth = 40;

	/// <summary>
	/// 过月AI主要目标最大行动点.
	/// </summary>
	public sbyte PrimaryGoalMaxActionPoints = 60;

	/// <summary>
	/// 过月AI次要目标最大行动点.
	/// </summary>
	public sbyte SecondaryGoalMaxActionPoints = 60;

	/// <summary>
	/// 文本气泡持续时间
	/// </summary>
	public float AdventureDialogContinuousTime = 2f;

	/// <summary>
	/// 文本气泡渐隐时间
	/// </summary>
	public float AdventureDialogFadeTime = 0.5f;

	/// <summary>
	/// 戒心最小值
	/// </summary>
	public int AlertnessMin = -600000;

	/// <summary>
	/// 戒心最大值
	/// </summary>
	public int AlertnessMax = 600000;

	/// <summary>
	/// 戒心等级范围
	/// </summary>
	public int[] AlertnessLevelRange = new int[8] { -600000, -400000, -200000, -10000, 10000, 200000, 400000, 600000 };

	/// <summary>
	/// 戒心等级对好感变化的影响
	/// </summary>
	public int[] AlertnessLevelEffectToChangeFavor = new int[7] { 80, 60, 40, 0, -40, -60, -80 };

	/// <summary>
	/// 戒心值对好感上限的影响（戒心值除以此值）
	/// </summary>
	public int AlertnessEffectToMaxFavor = 10;

	/// <summary>
	/// 戒心等级对交互成功率的影响
	/// </summary>
	public int[] AlertnessLevelEffectToInteractSuccessRate = new int[7] { 175, 150, 125, 100, 75, 50, 25 };

	/// <summary>
	/// 基础初见好感的随机范围
	/// </summary>
	public int[] InitialAlertnessBaseRandomRange = new int[2] { -100000, 10000 };

	/// <summary>
	/// 刚正的人物对其他立场的初见好感
	/// </summary>
	public int[] InitialAlertnessForBehaviorTypeJust = new int[5] { -200000, -100000, 0, 100000, 200000 };

	/// <summary>
	/// 仁善的人物对其他立场的初见好感
	/// </summary>
	public int[] InitialAlertnessForBehaviorTypeKind = new int[5] { -100000, -200000, 0, 100000, 50000 };

	/// <summary>
	/// 中庸的人物对其他立场的初见好感
	/// </summary>
	public int[] InitialAlertnessForBehaviorTypeEven = new int[5] { 50000, 0, 0, 0, 50000 };

	/// <summary>
	/// 叛逆的人物对其他立场的初见好感
	/// </summary>
	public int[] InitialAlertnessForBehaviorTypeRebel = new int[5] { 50000, 100000, 0, -200000, -100000 };

	/// <summary>
	/// 唯我的人物对其他立场的初见好感
	/// </summary>
	public int[] InitialAlertnessForBehaviorTypeEgoistic = new int[5] { 200000, 100000, 0, -100000, -200000 };

	/// <summary>
	/// 正派门派的太吾名誉对初见戒心的影响
	/// </summary>
	public int[] InitialAlertnessForTaiwuFameByGoodSect = new int[7] { 100000, 50000, 10000, 0, 0, 0, 0 };

	/// <summary>
	/// 邪派门派的太吾名誉对初见戒心的影响
	/// </summary>
	public int[] InitialAlertnessForTaiwuFameByEvilSect = new int[7] { 0, 0, 0, 0, 10000, 50000, 100000 };

	/// <summary>
	/// 中立门派的太吾名誉对初见戒心的影响
	/// </summary>
	public int[] InitialAlertnessForTaiwuFameByNeutralSect = new int[7] { 50000, 0, 0, 0, 0, 0, 50000 };

	/// <summary>
	/// 非门派组织的太吾名誉对初见戒心的影响
	/// </summary>
	public int[] InitialAlertnessForTaiwuFameByCivilianSettlement = new int[7] { 100000, 10000, 5000, 0, -5000, -10000, -100000 };

	/// <summary>
	/// 玄狱词条戒心单位值
	/// </summary>
	public int InitialAlertnessChallengeModeFactorBase = 6000;

	/// <summary>
	/// 玄狱词条名声不同扣减等级
	/// </summary>
	public int InitialAlertnessChallengeModeFameDifferent = 5;

	/// <summary>
	/// 玄狱词条名声冲突扣减等级
	/// </summary>
	public int InitialAlertnessChallengeModeFameConflict = 25;

	/// <summary>
	/// 玄狱词条立场不同扣减等级
	/// </summary>
	public int InitialAlertnessChallengeModeBehaviorDifferent = 5;

	/// <summary>
	/// 玄狱词条立场冲突扣减等级
	/// </summary>
	public int InitialAlertnessChallengeModeBehaviorConflict = 25;

	/// <summary>
	/// 成功夸奖对方减少一定戒心
	/// </summary>
	public int[] ChangeAlertnessOnPraise = new int[5] { -5000, -10000, -2000, 5000, -5000 };

	/// <summary>
	/// 成功辱骂对方则增加一定戒心
	/// </summary>
	public int[] ChangeAlertnessOnSneer = new int[5] { 5000, 5000, 2000, -10000, 5000 };

	/// <summary>
	/// 可用突破总步数的基础值
	/// </summary>
	public sbyte BreakoutBaseAvailableStepsCount = 20;

	/// <summary>
	/// 可用突破总步数的最大值
	/// </summary>
	public sbyte BreakoutMaxAvailableStepsCount = 99;

	/// <summary>
	/// 可用突破总步数的最小值
	/// </summary>
	public sbyte BreakoutMinAvailableStepsCount = 3;

	/// <summary>
	/// 特殊 npc 与武林盟主固定突破总步数
	/// </summary>
	public sbyte BreakoutSpecialNpcStepsCount = 30;

	/// <summary>
	/// 突破盘初始化时如常格的基础显示概率
	/// </summary>
	public sbyte BreakoutShowNormalCellBaseOdds = 20;

	/// <summary>
	/// 突破盘初始化时特殊格的基础显示概率
	/// </summary>
	public sbyte BreakoutShowSpecialCellBaseOdds = 60;

	/// <summary>
	/// 突破盘初始化时总纲加成格的基础显示概率
	/// </summary>
	public sbyte BreakoutShowBonusCellBaseOdds = 20;

	/// <summary>
	/// 突破盘玄机格获取威力修正系数
	/// </summary>
	public sbyte BreakoutBonusAddPowerCorrectionFactor = 50;

	/// <summary>
	/// 突破盘历练类玄机各档位历练值
	/// </summary>
	public static readonly int[] BreakoutBonusExpLevelValues = new int[7] { 500, 1000, 2000, 4000, 8000, 16000, 32000 };

	/// <summary>
	/// 突破盘历练类玄机各档位减少使用需求
	/// </summary>
	public static readonly int[] BreakoutBonusExpEffectValues = new int[7] { -4, -5, -6, -7, -8, -9, -10 };

	/// <summary>
	/// 突破盘亲友类玄机各档位好感参数
	/// </summary>
	public static readonly int[] BreakoutBonusFriendFavorabilityTypeValues = new int[7] { 0, 50, 100, 150, 200, 250, 300 };

	/// <summary>
	/// 突破盘亲友类玄机基础威力加值
	/// </summary>
	public const int BreakoutBonusFriendAddPowerBase = 1;

	/// <summary>
	/// 突破盘亲友类玄机造诣威力加值除数
	/// </summary>
	public const int BreakoutBonusFriendAddPowerDivisor = 10000;

	/// <summary>
	/// 突破盘亲友类玄机造诣威力加值下限
	/// </summary>
	public const int BreakoutBonusFriendAddPowerExtraMin = 0;

	/// <summary>
	/// 突破盘亲友类玄机造诣威力加值上限
	/// </summary>
	public const int BreakoutBonusFriendAddPowerExtraMax = 9;

	/// <summary>
	/// 突破盘亲友类玄机造诣品级除数
	/// </summary>
	public const int BreakoutBonusFriendAttainmentGradeDivisor = 50;

	/// <summary>
	/// 突破盘亲友类玄机造诣品级减数
	/// </summary>
	public const int BreakoutBonusFriendAttainmentGradeMinus = 1;

	/// <summary>
	/// 独创心法使用非适宜物品转换进度值时价值百分比
	/// </summary>
	public int SectStoryEmeiBonusNotFitProgressPercent = 10;

	/// <summary>
	/// 独创心法使用物品转换进度值保底
	/// </summary>
	public int SectStoryEmeiBonusMinProgress = 1;

	/// <summary>
	/// 独创心法单个使用次数所需的进度值
	/// </summary>
	public int SectStoryEmeiBonusProgressPerCount = 30750;

	/// <summary>
	/// 独创心法回收时返还的进度值百分比
	/// </summary>
	public int SectStoryEmeiBonusProgressRecyclePercent = 50;

	/// <summary>
	/// 获取突破遗惠所需的实战度
	/// </summary>
	public int SkillProficiencyIsEnoughToGainLegacyPoint = 300;

	/// <summary>
	/// 罗汉偶像的亲友玄机造诣
	/// </summary>
	public short LuohanRelationTypeAttainment = 450;

	/// <summary>
	/// 罗汉偶像的玄机威力的基础系数
	/// </summary>
	public int LuohanMaxPowerBase = 60;

	/// <summary>
	/// 罗汉偶像的玄机威力的品级系数
	/// </summary>
	public int LuohanMaxPowerGradeFactor = 15;

	/// <summary>
	/// 罗汉偶像的玄机威力的资质系数
	/// </summary>
	public int LuohanMaxPowerQualificationFactor = 20;

	/// <summary>
	/// 奇书阳眼增加突破天资数
	/// </summary>
	public int LegendaryBookYangAddStepNormal = 5;

	/// <summary>
	/// 奇书阴眼增加突破入魔数
	/// </summary>
	public int LegendaryBookYinAddStepGoneMad = 5;

	/// <summary>
	/// 玄狱模式-物以稀贵-人物、商店的初始物品、资源的生成比例
	/// </summary>
	public int ChallengeCharacterWealthCreateRate = 50;

	/// <summary>
	/// 玄狱模式-物以稀贵-库房的补充资源和物品的比例
	/// </summary>
	public int ChallengeTreasurySupplyRate = 50;

	/// <summary>
	/// 玄狱模式-物以稀贵-物品售价加成，根据商店等级
	/// </summary>
	public int[] ChallengeShopItemPriceBonus = new int[7] { 25, 50, 75, 100, 150, 250, 400 };

	/// <summary>
	/// 玄狱模式-物以稀贵-对方的交换优势加成比例
	/// </summary>
	public int ChallengeExchangeAdvantageBonus = 50;

	/// <summary>
	/// 玄狱模式-独门独院-太吾村基础建设空间减少值
	/// </summary>
	public int ChallengeTaiwuVillageBaseSpaceReduce = 20;

	/// <summary>
	/// 玄狱模式-独门独院-太吾村信誓等级增加的建设空间减少值（3=&gt;2）
	/// </summary>
	public const int ChallengeTaiwuVillageLevelEffectReduce = 1;

	/// <summary>
	/// 玄狱模式-独门独院-太吾村产业除自然资源、村庄建筑外，其他建筑的建造数量上限
	/// </summary>
	public const int ChallengeTaiwuVillageBuildCountLimit = 1;

	/// <summary>
	/// 玄狱模式-一志难求-技能分数
	/// </summary>
	public int[] ChallengeProfessionSkillLearnScores = new int[4] { 1, 3, 9, 27 };

	/// <summary>
	/// 玄狱模式-一志难求-历练消耗系数
	/// </summary>
	public int ChallengeProfessionSkillLearnExpMultiplier = 1000;

	/// <summary>
	/// 玄狱模式-心魔相通-每月生成爪牙
	/// </summary>
	public int ChallengeInfectedDemonMinionPerMonth = 1;

	/// <summary>
	/// 玄狱模式-心魔相通-初始爪牙
	/// </summary>
	public int ChallengeInfectedDemonInitMinion = 3;

	/// <summary>
	/// 玄狱模式-心魔相通-最大爪牙数
	/// </summary>
	public int ChallengeInfectedDemonMaxMinion = 10;

	/// <summary>
	/// 玄狱模式-心魔相通-爪牙活动范围
	/// </summary>
	public int ChallengeInfectedDemonMinionRange = 2;

	/// <summary>
	/// 玄狱模式-心魔相通-失心魔出现间隔
	/// </summary>
	public int ChallengeInfectedDemonInterval = 36;

	/// <summary>
	/// 玄狱模式-入不敷出-离村好感阈值
	/// </summary>
	public int ChallengeCostResourceLeaveVillageThreshold = -10000;

	/// <summary>
	/// 玄狱模式-入不敷出-好感衰减系数
	/// </summary>
	public float ChallengeCostResourceFavorFactor = 3f;

	/// <summary>
	/// 玄狱模式-入不敷出-造诣折算为资源的比例
	/// </summary>
	public int ChallengeCostResourceResourceFactorFood = 10;

	/// <summary>
	/// 玄狱模式-入不敷出-造诣折算为资源的比例
	/// </summary>
	public int ChallengeCostResourceResourceFactorWood = 10;

	/// <summary>
	/// 玄狱模式-入不敷出-造诣折算为资源的比例
	/// </summary>
	public int ChallengeCostResourceResourceFactorMetal = 10;

	/// <summary>
	/// 玄狱模式-入不敷出-造诣折算为资源的比例
	/// </summary>
	public int ChallengeCostResourceResourceFactorJade = 10;

	/// <summary>
	/// 玄狱模式-入不敷出-造诣折算为资源的比例
	/// </summary>
	public int ChallengeCostResourceResourceFactorFabric = 10;

	/// <summary>
	/// 玄狱模式-入不敷出-造诣折算为资源的比例
	/// </summary>
	public int ChallengeCostResourceResourceFactorHerb = 10;

	/// <summary>
	/// 玄狱模式-入不敷出-造诣折算为资源的比例
	/// </summary>
	public int ChallengeCostResourceResourceFactorMoney = 2;

	/// <summary>
	/// 玄狱模式-入不敷出-造诣折算为资源的比例
	/// </summary>
	public int ChallengeCostResourceResourceFactorAuth = 20;

	/// <summary>
	/// 玄狱模式-公平对决-九品到一品战利品，允许的总决斗点数上限
	/// </summary>
	public int[] ChallengeCricketFairCombatMaxPointByWagerGrade = new int[9] { 8, 16, 24, 32, 40, 48, 56, 64, 72 };

	/// <summary>
	/// 玄狱模式-公平对决-九品到一品蛐蛐的出战消耗
	/// </summary>
	public int[] ChallengeCricketFairCombatCostByCricketGrade = new int[9] { 0, 0, 0, 1, 2, 4, 8, 16, 32 };

	/// <summary>
	/// 玄狱模式-敝帚自珍-Npc优势加成
	/// </summary>
	public int[] ChallengeExchangeGradeBonusNpc = new int[9] { 0, 25, 50, 100, 200, 350, 550, 700, 1000 };

	/// <summary>
	/// 玄狱模式-敝帚自珍-库房优势加成。库房等级为2/5/8，因此每组只有最后一个生效
	/// </summary>
	public int[] ChallengeExchangeGradeBonusTreasury = new int[9] { 0, 0, 50, 0, 0, 350, 0, 0, 1000 };

	/// <summary>
	/// 玄狱模式-君子不器-基础强健值（顺序与 Character 一致，外伤/内伤/重创/失神）
	/// </summary>
	public DamageStepCollection ChallengeEffectDamageFactor = new DamageStepCollection(200, 200, 160, 180, 180, 180, 180, 200, 200, 160, 180, 180, 180, 180, 200, 160);

	/// <summary>
	/// 各类战斗战败所需标记数，按顺序依次是切磋，恶斗，死斗，接招
	/// </summary>
	public static readonly byte[] NeedDefeatMarkCount = new byte[4] { 12, 24, 36, 24 };

	/// <summary>
	/// 各类战斗投降时额外添加的标记数，与相关战斗评价绑定，按顺序依次是切磋，恶斗，死斗，接招
	/// </summary>
	public static readonly byte[] SurrenderInjuryCount = new byte[4] { 3, 9, 36, 6 };

	/// <summary>
	/// 各类战斗主动功法获得实战值的系数
	/// </summary>
	public static readonly byte[] ProactiveProficiencyFactor = new byte[4] { 1, 2, 3, 2 };

	/// <summary>
	/// 被动功法每场战斗获得实战值下限
	/// </summary>
	public const int PassiveMinProficiency = 1;

	/// <summary>
	/// 被动功法每场战斗获得实战值上限
	/// </summary>
	public const int PassiveMaxProficiency = 3;

	/// <summary>
	/// 最大实战值
	/// </summary>
	public const int MaxProficiency = 999999999;

	/// <summary>
	/// 实战值需求
	/// </summary>
	public const int ProficiencyRequirement = 300;

	/// <summary>
	/// 玄字装备每场战斗获得契合度下限
	/// </summary>
	public int MysteryMinCompatibilityPerCombat = 3;

	/// <summary>
	/// 玄字装备每场战斗获得契合度上限
	/// </summary>
	public int MysteryMaxCompatibilityPerCombat = 5;

	/// <summary>
	/// 内息标记初始阈值
	/// </summary>
	public short DefeatMarkQiDisorderThreshold = 1000;

	/// <summary>
	/// 首个内息标记额外提高的阈值
	/// </summary>
	public short DefeatMarkQiDisorderFirstExtra = 2000;

	/// <summary>
	/// 每个状态标记需要的负面状态强度
	/// </summary>
	public short DefeatMarkCombatStatePower = 500;

	/// <summary>
	/// 状态标记数量上限
	/// </summary>
	public sbyte DefeatMarkCombatStateMaxCount = 8;

	/// <summary>
	/// 距离攻击范围最小间隔距离
	/// </summary>
	public byte AttackRangeMidMinDistance = 3;

	/// <summary>
	/// 恶斗中绳子命中所需最少标记数
	/// </summary>
	public sbyte RopeRequireMinMarkCountInBeat = 16;

	/// <summary>
	/// 死斗中绳子命中所需最少标记数
	/// </summary>
	public sbyte RopeRequireMinMarkCountInDie = 24;

	/// <summary>
	/// 恶斗中绳子基础命中率
	/// </summary>
	public sbyte RopeBaseHitOddsInBeat = 6;

	/// <summary>
	/// 死斗中绳子基础命中率
	/// </summary>
	public sbyte RopeBaseHitOddsInDie = 12;

	/// <summary>
	/// 淬毒和解毒所需要的毒术造诣
	/// </summary>
	public short[] PoisonAttainments = new short[9] { 10, 30, 60, 100, 150, 210, 280, 360, 450 };

	/// <summary>
	/// 修理所需要的技艺造诣
	/// </summary>
	public short[] RepairAttainments = new short[9] { 0, 10, 30, 60, 100, 150, 210, 280, 360 };

	/// <summary>
	/// 修理所需要的资源的基础值
	/// </summary>
	public short[] RepairBaseResourseRequirement = new short[9] { 5, 10, 15, 25, 35, 45, 60, 75, 90 };

	/// <summary>
	/// 制造药品时,药材引子要求的造诣
	/// </summary>
	public short[] MakeMadicineAttainments = new short[9] { 10, 30, 60, 100, 150, 210, 280, 360, 450 };

	/// <summary>
	/// 拆解所需的技艺造诣
	/// </summary>
	public short[] DisassembleAttainments = new short[9] { 10, 30, 60, 100, 150, 210, 280, 360, 450 };

	/// <summary>
	/// 特效影响的疗伤驱毒速度百分比下限
	/// </summary>
	public int HealInjuryPoisonSpeedMinPercent = 20;

	/// <summary>
	/// 提气值上限
	/// </summary>
	public const short BreathMaxValue = 30000;

	/// <summary>
	/// 架势值上限
	/// </summary>
	public const short StanceMaxValue = 4000;

	/// <summary>
	/// 恢复提气基础值
	/// </summary>
	public sbyte RecoverBreathBaseValue = 30;

	/// <summary>
	/// 恢复架势基础值
	/// </summary>
	public sbyte RecoverStanceBaseValue = 60;

	/// <summary>
	/// 各武器攻势数对应的架势恢复除数（用于相关公式）
	/// </summary>
	public sbyte[] RecoverStanceDivisorByWeapon = new sbyte[3] { 6, 4, 2 };

	/// <summary>
	/// 追击获得架势值
	/// </summary>
	public const short PursueAttackAddStance = 25;

	/// <summary>
	/// 攻速影响前后摇帧系数
	/// </summary>
	public sbyte AttackSpeedFactor = 50;

	/// <summary>
	/// 普攻前摇帧数下限
	/// </summary>
	public sbyte MinPrepareFrame = 9;

	/// <summary>
	/// 解封攻击进度单位
	/// </summary>
	public int UnlockAttackUnit = 18000;

	/// <summary>
	/// 最多累积变招次数
	/// </summary>
	public const int MaxChangeTrickCount = 12;

	/// <summary>
	/// 变招次数进度上限（每个上限值转为一次变招机会）
	/// </summary>
	public int MaxChangeTrickProgress = 100;

	/// <summary>
	/// 变招次数进度单次获取上限
	/// </summary>
	public int MaxChangeTrickProgressOnce = 1200;

	/// <summary>
	/// 变招选取破绽消耗的变招次数倍率
	/// </summary>
	public int ChangeTrickMultiplierFlaw = 2;

	/// <summary>
	/// 变招选取封穴消耗的变招次数倍率
	/// </summary>
	public int ChangeTrickMultiplierAcupoint = 3;

	/// <summary>
	/// 非追击变招进度加值
	/// </summary>
	public int FirstAttackAddChangeTrickProgress = 10;

	/// <summary>
	/// 追击变招进度加值
	/// </summary>
	public int PursueAttackAddChangeTrickProgress = 3;

	/// <summary>
	/// 被化解时各攻势对应的变招进度百分比
	/// </summary>
	public int[] AvoidChangeTrickProgressPercentByWeapon = new int[3] { 33, 66, 100 };

	/// <summary>
	/// 暴击伤害除数
	/// </summary>
	public int BaseCriticalOdds = 60;

	/// <summary>
	/// 被化解时仍获得蓄式的基础概率
	/// </summary>
	public int AvoidAddTrickBaseOdds = 10;

	/// <summary>
	/// 被化解时仍获得蓄式的命中值除数
	/// </summary>
	public int AvoidAddTrickHitOddsDivisor = 2;

	/// <summary>
	/// 普通攻击额外命中率（特效影响后命中率大于零时生效）
	/// </summary>
	public int NormalAttackExtraHitOdds;

	/// <summary>
	/// 普通攻击基础伤害值
	/// </summary>
	public int BaseAttackDamageValue = 9;

	/// <summary>
	/// 武器的每点攻势所增加的基础伤害
	/// </summary>
	public int AddBaseAttackDamageValue = 3;

	/// <summary>
	/// 摧破攻击基础伤害值
	/// </summary>
	public int BaseSkillDamageValue = 60;

	/// <summary>
	/// 解封攻击基础伤害值
	/// </summary>
	public int BaseUnlockDamageValue = 30;

	/// <summary>
	/// 灵性攻击基础伤害值
	/// </summary>
	public int BaseSpiritDamageValue = 30;

	/// <summary>
	/// 基础普通攻击除数
	/// </summary>
	public int BaseAttackOdds = 800;

	/// <summary>
	/// 基础心神摧破除数
	/// </summary>
	public int BaseMindAttackOdds = 30;

	/// <summary>
	/// 基础摧破攻击除数
	/// </summary>
	public int BaseSkillAttackOdds = 30;

	/// <summary>
	/// 基础解封攻击除数
	/// </summary>
	public int BaseUnlockAttackOdds = 30;

	/// <summary>
	/// 基础灵性攻击除数
	/// </summary>
	public int BaseSpiritAttackOdds = 800;

	/// <summary>
	/// 每个重创标记减少健康值（切磋，恶斗，死斗，接招）
	/// </summary>
	public sbyte[] ReduceHealthPerFatalDamageMark = new sbyte[4] { 0, 18, 36, 18 };

	/// <summary>
	/// 重创标记数量上限
	/// </summary>
	public int MaxFatalMarkCount = 999;

	/// <summary>
	/// 封穴所需命中率阈值
	/// </summary>
	public short[] AcupointLevelRequireHitOdds = new short[3] { 100, 300, 900 };

	/// <summary>
	/// 破绽所需命中率阈值
	/// </summary>
	public short[] FlawLevelRequireHitOdds = new short[3] { 100, 600, 1800 };

	/// <summary>
	/// 各级点穴基础持续时间
	/// </summary>
	public int[] AcupointBaseKeepTime = new int[4] { 90000, 135000, 270000, 540000 };

	/// <summary>
	/// 各级破绽基础持续时间
	/// </summary>
	public int[] FlawBaseKeepTime = new int[4] { 45000, 67500, 135000, 270000 };

	/// <summary>
	/// 破绽点穴每帧减少的基础时间
	/// </summary>
	public int FlawOrAcupointReduceBaseTime = 100;

	/// <summary>
	/// 破绽增加伤害百分比
	/// </summary>
	public int FlawAddDamagePercent = 40;

	/// <summary>
	/// 额外破绽增伤百分比
	/// </summary>
	public int ExtraFlawAddDamagePercent = 10;

	/// <summary>
	/// 身法跳跃默认阈值
	/// </summary>
	public short DefaultJumpThreshold = 10;

	/// <summary>
	/// 快速移动状态所需脚力值百分比
	/// </summary>
	public const short FastMoveMobilityPercent = 75;

	/// <summary>
	/// 慢速移动状态所需脚力值百分比
	/// </summary>
	public const short SlowMoveMobilityPercent = 25;

	/// <summary>
	/// 切换移动动作的距离阈值
	/// </summary>
	public short FastWalkDistance = 60;

	/// <summary>
	/// 快速移动级别
	/// </summary>
	public const byte FastMobilityLevel = 2;

	/// <summary>
	/// 慢速移动级别
	/// </summary>
	public const byte SlowMobilityLevel = 1;

	/// <summary>
	/// 极慢速移动级别
	/// </summary>
	public const byte VerySlowMobilityLevel = 0;

	/// <summary>
	/// 脚力值恢复速度
	/// </summary>
	public int MobilityRecoverSpeed = 200;

	/// <summary>
	/// 恢复状态恢复速度
	/// </summary>
	public int LockingRecoverSpeed = 400;

	/// <summary>
	/// 脚力值上限
	/// </summary>
	public int MaxMobility = 120000;

	/// <summary>
	/// 减少蓄力进度间隔帧数
	/// </summary>
	public int ReduceJumpProgressFrame = 6;

	/// <summary>
	/// 减少蓄力进度百分比
	/// </summary>
	public int ReduceJumpProgressPercent = 10;

	/// <summary>
	/// 基础移动间隔
	/// </summary>
	public int MoveCdBase = 32;

	/// <summary>
	/// 移动间隔系数
	/// </summary>
	public int MoveCdFactor = 20;

	/// <summary>
	/// 移动间隔基础除数
	/// </summary>
	public int MoveCdDivisorBase = 400;

	/// <summary>
	/// 移动间隔除数系数
	/// </summary>
	public int MoveCdDivisorFactor = 45;

	/// <summary>
	/// 身法非蓄力方向移动消耗身法值百分比
	/// </summary>
	public int AgileSkillNonJumpDirectionCostMobilityPercent = 10;

	/// <summary>
	/// 身法施展中基础加速百分比
	/// </summary>
	public short AgileSkillBaseAddSpeed = 100;

	/// <summary>
	/// 身法施展中基础命中加成值
	/// </summary>
	public short AgileSkillBaseAddHit = 200;

	/// <summary>
	/// 护体施展中基础化解加成值
	/// </summary>
	public short DefendSkillBaseAddAvoid = 200;

	/// <summary>
	/// 护体施展中基础防御加成值
	/// </summary>
	public short DefendSkillBaseAddPenetrateResist = 400;

	/// <summary>
	/// 护体基础反击威力
	/// </summary>
	public short DefendSkillBaseFightBackPower = 150;

	/// <summary>
	/// 护体基础反震威力
	/// </summary>
	public short DefendSkillBaseBouncePower = 25;

	/// <summary>
	/// 护体主动取消封禁帧数倍率
	/// </summary>
	public int DefendSkillClearManualSilenceFrameRatio = 300;

	/// <summary>
	/// 心神标记基础持续时间
	/// </summary>
	public short MindMarkBaseKeepTime = 900;

	/// <summary>
	/// 基础心韵值
	/// </summary>
	public int BaseMindRhythm = 6;

	/// <summary>
	/// 基础心神动摇时间
	/// </summary>
	public int BaseMindUpheavalTime = 180;

	/// <summary>
	/// 心神动摇造成伤害标记比例（100 对应 1 个标记）
	/// </summary>
	public int MindUpheavalAddDamageStepPercent = 50;

	/// <summary>
	/// 愈合标记基础持续时间
	/// </summary>
	public int ScarMarkBaseKeepTime = 1800;

	/// <summary>
	/// 每个愈合标记所需的进度值
	/// </summary>
	public int ScarMarkProgressPerMark = 100;

	/// <summary>
	/// 每次消除伤势或重创标记时累积的愈合标记进度下限
	/// </summary>
	public int ScarMarkProgressMin = 40;

	/// <summary>
	/// 每次消除伤势或重创标记时累积的愈合标记进度上限
	/// </summary>
	public int ScarMarkProgressMax = 60;

	/// <summary>
	/// 攻势每单位恢复固定间隔帧数
	/// </summary>
	public short AttackPrepareValueFixedDelayFramePerUnit = 20;

	/// <summary>
	/// 变招提高的命中值百分比
	/// </summary>
	public short[] AttackChangeTrickHitValueAddPercent = new short[3] { 50, 200, 350 };

	/// <summary>
	/// 变招消耗架势基础百分比
	/// </summary>
	public short[] AttackChangeTrickCostBlockBasePercent = new short[3] { 150, 300, 450 };

	/// <summary>
	/// 破敌强击命中基础百分比（索引为武器攻势数）
	/// </summary>
	public short[] BreakAttackHitBasePercent = new short[3] { 150, 300, 450 };

	/// <summary>
	/// 蛊引数上限
	/// </summary>
	public short MaxWugCount = 90;

	/// <summary>
	/// 地区恩义值限定范围
	/// </summary>
	public int[] SpiritualDebtLimit = new int[2] { -999999999, 999999999 };

	/// <summary>
	/// 各种功法装备类型的装备格数量的初始值 (五种功法装备类型 + 万用格)
	/// </summary>
	public sbyte[] CombatSkillInitialEquipSlotCounts = new sbyte[6] { 6, 1, 1, 1, 1, 0 };

	/// <summary>
	/// 角色初始内力
	/// </summary>
	public short CharacterInitialNeili = 20;

	/// <summary>
	/// 无家可归的村民每月对太吾的好感变化
	/// </summary>
	public short HomelessFavorabilityChangePerMonth = -1200;

	/// <summary>
	/// 无家可归的村民每月的心情变化
	/// </summary>
	public sbyte HomelessHappinessChangePerMonth = -15;

	/// <summary>
	/// 厢房的居民每月对太吾的好感变化
	/// </summary>
	public short HouseFavorabilityChangePerMonth = 400;

	/// <summary>
	/// 厢房的居民每月的心情变化
	/// </summary>
	public sbyte HouseHappinessChangePerMonth = 5;

	/// <summary>
	/// 将村民逐出太吾村时,各个立场的村民的好感变化量
	/// </summary>
	public short[] FavorabilityChangeOnExpel = new short[5] { -20000, -15000, -10000, -15000, -20000 };

	/// <summary>
	/// 膂力转化为装备负重时的因子
	/// </summary>
	public int StrengthToEquipmentLoadFactor = 10;

	/// <summary>
	/// 人物装备负重的保底值
	/// </summary>
	public int EquipmentLoadBaseValue = 1500;

	/// <summary>
	/// 太吾村所在的区域强制指定的区域大小
	/// </summary>
	public int TaiwuVillageForceAreaSize = 38;

	/// <summary>
	/// 绳索每个品级提供的捕获概率加成
	/// </summary>
	public sbyte CaptureRatePerRopeGrade = 15;

	/// <summary>
	/// 战斗非主战角色获得的资源百分比
	/// </summary>
	public int CombatGetNonMainPercent = 25;

	/// <summary>
	/// 战斗每个精纯等级获得历练基础值
	/// </summary>
	public short[] CombatGetExpBase = new short[19]
	{
		100, 110, 140, 190, 260, 350, 460, 590, 740, 910,
		1100, 1310, 1540, 1790, 2060, 2350, 2660, 2990, 3340
	};

	/// <summary>
	/// 战斗每个精纯等级获得威望基础值
	/// </summary>
	public short[] CombatGetAuthorityBase = new short[19]
	{
		5, 10, 20, 30, 45, 60, 80, 105, 130, 160,
		190, 230, 280, 340, 410, 500, 610, 760, 950
	};

	/// <summary>
	/// 较艺结算时,参照战斗结算获取的历练、威望百分比
	/// </summary>
	public short LifeSkillBattleGainRatio = 50;

	/// <summary>
	/// 使用Boss剑柄增加入魔值
	/// </summary>
	public sbyte UseSwordFragmentAddXiangshuInfection = 20;

	/// <summary>
	/// 计算服食毒药时公式的系数
	/// </summary>
	public sbyte CalcApplyItemPoisonParam = 20;

	/// <summary>
	/// 投掷毒药时的系数
	/// </summary>
	public sbyte ThrowPoisonParam = 10;

	/// <summary>
	/// 处决蓄力总时间（秒）
	/// </summary>
	public float MercyPrepareMaxTime = 2f;

	/// <summary>
	/// 处决蓄力衰减时间（秒）
	/// </summary>
	public float MercyAutoIgnoreTime = 6f;

	/// <summary>
	/// 威力伤害最大值
	/// </summary>
	public int PowerDamageMax = 500;

	/// <summary>
	/// 威力伤害系数
	/// </summary>
	public int PowerDamageOffset = 500;

	/// <summary>
	/// 疲敝标记自然出现间隔帧数（不可为零）
	/// </summary>
	public uint TiredMarkAppearFrame = 540u;

	/// <summary>
	/// 初级资源心材提供给蛰室的基础经验值
	/// </summary>
	public int CricketRoomExpPerLowMaterialBaseValue = 50;

	/// <summary>
	/// 初级资源心材提供给蛰室的经验值递减单位
	/// </summary>
	public int CricketRoomExpPerLowMaterialDecreasingValue = 3;

	/// <summary>
	/// 初级资源心材提供给蛰室的最低经验值
	/// </summary>
	public int CricketRoomExpPerLowMaterialMinValue = 20;

	/// <summary>
	/// 高级资源心材提供给蛰室的基础经验值
	/// </summary>
	public int CricketRoomExpPerHighMaterialBaseValue = 150;

	/// <summary>
	/// 高级资源心材提供给蛰室的经验值递减单位
	/// </summary>
	public int CricketRoomExpPerHighMaterialDecreasingValue = 10;

	/// <summary>
	/// 高级资源心材提供给蛰室的最低经验值
	/// </summary>
	public int CricketRoomExpPerHighMaterialMinValue = 50;

	/// <summary>
	/// 蛰室每升一级所需的经验值
	/// </summary>
	public int CricketRoomRequireExpPerLevel = 1000;

	/// <summary>
	/// 蛰室初始等级
	/// </summary>
	public int CricketRoomBaseLevel = 1;

	/// <summary>
	/// 蛰室最大等级
	/// </summary>
	public int CricketRoomMaxLevel = 10;

	/// <summary>
	/// 蛰室解锁返灵玉所需等级
	/// </summary>
	public int CricketRoomPolymorphReturnRequireLevel = 3;

	/// <summary>
	/// 蛰室解锁促织许愿所需等级
	/// </summary>
	public int CricketRoomMakingWishRequireLevel = 10;

	/// <summary>
	/// 蛰龄与进度值换算单位（每年 100 进度）
	/// </summary>
	public int CricketAgeProgressPerYear = 100;

	/// <summary>
	/// 促织灵性上限值
	/// </summary>
	public int CricketSpiritMax = 1000;

	/// <summary>
	/// 促织灵性单位值（每次提升属性所需的灵性值）
	/// </summary>
	public int CricketSpiritUnit = 100;

	/// <summary>
	/// 促织灵性成长每次提升的属性值
	/// </summary>
	public int[] CricketSpiritGrowthProperties = new int[11]
	{
		10, 10, 1, 1, 1, 5, 1, 5, 5, 1,
		5
	};

	/// <summary>
	/// 促织灵性成长每次提升的耐久值
	/// </summary>
	public short CricketSpiritGrowthDurability = 1;

	/// <summary>
	/// 促织决斗胜利获得灵性值（索引与品级对应）
	/// </summary>
	public int[] CricketCombatAddSpirit = new int[9] { 1, 2, 3, 6, 9, 12, 18, 24, 32 };

	/// <summary>
	/// 促织投喂血露获得灵性值（索引与品级对应）
	/// </summary>
	public int[] CricketBloodDewAddSpirit = new int[9] { 10, 20, 30, 50, 80, 120, 170, 230, 300 };

	/// <summary>
	/// 触发化人过月事件基础概率
	/// </summary>
	public int CricketPolymorphBaseRate = 5;

	/// <summary>
	/// 触发化人过月事件递增概率
	/// </summary>
	public int CricketPolymorphAddRate = 1;

	/// <summary>
	/// 许愿生成的促织点持续时间
	/// </summary>
	public short CricketWishingDuration = 3;

	/// <summary>
	/// 许愿需要的促织缘
	/// </summary>
	public int CricketWishingCostLuckPoint = 300;

	/// <summary>
	/// 许愿捕捉失败返还的促织缘
	/// </summary>
	public int CricketWishingReturnLuckPoint = 150;

	/// <summary>
	/// 自定义人物主属性可用点数
	/// </summary>
	public short CustomProtagonistMainAttributeTotalPoint = 300;

	/// <summary>
	/// 自定义人物主属性单项上限
	/// </summary>
	public short CustomProtagonistMainAttributeMaxPoint = 90;

	/// <summary>
	/// 自定义人物主属性默认属性
	/// </summary>
	public short CustomProtagonistMainAttributeDefaultPoint = 20;

	/// <summary>
	/// 自定义人物技艺资质可用点数
	/// </summary>
	public short CustomProtagonistLifeSkillQualificationTotalPoint = 800;

	/// <summary>
	/// 自定义人物技艺资质单项上限
	/// </summary>
	public short CustomProtagonistLifeSkillQualificationMaxPoint = 90;

	/// <summary>
	/// 自定义人物技艺资质默认属性
	/// </summary>
	public short CustomProtagonistLifeSkillQualificationDefaultPoint = 40;

	/// <summary>
	/// 自定义人物功法资质可用点数
	/// </summary>
	public short CustomProtagonistCombatSkillQualificationTotalPoint = 700;

	/// <summary>
	/// 自定义人物功法资质单项上限
	/// </summary>
	public short CustomProtagonistCombatSkillQualificationMaxPoint = 90;

	/// <summary>
	/// 自定义人物功法资质默认属性
	/// </summary>
	public short CustomProtagonistCombatSkillQualificationDefaultPoint = 40;

	/// <summary>
	/// 自定义人物特性可用点数
	/// </summary>
	public short CustomProtagonistCharacterFeatureTotalPoint = 7;

	/// <summary>
	/// 最大结论点
	/// </summary>
	public int DebateMaxGamePoint = 6;

	/// <summary>
	/// 最大回合数，到达时强制结束较艺并结算
	/// </summary>
	public int DebateMaxRound = 20;

	/// <summary>
	/// 三条线
	/// </summary>
	public int DebateLineCount = 3;

	/// <summary>
	/// 每条线上六格
	/// </summary>
	public int DebateLineNodeCount = 6;

	/// <summary>
	/// 每条线上太吾优势的格子数
	/// </summary>
	public int[] DebateTaiwuVantageNodeCount = new int[3] { 4, 3, 2 };

	/// <summary>
	/// 每场较艺可选卡组类型上限
	/// </summary>
	public int DebateCardTypeLimit = 4;

	/// <summary>
	/// 每回合落子上限
	/// </summary>
	public int DebateMakeMoveLimit = 1;

	/// <summary>
	/// 每回合抽卡上限
	/// </summary>
	public int DebateGetStrategyLimit = 3;

	/// <summary>
	/// 每个论点的附着策略上限
	/// </summary>
	public int DebatePawnStrategyLimit = 3;

	/// <summary>
	/// 等级到论点论据的转换率
	/// </summary>
	public int DebateGradeToBasesPercent = 5;

	/// <summary>
	/// 论点对结论的伤害
	/// </summary>
	public int DebatePawnDamageToGamePoint = 1;

	/// <summary>
	/// 观众选取的地格范围
	/// </summary>
	public int DebateSpectatorPickRange = 1;

	/// <summary>
	/// 迫使投降的造诣系数
	/// </summary>
	public int DebateSurrenderAttainmentFactor = 200;

	/// <summary>
	/// 迫使投降的立场系数
	/// </summary>
	public int[] DebateSurrenderBehaviorFactor = new int[5] { 100, 80, 60, 80, 100 };

	/// <summary>
	/// 造诣到最大论据的转换随机范围
	/// </summary>
	public int[] DebateAttainmentToMaxBasesPercent = new int[2] { 85, 116 };

	/// <summary>
	/// 每回合较艺者的论据恢复
	/// </summary>
	public int DebateBasesRecoverPercent = 30;

	/// <summary>
	/// 初始策略点
	/// </summary>
	public int DebateInitialStrategyPoint = 4;

	/// <summary>
	/// 最大策略点
	/// </summary>
	public int DebateMaxStrategyPoint = 12;

	/// <summary>
	/// 每回合较艺者的策略点恢复
	/// </summary>
	public int DebateStrategyPointRecover = 2;

	/// <summary>
	/// 压力上限
	/// </summary>
	public int DebateMaxPressure = 100;

	/// <summary>
	/// 压力导致的策略点恢复百分比
	/// </summary>
	public int DebatePressureStrategyRecoverPercent = 50;

	/// <summary>
	/// 压力导致的论据恢复百分比
	/// </summary>
	public int DebatePressureBasesRecoverPercent = 50;

	/// <summary>
	/// 压力自动升高所需的回合数
	/// </summary>
	public int DebatePressureAutoIncreaseRound = 10;

	/// <summary>
	/// 压力自动升高数值
	/// </summary>
	public int DebatePreesureAutoIncreaseValue = 10;

	/// <summary>
	/// 低压力百分比
	/// </summary>
	public int DebateLowPressurePercent = 50;

	/// <summary>
	/// 中压力百分比
	/// </summary>
	public int DebateMidPressurePercent = 75;

	/// <summary>
	/// 高压力百分比
	/// </summary>
	public int DebateHighPressurePercent = 100;

	/// <summary>
	/// 心浮气躁概率
	/// </summary>
	public int[] DebateReduceStrategyRecoverProb = new int[4] { 0, 0, 100, 100 };

	/// <summary>
	/// 心烦意乱概率
	/// </summary>
	public int[] DebateReduceBasesRecoverProb = new int[4] { 0, 100, 100, 100 };

	/// <summary>
	/// 语无伦次概率
	/// </summary>
	public int[] DebateUseStrategyFailedProb = new int[4] { 0, 0, 0, 50 };

	/// <summary>
	/// 失魂落魄概率
	/// </summary>
	public int[] DebateMakeMoveFailedProb = new int[4] { 0, 0, 0, 50 };

	/// <summary>
	/// 论战导致的压力变化值
	/// </summary>
	public int DebatePressureDeltaInConflict = 5;

	/// <summary>
	/// 同一评价结算时的最大数量
	/// </summary>
	public int DebateCommentStackLimit = 3;

	/// <summary>
	/// 以大欺小对手的造诣百分比
	/// </summary>
	public int DebateBullyPercent = 50;

	/// <summary>
	/// 以小博大对手的造诣百分比
	/// </summary>
	public int DebateOverComePercent = 150;

	/// <summary>
	/// 观众发表评价的几率
	/// </summary>
	public int DebateCommentProb = 50;

	/// <summary>
	/// 己方观众发表正面评价的基础几率
	/// </summary>
	public int DebateSameSideCommentProb = 75;

	/// <summary>
	/// 对方观众发表正面评价的基础几率
	/// </summary>
	public int DebateOtherSideCommentProb = 25;

	/// <summary>
	/// 观众发表正面评价的好感度参数
	/// </summary>
	public int DebateCommentDivider = 1200;

	/// <summary>
	/// 观众使用场地效果的几率
	/// </summary>
	public int DebateAddNodeEffectProb = 50;

	/// <summary>
	/// 观众使用场地效果帮助己方的基础几率
	/// </summary>
	public int DebateHelpSameSideProb = 50;

	/// <summary>
	/// 观众使用场地效果帮助己方的好感度参数
	/// </summary>
	public int DebateHelpSameSideDivider = 600;

	/// <summary>
	/// 迫使投降系数
	/// </summary>
	public int DebateSurrenderFactor = 50;

	/// <summary>
	/// 最大可用策略数
	/// </summary>
	public int DebateMaxCanUseCards = 6;

	/// <summary>
	/// 重置策略压力阈值
	/// </summary>
	public int DebateResetCardsPressureLimit = 100;

	/// <summary>
	/// 重置策略压力增值
	/// </summary>
	public int DebateResetCardsPressureDelta = 25;

	/// <summary>
	/// 回合开始最多可抽取的策略数
	/// </summary>
	public int DebateMaxShuffleCard = 3;

	/// <summary>
	/// 优势路线初始权重随机上下限
	/// </summary>
	public List<int[]> AttackLineWeight = new List<int[]>
	{
		new int[2] { 2, 3 },
		new int[2] { 2, 3 },
		new int[2] { 3, 4 },
		new int[2] { 1, 4 },
		new int[2] { 3, 4 }
	};

	/// <summary>
	/// 中间路线初始权重随机上下限
	/// </summary>
	public List<int[]> MidLineWeight = new List<int[]>
	{
		new int[2] { 2, 3 },
		new int[2] { 3, 4 },
		new int[2] { 4, 5 },
		new int[2] { 1, 4 },
		new int[2] { 4, 5 }
	};

	/// <summary>
	/// 劣势路线初始权重随机上下限
	/// </summary>
	public List<int[]> DefenseLineWeight = new List<int[]>
	{
		new int[2] { 2, 3 },
		new int[2] { 6, 7 },
		new int[2] { 6, 7 },
		new int[2] { 1, 4 },
		new int[2] { 6, 7 }
	};

	/// <summary>
	/// 前期留论据
	/// </summary>
	public int[] EarlyBases = new int[5] { 50, 60, 55, 50, 40 };

	/// <summary>
	/// 中期留论据
	/// </summary>
	public int[] MidBases = new int[5] { 40, 50, 45, 40, 35 };

	/// <summary>
	/// 后期留论据
	/// </summary>
	public int[] LateBases = new int[5] { 35, 45, 40, 35, 30 };

	/// <summary>
	/// 前期留策略点
	/// </summary>
	public List<int[]> EarlyStrategyPoint = new List<int[]>
	{
		new int[2] { 5, 3 },
		new int[2] { 7, 4 },
		new int[2] { 6, 4 },
		new int[2] { 4, 3 },
		new int[2] { 3, 2 }
	};

	/// <summary>
	/// 中期留策略点
	/// </summary>
	public List<int[]> MidStrategyPoint = new List<int[]>
	{
		new int[2] { 4, 1 },
		new int[2] { 5, 2 },
		new int[2] { 3, 2 },
		new int[2] { 2, 1 },
		new int[2] { 1, 1 }
	};

	/// <summary>
	/// 后期留策略点
	/// </summary>
	public List<int[]> LateStrategyPoint = new List<int[]>
	{
		new int[2],
		new int[2],
		new int[2],
		new int[2],
		new int[2]
	};

	/// <summary>
	/// 造成伤害后的权重影响
	/// </summary>
	public int[] DamageLineWeight = new int[5] { 1, 1, 1, 1, 2 };

	/// <summary>
	/// 受到伤害后的权重影响
	/// </summary>
	public int[] DamagedLineWeight = new int[5] { 1, 2, 1, 1, 1 };

	/// <summary>
	/// 血量压力百分比影响阶段
	/// </summary>
	public List<int[]> StateGamePointPressureInfluence = new List<int[]>
	{
		new int[2] { 69, 19 },
		new int[2] { 59, 0 },
		new int[2] { 69, 19 },
		new int[2] { 79, 29 },
		new int[2] { 79, 39 }
	};

	/// <summary>
	/// 论点数量差影响阶段
	/// </summary>
	public List<int[]> StatePawnCountInfluence = new List<int[]>
	{
		new int[2] { 2, 3 },
		new int[2] { 4, 5 },
		new int[2] { 3, 4 },
		new int[2] { 2, 3 },
		new int[2] { 1, 2 }
	};

	/// <summary>
	/// 回合数影响阶段
	/// </summary>
	public int[] StateRoundInfluence = new int[5] { 13, 15, 14, 13, 12 };

	/// <summary>
	/// 声威袭人对路线权重的影响百分比
	/// </summary>
	public int EgoisticNodeEffectWeightPercent = 100;

	/// <summary>
	/// 旁敲侧击落子最高等级几率
	/// </summary>
	public int[] EvenNodeEffectMaxGradeProb = new int[5] { 80, 20, 50, 20, 50 };

	/// <summary>
	/// 不检查前中后期的回合数
	/// </summary>
	public int RoundBeforeEarly = 3;

	/// <summary>
	/// 论据足够时最低论点等级
	/// </summary>
	public int MinGradeIfEnoughBases = 6;

	/// <summary>
	/// 论据不足时前中后期落零级子的概率
	/// </summary>
	public int[] ZeroGradePawnProb = new int[3] { 90, 80, 60 };

	/// <summary>
	/// 后期劣势时放手一搏的概率
	/// </summary>
	public int MakeMoveOnOverwhelmingLineProb = 80;

	/// <summary>
	/// 移除论据占比过低的论点作为目标
	/// </summary>
	public int RemoveStrategyTargetPawnBasesPercent = 20;

	/// <summary>
	/// AI的道法自然前中后期使用时的手牌数量限制
	/// </summary>
	public int[] Taoism3CanUseCardLimit = new int[3] { 1, 3, 0 };

	/// <summary>
	/// AI的掐指一算前中后期使用时的手牌数量限制
	/// </summary>
	public int[] Math1CanUseCardLimit = new int[3] { 3, 0, 0 };

	/// <summary>
	/// AI重拾策略的弃牌数量限制
	/// </summary>
	public int ResetStrategyUsedCardLimit = 3;

	/// <summary>
	/// 购买时的基础价格变化百分值
	/// </summary>
	public const int BuyPriceBaseEffect = 200;

	/// <summary>
	/// 出售时的基础价格变化百分值
	/// </summary>
	public const int SellPriceBaseEffect = 20;

	/// <summary>
	/// 额外商品涨价数值
	/// </summary>
	public const int ExtraGoodsPriceEffect = 50;

	/// <summary>
	/// {刚正,仁善,中庸,叛逆,唯我}立场对应商品涨价概率
	/// </summary>
	public static readonly sbyte[] IncreasePriceProb = new sbyte[5] { 0, 0, 20, 40, 40 };

	/// <summary>
	/// {刚正,仁善,中庸,叛逆,唯我}立场对应商品降价概率
	/// </summary>
	public static readonly sbyte[] DecreasePriceProb = new sbyte[5] { 0, 40, 20, 40, 0 };

	/// <summary>
	/// 立场涨价幅度
	/// </summary>
	public const int BehaviorAddDiscount = 25;

	/// <summary>
	/// 立场降价幅度
	/// </summary>
	public const int BehaviorReduceDiscount = -25;

	/// <summary>
	/// 富商召唤商队时，太吾购买物品的基础涨价价格（应为负数，100%资历对应此涨价幅度，0资历时此项为0）
	/// </summary>
	public const int SeniorityToCaravanBuyPrice = -25;

	/// <summary>
	/// 富商召唤商队时，太吾出售物品的基础涨价价格（满资历对应此涨价幅度，0资历时此项为0）
	/// </summary>
	public const int SeniorityToCaravanSellPrice = 25;

	/// <summary>
	/// 0~9级世界侵袭度下,商会的页面可出现的级别
	/// </summary>
	public short[] MerchantFavorabilityUpperLimits = new short[10] { 0, 0, 1, 2, 3, 4, 5, 6, 6, 6 };

	/// <summary>
	/// 0~9级世界侵袭度下,出售给商店的物品品级，超过就减少商人的欠恩失义
	/// </summary>
	public short[] MerchantItemDebtGradeUpperLimits = new short[10] { 1, 1, 2, 3, 4, 5, 5, 6, 7, 7 };

	/// <summary>
	/// 商会好感上升到10,20,30,40,50,60,70,80,90,100所需要在商会的商店花费的银钱数额
	/// </summary>
	public int[] MerchantFavorabilityMoneyRequirements = new int[10] { 6000, 12000, 24000, 48000, 96000, 192000, 384000, 768000, 1536000, 3072000 };

	/// <summary>
	/// 商会好感到达10,20,30,40,50,60,70,80,90,100时，如果精纯小于配置，那么无法继续增长商会好感度
	/// </summary>
	public int[] MerchantFavorabilityXiangshuLevelRequirements = new int[10] { 0, 0, 2, 4, 6, 8, 10, 12, 14, 16 };

	/// <summary>
	/// 购买时商人好感对价格影响
	/// </summary>
	public int[] MerchantCharFavorabilityBuyEffect = new int[13]
	{
		25, 20, 15, 10, 5, 0, 0, 0, -5, -10,
		-15, -20, -25
	};

	/// <summary>
	/// 出售时商人好感对价格影响
	/// </summary>
	public int[] MerchantCharFavorabilitySellEffect = new int[13]
	{
		-10, -8, -6, -4, -2, 0, 0, 0, 2, 4,
		6, 8, 10
	};

	/// <summary>
	/// 商会的欠恩失义限制商店最高等级，达到该值就禁止访问对应等级的商店标签,-1表示无限制
	/// </summary>
	public int[] MerchantDebtLevelLimit = new int[7] { -1, 316500, 305700, 274200, 199800, 124200, 0 };

	/// <summary>
	/// 商店超好感购买的次数
	/// </summary>
	public short[] MerchantOverFavorBuyCount = new short[7] { -1, 12, 9, 6, 3, 2, 1 };

	/// <summary>
	/// 商会等级对应的抢劫事件的帮助获胜后的商会好感提升量
	/// </summary>
	public int[] CaravanRobbedEventWinAddMerchantFavorability = new int[7] { 2700, 6750, 13950, 25200, 41400, 36450, 92250 };

	/// <summary>
	/// 商队抢劫事件失败后的收益增幅降低的比例
	/// </summary>
	public short CaravanRobbedEventLoseReduceIncomeBonus = 33;

	/// <summary>
	/// 商队创建时的收入暴击倍率范围
	/// </summary>
	public short[] CaravanIncomeCriticalResultRange = new short[2] { 150, 300 };

	/// <summary>
	/// 商队抢劫事件结束后降低的被抢劫概率的百分比
	/// </summary>
	public sbyte CaravanRobbedEventEndReduceRobbedRate = 50;

	/// <summary>
	/// 商队等级对应的投资所需金钱,最高级的不会创建商队，不可投资
	/// </summary>
	public int[] InvestCaravanNeedMoney = new int[6] { 5000, 10000, 20000, 40000, 80000, 160000 };

	/// <summary>
	/// 被投资的商队等级对应的避免被抢劫所需威望系数
	/// </summary>
	public int[] InvestedCaravanAvoidRobbedNeedAuthorityFactor = new int[6] { 5, 10, 20, 40, 80, 160 };

	/// <summary>
	/// （不可修改，要改要联系程序）商店等级所需的好感等级
	/// </summary>
	public static readonly sbyte[] MerchantLevelNeedFavorabilityLevel = new sbyte[7] { 0, 2, 4, 6, 8, 9, 10 };

	/// <summary>
	/// 库房等级转为身份品级，初级 = 2；中级 = 5；高级 = 8
	/// </summary>
	public int[] ExchangeTreasuryLevelGrade = new int[3] { 2, 5, 8 };

	public float ExchangeBarRangeP1 = 72901f;

	/// <summary>
	/// 好感最高~最低对应的Npc优势值
	/// </summary>
	public int[] ExchangeFavorLevel = new int[13]
	{
		0, 0, 0, 0, 0, 25, 50, 100, 200, 350,
		550, 700, 1000
	};

	/// <summary>
	/// 戒心最低~最高对应Npc优势值
	/// </summary>
	public int[] ExchangeAlertnessLevel = new int[7] { 0, 0, 0, 50, 200, 550, 1000 };

	/// <summary>
	/// 相合立场的优势值
	/// </summary>
	public int ExchangeMoralitySame;

	/// <summary>
	/// 其他立场的优势值
	/// </summary>
	public int ExchangeMoralitySimilar = 25;

	/// <summary>
	/// 相冲立场的优势值
	/// </summary>
	public int ExchangeMoralityOpposite = 50;

	/// <summary>
	/// 名誉影响的善门派优势值
	/// </summary>
	public int[] ExchangeFameValueForGood = new int[7] { 0, 0, 0, 0, 0, 50, 100 };

	/// <summary>
	/// 名誉影响的其他优势值
	/// </summary>
	public int[] ExchangeFameValueForNeutral = new int[7] { 50, 25, 0, 0, 0, 25, 50 };

	/// <summary>
	/// 名誉影响的恶门派优势值
	/// </summary>
	public int[] ExchangeFameValueForBad = new int[7] { 100, 50, 0, 0, 0, 0, 0 };

	/// <summary>
	/// 性别对优势值的影响
	/// </summary>
	public int ExchangeSpecialGender = 50;

	/// <summary>
	/// 库房匮乏的影响
	/// </summary>
	public int ExchangeSpecialLackResource = 200;

	/// <summary>
	/// 太吾基础优势
	/// </summary>
	public int ExchangeBaseTaiwu = 100;

	/// <summary>
	/// 非门派npc基础优势
	/// </summary>
	public int ExchangeBaseNormalNpc = 200;

	/// <summary>
	/// 门派npc基础优势
	/// </summary>
	public int ExchangeBaseSectNpc = 300;

	/// <summary>
	/// 库房基础优势
	/// </summary>
	public int ExchangeBaseTreasury = 400;

	/// <summary>
	/// 秘闻的优势，要乘以秘闻的(等级 +1)
	/// </summary>
	public int ExchangeSecretAdvantageBonus = 5;

	/// <summary>
	/// 门派支持度的优势，要乘以支持度
	/// </summary>
	public int ExchangeApproveAdvantageBonus = 5;

	/// <summary>
	/// 地区恩义到优势的换算除数
	/// </summary>
	public int ExchangeDebtUnit = 5;

	/// <summary>
	/// 超出世界等级的品级对应的优势加成，最左边一项用来记录小于等于世界进度的人物获取的优势
	/// </summary>
	public int[] ExchangeGradeOverProgress = new int[9] { 0, 25, 50, 100, 200, 350, 550, 700, 1000 };

	/// <summary>
	/// 太吾获取同道俘虏时Npc心情变化
	/// </summary>
	public int[] GetPrisonerHappinessChange = new int[9] { 2, 4, 6, 8, 10, 12, 14, 16, 18 };

	/// <summary>
	/// 太吾获取同道俘虏时Npc好感变化
	/// </summary>
	public int[] GetPrisonerFavorChange = new int[9] { 600, 1200, 1800, 3000, 4200, 5400, 7200, 9000, 10800 };

	/// <summary>
	/// 菜肴上限
	/// </summary>
	public int FeastCount = 3;

	/// <summary>
	/// 菜肴可食用次数
	/// </summary>
	public int FeastDurability = 3;

	/// <summary>
	/// 回礼上限
	/// </summary>
	public int FeastGiftCount = 30;

	/// <summary>
	/// 基础心情
	/// </summary>
	public List<int> FeastBaseHappiness = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

	/// <summary>
	/// 基础好感
	/// </summary>
	public List<int> FeastBaseFaovr = new List<int> { 60, 120, 180, 300, 420, 540, 720, 900, 1080 };

	/// <summary>
	/// 规模心情加成
	/// </summary>
	public List<int> FeastBuildingLevelHappinessPercent = new List<int> { 50, 100, 150 };

	/// <summary>
	/// 规模好感加成
	/// </summary>
	public List<int> FeastBuildingLevelFavorPercent = new List<int> { 100, 200, 300 };

	/// <summary>
	/// 喜爱物品心情加成
	/// </summary>
	public int FeastLoveItemHappinessPercent = 50;

	/// <summary>
	/// 喜爱物品好感加成
	/// </summary>
	public int FeastLoveItemFavorPercent = 100;

	/// <summary>
	/// 喜爱物品回礼加成
	/// </summary>
	public int FeastLoveItemGiftAddOn = 1;

	/// <summary>
	/// 宴堂事件簿低心情值
	/// </summary>
	public int FeastLowHappiness = 40;

	/// <summary>
	/// 礼物品级上限参数
	/// </summary>
	public int[] FeastGiftGradeFactor = new int[2] { -3, -2 };

	/// <summary>
	/// 礼物折算资源百分比
	/// </summary>
	public int[] FeastGiftResourcePercent = new int[2] { 8, 12 };

	/// <summary>
	/// 礼物折算银钱百分比
	/// </summary>
	public int[] FeastGiftMoneyPercent = new int[2] { 40, 60 };

	/// <summary>
	/// 礼物折算银钱资源随机加成
	/// </summary>
	public int[] FeastGiftResourceAddon = new int[2] { 50, 100 };

	/// <summary>
	/// 主属性权重和分布权重表，[0]=42的权重为[1]=10, 43的权重为10，以此类推。这里的数值的用途是记录各属性分布，如需修改，还需同步修改配置表保证修改后的结果可以取到
	/// </summary>
	public WeightsSumDistribution MainAttributeWeightsTable = new WeightsSumDistribution(42, 6, 10, 17, 30, 51, 90, 153, 270, 459);

	/// <summary>
	/// 战斗资质权重和分布权重表，[0]=84对应均值120的资质，其余25项使用round(100 * 3 ^ ((0 : 24)/6))计算
	/// </summary>
	public WeightsSumDistribution CombatSkillQualificationWeightsTable = new WeightsSumDistribution(84, 100, 120, 144, 173, 208, 250, 300, 360, 433, 520, 624, 749, 900, 1081, 1298, 1559, 1872, 2248, 2700, 3243, 3894, 4677, 5616, 6745, 8100);

	/// <summary>
	/// 技艺资质权重和分布权重表，与战斗表基本相同
	/// </summary>
	public WeightsSumDistribution LifeSkillQualificationWeightsTable = new WeightsSumDistribution(96, 100, 120, 144, 173, 208, 250, 300, 360, 433, 520, 624, 749, 900, 1081, 1298, 1559, 1872, 2248, 2700, 3243, 3894, 4677, 5616, 6745, 8100);

	/// <summary>
	/// 用于计算血亲生出先天畸形的概率
	/// </summary>
	public int CongenitalMalformationProbability = 50;

	/// <summary>
	/// 主要属性 - 基础总值
	/// </summary>
	public const int CharacterCreationBaseMainAttributeSum = 168;

	/// <summary>
	/// 主要属性 - 每阶加值
	/// </summary>
	public const int CharacterCreationMainAttributePerLevel = 21;

	/// <summary>
	/// 技艺资质 - 基础总值
	/// </summary>
	public const int CharacterCreationBaseLifeSkillSum = 448;

	/// <summary>
	/// 技艺资质 - 每阶加值
	/// </summary>
	public const int CharacterCreationLifeSkillPerLevel = 56;

	/// <summary>
	/// 武学资质 - 基础总值
	/// </summary>
	public const int CharacterCreationBaseCombatSkillSum = 392;

	/// <summary>
	/// 武学资质 - 每阶加值
	/// </summary>
	public const int CharacterCreationCombatSkillPerLevel = 49;

	/// <summary>
	/// 变异几率
	/// </summary>
	public const int CharacterCreationMutationRate = 20;

	/// <summary>
	/// 浮动范围 (百分比)
	/// </summary>
	public const int CharacterCreationValueSpan = 20;

	/// <summary>
	/// 默认主属性随机变异次数的最大值（包含此最大值）
	/// </summary>
	public const int DefaultMainAttributeMutateCount = 2;

	/// <summary>
	/// 默认功法资质随机变异次数的最大值（包含此最大值）
	/// </summary>
	public const int DefaultCombatSkillQualificationMutateCount = 3;

	/// <summary>
	/// 默认技艺资质随机变异次数的最大值（包含此最大值）
	/// </summary>
	public const int DefaultLifeSkillQualificationMutateCount = 4;

	/// <summary>
	/// 门派角色属性生成类型权重
	/// </summary>
	public static readonly sbyte[] CharacterCreationSectMemberGenerationTypeWeights = new sbyte[3] { 70, 15, 15 };

	/// <summary>
	/// 非门派角色属性生成类型权重
	/// </summary>
	public static readonly sbyte[] CharacterCreationCivilianGenerationTypeWeights = new sbyte[3] { 50, 25, 25 };

	/// <summary>
	/// 重新修正品级的基础概率
	/// </summary>
	public static readonly sbyte[] CharacterCreationAdjustGradeBaseChances = new sbyte[9] { 5, 10, 15, 20, 25, 30, 40, 50, 60 };

	/// <summary>
	/// 修正目标品级的权重
	/// </summary>
	public static readonly short[][] CharacterCreationAdjustGradeWeights = new short[9][]
	{
		new short[9] { 900, 140, 100, 60, 40, 20, 0, 0, 0 },
		new short[9] { 35, 900, 140, 100, 60, 40, 20, 0, 0 },
		new short[9] { 25, 35, 900, 140, 100, 60, 40, 20, 0 },
		new short[9] { 15, 25, 35, 900, 140, 100, 60, 40, 20 },
		new short[9] { 10, 15, 25, 35, 900, 140, 100, 60, 40 },
		new short[9] { 5, 10, 15, 25, 35, 900, 140, 100, 60 },
		new short[9] { 0, 5, 10, 15, 25, 35, 900, 140, 100 },
		new short[9] { 0, 0, 5, 10, 15, 25, 35, 900, 140 },
		new short[9] { 0, 0, 0, 5, 10, 15, 25, 35, 900 }
	};

	/// <summary>
	/// 武学、技艺资质基础值. 小于该值表示不擅长, 同时也是作为-1时生成资质的权重值.
	/// </summary>
	public const short SkillAdjustBaseValue = 6;

	/// <summary>
	/// 最大尝试生成次数，超过后仍失败将报错
	/// </summary>
	public int MaxTaiwuVillageAreaCreateCount = 10;

	/// <summary>
	/// 每个方向最大的剑冢可用位置，超过将随机移除
	/// </summary>
	public int MaxSwordTombCanSelectCount = 40;

	/// <summary>
	/// 位于方向中轴上的得分
	/// </summary>
	public int SwordTombRightDirectionPoint = 200;

	/// <summary>
	/// 不位于方向中轴上的最大分数
	/// </summary>
	public int SwordTombNormalDirectionPoint = 200;

	/// <summary>
	/// 不位于中轴上的每单位距离的扣分
	/// </summary>
	public int SwordTombNormalDirectionOffset = 10;

	/// <summary>
	/// 和其它剑冢的最小距离
	/// </summary>
	public int SwordTombMinimumDistance = 6;

	/// <summary>
	/// 第一个剑冢和太吾村的最佳距离
	/// </summary>
	public int[] SwordTombFirstBestDistanceRange = new int[2] { 4, 6 };

	/// <summary>
	/// 剑冢和太吾村的最佳距离
	/// </summary>
	public int[] SwordTombNormalBestDistanceRange = new int[2] { 8, 9 };

	/// <summary>
	/// 最佳距离的得分
	/// </summary>
	public int SwordTombBestDistanceRangePoint = 250;

	/// <summary>
	/// 见闻剩余使用次数的最大值
	/// </summary>
	public int NormalInformationMaxRemainCount = 99;

	/// <summary>
	/// 可消耗的见闻能使用的默认最大回数
	/// </summary>
	public int NormalInformationDefaultCostableMaxUseCount = 3;

	/// <summary>
	/// 制造自动选择工具的品级分数
	/// </summary>
	public int[] MakeAutoSelectToolGradeScore = new int[9] { 3, 4, 5, 7, 9, 11, 14, 18, 23 };

	/// <summary>
	/// 制造自动选择工具的完全损耗分数
	/// </summary>
	public int[] MakeAutoSelectToolDestroyScore = new int[9] { 1, 3, 9, 22, 46, 84, 138, 211, 307 };

	/// <summary>
	/// 1~6级伤口疗伤所需造诣
	/// </summary>
	public short[] HealInjuryAttainment = new short[6] { 30, 60, 120, 210, 330, 480 };

	/// <summary>
	/// 1~3级中毒驱毒所需造诣
	/// </summary>
	public short[] HealPoisonAttainment = new short[3] { 60, 210, 480 };

	/// <summary>
	/// 滞碍、逆阻、紊乱、绝断调息所需造诣
	/// </summary>
	public short[] HealQiDisorderAttainment = new short[4] { 60, 210, 480, 480 };

	/// <summary>
	/// 抱恙、衰弱、垂危、濒死所需造诣
	/// </summary>
	public short[] HealHealthAttainment = new short[4] { 60, 210, 480, 480 };

	/// <summary>
	/// 疗伤基础药材花费
	/// </summary>
	public short HealInjuryBaseHerb = 20;

	/// <summary>
	/// 疗伤基础银钱花费
	/// </summary>
	public short HealInjuryBaseMoney = 100;

	/// <summary>
	/// 1~6级伤口疗伤所需额外药材
	/// </summary>
	public short[] HealInjuryExtraHerb = new short[6] { 10, 20, 40, 80, 160, 320 };

	/// <summary>
	/// 1~6级伤口疗伤所需额外银钱
	/// </summary>
	public short[] HealInjuryExtraMoney = new short[6] { 50, 100, 200, 400, 800, 1600 };

	/// <summary>
	/// 1~6级伤口疗伤所需地区恩义
	/// </summary>
	public short[] HealInjuryCostSpiritualDebt = new short[6] { 30, 60, 90, 120, 150, 180 };

	/// <summary>
	/// 驱毒基础药材花费
	/// </summary>
	public short HealPoisonBaseHerb = 20;

	/// <summary>
	/// 驱毒基础银钱花费
	/// </summary>
	public short HealPoisonBaseMoney = 100;

	/// <summary>
	/// 1~3级中毒驱毒所需额外药材
	/// </summary>
	public short[] HealPoisonExtraHerb = new short[3] { 20, 80, 320 };

	/// <summary>
	/// 1~3级中毒驱毒所需额外银钱
	/// </summary>
	public short[] HealPoisonExtraMoney = new short[3] { 100, 400, 1600 };

	/// <summary>
	/// 1~3级中毒驱毒所需地区恩义
	/// </summary>
	public short[] HealPoisonExtraSpiritualDebt = new short[3] { 60, 120, 180 };

	/// <summary>
	/// 顺畅、滞碍、逆阻、紊乱、绝断调息所需药材
	/// </summary>
	public short[] HealQiDisorderHerb = new short[5] { 20, 40, 80, 160, 320 };

	/// <summary>
	/// 顺畅、滞碍、逆阻、紊乱、绝断调息所需银钱
	/// </summary>
	public short[] HealQiDisorderMoney = new short[5] { 100, 200, 400, 800, 1600 };

	/// <summary>
	/// 顺畅、滞碍、逆阻、紊乱、绝断调息所需地区恩义
	/// </summary>
	public short[] HealQiDisorderCostSpiritualDebt = new short[5] { 60, 120, 180, 180, 180 };

	/// <summary>
	/// 康健、抱恙、衰弱、垂危、濒死复元所需药材
	/// </summary>
	public short[] HealHealthHerb = new short[5] { 40, 80, 160, 320, 1280 };

	/// <summary>
	/// 康健、抱恙、衰弱、垂危、濒死复元所需银钱
	/// </summary>
	public short[] HealHealthMoney = new short[5] { 200, 400, 800, 1600, 6400 };

	/// <summary>
	/// 康健、抱恙、衰弱、垂危、濒死复元所需地区恩义
	/// </summary>
	public short[] HealHealthCostSpiritualDebt = new short[5] { 60, 120, 180, 180, 180 };

	/// <summary>
	/// 不同立场大夫的疗伤驱毒调息复元收费百分比
	/// </summary>
	public short[] HealMoneyPercent = new short[5] { 150, 100, 200, 250, 300 };

	/// <summary>
	/// 计算驱毒时的造诣百分比
	/// </summary>
	public int HealPoisonAttainmentPercent = 1000;

	/// <summary>
	/// 计算调息时的造诣百分比（医术和毒术中更高的那个）
	/// </summary>
	public int HealQiDisorderAttainmentPercent = 500;

	/// <summary>
	/// 同个地格发生天灾的月份间隔
	/// </summary>
	public int LocationNaturalDisasterDuration = 12;

	/// <summary>
	/// 计算复元时的造诣百分比（医术和毒术中更高的那个）
	/// </summary>
	public int HealHealthAttainmentPercent = 100;

	/// <summary>
	/// 武林大会筹备物品价值除数
	/// </summary>
	public int MartialArtTournamentPreparationValueDivider = 1000;

	/// <summary>
	/// 武林大会战力除数
	/// </summary>
	public int MartialArtTournamentCombatPowerValueDivider = 100;

	/// <summary>
	/// 武林大会善门派声誉区间
	/// </summary>
	public (int, int) MartialArtTournamentGoodFameRange = (25, 1000);

	/// <summary>
	/// 武林大会中立门派声誉区间
	/// </summary>
	public (int, int) MartialArtTournamentNeutralFameRange = (-25, 25);

	/// <summary>
	/// 武林大会恶门派声誉区间
	/// </summary>
	public (int, int) MartialArtTournamentBadFameRange = (-1000, 25);

	/// <summary>
	/// 资源价值
	/// </summary>
	public static readonly sbyte[] ResourcesPrice = new sbyte[8] { 5, 5, 5, 5, 5, 5, 1, 10 };

	/// <summary>
	/// 历练价值
	/// </summary>
	public const sbyte ExpPrice = 5;

	/// <summary>
	/// 蛟代步和礼物10个属性的最大值,依次是:旅行时间,行囊负重,掉落加成,降服加成,俘虏栏位数量,价值,救治失心人加成,心情,好感
	/// </summary>
	public int[] JiaoMaxProperty = new int[9] { 60, 20000, 150, 150, 12, 123000, 150, 36, 21600 };

	/// <summary>
	/// 订单价格百分比
	/// </summary>
	public int ArtisanOrderPricePercent = 33;

	/// <summary>
	/// 截取订单价格倍数
	/// </summary>
	public int ArtisanOrderInterceptPricePercent = 300;

	/// <summary>
	/// 截取订单且较艺获胜价格额外百分比
	/// </summary>
	public int ArtisanOrderInterceptDebatePricePercent = 150;

	/// <summary>
	/// 奇书接受交换时按银钱衡量的原价
	/// </summary>
	public int ExchangeLegendaryBookBasePriceInCoin = 3000000;

	/// <summary>
	/// 交换藏书时各立场对书籍的价值的百分比影响
	/// </summary>
	public List<int[]> ExchangeBookBehaviorTypeToValuePercent = new List<int[]>
	{
		new int[2] { 200, 15 },
		new int[2] { 100, 30 },
		new int[2] { 150, 20 },
		new int[2] { 100, 30 },
		new int[2] { 200, 15 }
	};

	/// <summary>
	/// 交换藏书时藏书价值的除数
	/// </summary>
	public int ExchangeBookValueDivider = 10;

	/// <summary>
	/// 交换藏书时藏书耐久的基础百分比影响
	/// </summary>
	public int ExchangeBookValueDurabilityBasePercent = 50;

	/// <summary>
	/// 交换藏书时藏书耐久影响的百分比影响
	/// </summary>
	public int ExchangeBookValueDurabilityFactor = 50;

	/// <summary>
	/// 茶马帮携带货物可交易的西域货物等级小于等于4级时的交易成功概率惩罚
	/// </summary>
	public int CaravanExchangeProbPenalize = 50;

	/// <summary>
	/// 物品的价值转换为贡献值的百分比
	/// </summary>
	public int ItemContributionPercent = 100;

	/// <summary>
	/// 资源的价值转换为贡献值的百分比
	/// </summary>
	public int ResourceContributionPercent = 200;

	/// <summary>
	/// 夫妻发起爱慕概率
	/// </summary>
	public sbyte HusbandAndWifeStartAdoreChance = 25;

	/// <summary>
	/// 夫妻间爱慕判定冷却
	/// </summary>
	public sbyte HusbandAndWifeStartAdoreCooldown = 6;

	/// <summary>
	/// 适婚年龄范围
	/// </summary>
	public int[] GoodMarriageAgeRange = new int[2] { 20, 29 };

	/// <summary>
	/// 晚婚年龄范围
	/// </summary>
	public int[] LateMarriageAgeRange = new int[2] { 30, 39 };

	/// <summary>
	/// 适婚发起异地嫁娶概率
	/// </summary>
	public sbyte DistantMarriageGoodAgeChance = 5;

	/// <summary>
	/// 晚婚发起异地嫁娶概率
	/// </summary>
	public sbyte DistantMarriageLateAgeChance = 15;

	/// <summary>
	/// 适婚目标品级偏移范围
	/// </summary>
	public sbyte[] DistantMarriageGoodAgeTargetGradeRange = new sbyte[2] { 1, 3 };

	/// <summary>
	/// 晚婚目标品级偏移范围
	/// </summary>
	public sbyte[] DistantMarriageLateAgeTargetGradeRange = new sbyte[2] { -2, 0 };

	/// <summary>
	/// 适婚目标年龄范围, 数组的一级下标为性别.
	/// </summary>
	public int[][] DistantMarriageGoodAgeTargetAgeRange = new int[2][]
	{
		new int[2] { 24, 29 },
		new int[2] { 24, 39 }
	};

	/// <summary>
	/// 晚婚目标年龄范围, 数组的一级下标为性别.
	/// </summary>
	public int[][] DistantMarriageLateAgeTargetAgeRange = new int[2][]
	{
		new int[2] { 34, 39 },
		new int[2] { 34, 49 }
	};

	/// <summary>
	/// 拜认和收养所需的年龄差
	/// </summary>
	public int AdoptiveRelationAgeRequirement = 14;

	/// <summary>
	/// 遗物书籍完整概率系数
	/// </summary>
	public int BequestBookPageCompleteFactor = 3;

	/// <summary>
	/// 遗物书籍亡佚概率系数
	/// </summary>
	public int BequestBookPageLostFactor = 5;

	/// <summary>
	/// 亲近基础值=好感等级的绝对值*该系数
	/// </summary>
	public int[][] BequestBehaviorRelationFactor = new int[5][]
	{
		new int[8] { 10, 9, 8, 7, 6, 5, 4, 3 },
		new int[8] { 10, 9, 5, 6, 8, 7, 3, 4 },
		new int[8] { 9, 10, 6, 5, 8, 7, 4, 3 },
		new int[8] { 4, 5, 7, 3, 9, 8, 6, 10 },
		new int[8] { 8, 7, 5, 6, 4, 10, 3, 9 }
	};

	/// <summary>
	/// 亲近基础值*该系数
	/// </summary>
	public int BequestRelationPositiveFinalFactor = 100;

	/// <summary>
	/// 该系数-亲近基础值
	/// </summary>
	public int BequestRelationNegativeFinalFactor = 100;

	/// <summary>
	/// 亲进度阈值，超过的进入遗产分配备选
	/// </summary>
	public int BequestRelationThreshold = 1000;

	/// <summary>
	/// 基础概率=该值+接收者品阶-物品品级
	/// </summary>
	public int BequestProbabilityFactor1 = 8;

	/// <summary>
	/// 最终概率=基础概率*该系数
	/// </summary>
	public int BequestProbabilityFactor2 = 10;

	/// <summary>
	/// 遗物中生成书籍的概率
	/// </summary>
	public int BequestGenerateBookPercent;

	/// <summary>
	/// 遗物入库的概率
	/// </summary>
	public int[] BequestPublicPercent = new int[5] { 30, 25, 20, 15, 10 };

	/// <summary>
	/// 遗物继承的概率
	/// </summary>
	public int[] BequestPrivatePercent = new int[5] { 25, 30, 35, 40, 45 };

	/// <summary>
	/// 太吾初见好感基础值
	/// </summary>
	public int TaiwuBaseInitialFavorabilityValue = 3000;

	/// <summary>
	/// NPC初见好感基础值
	/// </summary>
	public int NpcBaseInitialFavorabilityValue = 15000;

	/// <summary>
	/// 秘闻 NPC 传播数目因子，和威望值判定有关
	/// </summary>
	public int SecretInformationNpcPlanDisseminateAmountFactor = 10000;

	/// <summary>
	/// 秘闻公开时单个类别显示的人物上限
	/// </summary>
	public int SecretInformationBroadcastNotifyElementDisplayLimit = 4;

	/// <summary>
	/// 秘闻商店角色在区域内收集秘闻的最大数目
	/// </summary>
	public int SecretInformationShopCharacterCollectInAreaMaxAmount = 15;

	/// <summary>
	/// 秘闻默认显示设置
	/// </summary>
	public sbyte[] SecretInformationDefaultDisplaySettings = new sbyte[5] { 0, 1, 1, 1, 1 };

	/// <summary>
	/// 秘闻接受后传播几率的等级阈值表
	/// </summary>
	public short[] SecretInformationReceivedDisseminateLevels = new short[4] { 0, 30, 50, 80 };

	/// <summary>
	/// 秘闻商店角色交易后的好感度变化
	/// </summary>
	public short[] SecretInformationShopCharacterFavorabilityChanges = new short[3] { 1000, 2000, 5000 };

	/// <summary>
	/// 秘闻来源角色获得威望相较传播消耗配置值的比率，20 则表示为传播消耗配置值的 20%
	/// </summary>
	public short SecretInformationSourceCharacterAuthorityGainToCostConfigRate = 20;

	/// <summary>
	/// 秘闻可使用的最大回数（未公开秘闻）
	/// </summary>
	public int SecretInformationInPrivateMaxUseCount = 3;

	/// <summary>
	/// 秘闻可使用的最大回数（公开秘闻）
	/// </summary>
	public int SecretInformationInBroadcastMaxUseCount = 3;

	/// <summary>
	/// 秘闻显示尺寸计算-秘闻物品品阶对应价值表
	/// </summary>
	public static readonly short[] SecretInformationDisplay_ItemGradeToValue = new short[9] { 0, 0, 0, 3, 6, 9, 33, 66, 99 };

	/// <summary>
	/// 秘闻显示尺寸计算-A位置门派人物地位对应价值表
	/// </summary>
	public static readonly short[] SecretInformationDisplay_PosASectCharGradeToValue = new short[9] { 1, 2, 3, 8, 10, 12, 21, 24, 27 };

	/// <summary>
	/// 秘闻显示尺寸计算-A位置非门派人物地位对应价值表
	/// </summary>
	public static readonly short[] SecretInformationDisplay_PosANotSectCharGradeToValue = new short[9] { 0, 0, 1, 1, 2, 2, 3, 4, 5 };

	/// <summary>
	/// 秘闻显示尺寸计算-B位置门派人物地位对应价值表
	/// </summary>
	public static readonly short[] SecretInformationDisplay_PosBSectCharGradeToValue = new short[9] { 1, 2, 3, 8, 10, 12, 21, 24, 27 };

	/// <summary>
	/// 秘闻显示尺寸计算-B位置非门派人物地位对应价值表
	/// </summary>
	public static readonly short[] SecretInformationDisplay_PosBNotSectCharGradeToValue = new short[9] { 0, 0, 1, 1, 2, 2, 3, 4, 5 };

	/// <summary>
	/// 秘闻显示尺寸计算-C位置门派人物地位对应价值表
	/// </summary>
	public static readonly short[] SecretInformationDisplay_PosCSectCharGradeToValue = new short[9] { 1, 2, 3, 8, 10, 12, 21, 24, 27 };

	/// <summary>
	/// 秘闻显示尺寸计算-C位置非门派人物地位对应价值表
	/// </summary>
	public static readonly short[] SecretInformationDisplay_PosCNotSectCharGradeToValue = new short[9] { 0, 0, 1, 1, 2, 2, 3, 4, 5 };

	/// <summary>
	/// 秘闻显示尺寸计算-A位置门派人物关系对应价值表
	/// </summary>
	public static readonly short[] SecretInformationDisplay_PosASectCharRelationTypeToValue = new short[18]
	{
		0, 99, 99, 99, 99, 99, 99, 99, 99, 99,
		15, 99, 6, 6, 3, 9, 12, 99
	};

	/// <summary>
	/// 秘闻显示尺寸计算-A位置非门派人物关系对应价值表
	/// </summary>
	public static readonly short[] SecretInformationDisplay_PosANotSectCharRelationTypeToValue = new short[18]
	{
		0, 99, 99, 99, 99, 99, 99, 99, 99, 99,
		15, 99, 6, 6, 3, 9, 12, 99
	};

	/// <summary>
	/// 秘闻显示尺寸计算-B位置门派人物关系对应价值表
	/// </summary>
	public static readonly short[] SecretInformationDisplay_PosBSectCharRelationTypeToValue = new short[18]
	{
		0, 99, 99, 99, 99, 99, 99, 99, 99, 99,
		15, 99, 6, 6, 3, 9, 12, 99
	};

	/// <summary>
	/// 秘闻显示尺寸计算-B位置非门派人物关系对应价值表
	/// </summary>
	public static readonly short[] SecretInformationDisplay_PosBNotSectCharRelationTypeToValue = new short[18]
	{
		0, 99, 99, 99, 99, 99, 99, 99, 99, 99,
		15, 99, 6, 6, 3, 9, 12, 99
	};

	/// <summary>
	/// 秘闻显示尺寸计算-C位置门派人物关系对应价值表
	/// </summary>
	public static readonly short[] SecretInformationDisplay_PosCSectCharRelationTypeToValue = new short[18]
	{
		0, 99, 99, 99, 99, 99, 99, 99, 99, 99,
		15, 99, 6, 6, 3, 9, 12, 99
	};

	/// <summary>
	/// 秘闻显示尺寸计算-C位置非门派人物关系对应价值表
	/// </summary>
	public static readonly short[] SecretInformationDisplay_PosCNotSectCharRelationTypeToValue = new short[18]
	{
		0, 99, 99, 99, 99, 99, 99, 99, 99, 99,
		15, 99, 6, 6, 3, 9, 12, 99
	};

	/// <summary>
	/// 秘闻尺寸划分阈值
	/// </summary>
	public static readonly ushort[] SecretInformationDisplay_SizeThresholds = new ushort[3] { 0, 60, 130 };

	/// <summary>
	/// 秘闻公开时,不同立场人物的心情变化的百分比修正
	/// </summary>
	public short[] BroadcastSecretInformationHappinessAdjust = new short[5] { 100, 133, 66, 166, 33 };

	/// <summary>
	/// 关系的系数 按照RelationDisplayType的顺序 最后一个是太吾自己
	/// </summary>
	public int[] SecretRelationFactor = new int[11]
	{
		99, 15, 99, 99, 1, 12, 3, 9, 6, 99,
		99
	};

	/// <summary>
	/// 门派的系数
	/// </summary>
	public int[] SecretSectFactor = new int[9] { 1, 2, 3, 8, 10, 12, 21, 24, 27 };

	/// <summary>
	/// 非门派的系数
	/// </summary>
	public int[] SecretNonSectFactor = new int[9] { 1, 2, 3, 5, 9, 12, 15, 18, 21 };

	/// <summary>
	/// 物品的系数
	/// </summary>
	public int[] SecretItemFactor = new int[9] { 0, 0, 0, 3, 6, 7, 33, 66, 99 };

	/// <summary>
	/// 关系的分数
	/// </summary>
	public int[] SecretRelationScore = new int[3] { 0, 3, 11 };

	/// <summary>
	/// 人物的分数
	/// </summary>
	public int[] SecretCharScore = new int[3] { 1, 3, 10 };

	/// <summary>
	/// 物品的分数
	/// </summary>
	public int[] SecretItemScore = new int[3] { 1, 5, 15 };

	/// <summary>
	/// 重要程度的分数
	/// </summary>
	public int[] SecretSortValueScore = new int[3] { 1, 6, 22 };

	/// <summary>
	/// 秘闻等级区间
	/// </summary>
	public int[] SecretLevelRange = new int[2] { 100, 400 };

	/// <summary>
	/// 三魔三才初始入魔值
	/// </summary>
	public int ThreeVitalsInitInfection = 50;

	/// <summary>
	/// 三魔三才最小入魔值
	/// </summary>
	public int ThreeVitalsMinInfection;

	/// <summary>
	/// 三魔三才最大入魔值
	/// </summary>
	public int ThreeVitalsMaxInfection = 100;

	/// <summary>
	/// 三魔三才每月入魔值变化
	/// </summary>
	public int ThreeVitalsInfectionDelta = 5;

	/// <summary>
	/// 三魔三才入魔值较低阈值
	/// </summary>
	public int ThreeVitalsThresholdLow = 20;

	/// <summary>
	/// 三魔三才入魔值较高阈值
	/// </summary>
	public int ThreeVitalsThresholdHigh = 80;

	/// <summary>
	/// 三魔三才为敌概率基础系数
	/// </summary>
	public int ThreeVitalsDefectionBase = 50;

	/// <summary>
	/// 三魔三才为敌概率额外系数
	/// </summary>
	public int ThreeVitalsDefectionExtra = 5;

	/// <summary>
	/// 界青星运要求
	/// </summary>
	public int JieQingPointRequire = 50;

	/// <summary>
	/// 五仙驱动王蛊需要消耗的资源类型
	/// </summary>
	public sbyte WuxianDriveWugKingCostResourceType = 5;

	/// <summary>
	/// 五仙驱动王蛊需要消耗的资源量
	/// </summary>
	public int WuxianDriveWugKingCostResourceCount = 5000;

	/// <summary>
	/// 五仙驱动王蛊后，同一种蛊要冷却几个月才能再次驱动
	/// </summary>
	public short WuxianDriveWugKingCooldown = 6;

	/// <summary>
	/// 五仙驱动王蛊需要消耗的精力
	/// </summary>
	public short WuxianDriveWugKingCostActionPoint = 50;

	/// <summary>
	/// 百花生关死节对象和太吾的精纯差值要求 
	/// </summary>
	public sbyte BaihuaLifeLinkTargetConsummate = 4;

	/// <summary>
	/// 无字切换状态的月数
	/// </summary>
	public sbyte WordlessStatusChangeDuration = 3;

	/// <summary>
	/// 无字和太吾的距离
	/// </summary>
	public sbyte WordlessStatusStep = 2;

	/// <summary>
	/// 造化生人所需精力
	/// </summary>
	public const int CreateMirrorCharacterCost = 10;

	/// <summary>
	/// 羽毛值上限
	/// </summary>
	public int FeatherValueMax = 6400;

	/// <summary>
	/// 每只羽毛消耗的羽毛值
	/// </summary>
	public int FeatherValuePerFeather = 100;

	/// <summary>
	/// 每月基础羽毛值增加
	/// </summary>
	public int FeatherValueBaseMonthly = 12;

	/// <summary>
	/// 每只元鸡每月额外增加
	/// </summary>
	public int FeatherValuePerChicken = 2;

	/// <summary>
	/// 初次解锁羽毛值
	/// </summary>
	public int InitialFeatherValue = 50;

	/// <summary>
	/// 初次解锁元鸡产毛数量
	/// </summary>
	public int InitialFeatherChickens = 3;

	/// <summary>
	/// 培育羽毛获得的羽毛值
	/// </summary>
	public int CultivateFeatherValue = 700;

	/// <summary>
	/// 培育羽毛每种资源消耗
	/// </summary>
	public int CultivateCost = 7000;

	/// <summary>
	/// 培育羽毛精力消耗
	/// </summary>
	public int CultivateEnergyCost = 10;

	/// <summary>
	/// 大王拔毛获得羽毛数量
	/// </summary>
	public int KingFeatherCount = 2;

	/// <summary>
	/// 界青星运上限
	/// </summary>
	public int MaximumJieQingPoint = 99999;

	/// <summary>
	/// 奇纹星台初始上限
	/// </summary>
	public int NormalQiwenXingtaiCount = 3;

	/// <summary>
	/// 奇纹星台进阶上限
	/// </summary>
	public int AdvancedQiwenXingtaiCount = 9;

	/// <summary>
	/// 玉蝉将一段时日内所得星运尽数赠予了太吾的概率……
	/// </summary>
	public int GainExtraJieqingXingyunProbability = 20;

	/// <summary>
	/// 玉蝉将一段时日内所得星运尽数赠予了太吾的最小数量（含此数值）……
	/// </summary>
	public int GainExtraJieqingXingyunValueMinInclusive = 500;

	/// <summary>
	/// 玉蝉将一段时日内所得星运尽数赠予了太吾的最大数量（不含此数值）……
	/// </summary>
	public int GainExtraJieqingXingyunValueMaxExclusive = 501;

	/// <summary>
	/// 公库资源补充范围
	/// </summary>
	public List<short[]> TreasuryResourceSupplyRanges = new List<short[]>
	{
		new short[2] { 100, 150 },
		new short[2] { 200, 300 },
		new short[2] { 300, 450 },
		new short[2] { 400, 600 },
		new short[2] { 500, 750 }
	};

	/// <summary>
	/// 公库道具补充次数
	/// </summary>
	public List<sbyte[]> TreasuryItemSupplyCounts = new List<sbyte[]>
	{
		new sbyte[9] { 4, 3, 2, 2, 2, 1, 1, 1, 0 },
		new sbyte[9] { 5, 4, 3, 2, 2, 2, 2, 1, 1 },
		new sbyte[9] { 6, 5, 4, 3, 3, 2, 3, 2, 1 },
		new sbyte[9] { 7, 6, 5, 4, 4, 3, 3, 3, 2 },
		new sbyte[9] { 8, 7, 6, 5, 5, 4, 4, 3, 3 }
	};

	/// <summary>
	/// 成员提升速度因子
	/// </summary>
	public List<int> MemberSelfImproveSpeedFactor = new List<int> { 50, 100, 200 };

	/// <summary>
	/// 库房匮乏情况
	/// </summary>
	public int[] TreasuryStatusThreshold = new int[2] { 80, 120 };

	/// <summary>
	/// 库房守卫数量
	/// </summary>
	public int TreasuryGuardCount = 2;

	/// <summary>
	/// 城镇库房守卫最高品级
	/// </summary>
	public List<sbyte> TreasuryGuardMaxGrade = new List<sbyte> { 2, 4, 6 };

	/// <summary>
	/// 门派城镇库房守卫最高品级
	/// </summary>
	public List<sbyte> SectTreasuryGuardMaxGrade = new List<sbyte> { 3, 5, 7 };

	/// <summary>
	/// 中层库房门派支持度要求
	/// </summary>
	public int TreasuryRquireApprovingMid = 40;

	/// <summary>
	/// 深层库房门派支持度要求
	/// </summary>
	public int TreasuryRquireApprovingHigh = 70;

	/// <summary>
	/// 中层库房地区恩义要求
	/// </summary>
	public int TreasuryRquireSpiritualDebtMid = 400;

	/// <summary>
	/// 深层库房地区恩义要求
	/// </summary>
	public int TreasuryRquireSpiritualDebtHigh = 700;

	/// <summary>
	/// 中层监狱的门派支持度要求(40.0)
	/// </summary>
	public int PrisonRequireApprovingMid = 400;

	/// <summary>
	/// 深层监狱的门派支持度要求(70.0)
	/// </summary>
	public int PrisonRequireApprovingHigh = 700;

	/// <summary>
	/// 清库前总价值达到清库后总价值的百分比时规模提升
	/// </summary>
	public int TreasurySupplyLevelUpPercent = 150;

	/// <summary>
	/// 默认戒严时间（单位为月）
	/// </summary>
	public int[] TreasuryAlterTime = new int[3] { 3, 6, 12 };

	/// <summary>
	/// 默认守卫精纯，目前用于计算无智能NPC守卫时囚徒的抵抗度
	/// </summary>
	public int[] GuardConsummateLevel = new int[3] { 6, 10, 14 };

	/// <summary>
	/// 时节提供的威力加成
	/// </summary>
	public sbyte SolarTermAddCombatSkillPower = 10;

	/// <summary>
	/// 时节提供的外伤治疗增益
	/// </summary>
	public sbyte SolarTermAddHealOuterInjury = 20;

	/// <summary>
	/// 时节提供的内伤治疗增益
	/// </summary>
	public sbyte SolarTermAddHealInnerInjury = 20;

	/// <summary>
	/// 时节提供的调息加成
	/// </summary>
	public sbyte SolarTermAddRecoverQiDisorder = 10;

	/// <summary>
	/// 时节提供的毒效加成
	/// </summary>
	public sbyte SolarTermAddHealPoison = 20;

	/// <summary>
	/// 时节提供的驱毒增益
	/// </summary>
	public sbyte SolarTermAddPoisonEffect = 20;

	/// <summary>
	/// 时节提供的恢复健康增益
	/// </summary>
	public sbyte SolarTermAddHealth = 20;

	/// <summary>
	/// 一年包含的月数
	/// </summary>
	public const sbyte MonthsPerYear = 12;

	/// <summary>
	/// 一月包含的天数
	/// </summary>
	public const sbyte DaysPerMonth = 30;

	/// <summary>
	/// 一天包含的行动点数
	/// </summary>
	public const int ActionPointsPerDay = 10;

	/// <summary>
	/// 每月精力最大值
	/// </summary>
	public int ActionPointLimitPerMonth = 600;

	/// <summary>
	/// 每月精力恢复值
	/// </summary>
	public int ActionPointRecoveryPerMonth = 300;

	/// <summary>
	/// 玄狱词条时不我待激活时每月精力最大值
	/// </summary>
	public int MoreActionPointLimitPerMonth = 900;

	/// <summary>
	/// 玄狱词条时不我待激活时每月精力恢复值
	/// </summary>
	public int MoreActionPointRecoveryPerMonth = 450;

	/// <summary>
	/// 故事开始时间固定为第一年的六月
	/// </summary>
	public int GameStartDate = 8;

	/// <summary>
	/// 城镇属地范围以外可以生成普通地形的范围
	/// </summary>
	public int MapNormalBlockRange = 3;

	/// <summary>
	/// 每块已经探索的地图区域会使新开通传驿通路的威望需求增加值
	/// </summary>
	public byte MapAreaOpenPrestige = 50;

	/// <summary>
	/// 初始解锁所有驿站的州域数量（太吾村州域+相邻州域）
	/// </summary>
	public sbyte MapInitUnlockStationStateCount = 3;

	/// <summary>
	/// 从婴儿变成孩童的年龄
	/// </summary>
	public int AgeBaby = 3;

	/// <summary>
	/// 从孩童变成成年人的年龄 (同时也是创建人物时的最小年龄和玄灰特性开始生效的年龄)
	/// </summary>
	public const int AgeAdult = 16;

	/// <summary>
	/// 玄灰导致的死亡年龄 - 中年分组
	/// </summary>
	public const int AgeDarkAsh = 40;

	/// <summary>
	/// 玄灰导致的死亡年龄 - 老年分组
	/// </summary>
	public const int AgeDarkAshVictim = 70;

	/// <summary>
	/// 玄灰导致的青年分组 - 接收玄灰死亡额度比例
	/// </summary>
	public const int DarkAshWeightAdult = 1;

	/// <summary>
	/// 玄灰导致的中年分组 - 接收玄灰死亡额度比例
	/// </summary>
	public const int DarkAshWeightSemi = 3;

	/// <summary>
	/// 玄灰导致的老年分组 - 接收玄灰死亡额度比例
	/// </summary>
	public const int DarkAshWeightOld = 6;

	/// <summary>
	/// 玄灰人口阈值百分比波动上限
	/// </summary>
	public int PopulationLimitRandomRateMax = 120;

	/// <summary>
	/// 创建人物时的最大年龄
	/// </summary>
	public int MaxAgeOfCreatingChar = 30;

	/// <summary>
	/// 显示上嘴唇胡须的年龄
	/// </summary>
	public int AgeShowBeard1 = 20;

	/// <summary>
	/// 显示下嘴唇胡须的年龄
	/// </summary>
	public int AgeShowBeard2 = 30;

	/// <summary>
	/// 显示抬头纹年龄判断条件之一，判断当前年龄大于等于此值
	/// </summary>
	public int AgeShowWrinkle1 = 60;

	/// <summary>
	/// 显示表情纹的年龄判断条件之一，判断当前年龄大于等于此值
	/// </summary>
	public int AgeShowWrinkle2 = 70;

	/// <summary>
	/// 显示眼袋纹的年龄判断条件之一，判断当前年龄大于等于此值
	/// </summary>
	public int AgeShowWrinkle3 = 50;

	/// <summary>
	/// 捏脸系统中人物没有任何特征的几率,以10000为100%
	/// </summary>
	public int AvatarNoneFeatureObb = 5000;

	/// <summary>
	/// 捏脸系统中人物具有正面的特征的几率,以10000为100%
	/// </summary>
	public int AvatarHasFeature1Obb = 2500;

	/// <summary>
	/// 捏脸系统中人物具有负面的特征的几率,以10000为100%
	/// </summary>
	public int AvatarHasFeature2Obb = 2500;

	/// <summary>
	/// 捏脸系统中人物魅力由于被特征丑化而掉档的几率,以10000为100%
	/// </summary>
	public int AvatarBadFeatureObb = 500;

	/// <summary>
	/// 捏脸系统中人物没有任何胡子的几率,以10000为100%
	/// </summary>
	public int AvatarNoneBeardObb = 2500;

	/// <summary>
	/// 人物形象随机算法中毛发异色的概率,最大值为100
	/// </summary>
	public byte AvatarFurColorSplitObb = 10;

	/// <summary>
	/// 人物一旦毛发异色,则[单独胡子异色的概率,单独眉毛异色的概率,单独头发异色的概率,全异色的概率],所有概率值之和最大为100
	/// </summary>
	public byte[] AvatarFurColorSplitObbArray = new byte[4] { 20, 40, 30, 10 };

	/// <summary>
	/// 遗传算法中遗传信息发生突变的几率,以10000为100%
	/// </summary>
	public int AvatarChanceMutation = 1000;

	/// <summary>
	/// 基础魅力中眉毛的魅力占比,四个占比之和是1
	/// </summary>
	public float EyebrowRatioInBaseCharm = 0.2f;

	/// <summary>
	/// 基础魅力中眼睛的魅力占比,四个占比之和是1
	/// </summary>
	public float EyesRatioInBaseCharm = 0.4f;

	/// <summary>
	/// 基础魅力中鼻子的魅力占比,四个占比之和是1
	/// </summary>
	public float NoseRatioInBaseCharm = 0.2f;

	/// <summary>
	/// 基础魅力中嘴巴的魅力占比,四个占比之和是1
	/// </summary>
	public float MouthRatioInBaseCharm = 0.2f;

	/// <summary>
	/// 研读参考书栏位数上限
	/// </summary>
	public const byte MaxReferenceBookSlotCount = 3;

	/// <summary>
	/// 中文语境下姓名的姓氏长度限制和名字长度限制
	/// </summary>
	public byte[] NameLengthConfig_CN = new byte[2] { 2, 2 };

	/// <summary>
	/// 英文语境下姓名的姓氏长度限制和名字长度限制
	/// </summary>
	public byte[] NameLengthConfig_EN = new byte[2] { 6, 6 };

	/// <summary>
	/// 五行属性对应字体颜色
	/// </summary>
	public string[] FiveElementsTypeColor = new string[6] { "yellow", "darkpurple", "darkcyan", "red", "lightgreen", "white" };

	/// <summary>
	/// 功法基础威力上限
	/// </summary>
	public short CombatSkillMaxBasePower = 100;

	/// <summary>
	/// 功法最终威力下限
	/// </summary>
	public const sbyte CombatSkillMinPower = 10;

	/// <summary>
	/// 功法最终威力上限
	/// </summary>
	public short CombatSkillMaxPower = 9999;

	/// <summary>
	/// 功法使用需求百分比下限
	/// </summary>
	public const sbyte CombatSkillRequirementMinPercent = 10;

	/// <summary>
	/// 装备基础威力上限
	/// </summary>
	public short EquipmentBaseMaxPower = 180;

	/// <summary>
	/// 装备最终威力上限
	/// </summary>
	public const short EquipmentMaxPower = 9999;

	/// <summary>
	/// 地块资源采集收获百分比
	/// </summary>
	public sbyte CollectResourcePercent = 33;

	/// <summary>
	/// 修炼了有驻颜效果的功法后, 生理年龄的固定值
	/// </summary>
	public short RejuvenatedAge = 20;

	/// <summary>
	/// 未成年时的固定魅力
	/// </summary>
	public short ImmaturityAttraction = 400;

	/// <summary>
	/// 带面具或面纱的固定魅力
	/// </summary>
	public short MaskOrVeilAttraction = 400;

	/// <summary>
	/// 蛐蛐活动开始月份
	/// </summary>
	public byte CricketActiveStartMonth = 7;

	/// <summary>
	/// 蛐蛐活动结束月份
	/// </summary>
	public byte CricketActiveEndMonth = 10;

	/// <summary>
	/// 蛐蛐鸣叫单组最小数量
	/// </summary>
	public byte[] CricketSingGroupCricketCountMin = new byte[3] { 3, 3, 3 };

	/// <summary>
	/// 蛐蛐鸣叫单组最大数量
	/// </summary>
	public byte[] CricketSingGroupCricketCountMax = new byte[3] { 6, 6, 6 };

	/// <summary>
	/// 蛐蛐鸣叫单组最小起始时间（秒）
	/// </summary>
	public float[] CricketSingGroupStartTimeMin = new float[3] { 0.5f, 10f, 12.5f };

	/// <summary>
	/// 蛐蛐鸣叫单组最大起始时间（秒）
	/// </summary>
	public float[] CricketSingGroupStartTimeMax = new float[3] { 7.5f, 15f, 22.5f };

	/// <summary>
	/// 蛐蛐鸣叫单组最小次数
	/// </summary>
	public byte[] CricketSingGroupSingCountMin = new byte[3] { 2, 1, 0 };

	/// <summary>
	/// 蛐蛐鸣叫单组最大次数
	/// </summary>
	public byte[] CricketSingGroupSingCountMax = new byte[3] { 4, 3, 2 };

	/// <summary>
	/// 蛐蛐单次鸣叫最小基础时间（秒）
	/// </summary>
	public float CricketSingBaseTimeMin = 0.5f;

	/// <summary>
	/// 蛐蛐单次鸣叫最大基础时间（秒）
	/// </summary>
	public float CricketSingBaseTimeMax = 1f;

	/// <summary>
	/// 蛐蛐单次鸣叫每品级蛐蛐额外时间（秒）
	/// </summary>
	public float CricketSingGradeTime = 0.1f;

	/// <summary>
	/// 蛐蛐单次鸣叫最小间隔时间（秒）
	/// </summary>
	public float CricketSingDelayTimeMin = 0.5f;

	/// <summary>
	/// 蛐蛐单次鸣叫最大间隔时间（秒）
	/// </summary>
	public float CricketSingDelayTimeMax = 2f;

	/// <summary>
	/// 捕捉蛐蛐必然成功的鸣叫音量（含）
	/// </summary>
	public short CatchCricketSuccessSingLevel = 95;

	/// <summary>
	/// 地图每个州域中的区域个数
	/// </summary>
	public const sbyte AreaPerState = 9;

	/// <summary>
	/// 地图每个州域中的正常区域个数
	/// </summary>
	public const sbyte NormalAreaPerState = 3;

	/// <summary>
	/// 地图废弃区域宽度
	/// </summary>
	public const byte BrokenAreaWidth = 5;

	/// <summary>
	/// 不同阶级的团体角色的基础影响力
	/// </summary>
	public short[] OrgCharBaseInfluencePowers = new short[9] { 10, 20, 30, 50, 70, 90, 120, 160, 210 };

	/// <summary>
	/// 团体支持度的最大值
	/// </summary>
	public const short OrgMaxApprovingRate = 1000;

	/// <summary>
	/// 标记地点数基础上限
	/// </summary>
	public short MarkLocationBaseMaxCount = 10;

	/// <summary>
	/// 州的个数
	/// </summary>
	public const sbyte StatesCount = 15;

	/// <summary>
	/// 大门派的个数
	/// </summary>
	public const sbyte LargeSectsCount = 15;

	/// <summary>
	/// 调息吐纳为 100% 时, 恢复的内息紊乱值
	/// </summary>
	public short RecoveryOfQiDisorderUnitValue = 40;

	/// <summary>
	/// 每完成一次祠堂传授,威望花费的步进值
	/// </summary>
	public ushort ShrineAuthorityPerTime = 200;

	/// <summary>
	/// 不同级别的坟墓的最大耐久
	/// </summary>
	public short[] GraveDurabilities = new short[4] { 6, 12, 36, 72 };

	/// <summary>
	/// 不同级别的坟墓的金钱消耗
	/// </summary>
	public short[] GraveLevelMoneyCosts = new short[4] { 0, 1000, 3000, 9000 };

	/// <summary>
	/// 每年太吾祠堂增加威望的月份
	/// </summary>
	public sbyte ShrineAuthorityAddMonth = 1;

	/// <summary>
	/// 建筑建造操作派遣人数上限
	/// </summary>
	public const sbyte BuildingOperatorMaxCount = 3;

	/// <summary>
	/// 经营类建筑经营者人数上限
	/// </summary>
	public const sbyte ShopManagerMaxCount = 7;

	/// <summary>
	/// 建筑指派预设数目，存档数量，不可修改
	/// </summary>
	public const sbyte BuildingOptionAutoGiveMemberPresetCount = 9;

	/// <summary>
	/// 建筑指派预设数目，使用数量，不能超过存档数量
	/// </summary>
	public const sbyte BuildingOptionAutoGiveMemberPresetActiveCount = 3;

	/// <summary>
	/// 经营建筑中村民潜力提升的最大次数
	/// </summary>
	public sbyte TaiwuVillagerMaxPotential = 36;

	/// <summary>
	/// 最大主要属性值的保底值
	/// </summary>
	public short MinValueOfMaxMainAttributes = 1;

	/// <summary>
	/// 最大主要属性值的最大值
	/// </summary>
	public short MaxValueOfMaxMainAttributes = 9999;

	/// <summary>
	/// 攻防属性的保底值
	/// </summary>
	public short MinValueOfAttackAndDefenseAttributes = 20;

	/// <summary>
	/// 次要属性的 A 类中间值的最小值
	/// </summary>
	public short MinAValueOfMinorAttributes = 20;

	/// <summary>
	/// 次要属性的最大值
	/// </summary>
	public const short MaxValueOfMinorAttributes = 1000;

	/// <summary>
	/// 角色的各个可生长的形象部件的生长时间 (月)
	/// </summary>
	public sbyte[] AvatarElementGrowthDurations = new sbyte[7] { 18, 12, 12, 0, 0, 0, 18 };

	/// <summary>
	/// 角色的基础喜恶变化周期, 单位年
	/// </summary>
	public sbyte BaseHobbyChangingPeriod = 4;

	/// <summary>
	/// 较艺系统中不同立场的力量波动值
	/// </summary>
	public List<short[]> LifeSkillCombatPowerWave = new List<short[]>
	{
		new short[3] { 100, 100, 100 },
		new short[3] { 80, 100, 120 },
		new short[3] { 110, 80, 110 },
		new short[3] { 80, 140, 80 },
		new short[3] { 120, 100, 80 }
	};

	/// <summary>
	/// 较艺系统中不同立场的 AI 演出举棋不定次数的随机范围
	/// </summary>
	public List<byte[]> LifeSkillCombatAISwingRange = new List<byte[]>
	{
		new byte[2] { 1, 2 },
		new byte[2] { 2, 4 },
		new byte[2] { 1, 4 },
		new byte[2] { 2, 4 },
		new byte[2] { 1, 2 }
	};

	/// <summary>
	/// 天灾地块生成天材地宝奇遇的机率（%）
	/// </summary>
	public sbyte DisasterAdventureSpawnChance = 35;

	/// <summary>
	/// 天灾触发判定相邻格的范围
	/// </summary>
	public sbyte[] DisasterTriggerRanges = new sbyte[4] { 0, 1, 2, 3 };

	/// <summary>
	/// 天灾触发对附近格的戾气百分比总和的要求阈值
	/// </summary>
	public short[] DisasterTriggerNeighborSumThresholds = new short[4] { 100, 155, 290, 425 };

	/// <summary>
	/// 天灾触发对当前地格的戾气百分比要求阈值
	/// </summary>
	public sbyte[] DisasterTriggerCurrBlockThresholds = new sbyte[4] { 100, 75, 50, 25 };

	/// <summary>
	/// 毁坏区域各等级敌人的分布
	/// </summary>
	public sbyte[] BrokenAreaEnemyCountLevelDist = new sbyte[3] { 6, 4, 2 };

	/// <summary>
	/// 资源价值
	/// </summary>
	public static readonly sbyte[] ResourcesWorth = new sbyte[8] { 5, 5, 5, 5, 5, 5, 1, 10 };

	/// <summary>
	/// 资源交换、押注等行为时的最小资源单位
	/// </summary>
	public static readonly short[] UnitsOfResourceTransfer = new short[8] { 20, 20, 20, 20, 20, 20, 100, 10 };

	/// <summary>
	/// 角色阶层决定的事物价值因子 (角色阶层越高, 在其心中无法用金钱买到的事物的价值就越高)
	/// </summary>
	public short[] WorthFactorsOfGrade = new short[9] { 1, 2, 4, 8, 16, 32, 64, 128, 256 };

	/// <summary>
	/// 转让资源道具后, 对方的好感及好感上限的允许的最低值
	/// </summary>
	public short MinFavorabilityAfterTransferring = 14000;

	/// <summary>
	/// 无坐骑情况下的劫持软上限基础值
	/// </summary>
	public short KidnapSlotBaseMaxCount = 1;

	/// <summary>
	/// 劫持角色转移时的抵抗值变化
	/// </summary>
	public sbyte ResistChangeOnKidnapCharacterTransfer = 20;

	/// <summary>
	/// 奇遇格最小七元消耗
	/// </summary>
	public sbyte AdventureNodePersonalityMinCost = 1;

	/// <summary>
	/// 奇遇格最大七元消耗
	/// </summary>
	public sbyte AdventureNodePersonalityMaxCost = 10;

	/// <summary>
	/// 鸡 - 杂虫心情加成
	/// </summary>
	public sbyte ChickenMiscTaste = 20;

	/// <summary>
	/// 鸡 - 零心情逃跑几率
	/// </summary>
	public float ChickenEscapeRate = 0.1f;

	/// <summary>
	/// 鸡 - 心情衰减下限
	/// </summary>
	public sbyte ChickenDecayMin = 1;

	/// <summary>
	/// 鸡 - 心情衰减上限
	/// </summary>
	public sbyte ChickenDecayMax = 2;

	/// <summary>
	/// 轮回台进度最大值
	/// </summary>
	public sbyte SamsaraPlatformMaxProgress = 18;

	/// <summary>
	/// 轮回台转世到门派的概率
	/// </summary>
	public sbyte SamsaraPlatformBornInSectOdds = 75;

	/// <summary>
	/// 轮回台属性值加成基础百分比
	/// </summary>
	public sbyte SamsaraPlatformAddBasePercent = 2;

	/// <summary>
	/// 轮回台属性值加成每级提升百分比
	/// </summary>
	public sbyte SamsaraPlatformAddPercentPerLevel = 3;

	/// <summary>
	/// 遗惠抽取分组等级所需的世界细节得分阈值
	/// </summary>
	public sbyte[] LegacyGroupLevelThresholds = new sbyte[4] { 0, 30, 60, 120 };

	/// <summary>
	/// 随机从卡池中抽取遗惠卡的遗惠点消耗的基础值，每次抽取后再抽翻倍
	/// </summary>
	public int SelectRandomLegacyCost = 500;

	/// <summary>
	/// 迷香阵占领后获得人物的技艺资质修正加成。
	/// </summary>
	public short MixiangzhenLifeSkillAdjustBonus = 70;

	/// <summary>
	/// 迷香阵占领后获得人物的技艺资质修正加成的技艺类型数量。
	/// </summary>
	public int MixiangzhenLifeSkillAdjustTypeCount = 3;

	/// <summary>
	/// 修罗场占领后获得人物的功法资质修正加成。
	/// </summary>
	public short XiuluochangCombatSkillAdjustBonus = 70;

	/// <summary>
	/// 修罗场占领后获得人物的功法资质修正加成的功法类型数量。
	/// </summary>
	public int XiuluochangCombatSkillAdjustTypeCount = 3;

	/// <summary>
	/// 贤士馆招募人才每人花费威望
	/// </summary>
	public short RecruitPeopleCost = 3000;

	/// <summary>
	/// 生成含装备特效的装备的概率
	/// </summary>
	public sbyte EquipmentWithEffectRate = 25;

	/// <summary>
	/// 厢房容量
	/// </summary>
	public sbyte ComfortableHouseCapacity = 3;

	/// <summary>
	/// 藏书阁修补九种品级书籍各需要的总进度
	/// </summary>
	public short[] FixBookTotalProgress = new short[9] { 150, 200, 300, 500, 800, 1200, 1800, 2600, 3600 };

	/// <summary>
	/// [缓慢,正常,较快,极快]下剑冢奇遇持续时间
	/// </summary>
	public short[] SwordTombAdventureLastMonthCount = new short[4] { -99, 108, 72, 36 };

	/// <summary>
	/// [缓慢,正常,较快,极快]下剑冢奇遇再次进入异动的冷却时间
	/// </summary>
	public static readonly short[] SwordTombAdventureCountDownCoolDown = new short[4] { 36, 12, 6, 3 };

	/// <summary>
	/// 从上一次比武大会举办完成到下一次开始筹备的间隔时间
	/// </summary>
	public const sbyte MartialArtTournamentInterval = 108;

	/// <summary>
	/// 比武大会筹备时间
	/// </summary>
	public const sbyte MartialArtTournamentPreparationDuration = 12;

	/// <summary>
	/// 比武大会等待角色就位的最长时间
	/// </summary>
	public const sbyte MartialArtTournamentWaitMaxDuration = 6;

	/// <summary>
	/// 0~9级世界侵袭度下,门派支持度的上限
	/// </summary>
	public short[] SectApprovingRateUpperLimits = new short[10] { 30, 30, 40, 50, 60, 70, 80, 90, 100, 100 };

	/// <summary>
	/// 0~9级世界侵袭度下,入魔人的品级限制（&gt;此品级限制的人物入魔值无论何种原因均不会增加）
	/// </summary>
	public sbyte[] XiangshuInfectionGradeUpperLimits = new sbyte[10] { 1, 1, 2, 3, 4, 5, 6, 7, 8, 8 };

	/// <summary>
	/// 遗惠传承插画的阈值
	/// </summary>
	public int[] LegacyImageThreshold = new int[5] { 0, 3000, 6000, 9000, 12000 };

	/// <summary>
	/// 促织、较艺、切磋、挑战的胜利方心情
	/// </summary>
	public int[] OtherCombatWinHappiness = new int[5] { 2, 3, 2, 3, 2 };

	/// <summary>
	/// 促织、较艺、切磋、挑战的失败方心情
	/// </summary>
	public int[] OtherCombatLoseHappiness = new int[5] { -2, -3, -2, -3, -2 };

	/// <summary>
	/// 促织、较艺、切磋、挑战的胜利方对失败方好感
	/// </summary>
	public int[] OtherCombatWinFavorability = new int[5] { -1200, -600, 0, -600, -1200 };

	/// <summary>
	/// 促织、较艺、切磋、挑战的失败方对胜利方好感
	/// </summary>
	public int[] OtherCombatLoseFavorability = new int[5] { 600, 1200, 600, 1200, 600 };

	/// <summary>
	/// 作恶行为消耗的属性
	/// </summary>
	public sbyte HarmfulActionCost = 10;

	/// <summary>
	/// 全局作恶行为调节（0 为无修正）
	/// </summary>
	public short HarmfulActionSuccessGlobalFactor;

	/// <summary>
	/// 作恶行为阶段基础成功率
	/// </summary>
	public sbyte HarmfulActionPhaseBaseSuccessRate = 90;

	/// <summary>
	/// 太吾祠堂每月增加威望系数
	/// </summary>
	public sbyte TaiwuShrineAddAuthorityFactor = 5;

	/// <summary>
	/// 入魔速度,index为 0:悲极 1:痛苦 2:沮丧
	/// </summary>
	public sbyte[] XiangshuInfectionAddSpeed = new sbyte[3] { 5, 3, 1 };

	/// <summary>
	/// 正练书页“修”增加走火入魔伤害概率
	/// </summary>
	public sbyte DirectPageAddInjuryOdds = 40;

	/// <summary>
	/// 逆练书页“用”免除走火入魔伤害概率
	/// </summary>
	public sbyte ReversePageNoInjuryOdds = 60;

	/// <summary>
	/// 每个品级的功法技艺造诣加成值
	/// </summary>
	public sbyte[] AddAttainmentPerGrade = new sbyte[9] { 10, 10, 15, 20, 20, 25, 30, 40, 50 };

	/// <summary>
	/// 从俘虏身上拿取物品的最大数量限制
	/// </summary>
	public short TakeItemFromPrisonerMaxCount = 9999;

	/// <summary>
	/// 装备负重大于100%/200%/300%时对应的移动速度、攻击速度、施展速度百分比
	/// </summary>
	public int[] EquipLoadSpeedPercent = new int[3] { 80, 50, 20 };

	/// <summary>
	/// 装备负重大于100%/200%/300%时对应的步伐稳健、引气冲关、武具运用百分比
	/// </summary>
	public int[] EquipHealSpeedPercent = new int[3] { 110, 125, 140 };

	/// <summary>
	/// 真气最小变化值（特效影响后不可低于该值）
	/// </summary>
	public const byte NeiliAllocationChangeMinValue = 1;

	/// <summary>
	/// 战斗中真气低于初始真气时自动增加总进度值
	/// </summary>
	public int CombatNeiliAllocationAutoAddTotalProgress = 24000;

	/// <summary>
	/// 战斗中真气高于初始真气时自动减少总进度值
	/// </summary>
	public int CombatNeiliAllocationAutoReduceTotalProgress = 18000;

	/// <summary>
	/// 功法提供的真气加成系数
	/// </summary>
	public int CombatSkillNeiliAllocationBonusPercent = 25;

	/// <summary>
	/// 中毒量上限
	/// </summary>
	public const int MaxPoisonedValue = 25000;

	/// <summary>
	/// 混合毒素最小可发作次数
	/// </summary>
	public const int MixPoisonAffectCountMin = 1;

	/// <summary>
	/// 混合毒素最大可发作次数
	/// </summary>
	public const int MixPoisonAffectCountMax = 4;

	/// <summary>
	/// 称赞羞辱的级别上限,依次是：赋性,魅力,名誉,特性,财富
	/// </summary>
	public int[] TalkByPraiseOrSneerMaxDegree = new int[5] { 5, 4, 3, 5, 5 };

	/// <summary>
	/// 称赞羞辱的每级好感,依次是：赋性,魅力,名誉,特性,财富
	/// </summary>
	public int[] TalkByPraiseOrSneerPerDegreeFavorability = new int[5] { 120, 150, 200, 120, 120 };

	/// <summary>
	/// 称赞效果的立场倍率
	/// </summary>
	public int[] TalkByPraiseBehaviorRate = new int[5] { 2, 3, 4, -2, 3 };

	/// <summary>
	/// 羞辱效果的立场倍率
	/// </summary>
	public int[] TalkBySneerBehaviorRate = new int[5] { -2, -3, -4, 2, -3 };

	/// <summary>
	/// 坟墓互动-祭拜故人所需的银钱
	/// </summary>
	public int[] MourningMoneyCost = new int[4] { 50, 100, 300, 900 };

	/// <summary>
	/// 坟墓互动-修葺坟墓所需的银钱
	/// </summary>
	public int[] UpgradeGraveMoneyCost = new int[3] { 1000, 3000, 9000 };

	/// <summary>
	/// 坟墓互动-摸金倒斗依次跳转到对应事件的概率（无事发生,盗掘资源/道具,骷髅人战斗）
	/// </summary>
	public sbyte[] RobGraveEventWeight = new sbyte[3] { 50, 40, 20 };

	/// <summary>
	/// 研读已读完的书历练获取百分比
	/// </summary>
	public sbyte ReadingFinishedBookExpGainPercent = 20;

	/// <summary>
	/// 计算兵器CD时重量额外加值
	/// </summary>
	public short WeaponCdExtraWeight = 150;

	/// <summary>
	/// 显示白发的年龄
	/// </summary>
	public short AgeShowWhiteHair = 60;

	/// <summary>
	/// 人物身份品级对要挟难度的影响系数
	/// </summary>
	public int ThreatenDifficultyFactorOfGrade = 6;

	/// <summary>
	/// 人物处世立场对要挟难度的影响系数
	/// </summary>
	public int[] ThreatenDifficultyFactorOfBehaviorType = new int[5] { 18, 12, 6, 12, 18 };

	/// <summary>
	/// 人物的正面好感类型对要挟难度的影响系数
	/// </summary>
	public int[] ThreatenDifficultyFactorOfPositiveFavorType = new int[5] { 0, -300, -200, 300, 200 };

	/// <summary>
	/// 人物的负面好感类型对要挟难度的影响系数
	/// </summary>
	public int[] ThreatenDifficultyFactorOfNegativeFavorType = new int[5] { -200, -300, 200, -300, 0 };

	/// <summary>
	/// 秘闻重要程度对要挟力度的影响系数
	/// </summary>
	public int ThreatenEffectFactorOfSortValue = 2;

	/// <summary>
	/// 秘闻已知人数对要挟力度的影响系数
	/// </summary>
	public int ThreatenEffectFactorOfHolderCount = 30;

	/// <summary>
	/// 对于城镇人物而言,秘闻重要程度对要挟力度的额外修正
	/// </summary>
	public int ThreatenEffectDenominatorOfCityAndTown = 3;

	/// <summary>
	/// 玩家名誉的绝对值对要挟力度的额外修正
	/// </summary>
	public int ThreatenEffectDenominatorOfFame = 2;

	/// <summary>
	/// 战斗中修理每1点耐久消耗帧数
	/// </summary>
	public short RepairInCombatFrameUnit = 6;

	/// <summary>
	/// 通过穿针引线结成关系的难度的品级影响
	/// </summary>
	public int GradeFactorOfStartRelationDifficultyByThreadNeedle = 6;

	/// <summary>
	/// 通过穿针引线结成关系的难度的立场参数
	/// </summary>
	public int[] BehaviorBonusOfStartRelationDifficultyByThreadNeedle = new int[5] { 18, 6, 12, 6, 18 };

	/// <summary>
	/// 通过穿针引线结成关系的难度的人物立场对好感影响的修正
	/// </summary>
	public int[] BehaviorFactorOfStartRelationDifficultyByThreadNeedle = new int[5] { 0, 300, 200, -300, 100 };

	/// <summary>
	/// 通过穿针引线断绝关系的难度的品级影响
	/// </summary>
	public int GradeFactorOfEndRelationDifficultyByThreadNeedle = -6;

	/// <summary>
	/// 通过穿针引线断绝关系的难度的立场影响
	/// </summary>
	public int[] BehaviorBonusOfEndRelationDifficultyByThreadNeedle = new int[5] { -18, -6, -12, -6, -18 };

	/// <summary>
	/// 通过穿针引线断绝关系的难度的人物立场对好感影响的修正
	/// </summary>
	public int[] BehaviorFactorOfEndRelationDifficultyByThreadNeedle = new int[5] { 0, -300, -200, 300, -100 };

	/// <summary>
	/// 通过穿针引线结成关系的力度的秘闻重要程度的影响
	/// </summary>
	public int SortValueFactorOfStartRelationEffectByThreadNeedle = 4;

	/// <summary>
	/// 通过穿针引线结成关系的力度的提议者名誉的影响
	/// </summary>
	public int FameFactorPromotedOfStartRelationEffectByThreadNeedle = 4;

	/// <summary>
	/// 通过穿针引线结成关系的力度的指定人物名誉的影响
	/// </summary>
	public int FameFactorNominatedOfStartRelationEffectByThreadNeedle = 2;

	/// <summary>
	/// 较艺卡组的初级卡牌数量上限
	/// </summary>
	public int LifeSkillBattlePrimaryCardMaxUsedCount = 18;

	/// <summary>
	/// 较艺卡组的中级卡牌数量上限
	/// </summary>
	public int LifeSkillBattleMiddleCardMaxUsedCount = 9;

	/// <summary>
	/// 较艺卡组的高级卡牌数量上限
	/// </summary>
	public int LifeSkillBattleHighCardMaxUsedCount = 3;

	/// <summary>
	/// 奇书解锁突破盘所需时间
	/// </summary>
	public int LegendaryBookUnlockBreakPlateTime = 10;

	/// <summary>
	/// 奇书属性加成点解锁所需历练值
	/// </summary>
	public int[] LegendaryBookUnlockExp = new int[24]
	{
		500, 1000, 1500, 2000, 2500, 3000, 3500, 4000, 4500, 5000,
		5500, 6000, 6500, 7000, 7500, 8000, 8500, 9000, 9500, 10000,
		10500, 11000, 11500, 12000
	};

	/// <summary>
	/// 打败剑冢数量对应的奇书出现数量（包含教学剑冢）
	/// </summary>
	public sbyte[] LegendaryBookAppearAmounts = new sbyte[6] { 0, 1, 2, 4, 8, 14 };

	/// <summary>
	/// 奇书出现几率
	/// </summary>
	public sbyte LegendaryBookAppearChance = 33;

	/// <summary>
	/// 诚恳求取奇书时不同立场的人物处于成长阶段要求太吾的世界排名配置
	/// </summary>
	public int[] RequestLegendaryBookRequireRankWhenOwningBook = new int[5] { 40, 80, 20, 10, 5 };

	/// <summary>
	/// 诚恳求取奇书时不同立场的人物处于执迷阶段要求太吾的世界排名配置
	/// </summary>
	public int[] RequestLegendaryBookRequireRankWhenShocked = new int[5] { 24, 48, 12, 6, 3 };

	/// <summary>
	/// NPC接受奇书作为礼物时不同立场的人物对于自身世界排名的需求配置
	/// </summary>
	public int[] AcceptLegendaryBookAsGiftRequireRank = new int[5] { 5, 25, 100, 1000, 500 };

	/// <summary>
	/// 检测近亲相交时的代数判定 (检查关系方父母辈的交集视为一代)
	/// </summary>
	public sbyte InsectDetectionGenerationCount = 2;

	/// <summary>
	/// 挖掘宝藏的品级概率加成
	/// </summary>
	public sbyte[] FindTreasureGradeRate = new sbyte[9] { 40, 35, 30, 25, 20, 15, 10, 5, 1 };

	/// <summary>
	/// 单次精挑细选需要的资源数量
	/// </summary>
	public int ChoosyResourceBaseCost = 1000;

	/// <summary>
	/// 1~3级的中毒等级对应的中毒量阈值
	/// </summary>
	public short[] PoisonLevelThresholds = new short[3] { 500, 3500, 12500 };

	/// <summary>
	/// 毒抗最大值
	/// </summary>
	public const int MaxPoisonResistance = 1000;

	/// <summary>
	/// 宝物减少毒抗百分比
	/// </summary>
	public int AccessoryReducePoisonPercent = 100;

	/// <summary>
	/// 真气加成效果百分比
	/// </summary>
	public int AllocatedNeiliEffectPercent = 100;

	/// <summary>
	/// NPC突破功法基础成功率
	/// </summary>
	public sbyte NpcBreakoutBaseSuccessRate = 40;

	/// <summary>
	/// 门派特殊饰品功法威力加成
	/// </summary>
	public sbyte SectAccessoryBonusCombatSkillPower = 20;

	/// <summary>
	/// 村民工作带来的资质提升上限
	/// </summary>
	public const int VillageWorkQualificationImproveLimit = 30;

	/// <summary>
	/// 动物转世概率
	/// </summary>
	public sbyte AnimalSamsaraChance = 10;

	/// <summary>
	/// 外道巢穴劫持的角色过月健康变化
	/// </summary>
	public short EnemyNestKidnappedCharHealthChange = -12;

	/// <summary>
	/// 资源上限
	/// </summary>
	public const int ResourceLimit = 999999999;

	/// <summary>
	/// 对话记录最大保存记录数量
	/// </summary>
	public const int EventLogLimit = 99;

	/// <summary>
	/// 正常情况下的精纯上限
	/// </summary>
	public const int ConsummateLevelUpperLimit = 18;

	/// <summary>
	/// 请教功法时根据对方功法正逆练类型来确定书页为逆练的概率
	/// </summary>
	public static readonly short[] CombatSkillPageReverseProb = new short[3] { 50, 25, 75 };

	/// <summary>
	/// 最大精纯点数
	/// </summary>
	public sbyte MaxConsummateLevel = 18;

	/// <summary>
	/// 野兽代步最大驯服度
	/// </summary>
	public int MaxCarrierTamePoint = 100;

	/// <summary>
	/// 太吾学习功法、npc指点太吾功法时功法的初始修习度参数
	/// </summary>
	public int LearnCombatSkillPracticeLevelParam = 50;

	/// <summary>
	/// 功法单次修习增长修习度所需造诣
	/// </summary>
	public int[] CombatSkillPracticeLevelBonusRequirements = new int[5] { 0, 30, 100, 210, 360 };

	/// <summary>
	/// 功法单次修习增长修习度
	/// </summary>
	public int[] CombatSkillPracticeLevelBonus = new int[5] { 1, 2, 3, 4, 5 };

	/// <summary>
	/// 劝说不同人物品级俘虏需要的名誉值
	/// </summary>
	public int[] PersuadePrisonerNeedFrame = new int[9] { 25, 30, 40, 50, 60, 70, 80, 90, 100 };

	/// <summary>
	/// 神龙生成时周围小龙的数量上限
	/// </summary>
	public int FiveLoongDlcMinionLoongMaxCount = 12;

	/// <summary>
	/// 神龙地形行走时每种负面标记数量上限
	/// </summary>
	public int FiveLoongDlcMaxDebuffCount = 99;

	/// <summary>
	/// 蛟卵的孵化总时长
	/// </summary>
	public int JiaoEggIncubationTime = 3;

	/// <summary>
	/// 蛟的繁育总时长
	/// </summary>
	public int JiaoBreedingTime = 3;

	/// <summary>
	/// 初始时蛟卵的掉落率
	/// </summary>
	public int InitJiaoEggDropRate = 20;

	/// <summary>
	/// 初始时雄性蛟卵的掉落率
	/// </summary>
	public int InitMaleJiaoEggDropRate = 50;

	/// <summary>
	/// 养育蛟急进助长失败概率计算的公式参数
	/// </summary>
	public int[] BringUpJiaoCalcParam = new int[3] { 100, 50, 1 };

	/// <summary>
	/// 养育蛟急进助长失败概率计算的立场补正
	/// </summary>
	public int[] BringUpJiaoBehaviorParam = new int[5] { 60, 40, 80, 150, 120 };

	/// <summary>
	/// 在一片神龙地格最多可埋藏待挖掘的龙鳞数量
	/// </summary>
	public int BurriedScalesOfEachLoongArea = 18;

	/// <summary>
	/// 在一片神龙地格最多可埋藏待挖掘的蛟卵数量
	/// </summary>
	public int BurriedEggsOfEachLoongArea = 3;

	/// <summary>
	/// 每次击败小龙但并未获得蛟卵后蛟卵掉落增加的概率
	/// </summary>
	public int JiaoEggDropRateUpPerMiss = 20;

	/// <summary>
	/// 未成年的蛟被抓回时驯服度的增加量
	/// </summary>
	public int JiaoTamePointAddWhenCaught = 15;

	/// <summary>
	/// 资源地格被产业建筑依赖时发生的衰减百分比，每多一个产业建筑依赖此资源地格，这个影响就会多一层
	/// </summary>
	public int BuildingResourceYieldLevelAttenuationPercent = 80;

	/// <summary>
	/// 蛟龙代步属性遗传系数（第一个值为父母先天基础值的遗传比例，第二个值为父母后天养成值的遗传比例）
	/// </summary>
	public int[] JiaoLoongCarrierPropertyFactor = new int[2] { 60, 40 };

	/// <summary>
	/// 蛟龙礼物属性遗传系数（第一个值为父母最终属性的遗传比例，第二个值为父母后天养成值的遗传比例）
	/// </summary>
	public int[] JiaoLoongGiftPropertyFactor = new int[2] { 45, 30 };

	/// <summary>
	/// 蛟龙表现属性遗传系数（第一个值为父母先天基础值的遗传比例，第二个值为父母后天养成值的遗传比例）
	/// </summary>
	public int[] JiaoLoongPresentPropertyFactor = new int[2] { 30, 20 };

	/// <summary>
	/// 蛟的驯服度的初始值范围
	/// </summary>
	public int[] JiaoInitialTamePoint = new int[2] { 50, 70 };

	/// <summary>
	/// 蛟逃跑概率收到立场的补正
	/// </summary>
	public int[] JiaoFleeBehaviorInfluence = new int[5] { 60, 40, 80, 150, 120 };

	/// <summary>
	/// 蛟逃跑抓捕后属性变化的立场补正
	/// </summary>
	public int[] JiaoPropertyChangeBehaviorInfluence = new int[5] { 80, 50, 100, 200, 150 };

	/// <summary>
	/// 击败神龙获得的龙鳞数量
	/// </summary>
	public int DefeatLoongGetScaleCount = 9;

	/// <summary>
	/// 第一次随机进化结果需要的龙鳞
	/// </summary>
	public int RequiredLoongScaleForFirstTimeEvolution = 9;

	/// <summary>
	/// 后续随机进化结果需要的龙鳞
	/// </summary>
	public int RequiredLoongScaleForEvolution = 3;

	/// <summary>
	/// 每次获得一个蛟卵后，蛟卵性别掉率改变量
	/// </summary>
	public int JiaoEggGenderModification = 25;

	/// <summary>
	/// 赌坊·青楼在经营遭到失败后获得下次经营成功的几率补正值
	/// </summary>
	public int TaiwuVillageMoneyPrestigeCompensation = 10;

	/// <summary>
	/// 蛟池安抚功能，每次安抚增加的驯服度的值
	/// </summary>
	public int PettingJiaoAddsTamingPoints = 15;

	/// <summary>
	/// 蛟池安抚功能使用技能后的冷却月份
	/// </summary>
	public int PettingJiaoFunctionCoolDuration = 3;

	/// <summary>
	/// 生成蛐蛐时，人物每个品阶对应的蛐蛐生成品阶基础参数
	/// </summary>
	public sbyte[] BaseCricketGrade = new sbyte[9] { 0, 0, 0, 1, 2, 3, 4, 4, 5 };

	/// <summary>
	/// 蛐蛐决斗时，人物每个品阶对应的奖励基准品阶
	/// </summary>
	public sbyte[] BaseCricketWagerGrade = new sbyte[9] { 0, 1, 2, 2, 3, 4, 4, 5, 6 };

	/// <summary>
	/// 生成第一只蛐蛐时，人物杂学造诣的除值，值越高，蛐蛐升级次数越少
	/// </summary>
	public int EclecticDivisor = 150;

	/// <summary>
	/// 生成第三只蛐蛐时，纯杂学造诣方式的除值，值越高，蛐蛐升级次数越少
	/// </summary>
	public int PureEclecticDivisor = 75;

	/// <summary>
	/// 生成第三只蛐蛐时，纯身份方式，人物身份品阶转化为蛐蛐品阶的减值
	/// </summary>
	public int CharGradeDecrement = -2;

	/// <summary>
	/// 战斗资源掉落数量范围
	/// </summary>
	public int[] CombatResourceDropParam = new int[9] { 100, 200, 400, 700, 900, 1400, 2000, 4000, 7000 };

	/// <summary>
	/// 万蛊坛炼制王蛊消耗的毒素总量
	/// </summary>
	public int WugJugRefiningCostPoison = 10000;

	/// <summary>
	/// 万蛊坛当月多次炼制王蛊额外消耗的毒素总量百分比
	/// </summary>
	public int WugJugRefiningCostPoisonBonusPercent = 100;

	/// <summary>
	/// 万蛊坛每间隔一月减少额外消耗的毒素总量百分比
	/// </summary>
	public int WugJugRefiningCostPoisonMonthPercent = -50;

	/// <summary>
	/// 万蛊坛投入毒素量系数
	/// </summary>
	public int WugJugPoisonDropRatio = 10;

	/// <summary>
	/// 食物对坐骑的耐久度增加值，品级0-8
	/// </summary>
	public int[] FoodGradeAddCarrierDurability = new int[9] { 30, 30, 30, 60, 60, 60, 90, 90, 90 };

	/// <summary>
	/// 坐骑喜欢的食物的耐久度额外加值
	/// </summary>
	public int LikeFoodAddCarrierDurability = 30;

	/// <summary>
	/// 坐骑讨厌的食物的耐久度额外减值
	/// </summary>
	public int DislikeFoodAddCarrierDurability = -30;

	/// <summary>
	/// 五仙恩义互动五圣秘浴移除蛊虫数
	/// </summary>
	public int WuxianSpiritualDebtInteractionRemoveWugCount = 3;

	/// <summary>
	/// 五仙恩义互动五圣秘浴变化王蛊持续时间
	/// </summary>
	public short WuxianSpiritualDebtInteractionChangeWugKingDuration = -12;

	/// <summary>
	/// 经营建筑总造诣值的最终除数
	/// </summary>
	public int BuildingTotalAttainmentFinalDivisor = 3;

	/// <summary>
	/// 经营建筑售卖道具在基础价格的基础上的额外加成百分比
	/// </summary>
	public int BuildingSoldItemExtraAddFactor = 40;

	/// <summary>
	/// 经营产出随机因子上限
	/// </summary>
	public int BuildingOutputRandomFactorUpperLimit = 120;

	/// <summary>
	/// 经营产出随机因子下限
	/// </summary>
	public int BuildingOutputRandomFactorLowerLimit = 80;

	/// <summary>
	/// 参考书栏位解锁需要的任意技艺造诣(三本书)
	/// </summary>
	public int[] ReferenceBookSlotUnlockParams = new int[3] { 0, 200, 400 };

	/// <summary>
	/// 可以驱灭外道的精纯差（太吾高于敌方）
	/// </summary>
	public int RandomEnemyEscapeConsummateLevelGap = 4;

	/// <summary>
	/// 各个相枢进度下，产业经营时村名能习得技艺的最高品级
	/// </summary>
	public sbyte[] ShopManagerLearnSkillMaxGrades = new sbyte[10] { 1, 1, 2, 3, 4, 5, 6, 7, 8, 8 };

	/// <summary>
	/// 产业经营者习得功法、技艺时随机品级的概率
	/// </summary>
	public sbyte ShopManagerLearnRandomGradeChance = 25;

	/// <summary>
	/// 参考书品阶对书籍研读效率的基础加成倍率
	/// </summary>
	public int LifeSkillBookRefBonus = 15;

	/// <summary>
	/// 同类型书或特定技艺书对书籍研读效率的特殊加成倍率
	/// </summary>
	public int SameTypeBookRefBonus = 30;

	/// <summary>
	/// 门派角色在组织中超过一定品级将获得修行特性
	/// </summary>
	public int AddMemberFeatureMinGrade = 3;

	/// <summary>
	/// 最大公库守卫数量
	/// </summary>
	public int MaxTreasuryGuardCount = 3;

	/// <summary>
	/// 最大公库守卫级别
	/// </summary>
	public sbyte MaxTreasuryGuardGrade = 7;

	/// <summary>
	/// 公库守卫同道指令冷却加成（百分比）
	/// </summary>
	public int TreasuryGuardTeammateCdBonus = -80;

	/// <summary>
	/// 公库守卫获取同道攻防命中值百分比
	/// </summary>
	public int TreasuryGuardPropertyPercent = 75;

	/// <summary>
	/// 公库守卫获取同道造诣百分比（计算发挥威力时）
	/// </summary>
	public int TreasuryGuardAttainmentPercent = 150;

	/// <summary>
	/// 对人物行囊物品的敌对行为(唬骗、偷窃、抢夺)消耗的时间
	/// </summary>
	public int HostileOperationTakeItemCostTime = 5;

	/// <summary>
	/// 对人物行囊资源物品进行敌对行为(唬骗、偷窃、抢夺)时，资源的上限限制倍率，用总量除以该配置
	/// </summary>
	public int HostileOperationTakeItemMaxResourceFactor = 5;

	/// <summary>
	/// 主动研读进度上限
	/// </summary>
	public short MaxActiveReadingProgress = 30;

	/// <summary>
	/// 主动周天进度上限
	/// </summary>
	public short MaxActiveNeigongLoopingProgress = 30;

	/// <summary>
	/// 额外真气获取上限（从额外真气进度中）
	/// </summary>
	public short MaxExtraNeiliAllocation = 50;

	/// <summary>
	/// 多少个额外真气进度换算一个额外真气
	/// </summary>
	public short ExtraNeiliAllocationFromProgressRatio = 55;

	/// <summary>
	/// 最多多少个天人感应挂在太吾身上
	/// </summary>
	public short MaxQiArtStrategyCount = 3;

	/// <summary>
	/// 人物级别对应的警惕参数
	/// </summary>
	public sbyte[] CharacterGradeAlertness = new sbyte[9] { 1, 1, 2, 2, 3, 3, 4, 4, 5 };

	/// <summary>
	/// 主动研读扣多少属性
	/// </summary>
	public short ActiveReadingAttributeCost = 3;

	/// <summary>
	/// 主动周天扣多少属性
	/// </summary>
	public short ActiveNeigongLoopingAttributeCost = 3;

	/// <summary>
	/// 主动研读扣多少天时间
	/// </summary>
	public short ActiveReadingTimeCost = 1;

	/// <summary>
	/// 主动周天扣多少天时间
	/// </summary>
	public short ActiveNeigongLoopingTimeCost = 1;

	/// <summary>
	/// 鼠标停留多少秒才显示tips
	/// </summary>
	public float MouseTipDelayTime = 0.2f;

	/// <summary>
	/// 辅助功法栏位解锁需要的任意武学造诣(三本书)
	/// </summary>
	public int[] ReferenceSkillSlotUnlockParams = new int[3] { 0, 200, 400 };

	/// <summary>
	/// 产生天人感应的基础概率
	/// </summary>
	public sbyte BaseLoopingEventProbability = 20;

	/// <summary>
	/// 暗害行为的造诣阈值
	/// </summary>
	public short[] PlotHarmActionAttainmentThresholds = new short[6] { 30, 60, 150, 210, 360, 450 };

	/// <summary>
	/// 毒害行为的造诣阈值
	/// </summary>
	public short[] PoisonActionAttainmentThresholds = new short[3] { 60, 210, 450 };

	/// <summary>
	/// 额外真气的ExtraNeiliAllocationFromProgressRatio值是动态的，开始是基础值，每过一次台阶获得一个额外真气，这个台阶就上涨此值一次。所以每次的台阶是：ExtraNeiliAllocationFromProgressRatio + 已获得额外真气 * ExtraNeiliAllocationFromProgressRatioGrowth
	/// </summary>
	public short ExtraNeiliAllocationFromProgressRatioGrowth = 5;

	/// <summary>
	/// 主动研读进度影响的主动研读效率（最后的乘算）
	/// </summary>
	public short[] ActiveReadProgressAffectedEfficiency = new short[3] { 150, 100, 50 };

	/// <summary>
	/// 主动周天进度影响的主动周天效率（最后的乘算）
	/// </summary>
	public short[] ActiveLoopProgressAffectedEfficiency = new short[3] { 150, 100, 50 };

	/// <summary>
	/// 选择的参与演化的铭刻人物的数量上限
	/// </summary>
	public int InscriptionCharForCreationMaxCount = 100;

	/// <summary>
	/// 库房互动获取的最大物品数量，包括交换和窃取
	/// </summary>
	public int SettlementTreasuryGetItemMaxCount = 9;

	/// <summary>
	/// 库房互动给予的最大物品数量，包括交换和赠送
	/// </summary>
	public int SettlementTreasuryGiveItemMaxCount = 9;

	/// <summary>
	/// 百花生关死节杀死人物后的冷却时间
	/// </summary>
	public sbyte BaihuaLifeLinkRemoveCharacterCooldown = 6;

	/// <summary>
	/// 伏龙天火伤害
	/// </summary>
	public sbyte FulongFlameDamage = 1;

	/// <summary>
	/// 琉璃的炸弹伤害
	/// </summary>
	public sbyte FulongMineDamage = 2;

	/// <summary>
	/// 琉璃的炸弹对太吾的伤害
	/// </summary>
	public sbyte FulongMineDamageTaiwu = 4;

	/// <summary>
	/// 定居点库房、监牢被强闯后的戒严时间
	/// </summary>
	public int SettlementAlterTime = 6;

	/// <summary>
	/// 互动中空手进行毒害行为，人物毒术造诣每过一个阈值，调用的欠恩失义公式中视作道具level品级加1
	/// </summary>
	public short[] PoisonByToxicologyAttainmentThresholds = new short[9] { 50, 100, 150, 200, 210, 300, 360, 450, 600 };

	/// <summary>
	/// 淬毒凝炼后的毒量加成
	/// </summary>
	public int CondensedPoisonValueBonus = 50;

	/// <summary>
	/// 淬毒凝炼所需的造诣加成
	/// </summary>
	public int CondensePoisonRequiredAttainmentBonus = 50;

	/// <summary>
	/// 伏龙灭火所需时间
	/// </summary>
	public int FulongFlameExtinguishCost = 1;

	/// <summary>
	/// 地格有多少资源才可以给农户迁移
	/// </summary>
	public short VillagerRoleFarmerMigrateMinResource = 120;

	/// <summary>
	/// 迁移资源基础成功率
	/// </summary>
	public short VillagerRoleFarmerMigrateBaseSuccessRate = 10;

	/// <summary>
	/// 伏龙灭火每个火区的炸弹数量
	/// </summary>
	public int FulongFlameBoomNumber = 6;

	/// <summary>
	/// 伏龙灭火火区的自行消失时长
	/// </summary>
	public int FulongFlameExtinguishTime = 5;

	/// <summary>
	/// 贵客三技能，每月最多可恢复的额外行动力
	/// </summary>
	public int ProfessionSkillRecoverActionPointLimit = 300;

	/// <summary>
	/// NPC造诣盘精纯计数
	/// </summary>
	public int[] ConsummateLevelPoints = new int[9] { 5, 10, 15, 20, 25, 30, 35, 45, 55 };

	/// <summary>
	/// NPC精纯进度提升速度
	/// </summary>
	public int[] ConsummateLevelProgressSpeed = new int[9] { 127, 150, 187, 240, 315, 390, 510, 660, 975 };

	/// <summary>
	/// NPC精纯提升进度阈值
	/// </summary>
	public int[] ConsummateLevelProgressThreshold = new int[18]
	{
		400, 800, 1200, 1600, 2000, 2400, 2800, 3200, 3600, 4000,
		4400, 4800, 5200, 5600, 6000, 6400, 6800, 7200
	};

	/// <summary>
	/// 云游僧技能3根据当前资质评级来增加资质的数量
	/// </summary>
	public short[] TravelingBuddhistMonkSkill2QualificationDelta = new short[9] { 3, 3, 3, 2, 2, 2, 1, 1, 1 };

	/// <summary>
	/// 传武/艺书籍选择最大数量
	/// </summary>
	public int TeachSkillBookSelctMaxCount = 9;

	/// <summary>
	/// 传武/艺角色选择最大数量
	/// </summary>
	public int TeachSkillCharacterMaxCount = 12;

	/// <summary>
	/// 修理机关人内外伤造诣需求
	/// </summary>
	public short[] GearMateRepairInjuryAttainmentRequirement = new short[6] { 30, 60, 120, 210, 330, 480 };

	/// <summary>
	/// 修理机关人中毒造诣需求
	/// </summary>
	public short[] GearMateRepairPoisonAttainmentRequirement = new short[3] { 60, 210, 480 };

	/// <summary>
	/// 修理机关人紊乱造诣需求
	/// </summary>
	public short[] GearMateRepairDisorderOfQiAttainmentRequirement = new short[5] { 0, 60, 210, 480, 480 };

	/// <summary>
	/// 参考书加成的基础相加项
	/// </summary>
	public int BaseRefBonusSpeed = 30;

	/// <summary>
	/// 每月资历变化
	/// </summary>
	public int ProfessionSeniorityPerMonth = 10000;

	/// <summary>
	/// 每月太吾气泡显示的时机
	/// </summary>
	public int TaiwuBubbleBoxDisplayRequirement = 15;

	/// <summary>
	/// 追踪野兽技能，概率公式因子 A
	/// </summary>
	public int HunterSkill2_OddFormulaFactorA = 20;

	/// <summary>
	/// 追踪野兽技能，概率公式因子 B
	/// </summary>
	public int HunterSkill2_OddFormulaFactorB = 20;

	/// <summary>
	/// 追踪野兽，第一只，第二只，第三只追踪到的野兽精纯取值
	/// </summary>
	public List<byte[]> HunterSkill2_AnimalCountIndexToAnimalConsummateLevelList = new List<byte[]>
	{
		new byte[4] { 0, 2, 4, 6 },
		new byte[4] { 4, 6, 8, 10 },
		new byte[4] { 8, 10, 12, 14 }
	};

	/// <summary>
	/// 资历百分比小于80，能追踪到1只；小于90,2只；小于100,3只
	/// </summary>
	public short[] HunterSkill2_SeniorityPercentToAnimalCount = new short[3] { 80, 90, 100 };

	/// <summary>
	/// 太吾向NPC请教志向获得的资历.
	/// </summary>
	public int[] TeachProfessionSkillSeniority = new int[4] { 3000, 12000, 36000, 72000 };

	/// <summary>
	/// 牢房里绳子抵抗值效果百分比
	/// </summary>
	public short KidnapResistanceBonusInPrison = 100;

	/// <summary>
	/// 山人4查看地格物品精力消耗
	/// </summary>
	public short SavageSkill3_OpenItemSelectTimeCost = 10;

	/// <summary>
	/// 额外资历导致给予见闻的资历百分比计算因子
	/// </summary>
	public short GiveProfessionInformationFactorWithExtraSeniority = 50;

	/// <summary>
	/// 太吾请教npc职业经验的冷却
	/// </summary>
	public const short CharacterTeachTaiwuProfessionCoolDown = 12;

	/// <summary>
	/// 大夫4技能金针渡命转移的寿元百分比
	/// </summary>
	public int DoctorSkill3_HealthTransferPercent = 50;

	/// <summary>
	/// 大夫4技能金针渡命增加的好感度百分比
	/// </summary>
	public int DoctorSkill3_FavorabilityChangePercent = 500;

	/// <summary>
	/// 太吾村民势力值的阶级划分比例
	/// </summary>
	public short[] VillagerInfluencePowerRankingRatio = new short[9] { 1, 2, 3, 5, 8, 12, 17, 22, 30 };

	/// <summary>
	/// 茶酒内息变动的上下限
	/// </summary>
	public int[] TeaWineEffectDisorderOfQiDelta = new int[2] { 50, 150 };

	/// <summary>
	/// 武师平民一技能对初见好感提升百分比
	/// </summary>
	public short ProfessionInitialFavorabilitiesImprovePercent = 33;

	/// <summary>
	/// 修改一条州域法规的惩罚力度，每次修改持续3年
	/// </summary>
	public short TownPunishmentSeverityCustomizeDuration = 36;

	/// <summary>
	/// 然山恩义互动王禅典籍，研读书籍的最大次数，在和选择的书籍耐久度中取最小值
	/// </summary>
	public short SpiritualDebtInteractionRanshanMaxReadingCount = 9;

	/// <summary>
	/// 武当恩义互动七星调元，周天运转的最大次数
	/// </summary>
	public short SpiritualDebtInteractionRanshanMaxNeigongLoopingCount = 7;

	/// <summary>
	/// 初始毒发概率为25，每月增加5，毒发后归零
	/// </summary>
	public int[] KongsangCharacterFeaturePoisonedProbParm = new int[2] { 25, 5 };

	/// <summary>
	/// 练功增加的实战度
	/// </summary>
	public int[] BaseCombatSkillPracticeProficiencyDelta = new int[2] { 3, 6 };

	/// <summary>
	/// 练功消耗的精力，基础值 - 练功房规模 * 系数
	/// </summary>
	public int[] CombatSkillPracticeActionPointCost = new int[2] { 200, 5 };

	/// <summary>
	/// 抓取入魔人时押入石牢而非地方监狱的概率
	/// </summary>
	public int ImprisonInStoneHouseChance = 33;

	/// <summary>
	/// 地图拾取物资源类型生成数量正负随机波动
	/// </summary>
	public short MapPickupResourceCountRandomFactor = 25;

	/// <summary>
	/// 地图拾取物道具类型生成品级正负随机波动
	/// </summary>
	public byte MapPickupItemGradeRandomFactor = 1;

	/// <summary>
	/// 普通拾取物生成时，有多少概率会伴随一个爪牙来守护
	/// </summary>
	public byte MapPickupHasXiangshuMinionProbability = 25;

	/// <summary>
	/// 制造物品的三个级别的造诣倍率要求
	/// </summary>
	public int[] MakeItemStageAttainmentFactor = new int[3] { 100, 150, 200 };

	/// <summary>
	/// 修改惩罚力度范围
	/// </summary>
	public sbyte ModifySeverityDefaultRange = 1;

	/// <summary>
	/// 修改惩罚力度消耗系数
	/// </summary>
	public int ModifySeverityCostFactor = 1000;

	/// <summary>
	/// 茶马帮从1到20级，对应多少知名度
	/// </summary>
	public short[] TeaHorseCaravanLevelToAwareness = new short[20]
	{
		100, 150, 200, 300, 400, 500, 600, 700, 800, 1000,
		1200, 1400, 1600, 1900, 2200, 2500, 2800, 3200, 3600, 4000
	};

	/// <summary>
	/// 居所解锁消耗，默认解锁的格不用填，总共8格，顺序是从上往下，从左往右，下同
	/// </summary>
	public List<ResourceInfo> ResidentUnlockCost = new List<ResourceInfo>
	{
		new ResourceInfo(1, 1000),
		new ResourceInfo(2, 1000),
		new ResourceInfo(1, 1000),
		new ResourceInfo(2, 1000),
		new ResourceInfo(2, 1000),
		new ResourceInfo(1, 1000),
		new ResourceInfo(2, 1000),
		new ResourceInfo(1, 1000)
	};

	/// <summary>
	/// 仓库解锁消耗，默认解锁的格不用填，总共8格
	/// </summary>
	public List<ResourceInfo> WarehouseUnlockCost = new List<ResourceInfo>
	{
		new ResourceInfo(2, 1000),
		new ResourceInfo(7, 500),
		new ResourceInfo(1, 1000),
		new ResourceInfo(5, 1000),
		new ResourceInfo(0, 1000),
		new ResourceInfo(3, 1000),
		new ResourceInfo(6, 5000),
		new ResourceInfo(4, 1000)
	};

	/// <summary>
	/// 厢房解锁消耗，默认解锁的格不用填，总共2格
	/// </summary>
	public List<ResourceInfo> ComfortableHouseUnlockCost = new List<ResourceInfo>
	{
		new ResourceInfo(6, 25000),
		new ResourceInfo(7, 2500)
	};

	/// <summary>
	/// 重申信誓基础奖励银钱
	/// </summary>
	public int VowRewardResourceBasePrice = 10000;

	/// <summary>
	/// 完成地区主线后重申信誓所需的威望比例
	/// </summary>
	public int VowFinishedSectStoryAuthorityPercent = 50;

	/// <summary>
	/// 初到太吾村门派弟子相争获得支持品级
	/// </summary>
	public sbyte[] MainStoryHelpSectApprovedGrades = new sbyte[4] { 0, 1, 2, 3 };

	/// <summary>
	/// 初到太吾村门派弟子相争获得支持数量
	/// </summary>
	public int[] MainStoryHelpSectApprovedCounts = new int[4] { 3, 2, 1, 1 };

	/// <summary>
	/// 初到太吾村门派弟子相争所帮助门派获得恩义
	/// </summary>
	public int MainStoryHelpSectAddSpiritualDebt = 1000;

	/// <summary>
	/// 初到太吾村门派弟子相争未帮助门派减少恩义
	/// </summary>
	public int MainStoryNotHelpSectAddSpiritualDebt = -500;

	/// <summary>
	/// 太吾村升级威望消耗
	/// </summary>
	public int[] TaiwuVillageUpgradeAuthorityCosts = new int[15]
	{
		0, 2500, 5000, 7500, 10000, 12500, 15000, 17500, 20000, 25000,
		30000, 35000, 40000, 45000, 50000
	};

	/// <summary>
	/// 太吾村招募不同资质人物需要的分数
	/// </summary>
	public int[] RecruitCharacterGradeScoreThresholds = new int[9] { 100, 200, 300, 500, 700, 900, 1200, 1600, 2100 };

	/// <summary>
	/// 经营进度提升基础值
	/// </summary>
	public int ShopManageProgressBaseDelta = 650;

	/// <summary>
	/// 最大制造进度
	/// </summary>
	public int MaxProductionProgress = 10000;

	/// <summary>
	/// 投入引子后引子品级-1，0，+1的产物增加的权重 
	/// </summary>
	public int[] MaterialWeightToArtisanOrder = new int[3] { 40, 60, 10 };

	/// <summary>
	/// 初始产物的三个级别的权重
	/// </summary>
	public int[] InitialProductionWeight = new int[3] { 10, 60, 40 };

	/// <summary>
	/// 工作者的造诣加成
	/// </summary>
	public int AddOnAttainmentOfWorker = 50;

	/// <summary>
	/// 领袖的造诣加成
	/// </summary>
	public int AddOnAttainmentOfLeader = 150;

	/// <summary>
	/// 工作者造诣除数
	/// </summary>
	public int WorkerAttainmentDivider = 3;

	/// <summary>
	/// 匠人的造诣乘数
	/// </summary>
	public int ArtisanAttainmentFactor1 = 2;

	/// <summary>
	/// 匠人的安定值/文化值乘数
	/// </summary>
	public int ArtisanAttainmentFactor2 = 200;

	/// <summary>
	/// 每月增加的制造进度基础值
	/// </summary>
	public int MonthlyOrderProgressBase = 250;

	/// <summary>
	/// 每月增加的制造进度基础值倍数
	/// </summary>
	public int MonthlyOrderProgressFactor = 2;

	/// <summary>
	/// 茶酒订单的造诣需求
	/// </summary>
	public int[] TeaWineArtisanOrderAttainmentRequirement = new int[9] { 10, 30, 60, 100, 150, 210, 280, 360, 450 };

	/// <summary>
	/// 一格范围内的采集资源建筑产能
	/// </summary>
	public int[] CollectResourceBuildingProductivityDistanceOne = new int[4] { 100, 80, 60, 40 };

	/// <summary>
	/// 一格范围以外的采集资源建筑产能
	/// </summary>
	public int CollectResourceBuildingProductivityDistanceMore = 20;

	/// <summary>
	/// 领袖每月额外获取当月总收获的20%，每名成员额外获得当月收获的10%作为报酬，此报酬不会影响产业建筑的收入…”
	/// </summary>
	public sbyte[] ShopBuildingSharePencent = new sbyte[2] { 20, 10 };

	/// <summary>
	/// 山底暗河奇遇巨蟒捕获后的驯服度
	/// </summary>
	public sbyte DarkRiverHugeSnakeTamePoint = 95;

	/// <summary>
	/// 采集资源时引子获得升级参数1
	/// </summary>
	public const int CollectMaterialMinResource = 100;

	/// <summary>
	/// 采集资源时引子获得升级参数2
	/// </summary>
	public const int CollectMaterialChanceDivider = 10;

	/// <summary>
	/// 农户采集资源时相较于太吾采集到引子的概率的百分比
	/// </summary>
	public const int FarmerCollectMaterialChancePercent = 20;

	/// <summary>
	/// 主城/门派/其他的互动公式系数（推恩施义和安定文化使用）
	/// </summary>
	public sbyte[] ExtendFavorSafetyAndCultureAreaFactor = new sbyte[3] { 20, 15, 10 };

	/// <summary>
	/// 刷新商人物品的行动点消耗（=5.0）
	/// </summary>
	public int RefreshItemApCost = 50;

	/// <summary>
	/// 功法突破威力上限命名分组数值（下中上三阶）
	/// </summary>
	public static readonly List<int[]> BreakoutMaxPowerNameValueArray = new List<int[]>
	{
		new int[9] { 0, 16, 24, 32, 40, 48, 56, 64, 72 },
		new int[9] { 0, 24, 36, 48, 60, 72, 84, 96, 108 },
		new int[9] { 0, 36, 54, 72, 90, 108, 126, 144, 162 }
	};

	/// <summary>
	/// 每个装备槽中装备的战斗力乘数（策划可以按需修改）
	/// </summary>
	public static readonly int[] EquipmentSlotCombatPower = new int[12]
	{
		500, 500, 500, 500, 500, 500, 500, 500, 500, 500,
		500, 500
	};

	/// <summary>
	/// 用于计算战斗力对村镇影响力的影响系数，非战力部分的系数为100减此系数（策划可以按需修改）
	/// </summary>
	public const int VillageCombatInfluenceValueFactor = 80;

	/// <summary>
	/// 用于计算战斗力对村镇影响力的影响系数的除数（策划可以按需修改）
	/// </summary>
	public const int VillageCombatInfluenceValueUnit = 4000;

	/// <summary>
	/// 用于计算战斗力对门派影响力的影响系数，非战力部分的系数为100减此系数（策划可以按需修改）
	/// </summary>
	public const int SectCombatInfluenceValueFactor = 80;

	/// <summary>
	/// 用于计算战斗力对门派影响力的影响系数的除数（策划可以按需修改）
	/// </summary>
	public const int SectCombatInfluenceValueUnit = 2000;

	/// <summary>
	/// 同行暗渊地格/毁坏地格/玄石之地时代步耐久的损失范围
	/// </summary>
	public static readonly int[] CarrierDurationReduceOnRuinBlock = new int[2] { 1, 4 };

	/// <summary>
	/// 太吾村民获取武学和技艺的遗惠时的造诣要求
	/// </summary>
	public short VillagerSkillLegacyAttainmentRequirement = 450;

	/// <summary>
	/// 每个月每个角色可增加实战度的功法的最大数量
	/// </summary>
	public const int UpdateProficiencyMaxCount = 9;

	/// <summary>
	/// 每个月每个角色每个功法可增长的实战度最大值（门派角色，非门派角色）
	/// </summary>
	public static readonly int[] UpdateProficiencyMaxDelta = new int[2] { 6, 3 };

	/// <summary>
	/// 被破坏地格寻路消耗
	/// </summary>
	public int MapDestroyedBlockPathingCost = 90;

	/// <summary>
	/// 存档改名最大字符数（策划可以按需修改）
	/// </summary>
	public const int MaximumRenameCharactersInSaveSlot = 6;

	/// <summary>
	/// 建筑改名最大字符数（未实装）（策划可以按需修改）
	/// </summary>
	public const int MaximumRenameCharactersInBuildings = 6;

	/// <summary>
	/// 关注人物改名最大字符数（未实装）（策划可以按需修改）
	/// </summary>
	public const int MaximumRenameCharactersInSaveFollowers = 4;

	/// <summary>
	/// 村民身份改名最大字符数（未实装）（策划可以按需修改）
	/// </summary>
	public const int MaximumRenameCharactersInVillagerRole = 2;

	/// <summary>
	/// 天灾生成相枢爪牙的额外随机值，满足等式 额外随机值 = 最大值 - 最小值 + 1
	/// </summary>
	public int GenerateXiangshuMinionAfterDisasterRangeMax = 3;

	/// <summary>
	/// 天灾生成的相枢爪牙的最小值，实际值 = Base + Random.Range(0, RangeMax)
	/// </summary>
	public int GenerateXiangshuMinionAfterDisasterBase = 1;

	/// <summary>
	/// 天灾生成爪牙时等级降低的最大值（不包含自身，3的意思是生成的爪牙随机减0~2级）
	/// </summary>
	public int GenerateXiangshuMinionAfterDisasterGradeMinusMax = 3;

	/// <summary>
	/// 开化地格出现天灾之后，周围生成相枢爪牙需要额外判定的概率百分比（在随机到min~max的初步生成数量A之后，这A个爪牙是否生成，需要额外过一次这个概率的判断）
	/// </summary>
	public int GenerateXiangshuMinionAfterDisasterInDevelopedBlockProbabilityPercentage = 33;

	/// <summary>
	/// 历灾渡劫后身龄增长间隔
	/// </summary>
	public const int TaoistMonkSkilll3_AgeIncreaseCooldown = 3;

	/// <summary>
	/// 云游道4技能每月身龄、寿元增加量
	/// </summary>
	public const int TravelingTaoistMonkSkilll3_AgeIncreaseAddon = 2;

	/// <summary>
	/// 旅途事件中道路坎坷对载具的耐久减少
	/// </summary>
	public int TravelingEventRoadBlockDurabilityChange = 10;

	/// <summary>
	/// 当选择性别生成时，生成后的龙岛忠仆的最小魅力值
	/// </summary>
	public short FulongServantBaseAttraction = 600;

	/// <summary>
	/// 正派和邪派角色对应的名誉可获取的星运值
	/// </summary>
	public List<int[]> ExtraLegacyPointGain = new List<int[]>
	{
		new int[7] { 200, 150, 100, 0, 0, 0, 0 },
		new int[7] { 0, 0, 0, 0, 100, 150, 200 }
	};

	/// <summary>
	/// 定居点地格开化显示范围
	/// </summary>
	public sbyte SettlementInfluenceRange = 3;

	/// <summary>
	/// 资源点产出心材冷却
	/// </summary>
	public int[] ResourceBlockBuildingCoreProducingCooldown = new int[2] { 3, 6 };

	/// <summary>
	/// 资源点产出心材概率最大值
	/// </summary>
	public int[] ResourceBlockBuildingCoreProducingMaxChance = new int[2] { 10000, 30000 };

	/// <summary>
	/// 自动生成的相枢爪牙生存时间系数
	/// </summary>
	public int GeneratedXiangshuMinionDurationFactor = 100;

	/// <summary>
	/// 亡流寨感染玄灰人数的额外随机值，满足等式 额外随机值 = 最大值 - 最小值 + 1
	/// </summary>
	public int BrokenPerformDarkAshInfectorRangeMax = 3;

	/// <summary>
	/// 亡流寨感染玄灰的人数最小值，实际值 = Base + Random.Range(0, RangeMax)
	/// </summary>
	public int BrokenPerformDarkAshInfectorBase = 3;

	/// <summary>
	/// 老道士的玄灰特性持续时间
	/// </summary>
	public int DarkAshDurationOldTaosim = 6;

	/// <summary>
	/// 玄灰特性持续时间的额外随机值，满足等式 额外随机值 = 最大值 - 最小值 + 1
	/// </summary>
	public int DarkAshDurationRangeMax = 7;

	/// <summary>
	/// 玄灰特性的持续时间最小值，实际值 = Base + Random.Range(0, RangeMax)
	/// </summary>
	public int DarkAshDurationBase = 6;

	/// <summary>
	/// 玄灰剩余时间【小于等于】此数值时发出通知（策划可以按需修改）
	/// </summary>
	public const int DarkAshShouldNotify = 6;

	/// <summary>
	/// 初始化世界时全局人口除数，为平衡OrganizationMember中人数而设，一般不应修改
	/// </summary>
	public const int PopulationFactor = 125;

	/// <summary>
	/// 伏虞心念的等级阈值，（等级取值范围1~8，1~2点对应1级，71点对应7级，72点对应满级8级），以小于等于判定是否达到阈值，最后一个数字是最大心念数（策划可以按需修改）
	/// </summary>
	public static readonly int[] FuyuFaithLevel = new int[9] { 0, 1, 3, 6, 12, 18, 30, 48, 72 };

	/// <summary>
	/// 伏虞心念的回礼等级加值（策划可以按需修改）
	/// </summary>
	public static readonly int[] FuyuFaithAddLevel = new int[9] { 0, 0, 0, 1, 1, 1, 2, 2, 2 };

	/// <summary>
	/// 伏虞心念的回礼资源上限（策划可以按需修改）
	/// </summary>
	public static readonly int[] FuyuResourceValueMax = new int[9] { 300, 600, 1800, 4500, 9300, 16800, 27600, 42300, 61500 };

	/// <summary>
	/// 伏虞心念回礼：根据心念级别增加好感（策划可以按需修改）
	/// </summary>
	public static readonly int[] FuyuFaithFavorByLevel = new int[9] { 600, 1200, 1800, 3000, 4200, 5400, 7200, 9000, 10800 };

	/// <summary>
	/// 伏虞心念回礼：根据心念级别增加回礼等级的世界进度上限（策划可以按需修改）
	/// </summary>
	public static readonly int[] FuyuFaithAddGiftLevel = new int[9] { 0, 0, 0, 1, 1, 1, 2, 2, 2 };

	/// <summary>
	/// 伏虞心念回礼：根据心念级别增加恩义 * FuyuFaithDebtFactor / 100（策划可以按需修改）
	/// </summary>
	public static readonly int[] FuyuFaithDebtByLevel = new int[9] { 10, 20, 30, 50, 60, 70, 100, 110, 120 };

	/// <summary>
	/// 伏虞心念回礼：FuyuFaithDebtFactor值
	/// </summary>
	public int FuyuFaithDebtFactor = 300;

	/// <summary>
	/// 拯救失心人符箓/伏虞心念获取与精纯的关系（策划可以按需修改）
	/// </summary>
	public static readonly sbyte[] FuyuFaithCountBySaveInfected = new sbyte[19]
	{
		1, 1, 2, 3, 4, 5, 6, 7, 8, 9,
		10, 12, 14, 17, 20, 24, 28, 33, 38
	};

	/// <summary>
	/// 邀约消耗精力
	/// </summary>
	public int AppointmentCostDays = 5;

	/// <summary>
	/// 村民取用物品作为玄机需求的品级上限
	/// </summary>
	public sbyte TaiwuVillagerSkillBreakBonusItemGradeLimit = 5;

	/// <summary>
	/// 移宫易穴公式的参数，含义是未更换过时，消耗的历练是突破基础历练配置的倍数
	/// </summary>
	public short SwapSkillBreakCostExp = 5;

	/// <summary>
	/// 过月事件异地嫁娶好感度变化
	/// </summary>
	public short DistantMarriageInfluencedByTaiwuFavorDelta = 15000;

	/// <summary>
	/// 每月战斗、较艺提供的周天、读书次数
	/// </summary>
	public const sbyte LearnInPracticeCountPerMonth = 1;

	/// <summary>
	/// 过月月报的最大保存月数
	/// </summary>
	public int MonthsMonthNotificationsKept = 12;

	/// <summary>
	/// 恩义互动改变立场值上限
	/// </summary>
	public int SpiritualDebtInteractionChangeMoralityMax = 50;

	/// <summary>
	/// 亦正亦邪名誉判定阈值，正负声望绝对值之和小于此数值将被视为默默无闻
	/// </summary>
	public int FameAbsValueForBothGoodAndBad = 50;

	/// <summary>
	/// 酒中真仙数值，资历百分比除以该值
	/// </summary>
	public int WineTasterSkill2Factor = 10;

	/// <summary>
	/// 能看到真名的最小好感
	/// </summary>
	public const short RequiredMinimalFavorabilityToRevelRealName = 10000;

	/// <summary>
	/// 显示抬头纹年龄判断条件之一，判断当前年龄大于等于最大寿命的这个百分比
	/// </summary>
	public int AgePercentShowWrinkle1 = 60;

	/// <summary>
	/// 显示表情纹的年龄判断条件之一，判断当前年龄大于等于最大寿命的这个百分比
	/// </summary>
	public int AgePercentShowWrinkle2 = 70;

	/// <summary>
	/// 显示眼袋纹的年龄判断条件之一，判断当前年龄大于等于最大寿命的这个百分比
	/// </summary>
	public int AgePercentShowWrinkle3 = 50;

	/// <summary>
	/// 无念众数量上限
	/// </summary>
	public const int NoMindGuyCount = 6;

	/// <summary>
	/// 村民取用物品作为玄机需求的品级上限数组，用精纯等级索引
	/// </summary>
	public int[] TaiwuVillagerSkillBreakBonusItemGradeLimitArray = new int[19]
	{
		0, 0, 1, 1, 2, 2, 3, 3, 4, 4,
		5, 5, 6, 6, 7, 7, 8, 8, 8
	};

	public IReadOnlyDictionary<string, int> RefNameMap
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public int GetItemId(string refName)
	{
		throw new NotImplementedException();
	}

	public int AddExtraItem(string identifier, string refName, object configItem)
	{
		throw new NotImplementedException();
	}

	public void Init()
	{
		Init_AdvanceMonth();
		Init_Adventure();
		Init_Alertness();
		Init_Breakout();
		Init_Challenge();
		Init_Combat();
		Init_CricketPolymorph();
		Init_CustomProtagonist();
		Init_Debate();
		Init_EditableMerchantConst();
		Init_Exchange();
		Init_Feast();
		Init_GenTaiwuVillage();
		Init_Genetics();
		Init_Information();
		Init_Make();
		Init_MapAction();
		Init_MartialArtTournament();
		Init_PriceValue();
		Init_Relation();
		Init_SecretInformation();
		Init_SectStory();
		Init_SettlementTreasury();
		Init_SolarTerm();
		Init_Time();
		Init_Unclassified();
	}

	private void Init_AdvanceMonth()
	{
		AbandonBabyToTaiwuVillageChance = 20;
		PrimaryGoalActionPointsPerMonth = 40;
		SecondaryGoalActionPointsPerMonth = 40;
		PrimaryGoalMaxActionPoints = 60;
		SecondaryGoalMaxActionPoints = 60;
	}

	private void Init_Adventure()
	{
		AdventureDialogContinuousTime = 2f;
		AdventureDialogFadeTime = 0.5f;
	}

	private void Init_Alertness()
	{
		AlertnessMin = -600000;
		AlertnessMax = 600000;
		AlertnessLevelRange = new int[8] { -600000, -400000, -200000, -10000, 10000, 200000, 400000, 600000 };
		AlertnessLevelEffectToChangeFavor = new int[7] { 80, 60, 40, 0, -40, -60, -80 };
		AlertnessEffectToMaxFavor = 10;
		AlertnessLevelEffectToInteractSuccessRate = new int[7] { 175, 150, 125, 100, 75, 50, 25 };
		InitialAlertnessBaseRandomRange = new int[2] { -100000, 10000 };
		InitialAlertnessForBehaviorTypeJust = new int[5] { -200000, -100000, 0, 100000, 200000 };
		InitialAlertnessForBehaviorTypeKind = new int[5] { -100000, -200000, 0, 100000, 50000 };
		InitialAlertnessForBehaviorTypeEven = new int[5] { 50000, 0, 0, 0, 50000 };
		InitialAlertnessForBehaviorTypeRebel = new int[5] { 50000, 100000, 0, -200000, -100000 };
		InitialAlertnessForBehaviorTypeEgoistic = new int[5] { 200000, 100000, 0, -100000, -200000 };
		InitialAlertnessForTaiwuFameByGoodSect = new int[7] { 100000, 50000, 10000, 0, 0, 0, 0 };
		InitialAlertnessForTaiwuFameByEvilSect = new int[7] { 0, 0, 0, 0, 10000, 50000, 100000 };
		InitialAlertnessForTaiwuFameByNeutralSect = new int[7] { 50000, 0, 0, 0, 0, 0, 50000 };
		InitialAlertnessForTaiwuFameByCivilianSettlement = new int[7] { 100000, 10000, 5000, 0, -5000, -10000, -100000 };
		InitialAlertnessChallengeModeFactorBase = 6000;
		InitialAlertnessChallengeModeFameDifferent = 5;
		InitialAlertnessChallengeModeFameConflict = 25;
		InitialAlertnessChallengeModeBehaviorDifferent = 5;
		InitialAlertnessChallengeModeBehaviorConflict = 25;
		ChangeAlertnessOnPraise = new int[5] { -5000, -10000, -2000, 5000, -5000 };
		ChangeAlertnessOnSneer = new int[5] { 5000, 5000, 2000, -10000, 5000 };
	}

	private void Init_Breakout()
	{
		BreakoutBaseAvailableStepsCount = 20;
		BreakoutMaxAvailableStepsCount = 99;
		BreakoutMinAvailableStepsCount = 3;
		BreakoutSpecialNpcStepsCount = 30;
		BreakoutShowNormalCellBaseOdds = 20;
		BreakoutShowSpecialCellBaseOdds = 60;
		BreakoutShowBonusCellBaseOdds = 20;
		BreakoutBonusAddPowerCorrectionFactor = 50;
		SectStoryEmeiBonusNotFitProgressPercent = 10;
		SectStoryEmeiBonusMinProgress = 1;
		SectStoryEmeiBonusProgressPerCount = 30750;
		SectStoryEmeiBonusProgressRecyclePercent = 50;
		SkillProficiencyIsEnoughToGainLegacyPoint = 300;
		LuohanRelationTypeAttainment = 450;
		LuohanMaxPowerBase = 60;
		LuohanMaxPowerGradeFactor = 15;
		LuohanMaxPowerQualificationFactor = 20;
		LegendaryBookYangAddStepNormal = 5;
		LegendaryBookYinAddStepGoneMad = 5;
	}

	private void Init_Challenge()
	{
		ChallengeCharacterWealthCreateRate = 50;
		ChallengeTreasurySupplyRate = 50;
		ChallengeShopItemPriceBonus = new int[7] { 25, 50, 75, 100, 150, 250, 400 };
		ChallengeExchangeAdvantageBonus = 50;
		ChallengeTaiwuVillageBaseSpaceReduce = 20;
		ChallengeProfessionSkillLearnScores = new int[4] { 1, 3, 9, 27 };
		ChallengeProfessionSkillLearnExpMultiplier = 1000;
		ChallengeInfectedDemonMinionPerMonth = 1;
		ChallengeInfectedDemonInitMinion = 3;
		ChallengeInfectedDemonMaxMinion = 10;
		ChallengeInfectedDemonMinionRange = 2;
		ChallengeInfectedDemonInterval = 36;
		ChallengeCostResourceLeaveVillageThreshold = -10000;
		ChallengeCostResourceFavorFactor = 3f;
		ChallengeCostResourceResourceFactorFood = 10;
		ChallengeCostResourceResourceFactorWood = 10;
		ChallengeCostResourceResourceFactorMetal = 10;
		ChallengeCostResourceResourceFactorJade = 10;
		ChallengeCostResourceResourceFactorFabric = 10;
		ChallengeCostResourceResourceFactorHerb = 10;
		ChallengeCostResourceResourceFactorMoney = 2;
		ChallengeCostResourceResourceFactorAuth = 20;
		ChallengeCricketFairCombatMaxPointByWagerGrade = new int[9] { 8, 16, 24, 32, 40, 48, 56, 64, 72 };
		ChallengeCricketFairCombatCostByCricketGrade = new int[9] { 0, 0, 0, 1, 2, 4, 8, 16, 32 };
		ChallengeExchangeGradeBonusNpc = new int[9] { 0, 25, 50, 100, 200, 350, 550, 700, 1000 };
		ChallengeExchangeGradeBonusTreasury = new int[9] { 0, 0, 50, 0, 0, 350, 0, 0, 1000 };
		ChallengeEffectDamageFactor = new DamageStepCollection(200, 200, 160, 180, 180, 180, 180, 200, 200, 160, 180, 180, 180, 180, 200, 160);
	}

	private void Init_Combat()
	{
		MysteryMinCompatibilityPerCombat = 3;
		MysteryMaxCompatibilityPerCombat = 5;
		DefeatMarkQiDisorderThreshold = 1000;
		DefeatMarkQiDisorderFirstExtra = 2000;
		DefeatMarkCombatStatePower = 500;
		DefeatMarkCombatStateMaxCount = 8;
		AttackRangeMidMinDistance = 3;
		RopeRequireMinMarkCountInBeat = 16;
		RopeRequireMinMarkCountInDie = 24;
		RopeBaseHitOddsInBeat = 6;
		RopeBaseHitOddsInDie = 12;
		PoisonAttainments = new short[9] { 10, 30, 60, 100, 150, 210, 280, 360, 450 };
		RepairAttainments = new short[9] { 0, 10, 30, 60, 100, 150, 210, 280, 360 };
		RepairBaseResourseRequirement = new short[9] { 5, 10, 15, 25, 35, 45, 60, 75, 90 };
		MakeMadicineAttainments = new short[9] { 10, 30, 60, 100, 150, 210, 280, 360, 450 };
		DisassembleAttainments = new short[9] { 10, 30, 60, 100, 150, 210, 280, 360, 450 };
		HealInjuryPoisonSpeedMinPercent = 20;
		RecoverBreathBaseValue = 30;
		RecoverStanceBaseValue = 60;
		RecoverStanceDivisorByWeapon = new sbyte[3] { 6, 4, 2 };
		AttackSpeedFactor = 50;
		MinPrepareFrame = 9;
		UnlockAttackUnit = 18000;
		MaxChangeTrickProgress = 100;
		MaxChangeTrickProgressOnce = 1200;
		ChangeTrickMultiplierFlaw = 2;
		ChangeTrickMultiplierAcupoint = 3;
		FirstAttackAddChangeTrickProgress = 10;
		PursueAttackAddChangeTrickProgress = 3;
		AvoidChangeTrickProgressPercentByWeapon = new int[3] { 33, 66, 100 };
		BaseCriticalOdds = 60;
		AvoidAddTrickBaseOdds = 10;
		AvoidAddTrickHitOddsDivisor = 2;
		NormalAttackExtraHitOdds = 0;
		BaseAttackDamageValue = 9;
		AddBaseAttackDamageValue = 3;
		BaseSkillDamageValue = 60;
		BaseUnlockDamageValue = 30;
		BaseSpiritDamageValue = 30;
		BaseAttackOdds = 800;
		BaseMindAttackOdds = 30;
		BaseSkillAttackOdds = 30;
		BaseUnlockAttackOdds = 30;
		BaseSpiritAttackOdds = 800;
		ReduceHealthPerFatalDamageMark = new sbyte[4] { 0, 18, 36, 18 };
		MaxFatalMarkCount = 999;
		AcupointLevelRequireHitOdds = new short[3] { 100, 300, 900 };
		FlawLevelRequireHitOdds = new short[3] { 100, 600, 1800 };
		AcupointBaseKeepTime = new int[4] { 90000, 135000, 270000, 540000 };
		FlawBaseKeepTime = new int[4] { 45000, 67500, 135000, 270000 };
		FlawOrAcupointReduceBaseTime = 100;
		FlawAddDamagePercent = 40;
		ExtraFlawAddDamagePercent = 10;
		DefaultJumpThreshold = 10;
		FastWalkDistance = 60;
		MobilityRecoverSpeed = 200;
		LockingRecoverSpeed = 400;
		MaxMobility = 120000;
		ReduceJumpProgressFrame = 6;
		ReduceJumpProgressPercent = 10;
		MoveCdBase = 32;
		MoveCdFactor = 20;
		MoveCdDivisorBase = 400;
		MoveCdDivisorFactor = 45;
		AgileSkillNonJumpDirectionCostMobilityPercent = 10;
		AgileSkillBaseAddSpeed = 100;
		AgileSkillBaseAddHit = 200;
		DefendSkillBaseAddAvoid = 200;
		DefendSkillBaseAddPenetrateResist = 400;
		DefendSkillBaseFightBackPower = 150;
		DefendSkillBaseBouncePower = 25;
		DefendSkillClearManualSilenceFrameRatio = 300;
		MindMarkBaseKeepTime = 900;
		BaseMindRhythm = 6;
		BaseMindUpheavalTime = 180;
		MindUpheavalAddDamageStepPercent = 50;
		ScarMarkBaseKeepTime = 1800;
		ScarMarkProgressPerMark = 100;
		ScarMarkProgressMin = 40;
		ScarMarkProgressMax = 60;
		AttackPrepareValueFixedDelayFramePerUnit = 20;
		AttackChangeTrickHitValueAddPercent = new short[3] { 50, 200, 350 };
		AttackChangeTrickCostBlockBasePercent = new short[3] { 150, 300, 450 };
		BreakAttackHitBasePercent = new short[3] { 150, 300, 450 };
		MaxWugCount = 90;
		SpiritualDebtLimit = new int[2] { -999999999, 999999999 };
		CombatSkillInitialEquipSlotCounts = new sbyte[6] { 6, 1, 1, 1, 1, 0 };
		CharacterInitialNeili = 20;
		HomelessFavorabilityChangePerMonth = -1200;
		HomelessHappinessChangePerMonth = -15;
		HouseFavorabilityChangePerMonth = 400;
		HouseHappinessChangePerMonth = 5;
		FavorabilityChangeOnExpel = new short[5] { -20000, -15000, -10000, -15000, -20000 };
		StrengthToEquipmentLoadFactor = 10;
		EquipmentLoadBaseValue = 1500;
		TaiwuVillageForceAreaSize = 38;
		CaptureRatePerRopeGrade = 15;
		CombatGetNonMainPercent = 25;
		CombatGetExpBase = new short[19]
		{
			100, 110, 140, 190, 260, 350, 460, 590, 740, 910,
			1100, 1310, 1540, 1790, 2060, 2350, 2660, 2990, 3340
		};
		CombatGetAuthorityBase = new short[19]
		{
			5, 10, 20, 30, 45, 60, 80, 105, 130, 160,
			190, 230, 280, 340, 410, 500, 610, 760, 950
		};
		LifeSkillBattleGainRatio = 50;
		UseSwordFragmentAddXiangshuInfection = 20;
		CalcApplyItemPoisonParam = 20;
		ThrowPoisonParam = 10;
		MercyPrepareMaxTime = 2f;
		MercyAutoIgnoreTime = 6f;
		PowerDamageMax = 500;
		PowerDamageOffset = 500;
		TiredMarkAppearFrame = 540u;
	}

	private void Init_CricketPolymorph()
	{
		CricketRoomExpPerLowMaterialBaseValue = 50;
		CricketRoomExpPerLowMaterialDecreasingValue = 3;
		CricketRoomExpPerLowMaterialMinValue = 20;
		CricketRoomExpPerHighMaterialBaseValue = 150;
		CricketRoomExpPerHighMaterialDecreasingValue = 10;
		CricketRoomExpPerHighMaterialMinValue = 50;
		CricketRoomRequireExpPerLevel = 1000;
		CricketRoomBaseLevel = 1;
		CricketRoomMaxLevel = 10;
		CricketRoomPolymorphReturnRequireLevel = 3;
		CricketRoomMakingWishRequireLevel = 10;
		CricketAgeProgressPerYear = 100;
		CricketSpiritMax = 1000;
		CricketSpiritUnit = 100;
		CricketSpiritGrowthProperties = new int[11]
		{
			10, 10, 1, 1, 1, 5, 1, 5, 5, 1,
			5
		};
		CricketSpiritGrowthDurability = 1;
		CricketCombatAddSpirit = new int[9] { 1, 2, 3, 6, 9, 12, 18, 24, 32 };
		CricketBloodDewAddSpirit = new int[9] { 10, 20, 30, 50, 80, 120, 170, 230, 300 };
		CricketPolymorphBaseRate = 5;
		CricketPolymorphAddRate = 1;
		CricketWishingDuration = 3;
		CricketWishingCostLuckPoint = 300;
		CricketWishingReturnLuckPoint = 150;
	}

	private void Init_CustomProtagonist()
	{
		CustomProtagonistMainAttributeTotalPoint = 300;
		CustomProtagonistMainAttributeMaxPoint = 90;
		CustomProtagonistMainAttributeDefaultPoint = 20;
		CustomProtagonistLifeSkillQualificationTotalPoint = 800;
		CustomProtagonistLifeSkillQualificationMaxPoint = 90;
		CustomProtagonistLifeSkillQualificationDefaultPoint = 40;
		CustomProtagonistCombatSkillQualificationTotalPoint = 700;
		CustomProtagonistCombatSkillQualificationMaxPoint = 90;
		CustomProtagonistCombatSkillQualificationDefaultPoint = 40;
		CustomProtagonistCharacterFeatureTotalPoint = 7;
	}

	private void Init_Debate()
	{
		DebateMaxGamePoint = 6;
		DebateMaxRound = 20;
		DebateLineCount = 3;
		DebateLineNodeCount = 6;
		DebateTaiwuVantageNodeCount = new int[3] { 4, 3, 2 };
		DebateCardTypeLimit = 4;
		DebateMakeMoveLimit = 1;
		DebateGetStrategyLimit = 3;
		DebatePawnStrategyLimit = 3;
		DebateGradeToBasesPercent = 5;
		DebatePawnDamageToGamePoint = 1;
		DebateSpectatorPickRange = 1;
		DebateSurrenderAttainmentFactor = 200;
		DebateSurrenderBehaviorFactor = new int[5] { 100, 80, 60, 80, 100 };
		DebateAttainmentToMaxBasesPercent = new int[2] { 85, 116 };
		DebateBasesRecoverPercent = 30;
		DebateInitialStrategyPoint = 4;
		DebateMaxStrategyPoint = 12;
		DebateStrategyPointRecover = 2;
		DebateMaxPressure = 100;
		DebatePressureStrategyRecoverPercent = 50;
		DebatePressureBasesRecoverPercent = 50;
		DebatePressureAutoIncreaseRound = 10;
		DebatePreesureAutoIncreaseValue = 10;
		DebateLowPressurePercent = 50;
		DebateMidPressurePercent = 75;
		DebateHighPressurePercent = 100;
		DebateReduceStrategyRecoverProb = new int[4] { 0, 0, 100, 100 };
		DebateReduceBasesRecoverProb = new int[4] { 0, 100, 100, 100 };
		DebateUseStrategyFailedProb = new int[4] { 0, 0, 0, 50 };
		DebateMakeMoveFailedProb = new int[4] { 0, 0, 0, 50 };
		DebatePressureDeltaInConflict = 5;
		DebateCommentStackLimit = 3;
		DebateBullyPercent = 50;
		DebateOverComePercent = 150;
		DebateCommentProb = 50;
		DebateSameSideCommentProb = 75;
		DebateOtherSideCommentProb = 25;
		DebateCommentDivider = 1200;
		DebateAddNodeEffectProb = 50;
		DebateHelpSameSideProb = 50;
		DebateHelpSameSideDivider = 600;
		DebateSurrenderFactor = 50;
		DebateMaxCanUseCards = 6;
		DebateResetCardsPressureLimit = 100;
		DebateResetCardsPressureDelta = 25;
		DebateMaxShuffleCard = 3;
		AttackLineWeight = new List<int[]>
		{
			new int[2] { 2, 3 },
			new int[2] { 2, 3 },
			new int[2] { 3, 4 },
			new int[2] { 1, 4 },
			new int[2] { 3, 4 }
		};
		MidLineWeight = new List<int[]>
		{
			new int[2] { 2, 3 },
			new int[2] { 3, 4 },
			new int[2] { 4, 5 },
			new int[2] { 1, 4 },
			new int[2] { 4, 5 }
		};
		DefenseLineWeight = new List<int[]>
		{
			new int[2] { 2, 3 },
			new int[2] { 6, 7 },
			new int[2] { 6, 7 },
			new int[2] { 1, 4 },
			new int[2] { 6, 7 }
		};
		EarlyBases = new int[5] { 50, 60, 55, 50, 40 };
		MidBases = new int[5] { 40, 50, 45, 40, 35 };
		LateBases = new int[5] { 35, 45, 40, 35, 30 };
		EarlyStrategyPoint = new List<int[]>
		{
			new int[2] { 5, 3 },
			new int[2] { 7, 4 },
			new int[2] { 6, 4 },
			new int[2] { 4, 3 },
			new int[2] { 3, 2 }
		};
		MidStrategyPoint = new List<int[]>
		{
			new int[2] { 4, 1 },
			new int[2] { 5, 2 },
			new int[2] { 3, 2 },
			new int[2] { 2, 1 },
			new int[2] { 1, 1 }
		};
		LateStrategyPoint = new List<int[]>
		{
			new int[2],
			new int[2],
			new int[2],
			new int[2],
			new int[2]
		};
		DamageLineWeight = new int[5] { 1, 1, 1, 1, 2 };
		DamagedLineWeight = new int[5] { 1, 2, 1, 1, 1 };
		StateGamePointPressureInfluence = new List<int[]>
		{
			new int[2] { 69, 19 },
			new int[2] { 59, 0 },
			new int[2] { 69, 19 },
			new int[2] { 79, 29 },
			new int[2] { 79, 39 }
		};
		StatePawnCountInfluence = new List<int[]>
		{
			new int[2] { 2, 3 },
			new int[2] { 4, 5 },
			new int[2] { 3, 4 },
			new int[2] { 2, 3 },
			new int[2] { 1, 2 }
		};
		StateRoundInfluence = new int[5] { 13, 15, 14, 13, 12 };
		EgoisticNodeEffectWeightPercent = 100;
		EvenNodeEffectMaxGradeProb = new int[5] { 80, 20, 50, 20, 50 };
		RoundBeforeEarly = 3;
		MinGradeIfEnoughBases = 6;
		ZeroGradePawnProb = new int[3] { 90, 80, 60 };
		MakeMoveOnOverwhelmingLineProb = 80;
		RemoveStrategyTargetPawnBasesPercent = 20;
		Taoism3CanUseCardLimit = new int[3] { 1, 3, 0 };
		Math1CanUseCardLimit = new int[3] { 3, 0, 0 };
		ResetStrategyUsedCardLimit = 3;
	}

	private void Init_EditableMerchantConst()
	{
		MerchantFavorabilityUpperLimits = new short[10] { 0, 0, 1, 2, 3, 4, 5, 6, 6, 6 };
		MerchantItemDebtGradeUpperLimits = new short[10] { 1, 1, 2, 3, 4, 5, 5, 6, 7, 7 };
		MerchantFavorabilityMoneyRequirements = new int[10] { 6000, 12000, 24000, 48000, 96000, 192000, 384000, 768000, 1536000, 3072000 };
		MerchantFavorabilityXiangshuLevelRequirements = new int[10] { 0, 0, 2, 4, 6, 8, 10, 12, 14, 16 };
		MerchantCharFavorabilityBuyEffect = new int[13]
		{
			25, 20, 15, 10, 5, 0, 0, 0, -5, -10,
			-15, -20, -25
		};
		MerchantCharFavorabilitySellEffect = new int[13]
		{
			-10, -8, -6, -4, -2, 0, 0, 0, 2, 4,
			6, 8, 10
		};
		MerchantDebtLevelLimit = new int[7] { -1, 316500, 305700, 274200, 199800, 124200, 0 };
		MerchantOverFavorBuyCount = new short[7] { -1, 12, 9, 6, 3, 2, 1 };
		CaravanRobbedEventWinAddMerchantFavorability = new int[7] { 2700, 6750, 13950, 25200, 41400, 36450, 92250 };
		CaravanRobbedEventLoseReduceIncomeBonus = 33;
		CaravanIncomeCriticalResultRange = new short[2] { 150, 300 };
		CaravanRobbedEventEndReduceRobbedRate = 50;
		InvestCaravanNeedMoney = new int[6] { 5000, 10000, 20000, 40000, 80000, 160000 };
		InvestedCaravanAvoidRobbedNeedAuthorityFactor = new int[6] { 5, 10, 20, 40, 80, 160 };
	}

	private void Init_Exchange()
	{
		ExchangeTreasuryLevelGrade = new int[3] { 2, 5, 8 };
		ExchangeBarRangeP1 = 72901f;
		ExchangeFavorLevel = new int[13]
		{
			0, 0, 0, 0, 0, 25, 50, 100, 200, 350,
			550, 700, 1000
		};
		ExchangeAlertnessLevel = new int[7] { 0, 0, 0, 50, 200, 550, 1000 };
		ExchangeMoralitySame = 0;
		ExchangeMoralitySimilar = 25;
		ExchangeMoralityOpposite = 50;
		ExchangeFameValueForGood = new int[7] { 0, 0, 0, 0, 0, 50, 100 };
		ExchangeFameValueForNeutral = new int[7] { 50, 25, 0, 0, 0, 25, 50 };
		ExchangeFameValueForBad = new int[7] { 100, 50, 0, 0, 0, 0, 0 };
		ExchangeSpecialGender = 50;
		ExchangeSpecialLackResource = 200;
		ExchangeBaseTaiwu = 100;
		ExchangeBaseNormalNpc = 200;
		ExchangeBaseSectNpc = 300;
		ExchangeBaseTreasury = 400;
		ExchangeSecretAdvantageBonus = 5;
		ExchangeApproveAdvantageBonus = 5;
		ExchangeDebtUnit = 5;
		ExchangeGradeOverProgress = new int[9] { 0, 25, 50, 100, 200, 350, 550, 700, 1000 };
		GetPrisonerHappinessChange = new int[9] { 2, 4, 6, 8, 10, 12, 14, 16, 18 };
		GetPrisonerFavorChange = new int[9] { 600, 1200, 1800, 3000, 4200, 5400, 7200, 9000, 10800 };
	}

	private void Init_Feast()
	{
		FeastCount = 3;
		FeastDurability = 3;
		FeastGiftCount = 30;
		FeastBaseHappiness = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
		FeastBaseFaovr = new List<int> { 60, 120, 180, 300, 420, 540, 720, 900, 1080 };
		FeastBuildingLevelHappinessPercent = new List<int> { 50, 100, 150 };
		FeastBuildingLevelFavorPercent = new List<int> { 100, 200, 300 };
		FeastLoveItemHappinessPercent = 50;
		FeastLoveItemFavorPercent = 100;
		FeastLoveItemGiftAddOn = 1;
		FeastLowHappiness = 40;
		FeastGiftGradeFactor = new int[2] { -3, -2 };
		FeastGiftResourcePercent = new int[2] { 8, 12 };
		FeastGiftMoneyPercent = new int[2] { 40, 60 };
		FeastGiftResourceAddon = new int[2] { 50, 100 };
	}

	private void Init_Genetics()
	{
		MainAttributeWeightsTable = new WeightsSumDistribution(42, 6, 10, 17, 30, 51, 90, 153, 270, 459);
		CombatSkillQualificationWeightsTable = new WeightsSumDistribution(84, 100, 120, 144, 173, 208, 250, 300, 360, 433, 520, 624, 749, 900, 1081, 1298, 1559, 1872, 2248, 2700, 3243, 3894, 4677, 5616, 6745, 8100);
		LifeSkillQualificationWeightsTable = new WeightsSumDistribution(96, 100, 120, 144, 173, 208, 250, 300, 360, 433, 520, 624, 749, 900, 1081, 1298, 1559, 1872, 2248, 2700, 3243, 3894, 4677, 5616, 6745, 8100);
		CongenitalMalformationProbability = 50;
	}

	private void Init_GenTaiwuVillage()
	{
		MaxTaiwuVillageAreaCreateCount = 10;
		MaxSwordTombCanSelectCount = 40;
		SwordTombRightDirectionPoint = 200;
		SwordTombNormalDirectionPoint = 200;
		SwordTombNormalDirectionOffset = 10;
		SwordTombMinimumDistance = 6;
		SwordTombFirstBestDistanceRange = new int[2] { 4, 6 };
		SwordTombNormalBestDistanceRange = new int[2] { 8, 9 };
		SwordTombBestDistanceRangePoint = 250;
	}

	private void Init_Information()
	{
		NormalInformationMaxRemainCount = 99;
		NormalInformationDefaultCostableMaxUseCount = 3;
	}

	private void Init_Make()
	{
		MakeAutoSelectToolGradeScore = new int[9] { 3, 4, 5, 7, 9, 11, 14, 18, 23 };
		MakeAutoSelectToolDestroyScore = new int[9] { 1, 3, 9, 22, 46, 84, 138, 211, 307 };
	}

	private void Init_MapAction()
	{
		HealInjuryAttainment = new short[6] { 30, 60, 120, 210, 330, 480 };
		HealPoisonAttainment = new short[3] { 60, 210, 480 };
		HealQiDisorderAttainment = new short[4] { 60, 210, 480, 480 };
		HealHealthAttainment = new short[4] { 60, 210, 480, 480 };
		HealInjuryBaseHerb = 20;
		HealInjuryBaseMoney = 100;
		HealInjuryExtraHerb = new short[6] { 10, 20, 40, 80, 160, 320 };
		HealInjuryExtraMoney = new short[6] { 50, 100, 200, 400, 800, 1600 };
		HealInjuryCostSpiritualDebt = new short[6] { 30, 60, 90, 120, 150, 180 };
		HealPoisonBaseHerb = 20;
		HealPoisonBaseMoney = 100;
		HealPoisonExtraHerb = new short[3] { 20, 80, 320 };
		HealPoisonExtraMoney = new short[3] { 100, 400, 1600 };
		HealPoisonExtraSpiritualDebt = new short[3] { 60, 120, 180 };
		HealQiDisorderHerb = new short[5] { 20, 40, 80, 160, 320 };
		HealQiDisorderMoney = new short[5] { 100, 200, 400, 800, 1600 };
		HealQiDisorderCostSpiritualDebt = new short[5] { 60, 120, 180, 180, 180 };
		HealHealthHerb = new short[5] { 40, 80, 160, 320, 1280 };
		HealHealthMoney = new short[5] { 200, 400, 800, 1600, 6400 };
		HealHealthCostSpiritualDebt = new short[5] { 60, 120, 180, 180, 180 };
		HealMoneyPercent = new short[5] { 150, 100, 200, 250, 300 };
		HealPoisonAttainmentPercent = 1000;
		HealQiDisorderAttainmentPercent = 500;
		LocationNaturalDisasterDuration = 12;
		HealHealthAttainmentPercent = 100;
	}

	private void Init_MartialArtTournament()
	{
		MartialArtTournamentPreparationValueDivider = 1000;
		MartialArtTournamentCombatPowerValueDivider = 100;
		MartialArtTournamentGoodFameRange = (25, 1000);
		MartialArtTournamentNeutralFameRange = (-25, 25);
		MartialArtTournamentBadFameRange = (-1000, 25);
	}

	private void Init_PriceValue()
	{
		JiaoMaxProperty = new int[9] { 60, 20000, 150, 150, 12, 123000, 150, 36, 21600 };
		ArtisanOrderPricePercent = 33;
		ArtisanOrderInterceptPricePercent = 300;
		ArtisanOrderInterceptDebatePricePercent = 150;
		ExchangeLegendaryBookBasePriceInCoin = 3000000;
		ExchangeBookBehaviorTypeToValuePercent = new List<int[]>
		{
			new int[2] { 200, 15 },
			new int[2] { 100, 30 },
			new int[2] { 150, 20 },
			new int[2] { 100, 30 },
			new int[2] { 200, 15 }
		};
		ExchangeBookValueDivider = 10;
		ExchangeBookValueDurabilityBasePercent = 50;
		ExchangeBookValueDurabilityFactor = 50;
		CaravanExchangeProbPenalize = 50;
		ItemContributionPercent = 100;
		ResourceContributionPercent = 200;
	}

	private void Init_Relation()
	{
		HusbandAndWifeStartAdoreChance = 25;
		HusbandAndWifeStartAdoreCooldown = 6;
		GoodMarriageAgeRange = new int[2] { 20, 29 };
		LateMarriageAgeRange = new int[2] { 30, 39 };
		DistantMarriageGoodAgeChance = 5;
		DistantMarriageLateAgeChance = 15;
		DistantMarriageGoodAgeTargetGradeRange = new sbyte[2] { 1, 3 };
		DistantMarriageLateAgeTargetGradeRange = new sbyte[2] { -2, 0 };
		DistantMarriageGoodAgeTargetAgeRange = new int[2][]
		{
			new int[2] { 24, 29 },
			new int[2] { 24, 39 }
		};
		DistantMarriageLateAgeTargetAgeRange = new int[2][]
		{
			new int[2] { 34, 39 },
			new int[2] { 34, 49 }
		};
		AdoptiveRelationAgeRequirement = 14;
		BequestBookPageCompleteFactor = 3;
		BequestBookPageLostFactor = 5;
		BequestBehaviorRelationFactor = new int[5][]
		{
			new int[8] { 10, 9, 8, 7, 6, 5, 4, 3 },
			new int[8] { 10, 9, 5, 6, 8, 7, 3, 4 },
			new int[8] { 9, 10, 6, 5, 8, 7, 4, 3 },
			new int[8] { 4, 5, 7, 3, 9, 8, 6, 10 },
			new int[8] { 8, 7, 5, 6, 4, 10, 3, 9 }
		};
		BequestRelationPositiveFinalFactor = 100;
		BequestRelationNegativeFinalFactor = 100;
		BequestRelationThreshold = 1000;
		BequestProbabilityFactor1 = 8;
		BequestProbabilityFactor2 = 10;
		BequestGenerateBookPercent = 0;
		BequestPublicPercent = new int[5] { 30, 25, 20, 15, 10 };
		BequestPrivatePercent = new int[5] { 25, 30, 35, 40, 45 };
		TaiwuBaseInitialFavorabilityValue = 3000;
		NpcBaseInitialFavorabilityValue = 15000;
	}

	private void Init_SecretInformation()
	{
		SecretInformationNpcPlanDisseminateAmountFactor = 10000;
		SecretInformationBroadcastNotifyElementDisplayLimit = 4;
		SecretInformationShopCharacterCollectInAreaMaxAmount = 15;
		SecretInformationDefaultDisplaySettings = new sbyte[5] { 0, 1, 1, 1, 1 };
		SecretInformationReceivedDisseminateLevels = new short[4] { 0, 30, 50, 80 };
		SecretInformationShopCharacterFavorabilityChanges = new short[3] { 1000, 2000, 5000 };
		SecretInformationSourceCharacterAuthorityGainToCostConfigRate = 20;
		SecretInformationInPrivateMaxUseCount = 3;
		SecretInformationInBroadcastMaxUseCount = 3;
		BroadcastSecretInformationHappinessAdjust = new short[5] { 100, 133, 66, 166, 33 };
		SecretRelationFactor = new int[11]
		{
			99, 15, 99, 99, 1, 12, 3, 9, 6, 99,
			99
		};
		SecretSectFactor = new int[9] { 1, 2, 3, 8, 10, 12, 21, 24, 27 };
		SecretNonSectFactor = new int[9] { 1, 2, 3, 5, 9, 12, 15, 18, 21 };
		SecretItemFactor = new int[9] { 0, 0, 0, 3, 6, 7, 33, 66, 99 };
		SecretRelationScore = new int[3] { 0, 3, 11 };
		SecretCharScore = new int[3] { 1, 3, 10 };
		SecretItemScore = new int[3] { 1, 5, 15 };
		SecretSortValueScore = new int[3] { 1, 6, 22 };
		SecretLevelRange = new int[2] { 100, 400 };
	}

	private void Init_SectStory()
	{
		ThreeVitalsInitInfection = 50;
		ThreeVitalsMinInfection = 0;
		ThreeVitalsMaxInfection = 100;
		ThreeVitalsInfectionDelta = 5;
		ThreeVitalsThresholdLow = 20;
		ThreeVitalsThresholdHigh = 80;
		ThreeVitalsDefectionBase = 50;
		ThreeVitalsDefectionExtra = 5;
		JieQingPointRequire = 50;
		WuxianDriveWugKingCostResourceType = 5;
		WuxianDriveWugKingCostResourceCount = 5000;
		WuxianDriveWugKingCooldown = 6;
		WuxianDriveWugKingCostActionPoint = 50;
		BaihuaLifeLinkTargetConsummate = 4;
		WordlessStatusChangeDuration = 3;
		WordlessStatusStep = 2;
		FeatherValueMax = 6400;
		FeatherValuePerFeather = 100;
		FeatherValueBaseMonthly = 12;
		FeatherValuePerChicken = 2;
		InitialFeatherValue = 50;
		InitialFeatherChickens = 3;
		CultivateFeatherValue = 700;
		CultivateCost = 7000;
		CultivateEnergyCost = 10;
		KingFeatherCount = 2;
		MaximumJieQingPoint = 99999;
		NormalQiwenXingtaiCount = 3;
		AdvancedQiwenXingtaiCount = 9;
		GainExtraJieqingXingyunProbability = 20;
		GainExtraJieqingXingyunValueMinInclusive = 500;
		GainExtraJieqingXingyunValueMaxExclusive = 501;
	}

	private void Init_SettlementTreasury()
	{
		TreasuryResourceSupplyRanges = new List<short[]>
		{
			new short[2] { 100, 150 },
			new short[2] { 200, 300 },
			new short[2] { 300, 450 },
			new short[2] { 400, 600 },
			new short[2] { 500, 750 }
		};
		TreasuryItemSupplyCounts = new List<sbyte[]>
		{
			new sbyte[9] { 4, 3, 2, 2, 2, 1, 1, 1, 0 },
			new sbyte[9] { 5, 4, 3, 2, 2, 2, 2, 1, 1 },
			new sbyte[9] { 6, 5, 4, 3, 3, 2, 3, 2, 1 },
			new sbyte[9] { 7, 6, 5, 4, 4, 3, 3, 3, 2 },
			new sbyte[9] { 8, 7, 6, 5, 5, 4, 4, 3, 3 }
		};
		MemberSelfImproveSpeedFactor = new List<int> { 50, 100, 200 };
		TreasuryStatusThreshold = new int[2] { 80, 120 };
		TreasuryGuardCount = 2;
		TreasuryGuardMaxGrade = new List<sbyte> { 2, 4, 6 };
		SectTreasuryGuardMaxGrade = new List<sbyte> { 3, 5, 7 };
		TreasuryRquireApprovingMid = 40;
		TreasuryRquireApprovingHigh = 70;
		TreasuryRquireSpiritualDebtMid = 400;
		TreasuryRquireSpiritualDebtHigh = 700;
		PrisonRequireApprovingMid = 400;
		PrisonRequireApprovingHigh = 700;
		TreasurySupplyLevelUpPercent = 150;
		TreasuryAlterTime = new int[3] { 3, 6, 12 };
		GuardConsummateLevel = new int[3] { 6, 10, 14 };
	}

	private void Init_SolarTerm()
	{
		SolarTermAddCombatSkillPower = 10;
		SolarTermAddHealOuterInjury = 20;
		SolarTermAddHealInnerInjury = 20;
		SolarTermAddRecoverQiDisorder = 10;
		SolarTermAddHealPoison = 20;
		SolarTermAddPoisonEffect = 20;
		SolarTermAddHealth = 20;
	}

	private void Init_Time()
	{
		ActionPointLimitPerMonth = 600;
		ActionPointRecoveryPerMonth = 300;
		MoreActionPointLimitPerMonth = 900;
		MoreActionPointRecoveryPerMonth = 450;
		GameStartDate = 8;
	}

	private void Init_Unclassified()
	{
		MapNormalBlockRange = 3;
		MapAreaOpenPrestige = 50;
		MapInitUnlockStationStateCount = 3;
		AgeBaby = 3;
		PopulationLimitRandomRateMax = 120;
		MaxAgeOfCreatingChar = 30;
		AgeShowBeard1 = 20;
		AgeShowBeard2 = 30;
		AgeShowWrinkle1 = 60;
		AgeShowWrinkle2 = 70;
		AgeShowWrinkle3 = 50;
		AvatarNoneFeatureObb = 5000;
		AvatarHasFeature1Obb = 2500;
		AvatarHasFeature2Obb = 2500;
		AvatarBadFeatureObb = 500;
		AvatarNoneBeardObb = 2500;
		AvatarFurColorSplitObb = 10;
		AvatarFurColorSplitObbArray = new byte[4] { 20, 40, 30, 10 };
		AvatarChanceMutation = 1000;
		EyebrowRatioInBaseCharm = 0.2f;
		EyesRatioInBaseCharm = 0.4f;
		NoseRatioInBaseCharm = 0.2f;
		MouthRatioInBaseCharm = 0.2f;
		NameLengthConfig_CN = new byte[2] { 2, 2 };
		NameLengthConfig_EN = new byte[2] { 6, 6 };
		FiveElementsTypeColor = new string[6] { "yellow", "darkpurple", "darkcyan", "red", "lightgreen", "white" };
		CombatSkillMaxBasePower = 100;
		CombatSkillMaxPower = 9999;
		EquipmentBaseMaxPower = 180;
		CollectResourcePercent = 33;
		RejuvenatedAge = 20;
		ImmaturityAttraction = 400;
		MaskOrVeilAttraction = 400;
		CricketActiveStartMonth = 7;
		CricketActiveEndMonth = 10;
		CricketSingGroupCricketCountMin = new byte[3] { 3, 3, 3 };
		CricketSingGroupCricketCountMax = new byte[3] { 6, 6, 6 };
		CricketSingGroupStartTimeMin = new float[3] { 0.5f, 10f, 12.5f };
		CricketSingGroupStartTimeMax = new float[3] { 7.5f, 15f, 22.5f };
		CricketSingGroupSingCountMin = new byte[3] { 2, 1, 0 };
		CricketSingGroupSingCountMax = new byte[3] { 4, 3, 2 };
		CricketSingBaseTimeMin = 0.5f;
		CricketSingBaseTimeMax = 1f;
		CricketSingGradeTime = 0.1f;
		CricketSingDelayTimeMin = 0.5f;
		CricketSingDelayTimeMax = 2f;
		CatchCricketSuccessSingLevel = 95;
		OrgCharBaseInfluencePowers = new short[9] { 10, 20, 30, 50, 70, 90, 120, 160, 210 };
		MarkLocationBaseMaxCount = 10;
		RecoveryOfQiDisorderUnitValue = 40;
		ShrineAuthorityPerTime = 200;
		GraveDurabilities = new short[4] { 6, 12, 36, 72 };
		GraveLevelMoneyCosts = new short[4] { 0, 1000, 3000, 9000 };
		ShrineAuthorityAddMonth = 1;
		TaiwuVillagerMaxPotential = 36;
		MinValueOfMaxMainAttributes = 1;
		MaxValueOfMaxMainAttributes = 9999;
		MinValueOfAttackAndDefenseAttributes = 20;
		MinAValueOfMinorAttributes = 20;
		AvatarElementGrowthDurations = new sbyte[7] { 18, 12, 12, 0, 0, 0, 18 };
		BaseHobbyChangingPeriod = 4;
		LifeSkillCombatPowerWave = new List<short[]>
		{
			new short[3] { 100, 100, 100 },
			new short[3] { 80, 100, 120 },
			new short[3] { 110, 80, 110 },
			new short[3] { 80, 140, 80 },
			new short[3] { 120, 100, 80 }
		};
		LifeSkillCombatAISwingRange = new List<byte[]>
		{
			new byte[2] { 1, 2 },
			new byte[2] { 2, 4 },
			new byte[2] { 1, 4 },
			new byte[2] { 2, 4 },
			new byte[2] { 1, 2 }
		};
		DisasterAdventureSpawnChance = 35;
		DisasterTriggerRanges = new sbyte[4] { 0, 1, 2, 3 };
		DisasterTriggerNeighborSumThresholds = new short[4] { 100, 155, 290, 425 };
		DisasterTriggerCurrBlockThresholds = new sbyte[4] { 100, 75, 50, 25 };
		BrokenAreaEnemyCountLevelDist = new sbyte[3] { 6, 4, 2 };
		WorthFactorsOfGrade = new short[9] { 1, 2, 4, 8, 16, 32, 64, 128, 256 };
		MinFavorabilityAfterTransferring = 14000;
		KidnapSlotBaseMaxCount = 1;
		ResistChangeOnKidnapCharacterTransfer = 20;
		AdventureNodePersonalityMinCost = 1;
		AdventureNodePersonalityMaxCost = 10;
		ChickenMiscTaste = 20;
		ChickenEscapeRate = 0.1f;
		ChickenDecayMin = 1;
		ChickenDecayMax = 2;
		SamsaraPlatformMaxProgress = 18;
		SamsaraPlatformBornInSectOdds = 75;
		SamsaraPlatformAddBasePercent = 2;
		SamsaraPlatformAddPercentPerLevel = 3;
		LegacyGroupLevelThresholds = new sbyte[4] { 0, 30, 60, 120 };
		SelectRandomLegacyCost = 500;
		MixiangzhenLifeSkillAdjustBonus = 70;
		MixiangzhenLifeSkillAdjustTypeCount = 3;
		XiuluochangCombatSkillAdjustBonus = 70;
		XiuluochangCombatSkillAdjustTypeCount = 3;
		RecruitPeopleCost = 3000;
		EquipmentWithEffectRate = 25;
		ComfortableHouseCapacity = 3;
		FixBookTotalProgress = new short[9] { 150, 200, 300, 500, 800, 1200, 1800, 2600, 3600 };
		SwordTombAdventureLastMonthCount = new short[4] { -99, 108, 72, 36 };
		SectApprovingRateUpperLimits = new short[10] { 30, 30, 40, 50, 60, 70, 80, 90, 100, 100 };
		XiangshuInfectionGradeUpperLimits = new sbyte[10] { 1, 1, 2, 3, 4, 5, 6, 7, 8, 8 };
		LegacyImageThreshold = new int[5] { 0, 3000, 6000, 9000, 12000 };
		OtherCombatWinHappiness = new int[5] { 2, 3, 2, 3, 2 };
		OtherCombatLoseHappiness = new int[5] { -2, -3, -2, -3, -2 };
		OtherCombatWinFavorability = new int[5] { -1200, -600, 0, -600, -1200 };
		OtherCombatLoseFavorability = new int[5] { 600, 1200, 600, 1200, 600 };
		HarmfulActionCost = 10;
		HarmfulActionSuccessGlobalFactor = 0;
		HarmfulActionPhaseBaseSuccessRate = 90;
		TaiwuShrineAddAuthorityFactor = 5;
		XiangshuInfectionAddSpeed = new sbyte[3] { 5, 3, 1 };
		DirectPageAddInjuryOdds = 40;
		ReversePageNoInjuryOdds = 60;
		AddAttainmentPerGrade = new sbyte[9] { 10, 10, 15, 20, 20, 25, 30, 40, 50 };
		TakeItemFromPrisonerMaxCount = 9999;
		EquipLoadSpeedPercent = new int[3] { 80, 50, 20 };
		EquipHealSpeedPercent = new int[3] { 110, 125, 140 };
		CombatNeiliAllocationAutoAddTotalProgress = 24000;
		CombatNeiliAllocationAutoReduceTotalProgress = 18000;
		CombatSkillNeiliAllocationBonusPercent = 25;
		TalkByPraiseOrSneerMaxDegree = new int[5] { 5, 4, 3, 5, 5 };
		TalkByPraiseOrSneerPerDegreeFavorability = new int[5] { 120, 150, 200, 120, 120 };
		TalkByPraiseBehaviorRate = new int[5] { 2, 3, 4, -2, 3 };
		TalkBySneerBehaviorRate = new int[5] { -2, -3, -4, 2, -3 };
		MourningMoneyCost = new int[4] { 50, 100, 300, 900 };
		UpgradeGraveMoneyCost = new int[3] { 1000, 3000, 9000 };
		RobGraveEventWeight = new sbyte[3] { 50, 40, 20 };
		ReadingFinishedBookExpGainPercent = 20;
		WeaponCdExtraWeight = 150;
		AgeShowWhiteHair = 60;
		ThreatenDifficultyFactorOfGrade = 6;
		ThreatenDifficultyFactorOfBehaviorType = new int[5] { 18, 12, 6, 12, 18 };
		ThreatenDifficultyFactorOfPositiveFavorType = new int[5] { 0, -300, -200, 300, 200 };
		ThreatenDifficultyFactorOfNegativeFavorType = new int[5] { -200, -300, 200, -300, 0 };
		ThreatenEffectFactorOfSortValue = 2;
		ThreatenEffectFactorOfHolderCount = 30;
		ThreatenEffectDenominatorOfCityAndTown = 3;
		ThreatenEffectDenominatorOfFame = 2;
		RepairInCombatFrameUnit = 6;
		GradeFactorOfStartRelationDifficultyByThreadNeedle = 6;
		BehaviorBonusOfStartRelationDifficultyByThreadNeedle = new int[5] { 18, 6, 12, 6, 18 };
		BehaviorFactorOfStartRelationDifficultyByThreadNeedle = new int[5] { 0, 300, 200, -300, 100 };
		GradeFactorOfEndRelationDifficultyByThreadNeedle = -6;
		BehaviorBonusOfEndRelationDifficultyByThreadNeedle = new int[5] { -18, -6, -12, -6, -18 };
		BehaviorFactorOfEndRelationDifficultyByThreadNeedle = new int[5] { 0, -300, -200, 300, -100 };
		SortValueFactorOfStartRelationEffectByThreadNeedle = 4;
		FameFactorPromotedOfStartRelationEffectByThreadNeedle = 4;
		FameFactorNominatedOfStartRelationEffectByThreadNeedle = 2;
		LifeSkillBattlePrimaryCardMaxUsedCount = 18;
		LifeSkillBattleMiddleCardMaxUsedCount = 9;
		LifeSkillBattleHighCardMaxUsedCount = 3;
		LegendaryBookUnlockBreakPlateTime = 10;
		LegendaryBookUnlockExp = new int[24]
		{
			500, 1000, 1500, 2000, 2500, 3000, 3500, 4000, 4500, 5000,
			5500, 6000, 6500, 7000, 7500, 8000, 8500, 9000, 9500, 10000,
			10500, 11000, 11500, 12000
		};
		LegendaryBookAppearAmounts = new sbyte[6] { 0, 1, 2, 4, 8, 14 };
		LegendaryBookAppearChance = 33;
		RequestLegendaryBookRequireRankWhenOwningBook = new int[5] { 40, 80, 20, 10, 5 };
		RequestLegendaryBookRequireRankWhenShocked = new int[5] { 24, 48, 12, 6, 3 };
		AcceptLegendaryBookAsGiftRequireRank = new int[5] { 5, 25, 100, 1000, 500 };
		InsectDetectionGenerationCount = 2;
		FindTreasureGradeRate = new sbyte[9] { 40, 35, 30, 25, 20, 15, 10, 5, 1 };
		ChoosyResourceBaseCost = 1000;
		PoisonLevelThresholds = new short[3] { 500, 3500, 12500 };
		AccessoryReducePoisonPercent = 100;
		AllocatedNeiliEffectPercent = 100;
		NpcBreakoutBaseSuccessRate = 40;
		SectAccessoryBonusCombatSkillPower = 20;
		AnimalSamsaraChance = 10;
		EnemyNestKidnappedCharHealthChange = -12;
		MaxConsummateLevel = 18;
		MaxCarrierTamePoint = 100;
		LearnCombatSkillPracticeLevelParam = 50;
		CombatSkillPracticeLevelBonusRequirements = new int[5] { 0, 30, 100, 210, 360 };
		CombatSkillPracticeLevelBonus = new int[5] { 1, 2, 3, 4, 5 };
		PersuadePrisonerNeedFrame = new int[9] { 25, 30, 40, 50, 60, 70, 80, 90, 100 };
		FiveLoongDlcMinionLoongMaxCount = 12;
		FiveLoongDlcMaxDebuffCount = 99;
		JiaoEggIncubationTime = 3;
		JiaoBreedingTime = 3;
		InitJiaoEggDropRate = 20;
		InitMaleJiaoEggDropRate = 50;
		BringUpJiaoCalcParam = new int[3] { 100, 50, 1 };
		BringUpJiaoBehaviorParam = new int[5] { 60, 40, 80, 150, 120 };
		BurriedScalesOfEachLoongArea = 18;
		BurriedEggsOfEachLoongArea = 3;
		JiaoEggDropRateUpPerMiss = 20;
		JiaoTamePointAddWhenCaught = 15;
		BuildingResourceYieldLevelAttenuationPercent = 80;
		JiaoLoongCarrierPropertyFactor = new int[2] { 60, 40 };
		JiaoLoongGiftPropertyFactor = new int[2] { 45, 30 };
		JiaoLoongPresentPropertyFactor = new int[2] { 30, 20 };
		JiaoInitialTamePoint = new int[2] { 50, 70 };
		JiaoFleeBehaviorInfluence = new int[5] { 60, 40, 80, 150, 120 };
		JiaoPropertyChangeBehaviorInfluence = new int[5] { 80, 50, 100, 200, 150 };
		DefeatLoongGetScaleCount = 9;
		RequiredLoongScaleForFirstTimeEvolution = 9;
		RequiredLoongScaleForEvolution = 3;
		JiaoEggGenderModification = 25;
		TaiwuVillageMoneyPrestigeCompensation = 10;
		PettingJiaoAddsTamingPoints = 15;
		PettingJiaoFunctionCoolDuration = 3;
		BaseCricketGrade = new sbyte[9] { 0, 0, 0, 1, 2, 3, 4, 4, 5 };
		BaseCricketWagerGrade = new sbyte[9] { 0, 1, 2, 2, 3, 4, 4, 5, 6 };
		EclecticDivisor = 150;
		PureEclecticDivisor = 75;
		CharGradeDecrement = -2;
		CombatResourceDropParam = new int[9] { 100, 200, 400, 700, 900, 1400, 2000, 4000, 7000 };
		WugJugRefiningCostPoison = 10000;
		WugJugRefiningCostPoisonBonusPercent = 100;
		WugJugRefiningCostPoisonMonthPercent = -50;
		WugJugPoisonDropRatio = 10;
		FoodGradeAddCarrierDurability = new int[9] { 30, 30, 30, 60, 60, 60, 90, 90, 90 };
		LikeFoodAddCarrierDurability = 30;
		DislikeFoodAddCarrierDurability = -30;
		WuxianSpiritualDebtInteractionRemoveWugCount = 3;
		WuxianSpiritualDebtInteractionChangeWugKingDuration = -12;
		BuildingTotalAttainmentFinalDivisor = 3;
		BuildingSoldItemExtraAddFactor = 40;
		BuildingOutputRandomFactorUpperLimit = 120;
		BuildingOutputRandomFactorLowerLimit = 80;
		ReferenceBookSlotUnlockParams = new int[3] { 0, 200, 400 };
		RandomEnemyEscapeConsummateLevelGap = 4;
		ShopManagerLearnSkillMaxGrades = new sbyte[10] { 1, 1, 2, 3, 4, 5, 6, 7, 8, 8 };
		ShopManagerLearnRandomGradeChance = 25;
		LifeSkillBookRefBonus = 15;
		SameTypeBookRefBonus = 30;
		AddMemberFeatureMinGrade = 3;
		MaxTreasuryGuardCount = 3;
		MaxTreasuryGuardGrade = 7;
		TreasuryGuardTeammateCdBonus = -80;
		TreasuryGuardPropertyPercent = 75;
		TreasuryGuardAttainmentPercent = 150;
		HostileOperationTakeItemCostTime = 5;
		HostileOperationTakeItemMaxResourceFactor = 5;
		MaxActiveReadingProgress = 30;
		MaxActiveNeigongLoopingProgress = 30;
		MaxExtraNeiliAllocation = 50;
		ExtraNeiliAllocationFromProgressRatio = 55;
		MaxQiArtStrategyCount = 3;
		CharacterGradeAlertness = new sbyte[9] { 1, 1, 2, 2, 3, 3, 4, 4, 5 };
		ActiveReadingAttributeCost = 3;
		ActiveNeigongLoopingAttributeCost = 3;
		ActiveReadingTimeCost = 1;
		ActiveNeigongLoopingTimeCost = 1;
		MouseTipDelayTime = 0.2f;
		ReferenceSkillSlotUnlockParams = new int[3] { 0, 200, 400 };
		BaseLoopingEventProbability = 20;
		PlotHarmActionAttainmentThresholds = new short[6] { 30, 60, 150, 210, 360, 450 };
		PoisonActionAttainmentThresholds = new short[3] { 60, 210, 450 };
		ExtraNeiliAllocationFromProgressRatioGrowth = 5;
		ActiveReadProgressAffectedEfficiency = new short[3] { 150, 100, 50 };
		ActiveLoopProgressAffectedEfficiency = new short[3] { 150, 100, 50 };
		InscriptionCharForCreationMaxCount = 100;
		SettlementTreasuryGetItemMaxCount = 9;
		SettlementTreasuryGiveItemMaxCount = 9;
		BaihuaLifeLinkRemoveCharacterCooldown = 6;
		FulongFlameDamage = 1;
		FulongMineDamage = 2;
		FulongMineDamageTaiwu = 4;
		SettlementAlterTime = 6;
		PoisonByToxicologyAttainmentThresholds = new short[9] { 50, 100, 150, 200, 210, 300, 360, 450, 600 };
		CondensedPoisonValueBonus = 50;
		CondensePoisonRequiredAttainmentBonus = 50;
		FulongFlameExtinguishCost = 1;
		VillagerRoleFarmerMigrateMinResource = 120;
		VillagerRoleFarmerMigrateBaseSuccessRate = 10;
		FulongFlameBoomNumber = 6;
		FulongFlameExtinguishTime = 5;
		ProfessionSkillRecoverActionPointLimit = 300;
		ConsummateLevelPoints = new int[9] { 5, 10, 15, 20, 25, 30, 35, 45, 55 };
		ConsummateLevelProgressSpeed = new int[9] { 127, 150, 187, 240, 315, 390, 510, 660, 975 };
		ConsummateLevelProgressThreshold = new int[18]
		{
			400, 800, 1200, 1600, 2000, 2400, 2800, 3200, 3600, 4000,
			4400, 4800, 5200, 5600, 6000, 6400, 6800, 7200
		};
		TravelingBuddhistMonkSkill2QualificationDelta = new short[9] { 3, 3, 3, 2, 2, 2, 1, 1, 1 };
		TeachSkillBookSelctMaxCount = 9;
		TeachSkillCharacterMaxCount = 12;
		GearMateRepairInjuryAttainmentRequirement = new short[6] { 30, 60, 120, 210, 330, 480 };
		GearMateRepairPoisonAttainmentRequirement = new short[3] { 60, 210, 480 };
		GearMateRepairDisorderOfQiAttainmentRequirement = new short[5] { 0, 60, 210, 480, 480 };
		BaseRefBonusSpeed = 30;
		ProfessionSeniorityPerMonth = 10000;
		TaiwuBubbleBoxDisplayRequirement = 15;
		HunterSkill2_OddFormulaFactorA = 20;
		HunterSkill2_OddFormulaFactorB = 20;
		HunterSkill2_AnimalCountIndexToAnimalConsummateLevelList = new List<byte[]>
		{
			new byte[4] { 0, 2, 4, 6 },
			new byte[4] { 4, 6, 8, 10 },
			new byte[4] { 8, 10, 12, 14 }
		};
		HunterSkill2_SeniorityPercentToAnimalCount = new short[3] { 80, 90, 100 };
		TeachProfessionSkillSeniority = new int[4] { 3000, 12000, 36000, 72000 };
		KidnapResistanceBonusInPrison = 100;
		SavageSkill3_OpenItemSelectTimeCost = 10;
		GiveProfessionInformationFactorWithExtraSeniority = 50;
		DoctorSkill3_HealthTransferPercent = 50;
		DoctorSkill3_FavorabilityChangePercent = 500;
		VillagerInfluencePowerRankingRatio = new short[9] { 1, 2, 3, 5, 8, 12, 17, 22, 30 };
		TeaWineEffectDisorderOfQiDelta = new int[2] { 50, 150 };
		ProfessionInitialFavorabilitiesImprovePercent = 33;
		TownPunishmentSeverityCustomizeDuration = 36;
		SpiritualDebtInteractionRanshanMaxReadingCount = 9;
		SpiritualDebtInteractionRanshanMaxNeigongLoopingCount = 7;
		KongsangCharacterFeaturePoisonedProbParm = new int[2] { 25, 5 };
		BaseCombatSkillPracticeProficiencyDelta = new int[2] { 3, 6 };
		CombatSkillPracticeActionPointCost = new int[2] { 200, 5 };
		ImprisonInStoneHouseChance = 33;
		MapPickupResourceCountRandomFactor = 25;
		MapPickupItemGradeRandomFactor = 1;
		MapPickupHasXiangshuMinionProbability = 25;
		MakeItemStageAttainmentFactor = new int[3] { 100, 150, 200 };
		ModifySeverityDefaultRange = 1;
		ModifySeverityCostFactor = 1000;
		TeaHorseCaravanLevelToAwareness = new short[20]
		{
			100, 150, 200, 300, 400, 500, 600, 700, 800, 1000,
			1200, 1400, 1600, 1900, 2200, 2500, 2800, 3200, 3600, 4000
		};
		ResidentUnlockCost = new List<ResourceInfo>
		{
			new ResourceInfo(1, 1000),
			new ResourceInfo(2, 1000),
			new ResourceInfo(1, 1000),
			new ResourceInfo(2, 1000),
			new ResourceInfo(2, 1000),
			new ResourceInfo(1, 1000),
			new ResourceInfo(2, 1000),
			new ResourceInfo(1, 1000)
		};
		WarehouseUnlockCost = new List<ResourceInfo>
		{
			new ResourceInfo(2, 1000),
			new ResourceInfo(7, 500),
			new ResourceInfo(1, 1000),
			new ResourceInfo(5, 1000),
			new ResourceInfo(0, 1000),
			new ResourceInfo(3, 1000),
			new ResourceInfo(6, 5000),
			new ResourceInfo(4, 1000)
		};
		ComfortableHouseUnlockCost = new List<ResourceInfo>
		{
			new ResourceInfo(6, 25000),
			new ResourceInfo(7, 2500)
		};
		VowRewardResourceBasePrice = 10000;
		VowFinishedSectStoryAuthorityPercent = 50;
		MainStoryHelpSectApprovedGrades = new sbyte[4] { 0, 1, 2, 3 };
		MainStoryHelpSectApprovedCounts = new int[4] { 3, 2, 1, 1 };
		MainStoryHelpSectAddSpiritualDebt = 1000;
		MainStoryNotHelpSectAddSpiritualDebt = -500;
		TaiwuVillageUpgradeAuthorityCosts = new int[15]
		{
			0, 2500, 5000, 7500, 10000, 12500, 15000, 17500, 20000, 25000,
			30000, 35000, 40000, 45000, 50000
		};
		RecruitCharacterGradeScoreThresholds = new int[9] { 100, 200, 300, 500, 700, 900, 1200, 1600, 2100 };
		ShopManageProgressBaseDelta = 650;
		MaxProductionProgress = 10000;
		MaterialWeightToArtisanOrder = new int[3] { 40, 60, 10 };
		InitialProductionWeight = new int[3] { 10, 60, 40 };
		AddOnAttainmentOfWorker = 50;
		AddOnAttainmentOfLeader = 150;
		WorkerAttainmentDivider = 3;
		ArtisanAttainmentFactor1 = 2;
		ArtisanAttainmentFactor2 = 200;
		MonthlyOrderProgressBase = 250;
		MonthlyOrderProgressFactor = 2;
		TeaWineArtisanOrderAttainmentRequirement = new int[9] { 10, 30, 60, 100, 150, 210, 280, 360, 450 };
		CollectResourceBuildingProductivityDistanceOne = new int[4] { 100, 80, 60, 40 };
		CollectResourceBuildingProductivityDistanceMore = 20;
		ShopBuildingSharePencent = new sbyte[2] { 20, 10 };
		DarkRiverHugeSnakeTamePoint = 95;
		ExtendFavorSafetyAndCultureAreaFactor = new sbyte[3] { 20, 15, 10 };
		RefreshItemApCost = 50;
		VillagerSkillLegacyAttainmentRequirement = 450;
		MapDestroyedBlockPathingCost = 90;
		GenerateXiangshuMinionAfterDisasterRangeMax = 3;
		GenerateXiangshuMinionAfterDisasterBase = 1;
		GenerateXiangshuMinionAfterDisasterGradeMinusMax = 3;
		GenerateXiangshuMinionAfterDisasterInDevelopedBlockProbabilityPercentage = 33;
		TravelingEventRoadBlockDurabilityChange = 10;
		FulongServantBaseAttraction = 600;
		ExtraLegacyPointGain = new List<int[]>
		{
			new int[7] { 200, 150, 100, 0, 0, 0, 0 },
			new int[7] { 0, 0, 0, 0, 100, 150, 200 }
		};
		SettlementInfluenceRange = 3;
		ResourceBlockBuildingCoreProducingCooldown = new int[2] { 3, 6 };
		ResourceBlockBuildingCoreProducingMaxChance = new int[2] { 10000, 30000 };
		GeneratedXiangshuMinionDurationFactor = 100;
		BrokenPerformDarkAshInfectorRangeMax = 3;
		BrokenPerformDarkAshInfectorBase = 3;
		DarkAshDurationOldTaosim = 6;
		DarkAshDurationRangeMax = 7;
		DarkAshDurationBase = 6;
		FuyuFaithDebtFactor = 300;
		AppointmentCostDays = 5;
		TaiwuVillagerSkillBreakBonusItemGradeLimit = 5;
		SwapSkillBreakCostExp = 5;
		DistantMarriageInfluencedByTaiwuFavorDelta = 15000;
		MonthsMonthNotificationsKept = 12;
		SpiritualDebtInteractionChangeMoralityMax = 50;
		FameAbsValueForBothGoodAndBad = 50;
		WineTasterSkill2Factor = 10;
		AgePercentShowWrinkle1 = 60;
		AgePercentShowWrinkle2 = 70;
		AgePercentShowWrinkle3 = 50;
		TaiwuVillagerSkillBreakBonusItemGradeLimitArray = new int[19]
		{
			0, 0, 1, 1, 2, 2, 3, 3, 4, 4,
			5, 5, 6, 6, 7, 7, 8, 8, 8
		};
	}

	public void ImportFromCollection(IEnumerable enumerable)
	{
	}

	public void ExportToFiles(string directory)
	{
		string path = Path.Combine(directory, GetType().Name + ".json");
		CommonObjectSerializer.Serialize(this, out var content, CommonObjectSerializer.MarshalFormat.Json);
		File.WriteAllText(path, content);
	}

	public void ImportFromFiles(string directory)
	{
		CommonObjectSerializer.Deserialize<GlobalConfig>(File.ReadAllText(Path.Combine(directory, GetType().Name + ".json")), out var globalConfig, CommonObjectSerializer.MarshalFormat.Json);
		Instance = globalConfig;
	}
}

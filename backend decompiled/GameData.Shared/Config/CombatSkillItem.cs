using System;
using System.Collections.Generic;
using Config.Common;
using Config.ConfigCells.Character;
using GameData.Domains.Character;
using GameData.Domains.Item;

namespace Config;

/// <summary>
/// 功法配置
/// </summary>
[Serializable]
public class CombatSkillItem : ConfigItem<CombatSkillItem, short>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 品阶
	/// </summary>
	public readonly sbyte Grade;

	/// <summary>
	/// 说明
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 图标
	/// </summary>
	public readonly string Icon;

	/// <summary>
	/// 装备部位类型
	/// - 内功、摧破、轻灵、护体、奇窍
	/// </summary>
	public readonly sbyte EquipType;

	/// <summary>
	/// 类型
	/// - 拳掌、指法…
	/// </summary>
	public readonly sbyte Type;

	/// <summary>
	/// 子类型
	/// </summary>
	public readonly ECombatSkillSubType SubType;

	/// <summary>
	/// 功法栏格数
	/// </summary>
	public readonly sbyte GridCost;

	/// <summary>
	/// 门派
	/// - 门派的团体模板 ID
	/// </summary>
	public readonly sbyte SectId;

	/// <summary>
	/// 五行
	/// - 0~4: 金木水火土，5: 混元
	/// </summary>
	public readonly sbyte FiveElements;

	/// <summary>
	/// 书籍ID
	/// </summary>
	public readonly short BookId;

	/// <summary>
	/// NPC能否在奇遇中意外获得
	/// </summary>
	public readonly bool CanObtainByAdventure;

	/// <summary>
	/// 是否在门派功法树中隐藏（不传之秘）
	/// </summary>
	public readonly bool IsNonPublic;

	/// <summary>
	/// 门派功法排序
	/// - 功法在所属门派内的Id
	/// </summary>
	public readonly sbyte OrderIdInSect;

	/// <summary>
	/// 使用需求
	/// - 数据格式：{能力类型,需求数值}
	/// </summary>
	public readonly List<PropertyAndValue> UsingRequirement;

	/// <summary>
	/// 正练特效ID
	/// </summary>
	public readonly int DirectEffectID;

	/// <summary>
	/// 逆练特效ID
	/// </summary>
	public readonly int ReverseEffectID;

	/// <summary>
	/// 传授时的资质加成系数
	/// </summary>
	public readonly byte InheritAttainmentAdiitionRate;

	/// <summary>
	/// 修炼类型
	/// - 对应代码中CombatSkillPracticeType枚举值
	/// </summary>
	public readonly sbyte PracticeType;

	/// <summary>
	/// 突破盘 ID
	/// </summary>
	public readonly sbyte SkillBreakPlateId;

	/// <summary>
	/// 突破起点
	/// </summary>
	public readonly string BreakStart;

	/// <summary>
	/// 突破终点
	/// </summary>
	public readonly string BreakEnd;

	/// <summary>
	/// 走火入魔伤势是否内伤
	/// </summary>
	public readonly bool GoneMadInnerInjury;

	/// <summary>
	/// 走火入魔伤势部位
	/// </summary>
	public readonly List<sbyte> GoneMadInjuredPart;

	/// <summary>
	/// 走火入魔伤势值
	/// </summary>
	public readonly sbyte GoneMadInjuryValue;

	/// <summary>
	/// 走火入魔内息紊乱值
	/// </summary>
	public readonly short GoneMadQiDisorder;

	/// <summary>
	/// 周天运转可获得的总内力值
	/// </summary>
	public readonly short TotalObtainableNeili;

	/// <summary>
	/// 每次周天运转增加的内力值
	/// </summary>
	public readonly short ObtainedNeiliPerLoop;

	/// <summary>
	/// 移入五行
	/// - 周天运转五行转移时, 量增加的五行类型
	/// </summary>
	public readonly sbyte DestTypeWhileLooping;

	/// <summary>
	/// 转移方式
	/// - 周天运转五行转移时, 转移的方式. 0: 从克制自己的转移到自己, 1: 从被自己克制的转移到自己, 2: 从化生自己的转移到自己, 3: 从被自己化生的转移到自己.
	/// </summary>
	public readonly sbyte TransferTypeWhileLooping;

	/// <summary>
	/// 五行转移量
	/// - 周天运转五行转移时的转移量
	/// </summary>
	public readonly sbyte FiveElementChangePerLoop;

	/// <summary>
	/// 各类功法格数
	/// - 由辅助配置列组合，不可直接配置此列
	/// </summary>
	public readonly sbyte[] SpecificGrids;

	/// <summary>
	/// 万用格数
	/// </summary>
	public readonly sbyte GenericGrid;

	/// <summary>
	/// 命中
	/// </summary>
	public readonly HitOrAvoidShorts HitValues;

	/// <summary>
	/// 化解
	/// </summary>
	public readonly HitOrAvoidShorts AvoidValues;

	/// <summary>
	/// 攻击
	/// </summary>
	public readonly OuterAndInnerShorts Penetrations;

	/// <summary>
	/// 防御
	/// </summary>
	public readonly OuterAndInnerShorts PenetrationResists;

	/// <summary>
	/// 架势提气恢复
	/// </summary>
	public readonly OuterAndInnerShorts RecoveryOfStanceAndBreath;

	/// <summary>
	/// 移动速度
	/// </summary>
	public readonly short MoveSpeed;

	/// <summary>
	/// 步伐稳健
	/// </summary>
	public readonly short RecoveryOfFlaw;

	/// <summary>
	/// 施展速度
	/// </summary>
	public readonly short CastSpeed;

	/// <summary>
	/// 引气冲关
	/// </summary>
	public readonly short RecoveryOfBlockedAcupoint;

	/// <summary>
	/// 武具发挥
	/// </summary>
	public readonly short WeaponSwitchSpeed;

	/// <summary>
	/// 攻击速度
	/// </summary>
	public readonly short AttackSpeed;

	/// <summary>
	/// 内功发挥
	/// </summary>
	public readonly short InnerRatio;

	/// <summary>
	/// 调息吐纳
	/// </summary>
	public readonly short RecoveryOfQiDisorder;

	/// <summary>
	/// 毒素抵抗
	/// </summary>
	public readonly PoisonShorts PoisonResists;

	/// <summary>
	/// 资源包名称
	/// - Asset文件名
	/// </summary>
	public readonly string AssetFileName;

	/// <summary>
	/// 准备动画
	/// </summary>
	public readonly string PrepareAnimation;

	/// <summary>
	/// 施展动画
	/// </summary>
	public readonly string CastAnimation;

	/// <summary>
	/// 施展特效
	/// </summary>
	public readonly string CastParticle;

	/// <summary>
	/// 施展附属动画
	/// - 仅在施展时显示的附属骨骼和特效
	/// </summary>
	public readonly string CastPetAnimation;

	/// <summary>
	/// 施展附属特效
	/// </summary>
	public readonly string CastPetParticle;

	/// <summary>
	/// 开始施展和4段功法动画播放时双方的距离
	/// - 开始施展时攻击者移动，后4段动画受击者移动
	/// </summary>
	public readonly short[] DistanceWhenFourStepAnimation;

	/// <summary>
	/// 施展音效
	/// </summary>
	public readonly string CastSoundEffect;

	/// <summary>
	/// 玩家施展boss功法准备动画
	/// - 玩家施展boss功法时的表现效果
	/// </summary>
	public readonly string PlayerCastBossSkillPrepareAni;

	/// <summary>
	/// 玩家施展boss功法施展动画
	/// </summary>
	public readonly string PlayerCastBossSkillAni;

	/// <summary>
	/// 玩家施展boss功法施展特效
	/// </summary>
	public readonly string PlayerCastBossSkillParticle;

	/// <summary>
	/// 玩家施展boss功法施展音效
	/// </summary>
	public readonly string PlayerCastBossSkillSound;

	/// <summary>
	/// 玩家施展boss功法表现距离
	/// </summary>
	public readonly short[] PlayerCastBossSkillDistance;

	/// <summary>
	/// 准备（读条）总进度值
	/// - 每帧增加60+40*人物施展速度
	/// </summary>
	public readonly int PrepareTotalProgress;

	/// <summary>
	/// 施展需要的身体部位列表
	/// - 0-头|1-胸|2-腹|3-双手|4-单手|5-双腿|6-单腿，3和4、5和6不可同时配置
	/// </summary>
	public readonly List<sbyte> NeedBodyPartTypes;

	/// <summary>
	/// 消耗脚力/身法百分比
	/// </summary>
	public readonly short MobilityCost;

	/// <summary>
	/// 气势总消耗%
	/// - 根据内功比例分配为提气架势
	/// </summary>
	public readonly sbyte BreathStanceTotalCost;

	/// <summary>
	/// 初始内功比例
	/// - 提气架势, 内伤外伤, 破体破气等的内外功比例. 取值范围 [0, 100], 0 表示纯外功, 100 表示纯内功.
	/// </summary>
	public readonly sbyte BaseInnerRatio;

	/// <summary>
	/// 内功比例变化范围
	/// - 受人物内功发挥属性加成
	/// </summary>
	public readonly sbyte InnerRatioChangeRange;

	/// <summary>
	/// 攻击
	/// - 根据内功发挥分配为破体破气
	/// </summary>
	public readonly short Penetrate;

	/// <summary>
	/// 施展时增加的距离
	/// </summary>
	public readonly short DistanceAdditionWhenCast;

	/// <summary>
	/// 消耗式
	/// - 数据格式：{式类型,个数}。式类型对应Combat/TrickType表中的模板ID
	/// </summary>
	public readonly List<NeedTrick> TrickCost;

	/// <summary>
	/// 消耗武器耐久度
	/// </summary>
	public readonly sbyte WeaponDurableCost;

	/// <summary>
	/// 消耗蛊引数
	/// </summary>
	public readonly sbyte WugCost;

	/// <summary>
	/// 最佳武器分组ID
	/// - 对应Item/Weapon表中的模板ID, 配置同组的首位武器即可
	/// </summary>
	public readonly short MostFittingWeaponID;

	/// <summary>
	/// 固定最佳武器
	/// - 对应Item/Weapon表中的模板ID
	/// </summary>
	public readonly short FixedBestWeaponID;

	/// <summary>
	/// 攻击部位概率分布
	/// - 对应Combat/BodyPart表中的模板ID
	/// </summary>
	public readonly sbyte[] InjuryPartAtkRateDistribution;

	/// <summary>
	/// 总命中值
	/// - 根据每段成数分布分配到各种命中类型
	/// </summary>
	public readonly short TotalHit;

	/// <summary>
	/// 每段命中威力成数分布
	/// - 力道、精妙、迅疾、动心
	/// </summary>
	public readonly sbyte[] PerHitDamageRateDistribution;

	/// <summary>
	/// 有无点穴效果
	/// </summary>
	public readonly bool HasAtkAcupointEffect;

	/// <summary>
	/// 有无破绽效果
	/// </summary>
	public readonly bool HasAtkFlawEffect;

	/// <summary>
	/// 含有毒素
	/// </summary>
	public readonly PoisonsAndLevels Poisons;

	/// <summary>
	/// 装备损坏几率
	/// </summary>
	public readonly sbyte EquipmentBreakOdds;

	/// <summary>
	/// 施展后添加蛊类型
	/// - 用于NPC间战斗简易流程
	/// </summary>
	public readonly sbyte AddWugType;

	/// <summary>
	/// 施展后添加伤残特性
	/// </summary>
	public readonly short[] AddBreakBodyFeature;

	/// <summary>
	/// 移动速度加成
	/// - 最终加成值=(GlobalConfig.AgileSkillBaseAddSpeed|AgileSkillBaseAddHit)*配置值/100
	/// </summary>
	public readonly short AddMoveSpeedOnCast;

	/// <summary>
	/// 移动速度百分比加成
	/// </summary>
	public readonly short AddPercentMoveSpeedOnCast;

	/// <summary>
	/// 移动间隔影响
	/// </summary>
	public readonly short MoveCdBonus;

	/// <summary>
	/// 命中值加成
	/// </summary>
	public readonly short[] AddHitOnCast;

	/// <summary>
	/// 身法值每帧减少值
	/// - 每帧减少 MobilityReduceSpeed 后判定移除身法，未移除时增加 MobilityAddSpeed，每次移动消耗 MoveCostMobility
	/// </summary>
	public readonly int MobilityReduceSpeed;

	/// <summary>
	/// 身法值每帧增加值
	/// </summary>
	public readonly int MobilityAddSpeed;

	/// <summary>
	/// 每次移动消耗身法值
	/// </summary>
	public readonly int MoveCostMobility;

	/// <summary>
	/// 蓄力移动距离上限
	/// - 蓄力移动相关配置，仅特效激活时生效。后退时蓄力帧数需*1.33。允许部分蓄力时可在未蓄力到上限时移动，但仍以10距离为单位
	/// </summary>
	public readonly sbyte MaxJumpDistance;

	/// <summary>
	/// 单位距离蓄力帧数
	/// </summary>
	public readonly int JumpPrepareFrame;

	/// <summary>
	/// 能否部分蓄力
	/// </summary>
	public readonly bool CanPartlyJump;

	/// <summary>
	/// 蓄力移动动画
	/// - 0-前进、1-后退
	/// </summary>
	public readonly string[] JumpAni;

	/// <summary>
	/// 蓄力移动特效
	/// </summary>
	public readonly string[] JumpParticle;

	/// <summary>
	/// 蓄力移动距离变化延迟帧数
	/// </summary>
	public readonly short JumpChangeDistanceFrame;

	/// <summary>
	/// 蓄力移动距离变化帧数
	/// - 默认持续到动画结束
	/// </summary>
	public readonly short JumpChangeDistanceDuration;

	/// <summary>
	/// 分数加成类型
	/// - AI 在选取功法时的分数加成类型. -1: 无加成, -2: 必选, 2: 腿法.
	/// </summary>
	public readonly sbyte ScoreBonusType;

	/// <summary>
	/// 分数加成
	/// - AI 在选取功法时的分数加成
	/// </summary>
	public readonly short ScoreBonus;

	/// <summary>
	/// 御体加成
	/// - 最终加成值=(GlobalConfig.DefendSkillBaseAddPenetrateResist)*配置值/100
	/// </summary>
	public readonly short AddOuterPenetrateResistOnCast;

	/// <summary>
	/// 御气加成
	/// </summary>
	public readonly short AddInnerPenetrateResistOnCast;

	/// <summary>
	/// 化解值加成
	/// - 最终加成值=(GlobalConfig.DefendSkillBaseAddAvoid)*配置值/100
	/// </summary>
	public readonly short[] AddAvoidOnCast;

	/// <summary>
	/// 反击威力
	/// </summary>
	public readonly short FightBackDamage;

	/// <summary>
	/// 外伤反震威力
	/// </summary>
	public readonly short BounceRateOfOuterInjury;

	/// <summary>
	/// 内伤反震威力
	/// </summary>
	public readonly short BounceRateOfInnerInjury;

	/// <summary>
	/// 持续帧数
	/// </summary>
	public readonly short ContinuousFrames;

	/// <summary>
	/// 反震距离
	/// </summary>
	public readonly short BounceDistance;

	/// <summary>
	/// 护体动画
	/// - 护体功法生效期间持续播放
	/// </summary>
	public readonly string DefendAnimation;

	/// <summary>
	/// 护体特效
	/// </summary>
	public readonly string DefendParticle;

	/// <summary>
	/// 护体音效
	/// </summary>
	public readonly string DefendSound;

	/// <summary>
	/// 反击动画
	/// </summary>
	public readonly string FightBackAnimation;

	/// <summary>
	/// 反击特效
	/// </summary>
	public readonly string FightBackParticle;

	/// <summary>
	/// 反击音效
	/// </summary>
	public readonly string FightBackSound;

	/// <summary>
	/// 运功属性加成
	/// - 目前仅用于奇窍功法
	/// </summary>
	public readonly List<PropertyAndValue> PropertyAddList;

	/// <summary>
	/// 全部位外伤阈值
	/// </summary>
	public readonly int[] OuterDamageSteps;

	/// <summary>
	/// 全部位内伤阈值
	/// </summary>
	public readonly int[] InnerDamageSteps;

	/// <summary>
	/// 重创
	/// </summary>
	public readonly int FatalDamageStep;

	/// <summary>
	/// 心神
	/// </summary>
	public readonly int MindDamageStep;

	/// <summary>
	/// 提供的周天策略
	/// </summary>
	public readonly List<sbyte> PossibleQiArtStrategyList;

	/// <summary>
	/// 获取真气进度
	/// - 每次周天结束，获取多少真气的增加进度，增加进度达到100时，对应真气额外+1，最多50真气，做为额外的真气，不影响内力的加点
	/// </summary>
	public readonly sbyte[] ExtraNeiliAllocationProgress;

	/// <summary>
	/// 对周天有加成的内功
	/// - 当列表中的内功是辅助内功时，对当前内功周天有加成
	/// </summary>
	public readonly List<short> LoopBonusSkillList;

	/// <summary>
	/// 天人感应的概率
	/// </summary>
	public readonly sbyte QiArtStrategyGenerateProbability;

	/// <summary>
	/// 无效的玄机格类型
	/// - 主要用于补充无法通过功法装配类型排除的玄机格类型
	/// </summary>
	public readonly List<sbyte> InvalidBreakBonusTypes;

	/// <summary>
	/// 功法视频名字
	/// - 用于门派功法界面播放视频
	/// </summary>
	public readonly string VideoName;

	/// <summary>
	/// 突破盘
	/// </summary>
	public SkillBreakPlateItem SkillBreakPlate => Config.SkillBreakPlate.Instance[SkillBreakPlateId];

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">名称</param>
	/// <param name="grade">品阶</param>
	/// <param name="desc">说明</param>
	/// <param name="icon">图标</param>
	/// <param name="equipType">装备部位类型 - 内功、摧破、轻灵、护体、奇窍</param>
	/// <param name="type">类型 - 拳掌、指法…</param>
	/// <param name="subType">子类型</param>
	/// <param name="gridCost">功法栏格数</param>
	/// <param name="sectId">门派 - 门派的团体模板 ID</param>
	/// <param name="fiveElements">五行 - 0~4: 金木水火土，5: 混元</param>
	/// <param name="bookId">书籍ID</param>
	/// <param name="canObtainByAdventure">NPC能否在奇遇中意外获得</param>
	/// <param name="isNonPublic">是否在门派功法树中隐藏（不传之秘）</param>
	/// <param name="orderIdInSect">门派功法排序 - 功法在所属门派内的Id</param>
	/// <param name="usingRequirement">使用需求 - 数据格式：{能力类型,需求数值}</param>
	/// <param name="directEffectID">正练特效ID</param>
	/// <param name="reverseEffectID">逆练特效ID</param>
	/// <param name="inheritAttainmentAdiitionRate">传授时的资质加成系数</param>
	/// <param name="practiceType">修炼类型 - 对应代码中CombatSkillPracticeType枚举值</param>
	/// <param name="skillBreakPlateId">突破盘 ID</param>
	/// <param name="breakStart">突破起点</param>
	/// <param name="breakEnd">突破终点</param>
	/// <param name="goneMadInnerInjury">走火入魔伤势是否内伤</param>
	/// <param name="goneMadInjuredPart">走火入魔伤势部位</param>
	/// <param name="goneMadInjuryValue">走火入魔伤势值</param>
	/// <param name="goneMadQiDisorder">走火入魔内息紊乱值</param>
	/// <param name="totalObtainableNeili">周天运转可获得的总内力值</param>
	/// <param name="obtainedNeiliPerLoop">每次周天运转增加的内力值</param>
	/// <param name="destTypeWhileLooping">移入五行 - 周天运转五行转移时, 量增加的五行类型</param>
	/// <param name="transferTypeWhileLooping">转移方式 - 周天运转五行转移时, 转移的方式. 0: 从克制自己的转移到自己, 1: 从被自己克制的转移到自己, 2: 从化生自己的转移到自己, 3: 从被自己化生的转移到自己.</param>
	/// <param name="fiveElementChangePerLoop">五行转移量 - 周天运转五行转移时的转移量</param>
	/// <param name="specificGrids">各类功法格数 - 由辅助配置列组合，不可直接配置此列</param>
	/// <param name="genericGrid">万用格数</param>
	/// <param name="hitValues">命中</param>
	/// <param name="avoidValues">化解</param>
	/// <param name="penetrations">攻击</param>
	/// <param name="penetrationResists">防御</param>
	/// <param name="recoveryOfStanceAndBreath">架势提气恢复</param>
	/// <param name="moveSpeed">移动速度</param>
	/// <param name="recoveryOfFlaw">步伐稳健</param>
	/// <param name="castSpeed">施展速度</param>
	/// <param name="recoveryOfBlockedAcupoint">引气冲关</param>
	/// <param name="weaponSwitchSpeed">武具发挥</param>
	/// <param name="attackSpeed">攻击速度</param>
	/// <param name="innerRatio">内功发挥</param>
	/// <param name="recoveryOfQiDisorder">调息吐纳</param>
	/// <param name="poisonResists">毒素抵抗</param>
	/// <param name="assetFileName">资源包名称 - Asset文件名</param>
	/// <param name="prepareAnimation">准备动画</param>
	/// <param name="castAnimation">施展动画</param>
	/// <param name="castParticle">施展特效</param>
	/// <param name="castPetAnimation">施展附属动画 - 仅在施展时显示的附属骨骼和特效</param>
	/// <param name="castPetParticle">施展附属特效</param>
	/// <param name="distanceWhenFourStepAnimation">开始施展和4段功法动画播放时双方的距离 - 开始施展时攻击者移动，后4段动画受击者移动</param>
	/// <param name="castSoundEffect">施展音效</param>
	/// <param name="playerCastBossSkillPrepareAni">玩家施展boss功法准备动画 - 玩家施展boss功法时的表现效果</param>
	/// <param name="playerCastBossSkillAni">玩家施展boss功法施展动画</param>
	/// <param name="playerCastBossSkillParticle">玩家施展boss功法施展特效</param>
	/// <param name="playerCastBossSkillSound">玩家施展boss功法施展音效</param>
	/// <param name="playerCastBossSkillDistance">玩家施展boss功法表现距离</param>
	/// <param name="prepareTotalProgress">准备（读条）总进度值 - 每帧增加60+40*人物施展速度</param>
	/// <param name="needBodyPartTypes">施展需要的身体部位列表 - 0-头|1-胸|2-腹|3-双手|4-单手|5-双腿|6-单腿，3和4、5和6不可同时配置</param>
	/// <param name="mobilityCost">消耗脚力/身法百分比</param>
	/// <param name="breathStanceTotalCost">气势总消耗% - 根据内功比例分配为提气架势</param>
	/// <param name="baseInnerRatio">初始内功比例 - 提气架势, 内伤外伤, 破体破气等的内外功比例. 取值范围 [0, 100], 0 表示纯外功, 100 表示纯内功.</param>
	/// <param name="innerRatioChangeRange">内功比例变化范围 - 受人物内功发挥属性加成</param>
	/// <param name="penetrate">攻击 - 根据内功发挥分配为破体破气</param>
	/// <param name="distanceAdditionWhenCast">施展时增加的距离</param>
	/// <param name="trickCost">消耗式 - 数据格式：{式类型,个数}。式类型对应Combat/TrickType表中的模板ID</param>
	/// <param name="weaponDurableCost">消耗武器耐久度</param>
	/// <param name="wugCost">消耗蛊引数</param>
	/// <param name="mostFittingWeaponID">最佳武器分组ID - 对应Item/Weapon表中的模板ID, 配置同组的首位武器即可</param>
	/// <param name="fixedBestWeaponID">固定最佳武器 - 对应Item/Weapon表中的模板ID</param>
	/// <param name="injuryPartAtkRateDistribution">攻击部位概率分布 - 对应Combat/BodyPart表中的模板ID</param>
	/// <param name="totalHit">总命中值 - 根据每段成数分布分配到各种命中类型</param>
	/// <param name="perHitDamageRateDistribution">每段命中威力成数分布 - 力道、精妙、迅疾、动心</param>
	/// <param name="hasAtkAcupointEffect">有无点穴效果</param>
	/// <param name="hasAtkFlawEffect">有无破绽效果</param>
	/// <param name="poisons">含有毒素</param>
	/// <param name="equipmentBreakOdds">装备损坏几率</param>
	/// <param name="addWugType">施展后添加蛊类型 - 用于NPC间战斗简易流程</param>
	/// <param name="addBreakBodyFeature">施展后添加伤残特性</param>
	/// <param name="addMoveSpeedOnCast">移动速度加成 - 最终加成值=(GlobalConfig.AgileSkillBaseAddSpeed|AgileSkillBaseAddHit)*配置值/100</param>
	/// <param name="addPercentMoveSpeedOnCast">移动速度百分比加成</param>
	/// <param name="moveCdBonus">移动间隔影响</param>
	/// <param name="addHitOnCast">命中值加成</param>
	/// <param name="mobilityReduceSpeed">身法值每帧减少值 - 每帧减少 MobilityReduceSpeed 后判定移除身法，未移除时增加 MobilityAddSpeed，每次移动消耗 MoveCostMobility</param>
	/// <param name="mobilityAddSpeed">身法值每帧增加值</param>
	/// <param name="moveCostMobility">每次移动消耗身法值</param>
	/// <param name="maxJumpDistance">蓄力移动距离上限 - 蓄力移动相关配置，仅特效激活时生效。后退时蓄力帧数需*1.33。允许部分蓄力时可在未蓄力到上限时移动，但仍以10距离为单位</param>
	/// <param name="jumpPrepareFrame">单位距离蓄力帧数</param>
	/// <param name="canPartlyJump">能否部分蓄力</param>
	/// <param name="jumpAni">蓄力移动动画 - 0-前进、1-后退</param>
	/// <param name="jumpParticle">蓄力移动特效</param>
	/// <param name="jumpChangeDistanceFrame">蓄力移动距离变化延迟帧数</param>
	/// <param name="jumpChangeDistanceDuration">蓄力移动距离变化帧数 - 默认持续到动画结束</param>
	/// <param name="scoreBonusType">分数加成类型 - AI 在选取功法时的分数加成类型. -1: 无加成, -2: 必选, 2: 腿法.</param>
	/// <param name="scoreBonus">分数加成 - AI 在选取功法时的分数加成</param>
	/// <param name="addOuterPenetrateResistOnCast">御体加成 - 最终加成值=(GlobalConfig.DefendSkillBaseAddPenetrateResist)*配置值/100</param>
	/// <param name="addInnerPenetrateResistOnCast">御气加成</param>
	/// <param name="addAvoidOnCast">化解值加成 - 最终加成值=(GlobalConfig.DefendSkillBaseAddAvoid)*配置值/100</param>
	/// <param name="fightBackDamage">反击威力</param>
	/// <param name="bounceRateOfOuterInjury">外伤反震威力</param>
	/// <param name="bounceRateOfInnerInjury">内伤反震威力</param>
	/// <param name="continuousFrames">持续帧数</param>
	/// <param name="bounceDistance">反震距离</param>
	/// <param name="defendAnimation">护体动画 - 护体功法生效期间持续播放</param>
	/// <param name="defendParticle">护体特效</param>
	/// <param name="defendSound">护体音效</param>
	/// <param name="fightBackAnimation">反击动画</param>
	/// <param name="fightBackParticle">反击特效</param>
	/// <param name="fightBackSound">反击音效</param>
	/// <param name="propertyAddList">运功属性加成 - 目前仅用于奇窍功法</param>
	/// <param name="outerDamageSteps">全部位外伤阈值</param>
	/// <param name="innerDamageSteps">全部位内伤阈值</param>
	/// <param name="fatalDamageStep">重创</param>
	/// <param name="mindDamageStep">心神</param>
	/// <param name="possibleQiArtStrategyList">提供的周天策略</param>
	/// <param name="extraNeiliAllocationProgress">获取真气进度 - 每次周天结束，获取多少真气的增加进度，增加进度达到100时，对应真气额外+1，最多50真气，做为额外的真气，不影响内力的加点</param>
	/// <param name="loopBonusSkillList">对周天有加成的内功 - 当列表中的内功是辅助内功时，对当前内功周天有加成</param>
	/// <param name="qiArtStrategyGenerateProbability">天人感应的概率</param>
	/// <param name="invalidBreakBonusTypes">无效的玄机格类型 - 主要用于补充无法通过功法装配类型排除的玄机格类型</param>
	/// <param name="videoName">功法视频名字 - 用于门派功法界面播放视频</param>
	public CombatSkillItem(short templateId, string name, sbyte grade, string desc, string icon, sbyte equipType, sbyte type, ECombatSkillSubType subType, sbyte gridCost, sbyte sectId, sbyte fiveElements, short bookId, bool canObtainByAdventure, bool isNonPublic, sbyte orderIdInSect, List<PropertyAndValue> usingRequirement, int directEffectID, int reverseEffectID, byte inheritAttainmentAdiitionRate, sbyte practiceType, sbyte skillBreakPlateId, string breakStart, string breakEnd, bool goneMadInnerInjury, List<sbyte> goneMadInjuredPart, sbyte goneMadInjuryValue, short goneMadQiDisorder, short totalObtainableNeili, short obtainedNeiliPerLoop, sbyte destTypeWhileLooping, sbyte transferTypeWhileLooping, sbyte fiveElementChangePerLoop, sbyte[] specificGrids, sbyte genericGrid, HitOrAvoidShorts hitValues, HitOrAvoidShorts avoidValues, OuterAndInnerShorts penetrations, OuterAndInnerShorts penetrationResists, OuterAndInnerShorts recoveryOfStanceAndBreath, short moveSpeed, short recoveryOfFlaw, short castSpeed, short recoveryOfBlockedAcupoint, short weaponSwitchSpeed, short attackSpeed, short innerRatio, short recoveryOfQiDisorder, PoisonShorts poisonResists, string assetFileName, string prepareAnimation, string castAnimation, string castParticle, string castPetAnimation, string castPetParticle, short[] distanceWhenFourStepAnimation, string castSoundEffect, string playerCastBossSkillPrepareAni, string playerCastBossSkillAni, string playerCastBossSkillParticle, string playerCastBossSkillSound, short[] playerCastBossSkillDistance, int prepareTotalProgress, List<sbyte> needBodyPartTypes, short mobilityCost, sbyte breathStanceTotalCost, sbyte baseInnerRatio, sbyte innerRatioChangeRange, short penetrate, short distanceAdditionWhenCast, List<NeedTrick> trickCost, sbyte weaponDurableCost, sbyte wugCost, short mostFittingWeaponID, short fixedBestWeaponID, sbyte[] injuryPartAtkRateDistribution, short totalHit, sbyte[] perHitDamageRateDistribution, bool hasAtkAcupointEffect, bool hasAtkFlawEffect, PoisonsAndLevels poisons, sbyte equipmentBreakOdds, sbyte addWugType, short[] addBreakBodyFeature, short addMoveSpeedOnCast, short addPercentMoveSpeedOnCast, short moveCdBonus, short[] addHitOnCast, int mobilityReduceSpeed, int mobilityAddSpeed, int moveCostMobility, sbyte maxJumpDistance, int jumpPrepareFrame, bool canPartlyJump, string[] jumpAni, string[] jumpParticle, short jumpChangeDistanceFrame, short jumpChangeDistanceDuration, sbyte scoreBonusType, short scoreBonus, short addOuterPenetrateResistOnCast, short addInnerPenetrateResistOnCast, short[] addAvoidOnCast, short fightBackDamage, short bounceRateOfOuterInjury, short bounceRateOfInnerInjury, short continuousFrames, short bounceDistance, string defendAnimation, string defendParticle, string defendSound, string fightBackAnimation, string fightBackParticle, string fightBackSound, List<PropertyAndValue> propertyAddList, int[] outerDamageSteps, int[] innerDamageSteps, int fatalDamageStep, int mindDamageStep, List<sbyte> possibleQiArtStrategyList, sbyte[] extraNeiliAllocationProgress, List<short> loopBonusSkillList, sbyte qiArtStrategyGenerateProbability, List<sbyte> invalidBreakBonusTypes, string videoName)
	{
		TemplateId = templateId;
		Name = name;
		Grade = grade;
		Desc = desc;
		Icon = icon;
		EquipType = equipType;
		Type = type;
		SubType = subType;
		GridCost = gridCost;
		SectId = sectId;
		FiveElements = fiveElements;
		BookId = bookId;
		CanObtainByAdventure = canObtainByAdventure;
		IsNonPublic = isNonPublic;
		OrderIdInSect = orderIdInSect;
		UsingRequirement = usingRequirement;
		DirectEffectID = directEffectID;
		ReverseEffectID = reverseEffectID;
		InheritAttainmentAdiitionRate = inheritAttainmentAdiitionRate;
		PracticeType = practiceType;
		SkillBreakPlateId = skillBreakPlateId;
		BreakStart = breakStart;
		BreakEnd = breakEnd;
		GoneMadInnerInjury = goneMadInnerInjury;
		GoneMadInjuredPart = goneMadInjuredPart;
		GoneMadInjuryValue = goneMadInjuryValue;
		GoneMadQiDisorder = goneMadQiDisorder;
		TotalObtainableNeili = totalObtainableNeili;
		ObtainedNeiliPerLoop = obtainedNeiliPerLoop;
		DestTypeWhileLooping = destTypeWhileLooping;
		TransferTypeWhileLooping = transferTypeWhileLooping;
		FiveElementChangePerLoop = fiveElementChangePerLoop;
		SpecificGrids = specificGrids;
		GenericGrid = genericGrid;
		HitValues = hitValues;
		AvoidValues = avoidValues;
		Penetrations = penetrations;
		PenetrationResists = penetrationResists;
		RecoveryOfStanceAndBreath = recoveryOfStanceAndBreath;
		MoveSpeed = moveSpeed;
		RecoveryOfFlaw = recoveryOfFlaw;
		CastSpeed = castSpeed;
		RecoveryOfBlockedAcupoint = recoveryOfBlockedAcupoint;
		WeaponSwitchSpeed = weaponSwitchSpeed;
		AttackSpeed = attackSpeed;
		InnerRatio = innerRatio;
		RecoveryOfQiDisorder = recoveryOfQiDisorder;
		PoisonResists = poisonResists;
		AssetFileName = assetFileName;
		PrepareAnimation = prepareAnimation;
		CastAnimation = castAnimation;
		CastParticle = castParticle;
		CastPetAnimation = castPetAnimation;
		CastPetParticle = castPetParticle;
		DistanceWhenFourStepAnimation = distanceWhenFourStepAnimation;
		CastSoundEffect = castSoundEffect;
		PlayerCastBossSkillPrepareAni = playerCastBossSkillPrepareAni;
		PlayerCastBossSkillAni = playerCastBossSkillAni;
		PlayerCastBossSkillParticle = playerCastBossSkillParticle;
		PlayerCastBossSkillSound = playerCastBossSkillSound;
		PlayerCastBossSkillDistance = playerCastBossSkillDistance;
		PrepareTotalProgress = prepareTotalProgress;
		NeedBodyPartTypes = needBodyPartTypes;
		MobilityCost = mobilityCost;
		BreathStanceTotalCost = breathStanceTotalCost;
		BaseInnerRatio = baseInnerRatio;
		InnerRatioChangeRange = innerRatioChangeRange;
		Penetrate = penetrate;
		DistanceAdditionWhenCast = distanceAdditionWhenCast;
		TrickCost = trickCost;
		WeaponDurableCost = weaponDurableCost;
		WugCost = wugCost;
		MostFittingWeaponID = mostFittingWeaponID;
		FixedBestWeaponID = fixedBestWeaponID;
		InjuryPartAtkRateDistribution = injuryPartAtkRateDistribution;
		TotalHit = totalHit;
		PerHitDamageRateDistribution = perHitDamageRateDistribution;
		HasAtkAcupointEffect = hasAtkAcupointEffect;
		HasAtkFlawEffect = hasAtkFlawEffect;
		Poisons = poisons;
		EquipmentBreakOdds = equipmentBreakOdds;
		AddWugType = addWugType;
		AddBreakBodyFeature = addBreakBodyFeature;
		AddMoveSpeedOnCast = addMoveSpeedOnCast;
		AddPercentMoveSpeedOnCast = addPercentMoveSpeedOnCast;
		MoveCdBonus = moveCdBonus;
		AddHitOnCast = addHitOnCast;
		MobilityReduceSpeed = mobilityReduceSpeed;
		MobilityAddSpeed = mobilityAddSpeed;
		MoveCostMobility = moveCostMobility;
		MaxJumpDistance = maxJumpDistance;
		JumpPrepareFrame = jumpPrepareFrame;
		CanPartlyJump = canPartlyJump;
		JumpAni = jumpAni;
		JumpParticle = jumpParticle;
		JumpChangeDistanceFrame = jumpChangeDistanceFrame;
		JumpChangeDistanceDuration = jumpChangeDistanceDuration;
		ScoreBonusType = scoreBonusType;
		ScoreBonus = scoreBonus;
		AddOuterPenetrateResistOnCast = addOuterPenetrateResistOnCast;
		AddInnerPenetrateResistOnCast = addInnerPenetrateResistOnCast;
		AddAvoidOnCast = addAvoidOnCast;
		FightBackDamage = fightBackDamage;
		BounceRateOfOuterInjury = bounceRateOfOuterInjury;
		BounceRateOfInnerInjury = bounceRateOfInnerInjury;
		ContinuousFrames = continuousFrames;
		BounceDistance = bounceDistance;
		DefendAnimation = defendAnimation;
		DefendParticle = defendParticle;
		DefendSound = defendSound;
		FightBackAnimation = fightBackAnimation;
		FightBackParticle = fightBackParticle;
		FightBackSound = fightBackSound;
		PropertyAddList = propertyAddList;
		OuterDamageSteps = outerDamageSteps;
		InnerDamageSteps = innerDamageSteps;
		FatalDamageStep = fatalDamageStep;
		MindDamageStep = mindDamageStep;
		PossibleQiArtStrategyList = possibleQiArtStrategyList;
		ExtraNeiliAllocationProgress = extraNeiliAllocationProgress;
		LoopBonusSkillList = loopBonusSkillList;
		QiArtStrategyGenerateProbability = qiArtStrategyGenerateProbability;
		InvalidBreakBonusTypes = invalidBreakBonusTypes;
		VideoName = videoName;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public CombatSkillItem()
	{
		TemplateId = 0;
		Name = null;
		Grade = 0;
		Desc = null;
		Icon = null;
		EquipType = -1;
		Type = 0;
		SubType = ECombatSkillSubType.Invalid;
		GridCost = 0;
		SectId = 0;
		FiveElements = 5;
		BookId = 0;
		CanObtainByAdventure = true;
		IsNonPublic = false;
		OrderIdInSect = -1;
		UsingRequirement = new List<PropertyAndValue>();
		DirectEffectID = 0;
		ReverseEffectID = 0;
		InheritAttainmentAdiitionRate = 0;
		PracticeType = -1;
		SkillBreakPlateId = 0;
		BreakStart = null;
		BreakEnd = null;
		GoneMadInnerInjury = false;
		GoneMadInjuredPart = new List<sbyte>();
		GoneMadInjuryValue = 0;
		GoneMadQiDisorder = 0;
		TotalObtainableNeili = 0;
		ObtainedNeiliPerLoop = 0;
		DestTypeWhileLooping = -1;
		TransferTypeWhileLooping = -1;
		FiveElementChangePerLoop = 0;
		SpecificGrids = new sbyte[4];
		GenericGrid = 0;
		HitValues = new HitOrAvoidShorts(default(short), default(short), default(short), default(short));
		AvoidValues = new HitOrAvoidShorts(default(short), default(short), default(short), default(short));
		Penetrations = new OuterAndInnerShorts(0, 0);
		PenetrationResists = new OuterAndInnerShorts(0, 0);
		RecoveryOfStanceAndBreath = new OuterAndInnerShorts(0, 0);
		MoveSpeed = 0;
		RecoveryOfFlaw = 0;
		CastSpeed = 0;
		RecoveryOfBlockedAcupoint = 0;
		WeaponSwitchSpeed = 0;
		AttackSpeed = 0;
		InnerRatio = 0;
		RecoveryOfQiDisorder = 0;
		PoisonResists = new PoisonShorts(default(int), default(int), default(int), default(int), default(int), default(int));
		AssetFileName = null;
		PrepareAnimation = null;
		CastAnimation = null;
		CastParticle = null;
		CastPetAnimation = null;
		CastPetParticle = null;
		DistanceWhenFourStepAnimation = new short[5];
		CastSoundEffect = null;
		PlayerCastBossSkillPrepareAni = null;
		PlayerCastBossSkillAni = null;
		PlayerCastBossSkillParticle = null;
		PlayerCastBossSkillSound = null;
		PlayerCastBossSkillDistance = null;
		PrepareTotalProgress = 0;
		NeedBodyPartTypes = new List<sbyte>();
		MobilityCost = 0;
		BreathStanceTotalCost = 0;
		BaseInnerRatio = 0;
		InnerRatioChangeRange = 20;
		Penetrate = 0;
		DistanceAdditionWhenCast = 0;
		TrickCost = new List<NeedTrick>();
		WeaponDurableCost = 0;
		WugCost = 0;
		MostFittingWeaponID = 0;
		FixedBestWeaponID = 0;
		InjuryPartAtkRateDistribution = new sbyte[7] { 20, 20, 1, 20, 20, 20, 20 };
		TotalHit = 0;
		PerHitDamageRateDistribution = new sbyte[4];
		HasAtkAcupointEffect = false;
		HasAtkFlawEffect = false;
		Poisons = new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short));
		EquipmentBreakOdds = 0;
		AddWugType = -1;
		AddBreakBodyFeature = null;
		AddMoveSpeedOnCast = 0;
		AddPercentMoveSpeedOnCast = 0;
		MoveCdBonus = 0;
		AddHitOnCast = new short[4];
		MobilityReduceSpeed = 36;
		MobilityAddSpeed = 0;
		MoveCostMobility = 36;
		MaxJumpDistance = -1;
		JumpPrepareFrame = -1;
		CanPartlyJump = false;
		JumpAni = null;
		JumpParticle = null;
		JumpChangeDistanceFrame = -1;
		JumpChangeDistanceDuration = -1;
		ScoreBonusType = -1;
		ScoreBonus = 0;
		AddOuterPenetrateResistOnCast = 0;
		AddInnerPenetrateResistOnCast = 0;
		AddAvoidOnCast = new short[4];
		FightBackDamage = 0;
		BounceRateOfOuterInjury = 0;
		BounceRateOfInnerInjury = 0;
		ContinuousFrames = 0;
		BounceDistance = 0;
		DefendAnimation = null;
		DefendParticle = null;
		DefendSound = null;
		FightBackAnimation = null;
		FightBackParticle = null;
		FightBackSound = null;
		PropertyAddList = new List<PropertyAndValue>();
		OuterDamageSteps = new int[7];
		InnerDamageSteps = new int[7];
		FatalDamageStep = 0;
		MindDamageStep = 0;
		PossibleQiArtStrategyList = new List<sbyte>();
		ExtraNeiliAllocationProgress = new sbyte[5];
		LoopBonusSkillList = new List<short>();
		QiArtStrategyGenerateProbability = 0;
		InvalidBreakBonusTypes = new List<sbyte>();
		VideoName = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public CombatSkillItem(short templateId, CombatSkillItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Grade = other.Grade;
		Desc = other.Desc;
		Icon = other.Icon;
		EquipType = other.EquipType;
		Type = other.Type;
		SubType = other.SubType;
		GridCost = other.GridCost;
		SectId = other.SectId;
		FiveElements = other.FiveElements;
		BookId = other.BookId;
		CanObtainByAdventure = other.CanObtainByAdventure;
		IsNonPublic = other.IsNonPublic;
		OrderIdInSect = other.OrderIdInSect;
		UsingRequirement = other.UsingRequirement;
		DirectEffectID = other.DirectEffectID;
		ReverseEffectID = other.ReverseEffectID;
		InheritAttainmentAdiitionRate = other.InheritAttainmentAdiitionRate;
		PracticeType = other.PracticeType;
		SkillBreakPlateId = other.SkillBreakPlateId;
		BreakStart = other.BreakStart;
		BreakEnd = other.BreakEnd;
		GoneMadInnerInjury = other.GoneMadInnerInjury;
		GoneMadInjuredPart = other.GoneMadInjuredPart;
		GoneMadInjuryValue = other.GoneMadInjuryValue;
		GoneMadQiDisorder = other.GoneMadQiDisorder;
		TotalObtainableNeili = other.TotalObtainableNeili;
		ObtainedNeiliPerLoop = other.ObtainedNeiliPerLoop;
		DestTypeWhileLooping = other.DestTypeWhileLooping;
		TransferTypeWhileLooping = other.TransferTypeWhileLooping;
		FiveElementChangePerLoop = other.FiveElementChangePerLoop;
		SpecificGrids = other.SpecificGrids;
		GenericGrid = other.GenericGrid;
		HitValues = other.HitValues;
		AvoidValues = other.AvoidValues;
		Penetrations = other.Penetrations;
		PenetrationResists = other.PenetrationResists;
		RecoveryOfStanceAndBreath = other.RecoveryOfStanceAndBreath;
		MoveSpeed = other.MoveSpeed;
		RecoveryOfFlaw = other.RecoveryOfFlaw;
		CastSpeed = other.CastSpeed;
		RecoveryOfBlockedAcupoint = other.RecoveryOfBlockedAcupoint;
		WeaponSwitchSpeed = other.WeaponSwitchSpeed;
		AttackSpeed = other.AttackSpeed;
		InnerRatio = other.InnerRatio;
		RecoveryOfQiDisorder = other.RecoveryOfQiDisorder;
		PoisonResists = other.PoisonResists;
		AssetFileName = other.AssetFileName;
		PrepareAnimation = other.PrepareAnimation;
		CastAnimation = other.CastAnimation;
		CastParticle = other.CastParticle;
		CastPetAnimation = other.CastPetAnimation;
		CastPetParticle = other.CastPetParticle;
		DistanceWhenFourStepAnimation = other.DistanceWhenFourStepAnimation;
		CastSoundEffect = other.CastSoundEffect;
		PlayerCastBossSkillPrepareAni = other.PlayerCastBossSkillPrepareAni;
		PlayerCastBossSkillAni = other.PlayerCastBossSkillAni;
		PlayerCastBossSkillParticle = other.PlayerCastBossSkillParticle;
		PlayerCastBossSkillSound = other.PlayerCastBossSkillSound;
		PlayerCastBossSkillDistance = other.PlayerCastBossSkillDistance;
		PrepareTotalProgress = other.PrepareTotalProgress;
		NeedBodyPartTypes = other.NeedBodyPartTypes;
		MobilityCost = other.MobilityCost;
		BreathStanceTotalCost = other.BreathStanceTotalCost;
		BaseInnerRatio = other.BaseInnerRatio;
		InnerRatioChangeRange = other.InnerRatioChangeRange;
		Penetrate = other.Penetrate;
		DistanceAdditionWhenCast = other.DistanceAdditionWhenCast;
		TrickCost = other.TrickCost;
		WeaponDurableCost = other.WeaponDurableCost;
		WugCost = other.WugCost;
		MostFittingWeaponID = other.MostFittingWeaponID;
		FixedBestWeaponID = other.FixedBestWeaponID;
		InjuryPartAtkRateDistribution = other.InjuryPartAtkRateDistribution;
		TotalHit = other.TotalHit;
		PerHitDamageRateDistribution = other.PerHitDamageRateDistribution;
		HasAtkAcupointEffect = other.HasAtkAcupointEffect;
		HasAtkFlawEffect = other.HasAtkFlawEffect;
		Poisons = other.Poisons;
		EquipmentBreakOdds = other.EquipmentBreakOdds;
		AddWugType = other.AddWugType;
		AddBreakBodyFeature = other.AddBreakBodyFeature;
		AddMoveSpeedOnCast = other.AddMoveSpeedOnCast;
		AddPercentMoveSpeedOnCast = other.AddPercentMoveSpeedOnCast;
		MoveCdBonus = other.MoveCdBonus;
		AddHitOnCast = other.AddHitOnCast;
		MobilityReduceSpeed = other.MobilityReduceSpeed;
		MobilityAddSpeed = other.MobilityAddSpeed;
		MoveCostMobility = other.MoveCostMobility;
		MaxJumpDistance = other.MaxJumpDistance;
		JumpPrepareFrame = other.JumpPrepareFrame;
		CanPartlyJump = other.CanPartlyJump;
		JumpAni = other.JumpAni;
		JumpParticle = other.JumpParticle;
		JumpChangeDistanceFrame = other.JumpChangeDistanceFrame;
		JumpChangeDistanceDuration = other.JumpChangeDistanceDuration;
		ScoreBonusType = other.ScoreBonusType;
		ScoreBonus = other.ScoreBonus;
		AddOuterPenetrateResistOnCast = other.AddOuterPenetrateResistOnCast;
		AddInnerPenetrateResistOnCast = other.AddInnerPenetrateResistOnCast;
		AddAvoidOnCast = other.AddAvoidOnCast;
		FightBackDamage = other.FightBackDamage;
		BounceRateOfOuterInjury = other.BounceRateOfOuterInjury;
		BounceRateOfInnerInjury = other.BounceRateOfInnerInjury;
		ContinuousFrames = other.ContinuousFrames;
		BounceDistance = other.BounceDistance;
		DefendAnimation = other.DefendAnimation;
		DefendParticle = other.DefendParticle;
		DefendSound = other.DefendSound;
		FightBackAnimation = other.FightBackAnimation;
		FightBackParticle = other.FightBackParticle;
		FightBackSound = other.FightBackSound;
		PropertyAddList = other.PropertyAddList;
		OuterDamageSteps = other.OuterDamageSteps;
		InnerDamageSteps = other.InnerDamageSteps;
		FatalDamageStep = other.FatalDamageStep;
		MindDamageStep = other.MindDamageStep;
		PossibleQiArtStrategyList = other.PossibleQiArtStrategyList;
		ExtraNeiliAllocationProgress = other.ExtraNeiliAllocationProgress;
		LoopBonusSkillList = other.LoopBonusSkillList;
		QiArtStrategyGenerateProbability = other.QiArtStrategyGenerateProbability;
		InvalidBreakBonusTypes = other.InvalidBreakBonusTypes;
		VideoName = other.VideoName;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override CombatSkillItem Duplicate(int templateId)
	{
		return new CombatSkillItem((short)templateId, this);
	}

	/// <summary>
	/// 该功法是否可以使用指定玄机效果
	/// </summary>
	/// <param name="effect"></param>
	/// <returns></returns>
	public bool MatchBreakPlateBonusEffect(SkillBreakBonusEffectItem effect)
	{
		if (effect != null && effect.GetImplementId(EquipType) >= 0)
		{
			return !InvalidBreakBonusTypes.Contains(effect.TemplateId);
		}
		return false;
	}
}

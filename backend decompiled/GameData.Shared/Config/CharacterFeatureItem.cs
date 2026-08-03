using System;
using System.Collections.Generic;
using Config.Common;
using Config.ConfigCells.Character;

namespace Config;

[Serializable]
public class CharacterFeatureItem : ConfigItem<CharacterFeatureItem, short>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 小村名称
	/// - 小村剧情中的名字（为了不显示相枢）
	/// </summary>
	public readonly string SmallVillageName;

	/// <summary>
	/// 隐藏
	/// - 是否在角色的特性界面中隐藏
	/// </summary>
	public readonly bool Hidden;

	/// <summary>
	/// 奇遇特性
	/// - 奇遇专用特性，此类特性在奇遇中过月不会缩短持续时间
	/// </summary>
	public readonly bool BelongAdventure;

	/// <summary>
	/// 类型
	/// - 0.特殊特性（特殊），1.普通正面特性（通常），2.普通负面特性（通常），3.临时特性（临时）；影响特性在人物界面显示时的标签和类型判断
	/// </summary>
	public readonly ECharacterFeatureType Type;

	/// <summary>
	/// 说明
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 小村说明
	/// - 小村剧情中的说明（为了不显示相枢）
	/// </summary>
	public readonly string SmallVillageDesc;

	/// <summary>
	/// 功能说明
	/// - 存在特殊效果的特性的功能说明
	/// </summary>
	public readonly string EffectDesc;

	/// <summary>
	/// 攻防智星级
	/// - 此字段自动生成, 实际配置字段为 "攻击", "防御", "机略".pos+蓝，neg+红，inc白，dec灰
	/// </summary>
	public readonly FeatureMedals[] FeatureMedals;

	/// <summary>
	/// 级别
	/// - 特性的正逆等级. 取值范围 [-3, 3]. 角色添加或移除正逆不为0的特性时将重新生成同道指令.
	/// </summary>
	public readonly sbyte Level;

	/// <summary>
	/// 入魔性质
	/// - 目前主要用于部分特效判定入魔人
	/// </summary>
	public readonly ECharacterFeatureInfectedType InfectedType;

	/// <summary>
	/// 无视健康
	/// - 有此特性的人物，无视健康带来的影响，如战斗中的健康标记，健康状态的判断条件等，均视为100%满健康
	/// </summary>
	public readonly bool IgnoreHealthMark;

	/// <summary>
	/// 守卫特性效果
	/// - 进入战斗后会激活一系列特殊效果
	/// </summary>
	public readonly bool IsTreasuryGuard;

	/// <summary>
	/// 可名门修改
	/// </summary>
	public readonly bool CanBeModified;

	/// <summary>
	/// 可改命交换
	/// </summary>
	public readonly bool CanBeExchanged;

	/// <summary>
	/// 可合并遗传
	/// - 可根据正逆等级合并遗传. 对于可合并遗传特性, 等级排列必须是 1, 2, 3, -1, -2, -3.
	/// </summary>
	public readonly bool Mergeable;

	/// <summary>
	/// 基础特性
	/// - 每个人的基础特性有个数限制
	/// </summary>
	public readonly bool Basic;

	/// <summary>
	/// 可铭刻
	/// </summary>
	public readonly bool Inscribable;

	/// <summary>
	/// 来自灵魂
	/// - 能否被金刚特殊互动继承，来自灵魂方
	/// </summary>
	public readonly bool SoulTransform;

	/// <summary>
	/// 来自肉体
	/// - 能否被金刚特殊互动继承，来自肉体方
	/// </summary>
	public readonly bool BodyTransform;

	/// <summary>
	/// 可删除
	/// - 控制太吾能否主动删除此特性
	/// </summary>
	public readonly bool CanDeleteManually;

	/// <summary>
	/// 可梦回
	/// - 梦回后会保留
	/// </summary>
	public readonly bool CanCrossArchive;

	/// <summary>
	/// 可轮回继承
	/// - 轮回后会有一定规则继承到新的人物身上
	/// </summary>
	public readonly bool InheritableThroughSamsara;

	/// <summary>
	/// 太吾传剑可继承
	/// - 目前仅会在地主中出现在太吾身上，太吾传剑后仍存在
	/// </summary>
	public readonly bool InheritableTransferTaiwu;

	/// <summary>
	/// 死人保持此特性
	/// - 设置为0的特性会在人物死亡后删除，但不触发移除特性的逻辑
	/// </summary>
	public readonly bool CanRecordWhenDead;

	/// <summary>
	/// 阻止玄灰发展
	/// - 这里是阻止玄灰发展的原因，不为Invalid时可以阻止玄灰发展
	/// </summary>
	public readonly ECharacterFeatureDarkAshProtector DarkAshProtector;

	/// <summary>
	/// 绑定组织
	/// - 当角色组织不再符合需求时, 自动移除特性.
	/// </summary>
	public readonly sbyte RequiredOrganization;

	/// <summary>
	/// 互斥组
	/// - 有了此组中任意一个特性后, 角色就不能拥有此组中的其他特性. 互斥组 ID 固定为组内第一个特性的 ID.
	/// </summary>
	public readonly short MutexGroupId;

	/// <summary>
	/// 显示优先级
	/// - 用于显示时的排序, 数字越小越靠前.
	/// </summary>
	public readonly short DisplayPriority;

	/// <summary>
	/// 出现几率
	/// - 在一般人身上该特性出现的机率权重值
	/// </summary>
	public readonly sbyte AppearProb;

	/// <summary>
	/// 持续时间
	/// - 该特性持续存在的月份数，0表示永久存在
	/// </summary>
	public readonly sbyte Duration;

	/// <summary>
	/// 性别
	/// - 0: 女, 1: 男, -1: 未知/不限制.
	/// </summary>
	public readonly sbyte Gender;

	/// <summary>
	/// 候选组
	/// - 出生时的随机特性候选组. 0: 正面基础特性, 1: 负面基础特性.
	/// </summary>
	public readonly sbyte CandidateGroupId;

	/// <summary>
	/// 主角的出现几率
	/// - 在主角身上该特性出现的机率权重值. 只作用于基础特性, 其他特性权重和普通人一样.
	/// </summary>
	public readonly sbyte ProtagonistAppearProb;

	/// <summary>
	/// 遗传几率
	/// </summary>
	public readonly sbyte GeneticProb;

	/// <summary>
	/// 根据精纯增加主属性加值
	/// </summary>
	public readonly bool MakeConsummateLevelRelated;

	/// <summary>
	/// 失去精纯加成
	/// - 特性存续期间，是否失去精纯加成（不含对最大真气的影响）
	/// </summary>
	public readonly bool LoseConsummateBonus;

	/// <summary>
	/// 是否是鸡特性
	/// </summary>
	public readonly bool IsChickenFeature;

	/// <summary>
	/// 特效类
	/// - 特性关联的特效类
	/// </summary>
	public readonly string AssociatedSpecialEffect;

	/// <summary>
	/// 功法威力加成
	/// - 此字段自动生成, 实际配置字段为从 "内功" 到 "奇窍" 的 5 个字段.
	/// </summary>
	public readonly short[] CombatSkillPowerBonuses;

	/// <summary>
	/// 五行威力加成
	/// - 此字段自动生成, 实际配置字段为从 "金刚" 到 "归元" 的 5 个字段。百分比加成，B类
	/// </summary>
	public readonly sbyte[] FiveElementPowerBonuses;

	public readonly List<FeatureAddSkillPower> CombatSkillTypePowerBonuses;

	/// <summary>
	/// 功法栏位加成
	/// - 此字段自动生成, 实际配置字段为从 "内功" 到 "奇窍" 的 5 个字段.
	/// </summary>
	public readonly sbyte[] CombatSkillSlotBonuses;

	/// <summary>
	/// 冷静
	/// </summary>
	public readonly sbyte PersonalityCalm;

	/// <summary>
	/// 聪颖
	/// </summary>
	public readonly sbyte PersonalityClever;

	/// <summary>
	/// 热情
	/// </summary>
	public readonly sbyte PersonalityEnthusiastic;

	/// <summary>
	/// 勇壮
	/// </summary>
	public readonly sbyte PersonalityBrave;

	/// <summary>
	/// 坚毅
	/// </summary>
	public readonly sbyte PersonalityFirm;

	/// <summary>
	/// 福缘
	/// </summary>
	public readonly sbyte PersonalityLucky;

	/// <summary>
	/// 合道
	/// </summary>
	public readonly sbyte PersonalityPerceptive;

	/// <summary>
	/// 膂力
	/// </summary>
	public readonly short Strength;

	/// <summary>
	/// 体质
	/// </summary>
	public readonly short Vitality;

	/// <summary>
	/// 灵敏
	/// </summary>
	public readonly short Dexterity;

	/// <summary>
	/// 根骨
	/// </summary>
	public readonly short Energy;

	/// <summary>
	/// 悟性
	/// </summary>
	public readonly short Intelligence;

	/// <summary>
	/// 定力
	/// </summary>
	public readonly short Concentration;

	/// <summary>
	/// 生育
	/// </summary>
	public readonly short Fertility;

	/// <summary>
	/// 喜恶变化周期
	/// </summary>
	public readonly sbyte HobbyChangingPeriod;

	/// <summary>
	/// 魅力
	/// </summary>
	public readonly short Attraction;

	/// <summary>
	/// 力道
	/// </summary>
	public readonly short HitRateStrength;

	/// <summary>
	/// 精妙
	/// </summary>
	public readonly short HitRateTechnique;

	/// <summary>
	/// 迅疾
	/// </summary>
	public readonly short HitRateSpeed;

	/// <summary>
	/// 动心
	/// </summary>
	public readonly short HitRateMind;

	/// <summary>
	/// 破体
	/// </summary>
	public readonly short PenetrateOfOuter;

	/// <summary>
	/// 破气
	/// </summary>
	public readonly short PenetrateOfInner;

	/// <summary>
	/// 卸力
	/// </summary>
	public readonly int AvoidRateStrength;

	/// <summary>
	/// 拆招
	/// </summary>
	public readonly int AvoidRateTechnique;

	/// <summary>
	/// 闪避
	/// </summary>
	public readonly int AvoidRateSpeed;

	/// <summary>
	/// 守心
	/// </summary>
	public readonly int AvoidRateMind;

	/// <summary>
	/// 御体
	/// </summary>
	public readonly int PenetrateResistOfOuter;

	/// <summary>
	/// 御气
	/// </summary>
	public readonly int PenetrateResistOfInner;

	/// <summary>
	/// 架势恢复
	/// </summary>
	public readonly short RecoveryOfStance;

	/// <summary>
	/// 提气恢复
	/// </summary>
	public readonly short RecoveryOfBreath;

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
	/// 攻击速度
	/// </summary>
	public readonly short AttackSpeed;

	/// <summary>
	/// 兵器切换
	/// </summary>
	public readonly short WeaponSwitchSpeed;

	/// <summary>
	/// 内功发挥
	/// </summary>
	public readonly short InnerRatio;

	/// <summary>
	/// 调息吐纳
	/// </summary>
	public readonly short RecoveryOfQiDisorder;

	/// <summary>
	/// 烈毒抵抗
	/// </summary>
	public readonly int ResistOfHotPoison;

	/// <summary>
	/// 郁毒抵抗
	/// </summary>
	public readonly int ResistOfGloomyPoison;

	/// <summary>
	/// 寒毒抵抗
	/// </summary>
	public readonly int ResistOfColdPoison;

	/// <summary>
	/// 赤毒抵抗
	/// </summary>
	public readonly int ResistOfRedPoison;

	/// <summary>
	/// 腐毒抵抗
	/// </summary>
	public readonly int ResistOfRottenPoison;

	/// <summary>
	/// 幻毒抵抗
	/// </summary>
	public readonly int ResistOfIllusoryPoison;

	/// <summary>
	/// 音律
	/// </summary>
	public readonly short QualificationMusic;

	/// <summary>
	/// 弈棋
	/// </summary>
	public readonly short QualificationChess;

	/// <summary>
	/// 诗书
	/// </summary>
	public readonly short QualificationPoem;

	/// <summary>
	/// 绘画
	/// </summary>
	public readonly short QualificationPainting;

	/// <summary>
	/// 术数
	/// </summary>
	public readonly short QualificationMath;

	/// <summary>
	/// 品鉴
	/// </summary>
	public readonly short QualificationAppraisal;

	/// <summary>
	/// 锻造
	/// </summary>
	public readonly short QualificationForging;

	/// <summary>
	/// 制木
	/// </summary>
	public readonly short QualificationWoodworking;

	/// <summary>
	/// 医术
	/// </summary>
	public readonly short QualificationMedicine;

	/// <summary>
	/// 毒术
	/// </summary>
	public readonly short QualificationToxicology;

	/// <summary>
	/// 织锦
	/// </summary>
	public readonly short QualificationWeaving;

	/// <summary>
	/// 巧匠
	/// </summary>
	public readonly short QualificationJade;

	/// <summary>
	/// 道法
	/// </summary>
	public readonly short QualificationTaoism;

	/// <summary>
	/// 佛学
	/// </summary>
	public readonly short QualificationBuddhism;

	/// <summary>
	/// 厨艺
	/// </summary>
	public readonly short QualificationCooking;

	/// <summary>
	/// 杂学
	/// </summary>
	public readonly short QualificationEclectic;

	/// <summary>
	/// 内功
	/// </summary>
	public readonly short QualificationNeigong;

	/// <summary>
	/// 身法
	/// </summary>
	public readonly short QualificationPosing;

	/// <summary>
	/// 绝技
	/// </summary>
	public readonly short QualificationStunt;

	/// <summary>
	/// 拳掌
	/// </summary>
	public readonly short QualificationFistAndPalm;

	/// <summary>
	/// 指法
	/// </summary>
	public readonly short QualificationFinger;

	/// <summary>
	/// 腿法
	/// </summary>
	public readonly short QualificationLeg;

	/// <summary>
	/// 暗器
	/// </summary>
	public readonly short QualificationThrow;

	/// <summary>
	/// 剑法
	/// </summary>
	public readonly short QualificationSword;

	/// <summary>
	/// 刀法
	/// </summary>
	public readonly short QualificationBlade;

	/// <summary>
	/// 长兵
	/// </summary>
	public readonly short QualificationPolearm;

	/// <summary>
	/// 奇门
	/// </summary>
	public readonly short QualificationSpecial;

	/// <summary>
	/// 软兵
	/// </summary>
	public readonly short QualificationWhip;

	/// <summary>
	/// 御射
	/// </summary>
	public readonly short QualificationControllableShot;

	/// <summary>
	/// 乐器
	/// </summary>
	public readonly short QualificationCombatMusic;

	/// <summary>
	/// 封禁时间
	/// - 影响战斗中有此特性的人物被封禁功法、兵器的持续时间，C类百分比作用
	/// </summary>
	public readonly int SilenceFramePercent;

	/// <summary>
	/// 每月入魔值变化
	/// </summary>
	public readonly short XiangshuInfectionChange;

	/// <summary>
	/// 寿命增减百分比
	/// </summary>
	public readonly short MaxHealthPercentBonus;

	/// <summary>
	/// 魅力增减百分比
	/// </summary>
	public readonly short AttractionPercentBonus;

	/// <summary>
	/// 好感增加因子
	/// - 影响好感增加量. 影响方式是好感变化量乘以此百分比.
	/// </summary>
	public readonly short FavorabilityIncrementFactor;

	/// <summary>
	/// 好感减少因子
	/// - 影响好感减少量. 影响方式是好感变化量乘以此百分比.
	/// </summary>
	public readonly short FavorabilityDecrementFactor;

	/// <summary>
	/// 爱慕多人几率因子
	/// </summary>
	public readonly short AdoreMultiplePeopleChanceFactor;

	/// <summary>
	/// 内息紊乱变化值
	/// </summary>
	public readonly short QiDisorderDelta;

	/// <summary>
	/// 健康变化值
	/// - 健康最大值百分比
	/// </summary>
	public readonly int HealthDelta;

	/// <summary>
	/// 战中敌方反噬伤害提高值
	/// - B类
	/// </summary>
	public readonly int InCombatEnemyGoneMadInjuryAddPercent;

	/// <summary>
	/// 战中敌方全毒抗减少值
	/// - A类
	/// </summary>
	public readonly int InCombatEnemyAllPoisonResistReduceValue;

	/// <summary>
	/// 战中己方直接伤害提高值
	/// - B类
	/// </summary>
	public readonly int InCombatMakeDirectDamageAddPercent;

	/// <summary>
	/// 最大真气降低值
	/// - 特性存续期间，真气上限失去多少
	/// </summary>
	public readonly int MaxNeiliAllocationDebuff;

	/// <summary>
	/// 门派名誉影响
	/// - 人物为特性所属门派身份时名誉影响；{}中表示从0~8品阶人物受影响值
	/// </summary>
	public readonly sbyte[] SectFameBonus;

	/// <summary>
	/// 非门派名誉影响
	/// - 人物不为特性所属门派身份时名誉影响；为固定值不随品阶变化
	/// </summary>
	public readonly sbyte NotSectFameBonu;

	/// <summary>
	/// 太吾名誉影响
	/// - 人物为太吾时名誉影响；为固定值不随品阶变化
	/// </summary>
	public readonly sbyte TaiwuFameBonu;

	/// <summary>
	/// 毒效增益
	/// </summary>
	public readonly sbyte AttachPoisonBonus;

	/// <summary>
	/// 解毒增益
	/// </summary>
	public readonly sbyte DetoxPoisonBonus;

	/// <summary>
	/// 治疗外伤增益
	/// </summary>
	public readonly sbyte HealOuterBonus;

	/// <summary>
	/// 治疗内伤增益
	/// </summary>
	public readonly sbyte HealInnerBonus;

	/// <summary>
	/// 紊乱增强
	/// - 紊乱增加时的影响
	/// </summary>
	public readonly short QiDisorderDebuffPercent;

	/// <summary>
	/// 紊乱恢复
	/// - 紊乱恢复时的影响
	/// </summary>
	public readonly short QiDisorderBuffPercent;

	/// <summary>
	/// 恢复健康增益
	/// </summary>
	public readonly int HealthRecovery;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="name">名称</param>
	/// <param name="smallVillageName">小村名称 - 小村剧情中的名字（为了不显示相枢）</param>
	/// <param name="hidden">隐藏 - 是否在角色的特性界面中隐藏</param>
	/// <param name="belongAdventure">奇遇特性 - 奇遇专用特性，此类特性在奇遇中过月不会缩短持续时间</param>
	/// <param name="type">类型 - 0.特殊特性（特殊），1.普通正面特性（通常），2.普通负面特性（通常），3.临时特性（临时）；影响特性在人物界面显示时的标签和类型判断</param>
	/// <param name="desc">说明</param>
	/// <param name="smallVillageDesc">小村说明 - 小村剧情中的说明（为了不显示相枢）</param>
	/// <param name="effectDesc">功能说明 - 存在特殊效果的特性的功能说明</param>
	/// <param name="featureMedals">攻防智星级 - 此字段自动生成, 实际配置字段为 "攻击", "防御", "机略".pos+蓝，neg+红，inc白，dec灰</param>
	/// <param name="level">级别 - 特性的正逆等级. 取值范围 [-3, 3]. 角色添加或移除正逆不为0的特性时将重新生成同道指令.</param>
	/// <param name="infectedType">入魔性质 - 目前主要用于部分特效判定入魔人</param>
	/// <param name="ignoreHealthMark">无视健康 - 有此特性的人物，无视健康带来的影响，如战斗中的健康标记，健康状态的判断条件等，均视为100%满健康</param>
	/// <param name="isTreasuryGuard">守卫特性效果 - 进入战斗后会激活一系列特殊效果</param>
	/// <param name="canBeModified">可名门修改</param>
	/// <param name="canBeExchanged">可改命交换</param>
	/// <param name="mergeable">可合并遗传 - 可根据正逆等级合并遗传. 对于可合并遗传特性, 等级排列必须是 1, 2, 3, -1, -2, -3.</param>
	/// <param name="basic">基础特性 - 每个人的基础特性有个数限制</param>
	/// <param name="inscribable">可铭刻</param>
	/// <param name="soulTransform">来自灵魂 - 能否被金刚特殊互动继承，来自灵魂方</param>
	/// <param name="bodyTransform">来自肉体 - 能否被金刚特殊互动继承，来自肉体方</param>
	/// <param name="canDeleteManually">可删除 - 控制太吾能否主动删除此特性</param>
	/// <param name="canCrossArchive">可梦回 - 梦回后会保留</param>
	/// <param name="inheritableThroughSamsara">可轮回继承 - 轮回后会有一定规则继承到新的人物身上</param>
	/// <param name="inheritableTransferTaiwu">太吾传剑可继承 - 目前仅会在地主中出现在太吾身上，太吾传剑后仍存在</param>
	/// <param name="canRecordWhenDead">死人保持此特性 - 设置为0的特性会在人物死亡后删除，但不触发移除特性的逻辑</param>
	/// <param name="darkAshProtector">阻止玄灰发展 - 这里是阻止玄灰发展的原因，不为Invalid时可以阻止玄灰发展</param>
	/// <param name="requiredOrganization">绑定组织 - 当角色组织不再符合需求时, 自动移除特性.</param>
	/// <param name="mutexGroupId">互斥组 - 有了此组中任意一个特性后, 角色就不能拥有此组中的其他特性. 互斥组 ID 固定为组内第一个特性的 ID.</param>
	/// <param name="displayPriority">显示优先级 - 用于显示时的排序, 数字越小越靠前.</param>
	/// <param name="appearProb">出现几率 - 在一般人身上该特性出现的机率权重值</param>
	/// <param name="duration">持续时间 - 该特性持续存在的月份数，0表示永久存在</param>
	/// <param name="gender">性别 - 0: 女, 1: 男, -1: 未知/不限制.</param>
	/// <param name="candidateGroupId">候选组 - 出生时的随机特性候选组. 0: 正面基础特性, 1: 负面基础特性.</param>
	/// <param name="protagonistAppearProb">主角的出现几率 - 在主角身上该特性出现的机率权重值. 只作用于基础特性, 其他特性权重和普通人一样.</param>
	/// <param name="geneticProb">遗传几率</param>
	/// <param name="makeConsummateLevelRelated">根据精纯增加主属性加值</param>
	/// <param name="loseConsummateBonus">失去精纯加成 - 特性存续期间，是否失去精纯加成（不含对最大真气的影响）</param>
	/// <param name="isChickenFeature">是否是鸡特性</param>
	/// <param name="associatedSpecialEffect">特效类 - 特性关联的特效类</param>
	/// <param name="combatSkillPowerBonuses">功法威力加成 - 此字段自动生成, 实际配置字段为从 "内功" 到 "奇窍" 的 5 个字段.</param>
	/// <param name="fiveElementPowerBonuses">五行威力加成 - 此字段自动生成, 实际配置字段为从 "金刚" 到 "归元" 的 5 个字段。百分比加成，B类</param>
	/// <param name="combatSkillTypePowerBonuses"></param>
	/// <param name="combatSkillSlotBonuses">功法栏位加成 - 此字段自动生成, 实际配置字段为从 "内功" 到 "奇窍" 的 5 个字段.</param>
	/// <param name="personalityCalm">冷静</param>
	/// <param name="personalityClever">聪颖</param>
	/// <param name="personalityEnthusiastic">热情</param>
	/// <param name="personalityBrave">勇壮</param>
	/// <param name="personalityFirm">坚毅</param>
	/// <param name="personalityLucky">福缘</param>
	/// <param name="personalityPerceptive">合道</param>
	/// <param name="strength">膂力</param>
	/// <param name="vitality">体质</param>
	/// <param name="dexterity">灵敏</param>
	/// <param name="energy">根骨</param>
	/// <param name="intelligence">悟性</param>
	/// <param name="concentration">定力</param>
	/// <param name="fertility">生育</param>
	/// <param name="hobbyChangingPeriod">喜恶变化周期</param>
	/// <param name="attraction">魅力</param>
	/// <param name="hitRateStrength">力道</param>
	/// <param name="hitRateTechnique">精妙</param>
	/// <param name="hitRateSpeed">迅疾</param>
	/// <param name="hitRateMind">动心</param>
	/// <param name="penetrateOfOuter">破体</param>
	/// <param name="penetrateOfInner">破气</param>
	/// <param name="avoidRateStrength">卸力</param>
	/// <param name="avoidRateTechnique">拆招</param>
	/// <param name="avoidRateSpeed">闪避</param>
	/// <param name="avoidRateMind">守心</param>
	/// <param name="penetrateResistOfOuter">御体</param>
	/// <param name="penetrateResistOfInner">御气</param>
	/// <param name="recoveryOfStance">架势恢复</param>
	/// <param name="recoveryOfBreath">提气恢复</param>
	/// <param name="moveSpeed">移动速度</param>
	/// <param name="recoveryOfFlaw">步伐稳健</param>
	/// <param name="castSpeed">施展速度</param>
	/// <param name="recoveryOfBlockedAcupoint">引气冲关</param>
	/// <param name="attackSpeed">攻击速度</param>
	/// <param name="weaponSwitchSpeed">兵器切换</param>
	/// <param name="innerRatio">内功发挥</param>
	/// <param name="recoveryOfQiDisorder">调息吐纳</param>
	/// <param name="resistOfHotPoison">烈毒抵抗</param>
	/// <param name="resistOfGloomyPoison">郁毒抵抗</param>
	/// <param name="resistOfColdPoison">寒毒抵抗</param>
	/// <param name="resistOfRedPoison">赤毒抵抗</param>
	/// <param name="resistOfRottenPoison">腐毒抵抗</param>
	/// <param name="resistOfIllusoryPoison">幻毒抵抗</param>
	/// <param name="qualificationMusic">音律</param>
	/// <param name="qualificationChess">弈棋</param>
	/// <param name="qualificationPoem">诗书</param>
	/// <param name="qualificationPainting">绘画</param>
	/// <param name="qualificationMath">术数</param>
	/// <param name="qualificationAppraisal">品鉴</param>
	/// <param name="qualificationForging">锻造</param>
	/// <param name="qualificationWoodworking">制木</param>
	/// <param name="qualificationMedicine">医术</param>
	/// <param name="qualificationToxicology">毒术</param>
	/// <param name="qualificationWeaving">织锦</param>
	/// <param name="qualificationJade">巧匠</param>
	/// <param name="qualificationTaoism">道法</param>
	/// <param name="qualificationBuddhism">佛学</param>
	/// <param name="qualificationCooking">厨艺</param>
	/// <param name="qualificationEclectic">杂学</param>
	/// <param name="qualificationNeigong">内功</param>
	/// <param name="qualificationPosing">身法</param>
	/// <param name="qualificationStunt">绝技</param>
	/// <param name="qualificationFistAndPalm">拳掌</param>
	/// <param name="qualificationFinger">指法</param>
	/// <param name="qualificationLeg">腿法</param>
	/// <param name="qualificationThrow">暗器</param>
	/// <param name="qualificationSword">剑法</param>
	/// <param name="qualificationBlade">刀法</param>
	/// <param name="qualificationPolearm">长兵</param>
	/// <param name="qualificationSpecial">奇门</param>
	/// <param name="qualificationWhip">软兵</param>
	/// <param name="qualificationControllableShot">御射</param>
	/// <param name="qualificationCombatMusic">乐器</param>
	/// <param name="silenceFramePercent">封禁时间 - 影响战斗中有此特性的人物被封禁功法、兵器的持续时间，C类百分比作用</param>
	/// <param name="xiangshuInfectionChange">每月入魔值变化</param>
	/// <param name="maxHealthPercentBonus">寿命增减百分比</param>
	/// <param name="attractionPercentBonus">魅力增减百分比</param>
	/// <param name="favorabilityIncrementFactor">好感增加因子 - 影响好感增加量. 影响方式是好感变化量乘以此百分比.</param>
	/// <param name="favorabilityDecrementFactor">好感减少因子 - 影响好感减少量. 影响方式是好感变化量乘以此百分比.</param>
	/// <param name="adoreMultiplePeopleChanceFactor">爱慕多人几率因子</param>
	/// <param name="qiDisorderDelta">内息紊乱变化值</param>
	/// <param name="healthDelta">健康变化值 - 健康最大值百分比</param>
	/// <param name="inCombatEnemyGoneMadInjuryAddPercent">战中敌方反噬伤害提高值 - B类</param>
	/// <param name="inCombatEnemyAllPoisonResistReduceValue">战中敌方全毒抗减少值 - A类</param>
	/// <param name="inCombatMakeDirectDamageAddPercent">战中己方直接伤害提高值 - B类</param>
	/// <param name="maxNeiliAllocationDebuff">最大真气降低值 - 特性存续期间，真气上限失去多少</param>
	/// <param name="sectFameBonus">门派名誉影响 - 人物为特性所属门派身份时名誉影响；{}中表示从0~8品阶人物受影响值</param>
	/// <param name="notSectFameBonu">非门派名誉影响 - 人物不为特性所属门派身份时名誉影响；为固定值不随品阶变化</param>
	/// <param name="taiwuFameBonu">太吾名誉影响 - 人物为太吾时名誉影响；为固定值不随品阶变化</param>
	/// <param name="attachPoisonBonus">毒效增益</param>
	/// <param name="detoxPoisonBonus">解毒增益</param>
	/// <param name="healOuterBonus">治疗外伤增益</param>
	/// <param name="healInnerBonus">治疗内伤增益</param>
	/// <param name="qiDisorderDebuffPercent">紊乱增强 - 紊乱增加时的影响</param>
	/// <param name="qiDisorderBuffPercent">紊乱恢复 - 紊乱恢复时的影响</param>
	/// <param name="healthRecovery">恢复健康增益</param>
	public CharacterFeatureItem(short templateId, string name, string smallVillageName, bool hidden, bool belongAdventure, ECharacterFeatureType type, string desc, string smallVillageDesc, string effectDesc, FeatureMedals[] featureMedals, sbyte level, ECharacterFeatureInfectedType infectedType, bool ignoreHealthMark, bool isTreasuryGuard, bool canBeModified, bool canBeExchanged, bool mergeable, bool basic, bool inscribable, bool soulTransform, bool bodyTransform, bool canDeleteManually, bool canCrossArchive, bool inheritableThroughSamsara, bool inheritableTransferTaiwu, bool canRecordWhenDead, ECharacterFeatureDarkAshProtector darkAshProtector, sbyte requiredOrganization, short mutexGroupId, short displayPriority, sbyte appearProb, sbyte duration, sbyte gender, sbyte candidateGroupId, sbyte protagonistAppearProb, sbyte geneticProb, bool makeConsummateLevelRelated, bool loseConsummateBonus, bool isChickenFeature, string associatedSpecialEffect, short[] combatSkillPowerBonuses, sbyte[] fiveElementPowerBonuses, List<FeatureAddSkillPower> combatSkillTypePowerBonuses, sbyte[] combatSkillSlotBonuses, sbyte personalityCalm, sbyte personalityClever, sbyte personalityEnthusiastic, sbyte personalityBrave, sbyte personalityFirm, sbyte personalityLucky, sbyte personalityPerceptive, short strength, short vitality, short dexterity, short energy, short intelligence, short concentration, short fertility, sbyte hobbyChangingPeriod, short attraction, short hitRateStrength, short hitRateTechnique, short hitRateSpeed, short hitRateMind, short penetrateOfOuter, short penetrateOfInner, int avoidRateStrength, int avoidRateTechnique, int avoidRateSpeed, int avoidRateMind, int penetrateResistOfOuter, int penetrateResistOfInner, short recoveryOfStance, short recoveryOfBreath, short moveSpeed, short recoveryOfFlaw, short castSpeed, short recoveryOfBlockedAcupoint, short attackSpeed, short weaponSwitchSpeed, short innerRatio, short recoveryOfQiDisorder, int resistOfHotPoison, int resistOfGloomyPoison, int resistOfColdPoison, int resistOfRedPoison, int resistOfRottenPoison, int resistOfIllusoryPoison, short qualificationMusic, short qualificationChess, short qualificationPoem, short qualificationPainting, short qualificationMath, short qualificationAppraisal, short qualificationForging, short qualificationWoodworking, short qualificationMedicine, short qualificationToxicology, short qualificationWeaving, short qualificationJade, short qualificationTaoism, short qualificationBuddhism, short qualificationCooking, short qualificationEclectic, short qualificationNeigong, short qualificationPosing, short qualificationStunt, short qualificationFistAndPalm, short qualificationFinger, short qualificationLeg, short qualificationThrow, short qualificationSword, short qualificationBlade, short qualificationPolearm, short qualificationSpecial, short qualificationWhip, short qualificationControllableShot, short qualificationCombatMusic, int silenceFramePercent, short xiangshuInfectionChange, short maxHealthPercentBonus, short attractionPercentBonus, short favorabilityIncrementFactor, short favorabilityDecrementFactor, short adoreMultiplePeopleChanceFactor, short qiDisorderDelta, int healthDelta, int inCombatEnemyGoneMadInjuryAddPercent, int inCombatEnemyAllPoisonResistReduceValue, int inCombatMakeDirectDamageAddPercent, int maxNeiliAllocationDebuff, sbyte[] sectFameBonus, sbyte notSectFameBonu, sbyte taiwuFameBonu, sbyte attachPoisonBonus, sbyte detoxPoisonBonus, sbyte healOuterBonus, sbyte healInnerBonus, short qiDisorderDebuffPercent, short qiDisorderBuffPercent, int healthRecovery)
	{
		TemplateId = templateId;
		Name = name;
		SmallVillageName = smallVillageName;
		Hidden = hidden;
		BelongAdventure = belongAdventure;
		Type = type;
		Desc = desc;
		SmallVillageDesc = smallVillageDesc;
		EffectDesc = effectDesc;
		FeatureMedals = featureMedals;
		Level = level;
		InfectedType = infectedType;
		IgnoreHealthMark = ignoreHealthMark;
		IsTreasuryGuard = isTreasuryGuard;
		CanBeModified = canBeModified;
		CanBeExchanged = canBeExchanged;
		Mergeable = mergeable;
		Basic = basic;
		Inscribable = inscribable;
		SoulTransform = soulTransform;
		BodyTransform = bodyTransform;
		CanDeleteManually = canDeleteManually;
		CanCrossArchive = canCrossArchive;
		InheritableThroughSamsara = inheritableThroughSamsara;
		InheritableTransferTaiwu = inheritableTransferTaiwu;
		CanRecordWhenDead = canRecordWhenDead;
		DarkAshProtector = darkAshProtector;
		RequiredOrganization = requiredOrganization;
		MutexGroupId = mutexGroupId;
		DisplayPriority = displayPriority;
		AppearProb = appearProb;
		Duration = duration;
		Gender = gender;
		CandidateGroupId = candidateGroupId;
		ProtagonistAppearProb = protagonistAppearProb;
		GeneticProb = geneticProb;
		MakeConsummateLevelRelated = makeConsummateLevelRelated;
		LoseConsummateBonus = loseConsummateBonus;
		IsChickenFeature = isChickenFeature;
		AssociatedSpecialEffect = associatedSpecialEffect;
		CombatSkillPowerBonuses = combatSkillPowerBonuses;
		FiveElementPowerBonuses = fiveElementPowerBonuses;
		CombatSkillTypePowerBonuses = combatSkillTypePowerBonuses;
		CombatSkillSlotBonuses = combatSkillSlotBonuses;
		PersonalityCalm = personalityCalm;
		PersonalityClever = personalityClever;
		PersonalityEnthusiastic = personalityEnthusiastic;
		PersonalityBrave = personalityBrave;
		PersonalityFirm = personalityFirm;
		PersonalityLucky = personalityLucky;
		PersonalityPerceptive = personalityPerceptive;
		Strength = strength;
		Vitality = vitality;
		Dexterity = dexterity;
		Energy = energy;
		Intelligence = intelligence;
		Concentration = concentration;
		Fertility = fertility;
		HobbyChangingPeriod = hobbyChangingPeriod;
		Attraction = attraction;
		HitRateStrength = hitRateStrength;
		HitRateTechnique = hitRateTechnique;
		HitRateSpeed = hitRateSpeed;
		HitRateMind = hitRateMind;
		PenetrateOfOuter = penetrateOfOuter;
		PenetrateOfInner = penetrateOfInner;
		AvoidRateStrength = avoidRateStrength;
		AvoidRateTechnique = avoidRateTechnique;
		AvoidRateSpeed = avoidRateSpeed;
		AvoidRateMind = avoidRateMind;
		PenetrateResistOfOuter = penetrateResistOfOuter;
		PenetrateResistOfInner = penetrateResistOfInner;
		RecoveryOfStance = recoveryOfStance;
		RecoveryOfBreath = recoveryOfBreath;
		MoveSpeed = moveSpeed;
		RecoveryOfFlaw = recoveryOfFlaw;
		CastSpeed = castSpeed;
		RecoveryOfBlockedAcupoint = recoveryOfBlockedAcupoint;
		AttackSpeed = attackSpeed;
		WeaponSwitchSpeed = weaponSwitchSpeed;
		InnerRatio = innerRatio;
		RecoveryOfQiDisorder = recoveryOfQiDisorder;
		ResistOfHotPoison = resistOfHotPoison;
		ResistOfGloomyPoison = resistOfGloomyPoison;
		ResistOfColdPoison = resistOfColdPoison;
		ResistOfRedPoison = resistOfRedPoison;
		ResistOfRottenPoison = resistOfRottenPoison;
		ResistOfIllusoryPoison = resistOfIllusoryPoison;
		QualificationMusic = qualificationMusic;
		QualificationChess = qualificationChess;
		QualificationPoem = qualificationPoem;
		QualificationPainting = qualificationPainting;
		QualificationMath = qualificationMath;
		QualificationAppraisal = qualificationAppraisal;
		QualificationForging = qualificationForging;
		QualificationWoodworking = qualificationWoodworking;
		QualificationMedicine = qualificationMedicine;
		QualificationToxicology = qualificationToxicology;
		QualificationWeaving = qualificationWeaving;
		QualificationJade = qualificationJade;
		QualificationTaoism = qualificationTaoism;
		QualificationBuddhism = qualificationBuddhism;
		QualificationCooking = qualificationCooking;
		QualificationEclectic = qualificationEclectic;
		QualificationNeigong = qualificationNeigong;
		QualificationPosing = qualificationPosing;
		QualificationStunt = qualificationStunt;
		QualificationFistAndPalm = qualificationFistAndPalm;
		QualificationFinger = qualificationFinger;
		QualificationLeg = qualificationLeg;
		QualificationThrow = qualificationThrow;
		QualificationSword = qualificationSword;
		QualificationBlade = qualificationBlade;
		QualificationPolearm = qualificationPolearm;
		QualificationSpecial = qualificationSpecial;
		QualificationWhip = qualificationWhip;
		QualificationControllableShot = qualificationControllableShot;
		QualificationCombatMusic = qualificationCombatMusic;
		SilenceFramePercent = silenceFramePercent;
		XiangshuInfectionChange = xiangshuInfectionChange;
		MaxHealthPercentBonus = maxHealthPercentBonus;
		AttractionPercentBonus = attractionPercentBonus;
		FavorabilityIncrementFactor = favorabilityIncrementFactor;
		FavorabilityDecrementFactor = favorabilityDecrementFactor;
		AdoreMultiplePeopleChanceFactor = adoreMultiplePeopleChanceFactor;
		QiDisorderDelta = qiDisorderDelta;
		HealthDelta = healthDelta;
		InCombatEnemyGoneMadInjuryAddPercent = inCombatEnemyGoneMadInjuryAddPercent;
		InCombatEnemyAllPoisonResistReduceValue = inCombatEnemyAllPoisonResistReduceValue;
		InCombatMakeDirectDamageAddPercent = inCombatMakeDirectDamageAddPercent;
		MaxNeiliAllocationDebuff = maxNeiliAllocationDebuff;
		SectFameBonus = sectFameBonus;
		NotSectFameBonu = notSectFameBonu;
		TaiwuFameBonu = taiwuFameBonu;
		AttachPoisonBonus = attachPoisonBonus;
		DetoxPoisonBonus = detoxPoisonBonus;
		HealOuterBonus = healOuterBonus;
		HealInnerBonus = healInnerBonus;
		QiDisorderDebuffPercent = qiDisorderDebuffPercent;
		QiDisorderBuffPercent = qiDisorderBuffPercent;
		HealthRecovery = healthRecovery;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public CharacterFeatureItem()
	{
		TemplateId = 0;
		Name = null;
		SmallVillageName = null;
		Hidden = false;
		BelongAdventure = false;
		Type = ECharacterFeatureType.Special;
		Desc = null;
		SmallVillageDesc = null;
		EffectDesc = null;
		FeatureMedals = new FeatureMedals[3]
		{
			new FeatureMedals(),
			new FeatureMedals(),
			new FeatureMedals()
		};
		Level = 0;
		InfectedType = ECharacterFeatureInfectedType.NotInfected;
		IgnoreHealthMark = false;
		IsTreasuryGuard = false;
		CanBeModified = false;
		CanBeExchanged = false;
		Mergeable = false;
		Basic = false;
		Inscribable = false;
		SoulTransform = false;
		BodyTransform = false;
		CanDeleteManually = false;
		CanCrossArchive = true;
		InheritableThroughSamsara = false;
		InheritableTransferTaiwu = false;
		CanRecordWhenDead = true;
		DarkAshProtector = ECharacterFeatureDarkAshProtector.None;
		RequiredOrganization = 0;
		MutexGroupId = 0;
		DisplayPriority = 0;
		AppearProb = 0;
		Duration = 0;
		Gender = -1;
		CandidateGroupId = -1;
		ProtagonistAppearProb = 0;
		GeneticProb = 0;
		MakeConsummateLevelRelated = false;
		LoseConsummateBonus = false;
		IsChickenFeature = false;
		AssociatedSpecialEffect = null;
		CombatSkillPowerBonuses = new short[5];
		FiveElementPowerBonuses = new sbyte[5];
		CombatSkillTypePowerBonuses = null;
		CombatSkillSlotBonuses = new sbyte[5];
		PersonalityCalm = 0;
		PersonalityClever = 0;
		PersonalityEnthusiastic = 0;
		PersonalityBrave = 0;
		PersonalityFirm = 0;
		PersonalityLucky = 0;
		PersonalityPerceptive = 0;
		Strength = 0;
		Vitality = 0;
		Dexterity = 0;
		Energy = 0;
		Intelligence = 0;
		Concentration = 0;
		Fertility = 0;
		HobbyChangingPeriod = 0;
		Attraction = 0;
		HitRateStrength = 0;
		HitRateTechnique = 0;
		HitRateSpeed = 0;
		HitRateMind = 0;
		PenetrateOfOuter = 0;
		PenetrateOfInner = 0;
		AvoidRateStrength = 0;
		AvoidRateTechnique = 0;
		AvoidRateSpeed = 0;
		AvoidRateMind = 0;
		PenetrateResistOfOuter = 0;
		PenetrateResistOfInner = 0;
		RecoveryOfStance = 0;
		RecoveryOfBreath = 0;
		MoveSpeed = 0;
		RecoveryOfFlaw = 0;
		CastSpeed = 0;
		RecoveryOfBlockedAcupoint = 0;
		AttackSpeed = 0;
		WeaponSwitchSpeed = 0;
		InnerRatio = 0;
		RecoveryOfQiDisorder = 0;
		ResistOfHotPoison = 0;
		ResistOfGloomyPoison = 0;
		ResistOfColdPoison = 0;
		ResistOfRedPoison = 0;
		ResistOfRottenPoison = 0;
		ResistOfIllusoryPoison = 0;
		QualificationMusic = 0;
		QualificationChess = 0;
		QualificationPoem = 0;
		QualificationPainting = 0;
		QualificationMath = 0;
		QualificationAppraisal = 0;
		QualificationForging = 0;
		QualificationWoodworking = 0;
		QualificationMedicine = 0;
		QualificationToxicology = 0;
		QualificationWeaving = 0;
		QualificationJade = 0;
		QualificationTaoism = 0;
		QualificationBuddhism = 0;
		QualificationCooking = 0;
		QualificationEclectic = 0;
		QualificationNeigong = 0;
		QualificationPosing = 0;
		QualificationStunt = 0;
		QualificationFistAndPalm = 0;
		QualificationFinger = 0;
		QualificationLeg = 0;
		QualificationThrow = 0;
		QualificationSword = 0;
		QualificationBlade = 0;
		QualificationPolearm = 0;
		QualificationSpecial = 0;
		QualificationWhip = 0;
		QualificationControllableShot = 0;
		QualificationCombatMusic = 0;
		SilenceFramePercent = 0;
		XiangshuInfectionChange = 0;
		MaxHealthPercentBonus = 0;
		AttractionPercentBonus = 0;
		FavorabilityIncrementFactor = 100;
		FavorabilityDecrementFactor = 100;
		AdoreMultiplePeopleChanceFactor = 100;
		QiDisorderDelta = 0;
		HealthDelta = 0;
		InCombatEnemyGoneMadInjuryAddPercent = 0;
		InCombatEnemyAllPoisonResistReduceValue = 0;
		InCombatMakeDirectDamageAddPercent = 0;
		MaxNeiliAllocationDebuff = 0;
		SectFameBonus = new sbyte[9];
		NotSectFameBonu = 0;
		TaiwuFameBonu = 0;
		AttachPoisonBonus = 0;
		DetoxPoisonBonus = 0;
		HealOuterBonus = 0;
		HealInnerBonus = 0;
		QiDisorderDebuffPercent = 0;
		QiDisorderBuffPercent = 0;
		HealthRecovery = 0;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public CharacterFeatureItem(short templateId, CharacterFeatureItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		SmallVillageName = other.SmallVillageName;
		Hidden = other.Hidden;
		BelongAdventure = other.BelongAdventure;
		Type = other.Type;
		Desc = other.Desc;
		SmallVillageDesc = other.SmallVillageDesc;
		EffectDesc = other.EffectDesc;
		FeatureMedals = other.FeatureMedals;
		Level = other.Level;
		InfectedType = other.InfectedType;
		IgnoreHealthMark = other.IgnoreHealthMark;
		IsTreasuryGuard = other.IsTreasuryGuard;
		CanBeModified = other.CanBeModified;
		CanBeExchanged = other.CanBeExchanged;
		Mergeable = other.Mergeable;
		Basic = other.Basic;
		Inscribable = other.Inscribable;
		SoulTransform = other.SoulTransform;
		BodyTransform = other.BodyTransform;
		CanDeleteManually = other.CanDeleteManually;
		CanCrossArchive = other.CanCrossArchive;
		InheritableThroughSamsara = other.InheritableThroughSamsara;
		InheritableTransferTaiwu = other.InheritableTransferTaiwu;
		CanRecordWhenDead = other.CanRecordWhenDead;
		DarkAshProtector = other.DarkAshProtector;
		RequiredOrganization = other.RequiredOrganization;
		MutexGroupId = other.MutexGroupId;
		DisplayPriority = other.DisplayPriority;
		AppearProb = other.AppearProb;
		Duration = other.Duration;
		Gender = other.Gender;
		CandidateGroupId = other.CandidateGroupId;
		ProtagonistAppearProb = other.ProtagonistAppearProb;
		GeneticProb = other.GeneticProb;
		MakeConsummateLevelRelated = other.MakeConsummateLevelRelated;
		LoseConsummateBonus = other.LoseConsummateBonus;
		IsChickenFeature = other.IsChickenFeature;
		AssociatedSpecialEffect = other.AssociatedSpecialEffect;
		CombatSkillPowerBonuses = other.CombatSkillPowerBonuses;
		FiveElementPowerBonuses = other.FiveElementPowerBonuses;
		CombatSkillTypePowerBonuses = other.CombatSkillTypePowerBonuses;
		CombatSkillSlotBonuses = other.CombatSkillSlotBonuses;
		PersonalityCalm = other.PersonalityCalm;
		PersonalityClever = other.PersonalityClever;
		PersonalityEnthusiastic = other.PersonalityEnthusiastic;
		PersonalityBrave = other.PersonalityBrave;
		PersonalityFirm = other.PersonalityFirm;
		PersonalityLucky = other.PersonalityLucky;
		PersonalityPerceptive = other.PersonalityPerceptive;
		Strength = other.Strength;
		Vitality = other.Vitality;
		Dexterity = other.Dexterity;
		Energy = other.Energy;
		Intelligence = other.Intelligence;
		Concentration = other.Concentration;
		Fertility = other.Fertility;
		HobbyChangingPeriod = other.HobbyChangingPeriod;
		Attraction = other.Attraction;
		HitRateStrength = other.HitRateStrength;
		HitRateTechnique = other.HitRateTechnique;
		HitRateSpeed = other.HitRateSpeed;
		HitRateMind = other.HitRateMind;
		PenetrateOfOuter = other.PenetrateOfOuter;
		PenetrateOfInner = other.PenetrateOfInner;
		AvoidRateStrength = other.AvoidRateStrength;
		AvoidRateTechnique = other.AvoidRateTechnique;
		AvoidRateSpeed = other.AvoidRateSpeed;
		AvoidRateMind = other.AvoidRateMind;
		PenetrateResistOfOuter = other.PenetrateResistOfOuter;
		PenetrateResistOfInner = other.PenetrateResistOfInner;
		RecoveryOfStance = other.RecoveryOfStance;
		RecoveryOfBreath = other.RecoveryOfBreath;
		MoveSpeed = other.MoveSpeed;
		RecoveryOfFlaw = other.RecoveryOfFlaw;
		CastSpeed = other.CastSpeed;
		RecoveryOfBlockedAcupoint = other.RecoveryOfBlockedAcupoint;
		AttackSpeed = other.AttackSpeed;
		WeaponSwitchSpeed = other.WeaponSwitchSpeed;
		InnerRatio = other.InnerRatio;
		RecoveryOfQiDisorder = other.RecoveryOfQiDisorder;
		ResistOfHotPoison = other.ResistOfHotPoison;
		ResistOfGloomyPoison = other.ResistOfGloomyPoison;
		ResistOfColdPoison = other.ResistOfColdPoison;
		ResistOfRedPoison = other.ResistOfRedPoison;
		ResistOfRottenPoison = other.ResistOfRottenPoison;
		ResistOfIllusoryPoison = other.ResistOfIllusoryPoison;
		QualificationMusic = other.QualificationMusic;
		QualificationChess = other.QualificationChess;
		QualificationPoem = other.QualificationPoem;
		QualificationPainting = other.QualificationPainting;
		QualificationMath = other.QualificationMath;
		QualificationAppraisal = other.QualificationAppraisal;
		QualificationForging = other.QualificationForging;
		QualificationWoodworking = other.QualificationWoodworking;
		QualificationMedicine = other.QualificationMedicine;
		QualificationToxicology = other.QualificationToxicology;
		QualificationWeaving = other.QualificationWeaving;
		QualificationJade = other.QualificationJade;
		QualificationTaoism = other.QualificationTaoism;
		QualificationBuddhism = other.QualificationBuddhism;
		QualificationCooking = other.QualificationCooking;
		QualificationEclectic = other.QualificationEclectic;
		QualificationNeigong = other.QualificationNeigong;
		QualificationPosing = other.QualificationPosing;
		QualificationStunt = other.QualificationStunt;
		QualificationFistAndPalm = other.QualificationFistAndPalm;
		QualificationFinger = other.QualificationFinger;
		QualificationLeg = other.QualificationLeg;
		QualificationThrow = other.QualificationThrow;
		QualificationSword = other.QualificationSword;
		QualificationBlade = other.QualificationBlade;
		QualificationPolearm = other.QualificationPolearm;
		QualificationSpecial = other.QualificationSpecial;
		QualificationWhip = other.QualificationWhip;
		QualificationControllableShot = other.QualificationControllableShot;
		QualificationCombatMusic = other.QualificationCombatMusic;
		SilenceFramePercent = other.SilenceFramePercent;
		XiangshuInfectionChange = other.XiangshuInfectionChange;
		MaxHealthPercentBonus = other.MaxHealthPercentBonus;
		AttractionPercentBonus = other.AttractionPercentBonus;
		FavorabilityIncrementFactor = other.FavorabilityIncrementFactor;
		FavorabilityDecrementFactor = other.FavorabilityDecrementFactor;
		AdoreMultiplePeopleChanceFactor = other.AdoreMultiplePeopleChanceFactor;
		QiDisorderDelta = other.QiDisorderDelta;
		HealthDelta = other.HealthDelta;
		InCombatEnemyGoneMadInjuryAddPercent = other.InCombatEnemyGoneMadInjuryAddPercent;
		InCombatEnemyAllPoisonResistReduceValue = other.InCombatEnemyAllPoisonResistReduceValue;
		InCombatMakeDirectDamageAddPercent = other.InCombatMakeDirectDamageAddPercent;
		MaxNeiliAllocationDebuff = other.MaxNeiliAllocationDebuff;
		SectFameBonus = other.SectFameBonus;
		NotSectFameBonu = other.NotSectFameBonu;
		TaiwuFameBonu = other.TaiwuFameBonu;
		AttachPoisonBonus = other.AttachPoisonBonus;
		DetoxPoisonBonus = other.DetoxPoisonBonus;
		HealOuterBonus = other.HealOuterBonus;
		HealInnerBonus = other.HealInnerBonus;
		QiDisorderDebuffPercent = other.QiDisorderDebuffPercent;
		QiDisorderBuffPercent = other.QiDisorderBuffPercent;
		HealthRecovery = other.HealthRecovery;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override CharacterFeatureItem Duplicate(int templateId)
	{
		return new CharacterFeatureItem((short)templateId, this);
	}

	/// <summary>
	/// 获取CharacterProperty加成
	/// </summary>
	/// <param name="key"></param>
	public int GetCharacterPropertyBonusInt(ECharacterPropertyReferencedType key)
	{
		return key switch
		{
			ECharacterPropertyReferencedType.PersonalityCalm => PersonalityCalm, 
			ECharacterPropertyReferencedType.PersonalityClever => PersonalityClever, 
			ECharacterPropertyReferencedType.PersonalityEnthusiastic => PersonalityEnthusiastic, 
			ECharacterPropertyReferencedType.PersonalityBrave => PersonalityBrave, 
			ECharacterPropertyReferencedType.PersonalityFirm => PersonalityFirm, 
			ECharacterPropertyReferencedType.PersonalityLucky => PersonalityLucky, 
			ECharacterPropertyReferencedType.PersonalityPerceptive => PersonalityPerceptive, 
			ECharacterPropertyReferencedType.Strength => Strength, 
			ECharacterPropertyReferencedType.Vitality => Vitality, 
			ECharacterPropertyReferencedType.Dexterity => Dexterity, 
			ECharacterPropertyReferencedType.Energy => Energy, 
			ECharacterPropertyReferencedType.Intelligence => Intelligence, 
			ECharacterPropertyReferencedType.Concentration => Concentration, 
			ECharacterPropertyReferencedType.Fertility => Fertility, 
			ECharacterPropertyReferencedType.HobbyChangingPeriod => HobbyChangingPeriod, 
			ECharacterPropertyReferencedType.Attraction => Attraction, 
			ECharacterPropertyReferencedType.HitRateStrength => HitRateStrength, 
			ECharacterPropertyReferencedType.HitRateTechnique => HitRateTechnique, 
			ECharacterPropertyReferencedType.HitRateSpeed => HitRateSpeed, 
			ECharacterPropertyReferencedType.HitRateMind => HitRateMind, 
			ECharacterPropertyReferencedType.PenetrateOfOuter => PenetrateOfOuter, 
			ECharacterPropertyReferencedType.PenetrateOfInner => PenetrateOfInner, 
			ECharacterPropertyReferencedType.AvoidRateStrength => AvoidRateStrength, 
			ECharacterPropertyReferencedType.AvoidRateTechnique => AvoidRateTechnique, 
			ECharacterPropertyReferencedType.AvoidRateSpeed => AvoidRateSpeed, 
			ECharacterPropertyReferencedType.AvoidRateMind => AvoidRateMind, 
			ECharacterPropertyReferencedType.PenetrateResistOfOuter => PenetrateResistOfOuter, 
			ECharacterPropertyReferencedType.PenetrateResistOfInner => PenetrateResistOfInner, 
			ECharacterPropertyReferencedType.RecoveryOfStance => RecoveryOfStance, 
			ECharacterPropertyReferencedType.RecoveryOfBreath => RecoveryOfBreath, 
			ECharacterPropertyReferencedType.MoveSpeed => MoveSpeed, 
			ECharacterPropertyReferencedType.RecoveryOfFlaw => RecoveryOfFlaw, 
			ECharacterPropertyReferencedType.CastSpeed => CastSpeed, 
			ECharacterPropertyReferencedType.RecoveryOfBlockedAcupoint => RecoveryOfBlockedAcupoint, 
			ECharacterPropertyReferencedType.AttackSpeed => AttackSpeed, 
			ECharacterPropertyReferencedType.WeaponSwitchSpeed => WeaponSwitchSpeed, 
			ECharacterPropertyReferencedType.InnerRatio => InnerRatio, 
			ECharacterPropertyReferencedType.RecoveryOfQiDisorder => RecoveryOfQiDisorder, 
			ECharacterPropertyReferencedType.ResistOfHotPoison => ResistOfHotPoison, 
			ECharacterPropertyReferencedType.ResistOfGloomyPoison => ResistOfGloomyPoison, 
			ECharacterPropertyReferencedType.ResistOfColdPoison => ResistOfColdPoison, 
			ECharacterPropertyReferencedType.ResistOfRedPoison => ResistOfRedPoison, 
			ECharacterPropertyReferencedType.ResistOfRottenPoison => ResistOfRottenPoison, 
			ECharacterPropertyReferencedType.ResistOfIllusoryPoison => ResistOfIllusoryPoison, 
			ECharacterPropertyReferencedType.QualificationMusic => QualificationMusic, 
			ECharacterPropertyReferencedType.QualificationChess => QualificationChess, 
			ECharacterPropertyReferencedType.QualificationPoem => QualificationPoem, 
			ECharacterPropertyReferencedType.QualificationPainting => QualificationPainting, 
			ECharacterPropertyReferencedType.QualificationMath => QualificationMath, 
			ECharacterPropertyReferencedType.QualificationAppraisal => QualificationAppraisal, 
			ECharacterPropertyReferencedType.QualificationForging => QualificationForging, 
			ECharacterPropertyReferencedType.QualificationWoodworking => QualificationWoodworking, 
			ECharacterPropertyReferencedType.QualificationMedicine => QualificationMedicine, 
			ECharacterPropertyReferencedType.QualificationToxicology => QualificationToxicology, 
			ECharacterPropertyReferencedType.QualificationWeaving => QualificationWeaving, 
			ECharacterPropertyReferencedType.QualificationJade => QualificationJade, 
			ECharacterPropertyReferencedType.QualificationTaoism => QualificationTaoism, 
			ECharacterPropertyReferencedType.QualificationBuddhism => QualificationBuddhism, 
			ECharacterPropertyReferencedType.QualificationCooking => QualificationCooking, 
			ECharacterPropertyReferencedType.QualificationEclectic => QualificationEclectic, 
			ECharacterPropertyReferencedType.QualificationNeigong => QualificationNeigong, 
			ECharacterPropertyReferencedType.QualificationPosing => QualificationPosing, 
			ECharacterPropertyReferencedType.QualificationStunt => QualificationStunt, 
			ECharacterPropertyReferencedType.QualificationFistAndPalm => QualificationFistAndPalm, 
			ECharacterPropertyReferencedType.QualificationFinger => QualificationFinger, 
			ECharacterPropertyReferencedType.QualificationLeg => QualificationLeg, 
			ECharacterPropertyReferencedType.QualificationThrow => QualificationThrow, 
			ECharacterPropertyReferencedType.QualificationSword => QualificationSword, 
			ECharacterPropertyReferencedType.QualificationBlade => QualificationBlade, 
			ECharacterPropertyReferencedType.QualificationPolearm => QualificationPolearm, 
			ECharacterPropertyReferencedType.QualificationSpecial => QualificationSpecial, 
			ECharacterPropertyReferencedType.QualificationWhip => QualificationWhip, 
			ECharacterPropertyReferencedType.QualificationControllableShot => QualificationControllableShot, 
			ECharacterPropertyReferencedType.QualificationCombatMusic => QualificationCombatMusic, 
			_ => 0, 
		};
	}
}

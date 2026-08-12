using System;
using System.Collections.Generic;
using Config.Common;
using GameData.Domains.Character;
using GameData.Utilities;

namespace Config;

/// <summary>
/// 药毒
/// </summary>
/// <summary>
/// 药毒扩展： 加入PoisonType与WugType的计算
/// </summary>
[Serializable]
public class MedicineItem : ConfigItem<MedicineItem, short>, ICombatItemConfig, IItemConfig
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
	/// 物品类型
	/// - 参见 GameData.Domains.Item.ItemType
	/// </summary>
	public readonly sbyte ItemType;

	/// <summary>
	/// 物品子类
	/// - 参见 GameData.Domains.Item.ItemSubType
	/// </summary>
	public readonly short ItemSubType;

	/// <summary>
	/// 品级
	/// </summary>
	public readonly sbyte Grade;

	/// <summary>
	/// 所属分组
	/// </summary>
	public readonly short GroupId;

	/// <summary>
	/// 图标
	/// </summary>
	public readonly string Icon;

	/// <summary>
	/// 说明
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 功能说明
	/// </summary>
	public readonly string FunctionDesc;

	/// <summary>
	/// 战斗内效果说明
	/// </summary>
	public readonly string SpecialEffectDesc;

	/// <summary>
	/// 战斗特效
	/// </summary>
	public readonly short SpecialEffectId;

	/// <summary>
	/// 可让渡
	/// </summary>
	public readonly bool Transferable;

	/// <summary>
	/// 可堆叠
	/// </summary>
	public readonly bool Stackable;

	/// <summary>
	/// 可押注
	/// </summary>
	public readonly bool Wagerable;

	/// <summary>
	/// 可精制
	/// </summary>
	public readonly bool Refinable;

	/// <summary>
	/// 可淬毒
	/// </summary>
	public readonly bool Poisonable;

	/// <summary>
	/// 可修理
	/// - 同时控制是否会在耐久耗尽时自动销毁
	/// </summary>
	public readonly bool Repairable;

	/// <summary>
	/// 可梦回
	/// </summary>
	public readonly bool Inheritable;

	/// <summary>
	/// 最大耐久
	/// - 为正值在生成时会有浮动, 为负值则固定不变
	/// </summary>
	public readonly short MaxDurability;

	/// <summary>
	/// 重量
	/// </summary>
	public readonly int BaseWeight;

	/// <summary>
	/// 基础价值
	/// </summary>
	public readonly int BaseValue;

	/// <summary>
	/// 商会等级
	/// - 此物品售出时，可偿还哪个商店等级及以下的欠下数量（商店等级为0~6）
	/// </summary>
	public readonly sbyte MerchantLevel;

	/// <summary>
	/// 基础心情变化
	/// - 让渡后的基础心情变化
	/// </summary>
	public readonly sbyte BaseHappinessChange;

	/// <summary>
	/// 基础好感变化
	/// - 让渡后的好感变化基础值，最终值需要加上特殊效果的影响
	/// </summary>
	public readonly int BaseFavorabilityChange;

	/// <summary>
	/// 礼物级别
	/// - &gt;此级别的人物不会接受此礼物
	/// </summary>
	public readonly sbyte GiftLevel;

	/// <summary>
	/// 允许随机生成
	/// </summary>
	public readonly bool AllowRandomCreate;

	/// <summary>
	/// 掉落率
	/// - 取值范围 [0, 100]
	/// </summary>
	public readonly sbyte DropRate;

	/// <summary>
	/// 特殊物品
	/// - 0为正常物品，1为特殊物品，在某些情况下的筛选需要排除（例如太吾村商人指定物品行为）
	/// </summary>
	public readonly bool IsSpecial;

	/// <summary>
	/// 材质
	/// - 对应的资源类型
	/// </summary>
	public readonly sbyte ResourceType;

	/// <summary>
	/// 保存时间
	/// - 无主物品的可保存时间, 超过时间会损毁. 单位为月.
	/// </summary>
	public readonly short PreservationDuration;

	/// <summary>
	/// 复数使用
	/// - 此项设为真值且物品被堆叠时，会在使用道具的界面弹出选择数量框
	/// </summary>
	public readonly bool CanUseMultiple;

	/// <summary>
	/// 玄机格效果
	/// - 此物品提供的玄机格加成效果类型
	/// </summary>
	public readonly sbyte BreakBonusEffect;

	/// <summary>
	/// 任务锁
	/// - 当任务被启用时，禁止移动物品
	/// </summary>
	public readonly List<int> TaskLock;

	/// <summary>
	/// 持续时间
	/// - 服食后在服食栏上存在的时间, 单位月.为0表示不占用服食栏
	/// </summary>
	public readonly short Duration;

	/// <summary>
	/// 效果类型
	/// - 参见 GameData.Domains.Item.MedicineInstantEffectType
	/// </summary>
	public readonly EMedicineEffectType EffectType;

	/// <summary>
	/// 效果子类型
	/// - 对于毒素效果类型为毒素类型 (GameData.Domains.Combat.PoisonType), 对于蛊虫效果类型为蛊虫类型 (GameData.Domains.Item.WugType).
	/// </summary>
	public readonly EMedicineEffectSubType EffectSubType;

	/// <summary>
	/// 作用阈值
	/// - 未达到或已超过此值的作用值, 无法产生效果. 具体行为因效果类型而不同.
	/// </summary>
	public readonly short EffectThresholdValue;

	/// <summary>
	/// 作用值
	/// - 具体行为因效果类型而不同
	/// </summary>
	public readonly short EffectValue;

	/// <summary>
	/// 副作用值
	/// - 某些效果类型会有副作用. 对于毒药来说, 副作用为解蛊, 所填值为可解除的蛊的类型.
	/// </summary>
	public readonly short SideEffectValue;

	/// <summary>
	/// 伤势治疗次数
	/// </summary>
	public readonly sbyte InjuryRecoveryTimes;

	/// <summary>
	/// 消耗属性类型
	/// - 参见 GameData.Domains.Character.MainAttributeType
	/// </summary>
	public readonly sbyte RequiredMainAttributeType;

	/// <summary>
	/// 消耗属性值
	/// </summary>
	public readonly sbyte RequiredMainAttributeValue;

	/// <summary>
	/// 强健加成
	/// - 百分比，类型关系：外伤-外伤、内伤-内伤、内息-心神、健康-重创
	/// </summary>
	public readonly sbyte DamageStepBonus;

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
	public readonly short AvoidRateStrength;

	/// <summary>
	/// 拆招
	/// </summary>
	public readonly short AvoidRateTechnique;

	/// <summary>
	/// 闪避
	/// </summary>
	public readonly short AvoidRateSpeed;

	/// <summary>
	/// 守心
	/// </summary>
	public readonly short AvoidRateMind;

	/// <summary>
	/// 御体
	/// </summary>
	public readonly short PenetrateResistOfOuter;

	/// <summary>
	/// 御气
	/// </summary>
	public readonly short PenetrateResistOfInner;

	/// <summary>
	/// 架势速度
	/// </summary>
	public readonly short RecoveryOfStance;

	/// <summary>
	/// 提气速度
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
	/// 兵器切换
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
	/// 蛊毒类型
	/// - 参见 GameData.Domains.Combat.WugType
	/// </summary>
	public readonly sbyte WugType;

	/// <summary>
	/// 成长类型
	/// - 0: 有益若蛊1(战斗中), 1:有益若蛊2(战斗外), 2: 有害若蛊1(战斗中), 3: 有害若蛊2(战斗外), 4: 成蛊.
	/// </summary>
	public readonly sbyte WugGrowthType;

	/// <summary>
	/// 特效类名
	/// - 此列由特效代码作者维护
	/// </summary>
	public readonly string SpecialEffectClass;

	/// <summary>
	/// 机略消耗
	/// - 战斗前使用时消耗的机略值. 为 -1 表示战斗无法使用.
	/// </summary>
	public readonly sbyte ConsumedFeatureMedals;

	/// <summary>
	/// 最大使用距离
	/// - 战斗中，以2为最小距离，此配置参数为最大距离
	/// </summary>
	public readonly sbyte MaxUseDistance;

	/// <summary>
	/// 使用时间
	/// - 单位为帧数
	/// </summary>
	public readonly int UseFrame;

	/// <summary>
	/// 物品类型
	/// </summary>
	public readonly sbyte BuffAndOtherMedicine;

	/// <summary>
	/// 烈毒
	/// </summary>
	public readonly short ResistOfHotPoison;

	/// <summary>
	/// 郁毒
	/// </summary>
	public readonly short ResistOfGloomyPoison;

	/// <summary>
	/// 寒毒
	/// </summary>
	public readonly short ResistOfColdPoison;

	/// <summary>
	/// 赤毒
	/// </summary>
	public readonly short ResistOfRedPoison;

	/// <summary>
	/// 腐毒
	/// </summary>
	public readonly short ResistOfRottenPoison;

	/// <summary>
	/// 幻毒
	/// </summary>
	public readonly short ResistOfIllusoryPoison;

	/// <summary>
	/// 具有常规服食效果
	/// - 除毒药外均应使用公式自动推导
	/// </summary>
	public readonly bool HasNormalEatingEffect;

	/// <summary>
	/// 服食后立刻生效
	/// - 除毒药与活死药外几乎均应使用公式自动推导
	/// </summary>
	public readonly bool InstantAffect;

	/// <summary>
	/// 战斗使用表现
	/// - 本表都使用默认值
	/// </summary>
	public readonly short CombatUseEffect;

	/// <summary>
	/// 战斗准备使用表现
	/// - 本表都使用默认值
	/// </summary>
	public readonly short CombatPrepareUseEffect;

	/// <summary>
	/// 虚拟道具
	/// - 该类道具不会生成实例, 只是作为道具配置使用其模板数据. 暂时只有药毒可能出现虚拟道具，如果后续需要可扩展为所有道具共同的字段.
	/// </summary>
	public readonly bool IsVirtual;

	int ICombatItemConfig.ConsumedFeatureMedals => ConsumedFeatureMedals;

	int ICombatItemConfig.UseFrame => UseFrame;

	short IItemConfig.TemplateId => TemplateId;

	sbyte IItemConfig.ItemType => ItemType;

	short IItemConfig.ItemSubType => ItemSubType;

	string IItemConfig.Name => Name;

	string IItemConfig.Icon => Icon;

	sbyte IItemConfig.Grade => Grade;

	short IItemConfig.GroupId => GroupId;

	sbyte IItemConfig.MaxUseDistance => MaxUseDistance;

	short IItemConfig.Duration => Duration;

	int IItemConfig.BaseValue => BaseValue;

	List<int> IItemConfig.TaskLock => TaskLock;

	/// <summary>
	/// 获取药物的毒素类型/解毒类型（若无，返回-1）
	/// 如果需要区分或者强调代码逻辑为毒素类型/解读类型中的特定一种，可以使用下面的两个属性
	/// </summary>
	public sbyte PoisonType => EffectSubType.PoisonType();

	/// <summary>
	/// 获取药物的解毒类型（若无，返回-1）
	/// </summary>
	public sbyte DetoxPoisonType => EffectSubType.DetoxPoisonType();

	/// <summary>
	/// 获取药物的毒素类型（若无，返回-1）
	/// </summary>
	public sbyte ApplyPoisonType => EffectSubType.ApplyPoisonType();

	/// <summary>
	/// 获取药物的解蛊类型（毒药专属，非毒药返回-1）
	/// 需注意WugType是蛊专属的字段，不应在这里使用
	/// </summary>
	public sbyte DetoxWugType => EMedicineEffectSubTypeExtension.DetoxWugType(EffectType, SideEffectValue);

	/// <summary>
	/// 获取药物效果的影响类型
	/// </summary>
	public EMedicineEffectSubTypeExtension.Operate OperateType => EffectSubType.OperateType();

	/// <summary>
	/// 药物效果的影响是百分比类型
	/// </summary>
	public bool EffectIsPercentage => EffectSubType.IsPercentage();

	/// <summary>
	/// 药物效果的影响是值类型
	/// </summary>
	public bool EffectIsValue => EffectSubType.IsValue();

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="name">名称</param>
	/// <param name="itemType">物品类型 - 参见 GameData.Domains.Item.ItemType</param>
	/// <param name="itemSubType">物品子类 - 参见 GameData.Domains.Item.ItemSubType</param>
	/// <param name="grade">品级</param>
	/// <param name="groupId">所属分组</param>
	/// <param name="icon">图标</param>
	/// <param name="desc">说明</param>
	/// <param name="functionDesc">功能说明</param>
	/// <param name="specialEffectDesc">战斗内效果说明</param>
	/// <param name="specialEffectId">战斗特效</param>
	/// <param name="transferable">可让渡</param>
	/// <param name="stackable">可堆叠</param>
	/// <param name="wagerable">可押注</param>
	/// <param name="refinable">可精制</param>
	/// <param name="poisonable">可淬毒</param>
	/// <param name="repairable">可修理 - 同时控制是否会在耐久耗尽时自动销毁</param>
	/// <param name="inheritable">可梦回</param>
	/// <param name="maxDurability">最大耐久 - 为正值在生成时会有浮动, 为负值则固定不变</param>
	/// <param name="baseWeight">重量</param>
	/// <param name="baseValue">基础价值</param>
	/// <param name="merchantLevel">商会等级 - 此物品售出时，可偿还哪个商店等级及以下的欠下数量（商店等级为0~6）</param>
	/// <param name="baseHappinessChange">基础心情变化 - 让渡后的基础心情变化</param>
	/// <param name="baseFavorabilityChange">基础好感变化 - 让渡后的好感变化基础值，最终值需要加上特殊效果的影响</param>
	/// <param name="giftLevel">礼物级别 - &gt;此级别的人物不会接受此礼物</param>
	/// <param name="allowRandomCreate">允许随机生成</param>
	/// <param name="dropRate">掉落率 - 取值范围 [0, 100]</param>
	/// <param name="isSpecial">特殊物品 - 0为正常物品，1为特殊物品，在某些情况下的筛选需要排除（例如太吾村商人指定物品行为）</param>
	/// <param name="resourceType">材质 - 对应的资源类型</param>
	/// <param name="preservationDuration">保存时间 - 无主物品的可保存时间, 超过时间会损毁. 单位为月.</param>
	/// <param name="canUseMultiple">复数使用 - 此项设为真值且物品被堆叠时，会在使用道具的界面弹出选择数量框</param>
	/// <param name="breakBonusEffect">玄机格效果 - 此物品提供的玄机格加成效果类型</param>
	/// <param name="taskLock">任务锁 - 当任务被启用时，禁止移动物品</param>
	/// <param name="duration">持续时间 - 服食后在服食栏上存在的时间, 单位月.为0表示不占用服食栏</param>
	/// <param name="effectType">效果类型 - 参见 GameData.Domains.Item.MedicineInstantEffectType</param>
	/// <param name="effectSubType">效果子类型 - 对于毒素效果类型为毒素类型 (GameData.Domains.Combat.PoisonType), 对于蛊虫效果类型为蛊虫类型 (GameData.Domains.Item.WugType).</param>
	/// <param name="effectThresholdValue">作用阈值 - 未达到或已超过此值的作用值, 无法产生效果. 具体行为因效果类型而不同.</param>
	/// <param name="effectValue">作用值 - 具体行为因效果类型而不同</param>
	/// <param name="sideEffectValue">副作用值 - 某些效果类型会有副作用. 对于毒药来说, 副作用为解蛊, 所填值为可解除的蛊的类型.</param>
	/// <param name="injuryRecoveryTimes">伤势治疗次数</param>
	/// <param name="requiredMainAttributeType">消耗属性类型 - 参见 GameData.Domains.Character.MainAttributeType</param>
	/// <param name="requiredMainAttributeValue">消耗属性值</param>
	/// <param name="damageStepBonus">强健加成 - 百分比，类型关系：外伤-外伤、内伤-内伤、内息-心神、健康-重创</param>
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
	/// <param name="recoveryOfStance">架势速度</param>
	/// <param name="recoveryOfBreath">提气速度</param>
	/// <param name="moveSpeed">移动速度</param>
	/// <param name="recoveryOfFlaw">步伐稳健</param>
	/// <param name="castSpeed">施展速度</param>
	/// <param name="recoveryOfBlockedAcupoint">引气冲关</param>
	/// <param name="weaponSwitchSpeed">兵器切换</param>
	/// <param name="attackSpeed">攻击速度</param>
	/// <param name="innerRatio">内功发挥</param>
	/// <param name="recoveryOfQiDisorder">调息吐纳</param>
	/// <param name="wugType">蛊毒类型 - 参见 GameData.Domains.Combat.WugType</param>
	/// <param name="wugGrowthType">成长类型 - 0: 有益若蛊1(战斗中), 1:有益若蛊2(战斗外), 2: 有害若蛊1(战斗中), 3: 有害若蛊2(战斗外), 4: 成蛊.</param>
	/// <param name="specialEffectClass">特效类名 - 此列由特效代码作者维护</param>
	/// <param name="consumedFeatureMedals">机略消耗 - 战斗前使用时消耗的机略值. 为 -1 表示战斗无法使用.</param>
	/// <param name="maxUseDistance">最大使用距离 - 战斗中，以2为最小距离，此配置参数为最大距离</param>
	/// <param name="useFrame">使用时间 - 单位为帧数</param>
	/// <param name="buffAndOtherMedicine">物品类型</param>
	/// <param name="resistOfHotPoison">烈毒</param>
	/// <param name="resistOfGloomyPoison">郁毒</param>
	/// <param name="resistOfColdPoison">寒毒</param>
	/// <param name="resistOfRedPoison">赤毒</param>
	/// <param name="resistOfRottenPoison">腐毒</param>
	/// <param name="resistOfIllusoryPoison">幻毒</param>
	/// <param name="hasNormalEatingEffect">具有常规服食效果 - 除毒药外均应使用公式自动推导</param>
	/// <param name="instantAffect">服食后立刻生效 - 除毒药与活死药外几乎均应使用公式自动推导</param>
	/// <param name="combatUseEffect">战斗使用表现 - 本表都使用默认值</param>
	/// <param name="combatPrepareUseEffect">战斗准备使用表现 - 本表都使用默认值</param>
	/// <param name="isVirtual">虚拟道具 - 该类道具不会生成实例, 只是作为道具配置使用其模板数据. 暂时只有药毒可能出现虚拟道具，如果后续需要可扩展为所有道具共同的字段.</param>
	public MedicineItem(short templateId, string name, sbyte itemType, short itemSubType, sbyte grade, short groupId, string icon, string desc, string functionDesc, string specialEffectDesc, short specialEffectId, bool transferable, bool stackable, bool wagerable, bool refinable, bool poisonable, bool repairable, bool inheritable, short maxDurability, int baseWeight, int baseValue, sbyte merchantLevel, sbyte baseHappinessChange, int baseFavorabilityChange, sbyte giftLevel, bool allowRandomCreate, sbyte dropRate, bool isSpecial, sbyte resourceType, short preservationDuration, bool canUseMultiple, sbyte breakBonusEffect, List<int> taskLock, short duration, EMedicineEffectType effectType, EMedicineEffectSubType effectSubType, short effectThresholdValue, short effectValue, short sideEffectValue, sbyte injuryRecoveryTimes, sbyte requiredMainAttributeType, sbyte requiredMainAttributeValue, sbyte damageStepBonus, short hitRateStrength, short hitRateTechnique, short hitRateSpeed, short hitRateMind, short penetrateOfOuter, short penetrateOfInner, short avoidRateStrength, short avoidRateTechnique, short avoidRateSpeed, short avoidRateMind, short penetrateResistOfOuter, short penetrateResistOfInner, short recoveryOfStance, short recoveryOfBreath, short moveSpeed, short recoveryOfFlaw, short castSpeed, short recoveryOfBlockedAcupoint, short weaponSwitchSpeed, short attackSpeed, short innerRatio, short recoveryOfQiDisorder, sbyte wugType, sbyte wugGrowthType, string specialEffectClass, sbyte consumedFeatureMedals, sbyte maxUseDistance, int useFrame, sbyte buffAndOtherMedicine, short resistOfHotPoison, short resistOfGloomyPoison, short resistOfColdPoison, short resistOfRedPoison, short resistOfRottenPoison, short resistOfIllusoryPoison, bool hasNormalEatingEffect, bool instantAffect, short combatUseEffect, short combatPrepareUseEffect, bool isVirtual)
	{
		TemplateId = templateId;
		Name = name;
		ItemType = itemType;
		ItemSubType = itemSubType;
		Grade = grade;
		GroupId = groupId;
		Icon = icon;
		Desc = desc;
		FunctionDesc = functionDesc;
		SpecialEffectDesc = specialEffectDesc;
		SpecialEffectId = specialEffectId;
		Transferable = transferable;
		Stackable = stackable;
		Wagerable = wagerable;
		Refinable = refinable;
		Poisonable = poisonable;
		Repairable = repairable;
		Inheritable = inheritable;
		MaxDurability = maxDurability;
		BaseWeight = baseWeight;
		BaseValue = baseValue;
		MerchantLevel = merchantLevel;
		BaseHappinessChange = baseHappinessChange;
		BaseFavorabilityChange = baseFavorabilityChange;
		GiftLevel = giftLevel;
		AllowRandomCreate = allowRandomCreate;
		DropRate = dropRate;
		IsSpecial = isSpecial;
		ResourceType = resourceType;
		PreservationDuration = preservationDuration;
		CanUseMultiple = canUseMultiple;
		BreakBonusEffect = breakBonusEffect;
		TaskLock = taskLock;
		Duration = duration;
		EffectType = effectType;
		EffectSubType = effectSubType;
		EffectThresholdValue = effectThresholdValue;
		EffectValue = effectValue;
		SideEffectValue = sideEffectValue;
		InjuryRecoveryTimes = injuryRecoveryTimes;
		RequiredMainAttributeType = requiredMainAttributeType;
		RequiredMainAttributeValue = requiredMainAttributeValue;
		DamageStepBonus = damageStepBonus;
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
		WeaponSwitchSpeed = weaponSwitchSpeed;
		AttackSpeed = attackSpeed;
		InnerRatio = innerRatio;
		RecoveryOfQiDisorder = recoveryOfQiDisorder;
		WugType = wugType;
		WugGrowthType = wugGrowthType;
		SpecialEffectClass = specialEffectClass;
		ConsumedFeatureMedals = consumedFeatureMedals;
		MaxUseDistance = maxUseDistance;
		UseFrame = useFrame;
		BuffAndOtherMedicine = buffAndOtherMedicine;
		ResistOfHotPoison = resistOfHotPoison;
		ResistOfGloomyPoison = resistOfGloomyPoison;
		ResistOfColdPoison = resistOfColdPoison;
		ResistOfRedPoison = resistOfRedPoison;
		ResistOfRottenPoison = resistOfRottenPoison;
		ResistOfIllusoryPoison = resistOfIllusoryPoison;
		HasNormalEatingEffect = hasNormalEatingEffect;
		InstantAffect = instantAffect;
		CombatUseEffect = combatUseEffect;
		CombatPrepareUseEffect = combatPrepareUseEffect;
		IsVirtual = isVirtual;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public MedicineItem()
	{
		TemplateId = 0;
		Name = null;
		ItemType = 8;
		ItemSubType = 0;
		Grade = 0;
		GroupId = 0;
		Icon = null;
		Desc = null;
		FunctionDesc = null;
		SpecialEffectDesc = null;
		SpecialEffectId = 0;
		Transferable = true;
		Stackable = true;
		Wagerable = true;
		Refinable = false;
		Poisonable = true;
		Repairable = false;
		Inheritable = true;
		MaxDurability = 0;
		BaseWeight = 0;
		BaseValue = 15;
		MerchantLevel = 0;
		BaseHappinessChange = 0;
		BaseFavorabilityChange = 50;
		GiftLevel = 8;
		AllowRandomCreate = true;
		DropRate = 0;
		IsSpecial = false;
		ResourceType = 5;
		PreservationDuration = 36;
		CanUseMultiple = true;
		BreakBonusEffect = 0;
		TaskLock = new List<int>();
		Duration = 1;
		EffectType = EMedicineEffectType.Invalid;
		EffectSubType = EMedicineEffectSubType.Invalid;
		EffectThresholdValue = 0;
		EffectValue = 0;
		SideEffectValue = 0;
		InjuryRecoveryTimes = 0;
		RequiredMainAttributeType = -1;
		RequiredMainAttributeValue = 0;
		DamageStepBonus = 0;
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
		WeaponSwitchSpeed = 0;
		AttackSpeed = 0;
		InnerRatio = 0;
		RecoveryOfQiDisorder = 0;
		WugType = -1;
		WugGrowthType = -1;
		SpecialEffectClass = null;
		ConsumedFeatureMedals = -1;
		MaxUseDistance = -1;
		UseFrame = 60;
		BuffAndOtherMedicine = 0;
		ResistOfHotPoison = 0;
		ResistOfGloomyPoison = 0;
		ResistOfColdPoison = 0;
		ResistOfRedPoison = 0;
		ResistOfRottenPoison = 0;
		ResistOfIllusoryPoison = 0;
		HasNormalEatingEffect = true;
		InstantAffect = false;
		CombatUseEffect = 10;
		CombatPrepareUseEffect = 9;
		IsVirtual = false;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public MedicineItem(short templateId, MedicineItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		ItemType = other.ItemType;
		ItemSubType = other.ItemSubType;
		Grade = other.Grade;
		GroupId = other.GroupId;
		Icon = other.Icon;
		Desc = other.Desc;
		FunctionDesc = other.FunctionDesc;
		SpecialEffectDesc = other.SpecialEffectDesc;
		SpecialEffectId = other.SpecialEffectId;
		Transferable = other.Transferable;
		Stackable = other.Stackable;
		Wagerable = other.Wagerable;
		Refinable = other.Refinable;
		Poisonable = other.Poisonable;
		Repairable = other.Repairable;
		Inheritable = other.Inheritable;
		MaxDurability = other.MaxDurability;
		BaseWeight = other.BaseWeight;
		BaseValue = other.BaseValue;
		MerchantLevel = other.MerchantLevel;
		BaseHappinessChange = other.BaseHappinessChange;
		BaseFavorabilityChange = other.BaseFavorabilityChange;
		GiftLevel = other.GiftLevel;
		AllowRandomCreate = other.AllowRandomCreate;
		DropRate = other.DropRate;
		IsSpecial = other.IsSpecial;
		ResourceType = other.ResourceType;
		PreservationDuration = other.PreservationDuration;
		CanUseMultiple = other.CanUseMultiple;
		BreakBonusEffect = other.BreakBonusEffect;
		TaskLock = other.TaskLock;
		Duration = other.Duration;
		EffectType = other.EffectType;
		EffectSubType = other.EffectSubType;
		EffectThresholdValue = other.EffectThresholdValue;
		EffectValue = other.EffectValue;
		SideEffectValue = other.SideEffectValue;
		InjuryRecoveryTimes = other.InjuryRecoveryTimes;
		RequiredMainAttributeType = other.RequiredMainAttributeType;
		RequiredMainAttributeValue = other.RequiredMainAttributeValue;
		DamageStepBonus = other.DamageStepBonus;
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
		WeaponSwitchSpeed = other.WeaponSwitchSpeed;
		AttackSpeed = other.AttackSpeed;
		InnerRatio = other.InnerRatio;
		RecoveryOfQiDisorder = other.RecoveryOfQiDisorder;
		WugType = other.WugType;
		WugGrowthType = other.WugGrowthType;
		SpecialEffectClass = other.SpecialEffectClass;
		ConsumedFeatureMedals = other.ConsumedFeatureMedals;
		MaxUseDistance = other.MaxUseDistance;
		UseFrame = other.UseFrame;
		BuffAndOtherMedicine = other.BuffAndOtherMedicine;
		ResistOfHotPoison = other.ResistOfHotPoison;
		ResistOfGloomyPoison = other.ResistOfGloomyPoison;
		ResistOfColdPoison = other.ResistOfColdPoison;
		ResistOfRedPoison = other.ResistOfRedPoison;
		ResistOfRottenPoison = other.ResistOfRottenPoison;
		ResistOfIllusoryPoison = other.ResistOfIllusoryPoison;
		HasNormalEatingEffect = other.HasNormalEatingEffect;
		InstantAffect = other.InstantAffect;
		CombatUseEffect = other.CombatUseEffect;
		CombatPrepareUseEffect = other.CombatPrepareUseEffect;
		IsVirtual = other.IsVirtual;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override MedicineItem Duplicate(int templateId)
	{
		return new MedicineItem((short)templateId, this);
	}

	/// <summary>
	/// 获取CharacterProperty加成
	/// </summary>
	/// <param name="key"></param>
	public int GetCharacterPropertyBonusInt(ECharacterPropertyReferencedType key)
	{
		return key switch
		{
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
			ECharacterPropertyReferencedType.WeaponSwitchSpeed => WeaponSwitchSpeed, 
			ECharacterPropertyReferencedType.AttackSpeed => AttackSpeed, 
			ECharacterPropertyReferencedType.InnerRatio => InnerRatio, 
			ECharacterPropertyReferencedType.RecoveryOfQiDisorder => RecoveryOfQiDisorder, 
			ECharacterPropertyReferencedType.ResistOfHotPoison => ResistOfHotPoison, 
			ECharacterPropertyReferencedType.ResistOfGloomyPoison => ResistOfGloomyPoison, 
			ECharacterPropertyReferencedType.ResistOfColdPoison => ResistOfColdPoison, 
			ECharacterPropertyReferencedType.ResistOfRedPoison => ResistOfRedPoison, 
			ECharacterPropertyReferencedType.ResistOfRottenPoison => ResistOfRottenPoison, 
			ECharacterPropertyReferencedType.ResistOfIllusoryPoison => ResistOfIllusoryPoison, 
			_ => 0, 
		};
	}

	/// <summary>
	/// 获取药物效果的基础影响值，无参数时返回基础值或者百分比基础值，有参数时返回不受特效影响的效果值
	/// </summary>
	/// <param name="fullRangeValue">用于计算百分比效果值</param>
	/// <returns></returns>
	public int GetEffectValue(int fullRangeValue = 100)
	{
		return EMedicineEffectSubTypeExtension.EffectValue(fullRangeValue, EffectValue, EffectIsPercentage);
	}

	/// <summary>
	/// 获取固定值加成，不包括百分比加成
	/// 目前的实现中，毒素加成一定为数值加成，因此需要列出来单独处理
	///
	/// TODO: 修改CharacterProperty的相关定义，把BonusInt改成CValue
	/// </summary>
	/// <param name="key"></param>
	/// <returns></returns>
	public int GetCharacterPropertyBonusValue(ECharacterPropertyReferencedType key)
	{
		if (!EffectIsValue && key < ECharacterPropertyReferencedType.ResistOfHotPoison)
		{
			return 0;
		}
		return GetCharacterPropertyBonusInt(key);
	}

	/// <summary>
	/// 获取百分比加成数值，不包括固定值加成
	/// 目前的实现中，毒素加成一定为数值加成，因此需要列出来单独处理
	///
	/// TODO: 修改CharacterProperty的相关定义，把BonusInt改成CValue
	/// </summary>
	/// <param name="key"></param>
	/// <returns></returns>
	public int GetCharacterPropertyBonusPercentage(ECharacterPropertyReferencedType key)
	{
		bool flag = EffectIsPercentage;
		if (flag)
		{
			bool flag2 = ((key < ECharacterPropertyReferencedType.ResistOfHotPoison || key > ECharacterPropertyReferencedType.ResistOfIllusoryPoison) ? true : false);
			flag = flag2;
		}
		if (!flag)
		{
			return 0;
		}
		return GetCharacterPropertyBonusInt(key);
	}

	/// <summary>
	/// 是否含有加成
	/// </summary>
	/// <param name="key"></param>
	/// <returns></returns>
	public bool HasCharacterPropertyBonus(ECharacterPropertyReferencedType key)
	{
		if (key.TryParsePoisonResist(out var poisonType))
		{
			return DetoxPoisonType == poisonType;
		}
		return GetCharacterPropertyBonusInt(key) > 0;
	}
}

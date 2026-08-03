using System;
using System.Collections.Generic;
using Config.Common;
using GameData.Domains.Character;
using GameData.Utilities;

namespace Config;

/// <summary>
/// 食物
/// </summary>
[Serializable]
public class FoodItem : ConfigItem<FoodItem, short>, IItemConfig
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
	/// 大图标
	/// </summary>
	public readonly string BigIcon;

	/// <summary>
	/// 说明
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 功能说明
	/// </summary>
	public readonly string FunctionDesc;

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
	/// - 服食后在服食栏上存在的时间, 单位月.
	/// </summary>
	public readonly short Duration;

	/// <summary>
	/// 机略消耗
	/// - 战斗前使用时消耗的机略值. 为 -1 表示战斗前无法使用.
	/// </summary>
	public readonly sbyte ConsumedFeatureMedals;

	/// <summary>
	/// 主要属性恢复
	/// - 此字段自动生成, 实际配置字段为从 "膂力" 到 "悟性" 的 6 个字段.
	/// </summary>
	public readonly MainAttributes MainAttributesRegen;

	/// <summary>
	/// 膂力
	/// </summary>
	public readonly short Strength;

	/// <summary>
	/// 灵敏
	/// </summary>
	public readonly short Dexterity;

	/// <summary>
	/// 定力
	/// </summary>
	public readonly short Concentration;

	/// <summary>
	/// 体质
	/// </summary>
	public readonly short Vitality;

	/// <summary>
	/// 根骨
	/// </summary>
	public readonly short Energy;

	/// <summary>
	/// 悟性
	/// </summary>
	public readonly short Intelligence;

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
	/// 食物类型
	/// </summary>
	public readonly List<EFoodFoodType> FoodType;

	short IItemConfig.TemplateId => TemplateId;

	sbyte IItemConfig.ItemType => ItemType;

	short IItemConfig.ItemSubType => ItemSubType;

	string IItemConfig.Name => Name;

	string IItemConfig.Icon => Icon;

	sbyte IItemConfig.Grade => Grade;

	short IItemConfig.GroupId => GroupId;

	short IItemConfig.Duration => Duration;

	int IItemConfig.BaseValue => BaseValue;

	List<int> IItemConfig.TaskLock => TaskLock;

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
	/// <param name="bigIcon">大图标</param>
	/// <param name="desc">说明</param>
	/// <param name="functionDesc">功能说明</param>
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
	/// <param name="breakBonusEffect">玄机格效果 - 此物品提供的玄机格加成效果类型</param>
	/// <param name="taskLock">任务锁 - 当任务被启用时，禁止移动物品</param>
	/// <param name="duration">持续时间 - 服食后在服食栏上存在的时间, 单位月.</param>
	/// <param name="consumedFeatureMedals">机略消耗 - 战斗前使用时消耗的机略值. 为 -1 表示战斗前无法使用.</param>
	/// <param name="mainAttributesRegen">主要属性恢复 - 此字段自动生成, 实际配置字段为从 "膂力" 到 "悟性" 的 6 个字段.</param>
	/// <param name="strength">膂力</param>
	/// <param name="dexterity">灵敏</param>
	/// <param name="concentration">定力</param>
	/// <param name="vitality">体质</param>
	/// <param name="energy">根骨</param>
	/// <param name="intelligence">悟性</param>
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
	/// <param name="resistOfHotPoison">烈毒</param>
	/// <param name="resistOfGloomyPoison">郁毒</param>
	/// <param name="resistOfColdPoison">寒毒</param>
	/// <param name="resistOfRedPoison">赤毒</param>
	/// <param name="resistOfRottenPoison">腐毒</param>
	/// <param name="resistOfIllusoryPoison">幻毒</param>
	/// <param name="foodType">食物类型</param>
	public FoodItem(short templateId, string name, sbyte itemType, short itemSubType, sbyte grade, short groupId, string icon, string bigIcon, string desc, string functionDesc, bool transferable, bool stackable, bool wagerable, bool refinable, bool poisonable, bool repairable, bool inheritable, short maxDurability, int baseWeight, int baseValue, sbyte merchantLevel, sbyte baseHappinessChange, int baseFavorabilityChange, sbyte giftLevel, bool allowRandomCreate, sbyte dropRate, bool isSpecial, sbyte resourceType, short preservationDuration, sbyte breakBonusEffect, List<int> taskLock, short duration, sbyte consumedFeatureMedals, MainAttributes mainAttributesRegen, short strength, short dexterity, short concentration, short vitality, short energy, short intelligence, short hitRateStrength, short hitRateTechnique, short hitRateSpeed, short hitRateMind, short penetrateOfOuter, short penetrateOfInner, short avoidRateStrength, short avoidRateTechnique, short avoidRateSpeed, short avoidRateMind, short penetrateResistOfOuter, short penetrateResistOfInner, short recoveryOfStance, short recoveryOfBreath, short moveSpeed, short recoveryOfFlaw, short castSpeed, short recoveryOfBlockedAcupoint, short weaponSwitchSpeed, short attackSpeed, short innerRatio, short recoveryOfQiDisorder, short resistOfHotPoison, short resistOfGloomyPoison, short resistOfColdPoison, short resistOfRedPoison, short resistOfRottenPoison, short resistOfIllusoryPoison, List<EFoodFoodType> foodType)
	{
		TemplateId = templateId;
		Name = name;
		ItemType = itemType;
		ItemSubType = itemSubType;
		Grade = grade;
		GroupId = groupId;
		Icon = icon;
		BigIcon = bigIcon;
		Desc = desc;
		FunctionDesc = functionDesc;
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
		BreakBonusEffect = breakBonusEffect;
		TaskLock = taskLock;
		Duration = duration;
		ConsumedFeatureMedals = consumedFeatureMedals;
		MainAttributesRegen = mainAttributesRegen;
		Strength = strength;
		Dexterity = dexterity;
		Concentration = concentration;
		Vitality = vitality;
		Energy = energy;
		Intelligence = intelligence;
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
		ResistOfHotPoison = resistOfHotPoison;
		ResistOfGloomyPoison = resistOfGloomyPoison;
		ResistOfColdPoison = resistOfColdPoison;
		ResistOfRedPoison = resistOfRedPoison;
		ResistOfRottenPoison = resistOfRottenPoison;
		ResistOfIllusoryPoison = resistOfIllusoryPoison;
		FoodType = foodType;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public FoodItem()
	{
		TemplateId = 0;
		Name = null;
		ItemType = 7;
		ItemSubType = 0;
		Grade = 0;
		GroupId = 0;
		Icon = null;
		BigIcon = null;
		Desc = null;
		FunctionDesc = null;
		Transferable = true;
		Stackable = true;
		Wagerable = true;
		Refinable = false;
		Poisonable = true;
		Repairable = false;
		Inheritable = true;
		MaxDurability = 0;
		BaseWeight = 0;
		BaseValue = 5;
		MerchantLevel = 0;
		BaseHappinessChange = 0;
		BaseFavorabilityChange = 100;
		GiftLevel = 8;
		AllowRandomCreate = true;
		DropRate = 0;
		IsSpecial = false;
		ResourceType = 0;
		PreservationDuration = 3;
		BreakBonusEffect = 0;
		TaskLock = new List<int>();
		Duration = 1;
		ConsumedFeatureMedals = 1;
		MainAttributesRegen = new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short));
		Strength = 0;
		Dexterity = 0;
		Concentration = 0;
		Vitality = 0;
		Energy = 0;
		Intelligence = 0;
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
		ResistOfHotPoison = 0;
		ResistOfGloomyPoison = 0;
		ResistOfColdPoison = 0;
		ResistOfRedPoison = 0;
		ResistOfRottenPoison = 0;
		ResistOfIllusoryPoison = 0;
		FoodType = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public FoodItem(short templateId, FoodItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		ItemType = other.ItemType;
		ItemSubType = other.ItemSubType;
		Grade = other.Grade;
		GroupId = other.GroupId;
		Icon = other.Icon;
		BigIcon = other.BigIcon;
		Desc = other.Desc;
		FunctionDesc = other.FunctionDesc;
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
		BreakBonusEffect = other.BreakBonusEffect;
		TaskLock = other.TaskLock;
		Duration = other.Duration;
		ConsumedFeatureMedals = other.ConsumedFeatureMedals;
		MainAttributesRegen = other.MainAttributesRegen;
		Strength = other.Strength;
		Dexterity = other.Dexterity;
		Concentration = other.Concentration;
		Vitality = other.Vitality;
		Energy = other.Energy;
		Intelligence = other.Intelligence;
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
		ResistOfHotPoison = other.ResistOfHotPoison;
		ResistOfGloomyPoison = other.ResistOfGloomyPoison;
		ResistOfColdPoison = other.ResistOfColdPoison;
		ResistOfRedPoison = other.ResistOfRedPoison;
		ResistOfRottenPoison = other.ResistOfRottenPoison;
		ResistOfIllusoryPoison = other.ResistOfIllusoryPoison;
		FoodType = other.FoodType;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override FoodItem Duplicate(int templateId)
	{
		return new FoodItem((short)templateId, this);
	}

	/// <summary>
	/// 获取CharacterProperty加成
	/// </summary>
	/// <param name="key"></param>
	public int GetCharacterPropertyBonusInt(ECharacterPropertyReferencedType key)
	{
		return key switch
		{
			ECharacterPropertyReferencedType.Strength => Strength, 
			ECharacterPropertyReferencedType.Dexterity => Dexterity, 
			ECharacterPropertyReferencedType.Concentration => Concentration, 
			ECharacterPropertyReferencedType.Vitality => Vitality, 
			ECharacterPropertyReferencedType.Energy => Energy, 
			ECharacterPropertyReferencedType.Intelligence => Intelligence, 
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
}

using System;
using System.Collections.Generic;
using Config.Common;
using Config.ConfigCells.Character;
using GameData.Domains.Character;
using GameData.Utilities;

namespace Config;

/// <summary>
/// 防具
/// </summary>
[Serializable]
public class ArmorItem : ConfigItem<ArmorItem, short>, IItemConfig
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
	/// 可卸除
	/// - 已装备的物品是否可被卸除到行囊中
	/// </summary>
	public readonly bool Detachable;

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
	/// - 让渡后的好感变化基础值，最终值需要加上装备特效的影响
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
	/// 允许进行生铸
	/// - 同时禁止作为源和目标，禁止作为源时为软限制，可在生铸界面看到对应禁用原因
	/// </summary>
	public readonly bool AllowRawCreate;

	/// <summary>
	/// 允许进行残铸
	/// - 仅影响架海神杖选择残铸目标
	/// </summary>
	public readonly bool AllowCrippledCreate;

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
	/// 制造类型
	/// </summary>
	public readonly short MakeItemSubType;

	/// <summary>
	/// 任务锁
	/// - 当任务被启用时，禁止移动物品
	/// </summary>
	public readonly List<int> TaskLock;

	/// <summary>
	/// 装备类型
	/// - GameData.Domains.Character.EquipmentType
	/// </summary>
	public readonly sbyte EquipmentType;

	/// <summary>
	/// 装备效果
	/// - 装备词条 ID
	/// </summary>
	public readonly short EquipmentEffectId;

	/// <summary>
	/// 武具效果
	/// - 武具效果 ID
	/// </summary>
	public readonly short EquipmentMasteryId;

	/// <summary>
	/// 破刃
	/// </summary>
	public readonly short BaseEquipmentAttack;

	/// <summary>
	/// 坚韧
	/// </summary>
	public readonly short BaseEquipmentDefense;

	/// <summary>
	/// 角色属性需求
	/// </summary>
	public readonly List<PropertyAndValue> RequiredCharacterProperties;

	/// <summary>
	/// 化解因子
	/// - 此字段自动生成, 实际配置字段为从 "卸力" 到 "守心" 的 4 个字段.
	/// </summary>
	public readonly HitOrAvoidShorts BaseAvoidFactors;

	/// <summary>
	/// 防御因子
	/// - 此字段自动生成, 实际配置字段为从 "御体" 到 "御气" 的 2 个字段.
	/// </summary>
	public readonly OuterAndInnerShorts BasePenetrationResistFactors;

	/// <summary>
	/// 减伤因子
	/// </summary>
	public readonly OuterAndInnerShorts BaseInjuryFactors;

	/// <summary>
	/// 关联的武器
	/// - 用于鞋类防具使用腿法时使用武器的配置数据
	/// </summary>
	public readonly short RelatedWeapon;

	/// <summary>
	/// 人物骨骼动画插槽和附件
	/// - 格式{插槽1,附件1,插槽2,附件2...}
	/// </summary>
	public readonly List<string> SkeletonSlotAndAttachment;

	/// <summary>
	/// 装备的战斗力比例系数
	/// - NPC装备此装备时，战斗力增加 GlobalConfig.CombatPower[equipIndex] * EquipmentCombatPowerValueFactor / 100
	/// </summary>
	public readonly short EquipmentCombatPowerValueFactor;

	short IItemConfig.TemplateId => TemplateId;

	sbyte IItemConfig.ItemType => ItemType;

	short IItemConfig.ItemSubType => ItemSubType;

	string IItemConfig.Name => Name;

	string IItemConfig.Icon => Icon;

	sbyte IItemConfig.Grade => Grade;

	short IItemConfig.GroupId => GroupId;

	int IItemConfig.BaseValue => BaseValue;

	int IItemConfig.EquipmentMasteryId => EquipmentMasteryId;

	List<int> IItemConfig.TaskLock => TaskLock;

	short IItemConfig.MakeItemSubType => MakeItemSubType;

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
	/// <param name="transferable">可让渡</param>
	/// <param name="stackable">可堆叠</param>
	/// <param name="wagerable">可押注</param>
	/// <param name="refinable">可精制</param>
	/// <param name="poisonable">可淬毒</param>
	/// <param name="repairable">可修理 - 同时控制是否会在耐久耗尽时自动销毁</param>
	/// <param name="inheritable">可梦回</param>
	/// <param name="detachable">可卸除 - 已装备的物品是否可被卸除到行囊中</param>
	/// <param name="maxDurability">最大耐久 - 为正值在生成时会有浮动, 为负值则固定不变</param>
	/// <param name="baseWeight">重量</param>
	/// <param name="baseValue">基础价值</param>
	/// <param name="merchantLevel">商会等级 - 此物品售出时，可偿还哪个商店等级及以下的欠下数量（商店等级为0~6）</param>
	/// <param name="baseHappinessChange">基础心情变化 - 让渡后的基础心情变化</param>
	/// <param name="baseFavorabilityChange">基础好感变化 - 让渡后的好感变化基础值，最终值需要加上装备特效的影响</param>
	/// <param name="giftLevel">礼物级别 - &gt;此级别的人物不会接受此礼物</param>
	/// <param name="allowRandomCreate">允许随机生成</param>
	/// <param name="allowRawCreate">允许进行生铸 - 同时禁止作为源和目标，禁止作为源时为软限制，可在生铸界面看到对应禁用原因</param>
	/// <param name="allowCrippledCreate">允许进行残铸 - 仅影响架海神杖选择残铸目标</param>
	/// <param name="dropRate">掉落率 - 取值范围 [0, 100]</param>
	/// <param name="isSpecial">特殊物品 - 0为正常物品，1为特殊物品，在某些情况下的筛选需要排除（例如太吾村商人指定物品行为）</param>
	/// <param name="resourceType">材质 - 对应的资源类型</param>
	/// <param name="preservationDuration">保存时间 - 无主物品的可保存时间, 超过时间会损毁. 单位为月.</param>
	/// <param name="makeItemSubType">制造类型</param>
	/// <param name="taskLock">任务锁 - 当任务被启用时，禁止移动物品</param>
	/// <param name="equipmentType">装备类型 - GameData.Domains.Character.EquipmentType</param>
	/// <param name="equipmentEffectId">装备效果 - 装备词条 ID</param>
	/// <param name="equipmentMasteryId">武具效果 - 武具效果 ID</param>
	/// <param name="baseEquipmentAttack">破刃</param>
	/// <param name="baseEquipmentDefense">坚韧</param>
	/// <param name="requiredCharacterProperties">角色属性需求</param>
	/// <param name="baseAvoidFactors">化解因子 - 此字段自动生成, 实际配置字段为从 "卸力" 到 "守心" 的 4 个字段.</param>
	/// <param name="basePenetrationResistFactors">防御因子 - 此字段自动生成, 实际配置字段为从 "御体" 到 "御气" 的 2 个字段.</param>
	/// <param name="baseInjuryFactors">减伤因子</param>
	/// <param name="relatedWeapon">关联的武器 - 用于鞋类防具使用腿法时使用武器的配置数据</param>
	/// <param name="skeletonSlotAndAttachment">人物骨骼动画插槽和附件 - 格式{插槽1,附件1,插槽2,附件2...}</param>
	/// <param name="equipmentCombatPowerValueFactor">装备的战斗力比例系数 - NPC装备此装备时，战斗力增加 GlobalConfig.CombatPower[equipIndex] * EquipmentCombatPowerValueFactor / 100</param>
	public ArmorItem(short templateId, string name, sbyte itemType, short itemSubType, sbyte grade, short groupId, string icon, string desc, string functionDesc, bool transferable, bool stackable, bool wagerable, bool refinable, bool poisonable, bool repairable, bool inheritable, bool detachable, short maxDurability, int baseWeight, int baseValue, sbyte merchantLevel, sbyte baseHappinessChange, int baseFavorabilityChange, sbyte giftLevel, bool allowRandomCreate, bool allowRawCreate, bool allowCrippledCreate, sbyte dropRate, bool isSpecial, sbyte resourceType, short preservationDuration, short makeItemSubType, List<int> taskLock, sbyte equipmentType, short equipmentEffectId, short equipmentMasteryId, short baseEquipmentAttack, short baseEquipmentDefense, List<PropertyAndValue> requiredCharacterProperties, HitOrAvoidShorts baseAvoidFactors, OuterAndInnerShorts basePenetrationResistFactors, OuterAndInnerShorts baseInjuryFactors, short relatedWeapon, List<string> skeletonSlotAndAttachment, short equipmentCombatPowerValueFactor)
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
		Transferable = transferable;
		Stackable = stackable;
		Wagerable = wagerable;
		Refinable = refinable;
		Poisonable = poisonable;
		Repairable = repairable;
		Inheritable = inheritable;
		Detachable = detachable;
		MaxDurability = maxDurability;
		BaseWeight = baseWeight;
		BaseValue = baseValue;
		MerchantLevel = merchantLevel;
		BaseHappinessChange = baseHappinessChange;
		BaseFavorabilityChange = baseFavorabilityChange;
		GiftLevel = giftLevel;
		AllowRandomCreate = allowRandomCreate;
		AllowRawCreate = allowRawCreate;
		AllowCrippledCreate = allowCrippledCreate;
		DropRate = dropRate;
		IsSpecial = isSpecial;
		ResourceType = resourceType;
		PreservationDuration = preservationDuration;
		MakeItemSubType = makeItemSubType;
		TaskLock = taskLock;
		EquipmentType = equipmentType;
		EquipmentEffectId = equipmentEffectId;
		EquipmentMasteryId = equipmentMasteryId;
		BaseEquipmentAttack = baseEquipmentAttack;
		BaseEquipmentDefense = baseEquipmentDefense;
		RequiredCharacterProperties = requiredCharacterProperties;
		BaseAvoidFactors = baseAvoidFactors;
		BasePenetrationResistFactors = basePenetrationResistFactors;
		BaseInjuryFactors = baseInjuryFactors;
		RelatedWeapon = relatedWeapon;
		SkeletonSlotAndAttachment = skeletonSlotAndAttachment;
		EquipmentCombatPowerValueFactor = equipmentCombatPowerValueFactor;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public ArmorItem()
	{
		TemplateId = 0;
		Name = null;
		ItemType = 1;
		ItemSubType = 0;
		Grade = 0;
		GroupId = 0;
		Icon = null;
		Desc = null;
		FunctionDesc = null;
		Transferable = true;
		Stackable = false;
		Wagerable = true;
		Refinable = true;
		Poisonable = true;
		Repairable = true;
		Inheritable = true;
		Detachable = true;
		MaxDurability = 0;
		BaseWeight = 0;
		BaseValue = 20;
		MerchantLevel = 0;
		BaseHappinessChange = 0;
		BaseFavorabilityChange = 150;
		GiftLevel = 8;
		AllowRandomCreate = true;
		AllowRawCreate = true;
		AllowCrippledCreate = true;
		DropRate = 0;
		IsSpecial = false;
		ResourceType = 0;
		PreservationDuration = 36;
		MakeItemSubType = 0;
		TaskLock = new List<int>();
		EquipmentType = 0;
		EquipmentEffectId = 0;
		EquipmentMasteryId = 0;
		BaseEquipmentAttack = 0;
		BaseEquipmentDefense = 0;
		RequiredCharacterProperties = new List<PropertyAndValue>();
		BaseAvoidFactors = new HitOrAvoidShorts(default(short), default(short), default(short), default(short));
		BasePenetrationResistFactors = new OuterAndInnerShorts(0, 0);
		BaseInjuryFactors = new OuterAndInnerShorts(0, 0);
		RelatedWeapon = 0;
		SkeletonSlotAndAttachment = null;
		EquipmentCombatPowerValueFactor = 100;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public ArmorItem(short templateId, ArmorItem other)
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
		Transferable = other.Transferable;
		Stackable = other.Stackable;
		Wagerable = other.Wagerable;
		Refinable = other.Refinable;
		Poisonable = other.Poisonable;
		Repairable = other.Repairable;
		Inheritable = other.Inheritable;
		Detachable = other.Detachable;
		MaxDurability = other.MaxDurability;
		BaseWeight = other.BaseWeight;
		BaseValue = other.BaseValue;
		MerchantLevel = other.MerchantLevel;
		BaseHappinessChange = other.BaseHappinessChange;
		BaseFavorabilityChange = other.BaseFavorabilityChange;
		GiftLevel = other.GiftLevel;
		AllowRandomCreate = other.AllowRandomCreate;
		AllowRawCreate = other.AllowRawCreate;
		AllowCrippledCreate = other.AllowCrippledCreate;
		DropRate = other.DropRate;
		IsSpecial = other.IsSpecial;
		ResourceType = other.ResourceType;
		PreservationDuration = other.PreservationDuration;
		MakeItemSubType = other.MakeItemSubType;
		TaskLock = other.TaskLock;
		EquipmentType = other.EquipmentType;
		EquipmentEffectId = other.EquipmentEffectId;
		EquipmentMasteryId = other.EquipmentMasteryId;
		BaseEquipmentAttack = other.BaseEquipmentAttack;
		BaseEquipmentDefense = other.BaseEquipmentDefense;
		RequiredCharacterProperties = other.RequiredCharacterProperties;
		BaseAvoidFactors = other.BaseAvoidFactors;
		BasePenetrationResistFactors = other.BasePenetrationResistFactors;
		BaseInjuryFactors = other.BaseInjuryFactors;
		RelatedWeapon = other.RelatedWeapon;
		SkeletonSlotAndAttachment = other.SkeletonSlotAndAttachment;
		EquipmentCombatPowerValueFactor = other.EquipmentCombatPowerValueFactor;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override ArmorItem Duplicate(int templateId)
	{
		return new ArmorItem((short)templateId, this);
	}
}

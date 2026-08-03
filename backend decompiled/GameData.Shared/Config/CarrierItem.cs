using System;
using System.Collections.Generic;
using Config.Common;
using GameData.Domains.Item;
using GameData.Utilities;

namespace Config;

/// <summary>
/// 代步
/// </summary>
[Serializable]
public class CarrierItem : ConfigItem<CarrierItem, short>, IItemConfig
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
	/// 基础旅行时间减少
	/// - 旅行时间减少百分比
	/// </summary>
	public readonly sbyte BaseTravelTimeReduction;

	/// <summary>
	/// 基础最大行囊负重加成
	/// </summary>
	public readonly short BaseMaxInventoryLoadBonus;

	/// <summary>
	/// 基础最大劫持软上限加成
	/// </summary>
	public readonly short BaseMaxKidnapSlotCountBonus;

	/// <summary>
	/// 基础掉落率加成
	/// - 装备后对其他物品的掉落率加成的影响
	/// </summary>
	public readonly short BaseDropRateBonus;

	/// <summary>
	/// 基础降伏机率加成
	/// - 绳索捕捉成功概率加成
	/// </summary>
	public readonly short BaseCaptureRateBonus;

	/// <summary>
	/// 探索的奖励
	/// - 地图拾取物奖励升级的概率
	/// </summary>
	public readonly short BaseExploreBonusRate;

	/// <summary>
	/// 出战角色
	/// - 目前仅用于猎户技能，当动物可以施展普攻时需配置出战时创建的角色 ID，该角色必须是固定敌人（生成方式 3）
	/// </summary>
	public readonly short CharacterIdInCombat;

	/// <summary>
	/// 驭使效果
	/// </summary>
	public readonly short CombatState;

	/// <summary>
	/// 驭使赋性
	/// - 满驯服度时提供的赋性加成
	/// </summary>
	public readonly sbyte[] TamePersonalities;

	/// <summary>
	/// 是否飞行
	/// </summary>
	public readonly bool IsFlying;

	/// <summary>
	/// 是否可被驯服
	/// - 0 == 需要被驯服，-1==不需要被驯服
	/// </summary>
	public readonly sbyte TamePoint;

	/// <summary>
	/// 喜好的食物类型
	/// - 喜恶食物列填写Material表中物品子类为500、品级为0的食物：鸡蛋、野兔、小麦、草鱼
	/// </summary>
	public readonly List<short> LoveFoodType;

	/// <summary>
	/// 厌恶的食物类型
	/// </summary>
	public readonly List<short> HateFoodType;

	/// <summary>
	/// 悬停展示立绘
	/// </summary>
	public readonly string StandDisplay;

	/// <summary>
	/// 旅行模型
	/// </summary>
	public readonly short TravelSkeleton;

	/// <summary>
	/// 自身带毒
	/// - 此字段自动生成, 实际配置字段为从 "烈值" 到 "幻等" 的 12 个字段.
	/// </summary>
	public readonly PoisonsAndLevels InnatePoisons;

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
	/// <param name="baseFavorabilityChange">基础好感变化 - 让渡后的好感变化基础值，最终值需要加上特殊效果的影响</param>
	/// <param name="giftLevel">礼物级别 - &gt;此级别的人物不会接受此礼物</param>
	/// <param name="allowRandomCreate">允许随机生成</param>
	/// <param name="dropRate">掉落率 - 取值范围 [0, 100]</param>
	/// <param name="isSpecial">特殊物品 - 0为正常物品，1为特殊物品，在某些情况下的筛选需要排除（例如太吾村商人指定物品行为）</param>
	/// <param name="resourceType">材质 - 对应的资源类型</param>
	/// <param name="preservationDuration">保存时间 - 无主物品的可保存时间, 超过时间会损毁. 单位为月.</param>
	/// <param name="makeItemSubType">制造类型</param>
	/// <param name="taskLock">任务锁 - 当任务被启用时，禁止移动物品</param>
	/// <param name="equipmentType">装备类型 - GameData.Domains.Character.EquipmentType</param>
	/// <param name="equipmentEffectId">装备效果 - 装备词条 ID</param>
	/// <param name="baseTravelTimeReduction">基础旅行时间减少 - 旅行时间减少百分比</param>
	/// <param name="baseMaxInventoryLoadBonus">基础最大行囊负重加成</param>
	/// <param name="baseMaxKidnapSlotCountBonus">基础最大劫持软上限加成</param>
	/// <param name="baseDropRateBonus">基础掉落率加成 - 装备后对其他物品的掉落率加成的影响</param>
	/// <param name="baseCaptureRateBonus">基础降伏机率加成 - 绳索捕捉成功概率加成</param>
	/// <param name="baseExploreBonusRate">探索的奖励 - 地图拾取物奖励升级的概率</param>
	/// <param name="characterIdInCombat">出战角色 - 目前仅用于猎户技能，当动物可以施展普攻时需配置出战时创建的角色 ID，该角色必须是固定敌人（生成方式 3）</param>
	/// <param name="combatState">驭使效果</param>
	/// <param name="tamePersonalities">驭使赋性 - 满驯服度时提供的赋性加成</param>
	/// <param name="isFlying">是否飞行</param>
	/// <param name="tamePoint">是否可被驯服 - 0 == 需要被驯服，-1==不需要被驯服</param>
	/// <param name="loveFoodType">喜好的食物类型 - 喜恶食物列填写Material表中物品子类为500、品级为0的食物：鸡蛋、野兔、小麦、草鱼</param>
	/// <param name="hateFoodType">厌恶的食物类型</param>
	/// <param name="standDisplay">悬停展示立绘</param>
	/// <param name="travelSkeleton">旅行模型</param>
	/// <param name="innatePoisons">自身带毒 - 此字段自动生成, 实际配置字段为从 "烈值" 到 "幻等" 的 12 个字段.</param>
	/// <param name="equipmentCombatPowerValueFactor">装备的战斗力比例系数 - NPC装备此装备时，战斗力增加 GlobalConfig.CombatPower[equipIndex] * EquipmentCombatPowerValueFactor / 100</param>
	public CarrierItem(short templateId, string name, sbyte itemType, short itemSubType, sbyte grade, short groupId, string icon, string desc, string functionDesc, bool transferable, bool stackable, bool wagerable, bool refinable, bool poisonable, bool repairable, bool inheritable, bool detachable, short maxDurability, int baseWeight, int baseValue, sbyte merchantLevel, sbyte baseHappinessChange, int baseFavorabilityChange, sbyte giftLevel, bool allowRandomCreate, sbyte dropRate, bool isSpecial, sbyte resourceType, short preservationDuration, short makeItemSubType, List<int> taskLock, sbyte equipmentType, short equipmentEffectId, sbyte baseTravelTimeReduction, short baseMaxInventoryLoadBonus, short baseMaxKidnapSlotCountBonus, short baseDropRateBonus, short baseCaptureRateBonus, short baseExploreBonusRate, short characterIdInCombat, short combatState, sbyte[] tamePersonalities, bool isFlying, sbyte tamePoint, List<short> loveFoodType, List<short> hateFoodType, string standDisplay, short travelSkeleton, PoisonsAndLevels innatePoisons, short equipmentCombatPowerValueFactor)
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
		DropRate = dropRate;
		IsSpecial = isSpecial;
		ResourceType = resourceType;
		PreservationDuration = preservationDuration;
		MakeItemSubType = makeItemSubType;
		TaskLock = taskLock;
		EquipmentType = equipmentType;
		EquipmentEffectId = equipmentEffectId;
		BaseTravelTimeReduction = baseTravelTimeReduction;
		BaseMaxInventoryLoadBonus = baseMaxInventoryLoadBonus;
		BaseMaxKidnapSlotCountBonus = baseMaxKidnapSlotCountBonus;
		BaseDropRateBonus = baseDropRateBonus;
		BaseCaptureRateBonus = baseCaptureRateBonus;
		BaseExploreBonusRate = baseExploreBonusRate;
		CharacterIdInCombat = characterIdInCombat;
		CombatState = combatState;
		TamePersonalities = tamePersonalities;
		IsFlying = isFlying;
		TamePoint = tamePoint;
		LoveFoodType = loveFoodType;
		HateFoodType = hateFoodType;
		StandDisplay = standDisplay;
		TravelSkeleton = travelSkeleton;
		InnatePoisons = innatePoisons;
		EquipmentCombatPowerValueFactor = equipmentCombatPowerValueFactor;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public CarrierItem()
	{
		TemplateId = 0;
		Name = null;
		ItemType = 4;
		ItemSubType = 0;
		Grade = 0;
		GroupId = 0;
		Icon = null;
		Desc = null;
		FunctionDesc = null;
		Transferable = true;
		Stackable = false;
		Wagerable = true;
		Refinable = false;
		Poisonable = false;
		Repairable = false;
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
		DropRate = 0;
		IsSpecial = false;
		ResourceType = 0;
		PreservationDuration = 36;
		MakeItemSubType = 0;
		TaskLock = new List<int>();
		EquipmentType = 7;
		EquipmentEffectId = 0;
		BaseTravelTimeReduction = 0;
		BaseMaxInventoryLoadBonus = 0;
		BaseMaxKidnapSlotCountBonus = 0;
		BaseDropRateBonus = 0;
		BaseCaptureRateBonus = 0;
		BaseExploreBonusRate = 0;
		CharacterIdInCombat = 0;
		CombatState = 0;
		TamePersonalities = new sbyte[7];
		IsFlying = false;
		TamePoint = -1;
		LoveFoodType = null;
		HateFoodType = null;
		StandDisplay = null;
		TravelSkeleton = 0;
		InnatePoisons = new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short));
		EquipmentCombatPowerValueFactor = 0;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public CarrierItem(short templateId, CarrierItem other)
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
		DropRate = other.DropRate;
		IsSpecial = other.IsSpecial;
		ResourceType = other.ResourceType;
		PreservationDuration = other.PreservationDuration;
		MakeItemSubType = other.MakeItemSubType;
		TaskLock = other.TaskLock;
		EquipmentType = other.EquipmentType;
		EquipmentEffectId = other.EquipmentEffectId;
		BaseTravelTimeReduction = other.BaseTravelTimeReduction;
		BaseMaxInventoryLoadBonus = other.BaseMaxInventoryLoadBonus;
		BaseMaxKidnapSlotCountBonus = other.BaseMaxKidnapSlotCountBonus;
		BaseDropRateBonus = other.BaseDropRateBonus;
		BaseCaptureRateBonus = other.BaseCaptureRateBonus;
		BaseExploreBonusRate = other.BaseExploreBonusRate;
		CharacterIdInCombat = other.CharacterIdInCombat;
		CombatState = other.CombatState;
		TamePersonalities = other.TamePersonalities;
		IsFlying = other.IsFlying;
		TamePoint = other.TamePoint;
		LoveFoodType = other.LoveFoodType;
		HateFoodType = other.HateFoodType;
		StandDisplay = other.StandDisplay;
		TravelSkeleton = other.TravelSkeleton;
		InnatePoisons = other.InnatePoisons;
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
	public override CarrierItem Duplicate(int templateId)
	{
		return new CarrierItem((short)templateId, this);
	}
}

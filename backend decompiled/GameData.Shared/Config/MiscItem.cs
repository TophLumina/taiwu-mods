using System;
using System.Collections.Generic;
using Config.Common;
using GameData.Domains.Extra;
using GameData.Utilities;

namespace Config;

/// <summary>
/// 杂物
/// </summary>
[Serializable]
public class MiscItem : ConfigItem<MiscItem, short>, ICombatItemConfig, IItemConfig
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
	/// 可消耗
	/// - 控制战中使用该物品是否会从可使用物品中移除（非杂物默认会移除）
	/// </summary>
	public readonly bool Consumable;

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
	/// 制造类型
	/// </summary>
	public readonly short MakeItemSubType;

	/// <summary>
	/// 保存时间
	/// - 无主物品的可保存时间, 超过时间会损毁. 单位为月.
	/// </summary>
	public readonly short PreservationDuration;

	/// <summary>
	/// 任务锁
	/// - 当任务被启用时，禁止移动物品
	/// </summary>
	public readonly List<int> TaskLock;

	/// <summary>
	/// 玄机格效果
	/// - 此物品提供的玄机格加成效果类型
	/// </summary>
	public readonly sbyte BreakBonusEffect;

	/// <summary>
	/// 内力恢复
	/// - 使用后可恢复内力
	/// </summary>
	public readonly short Neili;

	/// <summary>
	/// 最大内力增加
	/// </summary>
	public readonly int MaxNeili;

	/// <summary>
	/// 内力五行转移
	/// - 类型，百分比
	/// </summary>
	public readonly IntPair FiveElementTransfer;

	/// <summary>
	/// 促织恢复时疗伤概率
	/// </summary>
	public readonly sbyte CricketHealInjuryOdds;

	/// <summary>
	/// 降低俘虏逃跑概率
	/// </summary>
	public readonly short ReduceEscapeRate;

	/// <summary>
	/// 机略消耗
	/// - 战斗前使用时消耗的机略值. 为 -1 表示战斗中无法使用.
	/// </summary>
	public readonly sbyte ConsumedFeatureMedals;

	/// <summary>
	/// 战斗准备时是否允许在人物行囊使用
	/// - 0为不可用，1为可用
	/// </summary>
	public readonly bool CanUseOnPrepareCombat;

	/// <summary>
	/// 允许在切磋与接招战使用
	/// </summary>
	public readonly bool AllowUseInPlayAndTest;

	/// <summary>
	/// 可触发通用使用事件
	/// </summary>
	public readonly bool CanTriggerCommonEvent;

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
	/// 所需战斗配置
	/// - 填空则不限制战斗配置
	/// </summary>
	public readonly List<short> RequireCombatConfig;

	/// <summary>
	/// 允许的毁坏地格级别
	/// - 范围从 1~6
	/// </summary>
	public readonly List<int> AllowBrokenLevels;

	/// <summary>
	/// 生成类型
	/// - 对应存档修复的版本号，子表中较高版本应排在下面
	/// </summary>
	public readonly EMiscGenerateType GenerateType;

	/// <summary>
	/// 各州域分布数量
	/// </summary>
	public readonly List<TreasureStateInfo> StateBuryAmount;

	/// <summary>
	/// 资源心材类别
	/// </summary>
	public readonly EMiscResourceMaterialType ResourceMaterialType;

	/// <summary>
	/// 筛选类别
	/// - 筛选类别用于筛选，一般一个筛选类别可以包括多个同子类的杂物。
	/// </summary>
	public readonly EMiscFilterType FilterType;

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
	/// 获得历练
	/// </summary>
	public readonly int GainExp;

	/// <summary>
	/// 资源数量
	/// - 销毁后可获得的资源数量
	/// </summary>
	public readonly short ResourceAmount;

	/// <summary>
	/// 转赠时触发事件
	/// </summary>
	public readonly bool HasGiftEvent;

	int ICombatItemConfig.ConsumedFeatureMedals => ConsumedFeatureMedals;

	int ICombatItemConfig.UseFrame => UseFrame;

	bool ICombatItemConfig.AllowUseInPlayAndTest => AllowUseInPlayAndTest;

	short IItemConfig.TemplateId => TemplateId;

	sbyte IItemConfig.ItemType => ItemType;

	short IItemConfig.ItemSubType => ItemSubType;

	string IItemConfig.Name => Name;

	string IItemConfig.Icon => Icon;

	sbyte IItemConfig.Grade => Grade;

	short IItemConfig.GroupId => GroupId;

	sbyte IItemConfig.MaxUseDistance => MaxUseDistance;

	short IItemConfig.Duration => 0;

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
	/// <param name="consumable">可消耗 - 控制战中使用该物品是否会从可使用物品中移除（非杂物默认会移除）</param>
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
	/// <param name="makeItemSubType">制造类型</param>
	/// <param name="preservationDuration">保存时间 - 无主物品的可保存时间, 超过时间会损毁. 单位为月.</param>
	/// <param name="taskLock">任务锁 - 当任务被启用时，禁止移动物品</param>
	/// <param name="breakBonusEffect">玄机格效果 - 此物品提供的玄机格加成效果类型</param>
	/// <param name="neili">内力恢复 - 使用后可恢复内力</param>
	/// <param name="maxNeili">最大内力增加</param>
	/// <param name="fiveElementTransfer">内力五行转移 - 类型，百分比</param>
	/// <param name="cricketHealInjuryOdds">促织恢复时疗伤概率</param>
	/// <param name="reduceEscapeRate">降低俘虏逃跑概率</param>
	/// <param name="consumedFeatureMedals">机略消耗 - 战斗前使用时消耗的机略值. 为 -1 表示战斗中无法使用.</param>
	/// <param name="canUseOnPrepareCombat">战斗准备时是否允许在人物行囊使用 - 0为不可用，1为可用</param>
	/// <param name="allowUseInPlayAndTest">允许在切磋与接招战使用</param>
	/// <param name="canTriggerCommonEvent">可触发通用使用事件</param>
	/// <param name="maxUseDistance">最大使用距离 - 战斗中，以2为最小距离，此配置参数为最大距离</param>
	/// <param name="useFrame">使用时间 - 单位为帧数</param>
	/// <param name="requireCombatConfig">所需战斗配置 - 填空则不限制战斗配置</param>
	/// <param name="allowBrokenLevels">允许的毁坏地格级别 - 范围从 1~6</param>
	/// <param name="generateType">生成类型 - 对应存档修复的版本号，子表中较高版本应排在下面</param>
	/// <param name="stateBuryAmount">各州域分布数量</param>
	/// <param name="resourceMaterialType">资源心材类别</param>
	/// <param name="filterType">筛选类别 - 筛选类别用于筛选，一般一个筛选类别可以包括多个同子类的杂物。</param>
	/// <param name="combatUseEffect">战斗使用表现 - 本表都使用默认值</param>
	/// <param name="combatPrepareUseEffect">战斗准备使用表现 - 本表都使用默认值</param>
	/// <param name="gainExp">获得历练</param>
	/// <param name="resourceAmount">资源数量 - 销毁后可获得的资源数量</param>
	/// <param name="hasGiftEvent">转赠时触发事件</param>
	public MiscItem(short templateId, string name, sbyte itemType, short itemSubType, sbyte grade, short groupId, string icon, string desc, string functionDesc, bool transferable, bool stackable, bool wagerable, bool refinable, bool poisonable, bool repairable, bool inheritable, bool consumable, short maxDurability, int baseWeight, int baseValue, sbyte merchantLevel, sbyte baseHappinessChange, int baseFavorabilityChange, sbyte giftLevel, bool allowRandomCreate, sbyte dropRate, bool isSpecial, sbyte resourceType, short makeItemSubType, short preservationDuration, List<int> taskLock, sbyte breakBonusEffect, short neili, int maxNeili, IntPair fiveElementTransfer, sbyte cricketHealInjuryOdds, short reduceEscapeRate, sbyte consumedFeatureMedals, bool canUseOnPrepareCombat, bool allowUseInPlayAndTest, bool canTriggerCommonEvent, sbyte maxUseDistance, int useFrame, List<short> requireCombatConfig, List<int> allowBrokenLevels, EMiscGenerateType generateType, List<TreasureStateInfo> stateBuryAmount, EMiscResourceMaterialType resourceMaterialType, EMiscFilterType filterType, short combatUseEffect, short combatPrepareUseEffect, int gainExp, short resourceAmount, bool hasGiftEvent)
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
		Consumable = consumable;
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
		MakeItemSubType = makeItemSubType;
		PreservationDuration = preservationDuration;
		TaskLock = taskLock;
		BreakBonusEffect = breakBonusEffect;
		Neili = neili;
		MaxNeili = maxNeili;
		FiveElementTransfer = fiveElementTransfer;
		CricketHealInjuryOdds = cricketHealInjuryOdds;
		ReduceEscapeRate = reduceEscapeRate;
		ConsumedFeatureMedals = consumedFeatureMedals;
		CanUseOnPrepareCombat = canUseOnPrepareCombat;
		AllowUseInPlayAndTest = allowUseInPlayAndTest;
		CanTriggerCommonEvent = canTriggerCommonEvent;
		MaxUseDistance = maxUseDistance;
		UseFrame = useFrame;
		RequireCombatConfig = requireCombatConfig;
		AllowBrokenLevels = allowBrokenLevels;
		GenerateType = generateType;
		StateBuryAmount = stateBuryAmount;
		ResourceMaterialType = resourceMaterialType;
		FilterType = filterType;
		CombatUseEffect = combatUseEffect;
		CombatPrepareUseEffect = combatPrepareUseEffect;
		GainExp = gainExp;
		ResourceAmount = resourceAmount;
		HasGiftEvent = hasGiftEvent;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public MiscItem()
	{
		TemplateId = 0;
		Name = null;
		ItemType = 12;
		ItemSubType = 1200;
		Grade = 0;
		GroupId = 0;
		Icon = null;
		Desc = null;
		FunctionDesc = null;
		Transferable = true;
		Stackable = true;
		Wagerable = true;
		Refinable = false;
		Poisonable = false;
		Repairable = false;
		Inheritable = true;
		Consumable = false;
		MaxDurability = 0;
		BaseWeight = 0;
		BaseValue = 10;
		MerchantLevel = 0;
		BaseHappinessChange = 0;
		BaseFavorabilityChange = 50;
		GiftLevel = 8;
		AllowRandomCreate = true;
		DropRate = 0;
		IsSpecial = false;
		ResourceType = 0;
		MakeItemSubType = 0;
		PreservationDuration = 36;
		TaskLock = new List<int>();
		BreakBonusEffect = 0;
		Neili = 0;
		MaxNeili = 0;
		FiveElementTransfer = new IntPair(0, 0);
		CricketHealInjuryOdds = 0;
		ReduceEscapeRate = 0;
		ConsumedFeatureMedals = -1;
		CanUseOnPrepareCombat = false;
		AllowUseInPlayAndTest = false;
		CanTriggerCommonEvent = false;
		MaxUseDistance = -1;
		UseFrame = 60;
		RequireCombatConfig = new List<short>();
		AllowBrokenLevels = new List<int>();
		GenerateType = EMiscGenerateType.Invalid;
		StateBuryAmount = new List<TreasureStateInfo>();
		ResourceMaterialType = EMiscResourceMaterialType.Invalid;
		FilterType = EMiscFilterType.Invalid;
		CombatUseEffect = 0;
		CombatPrepareUseEffect = 0;
		GainExp = 0;
		ResourceAmount = 0;
		HasGiftEvent = false;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public MiscItem(short templateId, MiscItem other)
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
		Consumable = other.Consumable;
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
		MakeItemSubType = other.MakeItemSubType;
		PreservationDuration = other.PreservationDuration;
		TaskLock = other.TaskLock;
		BreakBonusEffect = other.BreakBonusEffect;
		Neili = other.Neili;
		MaxNeili = other.MaxNeili;
		FiveElementTransfer = other.FiveElementTransfer;
		CricketHealInjuryOdds = other.CricketHealInjuryOdds;
		ReduceEscapeRate = other.ReduceEscapeRate;
		ConsumedFeatureMedals = other.ConsumedFeatureMedals;
		CanUseOnPrepareCombat = other.CanUseOnPrepareCombat;
		AllowUseInPlayAndTest = other.AllowUseInPlayAndTest;
		CanTriggerCommonEvent = other.CanTriggerCommonEvent;
		MaxUseDistance = other.MaxUseDistance;
		UseFrame = other.UseFrame;
		RequireCombatConfig = other.RequireCombatConfig;
		AllowBrokenLevels = other.AllowBrokenLevels;
		GenerateType = other.GenerateType;
		StateBuryAmount = other.StateBuryAmount;
		ResourceMaterialType = other.ResourceMaterialType;
		FilterType = other.FilterType;
		CombatUseEffect = other.CombatUseEffect;
		CombatPrepareUseEffect = other.CombatPrepareUseEffect;
		GainExp = other.GainExp;
		ResourceAmount = other.ResourceAmount;
		HasGiftEvent = other.HasGiftEvent;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override MiscItem Duplicate(int templateId)
	{
		return new MiscItem((short)templateId, this);
	}
}

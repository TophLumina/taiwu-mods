using System;
using System.Collections.Generic;
using Config.Common;
using Config.ConfigCells.Character;
using GameData.Domains.Character;
using GameData.Domains.Item;
using GameData.Utilities;

namespace Config;

/// <summary>
/// 武器
/// </summary>
[Serializable]
public class WeaponItem : ConfigItem<WeaponItem, short>, IItemConfig
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
	/// 破甲
	/// </summary>
	public readonly short BaseEquipmentAttack;

	/// <summary>
	/// 坚韧
	/// </summary>
	public readonly short BaseEquipmentDefense;

	/// <summary>
	/// 自身带毒
	/// - 此字段自动生成, 实际配置字段为从 "烈值" 到 "幻等" 的 12 个字段.
	/// </summary>
	public readonly PoisonsAndLevels InnatePoisons;

	/// <summary>
	/// 角色属性需求
	/// </summary>
	public readonly List<PropertyAndValue> RequiredCharacterProperties;

	/// <summary>
	/// 动作索引
	/// - 对应TrickType配置表中，【攻击动作列表】一列的数组sbyte[]的位置，例如一个式有多种动画时，根据此式在此列的索引不同，其对应的动画也不同；另TrickType配置表中【攻击时的表现距离】、【攻击动作列表】、【攻击特效列表】、【攻击音效列表】的位置一一对应。
	/// </summary>
	public readonly sbyte WeaponAction;

	/// <summary>
	/// 战斗图形 右
	/// </summary>
	public readonly string CombatPictureR;

	/// <summary>
	/// 战斗图形 左
	/// </summary>
	public readonly string CombatPictureL;

	/// <summary>
	/// 待机动画
	/// </summary>
	public readonly string IdleAni;

	/// <summary>
	/// 前进动画
	/// </summary>
	public readonly string ForwardAni;

	/// <summary>
	/// 后退动画
	/// </summary>
	public readonly string BackwardAni;

	/// <summary>
	/// 快速前进动画
	/// </summary>
	public readonly string FastForwardAni;

	/// <summary>
	/// 快速后退动画
	/// </summary>
	public readonly string FastBackwardAni;

	/// <summary>
	/// 化解动画
	/// - {卸力、拆招、闪避、守心}
	/// </summary>
	public readonly string[] AvoidAnis;

	/// <summary>
	/// 受击动画
	/// - {轻、中、重}
	/// </summary>
	public readonly string[] HittedAnis;

	/// <summary>
	/// 受重创特效
	/// </summary>
	public readonly string FatalParticle;

	/// <summary>
	/// 队友指令动画名后缀
	/// - 仅用于部分队友指令动画
	/// </summary>
	public readonly string TeammateCmdAniPostfix;

	/// <summary>
	/// 招架动画列表
	/// - 招架表现，每次招架时从列表中随机一个播放。其中音效单独随机，不需与动画特效序号匹配
	/// </summary>
	public readonly List<string> BlockAnis;

	/// <summary>
	/// 招架特效列表
	/// </summary>
	public readonly List<string> BlockParticles;

	/// <summary>
	/// 招架音效列表
	/// </summary>
	public readonly List<string> BlockSounds;

	/// <summary>
	/// 击中音效列表
	/// </summary>
	public readonly List<string> HitSounds;

	/// <summary>
	/// 挥动音效后缀
	/// </summary>
	public readonly string SwingSoundsSuffix;

	/// <summary>
	/// 衣物受击
	/// - 是否播放衣物受击音效
	/// </summary>
	public readonly bool PlayArmorHitSound;

	/// <summary>
	/// 解封效果
	/// </summary>
	public readonly int UnlockEffect;

	/// <summary>
	/// 式
	/// - 对应 TrickType 表
	/// </summary>
	public readonly List<sbyte> Tricks;

	/// <summary>
	/// 式距离调整
	/// - {{TrickType表模板Id, 最小距离, 最大距离}, …}
	/// </summary>
	public readonly List<TrickDistanceAdjust> TrickDistanceAdjusts;

	/// <summary>
	/// 随机式
	/// </summary>
	public readonly bool RandomTrick;

	/// <summary>
	/// 能否变招
	/// </summary>
	public readonly bool CanChangeTrick;

	/// <summary>
	/// 变招能力
	/// - 以百分比影响变招量的增加，受武器发挥度影响
	/// </summary>
	public readonly short ChangeTrickPercent;

	/// <summary>
	/// 追击因子
	/// - 0 表示完全无法追击, 数值越大追击的几率越大，受发挥度影响
	/// </summary>
	public readonly short PursueAttackFactor;

	/// <summary>
	/// 攻击消耗
	/// - 攻击时消耗的准备点. 取值范围 [0, 2]
	/// </summary>
	public readonly sbyte AttackPreparePointCost;

	/// <summary>
	/// 基础前摇
	/// </summary>
	public readonly int BaseStartupFrames;

	/// <summary>
	/// 基础后摇
	/// </summary>
	public readonly int BaseRecoveryFrames;

	/// <summary>
	/// 最小距离
	/// </summary>
	public readonly short MinDistance;

	/// <summary>
	/// 最大距离
	/// </summary>
	public readonly short MaxDistance;

	/// <summary>
	/// 基础命中因子
	/// - 此字段自动生成, 实际配置字段为从 "力道" 到 "动心" 的 4 个字段.
	/// </summary>
	public readonly HitOrAvoidShorts BaseHitFactors;

	/// <summary>
	/// 攻击因子
	/// - 获取人物破体、破气的比例
	/// </summary>
	public readonly short BasePenetrationFactor;

	/// <summary>
	/// 架势增加
	/// - 击中后增加的基础架势值, 最终值受角色架势恢复影响.
	/// </summary>
	public readonly short StanceIncrement;

	/// <summary>
	/// 默认比例
	/// - 武器默认的内外功比例, 为 0 表示纯外伤, 为 100 表示纯内伤.
	/// </summary>
	public readonly sbyte DefaultInnerRatio;

	/// <summary>
	/// 可调范围
	/// - 玩家可调的内外功比例范围, 受角色内功发挥影响. 取值范围 [0, 100], 其值表示可上下调整的绝对值.
	/// </summary>
	public readonly sbyte InnerRatioAdjustRange;

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
	/// <param name="baseEquipmentAttack">破甲</param>
	/// <param name="baseEquipmentDefense">坚韧</param>
	/// <param name="innatePoisons">自身带毒 - 此字段自动生成, 实际配置字段为从 "烈值" 到 "幻等" 的 12 个字段.</param>
	/// <param name="requiredCharacterProperties">角色属性需求</param>
	/// <param name="weaponAction">动作索引 - 对应TrickType配置表中，【攻击动作列表】一列的数组sbyte[]的位置，例如一个式有多种动画时，根据此式在此列的索引不同，其对应的动画也不同；另TrickType配置表中【攻击时的表现距离】、【攻击动作列表】、【攻击特效列表】、【攻击音效列表】的位置一一对应。</param>
	/// <param name="combatPictureR">战斗图形 右</param>
	/// <param name="combatPictureL">战斗图形 左</param>
	/// <param name="idleAni">待机动画</param>
	/// <param name="forwardAni">前进动画</param>
	/// <param name="backwardAni">后退动画</param>
	/// <param name="fastForwardAni">快速前进动画</param>
	/// <param name="fastBackwardAni">快速后退动画</param>
	/// <param name="avoidAnis">化解动画 - {卸力、拆招、闪避、守心}</param>
	/// <param name="hittedAnis">受击动画 - {轻、中、重}</param>
	/// <param name="fatalParticle">受重创特效</param>
	/// <param name="teammateCmdAniPostfix">队友指令动画名后缀 - 仅用于部分队友指令动画</param>
	/// <param name="blockAnis">招架动画列表 - 招架表现，每次招架时从列表中随机一个播放。其中音效单独随机，不需与动画特效序号匹配</param>
	/// <param name="blockParticles">招架特效列表</param>
	/// <param name="blockSounds">招架音效列表</param>
	/// <param name="hitSounds">击中音效列表</param>
	/// <param name="swingSoundsSuffix">挥动音效后缀</param>
	/// <param name="playArmorHitSound">衣物受击 - 是否播放衣物受击音效</param>
	/// <param name="unlockEffect">解封效果</param>
	/// <param name="tricks">式 - 对应 TrickType 表</param>
	/// <param name="trickDistanceAdjusts">式距离调整 - {{TrickType表模板Id, 最小距离, 最大距离}, …}</param>
	/// <param name="randomTrick">随机式</param>
	/// <param name="canChangeTrick">能否变招</param>
	/// <param name="changeTrickPercent">变招能力 - 以百分比影响变招量的增加，受武器发挥度影响</param>
	/// <param name="pursueAttackFactor">追击因子 - 0 表示完全无法追击, 数值越大追击的几率越大，受发挥度影响</param>
	/// <param name="attackPreparePointCost">攻击消耗 - 攻击时消耗的准备点. 取值范围 [0, 2]</param>
	/// <param name="baseStartupFrames">基础前摇</param>
	/// <param name="baseRecoveryFrames">基础后摇</param>
	/// <param name="minDistance">最小距离</param>
	/// <param name="maxDistance">最大距离</param>
	/// <param name="baseHitFactors">基础命中因子 - 此字段自动生成, 实际配置字段为从 "力道" 到 "动心" 的 4 个字段.</param>
	/// <param name="basePenetrationFactor">攻击因子 - 获取人物破体、破气的比例</param>
	/// <param name="stanceIncrement">架势增加 - 击中后增加的基础架势值, 最终值受角色架势恢复影响.</param>
	/// <param name="defaultInnerRatio">默认比例 - 武器默认的内外功比例, 为 0 表示纯外伤, 为 100 表示纯内伤.</param>
	/// <param name="innerRatioAdjustRange">可调范围 - 玩家可调的内外功比例范围, 受角色内功发挥影响. 取值范围 [0, 100], 其值表示可上下调整的绝对值.</param>
	/// <param name="equipmentCombatPowerValueFactor">装备的战斗力比例系数 - NPC装备此装备时，战斗力增加 GlobalConfig.CombatPower[equipIndex] * EquipmentCombatPowerValueFactor / 100</param>
	public WeaponItem(short templateId, string name, sbyte itemType, short itemSubType, sbyte grade, short groupId, string icon, string desc, string functionDesc, bool transferable, bool stackable, bool wagerable, bool refinable, bool poisonable, bool repairable, bool inheritable, bool detachable, short maxDurability, int baseWeight, int baseValue, sbyte merchantLevel, sbyte baseHappinessChange, int baseFavorabilityChange, sbyte giftLevel, bool allowRandomCreate, bool allowRawCreate, bool allowCrippledCreate, sbyte dropRate, bool isSpecial, sbyte resourceType, short preservationDuration, short makeItemSubType, List<int> taskLock, sbyte equipmentType, short equipmentEffectId, short equipmentMasteryId, short baseEquipmentAttack, short baseEquipmentDefense, PoisonsAndLevels innatePoisons, List<PropertyAndValue> requiredCharacterProperties, sbyte weaponAction, string combatPictureR, string combatPictureL, string idleAni, string forwardAni, string backwardAni, string fastForwardAni, string fastBackwardAni, string[] avoidAnis, string[] hittedAnis, string fatalParticle, string teammateCmdAniPostfix, List<string> blockAnis, List<string> blockParticles, List<string> blockSounds, List<string> hitSounds, string swingSoundsSuffix, bool playArmorHitSound, int unlockEffect, List<sbyte> tricks, List<TrickDistanceAdjust> trickDistanceAdjusts, bool randomTrick, bool canChangeTrick, short changeTrickPercent, short pursueAttackFactor, sbyte attackPreparePointCost, int baseStartupFrames, int baseRecoveryFrames, short minDistance, short maxDistance, HitOrAvoidShorts baseHitFactors, short basePenetrationFactor, short stanceIncrement, sbyte defaultInnerRatio, sbyte innerRatioAdjustRange, short equipmentCombatPowerValueFactor)
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
		InnatePoisons = innatePoisons;
		RequiredCharacterProperties = requiredCharacterProperties;
		WeaponAction = weaponAction;
		CombatPictureR = combatPictureR;
		CombatPictureL = combatPictureL;
		IdleAni = idleAni;
		ForwardAni = forwardAni;
		BackwardAni = backwardAni;
		FastForwardAni = fastForwardAni;
		FastBackwardAni = fastBackwardAni;
		AvoidAnis = avoidAnis;
		HittedAnis = hittedAnis;
		FatalParticle = fatalParticle;
		TeammateCmdAniPostfix = teammateCmdAniPostfix;
		BlockAnis = blockAnis;
		BlockParticles = blockParticles;
		BlockSounds = blockSounds;
		HitSounds = hitSounds;
		SwingSoundsSuffix = swingSoundsSuffix;
		PlayArmorHitSound = playArmorHitSound;
		UnlockEffect = unlockEffect;
		Tricks = tricks;
		TrickDistanceAdjusts = trickDistanceAdjusts;
		RandomTrick = randomTrick;
		CanChangeTrick = canChangeTrick;
		ChangeTrickPercent = changeTrickPercent;
		PursueAttackFactor = pursueAttackFactor;
		AttackPreparePointCost = attackPreparePointCost;
		BaseStartupFrames = baseStartupFrames;
		BaseRecoveryFrames = baseRecoveryFrames;
		MinDistance = minDistance;
		MaxDistance = maxDistance;
		BaseHitFactors = baseHitFactors;
		BasePenetrationFactor = basePenetrationFactor;
		StanceIncrement = stanceIncrement;
		DefaultInnerRatio = defaultInnerRatio;
		InnerRatioAdjustRange = innerRatioAdjustRange;
		EquipmentCombatPowerValueFactor = equipmentCombatPowerValueFactor;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public WeaponItem()
	{
		TemplateId = 0;
		Name = null;
		ItemType = 0;
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
		InnatePoisons = new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short));
		RequiredCharacterProperties = new List<PropertyAndValue>();
		WeaponAction = 0;
		CombatPictureR = null;
		CombatPictureL = null;
		IdleAni = null;
		ForwardAni = null;
		BackwardAni = null;
		FastForwardAni = null;
		FastBackwardAni = null;
		AvoidAnis = null;
		HittedAnis = null;
		FatalParticle = null;
		TeammateCmdAniPostfix = null;
		BlockAnis = new List<string> { "" };
		BlockParticles = new List<string> { "" };
		BlockSounds = new List<string> { "" };
		HitSounds = new List<string> { "" };
		SwingSoundsSuffix = null;
		PlayArmorHitSound = true;
		UnlockEffect = 0;
		Tricks = null;
		TrickDistanceAdjusts = new List<TrickDistanceAdjust>();
		RandomTrick = true;
		CanChangeTrick = true;
		ChangeTrickPercent = 100;
		PursueAttackFactor = 0;
		AttackPreparePointCost = 0;
		BaseStartupFrames = 36;
		BaseRecoveryFrames = 72;
		MinDistance = 20;
		MaxDistance = 50;
		BaseHitFactors = new HitOrAvoidShorts(default(short), default(short), default(short), default(short));
		BasePenetrationFactor = 0;
		StanceIncrement = 30;
		DefaultInnerRatio = 0;
		InnerRatioAdjustRange = 15;
		EquipmentCombatPowerValueFactor = 100;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public WeaponItem(short templateId, WeaponItem other)
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
		InnatePoisons = other.InnatePoisons;
		RequiredCharacterProperties = other.RequiredCharacterProperties;
		WeaponAction = other.WeaponAction;
		CombatPictureR = other.CombatPictureR;
		CombatPictureL = other.CombatPictureL;
		IdleAni = other.IdleAni;
		ForwardAni = other.ForwardAni;
		BackwardAni = other.BackwardAni;
		FastForwardAni = other.FastForwardAni;
		FastBackwardAni = other.FastBackwardAni;
		AvoidAnis = other.AvoidAnis;
		HittedAnis = other.HittedAnis;
		FatalParticle = other.FatalParticle;
		TeammateCmdAniPostfix = other.TeammateCmdAniPostfix;
		BlockAnis = other.BlockAnis;
		BlockParticles = other.BlockParticles;
		BlockSounds = other.BlockSounds;
		HitSounds = other.HitSounds;
		SwingSoundsSuffix = other.SwingSoundsSuffix;
		PlayArmorHitSound = other.PlayArmorHitSound;
		UnlockEffect = other.UnlockEffect;
		Tricks = other.Tricks;
		TrickDistanceAdjusts = other.TrickDistanceAdjusts;
		RandomTrick = other.RandomTrick;
		CanChangeTrick = other.CanChangeTrick;
		ChangeTrickPercent = other.ChangeTrickPercent;
		PursueAttackFactor = other.PursueAttackFactor;
		AttackPreparePointCost = other.AttackPreparePointCost;
		BaseStartupFrames = other.BaseStartupFrames;
		BaseRecoveryFrames = other.BaseRecoveryFrames;
		MinDistance = other.MinDistance;
		MaxDistance = other.MaxDistance;
		BaseHitFactors = other.BaseHitFactors;
		BasePenetrationFactor = other.BasePenetrationFactor;
		StanceIncrement = other.StanceIncrement;
		DefaultInnerRatio = other.DefaultInnerRatio;
		InnerRatioAdjustRange = other.InnerRatioAdjustRange;
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
	public override WeaponItem Duplicate(int templateId)
	{
		return new WeaponItem((short)templateId, this);
	}
}

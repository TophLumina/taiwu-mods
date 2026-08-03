using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class BuildingBlockItem : ConfigItem<BuildingBlockItem, short>
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
	/// 建筑功能分类
	/// </summary>
	public readonly EBuildingBlockFuncType FuncType;

	/// <summary>
	/// 说明
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 功能说明
	/// </summary>
	public readonly string FuncDesc;

	/// <summary>
	/// 图标
	/// </summary>
	public readonly string Icon;

	/// <summary>
	/// 功能图标
	/// </summary>
	public readonly string FuncIcon;

	/// <summary>
	/// 类型
	/// </summary>
	public readonly EBuildingBlockType Type;

	/// <summary>
	/// 门类
	/// </summary>
	public readonly EBuildingBlockClass Class;

	/// <summary>
	/// 规模上限
	/// </summary>
	public readonly sbyte MaxLevel;

	/// <summary>
	/// 开放使用
	/// - 为TRUE的建筑，即使不在太吾村，玩家也可以打开建筑界面并使用（某些不能打开但有地图影响效果的不受此限制）
	/// </summary>
	public readonly bool CanOpenManageOutTaiwu;

	/// <summary>
	/// 宽度
	/// </summary>
	public readonly sbyte Width;

	/// <summary>
	/// 颜色
	/// - 用于视图切换时在附属建筑显示
	/// </summary>
	public readonly string Color;

	/// <summary>
	/// 基础建造消耗
	/// - 也用于计算拆除时获得的资源。由辅助配置列P-W组合，不可直接配置此列
	/// </summary>
	public readonly ushort[] BaseBuildCost;

	/// <summary>
	/// 拆除返还资源百分比
	/// </summary>
	public readonly byte RemoveGetResourcePercent;

	/// <summary>
	/// 迁移消耗资源百分比
	/// - 规划建筑位置时，如果进行了迁移，消耗【基础建造消耗】的百分之多少的资源；且如果配置了数值，视为建筑可迁移，没配置数值的不可迁移
	/// </summary>
	public readonly sbyte MoveBuildCostResourceRate;

	/// <summary>
	/// 采集收获资源基础值。毒物为不在资源类型表中的特殊类型，实际收获资源类型为药材
	/// - 由辅助配置列组合，不可直接配置此列
	/// </summary>
	public readonly sbyte[] CollectResourcePercent;

	/// <summary>
	/// 心材
	/// - 建造该建筑所需要的心材，默认不需要
	/// </summary>
	public readonly short BuildingCoreItem;

	/// <summary>
	/// 依赖产业格类型
	/// - 建造或使用需要相邻的建筑和资源
	/// </summary>
	public readonly List<short> DependBuildings;

	/// <summary>
	/// 拓展产业格类型
	/// - 依托本建筑可建造的拓展建筑
	/// </summary>
	public readonly List<short> ExpandBuildings;

	/// <summary>
	/// 需求技艺类型
	/// - 用于计算建造、扩建、拆除速度；制造类型等
	/// </summary>
	public readonly sbyte RequireLifeSkillType;

	/// <summary>
	/// 需求功法类型
	/// </summary>
	public readonly sbyte RequireCombatSkillType;

	/// <summary>
	/// 建筑需求七元
	/// - 用于经营养成时的计算
	/// </summary>
	public readonly sbyte RequirePersonalityType;

	/// <summary>
	/// 领袖名称
	/// </summary>
	public readonly string LeaderName;

	/// <summary>
	/// 成员名称
	/// </summary>
	public readonly string MemberName;

	/// <summary>
	/// 招人技艺资质修正
	/// - 如同不同身份的人物生成时的资质修正修正招人时的人物资质
	/// </summary>
	public readonly short[] RecruitLifeSkillsAdjust;

	/// <summary>
	/// 招人武学资质修正
	/// - 与技艺修正不同的是，武学的招人修正，需要将同归属的练功房下的不同武学建筑的修正组合在一起取每项的最大值，得到最终的修正参数，极端情况下，一个炼神峰如何属于多个练功房，则会获取所有练功房下属的不同武学建筑的影响
	/// </summary>
	public readonly short[] RecruitCombatSkillsAdjust;

	/// <summary>
	/// 各操作所需总进度值
	/// - 数据格式：{建造,扩建,撤除}。由辅助配置列AF-AH组合，不可直接配置此列
	/// </summary>
	public readonly short[] OperationTotalProgress;

	/// <summary>
	/// 耐久上限
	/// </summary>
	public readonly sbyte MaxDurability;

	/// <summary>
	/// 基础维护费
	/// - 格式为{资源类型,需求数量}，资源类型对应ResourceType表中的模板ID
	/// </summary>
	public readonly List<ResourceInfo> BaseMaintenanceCost;

	/// <summary>
	/// 基础修理费
	/// - 每修理1耐久需要的银钱
	/// </summary>
	public readonly int BaseRepairCost;

	/// <summary>
	/// 是否必须维护
	/// </summary>
	public readonly bool MustMaintenance;

	/// <summary>
	/// 是否唯一建筑
	/// </summary>
	public readonly bool IsUnique;

	/// <summary>
	/// 销毁方式
	/// - 当建筑的耐久降到0时的处理：-1.不会损坏，0.变成废墟，1.最多降至0耐久，不会变成废墟
	/// </summary>
	public readonly sbyte DestoryType;

	/// <summary>
	/// 增加技艺的研读效率
	/// - 对应技艺类型表LifeSkillType中的模板ID，增加定居点范围内，人物研读对应技艺书时的效率，效率+=(规模*2)%，最高*1.4
	/// </summary>
	public readonly sbyte AddReadingLifeSkillBookEfficiency;

	/// <summary>
	/// 减少功法的修习、突破消耗
	/// - 对应功法类型表Combat/CombatSkillType中的模板ID，减少定居点范围内的人物修习、突破对应功法时消耗的历练，修习、突破的历练消耗-=(规模*5)%，最高*0.5
	/// </summary>
	public readonly sbyte ReduceCombatSkillCost;

	/// <summary>
	/// 增加功法的突破成功率
	/// - 对应功法类型表Combat/CombatSkillType中的模板ID，增加定居点范围的人物在突破对应功法时的成功率，突破时的成功率+=(规模*3)%，最高*1.3
	/// </summary>
	public readonly sbyte AddCombatSkillBreakout;

	/// <summary>
	/// 增加技艺的造诣
	/// - 对应技艺类型表LifeSkillType中的模板ID，增加定居点范围内的人物的造诣，造诣+=规模*10
	/// </summary>
	public readonly sbyte AddLifeSkillAttainment;

	/// <summary>
	/// 增加研读时灵光乍现的几率
	/// - 对应技艺类型表LifeSkillType中的模板ID，增加定居点范围的人物研读书籍时的灵光乍现几率，=原几率*(100+规模*10)/100，最大*2
	/// </summary>
	public readonly sbyte AddReadingLifeSkillBookFlash;

	/// <summary>
	/// 是否可进行制造
	/// </summary>
	public readonly bool CanMakeItem;

	/// <summary>
	/// 是否加成制造品级
	/// </summary>
	public readonly bool UpgradeMakeItem;

	/// <summary>
	/// 降低制造、修理、精制时所需要的造诣
	/// - 降低制造、修理、精制、淬毒、解毒时所需要的造诣，降低=规模*10
	/// </summary>
	public readonly sbyte ReduceMakeRequirementLifeSkillType;

	/// <summary>
	/// 建筑适配身份
	/// </summary>
	public readonly short[] VillagerRoleTemplateIds;

	/// <summary>
	/// 是否能放人
	/// - 建筑经营界面能不能放人的判定
	/// </summary>
	public readonly bool IsShop;

	/// <summary>
	/// 是否需要主事来生效
	/// - TRUE指此建筑的效果要放了主事才生效，FALSE指的是这个建筑不用配置主事也能生效（非太吾村建筑无视此条都能生效）
	/// </summary>
	public readonly bool NeedLeader;

	/// <summary>
	/// 是否需要经营进度
	/// </summary>
	public readonly bool NeedShopProgress;

	/// <summary>
	/// 是否资源采集建筑
	/// </summary>
	public readonly bool IsCollectResourceBuilding;

	/// <summary>
	/// 是否显示资源存放位置
	/// </summary>
	public readonly bool ShowResourceStoreLocation;

	/// <summary>
	/// 是否显示物品存放位置
	/// </summary>
	public readonly bool ShowItemStoreLocation;

	/// <summary>
	/// 显示的物品存放位置是否为资源存放位置
	/// </summary>
	public readonly bool ShowItemLocationAsResourceLocation;

	/// <summary>
	/// 一次产出需要生产值
	/// </summary>
	public readonly short MaxProduceValue;

	/// <summary>
	/// 需要文化值
	/// - 为负值时表示需要低于100多少
	/// </summary>
	public readonly sbyte RequireCulture;

	/// <summary>
	/// 需要安定值
	/// </summary>
	public readonly sbyte RequireSafety;

	/// <summary>
	/// 成功事件
	/// - 经营事件
	/// </summary>
	public readonly List<short> SuccesEvent;

	/// <summary>
	/// 失败事件
	/// </summary>
	public readonly List<short> FailEvent;

	/// <summary>
	/// 闲置事件
	/// </summary>
	public readonly short IdleEvent;

	/// <summary>
	/// 各评价等级特殊事件列表
	/// </summary>
	public readonly List<ShortList> SpecialEvent;

	/// <summary>
	/// 对应的商队类型
	/// </summary>
	public readonly sbyte MerchantId;

	/// <summary>
	/// 扩建信息条目
	/// </summary>
	public readonly List<short> ExpandInfos;

	/// <summary>
	/// 资源特殊效果
	/// </summary>
	public readonly string EffectDesc;

	/// <summary>
	/// 所属组织
	/// </summary>
	public readonly sbyte BelongOrganization;

	/// <summary>
	/// 建筑等级背景
	/// - 分别是1*1 和2*2的建筑
	/// </summary>
	public readonly string[] BuildingAreaLevelBack;

	/// <summary>
	/// 等级显示样式
	/// </summary>
	public readonly string[] BuildingAreaLevelInfoBackendPattern;

	/// <summary>
	/// 可用匠人订单
	/// </summary>
	public readonly bool ArtisanOrderAvailable;

	/// <summary>
	/// 加载页面可用
	/// - 0可用 1不可用
	/// </summary>
	public readonly byte AvailableOnLoading;

	/// <summary>
	/// 可建造门派
	/// - 可以在哪些门派中建造
	/// </summary>
	public readonly List<short> AvailableOrganization;

	/// <summary>
	/// 所需支持度
	/// - 千分之数值
	/// </summary>
	public readonly short ApprovingRate;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">名称</param>
	/// <param name="funcType">建筑功能分类</param>
	/// <param name="desc">说明</param>
	/// <param name="funcDesc">功能说明</param>
	/// <param name="icon">图标</param>
	/// <param name="funcIcon">功能图标</param>
	/// <param name="type">类型</param>
	/// <param name="enumClass">门类</param>
	/// <param name="maxLevel">规模上限</param>
	/// <param name="canOpenManageOutTaiwu">开放使用 - 为TRUE的建筑，即使不在太吾村，玩家也可以打开建筑界面并使用（某些不能打开但有地图影响效果的不受此限制）</param>
	/// <param name="width">宽度</param>
	/// <param name="color">颜色 - 用于视图切换时在附属建筑显示</param>
	/// <param name="baseBuildCost">基础建造消耗 - 也用于计算拆除时获得的资源。由辅助配置列P-W组合，不可直接配置此列</param>
	/// <param name="removeGetResourcePercent">拆除返还资源百分比</param>
	/// <param name="moveBuildCostResourceRate">迁移消耗资源百分比 - 规划建筑位置时，如果进行了迁移，消耗【基础建造消耗】的百分之多少的资源；且如果配置了数值，视为建筑可迁移，没配置数值的不可迁移</param>
	/// <param name="collectResourcePercent">采集收获资源基础值。毒物为不在资源类型表中的特殊类型，实际收获资源类型为药材 - 由辅助配置列组合，不可直接配置此列</param>
	/// <param name="buildingCoreItem">心材 - 建造该建筑所需要的心材，默认不需要</param>
	/// <param name="dependBuildings">依赖产业格类型 - 建造或使用需要相邻的建筑和资源</param>
	/// <param name="expandBuildings">拓展产业格类型 - 依托本建筑可建造的拓展建筑</param>
	/// <param name="requireLifeSkillType">需求技艺类型 - 用于计算建造、扩建、拆除速度；制造类型等</param>
	/// <param name="requireCombatSkillType">需求功法类型</param>
	/// <param name="requirePersonalityType">建筑需求七元 - 用于经营养成时的计算</param>
	/// <param name="leaderName">领袖名称</param>
	/// <param name="memberName">成员名称</param>
	/// <param name="recruitLifeSkillsAdjust">招人技艺资质修正 - 如同不同身份的人物生成时的资质修正修正招人时的人物资质</param>
	/// <param name="recruitCombatSkillsAdjust">招人武学资质修正 - 与技艺修正不同的是，武学的招人修正，需要将同归属的练功房下的不同武学建筑的修正组合在一起取每项的最大值，得到最终的修正参数，极端情况下，一个炼神峰如何属于多个练功房，则会获取所有练功房下属的不同武学建筑的影响</param>
	/// <param name="operationTotalProgress">各操作所需总进度值 - 数据格式：{建造,扩建,撤除}。由辅助配置列AF-AH组合，不可直接配置此列</param>
	/// <param name="maxDurability">耐久上限</param>
	/// <param name="baseMaintenanceCost">基础维护费 - 格式为{资源类型,需求数量}，资源类型对应ResourceType表中的模板ID</param>
	/// <param name="baseRepairCost">基础修理费 - 每修理1耐久需要的银钱</param>
	/// <param name="mustMaintenance">是否必须维护</param>
	/// <param name="isUnique">是否唯一建筑</param>
	/// <param name="destoryType">销毁方式 - 当建筑的耐久降到0时的处理：-1.不会损坏，0.变成废墟，1.最多降至0耐久，不会变成废墟</param>
	/// <param name="addReadingLifeSkillBookEfficiency">增加技艺的研读效率 - 对应技艺类型表LifeSkillType中的模板ID，增加定居点范围内，人物研读对应技艺书时的效率，效率+=(规模*2)%，最高*1.4</param>
	/// <param name="reduceCombatSkillCost">减少功法的修习、突破消耗 - 对应功法类型表Combat/CombatSkillType中的模板ID，减少定居点范围内的人物修习、突破对应功法时消耗的历练，修习、突破的历练消耗-=(规模*5)%，最高*0.5</param>
	/// <param name="addCombatSkillBreakout">增加功法的突破成功率 - 对应功法类型表Combat/CombatSkillType中的模板ID，增加定居点范围的人物在突破对应功法时的成功率，突破时的成功率+=(规模*3)%，最高*1.3</param>
	/// <param name="addLifeSkillAttainment">增加技艺的造诣 - 对应技艺类型表LifeSkillType中的模板ID，增加定居点范围内的人物的造诣，造诣+=规模*10</param>
	/// <param name="addReadingLifeSkillBookFlash">增加研读时灵光乍现的几率 - 对应技艺类型表LifeSkillType中的模板ID，增加定居点范围的人物研读书籍时的灵光乍现几率，=原几率*(100+规模*10)/100，最大*2</param>
	/// <param name="canMakeItem">是否可进行制造</param>
	/// <param name="upgradeMakeItem">是否加成制造品级</param>
	/// <param name="reduceMakeRequirementLifeSkillType">降低制造、修理、精制时所需要的造诣 - 降低制造、修理、精制、淬毒、解毒时所需要的造诣，降低=规模*10</param>
	/// <param name="villagerRoleTemplateIds">建筑适配身份</param>
	/// <param name="isShop">是否能放人 - 建筑经营界面能不能放人的判定</param>
	/// <param name="needLeader">是否需要主事来生效 - TRUE指此建筑的效果要放了主事才生效，FALSE指的是这个建筑不用配置主事也能生效（非太吾村建筑无视此条都能生效）</param>
	/// <param name="needShopProgress">是否需要经营进度</param>
	/// <param name="isCollectResourceBuilding">是否资源采集建筑</param>
	/// <param name="showResourceStoreLocation">是否显示资源存放位置</param>
	/// <param name="showItemStoreLocation">是否显示物品存放位置</param>
	/// <param name="showItemLocationAsResourceLocation">显示的物品存放位置是否为资源存放位置</param>
	/// <param name="maxProduceValue">一次产出需要生产值</param>
	/// <param name="requireCulture">需要文化值 - 为负值时表示需要低于100多少</param>
	/// <param name="requireSafety">需要安定值</param>
	/// <param name="succesEvent">成功事件 - 经营事件</param>
	/// <param name="failEvent">失败事件</param>
	/// <param name="idleEvent">闲置事件</param>
	/// <param name="specialEvent">各评价等级特殊事件列表</param>
	/// <param name="merchantId">对应的商队类型</param>
	/// <param name="expandInfos">扩建信息条目</param>
	/// <param name="effectDesc">资源特殊效果</param>
	/// <param name="belongOrganization">所属组织</param>
	/// <param name="buildingAreaLevelBack">建筑等级背景 - 分别是1*1 和2*2的建筑</param>
	/// <param name="buildingAreaLevelInfoBackendPattern">等级显示样式</param>
	/// <param name="artisanOrderAvailable">可用匠人订单</param>
	/// <param name="availableOnLoading">加载页面可用 - 0可用 1不可用</param>
	/// <param name="availableOrganization">可建造门派 - 可以在哪些门派中建造</param>
	/// <param name="approvingRate">所需支持度 - 千分之数值</param>
	public BuildingBlockItem(short templateId, string name, EBuildingBlockFuncType funcType, string desc, string funcDesc, string icon, string funcIcon, EBuildingBlockType type, EBuildingBlockClass enumClass, sbyte maxLevel, bool canOpenManageOutTaiwu, sbyte width, string color, ushort[] baseBuildCost, byte removeGetResourcePercent, sbyte moveBuildCostResourceRate, sbyte[] collectResourcePercent, short buildingCoreItem, List<short> dependBuildings, List<short> expandBuildings, sbyte requireLifeSkillType, sbyte requireCombatSkillType, sbyte requirePersonalityType, string leaderName, string memberName, short[] recruitLifeSkillsAdjust, short[] recruitCombatSkillsAdjust, short[] operationTotalProgress, sbyte maxDurability, List<ResourceInfo> baseMaintenanceCost, int baseRepairCost, bool mustMaintenance, bool isUnique, sbyte destoryType, sbyte addReadingLifeSkillBookEfficiency, sbyte reduceCombatSkillCost, sbyte addCombatSkillBreakout, sbyte addLifeSkillAttainment, sbyte addReadingLifeSkillBookFlash, bool canMakeItem, bool upgradeMakeItem, sbyte reduceMakeRequirementLifeSkillType, short[] villagerRoleTemplateIds, bool isShop, bool needLeader, bool needShopProgress, bool isCollectResourceBuilding, bool showResourceStoreLocation, bool showItemStoreLocation, bool showItemLocationAsResourceLocation, short maxProduceValue, sbyte requireCulture, sbyte requireSafety, List<short> succesEvent, List<short> failEvent, short idleEvent, List<ShortList> specialEvent, sbyte merchantId, List<short> expandInfos, string effectDesc, sbyte belongOrganization, string[] buildingAreaLevelBack, string[] buildingAreaLevelInfoBackendPattern, bool artisanOrderAvailable, byte availableOnLoading, List<short> availableOrganization, short approvingRate)
	{
		TemplateId = templateId;
		Name = name;
		FuncType = funcType;
		Desc = desc;
		FuncDesc = funcDesc;
		Icon = icon;
		FuncIcon = funcIcon;
		Type = type;
		Class = enumClass;
		MaxLevel = maxLevel;
		CanOpenManageOutTaiwu = canOpenManageOutTaiwu;
		Width = width;
		Color = color;
		BaseBuildCost = baseBuildCost;
		RemoveGetResourcePercent = removeGetResourcePercent;
		MoveBuildCostResourceRate = moveBuildCostResourceRate;
		CollectResourcePercent = collectResourcePercent;
		BuildingCoreItem = buildingCoreItem;
		DependBuildings = dependBuildings;
		ExpandBuildings = expandBuildings;
		RequireLifeSkillType = requireLifeSkillType;
		RequireCombatSkillType = requireCombatSkillType;
		RequirePersonalityType = requirePersonalityType;
		LeaderName = leaderName;
		MemberName = memberName;
		RecruitLifeSkillsAdjust = recruitLifeSkillsAdjust;
		RecruitCombatSkillsAdjust = recruitCombatSkillsAdjust;
		OperationTotalProgress = operationTotalProgress;
		MaxDurability = maxDurability;
		BaseMaintenanceCost = baseMaintenanceCost;
		BaseRepairCost = baseRepairCost;
		MustMaintenance = mustMaintenance;
		IsUnique = isUnique;
		DestoryType = destoryType;
		AddReadingLifeSkillBookEfficiency = addReadingLifeSkillBookEfficiency;
		ReduceCombatSkillCost = reduceCombatSkillCost;
		AddCombatSkillBreakout = addCombatSkillBreakout;
		AddLifeSkillAttainment = addLifeSkillAttainment;
		AddReadingLifeSkillBookFlash = addReadingLifeSkillBookFlash;
		CanMakeItem = canMakeItem;
		UpgradeMakeItem = upgradeMakeItem;
		ReduceMakeRequirementLifeSkillType = reduceMakeRequirementLifeSkillType;
		VillagerRoleTemplateIds = villagerRoleTemplateIds;
		IsShop = isShop;
		NeedLeader = needLeader;
		NeedShopProgress = needShopProgress;
		IsCollectResourceBuilding = isCollectResourceBuilding;
		ShowResourceStoreLocation = showResourceStoreLocation;
		ShowItemStoreLocation = showItemStoreLocation;
		ShowItemLocationAsResourceLocation = showItemLocationAsResourceLocation;
		MaxProduceValue = maxProduceValue;
		RequireCulture = requireCulture;
		RequireSafety = requireSafety;
		SuccesEvent = succesEvent;
		FailEvent = failEvent;
		IdleEvent = idleEvent;
		SpecialEvent = specialEvent;
		MerchantId = merchantId;
		ExpandInfos = expandInfos;
		EffectDesc = effectDesc;
		BelongOrganization = belongOrganization;
		BuildingAreaLevelBack = buildingAreaLevelBack;
		BuildingAreaLevelInfoBackendPattern = buildingAreaLevelInfoBackendPattern;
		ArtisanOrderAvailable = artisanOrderAvailable;
		AvailableOnLoading = availableOnLoading;
		AvailableOrganization = availableOrganization;
		ApprovingRate = approvingRate;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public BuildingBlockItem()
	{
		TemplateId = 0;
		Name = null;
		FuncType = EBuildingBlockFuncType.Other;
		Desc = null;
		FuncDesc = null;
		Icon = null;
		FuncIcon = null;
		Type = EBuildingBlockType.Invalid;
		Class = EBuildingBlockClass.Invalid;
		MaxLevel = 1;
		CanOpenManageOutTaiwu = false;
		Width = 1;
		Color = null;
		BaseBuildCost = new ushort[8];
		RemoveGetResourcePercent = 50;
		MoveBuildCostResourceRate = -1;
		CollectResourcePercent = new sbyte[7];
		BuildingCoreItem = 0;
		DependBuildings = new List<short>();
		ExpandBuildings = new List<short>();
		RequireLifeSkillType = 0;
		RequireCombatSkillType = 0;
		RequirePersonalityType = 0;
		LeaderName = null;
		MemberName = null;
		RecruitLifeSkillsAdjust = new short[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		RecruitCombatSkillsAdjust = new short[14]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1
		};
		OperationTotalProgress = new short[2] { -1, -1 };
		MaxDurability = -1;
		BaseMaintenanceCost = new List<ResourceInfo>();
		BaseRepairCost = -1;
		MustMaintenance = false;
		IsUnique = false;
		DestoryType = 0;
		AddReadingLifeSkillBookEfficiency = 0;
		ReduceCombatSkillCost = 0;
		AddCombatSkillBreakout = 0;
		AddLifeSkillAttainment = 0;
		AddReadingLifeSkillBookFlash = 0;
		CanMakeItem = false;
		UpgradeMakeItem = false;
		ReduceMakeRequirementLifeSkillType = 0;
		VillagerRoleTemplateIds = null;
		IsShop = false;
		NeedLeader = false;
		NeedShopProgress = false;
		IsCollectResourceBuilding = false;
		ShowResourceStoreLocation = false;
		ShowItemStoreLocation = false;
		ShowItemLocationAsResourceLocation = false;
		MaxProduceValue = -1;
		RequireCulture = 0;
		RequireSafety = 0;
		SuccesEvent = new List<short>();
		FailEvent = new List<short>();
		IdleEvent = 0;
		SpecialEvent = new List<ShortList>();
		MerchantId = 0;
		ExpandInfos = null;
		EffectDesc = null;
		BelongOrganization = 0;
		BuildingAreaLevelBack = new string[2] { "ui9_buildingarea_namebase_0_1", "ui9_buildingarea_namebase_1_1" };
		BuildingAreaLevelInfoBackendPattern = new string[2] { "buildingarea_industry_icon_7", "buildingarea_industry_base_7" };
		ArtisanOrderAvailable = false;
		AvailableOnLoading = 0;
		AvailableOrganization = new List<short>();
		ApprovingRate = 0;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public BuildingBlockItem(short templateId, BuildingBlockItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		FuncType = other.FuncType;
		Desc = other.Desc;
		FuncDesc = other.FuncDesc;
		Icon = other.Icon;
		FuncIcon = other.FuncIcon;
		Type = other.Type;
		Class = other.Class;
		MaxLevel = other.MaxLevel;
		CanOpenManageOutTaiwu = other.CanOpenManageOutTaiwu;
		Width = other.Width;
		Color = other.Color;
		BaseBuildCost = other.BaseBuildCost;
		RemoveGetResourcePercent = other.RemoveGetResourcePercent;
		MoveBuildCostResourceRate = other.MoveBuildCostResourceRate;
		CollectResourcePercent = other.CollectResourcePercent;
		BuildingCoreItem = other.BuildingCoreItem;
		DependBuildings = other.DependBuildings;
		ExpandBuildings = other.ExpandBuildings;
		RequireLifeSkillType = other.RequireLifeSkillType;
		RequireCombatSkillType = other.RequireCombatSkillType;
		RequirePersonalityType = other.RequirePersonalityType;
		LeaderName = other.LeaderName;
		MemberName = other.MemberName;
		RecruitLifeSkillsAdjust = other.RecruitLifeSkillsAdjust;
		RecruitCombatSkillsAdjust = other.RecruitCombatSkillsAdjust;
		OperationTotalProgress = other.OperationTotalProgress;
		MaxDurability = other.MaxDurability;
		BaseMaintenanceCost = other.BaseMaintenanceCost;
		BaseRepairCost = other.BaseRepairCost;
		MustMaintenance = other.MustMaintenance;
		IsUnique = other.IsUnique;
		DestoryType = other.DestoryType;
		AddReadingLifeSkillBookEfficiency = other.AddReadingLifeSkillBookEfficiency;
		ReduceCombatSkillCost = other.ReduceCombatSkillCost;
		AddCombatSkillBreakout = other.AddCombatSkillBreakout;
		AddLifeSkillAttainment = other.AddLifeSkillAttainment;
		AddReadingLifeSkillBookFlash = other.AddReadingLifeSkillBookFlash;
		CanMakeItem = other.CanMakeItem;
		UpgradeMakeItem = other.UpgradeMakeItem;
		ReduceMakeRequirementLifeSkillType = other.ReduceMakeRequirementLifeSkillType;
		VillagerRoleTemplateIds = other.VillagerRoleTemplateIds;
		IsShop = other.IsShop;
		NeedLeader = other.NeedLeader;
		NeedShopProgress = other.NeedShopProgress;
		IsCollectResourceBuilding = other.IsCollectResourceBuilding;
		ShowResourceStoreLocation = other.ShowResourceStoreLocation;
		ShowItemStoreLocation = other.ShowItemStoreLocation;
		ShowItemLocationAsResourceLocation = other.ShowItemLocationAsResourceLocation;
		MaxProduceValue = other.MaxProduceValue;
		RequireCulture = other.RequireCulture;
		RequireSafety = other.RequireSafety;
		SuccesEvent = other.SuccesEvent;
		FailEvent = other.FailEvent;
		IdleEvent = other.IdleEvent;
		SpecialEvent = other.SpecialEvent;
		MerchantId = other.MerchantId;
		ExpandInfos = other.ExpandInfos;
		EffectDesc = other.EffectDesc;
		BelongOrganization = other.BelongOrganization;
		BuildingAreaLevelBack = other.BuildingAreaLevelBack;
		BuildingAreaLevelInfoBackendPattern = other.BuildingAreaLevelInfoBackendPattern;
		ArtisanOrderAvailable = other.ArtisanOrderAvailable;
		AvailableOnLoading = other.AvailableOnLoading;
		AvailableOrganization = other.AvailableOrganization;
		ApprovingRate = other.ApprovingRate;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override BuildingBlockItem Duplicate(int templateId)
	{
		return new BuildingBlockItem((short)templateId, this);
	}
}

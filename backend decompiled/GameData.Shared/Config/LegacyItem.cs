using System;
using Config.Common;
using GameData.Domains.Character;

namespace Config;

[Serializable]
public class LegacyItem : ConfigItem<LegacyItem, short>
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
	/// 互斥组
	/// </summary>
	public readonly short GroupId;

	/// <summary>
	/// 品级
	/// </summary>
	public readonly sbyte Grade;

	/// <summary>
	/// 权重
	/// - 在随机抽取时，权重越大的越容易被抽到
	/// </summary>
	public readonly short Weight;

	/// <summary>
	/// 卡池类型
	/// - 表示这个遗惠在哪个卡池类型内可以抽取，分为修持（资质/成长类型/内力/特性）；机缘（立场/内力五行/人才/恩义/支持/资源点）；身难（剑冢/六维/魅力/寿命）
	/// </summary>
	public readonly sbyte WorldCreationGroup;

	/// <summary>
	/// 所属卡池等级
	/// - 表示这个遗惠在哪个等级的卡池里面可以抽取，分别为0~3
	/// </summary>
	public readonly sbyte Level;

	/// <summary>
	/// 单次传剑唯一
	/// - 只要在遗惠池中，就不再重复出现
	/// </summary>
	public readonly bool IsUnique;

	/// <summary>
	/// 永久唯一
	/// - 只要被选中过, 就永远不会再出现
	/// </summary>
	public readonly bool PermanentlyUnique;

	/// <summary>
	/// 消耗星运点数
	/// - 可能为负数，为负数则增加星运点数
	/// </summary>
	public readonly short ExtraCost;

	/// <summary>
	/// 消耗点数
	/// - 可能为负数，为负数则增加可用遗惠
	/// </summary>
	public readonly short Cost;

	/// <summary>
	/// 图标
	/// </summary>
	public readonly string Icon;

	/// <summary>
	/// 说明
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 新增特性
	/// </summary>
	public readonly short AddFeature;

	/// <summary>
	/// 加成的角色属性类型
	/// - 直接修改角色的基础属性，可遗传。只允许修改基础值可变的主要属性和资质。
	/// </summary>
	public readonly short ModifiedProperty;

	/// <summary>
	/// 属性变化量
	/// </summary>
	public readonly int PropertyDelta;

	/// <summary>
	/// 属性加成类型
	/// - 0: 加法变化, 1: 累加百分比变化
	/// </summary>
	public readonly sbyte PropertyBonusType;

	/// <summary>
	/// 目标内力五行
	/// </summary>
	public readonly NeiliProportionOfFiveElements TargetNeiliProportionOfFiveElements;

	/// <summary>
	/// 目标立场
	/// </summary>
	public readonly sbyte TargetBehaviorType;

	/// <summary>
	/// 目标技艺资质成长类型
	/// - 0: 均衡 1: 早熟 2: 晚成
	/// </summary>
	public readonly sbyte TargetQualificationGrowthTypeLifeSkill;

	/// <summary>
	/// 目标武学资质成长类型
	/// </summary>
	public readonly sbyte TargetQualificationGrowthTypeCombatSkill;

	/// <summary>
	/// 增加毒素免疫数量
	/// </summary>
	public readonly int PoisonImmunityCount;

	/// <summary>
	/// 新增产业资源
	/// - 产业地图的空地生成资源，如果产业地图没有空地（空地数需-所选的此类遗惠），此遗惠不可选
	/// </summary>
	public readonly short AddBuildingBlock;

	/// <summary>
	/// 增加建筑心材
	/// - 目前每次增加数量默认为1
	/// </summary>
	public readonly short AddBuildingCoreItem;

	/// <summary>
	/// 影响的门派
	/// </summary>
	public readonly sbyte AffectingOrganization;

	/// <summary>
	/// 新增支持的门派角色品级
	/// - 取值范围为[0,8]
	/// </summary>
	public readonly sbyte[] SupportingSectCharacterGrades;

	/// <summary>
	/// 影响的州域
	/// </summary>
	public readonly sbyte AffectingState;

	/// <summary>
	/// 地区恩义增加百分比
	/// </summary>
	public readonly sbyte SpiritualDebtDelta;

	/// <summary>
	/// 地区新生儿资质标准
	/// </summary>
	public readonly sbyte[] StateNewbornChildrenGrowingGrade;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="name">名称</param>
	/// <param name="groupId">互斥组</param>
	/// <param name="grade">品级</param>
	/// <param name="weight">权重 - 在随机抽取时，权重越大的越容易被抽到</param>
	/// <param name="worldCreationGroup">卡池类型 - 表示这个遗惠在哪个卡池类型内可以抽取，分为修持（资质/成长类型/内力/特性）；机缘（立场/内力五行/人才/恩义/支持/资源点）；身难（剑冢/六维/魅力/寿命）</param>
	/// <param name="level">所属卡池等级 - 表示这个遗惠在哪个等级的卡池里面可以抽取，分别为0~3</param>
	/// <param name="isUnique">单次传剑唯一 - 只要在遗惠池中，就不再重复出现</param>
	/// <param name="permanentlyUnique">永久唯一 - 只要被选中过, 就永远不会再出现</param>
	/// <param name="extraCost">消耗星运点数 - 可能为负数，为负数则增加星运点数</param>
	/// <param name="cost">消耗点数 - 可能为负数，为负数则增加可用遗惠</param>
	/// <param name="icon">图标</param>
	/// <param name="desc">说明</param>
	/// <param name="addFeature">新增特性</param>
	/// <param name="modifiedProperty">加成的角色属性类型 - 直接修改角色的基础属性，可遗传。只允许修改基础值可变的主要属性和资质。</param>
	/// <param name="propertyDelta">属性变化量</param>
	/// <param name="propertyBonusType">属性加成类型 - 0: 加法变化, 1: 累加百分比变化</param>
	/// <param name="targetNeiliProportionOfFiveElements">目标内力五行</param>
	/// <param name="targetBehaviorType">目标立场</param>
	/// <param name="targetQualificationGrowthTypeLifeSkill">目标技艺资质成长类型 - 0: 均衡 1: 早熟 2: 晚成</param>
	/// <param name="targetQualificationGrowthTypeCombatSkill">目标武学资质成长类型</param>
	/// <param name="poisonImmunityCount">增加毒素免疫数量</param>
	/// <param name="addBuildingBlock">新增产业资源 - 产业地图的空地生成资源，如果产业地图没有空地（空地数需-所选的此类遗惠），此遗惠不可选</param>
	/// <param name="addBuildingCoreItem">增加建筑心材 - 目前每次增加数量默认为1</param>
	/// <param name="affectingOrganization">影响的门派</param>
	/// <param name="supportingSectCharacterGrades">新增支持的门派角色品级 - 取值范围为[0,8]</param>
	/// <param name="affectingState">影响的州域</param>
	/// <param name="spiritualDebtDelta">地区恩义增加百分比</param>
	/// <param name="stateNewbornChildrenGrowingGrade">地区新生儿资质标准</param>
	public LegacyItem(short templateId, string name, short groupId, sbyte grade, short weight, sbyte worldCreationGroup, sbyte level, bool isUnique, bool permanentlyUnique, short extraCost, short cost, string icon, string desc, short addFeature, short modifiedProperty, int propertyDelta, sbyte propertyBonusType, NeiliProportionOfFiveElements targetNeiliProportionOfFiveElements, sbyte targetBehaviorType, sbyte targetQualificationGrowthTypeLifeSkill, sbyte targetQualificationGrowthTypeCombatSkill, int poisonImmunityCount, short addBuildingBlock, short addBuildingCoreItem, sbyte affectingOrganization, sbyte[] supportingSectCharacterGrades, sbyte affectingState, sbyte spiritualDebtDelta, sbyte[] stateNewbornChildrenGrowingGrade)
	{
		TemplateId = templateId;
		Name = name;
		GroupId = groupId;
		Grade = grade;
		Weight = weight;
		WorldCreationGroup = worldCreationGroup;
		Level = level;
		IsUnique = isUnique;
		PermanentlyUnique = permanentlyUnique;
		ExtraCost = extraCost;
		Cost = cost;
		Icon = icon;
		Desc = desc;
		AddFeature = addFeature;
		ModifiedProperty = modifiedProperty;
		PropertyDelta = propertyDelta;
		PropertyBonusType = propertyBonusType;
		TargetNeiliProportionOfFiveElements = targetNeiliProportionOfFiveElements;
		TargetBehaviorType = targetBehaviorType;
		TargetQualificationGrowthTypeLifeSkill = targetQualificationGrowthTypeLifeSkill;
		TargetQualificationGrowthTypeCombatSkill = targetQualificationGrowthTypeCombatSkill;
		PoisonImmunityCount = poisonImmunityCount;
		AddBuildingBlock = addBuildingBlock;
		AddBuildingCoreItem = addBuildingCoreItem;
		AffectingOrganization = affectingOrganization;
		SupportingSectCharacterGrades = supportingSectCharacterGrades;
		AffectingState = affectingState;
		SpiritualDebtDelta = spiritualDebtDelta;
		StateNewbornChildrenGrowingGrade = stateNewbornChildrenGrowingGrade;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public LegacyItem()
	{
		TemplateId = 0;
		Name = null;
		GroupId = 0;
		Grade = 0;
		Weight = 1;
		WorldCreationGroup = 0;
		Level = -1;
		IsUnique = false;
		PermanentlyUnique = false;
		ExtraCost = 0;
		Cost = 0;
		Icon = null;
		Desc = null;
		AddFeature = 0;
		ModifiedProperty = 0;
		PropertyDelta = 0;
		PropertyBonusType = 0;
		TargetNeiliProportionOfFiveElements = new NeiliProportionOfFiveElements(default(sbyte), default(sbyte), default(sbyte), default(sbyte), default(sbyte));
		TargetBehaviorType = 0;
		TargetQualificationGrowthTypeLifeSkill = -1;
		TargetQualificationGrowthTypeCombatSkill = -1;
		PoisonImmunityCount = 0;
		AddBuildingBlock = 0;
		AddBuildingCoreItem = 0;
		AffectingOrganization = 0;
		SupportingSectCharacterGrades = new sbyte[0];
		AffectingState = 0;
		SpiritualDebtDelta = 0;
		StateNewbornChildrenGrowingGrade = new sbyte[0];
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public LegacyItem(short templateId, LegacyItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		GroupId = other.GroupId;
		Grade = other.Grade;
		Weight = other.Weight;
		WorldCreationGroup = other.WorldCreationGroup;
		Level = other.Level;
		IsUnique = other.IsUnique;
		PermanentlyUnique = other.PermanentlyUnique;
		ExtraCost = other.ExtraCost;
		Cost = other.Cost;
		Icon = other.Icon;
		Desc = other.Desc;
		AddFeature = other.AddFeature;
		ModifiedProperty = other.ModifiedProperty;
		PropertyDelta = other.PropertyDelta;
		PropertyBonusType = other.PropertyBonusType;
		TargetNeiliProportionOfFiveElements = other.TargetNeiliProportionOfFiveElements;
		TargetBehaviorType = other.TargetBehaviorType;
		TargetQualificationGrowthTypeLifeSkill = other.TargetQualificationGrowthTypeLifeSkill;
		TargetQualificationGrowthTypeCombatSkill = other.TargetQualificationGrowthTypeCombatSkill;
		PoisonImmunityCount = other.PoisonImmunityCount;
		AddBuildingBlock = other.AddBuildingBlock;
		AddBuildingCoreItem = other.AddBuildingCoreItem;
		AffectingOrganization = other.AffectingOrganization;
		SupportingSectCharacterGrades = other.SupportingSectCharacterGrades;
		AffectingState = other.AffectingState;
		SpiritualDebtDelta = other.SpiritualDebtDelta;
		StateNewbornChildrenGrowingGrade = other.StateNewbornChildrenGrowingGrade;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override LegacyItem Duplicate(int templateId)
	{
		return new LegacyItem((short)templateId, this);
	}
}

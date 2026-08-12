using System;
using System.Collections.Generic;
using Config.Common;
using GameData.Domains.Character;

namespace Config;

[Serializable]
public class InteractionEventOptionItem : ConfigItem<InteractionEventOptionItem, short>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 选项Guid
	/// </summary>
	public readonly string OptionGuid;

	/// <summary>
	/// 互斥组
	/// - 用于冷却时间判定
	/// </summary>
	public readonly short MutexGroupId;

	/// <summary>
	/// 交互类别
	/// </summary>
	public readonly EInteractionEventOptionInteractionType InteractionType;

	/// <summary>
	/// 显示名
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 同道状态要求
	/// </summary>
	public readonly EInteractionEventOptionTaiwuGroupStatus TaiwuGroupStatus;

	/// <summary>
	/// 是否只允许每月一次
	/// </summary>
	public readonly bool OncePerMonth;

	/// <summary>
	/// 最小好感类型
	/// </summary>
	public readonly sbyte[] MinFavorType;

	/// <summary>
	/// 最大好感类型
	/// </summary>
	public readonly sbyte[] MaxFavorType;

	/// <summary>
	/// 交互人立场
	/// </summary>
	public readonly List<sbyte> BehaviorType;

	/// <summary>
	/// 太吾立场
	/// </summary>
	public readonly List<sbyte> TaiwuBehaviorType;

	/// <summary>
	/// 志向技能
	/// - 要求该技能可用且解锁
	/// </summary>
	public readonly int ProfessionSkill;

	/// <summary>
	/// 行动力消耗
	/// - 事件代码中部分选项引用了此数值作为扣除依据；取值范围[0,300]
	/// </summary>
	public readonly int ActionPointCost;

	/// <summary>
	/// 恩义消耗
	/// </summary>
	public readonly int SpiritualDebtCost;

	/// <summary>
	/// 历练消耗
	/// </summary>
	public readonly int ExpCost;

	/// <summary>
	/// 资源消耗
	/// - 此字段自动生成, 实际配置字段为从 "食" 到 "威" 的 8 个字段.
	/// </summary>
	public readonly ResourceInts ResourceCost;

	/// <summary>
	/// 主要属性消耗
	/// - 此字段自动生成, 实际配置字段为前面从 "膂力" 到 "悟性" 的 6 个字段. 所填数据为百分比.
	/// </summary>
	public readonly MainAttributes MainAttributeCost;

	/// <summary>
	/// 剧情节点之后
	/// - 需要在此剧情节点之后才可开启互动
	/// </summary>
	public readonly short AfterMainStoryLineProgress;

	/// <summary>
	/// 剧情节点之前
	/// - 需要在此剧情节点之前才可开启互动
	/// </summary>
	public readonly short BeforeMainStoryLineProgress;

	/// <summary>
	/// 剧情任务阶段
	/// - 需要在此剧情阶段才可开启互动
	/// </summary>
	public readonly List<short> DuringTask;

	/// <summary>
	/// 人物身份
	/// - 人物需要为对应身份人物
	/// </summary>
	public readonly List<short> OrganizationIdentity;

	/// <summary>
	/// 精纯比较
	/// </summary>
	public readonly EInteractionEventOptionCompareConsummate CompareConsummate;

	/// <summary>
	/// 人物归属
	/// - 人物需要归属对应势力之一
	/// </summary>
	public readonly List<short> Organization;

	/// <summary>
	/// 人物不可归属
	/// - 人物不可归属对应势力
	/// </summary>
	public readonly List<short> NonOrganization;

	/// <summary>
	/// 人物是否可以被倾述爱意
	/// - 0表示不限制;1表示检测人物可以被倾述爱意
	/// </summary>
	public readonly bool AbleAffectionate;

	/// <summary>
	/// 普通人物是否可以结婚
	/// - 0表示不限制;1表示检测人物可以结婚
	/// </summary>
	public readonly bool AbleNormalMarried;

	/// <summary>
	/// 出家人物是否可以结婚
	/// - 0代表不限制；1表示人物需要为出家状态
	/// </summary>
	public readonly bool AbleMonkMarried;

	/// <summary>
	/// 人物特性
	/// - 人物持有以下特性可进行互动
	/// </summary>
	public readonly short InteractionFeature;

	/// <summary>
	/// 人物持有物品
	/// - 人物持有对应物品
	/// </summary>
	public readonly short InteractionItem;

	/// <summary>
	/// 人物持有元鸡
	/// - 0表示不限制；1表示人物持有元鸡
	/// </summary>
	public readonly bool AbleChicken;

	/// <summary>
	/// 人物是否可以相枢入邪
	/// </summary>
	public readonly EInteractionEventOptionAbleXiangshu AbleXiangshu;

	/// <summary>
	/// 人物身份能力
	/// - 判定Npc身份是否可以执行以下互动
	/// </summary>
	public readonly EInteractionEventOptionIdentityAbility IdentityAbility;

	/// <summary>
	/// 太吾持有秘闻
	/// - 0表示不检查;1表示持有起码一则秘闻
	/// </summary>
	public readonly bool TaiwuSecretInformation;

	/// <summary>
	/// 太吾持有物品
	/// - 太吾需要持有对应物品至少一件
	/// </summary>
	public readonly short TaiwuItem;

	/// <summary>
	/// 是否获得门派支持
	/// </summary>
	public readonly EInteractionEventOptionOrganizationSupport OrganizationSupport;

	/// <summary>
	/// 关系人数限制
	/// - 需要检测是否达到对应关系的人数上限限制
	/// </summary>
	public readonly short RelationNumber;

	/// <summary>
	/// 同道人数限制
	/// - 1表示需要检测同道的人数上限限制；0表示不检测
	/// </summary>
	public readonly bool TeammateNumber;

	/// <summary>
	/// 太吾性别
	/// - 0: 女, 1: 男, -1: 不限制
	/// </summary>
	public readonly sbyte TaiwuGender;

	/// <summary>
	/// 交互人物性别
	/// - 0: 女, 1: 男, -1: 不限制
	/// </summary>
	public readonly sbyte InteractionGender;

	/// <summary>
	/// 最低年龄
	/// - -1为无限制
	/// </summary>
	public readonly sbyte InteractionMinAge;

	/// <summary>
	/// 最高年龄
	/// - -1为无限制
	/// </summary>
	public readonly sbyte InteractionMaxAge;

	/// <summary>
	/// 最低年龄
	/// - -1为无限制
	/// </summary>
	public readonly sbyte TaiwuMinAge;

	/// <summary>
	/// 最高年龄
	/// - -1为无限制
	/// </summary>
	public readonly sbyte TaiwuMaxAge;

	/// <summary>
	/// 判定队伍中至少一位成年
	/// - 0为无限制;1表示需要判定包括太吾在内的队伍中至少一位成年
	/// </summary>
	public readonly bool OneAdult;

	/// <summary>
	/// 内息是否符合要求
	/// - 双方任一高于对应内息值不可进行互动；-1表示不限制
	/// </summary>
	public readonly short AbleQi;

	/// <summary>
	/// 双方需要结成关系
	/// - 双方需要结成配置关系才可以进行互动
	/// </summary>
	public readonly short ExistentRelation;

	/// <summary>
	/// 双方不可存在关系
	/// - 若双方存在配置关系不可进行互动
	/// </summary>
	public readonly List<short> NonexistentRelation;

	/// <summary>
	/// 太吾不可持有关系
	/// - 若太吾存在配置关系不可进行互动
	/// </summary>
	public readonly List<short> TaiwuNonexistentRelation;

	/// <summary>
	/// 人物不可持有关系
	/// - 若人物存在配置关系不可进行互动
	/// </summary>
	public readonly List<short> InteractionNonexistentRelation;

	/// <summary>
	/// 判定位于指定地格
	/// - 0表示不限制；1表示人物需要位于所属势力的地格
	/// </summary>
	public readonly bool AbleOnOrganizationBlock;

	/// <summary>
	/// 是否可进行铸剑试炼
	/// - 0表示不限制;1表示可以进行进行铸剑试炼
	/// </summary>
	public readonly bool AbleZhujian;

	/// <summary>
	/// 是否可进行拜师学艺
	/// - 0表示不限制；1表示当前可以进行拜师学艺功能
	/// </summary>
	public readonly bool AbleJoinSect;

	/// <summary>
	/// 同道落单婴儿
	/// - 0表示不限制；1表示太吾同道存在落单婴儿，且交互人物为婴儿父母
	/// </summary>
	public readonly bool AbleReturnInfant;

	/// <summary>
	/// 自定义选项跳转链的事件guid
	/// - 从根事件开始，例如大部分的开头都是人物互动之总纲
	/// </summary>
	public readonly List<string> MapBlockCharCustomButtonEventPath;

	/// <summary>
	/// 自定义选项跳转链的选项guid
	/// - 长度和事件guid一致，对应每个事件内对应哪个选项
	/// </summary>
	public readonly List<string> MapBlockCharCustomButtonEventOptionPath;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="optionGuid">选项Guid</param>
	/// <param name="mutexGroupId">互斥组 - 用于冷却时间判定</param>
	/// <param name="interactionType">交互类别</param>
	/// <param name="name">显示名</param>
	/// <param name="taiwuGroupStatus">同道状态要求</param>
	/// <param name="oncePerMonth">是否只允许每月一次</param>
	/// <param name="minFavorType">最小好感类型</param>
	/// <param name="maxFavorType">最大好感类型</param>
	/// <param name="behaviorType">交互人立场</param>
	/// <param name="taiwuBehaviorType">太吾立场</param>
	/// <param name="professionSkill">志向技能 - 要求该技能可用且解锁</param>
	/// <param name="actionPointCost">行动力消耗 - 事件代码中部分选项引用了此数值作为扣除依据；取值范围[0,300]</param>
	/// <param name="spiritualDebtCost">恩义消耗</param>
	/// <param name="expCost">历练消耗</param>
	/// <param name="resourceCost">资源消耗 - 此字段自动生成, 实际配置字段为从 "食" 到 "威" 的 8 个字段.</param>
	/// <param name="mainAttributeCost">主要属性消耗 - 此字段自动生成, 实际配置字段为前面从 "膂力" 到 "悟性" 的 6 个字段. 所填数据为百分比.</param>
	/// <param name="afterMainStoryLineProgress">剧情节点之后 - 需要在此剧情节点之后才可开启互动</param>
	/// <param name="beforeMainStoryLineProgress">剧情节点之前 - 需要在此剧情节点之前才可开启互动</param>
	/// <param name="duringTask">剧情任务阶段 - 需要在此剧情阶段才可开启互动</param>
	/// <param name="organizationIdentity">人物身份 - 人物需要为对应身份人物</param>
	/// <param name="compareConsummate">精纯比较</param>
	/// <param name="organization">人物归属 - 人物需要归属对应势力之一</param>
	/// <param name="nonOrganization">人物不可归属 - 人物不可归属对应势力</param>
	/// <param name="ableAffectionate">人物是否可以被倾述爱意 - 0表示不限制;1表示检测人物可以被倾述爱意</param>
	/// <param name="ableNormalMarried">普通人物是否可以结婚 - 0表示不限制;1表示检测人物可以结婚</param>
	/// <param name="ableMonkMarried">出家人物是否可以结婚 - 0代表不限制；1表示人物需要为出家状态</param>
	/// <param name="interactionFeature">人物特性 - 人物持有以下特性可进行互动</param>
	/// <param name="interactionItem">人物持有物品 - 人物持有对应物品</param>
	/// <param name="ableChicken">人物持有元鸡 - 0表示不限制；1表示人物持有元鸡</param>
	/// <param name="ableXiangshu">人物是否可以相枢入邪</param>
	/// <param name="identityAbility">人物身份能力 - 判定Npc身份是否可以执行以下互动</param>
	/// <param name="taiwuSecretInformation">太吾持有秘闻 - 0表示不检查;1表示持有起码一则秘闻</param>
	/// <param name="taiwuItem">太吾持有物品 - 太吾需要持有对应物品至少一件</param>
	/// <param name="organizationSupport">是否获得门派支持</param>
	/// <param name="relationNumber">关系人数限制 - 需要检测是否达到对应关系的人数上限限制</param>
	/// <param name="teammateNumber">同道人数限制 - 1表示需要检测同道的人数上限限制；0表示不检测</param>
	/// <param name="taiwuGender">太吾性别 - 0: 女, 1: 男, -1: 不限制</param>
	/// <param name="interactionGender">交互人物性别 - 0: 女, 1: 男, -1: 不限制</param>
	/// <param name="interactionMinAge">最低年龄 - -1为无限制</param>
	/// <param name="interactionMaxAge">最高年龄 - -1为无限制</param>
	/// <param name="taiwuMinAge">最低年龄 - -1为无限制</param>
	/// <param name="taiwuMaxAge">最高年龄 - -1为无限制</param>
	/// <param name="oneAdult">判定队伍中至少一位成年 - 0为无限制;1表示需要判定包括太吾在内的队伍中至少一位成年</param>
	/// <param name="ableQi">内息是否符合要求 - 双方任一高于对应内息值不可进行互动；-1表示不限制</param>
	/// <param name="existentRelation">双方需要结成关系 - 双方需要结成配置关系才可以进行互动</param>
	/// <param name="nonexistentRelation">双方不可存在关系 - 若双方存在配置关系不可进行互动</param>
	/// <param name="taiwuNonexistentRelation">太吾不可持有关系 - 若太吾存在配置关系不可进行互动</param>
	/// <param name="interactionNonexistentRelation">人物不可持有关系 - 若人物存在配置关系不可进行互动</param>
	/// <param name="ableOnOrganizationBlock">判定位于指定地格 - 0表示不限制；1表示人物需要位于所属势力的地格</param>
	/// <param name="ableZhujian">是否可进行铸剑试炼 - 0表示不限制;1表示可以进行进行铸剑试炼</param>
	/// <param name="ableJoinSect">是否可进行拜师学艺 - 0表示不限制；1表示当前可以进行拜师学艺功能</param>
	/// <param name="ableReturnInfant">同道落单婴儿 - 0表示不限制；1表示太吾同道存在落单婴儿，且交互人物为婴儿父母</param>
	/// <param name="mapBlockCharCustomButtonEventPath">自定义选项跳转链的事件guid - 从根事件开始，例如大部分的开头都是人物互动之总纲</param>
	/// <param name="mapBlockCharCustomButtonEventOptionPath">自定义选项跳转链的选项guid - 长度和事件guid一致，对应每个事件内对应哪个选项</param>
	public InteractionEventOptionItem(short templateId, string optionGuid, short mutexGroupId, EInteractionEventOptionInteractionType interactionType, string name, EInteractionEventOptionTaiwuGroupStatus taiwuGroupStatus, bool oncePerMonth, sbyte[] minFavorType, sbyte[] maxFavorType, List<sbyte> behaviorType, List<sbyte> taiwuBehaviorType, int professionSkill, int actionPointCost, int spiritualDebtCost, int expCost, ResourceInts resourceCost, MainAttributes mainAttributeCost, short afterMainStoryLineProgress, short beforeMainStoryLineProgress, List<short> duringTask, List<short> organizationIdentity, EInteractionEventOptionCompareConsummate compareConsummate, List<short> organization, List<short> nonOrganization, bool ableAffectionate, bool ableNormalMarried, bool ableMonkMarried, short interactionFeature, short interactionItem, bool ableChicken, EInteractionEventOptionAbleXiangshu ableXiangshu, EInteractionEventOptionIdentityAbility identityAbility, bool taiwuSecretInformation, short taiwuItem, EInteractionEventOptionOrganizationSupport organizationSupport, short relationNumber, bool teammateNumber, sbyte taiwuGender, sbyte interactionGender, sbyte interactionMinAge, sbyte interactionMaxAge, sbyte taiwuMinAge, sbyte taiwuMaxAge, bool oneAdult, short ableQi, short existentRelation, List<short> nonexistentRelation, List<short> taiwuNonexistentRelation, List<short> interactionNonexistentRelation, bool ableOnOrganizationBlock, bool ableZhujian, bool ableJoinSect, bool ableReturnInfant, List<string> mapBlockCharCustomButtonEventPath, List<string> mapBlockCharCustomButtonEventOptionPath)
	{
		TemplateId = templateId;
		OptionGuid = optionGuid;
		MutexGroupId = mutexGroupId;
		InteractionType = interactionType;
		Name = name;
		TaiwuGroupStatus = taiwuGroupStatus;
		OncePerMonth = oncePerMonth;
		MinFavorType = minFavorType;
		MaxFavorType = maxFavorType;
		BehaviorType = behaviorType;
		TaiwuBehaviorType = taiwuBehaviorType;
		ProfessionSkill = professionSkill;
		ActionPointCost = actionPointCost;
		SpiritualDebtCost = spiritualDebtCost;
		ExpCost = expCost;
		ResourceCost = resourceCost;
		MainAttributeCost = mainAttributeCost;
		AfterMainStoryLineProgress = afterMainStoryLineProgress;
		BeforeMainStoryLineProgress = beforeMainStoryLineProgress;
		DuringTask = duringTask;
		OrganizationIdentity = organizationIdentity;
		CompareConsummate = compareConsummate;
		Organization = organization;
		NonOrganization = nonOrganization;
		AbleAffectionate = ableAffectionate;
		AbleNormalMarried = ableNormalMarried;
		AbleMonkMarried = ableMonkMarried;
		InteractionFeature = interactionFeature;
		InteractionItem = interactionItem;
		AbleChicken = ableChicken;
		AbleXiangshu = ableXiangshu;
		IdentityAbility = identityAbility;
		TaiwuSecretInformation = taiwuSecretInformation;
		TaiwuItem = taiwuItem;
		OrganizationSupport = organizationSupport;
		RelationNumber = relationNumber;
		TeammateNumber = teammateNumber;
		TaiwuGender = taiwuGender;
		InteractionGender = interactionGender;
		InteractionMinAge = interactionMinAge;
		InteractionMaxAge = interactionMaxAge;
		TaiwuMinAge = taiwuMinAge;
		TaiwuMaxAge = taiwuMaxAge;
		OneAdult = oneAdult;
		AbleQi = ableQi;
		ExistentRelation = existentRelation;
		NonexistentRelation = nonexistentRelation;
		TaiwuNonexistentRelation = taiwuNonexistentRelation;
		InteractionNonexistentRelation = interactionNonexistentRelation;
		AbleOnOrganizationBlock = ableOnOrganizationBlock;
		AbleZhujian = ableZhujian;
		AbleJoinSect = ableJoinSect;
		AbleReturnInfant = ableReturnInfant;
		MapBlockCharCustomButtonEventPath = mapBlockCharCustomButtonEventPath;
		MapBlockCharCustomButtonEventOptionPath = mapBlockCharCustomButtonEventOptionPath;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public InteractionEventOptionItem()
	{
		TemplateId = 0;
		OptionGuid = null;
		MutexGroupId = 0;
		InteractionType = EInteractionEventOptionInteractionType.Invalid;
		Name = null;
		TaiwuGroupStatus = EInteractionEventOptionTaiwuGroupStatus.Invalid;
		OncePerMonth = false;
		MinFavorType = new sbyte[5] { -6, -6, -6, -6, -6 };
		MaxFavorType = new sbyte[5] { 6, 6, 6, 6, 6 };
		BehaviorType = null;
		TaiwuBehaviorType = null;
		ProfessionSkill = 0;
		ActionPointCost = 0;
		SpiritualDebtCost = 0;
		ExpCost = 0;
		ResourceCost = new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int));
		MainAttributeCost = new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short));
		AfterMainStoryLineProgress = 0;
		BeforeMainStoryLineProgress = 0;
		DuringTask = null;
		OrganizationIdentity = null;
		CompareConsummate = EInteractionEventOptionCompareConsummate.Invalid;
		Organization = null;
		NonOrganization = null;
		AbleAffectionate = false;
		AbleNormalMarried = false;
		AbleMonkMarried = false;
		InteractionFeature = 0;
		InteractionItem = 0;
		AbleChicken = false;
		AbleXiangshu = EInteractionEventOptionAbleXiangshu.Invalid;
		IdentityAbility = EInteractionEventOptionIdentityAbility.Invalid;
		TaiwuSecretInformation = false;
		TaiwuItem = 0;
		OrganizationSupport = EInteractionEventOptionOrganizationSupport.Invalid;
		RelationNumber = 0;
		TeammateNumber = false;
		TaiwuGender = -1;
		InteractionGender = -1;
		InteractionMinAge = -1;
		InteractionMaxAge = -1;
		TaiwuMinAge = -1;
		TaiwuMaxAge = -1;
		OneAdult = false;
		AbleQi = -1;
		ExistentRelation = 0;
		NonexistentRelation = new List<short>();
		TaiwuNonexistentRelation = new List<short>();
		InteractionNonexistentRelation = new List<short>();
		AbleOnOrganizationBlock = false;
		AbleZhujian = false;
		AbleJoinSect = false;
		AbleReturnInfant = false;
		MapBlockCharCustomButtonEventPath = new List<string> { "" };
		MapBlockCharCustomButtonEventOptionPath = new List<string> { "" };
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public InteractionEventOptionItem(short templateId, InteractionEventOptionItem other)
	{
		TemplateId = templateId;
		OptionGuid = other.OptionGuid;
		MutexGroupId = other.MutexGroupId;
		InteractionType = other.InteractionType;
		Name = other.Name;
		TaiwuGroupStatus = other.TaiwuGroupStatus;
		OncePerMonth = other.OncePerMonth;
		MinFavorType = other.MinFavorType;
		MaxFavorType = other.MaxFavorType;
		BehaviorType = other.BehaviorType;
		TaiwuBehaviorType = other.TaiwuBehaviorType;
		ProfessionSkill = other.ProfessionSkill;
		ActionPointCost = other.ActionPointCost;
		SpiritualDebtCost = other.SpiritualDebtCost;
		ExpCost = other.ExpCost;
		ResourceCost = other.ResourceCost;
		MainAttributeCost = other.MainAttributeCost;
		AfterMainStoryLineProgress = other.AfterMainStoryLineProgress;
		BeforeMainStoryLineProgress = other.BeforeMainStoryLineProgress;
		DuringTask = other.DuringTask;
		OrganizationIdentity = other.OrganizationIdentity;
		CompareConsummate = other.CompareConsummate;
		Organization = other.Organization;
		NonOrganization = other.NonOrganization;
		AbleAffectionate = other.AbleAffectionate;
		AbleNormalMarried = other.AbleNormalMarried;
		AbleMonkMarried = other.AbleMonkMarried;
		InteractionFeature = other.InteractionFeature;
		InteractionItem = other.InteractionItem;
		AbleChicken = other.AbleChicken;
		AbleXiangshu = other.AbleXiangshu;
		IdentityAbility = other.IdentityAbility;
		TaiwuSecretInformation = other.TaiwuSecretInformation;
		TaiwuItem = other.TaiwuItem;
		OrganizationSupport = other.OrganizationSupport;
		RelationNumber = other.RelationNumber;
		TeammateNumber = other.TeammateNumber;
		TaiwuGender = other.TaiwuGender;
		InteractionGender = other.InteractionGender;
		InteractionMinAge = other.InteractionMinAge;
		InteractionMaxAge = other.InteractionMaxAge;
		TaiwuMinAge = other.TaiwuMinAge;
		TaiwuMaxAge = other.TaiwuMaxAge;
		OneAdult = other.OneAdult;
		AbleQi = other.AbleQi;
		ExistentRelation = other.ExistentRelation;
		NonexistentRelation = other.NonexistentRelation;
		TaiwuNonexistentRelation = other.TaiwuNonexistentRelation;
		InteractionNonexistentRelation = other.InteractionNonexistentRelation;
		AbleOnOrganizationBlock = other.AbleOnOrganizationBlock;
		AbleZhujian = other.AbleZhujian;
		AbleJoinSect = other.AbleJoinSect;
		AbleReturnInfant = other.AbleReturnInfant;
		MapBlockCharCustomButtonEventPath = other.MapBlockCharCustomButtonEventPath;
		MapBlockCharCustomButtonEventOptionPath = other.MapBlockCharCustomButtonEventOptionPath;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override InteractionEventOptionItem Duplicate(int templateId)
	{
		return new InteractionEventOptionItem((short)templateId, this);
	}
}

using System;
using System.Collections.Generic;
using Config.Common;
using Config.ConfigCells.Character;
using GameData.ActionPlanning.MonthlyAI;
using GameData.ActionPlanning.State;

namespace Config;

[Serializable]
public class PlanningActionItem : ConfigItem<PlanningActionItem, int>
{
	/// <summary>
	/// 行为 ID
	/// </summary>
	public readonly int TemplateId;

	/// <summary>
	/// 实现代码
	/// - 该列仅有程序填写，未配置的情况下行为会被规划但不会被执行。此处采用在表格中配置而非Attribute标注的方式,便于统计实现情况和异常处理. 默认会在GameData.ActionPlanning.ActionImpl下查找对应的类进行关联.
	/// </summary>
	public readonly string ImplementationPath;

	/// <summary>
	/// 需求参数类型
	/// </summary>
	public readonly sbyte[] Parameters;

	/// <summary>
	/// 人物立场
	/// - 该列由公式生成，禁止手动填写
	/// </summary>
	public readonly int[] BehaviorTypeWeights;

	/// <summary>
	/// 人物赋性
	/// </summary>
	public readonly int[] PersonalityWeights;

	/// <summary>
	/// 七元倾向
	/// </summary>
	public readonly sbyte PersonalityType;

	/// <summary>
	/// 志向要求
	/// - 需要为对应志向，且志向资历要达到所配置级别的技能需求时，才能进行该行为：{志向名,志向技能级别}
	/// </summary>
	public readonly int[] ProfessionRequirement;

	/// <summary>
	/// 身份要求
	/// </summary>
	public readonly short[] RequiredOrgMembers;

	/// <summary>
	/// 是否需要成年
	/// - 执行此行为是否需要人物成年
	/// - 即使值为false仍会排除婴儿
	/// </summary>
	public readonly bool IsAdultOnly;

	/// <summary>
	/// 是否排除太吾的同道
	/// - 值为时，太吾同道将不会执行此行为
	/// </summary>
	public readonly bool IsNonTaiwuTeammate;

	/// <summary>
	/// 是否排除出家或不许婚配的角色
	/// </summary>
	public readonly bool IsNonMonk;

	/// <summary>
	/// 不能闲逛的角色仍然执行行动的几率
	/// - 默认为-1，即无需闲逛判定
	/// </summary>
	public readonly int LoafChance;

	/// <summary>
	/// 是否允许移动
	/// - 执行此行为时人物可以移动寻炸可交互目标
	/// </summary>
	public readonly bool AllowMove;

	/// <summary>
	/// 行动力消耗
	/// - 主行动力有40，副行动力有40，过月未使用的会积累，最多积累到80
	/// </summary>
	public readonly int ActionPointCost;

	/// <summary>
	/// 其它使用行为的限制
	/// - 需要符合该限制，才能使用该行为. 与前置的区别是这类条件不会被用于寻路.
	/// </summary>
	public readonly StateConditionAndValue<StateKey>[] SelfRestrictions;

	/// <summary>
	/// 前置准备条件
	/// - 当要使用该行为但前置准备条件不足时，会引发寻路，人物将去尝试满足前置条件里的情况再使用该行为
	/// </summary>
	public readonly StateConditionAndValue<StateKey>[] Preconditions;

	/// <summary>
	/// 目标人物筛选
	/// - 当此行为对方不为自己，且需要对目标人物进行筛选时，此列条件用以筛选目标人物，此列编写条件默认为目标人物而无需填写对方词缀
	/// </summary>
	public readonly StateConditionAndValue<StateKey>[] TargetCharacterConditions;

	/// <summary>
	/// 引发效果增益
	/// </summary>
	public readonly StateEffect<StateKey>[] Effects;

	/// <summary>
	/// 引发效果减损
	/// </summary>
	public readonly StateEffect<StateKey>[] DeEffects;

	/// <summary>
	/// 筛选人数类型
	/// - 对于非必要对象, 即使不满足也可以进行行为. 此类行为能否筛选到目标人物以及目标人物的状态都不会影响寻路.
	/// </summary>
	public readonly EPlanningActionCharacterSelectCountType CharacterSelectCountType;

	/// <summary>
	/// 目标筛选人数范围
	/// - 只在筛选人数类型为多个对象时生效。
	/// </summary>
	public readonly int[] CharacterSelectCountRange;

	/// <summary>
	/// 目标筛选方式类型
	/// - 筛选目标角色时使用的逻辑. 与代码实现一一对应，如需新增类型需要由程序添加.
	/// </summary>
	public readonly EPlanningActionCharacterSelector CharacterSelector;

	/// <summary>
	/// 选择太吾
	/// - 如果太吾在行为的可选人物范围内时，以多少概率必然选择太吾发生
	/// </summary>
	public readonly int SelectTaiwuChance;

	/// <summary>
	/// 目标筛选范围类型
	/// - 筛选目标角色时检测的范围类型. 与代码实现一一对应，如需新增类型需要由程序添加.
	/// </summary>
	public readonly EPlanningActionCharacterSelectRange CharacterSelectRange;

	/// <summary>
	/// 目标筛选范围参数
	/// - 实际范围参数. 例如当目标筛选范围类型为
	/// </summary>
	public readonly int SelectRangeValue;

	/// <summary>
	/// 拒绝邀约
	/// - 当太吾和人物进行邀约聚会的交互时，若人物正在进行此项配置文本不为空的优先行为，将会拒绝太吾邀约,并应用文本于事件中
	/// </summary>
	public readonly string RefuseAppointment;

	/// <summary>
	/// 过月通知
	/// - 目标为太吾同道时添加,参数同经历，多一个发起者.
	/// </summary>
	public readonly short MonthlyNotification;

	/// <summary>
	/// 执行自身经历
	/// - 只适用于存在通用实现的行为经历，对于专用实现的行为，经历通过代码直接调用。
	/// </summary>
	public readonly short ExecuteSelfLifeRecord;

	/// <summary>
	/// 执行目标经历
	/// - 只适用于存在通用实现的行为经历，对于专用实现的行为，经历通过代码直接调用。
	/// </summary>
	public readonly short ExecuteTargetLifeRecord;

	/// <summary>
	/// 历练变化
	/// </summary>
	public readonly int ExpChange;

	/// <summary>
	/// 心情变化
	/// </summary>
	public readonly int HappinessChange;

	/// <summary>
	/// 好感变化
	/// </summary>
	public readonly short FavorabilityChange;

	/// <summary>
	/// 威望变化
	/// </summary>
	public readonly int AuthorityChange;

	/// <summary>
	/// 随机道具奖励
	/// </summary>
	public readonly List<PresetInventoryItem> RandomItemRewards;

	/// <summary>
	/// 自身匹配规则
	/// </summary>
	public readonly short SelfMatcher;

	/// <summary>
	/// 目标匹配规则
	/// </summary>
	public readonly short TargetMatcher;

	/// <summary>
	/// 执行冷却
	/// - 行为中断或完成后开始计时.
	/// </summary>
	public readonly int Cooldown;

	/// <summary>
	/// 战斗类型
	/// - 0-切磋、1-恶斗、2-死斗、3-接招
	/// </summary>
	public readonly sbyte CombatType;

	/// <summary>
	/// 处死概率
	/// </summary>
	public readonly int KillBaseChance;

	/// <summary>
	/// 关押概率
	/// </summary>
	public readonly int KidnapBaseChance;

	/// <summary>
	/// 释放概率
	/// </summary>
	public readonly int ReleaseBaseChance;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">行为 ID</param>
	/// <param name="implementationPath">实现代码 - 该列仅有程序填写，未配置的情况下行为会被规划但不会被执行。此处采用在表格中配置而非Attribute标注的方式,便于统计实现情况和异常处理. 默认会在GameData.ActionPlanning.ActionImpl下查找对应的类进行关联.</param>
	/// <param name="parameters">需求参数类型</param>
	/// <param name="behaviorTypeWeights">人物立场 - 该列由公式生成，禁止手动填写</param>
	/// <param name="personalityWeights">人物赋性</param>
	/// <param name="personalityType">七元倾向</param>
	/// <param name="professionRequirement">志向要求 - 需要为对应志向，且志向资历要达到所配置级别的技能需求时，才能进行该行为：{志向名,志向技能级别}</param>
	/// <param name="requiredOrgMembers">身份要求</param>
	/// <param name="isAdultOnly">是否需要成年 - 执行此行为是否需要人物成年 即使值为false仍会排除婴儿</param>
	/// <param name="isNonTaiwuTeammate">是否排除太吾的同道 - 值为时，太吾同道将不会执行此行为</param>
	/// <param name="isNonMonk">是否排除出家或不许婚配的角色</param>
	/// <param name="loafChance">不能闲逛的角色仍然执行行动的几率 - 默认为-1，即无需闲逛判定</param>
	/// <param name="allowMove">是否允许移动 - 执行此行为时人物可以移动寻炸可交互目标</param>
	/// <param name="actionPointCost">行动力消耗 - 主行动力有40，副行动力有40，过月未使用的会积累，最多积累到80</param>
	/// <param name="selfRestrictions">其它使用行为的限制 - 需要符合该限制，才能使用该行为. 与前置的区别是这类条件不会被用于寻路.</param>
	/// <param name="preconditions">前置准备条件 - 当要使用该行为但前置准备条件不足时，会引发寻路，人物将去尝试满足前置条件里的情况再使用该行为</param>
	/// <param name="targetCharacterConditions">目标人物筛选 - 当此行为对方不为自己，且需要对目标人物进行筛选时，此列条件用以筛选目标人物，此列编写条件默认为目标人物而无需填写对方词缀</param>
	/// <param name="effects">引发效果增益</param>
	/// <param name="deEffects">引发效果减损</param>
	/// <param name="characterSelectCountType">筛选人数类型 - 对于非必要对象, 即使不满足也可以进行行为. 此类行为能否筛选到目标人物以及目标人物的状态都不会影响寻路.</param>
	/// <param name="characterSelectCountRange">目标筛选人数范围 - 只在筛选人数类型为多个对象时生效。</param>
	/// <param name="characterSelector">目标筛选方式类型 - 筛选目标角色时使用的逻辑. 与代码实现一一对应，如需新增类型需要由程序添加.</param>
	/// <param name="selectTaiwuChance">选择太吾 - 如果太吾在行为的可选人物范围内时，以多少概率必然选择太吾发生</param>
	/// <param name="characterSelectRange">目标筛选范围类型 - 筛选目标角色时检测的范围类型. 与代码实现一一对应，如需新增类型需要由程序添加.</param>
	/// <param name="selectRangeValue">目标筛选范围参数 - 实际范围参数. 例如当目标筛选范围类型为</param>
	/// <param name="refuseAppointment">拒绝邀约 - 当太吾和人物进行邀约聚会的交互时，若人物正在进行此项配置文本不为空的优先行为，将会拒绝太吾邀约,并应用文本于事件中</param>
	/// <param name="monthlyNotification">过月通知 - 目标为太吾同道时添加,参数同经历，多一个发起者.</param>
	/// <param name="executeSelfLifeRecord">执行自身经历 - 只适用于存在通用实现的行为经历，对于专用实现的行为，经历通过代码直接调用。</param>
	/// <param name="executeTargetLifeRecord">执行目标经历 - 只适用于存在通用实现的行为经历，对于专用实现的行为，经历通过代码直接调用。</param>
	/// <param name="expChange">历练变化</param>
	/// <param name="happinessChange">心情变化</param>
	/// <param name="favorabilityChange">好感变化</param>
	/// <param name="authorityChange">威望变化</param>
	/// <param name="randomItemRewards">随机道具奖励</param>
	/// <param name="selfMatcher">自身匹配规则</param>
	/// <param name="targetMatcher">目标匹配规则</param>
	/// <param name="cooldown">执行冷却 - 行为中断或完成后开始计时.</param>
	/// <param name="combatType">战斗类型 - 0-切磋、1-恶斗、2-死斗、3-接招</param>
	/// <param name="killBaseChance">处死概率</param>
	/// <param name="kidnapBaseChance">关押概率</param>
	/// <param name="releaseBaseChance">释放概率</param>
	public PlanningActionItem(int templateId, string implementationPath, sbyte[] parameters, int[] behaviorTypeWeights, int[] personalityWeights, sbyte personalityType, int[] professionRequirement, short[] requiredOrgMembers, bool isAdultOnly, bool isNonTaiwuTeammate, bool isNonMonk, int loafChance, bool allowMove, int actionPointCost, StateConditionAndValue<StateKey>[] selfRestrictions, StateConditionAndValue<StateKey>[] preconditions, StateConditionAndValue<StateKey>[] targetCharacterConditions, StateEffect<StateKey>[] effects, StateEffect<StateKey>[] deEffects, EPlanningActionCharacterSelectCountType characterSelectCountType, int[] characterSelectCountRange, EPlanningActionCharacterSelector characterSelector, int selectTaiwuChance, EPlanningActionCharacterSelectRange characterSelectRange, int selectRangeValue, string refuseAppointment, short monthlyNotification, short executeSelfLifeRecord, short executeTargetLifeRecord, int expChange, int happinessChange, short favorabilityChange, int authorityChange, List<PresetInventoryItem> randomItemRewards, short selfMatcher, short targetMatcher, int cooldown, sbyte combatType, int killBaseChance, int kidnapBaseChance, int releaseBaseChance)
	{
		TemplateId = templateId;
		ImplementationPath = implementationPath;
		Parameters = parameters;
		BehaviorTypeWeights = behaviorTypeWeights;
		PersonalityWeights = personalityWeights;
		PersonalityType = personalityType;
		ProfessionRequirement = professionRequirement;
		RequiredOrgMembers = requiredOrgMembers;
		IsAdultOnly = isAdultOnly;
		IsNonTaiwuTeammate = isNonTaiwuTeammate;
		IsNonMonk = isNonMonk;
		LoafChance = loafChance;
		AllowMove = allowMove;
		ActionPointCost = actionPointCost;
		SelfRestrictions = selfRestrictions;
		Preconditions = preconditions;
		TargetCharacterConditions = targetCharacterConditions;
		Effects = effects;
		DeEffects = deEffects;
		CharacterSelectCountType = characterSelectCountType;
		CharacterSelectCountRange = characterSelectCountRange;
		CharacterSelector = characterSelector;
		SelectTaiwuChance = selectTaiwuChance;
		CharacterSelectRange = characterSelectRange;
		SelectRangeValue = selectRangeValue;
		RefuseAppointment = refuseAppointment;
		MonthlyNotification = monthlyNotification;
		ExecuteSelfLifeRecord = executeSelfLifeRecord;
		ExecuteTargetLifeRecord = executeTargetLifeRecord;
		ExpChange = expChange;
		HappinessChange = happinessChange;
		FavorabilityChange = favorabilityChange;
		AuthorityChange = authorityChange;
		RandomItemRewards = randomItemRewards;
		SelfMatcher = selfMatcher;
		TargetMatcher = targetMatcher;
		Cooldown = cooldown;
		CombatType = combatType;
		KillBaseChance = killBaseChance;
		KidnapBaseChance = kidnapBaseChance;
		ReleaseBaseChance = releaseBaseChance;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public PlanningActionItem()
	{
		TemplateId = 0;
		ImplementationPath = null;
		Parameters = new sbyte[0];
		BehaviorTypeWeights = new int[5] { 1, 1, 1, 1, 1 };
		PersonalityWeights = new int[7];
		PersonalityType = 0;
		ProfessionRequirement = new int[0];
		RequiredOrgMembers = new short[0];
		IsAdultOnly = false;
		IsNonTaiwuTeammate = false;
		IsNonMonk = false;
		LoafChance = -1;
		AllowMove = true;
		ActionPointCost = 0;
		SelfRestrictions = new StateConditionAndValue<StateKey>[0];
		Preconditions = new StateConditionAndValue<StateKey>[0];
		TargetCharacterConditions = new StateConditionAndValue<StateKey>[0];
		Effects = null;
		DeEffects = null;
		CharacterSelectCountType = EPlanningActionCharacterSelectCountType.None;
		CharacterSelectCountRange = null;
		CharacterSelector = EPlanningActionCharacterSelector.None;
		SelectTaiwuChance = 0;
		CharacterSelectRange = EPlanningActionCharacterSelectRange.None;
		SelectRangeValue = 1;
		RefuseAppointment = null;
		MonthlyNotification = 0;
		ExecuteSelfLifeRecord = 0;
		ExecuteTargetLifeRecord = 0;
		ExpChange = 0;
		HappinessChange = 0;
		FavorabilityChange = 0;
		AuthorityChange = 0;
		RandomItemRewards = new List<PresetInventoryItem>();
		SelfMatcher = 82;
		TargetMatcher = 82;
		Cooldown = 2;
		CombatType = -1;
		KillBaseChance = 0;
		KidnapBaseChance = 0;
		ReleaseBaseChance = 100;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public PlanningActionItem(int templateId, PlanningActionItem other)
	{
		TemplateId = templateId;
		ImplementationPath = other.ImplementationPath;
		Parameters = other.Parameters;
		BehaviorTypeWeights = other.BehaviorTypeWeights;
		PersonalityWeights = other.PersonalityWeights;
		PersonalityType = other.PersonalityType;
		ProfessionRequirement = other.ProfessionRequirement;
		RequiredOrgMembers = other.RequiredOrgMembers;
		IsAdultOnly = other.IsAdultOnly;
		IsNonTaiwuTeammate = other.IsNonTaiwuTeammate;
		IsNonMonk = other.IsNonMonk;
		LoafChance = other.LoafChance;
		AllowMove = other.AllowMove;
		ActionPointCost = other.ActionPointCost;
		SelfRestrictions = other.SelfRestrictions;
		Preconditions = other.Preconditions;
		TargetCharacterConditions = other.TargetCharacterConditions;
		Effects = other.Effects;
		DeEffects = other.DeEffects;
		CharacterSelectCountType = other.CharacterSelectCountType;
		CharacterSelectCountRange = other.CharacterSelectCountRange;
		CharacterSelector = other.CharacterSelector;
		SelectTaiwuChance = other.SelectTaiwuChance;
		CharacterSelectRange = other.CharacterSelectRange;
		SelectRangeValue = other.SelectRangeValue;
		RefuseAppointment = other.RefuseAppointment;
		MonthlyNotification = other.MonthlyNotification;
		ExecuteSelfLifeRecord = other.ExecuteSelfLifeRecord;
		ExecuteTargetLifeRecord = other.ExecuteTargetLifeRecord;
		ExpChange = other.ExpChange;
		HappinessChange = other.HappinessChange;
		FavorabilityChange = other.FavorabilityChange;
		AuthorityChange = other.AuthorityChange;
		RandomItemRewards = other.RandomItemRewards;
		SelfMatcher = other.SelfMatcher;
		TargetMatcher = other.TargetMatcher;
		Cooldown = other.Cooldown;
		CombatType = other.CombatType;
		KillBaseChance = other.KillBaseChance;
		KidnapBaseChance = other.KidnapBaseChance;
		ReleaseBaseChance = other.ReleaseBaseChance;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override PlanningActionItem Duplicate(int templateId)
	{
		return new PlanningActionItem(templateId, this);
	}
}

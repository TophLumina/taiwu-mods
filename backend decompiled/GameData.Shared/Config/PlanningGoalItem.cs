using System;
using Config.Common;
using GameData.ActionPlanning.MonthlyAI;
using GameData.ActionPlanning.State;

namespace Config;

[Serializable]
public class PlanningGoalItem : ConfigItem<PlanningGoalItem, int>
{
	/// <summary>
	/// 目标 ID
	/// </summary>
	public readonly int TemplateId;

	/// <summary>
	/// 名称
	/// - 暂时用普通字符串用于单元测试, 后续改为Lstring
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 隐藏
	/// - 是否在UI上隐藏
	/// </summary>
	public readonly bool HideInUI;

	/// <summary>
	/// 持续时间
	/// - 此行为可持续的最大时间，当持续时间结束，目标就会被移除并且开始冷却
	/// - 默认-1代表无限持续时间
	/// </summary>
	public readonly int Duration;

	/// <summary>
	/// 基础优先度
	/// - 人物将会依照行为优先度依次进行判定：行为优先度=基础优先度+立场优先度
	/// </summary>
	public readonly short BasePriority;

	/// <summary>
	/// 立场优先度
	/// - 该列由公式生成，禁止手动填写
	/// </summary>
	public readonly short[] MoralityPriority;

	/// <summary>
	/// 当务之急
	/// - 单独为人物添加的目标，会显示至当务之急中，优先级最高
	/// </summary>
	public readonly bool IsPrioritizedGoal;

	/// <summary>
	/// 寻路深度
	/// - 此目标最大的寻路深度
	/// </summary>
	public readonly int MaxPlanningDepth;

	/// <summary>
	/// 互斥行为
	/// - 此目标不可以寻路到的行为
	/// </summary>
	public readonly int[] ConflictActions;

	/// <summary>
	/// 前置要求
	/// - 添加目标时的条件，不满足时不会被添加.
	/// </summary>
	public readonly StateConditionAndValue<StateKey>[] AddConditions;

	/// <summary>
	/// 达成条件
	/// - 第二个参数的值含义，在没有第三个参数时：0-无取值，在没有第三个值的情况下，只要满足后续的大于小于等于条件即可；1-表示达成对应状态即可；当有第三个参数时，此值的作用变为对第三个参数的加减修正
	/// </summary>
	public readonly StateConditionAndValue<StateKey>[] Preconditions;

	/// <summary>
	/// 前置条件的人物约束A
	/// </summary>
	public readonly StateConditionAndValue<StateKey>[] TargetCharacterConditionsA;

	/// <summary>
	/// 前置条件的人物约束B
	/// </summary>
	public readonly StateConditionAndValue<StateKey>[] TargetCharacterConditionsB;

	/// <summary>
	/// 前置条件的人物约束C
	/// </summary>
	public readonly StateConditionAndValue<StateKey>[] TargetCharacterConditionsC;

	/// <summary>
	/// 目标参数类型
	/// </summary>
	public readonly sbyte[] Parameters;

	/// <summary>
	/// 目标参数验证
	/// </summary>
	public readonly EPlanningGoalValidator[] Validators;

	/// <summary>
	/// 新旧覆盖
	/// - 获得同个目标时，如果参数不一致，且此值为真时，覆盖之前的目标  (为true时同类目标只会存在一个)
	/// </summary>
	public readonly bool Overwrite;

	/// <summary>
	/// 创建目标逻辑实现
	/// </summary>
	public readonly string CreateGoalImpl;

	/// <summary>
	/// 创建逻辑重复检测
	/// - 只对当务之急生效.该项为true时，每月都会重新试图创建,创建失败表示已失效, 将直接移除
	/// </summary>
	public readonly bool RecreateEveryMonth;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">目标 ID</param>
	/// <param name="name">名称 - 暂时用普通字符串用于单元测试, 后续改为Lstring</param>
	/// <param name="hideInUI">隐藏 - 是否在UI上隐藏</param>
	/// <param name="duration">持续时间 - 此行为可持续的最大时间，当持续时间结束，目标就会被移除并且开始冷却 默认-1代表无限持续时间</param>
	/// <param name="basePriority">基础优先度 - 人物将会依照行为优先度依次进行判定：行为优先度=基础优先度+立场优先度</param>
	/// <param name="moralityPriority">立场优先度 - 该列由公式生成，禁止手动填写</param>
	/// <param name="isPrioritizedGoal">当务之急 - 单独为人物添加的目标，会显示至当务之急中，优先级最高</param>
	/// <param name="maxPlanningDepth">寻路深度 - 此目标最大的寻路深度</param>
	/// <param name="conflictActions">互斥行为 - 此目标不可以寻路到的行为</param>
	/// <param name="addConditions">前置要求 - 添加目标时的条件，不满足时不会被添加.</param>
	/// <param name="preconditions">达成条件 - 第二个参数的值含义，在没有第三个参数时：0-无取值，在没有第三个值的情况下，只要满足后续的大于小于等于条件即可；1-表示达成对应状态即可；当有第三个参数时，此值的作用变为对第三个参数的加减修正</param>
	/// <param name="targetCharacterConditionsA">前置条件的人物约束A</param>
	/// <param name="targetCharacterConditionsB">前置条件的人物约束B</param>
	/// <param name="targetCharacterConditionsC">前置条件的人物约束C</param>
	/// <param name="parameters">目标参数类型</param>
	/// <param name="validators">目标参数验证</param>
	/// <param name="overwrite">新旧覆盖 - 获得同个目标时，如果参数不一致，且此值为真时，覆盖之前的目标  (为true时同类目标只会存在一个)</param>
	/// <param name="createGoalImpl">创建目标逻辑实现</param>
	/// <param name="recreateEveryMonth">创建逻辑重复检测 - 只对当务之急生效.该项为true时，每月都会重新试图创建,创建失败表示已失效, 将直接移除</param>
	public PlanningGoalItem(int templateId, string name, bool hideInUI, int duration, short basePriority, short[] moralityPriority, bool isPrioritizedGoal, int maxPlanningDepth, int[] conflictActions, StateConditionAndValue<StateKey>[] addConditions, StateConditionAndValue<StateKey>[] preconditions, StateConditionAndValue<StateKey>[] targetCharacterConditionsA, StateConditionAndValue<StateKey>[] targetCharacterConditionsB, StateConditionAndValue<StateKey>[] targetCharacterConditionsC, sbyte[] parameters, EPlanningGoalValidator[] validators, bool overwrite, string createGoalImpl, bool recreateEveryMonth)
	{
		TemplateId = templateId;
		Name = name;
		HideInUI = hideInUI;
		Duration = duration;
		BasePriority = basePriority;
		MoralityPriority = moralityPriority;
		IsPrioritizedGoal = isPrioritizedGoal;
		MaxPlanningDepth = maxPlanningDepth;
		ConflictActions = conflictActions;
		AddConditions = addConditions;
		Preconditions = preconditions;
		TargetCharacterConditionsA = targetCharacterConditionsA;
		TargetCharacterConditionsB = targetCharacterConditionsB;
		TargetCharacterConditionsC = targetCharacterConditionsC;
		Parameters = parameters;
		Validators = validators;
		Overwrite = overwrite;
		CreateGoalImpl = createGoalImpl;
		RecreateEveryMonth = recreateEveryMonth;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public PlanningGoalItem()
	{
		TemplateId = 0;
		Name = null;
		HideInUI = false;
		Duration = -1;
		BasePriority = 0;
		MoralityPriority = new short[5];
		IsPrioritizedGoal = false;
		MaxPlanningDepth = 3;
		ConflictActions = new int[0];
		AddConditions = null;
		Preconditions = new StateConditionAndValue<StateKey>[0];
		TargetCharacterConditionsA = new StateConditionAndValue<StateKey>[0];
		TargetCharacterConditionsB = new StateConditionAndValue<StateKey>[0];
		TargetCharacterConditionsC = new StateConditionAndValue<StateKey>[0];
		Parameters = null;
		Validators = null;
		Overwrite = false;
		CreateGoalImpl = null;
		RecreateEveryMonth = false;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public PlanningGoalItem(int templateId, PlanningGoalItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		HideInUI = other.HideInUI;
		Duration = other.Duration;
		BasePriority = other.BasePriority;
		MoralityPriority = other.MoralityPriority;
		IsPrioritizedGoal = other.IsPrioritizedGoal;
		MaxPlanningDepth = other.MaxPlanningDepth;
		ConflictActions = other.ConflictActions;
		AddConditions = other.AddConditions;
		Preconditions = other.Preconditions;
		TargetCharacterConditionsA = other.TargetCharacterConditionsA;
		TargetCharacterConditionsB = other.TargetCharacterConditionsB;
		TargetCharacterConditionsC = other.TargetCharacterConditionsC;
		Parameters = other.Parameters;
		Validators = other.Validators;
		Overwrite = other.Overwrite;
		CreateGoalImpl = other.CreateGoalImpl;
		RecreateEveryMonth = other.RecreateEveryMonth;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override PlanningGoalItem Duplicate(int templateId)
	{
		return new PlanningGoalItem(templateId, this);
	}
}

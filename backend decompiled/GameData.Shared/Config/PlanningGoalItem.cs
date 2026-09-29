using System;
using Config.Common;
using GameData.ActionPlanning.MonthlyAI;
using GameData.ActionPlanning.State;

namespace Config;

[Serializable]
public class PlanningGoalItem : ConfigItem<PlanningGoalItem, int>
{
	public readonly int TemplateId;

	public readonly string Name;

	public readonly bool HideInUI;

	public readonly int Duration;

	public readonly short BasePriority;

	public readonly short[] MoralityPriority;

	public readonly bool IsPrioritizedGoal;

	public readonly int MaxPlanningDepth;

	public readonly int[] ConflictActions;

	public readonly StateConditionAndValue<StateKey>[] AddConditions;

	public readonly StateConditionAndValue<StateKey>[] Preconditions;

	public readonly StateConditionAndValue<StateKey>[] TargetCharacterConditionsA;

	public readonly StateConditionAndValue<StateKey>[] TargetCharacterConditionsB;

	public readonly StateConditionAndValue<StateKey>[] TargetCharacterConditionsC;

	public readonly sbyte[] Parameters;

	public readonly EPlanningGoalValidator[] Validators;

	public readonly bool Overwrite;

	public readonly string CreateGoalImpl;

	public readonly bool RecreateEveryMonth;

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

	public override PlanningGoalItem Duplicate(int templateId)
	{
		return new PlanningGoalItem(templateId, this);
	}
}

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
	public readonly int TemplateId;

	public readonly string ImplementationPath;

	public readonly sbyte[] Parameters;

	public readonly int[] BehaviorTypeWeights;

	public readonly int[] PersonalityWeights;

	public readonly sbyte PersonalityType;

	public readonly int[] ProfessionRequirement;

	public readonly short[] RequiredOrgMembers;

	public readonly bool IsAdultOnly;

	public readonly bool IsNonTaiwuTeammate;

	public readonly bool IsNonMonk;

	public readonly int LoafChance;

	public readonly bool AllowMove;

	public readonly int ActionPointCost;

	public readonly StateConditionAndValue<StateKey>[] SelfRestrictions;

	public readonly StateConditionAndValue<StateKey>[] Preconditions;

	public readonly StateConditionAndValue<StateKey>[] TargetCharacterConditions;

	public readonly StateEffect<StateKey>[] Effects;

	public readonly StateEffect<StateKey>[] DeEffects;

	public readonly EPlanningActionCharacterSelectCountType CharacterSelectCountType;

	public readonly int[] CharacterSelectCountRange;

	public readonly EPlanningActionCharacterSelector CharacterSelector;

	public readonly int SelectTaiwuChance;

	public readonly EPlanningActionCharacterSelectRange CharacterSelectRange;

	public readonly int SelectRangeValue;

	public readonly string RefuseAppointment;

	public readonly short MonthlyNotification;

	public readonly short ExecuteSelfLifeRecord;

	public readonly short ExecuteTargetLifeRecord;

	public readonly int ExpChange;

	public readonly int HappinessChange;

	public readonly short FavorabilityChange;

	public readonly int AuthorityChange;

	public readonly int XiangshuInfectionChange;

	public readonly List<PresetInventoryItem> RandomItemRewards;

	public readonly short SelfMatcher;

	public readonly short TargetMatcher;

	public readonly int Cooldown;

	public readonly sbyte CombatType;

	public readonly int KillBaseChance;

	public readonly int KidnapBaseChance;

	public readonly int ReleaseBaseChance;

	public PlanningActionItem(int templateId, string implementationPath, sbyte[] parameters, int[] behaviorTypeWeights, int[] personalityWeights, sbyte personalityType, int[] professionRequirement, short[] requiredOrgMembers, bool isAdultOnly, bool isNonTaiwuTeammate, bool isNonMonk, int loafChance, bool allowMove, int actionPointCost, StateConditionAndValue<StateKey>[] selfRestrictions, StateConditionAndValue<StateKey>[] preconditions, StateConditionAndValue<StateKey>[] targetCharacterConditions, StateEffect<StateKey>[] effects, StateEffect<StateKey>[] deEffects, EPlanningActionCharacterSelectCountType characterSelectCountType, int[] characterSelectCountRange, EPlanningActionCharacterSelector characterSelector, int selectTaiwuChance, EPlanningActionCharacterSelectRange characterSelectRange, int selectRangeValue, string refuseAppointment, short monthlyNotification, short executeSelfLifeRecord, short executeTargetLifeRecord, int expChange, int happinessChange, short favorabilityChange, int authorityChange, int xiangshuInfectionChange, List<PresetInventoryItem> randomItemRewards, short selfMatcher, short targetMatcher, int cooldown, sbyte combatType, int killBaseChance, int kidnapBaseChance, int releaseBaseChance)
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
		XiangshuInfectionChange = xiangshuInfectionChange;
		RandomItemRewards = randomItemRewards;
		SelfMatcher = selfMatcher;
		TargetMatcher = targetMatcher;
		Cooldown = cooldown;
		CombatType = combatType;
		KillBaseChance = killBaseChance;
		KidnapBaseChance = kidnapBaseChance;
		ReleaseBaseChance = releaseBaseChance;
	}

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
		XiangshuInfectionChange = 0;
		RandomItemRewards = new List<PresetInventoryItem>();
		SelfMatcher = 82;
		TargetMatcher = 82;
		Cooldown = 2;
		CombatType = 1;
		KillBaseChance = 0;
		KidnapBaseChance = 0;
		ReleaseBaseChance = 100;
	}

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
		XiangshuInfectionChange = other.XiangshuInfectionChange;
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

	public override PlanningActionItem Duplicate(int templateId)
	{
		return new PlanningActionItem(templateId, this);
	}
}

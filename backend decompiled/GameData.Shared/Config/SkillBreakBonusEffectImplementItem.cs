using System;
using Config.Common;

namespace Config;

[Serializable]
public class SkillBreakBonusEffectImplementItem : ConfigItem<SkillBreakBonusEffectImplementItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly sbyte AddRequirementType;

	public readonly sbyte ReduceCostBreathType;

	public readonly sbyte ReduceCostStanceType;

	public readonly sbyte ReduceCastFrameType;

	public readonly sbyte AddMaxPowerType;

	public readonly bool AddInjuryStep;

	public readonly bool AddFatalStep;

	public readonly bool AddMindStep;

	public readonly int PoisonResistFactor;

	public readonly int PenetrateFactor;

	public readonly int PenetrateResistFactor;

	public readonly int HitFactor;

	public readonly int AvoidFactor;

	public readonly int SubAttributeFactor;

	public readonly bool AddMainAttribute;

	public readonly bool AddHitAvoidStrength;

	public readonly bool AddHitAvoidTechnique;

	public readonly bool AddHitAvoidSpeed;

	public readonly bool AddHitAvoidMind;

	public readonly bool RelationAddHitMind;

	public readonly bool RelationAddAvoidMind;

	public readonly bool ReduceRequirements;

	public readonly bool AddPower;

	public readonly bool InnerRatioChangeRange;

	public readonly sbyte[] SpecificGrids;

	public readonly sbyte AddMaxPowerEquipType;

	public readonly int TotalObtainableNeili;

	public readonly bool AttackRangeForward;

	public readonly bool AttackRangeBackward;

	public readonly bool MakeDamage;

	public readonly bool AttackSkillHitFactor;

	public readonly bool PoisonFactor;

	public readonly bool CostMobilityByFrame;

	public readonly bool CostMobilityByMove;

	public readonly int CostMobilityByCastFactor;

	public readonly bool AgileSkillHitFactor;

	public readonly bool FightBackPower;

	public readonly bool BouncePower;

	public readonly bool DefensePenetrateResistFactor;

	public readonly bool DefenseAvoidFactor;

	public SkillBreakBonusEffectImplementItem(sbyte templateId, sbyte addRequirementType, sbyte reduceCostBreathType, sbyte reduceCostStanceType, sbyte reduceCastFrameType, sbyte addMaxPowerType, bool addInjuryStep, bool addFatalStep, bool addMindStep, int poisonResistFactor, int penetrateFactor, int penetrateResistFactor, int hitFactor, int avoidFactor, int subAttributeFactor, bool addMainAttribute, bool addHitAvoidStrength, bool addHitAvoidTechnique, bool addHitAvoidSpeed, bool addHitAvoidMind, bool relationAddHitMind, bool relationAddAvoidMind, bool reduceRequirements, bool addPower, bool innerRatioChangeRange, sbyte[] specificGrids, sbyte addMaxPowerEquipType, int totalObtainableNeili, bool attackRangeForward, bool attackRangeBackward, bool makeDamage, bool attackSkillHitFactor, bool poisonFactor, bool costMobilityByFrame, bool costMobilityByMove, int costMobilityByCastFactor, bool agileSkillHitFactor, bool fightBackPower, bool bouncePower, bool defensePenetrateResistFactor, bool defenseAvoidFactor)
	{
		TemplateId = templateId;
		AddRequirementType = addRequirementType;
		ReduceCostBreathType = reduceCostBreathType;
		ReduceCostStanceType = reduceCostStanceType;
		ReduceCastFrameType = reduceCastFrameType;
		AddMaxPowerType = addMaxPowerType;
		AddInjuryStep = addInjuryStep;
		AddFatalStep = addFatalStep;
		AddMindStep = addMindStep;
		PoisonResistFactor = poisonResistFactor;
		PenetrateFactor = penetrateFactor;
		PenetrateResistFactor = penetrateResistFactor;
		HitFactor = hitFactor;
		AvoidFactor = avoidFactor;
		SubAttributeFactor = subAttributeFactor;
		AddMainAttribute = addMainAttribute;
		AddHitAvoidStrength = addHitAvoidStrength;
		AddHitAvoidTechnique = addHitAvoidTechnique;
		AddHitAvoidSpeed = addHitAvoidSpeed;
		AddHitAvoidMind = addHitAvoidMind;
		RelationAddHitMind = relationAddHitMind;
		RelationAddAvoidMind = relationAddAvoidMind;
		ReduceRequirements = reduceRequirements;
		AddPower = addPower;
		InnerRatioChangeRange = innerRatioChangeRange;
		SpecificGrids = specificGrids;
		AddMaxPowerEquipType = addMaxPowerEquipType;
		TotalObtainableNeili = totalObtainableNeili;
		AttackRangeForward = attackRangeForward;
		AttackRangeBackward = attackRangeBackward;
		MakeDamage = makeDamage;
		AttackSkillHitFactor = attackSkillHitFactor;
		PoisonFactor = poisonFactor;
		CostMobilityByFrame = costMobilityByFrame;
		CostMobilityByMove = costMobilityByMove;
		CostMobilityByCastFactor = costMobilityByCastFactor;
		AgileSkillHitFactor = agileSkillHitFactor;
		FightBackPower = fightBackPower;
		BouncePower = bouncePower;
		DefensePenetrateResistFactor = defensePenetrateResistFactor;
		DefenseAvoidFactor = defenseAvoidFactor;
	}

	public SkillBreakBonusEffectImplementItem()
	{
		TemplateId = 0;
		AddRequirementType = 0;
		ReduceCostBreathType = 0;
		ReduceCostStanceType = 0;
		ReduceCastFrameType = 0;
		AddMaxPowerType = 0;
		AddInjuryStep = false;
		AddFatalStep = false;
		AddMindStep = false;
		PoisonResistFactor = 0;
		PenetrateFactor = 0;
		PenetrateResistFactor = 0;
		HitFactor = 0;
		AvoidFactor = 0;
		SubAttributeFactor = 0;
		AddMainAttribute = false;
		AddHitAvoidStrength = false;
		AddHitAvoidTechnique = false;
		AddHitAvoidSpeed = false;
		AddHitAvoidMind = false;
		RelationAddHitMind = false;
		RelationAddAvoidMind = false;
		ReduceRequirements = false;
		AddPower = false;
		InnerRatioChangeRange = false;
		SpecificGrids = new sbyte[4];
		AddMaxPowerEquipType = -1;
		TotalObtainableNeili = 0;
		AttackRangeForward = false;
		AttackRangeBackward = false;
		MakeDamage = false;
		AttackSkillHitFactor = false;
		PoisonFactor = false;
		CostMobilityByFrame = false;
		CostMobilityByMove = false;
		CostMobilityByCastFactor = 0;
		AgileSkillHitFactor = false;
		FightBackPower = false;
		BouncePower = false;
		DefensePenetrateResistFactor = false;
		DefenseAvoidFactor = false;
	}

	public SkillBreakBonusEffectImplementItem(sbyte templateId, SkillBreakBonusEffectImplementItem other)
	{
		TemplateId = templateId;
		AddRequirementType = other.AddRequirementType;
		ReduceCostBreathType = other.ReduceCostBreathType;
		ReduceCostStanceType = other.ReduceCostStanceType;
		ReduceCastFrameType = other.ReduceCastFrameType;
		AddMaxPowerType = other.AddMaxPowerType;
		AddInjuryStep = other.AddInjuryStep;
		AddFatalStep = other.AddFatalStep;
		AddMindStep = other.AddMindStep;
		PoisonResistFactor = other.PoisonResistFactor;
		PenetrateFactor = other.PenetrateFactor;
		PenetrateResistFactor = other.PenetrateResistFactor;
		HitFactor = other.HitFactor;
		AvoidFactor = other.AvoidFactor;
		SubAttributeFactor = other.SubAttributeFactor;
		AddMainAttribute = other.AddMainAttribute;
		AddHitAvoidStrength = other.AddHitAvoidStrength;
		AddHitAvoidTechnique = other.AddHitAvoidTechnique;
		AddHitAvoidSpeed = other.AddHitAvoidSpeed;
		AddHitAvoidMind = other.AddHitAvoidMind;
		RelationAddHitMind = other.RelationAddHitMind;
		RelationAddAvoidMind = other.RelationAddAvoidMind;
		ReduceRequirements = other.ReduceRequirements;
		AddPower = other.AddPower;
		InnerRatioChangeRange = other.InnerRatioChangeRange;
		SpecificGrids = other.SpecificGrids;
		AddMaxPowerEquipType = other.AddMaxPowerEquipType;
		TotalObtainableNeili = other.TotalObtainableNeili;
		AttackRangeForward = other.AttackRangeForward;
		AttackRangeBackward = other.AttackRangeBackward;
		MakeDamage = other.MakeDamage;
		AttackSkillHitFactor = other.AttackSkillHitFactor;
		PoisonFactor = other.PoisonFactor;
		CostMobilityByFrame = other.CostMobilityByFrame;
		CostMobilityByMove = other.CostMobilityByMove;
		CostMobilityByCastFactor = other.CostMobilityByCastFactor;
		AgileSkillHitFactor = other.AgileSkillHitFactor;
		FightBackPower = other.FightBackPower;
		BouncePower = other.BouncePower;
		DefensePenetrateResistFactor = other.DefensePenetrateResistFactor;
		DefenseAvoidFactor = other.DefenseAvoidFactor;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override SkillBreakBonusEffectImplementItem Duplicate(int templateId)
	{
		return new SkillBreakBonusEffectImplementItem((sbyte)templateId, this);
	}
}

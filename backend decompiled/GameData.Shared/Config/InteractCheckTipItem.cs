using System;
using Config.Common;

namespace Config;

[Serializable]
public class InteractCheckTipItem : ConfigItem<InteractCheckTipItem, short>
{
	public readonly short TemplateId;

	public readonly string PhaseName;

	public readonly string PhaseDesc;

	public readonly string PhaseIcon;

	public readonly string CheckDesc;

	public readonly short SelfCheckCharacterProperty;

	public readonly short TargetCheckCharacterProperty;

	public readonly sbyte SelfCheckAttainmentCombatSkillType;

	public readonly sbyte TargetCheckAttainmentCombatSkillType;

	public readonly sbyte SelfCheckAttainmentLifeSkillType;

	public readonly sbyte TargetCheckAttainmentLifeSkillType;

	public readonly EInteractCheckTipSpecialValueDisplayType SpecialValueDisplayType;

	public readonly string CheckResultProb;

	public readonly EInteractCheckTipConfessionLoveFactorType ConfessionLoveFactorType;

	public readonly string[] FactorDesc;

	public readonly EInteractCheckTipSpecialLineDisplayType SpecialLineDisplayType;

	public InteractCheckTipItem(short templateId, string phaseName, string phaseDesc, string phaseIcon, string checkDesc, short selfCheckCharacterProperty, short targetCheckCharacterProperty, sbyte selfCheckAttainmentCombatSkillType, sbyte targetCheckAttainmentCombatSkillType, sbyte selfCheckAttainmentLifeSkillType, sbyte targetCheckAttainmentLifeSkillType, EInteractCheckTipSpecialValueDisplayType specialValueDisplayType, string checkResultProb, EInteractCheckTipConfessionLoveFactorType confessionLoveFactorType, string[] factorDesc, EInteractCheckTipSpecialLineDisplayType specialLineDisplayType)
	{
		TemplateId = templateId;
		PhaseName = phaseName;
		PhaseDesc = phaseDesc;
		PhaseIcon = phaseIcon;
		CheckDesc = checkDesc;
		SelfCheckCharacterProperty = selfCheckCharacterProperty;
		TargetCheckCharacterProperty = targetCheckCharacterProperty;
		SelfCheckAttainmentCombatSkillType = selfCheckAttainmentCombatSkillType;
		TargetCheckAttainmentCombatSkillType = targetCheckAttainmentCombatSkillType;
		SelfCheckAttainmentLifeSkillType = selfCheckAttainmentLifeSkillType;
		TargetCheckAttainmentLifeSkillType = targetCheckAttainmentLifeSkillType;
		SpecialValueDisplayType = specialValueDisplayType;
		CheckResultProb = checkResultProb;
		ConfessionLoveFactorType = confessionLoveFactorType;
		FactorDesc = factorDesc;
		SpecialLineDisplayType = specialLineDisplayType;
	}

	public InteractCheckTipItem()
	{
		TemplateId = 0;
		PhaseName = null;
		PhaseDesc = null;
		PhaseIcon = null;
		CheckDesc = null;
		SelfCheckCharacterProperty = 0;
		TargetCheckCharacterProperty = 0;
		SelfCheckAttainmentCombatSkillType = 0;
		TargetCheckAttainmentCombatSkillType = 0;
		SelfCheckAttainmentLifeSkillType = 0;
		TargetCheckAttainmentLifeSkillType = 0;
		SpecialValueDisplayType = EInteractCheckTipSpecialValueDisplayType.Invalid;
		CheckResultProb = null;
		ConfessionLoveFactorType = EInteractCheckTipConfessionLoveFactorType.Invalid;
		FactorDesc = null;
		SpecialLineDisplayType = EInteractCheckTipSpecialLineDisplayType.Invalid;
	}

	public InteractCheckTipItem(short templateId, InteractCheckTipItem other)
	{
		TemplateId = templateId;
		PhaseName = other.PhaseName;
		PhaseDesc = other.PhaseDesc;
		PhaseIcon = other.PhaseIcon;
		CheckDesc = other.CheckDesc;
		SelfCheckCharacterProperty = other.SelfCheckCharacterProperty;
		TargetCheckCharacterProperty = other.TargetCheckCharacterProperty;
		SelfCheckAttainmentCombatSkillType = other.SelfCheckAttainmentCombatSkillType;
		TargetCheckAttainmentCombatSkillType = other.TargetCheckAttainmentCombatSkillType;
		SelfCheckAttainmentLifeSkillType = other.SelfCheckAttainmentLifeSkillType;
		TargetCheckAttainmentLifeSkillType = other.TargetCheckAttainmentLifeSkillType;
		SpecialValueDisplayType = other.SpecialValueDisplayType;
		CheckResultProb = other.CheckResultProb;
		ConfessionLoveFactorType = other.ConfessionLoveFactorType;
		FactorDesc = other.FactorDesc;
		SpecialLineDisplayType = other.SpecialLineDisplayType;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override InteractCheckTipItem Duplicate(int templateId)
	{
		return new InteractCheckTipItem((short)templateId, this);
	}
}
